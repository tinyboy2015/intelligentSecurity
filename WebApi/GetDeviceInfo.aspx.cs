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
    public partial class GetDeviceInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string device_ID = Request.Form["device_ID"];

            StringBuilder sb = new StringBuilder();
            //验证用户

            //查询数据
            DataTable dt = BODeviceInfo.Instance.Get(device_ID);
            if (dt.Rows.Count > 0)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("device_ID", dt.Rows[0]["device_ID"].ToString());
                rs_SDIC.Add("device_Name", dt.Rows[0]["device_Name"].ToString());
                rs_SDIC.Add("device_Type", dt.Rows[0]["device_Type"].ToString());
                rs_SDIC.Add("device_Remark", dt.Rows[0]["device_Remark"].ToString());
                rs_SDIC.Add("device_State", dt.Rows[0]["device_State"].ToString());
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));
            }
            else
            {
                Response.Write(biz.SetApiReturn("200", "1000", "为获取到数据"));
            }
        }
    }
}