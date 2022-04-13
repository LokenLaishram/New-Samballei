using ClosedXML.Excel;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.SMS;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduSMS;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduSMS
{
    public partial class SmsHistory : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddls();
                BindGrid(1);
            }
        }
        protected void Bindddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlSendTo, mstlookup.GetLookupsList(LookupNames.SendTo));
            Commonfunction.PopulateDdl(ddlSmsType, mstlookup.GetLookupsList(LookupNames.SmsType));
            Commonfunction.PopulateDdl(ddlSentBy, mstlookup.GetLookupsList(LookupNames.Admin));
        }
        //Get autocomplete SMSID
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetSmsID(string prefixText, int count, string contextKey)
        {
            SmsData objSmsData = new SmsData();
            SmsBO objSmsBO = new SmsBO();
            List<SmsData> getResult = new List<SmsData>();

            objSmsData.SmsID = Convert.ToInt64(prefixText);
            getResult = objSmsBO.GetSmsID(objSmsData);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].SmsID.ToString());
            }
            return list;
        }
        private void BindGrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SmsData> result = GetSmsHistoryList(index, pagesize);
            if (result.Count > 0)
            {
                GvSmsHistory.Visible = true;
                GvSmsHistory.PageSize = pagesize;
                GvSmsHistory.Visible = true;
                GvSmsHistory.VirtualItemCount = result[0].MaximumRows;
                GvSmsHistory.PageIndex = index - 1;
                GvSmsHistory.DataSource = result;
                GvSmsHistory.DataBind();
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
                lblresult.Visible = true;
            }
            else
            {
                lblresult.Visible = false;
                divsearch.Visible = true;
                GvSmsHistory.DataSource = null;
                GvSmsHistory.DataBind();
            }
        }
        public List<SmsData> GetSmsHistoryList(int curIndex, int pagesize)
        {
            SmsData objSmsData = new SmsData();
            SmsBO objSmsBO = new SmsBO();

            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime From = txtDateFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDateFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtDateTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtDateTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objSmsData.AcademicSessionID = Convert.ToInt32(ddlAcademicID.SelectedValue == "" ? "0" : ddlAcademicID.SelectedValue);
            objSmsData.SmsID = Convert.ToInt64(txtSmsID.Text.Trim() == "" ? "0" : txtSmsID.Text.Trim());
            objSmsData.SendTo = Convert.ToInt32(ddlSendTo.SelectedValue == "" ? "0" : ddlSendTo.SelectedValue);
            objSmsData.SmsTypeID = Convert.ToInt32(ddlSmsType.SelectedValue == "" ? "0" : ddlSmsType.SelectedValue);
            objSmsData.DateFrom = From;
            objSmsData.DateTo = To;
            objSmsData.StatusID = Convert.ToInt32(ddlStatus.SelectedValue == "" ? "0" : ddlStatus.SelectedValue);
            objSmsData.UserId = Convert.ToInt32(ddlSentBy.SelectedValue == "" ? "0" : ddlSentBy.SelectedValue);
            objSmsData.PageSize = pagesize;
            objSmsData.CurrentIndex = curIndex;

            return objSmsBO.SearchSmsHistoryList(objSmsData);
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
                wb.Worksheets.Add(dt, "Fee Collection");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= SmsHistory_" + (ddlSendTo.SelectedIndex == 0 ? "All" : ddlSendTo.SelectedItem.Text) + ".xlsx");
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
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SmsData> result = GetSmsHistoryList(1, pagesize);

            List<ExcelSmsHeaderHistory> listecelstd = new List<ExcelSmsHeaderHistory>();
            int i = 0;
            foreach (SmsData row in result)
            {
                ExcelSmsHeaderHistory EcxeclStd = new ExcelSmsHeaderHistory();
                EcxeclStd.SMSID = result[i].SmsID;
                EcxeclStd.SmsDescription = result[i].DeliveredSMS;
                EcxeclStd.TotalRecipients = result[i].RecipientCount;
                EcxeclStd.TotalSmsCost = result[i].TotalSmsCost;
                EcxeclStd.DateSent = Convert.ToString(result[i].SentTime);
                EcxeclStd.SentBy = result[i].SentBy;
                EcxeclStd.Status = result[i].HeaderStatus;
                listecelstd.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(listecelstd);
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

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void bindresponsive()
        {
            //Responsive 
            GvSmsHistory.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvSmsHistory.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSmsHistory.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSmsHistory.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvSmsHistory.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvSmsHistory.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvSmsHistory.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //GvSmsHistory.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";

            //  Adds THEAD and TBODY to GridView.
            GvSmsHistory.UseAccessibleHeader = true;
            GvSmsHistory.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvSmsHistory.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        protected void ResetAll()
        {
            divsearch.Visible = false;
            //MasterLookupBO mstlookup = new MasterLookupBO();
            //Commonfunction.PopulateDdl(ddlAcademicID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            //ddlAcademicID.SelectedIndex = 1;
            //Commonfunction.PopulateDdl(ddlSendTo, mstlookup.GetLookupsList(LookupNames.SendTo));
            //Commonfunction.PopulateDdl(ddlSmsType, mstlookup.GetLookupsList(LookupNames.SmsType));
            //Commonfunction.PopulateDdl(ddlSentBy, mstlookup.GetLookupsList(LookupNames.Admin));
            GvSmsHistory.DataSource = null;
            GvSmsHistory.DataBind();
            GvSmsHistory.Visible = false;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            lblresult.Visible = false;
            //btnsend.Enabled = false;
            ddlAcademicID.SelectedIndex = 1;
            ddlSendTo.SelectedIndex = 0;
            ddlSmsType.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
        }

        protected void GvSmsHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSmsHistory.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvSmsHistory_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                BindGrid(1);
                DataTable dt = new DataTable();

                dt = ds.Tables[0];
                {
                    string SortDir = string.Empty;
                    if (dir == SortDirection.Ascending)
                    {
                        dir = SortDirection.Descending;
                        SortDir = "Desc";
                    }
                    else
                    {
                        dir = SortDirection.Ascending;
                        SortDir = "Asc";
                    }
                    DataView sortedView = new DataView(dt);
                    sortedView.Sort = e.SortExpression + " " + SortDir;
                    GvSmsHistory.DataSource = sortedView;
                    GvSmsHistory.DataBind();

                    TableCell tableCell = GvSmsHistory.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvSmsHistory.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvSmsHistory.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
                    GvSmsHistory.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvSmsHistory.UseAccessibleHeader = true;
                    GvSmsHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
        static public int GetColumnIndexByDBName(GridView aGridView, String ColumnText)
        {
            System.Web.UI.WebControls.BoundField DataColumn;
            for (int Index = 0; Index < aGridView.Columns.Count; Index++)
            {
                DataColumn = aGridView.Columns[Index] as System.Web.UI.WebControls.BoundField;
                if (DataColumn != null)
                {
                    if (DataColumn.DataField == ColumnText)
                        return Index;
                }
            }
            return -1;
        }

        protected void GvSmsHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    SmsData objSmsData = new SmsData();
                    SmsBO objSmsBO = new SmsBO();

                    Label SMSID = (Label)e.Row.FindControl("lblSMSID");
                    Label SmsTypeID = (Label)e.Row.FindControl("lblSmsTypeID");
                    Label SendToID = (Label)e.Row.FindControl("lblSentToID");
                    Label AcademicID = (Label)e.Row.FindControl("lblAcademicID");

                    objSmsData.SmsID = Convert.ToInt32(SMSID.Text.Trim() == "" ? "0" : SMSID.Text.Trim());
                    objSmsData.SmsTypeID = Convert.ToInt32(SmsTypeID.Text.Trim() == "" ? "0" : SmsTypeID.Text.Trim());
                    objSmsData.SendTo = Convert.ToInt32(SendToID.Text.Trim() == "" ? "0" : SendToID.Text.Trim());
                    objSmsData.AcademicSessionID = Convert.ToInt32(AcademicID.Text.Trim() == "" ? "0" : AcademicID.Text.Trim());

                    if (objSmsData.SendTo == 1)
                    {
                        List<SmsData> GetResult = objSmsBO.SearchChildDetailBySmsID(objSmsData);
                        GridView SC = (GridView)e.Row.FindControl("GridStudentChild");
                        SC.DataSource = GetResult;
                        SC.DataBind();
                    }
                    else if (objSmsData.SendTo == 2)
                    {
                        List<SmsData> GetResult = objSmsBO.SearchChildDetailBySmsID(objSmsData);
                        GridView SC = (GridView)e.Row.FindControl("GridEmpChild");
                        SC.DataSource = GetResult;
                        SC.DataBind();
                    }
                    else
                    {
                        GridView SCstd = (GridView)e.Row.FindControl("GridStudentChild");
                        SCstd.DataSource = null;
                        SCstd.DataBind();
                        SCstd.Visible = false;

                        GridView SCEmp = (GridView)e.Row.FindControl("GridEmpChild");
                        SCEmp.DataSource = null;
                        SCEmp.DataBind();
                        SCEmp.Visible = false;
                    }
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
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

        protected void ddlSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void ddlSmsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void ddlSentBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
    }
}
