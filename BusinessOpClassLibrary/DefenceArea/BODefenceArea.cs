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
    public sealed class BODefenceArea
    {
        private DataBase dbop = new DataBase();
        BasicOp biz = new BasicOp();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BODefenceArea Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BODefenceArea>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BODefenceArea() { }

        #endregion

        #region Public methods
     
        public DataTable GetSearchSql(Dictionary<string, string> aWhere)
        {
            string sql = "SELECT * FROM S_DefenceArea  where 1=1 ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;


        }
        public DataTable Get(string uID)
        {
            return dbop.GetDataSet("select * from S_DefenceArea where  DA_seq = " + uID).Tables[0];
        }

        public bool Del(string uID, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                if (!S_DefenceArea.Delete(dbop, int.Parse(uID))) goto lbl_error;
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

        public bool DelALL()
        {
            string sql = "DELETE FROM S_DefenceArea WHERE 1 = 1";
            if(dbop.ExecNonQuery(sql)>0)
            {
                return true;
            }
            return false;
        }

        public bool Save(Dictionary<string, string> dbInfo,out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_DefenceArea u = dbInfo["DA_seq"] == "" ? new S_DefenceArea(dbop) : new S_DefenceArea(dbop, Convert.ToInt32(dbInfo["DA_seq"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.DA_seq == null)
                {
                  
                    if (!u.Add()) goto lbl_error;
                }
                else
                {                   
                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["DA_seq"] = u.DA_seq.ToString();
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


        #region //防区联动设备
        public DataTable GetDefenceAreaDeviceBydDAID(string DA_SEQ)
        {
            string sql = "select * from S_DefenceArea_Device where DAD_DefenceAreaID="+DA_SEQ;
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public bool DelDefenceAreaDeviceBydDAID(string DA_SEQ)
        {
            string sql = "DELETE FROM S_DefenceArea_Device WHERE DAD_DefenceAreaID = "+DA_SEQ;
            if (dbop.ExecNonQuery(sql) > 0)
            {
                return true;
            }
            return false;
        }


        public bool SaveDefenceAreaDevice(Dictionary<string, string> dbInfo, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_DefenceArea_Device u = dbInfo["DAD_seq"] == "" ? new S_DefenceArea_Device(dbop) : new S_DefenceArea_Device(dbop, Convert.ToInt32(dbInfo["DAD_seq"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.DAD_seq == null)
                {

                    if (!u.Add()) goto lbl_error;
                }
                else
                {
                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["DAD_seq"] = u.DAD_seq.ToString();
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

    }
}
