using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DEVICE: S_DEVICE
/// </summary>
public partial class S_DEVICE
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        device_ID = null;
        device_Name = null;
        device_Type = null;
        device_Remark = null;
        device_State = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["device_ID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["device_ID"].Equals(null))
            {
                device_ID = (int?)ds.Tables[0].Rows[0]["device_ID"];
            }
            if (!ds.Tables[0].Rows[0]["device_Name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["device_Name"].Equals(null))
            {
                device_Name = (string)ds.Tables[0].Rows[0]["device_Name"];
            }
            if (!ds.Tables[0].Rows[0]["device_Type"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["device_Type"].Equals(null))
            {
                device_Type = (string)ds.Tables[0].Rows[0]["device_Type"];
            }
            if (!ds.Tables[0].Rows[0]["device_Remark"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["device_Remark"].Equals(null))
            {
                device_Remark = (string)ds.Tables[0].Rows[0]["device_Remark"];
            }
            if (!ds.Tables[0].Rows[0]["device_State"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["device_State"].Equals(null))
            {
                device_State = (int?)ds.Tables[0].Rows[0]["device_State"];
            }
        }
    }
    public S_DEVICE()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DEVICE(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DEVICE(int? a_device_ID)
    {
        dbop = new DataBase();
        device_ID = a_device_ID;
        GetValue();
    }
    public S_DEVICE(DataBase a_dbop, int? a_device_ID)
    {
        dbop = a_dbop;
        device_ID = a_device_ID;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _device_ID;
    private string _device_Name;
    private string _device_Type;
    private string _device_Remark;
    private int? _device_State;
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
    /// device_ID
    /// </summary>
    public int? device_ID
    {
        get
        {
            return _device_ID;
        }
        set
        {
            _device_ID = value;
        }
    }
    /// <summary>
    /// device_Name
    /// </summary>
    public string device_Name
    {
        get
        {
            return _device_Name;
        }
        set
        {
            _device_Name = value;
        }
    }
    /// <summary>
    /// device_Type
    /// </summary>
    public string device_Type
    {
        get
        {
            return _device_Type;
        }
        set
        {
            _device_Type = value;
        }
    }
    /// <summary>
    /// device_Remark
    /// </summary>
    public string device_Remark
    {
        get
        {
            return _device_Remark;
        }
        set
        {
            _device_Remark = value;
        }
    }
    /// <summary>
    /// device_State
    /// </summary>
    public int? device_State
    {
        get
        {
            return _device_State;
        }
        set
        {
            _device_State = value;
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
        string strSql = "select [device_ID],[device_Name],[device_Type],[device_Remark],[device_State] from S_DEVICE where device_ID=@device_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@device_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = device_ID;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DEVICE(");
        strSql.Append("device_Name,device_Type,device_Remark,device_State)");
        strSql.Append(" values (");
        strSql.Append("@device_Name,@device_Type,@device_Remark,@device_State); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@device_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@device_Type", SqlDbType.NVarChar,100),
                new SqlParameter("@device_Remark", SqlDbType.NVarChar,200),
                new SqlParameter("@device_State", SqlDbType.Int,4)
        };
        parameters[0].Value = device_Name;
        parameters[1].Value = device_Type;
        parameters[2].Value = device_Remark;
        parameters[3].Value = device_State;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DEVICE set device_Name=@device_Name,device_Type=@device_Type,device_Remark=@device_Remark,device_State=@device_State where device_ID=@device_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@device_ID", SqlDbType.Int,4),
                new SqlParameter("@device_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@device_Type", SqlDbType.NVarChar,100),
                new SqlParameter("@device_Remark", SqlDbType.NVarChar,200),
                new SqlParameter("@device_State", SqlDbType.Int,4)
        };
        parameters[0].Value = device_ID;
        parameters[1].Value = device_Name;
        parameters[2].Value = device_Type;
        parameters[3].Value = device_Remark;
        parameters[4].Value = device_State;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DEVICE where device_ID=@device_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@device_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = device_ID;
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
            device_ID = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (device_ID == null || device_ID == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_device_ID)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@device_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = a_device_ID;
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

