<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="VendorDue.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.VendorDue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Sales&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../Sales/VendorDue.aspx">Vendor Due</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabDueList"><i class="icon nalika-edit" aria-hidden="true"></i>Due List</a></li>
                <li><a href="#tabDuePayment"><i class="icon nalika-picture" aria-hidden="true"></i>Due Payment</a></li>
                <li><a href="#tabDuePaymentList"><i class="icon nalika-picture" aria-hidden="true"></i>Due Payment List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabDueList">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_FinancialYear" Text="Financial Year"></asp:Label>
                                            <asp:DropDownList ID="ddl_FinancialYearID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_VendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddl_VendorTypeID" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddl_VendorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="hdnVendorID" />
                                            <asp:HiddenField runat="server" ID="hdnVendorName" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txt_VendorName" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True"
                                                ServiceMethod="GetVendorNameCompletionList" TargetControlID="txt_VendorName" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" CompletionListCssClass="Completion">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_VendorName" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_BillNo" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txt_BillNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_BillNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
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
                                    <div class="col-md-2 customRow">
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
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblStatus" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow"></div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn1reset_Click" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
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
                                        <input type="text" class="searchs form-control" placeholder="search..">
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
                                    <div id="duelist" class="col-md-12 customRow ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="Gv_DueList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnRowCommand="Gv_VendorDue_RowCommand"
                                                    CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv_DueList_RowDataBound"
                                                    Style="width: 100%">
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
                                                                            <asp:BoundField ItemStyle-Width="193px" DataField="GroupName" HeaderText="Item Group Name" />
                                                                            <asp:BoundField ItemStyle-Width="193px" DataField="SubGroupName" HeaderText="Item Sub-Group Name" />
                                                                            <asp:BoundField ItemStyle-Width="293px" DataField="ItemName" HeaderText="Item Name" />
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
                                                                Vendor Name
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblvendorName" runat="server" Text='<%# Eval("VendorName")%>'></asp:Label>
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
                                                                Total Bill
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltotalAmount" runat="server" Text='<%# Eval("GdTotalAmount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Discount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("GdDiscount")%>'></asp:Label>
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
                                                               Total Due Paid
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalDuePaid" runat="server" Text='<%# Eval("TotalDuePaid")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Due Discount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDueDis" runat="server" Text='<%# Eval("TotalDueDiscount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                          <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Due Balance
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDueBalance" runat="server" Text='<%# Eval("DueBalance")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Payment Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblindentdate" runat="server" Text='<%# Eval("AddedDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Details
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Print" class="cus-btn btn-sm btn-success button" Text="Detail" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Pay Due
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_duepay" class="cus-btn btn-sm btn-danger button" Text="Pay Due" runat="server"
                                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="PayDue" ValidationGroup="none" />
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
                            <div class="card_wrapper hidden">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltotalbill" Text="Total Bill"></asp:Label>
                                            <asp:TextBox ID="txtTotalBill" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblDiscount" Text="Total Discount"></asp:Label>
                                            <asp:TextBox ID="txtDiscount" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblnetbill" Text="Total Net-Amount"></asp:Label>
                                            <asp:TextBox ID="txtNetAmount" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblpayable" Text="Total Payable(with Tax%)"></asp:Label>
                                            <asp:TextBox ID="txtpayable" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label6" Text="Total Paid"></asp:Label>
                                            <asp:TextBox ID="txtTotalpaid" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbldue" Text="Total Due"></asp:Label>
                                            <asp:TextBox ID="txtTotalDue" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-------------------Start Second Tab-----------------------%>

                <div class="product-tab-list tab-pane fade" id="tabDuePayment">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblVendorType" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlVendorType2" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="tab2_lblVendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txtVendorName2" MaxLength="50" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:HiddenField ID="hdnVendotID" runat="server" />
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtVendorName2"
                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ& "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblBillNo" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txtBillNo2" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblTotalDuePaid" Text="Total Due Paid"></asp:Label>
                                            <asp:TextBox ID="txtTotalDuePaid" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label4" Text="Due Balance"></asp:Label>
                                            <asp:TextBox ID="txtDueBalance" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3" Text="Discount"></asp:Label>
                                            <asp:TextBox ID="txtDiscount2" onkeyup="return calculate();" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblDuePayable" Text="Due Payable Amount"></asp:Label>
                                            <asp:TextBox ID="txtDuePayable" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblPaidAmount" Text="Paid Amount"></asp:Label>
                                            <asp:TextBox ID="txtDuePaidAmount" onkeyup="return calculate();" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDuePaidAmount"
                                                ValidChars="0987654321"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblDueAmount" Text="Due Amount"></asp:Label>
                                            <asp:TextBox ID="DueBalance" disabled="disabled" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label2" Text="Payment Mode"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_PaymentMode" runat="server" class="form-control custextbox" OnSelectedIndexChanged="ddlpaymentmode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblinvoiceno" Text="Invoice No"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_InvoiceNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_ChequeNo" Text="Cheque No/UTR No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_ChequeNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label8" Text="Bank Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_BankName" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label7" Text="Due Bill No."></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDueBillNo" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label5" Text="Remark"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDueRemark" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnPay" class="btn btn-sm btn-success button" runat="server" Text="Pay" OnClick="DuePay_OnClick" />
                                            <asp:Button ID="btn2Cancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn2Cancel_OnClick" />
                                            <asp:Button ID="btn2Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-------------------Start Third Tab-----------------------%>

                <div class="product-tab-list tab-pane fade" id="tabDuePaymentList">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3FinancialYear" Text="Financial Year"></asp:Label>
                                            <asp:DropDownList ID="ddl3FinancialYear" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="Label10" Text="Vendor Type"></asp:Label>
                                            <asp:DropDownList ID="ddlvendortype3ID" runat="server" class="form-control custextbox"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlvendortype3ID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField runat="server" ID="HiddenField1" />
                                            <asp:HiddenField runat="server" ID="HiddenField2" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3VendorName" Text="Vendor Name"></asp:Label>
                                            <asp:TextBox ID="txt3VendorName" runat="server" class="form-control custextbox"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="True"
                                                ServiceMethod="GetVendorNameCompletionList3" TargetControlID="txt3VendorName" MinimumPrefixLength="1"
                                                CompletionInterval="10" EnableCaching="true"  CompletionListCssClass="Completion" CompletionSetCount="12">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt3VendorName"
                                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ&:0123456789 "></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3BillNo" Text="Bill No."></asp:Label>
                                            <asp:TextBox ID="txt3BillNo" MaxLength="10" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt3BillNo"
                                                ValidChars="0987654321abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"></asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mt10">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3DateFrom" Text="Date From"></asp:Label>
                                            <asp:TextBox ID="txt3DateFrom" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt3DateFrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt3DateFrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3DateTo" Text="Date To"></asp:Label>
                                            <asp:TextBox ID="txt3DateTo" runat="server" class="form-control custextbox">                                                                  
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt3DateTo" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt3DateTo" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl3Status" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddl3Status" runat="server" class="form-control custextbox">
                                                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btn3Search" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btn3Search_Click" />
                                            <asp:Button ID="btn3Cancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn3reset_Click" />
                                            <asp:Button ID="btn3Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lbl3result" runat="server"></asp:Label>
                                        <asp:Label ID="lbl3totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:LinkButton ID="btn3export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl3show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddl3show" AutoPostBack="true" runat="server" class="form-control custextbox">
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
                                    <asp:UpdateProgress ID="updateProgress3" runat="server">
                                        <ProgressTemplate>
                                            <div id="tab3_DIVloading" runat="server" class="Pageloader">
                                                <asp:Image ID="tab3_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                                <div id="duepaymentlist" class="col-md-12 customRow ">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="Gv_DuePaymentList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                                CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_DuePaymentList_RowCommand"
                                                Style="width: 100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText=" SL No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DueBillNo" HeaderStyle-ForeColor="white" SortExpression="DueBillNo" HeaderText="DueBillNo" />
                                                    <asp:BoundField DataField="VendorName" HeaderStyle-ForeColor="white" SortExpression="VendorName" HeaderText="Vendor Name" />
                                                    <asp:BoundField DataField="BillNo" HeaderStyle-ForeColor="white"  SortExpression="BillNo" HeaderText="BillNo" />
                                                    <asp:BoundField DataField="GdDue"  HeaderStyle-ForeColor="white" SortExpression="GdDue" HeaderText="Total Due" />
                                                    <asp:BoundField DataField="LastDuePaid"  HeaderStyle-ForeColor="white" SortExpression="LastDuePaid" HeaderText="LastDuePaid" />
                                                    <asp:BoundField DataField="TotalDueAmount"  HeaderStyle-ForeColor="white" SortExpression="TotalDueAmount" HeaderText="Total Due" />
                                                    <asp:BoundField DataField="DueDiscount"  HeaderStyle-ForeColor="white" SortExpression="DueDiscount" HeaderText="Discount" />
                                                    <asp:BoundField DataField="DuePayable"  HeaderStyle-ForeColor="white" SortExpression="DuePayable" HeaderText="DuePayable" />
                                                    <asp:BoundField DataField="DuePaid"  HeaderStyle-ForeColor="white" SortExpression="DuePaid" HeaderText="Due Paid " />
                                                    <asp:BoundField DataField="DueBalance"  HeaderStyle-ForeColor="white" SortExpression="DueBalance" HeaderText="DueBalance" />
                                                    <asp:BoundField DataField="PaymentModeName"  HeaderStyle-ForeColor="white" SortExpression="PaymentModeName" HeaderText="Payment Mode " />
                                                    <asp:BoundField DataField="AddedBy"  HeaderStyle-ForeColor="white" SortExpression="AddedBy" HeaderText="AddedBy " />
                                                    <asp:BoundField DataField="AddedDate"  HeaderStyle-ForeColor="white" SortExpression="AddedDate" HeaderText="AddedDT " />
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
                                                            <asp:Label ID="lblDueBillNo" Visible="false" runat="server" Text='<%# Eval("DueBillNo")%>'></asp:Label>
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
                                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
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
            if (document.getElementById("<%=ddlVendorType2.ClientID%>").value == "") {
                str = str + "\n Please enter Paid Amount";
                document.getElementById("<%=ddlVendorType2.ClientID %>").focus();
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
            $('[id*=Gv_DueList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_DueList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#duelist table tbody tr').each(function () {
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
            $('[id*=Gv_DueList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_DueList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#duelist table tbody tr').each(function () {
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
    <script type="text/javascript"> 
        function calculate() {

            var TotalAmt = document.getElementById("<%=txtDueBalance.ClientID%>").value;
            var Discount = document.getElementById("<%=txtDiscount2.ClientID%>").value;

            if (+(TotalAmt) >= +(Discount)) {
                document.getElementById("<%=txtDuePayable.ClientID%>").value = (TotalAmt - Discount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=DueBalance.ClientID%>").value = (TotalAmt - Discount).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txtDiscount2.ClientID%>").value = "";
                document.getElementById("<%=txtDuePayable.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=txtDuePaidAmount.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                document.getElementById("<%=DueBalance.ClientID%>").value = (TotalAmt).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Discount amount could not be grater than total Amount.");
            }

            var Payable = document.getElementById("<%=txtDuePayable.ClientID%>").value;
            var Paid = document.getElementById("<%=txtDuePaidAmount.ClientID%>").value;
            if (+(Payable) >= +(Paid)) {
                document.getElementById("<%=DueBalance.ClientID%>").value = (((TotalAmt - Discount)) - Paid).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
            }
            else {
                document.getElementById("<%=txtDuePaidAmount.ClientID%>").value = "";
                document.getElementById("<%=DueBalance.ClientID%>").value = (Payable).toString().match(/^-?\d+(?:\.\d{0,2})?/)[0];
                alert("Paid amount could not be grater than payable amount.");
            }

        }
    </script>
</asp:Content>
