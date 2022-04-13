<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EployeeLeaveApproval.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduEmployee.EployeeLeaveApproval" %>

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

            if (document.getElementById("<%=txtdatefrom.ClientID%>").value == "") {
                str = str + "\n Please select Datefrom."
                document.getElementById("<%=txtdatefrom.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtdateto.ClientID%>").value == "") {
                str = str + "\n Please select Dateto."
                document.getElementById("<%=txtdateto.ClientID %>").focus()
                i++
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str)
                return false
            }
            else
                return true
        }

        function PrintempLeave() {
            objEmpID = document.getElementById("<%= txtempID.ClientID %>")
            objDatefrom = document.getElementById("<%= txtdatefrom.ClientID %>")
            objDateto = document.getElementById("<%= txtdateto.ClientID %>")
            window.open("../EduEmployee/Reports/ReportViewer.aspx?option=EmployeeLeave&EmpNo=" + objEmpID.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value)

        }
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Employee Leave Approval">
                    <ContentTemplate>
                        <asp:Panel ID="panstdlist" runat="server">
                            <table style="width: 100%" class="fontstyle">
                                <tr>
                                    <td colspan="6">
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblemployeeID" runat="server" Text="Employee No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtempID" AutoPostBack="True" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtempID" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                          <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" ServiceMethod="GetEmpNo"
                                            MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                            CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                            CompletionSetCount="1" TargetControlID="txtempID" UseContextKey="True" DelimiterCharacters=""
                                            Enabled="True" ServicePath="">
                                        </asp:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldatefrom" runat="server" Text="Date from"></asp:Label>
                                        <span id="Span2" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdatefrom" runat="server" CssClass="cusTextBox" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtdatefrom" />
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldateto" runat="server" Text="Date to"></asp:Label>
                                        <span id="Span3" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdateto" runat="server" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtdateto" />
                                        <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateto" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div  style="text-align:right">
                                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Validate();"
                                                        OnClick="btnsearch_Click" />
                                                    <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                                    <asp:Button ID="btnprint" CssClass="button" runat="server" Text="Print" OnClientClick="return PrintempLeave();" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnsearch" />
                                                    <asp:PostBackTrigger ControlID="btnreset" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panelresult" runat="server" Height="300px">
                            <div style="height: 290px; width: 100%; overflow: auto;">
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="loading ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/EduImages/loadingx.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." CssClass="loadingText" />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvemployeeLeave" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="1300px" OnRowCommand="GvemployeeLeave_RowCommand"
                                    OnRowDataBound="GvemployeeLeave_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                LeaveID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveID" runat="server" Text='<%# Eval("LeaveID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Emp.</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                <asp:Label ID="lblIDs" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("LeaveID")%>'></asp:Label>
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
                                                Date From
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtdatefrom" Width="90px" Enabled="false" runat="server" Text='<%# Eval("DateFrom") %>'
                                                    CssClass="cusTextBox"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                    TargetControlID="txtdatefrom" />
                                                <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Date To
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtdateto" Width="90px" runat="server" Text='<%# Eval("DateTo") %>'
                                                    CssClass="cusTextBox"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                    TargetControlID="txtdateto" />
                                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateto" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Requestdays
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblnoofdays" runat="server" Text='<%# Eval("NosDays") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                ApprovedDays<span id="Span2" runat="server" style="color: #ff0000">*</span> <span
                                                    style="color: #ff0000">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtdays" Width="30px" runat="server" Text='<%# Eval("ApprovedDays") %>'
                                                    CssClass="cusTextBox"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender TargetControlID="txtdays" ID="FilteredTextBoxExtender1"
                                                    runat="server" ValidChars="0123456789" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                RequestDate
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblrequestdate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Status<span id="Span2" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblststus" Visible="false" runat="server" Text='<%# Eval("LeaveStatus") %>'></asp:Label>
                                                <asp:DropDownList ID="ddlstatus" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged"
                                                    AutoPostBack="true" CssClass="cusDropDown" Width="100px" runat="server">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                                    <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Remarks
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                RejectionRemarks
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRremarks" Width="100px" Text='<%# Eval("RejRemarks") %>' runat="server"
                                                    CssClass="cusTextBox"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                View</HeaderTemplate>
                                            <ItemTemplate>
                                                <a href="#" title='<%# Eval("LeaveDocumentpath") %>' style="color: Purple" onclick="window.open('../<%#Eval("LeaveDocumentpath")%>','','width=990,height=750; top=50, left=100')">
                                                    View</a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Save</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btnapprove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="save" Text="Save" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                A/RDate
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblaproveddate" runat="server" Text='<%# Eval("ApprovedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#D8EBF5" />
                                </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
