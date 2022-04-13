using Mobimp.Campusoft.BussinessProcess.TimeTable;
using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Edusoft.BussinessProcess.Common;
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
    public partial class ResourcePlanner : BasePage
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
            Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.TimeTableGroup));
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_resourceplanner.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_resourceplanner.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
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
            Gv_resourceplanner.UseAccessibleHeader = true;
            Gv_resourceplanner.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCell tableCell = Gv_resourceplanner.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        private void BindGrid(int index)
        {
            ClasswiseResourcePlannerData objdata = new ClasswiseResourcePlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            int pagesize = 0;// Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ClasswiseResourcePlannerData> result = Getsubjectwiseperiodlist(index, pagesize);
            if (result.Count > 0)
            {
                Gv_resourceplanner.Visible = true;
                string record = result.Count.ToString() == "1" ? " record found. " : " records found. ";
                Gv_resourceplanner.DataSource = result;
                Gv_resourceplanner.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                //divsearch.Visible = true;
                divsearch.Visible = true;
                Gv_resourceplanner.FooterRow.Cells[13].Text = result[0].TotalAvailableTeacher.ToString();
            }
            else
            {
                divsearch.Visible = false;
                Gv_resourceplanner.DataSource = null;
                Gv_resourceplanner.DataBind();
                Gv_resourceplanner.Visible = true;
                Gv_resourceplanner.FooterRow.Cells[13].Text = "";
                //lblresult.Visible = false;
            }
            calculatefooter();
        }
        public List<ClasswiseResourcePlannerData> Getsubjectwiseperiodlist(int curIndex, int pagesize)
        {
            ClasswiseResourcePlannerData objdata = new ClasswiseResourcePlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue);
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objBO.Getsubjectwiseresourceplanning(objdata);
        }
        public List<TeacherWisePeriod> Getsubjectteachers(int subjectid)
        {
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SubjectID = subjectid;
            objdata.EmployeeID = LoginToken.EmployeeID;
            objdata.IsActive = true;
            return objBO.GetSubjectwiseteacherlsit(objdata);
        }
        public List<TeacherWisePeriod> Getsubjectwiseteacherlist(int subjectid, int dayid)
        {
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SubjectID = subjectid;
            objdata.EmployeeID = LoginToken.EmployeeID;
            objdata.IsActive = true;
            objdata.DayID = dayid;
            return objBO.GetSubjectwiseactiveteachers(objdata);
        }
        public List<TeacherWisePeriod> GetsubjectDayteachers(int subjectid, int DayID)
        {
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SubjectID = subjectid;
            objdata.DayID = DayID;
            objdata.IsActive = true;
            return objBO.GetSubjectwiseDayteacherlsit(objdata);
        }
        public List<TeacherWisePeriod> Getassignsubjectlist(int subjectid, int DayID, int teacherID)
        {
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.FilterType = Convert.ToInt32(ddl_show.SelectedValue == "" ? "0" : ddl_show.SelectedValue);
            objdata.CategoryID = Convert.ToInt32(ddl_category.SelectedValue == "" ? "0" : ddl_category.SelectedValue);
            objdata.SubjectID = subjectid;
            objdata.DayID = DayID;
            objdata.TeacherID = teacherID;
            objdata.IsActive = true;
            return objBO.Getassignsubjectistt(objdata);
        }
        private void bindsubjectteachers(int subjectID)
        {
            List<TeacherWisePeriod> result = Getsubjectteachers(subjectID);
            if (result.Count > 0)
            {
                gv_teachers.DataSource = result;
                gv_teachers.DataBind();
            }
            else
            {
                gv_teachers.DataSource = null;
                gv_teachers.DataBind();

            }
        }
        private void Getteacherlist(int subjectID, int dayid)
        {
            List<TeacherWisePeriod> result = Getsubjectwiseteacherlist(subjectID, dayid);
            if (result.Count > 0)
            {
                gv_teacherlist.DataSource = result;
                gv_teacherlist.DataBind();
                gv_teacherlist.FooterRow.Cells[2].Text = "Total";
                gv_teacherlist.FooterRow.Cells[3].Text = result[0].ClassTotalPeriod.ToString();

                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == result[0].ClassTotalPeriod)
                {
                    gv_teacherlist.FooterRow.BackColor = System.Drawing.Color.Green;
                    gv_teacherlist.FooterRow.ForeColor = System.Drawing.Color.White;
                    btn_gen.Visible = true;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) != result[0].ClassTotalPeriod)
                {
                    gv_teacherlist.FooterRow.BackColor = System.Drawing.Color.Yellow;
                    gv_teacherlist.FooterRow.ForeColor = System.Drawing.Color.Black;
                    btn_gen.Visible = true;
                }
                if (result[0].ClassTotalPeriod == 0)
                {
                    btn_gen.Visible = false;
                }
                gv_teacherlist.FooterRow.Cells[2].Font.Bold = true;
                gv_teacherlist.FooterRow.Cells[3].Font.Bold = true;
            }
            else
            {
                gv_teacherlist.DataSource = null;
                gv_teacherlist.DataBind();

            }
        }
        private void bindsubjectDayteachers(int subjectID, int DayID)
        {
            List<TeacherWisePeriod> result = GetsubjectDayteachers(subjectID, DayID);
            if (result.Count > 0)
            {
                Gv_teacherwsie_period.DataSource = result;
                Gv_teacherwsie_period.DataBind();
            }
            else
            {
                Gv_teacherwsie_period.DataSource = null;
                Gv_teacherwsie_period.DataBind();

            }
        }
        private void bindassignsubjectlist(int subjectID, int DayID, int TeacherID)
        {
            List<TeacherWisePeriod> result = Getassignsubjectlist(subjectID, DayID, TeacherID);
            if (result.Count > 0)
            {
                Gv_subsubjectlist.DataSource = result;
                Gv_subsubjectlist.DataBind();
                bindgridfoucs();
            }
            else
            {
                Gv_subsubjectlist.DataSource = null;
                Gv_subsubjectlist.DataBind();

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

        protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void Gv_resourceplanner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "subject")
                {
                    ClassallocationData objclass = new ClassallocationData();
                    ClassallocationBO objBO = new ClassallocationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_resourceplanner.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lbl_subjectID");
                    LinkButton subject = (LinkButton)gr.Cells[0].FindControl("lnl_subject");

                    int subjectID = Convert.ToInt32(ID.Text);
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

        public List<ClasswisePeriodPlannerData> Getsectiionwiseperiodlist(int subjectID)
        {
            ClasswisePeriodPlannerData objdata = new ClasswisePeriodPlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.SubjectID = subjectID;
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            return objBO.Getsubjectwiseplannerlist(objdata);
        }
        protected void calculatefooter()
        {

            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;


            int j = 0; // initialization
            int total_sundaycount = 0;
            int total_mondaycount = 0;
            int total_tuesdaycount = 0;
            int total_wednesdaycount = 0;
            int total_thursdaycount = 0;
            int total_fridaycount = 0;
            int total_saturdaycount = 0;
            int totalperiod = 0;
            int totalextraperiod = 0;
            int TotalteacherRequired = 0;


            while (j <= lastindex) // condition
            {
                Label Totalperiods = (Label)Gv_resourceplanner.Rows[j].FindControl("lbl_totalperiod");
                Label totalextra = (Label)Gv_resourceplanner.Rows[j].FindControl("lbl_extraperiod");
                Label teacherreqd = (Label)Gv_resourceplanner.Rows[j].FindControl("lbl_teacherreqd");

                Label sunday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_sunday");
                Label monday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_monday");
                Label tuesday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_tuesday");
                Label wednesday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_wednesday");
                Label thursday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_thursday");
                Label friday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_friday");
                Label saturday = (Label)Gv_resourceplanner.Rows[j].FindControl("txt_saturday");

                if (Convert.ToInt32(Totalperiods.Text == "" ? "0" : Totalperiods.Text) > 0)
                {
                    totalperiod = totalperiod + Convert.ToInt32(Totalperiods.Text == "" ? "0" : Totalperiods.Text);
                }
                if (Convert.ToInt32(totalextra.Text == "" ? "0" : totalextra.Text) > 0)
                {
                    totalextraperiod = totalextraperiod + Convert.ToInt32(totalextra.Text == "" ? "0" : totalextra.Text);
                }
                if (Convert.ToInt32(teacherreqd.Text == "" ? "0" : teacherreqd.Text) > 0)
                {
                    TotalteacherRequired = TotalteacherRequired + Convert.ToInt32(teacherreqd.Text == "" ? "0" : teacherreqd.Text);
                }
                if (Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text) > 0)
                {
                    total_sundaycount = total_sundaycount + Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text);
                }
                if (Convert.ToInt32(monday.Text == "" ? "0" : monday.Text) > 0)
                {
                    total_mondaycount = total_mondaycount + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text);
                }
                if (Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text) > 0)
                {
                    total_tuesdaycount = total_tuesdaycount + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text);
                }
                if (Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text) > 0)
                {
                    total_wednesdaycount = total_wednesdaycount + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text);
                }
                if (Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text) > 0)
                {
                    total_thursdaycount = total_thursdaycount + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text);
                }
                if (Convert.ToInt32(friday.Text == "" ? "0" : friday.Text) > 0)
                {
                    total_fridaycount = total_fridaycount + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text);
                }
                if (Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text) > 0)
                {
                    total_saturdaycount = total_saturdaycount + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text);
                }
                j++;
            }
            Gv_resourceplanner.FooterRow.Cells[1].Text = "Total";
            Gv_resourceplanner.FooterRow.Cells[2].Text = totalperiod.ToString();
            Gv_resourceplanner.FooterRow.Cells[3].Text = totalextraperiod.ToString();
            Gv_resourceplanner.FooterRow.Cells[4].Text = TotalteacherRequired.ToString();
            Gv_resourceplanner.FooterRow.Cells[6].Text = total_sundaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[7].Text = total_mondaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[8].Text = total_tuesdaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[9].Text = total_wednesdaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[10].Text = total_thursdaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[11].Text = total_fridaycount.ToString();
            Gv_resourceplanner.FooterRow.Cells[12].Text = total_saturdaycount.ToString();
        }
        protected void btn_addteacher_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            lbl_teachersubject.Text = "Add " + lbl_subject.Text + " Teacher";
            lbl_teachersubjectid.Text = lbl_subjectid.Text;
            lbl_teachersubjectname.Text = lbl_subject.Text;
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            bindsubjectteachers(subjectid);
            div_addteacher.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_sunday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label sundaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_sunday");
            lbl_totalperiod.Text = sundaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Sunday.(" + sundaycount.Text + ")";
            int Day = 1;
            lbl_dayid.Text = "1";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Sunday.(" + sundaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_monday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label mondaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_monday");
            lbl_totalperiod.Text = mondaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Monday.(" + mondaycount.Text + ")";
            int Day = 2;
            lbl_dayid.Text = "2";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Monday.(" + mondaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);
            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_tuesday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label tuesdaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_tuesday");
            lbl_totalperiod.Text = tuesdaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Tuesday.(" + tuesdaycount.Text + ")";
            int Day = 3;
            lbl_dayid.Text = "3";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Tuesday.(" + tuesdaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            ddl_category.SelectedIndex = 0;
            ddl_subjectwiseteacher.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_wednesday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label wednesdaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_wednesday");
            lbl_totalperiod.Text = wednesdaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Wednesday.(" + wednesdaycount.Text + ")";
            int Day = 4;
            lbl_dayid.Text = "4";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Wednesday.(" + wednesdaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_thursday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label thursdaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_thursday");
            lbl_totalperiod.Text = thursdaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Thursday.(" + thursdaycount.Text + ")";
            int Day = 5;
            lbl_dayid.Text = "5";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Thursday.(" + thursdaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_friday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label fridaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_friday");
            lbl_totalperiod.Text = fridaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Friday.(" + fridaycount.Text + ")";
            int Day = 6;
            lbl_dayid.Text = "6";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Friday.(" + fridaycount.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));

            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;

        }
        protected void btn_saturday_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_resourceplanner.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectID");
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            lbl_daywisesubjectid.Text = lbl_subjectid.Text;
            Label lbl_subject = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("lbl_subjectname");
            Label saturdaycount = (Label)Gv_resourceplanner.Rows[rowindex].FindControl("txt_saturday");
            lbl_totalperiod.Text = saturdaycount.Text;
            lbl_daywisesubject.Text = lbl_subject.Text + ", Saturday.(" + saturdaycount.Text + ")";
            int Day = 7;
            lbl_dayid.Text = "7";

            lbl_teacherwisesubject.Text = lbl_subject.Text + ", Saturday.(" + lbl_totalperiod.Text + ")";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateteacherDdl(ddl_subjectwiseteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));

            ddl_subjectwiseteacher.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, Day, 0);
            Getteacherlist(subjectid, Day);

            Div_period_Planner.Visible = true;
            div_subjectlist.Visible = false;
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            PeriodplannerBO objBO = new PeriodplannerBO();
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            objdata.SubjectName = lbl_teachersubjectname.Text;
            objdata.SubjectID = Convert.ToInt32(lbl_teachersubjectid.Text == "" ? "0" : lbl_teachersubjectid.Text);
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            int result = objBO.Addsubjectwiseteachers(objdata);
            if (result == 1)
            {
                int subjectid = Convert.ToInt32(lbl_teachersubjectid.Text == "" ? "0" : lbl_teachersubjectid.Text);
                bindsubjectteachers(subjectid);

                return;
            }
            else
            {

                return;
            }
        }

        protected void gv_teachers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label StatusStatus = (Label)e.Row.FindControl("lbl_status");
                Button Acton = (Button)e.Row.FindControl("btn_action");

                if (StatusStatus.Text == "True")
                {
                    Acton.Text = "DEACTIVATE";
                    Acton.CssClass = "btn btn-info cus_btn";
                }
                if (StatusStatus.Text == "False")
                {
                    Acton.Text = "ACTIVATE";
                    Acton.CssClass = "btn btn-warning cus_btn";
                }

            }
        }

        protected void btn_action_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            PeriodplannerBO objBO = new PeriodplannerBO();
            TeacherWisePeriod objdata = new TeacherWisePeriod();

            Label teacherID = (Label)gv_teachers.Rows[rowindex].FindControl("lbl_teacherid");
            Label lbl_subjectid = (Label)gv_teachers.Rows[rowindex].FindControl("lbl_subjectid");
            Label status = (Label)gv_teachers.Rows[rowindex].FindControl("lbl_status");
            Button action = (Button)gv_teachers.Rows[rowindex].FindControl("btn_action");

            objdata.TeacherID = Convert.ToInt32(teacherID.Text == "" ? "0" : teacherID.Text);
            objdata.SubjectID = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.IsActive = status.Text == "True" ? false : true;

            int result = objBO.UpdateteacherStatus(objdata);
            if (result == 1)
            {
                int subjectid = Convert.ToInt32(lbl_teachersubjectid.Text == "" ? "0" : lbl_teachersubjectid.Text);
                bindsubjectteachers(subjectid);
                action.Focus();

                return;
            }
            else
            {

                return;
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindGrid(1);
            div_subjectlist.Visible = true;
            div_addteacher.Visible = false;
        }

        protected void Gv_resourceplanner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label sundaystatus = (Label)e.Row.FindControl("lbl_sundaystatus");
                Label mondaystatus = (Label)e.Row.FindControl("lbl_mondaystatus");
                Label tuesdaystatus = (Label)e.Row.FindControl("lbl_tuesdaystatus");
                Label wednesdaystatus = (Label)e.Row.FindControl("lbl_wednesdaystatus");
                Label thursdaystatus = (Label)e.Row.FindControl("lbl_thursdaystatus");
                Label fridaystatus = (Label)e.Row.FindControl("lbl_fridaystatus");
                Label saturdaystatus = (Label)e.Row.FindControl("lbl_saturdaystatus");

                LinkButton btn_sunday = (LinkButton)e.Row.FindControl("btn_sunday");
                LinkButton btn_monday = (LinkButton)e.Row.FindControl("btn_monday");
                LinkButton btn_tuesday = (LinkButton)e.Row.FindControl("btn_tuesday");
                LinkButton btn_wednesday = (LinkButton)e.Row.FindControl("btn_wednesday");
                LinkButton btn_thursday = (LinkButton)e.Row.FindControl("btn_thursday");
                LinkButton btn_friday = (LinkButton)e.Row.FindControl("btn_friday");
                LinkButton btn_saturday = (LinkButton)e.Row.FindControl("btn_saturday");

                Label txt_sunday = (Label)e.Row.FindControl("txt_sunday");
                Label txt_monday = (Label)e.Row.FindControl("txt_monday");
                Label txt_tuesday = (Label)e.Row.FindControl("txt_tuesday");
                Label txt_wednesday = (Label)e.Row.FindControl("txt_wednesday");
                Label txt_thursday = (Label)e.Row.FindControl("txt_thursday");
                Label txt_friday = (Label)e.Row.FindControl("txt_friday");
                Label txt_saturday = (Label)e.Row.FindControl("txt_saturday");

                if (sundaystatus.Text == "1")
                {
                    btn_sunday.CssClass = "btn btn-info roundcus_btn";
                }
                if (sundaystatus.Text == "0")
                {
                    btn_sunday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (mondaystatus.Text == "1")
                {
                    btn_monday.CssClass = "btn btn-info roundcus_btn";
                }
                if (mondaystatus.Text == "0")
                {
                    btn_monday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (tuesdaystatus.Text == "1")
                {
                    btn_tuesday.CssClass = "btn btn-info roundcus_btn";
                }
                if (tuesdaystatus.Text == "0")
                {
                    btn_tuesday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (wednesdaystatus.Text == "1")
                {
                    btn_wednesday.CssClass = "btn btn-info roundcus_btn";
                }
                if (wednesdaystatus.Text == "0")
                {
                    btn_wednesday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (thursdaystatus.Text == "1")
                {
                    btn_thursday.CssClass = "btn btn-info roundcus_btn";
                }
                if (thursdaystatus.Text == "0")
                {
                    btn_thursday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (sundaystatus.Text == "1")
                {
                    btn_sunday.CssClass = "btn btn-info roundcus_btn";
                }
                if (fridaystatus.Text == "0")
                {
                    btn_friday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (fridaystatus.Text == "1")
                {
                    btn_friday.CssClass = "btn btn-info roundcus_btn";
                }
                if (saturdaystatus.Text == "1")
                {
                    btn_saturday.CssClass = "btn btn-info roundcus_btn";
                }
                if (saturdaystatus.Text == "0")
                {
                    btn_saturday.CssClass = "btn btn-warning roundcus_btn";
                }
                if (txt_sunday.Text == "0")
                {
                    btn_sunday.BackColor = System.Drawing.Color.White;
                    btn_sunday.ForeColor = System.Drawing.Color.Black;
                    btn_sunday.Enabled = false;
                }
                if (txt_monday.Text == "0")
                {
                    btn_monday.BackColor = System.Drawing.Color.White;
                    btn_monday.ForeColor = System.Drawing.Color.Black;
                    btn_monday.Enabled = false;
                }
                if (txt_tuesday.Text == "0")
                {
                    btn_tuesday.BackColor = System.Drawing.Color.White;
                    btn_tuesday.ForeColor = System.Drawing.Color.Black;
                    btn_tuesday.Enabled = false;
                }
                if (txt_wednesday.Text == "0")
                {
                    btn_wednesday.BackColor = System.Drawing.Color.White;
                    btn_wednesday.ForeColor = System.Drawing.Color.Black;
                    txt_wednesday.Enabled = false;
                }
                if (txt_thursday.Text == "0")
                {
                    btn_thursday.BackColor = System.Drawing.Color.White;
                    btn_thursday.ForeColor = System.Drawing.Color.Black;
                    btn_thursday.Enabled = false;
                }
                if (txt_friday.Text == "0")
                {
                    btn_friday.BackColor = System.Drawing.Color.White;
                    btn_friday.ForeColor = System.Drawing.Color.Black;
                    btn_friday.Enabled = false;
                }
                if (txt_saturday.Text == "0")
                {
                    btn_saturday.BackColor = System.Drawing.Color.White;
                    btn_saturday.ForeColor = System.Drawing.Color.Black;
                    btn_saturday.Enabled = false;
                }
            }
        }

        protected void btn_assignsubject_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_teacherwsie_period.Rows.Count - 1;
            Label lbl_subjectid = (Label)Gv_teacherwsie_period.Rows[rowindex].FindControl("lbl_subjectid");
            Label lbl_teacherid = (Label)Gv_teacherwsie_period.Rows[rowindex].FindControl("lbl_teacherid");
            Label teacher = (Label)Gv_teacherwsie_period.Rows[rowindex].FindControl("lbl_teachername");
            lbl_teacherwisesubject.Text = lbl_daywisesubject.Text + ", Teacher: " + teacher.Text;
            lbl_teachernames.Text = teacher.Text;
            int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            int teacherid = Convert.ToInt32(lbl_teacherid.Text == "" ? "0" : lbl_teacherid.Text);
            int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            idsearch.Value = "";
            lbl_teacherwisesubjectid.Text = lbl_subjectid.Text;
            lbl_teacherwiseTeacherID.Text = lbl_teacherid.Text;
            ddl_show.SelectedIndex = 0;
            ddl_category.SelectedIndex = 0;
            bindassignsubjectlist(subjectid, dayid, teacherid);
            //int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_teachersubjectid.Text);
            Getteacherlist(subjectid, dayid);

            Div_period_Planner.Visible = true;
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < Gv_subsubjectlist.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_subsubjectlist.Rows[i].Cells[4].FindControl("txt_period") as TextBox;
                TextBox nexTextbox = Gv_subsubjectlist.Rows[i + 1].Cells[4].FindControl("txt_period") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_subsubjectlist.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btn_update.ClientID + "', event)");
                }
            }
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //int subjectids = Convert.ToInt32(lbl_daywisesubjectid.Text == "" ? "0" : lbl_daywisesubjectid.Text);
            //int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);

            //bindsubjectDayteachers(subjectids, dayid);
            //ModalPopupExtender3.Hide();
            //ModalPopupExtender2.Show();

            //int subjectid = Convert.ToInt32(lbl_teachersubjectid.Text == "" ? "0" : lbl_teachersubjectid.Text);
            //bindsubjectteachers(subjectid);
            //this.ModalPopupExtender1.Show();
            BindGrid(1);
            div_subjectlist.Visible = true;
            Div_period_Planner.Visible = false;
        }


        protected void btn_update_Click(object sender, EventArgs e)
        {
            int count = 0;
            int day = 0;

            PeriodplannerBO objBO = new PeriodplannerBO();
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            List<TeacherWisePeriod> subjectlist = new List<TeacherWisePeriod>();
            foreach (GridViewRow row in Gv_subsubjectlist.Rows)
            {
                IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                Label SubjectID = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_subjectid");
                Label lbl_subsubject = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_subsubjectid");
                Label ClassID = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_classID");
                Label SectionID = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_sectionID");
                Label lbl_dayid = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_dayID");
                TextBox txt_period = (TextBox)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("txt_period");
                day = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
                Label teacherID = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_teacherid");
                CheckBox checkstatus = (CheckBox)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("checksubjt");
                Label status = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_status");
                Label Maxperiod = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_class_totalperiod");
                Label Class = (Label)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("lbl_class");
                DropDownList ddl_teacherlist = (DropDownList)Gv_subsubjectlist.Rows[row.RowIndex].Cells[0].FindControl("ddl_teacherlist");
                TeacherWisePeriod objperioddata = new TeacherWisePeriod();
                int class_maxperiod = Convert.ToInt32(Maxperiod.Text == "" ? "0" : Maxperiod.Text);

                count = count + 1;
                objperioddata.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                objperioddata.SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                objperioddata.SubSubjectID = Convert.ToInt32(lbl_subsubject.Text == "" ? "0" : lbl_subsubject.Text);
                objperioddata.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                objperioddata.DayID = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
                if (ddl_teacherlist.SelectedIndex > 0)
                {
                    objperioddata.TeacherID = Convert.ToInt32(ddl_teacherlist.SelectedValue == "" ? "0" : ddl_teacherlist.SelectedValue);
                    objperioddata.PeriodNo = Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text);
                }
                //if (checkstatus.Checked && status.Text == "0")
                //{
                //    objperioddata.TeacherID = Convert.ToInt32(lbl_teacherwiseTeacherID.Text == "" ? "0" : lbl_teacherwiseTeacherID.Text);
                //}
                ////if (checkstatus.Checked && Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) == 0)
                ////{
                ////    periodno = periodno + 1;
                ////    txt_period.Text = periodno.ToString();
                ////    objperioddata.PeriodNo = periodno > class_maxperiod ? 0 : periodno;
                ////}
                //if (checkstatus.Checked && teacherID.Text == lbl_teacherwiseTeacherID.Text && Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > 0)
                //{
                //    objperioddata.PeriodNo = Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > class_maxperiod ? 0 : Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text);
                //}
                //if (checkstatus.Checked && teacherID.Text != lbl_teacherwiseTeacherID.Text && Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > 0)
                //{
                //    objperioddata.PeriodNo = Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > class_maxperiod ? 0 : Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text);
                //}
                ////if (checkstatus.Checked == false)
                ////{
                ////    txt_period.Text = "0";
                ////}
                //if (checkstatus.Checked && status.Text == "0" || teacherID.Text == lbl_teacherwiseTeacherID.Text)
                //{
                //    if (txt_period.Text == "1")
                //    {
                //        P_I_count = P_I_count + 1;
                //        if (P_I_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 1 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "2")
                //    {
                //        P_II_count = P_II_count + 1;
                //        if (P_II_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 2 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "3")
                //    {
                //        P_III_count = P_III_count + 1;
                //        if (P_III_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 3 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "4")
                //    {
                //        P_IV_count = P_IV_count + 1;
                //        if (P_IV_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 4 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "5")
                //    {
                //        P_V_count = P_V_count + 1;
                //        if (P_V_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 5 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "6")
                //    {
                //        P_VI_count = P_VI_count + 1;
                //        if (P_VI_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 6 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "7")
                //    {
                //        P_VII_count = P_VII_count + 1;
                //        if (P_VII_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 7 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "8")
                //    {
                //        P_VIII_count = P_VIII_count + 1;
                //        if (P_VIII_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 8 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "9")
                //    {
                //        P_IX_count = P_IX_count + 1;
                //        if (P_IX_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 9 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //    if (txt_period.Text == "10")
                //    {
                //        P_X_count = P_X_count + 1;
                //        if (P_IX_count > 1)
                //        {
                //            Class.BackColor = System.Drawing.Color.Yellow;
                //            txt_period.Focus();
                //            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Same period number 10 could not be assign multiple times for the same teacher.") + "')", true);
                //            this.ModalPopupExtender3.Show();
                //            return;
                //        }
                //    }
                //}
                //if (Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > class_maxperiod)
                //{
                //    Class.BackColor = System.Drawing.Color.Red;
                //    txt_period.Focus();
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("There is no slot in this class. Exceeds the max period for the same.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //    return;
                //}
                //else
                //{
                //    Class.BackColor = System.Drawing.Color.White;
                //}

                subjectlist.Add(objperioddata);
            }
            objdata.XMLData = XmlConvertor.AssignsubjectlisttoXML(subjectlist).ToString();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            objdata.DayID = day;
            objdata.TeacherID = Convert.ToInt32(lbl_teacherwiseTeacherID.Text == "" ? "0" : lbl_teacherwiseTeacherID.Text);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            //if (count == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select subject.") + "')", true);
            //    this.ModalPopupExtender3.Show();
            //    return;
            //}
            int result = objBO.UpdateassignSubjectlist(objdata);
            if (result == 1)
            {
                Int32 SubjectID = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
                objdata.DayID = day;
                Int32 TeacherID = Convert.ToInt32(lbl_teacherwiseTeacherID.Text == "" ? "0" : lbl_teacherwiseTeacherID.Text);
                bindassignsubjectlist(SubjectID, day, TeacherID);
                Getteacherlist(SubjectID, day);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("update") + "')", true);
                Div_period_Planner.Visible = true;
            }
            else
            {
                Div_period_Planner.Visible = true;

            }

        }
        protected void Gv_subsubjectlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label StatusStatus = (Label)e.Row.FindControl("lbl_status");
                CheckBox chk_status = (CheckBox)e.Row.FindControl("checksubjt");
                Label lbl_teacherid = (Label)e.Row.FindControl("lbl_teacherid");
                Label lbl_totalperiod = (Label)e.Row.FindControl("lbl_class_totalperiod");
                Label lbl_class = (Label)e.Row.FindControl("lbl_class");
                Label lbl_p_I_SubSubjectName = (Label)e.Row.FindControl("lbl_p_I_SubSubjectName");
                Label lbl_p_II_SubSubjectName = (Label)e.Row.FindControl("lbl_p_II_SubSubjectName");
                Label lbl_p_III_SubSubjectName = (Label)e.Row.FindControl("lbl_p_III_SubSubjectName");
                Label lbl_p_IV_SubSubjectName = (Label)e.Row.FindControl("lbl_p_IV_SubSubjectName");
                Label lbl_p_V_SubSubjectName = (Label)e.Row.FindControl("lbl_p_V_SubSubjectName");
                Label lbl_p_VI_SubSubjectName = (Label)e.Row.FindControl("lbl_p_VI_SubSubjectName");
                Label lbl_p_VII_SubSubjectName = (Label)e.Row.FindControl("lbl_p_VII_SubSubjectName");
                Label lbl_p_VIII_SubSubjectName = (Label)e.Row.FindControl("lbl_p_VIII_SubSubjectName");
                //Label lbl_p_IX_SubSubjectName = (Label)e.Row.FindControl("lbl_p_IX_SubSubjectName");
                //Label lbl_p_X_SubSubjectName = (Label)e.Row.FindControl("lbl_p_X_SubSubjectName");

                Label lbl_p_I_SubSubjectID = (Label)e.Row.FindControl("lbl_p_I_SubSubjectID");
                Label lbl_p_II_SubSubjectID = (Label)e.Row.FindControl("lbl_p_II_SubSubjectID");
                Label lbl_p_III_SubSubjectID = (Label)e.Row.FindControl("lbl_p_III_SubSubjectID");
                Label lbl_p_IV_SubSubjectID = (Label)e.Row.FindControl("lbl_p_IV_SubSubjectID");
                Label lbl_p_V_SubSubjectID = (Label)e.Row.FindControl("lbl_p_V_SubSubjectID");
                Label lbl_p_VI_SubSubjectID = (Label)e.Row.FindControl("lbl_p_VI_SubSubjectID");
                Label lbl_p_VII_SubSubjectID = (Label)e.Row.FindControl("lbl_p_VII_SubSubjectID");
                Label lbl_p_VIII_SubSubjectID = (Label)e.Row.FindControl("lbl_p_VIII_SubSubjectID");


                Label lbl_p_I_TeacherID = (Label)e.Row.FindControl("lbl_p_I_TeacherID");
                Label lbl_p_II_TeacherID = (Label)e.Row.FindControl("lbl_p_II_TeacherID");
                Label lbl_p_III_TeacherID = (Label)e.Row.FindControl("lbl_p_III_TeacherID");
                Label lbl_p_IV_TeacherID = (Label)e.Row.FindControl("lbl_p_IV_TeacherID");
                Label lbl_p_V_TeacherID = (Label)e.Row.FindControl("lbl_p_V_TeacherID");
                Label lbl_p_VI_TeacherID = (Label)e.Row.FindControl("lbl_p_VI_TeacherID");
                Label lbl_p_VII_TeacherID = (Label)e.Row.FindControl("lbl_p_VII_TeacherID");
                Label lbl_p_VIII_TeacherID = (Label)e.Row.FindControl("lbl_p_VIII_TeacherID");


                TextBox txt_period = (TextBox)e.Row.FindControl("txt_period");
                DropDownList ddl_teacherlist = (DropDownList)e.Row.FindControl("ddl_teacherlist");

                txt_period.Attributes["disabled"] = "disabled";

                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_teacherlist, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));

                ddl_teacherlist.SelectedValue = lbl_teacherid.Text;

                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 0)
                {
                    lbl_p_I_SubSubjectName.Text = "";
                    lbl_p_II_SubSubjectName.Text = "";
                    lbl_p_III_SubSubjectName.Text = "";
                    lbl_p_IV_SubSubjectName.Text = "";
                    lbl_p_V_SubSubjectName.Text = "";
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                    lbl_p_VIII_SubSubjectName.Text = "";
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 1)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Text = "";
                    lbl_p_III_SubSubjectName.Text = "";
                    lbl_p_IV_SubSubjectName.Text = "";
                    lbl_p_V_SubSubjectName.Text = "";
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 2)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Text = "";
                    lbl_p_IV_SubSubjectName.Text = "";
                    lbl_p_V_SubSubjectName.Text = "";
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 3)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Text = "";
                    lbl_p_V_SubSubjectName.Text = "";
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 4)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Text = "";
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    // lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 5)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Text = "";
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 6)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Visible = true;
                    lbl_p_VII_SubSubjectName.Text = "";
                    lbl_p_VIII_SubSubjectName.Text = "";
                    //lbl_p_IX_SubSubjectName.Visible = false;
                    //lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 7)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Visible = true;
                    lbl_p_VII_SubSubjectName.Visible = true;
                    lbl_p_VIII_SubSubjectName.Text = "";
                    // lbl_p_IX_SubSubjectName.Visible = false;
                    // lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 8)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Visible = true;
                    lbl_p_VII_SubSubjectName.Visible = true;
                    lbl_p_VIII_SubSubjectName.Visible = true;
                    // lbl_p_IX_SubSubjectName.Visible = false;
                    // lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 9)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Visible = true;
                    lbl_p_VII_SubSubjectName.Visible = true;
                    lbl_p_VIII_SubSubjectName.Visible = true;
                    // lbl_p_IX_SubSubjectName.Visible = true;
                    // lbl_p_X_SubSubjectName.Visible = false;
                }
                if (Convert.ToInt32(lbl_totalperiod.Text == "" ? "0" : lbl_totalperiod.Text) == 10)
                {
                    lbl_p_I_SubSubjectName.Visible = true;
                    lbl_p_II_SubSubjectName.Visible = true;
                    lbl_p_III_SubSubjectName.Visible = true;
                    lbl_p_IV_SubSubjectName.Visible = true;
                    lbl_p_V_SubSubjectName.Visible = true;
                    lbl_p_VI_SubSubjectName.Visible = true;
                    lbl_p_VII_SubSubjectName.Visible = true;
                    lbl_p_VIII_SubSubjectName.Visible = true;
                    //lbl_p_IX_SubSubjectName.Visible = true;
                    //lbl_p_X_SubSubjectName.Visible = true;
                }
                if (lbl_p_I_SubSubjectID.Text == "0" && lbl_p_I_SubSubjectName.Text != "")
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_I_SubSubjectID.Text != "0" && lbl_p_I_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_I_TeacherID.Text)
                    {
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_I_TeacherID.Text)
                    {
                        e.Row.Cells[6].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_II_SubSubjectID.Text == "0" && lbl_p_II_SubSubjectName.Text != "")
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_II_SubSubjectID.Text != "0" && lbl_p_II_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_II_TeacherID.Text)
                    {
                        e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_II_TeacherID.Text)
                    {
                        e.Row.Cells[7].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[7].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_III_SubSubjectID.Text == "0" && lbl_p_III_SubSubjectName.Text != "")
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_III_SubSubjectID.Text != "0" && lbl_p_III_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_III_TeacherID.Text)
                    {
                        e.Row.Cells[8].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_III_TeacherID.Text)
                    {
                        e.Row.Cells[8].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[8].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_IV_SubSubjectID.Text == "0" && lbl_p_IV_SubSubjectName.Text != "")
                {
                    e.Row.Cells[9].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_IV_SubSubjectID.Text != "0" && lbl_p_IV_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_IV_TeacherID.Text)
                    {
                        e.Row.Cells[9].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_IV_TeacherID.Text)
                    {
                        e.Row.Cells[9].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[9].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_V_SubSubjectID.Text == "0" && lbl_p_V_SubSubjectName.Text != "")
                {
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_V_SubSubjectID.Text != "0" && lbl_p_V_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_V_TeacherID.Text)
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_V_TeacherID.Text)
                    {
                        e.Row.Cells[10].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[10].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_VI_SubSubjectID.Text == "0" && lbl_p_VI_SubSubjectName.Text != "")
                {
                    e.Row.Cells[11].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_VI_SubSubjectID.Text != "0" && lbl_p_VI_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_VI_TeacherID.Text)
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_VI_TeacherID.Text)
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_VII_SubSubjectID.Text == "0" && lbl_p_VII_SubSubjectName.Text != "")
                {
                    e.Row.Cells[12].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_VII_SubSubjectID.Text != "0" && lbl_p_VII_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_VII_TeacherID.Text)
                    {
                        e.Row.Cells[12].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_VII_TeacherID.Text)
                    {
                        e.Row.Cells[12].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (lbl_p_VIII_SubSubjectID.Text == "0" && lbl_p_VIII_SubSubjectName.Text != "")
                {
                    e.Row.Cells[13].BackColor = System.Drawing.Color.Yellow;
                }
                if (lbl_p_VIII_SubSubjectID.Text != "0" && lbl_p_VIII_SubSubjectName.Text != "")
                {
                    if (ddl_teacherlist.SelectedValue == lbl_p_VIII_TeacherID.Text)
                    {
                        e.Row.Cells[13].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.White;
                    }
                    if (ddl_teacherlist.SelectedValue != lbl_p_VIII_TeacherID.Text)
                    {
                        e.Row.Cells[13].BackColor = System.Drawing.Color.LightGreen;
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (Convert.ToInt32(txt_period.Text == "" ? "0" : txt_period.Text) > 0)
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                }

                if (StatusStatus.Text == "1")
                {
                    chk_status.Checked = true;

                }
                if (StatusStatus.Text == "0")
                {
                    chk_status.Checked = false;

                }
                if (lbl_teacherwiseTeacherID.Text == lbl_teacherid.Text && StatusStatus.Text == "1")
                {
                    chk_status.Enabled = true;
                }
                if (lbl_teacherwiseTeacherID.Text != lbl_teacherid.Text && StatusStatus.Text == "1")
                {
                    chk_status.Enabled = false;
                }
                if (txt_period.Text != "0")
                {
                    txt_period.BackColor = System.Drawing.Color.Green;
                    txt_period.ForeColor = System.Drawing.Color.White;
                }

                Label lbl_category = (Label)e.Row.FindControl("lbl_category");
                if (ddl_category.SelectedValue == lbl_category.Text && ddl_category.SelectedValue != "0")
                {
                    e.Row.Visible = true;
                }
                if (ddl_category.SelectedValue != lbl_category.Text && ddl_category.SelectedValue != "0")
                {
                    e.Row.Visible = false;
                }
                if (ddl_category.SelectedValue == "0")
                {
                    e.Row.Visible = true;
                }



            }

        }

        protected void checksubjt_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((CheckBox)sender).Parent.Parent as GridViewRow;
                int rowindex = row.RowIndex;
                //  GridViewRow row1 = Gv_subsubjectlist.Rows[rowindex];
                Int32 lastindex = Gv_subsubjectlist.Rows.Count - 1;
                int i = 0;
                int p_I = 0;
                int p_II = 0;
                int p_III = 0;
                int p_IV = 0;
                int p_V = 0;
                int p_VI = 0;
                int p_VII = 0;
                int p_VIII = 0;
                int p_IX = 0;
                int p_X = 0;

                int Classwise_Teacher_Period = 0;

                while (i <= lastindex) // condition
                {
                    //MAIN SUBJECT// 
                    Label lbl_p_I_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubjectID");
                    Label lbl_p_II_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubjectID");
                    Label lbl_p_III_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubjectID");
                    Label lbl_p_IV_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubjectID");
                    Label lbl_p_V_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubjectID");
                    Label lbl_p_VI_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubjectID");
                    Label lbl_p_VII_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubjectID");
                    Label lbl_p_VIII_SubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubjectID");

                    //SUB SUBJECT//
                    Label lbl_p_I_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubSubjectID");
                    Label lbl_p_II_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubSubjectID");
                    Label lbl_p_III_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubSubjectID");
                    Label lbl_p_IV_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubSubjectID");
                    Label lbl_p_V_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubSubjectID");
                    Label lbl_p_VI_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubSubjectID");
                    Label lbl_p_VII_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubSubjectID");
                    Label lbl_p_VIII_SubSubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubSubjectID");

                    //PERIODWISE TEACHER ID//
                    Label lbl_p_I_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_TeacherID");
                    Label lbl_p_II_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_TeacherID");
                    Label lbl_p_III_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_TeacherID");
                    Label lbl_p_IV_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_TeacherID");
                    Label lbl_p_V_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_TeacherID");
                    Label lbl_p_VI_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_TeacherID");
                    Label lbl_p_VII_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_TeacherID");
                    Label lbl_p_VIII_TeacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_TeacherID");

                    // PERIODWISE SUBJECTNAME//
                    Label lbl_p_I_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubSubjectName");
                    Label lbl_p_II_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubSubjectName");
                    Label lbl_p_III_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubSubjectName");
                    Label lbl_p_IV_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubSubjectName");
                    Label lbl_p_V_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubSubjectName");
                    Label lbl_p_VI_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubSubjectName");
                    Label lbl_p_VII_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubSubjectName");
                    Label lbl_p_VIII_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubSubjectName");


                    if (Convert.ToInt32(lbl_p_I_SubSubjectID.Text == "" ? "0" : lbl_p_I_SubSubjectID.Text) > 0 && lbl_p_I_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_I = p_I + 1;
                    }
                    if (Convert.ToInt32(lbl_p_II_SubSubjectID.Text == "" ? "0" : lbl_p_II_SubSubjectID.Text) > 0 && lbl_p_II_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_II = p_II + 1;
                    }
                    if (Convert.ToInt32(lbl_p_III_SubSubjectID.Text == "" ? "0" : lbl_p_III_SubSubjectID.Text) > 0 && lbl_p_III_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_III = p_III + 1;
                    }
                    if (Convert.ToInt32(lbl_p_IV_SubSubjectID.Text == "" ? "0" : lbl_p_IV_SubSubjectID.Text) > 0 && lbl_p_IV_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_IV = p_IV + 1;
                    }
                    if (Convert.ToInt32(lbl_p_V_SubSubjectID.Text == "" ? "0" : lbl_p_V_SubSubjectID.Text) > 0 && lbl_p_V_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_V = p_V + 1;
                    }
                    if (Convert.ToInt32(lbl_p_VI_SubSubjectID.Text == "" ? "0" : lbl_p_VI_SubSubjectID.Text) > 0 && lbl_p_VI_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_VI = p_VI + 1;
                    }
                    if (Convert.ToInt32(lbl_p_VII_SubSubjectID.Text == "" ? "0" : lbl_p_VII_SubSubjectID.Text) > 0 && lbl_p_VII_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_VII = p_VII + 1;
                    }
                    if (Convert.ToInt32(lbl_p_VIII_SubSubjectID.Text == "" ? "0" : lbl_p_VIII_SubSubjectID.Text) > 0 && lbl_p_VIII_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                    {
                        p_VII = p_VIII + 1;
                    }


                    //Gv_subsubjectlist.Rows[i].Visible = false;


                    i++;
                }



                Label lbl_p_1_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_I_SubjectID");
                Label lbl_p_1_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_I_SubSubjectID");
                Label lbl_p_1_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_I_SubSubjectName");
                Label lbl_p_1_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_I_TeacherID");

                Label lbl_p_2_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_II_SubjectID");
                Label lbl_p_2_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_II_SubSubjectID");
                Label lbl_p_2_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_II_SubSubjectName");
                Label lbl_p_2_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_II_TeacherID");

                Label lbl_p_3_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_III_SubjectID");
                Label lbl_p_3_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_III_SubSubjectID");
                Label lbl_p_3_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_III_SubSubjectName");
                Label lbl_p_3_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_III_TeacherID");

                Label lbl_p_4_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_IV_SubjectID");
                Label lbl_p_4_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_IV_SubSubjectID");
                Label lbl_p_4_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_IV_SubSubjectName");
                Label lbl_p_4_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_IV_TeacherID");

                Label lbl_p_5_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_V_SubjectID");
                Label lbl_p_5_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_V_SubSubjectID");
                Label lbl_p_5_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_V_SubSubjectName");
                Label lbl_p_5_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_V_TeacherID");

                Label lbl_p_6_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VI_SubjectID");
                Label lbl_p_6_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VI_SubSubjectID");
                Label lbl_p_6_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VI_SubSubjectName");
                Label lbl_p_6_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VI_TeacherID");

                Label lbl_p_7_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VII_SubjectID");
                Label lbl_p_7_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VII_SubSubjectID");
                Label lbl_p_7_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VII_SubSubjectName");
                Label lbl_p_7_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VII_TeacherID");

                Label lbl_p_8_SubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VIII_SubjectID");
                Label lbl_p_8_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VIII_SubSubjectID");
                Label lbl_p_8_SubSubjectName = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VIII_SubSubjectName");
                Label lbl_p_8_TeacherID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VIII_TeacherID");

                Label lbl_classID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_classID");
                Label lbl_sectionID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_sectionID");
                Label lbl_dayID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_dayID");
                Label lbl_teacherid = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_teacherid");
                Label lbl_teachername = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_teacher");
                LinkButton btn_teacher = (LinkButton)Gv_subsubjectlist.Rows[rowindex].FindControl("btn_teacher");
                Label subjectid = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_subjectid");
                Label subsubjectid = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_subsubjectid");
                Label subsubjectname = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_subsubjectname");
                TextBox period = (TextBox)Gv_subsubjectlist.Rows[rowindex].FindControl("txt_period");
                CheckBox chk_ = (CheckBox)Gv_subsubjectlist.Rows[rowindex].FindControl("checksubjt");

                Label ClassTotalPeriod = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_class_totalperiod");

                int CT = Convert.ToInt32(ClassTotalPeriod.Text == "" ? "0" : ClassTotalPeriod.Text);

                int p1 = Convert.ToInt32(lbl_p_1_SubjectID.Text == "" ? "0" : lbl_p_1_SubjectID.Text);


                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");


                if (chk_.Checked == true && p_I == 0 && p1 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 1)
                    {
                        lbl_p_1_SubjectID.Text = subjectid.Text;
                        lbl_p_1_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_1_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_1_SubSubjectName.Text = subsubjectname.Text;
                        btn_teacher.Text = lbl_teachernames.Text;
                        period.Text = "1";
                        row.Cells[6].BackColor = System.Drawing.Color.Green;
                        row.Cells[6].ForeColor = System.Drawing.Color.White;

                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }

                if (chk_.Checked == false && lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_1_SubjectID.Text = "0";
                    lbl_p_1_SubSubjectID.Text = "0";
                    lbl_p_1_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    btn_teacher.Text = "";
                    lbl_p_1_SubSubjectName.Text = CT < 1 ? "" : "1";
                    row.Cells[6].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[6].ForeColor = System.Drawing.Color.Black;
                    period.Text = "";
                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p2 = Convert.ToInt32(lbl_p_2_SubjectID.Text == "" ? "0" : lbl_p_2_SubjectID.Text);

                if (chk_.Checked == true && p_II == 0 && p2 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 2)
                    {
                        lbl_p_2_SubjectID.Text = subjectid.Text;
                        lbl_p_2_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_2_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_2_SubSubjectName.Text = subsubjectname.Text;
                        btn_teacher.Text = lbl_teachernames.Text;
                        period.Text = "2";
                        row.Cells[7].BackColor = System.Drawing.Color.Green;
                        row.Cells[7].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }

                if (chk_.Checked == false && lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_2_SubjectID.Text = "0";
                    lbl_p_2_SubSubjectID.Text = "0";
                    lbl_p_2_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_2_SubSubjectName.Text = CT < 2 ? "" : "2";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[7].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[7].ForeColor = System.Drawing.Color.Black;
                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p3 = Convert.ToInt32(lbl_p_3_SubjectID.Text == "" ? "0" : lbl_p_3_SubjectID.Text);

                if (chk_.Checked == true && p_III == 0 && p3 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 3)
                    {
                        lbl_p_3_SubjectID.Text = subjectid.Text;
                        lbl_p_3_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_3_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_3_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "3";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[8].BackColor = System.Drawing.Color.Green;
                        row.Cells[8].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_3_SubjectID.Text = "0";
                    lbl_p_3_SubSubjectID.Text = "0";
                    lbl_p_3_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_3_SubSubjectName.Text = CT < 3 ? "" : "3";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[8].ForeColor = System.Drawing.Color.Black;

                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                            + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p4 = Convert.ToInt32(lbl_p_4_SubjectID.Text == "" ? "0" : lbl_p_4_SubjectID.Text);

                if (chk_.Checked == true && p_IV == 0 && p4 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 4)
                    {
                        lbl_p_4_SubjectID.Text = subjectid.Text;
                        lbl_p_4_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_4_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_4_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "4";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[9].BackColor = System.Drawing.Color.Green;
                        row.Cells[9].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_4_SubjectID.Text = "0";
                    lbl_p_4_SubSubjectID.Text = "0";
                    lbl_p_4_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_4_SubSubjectName.Text = CT < 4 ? "" : "4";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[9].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[9].ForeColor = System.Drawing.Color.Black;

                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                         + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p5 = Convert.ToInt32(lbl_p_5_SubjectID.Text == "" ? "0" : lbl_p_5_SubjectID.Text);

                if (chk_.Checked == true && p_V == 0 && p5 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 5)
                    {
                        lbl_p_5_SubjectID.Text = subjectid.Text;
                        lbl_p_5_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_5_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_5_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "5";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[10].BackColor = System.Drawing.Color.Green;
                        row.Cells[10].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_5_SubjectID.Text = "0";
                    lbl_p_5_SubSubjectID.Text = "0";
                    lbl_p_5_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_5_SubSubjectName.Text = CT < 5 ? "" : "5";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[10].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[10].ForeColor = System.Drawing.Color.Black;

                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p6 = Convert.ToInt32(lbl_p_6_SubjectID.Text == "" ? "0" : lbl_p_6_SubjectID.Text);

                if (chk_.Checked == true && p_VI == 0 && p6 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 6)
                    {
                        lbl_p_6_SubjectID.Text = subjectid.Text;
                        lbl_p_6_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_6_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_6_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "6";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[11].BackColor = System.Drawing.Color.Green;
                        row.Cells[11].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_6_SubjectID.Text = "0";
                    lbl_p_6_SubSubjectID.Text = "0";
                    lbl_p_6_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_6_SubSubjectName.Text = CT < 6 ? "" : "6";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[11].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[11].ForeColor = System.Drawing.Color.Black;

                }


                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                          + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p7 = Convert.ToInt32(lbl_p_7_SubjectID.Text == "" ? "0" : lbl_p_7_SubjectID.Text);

                if (chk_.Checked == true && p_VII == 0 && p7 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 7)
                    {
                        lbl_p_7_SubjectID.Text = subjectid.Text;
                        lbl_p_7_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_7_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_7_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "7";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[12].BackColor = System.Drawing.Color.Green;
                        row.Cells[12].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_7_SubjectID.Text = "0";
                    lbl_p_7_SubSubjectID.Text = "0";
                    lbl_p_7_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_7_SubSubjectName.Text = CT < 7 ? "" : "7";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[12].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[12].ForeColor = System.Drawing.Color.Black;

                }

                Classwise_Teacher_Period = Convert.ToInt32(lbl_p_1_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_2_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_3_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_4_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_5_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_6_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_7_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0")
                                        + Convert.ToInt32(lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text ? "1" : "0");

                int p8 = Convert.ToInt32(lbl_p_8_SubjectID.Text == "" ? "0" : lbl_p_8_SubjectID.Text);

                if (chk_.Checked == true && p_VIII == 0 && p8 == 0 && Classwise_Teacher_Period == 0)
                {
                    if (CT >= 8)
                    {
                        lbl_p_8_SubjectID.Text = subjectid.Text;
                        lbl_p_8_SubSubjectID.Text = subsubjectid.Text;
                        lbl_p_8_TeacherID.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_teacherid.Text = lbl_teacherwiseTeacherID.Text;
                        lbl_p_8_SubSubjectName.Text = subsubjectname.Text;
                        period.Text = "8";
                        btn_teacher.Text = lbl_teachernames.Text;
                        row.Cells[13].BackColor = System.Drawing.Color.Green;
                        row.Cells[13].ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        chk_.Checked = false;
                        period.Text = "";
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                        Div_period_Planner.Visible = true;
                        if (lastindex - rowindex > 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        if (lastindex - rowindex < 5)
                        {
                            TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                            txt_net.Focus();
                        }
                        return;
                    }
                }
                if (chk_.Checked == false && lbl_p_8_TeacherID.Text == lbl_teacherwiseTeacherID.Text)
                {
                    lbl_p_8_SubjectID.Text = "0";
                    lbl_p_8_SubSubjectID.Text = "0";
                    lbl_p_8_TeacherID.Text = "0";
                    lbl_teacherid.Text = "0";
                    lbl_p_8_SubSubjectName.Text = CT < 8 ? "" : "8";
                    period.Text = "";
                    btn_teacher.Text = "";
                    row.Cells[13].BackColor = System.Drawing.Color.Yellow;
                    row.Cells[13].ForeColor = System.Drawing.Color.Black;

                }
                if (lastindex - rowindex > 5)
                {
                    TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                    txt_net.Focus();
                }
                if (lastindex - rowindex < 5)
                {
                    TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                    txt_net.Focus();
                }
                Div_period_Planner.Visible = true;
            }
            catch (Exception mesg)
            {


            }
        }
        protected void btn_teacher_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label lbl_teacher = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_teacher");
            idsearch.Value = lbl_teacher.Text;
            idsearch.Focus();
            this.ModalPopupExtender2.Hide();

            Div_period_Planner.Visible = true;
        }

        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subjectid = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            int teacherid = Convert.ToInt32(lbl_teacherwiseTeacherID.Text == "" ? "0" : lbl_teacherwiseTeacherID.Text);
            int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);

            bindassignsubjectlist(subjectid, dayid, teacherid);

            Div_period_Planner.Visible = true;
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int32 lastindex = Gv_subsubjectlist.Rows.Count - 1;
            //int i = 0;
            //while (i <= lastindex) // condition
            //{
            //    //MAIN SUBJECT// 
            //    Label lbl_category = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_category");

            //    if (ddl_category.SelectedValue == lbl_category.Text && ddl_category.SelectedValue != "0")
            //    {
            //        Gv_subsubjectlist.Rows[i].Visible = true;
            //    }
            //    if (ddl_category.SelectedValue != lbl_category.Text && ddl_category.SelectedValue != "0")
            //    {
            //        Gv_subsubjectlist.Rows[i].Visible = false;
            //    }
            //    if (ddl_category.SelectedValue == "0")
            //    {
            //        Gv_subsubjectlist.Rows[i].Visible = true;
            //    }
            //    i++;
            //}
            int subjectid = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            int teacherid = Convert.ToInt32(lbl_teacherwiseTeacherID.Text == "" ? "0" : lbl_teacherwiseTeacherID.Text);
            int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            bindassignsubjectlist(subjectid, dayid, teacherid);
            Getteacherlist(subjectid, dayid);
            Div_period_Planner.Visible = true;
        }


        protected void ddl_teacherlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = ((DropDownList)sender).Parent.Parent as GridViewRow;
                int rowindex = row.RowIndex;
                int countclassAssign = 0;
                DropDownList ddl_teacherlist = (DropDownList)Gv_subsubjectlist.Rows[rowindex].FindControl("ddl_teacherlist");
                Label lbl_teacherids = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_teacherid");
                TextBox txt_periods = (TextBox)Gv_subsubjectlist.Rows[rowindex].FindControl("txt_period");
                string teacherid = "0";

                if (ddl_teacherlist.SelectedIndex > 0)
                {
                    teacherid = ddl_teacherlist.Text;
                }
                if (ddl_teacherlist.SelectedIndex == 0)
                {
                    teacherid = lbl_teacherids.Text;
                    lbl_teacherids.Text = "0";
                    txt_periods.Text = "";
                }

                //int i = 0;
                Int32 lastindex = Gv_subsubjectlist.Rows.Count - 1;
                //while (i < lastindex)
                //{
                //    Label lbl_teacherid = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_teacherid");
                //    TextBox txt_period = (TextBox)Gv_subsubjectlist.Rows[i].FindControl("txt_period");
                //    DropDownList ddl_selectteacher = (DropDownList)Gv_subsubjectlist.Rows[i].FindControl("ddl_teacherlist");
                //    if (ddl_selectteacher.SelectedValue == teacherid)
                //    {
                //        lbl_teacherid.Text = ddl_selectteacher.SelectedValue;
                //        countclassAssign = countclassAssign + 1;
                //        txt_period.Text = countclassAssign.ToString();
                //    }

                //    i++;
                //}

                PeriodplannerBO objBO = new PeriodplannerBO();
                TeacherWisePeriod objdata = new TeacherWisePeriod();
                List<TeacherWisePeriod> subjectlist = new List<TeacherWisePeriod>();


                Label lbl_subjectid = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_subjectid");

                Label lbl_subsubjectid = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_subsubjectid");
                Label lbl_dayID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_dayID");
                Label lbl_classID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_classID");
                Label lbl_sectionIDs = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_sectionID");
                Label totalperiod = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_class_totalperiod");
                TextBox txt_periodno = (TextBox)Gv_subsubjectlist.Rows[rowindex].FindControl("txt_period");

                Label lbl_p_I_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_I_SubSubjectID");
                Label lbl_p_II_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_II_SubSubjectID");
                Label lbl_p_III_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_III_SubSubjectID");
                Label lbl_p_IV_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_IV_SubSubjectID");
                Label lbl_p_V_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_V_SubSubjectID");
                Label lbl_p_VI_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VI_SubSubjectID");
                Label lbl_p_VII_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VII_SubSubjectID");
                Label lbl_p_VIII_SubSubjectID = (Label)Gv_subsubjectlist.Rows[rowindex].FindControl("lbl_p_VIII_SubSubjectID");

                int p1 = (Convert.ToInt32(lbl_p_I_SubSubjectID.Text == "0" ? "0" : lbl_p_I_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p2 = (Convert.ToInt32(lbl_p_II_SubSubjectID.Text == "0" ? "0" : lbl_p_II_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p3 = (Convert.ToInt32(lbl_p_III_SubSubjectID.Text == "0" ? "0" : lbl_p_III_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p4 = (Convert.ToInt32(lbl_p_IV_SubSubjectID.Text == "0" ? "0" : lbl_p_IV_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p5 = (Convert.ToInt32(lbl_p_V_SubSubjectID.Text == "0" ? "0" : lbl_p_V_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p6 = (Convert.ToInt32(lbl_p_VI_SubSubjectID.Text == "0" ? "0" : lbl_p_VI_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p7 = (Convert.ToInt32(lbl_p_VII_SubSubjectID.Text == "0" ? "0" : lbl_p_VII_SubSubjectID.Text)) == 0 ? 0 : 1;
                int p8 = (Convert.ToInt32(lbl_p_VIII_SubSubjectID.Text == "0" ? "0" : lbl_p_VIII_SubSubjectID.Text)) == 0 ? 0 : 1;

                //int total = Convert.ToInt32(totalperiod.Text == "" ? "0" : totalperiod.Text) - (p1+ p2+ p3+ p4+ p5+ p6+ p7+ p8);

                //if (countclassAssign == 1 && p1 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 2 && p2 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 3 && p3 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign ==4 && p4 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 5 && p5 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 6 && p6 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 6 && p6 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 7 && p7 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                //if (countclassAssign == 8 && p8 != 0)
                //{
                //    txt_periodno.Text = "";
                //    ddl_teacherlist.SelectedIndex = 0;
                //    lbl_teacherids.Text = "";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Expected period number exceeds the available slots.") + "')", true);
                //    this.ModalPopupExtender3.Show();
                //}
                objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                objdata.SubjectID = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
                objdata.SubSubjectID = Convert.ToInt32(lbl_subsubjectid.Text == "" ? "0" : lbl_subsubjectid.Text);
                objdata.DayID = Convert.ToInt32(lbl_dayID.Text == "" ? "0" : lbl_dayID.Text);
                objdata.TeacherID = Convert.ToInt32(ddl_teacherlist.Text == "" ? "0" : ddl_teacherlist.Text);
                objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
                objdata.ClassID = Convert.ToInt32(lbl_classID.Text == "" ? "0" : lbl_classID.Text);
                objdata.SectionID = Convert.ToInt32(lbl_sectionIDs.Text == "" ? "0" : lbl_sectionIDs.Text);
                objdata.PeriodNo = Convert.ToInt32(txt_periodno.Text == "" ? "0" : txt_periodno.Text);
                int result = objBO.UpdateTeachererAssignClass(objdata);
                if (result == 1)
                {
                    int subjectid = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
                    int dayid = Convert.ToInt32(lbl_dayID.Text == "" ? "0" : lbl_dayID.Text);
                    int Teachrerids = Convert.ToInt32(ddl_subjectwiseteacher.SelectedValue == "" ? "0" : ddl_subjectwiseteacher.SelectedValue);
                    bindassignsubjectlist(subjectid, dayid, Teachrerids);
                    Getteacherlist(subjectid, dayid);
                    //ddl_subjectwiseteacher.SelectedValue = ddl_teacherlist.Text;
                    Div_period_Planner.Visible = true;
                }
                ddl_teacherlist.Focus();

                if (lastindex - rowindex > 5)
                {
                    TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[rowindex + 5].FindControl("txt_focus");
                    txt_net.Focus();
                }
                if (lastindex - rowindex < 5)
                {
                    TextBox txt_net = (TextBox)Gv_subsubjectlist.Rows[lastindex].FindControl("txt_focus");
                    txt_net.Focus();
                }

            }
            catch (Exception mesg)
            {


            }
        }

        protected void btn_gen_Click(object sender, EventArgs e)
        {
            PeriodplannerBO objBO = new PeriodplannerBO();
            TeacherWisePeriod objdata = new TeacherWisePeriod();
            List<TeacherWisePeriod> subjectlist = new List<TeacherWisePeriod>();

            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.DayID = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            int result = objBO.GenerateTimetable(objdata);
            if (result == 1)
            {
                int subjectid = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
                int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
                int teacherid = Convert.ToInt32(ddl_subjectwiseteacher.SelectedValue == "" ? "0" : ddl_subjectwiseteacher.SelectedValue);
                bindassignsubjectlist(subjectid, dayid, teacherid);
                Getteacherlist(subjectid, dayid);
                Div_period_Planner.Visible = true;
            }
        }
        protected void ddl_subjectwiseteacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subjectid = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            int teacherID = Convert.ToInt32(ddl_subjectwiseteacher.SelectedValue == "" ? "0" : ddl_subjectwiseteacher.SelectedValue);
            bindassignsubjectlist(subjectid, dayid, teacherID);
            Getteacherlist(subjectid, dayid);
            Div_period_Planner.Visible = true;
        }

        protected void txt_periodcount_TextChanged(object sender, EventArgs e)
        {
            //GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            //int rowindex = row.RowIndex;
            //Int32 lastindex = gv_teacherlist.Rows.Count - 1;
            //PeriodplannerBO objBO = new PeriodplannerBO();
            //TeacherWisePeriod objdata = new TeacherWisePeriod();
            //List<TeacherWisePeriod> subjectlist = new List<TeacherWisePeriod>();

            //Label lbl_subjectid = (Label)gv_teacherlist.Rows[rowindex].FindControl("lbl_subjectid");
            //Label lbl_teacherid = (Label)gv_teacherlist.Rows[rowindex].FindControl("lbl_teacherid");
            //Label lbl_dayids = (Label)gv_teacherlist.Rows[rowindex].FindControl("lbl_dayid");
            //TextBox txt_periodcount = (TextBox)gv_teacherlist.Rows[rowindex].FindControl("txt_periodcount");

            //objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            //objdata.DayID = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            //objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            //objdata.SubjectID = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            //objdata.TeacherID = Convert.ToInt32(lbl_teacherid.Text == "" ? "0" : lbl_teacherid.Text);
            //objdata.PeriodCount = Convert.ToInt32(txt_periodcount.Text == "" ? "0" : txt_periodcount.Text);
            //int result = objBO.Teacherautodistributeclasses(objdata);
            //if (result == 1)
            //{
            //    int subjectid = Convert.ToInt32(lbl_teacherwisesubjectid.Text == "" ? "0" : lbl_teacherwisesubjectid.Text);
            //    int dayid = Convert.ToInt32(lbl_dayid.Text == "" ? "0" : lbl_dayid.Text);
            //    int teacherid = Convert.ToInt32(ddl_subjectwiseteacher.SelectedValue == "" ? "0" : ddl_subjectwiseteacher.SelectedValue);
            //    // bindassignsubjectlist(subjectid, dayid, teacherid);
            //    Getteacherlist(subjectid, dayid);
            //    if (lastindex - rowindex > 1)
            //    {
            //        TextBox txt_next = (TextBox)gv_teacherlist.Rows[rowindex + 1].FindControl("txt_periodcount");
            //        txt_next.Focus();
            //        Div_period_Planner.Visible = true;
            //    }
            //    if (lastindex - rowindex == 1)
            //    {
            //        TextBox txt_next = (TextBox)gv_teacherlist.Rows[lastindex].FindControl("txt_periodcount");
            //        txt_next.Focus();
            //        Div_period_Planner.Visible = true;
            //    }
            //    if (lastindex - rowindex == 0)
            //    {
            //        TextBox txt_next = (TextBox)gv_teacherlist.Rows[0].FindControl("txt_periodcount");
            //        txt_next.Focus();
            //        Div_period_Planner.Visible = true;
            //    }
            //    Div_period_Planner.Visible = true;
            //}
            //Div_period_Planner.Visible = true;
            //btnopen3.Focus();

            try
            {
                GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;

                int rowindex = row.RowIndex;
                Int32 glastindex = gv_teacherlist.Rows.Count - 1;


                Int32 lastindex = Gv_subsubjectlist.Rows.Count - 1;

                TextBox txt_periodcount = (TextBox)gv_teacherlist.Rows[rowindex].FindControl("txt_periodcount");

                Label teacherID = (Label)gv_teacherlist.Rows[rowindex].FindControl("lbl_teacherid");

                int perioc_count = Convert.ToInt32(txt_periodcount.Text == "" ? "0" : txt_periodcount.Text);
                int i = 0;
                int total_assign_class = 0;


                int p_I = 0;
                int p_II = 0;
                int p_III = 0;
                int p_IV = 0;
                int p_V = 0;
                int p_VI = 0;
                int p_VII = 0;
                int p_VIII = 0;

                while (i <= lastindex)
                {
                    Label Class_ID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_classID");
                    Label Section_ID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_sectionID");

                    Label class_teacherid = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_teacherid");
                    Label class_subjectid = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_subjectid");
                    Label class_subjsubjectid = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_subsubjectid");
                    Label Class_totalperiod = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_class_totalperiod");
                    TextBox period_number = (TextBox)Gv_subsubjectlist.Rows[i].FindControl("txt_period");
                    DropDownList ddl_teacherlist = (DropDownList)Gv_subsubjectlist.Rows[i].FindControl("ddl_teacherlist");


                    Label lbl_subsubjectname = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_subsubjectname");

                    Label p_I_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_TeacherID");
                    Label p_I_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubjectID");
                    Label p_I_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubSubjectID");
                    Label p_I_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_I_SubSubjectName");

                    Label p_II_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_TeacherID");
                    Label p_II_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubjectID");
                    Label p_II_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubSubjectID");
                    Label p_II_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_II_SubSubjectName");

                    Label p_III_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_TeacherID");
                    Label p_III_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubjectID");
                    Label p_III_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubSubjectID");
                    Label p_III_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_III_SubSubjectName");

                    Label p_IV_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_TeacherID");
                    Label p_IV_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubjectID");
                    Label p_IV_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubSubjectID");
                    Label p_IV_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_IV_SubSubjectName");

                    Label p_V_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_TeacherID");
                    Label p_V_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubjectID");
                    Label p_V_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubSubjectID");
                    Label p_V_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_V_SubSubjectName");

                    Label p_VI_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_TeacherID");
                    Label p_VI_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubjectID");
                    Label p_VI_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubSubjectID");
                    Label p_VI_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VI_SubSubjectName");

                    Label p_VII_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_TeacherID");
                    Label p_VII_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubjectID");
                    Label p_VII_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubSubjectID");
                    Label p_VII_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VII_SubSubjectName");

                    Label p_VIII_teacherID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_TeacherID");
                    Label p_VIII_subjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubjectID");
                    Label p_VIII_SubsubjectID = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubSubjectID");
                    Label p_VIII_SubSubjectName = (Label)Gv_subsubjectlist.Rows[i].FindControl("lbl_p_VIII_SubSubjectName");


                    int totalperiod = 0;
                    totalperiod = Convert.ToInt32(Class_totalperiod.Text == "" ? "0" : Class_totalperiod.Text);

                    int check_teacherexist = 0;

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       ;

                    if (p_I == 0 && check_teacherexist == 0 && totalperiod >= 1 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_I_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_I_subjectID.Text = class_subjectid.Text;
                        p_I_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_I_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "1";
                        Gv_subsubjectlist.Rows[i].Cells[6].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[6].ForeColor = System.Drawing.Color.White;
                        total_assign_class = total_assign_class + 1;
                        ddl_teacherlist.SelectedValue = teacherID.Text;

                    }
                    if (Convert.ToInt32(p_I_subjectID.Text == "" ? "0" : p_I_subjectID.Text) > 0 && p_I_teacherID.Text == teacherID.Text)
                    {
                        p_I = p_I + 1;
                    }

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       ;

                    if (p_II == 0 && check_teacherexist == 0 && totalperiod >= 2 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_II_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_II_subjectID.Text = class_subjectid.Text;
                        p_II_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_II_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "2";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[7].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[7].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_II_subjectID.Text == "" ? "0" : p_II_subjectID.Text) > 0 && p_II_teacherID.Text == teacherID.Text)
                    {
                        p_II = p_II + 1;
                    }


                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       ;

                    if (p_III == 0 && check_teacherexist == 0 && totalperiod >= 3 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_III_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_III_subjectID.Text = class_subjectid.Text;
                        p_III_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_III_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "3";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[8].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[8].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_III_subjectID.Text == "" ? "0" : p_III_subjectID.Text) > 0 && p_III_teacherID.Text == teacherID.Text)
                    {
                        p_III = p_III + 1;
                    }


                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                       ;

                    if (p_IV == 0 && check_teacherexist == 0 && totalperiod >= 4 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_IV_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_IV_subjectID.Text = class_subjectid.Text;
                        p_IV_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_IV_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "4";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[9].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[9].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_IV_subjectID.Text == "" ? "0" : p_IV_subjectID.Text) > 0 && p_IV_teacherID.Text == teacherID.Text)
                    {
                        p_IV = p_IV + 1;
                    }

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                     + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                     ;

                    if (p_V == 0 && check_teacherexist == 0 && totalperiod >= 5 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_V_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_V_subjectID.Text = class_subjectid.Text;
                        p_V_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_V_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "5";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[10].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[10].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_V_subjectID.Text == "" ? "0" : p_V_subjectID.Text) > 0 && p_V_teacherID.Text == teacherID.Text)
                    {
                        p_V = p_V + 1;
                    }

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                    + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                    ;

                    if (p_VI == 0 && check_teacherexist == 0 && totalperiod >= 6 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_VI_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_VI_subjectID.Text = class_subjectid.Text;
                        p_VI_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_VI_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "6";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[11].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[11].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_VI_subjectID.Text == "" ? "0" : p_VI_subjectID.Text) > 0 && p_VI_teacherID.Text == teacherID.Text)
                    {
                        p_VI = p_VI + 1;
                    }

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                 + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                 ;

                    if (p_VII == 0 && check_teacherexist == 0 && totalperiod >= 7 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_VII_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_VII_subjectID.Text = class_subjectid.Text;
                        p_VII_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_VII_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "7";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[12].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[12].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_VII_subjectID.Text == "" ? "0" : p_VII_subjectID.Text) > 0 && p_VII_teacherID.Text == teacherID.Text)
                    {
                        p_VII = p_VII + 1;
                    }

                    check_teacherexist = Convert.ToInt32(p_I_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_II_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_III_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_IV_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_V_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_VI_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_VII_teacherID.Text == teacherID.Text ? "1" : "0")
                                + Convert.ToInt32(p_VIII_teacherID.Text == teacherID.Text ? "1" : "0")
                                ;

                    if (p_VIII == 0 && check_teacherexist == 0 && totalperiod >= 8 && ddl_teacherlist.SelectedValue == "0")
                    {
                        p_VIII_teacherID.Text = teacherID.Text;
                        class_teacherid.Text = teacherID.Text;
                        p_VIII_subjectID.Text = class_subjectid.Text;
                        p_VIII_SubsubjectID.Text = class_subjsubjectid.Text;
                        p_VIII_SubSubjectName.Text = lbl_subsubjectname.Text;
                        period_number.Text = "8";
                        ddl_teacherlist.SelectedValue = teacherID.Text;
                        total_assign_class = total_assign_class + 1;
                        Gv_subsubjectlist.Rows[i].Cells[13].BackColor = System.Drawing.Color.Green;
                        Gv_subsubjectlist.Rows[i].Cells[13].ForeColor = System.Drawing.Color.White;

                    }
                    if (Convert.ToInt32(p_VIII_subjectID.Text == "" ? "0" : p_VIII_subjectID.Text) > 0 && p_VIII_teacherID.Text == teacherID.Text)
                    {
                        p_VIII = p_VIII + 1;
                    }

                    i++;

                    if (perioc_count == total_assign_class)
                    {
                        break;
                    }

                }
                if (glastindex - rowindex > 1)
                {
                    TextBox txt_next = (TextBox)gv_teacherlist.Rows[rowindex + 1].FindControl("txt_periodcount");
                    txt_next.Focus();
                    Div_period_Planner.Visible = true;
                }
                if (glastindex - rowindex == 1)
                {
                    TextBox txt_next = (TextBox)gv_teacherlist.Rows[glastindex].FindControl("txt_periodcount");
                    txt_next.Focus();
                    Div_period_Planner.Visible = true;
                }
                if (glastindex - rowindex == 0)
                {
                    TextBox txt_next = (TextBox)gv_teacherlist.Rows[0].FindControl("txt_periodcount");
                    txt_next.Focus();
                    Div_period_Planner.Visible = true;
                }

            }
            catch (Exception mesg)
            {


            }


        }


    }
}