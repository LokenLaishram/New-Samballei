<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="FeeDetailMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduUtility.FeeDetailMST" %>

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


            if (document.getElementById("<%=ddlfeetype.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select feetype.";
                document.getElementById("<%=ddlfeetype.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlfeetype.ClientID%>").value == "10") {
                if (document.getElementById("<%=ddladmissiontype.ClientID%>").selectedIndex == "0") {
                    str = str + "\n Please select student type.";
                    document.getElementById("<%=ddladmissiontype.ClientID %>").focus();
                    i++;
                }

            }
            if (document.getElementById("<%=txtfee.ClientID%>").value == "") {
                str = str + "\n Please enter fee amount.";
                document.getElementById("<%=txtfee.ClientID %>").focus();
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
                <div style="text-align:center">Fee Details</div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%" class="fontstyle">
                        <tr>
                            <td width="180px">
                                <asp:Label ID="lblsession" runat="server" Text="Academic Year"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlacademicsession" CssClass="cusDropDown" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="180px">
                                <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlclass" CssClass="cusDropDown" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="180px">
                                <asp:Label ID="lblfeetype" runat="server" Text="Fee Type"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlfeetype" AutoPostBack="true" CssClass="cusDropDown" runat="server"
                                    OnSelectedIndexChanged="ddlfeetype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                           
                        </tr>
                        <tr> <td width="180px">
                                <asp:Label ID="lbladmisiontype" runat="server" Text="Student Type"></asp:Label>
                                <span id="manadmissiontype" visible="false" runat="server" style="color: #ff0000">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddladmissiontype" CssClass="cusDropDown" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td width="180px">
                                <asp:Label ID="lblfee" runat="server" Text="Fee Amount"></asp:Label>
                                <span style="color: #ff0000">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfee" CssClass="cusTextBox" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtfee" ID="FilteredTextBoxExtender10"
                                    runat="server" ValidChars="0123456789." Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </td></tr>
                    </table>
                </div>
                <div  style="text-align: right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClientClick="return Validate()"
                                    OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="panelresult" runat="server" Height="300px">
                    <div style="height: 10px">
                    </div>
                    <div style="height: 300px; width: 100%; overflow: auto;">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="loading ">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="GvFeedetails" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                            AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false" PageSize="20"
                            OnRowCommand="GvFeedetails_RowCommand" OnPageIndexChanging="GvFeedetails_PageIndexChanging"
                            HorizontalAlign="Center">
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
                                        Class</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Fee Type</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeetypes" runat="server" Text='<%# Eval("FeeType")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Student Type</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladmissiontype" runat="server" Text='<%# Eval("AdmissionType")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Fee Amount</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblfees" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Added By</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Session</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsession" runat="server" Text='<%# Eval("SessionName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
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
                            <PagerStyle Height="15px" CssClass="paging" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
