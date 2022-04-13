using Mobimp.Campusoft.BussinessProcess.StudentPortalBO;
using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Edusoft.BussinessProcess.Common;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.Common;
using Mobimp.Edusoft.Data.EduAdmin;
using Mobimp.Edusoft.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.StdudentPortal.Fees
{
    public partial class OnlineAdmission : BasePage
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                txt_paymentstatus.Text = listdetails[0].PaymentStatus.ToString();
                lbl_lastdateID.Text = listdetails[0].FineDate.ToString("dd/MM/yyyy");
                if (listdetails[0].PaymentStatus.ToString() == "Not Paid")
                {
                    lbllastdate.Text = "Last Date";
                    lblpayableamount.Text = "Total Payable Amount (INR)";
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());
                    txt_paymentstatus.BackColor = System.Drawing.Color.Yellow;

                    if ((DateTime.Now - listdetails[0].FineDate).TotalDays > 0)
                    {
                        txt_totalfineamount.Text = Commonfunction.Getrounding(listdetails[0].FineAmount.ToString());
                    }
                    else
                    {
                        txt_totalfineamount.Text = "";
                    }
                    txt_discountamount.Text = Commonfunction.Getrounding(listdetails[0].ExemptionAmount.ToString());
                    txt_payableamount.Text = Commonfunction.Getrounding(((Convert.ToDecimal(txt_totalamount.Text == "" ? "0" : txt_totalamount.Text)
                                             + Convert.ToDecimal(txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text))
                                             - Convert.ToDecimal(txt_discountamount.Text == "" ? "0" : txt_discountamount.Text)).ToString());
                }
                if (listdetails[0].PaymentStatus.ToString() == "Paid")
                {
                    txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                    txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                    txt_totalamount.Text = Commonfunction.Getrounding(listdetails[0].TotalAmount.ToString());
                    txt_totalfineamount.Text = Commonfunction.Getrounding(listdetails[0].FineAmount.ToString());
                    txt_discountamount.Text = Commonfunction.Getrounding(listdetails[0].ExemptionAmount.ToString());
                    txt_payableamount.Text = "0.0";
                    btnpay.Attributes["disabled"] = "disabled";
                    lbllastdate.Text = "Payment Date";
                    lbl_lastdateID.Text = listdetails[0].PaymentDate.ToString("dd/MM/yyyy");
                    lbl_lastdateID.BackColor = System.Drawing.Color.Green;
                    lbl_lastdateID.ForeColor = System.Drawing.Color.White;
                    lblpayableamount.Text = "Total Paid Amount (INR)";
                    txt_payableamount.Text = Commonfunction.Getrounding(listdetails[0].TotalPaidAmount.ToString());
                    txt_payableamount.BackColor = System.Drawing.Color.Green;
                    txt_payableamount.ForeColor = System.Drawing.Color.White;

                }
                if (listdetails[0].Prevfeestatus.ToString() == "0")
                {
                    btnpay.Attributes["disabled"] = "disabled";
                    lbl_message.Text = "Previous year fees are due .Please clear and try again !!!.";
                    return;
                }
                // bindresponsive();
                //ds = ConvertToDataSet(listdetails);
            }
            else
            {
                GvFeedetails.DataSource = null;
                GvFeedetails.DataBind();
                GvFeedetails.Visible = true;
                txtstddetail.Text = "";
                txt_paymentstatus.Text = "";
                lbl_lastdateID.Text = "";
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
            objpayment.FeeTypeID = 1;
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
                foreach (GridViewRow row in GvFeedetails.Rows)
                {
                    Label IDS = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblID");
                    Label monthID = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblmonthID");
                    Label feetype = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeetypeID");
                    Label Particular = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblparticulars");
                    Label Feeamount = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblfeeamount");
                    Label Class = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("lblclassID");
                    Label Session = (Label)GvFeedetails.Rows[row.RowIndex].Cells[0].FindControl("sessionID");
                    PaymentData objdata = new PaymentData();
                    objdata.ID = Convert.ToInt32(IDS.Text == "" ? "0" : IDS.Text);
                    objdata.ClassID = Convert.ToInt32(Class.Text == "" ? "0" : Class.Text);
                    objdata.MonthID = Convert.ToInt32(monthID.Text == "" ? "0" : monthID.Text);
                    objdata.FeeTypeID = Convert.ToInt32(feetype.Text == "" ? "0" : feetype.Text);
                    objdata.FeeAmount = Convert.ToDecimal(Feeamount.Text == "" ? "0" : Feeamount.Text);
                    objdata.Particulars = Convert.ToString(Particular.Text);
                    objdata.AcademicSessionID = Convert.ToInt32(Session.Text == "" ? "0" : Session.Text);
                    paymentlist.Add(objdata);
                    check++;
                }
                Objpaydata.XMLData = XmlConvertor.OnlinepaymentStoXML(paymentlist).ToString();
                Session["PaymentDetails"] = XmlConvertor.OnlinepaymentStoXML(paymentlist).ToString();
                Objpaydata.StudentID = LoginToken.EmployeeID; // here employeeID is Student ID
                Objpaydata.FeeTypeID = 1;
                Objpaydata.TotalAmount = Convert.ToDecimal(txt_totalamount.Text == "" ? "0" : txt_totalamount.Text);
                Objpaydata.FineAmount = Convert.ToDecimal(txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text);
                Objpaydata.ExemptionAmount = Convert.ToDecimal(txt_discountamount.Text == "" ? "0" : txt_discountamount.Text);
                Objpaydata.TotalPaidAmount = Convert.ToDecimal(txt_payableamount.Text == "" ? "0" : txt_payableamount.Text);
                Objpaydata.AcademicSessionID = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);
                Objpaydata.CompanyID = LoginToken.CompanyID;
                Objpaydata.PaymentType = 1;

                Session["StudentID"] = LoginToken.EmployeeID;
                Session["FeeTypeID"] = 1;
                Session["TotalAmount"] = txt_totalamount.Text == "" ? "0" : txt_totalamount.Text;
                Session["FineAmount"] = txt_totalfineamount.Text == "" ? "0" : txt_totalfineamount.Text;
                Session["ExemptionAmount"] = txt_discountamount.Text == "" ? "0" : txt_discountamount.Text;
                Session["TotalPaidAmount"] = txt_payableamount.Text == "" ? "0" : txt_payableamount.Text;
                Session["AcademicSessionID"] = ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue;

                Response.Redirect("~/Payment.aspx", false);



                //if (fileName1 != "")
                //{
                //    //imageuploader as bit image
                //    int length = receiptuploadr.PostedFile.ContentLength;
                //    //create a byte array to store the binary image data
                //    byte[] imgbyte = new byte[length];
                //    //store the currently selected file in memeory
                //    HttpPostedFile img = receiptuploadr.PostedFile;
                //    //set the binary data
                //    img.InputStream.Read(imgbyte, 0, length);
                //    Objpaydata.Paymentreceipt = imgbyte;
                //}
                //int result = objpaymentBO.Payfee(Objpaydata);
                //if (result > 0)
                //{
                //    bindgrid(1);
                //    Session["BillID"] = result.ToString();
                //    Session["PaidAmount"] = 1;// txt_totalamount.Text == "" ? "0" : txt_totalamount.Text;
                //    Session["StudentID"] = LoginToken.EmployeeID; // Student ID
                //    Session["Year"] = Convert.ToInt32(ddlacademicsession.SelectedValue == "" ? "0" : ddlacademicsession.SelectedValue);

                //    Response.Redirect("~/StdudentPortal/Fees/PaymentStatus", false);

                //    btnpay.Attributes["disabled"] = "disabled";
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "successalert('" + Messagealert_.Alertmessage("Paid") + "')", true);
                //}
                //if (result == 2)
                //{
                //    btnpay.Attributes.Remove("disabled");
                //    txt_paymentstatus.BackColor = System.Drawing.Color.Green;
                //    txt_paymentstatus.ForeColor = System.Drawing.Color.White;
                //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + Messagealert_.Alertmessage("Duplicatepay") + "')", true);
                //}
            }
            catch (Exception ex) //Exception in agent layer itself
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.UIExceptionPolicy, ex, "1000001");
                LogManager.UpdateCmsErrorDetails(ex, EnumErrorLogSourceTier.Web);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "failalert('" + ExceptionMessage.GetMessage(ex) + "')", true);
                return;
            }
        }
    }
}