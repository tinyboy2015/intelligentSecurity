using System;
using System.Data;
using System.Configuration;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Collections;
using MySql.Data.MySqlClient;

namespace DatabaseOpClassLibrary
{
    public class DataBase
    {
           #region 私有变量
            protected Database _db;
            private DbProviderFactory dbpf = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["QSFB"].ProviderName.ToString());
            private DbConnection _dbConn;
            protected bool _inTrans = false;
            private DataSet ds;
            private DbTransaction dbTrans;
            private DbCommand dbCommand;


            private MySqlConnection SqlCn;
            private MySqlCommand SqlCm;
            private MySqlDataAdapter objdr;
            private MySqlCommand objcomm;

            //private string _strCon;
            //public SqlConnection _conn;
            #endregion


            #region Execute Multi SQL command
            /// Execute Multi SQL command;
            /// 
            /// Parameter Hashtable is the SQL commands（<key>: SQL command; <value>: command's DbParameter[]）
            public Boolean ExecuteSqlTran(SortedList SQLStringList)
            {
                OpenDB();
                Boolean ifSucc = false;
                int lastNumber = -1;
                using (DbConnection dbconn = _db.CreateConnection())
                {
                    dbconn.Open();
                    DbTransaction dbtran = dbconn.BeginTransaction();
                    try
                    {
                        for (int i = 0; i < SQLStringList.Count; i++)
                        {
                            string strsql = SQLStringList.GetKey(i).ToString().Trim();

                            if (strsql.Trim().Length > 1)
                            {
                                DbCommand dbCommand = _db.GetSqlStringCommand(strsql);
                                object valuei = SQLStringList.GetByIndex(i);
                                if (valuei != null)
                                {
                                    DbParameter[] cmdParms = (DbParameter[])valuei;
                                    SetCmdParams(dbCommand, cmdParms);
                                }
                                _db.ExecuteNonQuery(dbCommand, dbtran);
                            }
                        }
                        dbtran.Commit();
                        ifSucc = true;
                    }
                    catch
                    {
                        dbtran.Rollback();
                        ifSucc = false;
                    }
                    finally
                    {
                        dbconn.Close();
                    }
                }
                return ifSucc;
            }
            #endregion

            /// <summary>
            /// 数据库连接
            /// </summary>
            protected void OpenDB()
            {
                if (!_inTrans) _db = DatabaseFactory.CreateDatabase("QSFB");
            }

            /// <summary>
            /// 参数处理
            /// </summary>
            /// <param name="dbc">DbCommand 数据命令</param>
            /// <param name="dbParams">参数</param>
            protected void SetCmdParams(DbCommand dbc, DbParameter[] dbParams)
            {
                if (_db != null)
                {
                    for (int i = 0; i < dbParams.Length; i++)
                    {
                        _db.AddInParameter(dbc, dbParams[i].ParameterName, dbParams[i].DbType, dbParams[i].Value);
                    }
                }
            }


            #region Return DataSet

            /// <summary>
            /// 根据SQL语句返回DataSet
            /// </summary>
            /// <param name="sqlCmd">SQL语句</param>
            /// <returns>数据集</returns>
            public DataSet GetDataSet(string sqlCmd)
            {
                OpenDB();

                dbCommand = _db.GetSqlStringCommand(sqlCmd);
                ds = this.ExecuteDataSet(dbCommand);
                return ds;
            }

            /// <summary>
            /// 根据SQL语句和参数数组返回DataSet
            /// </summary>
            /// <param name="sqlCmd">带参数的SQL语句</param>
            /// <param name="dbParams">参数数组</param>
            /// <returns>数据集</returns>
            public DataSet GetDataSetWithParams(string sqlCmd, DbParameter[] dbParams)
            {
                OpenDB();

                dbCommand = _db.GetSqlStringCommand(sqlCmd);
                SetCmdParams(dbCommand, dbParams);
                ds = this.ExecuteDataSet(dbCommand);
                return ds;
            }

            /// <summary>
            /// 根据存储过程名字返回DataSet
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <returns>数据集</returns>
            public DataSet GetDataSetFromSP(string spName)
            {
                OpenDB();

                dbCommand = _db.GetStoredProcCommand(spName);
                ds = this.ExecuteDataSet(dbCommand);
                return ds;
            }

