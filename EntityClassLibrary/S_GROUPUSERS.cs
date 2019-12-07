using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_GROUPUSERS: 权限管理（组内人员表）
/// </summary>
public partial class S_GROUPUSERS
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        grouser_id = null;
        grouser_groups = null;
        grouser_user = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["grouser_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["grouser_id"].Equals(null))
            {
                grouser_id = (int?)ds.Tables[0].Rows[0]["grouser_id"];
            }
            if (!ds.Tables[0].Rows[0]["grouser_groups"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["grouser_groups"].Equals(null))
            {
                grouser_groups = (int?)ds.Tables[0].Rows[0]["grouser_groups"];
            }
            if (!ds.Tables[0].Rows[0]["grouser_user"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["grouser_user"].Equals(null))
            {
                grouser_user = (string)ds.Tables[0].Rows[0]["grouser_user"];
            }
        }
    }
    public S_GROUPUSERS()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_GROUPUSERS(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_GROUPUSERS(int? a_grouser_id)
    {
        dbop = new DataBase();
        grouser_id = a_grouser_id;
        GetValue();
    }
    public S_GROUPUSERS(DataBase a_dbop, int? a_grouser_id)
    {
        dbop = a_dbop;
        grouser_id = a_grouser_id;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _grouser_id;
    private int? _grouser_groups;
    private string _grouser_user;
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
    /// 自增列 主键ID
    /// </summary>
    public int? grouser_id
    {
        get
        {
            return _grouser_id;
        }
        set
        {
            _grouser_id = value;
        }
    }
    /// <summary>
    /// 组ID  S_GROUPRIGHTS.group_rig_grop
    /// </summary>
    public int? grouser_groups
    {
        get
        {
            return _grouser_groups;
        }
        set
        {
            _grouser_groups = value;
        }
    }
    /// <summary>
    /// 用户ID  S_User.user_id
    /// </summary>
    public string grouser_user
    {
        get
        {
            return _grouser_user;
        }
        set
        {
            _grouser_user = value;
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
        string strSql = "select [grouser_id],[grouser_groups],[grouser_user] from S_GROUPUSERS where grouser_id=@grouser_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@grouser_id", SqlDbType.Int,4)
        };
        parameters[0].Value = grouser_id;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_GROUPUSERS(");
        strSql.Append("grouser_groups,grouser_user)");
        strSql.Append(" values (");
        strSql.Append("@grouser_groups,@grouser_user); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@grouser_groups", SqlDbType.Int,4),
                new SqlParameter("@grouser_user", SqlDbType.NVarChar,128)
        };
        parameters[0].Value = grouser_groups;
        parameters[1].Value = grouser_user;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_GROUPUSERS set grouser_groups=@grouser_groups,grouser_user=@grouser_user where grouser_id=@grouser_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@grouser_id", SqlDbType.Int,4),
                new SqlParameter("@grouser_groups", SqlDbType.Int,4),
                new SqlParameter("@grouser_user", SqlDbType.NVarChar,128)
        };
        parameters[0].Value = grouser_id;
        parameters[1].Value = grouser_groups;
        parameters[2].Value = grouser_user;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_GROUPUSERS where grouser_id=@grouser_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@grouser_id", SqlDbType.Int,4)
        };
        parameters[0].Value = grouser_id;
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
            grouser_id = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (grouser_id == null || grouser_id == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_grouser_id)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@grouser_id", SqlDbType.Int,4)
            };
            parameters[0].Value = a_grouser_id;
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

