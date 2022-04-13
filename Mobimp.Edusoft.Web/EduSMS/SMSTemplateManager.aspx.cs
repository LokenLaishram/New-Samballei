using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduSMS;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.BussinessProcess.SMS;
using System.Text.RegularExpressions;

namespace Mobimp.Edusoft.Web.EduSMS
{
    public partial class SMSTemplateManager : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                bindgrid(1);
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SmsData objSMS = new SmsData();
                SmsBO objSMSBO = new SmsBO();

                string SmsDesc = txtdescription.Text;

                MatchCollection MatchResult = null;
                var regexObj = new Regex(@"#\w*#");
                MatchResult = regexObj.Matches(SmsDesc);

                if (MatchResult.Count>0)
                {
                    //string x = SmsDesc.Replace(MatchResult.ToString(), MatchResult.ToString().ToUpper());
                    foreach (Match m in MatchResult)
                    {
                        string setcase = m.Value.ToString().ToLower();
                        SmsDesc = SmsDesc.Replace(m.Value.ToString(), setcase);
                    }
                    objSMS.Descriptions = Regex.Replace(SmsDesc.Trim(), @"\s+", " ");
                }
                else
                {
                    objSMS.Descriptions = Regex.Replace(txtdescription.Text.Trim(), @"\s+", " ");
                }
                objSMS.Template = txtcode.Text;
                objSMS.UserId = LoginToken.UserLoginId;
                objSMS.AddedBy = LoginToken.LoginId;
                objSMS.CompanyID = LoginToken.CompanyID;
                objSMS.MgtType = LoginToken.MgtType;
                objSMS.IsActive = true; // ddlstatus.SelectedValue == "1" ? true : false; ;
                objSMS.ActionType = EnumActionType.Insert;
                if (ViewState["ID"] != null)
                {
                    objSMS.ActionType = EnumActionType.Update;
                    objSMS.TemplateID = Convert.ToInt32(ViewState["ID"].ToString());
                }
                int result = objSMSBO.UpdateSMSTemplateDetails(objSMS);
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
        protected void GvSMSTemplateDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edits")
                {
                    SmsData objSMS = new SmsData();
                    SmsBO objSMSBO = new SmsBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSMSTemplateDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objSMS.TemplateID = Convert.ToInt32(ID.Text);
                    List<SmsData> GetResult = objSMSBO.GetSMSTemplateDetailsByID(objSMS);
                    if (GetResult.Count > 0)
                    {
                        txtcode.Text = GetResult[0].Template;
                        txtdescription.Text = GetResult[0].Descriptions == null ? "" : GetResult[0].Descriptions;
                        ViewState["ID"] = GetResult[0].TemplateID;
                        btnsave.Text = "Update";
                        btnsave.Focus();
                        bindresponsive();
                    }
                }
                if (e.CommandName == "Deletes")
                {
                    SmsData objSMS = new SmsData();
                    SmsBO objSMSBO = new SmsBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvSMSTemplateDetails.Rows[i];
                    Label ID = (Label)gr.Cells[0].FindControl("lblID");
                    objSMS.TemplateID = Convert.ToInt32(ID.Text);
                    objSMS.ActionType = EnumActionType.Delete;
                    int Result = objSMSBO.DeleteSMSTemplateDetailsByID(objSMS);
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
            List<SmsData> lstSmsTemplate = GetSmsTemplatedetails(index, pagesize);
            if (lstSmsTemplate.Count > 0)
            {
                GvSMSTemplateDetails.PageSize = pagesize;
                string record = lstSmsTemplate[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstSmsTemplate[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstSmsTemplate[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                GvSMSTemplateDetails.VirtualItemCount = lstSmsTemplate[0].MaximumRows;//total item is required for custom paging
                GvSMSTemplateDetails.PageIndex = index - 1;
                GvSMSTemplateDetails.DataSource = lstSmsTemplate;
                GvSMSTemplateDetails.DataBind();
                ds = ConvertToDataSet(lstSmsTemplate);
                //TableCell tableCell = GvSMSTemplateDetails.HeaderRow.Cells[0];
                //Image img = new Image();
                //img.ImageUrl = "~/app-assets/images/asc.gif";
                //tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                //tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                GvSMSTemplateDetails.DataSource = null;
                GvSMSTemplateDetails.DataBind();
            }
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvSMSTemplateDetails.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            //GvSMSTemplateDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //GvSMSTemplateDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            //GvSMSTemplateDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            //GvSMSTemplateDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvSMSTemplateDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvSMSTemplateDetails.UseAccessibleHeader = true;
            GvSMSTemplateDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvSMSTemplateDetails_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvSMSTemplateDetails.DataSource = sortedView;
                    GvSMSTemplateDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvSMSTemplateDetails.HeaderRow.Cells[ColumnIndex];
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
        //protected void btnactivate_Click(object sender, EventArgs e)
        //{
        //    List<SmsData> lstSmsTemplatelist = new List<SmsData>();
        //    SmsData objSMS = new SmsData();
        //    SmsBO objSMSBO = new SmsBO();
        //    int index = 0;
        //    int count = 0;
        //    try
        //    {                // get all the record from the gridview
        //        foreach (GridViewRow row in GvSMSTemplateDetails.Rows)
        //        {
        //            IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        //            Label TemplateID = (Label)GvSMSTemplateDetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
        //            CheckBox chk = (CheckBox)GvSMSTemplateDetails.Rows[row.RowIndex].Cells[0].FindControl("chekboxselect");
        //            SmsData ObjDetails = new SmsData();
        //            if (chk.Checked)
        //            {
        //                ObjDetails.TemplateID = Convert.ToInt32(TemplateID.Text);
        //                count = count + 1;
        //                // ObjDetails.AcademicSessionID = LoginToken.AcademicSessionID;
        //                lstSmsTemplatelist.Add(ObjDetails);
        //                index++;
        //            }
        //        }
        //        objSMS.XmlSmsTemplatelist = XmlConvertor.ActivatedSmsTemplatetoXML(lstSmsTemplatelist).ToString();
        //        if (count == 0)
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Please select atleast one SmsTemplate", 0);
        //            return;
        //        }
        //        int results = objSMSBO.Activate(objSMS);
        //        if (results == 1)
        //        {
        //            bindgrid();
        //            Messagealert_.ShowMessage(lblresult, "Successfully activated", 1);
        //        }
        //        else
        //        {
        //            Messagealert_.ShowMessage(lblresult, "Error", 0);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
        //        LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
        //        lblresult.Text = ExceptionMessage.GetMessage(ex);
        //        lblresult.Visible = true;
        //        lblresult.CssSmsTemplate = "Message";
        //    }
        //}
        public List<SmsData> GetSmsTemplatedetails(int curIndex, int pagesize)
        {
            SmsData objSMS = new SmsData();
            SmsBO objSMSBO = new SmsBO();
            objSMS.Template = txtcode.Text == "" ? null : txtcode.Text;
            objSMS.Descriptions = txtdescription.Text == "" ? null : txtdescription.Text;
            objSMS.ActionType = EnumActionType.Select;
            objSMS.PageSize = pagesize;
            objSMS.CurrentIndex = curIndex;
            objSMS.IsActive = true; // ddlstatus.SelectedValue=="1"?true:false;
            return objSMSBO.SearchSmsTemplateDetails(objSMS);
        }
        private void clearall()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            ViewState["ID"] = null;
            txtcode.Text = "";
            txtdescription.Text = "";
            btnsave.Text = "Add";
            bindgrid(1);

        }
        protected void GvSMSTemplateDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvSMSTemplateDetails.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
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
                wb.Worksheets.Add(dt, "SmsTemplate List");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= SmsTemplate.xlsx");
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
            List<SmsData> SmsTemplateDetail = GetSmsTemplatedetails(1, size);
            List<SmsDatatoExcel> SmsTemplatetoexcel = new List<SmsDatatoExcel>();
            int i = 0;
            foreach (SmsData row in SmsTemplateDetail)
            {
                SmsDatatoExcel EcxeclStd = new SmsDatatoExcel();
                EcxeclStd.Template = SmsTemplateDetail[i].Template;
                EcxeclStd.Description = SmsTemplateDetail[i].Descriptions;
                SmsTemplatetoexcel.Add(EcxeclStd);
                i++;
            }
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(SmsTemplatetoexcel);
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
        
    }
}