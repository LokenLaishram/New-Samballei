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
    public partial class TeacherClassSubjectMapping : BasePage
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
            Commonfunction.Insertzeroitemindex(ddl_sections);
            Commonfunction.PopulateDdl(ddl_group, mstlookup.GetLookupsList(LookupNames.TimeTableGroup));
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_periodplanner.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_periodplanner.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
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
            Gv_periodplanner.UseAccessibleHeader = true;
            Gv_periodplanner.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCell tableCell = Gv_periodplanner.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        protected void bindgridfoucs()
        {
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[3].FindControl("txt_setpriod") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[3].FindControl("txt_setpriod") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[4].FindControl("txt_sunday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[4].FindControl("txt_sunday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[5].FindControl("txt_monday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[5].FindControl("txt_monday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[6].FindControl("txt_tuesday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[6].FindControl("txt_tuesday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[7].FindControl("txt_wednesday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[7].FindControl("txt_wednesday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[8].FindControl("txt_thursday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[8].FindControl("txt_thursday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[9].FindControl("txt_friday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[9].FindControl("txt_friday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
            for (int i = 0; i < Gv_periodplanner.Rows.Count - 1; i++)
            {
                TextBox curTexbox = Gv_periodplanner.Rows[i].Cells[10].FindControl("txt_saturday") as TextBox;
                TextBox nexTextbox = Gv_periodplanner.Rows[i + 1].Cells[10].FindControl("txt_saturday") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = Gv_periodplanner.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btnupdate.ClientID + "', event)");
                }
            }
        }
        private void BindGrid(int index)
        {

            if (ddlAcademicSessionID.SelectedIndex == 0)
            {
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                lblresult.Visible = false;
                btnupdate.Visible = false;
                btn_section.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select session.") + "')", true);
                return;
            }
            if (ddl_group.SelectedIndex == 0)
            {
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                lblresult.Visible = false;
                btnupdate.Visible = false;
                btn_section.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select group.") + "')", true);
                return;
            }
            if (ddl_class.SelectedIndex == 0)
            {
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                lblresult.Visible = false;
                btnupdate.Visible = false;
                btn_section.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select class.") + "')", true);
                return;
            }
            if (ddl_sections.SelectedIndex == 0)
            {
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                lblresult.Visible = false;
                btnupdate.Visible = false;
                btn_section.Visible = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select section.") + "')", true);
                return;
            }

            ClasswisePeriodPlannerData objdata = new ClasswisePeriodPlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            Gv_periodplanner.PageSize = pagesize;
            List<ClasswisePeriodPlannerData> result = Getsubjectwiseperiodlist(index, pagesize);
            if (result.Count > 0)
            {
                if (result[0].classname == null)
                {
                    divsearch.Visible = false;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("No time table rule for this class. ") + "')", true);
                    return;
                }
                else
                {
                    Gv_periodplanner.Visible = true;
                    string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                    lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                    lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                    lblresult.Visible = true;
                    Gv_periodplanner.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                    Gv_periodplanner.PageIndex = index - 1;
                    Gv_periodplanner.DataSource = result;
                    Gv_periodplanner.DataBind();
                    bindresponsive();
                    ds = ConvertToDataSet(result);
                    divsearch.Visible = true;
                    divsearch.Visible = true;
                    bindgridfoucs();
                    calculatefooter();
                }
                btnupdate.Visible = true;
                btn_section.Visible = true;
            }
            else
            {
                divsearch.Visible = false;
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                Gv_periodplanner.Visible = true;
                lblresult.Visible = false;
                btnupdate.Visible = false;
                btn_section.Visible = false;
            }
        }
        public List<ClasswisePeriodPlannerData> Getsubjectwiseperiodlist(int curIndex, int pagesize)
        {
            ClasswisePeriodPlannerData objdata = new ClasswisePeriodPlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objdata.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
            objdata.SectionID = Convert.ToInt32(ddl_sections.SelectedValue == "" ? "0" : ddl_sections.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue);
            objdata.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objBO.Getclasswiseperiodplannerlist(objdata);
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
        string sectionID = "";
        string className = "";
        int countsunday = 0;
        int countmonday = 0;
        int counttuesday = 0;
        int countwednesday = 0;
        int countthursday = 0;
        int countfriday = 0;
        int countsaturday = 0;
        int MaxPeriod = 0;
        protected void Gv_periodplanner_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label ID = (Label)e.Row.FindControl("lbl_sectionID");
                Label Class = (Label)e.Row.FindControl("lbl_class");
                Label subject = (Label)e.Row.FindControl("lbl_suject");
                Label slno = (Label)e.Row.FindControl("lbl_sln");
                Label noperiod = (Label)e.Row.FindControl("lbl_noperiod");
                Label norecess = (Label)e.Row.FindControl("lbl_norecess");
                Label lbl_ClassID = (Label)e.Row.FindControl("lbl_classID");
                Label lbl_SubjectID = (Label)e.Row.FindControl("lbl_subjectID");

                if (Convert.ToInt32(noperiod.Text == "" ? "0" : noperiod.Text) > MaxPeriod)
                {
                    MaxPeriod = Convert.ToInt32(noperiod.Text == "" ? "0" : noperiod.Text);
                }
                Label defaultperiod = (Label)e.Row.FindControl("lbl_defaultperiod");
                DropDownList ddl_period = (DropDownList)e.Row.FindControl("ddl_period");

                MasterLookupBO objmstlookupBO = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_period, objmstlookupBO.GetPeriodlistByclassID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                ddl_period.SelectedValue = defaultperiod.Text.ToString();

                Label techerID = (Label)e.Row.FindControl("lbl_teacher");
                DropDownList ddl_teacher = (DropDownList)e.Row.FindControl("ddl_teacher");

                int ClassID = Convert.ToInt32(lbl_ClassID.Text == "" ? "0" : lbl_ClassID.Text);
                int SubjectID = Convert.ToInt32(lbl_SubjectID.Text == "" ? "0" : lbl_SubjectID.Text);
                int sessionid = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                Commonfunction.PopulateDdl(ddl_teacher, objmstlookupBO.GetTeacherByClassID(ClassID, sessionid, sessionid));
                Commonfunction.PopulateDdl(ddl_teacher, objmstlookupBO.GetLookupsList(LookupNames.TeachingStaff));
                ddl_teacher.SelectedValue = techerID.Text.ToString();

                TextBox sunday = (TextBox)e.Row.FindControl("txt_sunday");
                TextBox monday = (TextBox)e.Row.FindControl("txt_monday");
                TextBox tuesday = (TextBox)e.Row.FindControl("txt_tuesday");
                TextBox wednesday = (TextBox)e.Row.FindControl("txt_wednesday");
                TextBox thursday = (TextBox)e.Row.FindControl("txt_thursday");
                TextBox friday = (TextBox)e.Row.FindControl("txt_friday");
                TextBox saturday = (TextBox)e.Row.FindControl("txt_saturday");

                if (sunday.Text == "0" || sunday.Text == "")
                {
                    sunday.Text = "";
                    sunday.BorderColor = System.Drawing.Color.Red;
                }
                //if (sunday.Text != "0" || sunday.Text != "")
                //{
                //    sunday.BackColor = System.Drawing.Color.gr;
                //    sunday.ForeColor= System.Drawing.Color.White;
                //}
                if (monday.Text == "0" || monday.Text == "")
                {
                    monday.Text = "";
                    monday.BorderColor = System.Drawing.Color.Red;
                }
                //if (monday.Text != "0" || monday.Text != "")
                //{
                //    monday.BackColor = System.Drawing.Color.DarkGreen;
                //    monday.ForeColor = System.Drawing.Color.White;
                //}
                if (tuesday.Text == "0" || tuesday.Text == "")
                {
                    tuesday.Text = "";
                    tuesday.BorderColor = System.Drawing.Color.Red;
                }
                //if (tuesday.Text != "0" || tuesday.Text != "")
                //{
                //    tuesday.BackColor = System.Drawing.Color.DarkGreen;
                //    tuesday.ForeColor = System.Drawing.Color.White;
                //}
                if (wednesday.Text == "0" || wednesday.Text == "")
                {
                    wednesday.Text = "";
                    wednesday.BorderColor = System.Drawing.Color.Red;
                }
                //if (wednesday.Text != "0" || wednesday.Text != "")
                //{
                //    wednesday.BackColor = System.Drawing.Color.DarkGreen;
                //    wednesday.ForeColor = System.Drawing.Color.White;
                //}
                if (thursday.Text == "0" || thursday.Text == "")
                {
                    thursday.Text = "";
                    thursday.BorderColor = System.Drawing.Color.Red;
                }
                //if (thursday.Text != "0" || thursday.Text != "")
                //{
                //    thursday.BackColor = System.Drawing.Color.DarkGreen;
                //    thursday.ForeColor = System.Drawing.Color.White;
                //}
                if (friday.Text == "0" || friday.Text == "")
                {
                    friday.Text = "";
                    friday.BorderColor = System.Drawing.Color.Red;
                }
                //if (friday.Text != "0" || friday.Text != "")
                //{
                //    friday.BackColor = System.Drawing.Color.DarkGreen;
                //    friday.ForeColor = System.Drawing.Color.White;
                //}
                if (saturday.Text == "0" || saturday.Text == "")
                {
                    saturday.Text = "";
                    saturday.BorderColor = System.Drawing.Color.Red;
                }
                //if (saturday.Text != "0" || saturday.Text != "")
                //{
                //    saturday.BackColor = System.Drawing.Color.DarkGreen;
                //    saturday.ForeColor = System.Drawing.Color.White;
                //}
                if (sectionID == ID.Text)
                {
                    countsectionID = countsectionID + 1;
                    slno.Text = countsectionID.ToString() + '.';
                    className = lbl_ClassID.Text;

                }
                else
                {
                    sectionID = ID.Text;
                    countsectionID = 1;
                    slno.Text = countsectionID.ToString() + '.';
                }
                if (countsectionID > 1)
                {
                    Class.Text = "";
                    Class.BackColor = System.Drawing.Color.White;
                    Class.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    Class.BackColor = System.Drawing.Color.White;
                    Class.ForeColor = System.Drawing.Color.Black;
                }
                countsunday = countsunday + Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text);
                countmonday = countmonday + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text);
                counttuesday = counttuesday + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text);
                countwednesday = countwednesday + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text);
                countthursday = countthursday + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text);
                countfriday = countfriday + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text);
                countsaturday = countsaturday + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text);
            }
            int total = countsunday + countmonday + counttuesday + countwednesday + countthursday + countfriday + countsaturday;
            txt_perdaytotalperiod.Text = " SN : " + countsunday.ToString() + " MN : " + countmonday.ToString() + "  TUE : " + counttuesday.ToString() + "  WED : " + countwednesday.ToString() + "  THU : " + countthursday.ToString() + "  FR : " + countfriday.ToString() + "  ST : " + countsaturday.ToString() + " = " + total.ToString(); ;
            lbl_maxperiod.Text = "Teachers are allowed to assign maximum  " + MaxPeriod.ToString() + " periods in a day for these classes.";
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
            if (ddl_subject.SelectedIndex > 0)
            {
                BindGrid(1);
                btnupdate.Visible = false;
                btn_section.Visible = false;
            }
            else
            {
                BindGrid(1);
                btnupdate.Visible = true;
                btn_section.Visible = true;
            }
        }

        protected void ddl_sections_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
            if (ddl_sections.SelectedIndex > 0)
            {
                btn_section.Text = "Apply " + ddl_sections.SelectedItem.Text;
                btn_section.Visible = true;
            }
            else
            {
                btn_section.Visible = false;
            }
        }
        protected void btn_update_section_Click(object sender, EventArgs e)
        {
            int updatetype = 1;
            updateplanner(updatetype);
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int updatetype = 2;
            updateplanner(updatetype);
        }
        protected void updateplanner(int updatetype)
        {
            try
            {
                Label sundayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sundayperiod");
                Label mondayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_mondayperiod");
                Label tuesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_tuesdayperiod");
                Label wednesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_wednesdayperiod");
                Label thursdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_thursdayperiod");
                Label fridayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_fridayperiod");
                Label saturdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_saturdayperiod");
                Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

                int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
                int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
                int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
                int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
                int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
                int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
                int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);
                int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

                int total_sundaycount = Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text);
                int total_mondaycount = Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text);
                int total_tuesdaycount = Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text);
                int total_wednesdaycount = Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text);
                int total_thursdaycount = Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text);
                int total_fridaycount = Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text);
                int total_saturdaycount = Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text);


                int extra = 0;
                if (total_sundaycount > permitted_sundayperiod)
                {
                    extra = total_sundaycount - permitted_sundayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for sunday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_sundaycount < permitted_sundayperiod)
                {
                    extra = permitted_sundayperiod - total_sundaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for sunday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_mondaycount > permitted_mondayperiod)
                {
                    extra = total_mondaycount - permitted_mondayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for monday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_mondaycount < permitted_mondayperiod)
                {
                    extra = permitted_mondayperiod - total_mondaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for monday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_tuesdaycount > permitted_tuesdayperiod)
                {
                    extra = total_tuesdaycount - permitted_tuesdayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for tuesday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_tuesdaycount < permitted_tuesdayperiod)
                {
                    extra = permitted_tuesdayperiod - total_tuesdaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for tuesday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_wednesdaycount > permitted_wednesdayperiod)
                {
                    extra = total_wednesdaycount - permitted_wednesdayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for wednesady. Please plan properly.") + "')", true);
                    return;
                }
                if (total_wednesdaycount < permitted_wednesdayperiod)
                {
                    extra = permitted_wednesdayperiod - total_wednesdaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for wednesady. Please plan properly.") + "')", true);
                    return;
                }
                if (total_thursdaycount > permitted_thursdayperiod)
                {
                    extra = total_thursdaycount - permitted_thursdayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for thursday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_thursdaycount < permitted_thursdayperiod)
                {
                    extra = permitted_thursdayperiod - total_thursdaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for thursday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_fridaycount > permitted_fridayperiod)
                {
                    extra = total_fridaycount - permitted_fridayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for friday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_fridaycount < permitted_fridayperiod)
                {
                    extra = permitted_fridayperiod - total_fridaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for friday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_saturdaycount > permitted_saturdayperiod)
                {
                    extra = total_saturdaycount - permitted_saturdayperiod;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for saturday. Please plan properly.") + "')", true);
                    return;
                }
                if (total_saturdaycount < permitted_saturdayperiod)
                {
                    extra = permitted_saturdayperiod - total_saturdaycount;
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is less for saturday. Please plan properly.") + "')", true);
                    return;
                }

                List<ClasswisePeriodPlannerData> subjectlist = new List<ClasswisePeriodPlannerData>();
                ClasswisePeriodPlannerData ObjData = new ClasswisePeriodPlannerData();
                ClassallocationBO ObjBO = new ClassallocationBO();
                ObjData.EmployeeID = LoginToken.EmployeeID;

                foreach (GridViewRow row in Gv_periodplanner.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ClassID = (Label)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("lbl_classID");
                    Label SectionID = (Label)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("lbl_sectionID");
                    Label SubjectID = (Label)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("lbl_subjectID");
                    Label totalweeklyperiod = (Label)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("lbl_sectionwise_weekly_period");
                    TextBox chksunday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_sunday");
                    TextBox chkmonday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_monday");
                    TextBox chktuesday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_tuesday");
                    TextBox chkwednesday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_wednesday");
                    TextBox chkthursday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_thursday");
                    TextBox chkfriday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_friday");
                    TextBox chksaturday = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_saturday");
                    DropDownList ddlperiod = (DropDownList)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("ddl_period");
                    DropDownList Teacher = (DropDownList)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("ddl_teacher");
                    TextBox Noperiod = (TextBox)Gv_periodplanner.Rows[row.RowIndex].Cells[0].FindControl("txt_setpriod");

                    ClasswisePeriodPlannerData objclass = new ClasswisePeriodPlannerData();
                    objclass.ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                    objclass.SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);
                    objclass.SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                    objclass.Sunday = Convert.ToInt32(chksunday.Text == "" ? "0" : chksunday.Text);
                    objclass.Monday = Convert.ToInt32(chkmonday.Text == "" ? "0" : chkmonday.Text);
                    objclass.Tuesday = Convert.ToInt32(chktuesday.Text == "" ? "0" : chktuesday.Text);
                    objclass.Wednesday = Convert.ToInt32(chkwednesday.Text == "" ? "0" : chkwednesday.Text);
                    objclass.Thursday = Convert.ToInt32(chkthursday.Text == "" ? "0" : chkthursday.Text);
                    objclass.Friday = Convert.ToInt32(chkfriday.Text == "" ? "0" : chkfriday.Text);
                    objclass.Saturday = Convert.ToInt32(chksaturday.Text == "" ? "0" : chksaturday.Text);
                    objclass.DefaultPeriod = Convert.ToInt32(ddlperiod.SelectedValue == "" ? "0" : ddlperiod.SelectedValue);
                    objclass.TeacherID = Convert.ToInt32(Teacher.SelectedValue == "" ? "0" : Teacher.SelectedValue);
                    objclass.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                    objclass.SubjectwisePeriod = Convert.ToInt32(Noperiod.Text == "" ? "0" : Noperiod.Text);
                    subjectlist.Add(objclass);
                }
                ObjData.XMLData = XmlConvertor.periodtoxml(subjectlist).ToString();
                ObjData.Status = 1;
                ObjData.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
                ObjData.SectionID = Convert.ToInt32(ddl_sections.SelectedValue == "" ? "0" : ddl_sections.SelectedValue);
                ObjData.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                ObjData.GroupID = Convert.ToInt32(ddl_group.SelectedValue == "" ? "0" : ddl_group.SelectedValue);
                ObjData.Updatetype = updatetype;
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

        protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }

        protected void txt_setpriod_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;
            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            int totalperiod = Convert.ToInt32(txt_totalperiod.Text == "" ? "0" : txt_totalperiod.Text);

            Label sundayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_sundayperiod");
            Label mondayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mondayperiod");
            Label tuesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_tuesdayperiod");
            Label wednesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_wednesdayperiod");
            Label thursdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_thursdayperiod");
            Label fridayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_fridayperiod");
            Label saturdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_saturdayperiod");

            Label mainsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mainsubjectid");
            Label subsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_subjectID");

            int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
            int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
            int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
            int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
            int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
            int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
            int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);

            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            txt_saunday.Text = "";
            txt_monday.Text = "";
            txt_tuesday.Text = "";
            txt_wednesday.Text = "";
            txt_thursday.Text = "";
            txt_friday.Text = "";
            txt_saturday.Text = "";

            int j = 0; // initialization
            int sundaycount = 0;
            int mondaycount = 0;
            int tuesdaycount = 0;
            int wednesdaycount = 0;
            int thursdaycount = 0;
            int fridaycount = 0;
            int saturdaycount = 0;
            while (j <= lastindex) // condition
            {
                TextBox sunday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_sunday");
                TextBox monday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_monday");
                TextBox tuesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_tuesday");
                TextBox wednesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_wednesday");
                TextBox thursday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_thursday");
                TextBox friday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_friday");
                TextBox saturday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_saturday");

                Label subjectID = (Label)Gv_periodplanner.Rows[j].FindControl("lbl_mainsubjectid");


                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text) > 0)
                {
                    sundaycount = sundaycount + Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(monday.Text == "" ? "0" : monday.Text) > 0)
                {
                    mondaycount = mondaycount + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text) > 0)
                {
                    tuesdaycount = tuesdaycount + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text) > 0)
                {
                    wednesdaycount = wednesdaycount + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text) > 0)
                {
                    thursdaycount = thursdaycount + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(friday.Text == "" ? "0" : friday.Text) > 0)
                {
                    fridaycount = fridaycount + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text) > 0)
                {
                    saturdaycount = saturdaycount + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text);
                }
                if (mondaycount == 1 && tuesdaycount == 1 && wednesdaycount == 1 && thursdaycount == 1 && fridaycount == 1 && saturdaycount == 1)
                {
                    mondaycount = 0;
                    tuesdaycount = 0;
                    wednesdaycount = 0;
                    thursdaycount = 0;
                    fridaycount = 0;
                    saturdaycount = 0;
                    //j = lastindex - (j + 1);
                }
                j++;
            }
            int i = 0; // initialization
            int X = totalperiod;
            while (i < totalperiod) // condition
            {
                int remainigsundayslot = permitted_sundayperiod - Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text);
                if (totalperiod > i && sundaycount == 0 && permitted_sundayperiod > 0 && remainigsundayslot > 0)
                {
                    txt_saunday.Text = (Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigmondayslot = permitted_mondayperiod - Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text);
                if (totalperiod > i && mondaycount == 0 && permitted_mondayperiod > 0 && remainigmondayslot > 0)
                {
                    txt_monday.Text = (Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigtuesdayslot = permitted_tuesdayperiod - Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text);
                if (totalperiod > i && tuesdaycount == 0 && permitted_tuesdayperiod > 0 && remainigtuesdayslot > 0)
                {
                    txt_tuesday.Text = (Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigwednesdayslot = permitted_wednesdayperiod - Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text);
                if (totalperiod > i && wednesdaycount == 0 && permitted_wednesdayperiod > 0 && remainigwednesdayslot > 0)
                {
                    txt_wednesday.Text = (Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigthursdayslot = permitted_thursdayperiod - Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text);
                if (totalperiod > i && thursdaycount == 0 && permitted_thursdayperiod > 0 && remainigthursdayslot > 0)
                {
                    txt_thursday.Text = (Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigfridayslot = permitted_fridayperiod - Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text);
                if (totalperiod > i && fridaycount == 0 && permitted_fridayperiod > 0 && remainigfridayslot > 0)
                {
                    txt_friday.Text = (Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigsaturdayslot = permitted_saturdayperiod - Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text);
                if (totalperiod > i && saturdaycount == 0 && permitted_saturdayperiod > 0 && remainigsaturdayslot > 0)
                {
                    txt_saturday.Text = (Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                if (X == totalperiod)
                {
                    i = totalperiod;
                    txt_totalperiod.Text = "";
                }
            }
            calculatefooter();
            calculatesubjectwisetotal();
            if (lastindex > rowindex)
            {
                TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex + 1].FindControl("txt_setpriod");
                next.Focus();
                //next.Attributes.Add("onfocus", "selectText();");
            }
            if (lastindex == rowindex)
            {
                TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
                next.Focus();
            }

        }

        protected void calculatefooter()
        {

            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label sundayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sundayperiod");
            Label mondayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_mondayperiod");
            Label tuesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_tuesdayperiod");
            Label wednesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_wednesdayperiod");
            Label thursdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_thursdayperiod");
            Label fridayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_fridayperiod");
            Label saturdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_saturdayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
            int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
            int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
            int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
            int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
            int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
            int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);



            int j = 0; // initialization
            int total_sundaycount = 0;
            int total_mondaycount = 0;
            int total_tuesdaycount = 0;
            int total_wednesdaycount = 0;
            int total_thursdaycount = 0;
            int total_fridaycount = 0;
            int total_saturdaycount = 0;
            int totalperiod = 0;


            while (j <= lastindex) // condition
            {
                TextBox Totalperiods = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_setpriod");
                TextBox sunday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_sunday");
                TextBox monday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_monday");
                TextBox tuesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_tuesday");
                TextBox wednesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_wednesday");
                TextBox thursday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_thursday");
                TextBox friday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_friday");
                TextBox saturday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_saturday");


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
                Totalperiods.Text = (Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text)
                                    + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text)
                                    + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text)
                                    + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text)
                                    + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text)
                                    + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text)
                                    + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text)
                                    ).ToString();

                totalperiod = totalperiod + Convert.ToInt32(Totalperiods.Text == "" ? "0" : Totalperiods.Text);
                j++;
            }
            Gv_periodplanner.FooterRow.Cells[2].Text = "Total";
            Gv_periodplanner.FooterRow.Cells[3].Text = totalperiod.ToString();
            Gv_periodplanner.FooterRow.Cells[4].Text = total_sundaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[5].Text = total_mondaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[6].Text = total_tuesdaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[7].Text = total_wednesdaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[8].Text = total_thursdaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[9].Text = total_fridaycount.ToString();
            Gv_periodplanner.FooterRow.Cells[10].Text = total_saturdaycount.ToString();

            lbl_sundaytotal.Text = total_sundaycount.ToString();
            lbl_mondaytotal.Text = total_mondaycount.ToString();
            lbl_tuesdaytotal.Text = total_tuesdaycount.ToString();
            lbl_wednesdaytotal.Text = total_wednesdaycount.ToString();
            lbl_thursdaytotal.Text = total_thursdaycount.ToString();
            lbl_fridaytotal.Text = total_fridaycount.ToString();
            lbl_saturdaytotal.Text = total_saturdaycount.ToString();

            Gv_periodplanner.FooterRow.Cells[2].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[3].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[4].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[5].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[6].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[7].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[8].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[9].Font.Bold = true;
            Gv_periodplanner.FooterRow.Cells[10].Font.Bold = true;

            //Gv_periodplanner.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            Gv_periodplanner.FooterRow.BackColor = System.Drawing.Color.Beige;
            if (total_mondaycount == permitted_mondayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[5].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[5].ForeColor = System.Drawing.Color.White;
            }
            if (total_mondaycount > permitted_mondayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[5].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[5].ForeColor = System.Drawing.Color.Black;
            }
            if (total_mondaycount < permitted_mondayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[5].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[5].ForeColor = System.Drawing.Color.Black;
            }

            if (total_tuesdaycount == permitted_tuesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[6].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[6].ForeColor = System.Drawing.Color.White;
            }
            if (total_tuesdaycount > permitted_tuesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[6].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[6].ForeColor = System.Drawing.Color.Black;
            }
            if (total_tuesdaycount < permitted_tuesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[6].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[6].ForeColor = System.Drawing.Color.Black;
            }

            if (total_wednesdaycount == permitted_wednesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[7].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[7].ForeColor = System.Drawing.Color.White;
            }
            if (total_wednesdaycount > permitted_wednesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[7].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[7].ForeColor = System.Drawing.Color.Black;
            }
            if (total_wednesdaycount < permitted_wednesdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[7].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[7].ForeColor = System.Drawing.Color.Black;
            }


            if (total_thursdaycount == permitted_thursdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[8].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[8].ForeColor = System.Drawing.Color.White;
            }
            if (total_thursdaycount > permitted_thursdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[8].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[8].ForeColor = System.Drawing.Color.Black;
            }
            if (total_thursdaycount < permitted_thursdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[8].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[8].ForeColor = System.Drawing.Color.Black;
            }

            if (total_fridaycount == permitted_fridayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[9].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[9].ForeColor = System.Drawing.Color.White;
            }
            if (total_fridaycount > permitted_fridayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[9].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[9].ForeColor = System.Drawing.Color.Black;
            }
            if (total_fridaycount < permitted_fridayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[9].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[9].ForeColor = System.Drawing.Color.Black;
            }

            if (total_saturdaycount == permitted_saturdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[10].BackColor = System.Drawing.Color.DarkGreen;
                Gv_periodplanner.FooterRow.Cells[10].ForeColor = System.Drawing.Color.White;
            }
            if (total_saturdaycount > permitted_saturdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[10].BackColor = System.Drawing.Color.Red;
                Gv_periodplanner.FooterRow.Cells[10].ForeColor = System.Drawing.Color.Black;
            }
            if (total_saturdaycount < permitted_saturdayperiod)
            {
                Gv_periodplanner.FooterRow.Cells[10].BackColor = System.Drawing.Color.Yellow;
                Gv_periodplanner.FooterRow.Cells[10].ForeColor = System.Drawing.Color.Black;
            }
            Gv_periodplanner.HeaderRow.Cells[3].Text = "SWP [" + totalperiod_allow.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[4].Text = "SN [" + sundayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[5].Text = "MN [" + mondayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[6].Text = "TU [" + tuesdayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[7].Text = "WE [" + wednesdayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[8].Text = "TH [" + thursdayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[9].Text = "FR [" + fridayperiod.Text + ']';
            Gv_periodplanner.HeaderRow.Cells[10].Text = "ST [" + saturdayperiod.Text + ']';

            //int extra = 0;
            //if (total_sundaycount > permitted_sundayperiod)
            //{
            //    extra = total_sundaycount - permitted_sundayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for sunday. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_mondaycount > permitted_mondayperiod)
            //{
            //    extra = total_mondaycount - permitted_mondayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for monday. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_tuesdaycount > permitted_tuesdayperiod)
            //{
            //    extra = total_tuesdaycount - permitted_tuesdayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for tuesday. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_wednesdaycount > permitted_wednesdayperiod)
            //{
            //    extra = total_wednesdaycount - permitted_wednesdayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for wednesady. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_thursdaycount > permitted_thursdayperiod)
            //{
            //    extra = total_thursdaycount - permitted_thursdayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for thursday. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_fridaycount > permitted_fridayperiod)
            //{
            //    extra = total_fridaycount - permitted_fridayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for friday. Please plan properly.") + "')", true);
            //    return;
            //}
            //if (total_saturdaycount > permitted_saturdayperiod)
            //{
            //    extra = total_saturdaycount - permitted_saturdayperiod;
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage(extra + " period is over for saturday. Please plan properly.") + "')", true);
            //    return;
            //}

        }
        protected void calculatesubjectwisetotal()
        {
            //int i = 0; // initialization
            //Int32 lastindex = Gv_periodplanner.Rows.Count - 1;
            int total = 0;
            //while (i < lastindex) // condition
            //{
            //    TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_setpriod");
            //    TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_sunday");
            //    TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_monday");
            //    TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_tuesday");
            //    TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_wednesday");
            //    TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_thursday");
            //    TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_friday");
            //    TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[i].FindControl("txt_saturday");

            //    txt_totalperiod.Text = (Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text)
            //                          + Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text)
            //                          + Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text)
            //                          + Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text)
            //                          + Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text)
            //                          + Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text)
            //                          + Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text)
            //                           ).ToString();
            //    total = total + Convert.ToInt32(txt_totalperiod.Text == "" ? "0" : txt_totalperiod.Text);
            //    i++;
            //}
            total = (Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text)
                                      + Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text)
                                      + Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text)
                                      + Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text)
                                      + Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text)
                                      + Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text)
                                      + Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text)
                                       );
            Gv_periodplanner.FooterRow.Cells[3].Text = total.ToString();
        }
        protected void txt_sunday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label sundayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sundayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            if (permitted_sundayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_sunday = Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text);
                if (totalperiodcount_sunday > permitted_sundayperiod)
                {
                    txt_saunday.Text = "";
                    calculatefooter();
                    // txt_saunday.Focus();
                }
                int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();
            }
            else
            {
                txt_saunday.Text = "";
                // txt_saunday.Focus();
            }
            calculatesubjectwisetotal();

        }

        protected void txt_monday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label mondayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_mondayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            int total_sundaycount = 0;
            int total_mondaycount = 0;
            int total_tuesdaycount = 0;
            int total_wednesdaycount = 0;
            int total_thursdaycount = 0;
            int total_fridaycount = 0;
            int total_saturdaycount = 0;

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            if (permitted_mondayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_monday = Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text);
                if (totalperiodcount_monday > permitted_mondayperiod)
                {
                    txt_monday.Text = "";
                    calculatefooter();
                    // txt_monday.Focus();
                }
                total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();
            }
            else
            {
                txt_monday.Text = "";
                // txt_monday.Focus();
            }
            calculatesubjectwisetotal();

        }
        protected void txt_tuesday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;
            Label tuesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_tuesdayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");


            if (permitted_tuesdayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_tuesday = Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text);
                if (totalperiodcount_tuesday > permitted_tuesdayperiod)
                {
                    txt_tuesday.Text = "";
                    calculatefooter();
                    //txt_tuesday.Focus();
                }
                int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();

            }
            else
            {
                txt_tuesday.Text = "";
                //txt_tuesday.Focus();
            }
            calculatesubjectwisetotal();
        }
        protected void txt_wednesday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label wednesdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_wednesdayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            if (permitted_wednesdayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_wednesday = Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text);
                if (totalperiodcount_wednesday > permitted_wednesdayperiod)
                {
                    txt_wednesday.Text = "";
                    calculatefooter();
                    //txt_wednesday.Focus();
                }
                int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();

            }
            else
            {
                txt_wednesday.Text = "";
                // txt_wednesday.Focus();
            }
            calculatesubjectwisetotal();
        }

        protected void txt_thursday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label thursdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_thursdayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");


            if (permitted_thursdayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_thursday = Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text);
                if (totalperiodcount_thursday > permitted_thursdayperiod)
                {
                    txt_thursday.Text = "";
                    calculatefooter();
                    //txt_thursday.Focus();
                    int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                    int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                    int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                    int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                    int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                    int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                    int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                    txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();
                }
            }
            else
            {
                txt_thursday.Text = "";
                // txt_thursday.Focus();
            }
            calculatesubjectwisetotal();
        }

        protected void txt_friday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label fridayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_fridayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");


            if (permitted_fridayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_friday = Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text);
                if (totalperiodcount_friday > permitted_fridayperiod)
                {
                    txt_friday.Text = "";
                    calculatefooter();
                    // txt_friday.Focus();
                }
                int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();
            }
            else
            {
                txt_friday.Text = "";
                //txt_friday.Focus();
            }
            calculatesubjectwisetotal();
        }

        protected void txt_saturday_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((TextBox)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;

            Label saturdayperiod = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_saturdayperiod");
            Label totalperiod_allow = (Label)Gv_periodplanner.Rows[0].FindControl("lbl_sectionwise_weekly_period");

            int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);
            int permitted_totalperiod = Convert.ToInt32(totalperiod_allow.Text == "" ? "0" : totalperiod_allow.Text);

            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            if (permitted_saturdayperiod > 0)
            {
                calculatefooter();
                int totalperiodcount_saturday = Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text);
                if (totalperiodcount_saturday > permitted_saturdayperiod)
                {
                    txt_saturday.Text = "";
                    calculatefooter();
                    //txt_saturday.Focus();
                }
                int total_sundaycount = Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text);
                int total_mondaycount = Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text);
                int total_tuesdaycount = Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text);
                int total_wednesdaycount = Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text);
                int total_thursdaycount = Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text);
                int total_fridaycount = Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text);
                int total_saturdaycount = Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text);
                txt_totalperiod.Text = (total_sundaycount + total_mondaycount + total_tuesdaycount + total_wednesdaycount + total_thursdaycount + total_fridaycount + total_saturdaycount).ToString();
            }
            else
            {
                txt_saturday.Text = "";
                //txt_saturday.Focus();
            }
            calculatesubjectwisetotal();
        }

        protected void bnt_cg_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;
            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            Label btntext = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_atperiod");
            txt_totalperiod.Text = btntext.Text;

            int totalperiod = Convert.ToInt32(txt_totalperiod.Text == "" ? "0" : txt_totalperiod.Text);

            Label sundayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_sundayperiod");
            Label mondayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mondayperiod");
            Label tuesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_tuesdayperiod");
            Label wednesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_wednesdayperiod");
            Label thursdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_thursdayperiod");
            Label fridayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_fridayperiod");
            Label saturdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_saturdayperiod");

            Label mainsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mainsubjectid");
            Label subsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_subjectID");

            int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
            int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
            int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
            int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
            int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
            int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
            int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);

            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            txt_saunday.Text = "";
            txt_monday.Text = "";
            txt_tuesday.Text = "";
            txt_wednesday.Text = "";
            txt_thursday.Text = "";
            txt_friday.Text = "";
            txt_saturday.Text = "";

            int j = 0; // initialization
            int sundaycount = 0;
            int mondaycount = 0;
            int tuesdaycount = 0;
            int wednesdaycount = 0;
            int thursdaycount = 0;
            int fridaycount = 0;
            int saturdaycount = 0;
            while (j <= lastindex) // condition
            {
                TextBox sunday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_sunday");
                TextBox monday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_monday");
                TextBox tuesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_tuesday");
                TextBox wednesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_wednesday");
                TextBox thursday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_thursday");
                TextBox friday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_friday");
                TextBox saturday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_saturday");

                Label subjectID = (Label)Gv_periodplanner.Rows[j].FindControl("lbl_mainsubjectid");


                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text) > 0)
                {
                    sundaycount = sundaycount + Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(monday.Text == "" ? "0" : monday.Text) > 0)
                {
                    mondaycount = mondaycount + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text) > 0)
                {
                    tuesdaycount = tuesdaycount + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text) > 0)
                {
                    wednesdaycount = wednesdaycount + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text) > 0)
                {
                    thursdaycount = thursdaycount + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(friday.Text == "" ? "0" : friday.Text) > 0)
                {
                    fridaycount = fridaycount + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text) > 0)
                {
                    saturdaycount = saturdaycount + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text);
                }
                if (mondaycount == 1 && tuesdaycount == 1 && wednesdaycount == 1 && thursdaycount == 1 && fridaycount == 1 && saturdaycount == 1)
                {
                    mondaycount = 0;
                    tuesdaycount = 0;
                    wednesdaycount = 0;
                    thursdaycount = 0;
                    fridaycount = 0;
                    saturdaycount = 0;
                    //j = lastindex - (j + 1);
                }
                j++;
            }
            int i = 0; // initialization
            int X = totalperiod;
            while (i < totalperiod) // condition
            {
                int remainigsundayslot = permitted_sundayperiod - Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text);
                if (totalperiod > i && sundaycount == 0 && permitted_sundayperiod > 0 && remainigsundayslot > 0)
                {
                    txt_saunday.Text = (Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigmondayslot = permitted_mondayperiod - Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text);
                if (totalperiod > i && mondaycount == 0 && permitted_mondayperiod > 0 && remainigmondayslot > 0)
                {
                    txt_monday.Text = (Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigtuesdayslot = permitted_tuesdayperiod - Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text);
                if (totalperiod > i && tuesdaycount == 0 && permitted_tuesdayperiod > 0 && remainigtuesdayslot > 0)
                {
                    txt_tuesday.Text = (Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigwednesdayslot = permitted_wednesdayperiod - Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text);
                if (totalperiod > i && wednesdaycount == 0 && permitted_wednesdayperiod > 0 && remainigwednesdayslot > 0)
                {
                    txt_wednesday.Text = (Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigthursdayslot = permitted_thursdayperiod - Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text);
                if (totalperiod > i && thursdaycount == 0 && permitted_thursdayperiod > 0 && remainigthursdayslot > 0)
                {
                    txt_thursday.Text = (Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigfridayslot = permitted_fridayperiod - Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text);
                if (totalperiod > i && fridaycount == 0 && permitted_fridayperiod > 0 && remainigfridayslot > 0)
                {
                    txt_friday.Text = (Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigsaturdayslot = permitted_saturdayperiod - Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text);
                if (totalperiod > i && saturdaycount == 0 && permitted_saturdayperiod > 0 && remainigsaturdayslot > 0)
                {
                    txt_saturday.Text = (Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                if (X == totalperiod)
                {
                    i = totalperiod;
                    txt_totalperiod.Text = "";
                }
            }
            calculatefooter();
            calculatesubjectwisetotal();
            //if (lastindex > rowindex)
            //{
            //    TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex + 1].FindControl("txt_setpriod");
            //    next.Focus();
            //    //next.Attributes.Add("onfocus", "selectText();");
            //}
            //if (lastindex == rowindex)
            //{
            //    TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            //    next.Focus();
            //}
        }

        protected void btn_cgzero_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Int32 lastindex = Gv_periodplanner.Rows.Count - 1;
            TextBox txt_totalperiod = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            Label btntext = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_atperiod");
            txt_totalperiod.Text = "0";

            int totalperiod = Convert.ToInt32(txt_totalperiod.Text == "" ? "0" : txt_totalperiod.Text);

            Label sundayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_sundayperiod");
            Label mondayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mondayperiod");
            Label tuesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_tuesdayperiod");
            Label wednesdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_wednesdayperiod");
            Label thursdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_thursdayperiod");
            Label fridayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_fridayperiod");
            Label saturdayperiod = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_saturdayperiod");

            Label mainsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_mainsubjectid");
            Label subsubjectid = (Label)Gv_periodplanner.Rows[rowindex].FindControl("lbl_subjectID");

            int permitted_sundayperiod = Convert.ToInt32(sundayperiod.Text == "" ? "0" : sundayperiod.Text);
            int permitted_mondayperiod = Convert.ToInt32(mondayperiod.Text == "" ? "0" : mondayperiod.Text);
            int permitted_tuesdayperiod = Convert.ToInt32(tuesdayperiod.Text == "" ? "0" : tuesdayperiod.Text);
            int permitted_wednesdayperiod = Convert.ToInt32(wednesdayperiod.Text == "" ? "0" : wednesdayperiod.Text);
            int permitted_thursdayperiod = Convert.ToInt32(thursdayperiod.Text == "" ? "0" : thursdayperiod.Text);
            int permitted_fridayperiod = Convert.ToInt32(fridayperiod.Text == "" ? "0" : fridayperiod.Text);
            int permitted_saturdayperiod = Convert.ToInt32(saturdayperiod.Text == "" ? "0" : saturdayperiod.Text);

            TextBox txt_saunday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_sunday");
            TextBox txt_monday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_monday");
            TextBox txt_tuesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_tuesday");
            TextBox txt_wednesday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_wednesday");
            TextBox txt_thursday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_thursday");
            TextBox txt_friday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_friday");
            TextBox txt_saturday = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_saturday");

            txt_saunday.Text = "";
            txt_monday.Text = "";
            txt_tuesday.Text = "";
            txt_wednesday.Text = "";
            txt_thursday.Text = "";
            txt_friday.Text = "";
            txt_saturday.Text = "";

            int j = 0; // initialization
            int sundaycount = 0;
            int mondaycount = 0;
            int tuesdaycount = 0;
            int wednesdaycount = 0;
            int thursdaycount = 0;
            int fridaycount = 0;
            int saturdaycount = 0;
            while (j <= lastindex) // condition
            {
                TextBox sunday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_sunday");
                TextBox monday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_monday");
                TextBox tuesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_tuesday");
                TextBox wednesday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_wednesday");
                TextBox thursday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_thursday");
                TextBox friday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_friday");
                TextBox saturday = (TextBox)Gv_periodplanner.Rows[j].FindControl("txt_saturday");

                Label subjectID = (Label)Gv_periodplanner.Rows[j].FindControl("lbl_mainsubjectid");


                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text) > 0)
                {
                    sundaycount = sundaycount + Convert.ToInt32(sunday.Text == "" ? "0" : sunday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(monday.Text == "" ? "0" : monday.Text) > 0)
                {
                    mondaycount = mondaycount + Convert.ToInt32(monday.Text == "" ? "0" : monday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text) > 0)
                {
                    tuesdaycount = tuesdaycount + Convert.ToInt32(tuesday.Text == "" ? "0" : tuesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text) > 0)
                {
                    wednesdaycount = wednesdaycount + Convert.ToInt32(wednesday.Text == "" ? "0" : wednesday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text) > 0)
                {
                    thursdaycount = thursdaycount + Convert.ToInt32(thursday.Text == "" ? "0" : thursday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(friday.Text == "" ? "0" : friday.Text) > 0)
                {
                    fridaycount = fridaycount + Convert.ToInt32(friday.Text == "" ? "0" : friday.Text);
                }
                if (Convert.ToInt32(subjectID.Text == "" ? "0" : subjectID.Text) == Convert.ToInt32(mainsubjectid.Text == "" ? "0" : mainsubjectid.Text) && Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text) > 0)
                {
                    saturdaycount = saturdaycount + Convert.ToInt32(saturday.Text == "" ? "0" : saturday.Text);
                }
                if (mondaycount == 1 && tuesdaycount == 1 && wednesdaycount == 1 && thursdaycount == 1 && fridaycount == 1 && saturdaycount == 1)
                {
                    mondaycount = 0;
                    tuesdaycount = 0;
                    wednesdaycount = 0;
                    thursdaycount = 0;
                    fridaycount = 0;
                    saturdaycount = 0;
                    //j = lastindex - (j + 1);
                }
                j++;
            }
            int i = 0; // initialization
            int X = totalperiod;
            while (i < totalperiod) // condition
            {
                int remainigsundayslot = permitted_sundayperiod - Convert.ToInt32(lbl_sundaytotal.Text == "" ? "0" : lbl_sundaytotal.Text);
                if (totalperiod > i && sundaycount == 0 && permitted_sundayperiod > 0 && remainigsundayslot > 0)
                {
                    txt_saunday.Text = (Convert.ToInt32(txt_saunday.Text == "" ? "0" : txt_saunday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigmondayslot = permitted_mondayperiod - Convert.ToInt32(lbl_mondaytotal.Text == "" ? "0" : lbl_mondaytotal.Text);
                if (totalperiod > i && mondaycount == 0 && permitted_mondayperiod > 0 && remainigmondayslot > 0)
                {
                    txt_monday.Text = (Convert.ToInt32(txt_monday.Text == "" ? "0" : txt_monday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigtuesdayslot = permitted_tuesdayperiod - Convert.ToInt32(lbl_tuesdaytotal.Text == "" ? "0" : lbl_tuesdaytotal.Text);
                if (totalperiod > i && tuesdaycount == 0 && permitted_tuesdayperiod > 0 && remainigtuesdayslot > 0)
                {
                    txt_tuesday.Text = (Convert.ToInt32(txt_tuesday.Text == "" ? "0" : txt_tuesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigwednesdayslot = permitted_wednesdayperiod - Convert.ToInt32(lbl_wednesdaytotal.Text == "" ? "0" : lbl_wednesdaytotal.Text);
                if (totalperiod > i && wednesdaycount == 0 && permitted_wednesdayperiod > 0 && remainigwednesdayslot > 0)
                {
                    txt_wednesday.Text = (Convert.ToInt32(txt_wednesday.Text == "" ? "0" : txt_wednesday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigthursdayslot = permitted_thursdayperiod - Convert.ToInt32(lbl_thursdaytotal.Text == "" ? "0" : lbl_thursdaytotal.Text);
                if (totalperiod > i && thursdaycount == 0 && permitted_thursdayperiod > 0 && remainigthursdayslot > 0)
                {
                    txt_thursday.Text = (Convert.ToInt32(txt_thursday.Text == "" ? "0" : txt_thursday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigfridayslot = permitted_fridayperiod - Convert.ToInt32(lbl_fridaytotal.Text == "" ? "0" : lbl_fridaytotal.Text);
                if (totalperiod > i && fridaycount == 0 && permitted_fridayperiod > 0 && remainigfridayslot > 0)
                {
                    txt_friday.Text = (Convert.ToInt32(txt_friday.Text == "" ? "0" : txt_friday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                int remainigsaturdayslot = permitted_saturdayperiod - Convert.ToInt32(lbl_saturdaytotal.Text == "" ? "0" : lbl_saturdaytotal.Text);
                if (totalperiod > i && saturdaycount == 0 && permitted_saturdayperiod > 0 && remainigsaturdayslot > 0)
                {
                    txt_saturday.Text = (Convert.ToInt32(txt_saturday.Text == "" ? "0" : txt_saturday.Text) + 1).ToString();
                    totalperiod = totalperiod - 1;
                }
                if (X == totalperiod)
                {
                    i = totalperiod;
                    txt_totalperiod.Text = "";
                }
            }
            calculatefooter();
            calculatesubjectwisetotal();
            //if (lastindex > rowindex)
            //{
            //    TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex + 1].FindControl("txt_setpriod");
            //    next.Focus();
            //    //next.Attributes.Add("onfocus", "selectText();");
            //}
            //if (lastindex == rowindex)
            //{
            //    TextBox next = (TextBox)Gv_periodplanner.Rows[rowindex].FindControl("txt_setpriod");
            //    next.Focus();
            //}
        }
    }
}