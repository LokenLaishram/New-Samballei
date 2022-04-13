<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="LeaveCorrector.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduEmployee.LeaveCorrector" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

        var Page
        function pageLoad() {

            Page = Sys.WebForms.PageRequestManager.getInstance()

            Page.add_initializeRequest(OnInitializeRequest)

        }

        function OnInitializeRequest(sender, args) {

            var postBackElement = args.get_postBackElement()

            if (Page.get_isInAsyncPostBack()) {
                alert('One request is already in progress....')
                args.set_cancel(true)
            }

        }

        function Validates() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txtemployeesID.ClientID%>").value == "") {
                str = str + "\n Please Enter Employee No."
                document.getElementById("<%=txtemployeesID.ClientID %>").focus()
                i++
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }
        function Printempattendancelist() {
            objempnames = document.getElementById("<%= txtemployee.ClientID %>")
            objacademicsessionID = document.getElementById("<%= ddlsessions.ClientID %>")
            objEmpID = document.getElementById("<%= txtemployeesID.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")
            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=EmpAttendanceTotal&EmpName=" + objempnames.value + "&Session=" + objacademicsessionID.value + "&EmpID=" + objEmpID.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value)

        }
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tabemplist" runat="server">
                    <HeaderTemplate>
                        Employee Attendance Corrector</HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%" class="fontstyle">
                            <tr>
                                <td colspan="8">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblemloyeename" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtemployee" CssClass="cusTextBox"></asp:TextBox><asp:FilteredTextBoxExtender
                                        TargetControlID="txtemployee" ID="FilteredTextBoxExtender2" runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                        Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetempNames"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtemployee" UseContextKey="True" DelimiterCharacters=""
                                        Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lblsessions" runat="server" Text="Academic Session"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlsessions" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblemployeesID" runat="server" Text="Employee No"></asp:Label>
                                    <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtemployeesID" Width="50px" CssClass="cusTextBox"></asp:TextBox><asp:FilteredTextBoxExtender
                                        TargetControlID="txtemployeesID" ID="FilteredTextBoxExtender1" runat="server"
                                        ValidChars="1234567890" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="cusTextBox"></asp:TextBox><asp:CalendarExtender
                                        ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtfrom" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                </td>
                                <td>
                                    <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtto" runat="server" CssClass="cusTextBox"></asp:TextBox><asp:CalendarExtender
                                        ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy" TargetControlID="txtto" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div  style="text-align: right">
                                        <asp:Button ID="btnsearchattendance" runat="server" CssClass="button" Text="Search"
                                            OnClick="btnsearchattendance_Click" OnClientClick="return Validates();" /><asp:Button
                                                ID="btncancel" CssClass="button" runat="server" Text="Reset" /><asp:Button ID="btnprint"
                                                    CssClass="button" runat="server" Text="Print" OnClientClick="return Printempattendancelist();" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div style="height: 400px; width: 100%; overflow: auto;">
                                                <asp:GridView ID="Gvattendancedetaillist" CssClass="gridViewHeader" runat="server"
                                                    EmptyDataText="No record found..." AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sl.</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp No.</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label><asp:Label
                                                                    ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp Name</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempname" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Attendance </span></HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="Attendance" Width="30px" Text='<%# Eval("Attendance") %>'></asp:TextBox><asp:FilteredTextBoxExtender
                                                                    TargetControlID="Attendance" ID="FilteredTextBoxExtender2" runat="server" ValidChars="PAL"
                                                                    Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Login Time</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogintime" runat="server" Text='<%# Eval("LoginTime","{0:t}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                LogOut Time </span></HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogoutime" runat="server" Text='<%# Eval("LogoutTime","{0:t}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remarks</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Day</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblday" runat="server" Text='<%# Eval("DaysName") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Date</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#D8EBF5" />
                                                </asp:GridView>
                                            </div>
                                            <div  style="text-align: right">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="button" OnClick="btnupdate_Click" /></ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnupdate" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
