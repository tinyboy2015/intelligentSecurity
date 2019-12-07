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
    public sealed class BOBaseInfo
    {
        private DataBase dbop = new DataBase();
        BasicOp biz = new BasicOp();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BOBaseInfo Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BOBaseInfo>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BOBaseInfo() { }

        #endregion

        #region Public methods

       
        public DataTable GetBaseInfoType(Dictionary<string, string> aWhere)
        {
            string sql = "SELECT * FROM S_DROPDOWNLIST order by dd_order asc ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public DataTable GetBaseItemList(string Code)
        {
            string sql = "SELECT * FROM S_DROPDOWNLIST_ITEMS where ddi_ddID='" + Code + "' order by ddi_order asc ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public DataTable GetBaseItemList(string Code,string dvalue)
        {
            string sql = "SELECT * FROM S_DROPDOWNLIST_ITEMS where ddi_ddID='" + Code + "' and ddi_value='"+ dvalue + "' order by ddi_order asc ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public DataTable Get(string uID)
        {
            return dbop.GetDataSet("select * from S_DROPDOWNLIST_ITEMS where  ddi_seq = " + uID).Tables[0];
        }

        public bool Del(string uID, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                if (!S_DROPDOWNLIST_ITEMS.Delete(dbop, int.Parse(uID))) goto lbl_error;
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
                S_DROPDOWNLIST_ITEMS u = dbInfo["ddi_seq"] == "" ? new S_DROPDOWNLIST_ITEMS(dbop) : new S_DROPDOWNLIST_ITEMS(dbop, Convert.ToInt32(dbInfo["ddi_seq"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.ddi_seq == null)
                {                    
                    if (!u.Add()) goto lbl_error;
                }
                else
                {                   
                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["ddi_seq"] = u.ddi_seq.ToString();
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
