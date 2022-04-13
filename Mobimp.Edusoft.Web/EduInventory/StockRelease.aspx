<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="StockRelease.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.StockRelease" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Indent List Sales&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Sales/StockRelease.aspx">Stock Release</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li id="Tap1" class="active" runat="server"><a href="#tabIndentListSales"><i class="icon nalika-edit" aria-hidden="true"></i>Paid Indent List</a></li>
               
                <li id="Tap3" runat="server"><a href="#tabSaleList"><i class="icon nalika-picture" aria-hidden="true"></i>Released Stock List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active  in" id="tabIndentListSales">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label15" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lblFYearID" Text="Financial Year"></asp:Label>
                                            <asp:DropDownList ID="ddlFYearID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlVendorTypeID" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlVendorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hdnVendorID" />
                                            <asp:HiddenField runat="server" ID="hdnVendorName" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txtVendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True"
                                                ServiceMethod="GetVendorNameCompletionList" TargetControlID="txtVendorName" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="Completion">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                TargetControlID="txtVendorName" ValidChars="abcdefghijklmnopqrstuvwxyz:1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl1BillNo" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txtBillNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBillNo"
                                                ValidChars="0987654321:abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateFrom" Text="Indent Date From"></asp:Label>
                                            <asp:TextBox ID="txtDateFrom" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtDateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDateFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateTo" Text="Indent Date To"></asp:Label>
                                            <asp:TextBox ID="txtDateTo" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtDateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label16" Text="Release Status"></asp:Label>
                                            <asp:DropDownList ID="ddlRStatusID" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="2" Text="ALL"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="OPEN"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="CLOSED"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-3 customRow pull-right">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-success button" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_OnClick" />

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
                                    <div id="indentlistsales" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_PaymentListSales" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnRowDataBound="Gv_PaymentList_OnRowDataBound"
                                                    CssClass="table-bordered table-striped gridviewcss" FooterStyle-CssClass="grid-footer-css" ShowFooter="true" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_PaymentListSales_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText=" SL No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                BillNo
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2gvBillNo" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Vendor Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2Vname" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Bill Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2GAppDate" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Released Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2GRelDate" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtTotal" runat="server" Text="Total :" />
                                                            </FooterTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Total Qty
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2GTotApp" runat="server" Text='<%# Eval("GdTotalApprovedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtTotApp" runat="server" />
                                                            </FooterTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Total Released
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2GTotRel" runat="server" Text='<%# Eval("GdTotalReleasedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtTotRel" runat="server" />
                                                            </FooterTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Due Released
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2GDueRel" runat="server" Text='<%# Eval("GdTotalDueReleasedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFtTotDueRel" runat="server" />
                                                            </FooterTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
                                                            <HeaderTemplate>
                                                                Payment Status
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2PaymentStatus" runat="server" Text='<%# Eval("PaymentStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="true">
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
                                                                <asp:Label ID="lbl2BillNo" runat="server" Visible="false" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                                <asp:Label ID="lblRStatusID" runat="server" Visible="false" Text='<%# Eval("IsReleasedClosed")%>'></asp:Label>
                                                                <asp:Button ID="btn_RDone" Visible="false" class="cus-btn btn-sm btn-danger button" Text="Released Close" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Released" ValidationGroup="none" />
                                                                <asp:Button ID="btn_RNow" Visible="true" class="cus-btn btn-sm btn-success button  " Text="Release Now" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Released" ValidationGroup="none" />
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
                                <div class="row hidden" style="margin-top: 20px;">
                                    <div class="col-md-4 customRow "></div>
                                    <div class="col-md-2 customRow ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label18" CssClass="lblcolor" Text="Total Approved Qty"></asp:Label>
                                            <asp:TextBox ID="txtNetApprovedQty" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label19" CssClass="lblcolor" Text="Total Released Qty"></asp:Label>
                                            <asp:TextBox ID="txtNetReleasedQty" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label20" CssClass="lblcolor" Text="Total Due Qty"></asp:Label>
                                            <asp:TextBox ID="txtNetDueReleaseQty" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-------------------Start Second Tab-----------------------%>

                <div class="product-tab-list tab-pane  fade" id="tabIndentSaleDetails">
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
                                    <h5>Stock Release </h5>
                                </div>
                                <div class="col-md-7 ">
                                    <asp:Label ID="lblpopMessage" runat="server" Style="color: red;"></asp:Label>
                                </div>
                                <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                    <asp:LinkButton ID="btnclose" runat="server" OnClick="btnRClose_OnClick"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblVendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddl2VendorTypeID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblVendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txt2VendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hdn2VendorID" runat="server" />
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt2VendorName"
                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblIndentNos" Text="Indent No."></asp:Label>
                                            <asp:TextBox ID="txtIndentNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtIndentNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label17" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txt2billno" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txt2billno"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12 customRow">
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="tab2_DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="tab2_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="indentlist" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                                                <asp:Label ID="lbl2StockNo" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Batch Year
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2BatchYearID" Visible="false" runat="server" Text='<%# Eval("BatchYearID")%>'></asp:Label>
                                                                <asp:Label ID="lbl2BatchYearName" runat="server" Text='<%# Eval("YearName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Book Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Unit
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
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
                                                                <asp:Label ID="lblApprovedQty" runat="server" Text='<%# Eval("TotalApprovedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Total Released Qty
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalReleasedQty" runat="server" Text='<%# Eval("TotalReleasedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Due Release Qty
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDueRQty" Visible="false" runat="server" Text='<%# Eval("TotalDueReleasedQty")%>'></asp:Label>
                                                                <asp:TextBox ID="txtDueQty" runat="server" CssClass="gridtextbox" Width="100px" BackColor="#eceeef" Text='<%# Eval("TotalDueReleasedQty")%>' OnTextChanged="OnQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender TargetControlID="txtDueQty" ID="FilteredTextBoxExtender6"
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
                                                                <asp:Label ID="lblitemStatusID" Visible="false" runat="server" Text='<%# Eval("IsItemReleasedClosed")%>'></asp:Label>
                                                                <asp:Label ID="lblitemStatusName" runat="server" Text='<%# Eval("ReleasedStatus")%>'></asp:Label>
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
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label21" Text="Total Stock"></asp:Label>
                                            <asp:TextBox ID="txt2TotalAvailStk" runat="server" class="form-control custextbox">
                                            </asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblappQty" Text="Total Indent Qty"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalApprovedQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Total Released Qty"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalReleasedQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label2" Text="Total Release Now"></asp:Label>
                                            <asp:TextBox ID="txtGdTotalReleasedNowQty" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3" Text="RNo."></asp:Label>
                                            <asp:TextBox ID="txtRNo" MaxLength="15" runat="server" class="form-control custextbox">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-8"></div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnReleased" OnClientClick="return Validate();" class="btn btn-sm btn-success button" runat="server" Text="Release Now" OnClick="btnupdate_Click" />
                                            <asp:Button ID="btn_Reset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn2Reset_OnClick" />
                                            <asp:Button ID="btn_Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClick="btn2print_OnClick" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Button ID="btn4_add" runat="server" />
                <%------/ MODAL POPUP--------%>

                <%-- //----TAB 3----//--%>
                <div class="product-tab-list tab-pane  fade" id="tabSaleList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label4" Text="Financial Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl3FYearID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label13" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label14" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddl3VendorTypeID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="HiddenField3" />
                                            <asp:HiddenField runat="server" ID="HiddenField4" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label5" Text="Vendor Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt3VendoName" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                                DelimiterCharacters=""
                                                Enabled="True"
                                                ServicePath="~/Webservices/ItemListAutoSuggession.asmx"
                                                ServiceMethod="GetVendorNameCompletionList"
                                                TargetControlID="txt3VendoName"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="10"
                                                EnableCaching="true"
                                                CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="HiddenField1" />
                                            <asp:HiddenField runat="server" ID="HiddenField2" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Released No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt3RNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Date From"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt3FromDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txt3FromDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt3FromDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt3ToDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txt3ToDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt3ToDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label8" Text="Released Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlReleasedStatusID" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="2">ALL</asp:ListItem>
                                                <asp:ListItem Value="0">OPEN </asp:ListItem>
                                                <asp:ListItem Value="1">CLOSE </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label10" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-3 customRow pull-right">
                                        <div class="form-group " style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch3" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClick="btnSearch3_OnClick" />
                                            <asp:Button ID="Button2" runat="server" class="btn btn-sm btn-indigo button" Text="Print" />
                                            <asp:Button ID="btnreset" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btnReset3_OnClick" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                        <asp:Label ID="Label12" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                                            <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" class="form-control custextbox">
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
                                        <asp:UpdateProgress ID="updateProgress3" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIV_loading" runat="server" class="Pageloader">
                                                    <asp:Image ID="img_UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="tab3Releasedlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_StockReleasedLists" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv3StockReleased_RowDataBound" OnRowCommand="Gv3StockReleased_RowCommand"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("ReleasedNo") %>');">
                                                            <img alt="Detail" id='imgdiv<%# Eval("ReleasedNo") %>' src="../Images/plus.gif" width="20px" />
                                                        </a>
                                                        <div id='div<%# Eval("ReleasedNo") %>' style="display: none;">
                                                            <asp:GridView ID="GridChildReleased" runat="server" AutoGenerateColumns="false" DataKeyNames="BillNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="ReleasedNo" HeaderText="RNo" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="GroupName" HeaderText="Group" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="SubGroupName" HeaderText="Sub-Group" />
                                                                    <asp:BoundField ItemStyle-Width="293px" DataField="ItemName" HeaderText="Item Name" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TotalApprovedQty" HeaderText="Total Approved" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TotalReleasedQty" HeaderText="Total Released" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="NowReleasedQty" HeaderText="Now Released" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="TotalDueReleasedQty" HeaderText="Due To Released" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Released No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl3ReleasedNo" runat="server" Text='<%# Eval("ReleasedNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Vendor
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblindentName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Approved Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdApprovedQty" runat="server" Text='<%# Eval("GdTotalApprovedQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Released
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalRelesedQty" runat="server" Text='<%# Eval("GdTotalReleasedQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Now Released 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReleasedNow" runat="server" Text='<%# Eval("GdTotalReleasedNow")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Due To Release
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGdDue" runat="server" Text='<%# Eval("GdTotalDueReleasedQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Released Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblindentdate" runat="server" Text='<%# Eval("AddedDate")%>'></asp:Label>
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
            </div>
        </div>
    </div>
    <script type="text/javascript">
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
