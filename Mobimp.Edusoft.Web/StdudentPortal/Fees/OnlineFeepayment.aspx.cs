using Mobimp.Campusoft.BussinessProcess.StudentPortalBO;
using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Common.Util;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.StdudentPortal.Fees
{
    public partial class OnlineFeepayment : BasePage
    {
        DataSet ds = new DataSet();
        LoginToken objLoginToken;

        protected void Page_Load(object sender, EventArgs e)
        {
            objLoginToken = (LoginToken)Session["LoginToken"];
            if (!IsPostBack)
            {
                BindDlls();
                bindgrid(1);
            }
        }
        protected void BindDlls()
        {
            MasterLookupBO mstlookup = new MasterLookupBO();
            Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
            ddlacademicsession.SelectedIndex = 1;
            txtstddetail.Attributes["disabled"] = "disabled";
            txt_paymentstatus.Attributes["disabled"] = "disabled";
            txt_totalamount.Attributes["disabled"] = "disabled";
            txt_totalfineamount.Attributes["disabled"] = "disabled";
            txt_discountamount.Attributes["disabled"] = "disabled";
            txt_payableamount.Attributes["disabled"] = "disabled";
            Session["PaymentDetails"] = null;
            Session["FeeTypeID"] = null;
            Session["TotalAmount"] = null;
            Session["FineAmount"] = null;
            Session["ExemptionAmount"] = null;
            Session["TotalPaidAmount"] = null;
            Session["StudentID"] = null;
            Session["BillID"] = null;
            Session["AcademicSessionID"] = null;
        }
        protected void bindresponsive()
        {
            //Responsive 
            GvFeedetails.HeaderRow.Cells[0].Attributes["data-hide"] = "expand";
            // GvstudentDetails.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet";
            GvFeedetails.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet";
            //  Adds THEAD and TBODY to GridView.
            GvFeedetails.UseAccessibleHeader = true;
            GvFeedetails.HeaderRow.TableSection = TableRowSection.TableHeader;

            TableCell tableCell = GvFeedetails.HeaderRow.Cells[0];
            Image img = new Image();
            img.ImageUrl = "~/app-assets/images/asc.gif";
            tableCell.Controls.Add(new LiteralControl("&nbsp;"));
            tableCell.Controls.Add(img);
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
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            bindgrid(1);
        }
        private void bindgrid(int index)
        {
            List<PaymentData> listdetails = Getstudentpaymentdetails();
            if (listdetails.Count > 0)
            {

                GvFeedetails.Visible = true;
                GvFeedetails.DataSource = listdetails;
                GvFeedetails.DataBind();
                txtstddetail.Text = listdetails[0].StudentName.ToString();
                Session["StudentName"] = listdetails[0].StudentName.ToString();
                // bindresponsive();
                //ds = ConvertToDataSet(listdetails);
                if (Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue) > 6 && listdetails[0].CurrentAdmissionStatus == 0)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please pay admission first.") + "')", true);
                    btnpay.Attributes["disabled"] = "disabled";
                    return;
                }
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                GvFeedetails.Visible = true;
                txtstddetail.Text = "";
                txt_paymentstatus.Text = "";

                txt_totalamount.Text = "";
                txt_totalfineamount.Text = "";
                txt_discountamount.Text = "";
                txt_payableamount.Text = "";
            }
        }
        public List<PaymentData> Getstudentpaymentdetails()
        {
            PaymentData objpayment = new PaymentData();
            OnlinepaymentBO objpaymentBO = new OnlinepaymentBO();
            objpayment.StudentID = LoginToken.EmployeeID;
            objpayment.FeeTypeID = 2;
            objpayment.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
            return objpaymentBO.Getfeepaymentdetails(objpayment);
        }
        protected void ddlacademicsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlacademicsession.SelectedIndex > 0)
            {
                bindgrid(1);
            }
            else
            {
                MasterLookupBO mstlookup = new MasterLookupBO();
                Commonfunction.PopulateDdl(ddlacademicsession, mstlookup.GetLookupsList(LookupNames.Academicsession));
                ddlacademicsession.SelectedIndex = 1;
                bindgrid(1);
            }
        }
        public string orderId;
        protected void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                //string fileName1 = receiptuploadr.FileName.ToString();
                //if (fileName1 == "")
                //{
                //    lbl_message.Visible = true;
                //    lbl_message.Text = "Please upload payment reciept.";
                //    return;
                //}
                //else
                //{
                //    lbl_message.Text = "";
                //    lbl_message.Visible = false;
                //}

                List<PaymentData> paymentlist = new List<PaymentData>();
                OnlinepaymentBO objpaymentBO = new OnlinepaymentBO();
                PaymentData Objpaydata = new PaymentData();

                int check = 0;
                int countnotpaid = 0;
                int countpaid = 0;

                foreach (GridViewRow row in GvFeedetails.Rows)
                {
                    Label IDS = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label monthID = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblmonthID");
                    Label feetype = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeetypeID");
                    Label Particular = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblparticulars");
                    Label Feeamount = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeeamount");
                    Label Class = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblclassID");
                    Label Session = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("sessionID");
                    Label Paymentstatus = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lbl_paymentstatus");

                    if (Paymentstatus.Text == "Not Paid")
                    {
                        countnotpaid += 1;

                    }
                    PaymentData objdata = new PaymentData();
                    CheckBox ChkFeeStatus = (CheckBox)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("chkfeestatus");
                    if (ChkFeeStatus.Checked)
                    {

                        countpaid += 1;
                        objdata.ID = Convert.ToInt32(IDS.Text == "" ? "0" : IDS.Text);
                        objdata.ClassID = Convert.ToInt32(Class.Text == "" ? "0" : Class.Text);
                        objdata.MonthID = Convert.ToInt32(monthID.Text == "" ? "0" : monthID.Text);
                        objdata.FeeTypeID = Convert.ToInt32(feetype.Text == "" ? "0" : feetype.Text);
                        objdata.FeeAmount = Convert.ToDecimal(Feeamount.Text == "" ? "0" : Feeamount.Text);
                        objdata.Particulars = Convert.ToString(Particular.Text);
                        objdata.AcademicSessionID = Convert.ToInt32(Session.Text == "" ? "0" : Session.Text);
                        paymentlist.Add(objdata);

                    }
                    check++;
                }
                if (countnotpaid != countpaid && ddlacademicsession.SelectedValue=="6")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Duepay") + "')", true);
                    return;
                }
                if (countpaid==0 && Convert.ToInt32(ddlacademicsession.SelectedValue==""?"0": ddlacademicsession.SelectedValue) >6)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Please pay atleast one installemnt.") + "')", true);
                    return;
                }
                Objpaydata.XMLData = XmlConvertor.OnlinepaymentStoXML(paymentlist).ToString();
                Session["PaymentDetails"] = XmlConvertor.OnlinepaymentStoXML(paymentlist).ToString();

                Objpaydata.StudentID = LoginToken.EmployeeID; // here employeeID is Student ID
                Objpaydata.FeeTypeID = 2;
                Objpaydata.TotalAmount = Convert.ToDecimal(txt_totalamount.Text == "" ? "0" : txt_totalamount.Text);
                Objpaydata.FineAmount = Convert.ToDecimal(txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text);
                Objpaydata.ExemptionAmount = Convert.ToDecimal(txt_discountamount.Text == "" ? "0" : txt_discountamount.Text);
                Objpaydata.TotalPaidAmount = Convert.ToDecimal(txt_payableamount.Text == "" ? "0" : txt_payableamount.Text);
                Objpaydata.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                Objpaydata.CompanyID = LoginToken.CompanyID;
                Objpaydata.PaymentType = 1; //online
                Objpaydata.EmployeeID = LoginToken.EmployeeID;

                if (txt_payableamount.Text == "0.00")
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("paidamount") + "')", true);
                    return;
                }


                Session["StudentID"] = LoginToken.EmployeeID;
                Session["FeeTypeID"] = 2;
                Session["TotalAmount"] = txt_totalamount.Text == "" ? "0" : txt_totalamount.Text;
                Session["FineAmount"] = txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text;
                Session["ExemptionAmount"] = txt_discountamount.Text == "" ? "0" : txt_discountamount.Text;
                Session["TotalPaidAmount"] = txt_payableamount.Text == "" ? "0" : txt_payableamount.Text;
                Session["AcademicSessionID"] = ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue;

                Response.Redirect("~/Payment.aspx", false);

            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }
        }
        protected void chkfeestatus_CheckedChanged(object sender, EventArgs e)
        {
            txt_totalamount.Text = "";
            txt_totalfineamount.Text = "";
            txt_discountamount.Text = "";
            txt_payableamount.Text = "";
            txt_totalfineamount.Text = "";
            double SumFeeAmount = 0;
            //double SumExemptAmount = 0;
            double SumFineAmount = 0;
            double SumTotalAmount = 0;
            double SumTotalExempted = 0;
            double NetAmount = 0;
            int index = 0;

            foreach (GridViewRow gvr in GvFeedetails.Rows)
            {
                CheckBox cb = (CheckBox)gvr.FindControl("chkfeestatus");
                Label MonthID = gvr.FindControl("lblmonthID") as Label;
                Label prepaiddueDate = gvr.FindControl("lbl_prepaidDuedate") as Label;
                Label postpaiddueDate = gvr.FindControl("lbl_postpaidDuedate") as Label;
                Label fineamount = gvr.FindControl("lblactualfineamount") as Label;
                Label exemptamount = (Label)(gvr.FindControl("lbl_exemptedamount"));
                Label calfineamount = gvr.FindControl("lblcalcfineamount") as Label;
                Label Feeamnt = (Label)(gvr.FindControl("lblfeeamount"));
                string CMonth = DateTime.Now.ToString("MM");
                string CYear = DateTime.Now.ToString("yyyy");
                string CDate = DateTime.Now.ToString("dd");
                int cmonthIDs = Convert.ToInt32(CMonth + CYear);
                if (Convert.ToDecimal(Feeamnt.Text == "" ? "0.0" : Feeamnt.Text) == Convert.ToDecimal(exemptamount.Text == "" ? "0.0" : exemptamount.Text))
                {
                    fineamount.Text = "0";
                }

                if (cb.Checked)
                {
                    gvr.BackColor = System.Drawing.Color.LightBlue;
                    if (Convert.ToInt32(cmonthIDs) > Convert.ToInt32(MonthID.Text))
                    {
                        calfineamount.Text = fineamount.Text;

                    }
                    if (Convert.ToInt32(cmonthIDs) == Convert.ToInt32(MonthID.Text))
                    {
                        if (Convert.ToInt32(CDate) > Convert.ToInt32(prepaiddueDate.Text))
                        { calfineamount.Text = fineamount.Text; }
                        else
                        { calfineamount.Text = ""; }
                    }
                }
                else
                {
                    gvr.BackColor = System.Drawing.Color.Transparent;
                    calfineamount.Text = "";
                }
                if (cb.Checked && cb != null)
                {
                    Label FeeAmount = (Label)(gvr.FindControl("lblfeeamount"));
                    Label exemptionamount = (Label)(gvr.FindControl("lbl_exemptedamount"));
                    double TotalAmt = Convert.ToDouble(FeeAmount.Text);
                    double TotalexmpAmt = Convert.ToDouble(exemptionamount.Text);
                    double cfineamount = Convert.ToDouble(calfineamount.Text == "" ? "0.0" : calfineamount.Text);
                    SumFineAmount += cfineamount;
                    SumTotalAmount += TotalAmt;
                    if (TotalexmpAmt > 0)// temporary solution
                    {
                        SumTotalExempted += TotalAmt;
                    }

                    NetAmount += (TotalAmt + cfineamount);
                    txt_totalamount.Text = SumTotalAmount.ToString("N2");
                    txt_totalfineamount.Text = SumFineAmount.ToString("N2");
                    txt_discountamount.Text = SumTotalExempted.ToString("N2");
                    txt_payableamount.Text = (NetAmount - SumTotalExempted).ToString("N2");
                    btnpay.Attributes.Remove("disabled");
                    FeeAmount.Focus();
                }
            }
            if (SumTotalAmount == 0)
            {
                txt_totalamount.Text = "";
                txt_totalfineamount.Text = "";
                txt_discountamount.Text = "";
                txt_payableamount.Text = "";
                txt_totalfineamount.Text = "";
                btnpay.Attributes["disabled"] = "disabled";
            }
        }
        int count = 0;

        public object ModuleDasboard { get; private set; }

        protected void GvFeedetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label paymentstatus = e.Row.FindControl("lbl_paymentstatus") as Label;
                    Label monthID = e.Row.FindControl("lblmonthID") as Label;
                    CheckBox FeeCheckBox = e.Row.FindControl("chkfeestatus") as CheckBox;
                    Label fineamount = e.Row.FindControl("lblactualfineamount") as Label;
                    string CMonth = DateTime.Now.ToString("MM");

                    if (paymentstatus.Text == "Paid")
                    {
                        FeeCheckBox.Visible = false;
                        fineamount.Visible = true;
                    }
                    else
                    {
                        FeeCheckBox.Visible = true;
                        fineamount.Visible = false;
                    }

                    if (paymentstatus.Text == "Paid")
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                        e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                        count = count + 1;

                    }
                    else
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.White;
                        e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
                    }
                }
                if (count == 1)
                {
                    txt_paymentstatus.Text = "Paid : " + count.ToString() + " Month.";
                    txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                    txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                }
                if (count > 1)
                {
                    txt_paymentstatus.Text = "Paid : " + count.ToString() + " Months.";
                    txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                    txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                }
                if (count == 0)
                {
                    txt_paymentstatus.Text = "Paid : 0 Month.";
                    txt_paymentstatus.BackColor = System.Drawing.Color.Yellow;
                    txt_paymentstatus.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                //lblmessage.Text = ExceptionMessage.GetMessage(ex);
            }

        }
        protected void btn_razorpay_Click(object sender, EventArgs e)
        {
            //string paymentId = orderId; // Request.Form["razorpay_payment_id"];

            //Dictionary<string, object> input = new Dictionary<string, object>();
            //input.Add("amount", 100); // this amount should be same as transaction amount

            //string key = "rzp_test_31Rowr54MAlxlt";
            //string secret = "QhyN2MXvcjZGv33L77d7cXaA";

            //RazorpayClient client = new RazorpayClient(key, secret);

            //Dictionary<string, string> attributes = new Dictionary<string, string>();

            //attributes.Add("razorpay_payment_id", paymentId);
            //attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            //attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            //Utils.verifyPaymentSignature(attributes);

        }

    }
}