using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_DROPDOWNLIST_ITEMS: 代码（子表）
/// </summary>
public partial class S_DROPDOWNLIST_ITEMS
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        ddi_seq = null;
        ddi_name = null;
        ddi_value = null;
        ddi_desc = null;
        ddi_order = null;
        ddi_ddID = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["ddi_seq"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_seq"].Equals(null))
            {
                ddi_seq = (int?)ds.Tables[0].Rows[0]["ddi_seq"];
            }
            if (!ds.Tables[0].Rows[0]["ddi_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_name"].Equals(null))
            {
                ddi_name = (string)ds.Tables[0].Rows[0]["ddi_name"];
            }
            if (!ds.Tables[0].Rows[0]["ddi_value"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_value"].Equals(null))
            {
                ddi_value = (string)ds.Tables[0].Rows[0]["ddi_value"];
            }
            if (!ds.Tables[0].Rows[0]["ddi_desc"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_desc"].Equals(null))
            {
                ddi_desc = (string)ds.Tables[0].Rows[0]["ddi_desc"];
            }
            if (!ds.Tables[0].Rows[0]["ddi_order"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_order"].Equals(null))
            {
                ddi_order = (int?)ds.Tables[0].Rows[0]["ddi_order"];
            }
            if (!ds.Tables[0].Rows[0]["ddi_ddID"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["ddi_ddID"].Equals(null))
            {
                ddi_ddID = (string)ds.Tables[0].Rows[0]["ddi_ddID"];
            }
        }
    }
    public S_DROPDOWNLIST_ITEMS()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_DROPDOWNLIST_ITEMS(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_DROPDOWNLIST_ITEMS(int? a_ddi_seq)
    {
        dbop = new DataBase();
        ddi_seq = a_ddi_seq;
        GetValue();
    }
    public S_DROPDOWNLIST_ITEMS(DataBase a_dbop, int? a_ddi_seq)
    {
        dbop = a_dbop;
        ddi_seq = a_ddi_seq;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _ddi_seq;
    private string _ddi_name;
    private string _ddi_value;
    private string _ddi_desc;
    private int? _ddi_order;
    private string _ddi_ddID;
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
    /// ddi_seq
    /// </summary>
    public int? ddi_seq
    {
        get
        {
            return _ddi_seq;
        }
        set
        {
            _ddi_seq = value;
        }
    }
    /// <summary>
    /// ddi_name
    /// </summary>
    public string ddi_name
    {
        get
        {
            return _ddi_name;
        }
        set
        {
            _ddi_name = value;
        }
    }
    /// <summary>
    /// ddi_value
    /// </summary>
    public string ddi_value
    {
        get
        {
            return _ddi_value;
        }
        set
        {
            _ddi_value = value;
        }
    }
    /// <summary>
    /// ddi_desc
    /// </summary>
    public string ddi_desc
    {
        get
        {
            return _ddi_desc;
        }
        set
        {
            _ddi_desc = value;
        }
    }
    /// <summary>
    /// ddi_order
    /// </summary>
    public int? ddi_order
    {
        get
        {
            return _ddi_order;
        }
        set
        {
            _ddi_order = value;
        }
    }
    /// <summary>
    /// ddi_ddID
    /// </summary>
    public string ddi_ddID
    {
        get
        {
            return _ddi_ddID;
        }
        set
        {
            _ddi_ddID = value;
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
        string strSql = "select [ddi_seq],[ddi_name],[ddi_value],[ddi_desc],[ddi_order],[ddi_ddID] from S_DROPDOWNLIST_ITEMS where ddi_seq=@ddi_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@ddi_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = ddi_seq;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_DROPDOWNLIST_ITEMS(");
        strSql.Append("ddi_name,ddi_value,ddi_desc,ddi_order,ddi_ddID)");
        strSql.Append(" values (");
        strSql.Append("@ddi_name,@ddi_value,@ddi_desc,@ddi_order,@ddi_ddID); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@ddi_name", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_value", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_desc", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_order", SqlDbType.Int,4),
                new SqlParameter("@ddi_ddID", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = ddi_name;
        parameters[1].Value = ddi_value;
        parameters[2].Value = ddi_desc;
        parameters[3].Value = ddi_order;
        parameters[4].Value = ddi_ddID;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_DROPDOWNLIST_ITEMS set ddi_name=@ddi_name,ddi_value=@ddi_value,ddi_desc=@ddi_desc,ddi_order=@ddi_order,ddi_ddID=@ddi_ddID where ddi_seq=@ddi_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@ddi_seq", SqlDbType.Int,4),
                new SqlParameter("@ddi_name", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_value", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_desc", SqlDbType.NVarChar,100),
                new SqlParameter("@ddi_order", SqlDbType.Int,4),
                new SqlParameter("@ddi_ddID", SqlDbType.NVarChar,100)
        };
        parameters[0].Value = ddi_seq;
        parameters[1].Value = ddi_name;
        parameters[2].Value = ddi_value;
        parameters[3].Value = ddi_desc;
        parameters[4].Value = ddi_order;
        parameters[5].Value = ddi_ddID;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_DROPDOWNLIST_ITEMS where ddi_seq=@ddi_seq";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@ddi_seq", SqlDbType.Int,4)
        };
        parameters[0].Value = ddi_seq;
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
            ddi_seq = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (ddi_seq == null || ddi_seq == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_ddi_seq)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@ddi_seq", SqlDbType.Int,4)
            };
            parameters[0].Value = a_ddi_seq;
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

