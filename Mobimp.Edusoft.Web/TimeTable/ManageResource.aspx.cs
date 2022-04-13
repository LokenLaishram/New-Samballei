using Mobimp.Campusoft.BussinessProcess.TimeTable;
using Mobimp.Campusoft.Data.TimeTable;
using Mobimp.Edusoft.BussinessProcess.Common;
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
    public partial class ManageResource : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddropdownlist();
                // BindGrid(1);
                divsearch.Visible = false;
            }
        }
        protected void binddropdownlist()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.TimeTableGroup));
            //Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetLookupsList(LookupNames.Subject));
            // Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            Commonfunction.Insertzeroitemindex(ddl_teacher);
            Commonfunction.Insertzeroitemindex(ddl_subject);
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_TimeTable.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_TimeTable.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
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
            //if (ddl_teacher.SelectedIndex == 0)
            //{
            //    Gv_TimeTable.DataSource = null;
            //    Gv_TimeTable.DataBind();
            //    lblresult.Visible = false;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select teacher.") + "')", true);
            //    return;
            //}
            if (ddl_day.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select day.") + "')", true);
                return;
            }

            if (ddl_subject.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select subject.") + "')", true);
                return;
            }

            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TimeTableData> result = Getteacherwiseallotedclass(index, pagesize);
            if (result.Count > 0)
            {

                Gv_TimeTable.Visible = true;
                Gv_TimeTable.PageSize = pagesize;
                // lbl_maxperiod.Text = result[0].MaxPeriodalowed.ToString();
                string record = result.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result.Count.ToString() + " " + record;
                lbl_totalrecords.Text = result.Count.ToString();
                lblresult.Visible = true;
                Gv_TimeTable.VirtualItemCount = result.Count;//total item is required for custom paging
                Gv_TimeTable.PageIndex = index - 1;
                Gv_TimeTable.DataSource = result;
                Gv_TimeTable.DataBind();
                // bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
                divsearch.Visible = true;
                bindteacherassignsubjectlist();

            }
            else
            {
                divsearch.Visible = false;
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                Gv_TimeTable.Visible = true;
                lblresult.Visible = false;
                // lbl_maxperiod.Text = "0";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please do class subject allocation for this teacher.") + "')", true);
                return;
            }
        }
        public List<TimeTableData> Getteacherwiseallotedclass(int curIndex, int pagesize)
        {
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objdata.DayID = Convert.ToInt32(ddl_day.SelectedValue == "" ? "0" : ddl_day.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue);
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objBO.GetTeacherwiseClass(objdata);
        }
        protected void bindteacherassignsubjectlist()
        {
            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objdata.DayID = Convert.ToInt32(ddl_day.SelectedValue == "" ? "0" : ddl_day.SelectedValue);
            objdata.EmployeeID = LoginToken.EmployeeID;
            List<TimeTableData> list = objBO.GetTeacherwiseassignsubjectlist(objdata);
            if (list.Count > 0)
            {
                gv_allotedsubjectlist.DataSource = list;
                gv_allotedsubjectlist.DataBind();
            }
            else
            {
                gv_allotedsubjectlist.DataSource = null;
                gv_allotedsubjectlist.DataBind();

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
        int countsectionID = 1;
        string classID = "";
        string sectionID = "";
        int allotedperiod = 0;
        protected void Gv_TimeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ID = (Label)e.Row.FindControl("lbl_sectionID");
                Label Class = (Label)e.Row.FindControl("lbl_class");
                Label lbl_ClassID = (Label)e.Row.FindControl("lbl_classID");
                Label SectionName = (Label)e.Row.FindControl("lbl_section");
                Label allotedsubject = (Label)e.Row.FindControl("lbl_alloted");
                Label allotedteacher = (Label)e.Row.FindControl("lbl_allotedtecherid");
                Label periodcount = (Label)e.Row.FindControl("lbl_periodcount");
                Label PeriodNo = (Label)e.Row.FindControl("lbl_period");
                DropDownList ddl_subject = (DropDownList)e.Row.FindControl("ddl_sbject");
                DropDownList ddl_gridteacher = (DropDownList)e.Row.FindControl("ddl_gridteacher");
                Label allotedSubjectID = (Label)e.Row.FindControl("lbl_subjectid");
                Label mainsubjectid = (Label)e.Row.FindControl("lbl_mainsubjectid");
                Label mainsubjectids = (Label)e.Row.FindControl("lbl_maonsubjectids");

                if (Convert.ToInt32(PeriodNo.Text) > Convert.ToInt32(periodcount.Text))
                {
                    ddl_subject.Visible = false;
                    ddl_gridteacher.Visible = false;

                }
                else
                {
                    ddl_subject.Visible = true;
                    ddl_gridteacher.Visible = true;
                    MasterLookupBO mstlookup = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddl_gridteacher, mstlookup.GetGridsystemgenratedSubjectwiseteacher(Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
                    //Commonfunction.TimetablePopulateDdl(ddl_subject, mstlookup.GetassignedSubjectList(Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(lbl_ClassID.Text == "" ? "0" : lbl_ClassID.Text), Convert.ToInt32(ID.Text == "" ? "0" : ID.Text)));
                }
                //if (allotedSubjectID.Text != "0" && allotedteacher.Text != "0")
                //{
                //    ddl_subject.SelectedValue = allotedSubjectID.Text;
                //    if (allotedteacher.Text != ddl_teacher.SelectedValue)
                //    {
                //        ddl_subject.Visible = false;
                //        ddl_subject.Attributes["disabled"] = "disabled";
                //    }
                //    else
                //    {
                //        ddl_subject.Visible = true;
                //        ddl_subject.Attributes.Remove("disabled");
                //    }
                //}

                //if (allotedteacher.Text == ddl_teacher.SelectedValue)
                //{
                //    allotedperiod = allotedperiod + 1;
                //    e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                //    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                //}
                //if (allotedteacher.Text == "0" && mainsubjectids.Text.Contains(mainsubjectid.Text))
                //{
                //    e.Row.Cells[5].BackColor = System.Drawing.Color.Yellow;
                //    e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                //}
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
            }
            ////lbl_allotedPeriod.Text = allotedperiod.ToString();
            //if (Convert.ToInt32(lbl_maxperiod.Text == "" ? "0" : lbl_maxperiod.Text) > Convert.ToInt32(lbl_allotedPeriod.Text == "" ? "0" : lbl_allotedPeriod.Text))
            //{
            //    lbl_remaiinigperiod.Text = (Convert.ToInt32(lbl_maxperiod.Text == "" ? "0" : lbl_maxperiod.Text) - Convert.ToInt32(lbl_allotedPeriod.Text == "" ? "0" : lbl_allotedPeriod.Text)).ToString();
            //}
            //else
            //{
            //    lbl_remaiinigperiod.Text = "0";
            //}
        }
        protected void ddl_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_day.SelectedIndex > 0)
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetTimetableGetSubjectList(Convert.ToInt32(ddl_day.SelectedValue == "" ? "0" : ddl_day.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddl_subject);
            }
            BindGrid(1);

        }
        protected void ddlAcademicSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_sbject_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((DropDownList)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            int lastindex = Gv_TimeTable.Rows.Count - 1;

            Label AllotedsubjectID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_subjectid");
            Label ClassID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_classID");
            Label SectionID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_sectionID");
            Label ID = (Label)Gv_TimeTable.Rows[rowindex].FindControl("ID");
            Label AllotedTeacher = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_allotedtecherid");
            Label PeriodNo = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_period");
            DropDownList ddl_newsubjectID = (DropDownList)Gv_TimeTable.Rows[rowindex].FindControl("ddl_sbject");

            TimeTableData objdata = new TimeTableData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.ID = Convert.ToInt32(ID.Text == "" ? "0" : ID.Text);
            objdata.AllocatedSubject = Convert.ToInt32(AllotedsubjectID.Text == "" ? "0" : AllotedsubjectID.Text);
            objdata.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
            objdata.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
            objdata.SubjectID = Convert.ToInt32(ddl_newsubjectID.SelectedValue == "" ? "0" : ddl_newsubjectID.SelectedValue);
            objdata.PeriodNo = PeriodNo.Text == "" ? "0" : PeriodNo.Text;
            objdata.DayID = Convert.ToInt32(ddl_day.SelectedValue == "" ? "0" : ddl_day.SelectedValue);
            if (ddl_newsubjectID.SelectedIndex > 0)
            {
                objdata.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            }
            objdata.AllocatedTeacher = Convert.ToInt32(AllotedTeacher.Text == "" ? "0" : AllotedTeacher.Text);
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.Text == "" ? "0" : ddlAcademicSessionID.Text);
            objdata.GroupID = Convert.ToInt32(ddl_group.Text == "" ? "0" : ddl_group.Text);
            int result = objBO.UpdateAllotedsubjectTeacher(objdata);
            if (result == 1)
            {
                BindGrid(1);
                if (lastindex - rowindex > 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[rowindex + 5].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }
                if (lastindex - rowindex < 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[lastindex].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }

            }
            if (result == 2)
            {
                ddl_newsubjectID.SelectedIndex = 0;
                BindGrid(1);
                if (lastindex - rowindex > 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[rowindex + 5].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }
                if (lastindex - rowindex < 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[lastindex].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Exceeds the maximum period permitted for this subject.") + "')", true);
                return;
            }
            if (result == 3)
            {
                BindGrid(1);
                if (lastindex - rowindex > 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[rowindex + 5].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }
                if (lastindex - rowindex < 5)
                {
                    DropDownList ddlnext = (DropDownList)Gv_TimeTable.Rows[lastindex].FindControl("ddl_sbject");
                    ddlnext.Focus();
                }
                ddl_newsubjectID.SelectedIndex = 0;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This time slot is already alloted in another class or section or same  by the selected resource. Please reset the slot or select another slot and then try.") + "')", true);
                return;
            }
        }
        protected void btn_teacher_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label AllotedTeacher = (Label)Gv_TimeTable.Rows[rowindex].FindControl("lbl_allotedtecherid");
            ddl_teacher.SelectedValue = AllotedTeacher.Text.ToString();
            BindGrid(1);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            string Teacher = ddl_teacher.SelectedValue;
            string Group = ddl_group.SelectedValue;
            String Year = ddlAcademicSessionID.SelectedValue;
            string url = "../TimeTable/Reports/ReportViewer.aspx?option=TeacherTimeTable&Session=" + Year + "&GroupID=" + Group + "&TeacherID=" + Teacher;
            string fullURL = "window.open('" + url + "', '_blank');";

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);

        }

        protected void btn_planner_Click(object sender, EventArgs e)
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
            if (ddl_teacher.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select teacher.") + "')", true);
                return;
            }
            if (ddl_day.SelectedIndex == 0)
            {
                Gv_TimeTable.DataSource = null;
                Gv_TimeTable.DataBind();
                lblresult.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select day.") + "')", true);
                return;
            }
            lbl_teachername.Text = ddl_teacher.SelectedItem.Text + " , Day : " + ddl_day.SelectedItem.Text;
            ModalPopupExtender3.Show();
        }

        protected void btn_period_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label Section = (Label)gv_allotedsubjectlist.Rows[rowindex].FindControl("lbl_section");
            Label Period = (Label)gv_allotedsubjectlist.Rows[rowindex].FindControl("lbl_period");
            Label subject = (Label)gv_allotedsubjectlist.Rows[rowindex].FindControl("lbl_alloted");

            int j = 0; // initialization
            Int32 lastindex = Gv_TimeTable.Rows.Count - 1;
            while (j <= lastindex) // condition
            {
                Label TSection = (Label)Gv_TimeTable.Rows[j].FindControl("lbl_section");
                Label TPeriod = (Label)Gv_TimeTable.Rows[j].FindControl("lbl_period");
                if (TSection.Text == Section.Text && TPeriod.Text == Period.Text)
                {
                    DropDownList ddl_subject = (DropDownList)Gv_TimeTable.Rows[j].FindControl("ddl_sbject");
                    Label timeslot = (Label)Gv_TimeTable.Rows[j].FindControl("lbl_timeslot");
                    timeslot.BackColor = System.Drawing.Color.Green;
                    timeslot.ForeColor = System.Drawing.Color.White;
                    ddl_subject.Focus();
                    break;
                }
                else
                {
                    j++;
                }
            }

        }

        protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetsystemgenratedSubjectwiseteacher(Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue)));
            BindGrid(1);
        }
    }
}