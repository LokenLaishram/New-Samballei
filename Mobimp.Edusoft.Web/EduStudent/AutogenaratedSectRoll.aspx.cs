using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduStudent;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduStudent
{
    public partial class AutogenaratedSectRoll : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                Ddls();
            }
        }
        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue)));
            if (ddlClassID.SelectedValue == "0")
            {
                GvstudentDetails.Visible = false;
                lblresult.Visible = false;
            }
            else
            {
                ddl_show.SelectedIndex = 0;
                BindGrid(1);
                GvstudentDetails.Visible = true;
                lblresult.Visible = true;
            }
            //Commonfunction.Insertzeroitemindex(ddlSectionID);
            txtRollNo.Text = "";
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        private void BindGrid(int index)
        {
            AutoRollData objstd = new AutoRollData();
            AddstudentBO objstdBO = new AddstudentBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<AutoRollData> result = GetStudentList(index, pagesize);
            if (result.Count > 0)
            {
                GvstudentDetails.Visible = true;
                GvstudentDetails.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? "  " : "  ";
                lblresult.Text = "Total Admission : " + result[0].MaximumRows.ToString() + " " + record;
                lblresult.BackColor = System.Drawing.Color.Green;
                lblresult.ForeColor = System.Drawing.Color.White;
                lbl_notadmission.Text = "Total Pending : " + ((result[0].TotalPreviusStudent) - (result[0].MaximumRows)).ToString();
                lbl_notadmission.BackColor = System.Drawing.Color.Yellow;
                lbl_notadmission.ForeColor = System.Drawing.Color.Black;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                lbl_notadmission.Visible = true;
                GvstudentDetails.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvstudentDetails.PageIndex = index - 1;
                GvstudentDetails.DataSource = result;
                GvstudentDetails.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                lbl_notadmission.Text = "";
                GvstudentDetails.DataSource = null;
                GvstudentDetails.DataBind();
                GvstudentDetails.Visible = true;
                lblresult.Visible = false;
                lbl_notadmission.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<AutoRollData> GetStudentList(int curIndex, int pagesize)
        {
            AutoRollData objstd = new AutoRollData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objstd.AllotedStatus = Convert.ToInt32(ddl_status.SelectedValue == "" ? "0" : ddl_status.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.Getautogenartedrollnumberst(objstd);
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            resetall();
        }
        private void resetall()
        {
            ddlClassID.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            txtRollNo.Text = "";
            divsearch.Visible = false;
            GvstudentDetails.Visible = false;
            lblresult.Text = "";
        }
        protected void GvstudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label Status = e.Row.FindControl("lbl_status") as Label;

                    if (Status.Text == "1")
                    {

                        e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.White;

                        e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    }
                    if (Status.Text == "2")
                    {

                        e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.Black;

                        e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[7].ForeColor = System.Drawing.Color.Black;
                    }

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                    e.Row.Cells[9].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                }
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
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
        protected void bindresponsive()
        {
            //Responsive 
            GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvstudentDetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvstudentDetails.UseAccessibleHeader = true;
            GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvstudentDetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
                wb.Worksheets.Add(dt, "Student List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= List of RollNos for Class :" + (ddlClassID.SelectedIndex == 0 ? "All" : ddlClassID.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<AutoRollData> studentdetails = GetStudentList(1, size);
            List<ExcelAutoRollData> listecelstd = new List<ExcelAutoRollData>();
            int i = 0;
            foreach (AutoRollData row in studentdetails)
            {
                ExcelAutoRollData EcxeclStd = new ExcelAutoRollData();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.DefaultSlot = studentdetails[i].DefaultSlot;
                EcxeclStd.ClassSerial = studentdetails[i].ClassSerial;
                EcxeclStd.ClassRank = studentdetails[i].ClassRank;
                EcxeclStd.ClassName = studentdetails[i].ClassName;
                EcxeclStd.AT_Section = studentdetails[i].AT_Section;
                EcxeclStd.AT_Roll = studentdetails[i].AT_Roll;
                EcxeclStd.CR_Section = studentdetails[i].CR_Section;
                EcxeclStd.CR_Roll = studentdetails[i].CR_Roll;
                EcxeclStd.BillDateTime_ASC = studentdetails[i].BillDateTime_ASC;
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
        protected void GvstudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvstudentDetails.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
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
        protected void GvstudentDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvstudentDetails.DataSource = sortedView;
                    GvstudentDetails.DataBind();

                    TableCell tableCell = GvstudentDetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvstudentDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvstudentDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvstudentDetails.UseAccessibleHeader = true;
                    GvstudentDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_show.SelectedIndex = 0;
            txtRollNo.Text = "";
            BindGrid(1);

        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            string sessionid = ddlAcademicSessionID.SelectedValue;
            string ClassID = ddlClassID.SelectedValue;
            string SectionID = ddlSectionID.SelectedValue;
            string roll = txtRollNo.Text;
            string Status = ddl_status.SelectedValue;

            string url = "../EduFees/Reports/ReportViewer.aspx?option=AutoRolls&SessionID=" + sessionid + "&ClassID=" + ClassID
                + "&SectionID=" + SectionID + "&RollNo=" + roll + "&Status=" + Status;
            string fullURL = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }
        protected void txtRollNo_TextChanged(object sender, EventArgs e)
        {
            ddl_show.SelectedIndex = 0;
            BindGrid(1);
        }

        protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_show.SelectedIndex = 0;
            BindGrid(1);
        }
    }
}