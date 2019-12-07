using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace BasicTools
{
    /// <summary>
    /// 用于类的属性和界面上的同名字段交互的类
    /// </summary>
    public class CollectProperty
    {
        static BasicOp bo = new BasicOp();
        /// <summary>
        /// 将页面上与属性同名的控件值收集到类中对应的属性
        /// </summary>
        /// <param name="Class">类的实例</param>
        /// <param name="ctl">包含要收集控件的控件容器（一般为Page）</param>
        public static void getPropertyFromPage(object Class, Control ctl)
        {
            Type t = Class.GetType();
            Object obj;
            Object value;

            PropertyInfo[] piList = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piList)
            {
                try
                {

                    string field = pi.Name;
                    obj = ctl.FindControl(field);
                    if (obj == null) continue;
                    switch (obj.GetType().Name)
                    {
                        case "HiddenField":
                            value = ((HiddenField)obj).Value;
                            break;
                        case "DropDownList":
                            value = ((DropDownList)obj).SelectedValue;
                            break;
                        case "TextBox":
                            value = ((TextBox)obj).Text;
                            break;
                        case "RadioButtonList":
                            value = ((RadioButtonList)obj).SelectedValue;
                            break;
                        case "Label":
                            value = ((Label)obj).Text;
                            break;                      
                        case "CheckBox":
                            value = ((CheckBox)obj).Checked ? "是" : "否";
                            break;
                        case "CheckBoxList":
                            CheckBoxList cbl = (CheckBoxList)obj;
                            value = "";
                            for (int i = 0; i < cbl.Items.Count; i++)
                            {
                                if (cbl.Items[i].Selected)
                                {
                                    value += (value.ToString() != "" ? "," : "") + cbl.Items[i].Value;
                                }
                            }
                            break;
                        default:
                            value = "";
                            break;
                    }

                    if (pi.PropertyType.ToString().Contains("Int32"))
                    {
                        if (value.ToString().Trim() == "")
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToInt32(value);
                        }
                    }
                    else if (pi.PropertyType.ToString().Contains("Decimal"))
                    {
                        if (value.ToString().Trim() == "")
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToDecimal(value);
                        }
                    }
                    else if (pi.PropertyType.ToString().Contains("Date"))
                    {
                        if (value.ToString().Trim() == "" || value.ToString().Trim().StartsWith("0000-00-00"))
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToDateTime(value);
                        }
                    }

                    pi.SetValue(Class, value, null);
                }
                catch
                {
                    pi.SetValue(Class, null, null);

                }
            }
        }

        /// <summary>
        /// 将类中的属性值设置到页面上与属性同名的控件中
        /// </summary>
        /// <param name="Class">类的实例</param>
        /// <param name="ctl">包含要设置控件的控件容器（一般为Page）</param>
        public static void setPropertyToPage(object Class, Control ctl)
        {
            Type t = Class.GetType();
            Object obj;
            Object value;

            PropertyInfo[] piList = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piList)
            {
                string field = pi.Name;
                obj = ctl.FindControl(field);
                if (obj == null) continue;
                value = pi.GetValue(Class, null);
                try
                {
                    switch (obj.GetType().Name)
                    {
                        case "HiddenField":
                            if (value != null)
                                ((HiddenField)obj).Value = value.GetType().ToString().Contains("DateTime") ? ((DateTime)value).ToString("yyyy-MM-dd HH:mm") : value.ToString();
                            else
                                ((HiddenField)obj).Value = "";
                            break;

                        case "DropDownList":
                            ((DropDownList)obj).SelectedIndex = -1;
                            if (value != null)
                            {
                                bo.DDLSafeSelect((DropDownList)obj, value.ToString());
                            }
                            break;

                        case "TextBox":
                            if (value != null)
                                if (value.GetType().ToString().Contains("DateTime"))
                                {
                                    ((TextBox)obj).Text = ((TextBox)obj).Attributes["containtime"] != null && ((TextBox)obj).Attributes["containtime"].ToString() == "Y" ? ((DateTime)value).ToString("yyyy-MM-dd HH:mm") : ((DateTime)value).ToString("yyyy-MM-dd");
                                }
                                else
                                    ((TextBox)obj).Text = value.ToString();
                            else
                                ((TextBox)obj).Text = "";
                            break;

                        case "RadioButtonList":
                            ((RadioButtonList)obj).SelectedIndex = -1;
                            if (value != null)
                            {
                                ((RadioButtonList)obj).Items.FindByValue(value.ToString()).Selected = true;
                            }
                            break;

                        case "Label":
                            if (value != null)
                                if (value.GetType().ToString().Contains("DateTime"))
                                {
                                    ((Label)obj).Text = ((Label)obj).Attributes["containtime"] != null && ((Label)obj).Attributes["containtime"].ToString() == "Y" ? ((DateTime)value).ToString("yyyy-MM-dd HH:mm") : ((DateTime)value).ToString("yyyy-MM-dd");
                                }
                                else
                                    ((Label)obj).Text = value.ToString();
                            else
                                ((Label)obj).Text = "";
                            break;

                        case "CheckBox":
                            ((CheckBox)obj).Checked = value.ToString() == "是" ? true : false;
                            break;

                        case "CheckBoxList":
                            string[] ary_value = value.ToString().Split(',');
                            CheckBoxList cbl = (CheckBoxList)obj;
                            foreach (string str in ary_value)
                            {
                                for (int i = 0; i < cbl.Items.Count; i++)
                                {
                                    if (cbl.Items[i].Value == str)
                                    {
                                        cbl.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                            break;

                       
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 清除包含控件的值（DropDownList，TextBox）
        /// </summary>
        /// <param name="panel">包含要清空的控件的容器</param>
        public static void clearControlsContent(Control panel, string[] exclude)
        {
            foreach (Control ctl in panel.Controls)
            {
                if (exclude != null && ((System.Collections.IList)exclude).Contains(ctl.ID)) continue;
                switch (ctl.GetType().Name)
                {
                    case "HiddenField":
                        ((HiddenField)ctl).Value = "";
                        break;
                    case "DropDownList":
                        if (((DropDownList)ctl).Items.Count > 0)
                            ((DropDownList)ctl).SelectedIndex = 0;
                        else
                            ((DropDownList)ctl).SelectedIndex = -1;
                        break;
                    case "RadioButtonList":
                        ((RadioButtonList)ctl).SelectedIndex = 0;
                        break;
                    case "TextBox":
                        ((TextBox)ctl).Text = "";
                        break;
                    case "CheckBox":
                        ((CheckBox)ctl).Checked = false;
                        break;
                    case "CheckBoxList":
                        CheckBoxList cbl = (CheckBoxList)ctl;
                        for (int i = 0; i < cbl.Items.Count; i++)
                        {
                            cbl.Items[i].Selected = false;
                        }
                        break;
                    case "GridView":
                        ((GridView)ctl).DataSource = null;
                        ((GridView)ctl).DataBind();
                        break;
                  
                    default:
                        clearControlsContent(ctl, exclude);
                        break;
                }
            }

        }

        public static void setEnable(Control panel, bool enabled, string[] exclude)
        {
            foreach (Control ctl in panel.Controls)
            {
                if (exclude != null && ((System.Collections.IList)exclude).Contains(ctl.ID)) continue;
                switch (ctl.GetType().Name)
                {
                    case "DropDownList":
                        ((DropDownList)ctl).Enabled = enabled;
                        break;

                    case "TextBox":
                        ((TextBox)ctl).Enabled = enabled;
                        break;

                    case "RadioButtonList":
                        ((RadioButtonList)ctl).Enabled = enabled;
                        break;
                    case "CheckBoxList":
                        ((CheckBoxList)ctl).Enabled = enabled;
                        break;

                    case "ImageButton":
                        ((ImageButton)ctl).Enabled = enabled;
                        break;

                    default:
                        setEnable(ctl, enabled, exclude);
                        break;

                }
            }
        }

        public static void setEnable(object Class, Control ctl, bool enabeld, string[] exclude)
        {
            Type t = Class.GetType();
            Object obj;

            PropertyInfo[] piList = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piList)
            {
                string field = pi.Name;
                obj = ctl.FindControl(field);
                if (obj == null) continue;
                if (exclude != null && ((System.Collections.IList)exclude).Contains(field)) continue;
                try
                {
                    switch (obj.GetType().Name)
                    {
                        case "DropDownList":
                            ((DropDownList)obj).Enabled = enabeld;
                            break;

                        case "TextBox":
                            ((TextBox)obj).Enabled = enabeld;
                            break;

                        case "RadioButtonList":
                            ((RadioButtonList)obj).Enabled = enabeld;
                            break;

                        //case "controls_autocompletesearch_ascx":
                        //    ((IAutoComplete)obj).Enabled = enabeld;
                        //    break;

                        case "CheckBoxList":
                            ((CheckBoxList)obj).Enabled = enabeld;
                            break;

                        case "ImageButton":
                            ((ImageButton)obj).Enabled = enabeld;
                            break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 将页面上与属性同名的控件值收集到类中对应的属性
        /// </summary>
        /// <param name="Class">类的实例</param>
        /// <param name="ctl">包含要收集控件的控件容器（一般为Page）</param>
        public static void getPropertyFromPage(object Class, System.Collections.Hashtable ht)
        {
            Type t = Class.GetType();
            Object obj;
            Object value;

            PropertyInfo[] piList = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piList)
            {
                try
                {
                    string field = pi.Name;
                    if (!ht.ContainsKey(field)) continue;
                    value = ht[field];

                    if (pi.PropertyType.ToString().Contains("Int32"))
                    {
                        if (value.ToString().Trim() == "")
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToInt32(value);
                        }
                    }
                    else if (pi.PropertyType.ToString().Contains("Decimal"))
                    {
                        if (value.ToString().Trim() == "")
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToDecimal(value);
                        }
                    }
                    else if (pi.PropertyType.ToString().Contains("Date"))
                    {
                        if (value.ToString().Trim() == "" || value.ToString().Trim().StartsWith("0000-00-00"))
                        {
                            value = null;
                        }
                        else
                        {
                            value = Convert.ToDateTime(value);
                        }
                    }

                    pi.SetValue(Class, value, null);
                }
                catch
                {
                    pi.SetValue(Class, null, null);

                }
            }
        }

        /// <summary>
        /// 从数据字典中收集到类中对应的属性
        /// </summary>
        /// <param name="Class">类的实例</param>
        /// <param name="Dictionary">数据字典</param>
        public static void getPropertyFromDictionary(object Class, Dictionary<string, string> paramList)
        {
            Type t = Class.GetType();
            Object value;
            #region 遍历Dictionary
            foreach (KeyValuePair<string, string> member in paramList)
            {
                PropertyInfo pi = t.GetProperty(member.Key);
                if (pi != null)
                {
                    try
                    {
                        value = member.Value;
                        if (pi.PropertyType.ToString().Contains("Int32"))
                        {
                            if (value.ToString().Trim() == "")
                            {
                                value = null;
                            }
                            else
                            {
                                value = Convert.ToInt32(value);
                            }
                        }
                        else if (pi.PropertyType.ToString().Contains("Decimal"))
                        {
                            if (value.ToString().Trim() == "")
                            {
                                value = null;
                            }
                            else
                            {
                                value = Convert.ToDecimal(value);
                            }
                        }
                        else if (pi.PropertyType.ToString().Contains("Date"))
                        {
                            if (value.ToString().Trim() == "" || value.ToString().Trim().StartsWith("0000-00-00"))
                            {
                                value = null;
                            }
                            else
                            {
                                value = Convert.ToDateTime(value);
                            }
                        }
                        else if (pi.PropertyType.ToString().Contains("Int16"))
                        {
                            if (value.ToString().Trim() == "")
                            {
                                value = null;
                            }
                            else
                            {
                                value = Convert.ToInt16(value);
                            }
                        }
                        pi.SetValue(Class, value, null);
                    }
                    catch
                    {
                        pi.SetValue(Class, null, null);
                    }
                }
            }
            #endregion

            #region 遍历property
            //PropertyInfo[] piList = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //foreach (PropertyInfo pi in piList)
            //{
            //    if (!paramList.ContainsKey(pi.Name)) continue;
            //    try
            //    {
            //        value = paramList[pi.Name];
            //        if (pi.PropertyType.ToString().Contains("Int32"))
            //        {
            //            if (value.ToString().Trim() == "")
            //            {
            //                value = null;
            //            }
            //            else
            //            {
            //                value = Convert.ToInt32(value);
            //            }
            //        }
            //        else if (pi.PropertyType.ToString().Contains("Decimal"))
            //        {
            //            if (value.ToString().Trim() == "")
            //            {
            //                value = null;
            //            }
            //            else
            //            {
            //                value = Convert.ToDecimal(value);
            //            }
            //        }
            //        else if (pi.PropertyType.ToString().Contains("Date"))
            //        {
            //            if (value.ToString().Trim() == "" || value.ToString().Trim().StartsWith("0000-00-00"))
            //            {
            //                value = null;
            //            }
            //            else
            //            {
            //                value = Convert.ToDateTime(value);
            //            }
            //        }
            //        pi.SetValue(Class, value, null);
            //    }
            //    catch
            //    {
            //        pi.SetValue(Class, null, null);
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// 从页面控件值收集到数据字典中
        /// </summary>
        /// <param name="Dictionary">数据字典</param>
        /// <param name="panel">包含要收集控件的控件容器（一般为Page）</param>
        public static void getDictionaryFromPage(Dictionary<string, string> paramList, Control panel, string objPre)
        {
            string name, value;
            foreach (Control obj in panel.Controls)
            {
                try
                {
                    if (string.IsNullOrEmpty(obj.ID)) continue;
                    name = objPre != "" ? obj.ID.Replace(objPre, "") : obj.ID;
                    switch (obj.GetType().Name)
                    {
                        case "HiddenField":
                            value = ((HiddenField)obj).Value;
                            break;
                        case "DropDownList":
                            value = ((DropDownList)obj).SelectedValue;
                            break;
                        case "TextBox":
                            value = ((TextBox)obj).Text;
                            break;
                        case "RadioButtonList":
                            value = ((RadioButtonList)obj).SelectedValue;
                            break;
                        case "Label":
                            value = ((Label)obj).Text;
                            break;
                      
                        default:
                            value = null;
                            break;
                    }
                    if (value != null)
                    {
                        paramList.Add(name, value);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public static void setDataRowToPage(DataTable dt, Control panel, string objPre)
        {
            string value;
            foreach (DataColumn dc in dt.Columns)
            {
                Control obj = panel.FindControl(objPre + dc.ColumnName);
                if (obj != null)
                {
                    value = dt.Rows[0][dc] == System.DBNull.Value || dt.Rows[0][dc] == null ? "" : dt.Rows[0][dc].GetType().ToString().Contains("DateTime") ? ((DateTime)dt.Rows[0][dc]).ToString("yyyy-MM-dd HH:mm") : dt.Rows[0][dc].ToString();
                    try
                    {
                        switch (obj.GetType().Name)
                        {
                            case "HiddenField":
                                ((HiddenField)obj).Value = value;
                                break;
                            case "DropDownList":
                                ((DropDownList)obj).SelectedIndex = -1;
                                //if (value != "")
                                {
                                    bo.DDLSafeSelect((DropDownList)obj, value);
                                }
                                break;
                            case "TextBox":
                                if (value != "" && dc.DataType.ToString().Contains("DateTime"))
                                {
                                    if (((TextBox)obj).Attributes["containtime"] == null || ((TextBox)obj).Attributes["containtime"].ToString() != "Y")
                                    {
                                        value = value.Substring(0, 10);
                                    }
                                }
                                ((TextBox)obj).Text = value;
                                break;
                            case "RadioButtonList":
                                ((RadioButtonList)obj).SelectedIndex = -1;
                                //if (value != "")
                                //{
                                ((RadioButtonList)obj).Items.FindByValue(value.ToString()).Selected = true;
                                //}
                                break;
                            case "Label":
                                if (value != "" && dc.DataType.ToString().Contains("DateTime"))
                                {
                                    if (((Label)obj).Attributes["containtime"] == null || ((Label)obj).Attributes["containtime"].ToString() != "Y")
                                    {
                                        value = value.Substring(0, 10);
                                    }
                                }
                                ((Label)obj).Text = value;
                                break;                           
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 从页面控件值收集到数据字典中
        /// </summary>
        /// <param name="Dictionary">数据字典</param>
        /// <param name="panel">包含要收集控件的控件容器（一般为Page）</param>
        public static void getDictionaryFromPage(Dictionary<string, object> paramList, Control panel, string objPre)
        {
            string name, value;
            foreach (Control obj in panel.Controls)
            {
                try
                {
                    if (string.IsNullOrEmpty(obj.ID)) continue;
                    name = objPre != "" ? obj.ID.Replace(objPre, "") : obj.ID;
                    switch (obj.GetType().Name)
                    {
                        case "HiddenField":
                            value = ((HiddenField)obj).Value;
                            break;
                        case "DropDownList":
                            value = ((DropDownList)obj).SelectedValue;
                            break;
                        case "TextBox":
                            value = ((TextBox)obj).Text;
                            break;
                        case "RadioButtonList":
                            value = ((RadioButtonList)obj).SelectedValue;
                            break;
                        case "Label":
                            value = ((Label)obj).Text;
                            break;
                       
                        default:
                            value = null;
                            break;
                    }
                    if (value != null)
                    {
                        paramList.Add(name, (object)value);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 从页面控件值收集到数据字典中
        /// </summary>
        /// <param name="Dictionary">数据字典</param>
        /// <param name="panel">包含要收集控件的控件容器（一般为Page）</param>
        public static void getDictionaryFromPage<T>(Dictionary<string, string> paramList, Control panel, string objPre)
        {
            //T t = default(T);
            Object obj;
            string value;

            PropertyInfo[] piList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in piList)
            {
                try
                {
                    string field = pi.Name;
                    obj = panel.FindControl(objPre + field);
                    if (obj == null) continue;
                    switch (obj.GetType().Name)
                    {
                        case "HiddenField":
                            value = ((HiddenField)obj).Value;
                            break;
                        case "DropDownList":
                            value = ((DropDownList)obj).SelectedValue;
                            break;
                        case "TextBox":
                            value = ((TextBox)obj).Text;
                            break;
                        case "RadioButtonList":
                            value = ((RadioButtonList)obj).SelectedValue;
                            break;
                        case "Label":
                            value = ((Label)obj).Text;
                            break;                      
                        default:
                            value = null;
                            break;
                    }
                    if (value != null)
                    {
                        paramList.Add(field, value);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 比对model实例是否完全相等
        /// </summary>
        /// <param name="oldModel">实例</param>
        /// <param name="newModel">实例</param>
        /// <param name="includes">对比字段</param>
        public static bool CompareDataModel<T>(object oldModel, object newModel, string includes)
        {
            PropertyInfo[] piList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            object oldValue, newValue;
            foreach (PropertyInfo pi in piList)
            {
                //if (pi.Name.Contains("RecordIsSelected")) continue;
                if (!includes.Contains("\"" + pi.Name + "\":")) continue;
                oldValue = pi.GetValue(oldModel, null);
                newValue = pi.GetValue(newModel, null);
                if ((oldValue == null || oldValue.Equals(System.DBNull.Value) || string.IsNullOrEmpty(oldValue.ToString())) && (newValue == null || newValue.Equals(System.DBNull.Value) || string.IsNullOrEmpty(newValue.ToString())))
                {
                    continue;
                }
                if (oldValue == null || newValue == null || !oldValue.Equals(newValue))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 数据集合转换为泛型集合     
        /// </summary>     
        /// <typeparam name="T">泛型类型</typeparam>    
        /// <param name="dataSet">数据集合</param>    
        /// <param name="tableIndex">待转换数据表索引</param>    
        /// <returns>泛型集合</returns>     
        public List<T> DataSetToIList<T>(DataSet dataSet, int tableIndex)
        {
            if (dataSet == null || dataSet.Tables.Count < 0)
            {
                return null;
            }
            if (tableIndex > dataSet.Tables.Count - 1)
            {
                return null;
            }
            if (tableIndex < 0)
            {
                tableIndex = 0;
            }
            DataTable dataTable = dataSet.Tables[tableIndex];
            // 返回值初始化       
            List<T> result = new List<T>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                T model = (T)Activator.CreateInstance(typeof(T));
                foreach (MemberInfo mInfo in model.GetType().GetMembers())//获取成员信息
                {
                    if (mInfo.MemberType == MemberTypes.Property)//判断该成员是否为属性信息
                    {
                        PropertyInfo pi = (PropertyInfo)mInfo;
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            string paramName = string.Empty;
                            string dataTableColumnName = dataTable.Columns[j].ColumnName;
                            foreach (var attr in Attribute.GetCustomAttributes(mInfo))//遍历属性信息中的特性
                            {
                                if (attr.GetType() == typeof(DescriptionAttribute))//获取Description特性加入参数名称
                                {
                                    paramName = ((DescriptionAttribute)attr).Description;
                                    if (paramName.Contains(","))
                                    {
                                        paramName = paramName.Substring(paramName.IndexOf(',') + 1);
                                    }
                                    break;
                                }
                            }
                            // 属性与字段名称一致的进行赋值   
                            if (paramName.ToUpper().Equals(dataTableColumnName.ToUpper()))
                            {
                                // 数据库NULL值单独处理       
                                if (dataTable.Rows[i][j] != DBNull.Value)
                                {
                                    //实体类字段类型和数据集字段类型不符
                                    if (pi.PropertyType != dataTable.Rows[i][j].GetType())
                                    {
                                        pi.SetValue(model, bo.HandleNull(dataTable.Rows[i][j], string.Empty).StringConvertTo(pi.PropertyType), null);
                                    }
                                    else
                                    {
                                        pi.SetValue(model, dataTable.Rows[i][j], null);
                                    }
                                }
                                else
                                {
                                    pi.SetValue(model, null, null);
                                }
                                break;
                            }
                        }
                    }
                }
                result.Add(model);
            }
            return result;
        }
    }

    #region String类扩展方法

    /// <summary>
    /// (String类扩展方法) 将字符串格式化成指定的数据类型
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// (String类扩展方法) 将字符串格式化成指定的数据类型
        /// </summary>
        /// <param name="str">字符串数据</param>
        /// <param name="type">指定的数据类型</param>
        /// <returns>转换为指定类型的对象</returns>
        public static Object StringConvertTo(this String str, Type type)
        {
            if (String.IsNullOrEmpty(str))
                return null;
            if (type == null)
                return str;
            if (type.IsArray)
            {
                Type elementType = type.GetElementType();
                String[] strs = str.Split(new char[] { ';' });
                Array array = Array.CreateInstance(elementType, strs.Length);
                for (int i = 0, c = strs.Length; i < c; ++i)
                {
                    array.SetValue(ConvertToCommonType(strs[i], elementType), i);
                }
                return array;
            }
            return ConvertToCommonType(str, type);
        }
        /// <summary>
        /// 将对象转换为指定类型的对象
        /// </summary>
        /// <param name="value">被转换的对象</param>
        /// <param name="destinationType">指定的数据类型</param>
        /// <returns>转换完毕的对象</returns>
        private static object ConvertToCommonType(object value, Type destinationType)
        {
            object returnValue;
            if ((value == null) || destinationType.IsInstanceOfType(value))
            {
                return value;
            }
            string str = value as string;
            if ((str != null) && (str.Length == 0))
            {
                return null;
            }
            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }
            if (!flag && !converter.CanConvertTo(destinationType))
            {
                throw new InvalidOperationException("无法转换成类型：" + value.ToString() + "==>" + destinationType);
            }
            try
            {
                returnValue = flag ? converter.ConvertFrom(null, null, value) : converter.ConvertTo(null, null, value, destinationType);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("类型转换出错：" + value.ToString() + "==>" + destinationType, e);
            }
            return returnValue;
        }
    }
    #endregion
}