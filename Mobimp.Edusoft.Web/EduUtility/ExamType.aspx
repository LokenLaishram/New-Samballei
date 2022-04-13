<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="ExamType.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduUtility.ExamType" %>

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
                    <h4>Exam Type Details</h4></div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td>
                                <asp:Label ID="lblexam" runat="server" Text="Exam Name"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlexam" runat="server" CssClass="cusDropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
                <div  style="text-align: right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click" />
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
                            AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false" OnRowCommand="GvExamdetails_RowCommand">
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
                                        <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("ExamName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Class Name</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                        <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Full Mark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("FullMark")%>' Width="50px"
                                            ID="txtfullmark"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pass Mark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("PassMark")%>' Width="50px"
                                            ID="txtpassmark"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
<%--                                <asp:TemplateField HeaderText="PR. Fmark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("PM")%>' Width="50px"
                                            ID="txtPMmark"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PR. Pmark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("PRpassMark")%>'
                                            Width="50px" ID="txtPRpassmark"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Total Mark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("TotalMark")%>'
                                            Width="50px" ID="txttotalmarks"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Passmark">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("TotalPassMark")%>'
                                            Width="50px" ID="txttotakpassmark"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Added By</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Date</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Edit</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                            CommandName="Edits" ForeColor="Blue">
                                  <img src="../EduImages/edit.png" height="20px" alt="" title="Edit" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Delete</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("ID")%>'
                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');">
                                            <img src="../EduImages/delete.png" height="20px" alt="" title="Delete"  border="0" />
                                       
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#d8ebf5" />
                        </asp:GridView>
                        <left>
                            <%--<asp:CustomPager ID="ExamPager" runat="server" />--%>
                        </left>
                    </div>
                    <div  style="text-align: right">
                        <asp:Button ID="btnupdate" runat="server" Text="Update" Enabled="false" UseSubmitBehavior="false"
                            CssClass="button" OnClick="btnupdate_Click" />
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
