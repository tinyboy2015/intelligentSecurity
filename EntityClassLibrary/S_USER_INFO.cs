using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_USER_INFO: S_USER_INFO
/// </summary>
public partial class S_USER_INFO
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        User_seq = null;
        User_id = null;
        User_name = null;
        User_passwd = null;
        User_canlogin = null;
        User_lastlogintime = null;
        User_lastloginip = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["User_seq"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_seq"].Equals(null))
            {
                User_seq = (int?)ds.Tables[0].Rows[0]["User_seq"];
            }
            if (!ds.Tables[0].Rows[0]["User_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_id"].Equals(null))
            {
                User_id = (string)ds.Tables[0].Rows[0]["User_id"];
            }
            if (!ds.Tables[0].Rows[0]["User_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_name"].Equals(null))
            {
                User_name = (string)ds.Tables[0].Rows[0]["User_name"];
            }
            if (!ds.Tables[0].Rows[0]["User_passwd"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_passwd"].Equals(null))
            {
                User_passwd = (string)ds.Tables[0].Rows[0]["User_passwd"];
            }
            if (!ds.Tables[0].Rows[0]["User_canlogin"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_canlogin"].Equals(null))
            {
                User_canlogin = (string)ds.Tables[0].Rows[0]["User_canlogin"];
            }
            if (!ds.Tables[0].Rows[0]["User_lastlogintime"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_lastlogintime"].Equals(null))
            {
                User_lastlogintime = (DateTime?)ds.Tables[0].Rows[0]["User_lastlogintime"];
            }
            if (!ds.Tables[0].Rows[0]["User_lastloginip"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["User_lastloginip"].Equals(null))
            {
                User_lastloginip = (string)ds.Tables[0].Rows[0]["User_lastloginip"];
            }
        }
    }
    public S_USER_INFO()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_USER_INFO(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_USER_INFO(int? a_User_seq)
    {
        dbop = new DataBase();
        User_seq = a_User_seq;
        GetValue();
    }
    public S_USER_INFO(DataBase a_dbop, int? a_User_seq)
    {
        dbop = a_dbop;
        User_seq = a_User_seq;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _User_seq;
    private string _User_id;
    private string _User_name;
    private string _User_passwd;
    private string _User_canlogin;
    private DateTime? _User_lastlogintime;
    private string _User_lastloginip;
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
    /// User_seq
    /// </summary>
    public int? User_seq
    {
        get
        {
            return _User_seq;
        }
        set
        {
            _User_seq = value;
        }
    }
    /// <summary>
    /// User_id
    /// </summary>
    public string User_id
    {
        get
        {
            return _User_id;
        }
        set
        {
            _User_id = value;
        }
    }
    /// <summary>
    /// User_name
    /// </summary>
    public string User_name
    {
        get
        {
            return _User_name;
        }
        set
        {
            _User_name = value;
        }
    }
    /// <summary>
    /// User_passwd
    /// </summary>
    public string User_passwd
    {
        get
        {
            return _User_passwd;
        }
        set
        {
            _User_passwd = value;
        }
    }
    /// <summary>
    /// User_canlogin
    /// </summary>
    public string User_canlogin
    {
        get
        {
            return _User_canlogin;
        }
        set
        {
            _User_canlogin = value;
        }
    }
    /// <summary>
    /// User_lastlogintime
    /// </summary>
    public DateTime? User_lastlogintime
    {
        get
        {
            return _User_lastlogintime;
        }
        set
        {
            _User_lastlogintime = value;
        }
    }
    /// <summary>
    /// User_lastloginip
    /// </summary>
    public string User_lastloginip
    {
        get
        {
            return _User_lastloginip;
        }
        set
        {
            _User_lastloginip = value;
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
        string strSql = "select [User_seq],[User_id],[User_name],[User_passwd],[User_canlogin],[User_lastlogintime],[User_lastloginip] from S_USER_INFO where User_seq=@User_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@User_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = User_seq;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_USER_INFO(");
        strSql.Append("User_id,User_name,User_passwd,User_canlogin,User_lastlogintime,User_lastloginip)");
        strSql.Append(" values (");
        strSql.Append("@User_id,@User_name,@User_passwd,@User_canlogin,@User_lastlogintime,@User_lastloginip); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@User_id", SqlDbType.NVarChar,128),
                new SqlParameter("@User_name", SqlDbType.NVarChar,100),
                new SqlParameter("@User_passwd", SqlDbType.NVarChar,400),
                new SqlParameter("@User_canlogin", SqlDbType.NVarChar,4),
                new SqlParameter("@User_lastlogintime", SqlDbType.DateTime,8),
                new SqlParameter("@User_lastloginip", SqlDbType.NVarChar,128)
        };
        parameters[0].Value = User_id;
        parameters[1].Value = User_name;
        parameters[2].Value = User_passwd;
        parameters[3].Value = User_canlogin;
        parameters[4].Value = User_lastlogintime;
        parameters[5].Value = User_lastloginip;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_USER_INFO set User_id=@User_id,User_name=@User_name,User_passwd=@User_passwd,User_canlogin=@User_canlogin,User_lastlogintime=@User_lastlogintime,User_lastloginip=@User_lastloginip where User_seq=@User_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@User_seq", SqlDbType.Int,4),
                new SqlParameter("@User_id", SqlDbType.NVarChar,128),
                new SqlParameter("@User_name", SqlDbType.NVarChar,100),
                new SqlParameter("@User_passwd", SqlDbType.NVarChar,400),
                new SqlParameter("@User_canlogin", SqlDbType.NVarChar,4),
                new SqlParameter("@User_lastlogintime", SqlDbType.DateTime,8),
                new SqlParameter("@User_lastloginip", SqlDbType.NVarChar,128)
        };
        parameters[0].Value = User_seq;
        parameters[1].Value = User_id;
        parameters[2].Value = User_name;
        parameters[3].Value = User_passwd;
        parameters[4].Value = User_canlogin;
        parameters[5].Value = User_lastlogintime;
        parameters[6].Value = User_lastloginip;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_USER_INFO where User_seq=@User_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@User_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = User_seq;
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
            User_seq = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (User_seq == null || User_seq == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_User_seq)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@User_seq", SqlDbType.Int,4)
            };
            parameters[0].Value = a_User_seq;
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

