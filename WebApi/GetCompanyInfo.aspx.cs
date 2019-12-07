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
    public partial class GetCompanyInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];

            StringBuilder sb = new StringBuilder();
            //验证用户

            //查询数据
            DataTable dt = BOCompanyinfo.Instance.GetCompanyInfo();
            if (dt.Rows.Count > 0)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("Company_name", dt.Rows[0]["Company_name"].ToString());
                rs_SDIC.Add("Company_sname", dt.Rows[0]["Company_sname"].ToString());
                rs_SDIC.Add("Company_address", dt.Rows[0]["Company_address"].ToString());
                rs_SDIC.Add("Company_tel", dt.Rows[0]["Company_tel"].ToString());
                rs_SDIC.Add("Company_contact", dt.Rows[0]["Company_contact"].ToString());
                rs_SDIC.Add("logoUrl", dt.Rows[0]["Company_logo"].ToString());
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));
            }
            else
            {
                Response.Write(biz.SetApiReturn("200", "1000", "为获取到数据"));
            }

        }
    }
}