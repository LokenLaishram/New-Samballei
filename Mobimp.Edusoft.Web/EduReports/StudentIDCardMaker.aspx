<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="StudentIDCardMaker.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduReports.StudentIDCardMaker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduReports/StudentIDCardMaker.aspx">Print ID Card</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="StudentIDCardMaker">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                             <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>
                                             <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClassID" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlSectionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtRollNo" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                Enabled="True" TargetControlID="txtRollNo" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.6em;">
                                             <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintIDCard();" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
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

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Academic Session."
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Class."
                document.getElementById("<%=ddlClassID.ClientID %>").focus()
                i++
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {
                return true
            }
        }
        function PrintIDCard() {

            var str = ""
            var i = 0
            var objStdID = ""

          
            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Academic Session."
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (objStdID.trim() == "") {
                if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                    str = str + "\n Please Select Class."
                    document.getElementById("<%=ddlClassID.ClientID %>").focus()
                    i++
                }
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {

                objclass = document.getElementById("<%= ddlClassID.ClientID %>")
                objsection = document.getElementById("<%= ddlSectionID.ClientID %>")
                objrollno = document.getElementById("<%= txtRollNo.ClientID %>")
                objsession = document.getElementById("<%= ddlAcademicSessionID.ClientID %>")

                window.open("../EduReports/Reports/ReportViewer.aspx?option=IDcard&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value )
            }
        }
    </script>
</asp:Content>
