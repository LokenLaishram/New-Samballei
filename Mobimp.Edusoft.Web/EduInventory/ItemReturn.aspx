<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ItemReturn.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.ItemReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" runat="server" id="a1" href="../EduInventory/ItemReturn.aspx">Item Return</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabItemReturn"><i class="icon nalika-edit" aria-hidden="true"></i>Item Return</a></li>
                <li><a href="#tabItemReturnDetails"><i class="icon nalika-picture" aria-hidden="true"></i>Item Return Details</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabItemReturn">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_IssueNo" Text="Issue No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_IssueNo" MaxLength="10" AutoPostBack="true" OnTextChanged="txt_IssueNo_TextChanged" runat="server" class="form-control ">
                                            </asp:TextBox>
                                            <asp:Label runat="server" ID="lblhdn_IssueNo" Visible="false"></asp:Label>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_IssueNo"
                                                ValidChars="0987654321ISNOisno">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetIssueNoAuto" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt_IssueNo"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/Webservices/autosuggestedpagesearch.asmx"
                                                CompletionListCssClass="completionList" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:TextBox ID="txt_VendorType" disabled="disabled" MaxLength="50" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txt_VendorName" disabled="disabled" MaxLength="50" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_IssueDate" Text="Issue Date"></asp:Label>
                                            <asp:TextBox ID="txt_IssueDate" disabled="disabled" MaxLength="20" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_TotalIssueQty" Text="Total Issue Quantity"></asp:Label>
                                            <asp:TextBox ID="txt_TotalIssueQty" disabled="disabled" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ReturnNo" Text="Return Number"></asp:Label>
                                            <asp:TextBox ID="txt_ReturnNo" disabled="disabled" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" class="btn btn-sm btn-success button" runat="server" Text="Add" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card_wrapper">
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
                                    <div id="itemreturn" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_ItemReturn" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                    CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_ItemReturn_RowCommand"
                                                    Style="width: 100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                SL No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                                <asp:Label ID="Gvlbl_IssueID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("IssueID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_VendorTypeID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("VendorTypeID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_VendorID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_ItemID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_UnitID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("UnitID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IssueNo" SortExpression="IssueNo" HeaderText="Issue No" />
                                                        <asp:BoundField DataField="StockNo" SortExpression="StockNo" HeaderText="Stock No" />
                                                        <asp:BoundField DataField="VendorTypeName" SortExpression="VendorTypeName" HeaderText="Vendor Type Name" />
                                                        <asp:BoundField DataField="VendorName" SortExpression="VendorName" HeaderText="Vendor Name" />
                                                        <asp:BoundField DataField="ItemName" SortExpression="ItemName" HeaderText="Item Name" />
                                                        <asp:BoundField DataField="Price" SortExpression="Price" HeaderText="Price" />
                                                        <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="Unit Name" />
                                                        <asp:BoundField DataField="ExpiryDate" SortExpression="ExpiryDate" HeaderText="Expiry Date" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Issue Quantity
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Gvlbl_IssueQty" Width="100px" Height="20px" runat="server" Text='<%# Eval("IssueQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Return Quantity
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="Gvtxt_ReturnQty" AutoPostBack="true" OnTextChanged="Gvtxt_ReturnQty_TextChanged" MaxLength="50" Width="100px" Height="20px" class="form-control" runat="server" Text="0"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="Gvtxt_ReturnQty"
                                                                    ValidChars="0987654321">
                                                                </asp:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="AddedBy" />
                                                        <asp:BoundField DataField="IssueDate" SortExpression="IssueDate" HeaderText="Issue Date" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Delete
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
                            <div class="row mt10">
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblRemark" Text="Remark"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txtRemark" runat="server" class="form-control ">                                                                  
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblTotalReturnQty" Text="Total Return Quantity"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_TotalReturnQty" runat="server" class="form-control ">                                                                  
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btnSave" class="btn btn-sm btn-success button" OnClientClick="return Validate();" OnClick="btnSave_Click" runat="server" Text="Save" />
                                        <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                                        <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-------------------Start Second Tab-----------------------%>

                <div class="product-tab-list tab-pane fade" id="tabItemReturnDetails">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblVendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="tab2_ddlVendorType" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblVendorName" Text="Vendor Name"></asp:Label>
                                            <asp:DropDownList ID="tab2_ddlVendorName" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblReturnNo" Text="Return No."></asp:Label>
                                            <asp:TextBox ID="tab2_txtReturnNo" MaxLength="10" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="tab2_txtReturnNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetReturnNoAuto" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="tab2_txtReturnNo"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/Webservices/autosuggestedpagesearch.asmx"
                                                CompletionListCssClass="completionList" CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblDateFrom" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="tab2_txtDateFrom" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="tab2_txtDateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="tab2_txtDateFrom" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblDateTo" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="tab2_txtDateTo" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="tab2_txtDateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="tab2_txtDateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblStatus" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="tab2_ddlStatus" runat="server" class="form-control ">
                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="tab2_btnSearch" OnClick="tab2_btnSearch_Click" class="btn btn-sm btn-info button" runat="server" Text="Search" />
                                            <asp:Button ID="tab2_btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" />
                                            <asp:Button ID="tab2_btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="tab2_lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="tab2_lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:LinkButton ID="tab2_btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="tab2_lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="tab2_ddl_show" AutoPostBack="true" runat="server" class="form-control">
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
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="tab2_DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="tab2_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="itemreturnlist" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_ItemReturnDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                    CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                                    Style="width: 100%" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText=" SL No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Return No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Gvlbl_ReturnNo" Width="100px" Height="20px" runat="server" Text='<%# Eval("ReturnNo")%>'></asp:Label>
                                                                <asp:Label ID="Gvlbl_IssueNo" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("IssueNo")%>'></asp:Label>
                                                                <asp:Label ID="Gvlbl_StockNo" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                                <asp:Label ID="Gvlbl_ReturnID" Visible="false" Width="100px" Height="20px" runat="server" Text='<%# Eval("ReturnID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="VendorTypeName" SortExpression="VendorTypeName" HeaderText="Vendor Type Name" />
                                                        <asp:BoundField DataField="VendorName" SortExpression="VendorName" HeaderText="Vendor Name" />
                                                        <asp:BoundField DataField="ItemName" SortExpression="ItemName" HeaderText="Item Name" />
                                                        <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="Unit" />
                                                        <asp:BoundField DataField="ReturnQty" SortExpression="ReturnQty" HeaderText="Return Qty." />
                                                        <asp:BoundField DataField="TotalReturnQty" SortExpression="TotalReturnQty" HeaderText="Total Return Qty." />
                                                        <asp:BoundField DataField="ExpiryDate" SortExpression="ExpiryDate" HeaderText="Expiry Date" />
                                                        <asp:BoundField DataField="ReturnDate" SortExpression="ReturnDate" HeaderText="Return Date" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Remark
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="Gvtxt_Remark" MaxLength="50" Width="100px" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="Gvtxt_Remark"
                                                                    ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& ">
                                                                </asp:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Print
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="Gvbtn_Print" class="cus-btn btn-sm btn-indigo button" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Print" ValidationGroup="none" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Delete
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="Gvbtn_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
            </div>
        </div>

    </div>

    <script type="text/javascript">

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=txt_IssueNo.ClientID%>").value == "") {
                str = str + "\n Please enter Issue No.";
                document.getElementById("<%=txt_IssueNo.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtRemark.ClientID%>").value == "") {
                str = str + "\n Please enter Remark";
                document.getElementById("<%=txtRemark.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_ItemReturnDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#itemreturnlist table tbody tr').each(function () {
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
            $('[id*=Gv_ItemReturn]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_ItemReturn]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#itemreturn table tbody tr').each(function () {
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
            $('[id*=Gv_ItemReturnDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_ItemReturnDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#itemreturnlist table tbody tr').each(function () {
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

</asp:Content>
