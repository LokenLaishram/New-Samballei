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
    public partial class BookIssue : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = true;
                btnsave.Attributes["disabled"] = "disabled";
                btnprint.Attributes["disabled"] = "disabled";
                txtissuedate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            IssueBookData objdata = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();
            List<IssueBookData> getResult = new List<IssueBookData>();
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
                    IssueBookData objIssueBookData = new IssueBookData();
                    IssueBookBO objBO = new IssueBookBO();
                    var source = txtstudent.Text.ToString();
                    if (source.Contains(":"))
                    {
                        string ID = source.Substring(source.LastIndexOf(':') + 1);
                        objIssueBookData.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
                        objIssueBookData.AcademicSessionID = LoginToken.AcademicSessionID;
                    }
                    else
                    {
                        txtstudent.Text = "";
                        return;
                    }
                    objIssueBookData.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);
                    List<IssueBookData> result = objBO.GetStudentDetailByID(objIssueBookData);
                    if (result.Count > 0)
                    {
                        hdnstudentid.Value = result[0].StudentID.ToString();
                        hdnclassid.Value = result[0].ClassID.ToString();
                        //hdnsect.Value = result[0].ClassID.ToString();
                    }
                }
            }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetBooksDetails(string prefixText, int count, string contextKey)
        {
            IssueBookData objitem = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();
            List<IssueBookData> getResult = new List<IssueBookData>();
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
        protected void bookdetail_OnTextChanged(object sender, EventArgs e)
        {
            if (txtbook.Text != "")
            {
                IssueBookData objdata = new IssueBookData();
                IssueBookBO objBO = new IssueBookBO();
                var source = txtbook.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objdata.HID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objdata.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtbook.Text = "";
                }
                List<IssueBookData> result = objBO.GetBookDetailByID(objdata);
                if (result.Count > 0)
                {
                    hdnbookid.Value = result[0].BooksID.ToString();
                    hdngroupid.Value = result[0].GroupID.ToString();
                    hdnsubgroupid.Value = result[0].SubGroupID.ToString();
                    txtqty.Text = result[0].Qty.ToString();
                    hdnbookname.Value = result[0].Books.ToString();
                    hdngroupname.Value = result[0].GroupName.ToString();
                    hdnsubgroupname.Value = result[0].SubGroupName.ToString();
                    hdnhid.Value = result[0].HID.ToString();
                }
            }
        }
        protected void txtreturndate_TextChanged(object sender, EventArgs e)
        {
            IssueBookData objitem = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();

            var source = txtbook.Text.ToString();
            if (txtbook.Text != "")
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                List<IssueBookData> Itemlist = Session["Itemlist"] == null ? new List<IssueBookData>() : (List<IssueBookData>)Session["Itemlist"];
                IssueBookData objItem = new IssueBookData();
                DateTime issue = txtissuedate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtissuedate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                DateTime returns = txtreturndate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtreturndate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                objItem.GroupName = hdngroupname.Value.ToString();
                objItem.SubGroupName = hdnsubgroupname.Value.ToString();
                objItem.Books = hdnbookname.Value.ToString();
                objItem.HID = Convert.ToInt32(hdnhid.Value == "" ? "0" : hdnhid.Value);
                objItem.Qty = 1;
                objItem.IssueDate = issue;
                objItem.ReturnDate = returns;

                Itemlist.Add(objItem);

                if (Itemlist.Count > 0)
                {
                    GvBookIssueDetails.DataSource = Itemlist;
                    GvBookIssueDetails.DataBind();
                    GvBookIssueDetails.Visible = true;
                    Session["Itemlist"] = Itemlist;
                    btnsave.Attributes.Remove("disabled");
                    txtissuedate.Text = "";
                    txtreturndate.Text = "";
                    txtbook.Text = "";
                    txtbook.Focus();
                    TotalSum();
                }
                else
                {
                    GvBookIssueDetails.DataSource = null;
                    GvBookIssueDetails.DataBind();
                    GvBookIssueDetails.Visible = true;
                    btnsave.Attributes["disabled"] = "disable";
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("system") + "')", true);
            }
        }
        protected void TotalSum()
        {
            double qtytotal = 0;
            foreach (GridViewRow gvr in GvBookIssueDetails.Rows)
            {
                Label ItemID = (Label)gvr.Cells[0].FindControl("lblItemID");
                Label BookName = (Label)gvr.Cells[0].FindControl("lblbookname");
                Label qty = (Label)gvr.Cells[0].FindControl("lblqty");
                
                qtytotal = qtytotal + Convert.ToDouble(qty.Text);
            }            
            lbltotalqty.Text = qtytotal.ToString();
        }
        protected void GvBookIssueDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvBookIssueDetails.Rows[i];
                    List<IssueBookData> Itemlist = Session["Itemlist"] == null ? new List<IssueBookData>() : (List<IssueBookData>)Session["Itemlist"];
                    if (Itemlist.Count > 0)
                    {
                     //  int totalamount = Itemlist[i].TotalItemQty;
                    }
                    Itemlist.RemoveAt(i);
                    Session["Itemlist"] = Itemlist;
                    GvBookIssueDetails.DataSource = Itemlist;
                    GvBookIssueDetails.DataBind();
                    TotalSum();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                int index = 0;
                List<IssueBookData> ItemList = new List<IssueBookData>();
                IssueBookData objitem = new IssueBookData();
                IssueBookBO objBO = new IssueBookBO();
                foreach (GridViewRow row in GvBookIssueDetails.Rows)
                {
                    Label lbhid = (Label)GvBookIssueDetails.Rows[row.RowIndex].Cells[0].FindControl("lbHID");
                    Label lblbookName = (Label)GvBookIssueDetails.Rows[row.RowIndex].Cells[0].FindControl("lblbookname");
                    Label lblqty = (Label)GvBookIssueDetails.Rows[row.RowIndex].Cells[0].FindControl("lblqty");
                    Label lblissue = (Label)GvBookIssueDetails.Rows[row.RowIndex].Cells[0].FindControl("lblIssueDate");
                    Label lblreturn = (Label)GvBookIssueDetails.Rows[row.RowIndex].Cells[0].FindControl("lblReturnDate");
                    DateTime issue = lblissue.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(lblissue.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    DateTime returns = lblreturn.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(lblreturn.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    IssueBookData objlist = new IssueBookData();
                    objlist.HID = Convert.ToInt32(lbhid.Text == "" ? "0" : lbhid.Text);
                    objlist.Books = lblbookName.Text.Trim();
                    objlist.Qty = Convert.ToInt32(lblqty.Text == "" ? "0" : lblqty.Text);
                    objlist.IssueDate = issue;
                    objlist.ReturnDate = returns;
                    ItemList.Add(objlist);
                    index++;
                }
                objitem.XmlBookIssuelist = XmlConvertor.BookIssueListXML(ItemList).ToString();
                objitem.StudentID = Convert.ToInt32(hdnstudentid.Value == "" ? "0" : hdnstudentid.Value);
                objitem.ClassID = Convert.ToInt32(hdnclassid.Value == "" ? "0" : hdnclassid.Value);
                objitem.TotalItemQty = Convert.ToInt32(lbltotalqty.Text == "" ? "0" : lbltotalqty.Text);
                objitem.AddedBy = LoginToken.LoginId;
                objitem.AcademicSessionID = LoginToken.AcademicSessionID;
                objitem.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);

                int results = objBO.UpdateBookIssueDetails(objitem);
                if (results > 0)
                {
                    hdnissueno.Value = results.ToString();
                    btnsave.Attributes["disabled"] = "disabled";
                    btnprint.Attributes.Remove("disabled");
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
            txtbook.Text = "";  txtqty.Text = "";
            txtstudent.Text = "";
            txtreturndate.Text = "";
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Bindddls();
            ddltype.SelectedValue = "1";
            clearall();
            GvBookIssueDetails.DataSource = null;
            GvBookIssueDetails.DataBind();
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
            IssueBookData objdata = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();
            List<IssueBookData> getResult = new List<IssueBookData>();
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
                IssueBookData objIssueBookData = new IssueBookData();
                IssueBookBO objBO = new IssueBookBO();
                var source = txtstudent2.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    objIssueBookData.StudentID = Convert.ToInt32(ID == "" ? "0" : ID);
                    objIssueBookData.AcademicSessionID = LoginToken.AcademicSessionID;
                }
                else
                {
                    txtstudent2.Text = "";
                    return;
                }
                List<IssueBookData> result = objBO.GetStudentDetailByID(objIssueBookData);
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
            IssueBookData objitem = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();
            List<IssueBookData> getResult = new List<IssueBookData>();
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
                IssueBookData objdata = new IssueBookData();
                IssueBookBO objBO = new IssueBookBO();
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
                List<IssueBookData> result = objBO.GetBookDetailByID(objdata);
                if (result.Count > 0)
                {
                    hdnbookid.Value = result[0].BooksID.ToString();
                    hdngroupid.Value = result[0].GroupID.ToString();
                    hdnsubgroupid.Value = result[0].SubGroupID.ToString();
                    txtqty.Text = result[0].Qty.ToString();
                    hdnbookname.Value = result[0].Books.ToString();
                    hdngroupname.Value = result[0].GroupName.ToString();
                    hdnsubgroupname.Value = result[0].SubGroupName.ToString();
                    hdnhid.Value = result[0].HID.ToString();
                }
            }
        }

        protected void GvBookissuelist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletess")
                {
                    IssueBookData objitemdata = new IssueBookData();
                    IssueBookBO objDepositfeedBO = new IssueBookBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = GvBookissuelist.Rows[i];

                    Label lblissueno = (Label)gr.Cells[0].FindControl("lblissueno");
                    Label lblgenerateid = (Label)gr.Cells[0].FindControl("lblgenerateid");
                    Label lblsessionID = (Label)gr.Cells[0].FindControl("lblsessionID");
                    Label lblstudentid = (Label)gr.Cells[0].FindControl("lblstudentid");
                    TextBox txtremark = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    txtremark.Enabled = true;
                    if (txtremark.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + "Please write remarks" + "')", true);
                        txtremark.Focus();
                        return;
                    }
                    else
                    {
                        objitemdata.Remarks = txtremark.Text;
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
                        Gettakingitemlist();
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
            Gettakingitemlist();
        }
        protected void Gettakingitemlist()
        {

            IssueBookData objlist = new IssueBookData();
            IssueBookBO objBO = new IssueBookBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtdatefrom2.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtdatefrom2.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtdateto2.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtdateto2.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objlist.AcademicSessionID = LoginToken.AcademicSessionID;
            objlist.StudentID = Convert.ToInt64(hdnstudentid2.Value.Trim() == "" ? "0" : hdnstudentid2.Value.Trim());
            objlist.ClassID = Convert.ToInt32(hdnclassid2.Value == "" ? "0" : hdnclassid2.Value);
            //objlist.SectionID = Convert.ToInt32(ddlsections.SelectedValue == "" ? "0" : ddlsections.SelectedValue);
            objlist.IsActive = ddlstatus2.SelectedValue == "1" ? true : false; 
            objlist.PageSize = GvBookissuelist.PageSize;
            objlist.CurrentIndex = 0;
            objlist.Datefrom = from;
            objlist.Dateto = To;
            objlist.TypeID = Convert.ToInt16(ddltype.SelectedValue == "" ? "0" : ddltype.SelectedValue);
            List<IssueBookData> result = objBO.SearchBookIssueDetails(objlist);
            if (result.Count > 0)
            {
                GvBookissuelist.Visible = true;
                GvBookissuelist.DataSource = result;
                GvBookissuelist.DataBind();
                lblresult.Text = "Total : " + result[0].MaximumRows.ToString() + "" + " record found. ";
            }
            else
            {
                //lblnetqty.Text = "0";
                GvBookissuelist.Visible = true;
                GvBookissuelist.DataSource = null;
                GvBookissuelist.DataBind();
            }
        }
        protected void GvBookissuelist_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    IssueBookData objitemData = new IssueBookData();
                    IssueBookBO objitemBO = new IssueBookBO();
                    Label issueno = (Label)e.Row.FindControl("lblissueno");
                    objitemData.IssueNo = issueno.Text.Trim();
                    List<IssueBookData> GetResult = objitemBO.SearchIssueBookByIssueNo(objitemData);
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
            GvBookIssueDetails.DataSource = null;
            GvBookIssueDetails.DataBind();
            txtstudent2.Text = "";      txtbook2.Text = "";     txtdatefrom2.Text = "";     txtdateto2.Text = "";
        }

        protected void bindresponsive()
        {
            //Responsive 
            GvBookIssueDetails.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvBookIssueDetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvBookIssueDetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvBookIssueDetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvBookIssueDetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            //GvBookIssueDetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvBookIssueDetails.UseAccessibleHeader = true;
            GvBookIssueDetails.HeaderRow.TableSection = TableRowSection.TableHeader;

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
        protected void GvBookissuelist_Sorting(object sender, GridViewSortEventArgs e)
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
                    GvBookIssueDetails.DataSource = sortedView;
                    GvBookIssueDetails.DataBind();
                    bindresponsive();
                    TableCell tableCell = GvBookIssueDetails.HeaderRow.Cells[ColumnIndex];
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
        protected void GvBookissuelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GvBookIssueDetails.PageIndex = e.NewPageIndex;
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
        //    //List<IssueBookData> grpDetail = GetRackSubGroupdetails(1, size);
        //    //List<AddBookToRackDatatoExcel> grptoexcel = new List<AddBookToRackDatatoExcel>();
        //    //int i = 0;
        //    //foreach (IssueBookData row in grpDetail)
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