using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DefenceArea_Device: S_DefenceArea_Device
/// </summary>
public partial class S_DefenceArea_Device
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        DAD_seq = null;
        DAD_DefenceAreaID = null;
        DAD_DeviceID = null;
        DAD_State = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["DAD_seq"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DAD_seq"].Equals(null))
            {
                DAD_seq = (int?)ds.Tables[0].Rows[0]["DAD_seq"];
            }
            if (!ds.Tables[0].Rows[0]["DAD_DefenceAreaID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DAD_DefenceAreaID"].Equals(null))
            {
                DAD_DefenceAreaID = (int?)ds.Tables[0].Rows[0]["DAD_DefenceAreaID"];
            }
            if (!ds.Tables[0].Rows[0]["DAD_DeviceID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DAD_DeviceID"].Equals(null))
            {
                DAD_DeviceID = (int?)ds.Tables[0].Rows[0]["DAD_DeviceID"];
            }
            if (!ds.Tables[0].Rows[0]["DAD_State"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DAD_State"].Equals(null))
            {
                DAD_State = (string)ds.Tables[0].Rows[0]["DAD_State"];
            }
        }
    }
    public S_DefenceArea_Device()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DefenceArea_Device(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DefenceArea_Device(int? a_DAD_seq)
    {
        dbop = new DataBase();
        DAD_seq = a_DAD_seq;
        GetValue();
    }
    public S_DefenceArea_Device(DataBase a_dbop, int? a_DAD_seq)
    {
        dbop = a_dbop;
        DAD_seq = a_DAD_seq;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _DAD_seq;
    private int? _DAD_DefenceAreaID;
    private int? _DAD_DeviceID;
    private string _DAD_State;
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
    /// DAD_seq
    /// </summary>
    public int? DAD_seq
    {
        get
        {
            return _DAD_seq;
        }
        set
        {
            _DAD_seq = value;
        }
    }
    /// <summary>
    /// DAD_DefenceAreaID
    /// </summary>
    public int? DAD_DefenceAreaID
    {
        get
        {
            return _DAD_DefenceAreaID;
        }
        set
        {
            _DAD_DefenceAreaID = value;
        }
    }
    /// <summary>
    /// DAD_DeviceID
    /// </summary>
    public int? DAD_DeviceID
    {
        get
        {
            return _DAD_DeviceID;
        }
        set
        {
            _DAD_DeviceID = value;
        }
    }
    /// <summary>
    /// DAD_State
    /// </summary>
    public string DAD_State
    {
        get
        {
            return _DAD_State;
        }
        set
        {
            _DAD_State = value;
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
        string strSql = "select [DAD_seq],[DAD_DefenceAreaID],[DAD_DeviceID],[DAD_State] from S_DefenceArea_Device where DAD_seq=@DAD_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DAD_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = DAD_seq;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DefenceArea_Device(");
        strSql.Append("DAD_DefenceAreaID,DAD_DeviceID,DAD_State)");
        strSql.Append(" values (");
        strSql.Append("@DAD_DefenceAreaID,@DAD_DeviceID,@DAD_State); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DAD_DefenceAreaID", SqlDbType.Int,4),
                new SqlParameter("@DAD_DeviceID", SqlDbType.Int,4),
                new SqlParameter("@DAD_State", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DAD_DefenceAreaID;
        parameters[1].Value = DAD_DeviceID;
        parameters[2].Value = DAD_State;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DefenceArea_Device set DAD_DefenceAreaID=@DAD_DefenceAreaID,DAD_DeviceID=@DAD_DeviceID,DAD_State=@DAD_State where DAD_seq=@DAD_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DAD_seq", SqlDbType.Int,4),
                new SqlParameter("@DAD_DefenceAreaID", SqlDbType.Int,4),
                new SqlParameter("@DAD_DeviceID", SqlDbType.Int,4),
                new SqlParameter("@DAD_State", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DAD_seq;
        parameters[1].Value = DAD_DefenceAreaID;
        parameters[2].Value = DAD_DeviceID;
        parameters[3].Value = DAD_State;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DefenceArea_Device where DAD_seq=@DAD_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DAD_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = DAD_seq;
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
            DAD_seq = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (DAD_seq == null || DAD_seq == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_DAD_seq)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@DAD_seq", SqlDbType.Int,4)
            };
            parameters[0].Value = a_DAD_seq;
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

