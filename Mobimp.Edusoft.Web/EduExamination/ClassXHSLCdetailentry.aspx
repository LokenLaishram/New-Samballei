<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="ClassXHSLCdetailentry.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.ClassXHSLCdetailentry" %>

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
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }
        function PrintReport() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objroll = document.getElementById("<%= txtrollNo.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            if (objclass.value == "1") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=ClassNursery&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&Session=" + objsession.value + "&RollNo=" + objroll.value);
            }
        }
    </script>
    <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tabemplist" runat="server" HeaderText="Class X HSLC detail Entry">
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
                                        <asp:Label ID="lblStudentcategory" runat="server" Text="Category"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlcategory" runat="server" AutoPostBack="true" CssClass="cusDropDown"
                                                    OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
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
                                        <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlsections" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlsections" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblrollNo" runat="server" Text="Roll No"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrollNo" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div  style="text-align: right">
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
                        <asp:Panel ID="panelresult" runat="server" Height="440px">
                            <div style="height: 420px; overflow: auto;">
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
                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Regd. No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblregistrationno" runat="server" Text='<%# Eval("")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Roll No">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txthslcrollno" CssClass="cusTextBox" Width="100px"
                                                    Text='<%# Eval("")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Secure Mark">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtsecuremark" CssClass="cusTextBox" Width="100px"
                                                    Text='<%# Eval("")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Division">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtdivision" CssClass="cusTextBox" Width="100px"
                                                    Text='<%# Eval("")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PC">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtpc" CssClass="cusTextBox" Width="50px" Text='<%# Eval("")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                            </div>
                            <div  style="text-align: right">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" Enabled="false" OnClientClick="javascript: return confirm('Are you sure to update?');"
                                            OnClick="btnupdate_Click" CssClass="button" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnupdate" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
