using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DROPDOWNLIST: 代码（主表）
/// </summary>
public partial class S_DROPDOWNLIST
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        dd_name = null;
        dd_code = null;
        dd_order = null;
        dd_edit = (string)GetSystemDefaultValue("N'Y'");
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["dd_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["dd_name"].Equals(null))
            {
                dd_name = (string)ds.Tables[0].Rows[0]["dd_name"];
            }
            if (!ds.Tables[0].Rows[0]["dd_code"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["dd_code"].Equals(null))
            {
                dd_code = (string)ds.Tables[0].Rows[0]["dd_code"];
            }
            if (!ds.Tables[0].Rows[0]["dd_order"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["dd_order"].Equals(null))
            {
                dd_order = (int?)ds.Tables[0].Rows[0]["dd_order"];
            }
            if (!ds.Tables[0].Rows[0]["dd_edit"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["dd_edit"].Equals(null))
            {
                dd_edit = (string)ds.Tables[0].Rows[0]["dd_edit"];
            }
        }
    }
    public S_DROPDOWNLIST()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DROPDOWNLIST(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DROPDOWNLIST(string a_dd_name)
    {
        dbop = new DataBase();
        dd_name = a_dd_name;
        GetValue();
    }
    public S_DROPDOWNLIST(DataBase a_dbop, string a_dd_name)
    {
        dbop = a_dbop;
        dd_name = a_dd_name;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private string _dd_name;
    private string _dd_code;
    private int? _dd_order;
    private string _dd_edit;
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
    /// dd_name
    /// </summary>
    public string dd_name
    {
        get
        {
            return _dd_name;
        }
        set
        {
            _dd_name = value;
        }
    }
    /// <summary>
    /// dd_code
    /// </summary>
    public string dd_code
    {
        get
        {
            return _dd_code;
        }
        set
        {
            _dd_code = value;
        }
    }
    /// <summary>
    /// dd_order
    /// </summary>
    public int? dd_order
    {
        get
        {
            return _dd_order;
        }
        set
        {
            _dd_order = value;
        }
    }
    /// <summary>
    /// dd_edit
    /// </summary>
    public string dd_edit
    {
        get
        {
            return _dd_edit;
        }
        set
        {
            _dd_edit = value;
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
        string strSql = "select [dd_name],[dd_code],[dd_order],[dd_edit] from S_DROPDOWNLIST where dd_name=@dd_name";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@dd_name", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = dd_name;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DROPDOWNLIST(");
        strSql.Append("dd_name,dd_code,dd_order,dd_edit)");
        strSql.Append(" values (");
        strSql.Append("@dd_name,@dd_code,@dd_order,@dd_edit)");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@dd_name", SqlDbType.NVarChar,100),
                new SqlParameter("@dd_code", SqlDbType.NVarChar,100),
                new SqlParameter("@dd_order", SqlDbType.Int,4),
                new SqlParameter("@dd_edit", SqlDbType.NVarChar,2)
        };
        parameters[0].Value = dd_name;
        parameters[1].Value = dd_code;
        parameters[2].Value = dd_order;
        parameters[3].Value = dd_edit;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DROPDOWNLIST set dd_name=@dd_name,dd_code=@dd_code,dd_order=@dd_order,dd_edit=@dd_edit where dd_name=@dd_name";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@dd_name", SqlDbType.NVarChar,100),
                new SqlParameter("@dd_code", SqlDbType.NVarChar,100),
                new SqlParameter("@dd_order", SqlDbType.Int,4),
                new SqlParameter("@dd_edit", SqlDbType.NVarChar,2)
        };
        parameters[0].Value = dd_name;
        parameters[1].Value = dd_code;
        parameters[2].Value = dd_order;
        parameters[3].Value = dd_edit;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DROPDOWNLIST where dd_name=@dd_name";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@dd_name", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = dd_name;
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
    public static bool Delete(DataBase a_dbop, string a_dd_name)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@dd_name", SqlDbType.NVarChar,100)
            };
            parameters[0].Value = a_dd_name;
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

