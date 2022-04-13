<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="EmployeeSalaryMaster.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduEmployee.EmployeeSalaryMaster" %>

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

            if (document.getElementById("<%=txtempID.ClientID%>").value == "") {
                str = str + "\n Please enter Employee No."
                document.getElementById("<%=txtempID.ClientID %>").focus()
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
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:TabContainer ID="tabEmployee" runat="server" CssClass="Tab" ActiveTabIndex="0"
                Width="100%">
                <asp:TabPanel ID="tabslarydetails" runat="server" HeaderText="Salary Details">
                    <HeaderTemplate>
                        Employee Salary Details
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
                                    <span id="Span1" runat="server" style="color: #ff0000">*</span> <span style="color: #ff0000">
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
                                    <asp:Label ID="txtempname" CssClass="cuslabel" Width="300px" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbldepartement" runat="server" Text="Department"></asp:Label>
                                    <asp:HiddenField runat="server" ID="hdnEmpID" />
                                </td>
                                <td>
                                    <asp:Label ID="txtdepartment" CssClass="cuslabel" Width="100px" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblsalaryamount" runat="server" Text="Basic"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsalary" CssClass="cusTextBox" runat="server"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtsalary" ID="FilteredTextBoxExtender4"
                                        runat="server" ValidChars="0123456789." Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="lbl" runat="server" Text="Increament"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtincreament" CssClass="cusTextBox" runat="server"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtincreament" ID="FilteredTextBoxExtender2"
                                        runat="server" ValidChars="0123456789." Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </td>
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
                                <td>
                                    <asp:Label ID="lblcategory" runat="server" Text="Employee Category"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlempcategories" runat="server" CssClass="cusDropDown">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div  style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClientClick="return Validate()"
                                            OnClick="btnsave_Click" />
                                        <asp:Button ID="btnsearchs" runat="server" CssClass="button" Text="Search" OnClick="btnsearchs_Click" />
                                        <asp:Button ID="btnreset" CssClass="button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div style="height: 300px; width: 100%; overflow: auto;">
                                        <asp:GridView ID="GvEmployeeSalary" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                            AutoGenerateColumns="False" Width="100%" OnRowCommand="GvEmployeeSalary_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Salary ID</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsalaryID" runat="server" Text='<%# Eval("SalaryID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        EmpNo.</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
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
                                                        Basic
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempsalary" runat="server" Text='<%# Eval("SalaryAmount", "{0:0#.##}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Increament
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblincreament" runat="server" Text='<%# Eval("Increament", "{0:0#.##}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Added Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remarks
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" CssClass="cusTextBox" Width="150px" ID="txtRemarks" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Edit</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Edits" ForeColor="Blue"> <img src="../EduImages/edit.png" height="15px" alt="" title="Edit" /></asp:LinkButton></ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#D8EBF5" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="tabsummary" runat="server" HeaderText="Employee Salary Summary">
                    <ContentTemplate>
                        <asp:Panel ID="panstdlist2" runat="server">
                            <table style="width: 100%" class="fontstyle">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblsession" runat="server" Text="Financial Year"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dllacademicsession" runat="server" CssClass="cusDropDown">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblempno" runat="server" Text="Employee No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtempnos" AutoPostBack="True" CssClass="cusTextBox"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender TargetControlID="txtempnos" ID="FilteredTextBoxExtender1"
                                            runat="server" ValidChars="0123456789" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetEmpNo"
                                            MinimumPrefixLength="2" CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                            CompletionListHighlightedItemCssClass="itemHighlighted" CompletionInterval="10"
                                            CompletionSetCount="1" TargetControlID="txtempnos" UseContextKey="True" DelimiterCharacters=""
                                            Enabled="True" ServicePath="">
                                        </asp:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblempnames" runat="server" Text="Employee Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtempnames" AutoPostBack="True" CssClass="cusTextBox"></asp:TextBox>
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
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div  style="text-align:right">
                                            <asp:Button ID="Btnsearch" runat="server" CssClass="button" Text="Search" OnClick="Btnsearch_Click" />
                                            <asp:Button ID="BtnCancel" CssClass="button" runat="server" Text="Reset" OnClick="BtnCancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="panel2" runat="server" Height="300px">
                            <div style="height: 290px; width: 100%; overflow: auto;">
                                <asp:GridView ID="GVSummary" CssClass="gridViewHeader" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" OnRowDataBound="GVSummary_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Salary ID</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblleaveID" runat="server" Text='<%# Eval("SalaryID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                EmpNo.</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
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
                                                Basic
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblempsalary" runat="server" Text='<%# Eval("SalaryAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Increament
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblincreament" runat="server" Text='<%# Eval("Increament", "{0:0#.##}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Added Date
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Closing Date
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblclosingdate" runat="server" Text='<%# Eval("LastRevisedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
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
