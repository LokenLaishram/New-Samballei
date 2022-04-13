<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ManualAttendance.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.ManualAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" >Manual Attendance</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSession" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtDate" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate" />
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
                                <asp:DropDownList ID="ddl_employee" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" class="btn btn-sm btn-info button"  UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnSearch_Click" runat="server" Text="Search" />
                                <asp:Button ID="btnReset" Visible="false" class="btn btn-sm btn-danger button" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnReset_Click" Text="Reset" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card_wrapper" id="divsearch" runat="server">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_export" runat="server" OnClick="btn_export_Click"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                            <asp:UpdateProgress ID="updateProgress1" runat="server">
                                <ProgressTemplate>
                                    <div id="DIVloading" runat="server" class="Pageloader">
                                        <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                            AlternateText="Loading ..." ToolTip="Loading ..." />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>

                        <div id="AttendanceList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvAttendanceList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" OnPageIndexChanging="GvAttendanceList_PageIndexChanging" OnRowDataBound="GvAttendanceList_RowDataBound">
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
                                            Employee
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblEmployeeID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYearID" Visible="false" runat="server" Text='<%# Eval("YearID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblMonthID" Visible="false" runat="server" Text='<%# Eval("MonthID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblDate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}")%>'></asp:Label>
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
                                            Shift
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_shift" runat="server" Text='<%# Eval("ShifTime")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            In Out Time
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="lbl_inouttime" runat="server" class="form-control" Text='<%# Eval("ShifTime")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Attendance
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblAttendanceID" Visible="false" runat="server" Text='<%# Eval("AttendanceStatusID")%>'></asp:Label>
                                            <asp:DropDownList ID="Gv_ddlAttendance" Class="form-control" runat="server">
                                                <asp:ListItem Value="1">Present</asp:ListItem>
                                                <asp:ListItem Value="2">Absent</asp:ListItem>
                                                <asp:ListItem Value="3">Leave</asp:ListItem>
                                                <asp:ListItem Value="4">Half Day</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Reason
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtReason" runat="server" class="form-control" Text='<%# Eval("Reason")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnUpdate" class="btn btn-sm btn-success button" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnUpdate_Click" runat="server" Text="Update" />
                                <asp:Button ID="btnPrint" Visible="false" class="btn btn-sm btn-indigo button"  runat="server" Text="Print" OnClientClick="return PrintManualAttendance();" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">       
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AttendanceList table tbody tr').each(function () {
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

       
        function PrintManualAttendance() {
            objacademicID = document.getElementById("<%= ddlSession.ClientID %>")
            objDate = document.getElementById("<%= txtDate.ClientID %>")

            window.open("../HR/Reports/ReportViewer.aspx?option=ManualAttendance&SessionID=" + objacademicID.value + "&Date=" + objDate.value)
        }

        $(function () {
            $('[id*=GvAttendanceList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvAttendanceList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AttendanceList table tbody tr').each(function () {
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
