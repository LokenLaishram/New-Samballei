using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduExamination
{
    public partial class PromoteStudent : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
                divsearch.Visible = false;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicseesions, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicseesions.SelectedIndex = 1;
            Commonfunction.Insertzeroitemindex(ddlsections);
        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlsections, objmstlookupBO.GetSectionByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
            //Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
            lblmessage.Visible = false;
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<Examdata> lstclass = getStudentdetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                divsearch.Visible = true;
                GvExamdetails.PageSize = pagesize;
                string record = lstclass.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass.Count.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass.Count.ToString(); ;
                lblresult.Visible = true;
                GvExamdetails.Visible = true;
                GvExamdetails.VirtualItemCount = lstclass.Count;//total item is required for custom paging
                GvExamdetails.PageIndex = index - 1;
                GvExamdetails.DataSource = lstclass;
                GvExamdetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvExamdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                ViewState["StudentID"] = lstclass[0].StudentID.ToString();
                btnupdate.Visible = true;
            }
            else
            {
                ViewState["StudentID"] = null;
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
                GvExamdetails.Visible = true;
                btnupdate.Visible = false;
            }
        }
        public List<Examdata> getStudentdetails(int curIndex, int pagesize)
        {
            Examdata objexam = new Examdata();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objexam.RollNo = Convert.ToInt32(txtrollNo.Text == "" ? "0" : txtrollNo.Text);
            objexam.Status = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
            objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
            objexam.PageSize = pagesize;
            objexam.CurrentIndex = curIndex;
            return objexamBO.GetPromoteStudent(objexam);
        }
        protected void chekboxall_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)GvExamdetails.HeaderRow.FindControl("chekboxall");
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                CheckBox checkrow = (CheckBox)row.FindControl("chekboxselect");
                if (chckheader.Checked == true)
                {
                    checkrow.Checked = true;
                }
                else
                {
                    // checkrow.Checked = false;
                    bindgrid(1);
                }
            }
        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {
                    Label Status = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblstatus");
                    TextBox Rank = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("txtrank");
                    CheckBox ChkStudent = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
                    Label IsPromoted = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblPromoted");

                    Label lblPromoteToClass = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblPromoteClass");
                    DropDownList ddlPromoteToClass = (DropDownList)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("ddlPromoteClass");
                    Label lblPromoteAcademicID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblPromoteAcademicID");

                    MasterLookupBO mstlookup = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlPromoteToClass, mstlookup.GetLookupsList(LookupNames.Class));
                    ddlPromoteToClass.Items.FindByValue(lblPromoteToClass.Text).Selected = true;

                    if (IsPromoted.Text == "1")
                    {
                        IsPromoted.CssClass = "indicator";
                        Rank.Enabled = false;
                        ChkStudent.Checked = true;
                        ChkStudent.Enabled = false;
                    }
                    else
                    {
                        // IsPromoted.CssClass = "indicator2";
                        Status.CssClass = "indicator2";
                        Rank.Enabled = false;
                        ChkStudent.Checked = false;
                        ChkStudent.Enabled = true;
                    }
                }

                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlclasses.SelectedIndex = 0;
            //ddlexam.SelectedIndex = 0;
            lblmessage.Visible = false;
            btnupdate.Visible = false;
            txtrollNo.Text = "";
            ddlsections.SelectedIndex = 0;
            ViewState["StudentID"] = null;
            ddlstatus.SelectedIndex = 1;
            Commonfunction.Insertzeroitemindex(ddlsections);
            GvExamdetails.DataSource = null;
            GvExamdetails.DataBind();
            GvExamdetails.Visible = false;
            divsearch.Visible = false;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<PromoteSrudent> lstexamdata = new List<PromoteSrudent>();
            PromoteSrudent objexam = new PromoteSrudent();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label SudentID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblstudentID");
                    CheckBox ChkStudent = (CheckBox)GvExamdetails.Rows[index].Cells[0].FindControl("chekboxselect");
                    DropDownList ddlPromoteToClass = (DropDownList)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("ddlPromoteClass");
                    Label ddlPromoteAcademicID = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblPromoteAcademicID");
                    PromoteSrudent ObjDetails = new PromoteSrudent();
                    if (ChkStudent.Checked)
                    {
                        ObjDetails.StudentID = Convert.ToInt32(SudentID.Text == "" ? "0" : SudentID.Text);
                        ObjDetails.IsPass = true;
                        ObjDetails.PromoteClassID = Convert.ToInt32(ddlPromoteToClass.SelectedValue == "" ? "0" : ddlPromoteToClass.SelectedValue);
                        ObjDetails.PromoteAcademicID = Convert.ToInt32(ddlPromoteAcademicID.Text == "" ? "0" : ddlPromoteAcademicID.Text);
                    }
                    else
                    {
                        ObjDetails.IsPass = false;
                    }
                    lstexamdata.Add(ObjDetails);
                    index++;
                }
                objexam.xmlpromotestudentlist = XmlConvertor.PromotedStudentlistToXML(lstexamdata).ToString();
                objexam.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
                objexam.CompanyID = LoginToken.CompanyID;
                objexam.AcademicSessionID = Convert.ToInt32(ddlacademicseesions.SelectedValue == "" ? "0" : ddlacademicseesions.SelectedValue);
                int results = objexamBO.PromoteStudent(objexam);
                if (results == 1)
                {
                    bindgrid(1);
                    ViewState["StudentID"] = null;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void bindresponsive()
        {
            //Responsive 
            GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamdetails.UseAccessibleHeader = true;
            GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvExamdetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExamdetails.DataSource = sortedView;
                    GvExamdetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvExamdetails.HeaderRow.Cells[ColumnIndex];
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

        protected void GvExamdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvExamdetails.PageIndex = e.NewPageIndex;
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
                wb.Worksheets.Add(dt, "Class List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class.xlsx");
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
            List<PrintresulttoExcel> classtoexcel = new List<PrintresulttoExcel>();
            int i = 0;
            foreach (Examdata row in ClassDetail)
            {
                PrintresulttoExcel EcxeclStd = new PrintresulttoExcel();
                //EcxeclStd.Code = ClassDetail[i].Code;
                //EcxeclStd.Class = ClassDetail[i].Descriptions;
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
        protected void ddlsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}