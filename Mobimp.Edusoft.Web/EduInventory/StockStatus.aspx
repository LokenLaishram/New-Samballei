<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StockStatus.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.StockStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Stock Status&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Stock/StockStatus.aspx">Stock Status</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li id="Tap1" class="active" runat="server"><a href="#tabstockstatus"><i class="icon nalika-edit" aria-hidden="true"></i>Stockwise Stock Status</a></li>
                <li id="Tap2" runat="server"><a href="#tabitemwiselist"><i class="icon nalika-picture" aria-hidden="true"></i>Itemwise Stock Status</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabstockstatus">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor/Press Name"></asp:Label>
                                            <asp:DropDownList ID="ddl_VendorName" runat="server" class="form-control custextbox ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label8" Text="Item Sub-Group"></asp:Label>
                                            <asp:DropDownList ID="ddlSubGroupID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubGroupID_SelectedIndexChanged" class="form-control custextbox ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_item" Text="Item/Book Name"></asp:Label>
                                            <asp:TextBox ID="txtItemName" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnTextChanged="txtItemName_OnTextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetItemName"
                                                MinimumPrefixLength="1" CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtItemName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" >
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnitemid1" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateFrom" Text="Received Date From"></asp:Label>
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
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_DateTo" Text="Received Date To"></asp:Label>
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
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_StockStatus" Text="Stock Status"></asp:Label>
                                            <asp:DropDownList ID="ddlStockStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1" Text="Open"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Close"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Condemn"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnReset_Click" />
                                            <asp:Button ID="btnPrint" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
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
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> all</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control custextbox" placeholder="search..">
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
                                    <div id="stockstatuslist" class="col-md-12 GridOverflow">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_StockStatus" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gv_StockStatus_PageIndexChanging"
                                                    CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnSorting="Gv_StockStatus_Sorting"
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
                                                                Recieved
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetRecievedQty" Visible="true" runat="server" Text='<%# Eval("RecievedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sold
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIssuedQty" Visible="true" runat="server" Text='<%# Eval("IssuedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Return
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReturnQty" Visible="true" runat="server" Text='<%# Eval("ReturnQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Condemn
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCondemnQty" Visible="true" runat="server" Text='<%# Eval("CondemnQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Balance
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetBalanceQty" Visible="true" runat="server" Text='<%# Eval("NetBalanceQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Indent
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetIndentQty" Visible="true" runat="server" Text='<%# Eval("NetIndentQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Entry Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEntryDate" Visible="true" runat="server" Text='<%# Eval("RecievedDT","{0:dd/MM/yyyy}")%>'></asp:Label>
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
                                <div class="row" style="margin: 6px 0px 0px 0px; border-top: 1px solid green;">
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label1" Text="Total Received Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txtGdReceivedQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label2" Text="Total Issue Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txtGdIssuedQty"></asp:Label>
                                    </div>

                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label3" Text="Total Return Qty :"></asp:Label>

                                        <asp:Label runat="server" ID="txtGdReturnQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label4" Text="Total Condemn Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txtGdCondemnQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label5" Text="Total Balance Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txtGdBalanceQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label6" Text="Total Indent Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txtGdIndentQty"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="product-tab-list tab-pane fade   " id="tabitemwiselist">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow hidden">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label10" Text="Vendor Name"></asp:Label>
                                            <asp:DropDownList ID="ddl2VendorNameID" runat="server" class="form-control custextbox" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label12" Text="Sub-Group"></asp:Label>
                                            <asp:DropDownList ID="ddl2SubGroupID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl2SubGroupID_SelectedIndexChanged" class="form-control custextbox ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label13" Text="Item/Book Name"></asp:Label>
                                            <asp:TextBox ID="txt2ItemName" MaxLength="100" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnTextChanged="txt2ItemName_OnTextChanged"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetItemNametab2" 
                                                MinimumPrefixLength="1" CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt2ItemName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnitemid2" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label14" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="txt2FromDate" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2FromDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2FromDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label15" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="txt2ToDate" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt2ToDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2ToDate" />
                                            <asp:HiddenField runat="server" ID="hdnuserlogin"/>
                                        </div>
                                    </div>
                                   
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-9"></div>
                                    <div class="col-md-3 customRow hidden">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label16" Text="Stock Status"></asp:Label>
                                            <asp:DropDownList ID="ddl2StockStatusID" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1" Text="Open"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Close"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Condemn"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btn2Search" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btn2Search_OnClick" />
                                            <asp:Button ID="btn2Reset" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn2Reset_Click" />
                                            <asp:Button ID="btn2Print" Visible="true" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintItemwiseStockStatus()" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lbl2result" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div>
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIV2loading" runat="server" class="Pageloader">
                                                    <asp:Image ID="img2UpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="ItemWiseStatuslist" class="col-md-12 GridOverflow">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GvItemwiseStatus" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvItemwiseStatus_PageIndexChanging"
                                                    CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false"
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
                                                                Class Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2SubGroupName" Visible="true" runat="server" Text='<%# Eval("SubGroupName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Book Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2BookName" Visible="true" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Unit
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2CUnitName" Visible="true" runat="server" Text='<%# Eval("CUnitName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Recieved
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2NetRecievedQty" Visible="true" runat="server" Text='<%# Eval("RecievedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sold
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2IssuedQty" Visible="true" runat="server" Text='<%# Eval("IssuedQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Return
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2ReturnQty" Visible="true" runat="server" Text='<%# Eval("ReturnQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Condemn
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2CondemnQty" Visible="true" runat="server" Text='<%# Eval("CondemnQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Balance
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2NetBalanceQty" Visible="true" runat="server" Text='<%# Eval("NetBalanceQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Indent
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl2NetIndentQty" Visible="true" runat="server" Text='<%# Eval("NetIndentQty")%>'></asp:Label>
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
                                <div class="row" style="margin: 6px 0px 0px 0px; border-top: 1px solid green; font-weight: bold;">
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label20" Text="Total Received Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdReceivedQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label22" Text="Total Issue Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdIssuedQty"></asp:Label>
                                    </div>

                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label24" Text="Total Return Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdReturnQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label26" Text="Total Condemn Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdCondemnQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label28" Text="Total Balance Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdBalanceQty"></asp:Label>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label runat="server" ID="Label30" Text="Total Indent Qty :"></asp:Label>
                                        <asp:Label runat="server" ID="txt2GdIndentQty"></asp:Label>
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
                $('#stockstatuslist table tbody tr').each(function () {
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
                        __doPostBack('<%=Gv_StockStatus.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }


        $(function () {
            $('[id*=Gv_StockStatus]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_StockStatus]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#stockstatuslist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });
        
        function PrintItemwiseStockStatus() {
            objfrom = document.getElementById("<%= txt2FromDate.ClientID%>")
            objto = document.getElementById("<%= txt2ToDate.ClientID %>")
            objhdnuserlogin = document.getElementById("<%= hdnuserlogin.ClientID %>")
            window.open("../EduInventory/Reports/ReportViewer.aspx?option=ItemWiseStockStatus&Datefrom=" + objfrom.value + "&Dateto=" + objto.value + "&UserLoginID=" + objhdnuserlogin.value )
        }
    </script>

</asp:Content>
