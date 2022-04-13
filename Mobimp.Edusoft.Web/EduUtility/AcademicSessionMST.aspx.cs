using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduUtility
{
    public partial class AcademicSessionMST : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                ddlstatus.SelectedIndex = 0;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                AcademicSessionData objAcademic = new AcademicSessionData();
                AcademicSessionBO objAcademicBO = new AcademicSessionBO();
                objAcademic.Code = txtcode.Text;
                objAcademic.Descriptions = txtdescription.Text;
                objAcademic.Status = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
                DateTime From = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objAcademic.DateFrom = From;
                DateTime To = txtto.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                objAcademic.DateTo = To;
                objAcademic.UserId = LoginToken.UserLoginId;
                objAcademic.AddedBy = LoginToken.LoginId;
                objAcademic.CompanyID = LoginToken.CompanyID;
                objAcademic.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objAcademic.ActionType = EnumActionType.Update;
                    objAcademic.ID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objAcademicBO.UpdateAcademicSession(objAcademic);
                if (result == 1 || result == 2)
                {
                    clearall();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage(result == 1 ? "save" : "update") + "')", true);
                    ViewState["ID"] = null;
                    btnsave.Text = "Add";
                }
                if (result == 5)
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
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<AcademicSessionData> lstclass = GetAcademicdetails(index, pagesize);
            if (lstclass.Count > 0)
            {
                GvAcademicDetails.PageSize = pagesize;
                string record = lstclass[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstclass[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstclass[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvAcademicDetails.VirtualItemCount = lstclass[0].MaximumRows;//total item is required for custom paging
                GvAcademicDetails.PageIndex = index - 1;
                GvAcademicDetails.DataSource = lstclass;
                GvAcademicDetails.DataBind();
                ds = ConvertToDataSet(lstclass);
                TableCell tableCell = GvAcademicDetails.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvAcademicDetails.DataSource = null;
                GvAcademicDetails.DataBind();
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
        public List<AcademicSessionData> GetAcademicdetails(int curIndex, int pagesize)
        {
            AcademicSessionData objAcademic = new AcademicSessionData();
            AcademicSessionBO objAcademicBO = new AcademicSessionBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objAcademic.Code = txtcode.Text == "" ? null : txtcode.Text;
            objAcademic.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objAcademic.Status = Convert.ToInt32(ddlstatus.SelectedValue == "" ? "0" : ddlstatus.SelectedValue);
            objAcademic.DateFrom = from;
            objAcademic.DateTo = To;
            objAcademic.ActionType = EnumActionType.Select;
            objAcademic.PageSize = pagesize;
            objAcademic.CurrentIndex = curIndex;
            return objAcademicBO.SearchAcademicSessionDetails(objAcademic);
        }
        protected void GvAcademicDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    AcademicSessionData objAcademic = new AcademicSessionData();
                    AcademicSessionBO objAcademicBO = new AcademicSessionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvAcademicDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objAcademic.ID = Convert.ToInt32(ID.Text);
                    objAcademic.ActionType = EnumActionType.Select;
                    List<AcademicSessionData> GetResult = objAcademicBO.GetAcademicSessionDetailsByID(objAcademic);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Code;
                        txtdescription.Text = GetResult[0].Descriptions;
                        ddlstatus.SelectedValue = GetResult[0].Status.ToString();
                        txtfrom.Text = GetResult[0].DateFrom.ToString("dd/MM/yyyy,dd-MM-yyyy");
                        txtto.Text = GetResult[0].DateTo.ToString("dd/MM/yyyy,dd-MM-yyyy");
                        ViewState["ID"] = GetResult[0].ID;
                        btnsave.Text = "Update";
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    AcademicSessionData objAcademic = new AcademicSessionData();
                    AcademicSessionBO objAcademicBO = new AcademicSessionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvAcademicDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objAcademic.Remarks = txtremarks.Text;
                    }
                    objAcademic.ID = Convert.ToInt32(ID.Text);
                    objAcademic.ActionType = EnumActionType.Delete;
                    int Result = objAcademicBO.DeleteAcademicSessionDetailsByID(objAcademic);
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
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            ddlstatus.SelectedIndex = 0;
            txtfrom.Text = "";
            txtto.Text = "";
            bindgrid(1);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            clearall();
            bindgrid(1);
            lblmessage.Visible = false;
        }
        protected void GvAcademicDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAcademicDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void GvAcademicDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvAcademicDetails.DataSource = sortedView;
                    GvAcademicDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvAcademicDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void bindresponsive()
        {
            //Responsive 
            GvAcademicDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvAcademicDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvAcademicDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvAcademicDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvAcademicDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvClassDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvAcademicDetails.UseAccessibleHeader = true;
            GvAcademicDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
                wb.Worksheets.Add(dt, "Session List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= AcademicSession.xlsx");
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
            List<AcademicSessionData> AcademicSessionDetail = GetAcademicdetails(1, size);
            List<AcademicSessionDatatoExcel> AcademicSessiontoexcel = new List<AcademicSessionDatatoExcel>();
            int i = 0;
            foreach (AcademicSessionData row in AcademicSessionDetail)
            {
                AcademicSessionDatatoExcel EcxeclStd = new AcademicSessionDatatoExcel();
                EcxeclStd.Code = AcademicSessionDetail[i].Code;
                EcxeclStd.Details = AcademicSessionDetail[i].Descriptions;
                EcxeclStd.DateFrom = AcademicSessionDetail[i].DateFrom;
                EcxeclStd.DateTo = AcademicSessionDetail[i].DateTo;
                EcxeclStd.Remarks = AcademicSessionDetail[i].Remarks;
                EcxeclStd.Status = AcademicSessionDetail[i].ExcelStatus;
                AcademicSessiontoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(AcademicSessiontoexcel);
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
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["ID"] == null)
            {
                bindgrid(1);
            }

        }
        protected void GvAcademicDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gvr in GvAcademicDetails.Rows)
            {
                Label status = (Label)gvr.FindControl("lblstatuss");
                if (status.Text == "0")
                {
                    gvr.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.Transparent;
                }
            }
        }
        //protected void Pager_PageCommand(object sender, PagerEventArgs e)
        //{
        //    List<AcademicSessionData> lstacademic = getdAcademicdetails(e.PageIndex);

        //    AcademicPager.PageSize = GvAcademicDetails.PageSize;
        //    AcademicPager.TotalRecords = lstacademic[0].MaximumRows;
        //    GvAcademicDetails.DataSource = lstacademic;
        //    GvAcademicDetails.DataBind();

        //    if (lstacademic.Count >= 1)
        //    {
        //        AcademicPager.Visible = true;
        //    }
        //    else
        //    {
        //        AcademicPager.Visible = false;
        //    }
        //}
    }
}