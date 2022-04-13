<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WorkOrder.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.WorkOrder" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ol class="breadcrumb">
                    <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
                    <li>Work Order&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a class="active" runat="server" id="a1" href="../WorkOrder/WorkOrder.aspx">Work Order Master</a></li>
                </ol>
                <div id="tabWorkOrder" runat="server">
                    <div class="card_wrapper">
                        <div class="row" style="background-color: ; margin: 0px 0px 0px 0px !important">
                            <div class="col-md-10"></div>
                            <div class="col-md-2">
                                <asp:Button ID="Button5" runat="server" CssClass=" btn-success btn-sm pull-right" Text="Work Order List" OnClick="btntab2_Onclick" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl_orderType" Text="Order Type"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #f00000"></span>
                                    <asp:DropDownList ID="ddlOrderType" runat="server" class="form-control "
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOrderType_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow ">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label2" Text="Template Name"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlOrderTemplateID" runat="server" class="form-control custextbox"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOrderTemplateID_OnSelectedIndexChanged">
                                        <asp:ListItem Value="1">Template-1</asp:ListItem>
                                        <asp:ListItem Value="2">Template-2 </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2 customRow"></div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label8" Text="Work Order No"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtOrderNo" AutoPostBack="true" placeholder="Work Order No." runat="server" class="form-control"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtOrderNo" ID="FilteredTextBoxExtender6"
                                        runat="server" ValidChars="(-/.)" FilterType="LowercaseLetters, UppercaseLetters, Numbers, Custom" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label3" Text="Date of Order "></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtOrderDate" placeholder="Order Date" runat="server" plaseholder="dd/mm/yyyy" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtOrderDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtOrderDate" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label14" Text="To"></asp:Label>
                                    <asp:TextBox ID="txtAddressTitle" runat="server" class="form-control" placeholder="Enter addess title"></asp:TextBox>
                                    <asp:TextBox ID="txtVendorName" runat="server" class="form-control" placeholder="Enter name of the vendor" OnTextChanged="txtVendorName_OnTextChanged"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetVendorDetails"
                                        MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                        CompletionSetCount="1" TargetControlID="txtVendorName" DelimiterCharacters="" UseContextKey="True">
                                    </asp:AutoCompleteExtender>
                                    <asp:HiddenField ID="hdnvendorid" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-2"></div>
                            <div class="col-md-6">
                                <div class="form-group" style="margin-top: 32px;">
                                    <asp:Label runat="server" ID="Label15" Text="Subject"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtSubject" placeholder="Enter subject" Height="35px" TextMode="MultiLine" Rows="4" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <CKEditor:CKEditorControl ID="CKEditorHeader" runat="server" placeholder="Enter subject" BasePath="../app-assets/ckeditorq/"
                                        Toolbar="Basic" ToolbarBasic="|Bold|Italic|Underline|Strike|Superscript|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|FontSize|TextColor|BGColor">
                                    </CKEditor:CKEditorControl>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblitemdetail" runat="server" Text="Item Name"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox runat="server" AutoPostBack="True" class="form-control" OnTextChanged="txtitemdetail_OnTextChanged" ID="txtitemdetail"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" ServiceMethod="GetItemDetails"
                                        MinimumPrefixLength="1" CompletionInterval="10" CompletionListCssClass="Completion"
                                        CompletionSetCount="1" TargetControlID="txtitemdetail" UseContextKey="True" DelimiterCharacters="">
                                    </asp:AutoCompleteExtender>
                                    <asp:HiddenField ID="hdnItemName" runat="server" />
                                    <asp:HiddenField ID="hdnsubgroupid" runat="server" />
                                    <asp:HiddenField ID="hdnitemid" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblsize" runat="server" Text="Size"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox runat="server" class="form-control" ID="txtsize"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtsize" ID="FilteredTextBoxExtender11"
                                        runat="server" ValidChars="1234567890.">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblnoofpage" runat="server" Text="No Of Page"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox runat="server" class="form-control" ID="txtnoofpage"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtnoofpage" ID="FilteredTextBoxExtender9"
                                        runat="server" ValidChars="1234567890.">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblnoofcopy" runat="server" Text="No Of Copy"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox runat="server" class="form-control" ID="txtnoofcopy"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtnoofcopy" ID="FilteredTextBoxExtender10"
                                        runat="server" ValidChars="1234567890.">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblnoissuepaper" runat="server" Text="No Of IssuePaper"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox runat="server" class="form-control" ID="txtnoissuepaper"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtnoissuepaper" ID="FilteredTextBoxExtender12"
                                        runat="server" ValidChars="1234567890.">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group" style="margin-top: 1.8em;">
                                    <asp:Button ID="btnadd" runat="server" class="btn btn-sm btn-success button" Text="Add" OnClick="btnadd_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
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
                                </div>
                            </div>
                            <asp:GridView ID="GvWorkOrder" Visible="false" EmptyDataText="Add Item" AutoGenerateColumns="false"
                                    CssClass="table-bordered table-striped gridviewcss" runat="server" OnRowCommand="GvWorkOrder_RowCommand"
                                    Style="width: 95% !important; border: 1px solid green !important; margin: 5px 0px 0px 0px;">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                SL No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblslno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ItemName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemid" runat="server" Visible="false" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                <asp:Label ID="lblsubgroupid" runat="server" Visible="false" Text='<%# Eval("SubGroupID")%>'></asp:Label>
                                                <asp:Label ID="lblItemname" runat="server" Text='<%# Eval("ItemName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Size">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No Of Page">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfPage" runat="server" Text='<%# Eval("NoOfPage")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No Of Copies">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfCopies" runat="server" Text='<%# Eval("NoOfCopies")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NoOfIssuePaper">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfIssuePaper" runat="server" Text='<%# Eval("NoOfIssuePaper")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Delete
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <CKEditor:CKEditorControl ID="CKEditorFooter" runat="server" BasePath="../app-assets/ckeditorq/"
                                        Toolbar="Basic" ToolbarBasic="|Bold|Italic|Underline|Strike|Superscript|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|FontSize|TextColor|BGColor">
                                    </CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--////////////////////////NNN//////////////////////////////-->

                    <div class="card_wrapper">
                        <div class="row mt-10">
                            <div class="col-md-2 customRow ">
                                <div class="form-group">
                                    <asp:Label ID="Label12" runat="server" Text="Total Copies"></asp:Label>
                                    <asp:TextBox ID="txtTotalCopies" runat="server" MaxLength="100" Class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl_DeliveryDate" Text="Delivery Before Date"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txt_DeliveryDate" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txt_DeliveryDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_DeliveryDate" />
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label9" Text="Printing Mode"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #f00000"></span>
                                    <asp:DropDownList ID="ddlPrintModeID" runat="server" class="form-control ">
                                        <asp:ListItem Value="0">--- Select ---</asp:ListItem>
                                        <asp:ListItem Value="1">Single Color</asp:ListItem>
                                        <asp:ListItem Value="2">Mono Color</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow ">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="System Gen. Order No."></asp:Label>
                                    <asp:TextBox ID="txtSysGenOrderNo" runat="server" MaxLength="100" Class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-8 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbl_description" runat="server" Text="Other Description"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #f00000"></span>
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="100" Class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                    <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" Text="Save" OnClick="btnupdate_Click" />
                                    <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btn_Reset" />
                                    <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print Preview" OnClick="BtnPrint_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <%---------------------Start Second Tab--------------------%>
                <div id="tabWorkOrderlist" runat="server" visible="false">

                    <div class="card_wrapper">
                        <div class="row" style="background-color: ; margin: 0px 0px 0px 0px !important">
                            <div class="col-md-10"></div>
                            <div class="col-md-2">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-sm pull-right" Text="Create New Work Order" OnClick="btntab1_Onclick" />
                            </div>
                        </div>
                        <div class="row mt10">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="tab2_lbl_OrderType" Text="Order Type"></asp:Label>
                                    <asp:DropDownList ID="ddl2OrderType" AutoPostBack="true"
                                        runat="server" class="form-control ">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label11" Text="Order No"></asp:Label>
                                    <asp:TextBox ID="txt2OrderNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txt2OrderNo"
                                        FilterType="LowercaseLetters,UppercaseLetters, Numbers, Custom " ValidChars="&/-(.) " />
                                </div>
                            </div>
                            <div class="col-md-6 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl2VendorName" Text="Vendor Name"></asp:Label>
                                    <asp:TextBox ID="txt2VendorName" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="tab2_FilteredTextBoxExtender" runat="server" TargetControlID="txt2VendorName"
                                        FilterType="LowercaseLetters,UppercaseLetters, Numbers, Custom " ValidChars="&/-(.):# " />
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
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
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label1" Text="Active Status"></asp:Label>
                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true"
                                        runat="server" class="form-control ">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">InActive</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row mt10">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl_DateForm" Text="Date Form"></asp:Label>
                                    <asp:TextBox ID="txt2DateForm" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="tab2_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txt2DateForm" />
                                    <asp:MaskedEditExtender ID="tab2_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2DateForm" />
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl_DateTo" Text="Date To"></asp:Label>
                                    <asp:TextBox ID="txt2DateTo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="tab2_CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txt2DateTo" />
                                    <asp:MaskedEditExtender ID="tab2_MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt2DateTo" />
                                </div>
                            </div>
                            <div class="col-md-8 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                    <asp:Button ID="btn2Search" runat="server" class="btn btn-sm btn-info scus-btn" Text="Search" OnClick="btn2Search_Click" />
                                    <asp:Button ID="btn2Cancel" class="btn btn-sm btn-danger " runat="server" Text="Cancel" OnClick="btn2Reset_OnClick" />
                                    <asp:Button ID="btn2Printlist" Visible="false" class="btn btn-sm btn-indigo " runat="server" Text="Print List" />

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card_wrapper">
                        <div class="row pad15">
                            <div class="col-md-4 customRow" style="margin-top: 13px;">
                                <asp:Label ID="lbl2results" runat="server"></asp:Label>
                                <asp:Label ID="lbl2totalrecords" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                <asp:Label ID="lbl2show" Text="Show" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-1 customRow">
                                <div class="form-group">
                                    <asp:DropDownList ID="dll2Show" AutoPostBack="true" runat="server" class="form-control">
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20"> 20 </asp:ListItem>
                                        <asp:ListItem Value="50"> 50 </asp:ListItem>
                                        <asp:ListItem Value="100"> 100 </asp:ListItem>
                                        <asp:ListItem Value="10000"> all</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <input type="text" class="searchs form-control" placeholder="Advance Search..">
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIV2loading" runat="server" class="Pageloader">
                                            <asp:Image ID="tab2_imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="WorkOrderlist" class="col-md-12 customRow ">
                                <asp:GridView ID="GvWorkOrderlist" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                    CssClass="table-bordered table-striped gridviewcss" runat="server" AutoGenerateColumns="false" OnRowCommand="GvWorkOrderlist_RowCommand"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl. No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="0.6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvOrderNo" runat="server" Text='<%# Eval("WorkOrderNo") %>'></asp:Label>
                                                <asp:Label ID="lbl2GvSysGenOrderNo" runat="server" Visible="false" Text='<%# Eval("SysGenWorkOrderNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvOrderType" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Press Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvVendorID" runat="server" Visible="false" Text='<%# Eval("VendorID") %>'></asp:Label>
                                                <asp:Label ID="lbl2GvVendorname" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Copies">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvTotalCopies" runat="server" Text='<%# Eval("TotalCopies") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Printing Mode">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvPrintMode" runat="server" Text='<%# Eval("PrintingMode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvOrderDate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delivery Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2GvDeliveryDate" runat="server" Text='<%# Eval("DeliverDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGvEdit" class="cus-btn btn-sm btn-indigo button" runat="server"
                                                    CommandName="lnkEdit" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGvPrint" class="cus-btn btn-sm btn-success button" runat="server"
                                                    CommandName="Print" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                           <i class="fa fa-print"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="0.3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkGvDelete" class="cus-btn btn-sm btn-danger button" runat="server"
                                                    CommandName="Deletes" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                            <i class="fa fa-trash-o"></i>
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
                        <asp:ModalPopupExtender ID="DeletePopup" BehaviorID="modalbehavior4" TargetControlID="btn4_add" runat="server" PopupControlID="PaymentPopUpWindow"
                            BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnclose">
                        </asp:ModalPopupExtender>
                        <asp:Panel runat="server" ID="PaymentPopUpWindow" CssClass="DeleteModel" Style="display: none; width: 80%; margin-top: -10px;">
                            <div class="row" style="border-bottom: 0px solid green;">
                                <div class="col-sm-11">
                                    <h5>Are you sure to delete work order? If yes, enter remark. </h5>
                                </div>
                                <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                                    <asp:LinkButton ID="btnclose" runat="server"><i class="fa fa-close" style="color: #ff011c;"> </i></asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 ">
                                    <asp:Label ID="lblpopMessage" runat="server" Style="color: red;"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPopWONo" Visible="false" runat="server"></asp:TextBox>
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
                        <asp:Button ID="btn4_add" runat="server" />
                    </div>
                    <%----/POP-UP ROW-----%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
                        __doPostBack('<%=GvWorkOrder.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
    </script>
</asp:Content>
