<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="ClassTopper.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.ClassTopper" %>

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
   
    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Class Topper">
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
                                        <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlexam" Width="250px" runat="server" CssClass="cusDropDown">
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
                        <div  style="text-align:right">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click"
                                                    OnClientClick="return Validate();" Width="87px" />
                                                <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Reset" OnClick="btncancel_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnsearch" />
                                                <asp:AsyncPostBackTrigger ControlID="btncancel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="panelresult" runat="server" Height="300px">
                            <div style="height: 290px; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvExamdetails" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" class="grid">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Admission No</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudentID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Name</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Class</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField>
                                            <HeaderTemplate>
                                                Section</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblroll" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Total Mark">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("TotalMark")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Obtained">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalmark" runat="server" Text='<%# Eval("TotalMarkObtain")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpc" runat="server" Text='<%# Eval("PC")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rank">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" CssClass="cusTextBox" Text='<%# Eval("Ranks")%>' Width="30px"
                                                    ID="txtrank"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
