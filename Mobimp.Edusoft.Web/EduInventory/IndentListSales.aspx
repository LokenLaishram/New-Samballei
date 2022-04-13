<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="IndentListSales.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.IndentListSales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Indent List Sales&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Sales/IndentListSales.aspx">Indent List Sales</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li id="Tap1" class="active" runat="server"><a href="#tabIndentListSales"><i class="icon nalika-edit" aria-hidden="true"></i>Indent Sales</a></li>
                <li id="Tap3" runat="server"><a href="#tabSaleList"><i class="icon nalika-picture" aria-hidden="true"></i>Sale List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active  in" id="tabIndentListSales">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddl_VendorTypeID" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddl_VendorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hdnVendorID" />
                                            <asp:HiddenField runat="server" ID="hdnVendorName" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor/Buyer Name"></asp:Label>
                                            <asp:TextBox ID="txt_VendorName" MaxLength="50" runat="server" class="form-control custextbox"
                                                AutoPostBack="True" OnTextChanged="txt_VendorName_TextChanged">                                                                  
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" CompletionListCssClass="Completion"
                                                Enabled="True" ServiceMethod="GetVendorNameCompletionList" TargetControlID="txt_VendorName"
                                                MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                TargetControlID="txt_VendorName" ValidChars="abcdefghijklmnopqrstuvwxyz:1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_IndentNo" Text="Indent No."></asp:Label>
                                            <asp:TextBox ID="txt_IndentNo" MaxLength="15" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_IndentNo"
                                                ValidChars="0987654321:abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateFrom" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="txt_DateFrom" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_DateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_DateFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateTo" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="txt_DateTo" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_DateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_DateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblStatus" Text="Payment Status"></asp:Label>
                                            <asp:DropDownList ID="ddl_ApprovedStatus" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddl_ApprovedStatus_OnSelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Pending"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Paid"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-success button" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btn_Reset_Click" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 " style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 " style="text-align: right; margin-top: -5px;">
                                        <asp:LinkButton ID="tab2_btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1 " style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="tab2_lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 ">
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
                                    <div class="col-md-4 ">
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
                                    <div id="indentlistsales" class="col-md-12 ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_IndentListSales" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnRowDataBound="Gv_IndentListSales_OnRowDataBound"
                                                    CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_IndentListSales_RowCommand"
                                                    Style="width: 100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                SL No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IndentNo"  SortExpression="IndentNo" HeaderText="Indent No." />
                                                        <asp:BoundField DataField="VendorName" SortExpression="VendorName" HeaderText="Vendor/Buyer Name" />
                                                        <asp:BoundField DataField="GdTotalIndentQty" SortExpression="GdTotalIndentQty" HeaderText="Qty" />
                                                        <asp:BoundField DataField="GdTotalPrice" SortExpression="GdTotalPrice" HeaderText="Total Price" />
                                                        <asp:BoundField DataField="GdDiscount" SortExpression="GdDiscount" HeaderText="Dis%" />
                                                        <asp:BoundField DataField="GdDiscountValue" SortExpression="GdDiscountValue" HeaderText="Dis Amt" />
                                                        <asp:BoundField DataField="GdPayable" SortExpression="GdPayable" HeaderText="Payable" />
                                                        <asp:BoundField DataField="ApproveStatus" SortExpression="ApproveStatus" HeaderText="Status" Visible="false" />
                                                        <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Added DT" />
                                                        <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="AddedBy" />

                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                Print Copy
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="GvddlPrintCopy" runat="server" Width="120px" Height="20px" class="form-control custextbox">
                                                                    <asp:ListItem Value="1">OFFICE COPY</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Details
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_print" class="cus-btn btn-sm btn-indigo button" Text="Details" runat="server"
                                                                    CommandName="Print" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Action
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSaleBillNo" Visible="false" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                                <asp:Label ID="lblIndentNo" runat="server" Visible="false" Text='<%# Eval("IndentNo")%>'></asp:Label>
                                                                <asp:Label ID="lblIsApproved" runat="server" Visible="false" Text='<%# Eval("IsApproved")%>'></asp:Label>
                                                                <asp:Button ID="btn_SalesAppd" Visible="true" class="cus-btn btn-sm btn-success button" Text="Paid Done" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Sales" ValidationGroup="none" />
                                                                <asp:Button ID="btn_Sales" Visible="true" class="cus-btn btn-sm btn-danger button  " Text="Pay Now" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Sales" ValidationGroup="none" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Released
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIsReleasedClose" Visible="false" runat="server" Text='<%# Eval("IsReleasedClosed")%>'></asp:Label>
                                                                <asp:Label ID="lblReleaseDone" runat="server" class="cus-btn btn-sm  button" Text='Pending Pay..'></asp:Label>
                                                                <asp:Button ID="btn_release" class="cus-btn btn-sm btn-indigo button" Text="Release Now" runat="server"
                                                                    CommandName="Release" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                                                <asp:Button ID="btnReleasedClosed" class="cus-btn btn-sm btn-indigo button" Text="Closed" runat="server"
                                                                    CommandName="Release" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>


                <%------SALE PAYMENT POPUP--------%>
                <asp:ModalPopupExtender ID="ModalPopupExtender4" BehaviorID="modalbehavior4" TargetControlID="btn4_add" runat="server" PopupControlID="PaymentPopUpWindow"
                    BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnclose">
                </asp:ModalPopupExtender>
                <asp:Panel runat="server" ID="PaymentPopUpWindow" CssClass="ModalPopUpPanelBg " Style="display: none; width: 80%; margin-top: -10px;">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="row" style="border-bottom: 0px solid green;">
                                <div class="col-sm-4">
                                    <h5>Sale Payment </h5>
                                </div>
                                <div class="col-md-7 ">
                                    <asp:Label ID="lblpopMessage" runat="server" Style="color: red;"></asp:Label>
                                </div>
                                <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                    <asp:LinkButton ID="btnclose" runat="server" OnClick="btnSaleClose_OnClick"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label ID="Label16" runat="server" Text="Payment Date"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtBankDate" runat="server" class="form-control custextbox" Placeholder="dd/MM/yyyy"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtBankDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtBankDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblVendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlVendorTypeID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblVendorName" Text="Vendor/Buyer Name"></asp:Label>
                                            <asp:TextBox ID="txtVendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtVendorName"
                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                            <asp:HiddenField ID="hdn_VendorID" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblIndentNos" Text="Indent No."></asp:Label>
                                            <asp:TextBox ID="txtIndentNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtIndentNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12 ">
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="tab2_DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="tab2_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>

                                        <div id="indentlist" class="col-md-12  " style="max-height: 580px; overflow: auto;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="Gv_IndentSaleList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                        CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                                        Style="width: 100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText=" SL No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Stock No
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStkNo2" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Batch Year
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl2BatchYearID" Visible="false" runat="server" Text='<%# Eval("BatchYearID")%>'></asp:Label>
                                                                    <asp:Label ID="lbl2BatchYear" runat="server" Text='<%# Eval("YearName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Class Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubGrp" runat="server" Text='<%# Eval("SubGroupName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Book Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemID" runat="server" Visible="false" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Unit Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Price
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Available Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Indent Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIndentQty" runat="server" Text='<%# Eval("IndentQty")%>'></asp:Label>
                                                                    <asp:TextBox ID="txt_IssueQty" runat="server" Visible="false" Width="100px" BackColor="#eceeef" Text='<%# Eval("IndentQty")%>'
                                                                        CssClass="gridtextbox" AutoPostBack="true" OnTextChanged="txt_IssueQty_TextChanged"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender TargetControlID="txt_IssueQty" ID="FilteredTextBoxExtender6"
                                                                        runat="server" ValidChars="0123456789."
                                                                        Enabled="True"></asp:FilteredTextBoxExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Total Price
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("TotalPrice")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltotalissue" Text="Total Indent Qty"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTotalIssueQty" MaxLength="10" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtTotalAmount"
                                                ValidChars="09897654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Total Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTotalAmount" MaxLength="15" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtTotalAmount"
                                                ValidChars="09897654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label15" Text="Discount(%)"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt2DisPercent" onkeyup="return calculate();" MaxLength="10" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txt2DisPercent"
                                                ValidChars="09897654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblTotalDiscount" Text="Discount Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTotalDiscount" onkeyup="return calculate();" MaxLength="10" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTotalDiscount"
                                                ValidChars="09897654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblNetAmount" Text="Net Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtNetAmount" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNetAmount"
                                                ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2  hidden">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblTax" Text="Tax %"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTax" onkeyup="return calculate();" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTax"
                                                ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblPayableAmt" Text="Payable Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtPayableAmt" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPayableAmt"
                                                ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblPaidAmt" Text="Paid Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtPaidAmt" onkeyup="return calculate();" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPaidAmt"
                                                ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblDueAmt" Text="Due Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDueAmt" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtDueAmt"
                                                ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label2" Text="Payment Mode"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_PaymentMode" runat="server" class="form-control custextbox" OnSelectedIndexChanged="ddlpaymentmode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label8" Text="Bank Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlBankID" runat="server" class="form-control custextbox" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblinvoiceno" Text="Invoice No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_InvoiceNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ChequeNo" Text="Chalan No./Cheque No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ChequeNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-5 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblRemark" Text="Remark"></asp:Label>
                                            <asp:TextBox ID="txtRemark" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtRemark"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3" Text="Bill No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtinvoiceno" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-5 ">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnPay" class="btn btn-sm btn-success button" runat="server" Text="Pay" OnClick="btnupdate_Click" />
                                            <asp:Button ID="btn_Reset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnReset_Click" />
                                            <asp:Button ID="btn_Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintIndentpaymentreceipt()" />
                                            <asp:Button ID="btnRelease" class="btn btn-sm btn-indigo button" runat="server" Text="Released" OnClick="btnShowReleasedWindow" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Button ID="btn4_add" runat="server" />
                <%------/ MODAL POPUP--------%>

                <%-- //----TAB 2----//--%>
                <div class="product-tab-list tab-pane  fade" id="tabSaleList" style="margin-top: -18px !important;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label4" Text="Financial Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlFinancialYearID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label ID="Label13" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label14" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlVendorType3ID" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlVendorType3ID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="HiddenField3" />
                                            <asp:HiddenField runat="server" ID="HiddenField4" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label5" Text="Vendor/Buyer Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtVendoName3" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="True" OnTextChanged="txt_VendorName_TextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="True"
                                                ServiceMethod="GetVendorNameCompletionList2" TargetControlID="txtVendoName3" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="Completion">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="HiddenField1" />
                                            <asp:HiddenField runat="server" ID="HiddenField2" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Bill No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtBillNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Date From"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_FromDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_FromDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_FromDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ToDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_ToDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_ToDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label10" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 "></div>
                                    <div class="col-md-3 ">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch3" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClick="btnSearch3_Click" />
                                            <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-indigo button" Text="Print" OnClick="btn3Print_OnClick" />
                                            <asp:Button ID="btnreset" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btn3reset_Click" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row pad15">
                                    <div class="col-md-4 " style="margin-top: 13px;">
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                        <asp:Label ID="Label12" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 " style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1 " style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 ">
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> all</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 ">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        <asp:UpdateProgress ID="updateProgress3" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIV_loading" runat="server" class="Pageloader">
                                                    <asp:Image ID="img_UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="tab2indentlist" class="col-md-12  ">
                                        <asp:GridView ID="Gv_SaleLists" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowDataBound="GVSaleList_RowDataBound"
                                            OnRowCommand="Gv_SaleLists_RowCommand" Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("BillNo") %>');">
                                                            <img alt="Detail" id='imgdiv<%# Eval("BillNo") %>' src="../Images/plus.gif" width="20px" />
                                                        </a>
                                                        <div id='div<%# Eval("BillNo") %>' style="display: none;">
                                                            <asp:GridView ID="GridChildIndent" runat="server" AutoGenerateColumns="false" DataKeyNames="BillNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="BillNo" HeaderText="Bill No" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="SubGroupName" HeaderText="Class Name" />
                                                                    <asp:BoundField ItemStyle-Width="293px" DataField="ItemName" HeaderText="Book Name" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="IssueQty" HeaderText="Issue Qty" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="Price" HeaderText="Price" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TotalPrice" HeaderText="Total Price" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Bill No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Vendor/Buyer
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblindentName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalIssueQty" runat="server" Text='<%# Eval("TotalIssueQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalAmount" runat="server" Text='<%# Eval("GdTotalAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Discount %
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("GdDiscount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Discount Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscountValue" runat="server" Text='<%# Eval("GdDiscountValue")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Net-Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdNetAmount" runat="server" Text='<%# Eval("GdNetAmount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Tax %
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdtax" runat="server" Text='<%# Eval("Gdtax","{0:0#.##}")%> '></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Payable
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdPayable" runat="server" Text='<%# Eval("GdPayable")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Paid
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdPaid" runat="server" Text='<%# Eval("GdPaid")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Due
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdDue" runat="server" Text='<%# Eval("GdDue")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Payment Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblindentdate" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
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
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_print" class="cus-btn btn-sm btn-indigo button" Text="Print" runat="server"
                                                            CommandName="Print" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                            CommandName="Deletes" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none" />
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

                <%--//------RELEASED MODAL------//--%>
                <asp:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="modalbehavior4" TargetControlID="btnRel" runat="server" PopupControlID="ReleasedPopUpWindow"
                    BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnRClose">
                </asp:ModalPopupExtender>
                <asp:Panel runat="server" ID="ReleasedPopUpWindow" CssClass="ModalPopUpPanelBg " Style="display: none; width: 80%; margin-top: -10px;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div class="row" style="border-bottom: 0px solid green;">
                                <div class="col-sm-4">
                                    <h5>Stock Release</h5>
                                </div>
                                <div class="col-md-7 ">
                                    <asp:Label ID="lblRpopMessage" runat="server" Text="PopUp message"></asp:Label>
                                </div>
                                <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                    <asp:LinkButton ID="btnRClose" runat="server" OnClick="btnRClose_OnClick"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label18" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddl2VendorTypeID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label19" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txt2VendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hdn2VendorID" runat="server" />
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txt2VendorName"
                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>

                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label20" Text="Indent No."></asp:Label>
                                            <asp:TextBox ID="txtRIndentNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtRIndentNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label21" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txt2billno" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txt2billno"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12 ">
                                        <asp:UpdateProgress ID="updateProgress4" runat="server">
                                            <ProgressTemplate>
                                                <div id="tab2_RDIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="tab2RimgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ...." ToolTip="Loading ...." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>

                                        <div id="DivReleased" class="col-md-12  ">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="Gv_StockReleasedList" EmptyDataText="No record found..."
                                                        CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false"
                                                        Style="width: 100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText=" SL No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Stock No.
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl2RStockNo" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Batch Year
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl2RBatchYearID" Visible="false" runat="server" Text='<%# Eval("BatchYearID")%>'></asp:Label>
                                                                    <asp:Label ID="lbl2RBatchYearName" runat="server" Text='<%# Eval("YearName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Book Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRItemID" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                    <asp:Label ID="lblRItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Unit
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRUnitName" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Available Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRAvailableQty" runat="server" Text='<%# Eval("AvailableQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Indent Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRApprovedQty" runat="server" Text='<%# Eval("TotalApprovedQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Total Released Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRTotalReleasedQty" runat="server" Text='<%# Eval("TotalReleasedQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Due Release Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRDueRQty" Visible="false" runat="server" Text='<%# Eval("TotalDueReleasedQty")%>'></asp:Label>
                                                                    <asp:TextBox ID="txtRDueQty" ReadOnly="true" runat="server" CssClass="gridtextbox" Width="100px" BackColor="#eceeef" Text='<%# Eval("TotalDueReleasedQty")%>' OnTextChanged="OnQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender TargetControlID="txtRDueQty" ID="FilteredTextBoxExtender6"
                                                                        runat="server" ValidChars="0123456789."
                                                                        Enabled="True"></asp:FilteredTextBoxExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Status
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRitemStatusID" Visible="false" runat="server" Text='<%# Eval("IsItemReleasedClosed")%>'></asp:Label>
                                                                    <asp:Label ID="lblRitemStatusName" runat="server" Text='<%# Eval("ReleasedStatus")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label22" Text="Total Stock"></asp:Label>
                                            <asp:TextBox ID="txt2TotalAvailStk" runat="server" class="form-control custextbox">
                                            </asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblappQty" Text="Total Indent Qty"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalApprovedQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label23" Text="Total Released Qty"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalReleasedQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label24" Text="Total Release Now"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalReleasedNowQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label25" Text="RNo."></asp:Label>
                                            <asp:TextBox ID="txtRNo" MaxLength="15" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnReleased" class="btn btn-sm btn-success button" runat="server" Text="Release Now" OnClick="btnReleased_OnClick" />

                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-8"></div>
                                    <div class="col-md-4 ">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="Button3" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClick="btn2print_OnClick" />
                                            <asp:Button ID="Button1" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnRClose_OnClick" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Button ID="btnRel" runat="server" />
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=txtPaidAmt.ClientID%>").value == "") {
                str = str + "\n Please enter Paid Amount";
                document.getElementById("<%=txtPaidAmt.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_PaymentMode.ClientID%>").value == "") {
                str = str + "\n Please select Payment Mode";
                document.getElementById("<%=ddl_PaymentMode.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtBankDate.ClientID%>").value == "") {
                str = str + "\n Please select Chalan date.";
                document.getElementById("<%=txtBankDate.ClientID %>").focus();
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

        $(function () {
            $('[id*=Gv_IndentListSales]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_IndentListSales]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#indentlistsales table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        $(function () {
            $('[id*=Gv_IndentList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_IndentList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#indentlist table tbody tr').each(function () {
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
        function calculate() {

            var TotalAmt = document.getElementById("<%=txtTotalAmount.ClientID%>").value;
            var Discount = document.getElementById("<%=txtTotalDiscount.ClientID%>").value;

            if (+(TotalAmt) >= +(Discount)) {
                document.getElementById("<%=txtNetAmount.ClientID%>").value = (TotalAmt - Discount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txtTotalDiscount.ClientID%>").value = "";
                document.getElementById("<%=txtNetAmount.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=txtPayableAmt.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=txtDueAmt.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Discount amount could not be grater than total Amount.");
            }
            var NetAmount = document.getElementById("<%=txtNetAmount.ClientID%>").value;
            var Tax = document.getElementById("<%=txtTax.ClientID%>").value;
            if (+(Tax) > +(100)) {
                document.getElementById("<%=txtTax.ClientID%>").value = "";
                document.getElementById("<%=txtPayableAmt.ClientID%>").value = (NetAmount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Tax could not be grater than 100%.");
            }
            else {
                document.getElementById("<%=txtPayableAmt.ClientID%>").value = ((TotalAmt - Discount) * (Tax / 100) + (TotalAmt - Discount)).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            var Payable = document.getElementById("<%=txtPayableAmt.ClientID%>").value;
            var Paid = document.getElementById("<%=txtPaidAmt.ClientID%>").value;
            if (+(Payable) >= +(Paid)) {
                document.getElementById("<%=txtDueAmt.ClientID%>").value = ((((TotalAmt - Discount) * (Tax / 100)) + (TotalAmt - Discount)) - Paid).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txtPaidAmt.ClientID%>").value = "";
                document.getElementById("<%=txtDueAmt.ClientID%>").value = (Payable).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Paid amount could not be grater than payable amount.");
            }

        }
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
        
        function PrintIndentpaymentreceipt() {
            objInvoiceNo = document.getElementById("<%= txtinvoiceno.ClientID%>")
            window.open("../EduInventory/Reports/ReportViewer.aspx?option=Indentpaymentreceipt&InvoiceNo=" + objInvoiceNo.value)
        }
    </script>
</asp:Content>
