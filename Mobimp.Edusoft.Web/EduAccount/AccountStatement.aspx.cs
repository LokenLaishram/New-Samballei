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
    public partial class AccountStatement : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDlls();
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlTransactionTypeID, mstlookup.GetLookupsList(LookupNames.TransactionType));
            Commonfunction.PopulateDdl(ddlAccountHeadID, mstlookup.GetLookupsList(LookupNames.AllLedgerHead));
            Commonfunction.PopulateDdl(ddlCollectedByID, mstlookup.GetLookupsList(LookupNames.CollectedBy));
            Commonfunction.PopulateDdl(ddlPaymentModeID, mstlookup.GetLookupsList(LookupNames.PaymentMode));
            txtFromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtCashIncome.Attributes["disabled"] = "disabled";
            txtBankIncome.Attributes["disabled"] = "disabled";
            txtExpenditure.Attributes["disabled"] = "disabled";
            txtBalance.Attributes["disabled"] = "disabled";
            btnClose.Attributes["disabled"] = "disabled";
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            IncClear();
            ExpClear();
            Income_bindgrid(1);
            Expenditure_bindgrid(1);
            BalanceCalculate();
        }

        //--------INCOME---------//

        private void Income_bindgrid(int index)
        {
            int pagesize = 10000; // Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StatementData> lstincome = getIncometranlist(index, pagesize);
            if (lstincome.Count > 0)
            {
               
                Gv_AccountStatement.PageSize = pagesize;
                string record = lstincome[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblIncResult.Text = "Total : " + lstincome[0].MaximumRows.ToString() + " " + record;
                lblIncResult.Visible = true;
                Gv_AccountStatement.VirtualItemCount = lstincome[0].MaximumRows; //total item is required for custom paging
                Gv_AccountStatement.PageIndex = index - 1;
                Gv_AccountStatement.DataSource = lstincome;
                Gv_AccountStatement.DataBind();
                Gv_AccountStatement.Visible = true;
                lblinctotalamt.Text = Commonfunction.Getrounding(lstincome[0].TotalIncome.ToString());
               // lblexptotalamt.Text = Commonfunction.Getrounding(lstincome[0].TotalExpenditure.ToString());

                txtCashIncome.Text = Commonfunction.Getrounding(lstincome[0].CashIncome.ToString());
                txtBankIncome.Text = Commonfunction.Getrounding(lstincome[0].BankIncome.ToString());
               // txtExpenditure.Text = Commonfunction.Getrounding(lstincome[0].Expenditure.ToString());
                txtBalance.Text = Commonfunction.Getrounding(lstincome[0].Balance.ToString());
                btnClose.Attributes.Remove("disabled");
               
                bindresponsive();
            }
            else
            {
                Gv_AccountStatement.DataSource = null;
                Gv_AccountStatement.DataBind();
                Gv_AccountStatement.Visible = false;
                IncClear();

            }
        }
        public List<StatementData> getIncometranlist(int curIndex, int pagesize)
        {
            StatementData objinc = new StatementData();
            StatementBO objBO = new StatementBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtFromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtFromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objinc.Datefrom = DateFrom;
            objinc.Dateto = DateTo;
            objinc.TransactionTypeID = Convert.ToInt32(ddlTransactionTypeID.Text == "" ? "0" : ddlTransactionTypeID.Text);
            objinc.AccountLedgerID = Convert.ToInt32(ddlAccountHeadID.Text == "" ? "0" : ddlAccountHeadID.Text);
            objinc.TransactionNo = txtTransactionNo.Text == "" ? "0" : txtTransactionNo.Text;
            objinc.PaymentModeID = Convert.ToInt32(ddlPaymentModeID.Text == "" ? "0" : ddlPaymentModeID.Text);
            objinc.AccountStatusID = Convert.ToInt32(ddlAccountStatus.Text == "" ? "0" : ddlAccountStatus.Text);
            objinc.CollectedByID = Convert.ToInt32(ddlCollectedByID.Text == "" ? "0" : ddlCollectedByID.Text);
            objinc.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objinc.PageSize = pagesize;
            objinc.CurrentIndex = curIndex;
            return objBO.SearchAccountTransactionList(objinc);
        }
        //--------EXPENDITURE---------//
        private void Expenditure_bindgrid(int index)
        {
            int pagesize = 10000; //  Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<StatementData> lstexp = getExptranlist(index, pagesize);
            if (lstexp.Count > 0)
            {
               
                gvExpStatement.PageSize = pagesize;
                string record = lstexp[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblexpResult.Text = "Total : " + lstexp[0].MaximumRows.ToString() + " " + record;
                lblexpResult.Visible = true;
                gvExpStatement.VirtualItemCount = lstexp[0].MaximumRows; //total item is required for custom paging
                gvExpStatement.PageIndex = index - 1;
                gvExpStatement.DataSource = lstexp;
                gvExpStatement.DataBind();
                gvExpStatement.Visible = true;
                //lblinctotalamt.Text = Commonfunction.Getrounding(lstexp[0].TotalIncome.ToString());
                lblexptotalamt.Text = Commonfunction.Getrounding(lstexp[0].TotalExpenditure.ToString());

              // txtCashIncome.Text = Commonfunction.Getrounding(lstexp[0].CashIncome.ToString());
                //txtBankIncome.Text = Commonfunction.Getrounding(lstexp[0].BankIncome.ToString());
                txtExpenditure.Text = Commonfunction.Getrounding(lstexp[0].Expenditure.ToString());
                txtBalance.Text = Commonfunction.Getrounding(lstexp[0].Balance.ToString());
                btnClose.Attributes.Remove("disabled");              
                Expbindresponsive();
            }
            else
            {
                gvExpStatement.DataSource = null;
                gvExpStatement.DataBind();
                gvExpStatement.Visible = false;
                ExpClear();

            }
        }
        public List<StatementData> getExptranlist(int curIndex, int pagesize)
        {
            StatementData objexp = new StatementData();
            StatementBO objBO = new StatementBO();
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime DateFrom = txtFromDate.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtFromDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime DateTo = txtToDate.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtToDate.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objexp.Datefrom = DateFrom;
            objexp.Dateto = DateTo;
            objexp.TransactionTypeID = Convert.ToInt32(ddlTransactionTypeID.Text == "" ? "0" : ddlTransactionTypeID.Text);
            objexp.AccountLedgerID = Convert.ToInt32(ddlAccountHeadID.Text == "" ? "0" : ddlAccountHeadID.Text);
            objexp.TransactionNo = txtTransactionNo.Text == "" ? "0" : txtTransactionNo.Text;
            objexp.PaymentModeID = Convert.ToInt32(ddlPaymentModeID.Text == "" ? "0" : ddlPaymentModeID.Text);
            objexp.AccountStatusID = Convert.ToInt32(ddlAccountStatus.Text == "" ? "0" : ddlAccountStatus.Text);
            objexp.CollectedByID = Convert.ToInt32(ddlCollectedByID.Text == "" ? "0" : ddlCollectedByID.Text);
            objexp.IsActive = ddlStatus.SelectedValue == "1" ? true : false;
            objexp.PageSize = pagesize;
            objexp.CurrentIndex = curIndex;
            return objBO.ExpenditureTransactionList(objexp);
        }

        protected void Gv_IndentGen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv_AccountStatement.PageIndex = e.NewPageIndex;
            Income_bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }
        protected void Clear_OnClick(object sender, EventArgs e)
        {
            Reset();
        }
        protected void BalanceCalculate()
        {
            decimal cashincome = Convert.ToDecimal(txtCashIncome.Text == "" ? "0.00" : txtCashIncome.Text);
            decimal bankincome = Convert.ToDecimal(txtBankIncome.Text == "" ? "0.00" : txtBankIncome.Text);
            decimal sumincome = cashincome + bankincome;
            decimal exp = Convert.ToDecimal(txtExpenditure.Text == "" ? "0.00" : txtExpenditure.Text);
            if(sumincome> exp)
            {
                txtBalance.Text = (sumincome - exp).ToString();
            }
            else
            {
                txtBalance.Text = "0.00";
            }
        }
            protected void IncClear()
        {
            txtCashIncome.Text = "0.00";
            txtBankIncome.Text = "0.00";
            lblIncResult.Text = "0.00";
            //txtBalance.Text = "0.00";
            lblinctotalamt.Text = "0.00";

        }
        protected void ExpClear()
        {
           
            txtExpenditure.Text = "0.00";
           // txtBalance.Text = "0.00";
            lblexpResult.Text = "0.00";
            lblexptotalamt.Text = "0.00";
        }
        protected void Reset()
        {
            ddlTransactionTypeID.SelectedIndex = 0;
            ddlAccountHeadID.SelectedIndex = 0;
            txtFromDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            txtToDate.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
            ddlAccountStatus.SelectedIndex = 0;
            lblIncResult.Visible = true;     
            Gv_AccountStatement.DataSource = null;
            Gv_AccountStatement.DataBind();
            Gv_AccountStatement.Visible = false;
            //-----Expenditure------//
            gvExpStatement.DataSource = null;
            gvExpStatement.DataBind();
            gvExpStatement.Visible = false;
            lblexpResult.Visible = false;
            txtCashIncome.Text = "0.00";
            txtBankIncome.Text = "0.00";
            txtExpenditure.Text = "0.00";
            txtBalance.Text = "0.00";
            lblinctotalamt.Text = "0.00";
            lblexptotalamt.Text = "0.00";
            btnClose.Attributes["disabled"] = "disabled";
        }
        protected void bindresponsive()
        {
            //Responsive 
            Gv_AccountStatement.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            Gv_AccountStatement.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            Gv_AccountStatement.UseAccessibleHeader = true;
            Gv_AccountStatement.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        protected void Expbindresponsive()
        {
            //Responsive 
            gvExpStatement.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            gvExpStatement.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            gvExpStatement.UseAccessibleHeader = true;
            gvExpStatement.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
    }
}