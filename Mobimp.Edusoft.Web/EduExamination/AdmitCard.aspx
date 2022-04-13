<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="AdmitCard.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.EduExamination.AdmitCard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/ClassMST.aspx">Admit Card</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblacademicsession" Text="Academic Years"></asp:Label>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblclasses" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblsections" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsections" runat="server" AutoPostBack="true" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblexam" Text="Exam"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlexam" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrollNo" Text="Roll No"></asp:Label>
                                <asp:TextBox ID="txtrollNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnprint" runat="server" class="btn btn-sm btn-indigo button" Text="Print" OnClientClick="return PrintAdmitCard();" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false;
            }
            else {
                return true;
            }
        }

        function PrintAdmitCard() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
        objsection = document.getElementById("<%= ddlsections.ClientID %>")
        objrollno = document.getElementById("<%= txtrollNo.ClientID %>")
        objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
        objexam = document.getElementById("<%= ddlexam.ClientID %>")

            window.open("../EduReports/Reports/ReportViewer.aspx?option=AdmitCard&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamID=" + objexam.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value)
        }
    </script>
</asp:Content>
