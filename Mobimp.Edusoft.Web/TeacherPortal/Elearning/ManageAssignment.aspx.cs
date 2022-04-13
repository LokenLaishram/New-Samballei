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
    public partial class ManageAssignment : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["TeacherID"] = null;
                BindDdls();
                bindgrid(1);
                divMain.Visible = true;
            }
        }
        protected void BindDdls()
        {
            MasterLookupBO objMstLookUp = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, objMstLookUp.GetLookupsList(LookupNames.Academicsession));
            ddlAcademicSessionID.SelectedIndex = 1;
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
        private List<ELearningData> GetLoginNamebyUserLoginID(Int64 UserLoginID) 
        {
            ELearningBO objEmpBO = new ELearningBO();
            return objEmpBO.SearchTeacherNamebyUserLoginID(UserLoginID);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstAssignment = GetTotalAssignmentsForRespectiveTeacher(index, pagesize);
            if (lstAssignment.Count > 0)
            {
                divMain.Visible = true;
                divAddAssignment.Visible = false;
                divAssignmentList.Visible = false;
                divTotalSubmitted.Visible = false;
                divTotalPending.Visible = false;
                GvTeacherAssignment.PageSize = pagesize;
                string record = lstAssignment[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstAssignment[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstAssignment[0].MaximumRows.ToString();
                lblresult.Visible = true;
                GvTeacherAssignment.VirtualItemCount = lstAssignment[0].MaximumRows;//total item is required for custom paging
                GvTeacherAssignment.PageIndex = index - 1;
                GvTeacherAssignment.DataSource = lstAssignment;
                GvTeacherAssignment.DataBind();
                ds = ConvertToDataSet(lstAssignment);
                TableCell tableCell = GvTeacherAssignment.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvTeacherAssignment.DataSource = null;
                GvTeacherAssignment.DataBind();
                lblresult.Visible = false;
            }
        }
        public List<ELearningData> GetTotalAssignmentsForRespectiveTeacher(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();

            objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
            objLearn.AcademicSessionID = LoginToken.AcademicSessionID;
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;

            return objLearnBO.SearchTotalAssignmentsForRespectiveTeacher(objLearn);
        }
        private void ClearAll()
        {
            bindgrid(1);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvTeacherAssignment.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvTeacherAssignment.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvTeacherAssignment.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvTeacherAssignment.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            //GvTeacherAssignment.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvTeacherAssignment.UseAccessibleHeader = true;
            GvTeacherAssignment.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                Response.AddHeader("content-disposition", "attachment;filename= Assignment " + ".xlsx");
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
            List<ELearningData> ELearningDetail = GetTotalAssignmentsForRespectiveTeacher(1, size);
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
        protected void GvTeacherAssignment_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvTeacherAssignment.DataSource = sortedView;
                    GvTeacherAssignment.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvTeacherAssignment.HeaderRow.Cells[ColumnIndex];
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
        protected void GvTeacherAssignment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTeacherAssignment.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvTeacherAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvTeacherAssignment.Rows[i];

                Label ID = (Label)gr.Cells[0].FindControl("lblID");
                Label SessionID = (Label)gr.Cells[0].FindControl("lbl_SessionID");
                Label ClassID = (Label)gr.Cells[0].FindControl("lbl_ClassID");
                Label SectionID = (Label)gr.Cells[0].FindControl("lbl_SectionID");
                Label SubjectID = (Label)gr.Cells[0].FindControl("lbl_SubjectID");
                Label SessionName = (Label)gr.Cells[0].FindControl("lbl_SessionName");
                Label ClassDetail = (Label)gr.Cells[0].FindControl("lbl_ClassDetail");
                Label ClassName = (Label)gr.Cells[0].FindControl("lbl_ClassName");
                Label SectionName = (Label)gr.Cells[0].FindControl("lbl_SectionName");
                Label SubjectName = (Label)gr.Cells[0].FindControl("lbl_SubjectName");

                lblhiddenID.Text = Convert.ToString(ID.Text == "" ? "0" : ID.Text);
                lblhiddenAcademicSessionID.Text = Convert.ToString(SessionID.Text == "" ? "0" : SessionID.Text);
                lblhiddenClassID.Text = Convert.ToString(ClassID.Text == "" ? "0" : ClassID.Text);
                lblhiddenSectionID.Text = Convert.ToString(SectionID.Text == "" ? "0" : SectionID.Text);
                lblhiddenSubjectID.Text = Convert.ToString(SubjectID.Text == "" ? "0" : SubjectID.Text);
                lblhiddenClassName.Text = Convert.ToString(ClassName.Text == "" ? "0" : ClassName.Text);
                lblhiddenSectionName.Text = Convert.ToString(SectionName.Text == "" ? "0" : SectionName.Text);
                lblhiddenSubjectName.Text = Convert.ToString(SubjectName.Text == "" ? "0" : SubjectName.Text);

                Int64 Pop_ID = Convert.ToInt64(ID.Text == "" ? "0" : ID.Text);
                Int64 Pop_TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
                int Pop_SubjectID = Convert.ToInt32(SubjectID.Text == "" ? "0" : SubjectID.Text);
                int Pop_SessionID = Convert.ToInt32(SessionID.Text == "" ? "0" : SessionID.Text);
                int Pop_ClassID = Convert.ToInt32(ClassID.Text == "" ? "0" : ClassID.Text);
                int Pop_SectionID = Convert.ToInt32(SectionID.Text == "" ? "0" : SectionID.Text);

                if (e.CommandName == "Add")
                {
                    divMain.Visible = false;
                    divAddAssignment.Visible = true;
                    divAssignmentList.Visible = false;
                    divTotalSubmitted.Visible = false;
                    divTotalPending.Visible = false;
                    lblErrorMsg.Visible = false;

                    txt_divAddClass.Text = lblhiddenClassName.Text;
                    txt_divAddSection.Text = lblhiddenSectionName.Text;
                    txt_divAddSubject.Text = lblhiddenSubjectName.Text;
                }

                if (e.CommandName == "TotalAssignment")
                {
                    divMain.Visible = false;
                    divAddAssignment.Visible = false;
                    divAssignmentList.Visible = true;
                    divTotalSubmitted.Visible = false;
                    divTotalPending.Visible = false;

                    BindAssignmentListDdl(Pop_SessionID, Pop_ClassID, Pop_SectionID, Pop_SubjectID, Pop_TeacherID);
                    BindGridAssignmentList(1);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public void BindAssignmentListDdl(int SessionID, int ClassID, int SectionID, int SubjectID, Int64 TeacherID)
        {
            MasterLookupBO objMstLookUp = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlClassID, objMstLookUp.GetAssignmentClassByTeacherID(Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), TeacherID));
            ddlClassID.SelectedValue = ClassID.ToString();
            Commonfunction.PopulateDdl(ddlSectionID, objMstLookUp.GetAssignmentSectionByClassIDTeacherID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), TeacherID));
            ddlSectionID.SelectedValue = SectionID.ToString();
            Commonfunction.PopulateDdl(ddlSubjectID, objMstLookUp.GetAssignmentSubjectByClassIDTeacherID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), TeacherID));
            ddlSubjectID.SelectedValue = SubjectID.ToString();
            txtAsgmtListTitle.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }

        //Add Assignment
        protected void btnSaveAsgmt_Click(object sender, EventArgs e)
        {
            txt_divAddClass.Text = lblhiddenClassName.Text;
            txt_divAddSection.Text = lblhiddenSectionName.Text;
            txt_divAddSubject.Text = lblhiddenSubjectName.Text;

            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            objLearn.AcademicSessionID = Convert.ToInt32(lblhiddenAcademicSessionID.Text);
            objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
            objLearn.ClassID = Convert.ToInt32(lblhiddenClassID.Text);
            objLearn.SectionID = Convert.ToInt32(lblhiddenSectionID.Text);
            objLearn.SubjectID = Convert.ToInt32(lblhiddenSubjectID.Text);
            objLearn.Title = txtAssignmentTitle.Text.Trim();
            DateTime LastDate = txtLastDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtLastDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objLearn.LastDate = LastDate;
            objLearn.Remark = txtRemark.Text.Trim();
            objLearn.ID = Convert.ToInt64(lblhiddenID.Text.Trim());

            string fileName = FileUploader.FileName.ToString();
            string ext = Path.GetExtension(fileName);

            if (fileName == "")
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Please select file and try.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("File") + "')", true);
            }
            else if (ext == ".jpg" || ext == ".pdf")
            {
                int length = FileUploader.PostedFile.ContentLength;
                byte[] imgbyte = new byte[length];
                HttpPostedFile img = FileUploader.PostedFile;
                img.InputStream.Read(imgbyte, 0, length);
                objLearn.AssignmentFile = imgbyte;

                int result = objLearnBO.AddAssignment(objLearn);
                if (result == 1 || result == 2)
                {
                    divMain.Visible = true;
                    divAddAssignment.Visible = false;
                    divAssignmentList.Visible = false;
                    divTotalSubmitted.Visible = false;
                    divTotalPending.Visible = false;

                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    //ViewState["TeacherID"] = null;
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("FileExtension") + "')", true);
            }


            
        }
        protected void btnCancelAsgmt_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        
        //Assignment List
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }
        private void BindGridAssignmentList(int index)
        {
            int pagesize = Convert.ToInt32(ddlAsmtList_Show.SelectedValue == "10000" ? lblAsgmtList_TotalRecords.Text : ddl_show.SelectedValue);
            List<ELearningData> lstAsgmtList = GetAssignmentList(index, pagesize);
            if (lstAsgmtList.Count > 0)
            {
                divMain.Visible = false;
                divAddAssignment.Visible = false;
                divAssignmentList.Visible = true;
                divTotalSubmitted.Visible = false;
                divTotalPending.Visible = false;
                GvAsgmtList.PageSize = pagesize;
                string record = lstAsgmtList[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblAsgmtListResult.Text = "Total : " + lstAsgmtList[0].MaximumRows.ToString() + " " + record;
                lblAsgmtList_TotalRecords.Text = lstAsgmtList[0].MaximumRows.ToString();
                lblAsgmtListResult.Visible = true;
                GvAsgmtList.VirtualItemCount = lstAsgmtList[0].MaximumRows;//total item is required for custom paging
                GvAsgmtList.PageIndex = index - 1;
                GvAsgmtList.DataSource = lstAsgmtList;
                GvAsgmtList.DataBind();
                ds = ConvertToDataSet(lstAsgmtList);
                TableCell tableCell = GvAsgmtList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                BindResponsiveAssignmentList();
            }
            else
            {
                GvAsgmtList.DataSource = null;
                GvAsgmtList.DataBind();
                lblAsgmtListResult.Visible = false;
            }
        }
        public List<ELearningData> GetAssignmentList(int curIndex, int pagesize)
        {
            ELearningData objLearn = new ELearningData();
            ELearningBO objLearnBO = new ELearningBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);

            objLearn.AcademicSessionID = Convert.ToInt32(lblhiddenAcademicSessionID.Text);
            objLearn.TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
            objLearn.ClassID = Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue);
            objLearn.SectionID = Convert.ToInt32(ddlSectionID.SelectedValue == "" ? "0" : ddlSectionID.SelectedValue);
            objLearn.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
            objLearn.Title = txtAsgmtListTitle.Text.Trim();
            objLearn.PageSize = pagesize;
            objLearn.CurrentIndex = curIndex;
            //objLearn.AssignmentFile = txtAssignmentTitle.Text.Trim();
            DateTime FromDate = txtFromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtFromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime ToDate = txtToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objLearn.Datefrom = FromDate;
            objLearn.Dateto = ToDate;

            return objLearnBO.SearchAssignmentList(objLearn);
        }
        protected void BindResponsiveAssignmentList()
        {
            //Responsive 
            GvAsgmtList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvAsgmtList.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvAsgmtList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvAsgmtList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            //GvAsgmtList.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvAsgmtList.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAsgmtList.UseAccessibleHeader = true;
            GvAsgmtList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void lnkAsgmtListBack_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void GvAsgmtList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int i = Convert.ToInt16(e.CommandArgument.ToString());
                GridViewRow gr = GvAsgmtList.Rows[i];

                Label SubAssignmentID = (Label)gr.Cells[0].FindControl("lbl_AsgmtID");
                Label ClassName = (Label)gr.Cells[0].FindControl("lbl_AsgmtClassName");
                Label SectionName = (Label)gr.Cells[0].FindControl("lbl_AsgmtSectionName");
                Label SubjectName = (Label)gr.Cells[0].FindControl("lbl_AsgmtSubjectName");
                Label Title = (Label)gr.Cells[0].FindControl("lbl_AsgmtTitle");
                Label AddedDate = (Label)gr.Cells[0].FindControl("lbl_AsgmtAddedDate");
                Label LastDate = (Label)gr.Cells[0].FindControl("lbl_AsgmtLastDate");

                lblhiddenClassName.Text = Convert.ToString(ClassName.Text == "" ? "0" : ClassName.Text);
                lblhiddenSectionName.Text = Convert.ToString(SectionName.Text == "" ? "0" : SectionName.Text);
                lblhiddenSubjectName.Text = Convert.ToString(SubjectName.Text == "" ? "0" : SubjectName.Text);
                lblhiddenTitle.Text = Convert.ToString(Title.Text == "" ? "0" : Title.Text);
                lblhiddenAddedDate.Text = Convert.ToString(AddedDate.Text == "" ? "0" : AddedDate.Text);
                lblhiddenLastDate.Text = Convert.ToString(LastDate.Text == "" ? "0" : LastDate.Text);

                Int64 Pop_AsgmtID = Convert.ToInt64(SubAssignmentID.Text == "" ? "0" : SubAssignmentID.Text);

                if (e.CommandName == "Pending")
                {
                    txtPendingClass.Text = lblhiddenClassName.Text;
                    txtPendingSection.Text = lblhiddenSectionName.Text;
                    txtPendingSubject.Text = lblhiddenSubjectName.Text;
                    txtPendingTitle.Text = lblhiddenTitle.Text;
                    txtPendingLastDate.Text = lblhiddenLastDate.Text;

                    divMain.Visible = false;
                    divAddAssignment.Visible = false;
                    divAssignmentList.Visible = false;
                    divTotalSubmitted.Visible = false;
                    divTotalPending.Visible = true;

                    int SubmittedStatus = 0;

                    GetStudentsList(Pop_AsgmtID, SubmittedStatus);
                }
                if (e.CommandName == "Submitted")
                {
                    txtSubmittedClass.Text = lblhiddenClassName.Text;
                    txtSubmittedSection.Text = lblhiddenSectionName.Text;
                    txtSubmittedSubject.Text = lblhiddenSubjectName.Text;
                    txtSubmittedTitle.Text = lblhiddenTitle.Text;
                    txtSubmittedLastDate.Text = lblhiddenLastDate.Text;

                    divMain.Visible = false;
                    divAddAssignment.Visible = false;
                    divAssignmentList.Visible = false;
                    divTotalSubmitted.Visible = true;
                    divTotalPending.Visible = false;

                    int SubmittedStatus = 1;

                    GetStudentsList(Pop_AsgmtID, SubmittedStatus);
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void ddlClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 TeacherID = Convert.ToInt64(ViewState["TeacherID"]);
            if (ddlClassID.SelectedIndex > 0)
            {
                MasterLookupBO objMstLookUp = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlSectionID, objMstLookUp.GetAssignmentSectionByClassIDTeacherID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), TeacherID));
            }
            else
            {
                Commonfunction.Insertzeroitemindex(ddlSectionID);
                Commonfunction.Insertzeroitemindex(ddlSubjectID);
            }
            MasterLookupBO objMst = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlSubjectID, objMst.GetAssignmentSubjectByClassIDTeacherID(Convert.ToInt32(ddlClassID.SelectedValue == "" ? "0" : ddlClassID.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), TeacherID));
            BindGridAssignmentList(1);
        }
        protected void ddlSectionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }
        protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }
        protected void lnkbtn_AsgmtList_Export_Click(object sender, EventArgs e)
        {

        }
        protected void ddlAsmtList_Show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }

        //Submitted Students & Pending Students
        public void GetStudentsList(Int64 AsgmtID, int SubmittedStatus)
        {
            ELearningData objELearn = new ELearningData();
            ELearningBO objELearnBO = new ELearningBO();

            objELearn.ID = AsgmtID;
            objELearn.Status = SubmittedStatus;
            objELearn.AcademicSessionID = LoginToken.AcademicSessionID;

            List<ELearningData> result = objELearnBO.GetStudentListByAssignmentID(objELearn);
            if (result.Count > 0)
            {
                if (SubmittedStatus == 1)
                {
                    GvTotalSubmittedStudents.DataSource = result;
                    GvTotalSubmittedStudents.DataBind();
                    bindresponsive_SubmittedStudents();
                }
                else
                {
                    GvTotalPendingStudents.DataSource = result;
                    GvTotalPendingStudents.DataBind();
                    bindresponsive_PendingStudents();
                }
            }
            else
            {
                GvTotalSubmittedStudents.DataSource = null;
                GvTotalSubmittedStudents.DataBind();
                GvTotalPendingStudents.DataSource = null;
                GvTotalPendingStudents.DataBind();
            }
        }
        protected void bindresponsive_SubmittedStudents()
        {
            //Responsive 
            GvTotalSubmittedStudents.UseAccessibleHeader = true;
            GvTotalSubmittedStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void bindresponsive_PendingStudents()
        {
            //Responsive 
            GvTotalPendingStudents.UseAccessibleHeader = true;
            GvTotalPendingStudents.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void btnTotalSubmitted_Back_Click(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }
        protected void btnTotalPending_Back_Click(object sender, EventArgs e)
        {
            BindGridAssignmentList(1);
        }

        protected void GvTotalPendingStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAsgmtStatusID = (Label)e.Row.FindControl("lbl_PendingStatusID");
                Label AsgmtStatus = (Label)e.Row.FindControl("lbl_PendingSubmissionStatus");

                if (lblAsgmtStatusID.Text=="0")
                {
                    AsgmtStatus.ForeColor = System.Drawing.Color.Red;
                    AsgmtStatus.Text = "Not Seen";
                }
                else if (lblAsgmtStatusID.Text == "1")
                {
                    AsgmtStatus.ForeColor = System.Drawing.Color.Yellow;
                }
            }
        }

        protected void GvTotalSubmittedStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}