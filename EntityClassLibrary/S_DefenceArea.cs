using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DefenceArea: S_DefenceArea
/// </summary>
public partial class S_DefenceArea
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        DA_seq = null;
        DA_NO = null;
        DA_Name = null;
        DA_JG = null;
        DA_Remark = null;
        DA_Area = null;
        DA_Date = null;
        DA_State = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["DA_seq"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_seq"].Equals(null))
            {
                DA_seq = (int?)ds.Tables[0].Rows[0]["DA_seq"];
            }
            if (!ds.Tables[0].Rows[0]["DA_NO"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_NO"].Equals(null))
            {
                DA_NO = (string)ds.Tables[0].Rows[0]["DA_NO"];
            }
            if (!ds.Tables[0].Rows[0]["DA_Name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_Name"].Equals(null))
            {
                DA_Name = (string)ds.Tables[0].Rows[0]["DA_Name"];
            }
            if (!ds.Tables[0].Rows[0]["DA_JG"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_JG"].Equals(null))
            {
                DA_JG = (int?)ds.Tables[0].Rows[0]["DA_JG"];
            }
            if (!ds.Tables[0].Rows[0]["DA_Remark"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_Remark"].Equals(null))
            {
                DA_Remark = (string)ds.Tables[0].Rows[0]["DA_Remark"];
            }
            if (!ds.Tables[0].Rows[0]["DA_Area"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_Area"].Equals(null))
            {
                DA_Area = (string)ds.Tables[0].Rows[0]["DA_Area"];
            }
            if (!ds.Tables[0].Rows[0]["DA_Date"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_Date"].Equals(null))
            {
                DA_Date = (DateTime?)ds.Tables[0].Rows[0]["DA_Date"];
            }
            if (!ds.Tables[0].Rows[0]["DA_State"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["DA_State"].Equals(null))
            {
                DA_State = (string)ds.Tables[0].Rows[0]["DA_State"];
            }
        }
    }
    public S_DefenceArea()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DefenceArea(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DefenceArea(int? a_DA_seq)
    {
        dbop = new DataBase();
        DA_seq = a_DA_seq;
        GetValue();
    }
    public S_DefenceArea(DataBase a_dbop, int? a_DA_seq)
    {
        dbop = a_dbop;
        DA_seq = a_DA_seq;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _DA_seq;
    private string _DA_NO;
    private string _DA_Name;
    private int? _DA_JG;
    private string _DA_Remark;
    private string _DA_Area;
    private DateTime? _DA_Date;
    private string _DA_State;
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
    /// DA_seq
    /// </summary>
    public int? DA_seq
    {
        get
        {
            return _DA_seq;
        }
        set
        {
            _DA_seq = value;
        }
    }
    /// <summary>
    /// DA_NO
    /// </summary>
    public string DA_NO
    {
        get
        {
            return _DA_NO;
        }
        set
        {
            _DA_NO = value;
        }
    }
    /// <summary>
    /// DA_Name
    /// </summary>
    public string DA_Name
    {
        get
        {
            return _DA_Name;
        }
        set
        {
            _DA_Name = value;
        }
    }
    /// <summary>
    /// DA_JG
    /// </summary>
    public int? DA_JG
    {
        get
        {
            return _DA_JG;
        }
        set
        {
            _DA_JG = value;
        }
    }
    /// <summary>
    /// DA_Remark
    /// </summary>
    public string DA_Remark
    {
        get
        {
            return _DA_Remark;
        }
        set
        {
            _DA_Remark = value;
        }
    }
    /// <summary>
    /// DA_Area
    /// </summary>
    public string DA_Area
    {
        get
        {
            return _DA_Area;
        }
        set
        {
            _DA_Area = value;
        }
    }
    /// <summary>
    /// DA_Date
    /// </summary>
    public DateTime? DA_Date
    {
        get
        {
            return _DA_Date;
        }
        set
        {
            _DA_Date = value;
        }
    }
    /// <summary>
    /// DA_State
    /// </summary>
    public string DA_State
    {
        get
        {
            return _DA_State;
        }
        set
        {
            _DA_State = value;
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
        string strSql = "select [DA_seq],[DA_NO],[DA_Name],[DA_JG],[DA_Remark],[DA_Area],[DA_Date],[DA_State] from S_DefenceArea where DA_seq=@DA_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DA_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = DA_seq;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DefenceArea(");
        strSql.Append("DA_NO,DA_Name,DA_JG,DA_Remark,DA_Area,DA_Date,DA_State)");
        strSql.Append(" values (");
        strSql.Append("@DA_NO,@DA_Name,@DA_JG,@DA_Remark,@DA_Area,@DA_Date,@DA_State); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DA_NO", SqlDbType.NVarChar,100),
                new SqlParameter("@DA_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@DA_JG", SqlDbType.Int,4),
                new SqlParameter("@DA_Remark", SqlDbType.NVarChar,200),
                new SqlParameter("@DA_Area", SqlDbType.NVarChar,8000),
                new SqlParameter("@DA_Date", SqlDbType.DateTime,8),
                new SqlParameter("@DA_State", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DA_NO;
        parameters[1].Value = DA_Name;
        parameters[2].Value = DA_JG;
        parameters[3].Value = DA_Remark;
        parameters[4].Value = DA_Area;
        parameters[5].Value = DA_Date;
        parameters[6].Value = DA_State;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DefenceArea set DA_NO=@DA_NO,DA_Name=@DA_Name,DA_JG=@DA_JG,DA_Remark=@DA_Remark,DA_Area=@DA_Area,DA_Date=@DA_Date,DA_State=@DA_State where DA_seq=@DA_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DA_seq", SqlDbType.Int,4),
                new SqlParameter("@DA_NO", SqlDbType.NVarChar,100),
                new SqlParameter("@DA_Name", SqlDbType.NVarChar,100),
                new SqlParameter("@DA_JG", SqlDbType.Int,4),
                new SqlParameter("@DA_Remark", SqlDbType.NVarChar,200),
                new SqlParameter("@DA_Area", SqlDbType.NVarChar,8000),
                new SqlParameter("@DA_Date", SqlDbType.DateTime,8),
                new SqlParameter("@DA_State", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = DA_seq;
        parameters[1].Value = DA_NO;
        parameters[2].Value = DA_Name;
        parameters[3].Value = DA_JG;
        parameters[4].Value = DA_Remark;
        parameters[5].Value = DA_Area;
        parameters[6].Value = DA_Date;
        parameters[7].Value = DA_State;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DefenceArea where DA_seq=@DA_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@DA_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = DA_seq;
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
            DA_seq = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (DA_seq == null || DA_seq == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_DA_seq)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@DA_seq", SqlDbType.Int,4)
            };
            parameters[0].Value = a_DA_seq;
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

