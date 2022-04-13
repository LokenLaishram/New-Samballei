<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Postexamsetting.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduUtility.Postexamsetting" %>

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
            if (document.getElementById("<%=ddlacademicsession.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Session.";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        function Validates() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=ddlclasses.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Exam.";
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

    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="css3gradient">
                <div style="text-align: center">
                    Post Exam Settings
                </div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Academic Session"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" CssClass="cusDropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlclasses" AutoPostBack="true" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged"
                                            runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Label ID="lblexam" runat="server" Text="Exam Name"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlexam" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlexam" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click"
                                    OnClientClick="return Validates();" />
                                <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="panelresult" runat="server" Height="300px" GroupingText="Result">
                    <div style="height: 300px; width: 100%; overflow: auto;">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="loading ">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                    <%--<center class="white">
                                        Loading...
                                    </center>--%>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="GvExamdetails" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                            OnRowDataBound="GvExamdetails_RowDataBound" AutoGenerateColumns="False" Width="100%"
                            class="grid" AllowPaging="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        ID</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Exam Name</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Descriptions")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        Class Name</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                        <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkstudent" Visible="false" runat="server" Text='<%# Eval("chkstudent")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkstd" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchksubject" Visible="false" runat="server" Text='<%# Eval("chksubject")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chksubject" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alt Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkaltsubject" Visible="false" runat="server" Text='<%# Eval("chkaltsubject")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkaltsubject" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opt Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkoptional" Visible="false" runat="server" Text='<%# Eval("chkoptsubject")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkoptsubject" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkmark" Visible="false" runat="server" Text='<%# Eval("chkmark")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkmark" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mark Entry">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkmarkentry" Visible="false" runat="server" Text='<%# Eval("chkmarkentry")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkmarkentry" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Result Declared">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchkresult" Visible="false" runat="server" Text='<%# Eval("chkresult")%>'></asp:Label>
                                        <asp:Label ID="lblchkpublisresult" Visible="false" runat="server" Text='<%# Eval("Chkresultpublish")%>'></asp:Label>
                                        <asp:CheckBox runat="server" Enabled="false" ID="chkdresult" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#d8ebf5" />
                        </asp:GridView>
                        <left>
                            <%--<asp:CustomPager ID="ExamPager" runat="server" />--%>
                        </left>
                    </div>
                    <div style="text-align: right">
                        <asp:Button ID="btnupdate" runat="server" Text="Update" Enabled="false" UseSubmitBehavior="false"
                            CssClass="button" OnClick="btnupdate_Click" />
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
