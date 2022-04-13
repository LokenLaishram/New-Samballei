using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mobimp.Edusoft.Web.AppCode;
using Mobimp.Edusoft.Web.UserControls;
using Mobimp.Campusoft.Data.HRAndPayroll.HR;
using Mobimp.Campusoft.BussinessProcess.HRAndPayroll.HR;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.BussinessProcess.Common;
using System.Data;
using System.Reflection;
using System.IO;
using ClosedXML.Excel;
using Mobimp.Edusoft.Common;

namespace Mobimp.Campusoft.Web.EduHRAndPayroll.HR
{
    public partial class LoanRepayment : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdl();
                if (Session["PaymentNo"] != null)
                {
                    txt_PaymentNo.Text = Session["PaymentNo"].ToString();
                    txt_PaymentNo.ReadOnly = true;
                    GetLoanDetailsByPaymentNo();
                    Session["PaymentNo"] = null;
                }
                txt_EmployeeName.Attributes["disabled"] = "disabled";
                txt_LoanAmount.Attributes["disabled"] = "disabled";
                txt_LoanBalance.Attributes["disabled"] = "disabled";
                txt_DueAmt.Attributes["disabled"] = "disabled";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetPaymentNo(string prefixText, int count, string contextKey)
        {
            LoanPaymentData ObjData = new LoanPaymentData();
            LoanPaymentBO ObjBO = new LoanPaymentBO();
            List<LoanPaymentData> getResult = new List<LoanPaymentData>();
            ObjData.LoanPaymentNo = prefixText;
            getResult = ObjBO.GetPaymentNo(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].LoanPaymentNo.ToString());
            }
            return list;
        }

        protected void txt_PaymentNo_TextChanged(object sender, EventArgs e)
        {
            GetLoanDetailsByPaymentNo();
        }

        protected void GetLoanDetailsByPaymentNo()
        {
            LoanPaymentData objdata = new LoanPaymentData();
            LoanPaymentBO objBO = new LoanPaymentBO();
            List<LoanPaymentData> getresult = new List<LoanPaymentData>();

            objdata.LoanPaymentNo = txt_PaymentNo.Text == "" ? "0" : txt_PaymentNo.Text;
            getresult = objBO.GetLoanDetailsByPaymentNo(objdata);
            if (getresult.Count > 0)
            {
                txt_EmployeeName.Text = getresult[0].EmployeeName;
                lbl_EmpID.Text = Convert.ToString(getresult[0].EmployeeID);
                txt_LoanAmount.Text = getresult[0].LoanAmount.ToString("0.00");
                txt_LoanBalance.Text = getresult[0].LastBalanceAmount.ToString("0.00");
            }
            else
            {
                txt_PaymentNo.Text = "";
                txt_EmployeeName.Text = "";
                lbl_EmpID.Text = "";
                txt_LoanAmount.Text = "";
                txt_LoanBalance.Text = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("NotFound") + "')", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txt_PaymentNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("PaymentNo") + "')", true);
                txt_PaymentNo.Focus();
                return;
            }
            if (txt_EmployeeName.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("BlankEmployeeName") + "')", true);
                txt_EmployeeName.Focus();
                return;
            }
            if (txt_LoanAmount.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("BlankLoanAmount") + "')", true);
                txt_LoanAmount.Focus();
                return;
            }
            if (txt_LoanBalance.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("BlankLoanBalance") + "')", true);
                txt_LoanBalance.Focus();
                return;
            }
            if (txt_RepaymentAmt.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("RepaymentAmount") + "')", true);
                txt_RepaymentAmt.Focus();
                return;
            }
            if (txt_DueAmt.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("BlankDueAmount") + "')", true);
                txt_DueAmt.Focus();
                return;
            }
            List<LoanPaymentData> getResult = new List<LoanPaymentData>();
            LoanPaymentData ObjData = new LoanPaymentData();
            LoanPaymentBO ObjBO = new LoanPaymentBO();
            ObjData.LoanPaymentNo = txt_PaymentNo.Text.Trim() == "" ? "0" : txt_PaymentNo.Text.Trim();
            ObjData.EmployeeName = txt_EmployeeName.Text.Trim() == null ? "" : txt_EmployeeName.Text.Trim();
            ObjData.EmployeeID = Convert.ToInt64( lbl_EmpID.Text == "" ? "0" : lbl_EmpID.Text);
            ObjData.LoanAmount = Convert.ToDecimal(txt_LoanAmount.Text == "" ? "0" : txt_LoanAmount.Text);
            ObjData.BalanceAmount = Convert.ToDecimal(txt_LoanBalance.Text == "" ? "0" : txt_LoanBalance.Text);
            ObjData.ReturnAmount = Convert.ToDecimal(txt_RepaymentAmt.Text == "" ? "0" : txt_RepaymentAmt.Text);
            ObjData.DueAmount = Convert.ToDecimal(txt_DueAmt.Text == "" ? "0" : txt_DueAmt.Text);
            ObjData.AddedBy = LoginToken.LoginId;
            ObjData.UserId = LoginToken.UserLoginId;
            ObjData.CompanyID = LoginToken.CompanyID;
            ObjData.AcademicSessionID = LoginToken.AcademicSessionID;
            getResult = ObjBO.SaveLoanRepayment(ObjData);
            if (getResult.Count > 0)
            {
                txt_RepaymentNo.Text = getResult[0].LoanReturnNo;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("save") + "')", true);
            }
            else
            {
                txt_RepaymentNo.Text = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("SaveError") + "')", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllTab1();
        }

        protected void ClearAllTab1()
        {
            lblmessage.Text = "";
            txt_PaymentNo.Text = "";
            txt_EmployeeName.Text = "";
            txt_LoanAmount.Text="";
            txt_LoanBalance.Text = "";
            txt_RepaymentAmt.Text = "";
            txt_DueAmt.Text = "";
            txt_RepaymentNo.Text = "";
        }


        //--------------------------------- Start Tab 2 ------------------------------

        protected void BindDdl()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddltab2_LoanType, mstlookup.GetLookupsList(LookupNames.LoanType));
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> GetEmployeeName(string prefixText, int count, string contextKey)
        {
            LoanPaymentData ObjData = new LoanPaymentData();
            LoanPaymentBO ObjBO = new LoanPaymentBO();
            List<LoanPaymentData> getResult = new List<LoanPaymentData>();
            ObjData.EmployeeName = prefixText;
            getResult = ObjBO.GetEmployeeName(ObjData);
            List<String> list = new List<String>();
            for (int i = 0; i < getResult.Count; i++)
            {
                list.Add(getResult[i].EmployeeName.ToString());
            }
            return list;
        }

        protected void btntab2_Search_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }

        private void bindgrid(int index)
        {
            int pagesize = Convert.ToInt32(ddl_show.SelectedValue == "10000" ? lbl_totalrecords.Text : ddl_show.SelectedValue);
            List<LoanPaymentData> lstHoliday = GetLoanRepaymentDetails(index, pagesize);
            if (lstHoliday.Count > 0)
            {
                Gvtab2_RepaymentList.PageSize = pagesize;
                string record = lstHoliday[0].MaximumRows.ToString() == "1" ? " record found. " : " records found. ";
                lblresult.Text = "Total : " + lstHoliday[0].MaximumRows.ToString() + " " + record;
                lbl_totalrecords.Text = lstHoliday[0].MaximumRows.ToString(); ;
                lblresult.Visible = true;
                Gvtab2_RepaymentList.VirtualItemCount = lstHoliday[0].MaximumRows;//total item is required for custom paging
                Gvtab2_RepaymentList.PageIndex = index - 1;
                Gvtab2_RepaymentList.DataSource = lstHoliday;
                Gvtab2_RepaymentList.DataBind();
                Gvtab2_RepaymentList.Visible = true;
                ds = ConvertToDataSet(lstHoliday);
                TableCell tableCell = Gvtab2_RepaymentList.HeaderRow.Cells[0];
                Image img = new Image();
                img.ImageUrl = "~/app-assets/images/asc.gif";
                tableCell.Controls.Add(new LiteralControl("&nbsp;"));
                tableCell.Controls.Add(img);
                bindresponsive();
            }
            else
            {
                Gvtab2_RepaymentList.DataSource = null;
                Gvtab2_RepaymentList.DataBind();
            }
        }

        public List<LoanPaymentData> GetLoanRepaymentDetails(int curIndex, int pagesize)
        {
            LoanPaymentData objdata = new LoanPaymentData();
            LoanPaymentBO objBO = new LoanPaymentBO();

            if (txttab2_EmpName.Text != "")
            {
                var source = txttab2_EmpName.Text.ToString();
                if (source.Contains(":"))
                {
                    string ID = source.Substring(source.LastIndexOf(':') + 1);
                    lbltab2_EmpID.Text = ID;
                }
            }
            objdata.EmployeeID = Convert.ToInt64(lbltab2_EmpID.Text == "" ? "0" : lbltab2_EmpID.Text);
            objdata.LoanTypeID = Convert.ToInt32(ddltab2_LoanType.SelectedValue == "" ? "0" : ddltab2_LoanType.SelectedValue);
            objdata.LoanStatusID = Convert.ToInt32(ddltab2_LoanStatus.SelectedValue == "" ? "0" : ddltab2_LoanStatus.SelectedValue);
            objdata.IsActive = ddltab2_IsActive.SelectedValue == "1" ? true : false;
            IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
            DateTime from = txtfrom.Text.Trim() == "" ? GlobalConstant.MinSQLDateTime : DateTime.Parse(txtfrom.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            DateTime To = txtto.Text.Trim() == "" ? System.DateTime.Now : DateTime.Parse(txtto.Text.Trim(), option, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            objdata.DateFrom = from;
            objdata.DateTo = To;
            objdata.PageSize = Gvtab2_RepaymentList.PageSize;
            objdata.CurrentIndex = curIndex;
            return objBO.GetLoanRepaymentDetails(objdata);
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
        protected void bindresponsive()
        {
            //Responsive 
            Gvtab2_RepaymentList.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Gvtab2_RepaymentList.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_RepaymentList.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_RepaymentList.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_RepaymentList.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            Gvtab2_RepaymentList.UseAccessibleHeader = true;
            Gvtab2_RepaymentList.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void btntab2_Cancel_Click(object sender, EventArgs e)
        {
            ClearAllTab2();
        }

        protected void ClearAllTab2()
        {
            lblresult.Text = "";
            txttab2_EmpName.Text = "";
            ddltab2_LoanType.SelectedIndex = 0;
            ddltab2_LoanStatus.SelectedIndex = 0;
            ddltab2_IsActive.SelectedIndex = 0;
            txtfrom.Text = "";
            txtto.Text = "";
            Gvtab2_RepaymentList.DataSource = null;
            Gvtab2_RepaymentList.DataBind();
            Gvtab2_RepaymentList.Visible = false;
        }

        protected void Gvtab2_RepaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletes")
                {
                    LoanPaymentData objData = new LoanPaymentData();
                    LoanPaymentBO objBO = new LoanPaymentBO();
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    int i = Convert.ToInt16(e.CommandArgument.ToString());
                    GridViewRow gr = Gvtab2_RepaymentList.Rows[i];
                    Label PaymentNo = (Label)gr.Cells[0].FindControl("Gvlbl_LoanPaymentNo");
                    Label ReturnNo = (Label)gr.Cells[0].FindControl("Gvlbl_LoanReturnNo");
                    Label ReturnAmount = (Label)gr.Cells[0].FindControl("Gvlbl_ReturnAmount");
                    TextBox Remark = (TextBox)gr.Cells[0].FindControl("txtremarks");
                    if (Remark.Text == "")
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Remark") + "')", true);
                        return;
                    }
                    objData.LoanPaymentNo = PaymentNo.Text == null ? "" : PaymentNo.Text;
                    objData.LoanReturnNo = ReturnNo.Text == null ? "" : ReturnNo.Text;
                    objData.ReturnAmount = Convert.ToDecimal(ReturnAmount.Text == "" ? "0" : ReturnAmount.Text);
                    objData.Remark = Remark.Text == null ? "" : Remark.Text;
                    objData.AddedBy = LoginToken.LoginId;
                    objData.UserId = LoginToken.UserLoginId;
                    objData.CompanyID = LoginToken.CompanyID;
                    objData.AcademicSessionID = LoginToken.AcademicSessionID;

                    int result = objBO.DeleteLoanRepaymentByReturnNo(objData);
                    if (result == 1)
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
            catch (Exception ex)
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

        protected void Gvtab2_RepaymentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gvtab2_RepaymentList.PageIndex = e.NewPageIndex;
            bindgrid(Convert.ToInt32(e.NewPageIndex + 1));
        }



        //--------------------------------- End Tab 2 ---------------------------------
    }
}