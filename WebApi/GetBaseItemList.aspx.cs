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
    public partial class GetBaseItemList : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Code = Request.Form["Code"];
            DataTable dt = BOBaseInfo.Instance.GetBaseItemList(Code);
            List<object> BOList = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                BO_SDIC.Add("ddi_seq", dr["ddi_seq"].ToString());
                BO_SDIC.Add("ddi_name", dr["ddi_name"].ToString());
                BO_SDIC.Add("ddi_value", dr["ddi_value"].ToString());
                BO_SDIC.Add("ddi_desc", dr["ddi_desc"].ToString());
                BO_SDIC.Add("ddi_order", dr["ddi_order"].ToString());
                BO_SDIC.Add("ddi_ddID", dr["ddi_ddID"].ToString());

                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            
        }
    }
}