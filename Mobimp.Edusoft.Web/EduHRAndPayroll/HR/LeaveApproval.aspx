<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="LeaveApproval.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.LeaveApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="~/EduHRAndPayroll/HR/LeaveApproval.aspx">Leave Approval</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="card_wrapper">
                        <div class="row">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Session"></asp:Label>
                                    <asp:DropDownList ID="ddlsession" runat="server" class="form-control ">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbltab2_leavetype" runat="server" Text="Leave Type"></asp:Label>
                                    <asp:DropDownList ID="tab2_ddlleavetype" AutoPostBack="true" OnSelectedIndexChanged="tab2_ddlleavetype_SelectedIndexChanged" runat="server" class="form-control ">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbldatefrom" runat="server" Text="Date From"></asp:Label>
                                    <asp:TextBox ID="txtdatefrom" AutoPostBack="true" OnTextChanged="txtdatefrom_TextChanged" runat="server" class="form-control"></asp:TextBox>
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
                                    <asp:TextBox ID="txtdateto" runat="server" AutoPostBack="true" OnTextChanged="txtdateto_TextChanged" class="form-control"></asp:TextBox>
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
                                    <asp:DropDownList ID="tab2_ddlstatus" AutoPostBack="true" OnSelectedIndexChanged="tab2_ddlstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                        <asp:ListItem Value="1">Pending</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Partial Approved</asp:ListItem>
                                        <asp:ListItem Value="4">Rejected</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                    <asp:Button ID="tab2_btnSearch" runat="server" Text="Search" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="tab2_btnSearch_Click" class="btn btn-sm btn-info button" />
                                    <asp:Button ID="tab2_btnCancel" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btn_Cancel_Click" Text="Reset" class="btn btn-sm btn-red button" />
                                    <asp:Button ID="tab2_btnPrint" Visible="false" runat="server" Text="Print" class="btn btn-sm btn-indigo button" />
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
                                                        CssClass="ChildGrid">
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
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
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
                                        <%--                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Print
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="tab2_GvBtnPrint" runat="server" Text="Print" class="btn btn-sm btn-indigo button" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Action
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="Gv_DeleteRequestList" class="btn btn-sm btn-info button" Text="Approve" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Action" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup1"
                            TargetControlID="tab2_btnCancel" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior1">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlPopup1" runat="server" CssClass="ModalPopUpPanel" Style="display: none">
                            <div style="text-align: right;">
                                <asp:LinkButton ID="lnbtnclosePopup1" runat="server" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lbl_1" Text="Requested By"></asp:Label>
                                        <asp:Label ID="lbl_requestedby" runat="server" class="form-control">
                                        </asp:Label>
                                         <asp:Label ID="lbl_eployeeID" Visible="false" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_2" runat="server" Text="Leave Type"></asp:Label>
                                        <asp:Label ID="lbl_leavetype" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_3" runat="server" Text="Requested On"></asp:Label>
                                        <asp:Label ID="lbl_requestedon" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_4" runat="server" Text="Total Requested"></asp:Label>
                                        <asp:Label ID="lbl_totalrequested" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_5" runat="server" Text="LR No."></asp:Label>
                                        <asp:Label ID="lbl_lrnumber" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper">
                                <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 100px; max-height: 200px; overflow-y: auto;">
                                    <asp:GridView ID="gv_leavedeatils" ShowFooter="true" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                        Style="width: 100%" GridLines="None">
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
                                                    <asp:TextBox ID="txtreason" Height="20px" Width="150PX" class="form-control" runat="server" Text='<%# Eval("Reason")%>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                All <asp:CheckBox ID="chekboxall" runat="server" AutoPostBack="true" OnCheckedChanged="chekboxall_CheckedChanged"  onclick="checkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckApprove" onclick="Check_Click(this);"  AutoPostBack="true" OnCheckedChanged="Gv_ChkIsLeaveRequest_CheckedChanged" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_total" runat="server" Text="Total Approved"></asp:Label>
                                        <asp:Label ID="lbl_totalapprove" runat="server" class="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-8 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Remarks"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_remarks" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btn_approve" runat="server" Text="Reject" UseSubmitBehavior="False" class="btn btn-sm btn-info button"  OnClick="btn_approve_Click"/>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

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
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

        function Check_Click(objRef) {

            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "white";
            }
            else {

                //If not checked change back to original color

                if (row.rowIndex % 2 == 0) {

                    //Alternating Row Color

                    row.style.backgroundColor = "white";

                }

                else {

                    row.style.backgroundColor = "white";

                }

            }

            //Get the reference of GridView

            var GridView = row.parentNode;
            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox

                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes

                //are checked check/uncheck Header Checkbox

                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;

                        break;

                    }

                }

            }
            headerCheckBox.checked = checked;
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
</asp:Content>
