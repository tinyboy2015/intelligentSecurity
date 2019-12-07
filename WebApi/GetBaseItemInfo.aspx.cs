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
    public partial class GetBaseItemInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ddi_seq = Request.Form["ddi_seq"];

            StringBuilder sb = new StringBuilder();
            //验证用户

            //查询数据
            DataTable dt = BOBaseInfo.Instance.Get(ddi_seq);
            if (dt.Rows.Count > 0)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("ddi_seq", dt.Rows[0]["ddi_seq"].ToString());
                rs_SDIC.Add("ddi_name", dt.Rows[0]["ddi_name"].ToString());
                rs_SDIC.Add("ddi_value", dt.Rows[0]["ddi_value"].ToString());
                rs_SDIC.Add("ddi_desc", dt.Rows[0]["ddi_desc"].ToString());
                rs_SDIC.Add("ddi_order", dt.Rows[0]["ddi_order"].ToString());
                rs_SDIC.Add("ddi_ddID", dt.Rows[0]["ddi_ddID"].ToString());
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));
            }
            else
            {
                Response.Write(biz.SetApiReturn("200", "1000", "为获取到数据"));
            }
        }
    }
}