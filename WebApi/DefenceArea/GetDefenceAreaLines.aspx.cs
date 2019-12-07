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
    public partial class GetDefenceAreaLines : System.Web.UI.Page
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        BasicOp biz = new BasicOp();
        protected void Page_Load(object sender, EventArgs e)
        {
            string djzb = "";
            try
            {
                 djzb = Request.Form["djzb"];
            }
            catch (Exception)
            {
                djzb = "";
            }

            DataTable dt = BODefenceArea.Instance.GetSearchSql(null);
            List<object> BOList = new List<object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                SortedDictionary<string, object> BO_SDIC = new SortedDictionary<string, object>();
                if (biz.HandleNull(djzb, "") != "")
                {
                    string[] strArray = djzb.Split('|');
                    string state = "0";
                    string Area = dr["DA_Area"].ToString();
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        if (Area.IndexOf(strArray[j])>0)
                        {
                            state = "1";
                            break;
                        }
                    }                    
                    BO_SDIC.Add("DA_seq", dr["DA_seq"].ToString());
                    BO_SDIC.Add("DA_Area", dr["DA_Area"].ToString());
                    BO_SDIC.Add("DA_NO", dr["DA_NO"].ToString());
                    BO_SDIC.Add("DA_Name", dr["DA_Name"].ToString());
                    BO_SDIC.Add("DA_JG", dr["DA_JG"].ToString());
                    BO_SDIC.Add("DA_Remark", dr["DA_Remark"].ToString());
                    BO_SDIC.Add("DA_State", state);
                    //查询联动设备
                    DataTable dtDAD = BODefenceArea.Instance.GetDefenceAreaDeviceBydDAID(dr["DA_seq"].ToString());
                    string strDAD = "";
                    for (int j = 0; j < dtDAD.Rows.Count; j++)
                    {
                        strDAD += dtDAD.Rows[j]["DAD_DeviceID"].ToString()+"_";
                    }

                    BO_SDIC.Add("DAID", strDAD);
                    
                }
                else
                {
                    BO_SDIC.Add("DA_seq", dr["DA_seq"].ToString());
                    BO_SDIC.Add("DA_Area", dr["DA_Area"].ToString());
                    BO_SDIC.Add("DA_NO", dr["DA_NO"].ToString());
                    BO_SDIC.Add("DA_Name", dr["DA_Name"].ToString());
                    BO_SDIC.Add("DA_JG", dr["DA_JG"].ToString());
                    BO_SDIC.Add("DA_Remark", dr["DA_Remark"].ToString());
                    BO_SDIC.Add("DA_State", "0");
                    BO_SDIC.Add("DAID", "");
                }
               
                BOList.Add(BO_SDIC);
            }
            Response.Write(biz.SetApiReturn("200", "2000", js.Serialize(BOList)));
            //Response.Write(js.Serialize(couponList));
        }
    }
}