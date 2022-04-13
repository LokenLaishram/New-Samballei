<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EmployeeLeaveRequest.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduEmployee.EmployeeLeaveRequest" %>

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


        function Validates() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txtempID.ClientID%>").value == "") {
                str = str + "\n Please enter EmployeeID."
                document.getElementById("<%=txtempID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtdays.ClientID%>").value == "") {
                str = str + "\n Please enter no of days."
                document.getElementById("<%=txtdays.ClientID %>").focus()
                i++
            }

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
    </script>
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TabContainer ID="tbcontaineremployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tapdemolyeelist" runat="server" HeaderText="Employee Leave Requisition">
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
                                        <span id="Span1" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtempID" AutoPostBack="True" CssClass="cusTextBox"
                                            OnTextChanged="txtempID_TextChanged"></asp:TextBox>
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
                                        <asp:Label ID="lblemployeename" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td style="width:300px">
                                        <asp:Label ID="txtempname" CssClass="cuslabel" Width="300px" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbldepartement" runat="server" Text="Department"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="txtdepartment" CssClass="cuslabel" Width="100px" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldatefrom" runat="server" Text="Date from"></asp:Label>
                                        <span id="Span2" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdatefrom" runat="server" CssClass="cusTextBox"></asp:TextBox>
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
                                    <td>
                                        <asp:Label ID="lbldays" runat="server" Text="No.Of Days"></asp:Label>
                                        <span id="Span4" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdays" Width="50px" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtdays" ID="FilteredTextBoxExtender2"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblremarks" runat="server" Text="Remarks"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox runat="server" ID="txtremarks" Rows="3" Width="300px" TextMode="MultiLine"
                                            CssClass="cusTextBox"></asp:TextBox>
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblphoto" runat="server" Text="Upload Application"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:FileUpload Width="50px" ID="FileUploader" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlstatus" Width="110px" runat="server" CssClass="cusDropDown">
                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                            <asp:ListItem Value="0">InActive </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div  style="text-align:right">
                                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClientClick="return Validates();"
                                                        OnClick="btnsave_Click" />
                                                    <asp:Button ID="btnsearch" runat="server" CssClass="button" Text="Search" OnClientClick="return Validate();"
                                                        OnClick="btnsearch_Click" />
                                                    <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnsave" />
                                                    <asp:PostBackTrigger ControlID="btnsearch" />
                                                    <asp:PostBackTrigger ControlID="btnreset" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panelresult" runat="server" Height="250px">
                            <div style="height: 250px; width: 100%; overflow: auto;">
                                <asp:GridView ID="GvemployeeLeave" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" OnRowCommand="GvemployeeLeave_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                LeaveID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblleaveID" runat="server" Text='<%# Eval("LeaveID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                EmpNo.</HeaderTemplate>
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
                                                <asp:Label ID="lbldatefrom" runat="server" Text='<%# Eval("DateFrom","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Date To
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldateto" runat="server" Text='<%# Eval("DateTo","{0:dd-MM-yyyy}") %>'></asp:Label>
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
                                                ApprovedDays
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblapprovedays" runat="server" Text='<%# Eval("ApprovedDays") %>'></asp:Label>
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
                                                Status
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Lstatus") %>'></asp:Label>
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
                                                Edit</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Edits" ForeColor="Blue"> <img src="../EduImages/edit.png" height="15px" alt="" title="Edit" /></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
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
                                                Delete</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="javascript: return confirm('Are you sure to delete ?');"> <img src="../EduImages/delete.png" height="16px" alt="" title="Delete"  border="0" /></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                A/R Date
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
