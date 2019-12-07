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
    public sealed class BODefaultValue
    {
        private DataBase dbop = new DataBase();
        BasicOp biz = new BasicOp();

        #region Singleton definition

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BODefaultValue Instance
        {
            [DebuggerStepThrough]
            get
            {
                return Singleton<BODefaultValue>.Instance;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BOCompanyinfo"/> class.
        /// </summary>
        private BODefaultValue() { }

        #endregion

        #region Public methods


        public DataTable GetDefaultVale(string name)
        {
            string sql = "SELECT * FROM S_DefaultValue where sd_name='"+name+"' ";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            return dt;
        }

        public bool Save(string value,string name)
        {
            string sql = "update S_DefaultValue set sd_value='"+value+ "' where sd_name='"+name+"'";
            if (dbop.ExecNonQuery(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
