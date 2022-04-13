using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.ELearning;
using Mobimp.Edusoft.BussinessProcess.ELearning;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.TeacherPortal.ELearning
{
    public partial class DailyTeacherLiveClassList : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTeacherName.Attributes["disabled"] = "disabled";
                ViewState["TeacherID"] = null;
                lblmessage.Visible = true;
                BindDdls();
                bindgrid(1);
                divMain.Visible = true;
            }
        }
        protected void BindDdls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlDayID, mstlookup.GetLookupsList(LookupNames.WeekDays));

            if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0)
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
            }
            txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            Int64 UserLoginID = LoginToken.UserLoginId;
            List<ELearningData> Result = GetLoginNamebyUserLoginID(UserLoginID);
            if (Result.Count > 0)
            {
                txtTeacherName.Text = Result[0].TeacherName.ToString();
                ViewState["TeacherID"] = Result[0].TeacherID.ToString();
            }
            else
            {
                ClearAll();
            }
        }
        private List<ELearningData> GetLoginNamebyUserLoginID(Int64 ID) 
        {
            ELearningBO objEmpBO = new ELearningBO();
            return objEmpBO.SearchTeacherNamebyUserLoginID(ID);
        }
        protected void ddlDayID_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            int DayOfTheWeekID = Convert.ToInt32(strClassDate.DayOfWeek);

            int CurrentMonth = Convert.ToInt32(DateTime.Now.Month);
            int CurrentYear = Convert.ToInt32(DateTime.Now.Year);
            int SelectedMonth = Convert.ToInt32(strClassDate.AddDays(Convert.ToInt32(ddlDayID.SelectedValue)).Month);
            int SelectedYear = Convert.ToInt32(strClassDate.AddDays(Convert.ToInt32(ddlDayID.SelectedValue)).Year);
            int SelectedDayID = Convert.ToInt32(ddlDayID.SelectedValue);
            int DayCount = 0;

            if (ddlDayID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Day") + "')", true);
            }
            else
            {
                if (ddlDayID.SelectedValue != "7")
                {
                    DayCount = SelectedDayID - DayOfTheWeekID;
                }
                else if (ddlDayID.SelectedValue == "7")
                {
                    DayCount = SelectedDayID - DayOfTheWeekID - 7;
                }

                if (SelectedDayID == DayOfTheWeekID)
                {
                    bindgrid(1);
                }
                else
                {
                    DateTime NewDate = strClassDate.AddDays(DayCount);
                    txtDate.Text = NewDate.ToString("dd-MM-yyyy");
                }
                if (SelectedYear <= CurrentYear && SelectedMonth <= CurrentMonth)
                {
                    bindgrid(1);
                }
                else
                {
                    if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0)
                    {
                        ddlDayID.SelectedValue = "7";
                    }
                    else
                    {
                        ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
                    }
                    txtDate.Text = Convert.ToString(DateTime.Now.Date.ToString("dd-MM-yyyy"));
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("DateOutOfRange") + "')", true);
                }
            }
            bindgrid(1);
        }
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            int DayOfTheWeekID = Convert.ToInt32(strClassDate.DayOfWeek);

            if (DayOfTheWeekID == 0)
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(DayOfTheWeekID);
            }
            int CurrentMonth = Convert.ToInt32(DateTime.Now.Month);
            int CurrentYear = Convert.ToInt32(DateTime.Now.Year);
            int SelectedMonth = Convert.ToInt32(strClassDate.Month);
            int SelectedYear = Convert.ToInt32(strClassDate.Year);

            if (SelectedYear <= CurrentYear && SelectedMonth <= CurrentMonth)
            {
                bindgrid(1);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("DateOutOfRange") + "')", true);
                if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0)
                {
                    ddlDayID.SelectedValue = "7";
                }
                else
                {
                    ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
                }
                txtDate.Text = Convert.ToString(DateTime.Now.Date.ToString("dd-MM-yyyy"));
            }
            bindgrid(1);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstSubTeacher = GetDailyTeacherLiveClassList(index, pagesize);
            if (lstSubTeacher.Count > 0)
            {
                divMain.Visible = true;
                divTotalStudents.Visible = false;
                divAttendedStudents.Visible = false;
                GvSubjectTeacher.PageSize = pagesize;
                string record = lstSubTeacher[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstSubTeacher[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstSubTeacher[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvSubjectTeacher.VirtualItemCount = lstSubTeacher[0].MaximumRows;//total item is required for custom paging
                GvSubjectTeacher.PageIndex = index - 1;
                GvSubjectTeacher.DataSource = lstSubTeacher;
                GvSubjectTeacher.DataBind();
                ds = ConvertToDataSet(lstSubTeacher);
                TableCell tableCell = GvSubjectTeacher.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSubjectTeacher.DataSource = null;
                GvSubjectTeacher.DataBind();
                lblresult.Visible = false;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvSubjectTeacher.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvSubjectTeacher.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvSubjectTeacher.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvSubjectTeacher.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvSubjectTeacher.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvSubjectTeacher.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvSubjectTeacher.UseAccessibleHeader = true;
            GvSubjectTeacher.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        public List<ELearningData> GetDailyTeacherLiveClassList(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            Int64 UserLoginID = LoginToken.UserLoginId;
            List<ELearningData> Result = GetLoginNamebyUserLoginID(UserLoginID);
            if (Result.Count > 0)
            {
                objLearn.TeacherName = Result[0].TeacherName.ToString();
            }
            else
            {
                ClearAll();
            }
            objLearn.DayID = Convert.ToInt32(ddlDayID.SelectedValue == "" ? "0" : ddlDayID.SelectedValue);
            DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objLearn.ClassDate = strClassDate;
            objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
            objLearn.AcademicSessionID = LoginToken.AcademicSessionID;
            objLearn.ActionType = EnumActionType.Select;
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;
            objLearn.UserId = UserLoginID;

            return objLearnBO.SearchDailyTeacherLiveClassList(objLearn);
        }
        private void ClearAll()
        {
            divVideo.Visible = false;
            btnUpdateTop.Visible = false;
            txtTeacherName.Attributes["disabled"] = "disabled";
            if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0)
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(Convert.ToUInt32(DateTime.Now.DayOfWeek));
            }
            txtDate.Text = Convert.ToString(DateTime.Now.Date.ToString("dd-MM-yyyy"));
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            //ViewState["TeacherID"] = null;
            ViewState["OnlineClassID"] = null;
            ClearAll();
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
                wb.Worksheets.Add(dt, "Class List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Online class details for " + (txtDate.Text) + " (" + (ddlDayID.SelectedItem.Text) + ")" + ".xlsx");
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
            List<ELearningData> ELearningDetail = GetDailyTeacherLiveClassList(1, size);
            List<ELearningTeacherClassExcel> ELearningToExcel = new List<ELearningTeacherClassExcel>();
            int i = 0;
            foreach (ELearningData row in ELearningDetail)
            {
                ELearningTeacherClassExcel EcxeclSubTeacher = new ELearningTeacherClassExcel();
                EcxeclSubTeacher.Class = ELearningDetail[i].classname.ToString();
                EcxeclSubTeacher.Section = ELearningDetail[i].SectionName.ToString();
                EcxeclSubTeacher.Day = ELearningDetail[i].DayName.ToString();
                EcxeclSubTeacher.Subject = ELearningDetail[i].SubjectName.ToString();
                EcxeclSubTeacher.StartTime = ELearningDetail[i].StartTime.ToString("h:mm tt");
                EcxeclSubTeacher.EndTime = ELearningDetail[i].EndTime.ToString("h:mm tt");
                EcxeclSubTeacher.Teacher = ELearningDetail[i].TeacherName.ToString();
                EcxeclSubTeacher.VideoLink = ELearningDetail[i].VideoLink.ToString();
                string ClassStatusID = ELearningDetail[i].ClassStatus.ToString();
                EcxeclSubTeacher.ClassStatus = ClassStatusID == "2" ? "Completed" : ClassStatusID == "1" ? "Ongoing" : "Undone";
                EcxeclSubTeacher.IsEnded = ClassStatusID == "2" ? "Yes" : "No";
                EcxeclSubTeacher.TotalStudents = ELearningDetail[i].TotalStudent;
                EcxeclSubTeacher.TotalStudentsAttended = ELearningDetail[i].TotalAttended;
                ELearningToExcel.Add(EcxeclSubTeacher);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(ELearningToExcel);
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

        protected void GvSubjectTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSubjectTeacher.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvSubjectTeacher_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvSubjectTeacher.DataSource = sortedView;
                    GvSubjectTeacher.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSubjectTeacher.HeaderRow.Cells[ColumnIndex];
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

        protected void GvSubjectTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    LinkButton TotalStudents = (LinkButton)e.Row.FindControl("lnk_TotalStudent");
                    LinkButton TotalStudentsAttended = (LinkButton)e.Row.FindControl("lnk_TotalAttended");
                    TotalStudents.Font.Bold = true;
                    TotalStudentsAttended.Font.Bold = true;

                    Label lblStartTime = (Label)e.Row.FindControl("lbl_StartTime");
                    Label lblEndTime = (Label)e.Row.FindControl("lbl_EndTime");
                    Label LiveClassStatus = (Label)e.Row.FindControl("lbl_OnlineClassStatus");
                    Label lblClassDate = (Label)e.Row.FindControl("lbl_ClassDate");
                    Button ActionButton = (Button)e.Row.FindControl("btn_Action");
                    Button EndButton = (Button)e.Row.FindControl("btn_EndClass");
                    Button EditButton = (Button)e.Row.FindControl("btn_Edit");

                    DateTime ClassDate = Convert.ToDateTime(lblClassDate.Text.ToString());
                    DateTime DateToday = DateTime.Now.Date;
                    DateTime StartTime = Convert.ToDateTime(lblStartTime.Text.ToString());
                    DateTime EndTime = Convert.ToDateTime(lblEndTime.Text.ToString());

                    TimeSpan StartSpan = StartTime.Subtract(Convert.ToDateTime(DateTime.Now.ToString("HH:mm")));
                    TimeSpan EndSpan = EndTime.Subtract(Convert.ToDateTime(DateTime.Now.ToString("HH:mm")));

                    if (ClassDate > DateToday) //Following Days
                    {
                        ActionButton.Text = "Link InActive";
                        ActionButton.CssClass = "btn btn-grey cus_btn";
                        ActionButton.Attributes["disabled"] = "disabled";
                        EndButton.Attributes["disabled"] = "disabled";
                        EditButton.Attributes["disabled"] = "disabled";
                    }
                    else if (ClassDate < DateToday) //Earlier Days
                    {
                        ActionButton.Attributes["disabled"] = "disabled";
                        EndButton.Attributes["disabled"] = "disabled";
                        EditButton.Attributes["disabled"] = "disabled";

                        if (LiveClassStatus.Text == "0") // && EndSpan <= TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Class Skipped";
                            ActionButton.CssClass = "btn btn-brown cus_btn";
                        }
                        else if (LiveClassStatus.Text == "1") // && StartSpan <= TimeSpan.Parse("00:15:00") && EndSpan > TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Class not Ended";
                            ActionButton.CssClass = "btn btn-yellow cus_btn";
                            ActionButton.ForeColor = System.Drawing.Color.Gray;
                            EndButton.Attributes.Remove("disabled");
                            EndButton.CssClass = "btn btn-success cus_btn";
                        }
                        else if (LiveClassStatus.Text == "2") // && EndSpan <= TimeSpan.Parse("00:00:00")
                        {
                            ActionButton.Text = "Class Ended";
                            ActionButton.CssClass = "btn btn-danger cus_btn";
                            ActionButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                        }
                    }
                    else //Same Day
                    {
                        EditButton.Attributes["disabled"] = "disabled";
                        ActionButton.Attributes["disabled"] = "disabled";
                        EndButton.Attributes["disabled"] = "disabled";

                        if (LiveClassStatus.Text == "0" && StartSpan > TimeSpan.Parse("00:15:00"))
                        {
                            ActionButton.Text = "Link InActive";
                            ActionButton.CssClass = "btn btn-blue-grey cus_btn";
                        }
                        else if (LiveClassStatus.Text == "0" && EndSpan < TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Class Skipped";
                            ActionButton.CssClass = "btn btn-brown cus_btn";
                        }
                        else if (LiveClassStatus.Text == "1") // && StartSpan <= TimeSpan.Parse("00:15:00") && EndSpan > TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Continue Class";
                            ActionButton.CssClass = "btn btn-yellow cus_btn";
                            ActionButton.ForeColor = System.Drawing.Color.Gray;
                            ActionButton.Attributes.Remove("disabled");
                            EndButton.Attributes.Remove("disabled");
                            EndButton.CssClass = "btn btn-success cus_btn";
                            if (EndSpan < TimeSpan.Parse("00:00:00"))
                            {
                                EditButton.Attributes["disabled"] = "disabled";
                            }
                            else
                            {
                                EditButton.Attributes.Remove("disabled");
                            }
                        }
                        else if (LiveClassStatus.Text == "2") // && EndSpan <= TimeSpan.Parse("00:00:00")
                        {
                            ActionButton.Text = "Class Ended";
                            ActionButton.CssClass = "btn btn-danger cus_btn";
                            ActionButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                            EndButton.Text = "Class Ended";
                        }
                        else //if (LiveClassStatus.Text == "0") // && StartSpan <= TimeSpan.Parse("00:15:00") && EndSpan > TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Start Class";
                            ActionButton.CssClass = "btn btn-success cus_btn";
                            ActionButton.Attributes.Remove("disabled");
                            EndButton.CssClass = "btn btn-red cus_btn";
                            EditButton.Attributes.Remove("disabled");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ClearAll();
                }
            }
        }

        protected void GvSubjectTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvSubjectTeacher.Rows[i];
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                
                Label ID = (Label)gr.Cells[0].FindControl("lblID");
                Label SessionID = (Label)gr.Cells[0].FindControl("lbl_SessionID");
                Label DayID = (Label)gr.Cells[0].FindControl("lbl_DayID");
                Label Session = (Label)gr.Cells[0].FindControl("lbl_Session");
                Label ClassID = (Label)gr.Cells[0].FindControl("lbl_ClassID");
                Label Class = (Label)gr.Cells[0].FindControl("lbl_Class");
                Label SectionID = (Label)gr.Cells[0].FindControl("lbl_SectionID");
                Label Section = (Label)gr.Cells[0].FindControl("lbl_Section");
                Label SubjectID = (Label)gr.Cells[0].FindControl("lbl_SubjectID");
                Label LiveClassID = (Label)gr.Cells[0].FindControl("lbl_LiveClassID");
                Label TotalStudent = (Label)gr.Cells[0].FindControl("lbl_TotalStudent");
                Label TotalAttended = (Label)gr.Cells[0].FindControl("lbl_TotalAttended");
                Label ClassDate = (Label)gr.Cells[0].FindControl("lbl_ClassDate");

                Label VideoLink = (Label)gr.Cells[0].FindControl("lbl_VideoLink");
                HyperLink ClassLink = (HyperLink)gr.Cells[0].FindControl("lnk_VideoLink");

                //lblhiddenID.Text = Convert.ToString(ID.Text == "" ? "0" : ID.Text);
                //lblhiddensessionID.Text = Convert.ToString(SessionID.Text == "" ? "0" : SessionID.Text);
                lblhiddensession.Text = Convert.ToString(Session.Text == "" ? "0" : Session.Text);
                //lblhiddenclassID.Text = Convert.ToString(ClassID.Text == "" ? "0" : ClassID.Text);
                lblhiddenclass.Text = Convert.ToString(Class.Text == "" ? "0" : Class.Text);
                //lblhiddensectionID.Text = Convert.ToString(SectionID.Text == "" ? "0" : SectionID.Text);
                lblhiddensection.Text = Convert.ToString(Section.Text == "" ? "0" : Section.Text);
                lblhiddenTotalStudent.Text = Convert.ToString(TotalStudent.Text == "" ? "0" : TotalStudent.Text);
                lblhiddenTotalStudentAttended.Text = Convert.ToString(TotalAttended.Text == "" ? "0" : TotalAttended.Text);

                Int64 Pop_ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                Int64 Pop_TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
                int Pop_SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                int Pop_SessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                int Pop_ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                int Pop_SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);

                //lblhiddensessionID.Text = Pop_SessionID.ToString();
                //lblhiddenclassID.Text = Pop_ClassID.ToString();
                //lblhiddensectionID.Text = Pop_SectionID.ToString();

                if (e.CommandName == "Edits")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();

                    objLearn.ID = Convert.ToInt32(ID.Text);
                    List<ELearningData> GetResult = objLearnBO.GetClassLinkByID(objLearn);
                    if (GetResult.Count > 0)
                    {
                        divVideo.Visible = true;
                        btnUpdateTop.Visible = true;
                        ViewState["OnlineClassID"] = GetResult[0].ID.ToString();
                        txtClass.Text = GetResult[0].classname.ToString();
                        txtSubject.Text = GetResult[0].SubjectName.ToString();
                        txtVideoLink.Text = GetResult[0].VideoLink.ToString();
                        txtClass.Attributes["disabled"] = "disabled";
                        txtSubject.Attributes["disabled"] = "disabled";
                    }
                }
                if (e.CommandName == "Start")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();

                    Int64 UserLoginID = LoginToken.UserLoginId;
                    objLearn.ID = Convert.ToInt64(ID.Text);
                    objLearn.AcademicSessionID = Convert.ToInt32(SessionID.Text);
                    objLearn.DayID = Convert.ToInt32(DayID.Text);
                    objLearn.LiveClassID = Convert.ToInt64(LiveClassID.Text);
                    objLearn.ClassID = Convert.ToInt32(ClassID.Text);
                    objLearn.SectionID = Convert.ToInt32(SectionID.Text);
                    objLearn.SubjectID = Convert.ToInt32(SubjectID.Text);
                    objLearn.TotalStudent = Convert.ToInt32(TotalStudent.Text);
                    objLearn.TotalAttended = Convert.ToInt32(TotalAttended.Text);
                    objLearn.VideoLink = Convert.ToString(VideoLink.Text);
                    objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
                    objLearn.UserId = UserLoginID;
                    objLearn.ClassDate = strClassDate;
                    objLearn.TeacherName = Convert.ToString(txtTeacherName.Text.Trim());

                    int Result = objLearnBO.StartDailyTeacherLiveClass(objLearn);
                    if (Result == 1 || Result == 2)
                    {
                        bindgrid(1);
                        string baseurl = VideoLink.Text.Trim();
                        string fullURL = "window.open('" + baseurl + "');";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("FailOnlineClass") + "')", true);
                    }
                }
                if (e.CommandName == "EndClass")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();

                    Int64 UserLoginID = LoginToken.UserLoginId;
                    objLearn.ID = Convert.ToInt64(ID.Text);
                    objLearn.AcademicSessionID = Convert.ToInt32(SessionID.Text);
                    objLearn.DayID = Convert.ToInt32(DayID.Text);
                    objLearn.LiveClassID = Convert.ToInt64(LiveClassID.Text);
                    objLearn.ClassID = Convert.ToInt32(ClassID.Text);
                    objLearn.SectionID = Convert.ToInt32(SectionID.Text);
                    objLearn.SubjectID = Convert.ToInt32(SubjectID.Text);
                    objLearn.TotalStudent = Convert.ToInt32(TotalStudent.Text);
                    objLearn.TotalAttended = Convert.ToInt32(TotalAttended.Text);
                    objLearn.VideoLink = Convert.ToString(VideoLink.Text);
                    objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
                    objLearn.UserId = UserLoginID;
                    objLearn.ClassDate = strClassDate;
                    objLearn.TeacherName = Convert.ToString(txtTeacherName.Text.Trim());

                    int Result = objLearnBO.EndDailyTeacherLiveClass(objLearn);
                    if (Result == 1 || Result == 2)
                    {
                        bindgrid(1);
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("SuccessEndingOnlineClass") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("FailEndingOnlineClass") + "')", true);
                    }
                }
                if (e.CommandName == "ViewTotalStudents")
                {
                    lblsessionTotalStudents2.Text = lblhiddensession.Text;
                    lblclassTotalStudents2.Text = lblhiddenclass.Text;
                    lblSectionTotalStudents2.Text = lblhiddensection.Text;
                    lblTotalStudentTotalStudents2.Text = lblhiddenTotalStudent.Text;
                    divMain.Visible = false;
                    divTotalStudents.Visible = true;
                    divAttendedStudents.Visible = false;
                    GetTotalStudents(Pop_SessionID, Pop_ClassID, Pop_SectionID);
                    //this.ModalPopupExtender1.Show();
                }
                if (e.CommandName == "ViewTotalStudentsAttended")
                {
                    lblsessionAttendedStudents2.Text = lblhiddensession.Text;
                    lblclassAttendedStudents2.Text = lblhiddenclass.Text;
                    lblSectionAttendedStudents2.Text = lblhiddensection.Text;
                    lblTotalAttendedStudents2.Text = lblhiddenTotalStudentAttended.Text;
                    divMain.Visible = false;
                    divTotalStudents.Visible = false;
                    divAttendedStudents.Visible = true;
                    GetTotalStudentsAttended(Pop_ID, Pop_TeacherID, Pop_SubjectID, Pop_SessionID, Pop_ClassID, Pop_SectionID);
                    //this.ModalPopupExtender2.Show();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }


        //PopUp1 -- Total Students
        public void GetTotalStudents(int SessionID, int ClassID, int SectionID)
        {
            ELearningData objELearn = new ELearningData();
            ELearningBO objELearnBO = new ELearningBO();

            objELearn.AcademicSessionID = SessionID;
            objELearn.ClassID = ClassID;
            objELearn.SectionID = SectionID;

            List<ELearningData> result = objELearnBO.GetTotalStudents(objELearn);
            if (result.Count > 0)
            {
                GvTotalStudents.DataSource = result;
                GvTotalStudents.DataBind();
                PopUp1_bindresponsive();
            }
            else
            {
                GvTotalStudents.DataSource = null;
                GvTotalStudents.DataBind();
            }
        }
        protected void PopUp1_bindresponsive()
        {
            //Responsive 
            GvTotalStudents.UseAccessibleHeader = true;
            GvTotalStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //PopUp2 -- Total Attended
        public void GetTotalStudentsAttended(Int64 Pop_ID, Int64 Pop_TeacherID, int Pop_SubjectID, int SessionID, int ClassID, int SectionID)
        {
            ELearningData objELearn = new ELearningData();
            ELearningBO objELearnBO = new ELearningBO();
            
            objELearn.ID = Pop_ID;
            objELearn.TeacherID = Pop_TeacherID;
            objELearn.SubjectID = Pop_SubjectID;
            objELearn.AcademicSessionID = SessionID;
            objELearn.ClassID = ClassID;
            objELearn.SectionID = SectionID;

            List<ELearningData> result = objELearnBO.GetTotalStudentsAttended(objELearn);
            if (result.Count > 0)
            {
                GvTotalAttended.DataSource = result;
                GvTotalAttended.DataBind();
                PopUp2_bindresponsive();
            }
            else
            {
                GvTotalAttended.DataSource = null;
                GvTotalAttended.DataBind();
            }
        }
        protected void PopUp2_bindresponsive()
        {
            //Responsive 
            GvTotalAttended.UseAccessibleHeader = true;
            GvTotalAttended.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btn_back_1_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void btn_back_2_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void btnUpdateBottom_Click(object sender, EventArgs e)
        {
            List<ELearningData> lstAttendedStudent = new List<ELearningData>();
            ELearningData objStd = new ELearningData();
            ELearningBO objStdBO = new ELearningBO();

            try
            {
                foreach (GridViewRow row in GvTotalAttended.Rows)
                {
                    Label ID = (Label)GvTotalAttended.Rows[row.RowIndex].Cells[0].FindControl("lbl_AttendID");
                    Label StudentID = (Label)GvTotalAttended.Rows[row.RowIndex].Cells[0].FindControl("lbl_StdIDAttendedStudents");
                    DropDownList Attendance = (DropDownList)GvTotalAttended.Rows[row.RowIndex].Cells[4].FindControl("ddl_StudentAttendance");

                    objStd.ID = Convert.ToInt64(ID.Text);
                    objStd.StudentID = Convert.ToInt64(StudentID.Text);
                    objStd.AttendanceID = Convert.ToInt32(Attendance.SelectedValue);

                    lstAttendedStudent.Add(objStd);
                }

                objStd.XmlStudentAttendanceList = XmlConvertor.E_LearningStudentAttendance(lstAttendedStudent).ToString();
                objStd.AcademicSessionID = LoginToken.AcademicSessionID;
                objStd.AddedBy = LoginToken.LoginId;
                objStd.UserId = LoginToken.UserLoginId;
                int results = objStdBO.UpdateStudentAttendance(objStd);
                if (results == 1)
                {
                    bindgrid(1);
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

        protected void btnUpdateTop_Click(object sender, EventArgs e)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();

            objLearn.ID = Convert.ToInt64(ViewState["OnlineClassID"]);
            objLearn.VideoLink = txtVideoLink.Text.Trim();
            objLearn.AddedBy = LoginToken.UserLoginId.ToString();

            int result = objLearnBO.UpdateTeachersClassVideoLink(objLearn);
            if (result == 1)
            {
                bindgrid(1);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Error") + "')", true);
            }
        }
    }
}