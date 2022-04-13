using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Campusoft.Data.EduFeeUtility;
using Mobimp.Campusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class StudentTypeMST : BasePage
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindgrid(1);
                Tap2Bindgrid(1);
                Tap3Bindgrid(1);
            }
        }
        // TAB 1
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                StudentTypeData objstudent = new StudentTypeData();
                StudentTypeBO obstudentBO = new StudentTypeBO();
                objstudent.Code = txtcode.Text;
                objstudent.Descriptions = txtdescription.Text;
                objstudent.UserId = LoginToken.UserLoginId;
                objstudent.AddedBy = LoginToken.LoginId;
                objstudent.CompanyID = LoginToken.CompanyID;
                objstudent.IsActive = ddlstatus.SelectedValue == "1" ? true : false; ;
                objstudent.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objstudent.ActionType = EnumActionType.Update;
                    objstudent.StudenttypeID = Convert.ToInt32(ViewState["ID"].ToString());

                }
                int result = obstudentBO.UpdateStudentType(objstudent);
                if (result == 1 || result == 2)
                {

                    //clearall();
                    Bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";

                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    clearall();
                    GvMainStudentTypeDetails.DataSource = GetStudentdetails(1,10);
                    GvMainStudentTypeDetails.DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                Bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {

                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void GvMainStudentTypeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    StudentTypeData objstd = new StudentTypeData();
                    StudentTypeBO objstdBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvMainStudentTypeDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstd.StudenttypeID = Convert.ToInt32(ID.Text);
                    objstd.ActionType = EnumActionType.Select;

                    List<StudentTypeData> GetResult = objstdBO.GetStudenttypeByID(objstd);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ViewState["ID"] = GetResult[0].StudenttypeID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    StudentTypeData objstudent = new StudentTypeData();
                    StudentTypeBO obstudentBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvMainStudentTypeDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstudent.StudenttypeID = Convert.ToInt32(ID.Text);
                    objstudent.ActionType = EnumActionType.Delete;
                    int Result = obstudentBO.DeleteStudentDetailsByID(objstudent);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        Bindgrid(1);
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
            Bindgrid(1);
        }
        private void Bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StudentTypeData> lststudenttype = GetStudentdetails(index, pagesize);
            if (lststudenttype.Count > 0)
            {
                GvMainStudentTypeDetails.PageSize = pagesize;
                string record = lststudenttype[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lststudenttype[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lststudenttype[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                divsearch.Visible = true;
                GvMainStudentTypeDetails.VirtualItemCount = lststudenttype[0].MaximumRows;//total item is required for custom paging
                GvMainStudentTypeDetails.PageIndex = index - 1;
                GvMainStudentTypeDetails.DataSource = lststudenttype;
                GvMainStudentTypeDetails.DataBind();
                ds = ConvertToDataSet(lststudenttype);
                TableCell tableCell = GvMainStudentTypeDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvMainStudentTypeDetails.DataSource = null;
                GvMainStudentTypeDetails.DataBind();
                divsearch.Visible = true;
            }

        }
        protected void bindresponsive()
        {
            //Responsive 
            GvMainStudentTypeDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvMainStudentTypeDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvMainStudentTypeDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvMainStudentTypeDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvMainStudentTypeDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
           
            //GvMainStudentTypeDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvMainStudentTypeDetails.UseAccessibleHeader = true;
            GvMainStudentTypeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        public List<StudentTypeData> GetStudentdetails(int curIndex, int pagesize)
        {
            StudentTypeData objstdtype = new StudentTypeData();
            StudentTypeBO objstdBO = new StudentTypeBO();
            objstdtype.Code = txtcode.Text == "" ? null : txtcode.Text;
            objstdtype.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objstdtype.ActionType = EnumActionType.Select;
            objstdtype.PageSize = pagesize;
            objstdtype.CurrentIndex = curIndex;
            objstdtype.IsActive = ddlstatus.SelectedValue == "1" ? true : false;
            return objstdBO.SearchStudentTypeList(objstdtype);
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            divsearch.Visible = false;
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            Bindgrid(1);

        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindgrid(1);
        }
        protected void ExportoExcel()
        {
            DataTable dt = GetDatafromDatabase();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Student Type");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= StudentTypeDetails.xlsx");
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
            List<StudentTypeData> MainStdtypeDetail = GetStudentdetails(1, size);
            List<MainStdTypeDatatoExcel> mainStdtypetoexcel = new List<MainStdTypeDatatoExcel>();
            int i = 0;
            foreach (StudentTypeData row in MainStdtypeDetail)
            {
                MainStdTypeDatatoExcel EcxeclStd = new MainStdTypeDatatoExcel();
                EcxeclStd.Code = MainStdtypeDetail[i].Code;
                EcxeclStd.Descriptions = MainStdtypeDetail[i].Descriptions;
                mainStdtypetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(mainStdtypetoexcel);
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
            Bindgrid(1);
        }
        protected void GvMainStudentTypeDetails_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                Bindgrid(1);
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
                    GvMainStudentTypeDetails.DataSource = sortedView;
                    GvMainStudentTypeDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvMainStudentTypeDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvMainStudentTypeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvMainStudentTypeDetails.PageIndex = e.NewPageIndex;
            Bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }


        //TAB 2
        protected void btntap2save_Click(object sender, EventArgs e)
        {
            try
            {
                StudentTypeData objstudent = new StudentTypeData();
                StudentTypeBO obstudentBO = new StudentTypeBO();
                objstudent.Code = txttap2code.Text;
                objstudent.Descriptions = txttap2description.Text;
                objstudent.UserId = LoginToken.UserLoginId;
                objstudent.AddedBy = LoginToken.LoginId;
                objstudent.CompanyID = LoginToken.CompanyID;
                objstudent.IsActive = ddltap2status.SelectedValue == "1" ? true : false;
                objstudent.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objstudent.ActionType = EnumActionType.Update;
                    objstudent.TransportStudenttypeID = Convert.ToInt32(ViewState["ID"].ToString());


                }
                int result = obstudentBO.UpdateTranportStudentType(objstudent);
                if (result == 1 || result == 2)
                {
                    Tap2Bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    Tap2clearall();
                    GvTranportStudentType.DataSource = getTransportStudentdetails(1,10);
                    GvTranportStudentType.DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                Tap2Bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                //PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                //LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                //lbltap2message.Text = ExceptionMessage.GetMessage(ex);
                //lbltap2message.Visible = true;
                //lbltap2message.CssClass = "MessageFailed";
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        //protected void Tap2Pager_PageCommand(object sender, PagerEventArgs e)
        //{
        //    List<StudentTypeData> lsttranpstudent = getTransportStudentdetails(e.PageIndex);

        //    TransportStudentPager.PageSize = GvStudentDetails.PageSize;
        //    TransportStudentPager.TotalRecords = lsttranpstudent[0].MaximumRows;
        //    GvTranportStudentType.DataSource = lsttranpstudent;
        //    GvTranportStudentType.DataBind();

        //    if (lsttranpstudent.Count >= 1)
        //    {
        //        TransportStudentPager.Visible = true;
        //    }
        //    else
        //    {
        //        TransportStudentPager.Visible = false;
        //    }

        //}
        protected void GvTranportStudentType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    StudentTypeData objstd = new StudentTypeData();
                    StudentTypeBO objstdBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTranportStudentType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstd.TransportStudenttypeID = Convert.ToInt32(ID.Text);
                    objstd.ActionType = EnumActionType.Select;

                    List<StudentTypeData> GetResult = objstdBO.GetTransportStudenttypeByID(objstd);
                    if (GetResult.Count > 0)
                    {
                        txttap2code.Text = GetResult[0].Code;
                        txttap2description.Text = GetResult[0].Descriptions;
                       // ddltap2status.SelectedValue = GetResult[0].IsActive.ToString();
                        ViewState["ID"] = GetResult[0].TransportStudenttypeID;
                        btntap2save.Text = "Update";
                        bindresponsive1();
                        
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    StudentTypeData objstudent = new StudentTypeData();
                    StudentTypeBO obstudentBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvTranportStudentType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstudent.TransportStudenttypeID = Convert.ToInt32(ID.Text);
                    objstudent.ActionType = EnumActionType.Delete;
                    int Result = obstudentBO.DeleteTransportStudentDetailsByID(objstudent);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        Tap2Bindgrid(1);
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
        protected void btntap2search_Click(object sender, EventArgs e)
        {
            Tap2Bindgrid(1);

        }
        
        private void Tap2Bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show1.SelectedValue == "10000" ? lbl_totalrecords1.Text : ddl_show1.SelectedValue);
            List<StudentTypeData> lsttranpstudenttype = getTransportStudentdetails(index, pagesize);
            if (lsttranpstudenttype.Count > 0)
            {
                GvTranportStudentType.PageSize = pagesize;
                string record = lsttranpstudenttype[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult1.Text = "Total : " + lsttranpstudenttype[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords1.Text = lsttranpstudenttype[0].MaximumRows.ToString(); ;
                lblresult1.Visible = true;
                divsearch1.Visible = true;
                GvTranportStudentType.VirtualItemCount = lsttranpstudenttype[0].MaximumRows;//total item is required for custom paging
                GvTranportStudentType.PageIndex = index - 1;
                GvTranportStudentType.DataSource = lsttranpstudenttype;
                GvTranportStudentType.DataBind();
                ds = ConvertToDataSet(lsttranpstudenttype);
                TableCell tableCell = GvTranportStudentType.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive1();
            }
            else
            {
                GvTranportStudentType.DataSource = null;
                GvTranportStudentType.DataBind();
                divsearch1.Visible = true;
            }

        }
        protected void bindresponsive1()
        {
            //Responsive 
            GvTranportStudentType.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvTranportStudentType.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvTranportStudentType.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvTranportStudentType.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvTranportStudentType.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //GvMainStudentTypeDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvTranportStudentType.UseAccessibleHeader = true;
            GvTranportStudentType.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        public DataSet ConvertToDataSet1<T>(IList<T> list)
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
        public SortDirection dir1
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
        static public int GetColumnIndexByDBName1(GridView aGridView, String ColumnText)
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
        public List<StudentTypeData> getTransportStudentdetails(int curIndex, int pagesize)
        {
            StudentTypeData objstdtype = new StudentTypeData();
            StudentTypeBO objstdBO = new StudentTypeBO();
            objstdtype.Code = txttap2code.Text == "" ? null : txttap2code.Text;
            objstdtype.Descriptions = txttap2description.Text == "" ? null : txttap2description.Text;
            objstdtype.IsActive = ddltap2status.SelectedValue == "1" ? true : false;
            objstdtype.ActionType = EnumActionType.Select;
            objstdtype.PageSize = GvTranportStudentType.PageSize;
            objstdtype.CurrentIndex = curIndex;
            return objstdBO.SearchTransportStudentTypeList(objstdtype);

        }
        private void Tap2clearall()
        {
            txttap2code.Text = "";
            txttap2description.Text = "";
            divsearch1.Visible = false;
        }
        protected void btntap2cancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            Response.Redirect("StudentTypeMST.aspx");
            divsearch1.Visible = false;
        }
        protected void ddl_show1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tap2Bindgrid(1);
        }
        protected void ExportoExcel1()
        {
            DataTable dt = GetDatafromDatabase1();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Student Type");
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
        protected DataTable GetDatafromDatabase1()
        {
            int size = Convert.ToInt32(ddl_show1.SelectedValue == "10000" ? lbl_totalrecords1.Text : ddl_show1.SelectedValue);
            List<StudentTypeData> transportStdtypeDetail = getTransportStudentdetails(1, size);
            List<TransportStdTypeDatatoExcel> transStdtypetoexcel = new List<TransportStdTypeDatatoExcel>();
            int i = 0;
            foreach (StudentTypeData row in transportStdtypeDetail)
            {
                TransportStdTypeDatatoExcel EcxeclTransStd = new TransportStdTypeDatatoExcel();
                EcxeclTransStd.Code = transportStdtypeDetail[i].Code;
                EcxeclTransStd.Descriptions = transportStdtypeDetail[i].Descriptions;
                transStdtypetoexcel.Add(EcxeclTransStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(transStdtypetoexcel);
            return dt;

        }
        public class ListtoDataTableConverter1
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
        protected void btn_export1_Click(object sender, EventArgs e)
        {
            ExportoExcel1();
        }
        protected void ddlstatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tap2Bindgrid(1);
        }
        protected void GvTranportStudentType_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                Tap2Bindgrid(1);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                {
                    string SortDir = string.Empty;
                    if (dir1 == SortDirection.Ascending)
                    {
                        dir1 = SortDirection.Descending;
                        SortDir = "Desc";
                    }
                    else
                    {
                        dir1 = SortDirection.Ascending;
                        SortDir = "Asc";
                    }
                    DataView sortedView = new DataView(dt);
                    sortedView.Sort = e.SortExpression + " " + SortDir;
                    GvTranportStudentType.DataSource = sortedView;
                    GvTranportStudentType.DataBind();
                    bindresponsive1();
                    TableCell tableCell = GvTranportStudentType.HeaderRow.Cells[ColumnIndex];
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
        protected void GvTranportStudentType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTranportStudentType.PageIndex = e.NewPageIndex;
            Tap2Bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }

        //TAB 3
        protected void btntab3save_Click(object sender, EventArgs e)
        {
            try
            {
                StudentTypeData objstudent = new StudentTypeData();
                StudentTypeBO obstudentBO = new StudentTypeBO();
                objstudent.Code = txttab3code.Text;
                objstudent.Descriptions = txttab3description.Text;
                objstudent.UserId = LoginToken.UserLoginId;
                objstudent.AddedBy = LoginToken.LoginId;
                objstudent.CompanyID = LoginToken.CompanyID;
                objstudent.IsActive = ddltab3status.SelectedValue == "1" ? true : false;
                objstudent.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objstudent.ActionType = EnumActionType.Update;
                    objstudent.StudenttypeID = Convert.ToInt32(ViewState["ID"].ToString());


                }
                int result = obstudentBO.UpdateBoardingStudentType(objstudent);
                if (result == 1 || result == 2)
                {
                    Tap3Bindgrid(1);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                else if (result == 5)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("duplicate") + "')", true);
                    Tap3clearall();
                    GvBoardingStudentType.DataSource = getBoardingStudentdetails(1, 10);
                    GvBoardingStudentType.DataBind();
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
                }
                Tap3Bindgrid(1);
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                //PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                //LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                //lbltap2message.Text = ExceptionMessage.GetMessage(ex);
                //lbltap2message.Visible = true;
                //lbltap2message.CssClass = "MessageFailed";
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        //protected void Tap2Pager_PageCommand(object sender, PagerEventArgs e)
        //{
        //    List<StudentTypeData> lsttranpstudent = getBoardingStudentdetails(e.PageIndex);

        //    TransportStudentPager.PageSize = GvStudentDetails.PageSize;
        //    TransportStudentPager.TotalRecords = lsttranpstudent[0].MaximumRows;
        //    GvBoardingStudentType.DataSource = lsttranpstudent;
        //    GvBoardingStudentType.DataBind();

        //    if (lsttranpstudent.Count >= 1)
        //    {
        //        TransportStudentPager.Visible = true;
        //    }
        //    else
        //    {
        //        TransportStudentPager.Visible = false;
        //    }

        //}
        protected void GvBoardingStudentType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    StudentTypeData objstd = new StudentTypeData();
                    StudentTypeBO objstdBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvBoardingStudentType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstd.StudenttypeID = Convert.ToInt32(ID.Text);
                    objstd.ActionType = EnumActionType.Select;

                    List<StudentTypeData> GetResult = objstdBO.GetBoardingStudenttypeByID(objstd);
                    if (GetResult.Count > 0)
                    {
                        txttab3code.Text = GetResult[0].Code;
                        txttab3description.Text = GetResult[0].Descriptions;
                       // ddltab3status.SelectedValue = GetResult[0].IsActive.ToString();
                        ViewState["ID"] = GetResult[0].StudenttypeID;
                        btntab3save.Text = "Update";
                        bindresponsive2();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    StudentTypeData objstudent = new StudentTypeData();
                    StudentTypeBO obstudentBO = new StudentTypeBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvBoardingStudentType.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objstudent.StudenttypeID = Convert.ToInt32(ID.Text);
                    objstudent.ActionType = EnumActionType.Delete;
                    int Result = obstudentBO.DeleteBoardingStudentDetailsByID(objstudent);
                    if (Result == 1)
                    {
                        //Messagealert_.ShowMessage(lbltap2message, "delete", 1);
                        //GvBoardingStudentType.DataSource = getBoardingStudentdetails(0);
                        //GvBoardingStudentType.DataBind();
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        Tap3Bindgrid(1);
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
        protected void btntab3search_Click(object sender, EventArgs e)
        {
            Tap3Bindgrid(1);
        }
       
        private void Tap3Bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show2.SelectedValue == "10000" ? lbl_totalrecords2.Text : ddl_show2.SelectedValue);
            List<StudentTypeData> lstboardingstudenttype = getBoardingStudentdetails(index, pagesize);
            if (lstboardingstudenttype.Count > 0)
            {
                GvBoardingStudentType.PageSize = pagesize;
                string record = lstboardingstudenttype[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult2.Text = "Total : " + lstboardingstudenttype[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords2.Text = lstboardingstudenttype[0].MaximumRows.ToString(); ;
                lblresult2.Visible = true;
                divsearch2.Visible = true;
                GvBoardingStudentType.VirtualItemCount = lstboardingstudenttype[0].MaximumRows;//total item is required for custom paging
                GvBoardingStudentType.PageIndex = index - 1;
                GvBoardingStudentType.DataSource = lstboardingstudenttype;
                GvBoardingStudentType.DataBind();
                ds = ConvertToDataSet(lstboardingstudenttype);
                TableCell tableCell = GvBoardingStudentType.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive2();
            }
            else
            {
                GvBoardingStudentType.DataSource = null;
                GvBoardingStudentType.DataBind();
                divsearch2.Visible = true;
            }

        }
        protected void bindresponsive2()
        {
            //Responsive 
            GvBoardingStudentType.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvBoardingStudentType.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvBoardingStudentType.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvBoardingStudentType.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvBoardingStudentType.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";

            //GvMainStudentTypeDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvBoardingStudentType.UseAccessibleHeader = true;
            GvBoardingStudentType.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        public DataSet ConvertToDataSet2<T>(IList<T> list)
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
        public SortDirection dir2
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
        static public int GetColumnIndexByDBName2(GridView aGridView, String ColumnText)
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

        public List<StudentTypeData> getBoardingStudentdetails(int curIndex, int pagesize)
        {
            StudentTypeData objstdtype = new StudentTypeData();
            StudentTypeBO objstdBO = new StudentTypeBO();
            objstdtype.Code = txttab3code.Text == "" ? null : txttab3code.Text;
            objstdtype.Descriptions = txttab3description.Text == "" ? null : txttab3description.Text;
            objstdtype.IsActive = ddltab3status.SelectedValue == "1" ? true : false;
            objstdtype.ActionType = EnumActionType.Select;
            objstdtype.PageSize = GvBoardingStudentType.PageSize;
            objstdtype.CurrentIndex = curIndex;
            return objstdBO.SearchBoardingStudentTypeList(objstdtype);

        }
        private void Tap3clearall()
        {
            txttab3code.Text = "";
            txttab3description.Text = "";
            divsearch2.Visible = false;
        }
        protected void btntab3cancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            Response.Redirect("StudentTypeMST.aspx");
            divsearch2.Visible = false;
        }
        protected void ddl_show2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tap3Bindgrid(1);
        }
        protected void ExportoExcel2()
        {
            DataTable dt = GetDatafromDatabase2();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Student Type");
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
        protected DataTable GetDatafromDatabase2()
        {
            int size = Convert.ToInt32(ddl_show2.SelectedValue == "10000" ? lbl_totalrecords2.Text : ddl_show2.SelectedValue);
            List<StudentTypeData> boardingStdtypeDetail = getBoardingStudentdetails(1, size);
            List<BoardingStdTypeDatatoExcel> boarStdtypetoexcel = new List<BoardingStdTypeDatatoExcel>();
            int i = 0;
            foreach (StudentTypeData row in boardingStdtypeDetail)
            {
                BoardingStdTypeDatatoExcel EcxeclboarsStd = new BoardingStdTypeDatatoExcel();
                EcxeclboarsStd.Code = boardingStdtypeDetail[i].Code;
                EcxeclboarsStd.Descriptions = boardingStdtypeDetail[i].Descriptions;
                boarStdtypetoexcel.Add(EcxeclboarsStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(boarStdtypetoexcel);
            return dt;

        }
        public class ListtoDataTableConverter2
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
        protected void btn_export2_Click(object sender, EventArgs e)
        {
            ExportoExcel2();
        }
        protected void ddlstatus2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tap3Bindgrid(1);
        }
        protected void GvBoardingStudentType_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                Tap3Bindgrid(1);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                {
                    string SortDir = string.Empty;
                    if (dir2 == SortDirection.Ascending)
                    {
                        dir2 = SortDirection.Descending;
                        SortDir = "Desc";
                    }
                    else
                    {
                        dir2 = SortDirection.Ascending;
                        SortDir = "Asc";
                    }
                    DataView sortedView = new DataView(dt);
                    sortedView.Sort = e.SortExpression + " " + SortDir;
                    GvBoardingStudentType.DataSource = sortedView;
                    GvBoardingStudentType.DataBind();
                    bindresponsive2();
                    TableCell tableCell = GvBoardingStudentType.HeaderRow.Cells[ColumnIndex];
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
        protected void GvBoardingStudentType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvBoardingStudentType.PageIndex = e.NewPageIndex;
            Tap3Bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }




    }
}