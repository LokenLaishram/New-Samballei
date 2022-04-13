<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="AccountStatement.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduAccount.AccountStatement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Account&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Account/AccountStatement.aspx">Account Statement</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="review-tab-pro-inner">
                    <ul id="myTab3" class="tab-review-design">
                        <li class="active"><a href="#TabTransactionList"><i class="icon nalika-picture" aria-hidden="true"></i>Account Statement</a></li>
                    </ul>
                    <div id="myTabContent" class="tab-content custom-product-edit">
                        <%-------------------First Second Tab-----------------------%>
                        <div class="product-tab-list tab-pane fade active in" id="TabTransactionList">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="card_wrapper">
                                        <div class="row mt10">

                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label2" Text="Transaction Type"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlTransactionTypeID" runat="server" class="form-control custextbox ">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-4 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label5" Text="Account Head"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlAccountHeadID" runat="server" class="form-control custextbox">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label11" runat="server"></asp:Label>
                                                    <asp:Label runat="server" ID="Label12" Text="Voucher No"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtTransactionNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label7" runat="server" Text="Date From"></asp:Label>
                                                    <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="txtFromDate" />
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFromDate" />
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                                                    <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtToDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                        TargetControlID="txtToDate" />
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtToDate" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row mt10">
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label3" Text="Payment Mode"></asp:Label>
                                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlPaymentModeID" runat="server" class="form-control custextbox">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label10" Text="Account Status"></asp:Label>
                                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlAccountStatus" runat="server" class="form-control custextbox">
                                                        <asp:ListItem Value="0">All</asp:ListItem>
                                                        <asp:ListItem Value="1">Open </asp:ListItem>
                                                        <asp:ListItem Value="2">Close </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label6" Text="Status"></asp:Label>
                                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                        <asp:ListItem Value="0">InActive </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-3 customRow">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="lblcollectedby" Text="Collected By"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:DropDownList ID="ddlCollectedByID" runat="server" class="form-control custextbox">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-3 customRow">
                                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClick="btnSearch_Click" />
                                                    <asp:Button ID="btn_print" runat="server" class="btn btn-sm btn-indigo button" Text="Print" />
                                                    <asp:Button ID="btnreset" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="Clear_OnClick" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row pad15">
                                            <div class="col-md-4 customRow" style="margin-top: 13px; color: green; font-weight: bold;">
                                                INCOME ||
                                        <asp:Label ID="lblIncResult" runat="server" Text="INCOME"></asp:Label>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div>
                                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                                    <ProgressTemplate>
                                                        <div id="DIV_loading" runat="server" class="Pageloader">
                                                            <asp:Image ID="img_UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </div>

                                            <div id="gvStatement" class="col-md-12 customRow ">
                                                <asp:GridView ID="Gv_AccountStatement" EmptyDataText="No record found..." CssClass="table-bordered table-striped gridviewcss"
                                                    runat="server" AutoGenerateColumns="false" Style="width: 100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                SlNo.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Voucher No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVoucherNo" runat="server" Text='<%# Eval("VoucherNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Trasaction Type
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTranType" runat="server" Text='<%# Eval("TransactionTypeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Transaction Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltrandate" runat="server" Text='<%# Eval("TransactionDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Payment Mode
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaymentModeName" runat="server" Text='<%# Eval("PaymentModeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Total Amount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("TrasactionAmount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Status
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("AccountStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Added By
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbladdedby" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remark
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncomeRemarks" runat="server" Text='<%# Eval("OverallNaration")%>'></asp:Label>
                                                                <asp:TextBox ID="txtremarks" Visible="false" Width="100px" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>

                                            </div>
                                            <div class="col-md-7 customRow "></div>
                                            <div class="col-md-2 customRow ">
                                                <div class="form-group">
                                                    <asp:Label ID="lblinctotal" runat="server" Style="color: green; font-size: 14px; font-weight: bold;" Text="Total :"></asp:Label>
                                                    <asp:Label ID="lblinctotalamt" runat="server" Style="color: black; font-size: 14px; font-weight: bold;" Text="0.00"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row pad15">
                                            <div class="col-md-4 customRow" style="margin-top: 13px; margin-bottom: 13px; color: red; font-weight: bold;">
                                                EXPENDITURE ||
                                                <asp:Label ID="lblexpResult" runat="server"></asp:Label>
                                            </div>
                                            <div id="gvExpStmnt" class="col-md-12 customRow ">
                                                <asp:GridView ID="gvExpStatement" EmptyDataText="No record found..."
                                                    CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false"
                                                    Style="width: 100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                SlNo.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Voucher No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpVoucherNo" runat="server" Text='<%# Eval("VoucherNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Trasaction Type
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpTranType" runat="server" Text='<%# Eval("TransactionTypeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Transaction Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExptrandate" runat="server" Text='<%# Eval("TransactionDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Payment Mode
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpPaymentModeName" runat="server" Text='<%# Eval("PaymentModeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Total Amount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpTotalAmount" runat="server" Text='<%# Eval("TrasactionAmount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Status
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpstatus" runat="server" Text='<%# Eval("AccountStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                          <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Added By
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2addedby" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Overall Naration
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblExpremarks" runat="server" Text='<%# Eval("OverallNaration")%>'></asp:Label>
                                                                <asp:TextBox ID="txtExpremarks" Visible="false" Width="100px" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                            <div class="col-md-7 customRow "></div>
                                            <div class="col-md-2 customRow ">
                                                <div class="form-group">
                                                    <asp:Label ID="lblexptotal" runat="server" Style="color: red; font-size: 14px; font-weight: bold;" Text="Total :"></asp:Label>
                                                    <asp:Label ID="lblexptotalamt" runat="server" Style="color: red; font-size: 14px; font-weight: bold;" Text="0.00"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row pad15">
                                            <div class="col-md-12 customRow" style="margin-top: 13px; color: blueviolet;">
                                                <asp:Label ID="Label13" runat="server" Text="ACCOUNT SUMMARY"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row pad15">
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                                    <asp:Label runat="server" ID="Label8" Text="Cash Income"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtCashIncome" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label14" runat="server"></asp:Label>
                                                    <asp:Label runat="server" ID="Label15" Text="Bank Income"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtBankIncome" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label16" runat="server"></asp:Label>
                                                    <asp:Label runat="server" ID="Label17" Text="Expenditure"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtExpenditure" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group">
                                                    <asp:Label ID="Label18" runat="server"></asp:Label>
                                                    <asp:Label runat="server" ID="Label19" Text="Balance"></asp:Label>
                                                    <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtBalance" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2 customRow">
                                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                                    <asp:Button ID="btnClose" runat="server" class="btn btn-sm btn-danger button" Text="Close A/C" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <script type="text/javascript">
        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlTransactionTypeID.ClientID%>").value == "0") {
                str = str + "\n Please select ledger group .";
                document.getElementById("<%=ddlTransactionTypeID.ClientID %>").focus();
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

    </script>

</asp:Content>
