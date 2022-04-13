using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.BussinessProcess.EduExam;
using System.Data;
using System.Reflection;
using ClosedXML.Excel;
using System.IO;

namespace Mobimp.Campusoft.Web.EduExamination
{
    public partial class SubjectMarkRange : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
           // Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlsubject, objmstlookupBO.GetSubjectByClassIDCatgeoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            if (ddlclasses.SelectedIndex > 0)
            {
                ddlsections.SelectedIndex = 0;
            }
            else
            {
                ddlsections.SelectedIndex = 0;
                ddlexam.SelectedIndex = 0;
                ddlsubject.SelectedIndex = 0;
            }
        }
        protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassIDAcademicID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue), Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue)));
            if (ddlsections.SelectedIndex > 0)
            {
                ddlexam.SelectedIndex = 0;
            }
            else
            {
                ddlexam.SelectedIndex = 0;
                ddlsubject.SelectedIndex = 0;
            }
        }
  
        protected void ddlexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsubject, objmstlookupBO.GetSubjectByClassIDCatgeoryID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            if (ddlexam.SelectedIndex > 0)
            {
                ddlsubject.SelectedIndex = 0;
            }
            else
            {
                ddlsubject.SelectedIndex = 0;
            }
        }
        protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubject.SelectedIndex > 0)
            {
                //GvMarklist.Visible = true;
                //bindgrid();
            }
            else
            {
                //GvMarklist.Visible = false;
            }
        }

        protected void GvMarklist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvMarklist.Rows)
            {
                try
                {
                    Label ID = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label StudentName = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblname");
                    Label ClassName = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblclass");
                    Label RollNo = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblroll");
                    Label SectionName = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblsec");
                    Label SubjectName = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblsubname");
                    Label SecureMark = (Label)GvMarklist.Rows[row.RowIndex].Cells[0].FindControl("lblsecure");
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Examdata> marklist = getStudentdetails(index, pagesize);
            if (marklist.Count > 0)
            {
                GvMarklist.PageSize = pagesize;
                string record = marklist[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + marklist[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = marklist[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvMarklist.VirtualItemCount = marklist[0].MaximumRows;//total item is required for custom paging
                GvMarklist.PageIndex = index - 1;
                GvMarklist.DataSource = marklist;
                GvMarklist.DataBind();
                ds = ConvertToDataSet(marklist);
                TableCell tableCell = GvMarklist.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                ViewState["StudentID"] = marklist[0].StudentID.ToString();
            }
            else
            {
                ViewState["StudentID"] = null;
                GvMarklist.DataSource = null;
                GvMarklist.DataBind();
                GvMarklist.Visible = true;
            }
        }
        public List<Examdata> getStudentdetails(int curIndex, int pagesize)
        {
            Examdata objexam = new Examdata();
            SubjectMarkRangeBO objexamBO = new SubjectMarkRangeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SubjectID = Convert.ToInt32(ddlsubject.SelectedValue == "" ? "0" : ddlsubject.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.From = Convert.ToInt32(txtfrom.Text == "" ? "0" : txtfrom.Text);
            objexam.To = Convert.ToInt32(txtto.Text == "" ? "0" : txtto.Text);
            return objexamBO.GetMarkList(objexam);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            ddlacademicseesions.SelectedIndex = 0;
            lblmessage.Visible = false;
            GvMarklist.DataSource = null;
            GvMarklist.DataBind();
            txtrollNo.Text = "";
            ddlsections.SelectedIndex = 0;
            ddlexam.SelectedIndex = 0;
            ddlsubject.SelectedIndex = 0;
            txtfrom.Text = "";
            txtto.Text = "";            
        }

        ///////////////
        protected void bindresponsive()
        {
            //Responsive 
            GvMarklist.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvMarklist.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvMarklist.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvMarklist.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvMarklist.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvMarklist.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvMarklist.UseAccessibleHeader = true;
            GvMarklist.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void GvMarklist_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvMarklist.DataSource = sortedView;
                    GvMarklist.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvMarklist.HeaderRow.Cells[ColumnIndex];
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
        ///////////////
        protected void GvMarklist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvMarklist.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
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
                wb.Worksheets.Add(dt, "mark List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Marklist.xlsx");
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
            List<Examdata> ClassDetail = getStudentdetails(1, size);
            List<SubjectMarkRangetoExcel> classtoexcel = new List<SubjectMarkRangetoExcel>();
            int i = 0;
            foreach (Examdata row in ClassDetail)
            {
                SubjectMarkRangetoExcel EcxeclStd = new SubjectMarkRangetoExcel();
                EcxeclStd.Section = ClassDetail[i].SectionName;
                EcxeclStd.RollNo = ClassDetail[i].RollNo;
                EcxeclStd.StudentName = ClassDetail[i].StudentName;
                EcxeclStd.SubjectName = ClassDetail[i].subjName;
                EcxeclStd.SecuredMark = ClassDetail[i].TotalSmark;
                classtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(classtoexcel);
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
    }
}