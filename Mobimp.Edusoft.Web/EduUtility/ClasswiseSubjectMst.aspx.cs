using ClosedXML.Excel;
using Mobimp.Campusoft.BussinessProcess.EduUtility;


using Mobimp.Campusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.EduUtility
{
    public partial class ClasswiseSubjectMst : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                bindddl();
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));
            Commonfunction.PopulateDdl(ddlSessionID, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlSessionID.SelectedIndex = 1;
            Commonfunction.PopulateDdl(ddlSubjectID, mstlookup.GetLookupsList(LookupNames.Subject));
            Commonfunction.PopulateDdl(ddl_category, mstlookup.GetLookupsList(LookupNames.SubjectCategory));
            ddl_category.SelectedIndex = 1;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSessionID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select academic session.") + "')", true);
                    ddlSessionID.Focus();
                    return;
                }
                if (ddlclass.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select class.") + "')", true);
                    ddlclass.Focus();
                    return;
                }
                if (ddlSubjectID.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Subject.") + "')", true);
                    ddlSubjectID.Focus();
                    return;
                }
                if (ddl_category.SelectedIndex == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select Subject Category.") + "')", true);
                    ddl_category.Focus();
                    return;
                }
                ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                objsubj.AcademicSessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue);
                objsubj.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
                objsubj.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
                objsubj.SubjectCategoryID = Convert.ToInt32(ddl_category.SelectedValue == "" ? "0" : ddl_category.SelectedValue);
                objsubj.IsActive = ddlStatus.SelectedIndex == 0 ? true : false;
                objsubj.AddedBy = LoginToken.LoginId;
                objsubj.UserId = LoginToken.UserLoginId;
                objsubj.CompanyID = LoginToken.CompanyID;
                objsubj.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objsubj.ActionType = EnumActionType.Update;
                    objsubj.ID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objsubjBO.UpdateSubjectDetails(objsubj);
                if (result == 1 || result == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 3)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot update a Subject for which an Exam is already conducted in the current Academic Session.") + "')", true);
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
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void GvSubjectdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                    ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectdetails.Rows[i];
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.ID = Convert.ToInt32(lblID.Text);
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    objsubj.ActionType = EnumActionType.Select;

                    List<ClasswiseSubjectData> GetResult = objsubjBO.GetClasswiseSubjectDetailsByID(objsubj);
                    if (GetResult.Count > 0)
                    {
                        if (GetResult[0].ExamStatus == 1)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot update a Subject for which an Exam is already conducted in the current Academic Session.") + "')", true);
                            bindgrid(1);
                        }
                        else
                        {
                            ddlclass.SelectedValue = GetResult[0].ClassID.ToString();
                            ddlSubjectID.SelectedValue = GetResult[0].SubjectID.ToString();
                            ViewState["ID"] = GetResult[0].ID;
                            btnsave.Text = "Update";
                            bindresponsive();
                        }
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                    ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectdetails.Rows[i];
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.ID = Convert.ToInt16(lblID.Text);
                    objsubj.ActionType = EnumActionType.Delete;
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    int Result = objsubjBO.DeleteClasswiseSubjectDetailsByID(objsubj);
                    if (Result == 1)
                    {

                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
                    }
                    else if (Result == 3)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot delete a Subject for which an Exam is already conducted in the current Academic Session.") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
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
        protected void gv_subsubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                    ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = gv_subsubject.Rows[i];
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.ID = Convert.ToInt32(lblID.Text);
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    objsubj.ActionType = EnumActionType.Select;

                    List<ClasswiseSubjectData> GetResult = objsubjBO.GetsubsubjectbyID(objsubj);
                    if (GetResult.Count > 0)
                    {
                        if (GetResult[0].ExamStatus == 1)
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot update a Subject for which an Exam is already conducted for the current Academic Session.") + "')", true);
                            ModalPopupExtender2.Show();
                        }
                        else
                        {
                            lbl_classid.Text = GetResult[0].ClassID.ToString();
                            lbl_subjectid.Text = GetResult[0].ParentSubjectID.ToString();
                            txt_sub_subject.Text = GetResult[0].Descriptions.ToString();
                            ViewState["SID"] = GetResult[0].ID;
                            btn_addsub.Text = "Update";
                            ModalPopupExtender2.Show();
                        }
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                    ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = gv_subsubject.Rows[i];
                    Label lblID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.ID = Convert.ToInt16(lblID.Text);
                    objsubj.ActionType = EnumActionType.Delete;
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    int Result = objsubjBO.DeleteSubsubjectByID(objsubj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindsubsubject();

                    }
                    else if (Result == 3)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Cannot delete a Subject for which an Exam is already conducted in the current Academic Session.") + "')", true);
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                    }
                    ModalPopupExtender2.Show();

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
            List<ClasswiseSubjectData> lstsubject = getSubjectdetails(index, pagesize);
            if (lstsubject.Count > 0)
            {
                GvSubjectdetails.PageSize = pagesize;
                string record = lstsubject[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsubject[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsubject[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvSubjectdetails.VirtualItemCount = lstsubject[0].MaximumRows;//total item is required for custom paging
                GvSubjectdetails.PageIndex = index - 1;
                GvSubjectdetails.DataSource = lstsubject;
                GvSubjectdetails.DataBind();
                GvSubjectdetails.Visible = true;
                ds = ConvertToDataSet(lstsubject);
                TableCell tableCell = GvSubjectdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();

            }
            else
            {
                GvSubjectdetails.Visible = true;
                GvSubjectdetails.DataSource = null;
                GvSubjectdetails.DataBind();
                divsearch.Visible = true;
                lblresult.Visible = false;
            }
        }
        public List<ClasswiseSubjectData> getSubjectdetails(int curIndex, int pagesize)
        {
            ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
            ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();

            objsubj.ClassID = Convert.ToInt32(ddlclass.SelectedValue == "" ? "0" : ddlclass.SelectedValue);
            objsubj.SubjectID = Convert.ToInt32(ddlSubjectID.SelectedValue == "" ? "0" : ddlSubjectID.SelectedValue);
            objsubj.SubjectCategoryID = Convert.ToInt32(ddl_category.SelectedValue == "" ? "0" : ddl_category.SelectedValue);
            objsubj.ActionType = EnumActionType.Select;
            objsubj.PageSize = pagesize;
            objsubj.CurrentIndex = curIndex;
            objsubj.AcademicSessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue); ;
            objsubj.IsActive = ddlStatus.SelectedIndex == 0 ? true : false;
            return objsubjBO.SearchClasswiseSubjectDetails(objsubj);
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvSubjectdetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvSubjectdetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvSubjectdetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvSubjectdetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvSubjectdetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //GvSubjectdetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvSubjectdetails.UseAccessibleHeader = true;
            GvSubjectdetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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

        private void clearall()
        {
            divsearch.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ddlSessionID.SelectedIndex = 1;
            ddlclass.SelectedIndex = 0;
            ddlSubjectID.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            GvSubjectdetails.DataSource = null;
            GvSubjectdetails.DataBind();
            GvSubjectdetails.Visible = false;
            ViewState["ID"] = null;
            divsearch.Visible = false;
            btnsave.Text = "Add";
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
                wb.Worksheets.Add(dt, "Subject details");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= Class.xlsx");
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
            List<ClasswiseSubjectData> SubjectTypeDetail = getSubjectdetails(1, size);
            List<SubjectTypeDatatoExcel> subjecttypetoexcel = new List<SubjectTypeDatatoExcel>();
            int i = 0;
            foreach (ClasswiseSubjectData row in SubjectTypeDetail)
            {
                SubjectTypeDatatoExcel EcxeclStd = new SubjectTypeDatatoExcel();
                EcxeclStd.Code = SubjectTypeDetail[i].Code;
                EcxeclStd.Descriptions = SubjectTypeDetail[i].Descriptions;
                subjecttypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(subjecttypetoexcel);
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
        protected void GvSubjectdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSubjectdetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvSubjectdetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvSubjectdetails.DataSource = sortedView;
                    GvSubjectdetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSubjectdetails.HeaderRow.Cells[ColumnIndex];
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
        //protected void btnupdate_Click(object sender, EventArgs e)
        //{
        //    List<ClasswiseSubjectData> lststudentlist = new List<ClasswiseSubjectData>();
        //    ClasswiseSubjectData objsubject = new ClasswiseSubjectData();
        //    ClasswiseSubjectBO objstdBO = new ClasswiseSubjectBO();

        //    try
        //    {
        //        // get all the record from the gridview
        //        foreach (GridViewRow row in GvSubjectdetails.Rows)
        //        {
        //            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        //            CheckBox ChkGrade = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkgrade");
        //            CheckBox chkOptional = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkOptional");
        //            CheckBox chkAlternative = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkAlternative");
        //            Label SubjectID = (Label)GvSubjectdetails.Rows[row.RowIndex].Cells[1].FindControl("lblID");
        //            DropDownList SubjectCategory = (DropDownList)GvSubjectdetails.Rows[row.RowIndex].Cells[6].FindControl("ddlcategory");

        //            ClasswiseSubjectData ObjDetails = new ClasswiseSubjectData();
        //            ObjDetails.SubjectID = Convert.ToInt32(SubjectID.Text);
        //            ObjDetails.IsGrade = Convert.ToInt32(ChkGrade.Checked ? 1 : 0);
        //            ObjDetails.IsOptional = Convert.ToInt32(chkOptional.Checked ? 1 : 0);
        //            ObjDetails.IsAlternative = Convert.ToInt32(chkAlternative.Checked ? 1 : 0);
        //            ObjDetails.SubjectCategoryID = Convert.ToInt32(SubjectCategory.SelectedValue == "" ? "0" : SubjectCategory.SelectedValue);
        //            lststudentlist.Add(ObjDetails);
        //        }
        //        objsubject.SubjectlistXML = XmlConvertor.ClasswiseSubjectListtoXML(lststudentlist).ToString();
        //        objsubject.AcademicSessionID = LoginToken.AcademicSessionID;
        //        int results = objstdBO.UpdateSubjectList(objsubject);
        //        if (results == 1)
        //        {
        //            bindgrid(1);

        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
        //    }
        //}
        protected void btn_add_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;
            int rowindex = row.RowIndex;
            Label subjectname = (Label)GvSubjectdetails.Rows[rowindex].FindControl("lbl_subjectname");
            Label classname = (Label)GvSubjectdetails.Rows[rowindex].FindControl("lblclassname");
            Label subjectID = (Label)GvSubjectdetails.Rows[rowindex].FindControl("lblSubjectID");
            Label ClassID = (Label)GvSubjectdetails.Rows[rowindex].FindControl("lbl_classID");
            lbl_classname.Text = classname.Text;
            lbl_subjectname.Text = subjectname.Text;
            lbl_classid.Text = ClassID.Text;
            lbl_subjectid.Text = subjectID.Text;
            txt_sub_subject.Text = "";
            ViewState["SID"] = null;
            bindsubsubject();
            ModalPopupExtender2.Show();
        }
        protected void btn_addsub_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txt_sub_subject.Text.Trim().Contains(":"))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please type and select the Sub Subject from the list.") + "')", true);
                    txt_sub_subject.Focus();
                    ModalPopupExtender2.Show();
                    return;
                }
                lbl_subsubjectID.Text = Commonfunction.SemicolonSeparation_String_64(txt_sub_subject.Text).ToString();

                ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
                ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
                objsubj.AcademicSessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue);
                objsubj.ClassID = Convert.ToInt32(lbl_classid.Text == "" ? "0" : lbl_classid.Text);
                objsubj.SubjectID = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
                objsubj.SubSubjectID = Convert.ToInt32(lbl_subsubjectID.Text == "" ? "0" : lbl_subsubjectID.Text);
                //objsubj.Descriptions = txt_sub_subject.Text.Trim();
                objsubj.IsActive = ddl_substatus.SelectedIndex == 0 ? true : false;
                objsubj.AddedBy = LoginToken.LoginId;
                objsubj.UserId = LoginToken.UserLoginId;
                objsubj.CompanyID = LoginToken.CompanyID;
                objsubj.ActionType = EnumActionType.Insert;
                if (ViewState["SID"] != null)
                {
                    objsubj.ActionType = EnumActionType.Update;
                    objsubj.ID = Convert.ToInt32(ViewState["SID"].ToString());
                }
                int result = objsubjBO.AddSubSubjectDetails(objsubj);
                if (result == 1 || result == 2)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["SID"] = null;
                    btn_addsub.Text = "Add";
                }
                if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                }
                txt_sub_subject.Text = "";
                ModalPopupExtender2.Show();
                bindsubsubject();
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public List<ClasswiseSubjectData> Getsubsubjectlist()
        {
            ClasswiseSubjectData objsubj = new ClasswiseSubjectData();
            ClasswiseSubjectBO objsubjBO = new ClasswiseSubjectBO();
            objsubj.ClassID = Convert.ToInt32(lbl_classid.Text == "" ? "0" : lbl_classid.Text);
            objsubj.SubjectID = Convert.ToInt32(lbl_subjectid.Text == "" ? "0" : lbl_subjectid.Text);
            objsubj.AcademicSessionID = Convert.ToInt32(ddlSessionID.SelectedValue == "" ? "0" : ddlSessionID.SelectedValue); ;
            objsubj.IsActive = ddl_substatus.SelectedIndex == 0 ? true : false;
            return objsubjBO.GetclasswiseSubsubjectlist(objsubj);
        }
        private void bindsubsubject()
        {
            btn_addsub.Text = "Add";

            List<ClasswiseSubjectData> lstsubject = Getsubsubjectlist();
            if (lstsubject.Count > 0)
            {
                gv_subsubject.DataSource = lstsubject;
                gv_subsubject.DataBind();
            }
            else
            {
                gv_subsubject.DataSource = null;
                gv_subsubject.DataBind();

            }
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddl_substatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsubsubject();
            ModalPopupExtender2.Show();
        }

        protected void ddlSubjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void gv_subsubject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label SubjectID = (Label)e.Row.FindControl("lbl_subjectID");
                    Label ParentSubjectID = (Label)e.Row.FindControl("lbl_ParentSubjectID");
                    Button btn_edit = (Button)e.Row.FindControl("lnkEdit");
                    Button btn_delete = (Button)e.Row.FindControl("lnkDelete");

                    if (SubjectID.Text == ParentSubjectID.Text)
                    {
                        btn_edit.Visible = false;
                        btn_delete.Visible = false;
                    }
                    else
                    {
                        btn_edit.Visible = true;
                        btn_delete.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }
        }

        protected void GvSubjectdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    if (ddlStatus.SelectedValue == "1")
                    {
                        GvSubjectdetails.Columns[11].Visible = true;
                    }
                    else
                    {
                        GvSubjectdetails.Columns[11].Visible = false;
                    }

                    Label SubSubjectStatus = (Label)e.Row.FindControl("lbl_subsubjectstatus");
                    if (SubSubjectStatus.Text == "0")
                    {
                        GvSubjectdetails.Columns[7].Visible = false;
                    }
                    else
                    {
                        GvSubjectdetails.Columns[7].Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                }
            }

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlclass.SelectedIndex > 0)
            {
                bindgrid(1);
            }
            else
            {
                GvSubjectdetails.DataSource = null;
                GvSubjectdetails.DataBind();
            }
        }
    }
}