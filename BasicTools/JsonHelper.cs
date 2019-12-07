using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data;
/// <summary>
///JSON序列化和反序列化辅助类
/// </summary>
public class JsonHelper
{
    /// <summary>        
    /// JSON序列化        
    /// </summary>       
    public static string JsonSerializer<T>(T t)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        MemoryStream ms = new MemoryStream();
        ser.WriteObject(ms, t);
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        ms.Close();
        //替换Json的Date字符串   
        string p = @"\\/Date\((\d+)\+\d+\)\\/";
        MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
        Regex reg = new Regex(p);
        jsonString = reg.Replace(jsonString, matchEvaluator);
        return jsonString;
    }

    /// <summary>        
    /// JSON反序列化    
    /// </summary>        
    public static T JsonDeserialize<T>(string jsonString)
    {
        //将"yyyy-MM-dd HH:mm:ss"格式的字符串转为"\/Date(1294499956278+0800)\/"格式
        string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
        MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
        Regex reg = new Regex(p);
        jsonString = reg.Replace(jsonString, matchEvaluator);
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
        T obj = (T)ser.ReadObject(ms);
        return obj;
    }

    /// <summary>        
    /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串        
    /// </summary>        
    private static string ConvertJsonDateToDateString(Match m)
    {
        string result = string.Empty;
        DateTime dt = new DateTime(1970, 1, 1);
        dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
        dt = dt.ToLocalTime();
        result = dt.ToString("yyyy-MM-dd HH:mm:ss");
        return result;
    }

    /// <summary>   
    /// 将时间字符串转为Json时间   
    /// </summary>  
    private static string ConvertDateStringToJsonDate(Match m)
    {
        string result = string.Empty;
        if (!string.IsNullOrEmpty(m.Groups[0].Value))
        {
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
        }
        return result;
    }

    /// <summary>        
    /// JSON反序列化需要的格式化参数  
    /// </summary> 
    /// 
    public static string JsonFormat(string jsonString, string sPre)
    {
        return "{" + jsonString.Replace("{\"name\":\"" + sPre, "\"").Replace("\",\"value\"", "\"").Replace("}", "").TrimStart('[').TrimEnd(']') + "}";
    }

    /// <summary>        
    /// 后台按控件序列化  
    /// </summary>
    public static string JsonSerializer<T>(Control panel, string ctlPre, string[] exclude)
    {
        Type t = typeof(T);
        StringBuilder sb = new StringBuilder("{");
        foreach (Control ctl in panel.Controls)
        {
            if (string.IsNullOrEmpty(ctl.ID)) continue;
            if (exclude != null && ((System.Collections.IList)exclude).Contains(ctl.ID)) continue;
            string name = ctlPre == "" ? ctl.ID : ctl.ID.Replace(ctlPre, "");
            PropertyInfo pi = t.GetProperty(name);
            if (pi == null) continue;
            switch (ctl.GetType().Name)
            {
                case "DropDownList":
                    sb.Append(formatJson(name, ((DropDownList)ctl).Text)); sb.Append(",");
                    break;

                case "TextBox":
                    if (pi.PropertyType.ToString().Contains("Date") && ((TextBox)ctl).Text != "")
                        sb.Append(formatJson(name, ((TextBox)ctl).Text + " 00:00:00"));
                    else
                        sb.Append(formatJson(name, ((TextBox)ctl).Text));
                    sb.Append(",");
                    break;

                case "RadioButtonList":
                    sb.Append(formatJson(name, ((RadioButtonList)ctl).Text)); sb.Append(",");
                    break;

                case "HiddenField":
                    sb.Append(formatJson(name, ((HiddenField)ctl).Value)); sb.Append(",");
                    break;
            }
        }
        return sb.ToString().TrimEnd(',') + "}";
    }

    private static string formatJson(string name, string value)
    {
        value = value.Replace("\"", "\\\"");
        StringBuilder sb = new StringBuilder("");
        sb.Append("\"" + name + "\":" + (value == "" ? "null" : "\"" + value + "\""));
        return sb.ToString();
    }

    public static string JsonSerializer(DataTable dt)
    {
        string value;
        StringBuilder sb = new StringBuilder("{");
        foreach (DataColumn dc in dt.Columns)
        {
            value = dt.Rows[0][dc] == System.DBNull.Value || dt.Rows[0][dc] == null ? "" : dt.Rows[0][dc].GetType().ToString().Contains("DateTime") ? ((DateTime)dt.Rows[0][dc]).ToString("yyyy-MM-dd HH:mm") : dt.Rows[0][dc].ToString();
            if (sb.ToString().Length > 1) sb.Append(",");
            sb.Append("\"" + dc.ColumnName + "\":\"" + value + "\"");
        }
        sb.Append("}");
        object obj = JsonDeserialize<object>(sb.ToString());
        return sb.ToString();
    }
}