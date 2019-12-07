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
    public partial class SetDafaultValue : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userkey = Request.Form["userkey"];
            string userPwd = Request.Form["userPwd"];

            string dvalue = Request.Form["dvalue"];
            string dname = Request.Form["dname"];
           
            StringBuilder sb = new StringBuilder();
            //验证用户
           
            //生成图片Base64
            if (dname == "防区示意图")
            {
                dvalue = decodeBase64ToImage(dvalue, userkey);
            }

            if (BODefaultValue.Instance.Save(dvalue, dname) == true)
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

                img = img.Remove(0, 23);

                byte[] bt = Convert.FromBase64String(img);

                string fileName = userKey + DateTime.Now.ToString("mmddHHmmss");//图片的名称

                string ImageFilePath = "~/upload/DefaultValue/";//上传到服务器的路径

                if (System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(ImageFilePath)) == false)
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(ImageFilePath));
                }

                string ImagePath = System.Web.HttpContext.Current.Server.MapPath(ImageFilePath) + fileName;    //定义图片名称

                System.IO.File.WriteAllBytes(ImagePath + ".png", bt); //保存图片到服务器
                string rtn = "upload/DefaultValue/" + fileName + ".png";
                return rtn;


            }
            catch (Exception ex)
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