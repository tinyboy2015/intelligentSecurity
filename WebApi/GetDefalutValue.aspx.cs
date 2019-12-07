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
    public partial class GetDefalutValue : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string dname = Request.Form["dname"];

            StringBuilder sb = new StringBuilder();
            //验证用户

            //查询数据
            DataTable dt = BODefaultValue.Instance.GetDefaultVale(dname); 
            if (dt.Rows.Count > 0)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("sd_seq", dt.Rows[0]["sd_seq"].ToString());
                rs_SDIC.Add("sd_value", dt.Rows[0]["sd_value"].ToString());
             
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));
            }
            else
            {
                Response.Write(biz.SetApiReturn("200", "1000", "未获取到数据"));
            }
        }
    }
}