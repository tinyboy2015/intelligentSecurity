using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DEVICE_INTERFACE: S_DEVICE_INTERFACE
/// </summary>
public partial class S_DEVICE_INTERFACE
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        DI_ID = null;
        DI_Name = null;
        DI_Desc = null;
        DI_DeviceID = null;
        DI_Order = null;
        DI_Date = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["DI_ID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_ID"].Equals(null))
            {
                DI_ID = (int?)ds.Tables[0].Rows[0]["DI_ID"];
            }
            if (!ds.Tables[0].Rows[0]["DI_Name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_Name"].Equals(null))
            {
                DI_Name = (string)ds.Tables[0].Rows[0]["DI_Name"];
            }
            if (!ds.Tables[0].Rows[0]["DI_Desc"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_Desc"].Equals(null))
            {
                DI_Desc = (string)ds.Tables[0].Rows[0]["DI_Desc"];
            }
            if (!ds.Tables[0].Rows[0]["DI_DeviceID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_DeviceID"].Equals(null))
            {
                DI_DeviceID = (string)ds.Tables[0].Rows[0]["DI_DeviceID"];
            }
            if (!ds.Tables[0].Rows[0]["DI_Order"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_Order"].Equals(null))
            {
                DI_Order = (int?)ds.Tables[0].Rows[0]["DI_Order"];
            }
            if (!ds.Tables[0].Rows[0]["DI_Date"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DI_Date"].Equals(null))
            {
                DI_Date = (DateTime?)ds.Tables[0].Rows[0]["DI_Date"];
            }
        }
    }
    public S_DEVICE_INTERFACE()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DEVICE_INTERFACE(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DEVICE_INTERFACE(int? a_DI_ID)
    {
        dbop = new DataBase();
        DI_ID = a_DI_ID;
        GetValue();
    }
    public S_DEVICE_INTERFACE(DataBase a_dbop, int? a_DI_ID)
    {
        dbop = a_dbop;
        DI_ID = a_DI_ID;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _DI_ID;
    private string _DI_Name;
    private string _DI_Desc;
    private string _DI_DeviceID;
    private int? _DI_Order;
    private DateTime? _DI_Date;
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
    /// DI_ID
    /// </summary>
    public int? DI_ID
    {
        get
        {
            return _DI_ID;
        }
        set
        {
            _DI_ID = value;
        }
    }
    /// <summary>
    /// DI_Name
    /// </summary>
    public string DI_Name
    {
        get
        {
            return _DI_Name;
        }
        set
        {
            _DI_Name = value;
        }
    }
    /// <summary>
    /// DI_Desc
    /// </summary>
    public string DI_Desc
    {
        get
        {
            return _DI_Desc;
        }
        set
        {
            _DI_Desc = value;
        }
    }
    /// <summary>
    /// DI_DeviceID
    /// </summary>
    public string DI_DeviceID
    {
        get
        {
            return _DI_DeviceID;
        }
        set
        {
            _DI_DeviceID = value;
        }
    }
    /// <summary>
    /// DI_Order
    /// </summary>
    public int? DI_Order
    {
        get
        {
            return _DI_Order;
        }
        set
        {
            _DI_Order = value;
        }
    }
    /// <summary>
    /// DI_Date
    /// </summary>
    public DateTime? DI_Date
    {
        get
        {
            return _DI_Date;
        }
        set
        {
            _DI_Date = value;
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
        string strSql = "select [DI_ID],[DI_Name],[DI_Desc],[DI_DeviceID],[DI_Order],[DI_Date] from S_DEVICE_INTERFACE where DI_ID=@DI_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DI_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DI_ID;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DEVICE_INTERFACE(");
        strSql.Append("DI_Name,DI_Desc,DI_DeviceID,DI_Order,DI_Date)");
        strSql.Append(" values (");
        strSql.Append("@DI_Name,@DI_Desc,@DI_DeviceID,@DI_Order,@DI_Date); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DI_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@DI_Desc", SqlDbType.NVarChar,200),
                new SqlParameter("@DI_DeviceID", SqlDbType.NVarChar,100),
                new SqlParameter("@DI_Order", SqlDbType.Int,4),
                new SqlParameter("@DI_Date", SqlDbType.DateTime,8)
        };
        parameters[0].Value = DI_Name;
        parameters[1].Value = DI_Desc;
        parameters[2].Value = DI_DeviceID;
        parameters[3].Value = DI_Order;
        parameters[4].Value = DI_Date;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DEVICE_INTERFACE set DI_Name=@DI_Name,DI_Desc=@DI_Desc,DI_DeviceID=@DI_DeviceID,DI_Order=@DI_Order,DI_Date=@DI_Date where DI_ID=@DI_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DI_ID", SqlDbType.Int,4),
                new SqlParameter("@DI_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@DI_Desc", SqlDbType.NVarChar,200),
                new SqlParameter("@DI_DeviceID", SqlDbType.NVarChar,100),
                new SqlParameter("@DI_Order", SqlDbType.Int,4),
                new SqlParameter("@DI_Date", SqlDbType.DateTime,8)
        };
        parameters[0].Value = DI_ID;
        parameters[1].Value = DI_Name;
        parameters[2].Value = DI_Desc;
        parameters[3].Value = DI_DeviceID;
        parameters[4].Value = DI_Order;
        parameters[5].Value = DI_Date;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DEVICE_INTERFACE where DI_ID=@DI_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DI_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DI_ID;
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
            DI_ID = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (DI_ID == null || DI_ID == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_DI_ID)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@DI_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = a_DI_ID;
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

