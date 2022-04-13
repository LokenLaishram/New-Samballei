<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EmployeesAttendance.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduEmployee.EmployeesAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">

//        var Page
//        function pageLoad() {

//            Page = Sys.WebForms.PageRequestManager.getInstance()

//            Page.add_initializeRequest(OnInitializeRequest)

//        }

//        function OnInitializeRequest(sender, args) {

//            var postBackElement = args.get_postBackElement()

//            if (Page.get_isInAsyncPostBack()) {
//                alert('One request is already in progress....')
//                args.set_cancel(true)
//            }

//        }
        function Printempattendancelist() {
            objempnames = document.getElementById("<%= txtempnames.ClientID %>")
            objacademicsessionID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objEmpID = document.getElementById("<%= txtemployeedID.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")


            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=EmpAttendance&EmpName=" + objempnames.value + "&Session=" + objacademicsessionID.value + "&EmpNo=" + objEmpID.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value)

        }
          
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Employee Details">
                    <HeaderTemplate>
                        Employee Attendance
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%" class="fontstyle">
                            <tr>
                                <td>
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblempnames" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtempnames" CssClass="cusTextBox"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtempnames" ID="FilteredTextBoxExtender7"
                                        runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                        Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetempNames"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtempnames" UseContextKey="True" DelimiterCharacters=""
                                        Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlacademicseesions" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblempID" runat="server" Text="Employee No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtemployeedID" AutoPostBack="true"  CssClass="cusTextBox"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtemployeedID" ID="txtentenderEID"
                                        runat="server" ValidChars="1234567890" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServiceMethod="GetEmpNo"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtemployeedID" UseContextKey="True"
                                        DelimiterCharacters="" Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Attendnce For :
                                </td>
                                <td>
                                    <asp:Label runat="server" CssClass="cuslabel" ID="txtday"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div >
                                        <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClick="btnsearch_Click" /><asp:Button
                                            ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:UpdatePanel ID="upMain" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:Label ID="lblattendanelist" runat="server"></asp:Label>
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
                                                <asp:GridView ID="Gvemployeeattendance" CssClass="gridViewHeader" runat="server"
                                                    EmptyDataText="No record found..." AutoGenerateColumns="False" Width="100%" OnRowCommand="Gvemployeeattendance_RowCommand"
                                                    OnRowDataBound="Gvemployeeattendance_RowDataBound">
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
                                                                <asp:Label ID="lblattendance" Visible="false" runat="server" Text='<%# Eval("Attendance") %>'></asp:Label>
                                                                <asp:Label ID="lbllogin" Visible="false" runat="server" Text='<%# Eval("IsLogin")%>'>
                                                                </asp:Label>
                                                                <asp:Label ID="lbllogout" Visible="false" runat="server" Text='<%# Eval("IsLogout")%>'>
                                                                </asp:Label>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp Name</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempname" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                User Password </span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <span style="color: #ff0000">*</span><span style="color: #ff0000"><asp:TextBox runat="server"
                                                                    ID="txtpassword" CssClass="cusTextBox" TextMode="Password"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Login</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnlogin" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Login" Text="Login" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remarks </span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" Width="200px" ID="txtremarks" CssClass="cusTextBox"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Logout</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnlogout" Enabled="false" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Logout" Text="LogOut" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#D8EBF5" />
                                                </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        Total Present :
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotpresent" ForeColor="#ff3300" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Total Absent :
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotabsent" ForeColor="#ff3300" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Total On Leave :
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotleave" ForeColor="#ff3300" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="tabemplist" runat="server" HeaderText="Employee List">
                    <HeaderTemplate>
                        Employee Attendance Detail List
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table style="width: 100%" class="fontstyle">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblemloyeename" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtemployee" CssClass="cusTextBox"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtemployee" ID="FilteredTextBoxExtender2"
                                        runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
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
                                    <asp:Label ID="lblsessions" runat="server" Text="Academic Year"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlsessions" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblemployeesID" runat="server" Text="Employee No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtemployeesID"  CssClass="cusTextBox"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtemployeesID" ID="FilteredTextBoxExtender1"
                                        runat="server" ValidChars="1234567890" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                     <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" ServiceMethod="GetEmpNo"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtemployeesID" UseContextKey="True"
                                        DelimiterCharacters="" Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtfrom" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                </td>
                                <td>
                                    <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtto" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtto" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div >
                                        <asp:Button ID="btnsearchattendance" runat="server" CssClass="button" Text="Search"
                                            OnClick="btnsearchattendance_Click" />
                                        <asp:Button ID="btncancel" CssClass="button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                        <asp:Button ID="btnprint" CssClass="button" runat="server" Text="Print" OnClientClick="return Printempattendancelist();" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:Label ID="lblresult" runat="server"></asp:Label>
                                            </div>
                                            <div style="height: 400px; width: 100%; overflow: auto;">
                                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                                    <ProgressTemplate>
                                                        <div id="DIVloading" runat="server" class="loading ">
                                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <asp:GridView ID="Gvattendancedetaillist" CssClass="gridViewHeader" runat="server"
                                                    EmptyDataText="No record found..." AutoGenerateColumns="False" Width="100%" OnRowDataBound="Gvattendancedetaillist_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sl.</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Emp No.</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                            </ItemTemplate>
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
                                                                Attendance </span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblattendance" runat="server" Text='<%# Eval("Attendance") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Login Time</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogintime" runat="server" Text='<%# Eval("LoginTime","{0:t}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Logout Time </span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogoutime" runat="server" Text='<%# Eval("LogoutTime","{0:t}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remarks</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Day</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblday" runat="server" Text='<%# Eval("DaysName") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Date</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#D8EBF5" />
                                                </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        Total Present :
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotresentlist" ForeColor="#ff3300" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Total Absent :
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotabsentlist" ForeColor="#ff3300" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        Total On Leave :
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotonleavlist" ForeColor="#ff3300" runat="server"></asp:Label>
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
