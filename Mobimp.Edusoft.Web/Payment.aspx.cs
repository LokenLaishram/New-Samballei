using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobimp.Campusoft.Web
{
    public partial class Payment : System.Web.UI.Page
    {
        public string orderId;
        public string Amount;
        public string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            decimal paidamount = Convert.ToDecimal(Session["TotalPaidAmount"]);
            
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100 * paidamount); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "");
            input.Add("payment_capture", 1);
       
            string key = "rzp_live_UkDxBlkiTZU1X0";
            string secret = "HdZPzrHYC4lz2VprxfZD2Pbi";

            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            orderId = order["id"].ToString();
            Amount = order["amount"].ToString();
        }
    }
}