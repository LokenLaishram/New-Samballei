<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StockEntry.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.StockEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Stock&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduInventory/StockEntry.aspx">Stock Entry</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabOrderList"><i class="icon nalika-edit" aria-hidden="true"></i>Work/Purchase Order List</a></li>
                <li><a href="#tabStockEntryList"><i class="icon nalika-picture" aria-hidden="true"></i>Stock Entry Details</a></li>
            </ul>

            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabOrderList">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_OrderType" Text="Order Type"></asp:Label>
                                            <asp:DropDownList ID="ddlOrderType" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label1" Text="Order No"></asp:Label>
                                            <asp:TextBox ID="txtOrderNo" MaxLength="50" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtOrderNo"
                                                ValidChars=" & " FilterType="LowercaseLetters,UppercaseLetters, Numbers,Custom">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlVendorType" runat="server" class="form-control "
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlVendorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txtvendordetail" MaxLength="50" runat="server" class="form-control " OnTextChanged="txtVendorName_OnTextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetVendorDetail"
                                                MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                                CompletionSetCount="1" TargetControlID="txtvendordetail" UseContextKey="True" DelimiterCharacters="">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField ID="hdnvendorid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateFrom" Text="Order Date From"></asp:Label>
                                            <asp:TextBox ID="txtDateFrom" runat="server" class="form-control ">                                                                  
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
                                            <asp:Label runat="server" ID="lbl_DateTo" Text="Order Date To"></asp:Label>
                                            <asp:TextBox ID="txtDateTo" runat="server" class="form-control ">                                                                  
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
                                            <asp:Label runat="server" ID="lblstatus" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlStatus" AutoPostBack="true"
                                                runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnReset_OnClick" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button hidden" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbltotalrecords" Visible="false" runat="server"></asp:Label>
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
                                            <asp:DropDownList ID="ddlShow" AutoPostBack="true" runat="server" class="form-control">
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
                                    <asp:UpdateProgress ID="updateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIV2loading" runat="server" class="Pageloader">
                                                <asp:Image ID="tabimgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <div id="WorkOrderlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvWorkOrderlist" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false" OnRowCommand="GvWorkOrderlist_RowCommand"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.No.">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Order No.</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOrderNo" runat="server" Text='<%# Eval("WorkOrderNo") %>'></asp:Label>
                                                        <asp:Label ID="lblGvSysGenOrderNo" runat="server" Visible="false" Text='<%# Eval("SysGenWorkOrderNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Order Type</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvOrderType" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Press Name</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvVendorID" runat="server" Visible="false" Text='<%# Eval("VendorID") %>'></asp:Label>
                                                        <asp:Label ID="lblGvVendorname" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Printing Mode</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvPrintMode" runat="server" Text='<%# Eval("PrintingMode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Total Copies</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTotalCopies" runat="server" Text='<%# Eval("TotalCopies") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Total Received</HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvTotalReceived" runat="server" Text='<%# Eval("TotalReceived") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Due </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGvDueReceived" runat="server" Text='<%# Eval("DueReceived") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        View
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkGvEdit" class="cus-btn btn-sm btn-indigo button" runat="server"
                                                            CommandName="Print" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-eye"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Entry
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkGvPrint" class="cus-btn btn-sm btn-success button" runat="server"
                                                            CommandName="StockEntry" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-arrow-down"></i>
                                                        </asp:LinkButton>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <%----POP-UP ROW-----%>
                            <div class="row">
                                <asp:ModalPopupExtender ID="WorkOrderPopup" BehaviorID="modalbehavior4" TargetControlID="btn_add" runat="server" PopupControlID="StockEntryPopUpWindow"
                                    BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnclose">
                                </asp:ModalPopupExtender>
                                <asp:Panel runat="server" ID="StockEntryPopUpWindow" CssClass="ModalPopUpPanelBg " Style="display: none; width: 80%; margin-top: -10px;">

                                    <div class="row" style="border-bottom: 0px solid green;">
                                        <div class="col-sm-4">
                                            <h5>Stock Entry With WO/PO </h5>
                                        </div>
                                        <div class="col-md-7 ">
                                            <asp:Label ID="lblpopMessage" runat="server" Style="color: red;"></asp:Label>
                                        </div>
                                        <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                            <asp:LinkButton ID="btnclose" runat="server"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row mt10">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label2" Text="Order Type"></asp:Label>
                                                    <asp:Label runat="server" ID="lblpopOrderTypeID" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtOrderType" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="lblOrderNos" Text="Order No."></asp:Label>
                                                    <asp:Label runat="server" ID="lblpopSysgenOrderNo" Visible="true"></asp:Label>
                                                    <asp:TextBox ID="txtOrdeNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label3" Text="Printing Mode"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPopPrintModeID" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtPrintMode" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="lblVendorName" Text="Vendor/Press Name"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPopVendorTypeID" Visible="false"></asp:Label>
                                                    <asp:Label runat="server" ID="lblpopVendorID" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtPopVendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row">
                                            <div id="OrderItemlist" class="col-md-12  " style="max-height: 580px; overflow: auto;">
                                                <asp:GridView ID="GvpopWorkOrderItemList" AllowPaging="true" AllowCustomPaging="false" EmptyDataText="No record found..."
                                                    CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false"
                                                    Style="width: 100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText=" SL No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Book Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvItemID" runat="server" Visible="false" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                                <asp:Label ID="lblgvItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Size
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvSize" runat="server" Text='<%# Eval("Size")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Pages
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvNoOfPage" runat="server" Text='<%# Eval("NoOfPage")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Copies
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCopies" runat="server" Text='<%# Eval("NoOfCopies")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Received
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvTotalReceived" runat="server" Text='<%# Eval("TotalReceived")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Due
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvIsFullReceived" Visible="false" runat="server" Text='<%# Eval("IsFullReceived")%>'></asp:Label>
                                                                <asp:Label ID="lblgvDueToReceived" runat="server" Text='<%# Eval("DueReceived")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Now Received 
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtgvNowReceived" runat="server" Width="60px" BackColor="#eceeef" Text='<%# Eval("DueReceived")%>'
                                                                    CssClass="gridtextbox" AutoPostBack="true" OnTextChanged="OnQty_TextChanged"></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender TargetControlID="txtgvNowReceived" ID="FilteredTextBoxExtender6"
                                                                    runat="server" ValidChars="0123456789."
                                                                    Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card_wrapper">
                                        <div class="row mt10">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:Label ID="Label16" runat="server" Text="Received Date"></asp:Label>
                                                    <span class="mandatory_field">*</span> <span style="color: #ff0000"></span>
                                                    <asp:TextBox ID="txtReceivedDate" runat="server" class="form-control custextbox" Placeholder="dd/MM/yyyy"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                        TargetControlID="txtReceivedDate" />
                                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtReceivedDate" />
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label6" Text="Total Copies"></asp:Label>
                                                    <asp:TextBox ID="txtgdTotalCopies" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label7" Text="Pre-Total Received"></asp:Label>
                                                    <asp:TextBox ID="txtgdPreTotalReceived" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label9" Text="Total Due"></asp:Label>
                                                    <asp:TextBox ID="txtgdDueToReceived" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label8" Text="Total Now Received"></asp:Label>
                                                    <asp:TextBox ID="txtgdNowReceived" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mt10">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label4" Text="Remark"></asp:Label>
                                                    <asp:TextBox ID="txtRemark" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                                    </asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtRemark"
                                                        ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ">
                                                    </asp:FilteredTextBoxExtender>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:Label runat="server" ID="Label5" Text="Received No."></asp:Label>
                                                    <asp:TextBox ID="txtReceivedNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                                    <asp:Button ID="btnPopSave" class="btn btn-sm btn-success button" runat="server" Text="Save" OnClick="BtnSave_OnClick" />
                                                    <asp:Button ID="btnPopReset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnReset_OnClick" />
                                                    <asp:Button ID="btnPopPrint" class="btn btn-sm btn-indigo button hidden" runat="server" Text="Print" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>
                                <asp:Button ID="btn_add" runat="server" />
                            </div>
                            <%----/POP-UP ROW-----%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <%-------------------Start Second Tab-----------------------%>

                <div class="product-tab-list tab-pane fade" id="tabStockEntryList">

                    <asp:UpdatePanel ID="updatepanelStockentry" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label15" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label17" Text="Order Type"></asp:Label>
                                            <asp:DropDownList ID="ddl2OrderType" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblOrderNo" Text="Order Number"></asp:Label>
                                            <asp:TextBox ID="txt2OrderNo" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl2ReceivedNo" Text="Received No."></asp:Label>
                                            <asp:TextBox ID="txt2ReceivedNo" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:DropDownList ID="ddl2VendorTypeID" Visible="false" runat="server" class="form-control "
                                                AutoPostBack="true" OnSelectedIndexChanged="ddl2VendorTypeID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblVendorName" Text="Vendor/Press Name"></asp:Label>
                                            <asp:TextBox ID="txt2VendorName" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                DelimiterCharacters=""
                                                Enabled="True"
                                                ServicePath="~/Webservices/ItemListAutoSuggession.asmx"
                                                ServiceMethod="GetVendorNameCompletionList"
                                                TargetControlID="txt2VendorName"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="10"
                                                EnableCaching="true"
                                                CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters,UppercaseLetters, Numbers,Custom"
                                                TargetControlID="txt2VendorName" ValidChars=" &.\/:  ">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl2ReceivedDate" Text="Received Date From"></asp:Label>
                                            <asp:TextBox ID="txt2ReceivedDateFrom" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2ReceivedDateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2ReceivedDateFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label10" Text="Received Date To"></asp:Label>
                                            <asp:TextBox ID="txt2ReceivedDateTo" runat="server" class="form-control ">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2ReceivedDateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2ReceivedDateTo" />
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label13" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label14" Text="IsActive"></asp:Label>
                                            <asp:DropDownList ID="ddlStatusID" runat="server" class="form-control ">
                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label12" Text="Received By"></asp:Label>
                                            <asp:DropDownList ID="ddl2ReceivedBy" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btn2search" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btn2Search_Click" />
                                                    <asp:Button ID="btn2Reset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn2Reset_OnClick" />
                                                    <asp:Button ID="btn2Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintStockEntryReceipt()" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btn2search" />
                                                    <asp:PostBackTrigger ControlID="btn2Reset" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lbl2message" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2result" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:LinkButton ID="btn2_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl2_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddl2_show" AutoPostBack="true" runat="server" class="form-control">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="20"> 20 </asp:ListItem>
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> all</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" id="searchs" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:UpdateProgress ID="updateProgress2" runat="server">
                                        <ProgressTemplate>
                                            <div id="tab2DIVloading" runat="server" class="Pageloader">
                                                <asp:Image ID="tab2_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <div id="stockentrylist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_StockReceivedList" AllowPaging="true" AllowCustomPaging="true" OnPageIndexChanging="GvStockReceivedlist_PageIndexChanging"
                                            EmptyDataText="No record found..." runat="server" AutoGenerateColumns="false" Style="width: 100%" OnRowCommand="GvReceivedList_RowCommand"
                                            CssClass="table-bordered table-striped gridviewcss" FooterStyle-BackColor="#3c8dbc" ShowFooter="true" OnRowDataBound="GvReceivedList_OnRowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText=" SlNo.">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                    <FooterStyle BackColor="#3c8dbc" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Received No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblRecNo" runat="server" Text='<%# Eval("ReceivedNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <FooterStyle BackColor="#3c8dbc" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Order No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblOrderNo" runat="server" Text='<%# Eval("WorkOrderNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <FooterStyle BackColor="#3c8dbc" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Vendor Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblVendorID" Visible="false" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                        <asp:Label ID="GvlblVendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="GvlblTotal" runat="server" Text="Total Received"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                    <FooterStyle BackColor="#3c8dbc" ForeColor="White" Font-Bold="true" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Received Qty
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblrecQty" runat="server" Text='<%# Eval("NowReceived")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="GvlblTotalRecQty" runat="server" Text='<%# Eval("TotalNowReceived")%>'></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <FooterStyle BackColor="#3c8dbc" ForeColor="White" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Received By
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblReceivedBy" runat="server" Text='<%# Eval("ReceivedBy")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                    <FooterStyle BackColor="#3c8dbc" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Received Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GvlblReceivedDate" runat="server" Text='<%# Eval("ReceivedDate","{0:dd/MM/yyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <FooterStyle BackColor="#3c8dbc" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Details
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkGvDetails" class="cus-btn btn-sm btn-success button" runat="server"
                                                            CommandName="EDetails" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-eye"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                    <FooterStyle BackColor="#3c8dbc" ForeColor="White" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkGvDelete" class="cus-btn btn-sm btn-success button" runat="server"
                                                            CommandName="EDelete" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-trash-o"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                    <FooterStyle BackColor="#3c8dbc" ForeColor="White" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                        <%----Entry Details POP-UP ROW-----%>
                                        <div class="row">
                                            <asp:ModalPopupExtender ID="PopupEntryDetails" BehaviorID="modalbehavior4" TargetControlID="btnpopEDetails" runat="server" PopupControlID="EntryPopUpPanel"
                                                BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btn2closepopup">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel runat="server" ID="EntryPopUpPanel" CssClass="ModalPopUpPanelBg" Style="display: none; width: 80%; margin-top: -10px;">
                                                <div class="row" style="border-bottom: 0px solid green;">
                                                    <div class="col-sm-4">
                                                        <h5>Stock Received Details</h5>
                                                    </div>
                                                    <div class="col-md-7 ">
                                                        <asp:Label ID="Label27" runat="server" Style="color: red;"></asp:Label>
                                                    </div>
                                                    <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                                        <asp:LinkButton ID="btn2closepopup" runat="server"><i class="fa fa-close" style="color: #ff011c;"> </i></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="card_wrapper">
                                                    <div class="row mt10">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="lbl3popRecNo" Text="Received No"></asp:Label>
                                                                <asp:TextBox ID="txt3popRecNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="lbl3popOrderType" Text="Order Type"></asp:Label>
                                                                <asp:TextBox ID="txt3popOrderType" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="lbl3popOrderNo" Text="Order No."></asp:Label>
                                                                <asp:Label runat="server" ID="lbl3SysgenOrderNo" Text="Order No."></asp:Label>
                                                                <asp:TextBox ID="txt3popOrderNo" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="lbl3popVendorName" Text="Vendor/Press Name"></asp:Label>
                                                                <asp:TextBox ID="txt3popVendorName" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row mt10">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="Label18" Text="Received Date"></asp:Label>
                                                                <asp:TextBox ID="txt3popRecDate" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <asp:Label runat="server" ID="Label19" Text="Received By"></asp:Label>
                                                                <asp:TextBox ID="txt3popRecBy" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                                                </asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="card_wrapper">
                                                    <div class="row mt10">
                                                        <asp:GridView ID="Gv3popEntryDetails" AllowSorting="true" EmptyDataText="No record found..." runat="server"
                                                            AutoGenerateColumns="false" Style="width: 100%" CssClass="table-bordered table-striped gridviewcss" FooterStyle-BackColor="#3c8dbc" ShowFooter="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText=" SlNo.">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex+1%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                                                    <FooterStyle BackColor="#3c8dbc" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Item/Book Name
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Gvlbl3ItemName" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                                    <FooterStyle BackColor="#3c8dbc" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Received Qty
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Gvlbl3recQty" runat="server" Text='<%# Eval("NowReceived")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="Gvlbl3TotalRecQty" runat="server" Text='<%# Eval("TotalNowReceived")%>'>></asp:Label>
                                                                    </FooterTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                                    <FooterStyle BackColor="#3c8dbc" ForeColor="White" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-10"></div>
                                                    <div class="col-md-1">
                                                        <div class="form-group pull-right">
                                                            <asp:Button ID="btn3popPrint" class="btn btn-sm btn-indigo button hidden" runat="server" Text="Print" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <div class="form-group pull-right">
                                                            <asp:Button ID="btn3popClose" class="btn btn-sm btn-danger button" runat="server" Text="Close" OnClick="btnEDetailsPopClose" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Button ID="btnpopEDetails" runat="server" />
                                        </div>
                                        <%----DELETE POP-UP ROW-----%>
                                        <div class="row">
                                            <asp:ModalPopupExtender ID="DeletePopup" BehaviorID="modalbehavior4" TargetControlID="btn2_add" runat="server" PopupControlID="DeletePopUpWindow"
                                                BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btn2close">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel runat="server" ID="DeletePopUpWindow" CssClass="DeleteModel" Style="display: none; width: 80%; margin-top: -10px;">
                                                <div class="row" style="border-bottom: 0px solid green;">
                                                    <div class="col-sm-11">
                                                        <h5>Are you sure to delete work order? If yes, enter remark. </h5>
                                                    </div>
                                                    <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                                        <asp:LinkButton ID="btn2close" runat="server"><i class="fa fa-close" style="color: #ff011c;"> </i></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 ">
                                                        <asp:Label ID="lblDeletePopMessage" runat="server" Style="color: red;"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <asp:TextBox ID="txtPopRNo" Visible="false" runat="server"></asp:TextBox>
                                                            <asp:TextBox ID="txtpopRemark" placeholder="Enter remark..." runat="server" class="form-control"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender TargetControlID="txtpopRemark" ID="FilteredTextBoxExtender8"
                                                                runat="server" ValidChars="(-/.)" FilterType="LowercaseLetters, UppercaseLetters, Numbers, Custom" Enabled="True">
                                                            </asp:FilteredTextBoxExtender>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4"></div>
                                                    <div class="col-md-4">
                                                        <div class="form-group center">
                                                            <asp:Button ID="btnPopDelete" runat="server" class="btn btn-sm btn-success button" Text="Yes" OnClick="BtnPopDelete_OnClick" />
                                                            <asp:Button ID="btnpopClose" class="btn btn-sm btn-danger button" runat="server" Text="No" OnClick="btnDeletePopClose" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Button ID="btn2_add" runat="server" />
                                        </div>
                                        <%----/ DELETE POP-UP ROW-----%>
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
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
                $('#purchaseorderlist table tbody tr').each(function () {
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
                $('#stockentrylist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });


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
            $('[id*=GvWorkOrderlist]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvWorkOrderlist]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#GvWorkOrderlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        //$(function () {
        //    $('[id*=Gv_StockReceivedList]').footable();
        //});
        //var prm = Sys.WebForms.PageRequestManager.getInstance();
        //prm.add_endRequest(function () {

        //    $('[id*=Gv_StockReceivedList]').footable();

        //    $('.searchs').on('keyup', function () {
        //        var searchTerm = $(this).val().toLowerCase();
        //        $('#Gv_StockReceivedList table tbody tr').each(function () {
        //            var lineStr = $(this).text().toLowerCase();
        //            if (lineStr.indexOf(searchTerm) === -1) {
        //                $(this).hide();
        //            } else {
        //                $(this).show();
        //            }
        //        });
        //    });
        //});

        function PrintStockEntryReceipt() {
            objOrderType = document.getElementById("<%= ddl2OrderType.ClientID%>")
            objVendorTypeID = document.getElementById("<%= ddl2VendorTypeID.ClientID %>")
            objvendorid = document.getElementById("<%= hdnvendorid.ClientID %>")
            objReceivedBy = document.getElementById("<%= ddl2ReceivedBy.ClientID %>")
            objOrderNo = document.getElementById("<%= txt2OrderNo.ClientID %>")
            objReceivedNo = document.getElementById("<%= txt2ReceivedNo.ClientID %>")
            objDateFrom = document.getElementById("<%= txt2ReceivedDateFrom.ClientID %>")
            objDateTo = document.getElementById("<%= txt2ReceivedDateTo.ClientID %>")
            window.open("../EduInventory/Reports/ReportViewer.aspx?option=StockEntryReceipt&OrderTypeID=" + objOrderType.value + "&VendorTypeID=" + objVendorTypeID.value + "&VendorID=" + objvendorid.value + "&ReceivedByID=" + objReceivedBy.value + "&WorkOrderNo=" + objOrderNo.value + "&ReceivedNo=" + objReceivedNo.value + "&Datefrom=" + objDateFrom.value + "&Dateto=" + objDateTo.value)
        }
    </script>
</asp:Content>
