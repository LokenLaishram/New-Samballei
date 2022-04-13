using Mobimp.Campusoft.BussinessProcess.TimeTable;
using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.TimeTable
{
    public partial class DailyTimetable : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddropdownlist();
                //BindGrid(1);
                divsearch.Visible = false;
            }
        }
        protected void binddropdownlist()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.Insertzeroitemindex(ddl_sections);
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.TimeTableGroup));
            Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_TimeTable.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_TimeTable.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";

            Gv_TimeTable.UseAccessibleHeader = true;
            Gv_TimeTable.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCell tableCell = Gv_TimeTable.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        private void BindGrid(int index)
        {
            if (ddlAcademicSessionID.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select session.") + "')", true);
                return;
            }
            if (ddl_group.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select group.") + "')", true);
                return;
            }
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TimeTableData> result = Getclasswisetimetable(index, pagesize);
            if (result.Count > 0)
            {

                Gv_TimeTable.Visible = true;
                Gv_TimeTable.PageSize = pagesize;
                string record = result.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result.Count.ToString() + " " + record;
                lbl_totalrecords.Text = result.Count.ToString();
                lblresult.Visible = true;
                // Gv_TimeTable.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                Gv_TimeTable.PageIndex = index - 1;
                Gv_TimeTable.DataSource = result;
                Gv_TimeTable.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
                divsearch.Visible = true;
            }
            else
            {
                divsearch.Visible = false;
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                Gv_TimeTable.Visible = true;
                lblresult.Visible = false;
            }
        }
        public List<TimeTableData> Getclasswisetimetable(int curIndex, int pagesize)
        {
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objdata.SectionID = Convert.ToInt32(ddl_sections.SelectedValue == "" ? "0" : ddl_sections.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue);
            objdata.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objdata.Periodid = Convert.ToInt32(ddl_period.SelectedValue == "" ? "0" : ddl_period.SelectedValue);
            DateTime date = txt_date.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.Date = date;
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objBO.GetDailyTimeTable(objdata);
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
        int countsectionID = 1;
        string classID = "";
        string sectionID = "";

        protected void Gv_TimeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label ID = (Label)e.Row.FindControl("lbl_sectionID");
                Label Class = (Label)e.Row.FindControl("lbl_class");
                Label lbl_ClassID = (Label)e.Row.FindControl("lbl_classID");
                Label SectionName = (Label)e.Row.FindControl("lbl_section");
                Button btn_print = (Button)e.Row.FindControl("lnkPrint");
                Label slotype = (Label)e.Row.FindControl("lbl_slotype");
                Label Period = (Label)e.Row.FindControl("lbl_period");
                Label lbl_subjectid = (Label)e.Row.FindControl("lbl_subject");
                Label noperiods = (Label)e.Row.FindControl("lbl_noperiods");
                Label timeslot = (Label)e.Row.FindControl("lbl_timeslot");
                Label lbl_substeacherid = (Label)e.Row.FindControl("lbl_substeacher");


                DropDownList ddl_subject = (DropDownList)e.Row.FindControl("ddl_subject");
                DropDownList ddl_susteacher = (DropDownList)e.Row.FindControl("ddl_substeacher");
                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                int ClassID = Convert.ToInt32(lbl_ClassID.Text == "" ? "0" : lbl_ClassID.Text);
                int SectionID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
                int GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
                int sessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                DateTime date = txt_date.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                int SubjectID = Convert.ToInt32(lbl_ClassID.Text == "" ? "0" : lbl_ClassID.Text);
                int PeriodNo = Convert.ToInt32(noperiods.Text == "" ? "0" : noperiods.Text);
                Commonfunction.PopulateDdl(ddl_subject, objmstlookupBO.GetDaywiseSubjectByClassID(ClassID, SectionID, GroupID, sessionID, date));
                Commonfunction.PopulateDdl(ddl_susteacher, objmstlookupBO.GetDaywiseSubstitionTeachers(PeriodNo, SubjectID, GroupID, sessionID, date));

                ddl_subject.SelectedValue = lbl_subjectid.Text;
                if (ddl_susteacher.Items.Count > 0)
                {
                    ddl_susteacher.SelectedValue = lbl_substeacherid.Text;
                }
                if (sectionID == ID.Text && classID == lbl_ClassID.Text)
                {
                    countsectionID = countsectionID + 1;
                }
                else
                {
                    sectionID = ID.Text;
                    classID = lbl_ClassID.Text;
                    countsectionID = 1;
                    btn_print.Visible = true;
                    SectionName.Visible = true;
                    Class.Visible = true;
                }
                if (countsectionID > 1)
                {
                    Class.Text = "";
                    SectionName.Visible = true;
                }


                if (lbl_ClassID.Text != classID)
                {
                    classID = lbl_ClassID.Text;
                }
                if (lbl_ClassID.Text == classID && Convert.ToInt32(Period.Text == "" ? "0" : Period.Text) > Convert.ToInt32(noperiods.Text == "" ? "0" : noperiods.Text))
                {
                    ddl_subject.Visible = false;
                    ddl_susteacher.Visible = false;
                    SectionName.Text = "";
                    timeslot.Text = "";
                    Period.Text = "";
                }

                if (Period.Text == "0")
                {
                    Period.Text = "";
                    ddl_subject.Visible = false;
                    ddl_susteacher.Visible = false;
                }

                if (lbl_substeacherid.Text != "0")
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Black;
                }

            }

        }
        protected void Gv_TimeTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Print")
                {
                    PeriodPlannerData objData = new PeriodPlannerData();
                    PeriodplannerBO objBO = new PeriodplannerBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_TimeTable.Rows[i];
                    Label ClassID = (Label)gr.Cells[0].FindControl("lbl_classID");
                    Label SectionID = (Label)gr.Cells[0].FindControl("lbl_sectionID");

                    string classID = ClassID.Text;
                    string sectionID = SectionID.Text;
                    string Group = ddl_group.SelectedValue;
                    String Year = ddlAcademicSessionID.SelectedValue;
                    string url = "../TimeTable/Reports/ReportViewer.aspx?option=SectionTimeTable&Session=" + Year + "&GroupID=" + Group + "&Class=" + classID + "&Section=" + sectionID;
                    string fullURL = "window.open('" + url + "', '_blank');";

                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

                }

            }
            catch (Exception ex) //Exception in agent layer itself 
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                lblmessage.Text = ExceptionMessage.GetMessage(ex);
                lblmessage.Visible = true;
                lblmessage.CssClass = "Message";
            }
        }
        protected void link_btn_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddlAcademicSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_sections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            BindGrid(1);
        }
        protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_sections_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                List<ClasswisePeriodPlannerData> subjectlist = new List<ClasswisePeriodPlannerData>();
                ClasswisePeriodPlannerData ObjData = new ClasswisePeriodPlannerData();
                ClassallocationBO ObjBO = new ClassallocationBO();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                foreach (GridViewRow row in Gv_TimeTable.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ClassID = (Label)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("lbl_classID");
                    Label SectionID = (Label)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("lbl_sectionID");
                    Label SubjectID = (Label)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("lbl_subjectID");
                    CheckBox chksunday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chksunday");
                    CheckBox chkmonday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chkmonday");
                    CheckBox chktuesday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chktuesday");
                    CheckBox chkwednesday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chkwednesday");
                    CheckBox chkthursday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chkthursday");
                    CheckBox chkfriday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chkfriday");
                    CheckBox chksaturday = (CheckBox)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("chksaturday");
                    DropDownList ddlperiod = (DropDownList)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("ddl_period");
                    DropDownList Teacher = (DropDownList)Gv_TimeTable.Rows[row.RowIndex].Cells[0].FindControl("ddl_teacher");

                    ClasswisePeriodPlannerData objclass = new ClasswisePeriodPlannerData();
                    objclass.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    objclass.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                    objclass.SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                    objclass.Sunday = chksunday.Checked ? 1 : 0;
                    objclass.Monday = chkmonday.Checked ? 1 : 0;
                    objclass.Tuesday = chktuesday.Checked ? 1 : 0;
                    objclass.Wednesday = chkwednesday.Checked ? 1 : 0;
                    objclass.Thursday = chkthursday.Checked ? 1 : 0;
                    objclass.Friday = chkfriday.Checked ? 1 : 0;
                    objclass.Saturday = chksaturday.Checked ? 1 : 0;
                    objclass.DefaultPeriod = Convert.ToInt32(ddlperiod.SelectedValue == "" ? "0" : ddlperiod.SelectedValue);
                    objclass.TeacherID = Convert.ToInt32(Teacher.SelectedValue == "" ? "0" : Teacher.SelectedValue);
                    objclass.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                    subjectlist.Add(objclass);
                }
                ObjData.XMLData = XmlConvertor.periodtoxml(subjectlist).ToString();
                int result = ObjBO.updateclasswiseperiod(ObjData);
                if (result == 1 || result == 2)
                {
                    BindGrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                    return;
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddl_teacher_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_subject_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_subject_SelectedIndexChanged2(object sender, EventArgs e)
        {
            GridViewRow row = ((DropDownList)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label ClassID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_classID");
            Label SectionID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_sectionID");
            Label PeriodNo = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_period");
            DropDownList ddl_newsubjectID = (DropDownList)Gv_TimeTable.Rows[rowindex].FindControl("ddl_subject");
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
            objdata.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
            objdata.SubjectID = Convert.ToInt32(ddl_newsubjectID.SelectedValue == "" ? "0" : ddl_newsubjectID.SelectedValue);
            objdata.PeriodNo = PeriodNo.Text == "" ? "0" : PeriodNo.Text;
            DateTime date = txt_date.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.Date = date;
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.Text == "" ? "0" : ddlAcademicSessionID.Text);
            objdata.GroupID = Convert.ToInt32(ddl_group.Text == "" ? "0" : ddl_group.Text);
            int result = objBO.UpdateDailyAllotedsubjectTeacher(objdata);
            if (result == 1 || result == 2)
            {
                BindGrid(1);
            }

        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_substeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((DropDownList)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label ClassID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_classID");
            Label SectionID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_sectionID");
            Label PeriodNo = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_period");
            DropDownList ddl_newsubjectID = (DropDownList)Gv_TimeTable.Rows[rowindex].FindControl("ddl_subject");
            DropDownList ddl_teacher = (DropDownList)Gv_TimeTable.Rows[rowindex].FindControl("ddl_substeacher");
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
            objdata.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
            objdata.SubjectID = Convert.ToInt32(ddl_newsubjectID.SelectedValue == "" ? "0" : ddl_newsubjectID.SelectedValue);
            objdata.SubsTeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objdata.PeriodNo = PeriodNo.Text == "" ? "0" : PeriodNo.Text;
            DateTime date = txt_date.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_date.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.Date = date;
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.Text == "" ? "0" : ddlAcademicSessionID.Text);
            objdata.GroupID = Convert.ToInt32(ddl_group.Text == "" ? "0" : ddl_group.Text);
            int result = objBO.UpdateDailySubstituteTeacher(objdata);
            if (result == 1)
            {
                BindGrid(1);
            }
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (ddlAcademicSessionID.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select session.") + "')", true);
                return;
            }
            if (ddl_group.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select group.") + "')", true);
                return;
            }
            string Teacher = ddl_teacher.SelectedValue;
            string Group = ddl_group.SelectedValue;
            String Year = ddlAcademicSessionID.SelectedValue;
            String Class = ddl_class.SelectedValue;
            String Section = ddl_sections.SelectedValue;
            String Subject = ddl_subject.SelectedValue;
            String period = ddl_period.SelectedValue;
            String Date = txt_date.Text;

            string url = "../TimeTable/Reports/ReportViewer.aspx?option=Dailytimetable&Session=" + Year + "&GroupID=" + Group + "&TeacherID=" + Teacher + "&ClassID=" + Class + "&SectionID=" + Section + "&SubjectID=" + Subject + "&PeriodNo=" + period + "&Date=" + Date;
            string fullURL = "window.open('" + url + "', '_blank');";

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }
    }
}