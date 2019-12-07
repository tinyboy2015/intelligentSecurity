using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_TREEMENU: 权限管理（菜单表）
/// </summary>
public partial class S_TREEMENU
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        module_id = null;
        index_no = null;
        module_name = null;
        is_leaf_module = null;
        parent_module_id = null;
        module_status = null;
        module_url = null;
        img_url = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["module_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["module_id"].Equals(null))
            {
                module_id = (int?)ds.Tables[0].Rows[0]["module_id"];
            }
            if (!ds.Tables[0].Rows[0]["index_no"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["index_no"].Equals(null))
            {
                index_no = (int?)ds.Tables[0].Rows[0]["index_no"];
            }
            if (!ds.Tables[0].Rows[0]["module_name"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["module_name"].Equals(null))
            {
                module_name = (string)ds.Tables[0].Rows[0]["module_name"];
            }
            if (!ds.Tables[0].Rows[0]["is_leaf_module"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["is_leaf_module"].Equals(null))
            {
                is_leaf_module = (int?)ds.Tables[0].Rows[0]["is_leaf_module"];
            }
            if (!ds.Tables[0].Rows[0]["parent_module_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["parent_module_id"].Equals(null))
            {
                parent_module_id = (int?)ds.Tables[0].Rows[0]["parent_module_id"];
            }
            if (!ds.Tables[0].Rows[0]["module_status"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["module_status"].Equals(null))
            {
                module_status = (int?)ds.Tables[0].Rows[0]["module_status"];
            }
            if (!ds.Tables[0].Rows[0]["module_url"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["module_url"].Equals(null))
            {
                module_url = (string)ds.Tables[0].Rows[0]["module_url"];
            }
            if (!ds.Tables[0].Rows[0]["img_url"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["img_url"].Equals(null))
            {
                img_url = (string)ds.Tables[0].Rows[0]["img_url"];
            }
        }
    }
    public S_TREEMENU()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_TREEMENU(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_TREEMENU(int? a_module_id)
    {
        dbop = new DataBase();
        module_id = a_module_id;
        GetValue();
    }
    public S_TREEMENU(DataBase a_dbop, int? a_module_id)
    {
        dbop = a_dbop;
        module_id = a_module_id;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _module_id;
    private int? _index_no;
    private string _module_name;
    private int? _is_leaf_module;
    private int? _parent_module_id;
    private int? _module_status;
    private string _module_url;
    private string _img_url;
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
    /// module_id
    /// </summary>
    public int? module_id
    {
        get
        {
            return _module_id;
        }
        set
        {
            _module_id = value;
        }
    }
    /// <summary>
    /// index_no
    /// </summary>
    public int? index_no
    {
        get
        {
            return _index_no;
        }
        set
        {
            _index_no = value;
        }
    }
    /// <summary>
    /// module_name
    /// </summary>
    public string module_name
    {
        get
        {
            return _module_name;
        }
        set
        {
            _module_name = value;
        }
    }
    /// <summary>
    /// is_leaf_module
    /// </summary>
    public int? is_leaf_module
    {
        get
        {
            return _is_leaf_module;
        }
        set
        {
            _is_leaf_module = value;
        }
    }
    /// <summary>
    /// parent_module_id
    /// </summary>
    public int? parent_module_id
    {
        get
        {
            return _parent_module_id;
        }
        set
        {
            _parent_module_id = value;
        }
    }
    /// <summary>
    /// module_status
    /// </summary>
    public int? module_status
    {
        get
        {
            return _module_status;
        }
        set
        {
            _module_status = value;
        }
    }
    /// <summary>
    /// module_url
    /// </summary>
    public string module_url
    {
        get
        {
            return _module_url;
        }
        set
        {
            _module_url = value;
        }
    }
    /// <summary>
    /// img_url
    /// </summary>
    public string img_url
    {
        get
        {
            return _img_url;
        }
        set
        {
            _img_url = value;
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
        string strSql = "select [module_id],[index_no],[module_name],[is_leaf_module],[parent_module_id],[module_status],[module_url],[img_url] from S_TREEMENU where module_id=@module_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@module_id", SqlDbType.Int,4)
        };
        parameters[0].Value = module_id;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_TREEMENU(");
        strSql.Append("module_id,index_no,module_name,is_leaf_module,parent_module_id,module_status,module_url,img_url)");
        strSql.Append(" values (");
        strSql.Append("@module_id,@index_no,@module_name,@is_leaf_module,@parent_module_id,@module_status,@module_url,@img_url)");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@module_id", SqlDbType.Int,4),
                new SqlParameter("@index_no", SqlDbType.Int,4),
                new SqlParameter("@module_name", SqlDbType.NVarChar,510),
                new SqlParameter("@is_leaf_module", SqlDbType.Int,4),
                new SqlParameter("@parent_module_id", SqlDbType.Int,4),
                new SqlParameter("@module_status", SqlDbType.Int,4),
                new SqlParameter("@module_url", SqlDbType.NVarChar,510),
                new SqlParameter("@img_url", SqlDbType.NVarChar,510)
        };
        parameters[0].Value = module_id;
        parameters[1].Value = index_no;
        parameters[2].Value = module_name;
        parameters[3].Value = is_leaf_module;
        parameters[4].Value = parent_module_id;
        parameters[5].Value = module_status;
        parameters[6].Value = module_url;
        parameters[7].Value = img_url;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_TREEMENU set module_id=@module_id,index_no=@index_no,module_name=@module_name,is_leaf_module=@is_leaf_module,parent_module_id=@parent_module_id,module_status=@module_status,module_url=@module_url,img_url=@img_url where module_id=@module_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@module_id", SqlDbType.Int,4),
                new SqlParameter("@index_no", SqlDbType.Int,4),
                new SqlParameter("@module_name", SqlDbType.NVarChar,510),
                new SqlParameter("@is_leaf_module", SqlDbType.Int,4),
                new SqlParameter("@parent_module_id", SqlDbType.Int,4),
                new SqlParameter("@module_status", SqlDbType.Int,4),
                new SqlParameter("@module_url", SqlDbType.NVarChar,510),
                new SqlParameter("@img_url", SqlDbType.NVarChar,510)
        };
        parameters[0].Value = module_id;
        parameters[1].Value = index_no;
        parameters[2].Value = module_name;
        parameters[3].Value = is_leaf_module;
        parameters[4].Value = parent_module_id;
        parameters[5].Value = module_status;
        parameters[6].Value = module_url;
        parameters[7].Value = img_url;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_TREEMENU where module_id=@module_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@module_id", SqlDbType.Int,4)
        };
        parameters[0].Value = module_id;
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
    public static bool Delete(DataBase a_dbop, int? a_module_id)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@module_id", SqlDbType.Int,4)
            };
            parameters[0].Value = a_module_id;
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

