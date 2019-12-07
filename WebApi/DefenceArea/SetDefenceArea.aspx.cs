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

namespace WebApi.DefenceArea
{
    public partial class SetDefenceArea : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string userkey = Request.Form["userkey"];
                string userPwd = Request.Form["userPwd"];

                string DA_NO = Request.Form["DA_NO"];
                string Hid_DA_seq = Request.Form["Hid_DA_seq"];
                string DA_Name = Request.Form["DA_Name"];
                string DA_JG = Request.Form["DA_JG"];
                string dqZB = Request.Form["dqZB"];
                string DA_Remark = Request.Form["DA_Remark"];

                string DAID = Request.Form["DAID"];

                StringBuilder sb = new StringBuilder();
                //验证用户


                //保存设备主表
                string sError = "";
                Dictionary<string, string>[] dblist = new Dictionary<string, string>[1];
                dblist[0] = new Dictionary<string, string>();
                dblist[0].Add("DA_seq", Hid_DA_seq);
                dblist[0].Add("DA_NO", DA_NO);
                dblist[0].Add("DA_Name", DA_Name);
                dblist[0].Add("DA_JG", DA_JG);
                dblist[0].Add("DA_Remark", DA_Remark);
                dblist[0].Add("DA_Area", dqZB);
                dblist[0].Add("DA_Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dblist[0].Add("DA_State", "1");
                if (BODefenceArea.Instance.Save(dblist[0], out sError))
                {
                    string DA_seq = dblist[0]["DA_seq"].ToString();
                    //删除当前防区所有设备
                    BODefenceArea.Instance.DelDefenceAreaDeviceBydDAID(DA_seq);
                    ////保存防区设备联动表
                    if (biz.HandleNull(DAID, "") != "")
                    {
                        string[] strArray = DAID.Split('_');
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (biz.HandleNull(strArray[i], "") != "")
                            {
                                Dictionary<string, string>[] dblist2 = new Dictionary<string, string>[1];
                                dblist2[0] = new Dictionary<string, string>();
                                dblist2[0].Add("DAD_seq", "");
                                dblist2[0].Add("DAD_DefenceAreaID", DA_seq);
                                dblist2[0].Add("DAD_DeviceID", strArray[i]);
                                dblist2[0].Add("DAD_State", "1");
                                BODefenceArea.Instance.SaveDefenceAreaDevice(dblist2[0], out sError);
                            }
                        }
                    }
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