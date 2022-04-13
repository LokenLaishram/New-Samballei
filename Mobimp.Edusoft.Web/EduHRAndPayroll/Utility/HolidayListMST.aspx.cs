using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Campusoft.Data.HRAndPayroll.Utility;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.Utility
{
    public partial class HolidayListMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                btnUpdate.Attributes["disabled"] = "disabled";
            }
        }
        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSession.SelectedValue = LoginToken.AcademicSessionID.ToString();
            Commonfunction.PopulateDdl(ddlMonth, mstlookup.GetLookupsList(LookupNames.Months));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSession.SelectedValue=="0")
            {
                lblmessage.Text = "Please Select Session.";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            if (ddlMonth.SelectedValue == "0")
            {
                lblmessage.Text = "Please Select Month.";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
                return;
            }
            else
            {
                lblmessage.Visible = false;
                lblmessage.Text = "";
            }
            bindgrid(1);
            
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<HolidayListData> lstHoliday = GetHolidayDetails(index, pagesize);
            if (lstHoliday.Count > 0)
            {
                GvHolidayList.PageSize = pagesize;
                string record = lstHoliday[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstHoliday[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstHoliday[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvHolidayList.VirtualItemCount = lstHoliday[0].MaximumRows;//total item is required for custom paging
                GvHolidayList.PageIndex = index - 1;
                GvHolidayList.DataSource = lstHoliday;
                GvHolidayList.DataBind();
                ds = ConvertToDataSet(lstHoliday);
                TableCell tableCell = GvHolidayList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnUpdate.Attributes.Remove("disabled");
                btnUpdate.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                GvHolidayList.DataSource = null;
                GvHolidayList.DataBind();
                btnUpdate.Attributes["disabled"] = "disabled";
                btnUpdate.Visible = false;
                btnPrint.Visible = false;
            }
        }
        public List<HolidayListData> GetHolidayDetails(int curIndex, int pagesize)
        {
            HolidayListData objdata = new HolidayListData();
            HolidayListBO objBO = new HolidayListBO();
            objdata.YearID = Convert.ToInt32(ddlSession.SelectedValue == "" ? "0" : ddlSession.SelectedValue);
            objdata.Year = ddlSession.SelectedItem.Text == null ? "" : ddlSession.SelectedItem.Text;
            objdata.MonthID = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "0" : ddlMonth.SelectedValue);
            objdata.Month = ddlMonth.SelectedItem.Text == null ? "" : ddlMonth.SelectedItem.Text;
            objdata.AddedBy = LoginToken.LoginId;
            objdata.UserId = LoginToken.UserLoginId;
            objdata.CompanyID = LoginToken.CompanyID;
            objdata.AcademicSessionID = LoginToken.AcademicSessionID;
            objdata.PageSize = GvHolidayList.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetHolidayDetails(objdata);
        }
        public DataSet ConvertToDataSet<T>(IList<T> list)
        {
            DataSet dsFromDtStru = new DataSet();
            DataTable table = new DataTable();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                table.Rows.Add(row);
            }
            dsFromDtStru.Tables.Add(table);
            return dsFromDtStru;
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvHolidayList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvHolidayList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvHolidayList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvHolidayList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvHolidayList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvHolidayList.UseAccessibleHeader = true;
            GvHolidayList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvHolidayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvHolidayList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvHolidayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label Day = (Label)e.Row.FindControl("Gv_lblDay");
                    if (Day.Text == "Sunday")
                    {
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Red;
                        //System.Drawing.ColorTranslator.FromHtml("#FFCC66");
                    }
                    CheckBox chkisholiday = (CheckBox)e.Row.FindControl("Gv_ChkHoliday");
                    Label lblisholiday = (Label)e.Row.FindControl("Gv_lblHoliday");
                    if (lblisholiday.Text == "1")
                    {
                        chkisholiday.Checked = true;
                        e.Row.Cells[4].BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        chkisholiday.Checked = false;
                        chkisholiday.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {           
            try
            {
                List<HolidayListData> ListHoliday = new List<HolidayListData>();
                HolidayListBO objBO = new HolidayListBO();
                HolidayListData objData = new HolidayListData();
                foreach (GridViewRow row in GvHolidayList.Rows)
                {                    
                    Label ID = (Label)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_ID");
                    Label YearID = (Label)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYearID");
                    Label Year = (Label)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblYear");
                    Label MonthID = (Label)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonthID");
                    Label Month = (Label)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_lblMonth");
                    TextBox Reason = (TextBox)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_txtReason");
                    CheckBox chkholiday = (CheckBox)GvHolidayList.Rows[row.RowIndex].Cells[0].FindControl("Gv_ChkHoliday");
                    HolidayListData ObjDetails = new HolidayListData();
                   
                    ObjDetails.ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                    ObjDetails.YearID = Convert.ToInt32 (YearID.Text == "" ? "0" : YearID.Text);
                    ObjDetails.Year = (Year.Text == null ? "" : Year.Text);
                    ObjDetails.MonthID = Convert.ToInt32 (MonthID.Text == "" ? "0" : MonthID.Text);
                    ObjDetails.Month = (Month.Text == "" ? "0" : Month.Text);
                    ObjDetails.Reason = Reason.Text == null ? "" : Reason.Text;
                    ObjDetails.IsHoliday = chkholiday.Checked ? 1 : 0;
                    ListHoliday.Add(ObjDetails);
                }
                objData.XMLData = XmlConvertor.HolidayListToXml(ListHoliday).ToString();
                objData.AddedBy = LoginToken.LoginId;
                objData.UserId = LoginToken.UserLoginId;
                objData.CompanyID = LoginToken.CompanyID;
                objData.AcademicSessionID = LoginToken.AcademicSessionID;

                int result = objBO.UpdateHolidayDetails(objData);
                if (result == 1)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    bindgrid(1);
                    return;
                }                
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    btnUpdate.Attributes["disabled"] = "disabled";
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ClearAll()
        {
            ddlSession.SelectedIndex = 0;
            lblmessage.Text = "";
            lblresult.Text = "";
            lbl_show.Text = "";
            ddlMonth.SelectedIndex = 0;
            ddl_show.SelectedIndex = 0;
            lbl_totalrecords.Text = "";
            GvHolidayList.DataSource = null;
            GvHolidayList.DataBind();
            GvHolidayList.Visible = false;
            btnUpdate.Attributes["disabled"] = "disabled";
            btnUpdate.Visible = false;
            btnPrint.Visible = false;
        }
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "LoanType List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= HolidayList.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        protected DataTable GetDatafromDatabase()
        {
            int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<HolidayListData> HolidayDetail = GetHolidayDetails(1, size);
            List<HolidayListDataToExcel> HolidayListToExcel = new List<HolidayListDataToExcel>();
            int i = 0;
            foreach (HolidayListData row in HolidayDetail)
            {
                HolidayListDataToExcel ExcelHoliday = new HolidayListDataToExcel();
                ExcelHoliday.SlNo = i + 1;
                ExcelHoliday.Year = HolidayDetail[i].Year;
                ExcelHoliday.Month = HolidayDetail[i].Month;
                ExcelHoliday.Date = HolidayDetail[i].Date;
                ExcelHoliday.Day = HolidayDetail[i].Day;
                ExcelHoliday.Reason = HolidayDetail[i].Reason;
                ExcelHoliday.HolidayStatus = HolidayDetail[i].HolidayStatus;
                HolidayListToExcel.Add(ExcelHoliday);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(HolidayListToExcel);
            return dt;
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}