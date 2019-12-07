using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Taih.MessageBus;

namespace SendTransportService
{
    public class TransportServiceMainTran
    {
        private const byte STD = 0x21; // 帧开始
        private const byte END = 0xBB;  //帧结束
      
        private const int iMaxDataLen = 500;
        int nReadPos;
        private ArrayList _msgs = new ArrayList();
        private MemoryStream _InStream = new MemoryStream();

        public Message[] Decode(byte[] buffer, int offset, int count)
        {
            _InStream.Seek(0, SeekOrigin.End);
            _InStream.Write(buffer, offset, count);
            bool CheckLength = true;
            if ((_InStream.Length > 0) && CheckLength)//如果有数据
            {
                byte[] buff = _InStream.ToArray();
                int nBegin = 0;
                int nEnd = 0;
                bool CheckBegin = false;
                nReadPos = 0;
                while ((nReadPos < buff.Length) && CheckLength)
                {
                    if (CheckBegin == false)
                    {
                        if (buff[nReadPos] == STD)
                        {
                            nBegin = nReadPos;
                            CheckBegin = true;
                        }
                        else
                        {
                            nReadPos++;
                        }
                    }
                    else
                    {
                        //判断剩余长度
                        if (((buff.Length - nReadPos) >= 6) && ((buff.Length - nReadPos) >= (6 + ((buff[nReadPos + 1] << 8) + buff[nReadPos + 2]))) && CheckBegin)
                        {
                            nEnd = nReadPos + 4 + ((buff[nReadPos + 1] << 8) + buff[nReadPos + 2]);
                            if (buff[nEnd] == 0xBB || buff[1000] == 0xBB)//判断结束符
                            {
                                MemoryStream ts = new MemoryStream();
                                ts.Write(buff, nReadPos, nEnd - nReadPos + 2);
                                byte[] tbuff = ts.ToArray();

                                if ((XOR(tbuff, 1, (int)(4 + ((buff[nReadPos + 1] << 8) + buff[nReadPos + 2]))) == buff[5 + ((buff[nReadPos + 1] << 8) + buff[nReadPos + 2])]) || buff[1001] == 0xCC)//判断校验和
                                {
                                    switch (buff[nReadPos + 3])
                                    {
                                        case CmdSocketType.HEARTBEAT:
                                        case CmdSocketType.ANSWER_HEARTBEAT:
                                        case CmdSocketType.DATA_INFO:
                                        case CmdSocketType.DATA_INFOBACK:
                                       
                                        default:
                                            break;
                                    }
                                    nReadPos = nEnd + 2;
                                    CheckBegin = false;
                                }
                                else
                                {
                                    nReadPos = nBegin + 1;
                                    CheckBegin = false;
                                }
                            }
                            else
                            {
                                nReadPos = nBegin + 1;
                                CheckBegin = false;
                            }
                        }
                        //长度不够
                        else
                        {
                            CheckLength = false;
                        }
                    }
                }
                _InStream.SetLength(0);
                _InStream.Write(buff, nReadPos, buff.Length - nReadPos);
                CheckLength = false;
            }
            else
            {
                _InStream.SetLength(0);
            }

            if (_msgs.Count > 0)
            {
                Message[] msgs = new Message[_msgs.Count];
                _msgs.CopyTo(msgs, 0);
                _msgs.Clear();
                return msgs;
            }
            else
            {
                return Message.EmptyArray;
            }
        }
             

        #region 数据发送

