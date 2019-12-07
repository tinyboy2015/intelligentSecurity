
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// 类似String.Format功能,实现参数化SQL语句的
/// </summary>
public class SqlFormatter
{
    #region Private Variables

    private string sql;
    private SqlParameter[] parameters;

    #endregion

    #region Properties

    public string Sql
    {
        get
        {
            return sql;
        }
    }
    public SqlParameter[] Parameters
    {
        get
        {
            return parameters;
        }
    }

    #endregion

    /// <summary>
    /// 格式化参数和字符串,结果放在 Sql 和 Parameters 属性中
    /// </summary>
    /// <param name="format">带有格式的SQL语句</param>
    /// <param name="args">各参数的值,类型自动判断生成参数</param>
    public void Format(String format, params object[] args)
    {
        if (format == null || args == null)
        {
            throw new ArgumentNullException((format == null) ? "format" : "args");
        }
        List<SqlParameter> commandParameters = new List<SqlParameter>();
        StringBuilder sb = new StringBuilder();
        char[] chars = format.ToCharArray(0, format.Length);
        int pos = 0;
        int len = chars.Length;
        char ch = '\x0';


        while (true)
        {
            int p = pos;
            int i = pos;

            // 复制所有的字符 一直到 {
            while (pos < len)
            {
                ch = chars[pos];

                pos++;
                if (ch == '}')
                {
                    if (pos < len && chars[pos] == '}') // Treat as escape character for }} 
                        pos++;
                    else
                        FormatError();
                }

                if (ch == '{')
                {
                    if (pos < len && chars[pos] == '{') // Treat as escape character for {{
                        pos++;
                    else
                    {
                        pos--;
                        break;
                    }
                }

                chars[i++] = ch;
            }
            if (i > p) sb.Append(chars, p, i - p);
            if (pos == len) break;

            // 取得索引号
            pos++;
            if (pos == len || (ch = chars[pos]) < '0' || ch > '9') FormatError();
            int index = 0;
            do
            {
                index = index * 10 + ch - '0';
                pos++;
                if (pos == len) FormatError();
                ch = chars[pos];
            } while (ch >= '0' && ch <= '9' && index < 1000000);
            if (index >= args.Length) throw new FormatException("索引(从零开始)必须大于或等于零，且小于参数列表的大小。");

            while (pos < len && (ch = chars[pos]) == ' ') pos++;

            // 随后的}
            if (ch != '}') FormatError();
            pos++;

            // 加入此参数
            object arg = args[index] ?? DBNull.Value;

            string parameterName = "@arg__" + index;
            SqlParameter para = new SqlParameter();
            para.ParameterName = parameterName;
            para.SqlDbType = ConvertSqlType(arg.GetType());
            para.Value = arg;
            commandParameters.Add(para);

            // 替换Sql语句中的参数
            sb.Append(parameterName);
        }

        parameters = commandParameters.ToArray();
        sql = sb.ToString();
    }

    #region private static Method

    private static void FormatError()
    {
        throw new FormatException("参数格式错误");
    }

    private static SqlDbType ConvertSqlType(Type type)
    {
        switch (type.FullName.ToLower())
        {
            case "system.int64":
            case "system.uint64":
                return SqlDbType.BigInt;
            case "system.boolean":
                return SqlDbType.Bit;
            case "system.datetime":
                return SqlDbType.DateTime;
            case "system.decimal":
                return SqlDbType.Decimal;
            case "system.double":
                return SqlDbType.Float;
            case "system.int32":
                return SqlDbType.Int;
            case "system.single":
                return SqlDbType.Real;
            case "system.int16":
                return SqlDbType.SmallInt;
            case "system.byte":
                return SqlDbType.TinyInt;
            case "system.sbyte":
                return SqlDbType.Bit;
            case "system.guid":
                return SqlDbType.UniqueIdentifier;
            case "system.byte()":
                return SqlDbType.VarBinary;
            case "system.string":
            case "system.text":
                return SqlDbType.VarChar;
            case "system.char":
                return SqlDbType.Char;
            case "system.object":
                return SqlDbType.Variant;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion

}