using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;
using DatabaseOpClassLibrary;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.Web;
using System.Web.Script.Serialization;

namespace BasicTools
{
    public class BasicOp
    {

        DatabaseOpClassLibrary.DataBase dbop = new DatabaseOpClassLibrary.DataBase();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        /// <summary>
        /// 返回code
        /// </summary>
        public static string code = "code";
        /// <summary>
        /// 返回原因
        /// </summary>
        public static string message = "message";
        /// <summary>
        /// 返回值内容
        /// </summary>
        public static string returnValue = "returnValue";

        #region 生成菜单
        public DataTable MenuList(int parentid)
        {
            DataTable dt = dbop.GetDataSet("SELECT  module_id,module_name,module_url,is_leaf_module,img_url FROM S_TREEMENU WHERE module_status=1 and parent_module_id = " + parentid + " ORDER BY index_no").Tables[0];
            return dt;
        }

        #endregion

        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public string HandleNull(object obj, string sDefault)
        {
            if (obj == System.DBNull.Value || obj == null)
            {
                return sDefault;
            }
            else
            {
                return obj.ToString();
            }
        }

        public double HandleNull(object obj, double dDefault)
        {
            if (obj == System.DBNull.Value || obj == null)
            {
                return dDefault;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }

        /// <summary>
        /// 非空判断
        /// </summary>
        /// <param name="obj">判断对象</param>
        /// <param name="dDefault">默认值</param>
        /// <returns>返回decimal 数据</returns>
        public decimal HandleNullDec(object obj, decimal dDefault)
        {
            if (obj == System.DBNull.Value || obj == null || HandleNull(obj, "") == "")
            {
                return dDefault;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        public double HandleNullDbl(object obj, double dDefault)
        {
            if (obj == System.DBNull.Value || obj == null || HandleNull(obj, "") == "")
            {
                return dDefault;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }

        /// <summary>
        /// 非空判断
        /// </summary>
        /// <param name="obj">判断对象</param>
        /// <param name="iDefault">默认值</param>
        /// <returns>返回int数据</returns>
        public int HandleNullInt(object obj, int iDefault)
        {
            if (obj == System.DBNull.Value || obj == null || HandleNull(obj, "") == "")
            {
                return iDefault;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 非空判断
        /// </summary>
        /// <param name="obj">判断对象</param>
        /// <param name="dateDefault">默认值</param>
        /// <returns>返回Datatime数据</returns>
        public DateTime HandleNullDate(object obj, DateTime dateDefault)
        {
            if (obj == "" || obj == null)
            {
                return dateDefault;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }

        public string HandleNullDate(object obj, string dateDefault, string dateFormat)
        {
            if (obj == null || obj == System.DBNull.Value)
            {
                return dateDefault;
            }
            else
            {
                return Convert.ToDateTime(obj).ToString(dateFormat);
            }
        }

        /// <summary>
        /// 获取返回值字符串方法
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="manage">manage</param>
        /// <param name="reutnValue">reutnValue</param>
        /// <returns></returns>
        public  string SetApiReturn(string code, string message, string returnValue)
        {

            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS, TRACE, HEAD, PATCH");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,content-type");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Max-Age", "0");


            SortedDictionary<string, object> backCall_SDIC;
            string backCall_JSon = "";
            backCall_SDIC = new SortedDictionary<string, object>();
            backCall_SDIC.Add(BasicOp.code, code);
            backCall_SDIC.Add(BasicOp.message, message);
            backCall_SDIC.Add(BasicOp.returnValue, returnValue);
            backCall_JSon = js.Serialize(backCall_SDIC);

           // OtherClass.UrlApi(HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.AbsolutePath + "?" + OtherClass.GetRequestPost() + "\r\n返回值：" + backCall_JSon);


            return backCall_JSon;
        }

        /// <summary>
        ///  将字符串以base64数字编码格式强制转换为字符串类型
        /// </summary>
        /// <param name="sRawData">数据字符串</param>
        /// <returns>返回字符串</returns>
        public string Base64Encode(string sRawData)
        {
            byte[] data = new byte[sRawData.Length];
            data = System.Text.Encoding.ASCII.GetBytes(sRawData);

            string Base64Data = Convert.ToBase64String(data);

            return Base64Data;
        }

        /// <summary>
        /// ASCII 转换字符串
        /// </summary>
        /// <param name="sBase64Data">64位数字格式字符串</param>
        /// <returns>返回数据字符串</returns>
        public string Base64Decode(string sBase64Data)
        {
            byte[] data = Convert.FromBase64String(sBase64Data);

            string rawData = System.Text.Encoding.ASCII.GetString(data);
            return rawData;
        }

        public void EnableToolButton(Button lb, bool enabled)
        {
            lb.Enabled = enabled;
            lb.CssClass = (enabled ? "btn" : "btnGray");
        }

        public void EnableDelToolButton(Button lb, bool enabled)
        {
            lb.Enabled = enabled;
            lb.CssClass = (enabled ? "btnRed" : "btnGray");
        }

        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="plainString">加密字符串</param>
        /// <param name="encrypType">加密类型</param>
        /// <returns>返回加密字符串</returns>
        public string EncryptPassword(string plainString, string encrypType)
        {
            string EncryptString;
            if (encrypType == "MD5")
            {
                EncryptString = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(plainString, "MD5");
            }
            else if (encrypType == "SHA1")
            {
                EncryptString = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(plainString, "SHA1");
            }
            else
            {
                EncryptString = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(plainString, "SHA1");
            }

            return EncryptString;
        }

        public void BindDDL(DropDownList ddl, string strSQL, string textName, string valueName)
        {
            DataTable dt;
            dt = dbop.GetDataSet(strSQL).Tables[0];
            ddl.DataSource = dt.DefaultView;
            ddl.DataTextField = textName;
            ddl.DataValueField = valueName;
            ddl.DataBind();
            if (ddl.Items.Count > 0)
            {
                ddl.SelectedIndex = 0;
            }

        }

        public string GetDropdownContent(string sDropdownType, bool textOnly)
        {
            string sReturn = "";
            string sql = "SELECT ddi_value,ddi_name FROM S_DROPDOWNLIST_ITEMS Where ddi_ddID='" + sDropdownType + "' order by ddi_order";
            DataTable dt;
            dt = dbop.GetDataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (textOnly) sReturn += 'Ö' + dr["ddi_name"].ToString() + 'Ä';
                else sReturn += 'Ö' + dr["ddi_value"].ToString() + 'Ä';
                sReturn += dr["ddi_name"].ToString();

            }
            if (sReturn != "") sReturn = sReturn.TrimStart('Ö');

            return sReturn;
        }
        public string GetDropdownContent(string sql, string valFldName, string textFldName)
        {
            string sReturn = "";
            DataTable dt = dbop.GetDataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                sReturn += 'Ö' + dr[valFldName].ToString() + 'Ä';
                sReturn += dr[textFldName].ToString();

            }
            if (sReturn != "") sReturn = sReturn.TrimStart('Ö');

            return sReturn;
        }

        public Boolean DDLSafeSelect(DropDownList ddl, string sValue)
        {
            ddl.ClearSelection();
            ListItem liError = ddl.Items.FindByValue("#InValidValue#");
            while (liError != null)
            {
                ddl.Items.Remove(liError);
                liError = ddl.Items.FindByValue("#InValidValue#");
            }
            ListItem li = ddl.Items.FindByValue(sValue);
            if (li == null)
            {
                ListItem liNew = new ListItem();
                liNew.Text = sValue;
                liNew.Value = sValue;
                liNew.Attributes.Add("style", "background: red;");

                ddl.Items.Insert(0, liNew);
                liNew.Selected = true;
                return false;
            }
            else
            {
                li.Selected = true;
                return true;
            }

        }

        public void AddDDLBlankRow(DropDownList ddl, string sText, string sValue)
        {

            ListItem li = new ListItem();
            li.Text = sText;
            li.Value = sValue;
            ddl.Items.Insert(0, li);
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                ddl.Items[i].Selected = false;
            }
            ddl.SelectedIndex = 0;
        }     

        //Ini FreeTextBox Control
        public void IniFTB(FreeTextBoxControls.FreeTextBox ftb)
        {
            //ftb.ToolbarLayout = "ParagraphMenu, FontFacesMenu, FontSizesMenu, FontForeColorsMenu, FontForeColorPicker, FontBackColorsMenu, FontBackColorPicker, Bold, Italic, Underline, Strikethrough |Superscript, Subscript, CreateLink, Unlink, InsertTable, InsertRule, RemoveFormat, JustifyLeft, JustifyRight, JustifyCenter, JustifyFull, BulletedList, NumberedList, Indent, Outdent |Cut, Copy, Paste, Delete, Undo, Redo, Print, Save";
            ftb.FontFacesMenuList = new string[] { "宋体", "黑体", "隶书", "楷体", "微软雅黑", "Arial", "Times", "Verdana", "Tahoma" };
        }
       
        #region 分页控件

        /// <summary>
        /// Get the total record count 
        /// 获取列表总记录数
        /// </summary>
        /// <param name="strFromStatement">sql中from的内容</param>
        /// <param name="strWhereStatement">sql中where的内容</param>
        /// <returns>the total record count</returns>
        public int SelectListPagedTotalCount(string strFromStatement, string strWhereStatement)
        {
            //SqlParameter[] parms = {
            //                            dbop.MakeInParam("@SelectStatement",SqlDbType.VarChar,2000,DBNull.Value),
            //                            dbop.MakeInParam("@FromStatement",SqlDbType.VarChar,2000,strFromStatement),
            //                            dbop.MakeInParam("@WhereStatement",SqlDbType.VarChar,2000,strWhereStatement),
            //                            dbop.MakeInParam("@OrderByExpression",SqlDbType.VarChar,500,DBNull.Value),
            //                            dbop.MakeInParam("@AscOrDesc",SqlDbType.VarChar,10,DBNull.Value),
            //                            dbop.MakeInParam("@RecordCount",SqlDbType.Int,0,DBNull.Value),
            //                            dbop.MakeInParam("@PageIndex",SqlDbType.Int,0,DBNull.Value),
            //                            dbop.MakeInParam("@PageSize",SqlDbType.Int,0,DBNull.Value),
            //                            dbop.MakeInParam("@DoCount",SqlDbType.Bit,0,true)
            //                       };

            //return (int)dbop.RunProcObject("spSelectListDynamicPaged2", parms, 1);
            return 0;
        }

        /// <summary>
        /// 显示当前页的数据
        /// </summary>
        /// <param name="strSelectStatement">sql中select的内容</param>
        /// <param name="strFromStatement">sql中from的内容</param>
        /// <param name="strWhereStatement">sql中where的内容</param>
        /// <param name="strOrderByExpression">sql中排序的字段</param>
        /// <param name="ascOrDesc">排序顺序（asc or desc）</param>
        /// <param name="intRecordCount">记录总数</param>
        /// <param name="intPageIndex">当前页的序号</param>
        /// <param name="intPageSize">每页的行数</param>
        /// <returns>返回当前页的数据</returns>
        public SqlDataReader SelectListPaged(string strSelectStatement, string strFromStatement, string strWhereStatement, string strOrderByExpression, string ascOrDesc, int intRecordCount, int intPageIndex, int intPageSize)
        {
            //SqlParameter[] parms = { dbop.MakeInParam("@SelectStatement",SqlDbType.VarChar,2000,strSelectStatement),
            //                           dbop.MakeInParam("@FromStatement",SqlDbType.VarChar,2000,strFromStatement),
            //                           dbop.MakeInParam("@WhereStatement",SqlDbType.VarChar,2000,strWhereStatement),
            //                           dbop.MakeInParam("@OrderByExpression",SqlDbType.VarChar,500,strOrderByExpression),
            //                           dbop.MakeInParam("@AscOrDesc",SqlDbType.VarChar,10,ascOrDesc),
            //                           dbop.MakeInParam("@RecordCount",SqlDbType.Int,0,intRecordCount),
            //                           dbop.MakeInParam("@PageIndex",SqlDbType.Int,0,intPageIndex),
            //                           dbop.MakeInParam("@PageSize",SqlDbType.Int,0,intPageSize),
            //                           dbop.MakeInParam("@DoCount",SqlDbType.Bit,0,false)
            //                       };

            //return dbop.GetReader("spSelectListDynamicPaged2", parms, 1);
            return null;
        }
        #endregion

        #region 语句式分页控件

        #region 总条数
        public int RowCount(string StrSql)
        {
            int rcount;
            rcount = int.Parse(dbop.GetSingleValue("select count(*) from (" + StrSql + ") rc").ToString());
            return rcount;
        }
        #endregion

        #region 分页
        public DataTable Paged(string StrSql, string StrOrder, string CurrentPage, string PageSize)
        {
            string SqlFormat, SqlAll, SqlBind;

            SqlFormat = "select * from ({0}) a where a.rownum between ({1}-1)*{2}+1 and {1}*{2}";

            SqlAll = "SELECT (ROW_NUMBER() OVER(ORDER BY " + StrOrder + ")) AS ROWNUM, A.* FROM ( " + StrSql + ") A";

            SqlBind = string.Format(SqlFormat, SqlAll, CurrentPage, PageSize);

            DataTable dt = dbop.GetDataSet(SqlBind).Tables[0];
            return dt;
        }
        #endregion

        #endregion

        #region 页面权限判断，返回数组
        /// <summary>
        /// 页面权限判断，返回数组[0]-可读/[1]-可改写/[2]-可新增/[3]-可删除/[4]-可打印
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pageid">页面地址(数据库中的地址样式)</param>
        /// <returns>数组</returns>
        public string[] PageRights(string userid, string pageid)
        {
            string[] sRights = new string[6];

            sRights[0] = "";
            sRights[1] = "";
            sRights[2] = "";
            sRights[3] = "";
            sRights[4] = "";
            sRights[5] = "";

            DataTable dt = dbop.GetDataSet("select grouser_groups from s_groupusers where grouser_user = '" + userid + "'").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                string groupid, strsql;
                groupid = dr["grouser_groups"].ToString();
                strsql = @"SELECT sgr.group_read,sgr.group_edit,sgr.group_add,sgr.group_del,sgr.group_print,sgr.group_data
                            FROM s_grouprights sgr,s_treemenu stm 
                            WHERE sgr.group_menu_id = stm.index_no AND
                                  sgr.group_gro_id = " + groupid + " AND ";
                strsql += "isnull(stm.module_url,'') = '" + pageid + "'";

                DataTable dt1 = dbop.GetDataSet(strsql).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    if (sRights[0] != "1") sRights[0] = dt1.Rows[0]["group_read"].ToString();
                    if (sRights[1] != "1") sRights[1] = dt1.Rows[0]["group_edit"].ToString();
                    if (sRights[2] != "1") sRights[2] = dt1.Rows[0]["group_add"].ToString();
                    if (sRights[3] != "1") sRights[3] = dt1.Rows[0]["group_del"].ToString();
                    if (sRights[4] != "1") sRights[4] = dt1.Rows[0]["group_print"].ToString();
                    if (sRights[5] != "1") sRights[5] = dt1.Rows[0]["group_data"].ToString();
                }
            }

            return sRights;
        }

        #endregion

        #region 返回系统版本号

        public string GetVersion()
        {
            return HandleNull(dbop.GetSingleValue("select sd_value_string from s_defaultvalue where sd_name = '系统当前版本号'"), "");
        }
        #endregion

        #region 返回类别信息
        public string GetConsultTypeDesc(string sValue)
        {
            return HandleNull(dbop.GetSingleValue("select ddi_name from S_DROPDOWNLIST_ITEMS where ddi_ddID = 'Consultant_type' and ddi_value = '" + sValue + "'"), "");
        }
        #endregion

        #region 图表专用

        public DataTable ConvertToChartTable(DataTable dt, string xColumn, string yColumn, string zColumn)
        {
            DataTable chartTable = new DataTable();

            DataView dv = dt.DefaultView;

            if (dv.Count <= 0)
            {
                return null;
            }

            string xColumnName, zColumnName;

            zColumnName = (zColumn == "" ? xColumn : zColumn);
            chartTable.Columns.Add(zColumnName, typeof(string));
            chartTable.PrimaryKey = new System.Data.DataColumn[] { chartTable.Columns[zColumnName] };

            // 加入所有的x列名
            for (int i = 0; i < dv.Count; i++)
            {
                xColumnName = dv[i][xColumn].ToString() == "" ? "NULL" : dv[i][xColumn].ToString();
                if (chartTable.Columns.IndexOf(xColumnName) == -1) chartTable.Columns.Add(xColumnName, typeof(int));
            }

            // 加入所有的行
            for (int i = 0; i < dv.Count; i++)
            {
                // 取到z值
                string zColumnValue;

                if (zColumnName == xColumn)
                    zColumnValue = yColumn;
                else
                    zColumnValue = dv[i][zColumnName].ToString();

                // 看是否已经插入此行
                DataRow dr = chartTable.Rows.Find(zColumnValue);

                if (dr == null)
                {
                    // 插入空行
                    dr = chartTable.NewRow();
                    dr[zColumnName] = zColumnValue;
                    chartTable.Rows.Add(dr);
                }

                xColumnName = dv[i][xColumn].ToString() == "" ? "NULL" : dv[i][xColumn].ToString();

                if (dr[xColumnName] == System.DBNull.Value)
                    dr[xColumnName] = dv[i][yColumn];
                else
                {
                    dr[xColumnName] = Convert.ToInt32(dr[xColumnName]) + Convert.ToInt32(dv[i][yColumn]);
                }
            }

            return chartTable;
        }

        #endregion

        public struct pd
        {
            public string table;
            public int TotalCount;
            public int CurrentPage;
            public pd(string table, int TotalCount, int CurrentPage)
            {
                this.table = table;
                this.TotalCount = TotalCount;
                this.CurrentPage = CurrentPage;
            }
        }

        public enum CalDayType
        {
            dayWork = 0,
            dayOff = 1,
            dayHoli = 2
        }

        public struct CalDay
        {
            public DateTime day;
            public string dayType;
            public CalDay(DateTime day, string dayType)
            {
                this.day = day;
                this.dayType = dayType;
            }
        }

        public struct FieldInfo
        {
            public string name;
            public string value;
            public FieldInfo(string name, string value)
            {
                this.name = name;
                this.value = value;
            }
        }

        public static Hashtable ParseJsonToHash(FieldInfo[] json)
        {
            Hashtable ht = new Hashtable();

            foreach (FieldInfo fi in json)
            {
                ht.Add(fi.name, fi.value);
            }
            return ht;
        }

        public static Dictionary<string, string> ParseJsonToDict(FieldInfo[] json)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (FieldInfo fi in json)
            {
                dic.Add(fi.name, fi.value);
            }
            return dic;
        }

