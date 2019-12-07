using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DEVICE_INTERFACE_PORT: S_DEVICE_INTERFACE_PORT
/// </summary>
public partial class S_DEVICE_INTERFACE_PORT
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        DIP_ID = null;
        DIP_PortID = null;
        DIP_NO = null;
        DIP_ZY = null;
        DIP_SX = null;
        DIP_XX = null;
        DIP_GYYZ = null;
        DIP_GLYZ = null;
        DIP_LXZS = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["DIP_ID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_ID"].Equals(null))
            {
                DIP_ID = (int?)ds.Tables[0].Rows[0]["DIP_ID"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_PortID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_PortID"].Equals(null))
            {
                DIP_PortID = (string)ds.Tables[0].Rows[0]["DIP_PortID"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_NO"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_NO"].Equals(null))
            {
                DIP_NO = (string)ds.Tables[0].Rows[0]["DIP_NO"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_ZY"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_ZY"].Equals(null))
            {
                DIP_ZY = (int?)ds.Tables[0].Rows[0]["DIP_ZY"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_SX"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_SX"].Equals(null))
            {
                DIP_SX = (int?)ds.Tables[0].Rows[0]["DIP_SX"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_XX"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_XX"].Equals(null))
            {
                DIP_XX = (int?)ds.Tables[0].Rows[0]["DIP_XX"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_GYYZ"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_GYYZ"].Equals(null))
            {
                DIP_GYYZ = (int?)ds.Tables[0].Rows[0]["DIP_GYYZ"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_GLYZ"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_GLYZ"].Equals(null))
            {
                DIP_GLYZ = (int?)ds.Tables[0].Rows[0]["DIP_GLYZ"];
            }
            if (!ds.Tables[0].Rows[0]["DIP_LXZS"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DIP_LXZS"].Equals(null))
            {
                DIP_LXZS = (int?)ds.Tables[0].Rows[0]["DIP_LXZS"];
            }
        }
    }
    public S_DEVICE_INTERFACE_PORT()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DEVICE_INTERFACE_PORT(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DEVICE_INTERFACE_PORT(int? a_DIP_ID)
    {
        dbop = new DataBase();
        DIP_ID = a_DIP_ID;
        GetValue();
    }
    public S_DEVICE_INTERFACE_PORT(DataBase a_dbop, int? a_DIP_ID)
    {
        dbop = a_dbop;
        DIP_ID = a_DIP_ID;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _DIP_ID;
    private string _DIP_PortID;
    private string _DIP_NO;
    private int? _DIP_ZY;
    private int? _DIP_SX;
    private int? _DIP_XX;
    private int? _DIP_GYYZ;
    private int? _DIP_GLYZ;
    private int? _DIP_LXZS;
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
    /// DIP_ID
    /// </summary>
    public int? DIP_ID
    {
        get
        {
            return _DIP_ID;
        }
        set
        {
            _DIP_ID = value;
        }
    }
    /// <summary>
    /// DIP_PortID
    /// </summary>
    public string DIP_PortID
    {
        get
        {
            return _DIP_PortID;
        }
        set
        {
            _DIP_PortID = value;
        }
    }
    /// <summary>
    /// DIP_NO
    /// </summary>
    public string DIP_NO
    {
        get
        {
            return _DIP_NO;
        }
        set
        {
            _DIP_NO = value;
        }
    }
    /// <summary>
    /// DIP_ZY
    /// </summary>
    public int? DIP_ZY
    {
        get
        {
            return _DIP_ZY;
        }
        set
        {
            _DIP_ZY = value;
        }
    }
    /// <summary>
    /// DIP_SX
    /// </summary>
    public int? DIP_SX
    {
        get
        {
            return _DIP_SX;
        }
        set
        {
            _DIP_SX = value;
        }
    }
    /// <summary>
    /// DIP_XX
    /// </summary>
    public int? DIP_XX
    {
        get
        {
            return _DIP_XX;
        }
        set
        {
            _DIP_XX = value;
        }
    }
    /// <summary>
    /// DIP_GYYZ
    /// </summary>
    public int? DIP_GYYZ
    {
        get
        {
            return _DIP_GYYZ;
        }
        set
        {
            _DIP_GYYZ = value;
        }
    }
    /// <summary>
    /// DIP_GLYZ
    /// </summary>
    public int? DIP_GLYZ
    {
        get
        {
            return _DIP_GLYZ;
        }
        set
        {
            _DIP_GLYZ = value;
        }
    }
    /// <summary>
    /// DIP_LXZS
    /// </summary>
    public int? DIP_LXZS
    {
        get
        {
            return _DIP_LXZS;
        }
        set
        {
            _DIP_LXZS = value;
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
        string strSql = "select [DIP_ID],[DIP_PortID],[DIP_NO],[DIP_ZY],[DIP_SX],[DIP_XX],[DIP_GYYZ],[DIP_GLYZ],[DIP_LXZS] from S_DEVICE_INTERFACE_PORT where DIP_ID=@DIP_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIP_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DIP_ID;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DEVICE_INTERFACE_PORT(");
        strSql.Append("DIP_PortID,DIP_NO,DIP_ZY,DIP_SX,DIP_XX,DIP_GYYZ,DIP_GLYZ,DIP_LXZS)");
        strSql.Append(" values (");
        strSql.Append("@DIP_PortID,@DIP_NO,@DIP_ZY,@DIP_SX,@DIP_XX,@DIP_GYYZ,@DIP_GLYZ,@DIP_LXZS); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIP_PortID", SqlDbType.NVarChar,100),
                new SqlParameter("@DIP_NO", SqlDbType.NVarChar,100),
                new SqlParameter("@DIP_ZY", SqlDbType.Int,4),
                new SqlParameter("@DIP_SX", SqlDbType.Int,4),
                new SqlParameter("@DIP_XX", SqlDbType.Int,4),
                new SqlParameter("@DIP_GYYZ", SqlDbType.Int,4),
                new SqlParameter("@DIP_GLYZ", SqlDbType.Int,4),
                new SqlParameter("@DIP_LXZS", SqlDbType.Int,4)
        };
        parameters[0].Value = DIP_PortID;
        parameters[1].Value = DIP_NO;
        parameters[2].Value = DIP_ZY;
        parameters[3].Value = DIP_SX;
        parameters[4].Value = DIP_XX;
        parameters[5].Value = DIP_GYYZ;
        parameters[6].Value = DIP_GLYZ;
        parameters[7].Value = DIP_LXZS;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DEVICE_INTERFACE_PORT set DIP_PortID=@DIP_PortID,DIP_NO=@DIP_NO,DIP_ZY=@DIP_ZY,DIP_SX=@DIP_SX,DIP_XX=@DIP_XX,DIP_GYYZ=@DIP_GYYZ,DIP_GLYZ=@DIP_GLYZ,DIP_LXZS=@DIP_LXZS where DIP_ID=@DIP_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIP_ID", SqlDbType.Int,4),
                new SqlParameter("@DIP_PortID", SqlDbType.NVarChar,100),
                new SqlParameter("@DIP_NO", SqlDbType.NVarChar,100),
                new SqlParameter("@DIP_ZY", SqlDbType.Int,4),
                new SqlParameter("@DIP_SX", SqlDbType.Int,4),
                new SqlParameter("@DIP_XX", SqlDbType.Int,4),
                new SqlParameter("@DIP_GYYZ", SqlDbType.Int,4),
                new SqlParameter("@DIP_GLYZ", SqlDbType.Int,4),
                new SqlParameter("@DIP_LXZS", SqlDbType.Int,4)
        };
        parameters[0].Value = DIP_ID;
        parameters[1].Value = DIP_PortID;
        parameters[2].Value = DIP_NO;
        parameters[3].Value = DIP_ZY;
        parameters[4].Value = DIP_SX;
        parameters[5].Value = DIP_XX;
        parameters[6].Value = DIP_GYYZ;
        parameters[7].Value = DIP_GLYZ;
        parameters[8].Value = DIP_LXZS;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DEVICE_INTERFACE_PORT where DIP_ID=@DIP_ID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DIP_ID", SqlDbType.Int,4)
        };
        parameters[0].Value = DIP_ID;
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
            DIP_ID = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (DIP_ID == null || DIP_ID == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_DIP_ID)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@DIP_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = a_DIP_ID;
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

