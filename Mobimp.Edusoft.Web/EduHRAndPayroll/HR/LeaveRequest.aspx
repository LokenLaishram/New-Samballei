<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="LeaveRequest.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.LeaveRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Employee&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="~/EduHRAndPayroll/HR/LeaveRequest.aspx">Leave Request</a></li>
        </ol>
        <ul id="myTab3" class="tab-review-design">
            <li class="active"><a href="#tabLeaveRequest"><i class="icon nalika-edit" aria-hidden="true"></i>Leave Request</a></li>
            <li><a href="#tabLeaveRequestList"><i class="icon nalika-picture" aria-hidden="true"></i>Leave Request List</a></li>
        </ul>
        <div id="myTabContent" class="tab-content custom-product-edit">
            <div class="product-tab-list tab-pane fade active in" id="tabLeaveRequest">
                <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card_wrapper">
                            <div class="row mt12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                        <asp:Label ID="lblsession" runat="server" Text=" Year"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddlsession" runat="server" class="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group test">
                                        <asp:Label ID="lblmonthID" runat="server" Text="Month"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:ListBox ID="monthlist" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_ItemID" runat="server" Text="Leave Type"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_leavetype" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblRequestNo" runat="server" Text="Leave Request Number"></asp:Label>
                                        <asp:TextBox ID="txtRequestNo" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-sm btn-info button" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnreset" runat="server" Text="Reset" class="btn btn-sm btn-red button" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnReset_Click" />
                                    </div>
                                </div>
                            </div>
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
                        <div class="card_wrapper" id="divsearch" runat="server">
                            <div class="row">
                                <div id="LeaveRequest" class="col-md-12 customRow " style="float: left; min-height: 30vh; width: 100%; overflow: auto">
                                    <asp:GridView ID="GvLeaveRequest" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                        CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                        OnPageIndexChanging="GvLeaveRequest_PageIndexChanging" OnRowDataBound="GvLeaveRequestList_RowDataBound"
                                        Style="width: 100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.No
                                                </HeaderTemplate>
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
                                                    <asp:Label ID="Gv_lblYearID" Visible="false" runat="server" Text='<%# Eval("YearID")%>'></asp:Label>
                                                    <asp:Label ID="Gv_lblYear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Month
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblMonthID" Visible="false" runat="server" Text='<%# Eval("MonthID")%>'></asp:Label>
                                                    <asp:Label ID="Gv_lblMonth" runat="server" Text='<%# Eval("Month")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Day
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblDay" runat="server" Text='<%# Eval("Day")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblDate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Reason
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtreason" Height="20px" class="form-control" runat="server" Text='<%# Eval("Reason")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Check
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Gv_ChkIsLeaveRequest" runat="server" AutoPostBack="true" OnCheckedChanged="Gv_ChkIsLeaveRequest_CheckedChanged"></asp:CheckBox>
                                                    <asp:Label ID="lbl_LeaveStatus" Visible="false" runat="server" Text='<%# Eval("PreviousLeavestatus")%>'></asp:Label>
                                                    <asp:Label ID="Gv_lblHoliday" Visible="false" runat="server" Text='<%# Eval("IsHoliday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row mt12">
                                <div class="col-md-5 customRow">
                                    <div class="form-group pull-right" style="margin-top: 0.8em">
                                        <asp:Label ID="lbl_totalLR" runat="server" Text="Total Leave Request"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <asp:TextBox ID="txt_totalLR" runat="server" Width="100px" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt12">
                                <div class="col-md-8 customRow">
                                    <asp:TextBox ID="txt_remark" placeholder="Enter remarks...." runat="server" TextMode="MultiLine" Style="min-height: 60px;" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em; margin-right: 1px;">
                                        <asp:Button ID="btn_Send" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" runat="server" Text="Send" OnClick="btn_Send_Click" class="btn btn-sm btn-info button" />
                                        <asp:Button ID="btn_Cancel" Visible="false" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" class="btn btn-sm btn-red button" />
                                        <asp:Button ID="btn_Print" runat="server" Text="Print" OnClientClick="return printLeaveRequest()" class="btn btn-sm btn-indigo button" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="product-tab-list tab-pane fade" id="tabLeaveRequestList">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card_wrapper">
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbltab2_leavetype" runat="server" Text="Leave Type"></asp:Label>
                                        <asp:DropDownList ID="tab2_ddlleavetype" AutoPostBack="true" runat="server" class="form-control ">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbldatefrom" runat="server" Text="Date From"></asp:Label>
                                        <asp:TextBox ID="txtdatefrom" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtdatefrom" />
                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbldateto" runat="server" Text="Date To"></asp:Label>
                                        <asp:TextBox ID="txtdateto" runat="server" class="form-control"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txtdateto" />
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateto" />
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="tab2_lblstatus" runat="server" Text="Status"></asp:Label>
                                        <asp:DropDownList ID="tab2_ddlstatus" AutoPostBack="true" runat="server" class="form-control ">
                                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="0">InActive</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="tab2_btnSearch" runat="server" Text="Search" OnClick="tab2_btnSearch_Click" class="btn btn-sm btn-info button" />
                                        <asp:Button ID="tab2_btnCancel" runat="server" OnClick="btn_Cancel_Click" Text="Reset" class="btn btn-sm btn-red button" />
                                        <asp:Button ID="tab2_btnPrint" runat="server" Text="Print" class="btn btn-sm btn-indigo button" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card_wrapper" id="div1" runat="server">
                            <div class="row">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="tab2_lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="tab2_lbltotalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px; visibility: hidden">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="tab2_lblshow" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="tab2_ddlshow" AutoPostBack="true" OnSelectedIndexChanged="tab2_ddlshow_SelectedIndexChanged" runat="server" class="form-control">
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
                                </div>
                                <div id="RequestList" class="col-md-12 customRow" style="float: left; max-height: 38vh; width: 100%; overflow: auto">
                                    <asp:GridView ID="Gv_RequestList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                        CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_RequestList_RowCommand"
                                        Style="width: 100%" OnRowDataBound="Gv_RequestList_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="JavaScript:ItemChildGridview('div<%# Eval("LeaveRequestNo") %>');">
                                                        <img id='imgdiv<%# Eval("LeaveRequestNo") %>' src="../../EduImages/plus.gif" width="20px" />
                                                    </a>
                                                    <div id='div<%# Eval("LeaveRequestNo") %>' style="display: none;">
                                                        <asp:GridView ID="GridChildRecordDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="ID,LeaveRequestNo"
                                                            CssClass="ChildGrid" OnRowDeleting="GridChildRecordDetails_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Sl.No
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        LR No.
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Cgv_lblRNo" runat="server" Text='<%# Eval("LeaveRequestNo") %>'></asp:Label>
                                                                        <asp:Label ID="Cgv_ID" runat="server" Text='<%# Eval("ID")%>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Status
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Cgv_lblStatus" runat="server" Text='<%# Eval("IsApprovedStatus")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        Date
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Cgv_lblRDateon" runat="server" Text='<%# Eval("RequestedDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:ButtonField CommandName="Delete" Text="Delete" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.No
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    LR No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblRequestNo" runat="server" Text='<%# Eval("LeaveRequestNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Leave Type
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblLeaveType" runat="server" Text='<%# Eval("LeaveType")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Requested Date
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lblRequestedDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Reason
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="tab2_GvlblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Remark
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="tab2_GvtxtDeleteRemark" class="form-control" runat="server" Text='<%# Eval("DeleteRemark") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Gv_lbltab2StatusID" Visible="false" runat="server" Text='<%# Eval("IsApproved") %>'></asp:Label>
                                                    <asp:Label ID="tab2_GvStatus" runat="server" Text='<%# Eval("IsApprovedStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Print
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="tab2_GvBtnPrint" runat="server" Text="Print" class="btn btn-sm btn-indigo button" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="Gv_DeleteRequestList" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletes" ValidationGroup="none" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>


        </div>
    </div>

    <script type="text/javascript">     

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#RequestList table tbody tr').each(function () {
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
        function printLeaveRequest() {
            objLRnumber = document.getElementById("<%= txtRequestNo.ClientID %>");

            window.open("../HR/Reports/ReportViewer.aspx?option=LeaveRequest&LeaveRequestNo=" + objLRnumber.value)
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvLeaveRequest]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#RequestList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        var myData = [{ id: 1, label: "Test" }];
        $(".myDropdownCheckbox").dropdownCheckbox({
            data: myData,
            title: "Dropdown Checkbox"
        });

        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../../EduImages/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../../EduImages/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../../EduImages/plus.gif");
            }
        }

    </script>
    <script type="text/javascript" src="<%= ResolveUrl("~/app-assets/multiselectlist/jquery.min.js")%>"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/bootstrap-multiselect.js")%>"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/bootstrap.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/app-assets/multiselectlist/jquery.min.js")%>"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=monthlist]').multiselect({
                includeSelectAllOption: true
            });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(function () {
                $('[id*=monthlist]').multiselect({
                    includeSelectAllOption: true
                });
            });
        });

    </script>
</asp:Content>
