<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="LoanRepayment.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.LoanRepayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../HR/LoanRepayment.aspx">Loan Repayment</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabLoanRepayment"><i class="icon nalika-edit" aria-hidden="true"></i>Loan Repayment</a></li>
                <li><a href="#tabLoanRepaymentList"><i class="icon nalika-picture" aria-hidden="true"></i>Loan Repayment List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabLoanRepayment">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_PaymentNo" Text="Loan Payment Number"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_PaymentNo" runat="server" AutoPostBack="true" OnTextChanged="txt_PaymentNo_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetPaymentNo" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txt_PaymentNo" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" CompletionListCssClass="accordion" ServicePath="">
                                            </asp:AutoCompleteExtender>                                        
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Employee" Text="Employee Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_EmployeeName" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lbl_EmpID" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_LoanAmt" Text="Loan Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_LoanAmount" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_LoanBalance" Text="Loan Balance"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_LoanBalance" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_RepaymentAmt" Text="Pay"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_RepaymentAmt" runat="server" MaxLength="10" onkeyup="return CalculateRepayment();" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txt_RepaymentAmt" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars="0123456789." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DueAmt" Text="Due Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_DueAmt" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblRepaymentNo" Text="Repayment Number"></asp:Label>
                                            <asp:TextBox ID="txt_RepaymentNo" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-sm btn-green button" OnClientClick="return Validate();" OnClick="btnSave_Click" Text="Pay" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <%------------------------------End Tab 1------------------------------%>
                <%------------------------------Start Tab 2------------------------------%>

                <div class="product-tab-list tab-pane fade" id="tabLoanRepaymentList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_EmpName" runat="server" Text="Employee Name"></asp:Label>
                                            <asp:TextBox ID="txttab2_EmpName" runat="server" AutoPostBack="true"
                                                class="form-control"></asp:TextBox>
                                            <asp:Label ID="lbltab2_EmpID" runat="server" Visible="false"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetEmployeeNameTab2" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txttab2_EmpName" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" CompletionListCssClass="accordion" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_LoanType" runat="server" Text="Loan Type"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_LoanType" class="form-control " runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_LoanStatus" runat="server" Text="Loan Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_LoanStatus" runat="server" class="form-control ">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="2">Completed</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_Status" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_IsActive" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btntab2_Search" OnClick="btntab2_Search_Click" runat="server" class="btn btn-sm btn-info button " Text="Search" />
                                            <asp:Button ID="btntab2_Cancel" class="btn btn-sm btn-danger button" OnClick="btntab2_Cancel_Click" runat="server" Text="Cancel" />
                                            <asp:Button ID="btntab2_Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> all</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="LoanRecordList" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gvtab2_RepaymentList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%" OnRowCommand="Gvtab2_RepaymentList_RowCommand" OnPageIndexChanging="Gvtab2_RepaymentList_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl.No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Payment No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanPaymentNo" Height="20px" runat="server" Text='<%# Eval("LoanPaymentNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Return No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanReturnNo" Height="20px" runat="server" Text='<%# Eval("LoanReturnNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Employee Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_EmployeeName" Height="20px" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Loan Type
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanType" Height="20px" runat="server" Text='<%# Eval("LoanType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Loan Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanAmount" Height="20px" runat="server" Text='<%# Eval("LoanAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Return Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_ReturnAmount" Height="20px" runat="server" Text='<%# Eval("ReturnAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Balance Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_BalanceAmount" Height="20px" runat="server" Text='<%# Eval("BalanceAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremarks" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_Print" class="cus-btn btn-sm btn-indigo button" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Print" ValidationGroup="none" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-- ----------------------------End Tab 2------------------------------%>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=txt_PaymentNo.ClientID%>").value == "") {
                str = str + "\n Please Enter Loan Payment Number.";
                document.getElementById("<%=txt_PaymentNo.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_EmployeeName.ClientID%>").value == "") {
                str = str + "\n Employee Name shouldn't be blank.";
                document.getElementById("<%=txt_EmployeeName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_LoanAmount.ClientID%>").value == "") {
                str = str + "\n Loan Amount shouldn't be blank.";
                document.getElementById("<%=txt_LoanAmount.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_LoanBalance.ClientID%>").value == "") {
                str = str + "\n Loan Balance shouldn't be blank.";
                document.getElementById("<%=txt_LoanBalance.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_RepaymentAmt.ClientID%>").value == "") {
                str = str + "\n Please Enter Payment Amount.";
                document.getElementById("<%=txt_LoanBalance.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_DueAmt.ClientID%>").value == "") {
                str = str + "\n Due Amount shouldn't be blank.";
                document.getElementById("<%=txt_DueAmt.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false;
            }
            else {
                return true;
            }
        }
        function successalert(str) {
            swal({
                title: "",
                text: str,
                icon: "success",
            });
        }
        function failalert(str) {
            swal({
                title: "",
                text: str,
                icon: "warning",
            });
        }

        function CalculateRepayment() {

            var LoanAmount = document.getElementById("<%=txt_LoanAmount.ClientID%>").value;
            var BalanceAmount = document.getElementById("<%=txt_LoanBalance.ClientID%>").value;
            var RepaymentAmount = document.getElementById("<%=txt_RepaymentAmt.ClientID%>").value;

            document.getElementById("<%=txt_DueAmt.ClientID%>").value = (+BalanceAmount - +RepaymentAmount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            var DueAmount = (+BalanceAmount - +RepaymentAmount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            if (+RepaymentAmount > (+BalanceAmount)) {
                document.getElementById("<%=txt_RepaymentAmt.ClientID%>").value = Math.round((+BalanceAmount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0]);
                document.getElementById("<%=txt_DueAmt.ClientID%>").value = "";
            }
        }

        function functionConfirm(event) {
            var row = event.parentNode.parentNode;
            var paramID = row.rowIndex - 1;
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this imaginary file!",

                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=Gvtab2_RepaymentList.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }
    </script>

</asp:Content>
