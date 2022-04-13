using ClosedXML.Excel;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduFees
{
    public partial class DefaulterList : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                BindDlls();
                // bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_feetype, mstlookup.GetLookupsList(LookupNames.FeeTypes));
            ddl_feetype.SelectedIndex = 2;
            ddl_feetype.Attributes["disabled"] = "disabled";
            Commonfunction.PopulateDdl(ddl_month, mstlookup.GetLookupsList(LookupNames.Months));

            Commonfunction.Insertzeroitemindex(ddlsections);
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvFeedetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvFeedetails.UseAccessibleHeader = true;
            GvFeedetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvClassDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                bindgrid(1);
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
                    GvFeedetails.DataSource = sortedView;
                    GvFeedetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvFeedetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<FeeStatusData> listdetails = Getdefaulterstudentlist(index, pagesize);
            if (listdetails.Count > 0)
            {
                GvFeedetails.PageSize = pagesize;
                string record = listdetails[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + listdetails[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = listdetails[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvFeedetails.VirtualItemCount = listdetails[0].MaximumRows;//total item is required for custom paging
                GvFeedetails.PageIndex = index - 1;
                GvFeedetails.DataSource = listdetails;
                GvFeedetails.DataBind();


            }
            else
            {
                lblresult.Text = "";
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                GvFeedetails.Visible = true;

            }
            divsearch.Visible = true;

        }
        public List<FeeStatusData> Getdefaulterstudentlist(int curIndex, int pagesize)
        {
            FeeStatusData objpayment = new FeeStatusData();
            FeeCollectionBO objpaymentBO = new FeeCollectionBO();
            objpayment.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objpayment.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objpayment.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objpayment.FeeTypeID = Convert.ToInt32(ddl_feetype.SelectedValue == "" ? "0" : ddl_feetype.SelectedValue);
            objpayment.MonthID = Convert.ToInt32(ddl_month.SelectedValue == "" ? "0" : ddl_month.SelectedValue);
            objpayment.Paystatus = Convert.ToInt32(ddl_status.SelectedValue == "" ? "0" : ddl_status.SelectedValue);
            objpayment.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objpayment.PageSize = pagesize;
            objpayment.CurrentIndex = curIndex;
            return objpaymentBO.Getdefaulterlist(objpayment);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlacademicseesions.SelectedIndex = 1;
            ddlclasses.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlsections);
            txtrollNo.Text = "";
            lblmessage.Visible = false;
            GvFeedetails.DataSource = null;
            GvFeedetails.DataBind();
            divsearch.Visible = false;
            ddl_month.SelectedIndex = 0;
            ddl_feetype.SelectedIndex = 2;
            ddl_status.SelectedIndex = 0;

        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Fee List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= FeeStatus.xlsx");
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
            List<FeeStatusData> data = Getdefaulterstudentlist(1, size);
            List<FeeStatusDataExcel> Datatoexcel = new List<FeeStatusDataExcel>();
            int i = 0;
            foreach (FeeStatusData row in data)
            {
                FeeStatusDataExcel Ecxecl = new FeeStatusDataExcel();
                Ecxecl.BillNo = data[i].BillNo;
                Ecxecl.BillDate = data[i].Billdatetime;
                Ecxecl.StudentName = data[i].StudentName;
                Ecxecl.Particulars = data[i].Particulars;
                Ecxecl.TotalFeeAmount = data[i].TotalFeeAmount;
                Ecxecl.TotalFineAmount = data[i].TotalFineAmount;
                Ecxecl.TotalDiscountAmount = data[i].TotalDiscountAmount;
                Ecxecl.TotalPaidAmount = data[i].TotalPaidAmount;
                Datatoexcel.Add(Ecxecl);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Datatoexcel);
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void GvFeedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvFeedetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvFeedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    FeeStatusData objpayment = new FeeStatusData();
                    FeeCollectionBO objpaymentBO = new FeeCollectionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvFeedetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("lbl_remark");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objpayment.Remarks = txtremarks.Text;
                    }
                    objpayment.ID = Convert.ToInt64(ID.Text);
                    objpayment.AcademicSessionID = LoginToken.AcademicSessionID;
                    objpayment.UserId = LoginToken.UserLoginId;
                    int Result = objpaymentBO.DeleteBill(objpayment);
                    if (Result == 1)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);

                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    bindresponsive();
                }
                if (e.CommandName == "Print")
                {
                    int j = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvFeedetails.Rows[j];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label Student = (Label)gr.Cells[0].FindControl("lblstudentID");
                    Label Session = (Label)gr.Cells[0].FindControl("lblsessionID");
                    string sessionid = Session.Text == "" ? "0" : Session.Text;
                    string studentID = Student.Text;
                    string billID = ID.Text;
                    string feetype = "0";
                    string url = "../EduFees/Reports/ReportViewer.aspx?option=FeeReciept&SessionID=" + sessionid + "&StudentID=" + studentID + "&BillID=" + billID + "&FeeTypeID=" + feetype;
                    string fullURL = "window.open('" + url + "', '_blank');";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            string sessionid = ddlacademicseesions.SelectedValue;
            string ClassID = ddlclasses.SelectedValue;
            string SectionID = ddlsections.SelectedValue;
            string roll = txtrollNo.Text;
            string Status = ddl_status.SelectedValue;
            string month = ddl_month.SelectedValue;

            string feetype = ddl_feetype.SelectedValue;
            string PageSize = ddl_show.SelectedValue;
            string url = "../EduFees/Reports/ReportViewer.aspx?option=Mtfeestatus&SessionID=" + sessionid + "&ClassID=" + ClassID
              + "&SectionID=" + SectionID + "&RollNo=" + roll + "&FeeTypeID=" + feetype
              + "&Status=" + Status + "&Month=" + month;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }
        protected void sbtnprint_Click(object sender, EventArgs e)
        {
            string sessionid = ddlacademicseesions.SelectedValue;
            string ClassID = ddlclasses.SelectedValue;
            string SectionID = ddlsections.SelectedValue;
            string roll = txtrollNo.Text;
            string Status = ddl_status.SelectedValue;
            string month = ddl_month.SelectedValue;

            string feetype = ddl_feetype.SelectedValue;
            string PageSize = ddl_show.SelectedValue;
            string url = "../EduFees/Reports/ReportViewer.aspx?option=SMtfeestatus&SessionID=" + sessionid + "&ClassID=" + ClassID
              + "&SectionID=" + SectionID + "&RollNo=" + roll + "&FeeTypeID=" + feetype
              + "&Status=" + Status + "&Month=" + month;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }
        protected void ddl_paymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddl_collectedby_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}