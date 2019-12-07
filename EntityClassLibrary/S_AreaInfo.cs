using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_AreaInfo: S_AreaInfo
/// </summary>
public partial class S_AreaInfo
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        areaID = null;
        areaNo = null;
        areaType = null;
        areaData = null;
        areaTime = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["areaID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["areaID"].Equals(null))
            {
                areaID = (int?)ds.Tables[0].Rows[0]["areaID"];
            }
            if (!ds.Tables[0].Rows[0]["areaNo"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["areaNo"].Equals(null))
            {
                areaNo = (string)ds.Tables[0].Rows[0]["areaNo"];
            }
            if (!ds.Tables[0].Rows[0]["areaType"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["areaType"].Equals(null))
            {
                areaType = (string)ds.Tables[0].Rows[0]["areaType"];
            }
            if (!ds.Tables[0].Rows[0]["areaData"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["areaData"].Equals(null))
            {
                areaData = (string)ds.Tables[0].Rows[0]["areaData"];
            }
            if (!ds.Tables[0].Rows[0]["areaTime"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["areaTime"].Equals(null))
            {
                areaTime = (DateTime?)ds.Tables[0].Rows[0]["areaTime"];
            }
        }
    }
    public S_AreaInfo()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_AreaInfo(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_AreaInfo(int? a_areaID)
    {
        dbop = new DataBase();
        areaID = a_areaID;
        GetValue();
    }
    public S_AreaInfo(DataBase a_dbop, int? a_areaID)
    {
        dbop = a_dbop;
        areaID = a_areaID;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _areaID;
    private string _areaNo;
    private string _areaType;
    private string _areaData;
    private DateTime? _areaTime;
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
    /// areaID
    /// </summary>
    public int? areaID
    {
        get
        {
            return _areaID;
        }
        set
        {
            _areaID = value;
        }
    }
    /// <summary>
    /// areaNo
    /// </summary>
    public string areaNo
    {
        get
        {
            return _areaNo;
        }
        set
        {
            _areaNo = value;
        }
    }
    /// <summary>
    /// areaType
    /// </summary>
    public string areaType
    {
        get
        {
            return _areaType;
        }
        set
        {
            _areaType = value;
        }
    }
    /// <summary>
    /// areaData
    /// </summary>
    public string areaData
    {
        get
        {
            return _areaData;
        }
        set
        {
            _areaData = value;
        }
    }
    /// <summary>
    /// areaTime
    /// </summary>
    public DateTime? areaTime
    {
        get
        {
            return _areaTime;
        }
        set
        {
            _areaTime = value;
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
        string strSql = "select [areaID],[areaNo],[areaType],[areaData],[areaTime] from S_AreaInfo where areaID=@areaID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@areaID", SqlDbType.Int,4)
        };
        parameters[0].Value = areaID;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_AreaInfo(");
        strSql.Append("areaID,areaNo,areaType,areaData,areaTime)");
        strSql.Append(" values (");
        strSql.Append("@areaID,@areaNo,@areaType,@areaData,@areaTime)");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@areaID", SqlDbType.Int,4),
                new SqlParameter("@areaNo", SqlDbType.VarChar,50),
                new SqlParameter("@areaType", SqlDbType.VarChar,50),
                new SqlParameter("@areaData", SqlDbType.VarChar,8000),
                new SqlParameter("@areaTime", SqlDbType.DateTime,8)
        };
        parameters[0].Value = areaID;
        parameters[1].Value = areaNo;
        parameters[2].Value = areaType;
        parameters[3].Value = areaData;
        parameters[4].Value = areaTime;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_AreaInfo set areaID=@areaID,areaNo=@areaNo,areaType=@areaType,areaData=@areaData,areaTime=@areaTime where areaID=@areaID";

        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@areaID", SqlDbType.Int,4),
                new SqlParameter("@areaNo", SqlDbType.VarChar,50),
                new SqlParameter("@areaType", SqlDbType.VarChar,50),
                new SqlParameter("@areaData", SqlDbType.VarChar,8000),
                new SqlParameter("@areaTime", SqlDbType.DateTime,8)
        };
        parameters[0].Value = areaID;
        parameters[1].Value = areaNo;
        parameters[2].Value = areaType;
        parameters[3].Value = areaData;
        parameters[4].Value = areaTime;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_AreaInfo where areaID=@areaID";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@areaID", SqlDbType.Int,4)
        };
        parameters[0].Value = areaID;
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
            int affectRows = dbop.ExecNonQueryWithParams(strSql, parameters);
            if (affectRows != 1) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_areaID)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@areaID", SqlDbType.Int,4)
            };
            parameters[0].Value = a_areaID;
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

