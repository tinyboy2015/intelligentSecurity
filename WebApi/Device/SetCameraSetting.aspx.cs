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
    public partial class SetCameraSetting : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string userkey = Request.Form["userkey"];
                string userPwd = Request.Form["userPwd"];

                string DIC_NameID = Request.Form["DIC_NameID"];
                string DI_DeviceID = Request.Form["DI_DeviceID"];
                string DI_ID = Request.Form["hidDeviceID"];
                string DIC_Type = Request.Form["DIC_Type"];
                string DIC_IP = Request.Form["DIC_IP"];
                string DIC_Admin = Request.Form["DIC_Admin"];
                string DIC_Pwd = Request.Form["DIC_Pwd"];
              

                StringBuilder sb = new StringBuilder();
                //验证用户


                //保存设备主表
                string sError = "";
                Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
                dblist[0] = new Dictionary<string, string>();
                dblist[0].Add("DI_ID", DI_ID);
                dblist[0].Add("DI_Name", DIC_NameID);
                dblist[0].Add("DI_DeviceID", DI_DeviceID);
                dblist[0].Add("DI_Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (BODeviceInfo.Instance.SaveDeviceInterface(dblist[0], out sError))
                {
                    //保存设备配置表
                    string DIP_PortID = dblist[0]["DI_ID"].ToString();
                    BODeviceInfo.Instance.DelDeviceInterfacePort(DIP_PortID);
                    Dictionary<string, string>[] dblist2 = new Dictionary<string, string>[1];
                    dblist2[0] = new Dictionary<string, string>();
                    dblist2[0].Add("DIC_ID", DI_ID);
                    dblist2[0].Add("DIC_NameID", DIP_PortID);
                    dblist2[0].Add("DIC_Type", DIC_Type);
                    dblist2[0].Add("DIC_IP", DIC_IP);
                    dblist2[0].Add("DIC_Admin", DIC_Admin);
                    dblist2[0].Add("DIC_Pwd", DIC_Pwd);

                    BODeviceInfo.Instance.SetDeviceInterfaceCamera(dblist2[0], out sError);

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