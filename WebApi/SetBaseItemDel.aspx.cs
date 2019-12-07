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
    public partial class SetBaseItemDel : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];
           
            string ddi_seq = Request.Form["ddi_seq"];
            string ddi_ddID = Request.Form["ddi_ddID"];

            StringBuilder sb = new StringBuilder();
            //验证用户


            //Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
            //dblist[0] = new Dictionary<string, string>();
          
            //dblist[0].Add("ddi_seq", ddi_seq);
            //dblist[0].Add("ddi_ddID", ddi_ddID);


            string sError = "";
            if (BOBaseInfo.Instance.Del(ddi_seq, out sError))
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("rs", "信息删除成功");
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));

            }
            else
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("rs", "信息删除失败");
                Response.Write(biz.SetApiReturn("200", "1000", js.Serialize(rs_SDIC)));
            }
        }
    }
}