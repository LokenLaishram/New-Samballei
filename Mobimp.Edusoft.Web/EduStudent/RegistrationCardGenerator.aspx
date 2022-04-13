<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="RegistrationCardGenerator.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduStudent.RegistrationCardGenerator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">
        function Validate() {

            var str = ""
            var i = 0
            if (document.getElementById("<%=ddlcategorys.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Student Category."
                document.getElementById("<%=ddlcategorys.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlclasses.ClientID %>").focus()
                i++
            }
          
           


            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }
        function PrintCertificate() {
            objcategory = document.getElementById("<%= ddlcategorys.ClientID %>")
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objrollno = document.getElementById("<%= txtrollno.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicsession.ClientID %>")

            window.open("../EduReports/Reports/ReportViewer.aspx?option=RGDcard&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&CategoryID=" + objcategory.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value)
          
        }
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Registration Card Generator">
                    <ContentTemplate>
                        <asp:Panel ID="panstdlist" runat="server">
                            <table style="width: 100%" class="fontstyle">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblmesagestudentlist" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlacademicsession" runat="server" CssClass="cusDropDown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlacademicsession" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcategory" runat="server" Text="Student Category"></asp:Label>
                                        <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlcategorys" runat="server" AutoPostBack="true" CssClass="cusDropDown"
                                                    OnSelectedIndexChanged="ddlcategorys_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcategorys" />
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
                                                <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" CssClass="cusDropDown"
                                                    OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlclasses" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                   

                                </tr>
                                <tr>   <td>
                                        <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                       
                                    </td>                                  <td>
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
                                        <asp:TextBox ID="txtrollno" Width="80px" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtrollno" ID="FilteredTextBoxExtender5"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td></tr>
                                <tr>
                                    <td colspan="6">
                                        <div  style="text-align:right">
                                            <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClick="btnsearch_Click"
                                                OnClientClick="return Validate();" Text="Search" />
                                                 <asp:Button ID="btnprint" runat="server" CssClass="button" 
                                                OnClientClick="return PrintCertificate();" Text="Print" />
                                            <asp:Button ID="btnreset" runat="server" CssClass="button" OnClick="btnreset_Click"
                                                Text="Reset" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panelresult" runat="server">
                            <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div>
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                    </div>
                                    <div style="height: 400px; width: 100%; overflow: auto;">
                                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="loading ">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:GridView ID="Gvstudenlist" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                            AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Admission No</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Student Name</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
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
                                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Roll No</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblrollno" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Regd.No</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" Width="200px" CssClass="cusTextBox" ID="txtregdNo" Text='<%# Eval("RegdNo")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#D8EBF5" />
                                        </asp:GridView>
                                    </div>
                                    <div  style="text-align: right">
                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="button" OnClick="btnupdate_Click"
                                                    OnClientClick="javascript: return confirm('Do you confirm to save?');" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnupdate" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
