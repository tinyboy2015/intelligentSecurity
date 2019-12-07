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
    public partial class GetAuthenticationMenuList : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = BOUserInfo.Instance.GetMenuList();
            List<object> BOList = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                BO_SDIC.Add("module_id", dr["module_id"].ToString());
                BO_SDIC.Add("module_name", dr["module_name"].ToString());
                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            //Response.Write(js.Serialize(couponList));
        }
    }
}