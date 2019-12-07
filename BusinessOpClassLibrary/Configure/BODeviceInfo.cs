using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseOpClassLibrary;
using System.Diagnostics;
using System.Data;
using BasicTools;

namespace BusinessOpClassLibrary
{
    public sealed class BODeviceInfo
    {
        private DataBase dbop = new DataBase();
        BasicOp biz = new BasicOp();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BODeviceInfo Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BODeviceInfo>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BODeviceInfo() { }

        #endregion

        #region Public methods

       
        public DataTable GetSearchSql(Dictionary<string, string> aWhere)
        {
            string sql = "SELECT a.*,b.ddi_name,b.ddi_desc FROM S_DEVICE a , S_DROPDOWNLIST_ITEMS b where a.device_Type = b.ddi_value ";
            if (aWhere.ContainsKey("device_Type") && !string.IsNullOrEmpty(aWhere["device_Type"]))
            {
                sql += " and device_Type='" + aWhere["device_Type"] + "'";
            }
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;


        }
        public DataTable Get(string uID)
        {
            return dbop.GetDataSet("select * from S_DEVICE where  device_ID = " + uID).Tables[0];
        }

        public bool Del(string uID, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                if (!S_DEVICE.Delete(dbop, int.Parse(uID))) goto lbl_error;
                dbop.CommitTrans();
            }
            catch (Exception exp)
            {
                sError = exp.Message;
                goto lbl_error;
            }
            return true;
        lbl_error:
            sError = "操作失败！" + sError;
            dbop.RollbackTrans();
            return false;
        }

        public bool Save(Dictionary<string, string> dbInfo, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_DEVICE u = dbInfo["device_ID"] == "" ? new S_DEVICE(dbop) : new S_DEVICE(dbop, Convert.ToInt32(dbInfo["device_ID"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.device_ID == null)
                {
                   
                    if (!u.Add()) goto lbl_error;
                }
                else
                {
                
                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["device_ID"] = u.device_ID.ToString();
            }
            catch (Exception exp)
            {
                sError = exp.Message;
                goto lbl_error;
            }
            return true;
        lbl_error:
            sError = "操作失败！" + sError;
            dbop.RollbackTrans();
            return false;
        }

        #endregion


        #region  //设备配置管理
        public bool SaveDeviceInterface(Dictionary<string, string> dbInfo, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_DEVICE_INTERFACE u = dbInfo["DI_ID"] == "" ? new S_DEVICE_INTERFACE(dbop) : new S_DEVICE_INTERFACE(dbop, Convert.ToInt32(dbInfo["DI_ID"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.DI_ID == null)
                {

                    if (!u.Add()) goto lbl_error;
                }
                else
                {

                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["DI_ID"] = u.DI_ID.ToString();
            }
            catch (Exception exp)
            {
                sError = exp.Message;
                goto lbl_error;
            }
            return true;
        lbl_error:
            sError = "操作失败！" + sError;
            dbop.RollbackTrans();
            return false;
        }

        public bool DelDeviceInterfacePort(string DIP_PortID)
        {
            string sql = "DELETE FROM S_DEVICE_INTERFACE_PORT WHERE DIP_PortID = " + DIP_PortID;
            dbop.ExecNonQuery(sql);

            sql = "DELETE FROM S_DEVICE_INTERFACE_CAMERA WHERE DIC_NameID = " + DIP_PortID;
            dbop.ExecNonQuery(sql);
            return true;
        }

        public bool SetDeviceInterfacePort(string DIP_PortID, string td,string No)
        {
           
            string[] sArray = td.Split(',');
          
            S_DEVICE_INTERFACE_PORT sdip = new S_DEVICE_INTERFACE_PORT(dbop);

            sdip.DIP_PortID = DIP_PortID;
            sdip.DIP_NO = No;
            sdip.DIP_ZY =Convert.ToInt32(sArray[0].ToString());
            sdip.DIP_SX = Convert.ToInt32(sArray[1].ToString());
            sdip.DIP_XX = Convert.ToInt32(sArray[2].ToString());
            sdip.DIP_GYYZ = Convert.ToInt32(sArray[3].ToString());
            sdip.DIP_GLYZ = Convert.ToInt32(sArray[4].ToString());
            sdip.DIP_LXZS = Convert.ToInt32(sArray[5].ToString());
                        sdip.Add();
            return true;
        }


        public DataTable GetDeviceSettingList(string DI_DeviceID)
        {
            string sql = "select * from S_DEVICE_INTERFACE where DI_DeviceID='"+ DI_DeviceID + "'";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public DataTable GetDeviceSettingSetList(string DIP_PortID)
        {
            string sql = "select * from S_DEVICE_INTERFACE_PORT where DIP_PortID='" + DIP_PortID + "' order by DIP_ID asc";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public bool DelSet(string uID, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                if (!S_DEVICE_INTERFACE.Delete(dbop, int.Parse(uID))) goto lbl_error;
                dbop.CommitTrans();
            }
            catch (Exception exp)
            {
                sError = exp.Message;
                goto lbl_error;
            }
            return true;
        lbl_error:
            sError = "操作失败！" + sError;
            dbop.RollbackTrans();
            return false;
        }

        //摄像头
        public bool SetDeviceInterfaceCamera(Dictionary<string, string> dbInfo, out string sError)
        {

            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_DEVICE_INTERFACE_CAMERA u = dbInfo["DIC_ID"] == "" ? new S_DEVICE_INTERFACE_CAMERA(dbop) : new S_DEVICE_INTERFACE_CAMERA(dbop, Convert.ToInt32(dbInfo["DIC_ID"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.DIC_ID == null)
                {

                    if (!u.Add()) goto lbl_error;
                }
                else
                {

                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["DIC_ID"] = u.DIC_ID.ToString();
            }
            catch (Exception exp)
            {
                sError = exp.Message;
                goto lbl_error;
            }
            return true;
        lbl_error:
            sError = "操作失败！" + sError;
            dbop.RollbackTrans();
            return false;
        }

        public DataTable GetDeviceSettingSetCameraInfo(string DIC_NameID)
        {
            string sql = "select * from S_DEVICE_INTERFACE_CAMERA where DIC_NameID='" + DIC_NameID + "' order by DIC_ID asc";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }
        #endregion
    }
}
