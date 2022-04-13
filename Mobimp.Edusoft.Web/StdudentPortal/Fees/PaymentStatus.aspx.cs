using Mobimp.Campusoft.BussinessProcess.StudentPortalBO;
using Mobimp.Campusoft.Data.StudentPortal;
using Mobimp.Edusoft.Web.AppCode;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web.StdudentPortal.Fees
{
    public partial class PaymentStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PaymentDetails"] != null && Session["StudentID"] != null
              && Session["FeeTypeID"] != null && Session["TotalAmount"] != null && Session["FineAmount"] != null
              && Session["ExemptionAmount"] != null && Session["TotalPaidAmount"] != null && Session["AcademicSessionID"] != null
             )
            {

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    string paymentId = Request.Form["razorpay_payment_id"];

                    string orderid = Request.Form["razorpay_order_id"];

                    Dictionary<string, object> input = new Dictionary<string, object>();
                    input.Add("amount", Session["TotalPaidAmount"].ToString()); // this amount should be same as transaction amount

                    string key = "rzp_live_UkDxBlkiTZU1X0";
                    string secret = "HdZPzrHYC4lz2VprxfZD2Pbi";

                    RazorpayClient client = new RazorpayClient(key, secret);
                    Dictionary<string, string> attributes = new Dictionary<string, string>();

                    attributes.Add("razorpay_payment_id", paymentId);
                    attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
                    attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

                    Utils.verifyPaymentSignature(attributes);


                    OnlinepaymentBO objpaymentBO = new OnlinepaymentBO();
                    PaymentData Objpaydata = new PaymentData();
                    Objpaydata.XMLData = Session["PaymentDetails"].ToString();
                    Objpaydata.StudentID = Convert.ToInt64(Session["StudentID"].ToString()); // here employeeID is Student ID
                    Objpaydata.FeeTypeID = Convert.ToInt32(Session["FeeTypeID"].ToString()); ;
                    Objpaydata.TotalAmount = Convert.ToDecimal(Session["TotalAmount"].ToString());
                    Objpaydata.FineAmount = Convert.ToDecimal(Session["FineAmount"].ToString());
                    Objpaydata.ExemptionAmount = Convert.ToDecimal(Session["ExemptionAmount"].ToString());
                    Objpaydata.TotalPaidAmount = Convert.ToDecimal(Session["TotalPaidAmount"].ToString());
                    Objpaydata.AcademicSessionID = Convert.ToInt32(Session["AcademicSessionID"].ToString());
                    Objpaydata.PaymentID = paymentId;
                    Objpaydata.OrderID = orderid;
                    Objpaydata.CompanyID = 1;
                    Objpaydata.PaymentType = 1; //online
                    Objpaydata.EmployeeID = Convert.ToInt64(Session["StudentID"].ToString());
                    IFormatProvider option = new System.Globalization.CultureInfo("en-GB", true);
                    DateTime date = DateTime.Today;
                    Objpaydata.Billdate = date;
                    int result = objpaymentBO.Payfee(Objpaydata);
                    if (result > 0)
                    {
                        lbl_feestatus.Text = "Successfully paid fee amount of ₹ " + Session["TotalPaidAmount"].ToString()+ " (exclusive of bank convenience and gst charges)";
                        lbl_feestatus.Visible = true;
                        Session["BillID"] = result.ToString();
                        lbl_error.Visible = false;
                        Session["PaymentDetails"] = null;
                        Session["FeeTypeID"] = null;
                        Session["TotalAmount"] = null;
                        Session["FineAmount"] = null;
                        Session["ExemptionAmount"] = null;
                        Session["TotalPaidAmount"] = null;

                    }
                }
                catch (Exception ex)
                {
                    lbl_error.Text = ex.ToString(); ;
                    lbl_feestatus.Visible = false;
                    lbl_error.Visible = true;
                }
            }

        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (Session["BillID"] != null && Session["StudentID"] != null && Session["AcademicSessionID"] != null)
            {
                string baseurl = Request.Url.GetLeftPart(UriPartial.Authority);
                string sessionid = Session["AcademicSessionID"].ToString();
                string studentID = Session["StudentID"].ToString();
                string billID = Session["BillID"].ToString();
                string feetype = "2";

                string param = "option=FeeReciept&SessionID=" + sessionid + "&StudentID=" + studentID + "&BillID=" + billID + "&FeeTypeID=" + feetype;
                Commonfunction common = new Commonfunction();
                string ecryptstring = common.Encrypt(param);
                string url = baseurl + "/StdudentPortal/EnReports/ReportViewer.aspx?ID=" + ecryptstring;

                string fullURL = "window.open('" + url + "', '_blank');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_New_Tab", fullURL, true);
            }

        }
    }
}