            /// <summary>
            /// 根据带参数的存储过程返回数据集
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <param name="dbParams">存储过程参数数组</param>
            /// <returns></returns>
            public DataSet GetDataSetFromSPWithParams(string spName, DbParameter[] dbParams)
            {
                OpenDB();

                dbCommand = _db.GetStoredProcCommand(spName, dbParams);
                ds = this.ExecuteDataSet(dbCommand);
                return ds;
            }
            #endregion

            #region

            /// <summary>
            /// 打开数据库连接
            /// </summary>
            protected void open()
            {
                if (SqlCn == null || SqlCn.State == System.Data.ConnectionState.Closed)
                {
                    SqlCn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["QSFB"].ConnectionString); //ConfigurationSettings.AppSettings.Get

                    SqlCn.Open();
                }
            }

            /// <summary>
            /// 关闭数据库连接
            /// </summary>
            public void Close()
            {
                if (SqlCn != null)
                {
                    SqlCn.Close();
                }
            }

            /// <summary>
            /// 建立SqlCommand，无参数
            /// </summary>
            /// <param name="strSql">存储过程名或是SQL语句</param>
            /// <param name="iFlag">1：存储过程；0：SQL语句</param>
            /// <returns>SqlCommand</returns>
            public MySqlCommand CreateCommand(string strSql, int iFlag)
            {
                open();

                MySqlCommand cmd = new MySqlCommand(strSql, SqlCn);

                if (iFlag == 1)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }

                return cmd;
            }

            /// <summary>
            /// 建立SqlCommand，有参数
            /// </summary>
            /// <param name="strSql">存储过程名或是SQL语句</param>
            /// <param name="Params">参数集</param>
            /// <param name="iFlag">1：存储过程；0：SQL语句</param>
            /// <returns>SqlCommand</returns>
            public MySqlCommand CreateCommand(string strSql, MySqlParameter[] Params, int iFlag)
            {
                open();

                MySqlCommand cmd = new MySqlCommand(strSql, SqlCn);

                if (iFlag == 1)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }

                if (Params != null)
                {
                    foreach (MySqlParameter parameter in Params)
                    {
                        if (parameter != null)

                            cmd.Parameters.Add(parameter);
                    }
                }

                cmd.Parameters.Add(
                    new MySqlParameter("@ReturnValue", MySqlDbType.Int32, 4,
                    ParameterDirection.ReturnValue, false, 0, 0,
                    string.Empty, DataRowVersion.Default, null));

                return cmd;
            }

            /// <summary>
            /// 执行sql语句，返回SqlDataReader
            /// </summary>
            /// <param name="strsql">Sql语句</param>
            /// <returns></returns>
            public MySqlDataAdapter GetReader(string strsql)
            {
                //OpenDB();

                //objcomm = CreateCommand(strsql, 0);

                //objdr = objcomm.ExecuteReader();

                return null;
            }

            /// <summary>
            /// 执行sql语句，返回SqlDataReader
            /// </summary>
            /// <param name="strsql">Sql语句</param>
            /// <param name="Params">参数集</param>
            /// <returns></returns>
            public MySqlDataReader GetReader(string strsql, MySqlParameter[] Params)
            {
                //OpenDB();

                //objcomm = CreateCommand(strsql, Params, 0);

                ////objdr = objcomm.ExecuteReader();
                //objdr = objcomm.ExecuteReader();

                return null;
            }

            /// <summary>
            /// 执行sql语句，返回SqlDataReader
            /// </summary>
            /// <param name="strsql">Sql语句或是存储过程名称</param>
            /// <param name="Params">参数集</param>
            /// <param name="iFlag">1：存储过程；0：SQL语句</param>
            /// <returns></returns>
            public MySqlDataReader GetReader(string strsql, MySqlParameter[] Params, int iFlag)
            {
                //OpenDB();

                //objcomm = CreateCommand(strsql, Params, iFlag);

                //objdr = objcomm.ExecuteReader();

                return null;
            }

            /// <summary>
            /// Make input param.
            /// </summary>
            /// <param name="ParamName">Name of param.</param>
            /// <param name="DbType">Param type.</param>
            /// <param name="Size">Param size.</param>
            /// <param name="Value">Param value.</param>
            /// <returns>New parameter.</returns>
            public MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
            {
                return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
            }

            /// <summary>
            /// Make Output param.
            /// </summary>
            /// <param name="ParamName">Name of param.</param>
            /// <param name="DbType">Param type.</param>
            /// <param name="Size">Param size.</param>
            /// <returns>New parameter.</returns>
            public MySqlParameter MakeOutParam(string ParamName, MySqlDbType DbType, int Size)
            {
                return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
            }

            /// <summary>
            /// Make stored procedure param.
            /// </summary>
            /// <param name="ParamName">Name of param.</param>
            /// <param name="DbType">Param type.</param>
            /// <param name="Size">Param size.</param>
            /// <param name="Direction">Parm direction.</param>
            /// <param name="Value">Param value.</param>
            /// <returns>New parameter.</returns>
            public MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, System.Int32 Size, ParameterDirection Direction, object Value)
            {
                MySqlParameter param;

                if (Size > 0)
                    param = new MySqlParameter(ParamName, DbType, Size);
                else
                    param = new MySqlParameter(ParamName, DbType);

                param.Direction = Direction;

                if (!(Direction == ParameterDirection.Output && Value == null))
                {
                    if (Value == null || Value.ToString().Trim() == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    else
                    {
                        param.Value = Value;
                    }
                }
                return param;
            }

            /// <summary>
            /// Run Sql statements, by prams
            /// </summary>
            /// <param name="sqlCmd">Sql statements.</param>
            /// <param name="dbParams">Sql statements params.</param>
            /// <returns>影响的行数</returns>
            public int RunProcRtnInt(string sqlCmd, MySqlParameter[] dbParams)
            {
                try
                {
                    int iReturn = 0;

                    OpenDB();

                    dbCommand = _db.GetSqlStringCommand(sqlCmd);

                    SetCmdParams(dbCommand, dbParams);

                    iReturn = this.ExecuteNonQuery(dbCommand);

                    return iReturn;
                }
                catch (MySqlException exp)
                {
                    throw new Exception("------ \nErrorNumber:" + exp.Number + " \nMessage:" + exp.Message + " \n------ ");
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            /// <summary>
            /// Run stored procedure, by prams
            /// </summary>
            /// <param name="procName">Name of stored procedure.</param>
            /// <param name="dbParams">Stored procedure params.</param>
            /// <param name="iFlag">1：stored procedure；0：sql statements</param>
            /// <returns>影响的行数</returns>
            public int RunProcRtnInt(string procName, MySqlParameter[] dbParams, int iFlag)
            {
                try
                {
                    int iReturn = 0;

                    MySqlCommand cmd = CreateCommand(procName, iFlag);

                    iReturn = (int)cmd.ExecuteNonQuery();

                    this.Close();

                    return iReturn;
                }
                catch (MySqlException exp)
                {
                    throw new Exception("------ \nErrorNumber:" + exp.Number + " \nMessage:" + exp.Message + " \n------ ");
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            /// <summary>
            ///  Run stored procedure ,by prams
            /// </summary>
            /// <param name="procName">Name of stored procedure.</param>
            /// <param name="prams">Stored procedure params.</param>
            /// <param name="iFlag">标记(1：存储过程；2：非存储过程)</param>
            /// <returns>返回首行首列</returns>
            public object RunProcObject(string procName, MySqlParameter[] prams, int iFlag)
            {
                try
                {
                    object objResult;

                    MySqlCommand cmd = CreateCommand(procName, prams, iFlag);

                    objResult = cmd.ExecuteScalar();

                    this.Close();

                    return objResult;
                }
                catch (MySqlException exp)
                {
                    throw new Exception("------ \nErrorNumber:" + exp.Number + " \nMessage:" + exp.Message + " \n------ ");
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            #region return DataRow

            /// <summary>
            /// Run stored procedure or Sql, by prams
            /// </summary>
            /// <param name="procName">Name of stored procedure or Sql.</param>
            /// <param name="prams">SqlParameter Of Stored procedure or Sql.</param>
            /// <param name="iFlag">标记(1：存储过程；2：非存储过程)</param>
            /// <param name="dataRow">Return result of procedure or Sql.</param>
            public void RunProcRtnDataRow(string procName, MySqlParameter[] prams, int iFlag, out DataRow dataRow)
            {
                MySqlCommand cmd = CreateCommand(procName, prams, iFlag);

                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                ada.Fill(tbl);

                if (tbl.Rows.Count > 0)
                {
                    dataRow = tbl.Rows[0];
                }
                else
                {
                    dataRow = null;
                }
            }

            #endregion

            /**********************************************/

            #endregion

            #region Return Single Value

            /// <summary>
            /// 根据SQL语句返回单一值
            /// </summary>
            /// <param name="sqlCmd">SQL语句</param>
            /// <returns>Object</returns>
            public object GetSingleValue(string sqlCmd)
            {
                OpenDB();

                dbCommand = _db.GetSqlStringCommand(sqlCmd);
                return this.ExecuteScalar(dbCommand);
            }

            /// <summary>
            /// 根据带参数的SQL语句返回单一值
            /// </summary>
            /// <param name="sqlCmd">SQL语句</param>
            /// <param name="dbParams">对应的参数数组</param>
            /// <returns>Object</returns>
            public object GetSingleValueWithParams(string sqlCmd, DbParameter[] dbParams)
            {
                OpenDB();
                dbCommand = _db.GetSqlStringCommand(sqlCmd);
                SetCmdParams(dbCommand, dbParams);
                return this.ExecuteScalar(dbCommand);
            }

            /// <summary>
            /// 根据存储过程名字返回单一值
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <returns>Object</returns>
            public object GetSingleValueFromSP(string spName)
            {
                OpenDB();
                dbCommand = _db.GetStoredProcCommand(spName);
                return this.ExecuteScalar(dbCommand);
            }

            /// <summary>
            /// 根据带参数的存储过程名字返回单一值
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <param name="dbParams">对应的参数数组</param>
            /// <returns>Object</returns>
            public object GetSingleValueFromSPWithParams(string spName, DbParameter[] dbParams)
            {
                OpenDB();
                dbCommand = _db.GetStoredProcCommand(spName, dbParams);
                return this.ExecuteScalar(dbCommand);
            }

            #endregion

            #region ExecNonQuery
            /// <summary>
            /// 执行SQL语句
            /// </summary>
            /// <param name="sqlCmd">SQL语句</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQuery(string sqlCmd)
            {
                OpenDB();

                DbCommand dbCommand = _db.GetSqlStringCommand(sqlCmd);
                return this.ExecuteNonQuery(dbCommand);
            }

            /// <summary>
            /// 执行带参数的SQL语句
            /// </summary>
            /// <param name="sqlCmd">SQL语句</param>
            /// <param name="dbParams">对应的参数数组</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQueryWithParams(string sqlCmd, DbParameter[] dbParams)
            {
                OpenDB();

                DbCommand dbCommand = _db.GetSqlStringCommand(sqlCmd);
                SetCmdParams(dbCommand, dbParams);
                return this.ExecuteNonQuery(dbCommand);
            }

            /// <summary>
            /// 执行存储过程
            /// </summary>
            /// <param name="spName">存储过程名称</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQueryWithFromSP(string spName)
            {
                OpenDB();

                DbCommand dbCommand = _db.GetStoredProcCommand(spName);
                return this.ExecuteNonQuery(dbCommand);
            }

            /// <summary>
            /// 执行带参数的存储过程
            /// </summary>
            /// <param name="spName">存储过程名称</param>
            /// <param name="dbParams">参数数组</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQueryWithFromSP(string spName, DbParameter[] dbParams)
            {
                OpenDB();

                DbCommand dbCommand = _db.GetStoredProcCommand(spName, dbParams);
                return this.ExecuteNonQuery(dbCommand);
            }
            #endregion

            #region 事务处理
            /// <summary>
            /// 开始一个事务，在一个实例中只能有一个事务出现
            /// </summary>
            /// <returns>成功与否</returns>
            public bool BeginTrans()
            {
                if (_inTrans) return false;
                try
                {
                    OpenDB();
                    _dbConn = _db.CreateConnection();
                    _dbConn.Open();
                    dbTrans = _dbConn.BeginTransaction();
                    _inTrans = true;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 提交当前事务
            /// </summary>
            /// <returns>成功与否</returns>
            public bool CommitTrans()
            {
                if (!_inTrans) return false;
                try
                {
                    dbTrans.Commit();
                    _inTrans = false;
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    _dbConn.Close();
                }
            }

            /// <summary>
            /// 回滚当前事务
            /// </summary>
            /// <returns>成功与否</returns>
            public bool RollbackTrans()
            {
                if (!_inTrans) return false;
                try
                {
                    dbTrans.Rollback();
                    _inTrans = false;
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    _dbConn.Close();
                }
            }
            #endregion

            #region 包括事务处理的内部私有方法

            private DataSet ExecuteDataSet(DbCommand dbCommand)
            {
                if (_inTrans)
                {
                    return _db.ExecuteDataSet(dbCommand, dbTrans);
                }
                else
                {
                    return _db.ExecuteDataSet(dbCommand);
                }
            }

            private object ExecuteScalar(DbCommand dbCommand)
            {
                object obj;

                if (_inTrans)
                {
                    obj = _db.ExecuteScalar(dbCommand, dbTrans);
                }
                else
                {
                    obj = _db.ExecuteScalar(dbCommand);
                }

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }

            private int ExecuteNonQuery(DbCommand dbCommand)
            {
                if (_inTrans)
                {
                    return _db.ExecuteNonQuery(dbCommand, dbTrans);
                }
                else
                {
                    return _db.ExecuteNonQuery(dbCommand);
                }
            }
            #endregion

            #region 扩充的DBOP功能
            /// <summary>
            /// 利用格式化的SQL语句返回DataSet
            /// </summary>
            /// <param name="formatSql">格式化的Sql语句</param>
            /// <param name="paramValues">各参数的值(个数应该和SQL语句中的参数对应)</param>
            /// <returns>DataSet</returns>
            public DataSet GetDataSetWithParams(string formatSql, params Object[] paramValues)
            {
                if ((paramValues != null) && (paramValues.Length > 0))
                {
                    SqlFormatter formatter = new SqlFormatter();
                    formatter.Format(formatSql, paramValues);
                    return GetDataSetWithParams(formatter.Sql, formatter.Parameters);
                }
                return GetDataSet(formatSql);

            }

            /// <summary>
            /// 利用格式化的SQL语句返回单个值
            /// </summary>
            /// <param name="formatSql">格式化的Sql语句</param>
            /// <param name="paramValues">各参数的值(个数应该和SQL语句中的参数对应)</param>
            /// <returns>Object</returns>
            public object GetSingleValueWithParams(string formatSql, params Object[] paramValues)
            {
                if ((paramValues != null) && (paramValues.Length > 0))
                {
                    SqlFormatter formatter = new SqlFormatter();
                    formatter.Format(formatSql, paramValues);
                    return GetSingleValueWithParams(formatter.Sql, formatter.Parameters);
                }
                return GetSingleValue(formatSql);
            }

            /// <summary>
            /// 执行格式化的SQL语句
            /// </summary>
            /// <param name="formatSql">格式化的Sql语句</param>
            /// <param name="paramValues">各参数的值(个数应该和SQL语句中的参数对应)</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQueryWithParams(string formatSql, params Object[] paramValues)
            {
                if ((paramValues != null) && (paramValues.Length > 0))
                {
                    SqlFormatter formatter = new SqlFormatter();
                    formatter.Format(formatSql, paramValues);
                    return ExecNonQueryWithParams(formatter.Sql, formatter.Parameters);
                }
                return ExecNonQueryWithParams(formatSql);
            }

            /// <summary>
            /// 利用格式化的SQL语句返回DataReader
            /// </summary>
            /// <param name="formatSql">格式化的Sql语句</param>
            /// <param name="paramValues">各参数的值(个数应该和SQL语句中的参数对应)</param>
            /// <returns>IDataReader</returns>
            public IDataReader GetDataReaderWithParams(string formatSql, params Object[] paramValues)
            {
                if ((paramValues != null) && (paramValues.Length > 0))
                {
                    SqlFormatter formatter = new SqlFormatter();
                    formatter.Format(formatSql, paramValues);
                    return GetDataReaderWithParams(formatter.Sql, formatter.Parameters);
                }
                return GetDataReaderWithParams(formatSql);
            }

            #endregion

            #region 转换参数Dictionary为SqlParameter

            private MySqlParameter[] FormatParams(System.Collections.Generic.Dictionary<string, string> Params, System.Collections.Generic.Dictionary<string, string> ParamsType)
            {
                MySqlParameter[] parameters = new MySqlParameter[Params.Count];
                int i = 0;
                foreach (System.Collections.Generic.KeyValuePair<string, string> member in Params)
                {
                    parameters[i] = new MySqlParameter();
                    parameters[i].ParameterName = "@" + member.Key;
                    parameters[i].Value = ParamsType != null && ParamsType.ContainsKey(member.Key) ? ConvertValue(ParamsType[member.Key], member.Value) : member.Value;
                    parameters[i].MySqlDbType = ParamsType != null && ParamsType.ContainsKey(member.Key) ? ConvertType(ParamsType[member.Key]) : MySqlDbType.VarChar;
                    i++;
                }
                return parameters;
            }

            private object ConvertValue(string type, string value)
            {
                switch (type)
                {
                    case "int": return Convert.ToInt32(value);
                    case "decimal": return Convert.ToDecimal(value);
                    case "datetime": return Convert.ToDateTime(value);
                    default: return value;
                }
            }

            private MySqlDbType ConvertType(string type)
            {
                switch (type)
                {
                    case "int": return MySqlDbType.Int32;
                    case "decimal": return MySqlDbType.Decimal;
                    case "datetime": return MySqlDbType.DateTime;
                    default: return MySqlDbType.VarChar;
                }
            }

            /// <summary>
            /// 根据带参数的存储过程返回数据集
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <param name="dbParams">存储过程参数数组</param>
            /// <returns></returns>
            public DataSet GetDataSetFromSP(string spName, System.Collections.Generic.Dictionary<string, string> dbParams, System.Collections.Generic.Dictionary<string, string> dbParamsType)
            {
                OpenDB();

                dbCommand = _db.GetStoredProcCommand(spName); // _db.GetStoredProcCommand(spName, FormatParams(dbParams, dbParamsType));
                SetCmdParams(dbCommand, FormatParams(dbParams, dbParamsType));
                ds = this.ExecuteDataSet(dbCommand);
                return ds;
            }

            /// <summary>
            /// 执行带参数的存储过程
            /// </summary>
            /// <param name="spName">存储过程名称</param>
            /// <param name="dbParams">参数数组</param>
            /// <returns>影响的行数</returns>
            public int ExecNonQueryFromSP(string spName, System.Collections.Generic.Dictionary<string, string> dbParams, System.Collections.Generic.Dictionary<string, string> dbParamsType)
            {
                OpenDB();

                DbCommand dbCommand = _db.GetStoredProcCommand(spName);
                SetCmdParams(dbCommand, FormatParams(dbParams, dbParamsType));
                return this.ExecuteNonQuery(dbCommand);
            }

            /// <summary>
            /// 根据带参数的存储过程名字返回单一值
            /// </summary>
            /// <param name="spName">存储过程名字</param>
            /// <param name="dbParams">对应的参数数组</param>
            /// <returns>Object</returns>
            public object GetSingleValueFromSP(string spName, System.Collections.Generic.Dictionary<string, string> dbParams, System.Collections.Generic.Dictionary<string, string> dbParamsType)
            {
                OpenDB();

                dbCommand = _db.GetStoredProcCommand(spName); //_db.GetStoredProcCommand(spName, FormatParams(dbParams, dbParamsType));
                SetCmdParams(dbCommand, FormatParams(dbParams, dbParamsType));
                return this.ExecuteScalar(dbCommand);
            }

            #endregion
        
    }
}
