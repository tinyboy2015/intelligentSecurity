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
    public partial class SetDeviceInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];

            string device_ID = Request.Form["device_ID"];
            string device_Name = Request.Form["device_Name"];
            string device_Type = Request.Form["device_Type"];
            string device_Remark = Request.Form["device_Remark"];
            //string device_State = Request.Form["device_State"];

            StringBuilder sb = new StringBuilder();
            //验证用户


            Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
            dblist[0] = new Dictionary<string, string>();
            dblist[0].Add("device_ID", device_ID);
            dblist[0].Add("device_Name", device_Name);
            dblist[0].Add("device_Type", device_Type);
            dblist[0].Add("device_Remark", device_Remark);
            dblist[0].Add("device_State", "0");


            string sError = "";
            if (BODeviceInfo.Instance.Save(dblist[0], out sError))
            {
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
    }
}