        /// <summary>
        /// 发送消息编码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte[] Encode2Bytes(Message message)
        {
            try
            {
                if (message == null)
                    return null;

                int iCmdType = message.GetInt32("CmdType");

                switch (iCmdType)
                {
                    case (int)CmdSocketType.HEARTBEAT:
                        return GetBaseMessage(CmdSocketType.HEARTBEAT);
                    case (int)CmdSocketType.ANSWER_HEARTBEAT:
                        return GetBaseMessage(CmdSocketType.ANSWER_HEARTBEAT);
                    case (int)CmdSocketType.DATA_INFO:
                        return null;
                    case (int)CmdSocketType.DATA_INFOBACK:
                        return null;
                 
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }


        /// <summary>
        /// 发送报警数据
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] GetBJInfo(Message message)
        {
            int n = 0;
            byte[] data = new byte[30000];
            try
            {
               
                return data;
            }
            catch
            {
                return null;
            }
        }


      


        /// <summary>
        /// 发送的波形信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] GetBxInfo(Message message)
        {
             return null;
           
        }

        /// <summary>
        /// 发送的数据信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] GetDataInfoAnswer(Message message)
        {
            byte[] data = new byte[13];

            int n = 0;

            try
            {
                data[n++] = STD;                                            //帧开始标志
                                                                            //DATA域的长度
                HostToNetworkOrder(data, n, 7, 2);
                n += 2;
                data[n++] = (byte)CmdSocketType.DATA_INFO;                  //命令头

                #region  DATA 发送数据


                DateTime dRecvTime = message.GetDateTime("RecvTime");

                int iYear = dRecvTime.Year;                             //年
                HostToNetworkOrder(data, n, iYear, 2);
                n += 2;

                int iMonth = dRecvTime.Month;                           //月
                data[n++] = (byte)iMonth;

                int iDay = dRecvTime.Day;                               //日
                data[n++] = (byte)iDay;

                int iHour = dRecvTime.Hour;                             //时
                data[n++] = (byte)iHour;

                int iMinute = dRecvTime.Minute;                         //分
                data[n++] = (byte)iMinute;

                int iSecond = dRecvTime.Second;                         //秒
                data[n++] = (byte)iSecond;

                #endregion

                data[n++] = END;        //帧结束标志
                                        //异或校验值
                byte code = XOR(data, 1, n - 1);
                data[n++] = code;

                return data;
            }
            catch
            {
                return null;
            }
        }




        /// <summary>
        /// 拼接通用信息
        /// </summary>
        /// <returns></returns>
        private byte[] GetBaseMessage(byte cmdType)
        {
            int n = 0;
            byte[] data = new byte[1024];
            try
            {
                data[n++] = STD;                            //帧开始标志
                data[n++] = 0;                              //DATA域的长度
                data[n++] = 0;
                data[n++] = cmdType;    //命令头

                data[n++] = END;                            //帧结束标志
                                                            //异或校验值
                byte code = XOR(data, 1, n - 1);
                data[n++] = code;
                return data;
            }
            catch
            {
                return null;
            }
        }


        private bool IsMatch(byte[] data)
        {
            int dataLen = data.Length;
            if (dataLen < 5)
            {
                return false;
            }

            if (data[0] != STD)
            {
                return false;
            }
            //验证CMD名称
            if (data[3] != CmdSocketType.HEARTBEAT && data[3] != CmdSocketType.DATA_INFO && data[3] != CmdSocketType.DATA_INFOBACK && data[3] != CmdSocketType.ANSWER_HEARTBEAT )
            {
                return false;
            }

            int length = (data[1] << 8) + data[2];
            if (length > (dataLen - 5)) // 包不完整
            {
                return false;
            }

            //校验失败
            if (XOR(data, 1, length + 3) != data[4 + length])
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bData">数据源</param>
        /// <param name="statrIndex">开始索引</param>
        /// <param name="iDataLen">数据长度</param>
        /// <returns>转化后结果</returns>
        private int NetworkToHostOrder(byte[] bData, int statrIndex, int iDataLen)
        {
            int iHostRet = 0;
            try
            {
                byte[] pRet = new byte[iDataLen];
                Array.Copy(bData, statrIndex, pRet, 0, pRet.Length);
                switch (iDataLen)
                {
                    case 2:
                        iHostRet = System.Net.IPAddress.NetworkToHostOrder(BitConverter.ToInt16(pRet, 0));
                        break;
                    case 4:
                        iHostRet = System.Net.IPAddress.NetworkToHostOrder(BitConverter.ToInt32(pRet, 0));
                        break;
                    default:
                        iHostRet = 0;
                        break;
                }
            }
            catch
            {
                return iHostRet;
            }
            return iHostRet;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="desByte"></param>
        /// <param name="iStatrIndex"></param>
        /// <param name="data"></param>
        /// <param name="iDataLen"></param>
        private void HostToNetworkOrder(byte[] desByte, int iStatrIndex, Int32 data, int iDataLen)
        {
            byte[] bDataLen;
            switch (iDataLen)
            {
                case 2:
                    bDataLen = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder((Int16)data));
                    desByte[iStatrIndex] = bDataLen[0];
                    desByte[iStatrIndex + 1] = bDataLen[1];
                    break;
                case 4:
                    bDataLen = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder((Int32)data));
                    desByte[iStatrIndex] = bDataLen[0];
                    desByte[iStatrIndex + 1] = bDataLen[1];
                    desByte[iStatrIndex + 2] = bDataLen[2];
                    desByte[iStatrIndex + 3] = bDataLen[3];
                    break;
            }
        }

        private byte XOR(byte[] data, int offset, int count)
        {
            byte rt = 0;
            for (int i = offset; i < offset + count; i++)
            {
                rt ^= data[i];
            }
            return rt;
        }

        #endregion
    }

    /// <summary>
    /// USDECmdType 的摘要说明。
    /// </summary>
    public class CmdSocketType
    {
        /// <summary>
        /// 连接主机。
        /// </summary>
        public const byte HEARTBEAT = 0xA0;

        /// <summary>
        /// 客户端回复心跳数据确认信息给服务器端
        /// </summary>
        public const byte ANSWER_HEARTBEAT = 0xB0;

        /// <summary>
        /// 服务器发送数据给客户端
        /// </summary>
        public const byte DATA_INFO = 0xA1;

        /// <summary>
        /// 客户端发送信息给服务器
        /// </summary>
        public const byte DATA_INFOBACK = 0xA2;


    }
}
