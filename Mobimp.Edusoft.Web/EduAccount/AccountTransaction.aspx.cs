using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Data.EduAccount;
using Mobimp.Edusoft.BussinessProcess.EduAccount;
using Mobimp.Edusoft.Common;

namespace Mobimp.Edusoft.Web.EduAccount
{
    public partial class AccountTransaction : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblmessage.Visible = true;
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddl_TransactionType, mstlookup.GetLookupsList(LookupNames.TransactionType));
            // Commonfunction.PopulateDdl(ddl_FromLedgerID, mstlookup.GetLookupsList(LookupNames.Ledger));
            // Commonfunction.PopulateDdl(ddl_ToLedgerID, mstlookup.GetLookupsList(LookupNames.Ledger));
            Commonfunction.PopulateDdl(ddl_PaymentMode, mstlookup.GetLookupsList(LookupNames.PaymentMode));
            ddl_PaymentMode.SelectedIndex = 1;
            txt_tansactionDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddl_FromLedgerID.Attributes["disabled"] = "disabled";
            ddl_ToLedgerID.Attributes["disabled"] = "disabled";
            txt_totaldebit.Attributes["disabled"] = "disabled";
            txt_totalcredit.Attributes["disabled"] = "disabled";
            txt_BankName.ReadOnly = true;
            txt_BankName.ReadOnly = true;
            txt_ChequeNo.ReadOnly = true;
            txt_InvoiceNo.ReadOnly = true;
            btnupdate.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";
            txt_TransactionNo.Attributes["disabled"] = "disabled";
            //---Tab2---//
            Commonfunction.PopulateDdl(ddlTransactionTypeID, mstlookup.GetLookupsList(LookupNames.TransactionType));
            Commonfunction.PopulateDdl(ddlAccountHeadID, mstlookup.GetLookupsList(LookupNames.AllLedgerHead));
            txt_FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
        }
        protected void ddl_TransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_TransactionType.SelectedIndex > 0)
            {
                ddl_FromLedgerID.Attributes.Remove("disabled");
                ddl_ToLedgerID.Attributes.Remove("disabled");
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_FromLedgerID, mstlookup.GetFromLederByTransactionTypeID(Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue)));
                Commonfunction.PopulateDdl(ddl_ToLedgerID, mstlookup.GetToLederByTransactionTypeID(Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue)));
                Session["TransactionList"] = null;
                Gv_Transaction.DataSource = null;
                Gv_Transaction.DataBind();
                Gv_Transaction.Visible = false;
            }
            else
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddl_FromLedgerID, mstlookup.GetFromLederByTransactionTypeID(Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue)));
                Commonfunction.PopulateDdl(ddl_ToLedgerID, mstlookup.GetToLederByTransactionTypeID(Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue)));
                ddl_FromLedgerID.SelectedIndex = 0;
                ddl_ToLedgerID.SelectedIndex = 0;
                ddl_FromLedgerID.Attributes["disabled"] = "disabled";
                ddl_ToLedgerID.Attributes["disabled"] = "disabled";
            }

        }
        //protected void ddl_FromLedgerID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(Convert.ToInt32(ddl_FromLedgerID.SelectedValue==""?"0": ddl_FromLedgerID.SelectedValue) == Convert.ToInt32(ddl_ToLedgerID.SelectedValue == "" ? "0" : ddl_ToLedgerID.SelectedValue))
        //    {
                
        //    }
        //    ClearWhenConditionFalse();
        //}
        protected void btnadd_Click(object sender, EventArgs e)
        {
            //if (LoginToken.SaveEnable == 0)
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("saveenable") + "')", true);
            //    return;
            //}
            if (txt_tansactionDate.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select transaction date.") + "')", true);
                return;
            }

            if (ddl_TransactionType.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select transaction type.") + "')", true);
                return;
            }
            if (ddl_FromLedgerID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select ledger head to transfer from.") + "')", true);
                return;
            }
            if (ddl_ToLedgerID.SelectedIndex == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please select to transfer ledger head.") + "')", true);
                return;
            }

            if (txt_Naration.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter transfer remark.") + "')", true);
                return;
            }
            if (txt_TransactionAmount.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please enter transfer amount.") + "')", true);
                return;
            }
            // Check Duplicate data 
            foreach (GridViewRow row in Gv_Transaction.Rows)
            {
                Label lblfromledgerID = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblfromledgerID");
                Label lblToLedgerID = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblToLedgerID");

                if (Convert.ToInt32(lblfromledgerID.Text == "" ? "0" : lblfromledgerID.Text) != Convert.ToInt32(lblfromledgerID.Text == "" ? "0" : lblfromledgerID.Text))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Ledger head which to transfer from cannot be multiple.") + "')", true);
                    return;
                }

                if (Convert.ToInt32(lblToLedgerID.Text == "" ? "0" : lblToLedgerID.Text) == Convert.ToInt32(ddl_ToLedgerID.SelectedValue == ""?"0": ddl_ToLedgerID.SelectedValue))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("This Ledger head have already added.") + "')", true);
                    return;
                }
                else
                {
                    
                }
            }

            List<TransactionData> TransactionList = Session["TransactionList"] == null ? new List<TransactionData>() : (List<TransactionData>)Session["TransactionList"];
            TransactionData Objdata = new TransactionData();
            Objdata.TransactionTypeID = Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue);
            Objdata.FromLedgerID = Convert.ToInt32(ddl_FromLedgerID.SelectedValue == "" ? "0" : ddl_FromLedgerID.SelectedValue);
            Objdata.FromLedgerName = ddl_FromLedgerID.SelectedItem.Text == "" ? "" : ddl_FromLedgerID.SelectedItem.Text;
            Objdata.ToLedgerID = Convert.ToInt32(ddl_ToLedgerID.SelectedValue == "" ? "0" : ddl_ToLedgerID.SelectedValue);
            Objdata.ToLedgerName = ddl_ToLedgerID.SelectedItem.Text == "" ? "" : ddl_ToLedgerID.SelectedItem.Text;
            Objdata.TransactionNaration = txt_Naration.Text;
            Objdata.TransactionAmount = Convert.ToDecimal(txt_TransactionAmount.Text == "" ? "0" : txt_TransactionAmount.Text);

            TransactionList.Add(Objdata);
            if (TransactionList.Count > 0)
            {
                Gv_Transaction.DataSource = TransactionList;
                Gv_Transaction.DataBind();
                Gv_Transaction.Visible = true;
                Session["TransactionList"] = TransactionList;

                TotalCalculate();
                Clear();
                bindresponsive();
                btnupdate.Attributes.Remove("disabled");

            }
            else
            {
                Gv_Transaction.DataSource = null;
                Gv_Transaction.DataBind();
                Gv_Transaction.Visible = true;
                TotalCalculate();
                Clear();
            }

        }
        public void TotalCalculate()
        {
            decimal TotalAmount = 0;
            foreach (GridViewRow row in Gv_Transaction.Rows)
            {
                Label lbltranamt = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblTranAmount");
                TotalAmount = TotalAmount + (Convert.ToDecimal(lbltranamt.Text == "" ? "0" : lbltranamt.Text));
            }
            txt_totaldebit.Text = Commonfunction.Getrounding(TotalAmount.ToString());
            txt_totalcredit.Text = Commonfunction.Getrounding(TotalAmount.ToString());

        }
        public void Clear()
        {
            ddl_ToLedgerID.SelectedIndex = 0;
            txt_Naration.Text = "";
            txt_TransactionAmount.Text = "";
        }

        protected void Gv_Transaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_Transaction.Rows[i];
                    List<TransactionData> TranList = Session["TransactionList"] == null ? new List<TransactionData>() : (List<TransactionData>)Session["TransactionList"];
                    if (TranList.Count > 0)
                    {
                        Decimal TranAmt = TranList[i].TransactionAmount;
                    }
                    TranList.RemoveAt(i);
                    Session["TransactionList"] = TranList;
                    Gv_Transaction.DataSource = TranList;
                    Gv_Transaction.DataBind();
                    TotalCalculate();
                }
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);

            }
        }
        protected void ddlpaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_PaymentMode.SelectedIndex > 0)
            {
                if (ddl_PaymentMode.SelectedValue == "1")
                {
                    txt_BankName.Text = "";
                    txt_BankName.ReadOnly = true;
                    txt_ChequeNo.ReadOnly = true;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "2")
                {
                    //  GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    txt_BankName.ReadOnly = true;
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = false;
                }
                else if (ddl_PaymentMode.SelectedValue == "3")
                {
                    // GetBankName(Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue));
                    txt_BankName.ReadOnly = true;
                    txt_InvoiceNo.Text = "";
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
                else if (ddl_PaymentMode.SelectedValue == "4")
                {
                    txt_BankName.Text = "";
                    txt_BankName.ReadOnly = false;
                    txt_ChequeNo.ReadOnly = false;
                    txt_InvoiceNo.ReadOnly = true;
                }
            }
            else
            {
                txt_BankName.Text = "";
                txt_BankName.ReadOnly = true;
                txt_ChequeNo.ReadOnly = true;
                txt_InvoiceNo.ReadOnly = true;
            }
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                List<TransactionData> list = new List<TransactionData>();
                TransactionBO TranBO = new TransactionBO();
                TransactionData obj = new TransactionData();
                List<TransactionData> Resultlist = new List<TransactionData>();
                foreach (GridViewRow row in Gv_Transaction.Rows)
                {
                    IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
                    Label FromledgerID = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblfromledgerID");
                    Label Fromledgername = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblfromledgername");
                    Label ToledgerID = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblToLedgerID");
                    Label ToledgerName = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblToLedgerName");
                    Label TranAmount = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblTranAmount");
                    Label TranNaration = (Label)Gv_Transaction.Rows[row.RowIndex].Cells[0].FindControl("lblTranNaration");

                    TransactionData ObjDetails = new TransactionData();

                    ObjDetails.FromLedgerID = Convert.ToInt32(FromledgerID.Text == "" ? "0" : FromledgerID.Text);
                    ObjDetails.FromLedgerName = Fromledgername.Text == "" ? "" : Fromledgername.Text;
                    ObjDetails.ToLedgerID = Convert.ToInt32(ToledgerID.Text == "" ? "0" : ToledgerID.Text);
                    ObjDetails.ToLedgerName = ToledgerName.Text == "" ? "" : ToledgerName.Text;
                    ObjDetails.TransactionAmount = Convert.ToDecimal(TranAmount.Text == "" ? "0" : TranAmount.Text);
                    ObjDetails.TransactionNaration = TranNaration.Text == "" ? "0" : TranNaration.Text;
                    list.Add(ObjDetails);
                }
                obj.XMLData = XmlConvertor.AccountTransListXML(list).ToString();
                IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                //DateTime from = txt_tansactionDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_tansactionDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                DateTime TransDate = txt_tansactionDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_tansactionDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                obj.TransactionDate = TransDate;
                obj.TransactionTypeID = Convert.ToInt32(ddl_TransactionType.SelectedValue == "" ? "0" : ddl_TransactionType.SelectedValue);
                obj.OverallNaration = txt_OverallNaration.Text;
                obj.PaymentModeID = Convert.ToInt32(ddl_PaymentMode.SelectedValue == "" ? "0" : ddl_PaymentMode.SelectedValue);
                obj.BankName = txt_BankName.Text;
                obj.Invoice = txt_InvoiceNo.Text;
                obj.ChequeNo = txt_ChequeNo.Text;
                obj.TotalCredit = Convert.ToDecimal(txt_totalcredit.Text == "" ? "0" : txt_totalcredit.Text);
                obj.EmployeeID = LoginToken.EmployeeID;
                obj.AcademicSessionID = LoginToken.AcademicSessionID;
                obj.CompanyID = LoginToken.CompanyID;
                Resultlist = TranBO.SaveAccountTransaction(obj);
                if (Resultlist.Count > 0)
                {
                    txt_TransactionNo.Text = Resultlist[0].TransactionNo.ToString();
                    btnupdate.Attributes["disabled"] = "disabled";
                    btnprint.Attributes.Remove("disabled");
                    ClearWhenCondition();
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
                }
                else
                {
                    btnupdate.Attributes.Remove("disabled");
                    btnprint.Attributes["disabled"] = "disabled";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("System Error.") + "')", true);
                }
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
            }
        }
        public void ClearWhenCondition()
        {
            Session["TransactionList"] = null;
            Gv_Transaction.DataSource = null;
            Gv_Transaction.DataBind();
            Gv_Transaction.Visible = false;
           
        }
        protected void BtnReset_OnClick(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            txt_tansactionDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddl_TransactionType.SelectedIndex = 0;
            txt_Naration.Text = "";
            txt_TransactionAmount.Text = "";
            Session["TransactionList"] = null;
            Gv_Transaction.DataSource = null;
            Gv_Transaction.DataBind();
            Gv_Transaction.Visible = false;
            txt_Naration.Text = "";
            ddl_PaymentMode.SelectedIndex = 0;
            txt_BankName.Text = "";
            txt_InvoiceNo.Text = "";
            txt_ChequeNo.Text = "";
            txt_totaldebit.Text = "0";
            txt_totalcredit.Text = "0";
            btnupdate.Attributes["disabled"] = "disabled";
            btnprint.Attributes["disabled"] = "disabled";

        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_Transaction.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_Transaction.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_Transaction.UseAccessibleHeader = true;
            Gv_Transaction.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        //--------TAB-2------------//
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<TransactionData> lstindent = gettranlist(index, pagesize);
            if (lstindent.Count > 0)
            {
                Gv_TransactionList.PageSize = pagesize;
                string record = lstindent[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstindent[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstindent[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gv_TransactionList.VirtualItemCount = lstindent[0].MaximumRows;//total item is required for custom paging
                Gv_TransactionList.PageIndex = index - 1;
                Gv_TransactionList.DataSource = lstindent;
                Gv_TransactionList.DataBind();
                Gv_TransactionList.Visible = true;
                bindresponsive2();
            }
            else
            {
                Gv_TransactionList.DataSource = null;
                Gv_TransactionList.DataBind();
                Gv_TransactionList.Visible = false;
            }
        }
        public List<TransactionData> gettranlist(int curIndex, int pagesize)
        {
            TransactionData objind = new TransactionData();
            TransactionBO objBO = new TransactionBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txt_FromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txt_FromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txt_ToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txt_ToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objind.Datefrom = DateFrom;
            objind.Dateto = DateTo;
            objind.TransactionTypeID = Convert.ToInt32(ddlTransactionTypeID.Text == "" ? "0" : ddlTransactionTypeID.Text);
            objind.AccountLedgerID = Convert.ToInt32(ddlAccountHeadID.Text == "" ? "0" : ddlAccountHeadID.Text);          
            objind.TransactionNo = txtTransactionNo.Text == "" ? "0" : txtTransactionNo.Text;
            objind.AccountStatusID = Convert.ToInt32(ddlAccountStatus.Text == "" ? "0" : ddlAccountStatus.Text);
            objind.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objind.PageSize = pagesize;
            objind.CurrentIndex = curIndex;          
            return objBO.SearchAccountTransactionList(objind);
        }

        protected void Gv_TransactionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TransactionData objdata = new TransactionData();
                    TransactionBO objbo = new TransactionBO();
                    Label lblTransactionNo = (Label)e.Row.FindControl("lblTransactionNo");
                    objdata.TransactionNo = lblTransactionNo.Text.Trim();
                    List<TransactionData> GetResult = objbo.SearchChildTransactionDetails(objdata);
                    if (GetResult.Count > 0)
                    {
                        GridView SC = (GridView)e.Row.FindControl("GridChildIndent");
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
        protected void Gv_TransactionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletes")
                {
                    //if (LoginToken.DeleteEnable == 0)
                    //{
                    //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("deleteenable") + "')", true);
                    //    return;
                    //}
                    TransactionData obj = new TransactionData();
                    TransactionBO objBO = new TransactionBO();
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gv_TransactionList.Rows[i];
                    Label TranNo = (Label)gr.Cells[0].FindControl("lblTransactionNo");
                    obj.TransactionNo = TranNo.Text.Trim();
                    TextBox txtremarks = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (txtremarks.Text.Trim() == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        bindresponsive();
                        txtremarks.Focus();
                        return;
                    }
                    else
                    {
                        obj.Remark = txtremarks.Text.Trim() == "" ? "" : txtremarks.Text.Trim();
                    }
                    obj.ActionType = EnumActionType.Delete;
                    obj.EmployeeID = LoginToken.EmployeeID;
                    int Result = objBO.DeleteTransactionbyTranNo(obj);
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
        protected void Gv_IndentGen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_TransactionList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void Clear_OnClick(object sender, EventArgs e)
        {
            Reset2();
        }
        protected void Reset2()
        {
            ddlTransactionTypeID.SelectedIndex = 0;
            ddlAccountHeadID.SelectedIndex = 0;
            txt_FromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txt_ToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddlAccountStatus.SelectedIndex = 0;          
            Gv_TransactionList.DataSource = null;
            Gv_TransactionList.DataBind();
            Gv_TransactionList.Visible = false;
        }
        protected void bindresponsive2()
        {
            //Responsive 
            Gv_TransactionList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_TransactionList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_TransactionList.UseAccessibleHeader = true;
            Gv_TransactionList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
    }
}