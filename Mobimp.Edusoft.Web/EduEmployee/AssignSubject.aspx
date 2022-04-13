<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="AssignSubject.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduEmployee.AssignSubject" %>

<%@ Register TagPrefix="asp" TagName="CustomPager" Src="~/UserControls/CustomPager.ascx" %>
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

            if (document.getElementById("<%=ddlcatgeory.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Category.";
                document.getElementById("<%=ddlcatgeory.ClientID %>").focus();
                i++;

            } 
            if (document.getElementById("<%=ddlclassses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclassses.ClientID %>").focus();
                i++;

            }

            if (document.getElementById("<%=ddlsection.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section.";
                document.getElementById("<%=ddlsection.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=ddlsubject.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subject.";
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=ddlteacher.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select teacher.";
                document.getElementById("<%=ddlteacher.ClientID %>").focus();
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
                <div style="text-align:center">
                    Assign Subject</div>
                <div id="divmessage" runat="server">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></div>
                <div>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" CssClass="cusDropDown" ID="ddlcatgeory">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblclassses" runat="server" Text="Class"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="cusDropDown" ID="ddlclassses"
                                    OnSelectedIndexChanged="ddlclassses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblsection" runat="server" Text="Section"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" CssClass="cusDropDown" ID="ddlsection">
                                </asp:DropDownList>
                            </td>
                           
                        </tr>
                        <tr> <td>
                                <asp:Label ID="lblsubject" runat="server" Text="Subject"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" CssClass="cusDropDown" ID="ddlsubject">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblteacher" runat="server" Text="Teacher"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server"  CssClass="cusDropDown" ID="ddlteacher">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="Radchecklist" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div  style="text-align:right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click"
                                    OnClientClick="return Validate()" />
                                <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClick="btnsearch_Click"
                                    Text="Search" />
                                <asp:Button ID="btncancel" runat="server" CssClass="button" OnClick="btncancel_Click"
                                    Text="Reset" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="panelresult" runat="server" Height="300px" GroupingText="Result">
                    <div class="grid" style="float: left; width: 100%">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="loading ">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:GridView ID="GvAssign" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                            OnPageIndexChanging="GvAssign_PageIndexChanging" AutoGenerateColumns="False"
                            Width="100%" class="grid" AllowPaging="false" PageSize="10" HorizontalAlign="Center"
                            OnRowCommand="GvAssign_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        ID</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("AssignID")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Class</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Section</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Subject</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Teacher</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblteacher" runat="server" Text='<%# Eval("EmpName")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        AddedBy</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Added Date Time</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate")%>'></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Edit</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("AssignID")%>'
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
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("AssignID")%>'
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
                            <asp:CustomPager ID="AssSubjectPager" runat="server" />
                        </left>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
