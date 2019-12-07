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
    public partial class GetDeviceList : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string device_Type = "";
            try
            {
                 device_Type = Request.Form["device_Type"];
            }
            catch (Exception)
            {
                device_Type = "";
            }
            Dictionary<string, string> aWhere = new Dictionary<string, string>();
            aWhere.Add("device_Type", device_Type);

            DataTable dt = BODeviceInfo.Instance.GetSearchSql(aWhere);
            List<object> BOList = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                BO_SDIC.Add("device_ID", dr["device_ID"].ToString());
                BO_SDIC.Add("device_Name", dr["device_Name"].ToString());
                BO_SDIC.Add("device_Type", dr["device_Type"].ToString());


                BO_SDIC.Add("device_Remark", dr["device_Remark"].ToString());
                BO_SDIC.Add("device_State", dr["device_State"].ToString());

                BO_SDIC.Add("ddi_name", dr["ddi_name"].ToString());
                BO_SDIC.Add("ddi_desc", dr["ddi_desc"].ToString());

                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            //Response.Write(js.Serialize(couponList));
        }
    }
}