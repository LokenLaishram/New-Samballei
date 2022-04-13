using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using ClosedXML.Excel;
using System.Reflection;
using System.IO;

namespace Mobimp.Campusoft.Web.EduUtility
{
    public partial class Examverifcation : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
                divsearch.Visible = false;
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclasses, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddlexam, mstlookup.GetLookupsList(LookupNames.ExamNames));
            ddlacademicsession.SelectedIndex = 1;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ExamTypeData> lstexam = GetExamTypedetails(pagesize,index);
            if (lstexam.Count > 0)
            {
                GvExamdetails.PageSize = pagesize;
                string record = lstexam[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstexam[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstexam[0].MaximumRows.ToString();
               // lbltotalmark.Text = lstexam[0].FullMark.ToString();
                //lblpassmark.Text = lstexam[0].PassMark.ToString();
                //lblresult.Visible = true;
                GvExamdetails.VirtualItemCount = lstexam[0].MaximumRows;//total item is required for custom paging
                GvExamdetails.PageIndex = index - 1;
                GvExamdetails.DataSource = lstexam;
                GvExamdetails.DataBind();
                btnupdate.Attributes.Remove("disabled");
                divsearch.Visible = false;
                bindresponsive();
                ds = ConvertToDataSet(lstexam);
                btnupdate.Visible = true;
            }
            else
            {
                GvExamdetails.DataSource = null;
                GvExamdetails.DataBind();
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
            GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvExamdetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvExamdetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //GvExamdetails.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamdetails.UseAccessibleHeader = true;
            GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvExamdetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        public List<ExamTypeData> GetExamTypedetails(int pagesize,int curIndex)
        {
            ExamTypeData objexamtype = new ExamTypeData();
            ExamTypeBO objobjexamtype = new ExamTypeBO();
            objexamtype.ExamID = Convert.ToInt32(ddlexam.SelectedValue == "" ? "0" : ddlexam.SelectedValue);
            objexamtype.ActionType = EnumActionType.Select;
            objexamtype.ClassID = Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue);
            objexamtype.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            objexamtype.PageSize = pagesize;
            objexamtype.CurrentIndex = curIndex;
            return objobjexamtype.Getyearwiseexamlist(objexamtype);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EduUtility/Examverifcation.aspx");
        }
        protected void GvExamdetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            //Commonfunction.PopulateDdl(ddlexam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlclasses.SelectedValue == "" ? "0" : ddlclasses.SelectedValue)));
        }
        protected void GvExamdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamdetails.Rows)
            {
                try
                {
                    Label lblchkstudent = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkstudent");
                    Label lblchksubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchksubject");
                    Label lblchkaltsubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkaltsubject");
                    Label lblchkoptsubject = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkoptional");
                    Label lblchkmark = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmark");
                    Label lblchkmark1 = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmark1");
                    Label lblchkmarkentry = (Label)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblchkmarkentry");

                    CheckBox chkstudent = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkstd");
                    CheckBox chksubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chksubject");
                    CheckBox chkaltsubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkaltsubject");
                    CheckBox chkoptsubject = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkoptsubject");
                    CheckBox chkmark = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmark");
                    CheckBox chkmark1 = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmark1");
                    CheckBox chkmarkentry = (CheckBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("chkmarkentry");

                    TextBox lblnostudent = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblnostudent");
                    TextBox lblnosubject = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblnosubject");
                    TextBox lblalt = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblalt");
                    TextBox lblopt = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblopt");
                    TextBox lblfm = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblfm");
                    TextBox lblpm = (TextBox)GvExamdetails.Rows[row.RowIndex].Cells[0].FindControl("lblpm");

                    lblnostudent.Attributes["disabled"] = "disabled";
                    lblnosubject.Attributes["disabled"] = "disabled";
                    lblalt.Attributes["disabled"] = "disabled";
                    lblopt.Attributes["disabled"] = "disabled";
                    lblfm.Attributes["disabled"] = "disabled";
                    lblpm.Attributes["disabled"] = "disabled";

                    if (lblchkstudent.Text == "1")
                    {
                        chkstudent.Checked = true;
                    }
                    else
                    {
                        chkstudent.Checked = false;
                    }
                    if (lblchksubject.Text == "1")
                    {
                        chksubject.Checked = true;
                    }
                    else
                    {
                        chksubject.Checked = false;
                    }
                    if (lblchkaltsubject.Text == "1")
                    {
                        chkaltsubject.Checked = true;
                    }
                    else
                    {
                        chkaltsubject.Checked = false;
                    }
                    if (lblchkoptsubject.Text == "1")
                    {
                        chkoptsubject.Checked = true;
                    }
                    else
                    {
                        chkoptsubject.Checked = false;
                    }
                    if (lblchkmark.Text == "1")
                    {
                        chkmark.Checked = true;
                    }
                    else
                    {
                        chkmark.Checked = false;
                    }
                    if (lblchkmark1.Text == "1")
                    {
                        chkmark1.Checked = true;
                    }
                    else
                    {
                        chkmark1.Checked = false;
                    }
                    if (lblchkmarkentry.Text == "1")
                    {
                        chkmarkentry.Checked = true;
                    }
                    else
                    {
                        chkmarkentry.Checked = false;
                    }

                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }
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
                wb.Worksheets.Add(dt, "ExamVerification List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= ExamVerification.xlsx");
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
            List<ExamTypeData> ExamDetail = GetExamTypedetails(1, size);
            List<ExamVerificationDatatoExcel> examtoexcel = new List<ExamVerificationDatatoExcel>();
            int i = 0;
            foreach (ExamTypeData row in ExamDetail)
            {
                ExamVerificationDatatoExcel EcxeclStd = new ExamVerificationDatatoExcel();
                EcxeclStd.ExamName = ExamDetail[i].ExamName;
                EcxeclStd.ClassName = ExamDetail[i].ClassName;
                EcxeclStd.TotalStudents = Convert.ToString(ExamDetail[i].NoOfStudent);
                EcxeclStd.TotalSubjects = Convert.ToString(ExamDetail[i].NoOfSubject);
                EcxeclStd.AltStudentSubject = Convert.ToString(ExamDetail[i].NoOfAlt);
                EcxeclStd.OptStudentSubject = Convert.ToString(ExamDetail[i].NoOfOpt);
                EcxeclStd.TotalFullMark = Convert.ToInt32(ExamDetail[i].TotalMark);
                EcxeclStd.TotalPassMark = Convert.ToInt32(ExamDetail[i].TotalPassMark);
                examtoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(examtoexcel);
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
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<ExamTypeData> lstmarks = new List<ExamTypeData>();
            ExamTypeData objstd = new ExamTypeData();
            ExamTypeBO objstdBO = new ExamTypeBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvExamdetails.Rows)
                {

                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    String ID =GvExamdetails.Rows[index].Cells[0].Text;
                    Label ClassID = (Label)GvExamdetails.Rows[index].Cells[0].FindControl("lblclassID");

                    CheckBox chkstudents = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkstd");
                    CheckBox chksubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chksubject");
                    CheckBox chkaltsubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkaltsubject");
                    CheckBox chkoptsubjects = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkoptsubject");
                    CheckBox chkmarks = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkmark");
                    CheckBox chkmarkentrys = (CheckBox)GvExamdetails.Rows[index].Cells[1].FindControl("chkmarkentry");

                    ExamTypeData ObjDetails = new ExamTypeData();
                    ObjDetails.ID = Convert.ToInt32(ID);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.chkstudent = chkstudents.Checked ? 1 : 0;
                    ObjDetails.chksubject = chksubjects.Checked ? 1 : 0;
                    ObjDetails.chkaltsubject = chkaltsubjects.Checked ? 1 : 0;
                    ObjDetails.chkoptsubject = chkoptsubjects.Checked ? 1 : 0;
                    ObjDetails.chkmark = chkmarks.Checked ? 1 : 0;
                    ObjDetails.chkmarkentry = chkmarkentrys.Checked ? 1 : 0;

                    lstmarks.Add(ObjDetails);
                    index++;
                }
                objstd.XmlMarksdetaillist = XmlConvertor.ProcessVerificationtoXML(lstmarks).ToString();
                int results = objstdBO.ProcessVerification(objstd);
                if (results == 1)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                    btnupdate.Attributes["disabled"] = "disabled";
                }
                else
                {
                    btnupdate.Attributes.Remove("disabled");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Error") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvExamdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvExamdetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
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

                    TableCell tableCell = GvExamdetails.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvExamdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvExamdetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvExamdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvExamdetails.UseAccessibleHeader = true;
                    GvExamdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
    }
}