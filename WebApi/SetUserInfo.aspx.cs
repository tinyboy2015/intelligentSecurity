using BasicTools;
using BusinessOpClassLibrary;
using DatabaseOpClassLibrary;
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
    public partial class SetUserInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        private DataBase dbop = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];

            string User_id = Request.Form["User_id"];
            string User_name = Request.Form["User_name"];
            string User_passwd = Request.Form["User_passwd"];
            string User_canlogin = Request.Form["User_canlogin"];
            string User_seq = Request.Form["User_seq"];

            string Agroup = Request.Form["Agroup"];
            StringBuilder sb = new StringBuilder();
            //验证用户


            Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
            dblist[0] = new Dictionary<string, string>();
            dblist[0].Add("User_seq", User_seq);
            dblist[0].Add("User_id", User_id);
            dblist[0].Add("User_name", User_name);
            dblist[0].Add("User_passwd", User_passwd);
            dblist[0].Add("User_canlogin", User_canlogin);
         

            string sError = "";
            if (BOUserInfo.Instance.Save(dblist[0], Agroup, out sError))
            {
                // 绑定权限
                string sql2 = "DELETE FROM S_GROUPUSERS WHERE grouser_user = '" + dblist[0]["User_seq"].ToString() + "'";
                dbop.ExecNonQuery(sql2);
                sql2 = "insert into S_GROUPUSERS(grouser_groups,grouser_user) values("+ Agroup + ",'" + dblist[0]["User_seq"].ToString() + "') ";
                dbop.ExecNonQuery(sql2);

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