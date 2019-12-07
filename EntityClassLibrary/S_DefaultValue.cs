using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DefaultValue: S_DefaultValue
/// </summary>
public partial class S_DefaultValue
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        sd_seq = null;
        sd_name = null;
        sd_value = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["sd_seq"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["sd_seq"].Equals(null))
            {
                sd_seq = (int?)ds.Tables[0].Rows[0]["sd_seq"];
            }
            if (!ds.Tables[0].Rows[0]["sd_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["sd_name"].Equals(null))
            {
                sd_name = (string)ds.Tables[0].Rows[0]["sd_name"];
            }
            if (!ds.Tables[0].Rows[0]["sd_value"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["sd_value"].Equals(null))
            {
                sd_value = (string)ds.Tables[0].Rows[0]["sd_value"];
            }
        }
    }
    public S_DefaultValue()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DefaultValue(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DefaultValue(int? a_sd_seq)
    {
        dbop = new DataBase();
        sd_seq = a_sd_seq;
        GetValue();
    }
    public S_DefaultValue(DataBase a_dbop, int? a_sd_seq)
    {
        dbop = a_dbop;
        sd_seq = a_sd_seq;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _sd_seq;
    private string _sd_name;
    private string _sd_value;
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
    /// sd_seq
    /// </summary>
    public int? sd_seq
    {
        get
        {
            return _sd_seq;
        }
        set
        {
            _sd_seq = value;
        }
    }
    /// <summary>
    /// sd_name
    /// </summary>
    public string sd_name
    {
        get
        {
            return _sd_name;
        }
        set
        {
            _sd_name = value;
        }
    }
    /// <summary>
    /// sd_value
    /// </summary>
    public string sd_value
    {
        get
        {
            return _sd_value;
        }
        set
        {
            _sd_value = value;
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
        string strSql = "select [sd_seq],[sd_name],[sd_value] from S_DefaultValue where sd_seq=@sd_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@sd_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = sd_seq;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DefaultValue(");
        strSql.Append("sd_name,sd_value)");
        strSql.Append(" values (");
        strSql.Append("@sd_name,@sd_value); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@sd_name", SqlDbType.NVarChar,100),
                new SqlParameter("@sd_value", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = sd_name;
        parameters[1].Value = sd_value;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DefaultValue set sd_name=@sd_name,sd_value=@sd_value where sd_seq=@sd_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@sd_seq", SqlDbType.Int,4),
                new SqlParameter("@sd_name", SqlDbType.NVarChar,100),
                new SqlParameter("@sd_value", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = sd_seq;
        parameters[1].Value = sd_name;
        parameters[2].Value = sd_value;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DefaultValue where sd_seq=@sd_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@sd_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = sd_seq;
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
            sd_seq = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (sd_seq == null || sd_seq == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_sd_seq)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@sd_seq", SqlDbType.Int,4)
            };
            parameters[0].Value = a_sd_seq;
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

