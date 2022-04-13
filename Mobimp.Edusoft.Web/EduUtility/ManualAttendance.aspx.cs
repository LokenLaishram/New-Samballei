using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.BussinessProcess.EduStudent;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Data.EduStudent;
using System.Data;
using System.Reflection;
using System.Configuration;
using ClosedXML.Excel;
using System.IO;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduAdmin;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class ManualAttendance : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindgridfoucs();
            if (!IsPostBack)
            {
                BindDlls();
                lblmessage.Visible = true;
                divsearch.Visible = false;
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentIDs(string prefixText, int count, string contextKey)
        {
            StudentData objSTD = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objSTD.AdmissionNo = prefixText;
            getResult = objempBO.GetStudentID(objSTD);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].AdmissionNo.ToString());
            }
            return list;
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < GvExamAttendance.Rows.Count - 1; i++)
            {
                TextBox curTexbox = GvExamAttendance.Rows[i].Cells[7].FindControl("txtattendance") as TextBox;
                TextBox nexTextbox = GvExamAttendance.Rows[i + 1].Cells[7].FindControl("txtattendance") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = GvExamAttendance.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnUpdate.ClientID + "', event)");
                }
            }
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            Commonfunction.PopulateDdl(ddlExam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            txtTotalWorkingDays.Text = "";
            //BindGrid(1);
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlClass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlExam);
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotalWorkingDays.Text == "" ? "0" : txtTotalWorkingDays.Text) < 1)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter total working days") + "')", true);
                return;
            }

            List<AttendanceData> lstexamdata = new List<AttendanceData>();
            AttendanceData objexam = new AttendanceData();
            ExamTypeBO objexamBO = new ExamTypeBO();
            int index = 0;
            int Chkwdrange = 0;

            try
            {
                //get all the record from the gridview
                foreach (GridViewRow row in GvExamAttendance.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    String SudentID = GvExamAttendance.Rows[index].Cells[0].Text.Trim();
                    Label ClassID = (Label)GvExamAttendance.Rows[index].Cells[0].FindControl("lblclassID");
                    Label SectionID = (Label)GvExamAttendance.Rows[index].Cells[0].FindControl("lblsectionID");
                    String Roll = GvExamAttendance.Rows[index].Cells[4].Text.Trim();
                    TextBox Attendance = (TextBox)GvExamAttendance.Rows[index].Cells[7].FindControl("txtattendance");

                    AttendanceData ObjDetails = new AttendanceData();
                    if (float.Parse(Attendance.Text == "" ? "0.0" : Attendance.Text) > float.Parse(txtTotalWorkingDays.Text == "" ? "0.0" : txtTotalWorkingDays.Text))
                    {
                        Attendance.Focus();
                        Chkwdrange = Chkwdrange + 1;
                    }
                    ObjDetails.StudentID = Convert.ToInt32(SudentID == "" ? "0" : SudentID);
                    ObjDetails.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    ObjDetails.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                    ObjDetails.RollNo = Convert.ToInt32(Roll == "" ? "0" : Roll);
                    ObjDetails.TotalPresent = Convert.ToInt32(Attendance.Text == "" ? "0" : Attendance.Text);
                    ObjDetails.TotalWorkingDays = Convert.ToInt32(txtTotalWorkingDays.Text == "" ? "0" : txtTotalWorkingDays.Text);
                    lstexamdata.Add(ObjDetails);
                    index++;

                }
                objexam.XMLData = XmlConvertor.ClasswiseAttendtoXML(lstexamdata).ToString();
                objexam.ClassID = Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
                objexam.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
                objexam.ExamID = Convert.ToInt32(ddlExam.SelectedValue == "" ? "0" : ddlExam.SelectedValue);
                if (Chkwdrange > 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Entered Attendance are greater than Working Days") + "')", true);
                    return;
                }

                objexam.CompanyID = LoginToken.CompanyID;
                objexam.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue); ;
                int results = objexamBO.Updatestudattendlist(objexam);
                if (results == 1)
                {
                    BindGrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                }
                else
                {
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlClass.SelectedIndex = 0;
            ddlExam.SelectedIndex = 0;
            lblmessage.Visible = false;
            txtTotalWorkingDays.Text = "";
            txtRollNo.Text = "";
            divsearch.Visible = false;
            ddlSectionID.SelectedIndex = 0;
            GvExamAttendance.DataSource = null;
            GvExamAttendance.DataBind();
            GvExamAttendance.Visible = false;
            ViewState["StudentID"] = null;
        }
        private void BindGrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            AttendanceData objExam = new AttendanceData();
            List<AttendanceData> result = GetStudentDetailsList(index, pagesize);
            if (result.Count > 0)
            {
                btnUpdate.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                txtTotalWorkingDays.Text = result[0].TotalWorkingDays.ToString();
                GvExamAttendance.Visible = true;
                GvExamAttendance.PageSize = pagesize;
                string record = result.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result.Count.ToString() + " " + record;
                lbl_totalrecords.Text = result.Count.ToString();
                lblresult.Visible = true;
                GvExamAttendance.VirtualItemCount = result.Count;//total item is required for custom paging
                GvExamAttendance.PageIndex = index - 1;
                GvExamAttendance.DataSource = result;
                GvExamAttendance.DataBind();
                bindresponsive();
                bindgridfoucs();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                GvExamAttendance.DataSource = null;
                GvExamAttendance.DataBind();
                GvExamAttendance.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<AttendanceData> GetStudentDetailsList(int curIndex, int pagesize)
        {
            AttendanceData objexam = new AttendanceData();
            ExamTypeBO objexamBO = new ExamTypeBO();

            objexam.ClassID = Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
            objexam.ExamID = Convert.ToInt32(ddlExam.SelectedValue == "" ? "0" : ddlExam.SelectedValue);
            objexam.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objexam.RollNo = Convert.ToInt32(txtRollNo.Text.Trim() == "" ? "0" : txtRollNo.Text.Trim());
            objexam.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objexam.PageSize = pagesize;
            objexam.CurrentIndex = curIndex;
            return objexamBO.GetstudAttendanceDetails(objexam);
        }
        protected void GvExamAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvExamAttendance.Rows)
            {
                try
                {
                    TextBox AD = (TextBox)GvExamAttendance.Rows[row.RowIndex].Cells[0].FindControl("txtattendance");

                    if (txtTotalWorkingDays.Text.Trim() == "")
                    {
                        AD.Attributes["disabled"] = "disabled";
                    }
                    else
                    {
                        AD.Attributes.Remove("disabled");
                    }
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }
        protected void GvExamAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvExamAttendance.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvExamAttendance_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvExamAttendance.DataSource = sortedView;
                    GvExamAttendance.DataBind();

                    TableCell tableCell = GvExamAttendance.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvExamAttendance.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvExamAttendance.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvExamAttendance.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvExamAttendance.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvExamAttendance.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvExamAttendance.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvExamAttendance.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvExamAttendance.UseAccessibleHeader = true;
                    GvExamAttendance.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void bindresponsive()
        {
            //Responsive 
            GvExamAttendance.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvExamAttendance.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvExamAttendance.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvExamAttendance.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvExamAttendance.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvExamAttendance.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvExamAttendance.UseAccessibleHeader = true;
            GvExamAttendance.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvExamAttendance.HeaderRow.Cells[0];
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
                Response.AddHeader("content-disposition", "attachment;filename=Attendance of " + (ddlExam.SelectedIndex == 0 ? "All" : ddlExam.SelectedItem.Text) + " - " + (ddlAcademicSessionID.SelectedIndex == 0 ? "All" : ddlAcademicSessionID.SelectedItem.Text) + " for Class :" + (ddlClass.SelectedIndex == 0 ? "All" : ddlClass.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            List<AttendanceData> studentdetails = GetStudentDetailsList(1, size);
            List<ExcelManualAttendance> listecelstd = new List<ExcelManualAttendance>();
            int i = 0;
            foreach (AttendanceData row in studentdetails)
            {
                ExcelManualAttendance EcxeclStd = new ExcelManualAttendance();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.Attendance = studentdetails[i].TotalPresent;
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            StudentData objstd = new StudentData();
            AddstudentBO objstdBO = new AddstudentBO();
            objstd.StudentID = 0;
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            List<StudentData> stdetails = objstdBO.GetstudentDetailByID(objstd);
            if (stdetails.Count > 0)
            {
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                Commonfunction.PopulateDdl(ddlExam, objmstlookupBO.GetExamTypeByClassID(Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                txtTotalWorkingDays.Text = "";
                ddlClass.SelectedValue = Convert.ToString(stdetails[0].ClassID);
            }
            else
            {
                ddlClass.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Student is not found.") + "')", true);
                return;
            }
        }

        protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
    }
}