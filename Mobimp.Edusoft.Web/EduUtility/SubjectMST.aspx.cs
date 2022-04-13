using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class SubjectMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divsearch.Visible = false;
                lblmessage.Visible = true;
                bindddl();
                bindgrid(1);
            }
        }
        private void bindddl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            //Commonfunction.PopulateDdl(ddlclass, mstlookup.GetLookupsList(LookupNames.Class));        

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SubjectData objsubj = new SubjectData();
                SubjectBO objsubjBO = new SubjectBO();
                objsubj.Code = txtcode.Text;
                objsubj.Descriptions = txtdescription.Text;
                objsubj.AddedBy = LoginToken.LoginId;
                objsubj.UserId = LoginToken.UserLoginId;
                objsubj.CompanyID = LoginToken.CompanyID;
                objsubj.IsActive = ddlStatusID.SelectedIndex == 0 ? true : false;
                objsubj.ActionType = EnumActionType.Insert;
                objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                objsubj.SubjectCategoryID = Convert.ToInt32(ddl_category.SelectedValue==""?"0": ddl_category.SelectedValue);
                if (ViewState["ID"] != null)
                {
                    objsubj.ActionType = EnumActionType.Update;
                    objsubj.SubjectID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = objsubjBO.UpdateSubjectDetails(objsubj);
                if (result == 1 || result == 2)
                {
                    bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvSubjectdetails.DataSource = getSubjectdetails(1, 10);
                    GvSubjectdetails.DataBind();
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
                    SubjectData objsubj = new SubjectData();
                    SubjectBO objsubjBO = new SubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectdetails.Rows[i];
                    Label SubjectID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.SubjectID = Convert.ToInt32(SubjectID.Text);
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    objsubj.ActionType = EnumActionType.Select;

                    List<SubjectData> GetResult = objsubjBO.GetSubjectDetailsByID(objsubj);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ddl_category.SelectedValue= GetResult[0].SubjectCategoryID.ToString();
                        ViewState["ID"] = GetResult[0].SubjectID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    SubjectData objsubj = new SubjectData();
                    SubjectBO objsubjBO = new SubjectBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSubjectdetails.Rows[i];
                    Label SubjectID = (Label)gr.Cells[0].FindControl("lblID");
                    objsubj.SubjectID = Convert.ToInt16(SubjectID.Text);
                    objsubj.ActionType = EnumActionType.Delete;
                    objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
                    int Result = objsubjBO.DeleteSubjectDetailsByID(objsubj);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        bindgrid(1);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<SubjectData> lstsubject = getSubjectdetails(index, pagesize);
            if (lstsubject.Count > 0)
            {
                GvSubjectdetails.PageSize = pagesize;
                string record = lstsubject[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstsubject[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstsubject[0].MaximumRows.ToString(); ;
                //lblresult.Visible = true;
                divsearch.Visible = true;
                GvSubjectdetails.VirtualItemCount = lstsubject[0].MaximumRows;//total item is required for custom paging
                GvSubjectdetails.PageIndex = index - 1;
                GvSubjectdetails.DataSource = lstsubject;
                GvSubjectdetails.DataBind();
                ds = ConvertToDataSet(lstsubject);
                TableCell tableCell = GvSubjectdetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
                btnupdate.Visible = true;
            }
            else
            {
                GvSubjectdetails.DataSource = null;
                GvSubjectdetails.DataBind();
                divsearch.Visible = true;
                btnupdate.Visible = false;
                lblresult.Visible = false;
            }
        }
        public List<SubjectData> getSubjectdetails(int curIndex, int pagesize)
        {
            SubjectData objsubj = new SubjectData();
            SubjectBO objsubjBO = new SubjectBO();
            objsubj.Code = txtcode.Text == "" ? "0" : txtcode.Text;
            objsubj.Descriptions = txtdescription.Text == "" ? "0" : txtdescription.Text;
            objsubj.ActionType = EnumActionType.Select;
            objsubj.PageSize = pagesize;
            objsubj.CurrentIndex = curIndex;
            objsubj.AcademicSessionID = LoginToken.AcademicSessionID;
            objsubj.IsActive = ddlStatusID.SelectedIndex == 0 ? true : false;
            objsubj.SubjectCategoryID = Convert.ToInt32(ddl_category.SelectedValue==""?"0": ddl_category.SelectedValue);
            return objsubjBO.SearchSubjectDetails(objsubj);
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

        protected void btnactivate_Click(object sender, EventArgs e)
        {
            List<SubjectData> lstsublist = new List<SubjectData>();
            SubjectData objsub = new SubjectData();
            SubjectBO objsubBO = new SubjectBO();
            int index = 0;
            int count = 0;
            try
            {                // get all the record from the gridview
                foreach (GridViewRow row in GvSubjectdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label SubjectID = (Label)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    CheckBox chk = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
                    SubjectData ObjDetails = new SubjectData();
                    if (chk.Checked)
                    {
                        ObjDetails.SubjectID = Convert.ToInt32(SubjectID.Text);
                        count = count + 1;
                        // ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
                        lstsublist.Add(ObjDetails);
                        index++;
                    }
                }
                objsub.Xmlsublist = XmlConvertor.ActivatedsubjecttoXML(lstsublist).ToString();
                if (count == 0)
                {
                    Messagealert_.ShowMessage(lblresult, "Please select atleast one Class", 0);
                    return;
                }
                int results = objsubBO.AcitvateSubject(objsub);
                if (results == 1)
                {
                    Messagealert_.ShowMessage(lblresult, "Successfully activated", 1);
                    bindgrid(1);
                }
                else
                {
                    Messagealert_.ShowMessage(lblresult, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            divsearch.Visible = false;
            //ddlclass.SelectedIndex = 0;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtdescription.Text = "";
            ddl_category.SelectedIndex = 0;
            ddlStatusID.SelectedIndex = 0;
            bindgrid(1);
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
                Response.AddHeader("content-disposition", "attachment;filename= SubjectDetails.xlsx");
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
            List<SubjectData> SubjectTypeDetail = getSubjectdetails(1, size);
            List<SubjectTypeDatatoExcel> subjecttypetoexcel = new List<SubjectTypeDatatoExcel>();
            int i = 0;
            foreach (SubjectData row in SubjectTypeDetail)
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
                //PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                //LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            List<SubjectData> lststudentlist = new List<SubjectData>();
            SubjectData objsubject = new SubjectData();
            SubjectBO objstdBO = new SubjectBO();

            try
            {
                // get all the record from the gridview
                foreach (GridViewRow row in GvSubjectdetails.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    CheckBox ChkGrade = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkgrade");
                    CheckBox chkOptional = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkOptional");
                    CheckBox chkAlternative = (CheckBox)GvSubjectdetails.Rows[row.RowIndex].Cells[0].FindControl("chkAlternative");
                    Label SubjectID = (Label)GvSubjectdetails.Rows[row.RowIndex].Cells[1].FindControl("lblID");
                    DropDownList SubjectCategory = (DropDownList)GvSubjectdetails.Rows[row.RowIndex].Cells[6].FindControl("ddlcategory");

                    SubjectData ObjDetails = new SubjectData();
                    ObjDetails.SubjectID = Convert.ToInt32(SubjectID.Text);
                    ObjDetails.IsGrade = Convert.ToInt32(ChkGrade.Checked ? 1 : 0);
                    ObjDetails.IsOptional = Convert.ToInt32(chkOptional.Checked ? 1 : 0);
                    ObjDetails.IsAlternative = Convert.ToInt32(chkAlternative.Checked ? 1 : 0);
                    ObjDetails.SubjectCategoryID = Convert.ToInt32(SubjectCategory.SelectedValue == "" ? "0" : SubjectCategory.SelectedValue);
                    lststudentlist.Add(ObjDetails);
                }
                objsubject.SubjectlistXML = XmlConvertor.SubjectListtoXML(lststudentlist).ToString();
                objsubject.AcademicSessionID = LoginToken.AcademicSessionID;
                int results = objstdBO.UpdateSubjectList(objsubject);
                if (results == 1)
                {
                    bindgrid(1);
                    btnupdate.Enabled = false;
                    Messagealert_.ShowMessage(lblmessage, "update", 1);
                }
                else
                {
                    btnupdate.Enabled = true;
                    Messagealert_.ShowMessage(lblmessage, "Error", 0);
                }
            }
            catch (Exception ex)
            {
                //PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                //LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                //lblmessage.Visible = true;
                //lblmessage.CssClass = "Message";
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
    }
}