        public class SearchInfo
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public static Dictionary<string, string> ParseJsonStringToDict(string json)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<SearchInfo> si = (List<SearchInfo>)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(List<SearchInfo>));
            foreach (SearchInfo s in si)
            {
                dic.Add(s.name, s.value);
            }
            return dic;
        }

        #region GridView 合并单元格

        public void MergeGVcells(GridView gv, int cell, string sLabel, string sValign)
        {
            string sValue = "";
            int iCount = 0;
            int iRowBegin = 0;
            int iRow = 0;
            string sCurValue;
            foreach (GridViewRow gvr in gv.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    if (sLabel == "")
                    {
                        sCurValue = gvr.Cells[cell].Text;
                    }
                    else
                    {
                        Label lbl = (Label)gvr.Cells[cell].FindControl(sLabel);
                        sCurValue = lbl.Text;
                    }
                    if (sCurValue == sValue)
                    {
                        iCount++;
                    }
                    else
                    {
                        if (iCount > 0)
                        {
                            for (int i = iRowBegin; i <= iRowBegin + iCount; i++)
                            {
                                if (i == iRowBegin)
                                {
                                    gv.Rows[i].Cells[cell].RowSpan = iCount + 1;
                                    gv.Rows[i].Cells[cell].Attributes.Add("Valign", sValign);
                                }
                                else
                                {
                                    //gv.Rows[i].Cells.Remove(gv.Rows[i].Cells[cell]);
                                    gv.Rows[i].Cells[cell].Visible = false;
                                }
                            }
                            iCount = 0;
                        }
                        sValue = sCurValue;
                        iRowBegin = iRow;
                    }
                    iRow++;
                }
            }
            //This is for the Last Call --- Since if the Last Row is duplicated, it will not affect in above loop!!!!
            if (iCount > 0)
            {
                for (int i = iRowBegin; i <= iRowBegin + iCount; i++)
                {
                    if (i == iRowBegin)
                    {
                        gv.Rows[i].Cells[cell].RowSpan = iCount + 1;
                        gv.Rows[i].Cells[cell].Attributes.Add("Valign", sValign);
                    }
                    else
                    {
                        //gv.Rows[i].Cells.Remove(gv.Rows[i].Cells[cell]);
                        gv.Rows[i].Cells[cell].Visible = false;
                    }
                }
            }
        }

        public void MergeGVcells(GridView gv, int cell, string sLabel, string sValign, int iKeyPos)
        {
            string sValue = "";
            int iCount = 0;
            int iRowBegin = 0;
            int iRow = 0;
            string sCurValue;
            string sKeyValue = "", sCurKeyValue;
            foreach (GridViewRow gvr in gv.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    sCurKeyValue = gvr.Cells[iKeyPos].Text;
                    if (sLabel == "")
                    {
                        sCurValue = gvr.Cells[cell].Text;
                    }
                    else
                    {
                        Label lbl = (Label)gvr.Cells[cell].FindControl(sLabel);
                        sCurValue = lbl.Text;
                    }
                    if (sCurValue == sValue && sCurKeyValue == sKeyValue)
                    {
                        iCount++;
                    }
                    else
                    {
                        if (iCount > 0)
                        {
                            for (int i = iRowBegin; i <= iRowBegin + iCount; i++)
                            {
                                if (i == iRowBegin)
                                {
                                    gv.Rows[i].Cells[cell].RowSpan = iCount + 1;
                                    gv.Rows[i].Cells[cell].Attributes.Add("Valign", sValign);
                                }
                                else
                                {
                                    //gv.Rows[i].Cells.Remove(gv.Rows[i].Cells[cell]);
                                    gv.Rows[i].Cells[cell].Visible = false;
                                }
                            }
                            iCount = 0;
                        }
                        sValue = sCurValue;
                        iRowBegin = iRow;
                        sKeyValue = sCurKeyValue;
                    }
                    iRow++;
                }
            }
            //This is for the Last Call --- Since if the Last Row is duplicated, it will not affect in above loop!!!!
            if (iCount > 0)
            {
                for (int i = iRowBegin; i <= iRowBegin + iCount; i++)
                {
                    if (i == iRowBegin)
                    {
                        gv.Rows[i].Cells[cell].RowSpan = iCount + 1;
                        gv.Rows[i].Cells[cell].Attributes.Add("Valign", sValign);
                    }
                    else
                    {
                        //gv.Rows[i].Cells.Remove(gv.Rows[i].Cells[cell]);
                        gv.Rows[i].Cells[cell].Visible = false;
                    }
                }
            }
        }

        #endregion

     

        #region 导出excel

        public void ExportToExcel(string dvContent, System.Web.UI.Page page, string fileName)
        {
            page.Response.Clear();
            page.Response.AddHeader("content-disposition", "attachment;filename=" + page.Server.UrlEncode(fileName + ".xls"));
            page.Response.Charset = "gb2312";
            //page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            page.Response.ContentType = "application/vnd.ms-xls";
            //page.Response.ContentType = "application/vnd.xls";
            page.Response.Write(@"<html>");
            page.Response.Write(@"<head>");
            page.Response.Write(@"<meta http-equiv=""content-type"" content=""text/html; charset=gb2312"">");
            page.Response.Write(@"<style text=""text/css"">.nfmt {vnd.ms-excel.numberformat:@;} </style>");
            page.Response.Write(@"</head>");
            page.Response.Write(@"<body>");
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            stringWrite.Write(dvContent);
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            //dv.RenderControl(htmlWrite);
            page.Response.Write(stringWrite.ToString());
            page.Response.Write(@"</body>");
            page.Response.Write(@"</html>");
            page.Response.End();

        }

        //NPOI插入空行
        public void InsertRows(HSSFSheet sheet, int fromRowIndex, int rowCount)
        {
            sheet.ShiftRows(fromRowIndex + 1, sheet.LastRowNum, rowCount, true, false, true);
            var rowSource = sheet.GetRow(fromRowIndex);
            var rowstyle = rowSource.RowStyle;
            var rowIndex = fromRowIndex + 1;
            var rowInsert = sheet.CreateRow(rowIndex);

            ///rowInsert.RowStyle = rowstyle;
            rowInsert.Height = rowSource.Height;
            var colIndex = rowSource.LastCellNum;

            var cellSource = rowSource.GetCell(colIndex);
            var celInsert = rowInsert.CreateCell(colIndex);

        }

        //NPOI复制空行
        public enum CopyType : short
        {
            all = 0,//所有的
            onlyData = 1,//数据
            onlyFormat = 2,//格式
            onlyComment = 3,//公式
            dataAndComment = 13,//数据和公示
            dataAndFormat = 12,//数据和格式
            formatAndComment = 23 //格式和公式
        }
        /// <param name="sheet"></param>
        /// <param name="fromRowIndex">来源行</param>
        /// <param name="startIndex">开始行</param>
        /// <param name="appendNum">追加几行</param>
        /// <param name="cellStartIndex">列开始索引</param>
        /// <param name="copyCellNum">几列</param>
        /// <param name="copytype">枚举</param>
        /// <param name="cellRanges">暂不支持行合并，行参数任意填写，列填写索引即可</param>
        public void CopyRange(HSSFSheet sheet, int fromRowIndex, int startIndex, int appendNum, int cellStartIndex, int copyCellNum, CopyType copytype, IList<CellRangeAddress> cellRanges)
        {

            HSSFRow sourceRow = (HSSFRow)sheet.GetRow(fromRowIndex);
            if (null == sourceRow)
            {
                return;
            }
            if (sourceRow != null)
            {
                HSSFRow changingRow = null;
                HSSFCell changingCell = null;
                HSSFCell sourceCell = null;
                sheet.ShiftRows(startIndex, sheet.LastRowNum, appendNum, true, false); //原来的后移
                if (fromRowIndex >= startIndex)
                {
                    sourceRow = (HSSFRow)sheet.GetRow(fromRowIndex + appendNum);
                }
                for (int i = 0; i < appendNum; i++)
                {
                    //插入行
                    changingRow = (HSSFRow)sheet.CreateRow(startIndex + i);
                    changingRow.Height = 400;
                    //设置列样式
                    for (int j = 0; j < copyCellNum; j++)
                    {
                        //需要变化的列
                        changingCell = (HSSFCell)changingRow.GetCell(cellStartIndex + j);
                        if (changingCell == null)
                            changingCell = (HSSFCell)changingRow.CreateCell(cellStartIndex + j);
                        //获取源对应数据
                        sourceCell = (HSSFCell)sourceRow.GetCell(cellStartIndex + j);
                        if (CopyType.all == copytype || CopyType.onlyData == copytype ||
                            CopyType.dataAndFormat == copytype || CopyType.dataAndComment == copytype)
                        {
                            //设置数据
                            changingCell.SetCellValue(sourceCell.StringCellValue);
                        }
                        if (CopyType.all == copytype || CopyType.onlyFormat == copytype ||
                            CopyType.dataAndFormat == copytype || CopyType.formatAndComment == copytype)
                        {
                            //设置格式
                            //单元格的编码
                            //changingCell.Encoding = sourceCell.Encoding;
                            //单元格的格式
                            changingCell.CellStyle = sourceCell.CellStyle;
                            //单元格的公式
                            //if (sourceCell.CellFormula == "")
                            //    changingCell.SetCellType(sourceCell.CellType);
                            //else
                            //    changingCell.SetCellType(CellType.FORMULA);
                        }
                        if (CopyType.all == copytype || CopyType.dataAndComment == copytype ||
                            CopyType.formatAndComment == copytype || CopyType.onlyComment == copytype)
                        {
                            //设置comment (待扩展)
                        }
                        changingCell.SetCellValue("");
                    }
                    //合并单元格
                    if (null != cellRanges)
                    {
                        foreach (CellRangeAddress cellRange in cellRanges)
                        {
                            sheet.AddMergedRegion(new CellRangeAddress(startIndex + i, startIndex + i, cellRange.FirstColumn, cellRange.LastColumn));
                        }

                    }
                }
            }
        }


        #endregion

        #region 其他

       
        /// 改变TextBox背景色
        /// </summary>
        /// <param name="tb">TextBox控件</param>
        /// <param name="ifChange">是否改变</param>
        public static void ChangeTBbgd(TextBox tb, Boolean ifChange)
        {
            if (ifChange)
            {
                tb.BackColor = System.Drawing.Color.LightYellow;
            }
            else
            {
                tb.BackColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// GridViewRow背景色，添加事件
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="sender"></param>
        /// <param name="e">Grid行事件</param>
        public void SetWebGridRowSelect(Page page, object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes.Add("onmouseover", "GV_changeBackColor(this, true)");
                //e.Row.Attributes.Add("onmouseout", "GV_changeBackColor(this, false)");
                e.Row.Attributes["OnClick"] = page.ClientScript.GetPostBackEventReference((GridView)sender, "Select$" + e.Row.RowIndex);
                e.Row.Style["cursor"] = "pointer";
            }
        }

      
      
        #endregion
    }
}

