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
    public sealed class BOUserInfo
    {
        private DataBase dbop = new DataBase();
        BasicOp biz = new BasicOp();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BOUserInfo Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BOUserInfo>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BOUserInfo() { }

        #endregion

        #region Public methods

        


        public DataTable GetSearchSql(Dictionary<string, string> aWhere)
        {
            string sql = "SELECT * FROM S_USER_INFO  where 1=1 ";
            //if (aWhere.ContainsKey("User_id") && !string.IsNullOrEmpty(aWhere["User_id"]))
            //{
            //    sql += " and User_id='" + aWhere["User_id"] + "'";
            //}
            //if (aWhere.ContainsKey("User_passwd") && !string.IsNullOrEmpty(aWhere["User_passwd"]))
            //{
            //    sql += " and User_passwd='" + biz.EncryptPassword(aWhere["User_passwd"], "MD5") + "'";
            //}
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
           

        }
        public DataTable Get(string uID)
        {
            return dbop.GetDataSet("select * from S_USER_INFO where  User_seq = " + uID).Tables[0];
        }

        public bool Del(string uID, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                if (!S_USER_INFO.Delete(dbop, int.Parse(uID))) goto lbl_error;
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

        public bool Save(Dictionary<string, string> dbInfo,string Agroup, out string sError)
        {
            sError = "";
            string sql = "";
            dbop.BeginTrans();
            try
            {
                S_USER_INFO u = dbInfo["User_seq"] == "" ? new S_USER_INFO(dbop) : new S_USER_INFO(dbop, Convert.ToInt32(dbInfo["User_seq"]));
                CollectProperty.getPropertyFromDictionary(u, dbInfo);
                if (u.User_seq == null)
                {
                    u.User_passwd = biz.EncryptPassword(dbInfo["User_passwd"], "MD5");
                    if (!u.Add()) goto lbl_error;
                }
                else
                {
                    //if (dbInfo["passwdChanged"] == "Y")
                    //{
                        u.User_passwd = biz.EncryptPassword(dbInfo["User_passwd"], "MD5");
                    //}
                    if (!u.Update()) goto lbl_error;
                }
                dbop.CommitTrans();
                dbInfo["User_seq"] = u.User_seq.ToString();

               
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


        #region //权限管理
        public DataTable GetGroupList()
        {
            string sql = "SELECT * FROM S_GROUPS  where 1=1 ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public DataTable GetMenuList()
        {
            string sql = "SELECT * FROM S_TREEMENU  where is_leaf_module=1 and module_status=1 order by index_no asc ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public bool SetAuthentication(string GroupID,string Aid)
        {
            string sql = "DELETE FROM S_GROUPRIGHTS WHERE group_gro_id = "+GroupID;
            dbop.ExecNonQuery(sql);
            string[] sArray = Aid.Split(',');
            for (int i = 0; i < sArray.Length; i++)
            {
                if (biz.HandleNull(sArray[i],"") != "")
                {
                    S_GROUPRIGHTS sg = new S_GROUPRIGHTS(dbop);
                    sg.group_gro_id = Convert.ToInt32(GroupID);
                    sg.group_menu_id= Convert.ToInt32(sArray[i]);
                    sg.group_read = 1;
                    sg.group_edit = 1;
                    sg.group_print = 1;
                    sg.group_add = 1;
                    sg.group_del = 1;
                    sg.group_data = 1;
                    sg.Add();
                }
            }
            return true;
        }
        #endregion
    }
}
