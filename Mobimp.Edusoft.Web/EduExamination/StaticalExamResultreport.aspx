<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="StaticalExamResultreport.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.StaticalExamResultreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

        var Page;
        function pageLoad() {

            Page = Sys.WebForms.PageRequestManager.getInstance();

            Page.add_initializeRequest(OnInitializeRequest);

        }

        function OnInitializeRequest(sender, args) {

            var postBackElement = args.get_postBackElement();

            if (Page.get_isInAsyncPostBack()) {
                alert('One request is already in progress....');
                args.set_cancel(true);
            }

        }
        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlacademicseesions.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlcategory.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Category.";
                document.getElementById("<%=ddlcategory.ClientID %>").focus();
                i++;
            }
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
            else
                return true;
        }
        function Validate1() {

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
            else
                return true;
        }
        function PrintResult() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")

            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objexam = document.getElementById("<%= ddlexam.ClientID %>")
            ObjeCategory = document.getElementById("<%= ddlcategory.ClientID %>")
            ObjexamNo = document.getElementById("<%= examtypeID.ClientID %>")
            window.open("../EduReports/Reports/ReportViewer.aspx?option=PrintStatisticalReport&Session=" + objsession.value + "&ExamNo=" + ObjexamNo.value);

        }
    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Exam Result Processor">
                    <ContentTemplate>
                        <div id="divmessage" runat="server">
                            <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                        <div>
                            <table width="100%" class="fontstyle">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStudentcategory" Visible="False" runat="server" Text="Category"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlcategory" Visible="false" AutoPostBack="true" runat="server"
                                                    CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcategory" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged"
                                                    CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblsections" runat="server" Visible="False" Text="Section"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsections" Visible="false" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsections" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlexam" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                    OnSelectedIndexChanged="ddlexam_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlexam" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Enabled="False" CssClass="cusTextBox" Width="50px" ID="examtypeID"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div >
                            <table width="100%">
                                <tr>
                                    <td style="text-align: center">
                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprocess" runat="server" CssClass="button" Text="Process" OnClientClick="return Validate1();"
                                                    Width="87px" OnClick="btnprocess_Click" />
                                                <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" OnClientClick="return PrintResult();" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
