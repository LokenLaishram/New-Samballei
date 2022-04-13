using ClosedXML.Excel;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.TimeTable
{
    public partial class TeacherwiseClassAllocation : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddropdownlist();
                BindGrid(1);
            }
        }
        protected void binddropdownlist()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlAcademicSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            Commonfunction.PopulateDdl(ddl_selectclass, mstlookup.GetLookupsList(LookupNames.Class));
            ddlAcademicSessionID.SelectedIndex = 1;
            Commonfunction.Insertzeroitemindex(ddl_sections);
            Commonfunction.PopulateDdl(ddl_class, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddl_subject, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddl_teacherlist, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_classallocation.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_classallocation.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
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
            Gv_classallocation.UseAccessibleHeader = true;
            Gv_classallocation.HeaderRow.TableSection = TableRowSection.TableHeader;
            TableCell tableCell = Gv_classallocation.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
        }
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_teacher, mstlookup.GetLookupsList(LookupNames.TeachingStaff));
            ddlAcademicSessionID.SelectedIndex = 1;
            ddl_teacher.SelectedIndex = 0;
            btn_add.Text = "Add";
            BindGrid(1);
        }
        protected void gv_classr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Status = e.Row.FindControl("lbl_allocated_classID") as Label;
                CheckBox Chk = e.Row.FindControl("chekclass") as CheckBox;
                if (Status.Text == "1")
                {
                    Chk.Checked = true;
                }
                else
                {
                    Chk.Checked = false;
                }
            }
        }
        protected void gv_subject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ListBox ddl_listbox = e.Row.FindControl("listperiod") as ListBox;
                Label allocatedsections = e.Row.FindControl("lbl_allocatedsectons") as Label;
                Label subjectID = e.Row.FindControl("lbl_subjectID") as Label;
                MasterLookupBO mstLookupBO = new MasterLookupBO();
                Commonfunction.Populatelistbox(ddl_listbox, mstLookupBO.GetassignedClass(Convert.ToInt32(lbl_aasignteacherID.Text == "" ? "0" : lbl_aasignteacherID.Text), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue), Convert.ToInt32(subjectID.Text)));

                if (ddl_listbox.Items.Count > 0)
                {
                    for (int j = 0; j < ddl_listbox.Items.Count; j++)
                    {
                        if (allocatedsections.Text.Contains(ddl_listbox.Items[j].Value.ToString()))
                        {
                            ddl_listbox.Items[j].Selected = true;
                        }
                    }
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                List<ClassallocationData> classlist = new List<ClassallocationData>();
                ClassallocationData ObjData = new ClassallocationData();
                ClassallocationBO ObjBO = new ClassallocationBO();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                int checkcount = 0;
                foreach (GridViewRow row in gv_class.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label ClassID = (Label)gv_class.Rows[row.RowIndex].Cells[0].FindControl("lbl_classID");
                    CheckBox chk = (CheckBox)gv_class.Rows[row.RowIndex].Cells[0].FindControl("chekclass");
                    ClassallocationData objclass = new ClassallocationData();
                    if (chk.Checked)
                    {
                        checkcount = checkcount + 1;
                        objclass.ClassID = Convert.ToInt32(ClassID.Text);
                        classlist.Add(objclass);
                    }
                }
                ObjData.XMLData = XmlConvertor.ClassListtoXML(classlist).ToString();
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.TeacherID = Convert.ToInt64(lblteacherID.Text == "" ? "0" : lblteacherID.Text);
                ObjData.Maxperiodallowed = Convert.ToInt32(txt_Teachermaxperiod.Text == "" ? "0" : txt_Teachermaxperiod.Text);
                ObjData.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                ObjData.CountClass = checkcount;
                int result = ObjBO.updateclassallocation(ObjData);
                if (result == 1 || result == 2)
                {
                    gv_class.DataSource = null;
                    gv_class.DataBind();
                    txt_Teachermaxperiod.Text = "";
                    BindGrid(1);
                }
                else
                {
                    lbl_classmessage.Text = "Error";
                    this.ModalPopupExtender1.Show();
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
        private void BindGrid(int index)
        {
            ClassallocationData objdata = new ClassallocationData();
            ClassallocationBO objBO = new ClassallocationBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ClassallocationData> result = Getteacherlist(index, pagesize);
            if (result.Count > 0)
            {
                Gv_classallocation.Visible = true;
                Gv_classallocation.PageSize = pagesize;
                string record = result[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = result[0].MaximumRows.ToString();
                lblresult.Visible = true;
                Gv_classallocation.VirtualItemCount = result[0].MaximumRows;//total item is required for custom paging
                Gv_classallocation.PageIndex = index - 1;
                Gv_classallocation.DataSource = result;
                Gv_classallocation.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
                divsearch.Visible = true;
            }
            else
            {
                Gv_classallocation.DataSource = null;
                Gv_classallocation.DataBind();
                Gv_classallocation.Visible = true;
                lblresult.Visible = false;
                divsearch.Visible = true;
            }
        }
        public List<ClassallocationData> Getteacherlist(int curIndex, int pagesize)
        {
            ClassallocationData objstd = new ClassallocationData();
            ClassallocationBO objstdBO = new ClassallocationBO();
            objstd.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objstd.TeacherID = Convert.ToInt32(ddl_teacher.SelectedValue == "" ? "0" : ddl_teacher.SelectedValue);
            objstd.PageSize = pagesize;
            objstd.CurrentIndex = curIndex;
            return objstdBO.Getallocatedteacherlist(objstd);
        }
        protected void ddlAcademicSessionID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void ddl_teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void Gv_classallocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "class")
                {
                    ClassallocationData objclass = new ClassallocationData();
                    ClassallocationBO objBO = new ClassallocationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_classallocation.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label name = (Label)gr.Cells[0].FindControl("lbl_name");
                    objclass.ID = Convert.ToInt32(ID.Text);
                    objclass.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                    List<ClassallocationData> GetResult = objBO.GetallocatedlistbyID(objclass);
                    if (GetResult.Count > 0)
                    {
                        lbl_teachername.Text = name.Text;
                        lblteacherID.Text = ID.Text;
                        txt_Teachermaxperiod.Text = GetResult[0].Maxperiodallowed.ToString();
                        gv_class.DataSource = GetResult;
                        gv_class.DataBind();


                    }
                    this.ModalPopupExtender1.Show();

                }
                if (e.CommandName == "subject")
                {
                    ClassallocationData objclass = new ClassallocationData();
                    ClassallocationBO objBO = new ClassallocationBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_classallocation.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    Label name = (Label)gr.Cells[0].FindControl("lbl_name");
                    objclass.ID = Convert.ToInt32(ID.Text);
                    lbl_aasignteacherID.Text = ID.Text;
                    lbl_teacher.Text = name.Text;
                    bindsubjectlist();
                    lbl_subjectmeassge.Text = "";
                    this.ModalPopupExtender2.Show();
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
        protected void bindgridfoucs()
        {
            for (int i = 0; i < gv_subject.Rows.Count - 1; i++)
            {
                TextBox curTexbox = gv_subject.Rows[i].Cells[3].FindControl("txt_rating") as TextBox;
                TextBox nexTextbox = gv_subject.Rows[i + 1].Cells[3].FindControl("txt_rating") as TextBox;
                curTexbox.Attributes.Add("onkeypress", "return clickEnter('" + nexTextbox.ClientID + "', event)");
                int lastindex = gv_subject.Rows.Count - 1;
                if (i + 2 > lastindex)
                {
                    nexTextbox.Attributes.Add("onkeypress", "return clickEnter('" + btn_save.ClientID + "', event)");
                }
            }

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
                wb.Worksheets.Add(dt, "Allocated List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Allocatedclaaa.xlsx");
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
            List<ClassallocationData> classallocation = Getteacherlist(1, size);
            List<ClassallocationtoExcel> listecelstd = new List<ClassallocationtoExcel>();
            int i = 0;
            foreach (ClassallocationData row in classallocation)
            {
                ClassallocationtoExcel Ecxeclclass = new ClassallocationtoExcel();
                Ecxeclclass.EmpName = classallocation[i].EmpName;
                Ecxeclclass.Maxperiodallowed = classallocation[i].Maxperiodallowed;
                Ecxeclclass.AllocatedClasses = classallocation[i].AllocatedClasses;
                Ecxeclclass.AllocatedSubjects = classallocation[i].AllocatedSubjects;
                listecelstd.Add(Ecxeclclass);
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        protected void Gv_classallocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_classallocation.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(e.NewPageIndex + 1));
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
        protected void Gv_classallocation_Sorting(object sender, GridViewSortEventArgs e)
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
                    Gv_classallocation.DataSource = sortedView;
                    Gv_classallocation.DataBind();

                    TableCell tableCell = Gv_classallocation.HeaderRow.Cells[ColumnIndex];
                    Image img = new Image();
                    img.ImageUrl = (SortDir == "Asc") ? "~/app-assets/images/asc.gif" : "~/app-assets/images/desc.gif";
                    tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                    tableCell.Controls.Add(img);

                    Gv_classallocation.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    Gv_classallocation.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
                    Gv_classallocation.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
                    Gv_classallocation.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
                    Gv_classallocation.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
                    // Adds THEAD and TBODY to GridView.
                    Gv_classallocation.UseAccessibleHeader = true;
                    Gv_classallocation.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void Gv_classallocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label classstatus = (Label)e.Row.FindControl("lbl_allocatedclasses");
                Label subjectstatus = (Label)e.Row.FindControl("lbl_allocatedsubjects");
                //Label Classlist = (Label)e.Row.FindControl("lbl_allocatedclasses");
                CheckBox checkbed = (CheckBox)e.Row.FindControl("chekboxselect");

                if (classstatus.Text != "")
                {
                    // e.Row.Cells[4].BackColor = System.Drawing.Color.LightGray;
                    classstatus.ForeColor = System.Drawing.Color.Black;
                }
                if (subjectstatus.Text != "")
                {
                    // e.Row.Cells[6].BackColor = System.Drawing.Color.LightGray;
                    subjectstatus.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
        protected void ddl_selectclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsubjectlist();
        }
        protected void bindsubjectlist()
        {
            SubjectAllocationData objsubject = new SubjectAllocationData();
            ClassallocationBO objstdBO = new ClassallocationBO();
            objsubject.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objsubject.TeacherID = Convert.ToInt32(lbl_aasignteacherID.Text == "" ? "0" : lbl_aasignteacherID.Text);
            objsubject.ID = Convert.ToInt32(ddl_selectclass.SelectedValue == "" ? "0" : ddl_selectclass.SelectedValue);
            List<SubjectAllocationData> result = objstdBO.GetAssignsubjectlist(objsubject);
            if (result.Count > 0)
            {
                gv_subject.DataSource = result;
                gv_subject.DataBind();
                bindgridfoucs();
                this.ModalPopupExtender2.Show();

            }
            else
            {
                gv_subject.DataSource = null;
                gv_subject.DataBind();
                this.ModalPopupExtender2.Show();
            }
            lbl_subjectmeassge.Text = "";
        }

        protected void btn_savesubject_Click(object sender, EventArgs e)
        {

            try
            {
                int selectedcount = 0;
                List<SubjectAllocationData> subjectlist = new List<SubjectAllocationData>();
                SubjectAllocationData ObjData = new SubjectAllocationData();
                ClassallocationBO ObjBO = new ClassallocationBO();
                ObjData.EmployeeID = LoginToken.EmployeeID;
                int checkcount = 0;
                int ratingcount = 0;
                foreach (GridViewRow row in gv_subject.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label SubjectID = (Label)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("lbl_subjectID");
                    Label ClassID = (Label)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("lbl_classID");
                    Label SectionID = (Label)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("lbl_sectionID");
                    TextBox rating = (TextBox)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("txt_rating");
                    CheckBox chk = (CheckBox)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("checksubject");
                    ListBox sectionlist = (ListBox)gv_subject.Rows[row.RowIndex].Cells[0].FindControl("listperiod");
                    SubjectAllocationData objclass = new SubjectAllocationData();
                    string selectedItem = "";
                    if (Convert.ToInt32(rating.Text == "" ? "0" : rating.Text) > 0)
                    {
                        ratingcount = ratingcount + 1;
                        objclass.SubjectID = Convert.ToInt32(SubjectID.Text);
                        objclass.Rating = Convert.ToInt32(rating.Text == "" ? "0" : rating.Text);

                        if (sectionlist.Items.Count > 0)
                        {
                            for (int i = 0; i < sectionlist.Items.Count; i++)
                            {
                                if (sectionlist.Items[i].Selected)
                                {
                                    selectedItem = selectedItem + "," + sectionlist.Items[i].Value;
                                    selectedcount = selectedcount + 1;
                                }
                            }
                        }
                        if (selectedItem != "")
                        {
                            objclass.AllocatedSections = selectedItem.Substring(1);
                        }
                        else
                        {
                            lbl_subjectmeassge.Text = "Please select the allocated classes for this rated subject.";
                            this.ModalPopupExtender2.Show();
                            rating.Focus();
                            return;
                        }
                        subjectlist.Add(objclass);
                    }
                }
                ObjData.XMLData = XmlConvertor.SubjectListtoXML(subjectlist).ToString();
                ObjData.CompanyID = LoginToken.CompanyID;
                ObjData.TeacherID = Convert.ToInt64(lbl_aasignteacherID.Text == "" ? "0" : lbl_aasignteacherID.Text);
                ObjData.ID = Convert.ToInt32(ddl_selectclass.SelectedValue == "" ? "0" : ddl_selectclass.SelectedValue);
                ObjData.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
                if (ratingcount == 0)
                {
                    lbl_subjectmeassge.Text = "Please rate atleast one subject.";
                    this.ModalPopupExtender2.Show();
                    return;
                }
                int result = ObjBO.updatesubjectallocation(ObjData);
                if (result == 1)
                {
                    BindGrid(1);
                    lbl_subjectmeassge.Text = "Saved successfully.";
                    // this.ModalPopupExtender2.Show();
                }
                //if (result == 2)
                //{
                //    BindGrid(1);
                //    lbl_subjectmeassge.Text = "! Exceeds the maximum period allowed.";
                //    this.ModalPopupExtender2.Show();
                //    return;
                //}
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btn_analyse_Click(object sender, EventArgs e)
        {
            Getsubjectwiseperiodlist(1);
            ModalPopupExtender3.Show();
        }
        private void Getsubjectwiseperiodlist(int index)
        {
            ClasswisePeriodPlannerData objdata = new ClasswisePeriodPlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<ClasswisePeriodPlannerData> result = Getsubjectwiseperiodlist(index, pagesize);
            if (result.Count > 0)
            {
                Gv_periodplanner.Visible = true;
                Gv_periodplanner.PageSize = pagesize;
                string record = result.Count.ToString() == "1" ? " record found. " : " records found. ";
                lblsubjectresult.Text = "Total : " + result.Count.ToString() + " " + record;
                lbl_subjecttotalrecords.Text = result.Count.ToString();
                lblsubjectresult.Visible = true;
                Gv_periodplanner.VirtualItemCount = result.Count; //total item is required for custom paging
                Gv_periodplanner.PageIndex = index - 1;
                Gv_periodplanner.DataSource = result;
                Gv_periodplanner.DataBind();
                bindresponsive();
                ds = ConvertToDataSet(result);
            }
            else
            {
                Gv_periodplanner.DataSource = null;
                Gv_periodplanner.DataBind();
                Gv_periodplanner.Visible = true;
                lblsubjectresult.Visible = false;
            }
        }
        public List<ClasswisePeriodPlannerData> Getsubjectwiseperiodlist(int curIndex, int pagesize)
        {
            ClasswisePeriodPlannerData objdata = new ClasswisePeriodPlannerData();
            PeriodplannerBO objBO = new PeriodplannerBO();
            objdata.AcademicSessionID = Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue);
            objdata.ClassID = Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue);
            objdata.SectionID = Convert.ToInt32(ddl_sections.SelectedValue == "" ? "0" : ddl_sections.SelectedValue);
            objdata.SubjectID = Convert.ToInt32(ddl_subject.SelectedValue == "" ? "0" : ddl_subject.SelectedValue);
            objdata.TeacherID = Convert.ToInt32(ddl_teacherlist.SelectedValue == "" ? "0" : ddl_teacherlist.SelectedValue);
            objdata.Status = Convert.ToInt32(ddl_status.SelectedValue == "" ? "0" : ddl_status.SelectedValue);
            objdata.EmployeeID = LoginToken.EmployeeID;
            return objBO.Getclasswise_sectionwise_subjectlist(objdata);
        }
        int countsectionID = 1;
        string sectionID = "";
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
                if (sectionID == ID.Text)
                {
                    countsectionID = countsectionID + 1;
                    slno.Text = countsectionID.ToString() + '.';
                }
                else
                {
                    sectionID = ID.Text;
                    countsectionID = 1;
                    slno.Text = countsectionID.ToString() + '.';
                }
                //if (countsectionID > 1)
                //{
                //    Class.Text = "";
                //}

            }
        }
        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterLookupBO objmstlookupBO = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_sections, objmstlookupBO.GetSectionByClassIDCategoryID(Convert.ToInt32(ddl_class.SelectedValue == "" ? "0" : ddl_class.SelectedValue), Convert.ToInt32(ddlAcademicSessionID.SelectedValue == "" ? "0" : ddlAcademicSessionID.SelectedValue)));
            Getsubjectwiseperiodlist(1);
            ModalPopupExtender3.Show();
        }
        protected void ddl_sections_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getsubjectwiseperiodlist(1);
            ModalPopupExtender3.Show();
        }
        protected void ddl_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getsubjectwiseperiodlist(1);
            ModalPopupExtender3.Show();
        }
        protected void ddl_teacherlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getsubjectwiseperiodlist(1);
            ModalPopupExtender3.Show();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ddl_class.SelectedIndex = 0;
            Commonfunction.Insertzeroitemindex(ddl_sections);
            ddl_subject.SelectedIndex = 0;
            ddl_teacherlist.SelectedIndex = 0;
            ddl_status.SelectedIndex = 0;
        }

    }
}