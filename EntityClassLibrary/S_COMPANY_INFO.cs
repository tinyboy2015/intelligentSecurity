using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_COMPANY_INFO: S_COMPANY_INFO
/// </summary>
public partial class S_COMPANY_INFO
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        Company_no = null;
        Company_name = null;
        Company_sname = null;
        Company_address = null;
        Company_tel = null;
        Company_contact = null;
        Company_logo = null;
        Company_banner = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["Company_no"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_no"].Equals(null))
            {
                Company_no = (string)ds.Tables[0].Rows[0]["Company_no"];
            }
            if (!ds.Tables[0].Rows[0]["Company_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_name"].Equals(null))
            {
                Company_name = (string)ds.Tables[0].Rows[0]["Company_name"];
            }
            if (!ds.Tables[0].Rows[0]["Company_sname"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_sname"].Equals(null))
            {
                Company_sname = (string)ds.Tables[0].Rows[0]["Company_sname"];
            }
            if (!ds.Tables[0].Rows[0]["Company_address"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_address"].Equals(null))
            {
                Company_address = (string)ds.Tables[0].Rows[0]["Company_address"];
            }
            if (!ds.Tables[0].Rows[0]["Company_tel"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_tel"].Equals(null))
            {
                Company_tel = (string)ds.Tables[0].Rows[0]["Company_tel"];
            }
            if (!ds.Tables[0].Rows[0]["Company_contact"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_contact"].Equals(null))
            {
                Company_contact = (string)ds.Tables[0].Rows[0]["Company_contact"];
            }
            if (!ds.Tables[0].Rows[0]["Company_logo"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_logo"].Equals(null))
            {
                Company_logo = (string)ds.Tables[0].Rows[0]["Company_logo"];
            }
            if (!ds.Tables[0].Rows[0]["Company_banner"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["Company_banner"].Equals(null))
            {
                Company_banner = (string)ds.Tables[0].Rows[0]["Company_banner"];
            }
        }
    }
    public S_COMPANY_INFO()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_COMPANY_INFO(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_COMPANY_INFO(string a_Company_no)
    {
        dbop = new DataBase();
        Company_no = a_Company_no;
        GetValue();
    }
    public S_COMPANY_INFO(DataBase a_dbop, string a_Company_no)
    {
        dbop = a_dbop;
        Company_no = a_Company_no;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private string _Company_no;
    private string _Company_name;
    private string _Company_sname;
    private string _Company_address;
    private string _Company_tel;
    private string _Company_contact;
    private string _Company_logo;
    private string _Company_banner;
    #endregion

    #region 成员属性
    public enum RecordSelectedState
    {
        No = 0,
        Yes = 1,
        ThirdState = 2
    }
    public RecordSelectedState RecordIsSelected
    {
        get
        {
            return (RecordSelectedState)_recordIsSelected;
        }
        set
        {
            _recordIsSelected = value;
        }
    }
    /// <summary>
    /// Company_no
    /// </summary>
    public string Company_no
    {
        get
        {
            return _Company_no;
        }
        set
        {
            _Company_no = value;
        }
    }
    /// <summary>
    /// Company_name
    /// </summary>
    public string Company_name
    {
        get
        {
            return _Company_name;
        }
        set
        {
            _Company_name = value;
        }
    }
    /// <summary>
    /// Company_sname
    /// </summary>
    public string Company_sname
    {
        get
        {
            return _Company_sname;
        }
        set
        {
            _Company_sname = value;
        }
    }
    /// <summary>
    /// Company_address
    /// </summary>
    public string Company_address
    {
        get
        {
            return _Company_address;
        }
        set
        {
            _Company_address = value;
        }
    }
    /// <summary>
    /// Company_tel
    /// </summary>
    public string Company_tel
    {
        get
        {
            return _Company_tel;
        }
        set
        {
            _Company_tel = value;
        }
    }
    /// <summary>
    /// Company_contact
    /// </summary>
    public string Company_contact
    {
        get
        {
            return _Company_contact;
        }
        set
        {
            _Company_contact = value;
        }
    }
    /// <summary>
    /// Company_logo
    /// </summary>
    public string Company_logo
    {
        get
        {
            return _Company_logo;
        }
        set
        {
            _Company_logo = value;
        }
    }
    /// <summary>
    /// Company_banner
    /// </summary>
    public string Company_banner
    {
        get
        {
            return _Company_banner;
        }
        set
        {
            _Company_banner = value;
        }
    }
    #endregion

    #region 成员方法
    /// <summary>
    /// Set database operator class instance.
    /// </summary>
    public void SetDBOPInstance(DataBase a_instance_name)
    {
        dbop = a_instance_name;
        return;
    }

    /// <summary>
    /// Return Select SQL statement with parameters.
    /// </summary>
    public string GetSelectSql()
    {
        string strSql = "select [Company_no],[Company_name],[Company_sname],[Company_address],[Company_tel],[Company_contact],[Company_logo],[Company_banner] from S_COMPANY_INFO where Company_no=@Company_no";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@Company_no", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = Company_no;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_COMPANY_INFO(");
        strSql.Append("Company_no,Company_name,Company_sname,Company_address,Company_tel,Company_contact,Company_logo,Company_banner)");
        strSql.Append(" values (");
        strSql.Append("@Company_no,@Company_name,@Company_sname,@Company_address,@Company_tel,@Company_contact,@Company_logo,@Company_banner)");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@Company_no", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_name", SqlDbType.NVarChar,256),
                new SqlParameter("@Company_sname", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_address", SqlDbType.NVarChar,2048),
                new SqlParameter("@Company_tel", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_contact", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_logo", SqlDbType.NVarChar,256),
                new SqlParameter("@Company_banner", SqlDbType.NVarChar,256)
        };
        parameters[0].Value = Company_no;
        parameters[1].Value = Company_name;
        parameters[2].Value = Company_sname;
        parameters[3].Value = Company_address;
        parameters[4].Value = Company_tel;
        parameters[5].Value = Company_contact;
        parameters[6].Value = Company_logo;
        parameters[7].Value = Company_banner;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_COMPANY_INFO set Company_no=@Company_no,Company_name=@Company_name,Company_sname=@Company_sname,Company_address=@Company_address,Company_tel=@Company_tel,Company_contact=@Company_contact,Company_logo=@Company_logo,Company_banner=@Company_banner where Company_no=@Company_no";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@Company_no", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_name", SqlDbType.NVarChar,256),
                new SqlParameter("@Company_sname", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_address", SqlDbType.NVarChar,2048),
                new SqlParameter("@Company_tel", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_contact", SqlDbType.NVarChar,100),
                new SqlParameter("@Company_logo", SqlDbType.NVarChar,256),
                new SqlParameter("@Company_banner", SqlDbType.NVarChar,256)
        };
        parameters[0].Value = Company_no;
        parameters[1].Value = Company_name;
        parameters[2].Value = Company_sname;
        parameters[3].Value = Company_address;
        parameters[4].Value = Company_tel;
        parameters[5].Value = Company_contact;
        parameters[6].Value = Company_logo;
        parameters[7].Value = Company_banner;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_COMPANY_INFO where Company_no=@Company_no";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@Company_no", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = Company_no;
        return parameters;
    }

    /// <summary>
    /// Insert a new record.
    /// </summary>
    public bool Add()
    {
        try
        {
            string strSql = GetInsertSql();
            SqlParameter[] parameters = GetInsertParameters();
            int affectRows = dbop.ExecNonQueryWithParams(strSql, parameters);
            if (affectRows != 1) return false;
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Delete current record.
    /// </summary>
    public bool Delete()
    {
        try
        {
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = GetDeleteParameters();
            int result = dbop.ExecNonQueryWithParams(strSql, parameters);
            return result == 1;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// Delete a record.
    /// </summary>
    public static bool Delete(DataBase a_dbop, string a_Company_no)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@Company_no", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = a_Company_no;
            int result = a_dbop.ExecNonQueryWithParams(strSql, parameters);
            return result == 1;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Update a record.
    /// </summary>
    public bool Update()
    {
        try
        {
            string strSql = GetUpdateSql();
            SqlParameter[] parameters = GetUpdateParameters();
            int result = dbop.ExecNonQueryWithParams(strSql, parameters);
            return result == 1;
        }
        catch
        {
            return false;
        }
    }




    #endregion

    #region 生成默认值方法
    /// <summary>
    /// Return System default value  from sqlserver.
    /// </summary>
    private object GetSystemDefaultValue(string defaultvalue)
    {
        string strSql = "select " + defaultvalue;
        return dbop.GetSingleValue(strSql);
    }
    #endregion

    #endregion
    #region 以下为用户扩展的属性、方法
    #region 枚举类型
    #endregion

    #endregion
}

