using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DEVICE_INTERFACE_CAMERA: S_DEVICE_INTERFACE_CAMERA
/// </summary>
public partial class S_DEVICE_INTERFACE_CAMERA
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        DIC_ID = null;
        DIC_NameID = null;
        DIC_Type = null;
        DIC_IP = null;
        DIC_Admin = null;
        DIC_Pwd = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["DIC_ID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_ID"].Equals(null))
            {
                DIC_ID = (int?)ds.Tables[0].Rows[0]["DIC_ID"];
            }
            if (!ds.Tables[0].Rows[0]["DIC_NameID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_NameID"].Equals(null))
            {
                DIC_NameID = (string)ds.Tables[0].Rows[0]["DIC_NameID"];
            }
            if (!ds.Tables[0].Rows[0]["DIC_Type"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_Type"].Equals(null))
            {
                DIC_Type = (string)ds.Tables[0].Rows[0]["DIC_Type"];
            }
            if (!ds.Tables[0].Rows[0]["DIC_IP"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_IP"].Equals(null))
            {
                DIC_IP = (string)ds.Tables[0].Rows[0]["DIC_IP"];
            }
            if (!ds.Tables[0].Rows[0]["DIC_Admin"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_Admin"].Equals(null))
            {
                DIC_Admin = (string)ds.Tables[0].Rows[0]["DIC_Admin"];
            }
            if (!ds.Tables[0].Rows[0]["DIC_Pwd"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIC_Pwd"].Equals(null))
            {
                DIC_Pwd = (string)ds.Tables[0].Rows[0]["DIC_Pwd"];
            }
        }
    }
    public S_DEVICE_INTERFACE_CAMERA()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DEVICE_INTERFACE_CAMERA(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DEVICE_INTERFACE_CAMERA(int? a_DIC_ID)
    {
        dbop = new DataBase();
        DIC_ID = a_DIC_ID;
        GetValue();
    }
    public S_DEVICE_INTERFACE_CAMERA(DataBase a_dbop, int? a_DIC_ID)
    {
        dbop = a_dbop;
        DIC_ID = a_DIC_ID;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _DIC_ID;
    private string _DIC_NameID;
    private string _DIC_Type;
    private string _DIC_IP;
    private string _DIC_Admin;
    private string _DIC_Pwd;
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
    /// DIC_ID
    /// </summary>
    public int? DIC_ID
    {
        get
        {
            return _DIC_ID;
        }
        set
        {
            _DIC_ID = value;
        }
    }
    /// <summary>
    /// DIC_NameID
    /// </summary>
    public string DIC_NameID
    {
        get
        {
            return _DIC_NameID;
        }
        set
        {
            _DIC_NameID = value;
        }
    }
    /// <summary>
    /// DIC_Type
    /// </summary>
    public string DIC_Type
    {
        get
        {
            return _DIC_Type;
        }
        set
        {
            _DIC_Type = value;
        }
    }
    /// <summary>
    /// DIC_IP
    /// </summary>
    public string DIC_IP
    {
        get
        {
            return _DIC_IP;
        }
        set
        {
            _DIC_IP = value;
        }
    }
    /// <summary>
    /// DIC_Admin
    /// </summary>
    public string DIC_Admin
    {
        get
        {
            return _DIC_Admin;
        }
        set
        {
            _DIC_Admin = value;
        }
    }
    /// <summary>
    /// DIC_Pwd
    /// </summary>
    public string DIC_Pwd
    {
        get
        {
            return _DIC_Pwd;
        }
        set
        {
            _DIC_Pwd = value;
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
        string strSql = "select [DIC_ID],[DIC_NameID],[DIC_Type],[DIC_IP],[DIC_Admin],[DIC_Pwd] from S_DEVICE_INTERFACE_CAMERA where DIC_ID=@DIC_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIC_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DIC_ID;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DEVICE_INTERFACE_CAMERA(");
        strSql.Append("DIC_NameID,DIC_Type,DIC_IP,DIC_Admin,DIC_Pwd)");
        strSql.Append(" values (");
        strSql.Append("@DIC_NameID,@DIC_Type,@DIC_IP,@DIC_Admin,@DIC_Pwd); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIC_NameID", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Type", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_IP", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Admin", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Pwd", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DIC_NameID;
        parameters[1].Value = DIC_Type;
        parameters[2].Value = DIC_IP;
        parameters[3].Value = DIC_Admin;
        parameters[4].Value = DIC_Pwd;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DEVICE_INTERFACE_CAMERA set DIC_NameID=@DIC_NameID,DIC_Type=@DIC_Type,DIC_IP=@DIC_IP,DIC_Admin=@DIC_Admin,DIC_Pwd=@DIC_Pwd where DIC_ID=@DIC_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIC_ID", SqlDbType.Int,4),
                new SqlParameter("@DIC_NameID", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Type", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_IP", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Admin", SqlDbType.NVarChar,100),
                new SqlParameter("@DIC_Pwd", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DIC_ID;
        parameters[1].Value = DIC_NameID;
        parameters[2].Value = DIC_Type;
        parameters[3].Value = DIC_IP;
        parameters[4].Value = DIC_Admin;
        parameters[5].Value = DIC_Pwd;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DEVICE_INTERFACE_CAMERA where DIC_ID=@DIC_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIC_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DIC_ID;
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
            DIC_ID = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (DIC_ID == null || DIC_ID == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_DIC_ID)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@DIC_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = a_DIC_ID;
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

