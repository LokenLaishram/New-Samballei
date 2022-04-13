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

namespace Mobimp.Edusoft.Web.StdudentPortal.ELearning
{
    public partial class MangeAssignmentStudent : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ID"] = null;
                BindDdls();
                BindSubjectDdl();
                bindgrid(1);
            }
        }
        protected void BindDdls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();

            List<ELearningData> Result = GetLoginNamebyUserLoginID();
            if (Result.Count > 0)
            {
                ViewState["ID"] = Result[0].StudentID.ToString();
                txtStudentName.Text = Result[0].StudentName.ToString();
                lblhiddensessionID.Text = Result[0].AcademicSessionID.ToString();
                lblhiddenclassID.Text = Result[0].ClassID.ToString();
                lblhiddensectionID.Text = Result[0].SectionID.ToString();
                lblhiddenRollNo.Text = Result[0].RollNo.ToString();
                txtClass.Text = Result[0].ClassDetail.ToString();
            }
            else
            {
                bindgrid(1);
            }
        }
        protected void BindSubjectDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSubjectID, mstlookup.GetAssignmentSubjectByClassIDSectionID(Convert.ToInt32(lblhiddenclassID.Text == "" ? "0" : lblhiddenclassID.Text), LoginToken.AcademicSessionID, Convert.ToInt32(lblhiddensectionID.Text == "" ? "0" : lblhiddensectionID.Text)));
        }
        private List<ELearningData> GetLoginNamebyUserLoginID() 
        {
            ELearningBO objELearnBO = new ELearningBO();

            Int64 UserLoginID = LoginToken.UserLoginId;
            int AcademicSessionID = LoginToken.AcademicSessionID;

            return objELearnBO.SearchStudentDetailsbyUserLoginID(UserLoginID, AcademicSessionID);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(lbl_totalrecords.Text == "" ? "10" : lbl_totalrecords.Text); // ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstStdClass = GetStudentAssignmentList(index, pagesize);
            if (lstStdClass.Count > 0)
            {
                GvStudentAssignment.PageSize = pagesize;
                string record = lstStdClass[0].MaximumRows.ToString() == "1" ? " Assignment" : " Assignments";
                lblresult.Text = "Number of" + record + " : " + lstStdClass[0].MaximumRows.ToString();
                lbl_totalrecords.Text = lstStdClass[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvStudentAssignment.VirtualItemCount = lstStdClass[0].MaximumRows;//total item is required for custom paging
                GvStudentAssignment.PageIndex = index - 1;
                GvStudentAssignment.DataSource = lstStdClass;
                GvStudentAssignment.DataBind();
                ds = ConvertToDataSet(lstStdClass);
                TableCell tableCell = GvStudentAssignment.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvStudentAssignment.DataSource = null;
                GvStudentAssignment.DataBind();
                lblresult.Visible = false;
            }
        }
        public List<ELearningData> GetStudentAssignmentList(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();

            objLearn.AcademicSessionID = LoginToken.AcademicSessionID;
            objLearn.StudentID = Convert.ToInt64(ViewState["ID"]);
            objLearn.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objLearn.SectionID = Convert.ToInt32(lblhiddensectionID.Text);
            objLearn.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
            objLearn.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;

            return objLearnBO.SearchAssignmentListByStudentID(objLearn);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvStudentAssignment.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvStudentAssignment.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvStudentAssignment.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvStudentAssignment.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvStudentAssignment.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvStudentAssignment.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvStudentAssignment.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvStudentAssignment.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvStudentAssignment.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvStudentAssignment.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvStudentAssignment.UseAccessibleHeader = true;
            GvStudentAssignment.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        //protected void timerGridview_Tick(object sender, EventArgs e)
        //{
        //    bindgrid(1);
        //}
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        protected void GvStudentAssignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStudentAssignment.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvStudentAssignment_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvStudentAssignment.DataSource = sortedView;
                    GvStudentAssignment.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvStudentAssignment.HeaderRow.Cells[ColumnIndex];
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
        protected void GvStudentAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvStudentAssignment.Rows[i];

                Label ID = (Label)gr.Cells[0].FindControl("lblID");
                Label SessionID = (Label)gr.Cells[0].FindControl("lbl_SessionID");
                Label DayID = (Label)gr.Cells[0].FindControl("lbl_DayID");
                Label ClassID = (Label)gr.Cells[0].FindControl("lbl_ClassID");
                Label SectionID = (Label)gr.Cells[0].FindControl("lbl_SectionID");
                Label RollNo = (Label)gr.Cells[0].FindControl("lbl_RollNo");
                Label SubjectID = (Label)gr.Cells[0].FindControl("lbl_SubjectID");
                Label LiveClassID = (Label)gr.Cells[0].FindControl("lbl_LiveClassID");
                Label TeacherLiveClassID = (Label)gr.Cells[0].FindControl("lbl_TeacherClassID");

                Label VideoLink = (Label)gr.Cells[0].FindControl("lbl_VideoLink");
                HyperLink ClassLink = (HyperLink)gr.Cells[0].FindControl("lnk_VideoLink");

                lblhiddenID.Text = Convert.ToString(ID.Text == "" ? "0" : ID.Text);
                lblhiddensessionID.Text = Convert.ToString(SessionID.Text == "" ? "0" : SessionID.Text);
                lblhiddenclassID.Text = Convert.ToString(ClassID.Text == "" ? "0" : ClassID.Text);
                lblhiddensectionID.Text = Convert.ToString(SectionID.Text == "" ? "0" : SectionID.Text);
                lblhiddenRollNo.Text = Convert.ToString(RollNo.Text == "" ? "0" : RollNo.Text);

                if (e.CommandName == "ViewTeacherAssignment")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();

                    Int64 UserLoginID = LoginToken.UserLoginId;
                    objLearn.ID = Convert.ToInt64(ID.Text);
                    objLearn.AcademicSessionID = Convert.ToInt32(SessionID.Text);
                    objLearn.LiveClassID = Convert.ToInt64(LiveClassID.Text);
                    objLearn.StudentID = Convert.ToInt64(ViewState["ID"]);
                    objLearn.StudentJoiningTime = DateTime.Now;
                    objLearn.StudentLogoutTime = DateTime.Now.AddSeconds(60);
                    objLearn.TeacherClassID = Convert.ToInt64(TeacherLiveClassID.Text);

                    int Result = objLearnBO.JoinDailyStudentLiveClass(objLearn);
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
                if (e.CommandName == "ViewSubmittedAssignment")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();

                    Int64 UserLoginID = LoginToken.UserLoginId;
                    objLearn.ID = Convert.ToInt64(ID.Text);
                    objLearn.AcademicSessionID = Convert.ToInt32(SessionID.Text);
                    objLearn.LiveClassID = Convert.ToInt64(LiveClassID.Text);
                    objLearn.StudentID = Convert.ToInt64(ViewState["ID"]);
                    objLearn.StudentJoiningTime = DateTime.Now;
                    objLearn.StudentLogoutTime = DateTime.Now.AddSeconds(60);
                    objLearn.TeacherClassID = Convert.ToInt64(TeacherLiveClassID.Text);

                    int Result = objLearnBO.JoinDailyStudentLiveClass(objLearn);
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
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvStudentAssignment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                //DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                Label ID = (Label)e.Row.FindControl("lbl_AsgmtID");
                Label TeacherAssignmentID = (Label)e.Row.FindControl("lbl_TeacherAssignmentID");
                Label StudentID = (Label)e.Row.FindControl("lbl_AsgmtStudentID");
                Label SubmissionStatusID = (Label)e.Row.FindControl("lbl_AsgmtSubmissionStatus");
                Label SubmissionLastDate = (Label)e.Row.FindControl("lbl_AsgmtLastDate");
                LinkButton SubmittedAssignment = (LinkButton)e.Row.FindControl("lnk_AsgmtStudentView");
                Button ActionButton = (Button)e.Row.FindControl("btn_AsgmtUpload");

                DateTime DateToday = DateTime.Now.Date;
                DateTime LastDate = Convert.ToDateTime(SubmissionLastDate.Text.ToString());

                TimeSpan DateSpan = DateToday.Subtract(Convert.ToDateTime(DateTime.Now.ToString("HH:mm")));

                if (SubmissionStatusID.Text == "0" || SubmissionStatusID.Text == "1")
                {
                    e.Row.Cells[11].Text = "Pending";
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                    SubmittedAssignment.Text = "";
                }
                else if (SubmissionStatusID.Text == "2")
                {
                    e.Row.Cells[11].Text = "Submitted";
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}