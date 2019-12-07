﻿using BasicTools;
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
    public partial class GetLogin : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];


            Dictionary<string, string> aWhere = new Dictionary<string, string>();
            aWhere.Add("User_id", username);
            aWhere.Add("User_passwd", password);

            //查询数据
            DataTable dt = BOUserInfo.Instance.GetSearchSql(aWhere);
            if (dt.Rows.Count > 0)
            {
                SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                rs_SDIC.Add("User_seq", dt.Rows[0]["User_seq"].ToString());
                rs_SDIC.Add("User_id", dt.Rows[0]["User_id"].ToString());
                rs_SDIC.Add("User_name", dt.Rows[0]["User_name"].ToString());
                rs_SDIC.Add("User_canlogin", dt.Rows[0]["User_canlogin"].ToString());
               
                Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(rs_SDIC)));
            }
            else
            {
                Response.Write(biz.SetApiReturn("200", "1000", "为获取到数据"));
            }
        }
    }
}