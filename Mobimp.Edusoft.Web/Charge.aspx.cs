using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentId = Request.Form["razorpay_payment_id"];
            string orderid = Request.Form["razorpay_order_id"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount


            string key = "rzp_test_cu47rEUAm1xF1d";
            string secret = "ih5Ode8J7nwvY7COqayebty2";

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            Utils.verifyPaymentSignature(attributes);

            //          Please use below code to refund the payment   
            //          Refund refund = new Razorpay.Api.Payment((string) paymentId).Refund();

            Console.WriteLine(paymentId);

        }
    }
}