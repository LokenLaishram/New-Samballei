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

namespace Mobimp.Edusoft.Web.EduStudent
{
    public partial class Attendance : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btnsearch]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                divsearch.Visible = false;
                divsearchTab2.Visible = false;
                Ddls();
                GetDatedetails();
            }
        }

        protected void Ddls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();

            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlAcademicSessionTab2, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionTab2.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlClass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlClassTab2, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlSectionTab2);

        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStdNames(string prefixText, int count, string contextKey)
        {
            StudentData objemp = new StudentData();
            AddstudentBO objempBO = new AddstudentBO();
            List<StudentData> getResult = new List<StudentData>();
            objemp.StudentName = prefixText;
            getResult = objempBO.GetStudentNames(objemp);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentName.ToString());
            }
            return list;
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
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void BindGrid(int index)
        {
            int pagesize = Convert.ToInt32(ddlshow.SelectedValue == "10000" ? lbl_totalrecords.Text : ddlshow.SelectedValue);
            StudentAttendance objExam = new StudentAttendance();
            List<StudentAttendance> result = GetStudentAttendanceDetails(index, pagesize);
            if (result.Count > 0)
            {
                //btnUpdate.Visible = true;
                btnUpdate.Attributes.Remove("disabled");
                //txtTotalWorkingDays.Text = result[0].TotalWorkingDay.ToString();
                GvAttendance.Visible = true;
                GvAttendance.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                lblPresent.Text = result[0].Present.ToString();
                lblAbsent.Text = result[0].Absents.ToString();
                lblLeave.Text = result[0].Leave.ToString();
                GvAttendance.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvAttendance.PageIndex = index - 1;
                GvAttendance.DataSource = result;
                GvAttendance.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                //ViewState["StudentID"] = null;
                GvAttendance.DataSource = null;
                GvAttendance.DataBind();
                GvAttendance.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }

        public List<StudentAttendance> GetStudentAttendanceDetails(int curIndex, int pagesize)
        {
            StudentAttendance objstd = new StudentAttendance();
            AddstudentBO objstdBO = new AddstudentBO();

            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objstd.ClassID = Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
            objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objstd.RollNo = Convert.ToInt32(txtRollNo.Text == "" ? "0" : txtRollNo.Text);
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtAttendanceDay.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtAttendanceDay.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objstd.AttendanceDate = from;
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;

            return objstdBO.Getclasswisesattendancetudentlist(objstd);
        }

        protected void GvAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvAttendance.Rows)
            {
                try
                {
                    Label AttenedanceID = (Label)GvAttendance.Rows[row.RowIndex].Cells[0].FindControl("lblattendanceID");
                    DropDownList ddlattendance = (DropDownList)GvAttendance.Rows[row.RowIndex].Cells[6].FindControl("ddlattendance");
                    if (AttenedanceID.Text != "0")
                    {
                        ddlattendance.Items.FindByValue(AttenedanceID.Text).Selected = true;
                    }
                    //ddlattendance.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    lblresult.Text = ExceptionMessage.GetMessage(ex);
                }
            }
        }

        protected void GetDatedetails()
        {
            GetTodaysDateDetails objstd = new GetTodaysDateDetails();
            AddstudentBO objstdBO = new AddstudentBO();
            //List<GetTodaysDateDetails> result = objstdBO.GetdateDetails(objstd);
            //if (result.Count > 0)
            //{
            //result[0].DaysName.ToString() + ", " +
            //DateTime.Now.DayOfWeek.ToString() + ", " + 
            txtAttendanceDay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //result[0].TodayDate.ToString("dd/MM/yyyy");
            //}result[0].DaysName.ToString() + ", " +
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            ddlClass.SelectedIndex = 0;
            ddlSectionID.SelectedIndex = 0;
            txtRollNo.Text = "";
            GvAttendance.DataSource = null;
            GvAttendance.DataBind();
            GvAttendance.Visible = false;
            lblPresent.Text = "0";
            lblAbsent.Text = "0";
            lblLeave.Text = "0";
            lblresult.Visible = false;
            lblmessage.Visible = false;
            divsearch.Visible = false;
            Commonfunction.Insertzeroitemindex(ddlSectionID);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<StudentAttendance> lstattendance = new List<StudentAttendance>();
            StudentAttendance objstd = new StudentAttendance();
            AddstudentBO objstdBO = new AddstudentBO();
            int index = 0;
            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvAttendance.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);

                    String StudentID = GvAttendance.Rows[index].Cells[0].Text.Trim();
                    String StudentName = GvAttendance.Rows[index].Cells[1].Text.Trim();
                    String ClassName = GvAttendance.Rows[index].Cells[2].Text.Trim();
                    String SectionName = GvAttendance.Rows[index].Cells[3].Text.Trim();
                    String RollNo = GvAttendance.Rows[index].Cells[4].Text.Trim();
                    Label lblClassID = (Label)GvAttendance.Rows[index].Cells[5].FindControl("lblclassID");
                    Label lblSectionID = (Label)GvAttendance.Rows[index].Cells[6].FindControl("lblsectionID");
                    Label CategoryID = (Label)GvAttendance.Rows[index].Cells[7].FindControl("lblCategoryID");
                    Label AttendanceID = (Label)GvAttendance.Rows[index].Cells[8].FindControl("lblattendanceID");
                    DropDownList ddlAttendanceID = (DropDownList)GvAttendance.Rows[index].Cells[8].FindControl("ddlattendance");
                    TextBox txtRemarks = (TextBox)GvAttendance.Rows[index].Cells[9].FindControl("txtRemarks");

                    StudentAttendance ObjDetails = new StudentAttendance();

                    ObjDetails.StudentID = Convert.ToInt32(StudentID == "" ? "0" : StudentID);
                    ObjDetails.AdmissionID = Convert.ToInt32(StudentID == "" ? "0" : StudentID);
                    ObjDetails.ClassID = Convert.ToInt32(lblClassID.Text == "" ? "0" : lblClassID.Text);
                    ObjDetails.SectionID = Convert.ToInt32(lblSectionID.Text == "" ? "0" : lblSectionID.Text);
                    ObjDetails.Remarks = txtRemarks.Text.Trim();
                    ObjDetails.RollNo = Convert.ToInt32(RollNo == "" ? "0" : RollNo);
                    ObjDetails.StudentCategoryID = Convert.ToInt32(CategoryID.Text == "" ? "0" : CategoryID.Text);
                    ObjDetails.AttendanceID = Convert.ToInt32(ddlAttendanceID.SelectedValue == "" ? "0" : ddlAttendanceID.SelectedValue);
                    ObjDetails.AddedBy = LoginToken.LoginId;
                    ObjDetails.UserloginID = LoginToken.UserLoginId;
                    ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                    lstattendance.Add(ObjDetails);
                    index++;

                }
                objstd.XmlStudenAttendancelist = XmlConvertor.AttendancelisttoXML(lstattendance).ToString();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime from = txtAttendanceDay.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtAttendanceDay.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objstd.AttendanceDate = from;
                objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                objstd.ClassID = Convert.ToInt32(ddlClass.SelectedValue == "" ? "0" : ddlClass.SelectedValue);
                objstd.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
                //objstd.StudentCategoryID = Convert.ToInt32(ddlcategorys.SelectedValue == "" ? "0" : ddlcategorys.SelectedValue);
                int results = objstdBO.UpdateStudentAttenedance(objstd);
                if (results == 1 || results == 2)
                {
                    BindGrid(1);
                    btnUpdate.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(results == 1 ? "save" : "update") + "')", true);
                }
                //else if (results == 5)
                //{
                //    Messagealert_.ShowMessage(lblmesagestudentlist, "Already done today's attendance  for this class.", 0);
                //}
                else
                {
                    btnUpdate.Attributes.Remove("disabled");
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

        protected void bindresponsive()
        {
            //Responsive 
            GvAttendance.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvAttendance.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvAttendance.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAttendance.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvAttendance.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAttendance.UseAccessibleHeader = true;
            GvAttendance.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvAttendance.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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

        protected void GvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendance.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvAttendance_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvAttendance.DataSource = sortedView;
                    GvAttendance.DataBind();

                    TableCell tableCell = GvAttendance.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvAttendance.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvAttendance.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvAttendance.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvAttendance.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvAttendance.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvAttendance.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvAttendance.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvAttendance.UseAccessibleHeader = true;
                    GvAttendance.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void ddlshow_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
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
                Response.AddHeader("content-disposition", "attachment;filename=Attendance of " + (txtAttendanceDay.Text.Trim()) + " for Class : " + (ddlClass.SelectedIndex == 0 ? "All" : ddlClass.SelectedItem.Text) + " Section : " + (ddlSectionID.SelectedIndex == 0 ? "" : ddlSectionID.SelectedItem.Text) + ".xlsx");
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
            int size = Convert.ToInt32(ddlshow.SelectedValue == "10000" ? lbl_totalrecords.Text : ddlshow.SelectedValue);
            List<StudentAttendance> studentdetails = GetStudentAttendanceDetails(1, size);
            List<ExcelParticularDayAttendance> listecelstd = new List<ExcelParticularDayAttendance>();
            int i = 0;
            foreach (StudentAttendance row in studentdetails)
            {
                ExcelParticularDayAttendance EcxeclStd = new ExcelParticularDayAttendance();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.Category = studentdetails[i].CategoryName;
                EcxeclStd.Gender = studentdetails[i].SexName;
                EcxeclStd.Date = studentdetails[i].AttendanceDate.ToString("dd/MM/yyyy");
                EcxeclStd.Attendance = studentdetails[i].Attendance;
                EcxeclStd.Remarks = studentdetails[i].Remarks;
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

        ///////////////////////////////// TAB 2 /////////////////////////////////////

        protected void ddlClassTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSectionTab2, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassTab2.SelectedValue == "" ? "0" : ddlClassTab2.SelectedValue), Convert.ToInt32(ddlAcademicSessionTab2.SelectedValue == "" ? "0" : ddlAcademicSessionTab2.SelectedValue)));
        }
        protected void btnSearchTab2_Click(object sender, EventArgs e)
        {
            BindGridTab2(1);
        }

        protected void BindGridTab2(int index)
        {
            int pagesize = Convert.ToInt32(ddlShowTab2.SelectedValue == "10000" ? lbl_totalrecordsTab2.Text : ddlShowTab2.SelectedValue);
            StudentAttendance objExam = new StudentAttendance();
            List<StudentAttendance> result = GetStudentAttendanceList(index, pagesize);
            if (result.Count > 0)
            {
                GvAttendanceTab2.Visible = true;
                GvAttendanceTab2.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresultTab2.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecordsTab2.Text = result[0].MaximumRows.ToString();
                lblresultTab2.Visible = true;
                lblTotalWD.Text = result[0].WorkingDays.ToString();
                lblTotalPre.Text = result[0].PresentDays.ToString();
                lblTotalAb.Text = result[0].NoAbsentDays.ToString();
                lblTotalLeave.Text = result[0].NoLeaveDays.ToString();
                GvAttendanceTab2.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                GvAttendanceTab2.PageIndex = index - 1;
                GvAttendanceTab2.DataSource = result;
                GvAttendanceTab2.DataBind();
                bindresponsiveTab2();
                ds = ConvertToDataSet(result);
                divsearchTab2.Visible = true;
            }
            else
            {
                GvAttendanceTab2.DataSource = null;
                GvAttendanceTab2.DataBind();
                GvAttendanceTab2.Visible = true;
                lblTotalWD.Text = "0";
                lblTotalPre.Text = "0";
                lblTotalAb.Text = "0";
                lblTotalLeave.Text = "0";
                lblresult.Visible = false;
                divsearch.Visible = true;
                //string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                //lblresultTab2.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                //lbl_totalrecordsTab2.Text = result[0].MaximumRows.ToString();
                //lblresultTab2.Visible = true;
                //lblmessages.CssClass = "Message";
                //lblmessages.Visible = true;
            }
        }

        public List<StudentAttendance> GetStudentAttendanceList(int curIndex, int pagesize)
        {
            StudentAttendance objstdAtd = new StudentAttendance();
            AddstudentBO objstdBO = new AddstudentBO();

            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            objstdAtd.Datefrom = from;
            objstdAtd.Dateto = To;
            objstdAtd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionTab2.SelectedValue == "" ? "0" : ddlAcademicSessionTab2.SelectedValue);
            objstdAtd.ClassID = Convert.ToInt32(ddlClassTab2.SelectedValue == "" ? "0" : ddlClassTab2.SelectedValue);
            objstdAtd.SectionID = Convert.ToInt32(ddlSectionTab2.SelectedValue == "" ? "0" : ddlSectionTab2.SelectedValue);
            objstdAtd.RollNo = Convert.ToInt32(txtRollNoTab2.Text == "" ? "0" : txtRollNoTab2.Text);
            objstdAtd.PageSize = pagesize;
            objstdAtd.CurrentIndex = curIndex;

            return objstdBO.Getclasswisesattendancelist(objstdAtd);
        }

        protected void btnResetTab2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        protected void ClearAll()
        {
            ddlSectionTab2.SelectedIndex = 0;
            ddlClassTab2.SelectedIndex = 0;
            txtRollNoTab2.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            GvAttendanceTab2.DataSource = null;
            GvAttendanceTab2.DataBind();
            GvAttendanceTab2.Visible = false;
            lblresult.Visible = false;
            lblresultTab2.Visible = false;
            //btnUpdate.Enabled = false;
            lblTotalWD.Text = "0";
            lblTotalPre.Text = "0";
            lblTotalAb.Text = "0";
            lblTotalLeave.Text = "0";
            divsearchTab2.Visible = false;
            Commonfunction.Insertzeroitemindex(ddlSectionTab2);
        }

        protected void bindresponsiveTab2()
        {
            //Responsive 
            GvAttendanceTab2.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvAttendanceTab2.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //GvAttendanceTab2.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAttendanceTab2.UseAccessibleHeader = true;
            GvAttendanceTab2.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvAttendanceTab2.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }

        protected void ddlShowTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridTab2(1);
        }

        protected void btnexportTab2_Click(object sender, EventArgs e)
        {
            ExportoExcelTab2();
        }

        protected void ExportoExcelTab2()
        {
            DataTable dt = GetDatafromDatabaseTab2();
            using (XLWorkbook wb = new XLWorkbook())
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime from = txtFrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtFrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                DateTime To = txtTo.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtTo.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                string dateFrom = from.ToString("dd-MM-yyyy");
                string dateTo = To.ToString("dd-MM-yyyy");

                wb.Worksheets.Add(dt, "Student List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=AttendanceDetails of Class : " + (ddlClassTab2.SelectedIndex == 0 ? "All" : ddlClassTab2.SelectedItem.Text) + " Section : " + (ddlSectionTab2.SelectedIndex == 0 ? "" : ddlSectionTab2.SelectedItem.Text) + " from " + (dateFrom.Trim()) + " to " + (dateTo.Trim()) + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected DataTable GetDatafromDatabaseTab2()
        {
            int size = Convert.ToInt32(ddlShowTab2.SelectedValue == "10000" ? lbl_totalrecordsTab2.Text : ddlShowTab2.SelectedValue);
            List<StudentAttendance> studentdetails = GetStudentAttendanceList(1, size);
            List<ExcelAttendanceDetailsList> listecelstd = new List<ExcelAttendanceDetailsList>();
            int i = 0;
            foreach (StudentAttendance row in studentdetails)
            {
                ExcelAttendanceDetailsList EcxeclStd = new ExcelAttendanceDetailsList();
                EcxeclStd.StudentID = studentdetails[i].StudentID;
                EcxeclStd.StudentName = studentdetails[i].StudentName;
                EcxeclStd.Category = studentdetails[i].CategoryName;
                EcxeclStd.Gender = studentdetails[i].SexName;
                EcxeclStd.Class = studentdetails[i].ClassName;
                EcxeclStd.Section = studentdetails[i].SectionName;
                EcxeclStd.RollNo = studentdetails[i].RollNo;
                EcxeclStd.Attendance = studentdetails[i].Attendance;
                EcxeclStd.Date = studentdetails[i].AddedDate.ToString("dd/MM/yyyy");
                EcxeclStd.Day = studentdetails[i].DaysName;
                EcxeclStd.Remarks = studentdetails[i].Remarks;
                listecelstd.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(listecelstd);
            return dt;
        }

        protected void GvAttendanceTab2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendanceTab2.PageIndex = e.NewPageIndex;
            BindGridTab2(Convert.ToInt32(e.NewPageIndex + 1));
        }

        protected void GvAttendanceTab2_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvAttendanceTab2.DataSource = sortedView;
                    GvAttendanceTab2.DataBind();

                    TableCell tableCell = GvAttendanceTab2.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    GvAttendanceTab2.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvAttendanceTab2.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    GvAttendanceTab2.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    GvAttendanceTab2.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    GvAttendanceTab2.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    GvAttendanceTab2.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
                    GvAttendanceTab2.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    GvAttendanceTab2.UseAccessibleHeader = true;
                    GvAttendanceTab2.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

    }
}