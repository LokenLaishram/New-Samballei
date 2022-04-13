<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EmployeeSalaryGenerator.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduEmployee.EmployeeSalaryGenerator" %>

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
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlmonth.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Month."
                document.getElementById("<%=ddlmonth.ClientID %>").focus()
                i++
            }


            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }
        function PrintPaySlip(SalaryID, Session, MonthID, SalaryStatus, Status) {

            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=PaySlip&SalaryID=" + SalaryID + "&SessionID=" + Session + "&MonthID=" + MonthID + "&SalaryStatus=" + SalaryStatus + "&Status=" + Status)

        }
        function PrintSalaryStatement() {
            ObjEmpNo = document.getElementById("<%= txtempID.ClientID %>")
            Objmonth = document.getElementById("<%= ddlmonth.ClientID %>")
            ObjefinancialYear = document.getElementById("<%= ddlfinancialyear.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
            Objisactive = document.getElementById("<%= ddlisdeleted.ClientID %>")
            Objcategory = document.getElementById("<%= ddlcategory.ClientID %>")
            if (Objmonth.value == "0") {
                alert("Please select Month.");
                return false;
            }
            if (Objcategory.value == "0") {
                alert("Please select Employee Category.");
                return false;
            }
            else {
                window.open("../EduEmployee/Reports/ReportViewer.aspx?option=SalaryStatement&EmployeeNo=" + ObjEmpNo.value + "&SessionID=" + ObjefinancialYear.value + "&MonthID=" + Objmonth.value + "&SalaryStatus=" + objstatus.value + "&Status=" + Objisactive.value + "&Category=" + Objcategory.value)
                return true;
            }
        }



    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tabEmployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tabslarydetails" runat="server" HeaderText="Salary Details">
                    <HeaderTemplate>
                        Employee Salary Generator
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
                                    <asp:Label ID="lblemployeeID" runat="server" Text="Employee No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtempID" AutoPostBack="True" CssClass="cusTextBox"
                                        OnTextChanged="txtempID_TextChanged"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtempID" ID="FilteredTextBoxExtender3"
                                        runat="server" ValidChars="0123456789" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetEmpNo"
                                        MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                        CompletionSetCount="1" TargetControlID="txtempID" UseContextKey="True" DelimiterCharacters=""
                                        Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lblemployeename" runat="server" Text="Employee Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="txtempname" Width="200px" CssClass="cuslabel"  runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbldepartement" runat="server" Text="Department"></asp:Label>
                                    <asp:HiddenField runat="server" ID="hdnEmpID" />
                                </td>
                                <td>
                                    <asp:Label ID="txtdepartment" Width="200px" CssClass="cuslabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfinancail" runat="server" Text="Financial Year"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlfinancialyear"  runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblmonth" runat="server" Text="Month"></asp:Label>
                                    <span id="Span1" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblstatuss" runat="server" Text="Salary Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cusDropDown">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="2">Paid</asp:ListItem>
                                        <asp:ListItem Value="1">Unpaid </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblcategories" runat="server" Text="Employee Category"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlisdeleted" runat="server" CssClass="cusDropDown">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Inactive </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                        <ContentTemplate>
                                            <div  style="text-align:right">
                                                <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Validate();"
                                                    OnClick="btnsearch_Click" />
                                                <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                                <asp:Button ID="btnprint" CssClass="button" runat="server" Text="Print" OnClientClick="return PrintSalaryStatement();" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnsearch" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div style="height: 300px; width: 100%; overflow: auto;">
                                        <asp:GridView ID="GVsalarygenerator" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                            AutoGenerateColumns="False" Width="100%" OnRowDataBound="GVsalarygenerator_RowDataBound"
                                            OnRowCommand="GVsalarygenerator_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        EmpNo.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("SalaryGeneratorID")%>'></asp:Label><asp:Label
                                                            ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Emp Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        L
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblleave" runat="server" Text='<%# Eval("TotalOnleave") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        A
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblabsent" runat="server" Text='<%# Eval("TotalAbsent") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Basic
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbasic" runat="server" Text='<%# Eval("Basic", "{0:0#.##}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Increament
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblincreament" runat="server" Text='<%# Eval("Increament", "{0:0#.##}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Bonus
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbonus" CssClass="GridTextBox" OnTextChanged="txtbonus_TextChanged"
                                                            AutoPostBack="true" runat="server" Text='<%# Eval("Bonus", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtbonus" ID="txtentenderEID1" runat="server"
                                                            ValidChars="1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Incentive
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtincentive" CssClass="GridTextBox" OnTextChanged="txtincentive_TextChanged"
                                                            AutoPostBack="true" runat="server" Text='<%# Eval("Incentives", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtincentive" ID="txtentenderEID2"
                                                            runat="server" ValidChars="1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Allowance
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtallowance" CssClass="GridTextBox" OnTextChanged="txtallowance_TextChanged"
                                                            AutoPostBack="true" runat="server" Text='<%# Eval("Allowance", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtallowance" ID="txtentenderEID3"
                                                            runat="server" ValidChars="1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Surplus
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtsurplus" CssClass="GridTextBox" OnTextChanged="txtsurplus_TextChanged"
                                                            AutoPostBack="true" runat="server" Text='<%# Eval("Surplus", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtsurplus" ID="txtentenderEID4" runat="server"
                                                            ValidChars="1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Proxy
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtproxy" runat="server" OnTextChanged="txtproxy_TextChanged" AutoPostBack="true"
                                                            CssClass="GridTextBox" Text='<%# Eval("Proxy", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtproxy" ID="txtentenderEID5" runat="server"
                                                            ValidChars="+-1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subduction
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtsubduction" OnTextChanged="txtsubduction_TextChanged" AutoPostBack="true"
                                                            CssClass="GridTextBox" runat="server" Text='<%# Eval("subduction", "{0:0#.##}") %>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txtsubduction" ID="txtentenderEID6"
                                                            runat="server" ValidChars="1234567890" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Gross Salary
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txttotalsalary" Width="60px" CssClass="GridTextBox" Enabled="false"
                                                            runat="server" Text='<%# Eval("SalaryAmount", "{0:0#.##}") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblactive" Visible="false" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                        <asp:Label ID="lblsession" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID") %>'></asp:Label>
                                                        <asp:Label ID="lblmonth" Visible="false" runat="server" Text='<%# Eval("MonthID") %>'></asp:Label>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                        <asp:Label ID="lblsalstatus" Visible="false" runat="server" Text='<%# Eval("SalaryStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Update
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnupdate" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Updates" ValidationGroup="none" Text="Update" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <img src="../EduImages/delete.png" height="20px" alt="" title="Delete"  border="0" /></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <a href="javascript: void(null);" style="color: red" onclick="PrintPaySlip('<%# Eval("SalaryGeneratorID")%>','<%# Eval("AcademicSessionID")%>','<%# Eval("MonthID")%>', '<%# Eval("SalaryStatus")%>', '<%# Eval("IsActive")%>'); return false;">
                                                            Print</a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#D8EBF5" />
                                        </asp:GridView>
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblcasule"></asp:Label>
                                                    :<asp:Label runat="server" ForeColor="Green" ID="lbltotalpaid" Text=" 0"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
