using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using DatabaseOpClassLibrary;
using System.Data;
using BasicTools;

namespace BusinessOpClassLibrary
{
    public sealed class BOCompanyinfo
    {
        //引用数据库访问类
        private DataBase dbop = new DataBase();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BOCompanyinfo Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BOCompanyinfo>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BOCompanyinfo() { }

        //public static BOCompanyinfo Instance()
        //{
        //    BOCompanyinfo a_instance = new BOCompanyinfo();
        //    return a_instance;
        //}

        #endregion

        #region Public methods

        /// <summary>
        /// 公司信息维护
        /// </summary>
        public bool SaveCompanyInfo(Dictionary<string, string>[] dblist, out string sError)
        {
            sError = "";
            //json方法
            //S_COMPANY_INFO ci = JsonHelper.JsonDeserialize<S_COMPANY_INFO>(dblist["S_COMPANY_INFO"]);
            S_COMPANY_INFO ci;
            if (dblist[0]["Company_no"] == "")
            {
                ci = new S_COMPANY_INFO();
            }
            else
            {
                ci = new S_COMPANY_INFO(dbop, dblist[0]["Company_no"]);
            }
            CollectProperty.getPropertyFromDictionary(ci, dblist[0]);
            ci.SetDBOPInstance(dbop);
            dbop.BeginTrans();
            try
            {
                if (string.IsNullOrEmpty(ci.Company_no))
                {
                    ci.Company_no = Guid.NewGuid().ToString();
                    if (!ci.Add()) goto lbl_error;
                }
                else
                {
                    if (!ci.Update()) goto lbl_error;
                }
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

        /// <summary>
        /// 获取公司信息
        /// </summary>
        public DataTable  GetCompanyInfo()
        {
            DataTable dt = dbop.GetDataSet("select * from s_company_info").Tables[0];
            return dt;
        }
        #endregion
    }
}
