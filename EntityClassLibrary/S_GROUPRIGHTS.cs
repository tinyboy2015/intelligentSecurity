using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using DatabaseOpClassLibrary;

/// <summary>
/// CLASS S_GROUPRIGHTS: 权限管理（组权限）
/// </summary>
public partial class S_GROUPRIGHTS
{
    #region 以下为代码生成器自动生成的代码，请尽量不要修改！
    #region 构造函数
    private void SetDefault()
    {
        group_rig_id = null;
        group_gro_id = null;
        group_menu_id = null;
        group_read = null;
        group_edit = null;
        group_print = null;
        group_add = null;
        group_del = null;
        group_data = null;
    }
    private void GetValue()
    {
        string strSql = GetSelectSql();
        SqlParameter[] parameters = GetSelectParameters();
        DataSet ds = dbop.GetDataSetWithParams(strSql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0]["group_rig_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_rig_id"].Equals(null))
            {
                group_rig_id = (int?)ds.Tables[0].Rows[0]["group_rig_id"];
            }
            if (!ds.Tables[0].Rows[0]["group_gro_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_gro_id"].Equals(null))
            {
                group_gro_id = (int?)ds.Tables[0].Rows[0]["group_gro_id"];
            }
            if (!ds.Tables[0].Rows[0]["group_menu_id"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_menu_id"].Equals(null))
            {
                group_menu_id = (int?)ds.Tables[0].Rows[0]["group_menu_id"];
            }
            if (!ds.Tables[0].Rows[0]["group_read"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_read"].Equals(null))
            {
                group_read = (int?)ds.Tables[0].Rows[0]["group_read"];
            }
            if (!ds.Tables[0].Rows[0]["group_edit"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_edit"].Equals(null))
            {
                group_edit = (int?)ds.Tables[0].Rows[0]["group_edit"];
            }
            if (!ds.Tables[0].Rows[0]["group_print"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_print"].Equals(null))
            {
                group_print = (int?)ds.Tables[0].Rows[0]["group_print"];
            }
            if (!ds.Tables[0].Rows[0]["group_add"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_add"].Equals(null))
            {
                group_add = (int?)ds.Tables[0].Rows[0]["group_add"];
            }
            if (!ds.Tables[0].Rows[0]["group_del"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_del"].Equals(null))
            {
                group_del = (int?)ds.Tables[0].Rows[0]["group_del"];
            }
            if (!ds.Tables[0].Rows[0]["group_data"].Equals(System.DBNull.Value) && !ds.Tables[0].Rows[0]["group_data"].Equals(null))
            {
                group_data = (int?)ds.Tables[0].Rows[0]["group_data"];
            }
        }
    }
    public S_GROUPRIGHTS()
    {
        dbop = new DataBase();
        SetDefault();
    }
    public S_GROUPRIGHTS(DataBase _dbop)
    {
        dbop = _dbop;
        SetDefault();
    }
    public S_GROUPRIGHTS(int? a_group_rig_id)
    {
        dbop = new DataBase();
        group_rig_id = a_group_rig_id;
        GetValue();
    }
    public S_GROUPRIGHTS(DataBase a_dbop, int? a_group_rig_id)
    {
        dbop = a_dbop;
        group_rig_id = a_group_rig_id;
        GetValue();
    }
    #endregion

    #region 私有成员
    private DataBase dbop;
    private RecordSelectedState _recordIsSelected = RecordSelectedState.No;
    private int? _group_rig_id;
    private int? _group_gro_id;
    private int? _group_menu_id;
    private int? _group_read;
    private int? _group_edit;
    private int? _group_print;
    private int? _group_add;
    private int? _group_del;
    private int? _group_data;
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
    /// 自增列
    /// </summary>
    public int? group_rig_id
    {
        get
        {
            return _group_rig_id;
        }
        set
        {
            _group_rig_id = value;
        }
    }
    /// <summary>
    /// 组编号S_GROUPS.group_id
    /// </summary>
    public int? group_gro_id
    {
        get
        {
            return _group_gro_id;
        }
        set
        {
            _group_gro_id = value;
        }
    }
    /// <summary>
    /// 菜单名称
    /// </summary>
    public int? group_menu_id
    {
        get
        {
            return _group_menu_id;
        }
        set
        {
            _group_menu_id = value;
        }
    }
    /// <summary>
    /// 查询权限（ 0，1）1有；2无
    /// </summary>
    public int? group_read
    {
        get
        {
            return _group_read;
        }
        set
        {
            _group_read = value;
        }
    }
    /// <summary>
    /// 修改权限（ 0，1）1有；2无
    /// </summary>
    public int? group_edit
    {
        get
        {
            return _group_edit;
        }
        set
        {
            _group_edit = value;
        }
    }
    /// <summary>
    /// 打印权限（ 0，1）1有；2无
    /// </summary>
    public int? group_print
    {
        get
        {
            return _group_print;
        }
        set
        {
            _group_print = value;
        }
    }
    /// <summary>
    /// 新增权限（ 0，1）1有；2无
    /// </summary>
    public int? group_add
    {
        get
        {
            return _group_add;
        }
        set
        {
            _group_add = value;
        }
    }
    /// <summary>
    /// 删除权限（ 0，1）1有；2无
    /// </summary>
    public int? group_del
    {
        get
        {
            return _group_del;
        }
        set
        {
            _group_del = value;
        }
    }
    /// <summary>
    /// group_data
    /// </summary>
    public int? group_data
    {
        get
        {
            return _group_data;
        }
        set
        {
            _group_data = value;
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
        string strSql = "select [group_rig_id],[group_gro_id],[group_menu_id],[group_read],[group_edit],[group_print],[group_add],[group_del],[group_data] from S_GROUPRIGHTS where group_rig_id=@group_rig_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Select SQL statement.
    /// </summary>
    public SqlParameter[] GetSelectParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_rig_id", SqlDbType.Int,4)
        };
        parameters[0].Value = group_rig_id;
        return parameters;
    }

    /// <summary>
    /// Return Insert SQL statement with parameters.
    /// </summary>
    public string GetInsertSql()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into S_GROUPRIGHTS(");
        strSql.Append("group_gro_id,group_menu_id,group_read,group_edit,group_print,group_add,group_del,group_data)");
        strSql.Append(" values (");
        strSql.Append("@group_gro_id,@group_menu_id,@group_read,@group_edit,@group_print,@group_add,@group_del,@group_data); SELECT @@IDENTITY");
        return strSql.ToString();
    }

    /// <summary>
    /// Return parameters of Insert SQL statement.
    /// </summary>
    public SqlParameter[] GetInsertParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_gro_id", SqlDbType.Int,4),
                new SqlParameter("@group_menu_id", SqlDbType.Int,4),
                new SqlParameter("@group_read", SqlDbType.Int,4),
                new SqlParameter("@group_edit", SqlDbType.Int,4),
                new SqlParameter("@group_print", SqlDbType.Int,4),
                new SqlParameter("@group_add", SqlDbType.Int,4),
                new SqlParameter("@group_del", SqlDbType.Int,4),
                new SqlParameter("@group_data", SqlDbType.Int,4)
        };
        parameters[0].Value = group_gro_id;
        parameters[1].Value = group_menu_id;
        parameters[2].Value = group_read;
        parameters[3].Value = group_edit;
        parameters[4].Value = group_print;
        parameters[5].Value = group_add;
        parameters[6].Value = group_del;
        parameters[7].Value = group_data;
        return parameters;
    }

    /// <summary>
    /// Return Update SQL statement with parameters.
    /// </summary>
    public string GetUpdateSql()
    {
        string strSql = "update S_GROUPRIGHTS set group_gro_id=@group_gro_id,group_menu_id=@group_menu_id,group_read=@group_read,group_edit=@group_edit,group_print=@group_print,group_add=@group_add,group_del=@group_del,group_data=@group_data where group_rig_id=@group_rig_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Update SQL statement.
    /// </summary>
    public SqlParameter[] GetUpdateParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_rig_id", SqlDbType.Int,4),
                new SqlParameter("@group_gro_id", SqlDbType.Int,4),
                new SqlParameter("@group_menu_id", SqlDbType.Int,4),
                new SqlParameter("@group_read", SqlDbType.Int,4),
                new SqlParameter("@group_edit", SqlDbType.Int,4),
                new SqlParameter("@group_print", SqlDbType.Int,4),
                new SqlParameter("@group_add", SqlDbType.Int,4),
                new SqlParameter("@group_del", SqlDbType.Int,4),
                new SqlParameter("@group_data", SqlDbType.Int,4)
        };
        parameters[0].Value = group_rig_id;
        parameters[1].Value = group_gro_id;
        parameters[2].Value = group_menu_id;
        parameters[3].Value = group_read;
        parameters[4].Value = group_edit;
        parameters[5].Value = group_print;
        parameters[6].Value = group_add;
        parameters[7].Value = group_del;
        parameters[8].Value = group_data;
        return parameters;
    }

    /// <summary>
    /// Return Update Delete statement with parameters.
    /// </summary>
    public static string GetDeleteSql()
    {
        string strSql = "delete from S_GROUPRIGHTS where group_rig_id=@group_rig_id";
        return strSql;
    }

    /// <summary>
    /// Return parameters of Delete SQL statement.
    /// </summary>
    public SqlParameter[] GetDeleteParameters()
    {
        SqlParameter[] parameters = {
                new SqlParameter("@group_rig_id", SqlDbType.Int,4)
        };
        parameters[0].Value = group_rig_id;
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
            group_rig_id = Convert.ToInt32(dbop.GetSingleValueWithParams(strSql, parameters));
            if (group_rig_id == null || group_rig_id == 0) return false;
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
    public static bool Delete(DataBase a_dbop, int? a_group_rig_id)
    {
        try
        {
            if (a_dbop == null) a_dbop = new DataBase();
            string strSql = GetDeleteSql();
            SqlParameter[] parameters = {
                    new SqlParameter("@group_rig_id", SqlDbType.Int,4)
            };
            parameters[0].Value = a_group_rig_id;
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

