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
    public partial class GetDefenceAreaSettingList : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string DI_DeviceID = "";
            try
            {
                DI_DeviceID = Request.Form["DI_DeviceID"];
            }
            catch (Exception)
            {
                DI_DeviceID = "";
            }
            //Dictionary<string, string> aWhere = new Dictionary<string, string>();
            //aWhere.Add("DI_DeviceID", DI_DeviceID);

            DataTable dt = BODeviceInfo.Instance.GetDeviceSettingList(DI_DeviceID);
            List<object> BOList = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                BO_SDIC.Add("DI_ID", dr["DI_ID"].ToString());
                BO_SDIC.Add("DI_Name", dr["DI_Name"].ToString());
               

                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            //Response.Write(js.Serialize(couponList));
        }
    }
}