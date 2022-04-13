<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Mobimp.Campusoft.Web.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay App</title>
    <style>
 
        /* Extra small devices (phones, 600px and down) */
        @media only screen and (max-width: 600px) {
            .btnpayment {
                    width: 50% !important;
    font-size: 14px !important;
    font-weight: bolder !important;
    background-color: orange !important;
    height: 30px !important;
    user-select: auto !important;
    color: #fff !important;
    border-style: none !important;
}
        }


        /* Small devices (portrait tablets and large phones, 600px and up) */
        @media only screen and (min-width: 700px) {
            .btnpayment {
                width: 46% !important;
                font-size: 35px !important;
                font-weight: bolder !important;
                background-color: orange !important;
                height: 76px !important;
                user-select: auto !important;
                color: #fff !important;
                border-style: none !important;
            }
        }


        /* Medium devices (landscape tablets, 768px and up) */
        @media only screen and (min-width: 768px) {
            .btnpayment {
                width: 46% !important;
                font-size: 35px !important;
                font-weight: bolder !important;
                background-color: orange !important;
                height: 76px !important;
                user-select: auto !important;
                color: #fff !important;
                border-style: none !important;
            }
        }

        /* Large devices (laptops/desktops, 992px and up) */
        @media only screen and (min-width: 992px) {
            .btnpayment {
                width: 17% !important;
                font-size: 21px !important;
                font-weight: bolder !important;
                background-color: orange !important;
                height: 52px !important;
                user-select: auto !important;
                color: #fff !important;
                border-style: none !important;
            }
        }

        /* Extra large devices (large laptops and desktops, 1200px and up) */
        @media only screen and (min-width: 1200px) {

            .btnpayment {
                width: 17% !important;
                font-size: 21px !important;
                font-weight: bolder !important;
                background-color: orange !important;
                height: 52px !important;
                user-select: auto !important;
                color: #fff !important;
                border-style: none !important;
            }
        }
    </style>
    <form action="StdudentPortal/Fees/PaymentStatus.aspx" method="post" name="razorpayForm">
        <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
        <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
        <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
    </form>
</head>

<body>
    <div style="height: 40vh"></div>
    <div style="text-align: center;">
        <button class="btnpayment" id="rzp-button1">Pay with Razorpay</button>
    </div>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        var orderId = "<%=orderId%>"
        var name = "<%=Name%>"
        var options = {
            "name": name,
            "description": "Pitambara School Fee Payment",
            "order_id": orderId,
            "image": "app-assets/images/login/PitambaraLogo.jpeg",
            "prefill": {
                "name": name,
                "email": "pstduent@gmail.com",
            },
            "notes": {
                "address": name,
                "email": "pstduent@gmail.com",
                "merchant_order_id": "<%=orderId%>",
        },
        "theme": {
            "color": "#F37254"
        }
    }
    // Boolean whether to show image inside a white frame. (default: true)
    options.theme.image_padding = false;
    options.handler = function (response) {
        document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
        document.getElementById('razorpay_order_id').value = orderId;
        document.getElementById('razorpay_signature').value = response.razorpay_signature;
        document.razorpayForm.submit(response.merchant_order_id);
    };
    options.modal = {
        ondismiss: function () {
            console.log("This code runs when the popup is closed");
        },
        // Boolean indicating whether pressing escape key 
        // should close the checkout form. (default: true)
        escape: true,
        // Boolean indicating whether clicking translucent blank
        // space outside checkout form should close the form. (default: false)
        backdropclose: false
    };
    var rzp = new Razorpay(options);
    document.getElementById('rzp-button1').onclick = function (e) {
        rzp.open();
        e.preventDefault();
    }
        </script >
</body>

</html>

