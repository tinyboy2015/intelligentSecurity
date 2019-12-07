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

namespace WebApi.Device
{
    public partial class GetCameraSettingInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string userkey = Request.Form["userkey"];
                string userPwd = Request.Form["userPwd"];
                string DI_DeviceID = Request.Form["DI_DeviceID"];
                string DI_ID = Request.Form["HIDDI_ID"];


                StringBuilder sb = new StringBuilder();
                //验证用户


                DataTable dt = BODeviceInfo.Instance.GetDeviceSettingSetCameraInfo(DI_ID);
                List<object> BOList = new List<object>();

                if(dt.Rows.Count>0)
                {                   
                    SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                    BO_SDIC.Add("DIC_ID", dt.Rows[0]["DIC_ID"].ToString());
                    BO_SDIC.Add("DIC_NameID", dt.Rows[0]["DIC_NameID"].ToString());

                    BO_SDIC.Add("DIC_Type", dt.Rows[0]["DIC_Type"].ToString());
                    BO_SDIC.Add("DIC_IP", dt.Rows[0]["DIC_IP"].ToString());
                    BO_SDIC.Add("DIC_Admin", dt.Rows[0]["DIC_Admin"].ToString());
                    BO_SDIC.Add("DIC_Pwd", dt.Rows[0]["DIC_Pwd"].ToString());

            
            

                    BOList.Add(BO_SDIC);
                }
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));

            }
            catch (Exception)
            {
                Response.Write(biz.SetApiReturn("200", "1000", ""));
            }

        }
    }
}