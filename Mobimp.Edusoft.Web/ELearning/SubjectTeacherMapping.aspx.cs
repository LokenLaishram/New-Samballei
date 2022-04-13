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

namespace Mobimp.Edusoft.Web.ELearning
{
    public partial class SubjectTeacherMapping : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                BindDlls();
                AutoCompleteExtender2.ContextKey = LoginToken.EmployeeID.ToString();
                Int64 UserLoginID = LoginToken.UserLoginId;
                int UserRoleID = LoginToken.RoleID;
                if (UserRoleID != 1)
                {
                    List<ELearningData> Result = GetLoginNamebyUserLoginID(UserLoginID);
                    if (Result.Count > 0)
                    {
                        txtTeacherID.Text = Result[0].TeacherName.ToString();
                        txtTeacherID.Attributes["disabled"] = "disabled";
                    }
                    else
                    {
                        txtTeacherID.Text = "";
                        txtTeacherID.Attributes.Remove("disabled");
                    }
                }
                else
                {
                    txtTeacherID.Text = "";
                    txtTeacherID.Attributes.Remove("disabled");
                }
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();

            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlDayID, mstlookup.GetLookupsList(LookupNames.WeekDays));
            Commonfunction.PopulateDdl(ddlClassID, mstlookup.GetLookupsList(LookupNames.Class));

            if (Convert.ToInt32(DateTime.Now.DayOfWeek) == 0) //Sunday
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
            }
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlSubjectID);
        }
        private List<ELearningData> GetLoginNamebyUserLoginID(Int64 ID)
        {
            ELearningBO objEmpBO = new ELearningBO();
            return objEmpBO.SearchTeacherNamebyUserLoginID(ID);
        }
        protected void ddlAcademicSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //divGrid.Visible = false;
        }
        protected void ddlDayID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserRoleID = LoginToken.RoleID;
            if (UserRoleID == 1)
            {
                if (ddlClassID.SelectedIndex > 0)
                {
                    MasterLookupBO objmstlookupBO = new MasterLookupBO();
                    Commonfunction.PopulateDdl(ddlSectionID, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                    Commonfunction.PopulateDdl(ddlSubjectID, objmstlookupBO.GetSubjectByClassIDAcademicID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                    //Commonfunction.Insertzeroitemindex(ddlSectionID);
                    //Commonfunction.Insertzeroitemindex(ddlSubjectID);
                    txtTeacherID.Text = "";
                    txtVideoLink.Text = "";
                    ddlStatus.SelectedIndex = 0;
                }
                else
                {
                    Commonfunction.Insertzeroitemindex(ddlSectionID);
                    Commonfunction.Insertzeroitemindex(ddlSubjectID);
                    txtTeacherID.Text = "";
                    txtVideoLink.Text = "";
                    ddlStatus.SelectedIndex = 0;
                }
            }
            bindgrid(1);
        }
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void ddlStatus_SelectedIndexChanged1(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ELearningData objLearn = new ELearningData();
                ELearningBO objLearnBO = new ELearningBO();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

                objLearn.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                objLearn.DayID = Convert.ToInt32(ddlDayID.SelectedValue == "" ? "0" : ddlDayID.SelectedValue);
                objLearn.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
                objLearn.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
                objLearn.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
                var TeacherID = txtTeacherID.Text.Substring(txtTeacherID.Text.LastIndexOf(':') + 1);
                objLearn.TeacherID = Convert.ToInt64(txtTeacherID.Text == "" ? "0" : TeacherID);
                objLearn.VideoLink = Convert.ToString(txtVideoLink.Text == "" ? "0" : txtVideoLink.Text);

                DateTime StartTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", timeStart.Hour, timeStart.Minute, timeStart.Second, timeStart.AmPm));
                DateTime EndTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", timeEnd.Hour, timeEnd.Minute, timeEnd.Second, timeEnd.AmPm));                
                
                if(EndTime<= StartTime)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("TimeError") + "')", true);
                    timeEnd.Focus();
                }
                else
                {
                    objLearn.TeacherStartTime = StartTime.ToString("H:mm:ss");
                    objLearn.TeacherEndTime = EndTime.ToString("H:mm:ss");

                    objLearn.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
                    objLearn.UserId = LoginToken.UserLoginId;
                    objLearn.AddedBy = LoginToken.LoginId;
                    objLearn.CompanyID = LoginToken.CompanyID;

                    DateTime dt = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());
                    MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                    if (dt.ToString("tt") == "AM")
                    {
                        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                    }
                    else
                    {
                        am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                    }
                    timeStart.SetTime(dt.Hour, dt.Minute, dt.Second, am_pm);
                    timeEnd.SetTime(dt.Hour, dt.Minute, dt.Second, am_pm);

                    objLearn.ActionType = EnumActionType.Insert;
                    if (ViewState["ID"] != null)
                    {
                        objLearn.ID = Convert.ToInt64(ViewState["ID"].ToString());
                        objLearn.OldTeacherID = Convert.ToInt64(ViewState["OldTeacherID"]);
                        objLearn.ActionType = EnumActionType.Update;
                    }
                    int result = objLearnBO.UpdateSubjectTeacherMapping(objLearn);
                    if (result == 1 || result == 2)
                    {
                        ddlSubjectID.SelectedIndex = 0;
                        txtTeacherID.Text = "";
                        txtVideoLink.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                        ViewState["ID"] = null;
                        ViewState["OldTeacherID"] = null;
                        btnsave.Text = "Add";
                    }
                    else if (result == 3)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("OngoingTeacherClass") + "')", true);
                    }
                    else if (result == 4)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("OngoingStudentClass") + "')", true);
                    }
                    else if (result == 5)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    bindgrid(1);
                }
                
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstSubTeacher = GetSubjectTeacherMapping(index, pagesize);
            if (lstSubTeacher.Count > 0)
            {
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
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSubjectTeacher.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvSubjectTeacher.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
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
        public List<ELearningData> GetSubjectTeacherMapping(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            objLearn.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objLearn.DayID = Convert.ToInt32(ddlDayID.SelectedValue == "" ? "0" : ddlDayID.SelectedValue);
            objLearn.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objLearn.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objLearn.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
            var TeacherID = txtTeacherID.Text.Substring(txtTeacherID.Text.LastIndexOf(':') + 1);
            objLearn.TeacherID = Convert.ToInt64(txtTeacherID.Text == "" ? "0" : TeacherID);
            objLearn.VideoLink = Convert.ToString(txtVideoLink.Text == "" ? "0" : txtVideoLink.Text);
            DateTime StartTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", timeStart.Hour, timeStart.Minute, timeStart.Second, timeStart.AmPm));
            DateTime EndTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", timeEnd.Hour, timeEnd.Minute, timeEnd.Second, timeEnd.AmPm));
            objLearn.TeacherStartTime = StartTime.ToString("H:mm:ss");
            objLearn.TeacherEndTime = EndTime.ToString("H:mm:ss");
            objLearn.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objLearn.ActionType = EnumActionType.Select;
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;
            
            return objLearnBO.SearchSubjectTeacherMapping(objLearn);
        }
        private void ClearAll()
        {
            ddlAcademicSessionID.SelectedIndex = 1;

            if (DateTime.Now.DayOfWeek == 0)
            {
                ddlDayID.SelectedValue = "7";
            }
            else
            {
                ddlDayID.SelectedValue = Convert.ToString(Convert.ToInt32(DateTime.Now.DayOfWeek));
            }
            int UserRoleID = LoginToken.RoleID;
            if (UserRoleID == 1)
            {
                txtTeacherID.Text = "";
            }
            ddlClassID.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddlSectionID);
            Commonfunction.Insertzeroitemindex(ddlSubjectID);
            txtVideoLink.Text = "";
            
            DateTime dt = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());
            MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
            if (dt.ToString("tt") == "AM")
            {
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
            }
            else
            {
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
            }
            timeStart.SetTime(dt.Hour, dt.Minute, dt.Second, am_pm);
            timeEnd.SetTime(dt.Hour, dt.Minute, dt.Second, am_pm);

            ddlStatus.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            ViewState["OldTeacherID"] = null;
            ClearAll();
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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
                Response.AddHeader("content-disposition", "attachment;filename= " + (ddlDayID.SelectedValue == "0" ? "Weekly" : ddlDayID.SelectedItem.Text) + " class schedule_" + (ddlClassID.SelectedValue == "0" ? "All Classes" : ddlClassID.SelectedItem.Text) + ".xlsx");
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
            List<ELearningData> ELearningDetail = GetSubjectTeacherMapping(1, size);
            List<ELearningDataToExcel> ELearningToExcel = new List<ELearningDataToExcel>();
            int i = 0;
            foreach (ELearningData row in ELearningDetail)
            {
                ELearningDataToExcel EcxeclSubTeacher = new ELearningDataToExcel();
                EcxeclSubTeacher.Class = ELearningDetail[i].classname.ToString();
                EcxeclSubTeacher.Section = ELearningDetail[i].SectionName.ToString();
                EcxeclSubTeacher.Day = ELearningDetail[i].DayName.ToString();
                EcxeclSubTeacher.Subject = ELearningDetail[i].SubjectName.ToString();
                EcxeclSubTeacher.StartTime = ELearningDetail[i].StartTime.ToString("h:mm tt");
                EcxeclSubTeacher.EndTime = ELearningDetail[i].EndTime.ToString("h:mm tt");
                EcxeclSubTeacher.Teacher = ELearningDetail[i].TeacherName.ToString();
                EcxeclSubTeacher.VideoLink = ELearningDetail[i].VideoLink.ToString();
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
        protected void btn_export_Click(object sender, EventArgs e)
        {
            ExportoExcel();
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
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

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void GvSubjectTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectTeacher.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objLearn.ID = Convert.ToInt32(ID.Text);
                    List<ELearningData> GetResult = objLearnBO.GetSubjectTeacherMappingByID(objLearn);
                    if (GetResult.Count > 0)
                    {
                        MasterLookupBO mstlookup = new MasterLookupBO();

                        ddlAcademicSessionID.SelectedValue = GetResult[0].AcademicSessionID.ToString();
                        ddlDayID.SelectedValue = GetResult[0].DayID.ToString();
                        ddlClassID.SelectedValue = GetResult[0].ClassID.ToString();
                        Commonfunction.PopulateDdl(ddlSectionID, mstlookup.GetSectionByClassIDCategoryID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                        Commonfunction.PopulateDdl(ddlSubjectID, mstlookup.GetSubjectByClassIDAcademicID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
                        ddlSectionID.SelectedValue = GetResult[0].SectionID.ToString();
                        ddlSubjectID.SelectedValue = GetResult[0].SubjectID.ToString();
                        txtTeacherID.Text = GetResult[0].TeacherName.ToString();
                        txtVideoLink.Text = GetResult[0].VideoLink.ToString();

                        DateTime dtStart = DateTime.Parse(GetResult[0].TeacherStartTime.ToString());
                        MKB.TimePicker.TimeSelector.AmPmSpec am_pmStart;
                        if (dtStart.ToString("tt") == "AM")
                        {
                            am_pmStart = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                        }
                        else
                        {
                            am_pmStart = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                        }
                        timeStart.SetTime(dtStart.Hour, dtStart.Minute, dtStart.Second, am_pmStart);

                        DateTime dtEnd = DateTime.Parse(GetResult[0].TeacherEndTime.ToString());
                        MKB.TimePicker.TimeSelector.AmPmSpec am_pmEnd;
                        if (dtEnd.ToString("tt") == "AM")
                        {
                            am_pmEnd = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                        }
                        else
                        {
                            am_pmEnd = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                        }
                        timeEnd.SetTime(dtEnd.Hour, dtEnd.Minute, dtEnd.Second, am_pmEnd);

                        ddlStatus.SelectedValue = GetResult[0].IsActive == true ? "1":"0";
                        ViewState["ID"] = GetResult[0].ID;
                        ViewState["OldTeacherID"] = GetResult[0].TeacherID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ELearningData objLearn = new ELearningData();
                    ELearningBO objLearnBO = new ELearningBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectTeacher.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objLearn.ID = Convert.ToInt32(ID.Text);
                    objLearn.ActionType = EnumActionType.Delete;
                    int Result = objLearnBO.DeleteSubjectTeacherMappingByID(objLearn);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("DeleteOnlineClass") + "')", true);
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
    }
}