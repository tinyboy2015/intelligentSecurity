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
    public partial class SetDefenceAreaSetting : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string userkey = Request.Form["userkey"];
                string userPwd = Request.Form["userPwd"];

                string comName = Request.Form["comName"];
                string DI_DeviceID = Request.Form["DI_DeviceID"];
                string DI_ID = Request.Form["hidDeviceID"];
                string td1 = Request.Form["td1"];
                string td2 = Request.Form["td2"];
                string td3 = Request.Form["td3"];
                string td4 = Request.Form["td4"];
                string td5 = Request.Form["td5"];
                string td6 = Request.Form["td6"];
                string td7 = Request.Form["td7"];
                string td8 = Request.Form["td8"];

                StringBuilder sb = new StringBuilder();
                //验证用户


                //保存设备主表
                string sError = "";
                Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
                dblist[0] = new Dictionary<string, string>();
                dblist[0].Add("DI_ID", DI_ID);
                dblist[0].Add("DI_Name", comName);
                dblist[0].Add("DI_DeviceID", DI_DeviceID);
                dblist[0].Add("DI_Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (BODeviceInfo.Instance.SaveDeviceInterface(dblist[0], out sError))
                {
                    //保存设备配置表
                    string DIP_PortID = dblist[0]["DI_ID"].ToString();
                    BODeviceInfo.Instance.DelDeviceInterfacePort(DIP_PortID);
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td1, "1");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td2, "2");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td3, "3");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td4, "4");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td5, "5");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td6, "6");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td7, "7");
                    BODeviceInfo.Instance.SetDeviceInterfacePort(DIP_PortID, td8, "8");
                    SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                    rs_SDIC.Add("rs", "信息保存成功");
                    Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));

                }
                else
                {
                    SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                    rs_SDIC.Add("rs", "信息保存失败");
                    Response.Write(biz.SetApiReturn("200", "1000", js.Serialize(rs_SDIC)));
                }

            }
            catch (Exception)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("rs", "信息保存失败");
                Response.Write(biz.SetApiReturn("200", "1000", js.Serialize(rs_SDIC)));
            }



        }
    }
}