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
    public partial class SetCompanyInfo : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];

            string Company_name = Request.Form["Company_name"];
            string Company_sname = Request.Form["Company_sname"];
            string Company_address = Request.Form["Company_address"];
            string Company_tel = Request.Form["Company_tel"];
            string Company_contact = Request.Form["Company_contact"];
            string Company_logo = Request.Form["Company_logo"];
            string ImageState = Request.Form["ImageState"];
            string logoUrl= Request.Form["logoUrl"];
            StringBuilder sb = new StringBuilder();
            //验证用户




            //生成图片Base64
            if(ImageState=="1")
            {
                logoUrl = decodeBase64ToImage(Company_logo, userkey);
            }
           

           
            Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
            dblist[0] = new Dictionary<string, string>();
            dblist[0].Add("Company_no", "");
            dblist[0].Add("Company_name", Company_name);
            dblist[0].Add("Company_sname", Company_sname);
            dblist[0].Add("Company_address", Company_address);
            dblist[0].Add("Company_tel", Company_tel);
            dblist[0].Add("Company_contact", Company_contact);
            dblist[0].Add("Company_logo", logoUrl);


            string sError = "";
            if (BOCompanyinfo.Instance.SaveCompanyInfo(dblist, out sError))
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


        public string decodeBase64ToImage(string str, string userKey)
        {
            try
            {
                string img = str;//从前台获取base64格式的图片

                img = img.Remove(0, 22);

                byte[] bt = Convert.FromBase64String(img);

                string fileName = userKey + DateTime.Now.ToString("mmddHHmmss");//图片的名称

                string ImageFilePath = "~/upload/Company/";//上传到服务器的路径

                if (System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(ImageFilePath)) == false)
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(ImageFilePath));
                }

                string ImagePath = System.Web.HttpContext.Current.Server.MapPath(ImageFilePath) + fileName;    //定义图片名称

                System.IO.File.WriteAllBytes(ImagePath + ".png", bt); //保存图片到服务器
                string rtn= "upload/Company/" + fileName + ".png";
                return rtn;
               

            }
            catch (Exception)
            {
                return "";
                //SortedDictionary<string, object> rs_SDIC = new SortedDictionary<string, object>();
                //rs_SDIC.Add("rs", "上传图片格式错误");
                //Response.Write(biz.SetApiReturn("200", "1000", js.Serialize(rs_SDIC)));
                //Response.Write("<script>alert('服务器异常');</script>");
            }
          
        }
    }
}