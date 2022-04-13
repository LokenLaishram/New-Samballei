<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PasswordChange.aspx.cs" Inherits="Mobimp.Edusoft.Web.PasswordChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Pass Word&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="PasswordChange.aspx">PassWord Change</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <div class="card_wrapper">
                    <div class="row">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                  <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" class="form-control"  ID="txtempnames"></asp:TextBox>
                              </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblloginID" runat="server" Text="User Name"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" class="form-control" Enabled="true" ID="txtusername"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbloldpassword" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblpassword" runat="server" Text="Old Password"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" class="form-control" TextMode="Password" ID="txtpassword"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblnewpassword" runat="server" Text="New Password"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtpasswords" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblconfirmpassword" runat="server" Text="Confirm Password"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcpassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtpasswords" ControlToCompare="txtcpassword"
                                    runat="server" ErrorMessage="Password does not match." ValidationGroup="grp"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" Text="Save" OnClick="btnsave_Click"
                                    OnClientClick="return Validate()" />
                                <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btncancel_Click" />
                                <%-- <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel"  class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </contenttemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">

        function successalert(str) {
            swal({
                title: "",
                text: str,
                icon: "success",
            });
        }
        function failalert(str) {
            swal({
                title: "",
                text: str,
                icon: "warning",
            });
        }
        function Validate() {

            var str = "";
            var i = 0;
            if (document.getElementById("<%=txtusername.ClientID%>").value == "") {
                str = str + "\n Please enter User name.";
                document.getElementById("<%=txtusername.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=txtpassword.ClientID%>").value == "") {
                str = str + "\n Please enter password.";
                document.getElementById("<%=txtpassword.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtpasswords.ClientID%>").value == "") {
                str = str + "\n Please enter password.";
                document.getElementById("<%=txtpasswords.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtcpassword.ClientID%>").value == "") {
                str = str + "\n Please enter password.";
                document.getElementById("<%=txtcpassword.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false;
            }
            else
                return true;
        }
    </script>
</asp:Content>

