using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_LOG_TABLE: 系统日志表
/// </summary>
public partial class S_LOG_TABLE
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        log_id = null;
        log_module_name = null;
        log_function_name = null;
        log_operate_type = null;
        log_des_before = null;
        log_des_after = null;
        log_by = null;
        log_date = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["log_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_id"].Equals(null))
            {
                log_id = (int?)ds.Tables[0].Rows[0]["log_id"];
            }
            if (!ds.Tables[0].Rows[0]["log_module_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_module_name"].Equals(null))
            {
                log_module_name = (string)ds.Tables[0].Rows[0]["log_module_name"];
            }
            if (!ds.Tables[0].Rows[0]["log_function_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_function_name"].Equals(null))
            {
                log_function_name = (string)ds.Tables[0].Rows[0]["log_function_name"];
            }
            if (!ds.Tables[0].Rows[0]["log_operate_type"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_operate_type"].Equals(null))
            {
                log_operate_type = (string)ds.Tables[0].Rows[0]["log_operate_type"];
            }
            if (!ds.Tables[0].Rows[0]["log_des_before"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_des_before"].Equals(null))
            {
                log_des_before = (string)ds.Tables[0].Rows[0]["log_des_before"];
            }
            if (!ds.Tables[0].Rows[0]["log_des_after"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_des_after"].Equals(null))
            {
                log_des_after = (string)ds.Tables[0].Rows[0]["log_des_after"];
            }
            if (!ds.Tables[0].Rows[0]["log_by"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_by"].Equals(null))
            {
                log_by = (string)ds.Tables[0].Rows[0]["log_by"];
            }
            if (!ds.Tables[0].Rows[0]["log_date"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["log_date"].Equals(null))
            {
                log_date = (DateTime?)ds.Tables[0].Rows[0]["log_date"];
            }
        }
    }
    public S_LOG_TABLE()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_LOG_TABLE(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_LOG_TABLE(int? a_log_id)
    {
        dbop = new DataBase();
        log_id = a_log_id;
        GetValue();
    }
    public S_LOG_TABLE(DataBase a_dbop, int? a_log_id)
    {
        dbop = a_dbop;
        log_id = a_log_id;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _log_id;
    private string _log_module_name;
    private string _log_function_name;
    private string _log_operate_type;
    private string _log_des_before;
    private string _log_des_after;
    private string _log_by;
    private DateTime? _log_date;
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
    /// log_id
    /// </summary>
    public int? log_id
    {
        get
        {
            return _log_id;
        }
        set
        {
            _log_id = value;
        }
    }
    /// <summary>
    /// log_module_name
    /// </summary>
    public string log_module_name
    {
        get
        {
            return _log_module_name;
        }
        set
        {
            _log_module_name = value;
        }
    }
    /// <summary>
    /// log_function_name
    /// </summary>
    public string log_function_name
    {
        get
        {
            return _log_function_name;
        }
        set
        {
            _log_function_name = value;
        }
    }
    /// <summary>
    /// log_operate_type
    /// </summary>
    public string log_operate_type
    {
        get
        {
            return _log_operate_type;
        }
        set
        {
            _log_operate_type = value;
        }
    }
    /// <summary>
    /// log_des_before
    /// </summary>
    public string log_des_before
    {
        get
        {
            return _log_des_before;
        }
        set
        {
            _log_des_before = value;
        }
    }
    /// <summary>
    /// log_des_after
    /// </summary>
    public string log_des_after
    {
        get
        {
            return _log_des_after;
        }
        set
        {
            _log_des_after = value;
        }
    }
    /// <summary>
    /// log_by
    /// </summary>
    public string log_by
    {
        get
        {
            return _log_by;
        }
        set
        {
            _log_by = value;
        }
    }
    /// <summary>
    /// log_date
    /// </summary>
    public DateTime? log_date
    {
        get
        {
            return _log_date;
        }
        set
        {
            _log_date = value;
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
        string strSql = "select [log_id],[log_module_name],[log_function_name],[log_operate_type],[log_des_before],[log_des_after],[log_by],[log_date] from S_LOG_TABLE where log_id=@log_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@log_id", SqlDbType.Int,4)
        };
        parameters[0].Value = log_id;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_LOG_TABLE(");
        strSql.Append("log_module_name,log_function_name,log_operate_type,log_des_before,log_des_after,log_by,log_date)");
        strSql.Append(" values (");
        strSql.Append("@log_module_name,@log_function_name,@log_operate_type,@log_des_before,@log_des_after,@log_by,@log_date); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@log_module_name", SqlDbType.NVarChar,40),
                new SqlParameter("@log_function_name", SqlDbType.NVarChar,40),
                new SqlParameter("@log_operate_type", SqlDbType.NVarChar,20),
                new SqlParameter("@log_des_before", SqlDbType.NVarChar,2000),
                new SqlParameter("@log_des_after", SqlDbType.NVarChar,2000),
                new SqlParameter("@log_by", SqlDbType.NVarChar,20),
                new SqlParameter("@log_date", SqlDbType.DateTime,8)
        };
        parameters[0].Value = log_module_name;
        parameters[1].Value = log_function_name;
        parameters[2].Value = log_operate_type;
        parameters[3].Value = log_des_before;
        parameters[4].Value = log_des_after;
        parameters[5].Value = log_by;
        parameters[6].Value = log_date;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_LOG_TABLE set log_module_name=@log_module_name,log_function_name=@log_function_name,log_operate_type=@log_operate_type,log_des_before=@log_des_before,log_des_after=@log_des_after,log_by=@log_by,log_date=@log_date where log_id=@log_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@log_id", SqlDbType.Int,4),
                new SqlParameter("@log_module_name", SqlDbType.NVarChar,40),
                new SqlParameter("@log_function_name", SqlDbType.NVarChar,40),
                new SqlParameter("@log_operate_type", SqlDbType.NVarChar,20),
                new SqlParameter("@log_des_before", SqlDbType.NVarChar,2000),
                new SqlParameter("@log_des_after", SqlDbType.NVarChar,2000),
                new SqlParameter("@log_by", SqlDbType.NVarChar,20),
                new SqlParameter("@log_date", SqlDbType.DateTime,8)
        };
        parameters[0].Value = log_id;
        parameters[1].Value = log_module_name;
        parameters[2].Value = log_function_name;
        parameters[3].Value = log_operate_type;
        parameters[4].Value = log_des_before;
        parameters[5].Value = log_des_after;
        parameters[6].Value = log_by;
        parameters[7].Value = log_date;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_LOG_TABLE where log_id=@log_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@log_id", SqlDbType.Int,4)
        };
        parameters[0].Value = log_id;
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
            log_id = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (log_id == null || log_id == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_log_id)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@log_id", SqlDbType.Int,4)
            };
            parameters[0].Value = a_log_id;
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

