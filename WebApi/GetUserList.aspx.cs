using BasicTools;
using BusinessOpClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApi
{
    public partial class GetUserList : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = BOUserInfo.Instance.GetSearchSql(null);
            List<object> BOList = new List<object>();
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                BO_SDIC.Add("User_seq", dr["User_seq"].ToString());
                BO_SDIC.Add("User_id",  dr["User_id"].ToString());
                BO_SDIC.Add("User_name", dr["User_name"].ToString());


                BO_SDIC.Add("User_canlogin", dr["User_canlogin"].ToString());
                BO_SDIC.Add("User_lastlogintime", dr["User_lastlogintime"].ToString());
                BO_SDIC.Add("User_lastloginip", dr["User_lastloginip"].ToString());

                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            //Response.Write(js.Serialize(couponList));
        }
    }
}