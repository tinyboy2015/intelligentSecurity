using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicTools
{
    public class StringFormat
    {
        public StringFormat()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 格式化SQL字符串，包含SQL特殊字符的字符串格式化后可以直接使用like等操作符
        /// </summary>
        /// <param name="strSql">原SQL字符串</param>
        /// <returns>格式化后的字符串</returns>
        public static string SqlStrFormat(string strSql)
        {
            if (strSql == "")
            {
                return "";
            }

            strSql = strSql.Replace("'", "''");
            strSql = strSql.Replace("[", "[[]");
            strSql = strSql.Replace("%", "[%]");
            strSql = strSql.Replace("_", "[_]");
            strSql = strSql.Replace("*", "[*]");
            return strSql;
        }


        /// <summary>
        /// 格式化SQL字符串，保留匹配符（仅替换单引号）
        /// </summary>
        /// <param name="strSql">原SQL字符串</param>
        /// <returns>格式化后的字符串</returns>
        public static string SqlStrFormat2(string strSql)
        {
            if (strSql == "")
            {
                return "";
            }
            strSql = strSql.Replace("'", "''");
            return strSql;
        }


        /// <summary>
        /// 将字符串用原格式在web页面上显示，主要是替换特殊的html标记
        /// </summary>
        /// <param name="strContent">原字符串</param>
        /// <returns>格式化后的字符串</returns>
        public static string HTMLFormat(string strContent)
        {
            if (strContent == "")
            {
                return "";
            }

            strContent = strContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br>").Replace(" ", "&nbsp;");

            return strContent;
        }
    }
}
