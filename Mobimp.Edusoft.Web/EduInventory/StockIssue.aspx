<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StockIssue.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.StockIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" runat="server" id="a1" href="../EduInventory/StockIssue.aspx">Stock Issue</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabStockIssue"><i class="icon nalika-edit" aria-hidden="true"></i>Stock Issue</a></li>
                <li><a href="#tabStockIssueDetails"><i class="icon nalika-picture" aria-hidden="true"></i>Stock Issue Details</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabStockIssue">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_VendorType" AutoPostBack="true" OnSelectedIndexChanged="ddl_VendorType_SelectedIndexChanged1" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_VendorName" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblitemdetail" runat="server" Text="Item Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox runat="server" AutoPostBack="True" class="form-control" OnTextChanged="txt_ItemName_TextChanged" ID="txt_ItemName"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetItemDetails"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txt_ItemName" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                            <asp:Label ID="lbl_GetItemName" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_ItemID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_UnitID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_UnitName" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_ExpiryDate" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbl_StockNo" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_AvailableQty" Text="Available Quantity"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_AvailableQty" MaxLength="5" disabled="disabled" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_AvailableQty"
                                                ValidChars="0987654321">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_IssueQty" Text="Issue Quantity"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_IssueQty" MaxLength="5" AutoPostBack="true" OnTextChanged="txt_IssueQty_TextChanged" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_IssueQty"
                                                ValidChars="0987654321">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnAdd" OnClientClick="return Validate();" OnClick="btnAdd_Click" class="btn btn-sm btn-success button" runat="server" Text="Add" />
                                        </div>
                                    </div>
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
                                <div id="stockissue" class="col-md-12 customRow ">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="Gv_StockIssue" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                CssClass="footable table-striped" AllowSorting="true" OnRowCommand="Gv_StockIssue_RowCommand" runat="server" AutoGenerateColumns="false"
                                                Style="width: 100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText=" SL No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1%>
                                                            <asp:Label ID="lblGv_StockNo" Visible="false" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                            <asp:Label ID="lblGv_VendorTypeID" Visible="false" runat="server" Text='<%# Eval("VendorTypeID")%>'></asp:Label>
                                                            <asp:Label ID="lblGv_VendorID" Visible="false" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                            <asp:Label ID="lblGv_ItemID" Visible="false" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                            <asp:Label ID="lblGv_UnitID" Visible="false" runat="server" Text='<%# Eval("UnitID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="VendorTypeName" SortExpression="VendorTypeName" HeaderText="Vendor Type Name" />
                                                    <asp:BoundField DataField="VendorName" SortExpression="VendorName" HeaderText="Vendor Name" />
                                                    <asp:BoundField DataField="ItemName" SortExpression="ItemName" HeaderText="Item Name" />
                                                    <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="Unit" />
                                                    <asp:BoundField DataField="TotalAvailableQty" SortExpression="TotalAvailableQty" HeaderText="Available Quantity" />
                                                    <asp:BoundField DataField="IssueQty" SortExpression="IssueQty" HeaderText="Issue Quantity" />
                                                    <asp:BoundField DataField="ExpiryDate" SortExpression="Expirydate" HeaderText="Expiry Date" />
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
                            <div class="row mt10">
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblRemark" Text="Remark"></asp:Label>
                                        <asp:TextBox ID="txtRemark" runat="server" class="form-control ">                                                                  
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" class="btn btn-sm btn-success button" runat="server" Text="Save" />
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" />
                                        <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Visible="false" Text="Print" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-------------------Start Second Tab-----------------------%>

                <div class="product-tab-list tab-pane fade" id="tabStockIssueDetails">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_VendorType" AutoPostBack="true" OnSelectedIndexChanged="ddltab2_VendorType_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_VendorName" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_ItemName" Text="Item Name"></asp:Label>
                                            <asp:TextBox ID="txttab2_ItemName" MaxLength="50" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetItemNameStockIssueAutoTab2" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txttab2_ItemName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" CompletionListCssClass="Completion" 
                                                CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="itemHighlighted">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_DateFrom" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="txttab2_DateFrom" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txttab2_DateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txttab2_DateFrom" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_DateTo" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="txttab2_DateTo" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txttab2_DateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txttab2_DateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltab2_Status" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_Status" runat="server" class="form-control ">
                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btntab2_Search" OnClick="btntab2_Search_Click" class="btn btn-sm btn-info button" runat="server" Text="Search" />
                                            <asp:Button ID="btntab2_Cancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" />
                                            <asp:Button ID="btntab2_Print" class="btn btn-sm btn-indigo button" Visible="false" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lbltab2_result" runat="server"></asp:Label>
                                        <asp:Label ID="lbltab2_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:LinkButton ID="btntab2_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbltab2_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddltab2_show" AutoPostBack="true" runat="server" class="form-control">
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
                                <div id="stockissuelist" class="col-md-12 customRow ">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="Gv_StockIssueDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gv_StockIssueDetails_PageIndexChanging"
                                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnSorting="Gv_StockIssueDetails_Sorting" OnRowCommand="Gv_StockIssueDetails_RowCommand"
                                                Style="width: 100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText=" SL No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Issue No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvTab2_IssueID" Visible="false" runat="server" Text='<%# Eval("IssueID")%>'></asp:Label>
                                                            <asp:Label ID="lblGvTab2_IssueNo" runat="server" Text='<%# Eval("IssueNo")%>'></asp:Label>
                                                            <asp:Label ID="lblGvTab2_StockNo" Visible="true" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="VendorTypeName" SortExpression="VendorTypeName" HeaderText="Vendor Type" />
                                                    <asp:BoundField DataField="VendorName" SortExpression="VendorName" HeaderText="Vendor Name" />
                                                    <asp:BoundField DataField="ItemName" SortExpression="ItemName" HeaderText="Item Name" />
                                                    <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="Unit" />
                                                    <asp:BoundField DataField="IssueQty" SortExpression="IssueQty" HeaderText="Issue Quantity" />
                                                    <asp:BoundField DataField="IssueDate" SortExpression="IssueDate" HeaderText="Issue Date" />
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
                                                            <asp:Button ID="btnGv_Print" class="cus-btn btn-sm btn-indigo button" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                CommandName="Print" ValidationGroup="none" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Delete
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGv_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirms(this); return false;" />
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
            if (document.getElementById("<%=ddl_VendorType.ClientID%>").value == "") {
                str = str + "\n Please select Vendor Type.";
                document.getElementById("<%=ddl_VendorType.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_VendorName.ClientID%>").value == "") {
                str = str + "\n Please select Vendor Name.";
                document.getElementById("<%=ddl_VendorName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_ItemName.ClientID%>").value == "") {
                str = str + "\n Please enter Item Name.";
                document.getElementById("<%=txt_ItemName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_AvailableQty.ClientID%>").value == "") {
                str = str + "\n Available Quantity shouldn't be blank.";
                document.getElementById("<%=txt_AvailableQty.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_IssueQty.ClientID%>").value == "") {
                str = str + "\n Please enter Issue Quantity.";
                document.getElementById("<%=txt_IssueQty.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_StockIssue.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        function functionConfirms(event) {
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
                        __doPostBack('<%=Gv_StockIssueDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        $(function () {
            $('[id*=Gv_StockIssue]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_StockIssue]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#stockissue table tbody tr').each(function () {
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
            $('[id*=Gv_StockIssueDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_StockIssueDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#stockissuelist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#stockissuelist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        $(document).ready(function () {

            $(window).scroll(function () {
                if ($(this).scrollTop() > 50) {
                    $('#back-to-top').fadeIn();
                } else {
                    $('#back-to-top').fadeOut();
                }
            });
            // scroll body to 0px on click
            $('#back-to-top').click(function () {
                $('#back-to-top').tooltip('hide');
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });

            $('#back-to-top').tooltip('show');

        });


    </script>

</asp:Content>
