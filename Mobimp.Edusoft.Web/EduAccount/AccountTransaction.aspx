<%@ Page Title="InventoSoft | Account transaction" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AccountTransaction.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduAccount.AccountTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Account&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Account/AccountTransaction.aspx">Account Transaction</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#TabTransaction"><i class="icon nalika-edit" aria-hidden="true"></i>Account Transaction</a></li>
                <li><a href="#TabTransactionList"><i class="icon nalika-picture" aria-hidden="true"></i>Transaction List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="TabTransaction">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_datefrom" runat="server" Text="Date from"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_tansactionDate" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txt_tansactionDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_tansactionDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3" Text="Transaction Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_TransactionType" runat="server" class="form-control " OnSelectedIndexChanged="ddl_TransactionType_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_FromLedgerID" Text="From Ledger Head"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_FromLedgerID" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ToLedgerID" Text="To Ledger Head"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_ToLedgerID" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblitemnaration" Text="Naration"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_Naration" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltransactionamout" Text="Transaction Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_TransactionAmount" ValidChars="0123456789." MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txt_TransactionAmount" ID="FilteredTextBoxExtender6"
                                                runat="server" ValidChars="0123456789."
                                                Enabled="True"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnadd_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div id="GV_Heading" style="padding: 0px 0px 12px 12px; color: #f44336;" class="col-md-12 ">
                                        Tranasaction List(s)
                                    </div>
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
                                    <div id="Tranlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_Transaction" EmptyDataText="No record found..." OnRowCommand="Gv_Transaction_RowCommand"
                                            CssClass="footable table-striped" runat="server" AutoGenerateColumns="false" Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        From Ledger head
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfromledgerID" Visible="false" runat="server" Text='<%# Eval("FromLedgerID")%>'></asp:Label>
                                                        <asp:Label ID="lblfromledgername" runat="server" Text='<%# Eval("FromLedgerName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        To Ledger Head
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblToLedgerID" Visible="false" runat="server" Text='<%# Eval("ToLedgerID")%>'></asp:Label>
                                                        <asp:Label ID="lblToLedgerName" runat="server" Text='<%# Eval("ToLedgerName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTranAmount" runat="server" Text='<%# Eval("TrasactionAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTranNaration" runat="server" Text='<%# Eval("TrasactionNaration")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                            CommandName="Deletes" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Naration" Text="Overall Naration"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_OverallNaration" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Payment Mode"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_PaymentMode" OnSelectedIndexChanged="ddlpaymentmode_SelectedIndexChanged" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label8" Text="Bank Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_BankName" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblinvoiceno" Text="Invoice No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_InvoiceNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ChequeNo" Text="Cheque No/UTR No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ChequeNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_totaldebit" Text="Total Debit"></asp:Label>
                                            <asp:TextBox ID="txt_totaldebit" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_totalcredit" Text="Total Credit"></asp:Label>
                                            <asp:TextBox ID="txt_totalcredit" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VoucherNo" Text="Voucher No."></asp:Label>
                                            <asp:TextBox ID="txt_TransactionNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button" Text="Save" OnClick="btnupdate_Click" />
                                            <asp:Button ID="btnprint" runat="server" class="btn btn-sm btn-indigo button" Text="Print" />
                                            <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="BtnReset_OnClick" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <%-------------------Start Second Tab-----------------------%>
                <div class="product-tab-list tab-pane fade" id="TabTransactionList">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label2" Text="Transaction Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlTransactionTypeID" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label5" Text="Account Head"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAccountHeadID" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label12" Text="Transaction No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTransactionNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label10" Text="Account Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAccountStatus" runat="server" class="form-control">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="1">Open </asp:ListItem>
                                                <asp:ListItem Value="2">Close </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Date From"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_FromDate" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txt_FromDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_FromDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ToDate" runat="server" class="form-control "></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txt_ToDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_ToDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow"></div>
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
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
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
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIV_loading" runat="server" class="Pageloader">
                                                    <asp:Image ID="img_UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="tab2indentlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_TransactionList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnRowCommand="Gv_TransactionList_RowCommand"
                                            CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv_TransactionList_RowDataBound"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("TransactionNo") %>');">
                                                            <img alt="Detail" id='imgdiv<%# Eval("TransactionNo") %>' src="../Images/plus.gif" width="20px" />
                                                        </a>
                                                        <div id='div<%# Eval("TransactionNo") %>' style="display: none;">
                                                            <asp:GridView ID="GridChildIndent" runat="server" AutoGenerateColumns="false" DataKeyNames="TransactionNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TransactionNo" HeaderText="Voucher No" />
                                                                    <asp:BoundField ItemStyle-Width="293px" DataField="FromLedgerName" HeaderText="From Ledger Head" />     
                                                                    <asp:BoundField ItemStyle-Width="293px" DataField="ToLedgerName" HeaderText="To Ledger Head" />                                                                   
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TrasactionAmount" HeaderText="Amount" />
                                                                    <asp:BoundField ItemStyle-Width="293px" DataField="TrasactionNaration" HeaderText="Naration" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Voucher No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTransactionNo" runat="server" Text='<%# Eval("TransactionNo")%>'></asp:Label>
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
                                                        <asp:Label ID="lbltrandate" runat="server" Text='<%# Eval("TransactionDate")%>'></asp:Label>
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
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremarks" Width="100px" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                            CommandName="Deletes" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" OnClientClick="Tab2functionConfirm(this); return false;" />
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
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Tranlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddl_FromLedgerID.ClientID%>").value == "0") {
                str = str + "\n Please select ledger group .";
                document.getElementById("<%=ddl_FromLedgerID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_ToLedgerID.ClientID%>").value == "0") {
                str = str + "\n Please select ledger to .";
                document.getElementById("<%=ddl_ToLedgerID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_FromLedgerID.ClientID%>").value == "0") {
                str = str + "\n Please select ledger nature.";
                document.getElementById("<%=ddl_FromLedgerID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_FromLedgerID.ClientID%>").value == "") {
                str = str + "\n Please enter opening balance.";
                document.getElementById("<%=ddl_FromLedgerID.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_Transaction.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_Session]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_Unit]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Tranlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });
    </script>
     <script type="text/javascript">
        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../Images/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../Images/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../Images/plus.gif");
            }
        }

    </script>
</asp:Content>
