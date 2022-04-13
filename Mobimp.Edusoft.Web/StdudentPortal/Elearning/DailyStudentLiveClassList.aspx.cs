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
    public partial class DailyStudentLiveClassList : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStudentName.Attributes["disabled"] = "disabled";
                ViewState["ID"] = null;
                lblmessage.Visible = true;
                BindDdls();
                bindgrid(1);
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

            List<ELearningData> Result = GetLoginNamebyUserLoginID();
            if (Result.Count > 0)
            {
                ViewState["ID"] = Result[0].StudentID.ToString();
                txtStudentName.Text = Result[0].StudentDetail.ToString();
                lblhiddenclassID.Text = Result[0].ClassID.ToString();
                lblhiddensectionID.Text = Result[0].SectionID.ToString();
                lblhiddenRollNo.Text = Result[0].RollNo.ToString();
            }
            else
            {
                ClearAll();
            }
        }
        private List<ELearningData> GetLoginNamebyUserLoginID() 
        {
            ELearningBO objELearnBO = new ELearningBO();

            Int64 UserLoginID = LoginToken.UserLoginId;
            int AcademicSessionID = LoginToken.AcademicSessionID;

            return objELearnBO.SearchStudentDetailsbyUserLoginID(UserLoginID, AcademicSessionID);
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
            int pagesize = Convert.ToInt32(lbl_totalrecords.Text == "" ? "10" : lbl_totalrecords.Text); // ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstStdClass = GetDailyStudentLiveClassList(index, pagesize);
            if (lstStdClass.Count > 0)
            {
                GvStudentOnlineClass.PageSize = pagesize;
                string record = lstStdClass[0].MaximumRows.ToString() == "1" ? " Class" : " Classes";
                lblresult.Text = "Number of" + record + " : " + lstStdClass[0].MaximumRows.ToString();
                lbl_totalrecords.Text = lstStdClass[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvStudentOnlineClass.VirtualItemCount = lstStdClass[0].MaximumRows;//total item is required for custom paging
                GvStudentOnlineClass.PageIndex = index - 1;
                GvStudentOnlineClass.DataSource = lstStdClass;
                GvStudentOnlineClass.DataBind();
                ds = ConvertToDataSet(lstStdClass);
                TableCell tableCell = GvStudentOnlineClass.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvStudentOnlineClass.DataSource = null;
                GvStudentOnlineClass.DataBind();
                lblresult.Visible = false;
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvStudentOnlineClass.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            GvStudentOnlineClass.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvStudentOnlineClass.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvStudentOnlineClass.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvStudentOnlineClass.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvStudentOnlineClass.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvStudentOnlineClass.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvStudentOnlineClass.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvStudentOnlineClass.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvStudentOnlineClass.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvStudentOnlineClass.UseAccessibleHeader = true;
            GvStudentOnlineClass.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        public List<ELearningData> GetDailyStudentLiveClassList(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            objLearn.AcademicSessionID = LoginToken.AcademicSessionID;
            objLearn.StudentID = Convert.ToInt64(ViewState["ID"]);
            objLearn.ClassID = Convert.ToInt32(lblhiddenclassID.Text);
            objLearn.SectionID = Convert.ToInt32(lblhiddensectionID.Text);
            objLearn.RollNo = Convert.ToInt32(lblhiddenRollNo.Text);
            objLearn.DayID = Convert.ToInt32(ddlDayID.SelectedValue == "" ? "0" : ddlDayID.SelectedValue);
            DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objLearn.ClassDate = strClassDate;
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;
            objLearn.UserId = LoginToken.UserLoginId;

            return objLearnBO.SearchDailyStudentLiveClassList(objLearn);
        }
        private void ClearAll()
        {
            txtStudentName.Attributes["disabled"] = "disabled";
            if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0)
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
            }
            txtDate.Text = Convert.ToString(DateTime.Now.Date.ToString("dd-MM-yyyy"));
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvStudentOnlineClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStudentOnlineClass.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvStudentOnlineClass_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvStudentOnlineClass.DataSource = sortedView;
                    GvStudentOnlineClass.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvStudentOnlineClass.HeaderRow.Cells[ColumnIndex];
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

        protected void GvStudentOnlineClass_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                //DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                Label lblClassDate = (Label)e.Row.FindControl("lbl_ClassDate");
                Label lblStartTime = (Label)e.Row.FindControl("lbl_StartTime");
                Label lblEndTime = (Label)e.Row.FindControl("lbl_EndTime");
                Label LiveClassStatus = (Label)e.Row.FindControl("lbl_OnlineClassStatus");
                Button ActionButton = (Button)e.Row.FindControl("btn_Action");

                DateTime ClassDate = Convert.ToDateTime(lblClassDate.Text.ToString());
                DateTime DateToday = DateTime.Now.Date;
                DateTime StartTime = Convert.ToDateTime(lblStartTime.Text.ToString());
                DateTime EndTime = Convert.ToDateTime(lblEndTime.Text.ToString());

                TimeSpan StartSpan = StartTime.Subtract(Convert.ToDateTime(DateTime.Now.ToString("HH:mm")));
                TimeSpan EndSpan = EndTime.Subtract(Convert.ToDateTime(DateTime.Now.ToString("HH:mm")));

                int IsPresent = Convert.ToInt32(e.Row.Cells[9].Text);

                if (ClassDate > DateToday) //For the classes in following days 
                {
                    ActionButton.Text = "Link InActive";
                    ActionButton.CssClass = "btn btn-grey cus_btn";
                    ActionButton.Attributes["disabled"] = "disabled";
                    e.Row.Cells[9].Text = "";
                }
                else if (ClassDate < DateToday) //Earlier Days
                {
                    ActionButton.Attributes["disabled"] = "disabled";
                    if (LiveClassStatus.Text == "0")
                    {
                        ActionButton.Text = "Class Off";
                        ActionButton.CssClass = "btn btn-brown cus_btn";
                        ActionButton.ForeColor = System.Drawing.Color.Black;
                        e.Row.Cells[9].Text = "";
                    }
                    else if (LiveClassStatus.Text == "1" || LiveClassStatus.Text == "2")
                    {
                        ActionButton.Text = "Class Ended";
                        ActionButton.CssClass = "btn btn-teal cus_btn";
                        if (IsPresent == 0)
                        {
                            e.Row.Cells[9].Text = "Absent";
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            e.Row.Cells[9].Text = "Present";
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                }
                else
                {
                    if (LiveClassStatus.Text == "0")
                    {
                        if (IsPresent == 0)
                        {
                            if (StartSpan > TimeSpan.Parse("00:15:00"))
                            {
                                ActionButton.Text = "Link InActive";
                                ActionButton.CssClass = "btn btn-grey cus_btn";
                                ActionButton.Attributes["disabled"] = "disabled";
                                e.Row.Cells[9].Text = "";
                            }
                            else if (EndSpan < TimeSpan.Parse("00:00:00"))
                            {
                                ActionButton.Text = "Class Off";
                                ActionButton.CssClass = "btn btn-brown cus_btn";
                                ActionButton.Attributes["disabled"] = "disabled";
                                e.Row.Cells[9].Text = "";
                            }
                            else
                            {
                                ActionButton.Text = "Join";
                                ActionButton.CssClass = "btn btn-danger cus_btn";
                                ActionButton.Attributes["disabled"] = "disabled";
                                e.Row.Cells[9].Text = "";
                            }
                        }
                        else
                        {
                            ActionButton.Text = "Join";
                            ActionButton.CssClass = "btn btn-danger cus_btn";
                            ActionButton.Attributes.Remove("disabled");
                            e.Row.Cells[9].Text = "";
                        }
                    }
                    else if (LiveClassStatus.Text == "1")
                    {
                        if (EndSpan < TimeSpan.Parse("00:00:00"))
                        {
                            ActionButton.Text = "Class Ended";
                            ActionButton.CssClass = "btn btn-teal cus_btn";
                            ActionButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                            ActionButton.Attributes["disabled"] = "disabled";
                            if (IsPresent == 0)
                            {
                                e.Row.Cells[9].Text = "Absent";
                                e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                e.Row.Cells[9].Text = "Present";
                                e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        else if (IsPresent == 1)
                        {
                            ActionButton.Text = "Continue";
                            ActionButton.ForeColor = System.Drawing.Color.Gray;
                            ActionButton.CssClass = "btn btn-yellow cus_btn";
                            ActionButton.Attributes.Remove("disabled");
                            e.Row.Cells[9].Text = "Present";
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            ActionButton.Text = "Join";
                            ActionButton.CssClass = "btn btn-success cus_btn";
                            ActionButton.Attributes.Remove("disabled");
                            e.Row.Cells[9].Text = "";
                        }
                    }
                    else if (LiveClassStatus.Text == "2")
                    {
                        ActionButton.Text = "Class Ended";
                        ActionButton.CssClass = "btn btn-teal cus_btn";
                        ActionButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                        ActionButton.Attributes["disabled"] = "disabled";
                        if (IsPresent == 0)
                        {
                            e.Row.Cells[9].Text = "Absent";
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            e.Row.Cells[9].Text = "Present";
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                    else
                    {
                        ActionButton.Text = "Disabled";
                        ActionButton.CssClass = "btn btn-red cus_btn";
                        ActionButton.ForeColor = System.Drawing.Color.WhiteSmoke;
                        ActionButton.Attributes["disabled"] = "disabled";
                    }
                }
            }
        }

        protected void GvStudentOnlineClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvStudentOnlineClass.Rows[i];
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

                DateTime strClassDate = txtDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                
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

                if (e.CommandName == "JoinClass")
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

        protected void timerGridview_Tick(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}