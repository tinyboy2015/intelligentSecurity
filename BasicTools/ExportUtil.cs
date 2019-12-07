using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using DatabaseOpClassLibrary;

namespace BasicTools
{
    /// <summary>
    /// OfficeUtil 的摘要说明
    /// </summary>
    public class ExportUtil
    {

        public static void ExportGVtoExcel(string fileName, GridView gv, string sInfo)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            short iCols = (short)gv.Columns.Count;
            int preRows = 3;

            SetTitle1(workbook, sheet, HttpContext.Current.Server.UrlDecode(fileName), iCols);

            if (sInfo != "")
            {
                preRows++;
                //Create SubTitle
                IRow subRow = sheet.CreateRow(3);
                subRow.HeightInPoints = 20;
                ICell subCell = subRow.CreateCell(0);
                subCell.SetCellValue(sInfo);
                ICellStyle styleSub = workbook.CreateCellStyle();
                styleSub.Alignment = HorizontalAlignment.LEFT;
                styleSub.VerticalAlignment = VerticalAlignment.CENTER;
                styleSub.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
                IFont fontSub = workbook.CreateFont();
                fontSub.FontHeight = 200;
                styleSub.SetFont(fontSub);
                subCell.CellStyle = styleSub;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 0, iCols - 1));
            }
            //add the header row to the table
            if (gv.HeaderRow != null)
            {
                ICellStyle styleHeader = workbook.CreateCellStyle();
                styleHeader.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.FillPattern = FillPatternType.LESS_DOTS;
                styleHeader.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.Alignment = HorizontalAlignment.CENTER;
                styleHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                IFont fontHeader = workbook.CreateFont();
                fontHeader.Boldweight = (short)FontBoldWeight.BOLD;
                styleHeader.SetFont(fontHeader);
                IRow headerRow = sheet.CreateRow(preRows);
                headerRow.HeightInPoints = 20;
                sheet.DefaultColumnWidth = 15;
                for (int ii = 0; ii < iCols; ii++)
                {
                    string sOutput = "";
                    foreach (Control control in gv.HeaderRow.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = headerRow.CreateCell(ii);
                    cell.CellStyle = styleHeader;
                    Unit unit = gv.Columns[ii].ItemStyle.Width;
                    if (unit.Value == 0) unit = gv.Columns[ii].HeaderStyle.Width;
                    if (unit.Value != 0)
                    {
                        if (unit.Value < 1)
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 100 * 256));
                        else
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 256));
                    }
                    cell.SetCellValue(sOutput + gv.HeaderRow.Cells[ii].Text.Replace("&nbsp;", ""));
                }
                preRows++;
            }

            //  add each of the data rows to the table
            IFont fontRed = workbook.CreateFont();
            fontRed.Color = NPOI.HSSF.Util.HSSFColor.RED.index;
            IFont fontBlue = workbook.CreateFont();
            fontBlue.Color = NPOI.HSSF.Util.HSSFColor.BLUE.index;
            IFont fontBlack = workbook.CreateFont();
            fontBlack.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow gvr = gv.Rows[i];

                IFont fontRow = fontBlack;
                if (gvr.Style["color"] == "blue")
                {
                    fontRow = fontRed;
                }
                else if (gvr.Style["color"] == "red")
                {
                    fontRow = fontBlue;
                }

                IRow curRow = sheet.CreateRow(preRows);
                preRows++;
                curRow.HeightInPoints = 16;
                for (int ii = 0; ii < iCols; ii++)
                {

                    string sOutput = "";
                    foreach (Control control in gvr.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell curCell = curRow.CreateCell(ii);
                    curCell.SetCellValue(sOutput + gvr.Cells[ii].Text.Replace("&nbsp;", "").Replace("<br />", "\r\n"));
                    ICellStyle curStyle = workbook.CreateCellStyle();
                    if (gvr.Style["background-color"] == "#ffffcc" && gvr.Cells[ii].Style["background-color"] != "white")
                    {
                        curStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
                        curStyle.FillPattern = FillPatternType.LESS_DOTS;
                        curStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
                    }
                    curStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    IFont fontCell = fontBlack;
                    if (gvr.Cells[ii].Style["color"] == "blue")
                    {
                        fontCell = fontBlue;
                    }
                    else if (gvr.Cells[ii].Style["color"] == "red")
                    {
                        fontCell = fontRed;
                    }

                    if (gvr.Cells[ii].Style["font-weight"] == "bold")
                    {
                        fontCell.Boldweight = (short)FontBoldWeight.BOLD;
                    }
                    curStyle.SetFont(fontCell);
                    switch (gv.Columns[ii].ItemStyle.HorizontalAlign.ToString().ToUpper())
                    {
                        case "CENTER":
                            curStyle.Alignment = HorizontalAlignment.CENTER;
                            curCell.CellStyle = curStyle;
                            break;
                        case "RIGHT":
                            curStyle.Alignment = HorizontalAlignment.RIGHT;
                            curCell.CellStyle = curStyle;
                            break;
                        default:
                            curCell.CellStyle = curStyle;
                            break;
                    }
                }
            }

            if (gv.FooterRow != null)
            {
                ICellStyle styleFoot = workbook.CreateCellStyle();
                //styleFoot.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                //styleFoot.FillPattern = FillPatternType.LESS_DOTS;
                //styleFoot.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleFoot.Alignment = HorizontalAlignment.RIGHT;
                styleFoot.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                IFont fontFoot = workbook.CreateFont();
                fontFoot.Boldweight = (short)FontBoldWeight.BOLD;
                styleFoot.SetFont(fontFoot);
                IRow footRow = sheet.CreateRow(preRows);
                footRow.HeightInPoints = 20;
                int iCurCol = 0;
                for (int ii = 0; ii < gv.Columns.Count; ii++)
                {
                    if (!gv.Columns[ii].Visible) continue;
                    string sOutput = "";
                    foreach (Control control in gv.FooterRow.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = footRow.CreateCell(iCurCol);
                    cell.CellStyle = styleFoot;
                    sOutput = sOutput + gv.FooterRow.Cells[ii].Text.Replace("&nbsp;", "");
                    if (sOutput.IndexOf("合计：") >= 0 || sOutput == "")
                    {
                        if (sOutput == "")
                        {
                            cell.SetCellValue(sOutput);
                        }
                        else
                        {
                            cell.SetCellValue("合计：");
                        }
                    }
                    else
                    {
                        cell.SetCellValue(sOutput); //Convert.ToDouble(sOutput)
                    }
                    iCurCol++;
                }
            }

            ExportFile(workbook, ms, fileName);
        }

        private static string FormatControl(Control control)
        {
            if (control.Visible == false) return "";
            if (control is LinkButton)
            {
                return (control as LinkButton).Text;
            }
            else if (control is DataBoundLiteralControl)
            {
                return (control as DataBoundLiteralControl).Text.Replace("\\r\\n", "").Trim().Replace("<br />", "\r\n");
            }
            else if (control is LiteralControl)
            {
                return (control as LiteralControl).Text.Replace("\\r\\n", "").Trim().Replace("<br />", "\r\n");
            }
            else if (control is Label)
            {
                return (control as Label).Text.Replace("\\r\\n", "").Trim().Replace("<br />", "\r\n");
            }
            else if (control is TextBox)
            {
                return (control as TextBox).Text;
            }
            else if (control is ImageButton)
            {
                return (control as ImageButton).AlternateText;
            }
            else if (control is Image)
            {
                return (control as Image).AlternateText;
            }
            else if (control is HyperLink)
            {
                return (control as HyperLink).Text;
            }
            else if (control is DropDownList)
            {
                return (control as DropDownList).SelectedItem.Text;
            }
            else if (control is CheckBox)
            {
                return (control as CheckBox).Checked ? "√" : "";
            }
            return "";
        }

        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is Image)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as Image).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "√" : ""));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }

        private static void SetCell(ISheet sheet, IRow curRow, short beginRow, short endRow, short beginCell, short endCell, ICellStyle style, string sValue)
        {
            ICell curCell = curRow.GetCell(beginCell);
            curCell.CellStyle = style;

            if (beginCell != endCell || beginRow != endRow)
            {
                sheet.AddMergedRegion(new CellRangeAddress(beginRow, endRow, beginCell, endCell));
            }
            curCell.SetCellValue(sValue);
        }

        private static void SetCell(ISheet sheet, IRow curRow, int beginRow, int endRow, int beginCell, int endCell, ICellStyle style, decimal decValue)
        {
            ICell curCell = curRow.GetCell(beginCell);
            curCell.CellStyle = style;

            if (beginCell != endCell || beginRow != endRow)
            {
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(beginRow, endRow, beginCell, endCell));
            }
            curCell.SetCellValue(Convert.ToDouble(decValue));
        }

        private static void CreateCells(IRow curRow, int icols, ICellStyle style)
        {
            for (int i = 0; i < icols; i++)
            {
                ICell curCell = curRow.CreateCell(i);
                curCell.CellStyle = style;
            }
        }

        private static void SetTitle1(HSSFWorkbook workbook, ISheet sheet, string title, int iCols)
        {
            BasicOp biz = new BasicOp();
            DataBase dbop = new DataBase();
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = HorizontalAlignment.CENTER;
            styleTitle.VerticalAlignment = VerticalAlignment.CENTER;
            styleTitle.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
            IFont fontTitle = workbook.CreateFont();
            fontTitle.FontHeight = 400;
            styleTitle.SetFont(fontTitle);

            IRow titleRow = sheet.CreateRow(0);
            ICell titleCell = titleRow.CreateCell(0);
            string sCompany = biz.HandleNull(dbop.GetSingleValue("Select sd_value_string From S_DefaultValue Where sd_name='公司名称'"), "中欧博雅");
            titleCell.SetCellValue(sCompany);
            titleCell.CellStyle = styleTitle;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, iCols - 1));

            ICellStyle styleTitleE = workbook.CreateCellStyle();
            styleTitleE.Alignment = HorizontalAlignment.CENTER;
            styleTitleE.VerticalAlignment = VerticalAlignment.CENTER;
            styleTitleE.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
            IFont fontTitleE = workbook.CreateFont();
            fontTitleE.FontHeight = 300;
            styleTitleE.SetFont(fontTitleE);

            string sCompanyE = biz.HandleNull(dbop.GetSingleValue("Select sd_value_string From S_DefaultValue Where sd_name='Company Name'"), "ZOBY");
            titleRow = sheet.CreateRow(1);
            titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(sCompanyE);
            titleCell.CellStyle = styleTitleE;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, iCols - 1));

            titleRow = sheet.CreateRow(2);
            titleRow.HeightInPoints = 50;
            titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(title);
            titleCell.CellStyle = styleTitle;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(2, 2, 0, iCols - 1));
        }

        private static void SetTitle(HSSFWorkbook workbook, ISheet sheet, string title, int iCols)
        {
            IRow titleRow = sheet.CreateRow(0);
            titleRow.HeightInPoints = 40;
            ICell titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(title);
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = HorizontalAlignment.CENTER;
            styleTitle.VerticalAlignment = VerticalAlignment.CENTER;
            styleTitle.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;

            IFont fontTitle = workbook.CreateFont();
            fontTitle.FontHeight = 400;
            styleTitle.SetFont(fontTitle);
            titleCell.CellStyle = styleTitle;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, iCols - 1));
        }

        private static void SetFixTitle(HSSFWorkbook workbook, ISheet sheet, string title, string branchCode, short iCols)
        {
            BasicOp biz = new BasicOp();
            DataBase dbop = new DataBase();
            ICellStyle styleTitle = workbook.CreateCellStyle();
            styleTitle.Alignment = HorizontalAlignment.CENTER;
            styleTitle.VerticalAlignment = VerticalAlignment.CENTER;
            styleTitle.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitle.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
            IFont fontTitle = workbook.CreateFont();
            fontTitle.FontHeight = 400;
            styleTitle.SetFont(fontTitle);

            IRow titleRow = sheet.CreateRow(0);
            ICell titleCell = titleRow.CreateCell(0);
            string sCompany = biz.HandleNull(dbop.GetSingleValue("Select sd_value_string From S_DefaultValue Where sd_name='公司名称'"), "中欧博雅");
            titleCell.SetCellValue(sCompany);
            titleCell.CellStyle = styleTitle;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, iCols));

            ICellStyle styleTitleE = workbook.CreateCellStyle();
            styleTitleE.Alignment = HorizontalAlignment.CENTER;
            styleTitleE.VerticalAlignment = VerticalAlignment.CENTER;
            styleTitleE.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
            styleTitleE.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
            IFont fontTitleE = workbook.CreateFont();
            fontTitleE.FontHeight = 300;
            styleTitleE.SetFont(fontTitleE);

            string sCompanyE = biz.HandleNull(dbop.GetSingleValue("Select sd_value_string From S_DefaultValue Where sd_name='Company Name'"), "ZOBY");
            titleRow = sheet.CreateRow(1);
            titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(sCompanyE);
            titleCell.CellStyle = styleTitleE;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, iCols - 1));

            titleRow = sheet.CreateRow(2);
            titleRow.HeightInPoints = 50;
            titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(title);
            titleCell.CellStyle = styleTitle;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(2, 2, 0, iCols - 1));

            IRow contactRow = sheet.CreateRow(3);
            ICell contactCell = contactRow.CreateCell(0);
            DataTable dt = dbop.GetDataSet("Select isnull(cs_add, '') as address, isnull(cs_phone, '') as phone, isnull(cs_fax, '') as fax From S_CompanyStructure Where cs_code='" + branchCode + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                string sContact = "";
                if (dt.Rows[0]["address"].ToString() != "") sContact += "地址：" + dt.Rows[0]["address"].ToString() + "    ";
                if (dt.Rows[0]["phone"].ToString() != "") sContact += "电话：" + dt.Rows[0]["phone"].ToString() + "    ";
                if (dt.Rows[0]["fax"].ToString() != "") sContact += "传真：" + dt.Rows[0]["fax"].ToString();
                contactCell.SetCellValue(sContact);
                ICellStyle styleContact = workbook.CreateCellStyle();
                styleContact.Alignment = HorizontalAlignment.LEFT;
                styleContact.VerticalAlignment = VerticalAlignment.CENTER;
                styleContact.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleContact.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
                styleContact.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
                styleContact.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
                IFont fontContact = workbook.CreateFont();
                fontContact.FontHeight = 200;
                styleContact.SetFont(fontContact);
                contactCell.CellStyle = styleContact;
                for (int i = 1; i < iCols; i++)
                {
                    ICell curCell = contactRow.CreateCell(i);
                    curCell.CellStyle = styleContact;
                }
            }
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 0, iCols - 1));
        }

        private static String translateColumnIndexToName(int index)
        {
            //assert (index >= 0);

            int quotient = (index) / 26;

            if (quotient > 0)
            {
                return translateColumnIndexToName(quotient - 1) + (char)((index % 26) + 65);
            }
            else
            {
                return "" + (char)((index % 26) + 65);
            }
        }

        public static void ExportFile(HSSFWorkbook workbook, System.IO.MemoryStream ms, string fileName)
        {
            workbook.Write(ms);
            //HttpContext.Current.Response.Charset = "GB2312";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + fileName + ".xls"));
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            ms.Close();
            ms.Dispose();
        }

        public static void ExportGVtoExcel(string fileName, DataTable dt, string sInfo, GridViewRow header, GridViewRow footer)
        {
            BasicOp biz = new BasicOp();
            HSSFWorkbook workbook = new HSSFWorkbook();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            short iCols = (short)dt.Columns.Count;
            int preRows = 3;

            SetTitle1(workbook, sheet, HttpContext.Current.Server.UrlDecode(fileName), iCols);

            if (sInfo != "")
            {
                preRows++;
                //Create SubTitle
                IRow subRow = sheet.CreateRow(3);
                subRow.HeightInPoints = 20;
                ICell subCell = subRow.CreateCell(0);
                subCell.SetCellValue(sInfo);
                ICellStyle styleSub = workbook.CreateCellStyle();
                styleSub.Alignment = HorizontalAlignment.LEFT;
                styleSub.VerticalAlignment = VerticalAlignment.CENTER;
                styleSub.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
                IFont fontSub = workbook.CreateFont();
                fontSub.FontHeight = 200;
                styleSub.SetFont(fontSub);
                subCell.CellStyle = styleSub;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 0, iCols - 1));
            }
            //add the header row to the table
            if (header != null)
            {
                ICellStyle styleHeader = workbook.CreateCellStyle();
                styleHeader.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.FillPattern = FillPatternType.LESS_DOTS;
                styleHeader.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.Alignment = HorizontalAlignment.CENTER;
                styleHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                IFont fontHeader = workbook.CreateFont();
                fontHeader.Boldweight = (short)FontBoldWeight.BOLD;
                styleHeader.SetFont(fontHeader);
                IRow headerRow = sheet.CreateRow(preRows);
                headerRow.HeightInPoints = 20;
                sheet.DefaultColumnWidth = 15;
                for (int ii = 0; ii < iCols; ii++)
                {
                    string sOutput = "";
                    foreach (Control control in header.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = headerRow.CreateCell(ii);
                    cell.CellStyle = styleHeader;
                    Unit unit = header.Cells[ii].Width;// gv.Columns[ii].ItemStyle.Width;
                    if (unit.Value == 0) unit = Unit.Pixel(100); //gv.Columns[ii].HeaderStyle.Width
                    if (unit.Value != 0)
                    {
                        if (unit.Value < 1)
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 100 * 256));
                        else
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 256));
                    }
                    cell.SetCellValue(sOutput + header.Cells[ii].Text.Replace("&nbsp;", ""));
                }
                preRows++;
            }

            //  add each of the data rows to the table
            IFont fontBlack = workbook.CreateFont();
            fontBlack.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
            ICellStyle curStyle = workbook.CreateCellStyle();
            curStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            curStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            curStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            curStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            curStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
            curStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
            curStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
            curStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
            curStyle.SetFont(fontBlack);
            curStyle.Alignment = HorizontalAlignment.CENTER;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IFont fontRow = fontBlack;

                IRow curRow = sheet.CreateRow(preRows);
                preRows++;
                curRow.HeightInPoints = 16;
                for (int ii = 0; ii < iCols; ii++)
                {
                    ICell curCell = curRow.CreateCell(ii);
                    curCell.SetCellValue(biz.HandleNull(dt.Rows[i][ii], ""));
                    curCell.CellStyle = curStyle;
                }
            }

            if (footer != null)
            {
                ICellStyle styleFoot = workbook.CreateCellStyle();
                styleFoot.Alignment = HorizontalAlignment.RIGHT;
                styleFoot.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                IFont fontFoot = workbook.CreateFont();
                fontFoot.Boldweight = (short)FontBoldWeight.BOLD;
                styleFoot.SetFont(fontFoot);
                IRow footRow = sheet.CreateRow(preRows);
                footRow.HeightInPoints = 20;
                int iCurCol = 0;
                for (int ii = 0; ii < footer.Cells.Count; ii++)
                {
                    string sOutput = "";
                    foreach (Control control in footer.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = footRow.CreateCell(iCurCol);
                    cell.CellStyle = styleFoot;
                    sOutput = sOutput + footer.Cells[ii].Text.Replace("&nbsp;", "");
                    if (sOutput.IndexOf("合计：") >= 0 || sOutput == "")
                    {
                        if (sOutput == "")
                        {
                            cell.SetCellValue(sOutput);
                        }
                        else
                        {
                            cell.SetCellValue("合计：");
                        }
                    }
                    else
                    {
                        cell.SetCellValue(Convert.ToDouble(sOutput));
                    }
                    iCurCol++;
                }
            }

            ExportFile(workbook, ms, fileName);
        }

        public static void ExportGVtoExcel(HSSFWorkbook workbook, GridView gv, string sInfo)
        {
            ISheet sheet = workbook.CreateSheet("Sheet" + sInfo);
            int iCols = gv.Columns.Count;
            int preRows = 3;

            if (sInfo != "")
            {
                preRows++;
                //Create SubTitle
                IRow subRow = sheet.CreateRow(3);
                subRow.HeightInPoints = 20;
                ICell subCell = subRow.CreateCell(0);
                subCell.SetCellValue(sInfo);
                ICellStyle styleSub = workbook.CreateCellStyle();
                styleSub.Alignment = HorizontalAlignment.LEFT;
                styleSub.VerticalAlignment = VerticalAlignment.CENTER;
                styleSub.BorderBottom = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderLeft = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderRight = NPOI.SS.UserModel.BorderStyle.NONE;
                styleSub.BorderTop = NPOI.SS.UserModel.BorderStyle.NONE;
                IFont fontSub = workbook.CreateFont();
                fontSub.FontHeight = 200;
                styleSub.SetFont(fontSub);
                subCell.CellStyle = styleSub;
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 0, iCols - 1));
            }
            //add the header row to the table
            if (gv.HeaderRow != null)
            {
                ICellStyle styleHeader = workbook.CreateCellStyle();
                styleHeader.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.FillPattern = FillPatternType.LESS_DOTS;
                styleHeader.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleHeader.Alignment = HorizontalAlignment.CENTER;
                styleHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleHeader.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                styleHeader.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                IFont fontHeader = workbook.CreateFont();
                fontHeader.Boldweight = (short)FontBoldWeight.BOLD;
                styleHeader.SetFont(fontHeader);
                IRow headerRow = sheet.CreateRow(preRows);
                headerRow.HeightInPoints = 20;
                sheet.DefaultColumnWidth = 15;
                for (int ii = 0; ii < iCols; ii++)
                {
                    string sOutput = "";
                    foreach (Control control in gv.HeaderRow.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = headerRow.CreateCell(ii);
                    cell.CellStyle = styleHeader;
                    Unit unit = gv.Columns[ii].ItemStyle.Width;
                    if (unit.Value == 0) unit = gv.Columns[ii].HeaderStyle.Width;
                    if (unit.Value != 0)
                    {
                        if (unit.Value < 1)
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 100 * 256));
                        else
                            sheet.SetColumnWidth(ii, Convert.ToInt32(unit.Value * 256));
                    }
                    cell.SetCellValue(sOutput + gv.HeaderRow.Cells[ii].Text.Replace("&nbsp;", ""));
                }
                preRows++;
            }

            //  add each of the data rows to the table
            IFont fontRed = workbook.CreateFont();
            fontRed.Color = NPOI.HSSF.Util.HSSFColor.RED.index;
            IFont fontBlue = workbook.CreateFont();
            fontBlue.Color = NPOI.HSSF.Util.HSSFColor.BLUE.index;
            IFont fontBlack = workbook.CreateFont();
            fontBlack.Color = NPOI.HSSF.Util.HSSFColor.BLACK.index;
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                GridViewRow gvr = gv.Rows[i];

                IFont fontRow = fontBlack;
                if (gvr.Style["color"] == "blue")
                {
                    fontRow = fontRed;
                }
                else if (gvr.Style["color"] == "red")
                {
                    fontRow = fontBlue;
                }

                IRow curRow = sheet.CreateRow(preRows);
                preRows++;
                curRow.HeightInPoints = 16;
                for (int ii = 0; ii < iCols; ii++)
                {

                    string sOutput = "";
                    foreach (Control control in gvr.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell curCell = curRow.CreateCell(ii);
                    curCell.SetCellValue(sOutput + gvr.Cells[ii].Text.Replace("&nbsp;", "").Replace("<br />", "\r\n"));
                    ICellStyle curStyle = workbook.CreateCellStyle();
                    if (gvr.Style["background-color"] == "#ffffcc" && gvr.Cells[ii].Style["background-color"] != "white")
                    {
                        curStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
                        curStyle.FillPattern = FillPatternType.LESS_DOTS;
                        curStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
                    }
                    curStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                    curStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    curStyle.RightBorderColor = NPOI.HSSF.Util.HSSFColor.GREY_40_PERCENT.index;
                    IFont fontCell = fontBlack;
                    if (gvr.Cells[ii].Style["color"] == "blue")
                    {
                        fontCell = fontBlue;
                    }
                    else if (gvr.Cells[ii].Style["color"] == "red")
                    {
                        fontCell = fontRed;
                    }

                    if (gvr.Cells[ii].Style["font-weight"] == "bold")
                    {
                        fontCell.Boldweight = (short)FontBoldWeight.BOLD;
                    }
                    curStyle.SetFont(fontCell);
                    switch (gv.Columns[ii].ItemStyle.HorizontalAlign.ToString().ToUpper())
                    {
                        case "CENTER":
                            curStyle.Alignment = HorizontalAlignment.CENTER;
                            curCell.CellStyle = curStyle;
                            break;
                        case "RIGHT":
                            curStyle.Alignment = HorizontalAlignment.RIGHT;
                            curCell.CellStyle = curStyle;
                            break;
                        default:
                            curCell.CellStyle = curStyle;
                            break;
                    }
                }
            }

            if (gv.FooterRow != null)
            {
                ICellStyle styleFoot = workbook.CreateCellStyle();
                //styleFoot.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                //styleFoot.FillPattern = FillPatternType.LESS_DOTS;
                //styleFoot.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.WHITE.GREY_25_PERCENT.index;
                styleFoot.Alignment = HorizontalAlignment.RIGHT;
                styleFoot.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                styleFoot.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                IFont fontFoot = workbook.CreateFont();
                fontFoot.Boldweight = (short)FontBoldWeight.BOLD;
                styleFoot.SetFont(fontFoot);
                IRow footRow = sheet.CreateRow(preRows);
                footRow.HeightInPoints = 20;
                int iCurCol = 0;
                for (int ii = 0; ii < gv.Columns.Count; ii++)
                {
                    if (!gv.Columns[ii].Visible) continue;
                    string sOutput = "";
                    foreach (Control control in gv.FooterRow.Cells[ii].Controls)
                    {
                        sOutput += FormatControl(control);
                    }
                    ICell cell = footRow.CreateCell(iCurCol);
                    cell.CellStyle = styleFoot;
                    sOutput = sOutput + gv.FooterRow.Cells[ii].Text.Replace("&nbsp;", "");
                    if (sOutput.IndexOf("合计：") >= 0 || sOutput == "")
                    {
                        if (sOutput == "")
                        {
                            cell.SetCellValue(sOutput);
                        }
                        else
                        {
                            cell.SetCellValue("合计：");
                        }
                    }
                    else
                    {
                        cell.SetCellValue(sOutput); //Convert.ToDouble(sOutput)
                    }
                    iCurCol++;
                }
            }
        }

    }
}

