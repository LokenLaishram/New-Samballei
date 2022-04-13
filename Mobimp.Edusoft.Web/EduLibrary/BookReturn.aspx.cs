using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.BussinessProcess.EduUtility;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduLibrary;
using Mobimp.Edusoft.BussinessProcess.EduLibrary;
using Mobimp.Edusoft.Data.EduFees;
using Mobimp.Edusoft.BussinessProcess.EduFees;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduLibrary
{
    public partial class BookReturn : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
                Bindddls();
                Bindddls2();
            }
        }
        protected void Bindddls()
        {
            AutoCompleteExtender2.ContextKey = ddltype.SelectedValue;
        }
        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
          AutoCompleteExtender2.ContextKey = ddltype.SelectedValue;
            hdnacademicid.Value = LoginToken.AcademicSessionID.ToString();
        }
   
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentDetails(string prefixText, int count, string contextKey)
        {
            ReturnBookData objdata = new ReturnBookData();
            ReturnBookBO objBO = new ReturnBookBO();
            List<ReturnBookData> getResult = new List<ReturnBookData>();
            objdata.StudentDetail = prefixText;
            objdata.TypeID = Convert.ToInt32(contextKey);
            getResult = objBO.GetAutoStudentDetails(objdata);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentDetail.ToString());
            }
            return list;
        }
        protected void studentdetail_OnTextChanged(object sender, EventArgs e)
        {
            if (txtstudent.Text != "")
            {
                ReturnBookData objdata = new ReturnBookData();
                ReturnBookBO objBO = new ReturnBookBO();
                var source = txtstudent.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtstudent.Text = "";
                    return;
                }
                objdata.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);
                List<ReturnBookData> result = objBO.GetStudentDetailByID(objdata);
                if (result.Count > 0)
                {
                    hdnstudentid.Value = result[0].StudentID.ToString();
                    hdnclassid.Value = result[0].ClassID.ToString();
                    txtissueno.Text  = result[0].IssueNo.ToString();
                }
                Bind();
            }
        }

        protected void txtissueno_TextChanged(object sender, EventArgs e)
        {
            Bind();
        }
        protected void Bind()
        {
            ReturnBookData objlist = new ReturnBookData();
            ReturnBookBO objBO = new ReturnBookBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime issuedate = txtissuedate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtissuedate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime returndate = txtreturndate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtreturndate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objlist.AcademicSessionID = LoginToken.AcademicSessionID;
            objlist.StudentID = Convert.ToInt64(hdnstudentid.Value.Trim() == "" ? "0" : hdnstudentid.Value.Trim());
            objlist.ClassID = Convert.ToInt32(hdnclassid.Value == "" ? "0" : hdnclassid.Value);
            objlist.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);
            objlist.IssueDate = issuedate;
            objlist.ReturnDate = returndate;
            objlist.IssueNo = txtissueno.Text.Trim();
            List<ReturnBookData> result = objBO.SearchBookReturnDetailsbyID(objlist);
            if (result.Count > 0)
            {
                GvBookReturnDetails.Visible = true;
                GvBookReturnDetails.DataSource = result;
                GvBookReturnDetails.DataBind();
            }
            else
            {
                GvBookReturnDetails.Visible = true;
                GvBookReturnDetails.DataSource = null;
                GvBookReturnDetails.DataBind();
            }
        }
        protected void GvBookReturnDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GvBookReturnDetails.Rows)
            {
                try
                {
                    CheckBox CheckB = (CheckBox)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("chkisreturn");
                    Label isreturn = (Label)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("lblisreturn");
                    Label returnstatus = (Label)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("lblreturnstatus");
                    if (isreturn.Text == "1")
                    {
                        returnstatus.CssClass = "indicator";
                        CheckB.Visible = false;
                        returnstatus.Visible = true;
                        returnstatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        returnstatus.CssClass = "indicator2";
                        CheckB.Visible = true;
                        returnstatus.Visible = false;
                    }
                }

                catch (Exception ex)
                {
                    LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                    //lblmessage.Text = ExceptionMessage.GetMessage(ex);
                }
            }

        }
        protected void checkboxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnsave.Attributes.Remove("disabled");
            foreach (GridViewRow gvr in GvBookReturnDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvr.FindControl("chkisreturn");
                if (chk.Checked)
                {
                    gvr.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.Transparent;
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                int index = 0;
                List<ReturnBookData> ItemList = new List<ReturnBookData>();
                ReturnBookData objitem = new ReturnBookData();
                ReturnBookBO objBO = new ReturnBookBO();
                foreach (GridViewRow row in GvBookReturnDetails.Rows)
                {
                    CheckBox chkisreturn = (CheckBox)GvBookReturnDetails.Rows[index].Cells[0].FindControl("chkisreturn");
                    if (chkisreturn.Checked==true)
                    {
                        Label lblissueid = (Label)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("lblissueid");
                        Label lbhid = (Label)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("lbHID");
                        Label lblqty = (Label)GvBookReturnDetails.Rows[row.RowIndex].Cells[0].FindControl("lblqty");
                        ReturnBookData objlist = new ReturnBookData();
                    
                        objlist.IsReturn = 1;
                        objlist.IssueID = Convert.ToInt32(lblissueid.Text == "" ? "0" : lblissueid.Text);
                        objlist.HID = Convert.ToInt32(lbhid.Text == "" ? "0" : lbhid.Text);
                        objlist.Qty = Convert.ToInt32(lblqty.Text == "" ? "0" : lblqty.Text);
                        ItemList.Add(objlist);                       
                    }
                    index++;
                }
                objitem.XmlBookReturnlist = XmlConvertor.BookReturnListXML(ItemList).ToString();
                objitem.StudentID = Convert.ToInt32(hdnstudentid.Value == "" ? "0" : hdnstudentid.Value);
                objitem.ClassID = Convert.ToInt32(hdnclassid.Value == "" ? "0" : hdnclassid.Value);
                //objitem.TotalItemQty = Convert.ToInt32(lbltotalqty.Text == "" ? "0" : lbltotalqty.Text);
                objitem.ModifiedBy = LoginToken.LoginId;
                objitem.AcademicSessionID = LoginToken.AcademicSessionID;
                objitem.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);

                int results = objBO.UpdateBookReturnDetails(objitem);
                if (results > 0)
                {
                    hdnissueno.Value = results.ToString();
                    btnsave.Attributes["disabled"] = "disabled";
                    btnprint.Attributes.Remove("disabled");
                    Bind();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                    
                }
                else
                {
                    btnsave.Attributes["disabled"] = "disabled";
                    btnprint.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
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
            txtissueno.Text = "";
            txtstudent.Text = "";
            txtreturndate.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Bindddls();
            ddltype.SelectedValue = "1";
            clearall();
            GvBookReturnDetails.DataSource = null;
            GvBookReturnDetails.DataBind();
        }

        //--------------------------TAB-2----------------------------//
        protected void Bindddls2()
        {
            AutoCompleteExtender3.ContextKey = ddltype2.SelectedValue;
        }
        protected void ddltype2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoCompleteExtender3.ContextKey = ddltype2.SelectedValue;
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetStudentDetails2(string prefixText, int count, string contextKey)
        {
            ReturnBookData objdata = new ReturnBookData();
            ReturnBookBO objBO = new ReturnBookBO();
            List<ReturnBookData> getResult = new List<ReturnBookData>();
            objdata.StudentDetail = prefixText;
            objdata.TypeID = Convert.ToInt32(contextKey);
            getResult = objBO.GetAutoStudentDetails(objdata);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].StudentDetail.ToString());
            }
            return list;
        }
        protected void studentdetail2_OnTextChanged(object sender, EventArgs e)
        {
            if (txtstudent.Text != "")
            {
                ReturnBookData objReturnBookData = new ReturnBookData();
                ReturnBookBO objBO = new ReturnBookBO();
                var source = txtstudent2.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objReturnBookData.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objReturnBookData.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtstudent2.Text = "";
                    return;
                }
                List<ReturnBookData> result = objBO.GetStudentDetailByID(objReturnBookData);
                if (result.Count > 0)
                {
                    hdnstudentid2.Value = result[0].StudentID.ToString();
                    hdnclassid2.Value = result[0].ClassID.ToString();
                }
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetBooksDetails2(string prefixText, int count, string contextKey)
        {
            ReturnBookData objitem = new ReturnBookData();
            ReturnBookBO objBO = new ReturnBookBO();
            List<ReturnBookData> getResult = new List<ReturnBookData>();
            objitem.BookDetails = prefixText;
            objitem.AcademicSessionID = Convert.ToInt32(contextKey);
            getResult = objBO.GetAutoBookDetails(objitem);

            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].BookDetails.ToString());
            }

            return list;
        }
        protected void bookdetail2_OnTextChanged(object sender, EventArgs e)
        {
            if (txtbook2.Text != "")
            {
                ReturnBookData objdata = new ReturnBookData();
                ReturnBookBO objBO = new ReturnBookBO();
                var source = txtbook2.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.HID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtbook2.Text = "";
                }
                List<ReturnBookData> result = objBO.GetBookDetailByID(objdata);
                if (result.Count > 0)
                {
                    hdnbookid.Value = result[0].BooksID.ToString();
                    hdngroupid.Value = result[0].GroupID.ToString();
                    hdnsubgroupid.Value = result[0].SubGroupID.ToString();
                    txtissueno.Text = result[0].IssueNo.ToString();
                    hdnbookname.Value = result[0].Books.ToString();
                    hdngroupname.Value = result[0].GroupName.ToString();
                    hdnsubgroupname.Value = result[0].SubGroupName.ToString();
                    hdnhid.Value = result[0].HID.ToString();
                }
            }
        }

        protected void GvBookreturnlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    ReturnBookData objitemdata = new ReturnBookData();
                    ReturnBookBO objDepositfeedBO = new ReturnBookBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvBookreturnlist.Rows[i];

                    Label lblissueno = (Label)gr.Cells[0].FindControl("lblissueno");
                    Label lblgenerateid = (Label)gr.Cells[0].FindControl("lblgenerateid");
                    Label lblsessionID = (Label)gr.Cells[0].FindControl("lblsessionID");
                    Label lblstudentid = (Label)gr.Cells[0].FindControl("lblstudentid");
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    txtremarks.Enabled = true;
                    if (txtremarks.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + "Please write remarks" + "')", true);
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        objitemdata.Remarks = txtremarks.Text;
                    }
                    objitemdata.IssueNo = lblissueno.Text == "" ? "null" : lblissueno.Text;
                    objitemdata.GenerateID = Convert.ToInt16(lblgenerateid.Text == "" ? "0" : lblgenerateid.Text);
                    objitemdata.StudentID = Convert.ToInt16(lblstudentid.Text == "" ? "0" : lblstudentid.Text);
                    objitemdata.AcademicSessionID = Convert.ToInt32(lblsessionID.Text == "" ? "0" : lblsessionID.Text);
                    objitemdata.UserId = LoginToken.UserLoginId;
                    objitemdata.ModifiedBy = LoginToken.LoginId;
                    int Result = objDepositfeedBO.DeleteBookIssueNo(objitemdata);
                    if (Result == 1)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("delete") + "')", true);
                        GetReturnlist();
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
            GetReturnlist();
        }
        protected void GetReturnlist()
        {
            ReturnBookData objlist = new ReturnBookData();
            ReturnBookBO objBO = new ReturnBookBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtdatefrom2.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom2.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtdateto2.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto2.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objlist.AcademicSessionID = LoginToken.AcademicSessionID;
            objlist.StudentID = Convert.ToInt64(hdnstudentid2.Value.Trim() == "" ? "0" : hdnstudentid2.Value.Trim());
            objlist.ClassID = Convert.ToInt32(hdnclassid2.Value == "" ? "0" : hdnclassid2.Value);
            //objlist.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objlist.IsActive = ddlstatus2.SelectedValue == "1" ? true : false; 
            objlist.PageSize = GvBookreturnlist.PageSize;
            objlist.CurrentIndex = 0;
            objlist.Datefrom = from;
            objlist.Dateto = To;
            objlist.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);
            List<ReturnBookData> result = objBO.SearchBookReturnDetails(objlist);
            if (result.Count > 0)
            {
                GvBookreturnlist.Visible = true;
                GvBookreturnlist.DataSource = result;
                GvBookreturnlist.DataBind();
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
            }
            else
            {
                //lblnetqty.Text = "0";
                GvBookreturnlist.Visible = true;
                GvBookreturnlist.DataSource = null;
                GvBookreturnlist.DataBind();
            }
        }
        protected void GvBookreturnlist_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ReturnBookData objitemData = new ReturnBookData();
                    ReturnBookBO objitemBO = new ReturnBookBO();
                    Label issueno = (Label)e.Row.FindControl("lblissueno");
                    objitemData.IssueNo = issueno.Text.Trim();
                    List<ReturnBookData> GetResult = objitemBO.SearchReturnBookByIssueNo(objitemData);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChild");
                        SC.DataSource = GetResult;
                        SC.DataBind();
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
        protected void btncancel2_Click(object sender, EventArgs e)
        {
            Bindddls2();
            ddltype.SelectedValue = "1";
            GvBookReturnDetails.DataSource = null;
            GvBookReturnDetails.DataBind();
            txtstudent2.Text = ""; txtbook2.Text = ""; txtdatefrom2.Text = ""; txtdateto2.Text = "";
        }

        protected void bindresponsive()
        {
            //Responsive 
            GvBookReturnDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvBookReturnDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvBookReturnDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvBookReturnDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvBookReturnDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvBookReturnDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvBookReturnDetails.UseAccessibleHeader = true;
            GvBookReturnDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvBookreturnlist_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                String ColumnName = e.SortExpression;
                int ColumnIndex = GetColumnIndexByDBName(sender as GridView, ColumnName);
                //bindgrid(1);
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
                    GvBookReturnDetails.DataSource = sortedView;
                    GvBookReturnDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvBookReturnDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvBookreturnlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GvBookReturnDetails.PageIndex = e.NewPageIndex;
            //bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void ddl_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bindgrid(1);
        }
        protected void ExportoExcel()
        {
            //DataTable dt = GetDatafromDatabase();
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt, "Book List");
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;filename= AddBooklist.xlsx");
            //    using (MemoryStream MyMemoryStream = new MemoryStream())
            //    {
            //        wb.SaveAs(MyMemoryStream);
            //        MyMemoryStream.WriteTo(Response.OutputStream);
            //        Response.Flush();
            //        Response.End();
            //    }
            //}
        }
        //protected DataTable GetDatafromDatabase()
        //{
        //    //int size = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
        //    //List<ReturnBookData> grpDetail = GetRackSubGroupdetails(1, size);
        //    //List<AddBookToRackDatatoExcel> grptoexcel = new List<AddBookToRackDatatoExcel>();
        //    //int i = 0;
        //    //foreach (ReturnBookData row in grpDetail)
        //    //{
        //    //    AddBookToRackDatatoExcel EcxeclStd = new AddBookToRackDatatoExcel();
        //    //    EcxeclStd.GroupName = grpDetail[i].GroupName;
        //    //    EcxeclStd.SubGroupName = grpDetail[i].SubGroupName;
        //    //    grptoexcel.Add(EcxeclStd);
        //    //    i++;
        //    //}
        //    //ListtoDataTableConverter converter = new ListtoDataTableConverter();
        //    //DataTable dt = converter.ToDataTable(grptoexcel);
        //    //return dt;

        //}
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
    }
}