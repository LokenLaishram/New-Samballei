<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StockEntryWithoutPO.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.StockEntryWithoutPO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Stock&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Stock/StockEntryWithoutPO.aspx">Good Received Note Without Work Order</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li id="Tap1" class="active" runat="server"><a href="#tabstockentry"><i class="icon nalika-edit" aria-hidden="true"></i>GRN Without WO</a></li>
                <li id="Tap2" runat="server"><a href="#tabentrylist"><i class="icon nalika-picture" aria-hidden="true"></i>GRN List</a></li>

            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active  in" id="tabstockentry">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label2" Text="Academic/Batch Year"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlBatchYearID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">

                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_VendorType" AutoPostBack="true" OnSelectedIndexChanged="ddl_VendorType_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 about-sparkline customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Received From Vendor(Press Name)"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_VendorName" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Group" Text="Group Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_Group" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Group_SelectedIndexChanged" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_SubGroup" Text="SubGroup Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_SubGroup" AutoPostBack="true" OnSelectedIndexChanged="ddl_SubGroup_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ItemName" Text="Item Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ItemName" MaxLength="250" AutoPostBack="true" OnTextChanged="txt_ItemName_TextChanged" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetItemName" MinimumPrefixLength="1" CompletionListCssClass="Completion"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt_ItemName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" >
                                            </asp:AutoCompleteExtender>
                                            <asp:Label ID="lbl_GetItemName" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_ItemID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_YearID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_YearName" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblunitname" Text="Unit"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtUnit" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Price" Text="Price"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_Price" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Quantity" Text="Quantity"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_Quantity" onkeyup="return EqvCalculate();" AutoPostBack="true"
                                                MaxLength="7" OnTextChanged="txt_Quantity_TextChanged" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_Quantity" ValidChars="0987654321"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_TotalPrice" Text="Total Price"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_TotalPrice" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_TotalPrice" ValidChars="0987654321."></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 ">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label9" Text="Stock Received Date"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtStkReceivedDate" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtStkReceivedDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtStkReceivedDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group " style="margin-top: 1.8em;">
                                            <asp:Button ID="btnAdd" OnClientClick="return Validate();" OnClick="btnAdd_Click" class="btn btn-sm btn-success button" runat="server" Text="Add" />
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnItemClear" OnClick="btnClear" class="btn btn-sm btn-success button" runat="server" Text="Clear" />
                                        </div>
                                    </div>
                                    <%-------HIDE AREA FOR----------%>
                                    <div class="col-md-2 hidden">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ConvertingUnit" Text="ConvertingUnit"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_ConvertingUnit" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 hidden">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_EquivalentQty" Text="Equivalent Quantity"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_EquivalentQty" AutoPostBack="true" onkeyup="return EqvCalculate();" MaxLength="5" runat="server" class="form-control custextbox ">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_EquivalentQty" ValidChars="0987654321"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-2 hidden">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_NetQnty" Text="Net Quantity"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_NetQnty" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_NetQnty" ValidChars="0987654321"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 hidden">
                                        <div class="form-group ">
                                            <asp:Label runat="server" ID="lbl_ExpiryDate" Text="Expiry Date"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ExpiryDate" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_ExpiryDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_ExpiryDate" />
                                        </div>
                                    </div>
                                    <%-------/HIDE AREA FOR----------%>
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
                                    <div id="lblheading" class="col-md-12 customRow ">
                                        <p>Item Lists</p>
                                    </div>
                                    <div id="stockentrywithoutpolist" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_StockEntryWithoutPO" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                    CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" OnRowCommand="Gv_StockEntryWithoutPO_RowCommand" AutoGenerateColumns="false"
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
                                                                Year
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGv_YearName" runat="server" Text='<%# Eval("YearName")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_YearID" Visible="false" runat="server" Text='<%# Eval("YearID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Item Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGv_ItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_ItemID" Visible="false" class="form-control" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_GroupID" Visible="false" class="form-control" runat="server" Text='<%# Eval("GroupID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_SubGroupID" Visible="false" class="form-control" runat="server" Text='<%# Eval("SubGroupID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_VendorTypeID" Visible="false" class="form-control" runat="server" Text='<%# Eval("VendorTypeID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_VendorID" Visible="false" class="form-control" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_EquivalentQty" Visible="false" class="form-control" runat="server" Text='<%# Eval("EquivalentQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Price
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Quantity
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvQty" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                TotalPrice
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvTotalPrice" runat="server" Text='<%# Eval("TotalPrice")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Unit
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGv_CUnitName" runat="server" Text='<%# Eval("ConvertingUnitName")%>'></asp:Label>
                                                                <asp:Label ID="lblGv_CUnitID" Visible="false" runat="server" Text='<%# Eval("ConvertingUnitID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Net Quantity
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvNetQuantity" runat="server" Text='<%# Eval("NetQuantity")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>                                                      
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Delete
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="ListConfirm(this); return false;" />
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
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-7 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblRemark" Text="Remark"></asp:Label>
                                            <asp:TextBox ID="txtRemark" MaxLength="300" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtRemark" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ReceiptNo" Text="Receipt Number"></asp:Label>
                                            <asp:TextBox ID="txt_ReceiptNo" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSave" class="btn btn-sm btn-success button" OnClick="btnSave_Click" runat="server" Text="Save" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" OnClick="btnCancel_Click" runat="server" Text="Reset" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" OnClientClick="return PrintStockEntryWPOList()" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane  fade" id="tabentrylist">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label4" Text="Vendor/Press Name"></asp:Label>
                                            <asp:DropDownList ID="ddl2VandorName" runat="server" class="form-control custextbox ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label8" Text="Item Sub-Group"></asp:Label>
                                            <asp:DropDownList ID="ddl2SubGroupID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl2SubGroupID_SelectedIndexChanged" class="form-control custextbox ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_item" Text="Item/Book Name"></asp:Label>
                                            <asp:TextBox ID="txt2ItemName" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnTextChanged="txt2ItemName_OnTextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetItemNameAuto" MinimumPrefixLength="1" CompletionListCssClass="Completion"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt2ItemName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" >
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Received No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtReceivedNo" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateFrom" Text="Received Date From"></asp:Label>
                                            <asp:TextBox ID="txt2DateFrom" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2DateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2DateFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateTo" Text="Received Date To"></asp:Label>
                                            <asp:TextBox ID="txt2DateTo" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2DateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2DateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_status" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddl2Status"
                                                runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btn2Search" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btn2Search_Click" />
                                            <asp:Button ID="btn2Reset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn2Reset_OnClick" />
                                            <asp:Button ID="btn2print" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-12 customRow" style="margin: 1px 0px 10px 0px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading2" runat="server" class="Pageloader">
                                                    <asp:Image ID="img2UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <div id="stockstatuslist" class="col-md-12 customRow GridOverflow" style="padding: 10px 0px 1px 0px; border-top: 1px solid green;">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="Gv_GRNote" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gv_GRNote_PageIndexChanging"
                                                        CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_GRNote_OnRowCommand"
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
                                                                    Receipt No.
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lb2ReceiptNo" Visible="true" runat="server" Text='<%# Eval("ReceiptNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Stock No.
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGv_StockID" Visible="false" runat="server" Text='<%# Eval("StockID")%>'></asp:Label>
                                                                    <asp:Label ID="lblGv_StockNo" Visible="true" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Vendor/Press
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVendorName" Visible="true" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Class Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubGroupName" Visible="true" runat="server" Text='<%# Eval("SubGroupName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Book Name
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBookName" Visible="true" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Unit
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCUnitName" Visible="true" runat="server" Text='<%# Eval("CUnitName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Qty
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNetRecievedQty" Visible="true" runat="server" Text='<%# Eval("RecievedQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lbl_totalqty" runat="server" Text='<%# Eval("NetRecievedQty")%>' />
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Recieved Date
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRecievedDT" Visible="true" runat="server" Text='<%# Eval("RecievedDT","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Added Date
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAddedDate" Visible="true" runat="server" Text='<%# Eval("AddedDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Remark
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtremarks" MaxLength="50" Width="100px" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtremarks"
                                                                        ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Delete
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btn_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                        CommandName="Deletes" ValidationGroup="none" />
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
                                <div class="row" style="margin: 6px 0px 0px 0px; border-top: 1px solid green;">
                                    <div class="col-md-6"></div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" CssClass="pull-right" ID="Label5" Text="Total Received Qty :"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" CssClass="pull-left" ID="lbl2TotalReceivedQty"></asp:Label>
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
            if (document.getElementById("<%=ddlBatchYearID.ClientID%>").value == "") {ype.";
                document.getElementById("<%=ddl_VendorType.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_VendorName.ClientID%>").value == "") {
                str = str + "\n Please select Vendor Name.";
                document.getElementById("<%=ddl_VendorName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_Group.ClientID%>").value == "") {
                str = str + "\n Please select Group.";
                document.getElementById("<%=ddl_Group.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_SubGroup.ClientID%>").value == "") {
                str = str + "\n Please select Sub Group.";
                document.getElementById("<%=ddl_VendorName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_ItemName.ClientID%>").value == "") {
                str = str + "\n Please enter Item Name.";
                document.getElementById("<%=txt_ItemName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_TotalPrice.ClientID%>").value == "") {
                str = str + "\n Item Price not set. Please set the item price from Item price master page.";
                document.getElementById("<%=txt_TotalPrice.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_Quantity.ClientID%>").value == "") {
                str = str + "\n Please enter Quantity.";
                document.getElementById("<%=txt_Quantity.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_ConvertingUnit.ClientID%>").value == "") {
                str = str + "\n Please select Unit.";
                document.getElementById("<%=ddl_ConvertingUnit.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_EquivalentQty.ClientID%>").value == "") {
                str = str + "\n Please enter Equivalent Quantity.";
                document.getElementById("<%=txt_EquivalentQty.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_ExpiryDate.ClientID%>").value == "") {
                str = str + "\n Please enter Expire Date.";
                document.getElementById("<%=txt_ExpiryDate.ClientID %>").focus();
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
        function ListConfirm(event) {
            var row = event.parentNode.parentNode;
            var paramID = row.rowIndex - 1;
            swal({
                title: "Are you sure?",
                text: "To removed item from list?",

                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=Gv_StockEntryWithoutPO.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
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
                        __doPostBack('<%=Gv_StockEntryWithoutPO.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        $(function () {
            $('[id*=Gv_StockEntryWithoutPO]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_StockEntryWithoutPO]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#stockentrywithoutpolist table tbody tr').each(function () {
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
        function EqvCalculate() {
            var Price = document.getElementById("<%=txt_Price.ClientID%>").value;
            var Qty = document.getElementById("<%=txt_Quantity.ClientID%>").value;
            var Eqv = document.getElementById("<%=txt_EquivalentQty.ClientID%>").value;

            document.getElementById("<%=txt_TotalPrice.ClientID%>").value = (Qty * Price).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];

            if (+(Eqv) >= 1) {
                document.getElementById("<%=txt_NetQnty.ClientID%>").value = (Qty * Eqv).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txt_TotalPrice.ClientID%>").value = 1;
            }
        }
        
        function PrintStockEntryWPOList() {
            objReceiptNo = document.getElementById("<%= txt_ReceiptNo.ClientID%>")
            window.open("../EduInventory/Reports/ReportViewer.aspx?option=StockEntryWPOList&ReceiptNo=" + objReceiptNo.value)
        }
    </script>
</asp:Content>
