using BasicTools;
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
    public partial class GetTreeMenu : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string uname = Request.QueryString["uname"].ToString();
            //string upwd = Request.QueryString["upwd"].ToString();

            StringBuilder sb = new StringBuilder();
            //验证用户

            //获取菜单
            string str = LoadMenu(0,"0");


            //str = "<li class=\"current\"><a href =\"test.html\" target = \"frame\" ><i class=\"icon-dashboard\"></i>控制台</a></li><li class=\"has-sub\"><a href = \"javascript:void(0);\" ><i class=\"icon-desktop\"></i>UI组件</a><ul class=\"sub-menu\"><li><a href = \"test2.html\" target=\"frame\"><i class=\"icon-angle-right\"></i>通用</a></li><li><a href = \"ui_buttons.html\" ><i class=\"icon-angle-right\"></i>按钮 </a></li></ul></li> ";


            //string s = Server.HtmlEncode(str);
            //string str2 = "{\"menu\":\""+s+"\" }";
            SortedDictionary<string, object> menu_SDIC = new SortedDictionary<string, object>();
            menu_SDIC.Add("menu", str);
            
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(menu_SDIC)));

           // Response.Write(str2);
        }


        public string LoadMenu(int pID, string pLevel)
        {
            string str = "<li class=\"current\">";
            str +="<a href = \"test.html\" target = \"frame\" >";
            str += "<i class=\"icon-dashboard\">";
            str += "</i>";
            str += "控制台";
            str += "</a>";
            str += "</li>";
            str+= MenuTree(pID, pLevel);
            
            return str;
        }
        public string MenuTree(int pID, string pLevel)
        {
            string sRtn = "";
            DataTable dt = biz.MenuList(pID);
            /*SecurityType st*/;
            foreach (DataRow drv in dt.Rows)
            {               
                switch (pLevel)
                {
                    case "0":
                        sRtn += "<li class=\"has-sub\"><a href = \"javascript:void(0);\" >";
                        sRtn += "<i class=\"icon-desktop\">";
                        sRtn += "</i>";
                        sRtn += drv["module_name"].ToString();
                       
                        sRtn += "</a>";
                        sRtn += "<ul class=\"sub-menu\">";
                        sRtn += MenuTree(Convert.ToInt32(drv["module_id"]), "1");
                        sRtn += "</ul>";
                        sRtn += "</li>";
                        break;                    
                    case "1":
                        //st = CheckSecurity(drv["module_url"].ToString());
                        //if (st.CanView)
                        //    sRtn += "<li><a href='" + drv["module_url"] + "' target='navTab' rel='page" + drv["module_id"] + "' external='true'>" + drv["module_name"] + "</a></li>";
                        //else
                          

                        sRtn += "<li ><a href = '" + drv["module_url"] + "' target = \"frame\" ><i class=\"icon-angle-right\"></i>" + drv["module_name"] + "</a></li>";
                        break;
                }
            }
            return sRtn;
        }
    }
}