<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mobimp.Campusoft.Web.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Sambalei Sekpil School Login Page">
    <meta name="author" content="MOBIMP">
    <title>Campusoft</title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="style.css" rel="stylesheet">
    <style>

    </style>
</head>
<body class=" login2background">
    <div id="page-container">
        <div class="container-fluid">
            <div class="row mtrl-cus">
                <div class="col-md-3 textcenter">
                    <div style="text-align: center; margin-top:1em">
                        <img class="logoclient" src="app-assets/images/login/SambaleiSekpil_Logo.png">
                        <br />
                        <br />
                        <p class="address">Near Kumbi Pologround, Manipur.</p>
                    </div>
                </div>
                <div class="col-md-6"></div>
                <div class="col-md-3 loginbox">
                    <form runat="server" id="Form1" class="login">
                        <div class=" row">
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-6">
                                <img src="assets/img/cs.jpg" alt="Logo" class="logo img-circle">
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-6  ">
                                <span class="singtext">Login </span>
                            </div>
                        </div>
                        <div class=" row loginbox_content ">
                            <div class="input-group input-group-sm">
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-user" style="color: #fff;"></span>
                                </span>
                                <asp:TextBox runat="server" ID="txtusername" type="text" class="form-control " placeholder="Username" value=""></asp:TextBox>
                            </div>
                            <div class="input-group input-group-sm">
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-lock" style="color: #fff;"></span>
                                </span>
                                <asp:TextBox runat="server" ID="txtpassword" type="password" class="form-control" placeholder="Password" value=""></asp:TextBox>
                                
                                <%-- <div class="flex-sb-m w-full" style="margin-top: 6px;">
                                    <input id="myCheckbox" runat="server" style="margin-top: 3px;" type="checkbox" checked>
                                    <label for="myCheckbox" style="margin-left: -70px; font-size: 12px;">Remember me</label>
                                    <span></span>
                                </div>--%>
                            </div>
                            <div class="input-group input-group-sm" style="font-size: 12px; color: #fff;" >
                              <input type="checkbox" onclick="myFunction()"> <label >  Show Password</label>
                                </div>
                            <div class="input-group input-group-sm" style=" margin-top: -15px; font-size: 12px; color: #fff;" >
                               <input name="myCheckbox"  runat="server" type="checkbox" id="myCheckbox"  checked="checked"><label >  Remember Me</label>
                                </div>
                        </div>
                        <div class="row" style="margin-top: -21px;">
                            <div class="col-lg-8 col-md-8  col-sm-8 col-xs-7 forgotpassword ">
                                
                                
                               <%-- <a href="#">Forgot Password?</a>--%>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4  col-xs-5 ">
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-default submit-btn" Text="Login" OnClick="btnlogin_Click" />
                            </div>

                        </div>
                        <div class="row" style="margin-top: -14px;">
                            <br />
                            <div class="col-md-12">
                                <div style="color: rgb(255, 255, 255); text-align: -webkit-center; background-color: #eb4336; font-size: .9em;">
                                    <span runat="server" id="lblmessage"></span>
                                </div>
                            </div>
                        </div>
                        <hr style="margin-top: 5px; margin-bottom: 5px">
                        <div class="row ">
                            
                            <div class="col-md-12 support">
                                <a href="#" style="color: #fff;">Dial number</a> <span style="font-size: 12px; font-weight:bold; color: #fff;"># 9366935564,6009755187</span>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="container-fluid displaymobile">
            <div class="row">
                <div class="col-md-12 graphics">
                    <img class="img-responsive" src="assets/img/graphic.svg">
                </div>
            </div>
        </div>
        <footer id="footer">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-5">
                        <p class="mt20 pfont">
                            <asp:Label runat="server" ID="lbl_softwarerights"></asp:Label>
                        </p>
                    </div>
                    <div class="col-md-5 mt20 pfont displaymobile">
                        <a style="color: #FFFFFF" href="#">Powered By - Mobimp Services Pvt Ltd</a>
                    </div>
                    <div class="col-md-2 displaymobile mt15">
                        <img class="textcentermob" src="assets/img/1.png" width="120">
                    </div>
                </div>
            </div>
        </footer>
    </div>
    <!-- Bootstrap core JavaScript
         ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="assets/js/ie10-viewport-bug-workaround.js"></script>
    <script>
        function myFunction() {
            var x = document.getElementById("txtpassword");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
    </script>
</body>
