<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IndentGeneration.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.IndentGeneration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Indent&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Indent/IndentGeneration.aspx">Indent Generation</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active">
                    <a href="#TabIndentGen"><i class="icon nalika-edit" aria-hidden="true"></i>Indent Generation</a>
                </li>
                <li><a href="#TabIndentList"><i class="icon nalika-picture" aria-hidden="true"></i>Indent List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="TabIndentGen">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3" Text="Vendor Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_VendorTypeID" runat="server" class="form-control custextbox" OnSelectedIndexChanged="ddl_VendorType_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label2" Text="Vendor/Buyer Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_VendorName" AutoPostBack="true" MaxLength="100" runat="server" class="form-control custextbox"
                                                placeholder="Search vendor name.." OnTextChanged="txt_VendorName_TextChanged"></asp:TextBox>
                                             <asp:TextBox ID="txt_InvVendorName" Visible="false" MaxLength="100" runat="server" class="form-control custextbox"
                                                placeholder="Search vendor name.." ></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                                Enabled="True" ServiceMethod="GetVendorNameCompletionList" TargetControlID="txt_VendorName"
                                                MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnVendorID" />
                                            <asp:HiddenField runat="server" ID="hdnVendorName" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_group" Text="Group"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_group" AutoPostBack="true" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged"
                                                runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_subgroup" Text="Sub Group"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_subgroup" OnSelectedIndexChanged="ddl_subgroup_SelectedIndexChanged"
                                                AutoPostBack="true" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label4" Text="Item Name"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ItemName" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="True" OnTextChanged="txt_ItemName_TextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"  DelimiterCharacters=""
                                                Enabled="True"  ServiceMethod="GetItemCompletionList" TargetControlID="txt_ItemName"
                                                MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>

                                            <asp:HiddenField runat="server" ID="hdnItemID" />
                                            <asp:HiddenField runat="server" ID="hdnItemCode" />
                                            <asp:HiddenField runat="server" ID="hdnItemName" />
                                            <asp:HiddenField runat="server" ID="hdnUnintID" />
                                            <asp:HiddenField runat="server" ID="hdnUnintName" />
                                            <asp:HiddenField runat="server" ID="hdnPrice" />
                                            <asp:HiddenField runat="server" ID="hdnStockNo" />
                                            <asp:HiddenField runat="server" ID="hdnBatchYearID" />
                                            <asp:HiddenField runat="server" ID="hdnYearname" />

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label10" Text="Unit"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtunit" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label12" Text="Stock"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtstock" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label16" Text="Tot Indent"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtTotalIndentQty" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label17" Text="Bal-Stock"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtBalQty" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label11" Text="Price"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtprice" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblqty" Text="Qty"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtqty" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtqty" ID="FilteredTextBoxExtender6"
                                                runat="server" ValidChars="0123456789."
                                                Enabled="True"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-10 "></div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnadd" runat="server" class="btn btn-sm btn-success button" Text="Add" OnClick="btnadd_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnclear" runat="server" class="btn btn-sm btn-success button" Text="Clear" OnClick="btn_Clear" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div id="GV_Heading" style="padding: 0px 0px 12px 12px; color: #f44336;" class="col-md-12 ">
                                        Item List(s)
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
                                    <div id="Indentlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_IndentGeneration" EmptyDataText="No record found..." OnRowCommand="Gv_IndentGeneration_RowCommand"
                                            CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false" Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Stock No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStkNo" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Vendor Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVendorID" runat="server" Visible="false" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                        <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Group
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGroupID" runat="server" Visible="false" Text='<%# Eval("GroupID")%>'></asp:Label>
                                                        <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("GroupName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sub-Group
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubGroupID" runat="server" Visible="false" Text='<%# Eval("SubGroupID")%>'></asp:Label>
                                                        <asp:Label ID="lblSubGroupName" runat="server" Text='<%# Eval("SubGroupName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Year
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBatchYearID" Visible="false" runat="server" Text='<%# Eval("BatchYearID")%>'></asp:Label>
                                                        <asp:Label ID="lblyear" runat="server" Text='<%# Eval("YearName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Item Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemID" runat="server" Visible="false" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                        <asp:Label ID="lblToLedgerName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Unit Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitID" runat="server" Visible="false" Text='<%# Eval("UnitID")%>'></asp:Label>
                                                        <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Indent Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_indentQty" runat="server" Width="80px" Text='<%# Eval("IndentQty")%>'
                                                            AutoPostBack="True" CssClass="gridtextbox" OnTextChanged="txt_indentQty_TextChanged"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender TargetControlID="txt_indentQty" ID="FilteredTextBoxExtender6"
                                                            runat="server" ValidChars="0123456789"
                                                            Enabled="True"></asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="0.1%" />
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
                                                        Total
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("TotalPrice")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_totalqty" Text="Total Qty"></asp:Label>
                                            <asp:TextBox ID="txt_GdTotalqty" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_totalprice" Text="Total Price"></asp:Label>
                                            <asp:TextBox ID="txt_GdTotalPrice" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label13" Text="Discount(%)"></asp:Label>
                                            <asp:TextBox ID="txtdiscount" MaxLength="6" runat="server" class="form-control custextbox" onkeyup="return Discount();"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtFormPrice" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="0123456789."
                                                Enabled="True"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label15" Text="Discount Value"></asp:Label>
                                            <asp:TextBox ID="txtDiscountValue" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label18" Text="Indent Form Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtFormPrice" MaxLength="3" onkeyup="return Discount();" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtFormPrice" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars="0123456789"
                                                Enabled="True"></asp:FilteredTextBoxExtender>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label14" Text="Payable Amount"></asp:Label>
                                            <asp:TextBox ID="txtpayable" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Naration" Text="Remark"></asp:Label>
                                            <span class="mandatory_field"></span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_remarks" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_IndentNo" Text="Indent No."></asp:Label>
                                            <asp:TextBox ID="txt_IndentNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button" Text="Save" OnClick="btnupdate_Click" />
                                            <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="Clear_OnClick" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label19" Text="Print Copy"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlPrintCopy" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1">Personal Copy</asp:ListItem>
                                                <asp:ListItem Value="2">Godown Copy </asp:ListItem>
                                                <asp:ListItem Value="3">TextBook Copy </asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-left" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnprint" runat="server" class="btn btn-sm btn-indigo button" Text="Print" OnClick="btnprint_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="TabIndentList">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Vendor Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlVendorTypeID" runat="server" class="form-control custextbox"
                                                OnSelectedIndexChanged="ddl_VendorType2_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label5" Text="Vendor/Buyer Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtVendoName" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="True" OnTextChanged="txt_VendorName_TextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="True"                                                
                                                ServiceMethod="GetVendorNameCompletionList" TargetControlID="txtVendoName" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="Completion">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Indent No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtIndentNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblStatus" Text="Indent Status"></asp:Label>
                                            <asp:DropDownList ID="ddl_ApprovedStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Pending"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Approved"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Date From"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_FromDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_FromDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_FromDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                                            <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ToDate" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_ToDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_ToDate" />
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label7" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3"></div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btn_print" runat="server" Visible="false" class="btn btn-sm btn-indigo button" Text="Print" />
                                            <asp:Button ID="btnreset" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="Clear2_OnClick" />
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
                                                <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                                        <asp:GridView ID="Gv_IndentGen" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gv_IndentGen_PageIndexChanging"
                                            CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" OnSorting="Gv_IndentGen_Sorting" OnRowDataBound="GVIndentList_RowDataBound" OnRowCommand="Gv_IndentGen_RowCommand" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("IndentNo") %>');">
                                                            <img alt="Detail" id='imgdiv<%# Eval("IndentNo") %>' src="../Images/plus.gif" width="20px" />
                                                        </a>
                                                        <div id='div<%# Eval("IndentNo") %>' style="display: none;">
                                                            <asp:GridView ID="GridChildIndent" runat="server" AutoGenerateColumns="false" DataKeyNames="IndentNo"
                                                                CssClass="ChildGrid">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="IndentNo" HeaderText="Indent No" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="StockNo" HeaderText="Stock No" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="YearName" HeaderText="Batch Year" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="SubGroupName" HeaderText="Class Name" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="ItemName" HeaderText="Book Name" />
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="IndentQty" DataFormatString="{0:0#.##}" HeaderText="Indent Qty" />
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
                                                        IndenNo
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblindentNo" runat="server" Text='<%# Eval("IndentNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Vendor/Buyer Name
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
                                                        <asp:Label ID="lblindentQty" runat="server" Text='<%# Eval("GdTotalIndentQty")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Price
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotalprice" runat="server" Text='<%# Eval("GdTotalPrice")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Payment Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("ApproveStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Indent Date
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
                                                        <asp:TextBox ID="txtremarks" Width="100px" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print Copy
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="GvddlPrintCopy" runat="server"  Width="120px" Height="20px" class="form-control custextbox">
                                                            <asp:ListItem Value="1">Personal Copy</asp:ListItem>
                                                            <asp:ListItem Value="2">Godown Copy </asp:ListItem>
                                                            <asp:ListItem Value="3">TextBook Copy </asp:ListItem>
                                                        </asp:DropDownList>
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
                $('#tab2indentlist table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddl_VendorTypeID.ClientID%>").value == "0") {
                str = str + "\n Please select vendor type.";
                document.getElementById("<%=ddl_VendorTypeID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_VendorName.ClientID%>").value == "") {
                str = str + "\n Please select vendor name .";
                document.getElementById("<%=txt_VendorName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_ItemName.ClientID%>").value == "") {
                str = str + "\n Please select Item Name.";
                document.getElementById("<%=txt_ItemName.ClientID %>").focus();
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
                text: "Are you sure to remove item from the list?",

                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=Gv_IndentGeneration.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_IndentGeneration]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_IndentGeneration]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Indentlist table tbody tr').each(function () {
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
    //---TAB2---//
     <script type="text/javascript">

         $(document).ready(function () {
             $('.searchs').on('keyup', function () {
                 var searchTerm = $(this).val().toLowerCase();
                 $('#tab2indentlist table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddl_VendorTypeID.ClientID%>").value == "0") {
                str = str + "\n Please select vendor type.";
                document.getElementById("<%=ddl_VendorTypeID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_VendorName.ClientID%>").value == "") {
                str = str + "\n Please select vendor name .";
                document.getElementById("<%=txt_VendorName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_ItemName.ClientID%>").value == "") {
                str = str + "\n Please select Item Name.";
                document.getElementById("<%=txt_ItemName.ClientID %>").focus();
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


        function Tab2functionConfirm(event) {
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
                        __doPostBack('<%=Gv_IndentGen.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_IndentGen]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_IndentGen]').footable();

            $('.searchs2').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Gv_IndentGen table tbody tr').each(function () {
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
        function Discount() {
            var TotalAmt = document.getElementById("<%=txt_GdTotalPrice.ClientID%>").value;
            var Discount = document.getElementById("<%=txtdiscount.ClientID%>").value;
            var FormPrice = document.getElementById("<%=txtFormPrice.ClientID%>").value;

            if (+(100) >= +(Discount)) {
                document.getElementById("<%=txtpayable.ClientID%>").value = Math.round(((TotalAmt - (TotalAmt * Discount / 100))) + (+FormPrice)).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=txtDiscountValue.ClientID%>").value = (TotalAmt * Discount / 100).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txtdiscount.ClientID%>").value = 15;
                document.getElementById("<%=txtpayable.ClientID%>").value = Math.round(((TotalAmt - (TotalAmt * 15 / 100))) + (+FormPrice)).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=txtDiscountValue.ClientID%>").value = (TotalAmt * 15 / 100).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Discount amount could not be grater than total Amount.");
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

    </script>
</asp:Content>
