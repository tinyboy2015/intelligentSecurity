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
    public partial class GetDefenceAreaSettingSet : System.Web.UI.Page
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


                DataTable dt = BODeviceInfo.Instance.GetDeviceSettingSetList(DI_ID);
                List<object> BOList = new List<object>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                    BO_SDIC.Add("DIP_ID", dr["DIP_ID"].ToString());
                    BO_SDIC.Add("DIP_PortID", dr["DIP_PortID"].ToString());

                    BO_SDIC.Add("DIP_NO", dr["DIP_NO"].ToString());
                    BO_SDIC.Add("DIP_ZY", dr["DIP_ZY"].ToString());
                    BO_SDIC.Add("DIP_SX", dr["DIP_SX"].ToString());
                    BO_SDIC.Add("DIP_XX", dr["DIP_XX"].ToString());

                    BO_SDIC.Add("DIP_GYYZ", dr["DIP_GYYZ"].ToString());
                    BO_SDIC.Add("DIP_GLYZ", dr["DIP_GLYZ"].ToString());
                    BO_SDIC.Add("DIP_LXZS", dr["DIP_LXZS"].ToString());

                    BOList.Add(BO_SDIC);
                }
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));

            }
            catch (Exception)
            {
                Response.Write(biz.SetApiReturn("200", "1000",""));
            }

         }
    }
}