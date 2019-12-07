using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_GROUPS: 权限管理（权限组表）
/// </summary>
public partial class S_GROUPS
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        group_id = null;
        group_name = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["group_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_id"].Equals(null))
            {
                group_id = (int?)ds.Tables[0].Rows[0]["group_id"];
            }
            if (!ds.Tables[0].Rows[0]["group_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_name"].Equals(null))
            {
                group_name = (string)ds.Tables[0].Rows[0]["group_name"];
            }
        }
    }
    public S_GROUPS()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_GROUPS(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_GROUPS(int? a_group_id)
    {
        dbop = new DataBase();
        group_id = a_group_id;
        GetValue();
    }
    public S_GROUPS(DataBase a_dbop, int? a_group_id)
    {
        dbop = a_dbop;
        group_id = a_group_id;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _group_id;
    private string _group_name;
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
    /// group_id
    /// </summary>
    public int? group_id
    {
        get
        {
            return _group_id;
        }
        set
        {
            _group_id = value;
        }
    }
    /// <summary>
    /// group_name
    /// </summary>
    public string group_name
    {
        get
        {
            return _group_name;
        }
        set
        {
            _group_name = value;
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
        string strSql = "select [group_id],[group_name] from S_GROUPS where group_id=@group_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_id", SqlDbType.Int,4)
        };
        parameters[0].Value = group_id;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_GROUPS(");
        strSql.Append("group_name)");
        strSql.Append(" values (");
        strSql.Append("@group_name); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_name", SqlDbType.NVarChar,200)
        };
        parameters[0].Value = group_name;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_GROUPS set group_name=@group_name where group_id=@group_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_id", SqlDbType.Int,4),
                new SqlParameter("@group_name", SqlDbType.NVarChar,200)
        };
        parameters[0].Value = group_id;
        parameters[1].Value = group_name;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_GROUPS where group_id=@group_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_id", SqlDbType.Int,4)
        };
        parameters[0].Value = group_id;
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
            group_id = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (group_id == null || group_id == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_group_id)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@group_id", SqlDbType.Int,4)
            };
            parameters[0].Value = a_group_id;
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

