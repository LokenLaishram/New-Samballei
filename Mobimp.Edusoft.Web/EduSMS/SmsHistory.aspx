<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SmsHistory.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduSMS.SmsHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>SMS&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="../EduSMS/SMSTemplateManager.aspx">SMS Template Manager</a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a6" href="../EduSMS/EduSMSmanager.aspx">Send SMS </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a3" href="../EduSMS/SmsHistory.aspx">SMS History</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblAcademicID" runat="server" Text="Academic Year"></asp:Label>
                                <asp:DropDownList ID="ddlAcademicID" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSmsID" runat="server" Text="SMS ID"></asp:Label>
                                <asp:TextBox ID="txtSmsID" runat="server" class="form-control" MaxLength="8"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="txtSmsID_AutoCompleteExtender" runat="server"
                                    ServiceMethod="GetSmsID" MinimumPrefixLength="1" CompletionInterval="100"
                                    CompletionSetCount="1" TargetControlID="txtSmsID" UseContextKey="True"
                                    DelimiterCharacters="" Enabled="True" ServicePath="">
                                </asp:AutoCompleteExtender>
                                <asp:FilteredTextBoxExtender TargetControlID="txtSmsID" ID="FilteredTextBoxExtender1"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSendTo" runat="server" Text="Sent To"></asp:Label>
                                <asp:DropDownList ID="ddlSendTo" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSendTo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSmsType" runat="server" Text="SMS Type"></asp:Label>
                                <asp:DropDownList ID="ddlSmsType" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSmsType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="10" Selected="True">-- Select --</asp:ListItem>
                                    <asp:ListItem Value="1">Sent</asp:ListItem>
                                    <asp:ListItem Value="2">Delivered</asp:ListItem>
                                    <asp:ListItem Value="3">Partial</asp:ListItem>
                                    <asp:ListItem Value="0">Failed</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblSentBy" runat="server" Text="Sent By"></asp:Label>
                                <asp:DropDownList ID="ddlSentBy" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSentBy_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblDateFrom" runat="server" Text="Date From"></asp:Label>
                                <asp:TextBox ID="txtDateFrom" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txtDateFrom_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtDateFrom" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDateFrom" />
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblDateTo" runat="server" Text="Date To"></asp:Label>
                                <asp:TextBox ID="txtDateTo" runat="server" class="form-control " AutoPostBack="true" OnTextChanged="txtDateTo_TextChanged"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtDateTo" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDateTo" />
                            </div>
                        </div>
                        <div class="col-md-6 customRow" style="text-align: right;margin-top:1.7em">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-blue button " OnClientClick="return Validates();"
                                    OnClick="btnSearch_Click" Text="Search" />
                                <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                <asp:Button ID="btnPrintList" class="btn btn-sm btn-success button" runat="server" Text="Print" OnClientClick="return PrintSmsHistory();" />
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
                                    <asp:LinkButton ID="btn_export" Visible="true" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                        <div class="col-md-2 customRow">

                        </div>
                        <div class="col-md-4 customRow" style="text-align:right">
                            <input type="text" class="searchs form-control" placeholder="search..">
                        </div>
                    </div>
                    <div class="row">
                        <div>
                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading7" runat="server" class="Pageloader ">
                                    <asp:Image ID="imgUpdateProgress1" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        </div>
                        <div id="SmsList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvSmsHistory" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvSmsHistory_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvSmsHistory_Sorting" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" GridLines="None" OnRowDataBound="GvSmsHistory_RowDataBound" >
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="150px">
                                        <HeaderTemplate>View</HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="JavaScript:ItemChildGridview('div<%# Eval("SmsID") %>');">
                                                <img alt="View" id="imgdiv<%# Eval("SmsID") %>" src="../EduImages/plus.gif" />
                                            </a>
                                            <div id="div<%# Eval("SmsID") %>" style="display: none;">
                                                <asp:GridView ID="GridStudentChild" runat="server" AutoGenerateColumns="false" DataKeyNames="SmsID"
                                                    CssClass="footable table-sm" HeaderStyle-BackColor="WhiteSmoke" BackColor="#ccffff" AlternatingRowStyle-BackColor="#ffffcc">
                                                    <Columns>
                                                        <asp:BoundField DataField="SmsID" HeaderText="SMS ID" ItemStyle-Width="1%" Visible="false" />
                                                        <asp:BoundField DataField="ResponseID" HeaderText="Response ID" ItemStyle-Width="1%" />
                                                        <asp:BoundField DataField="RecipientUniqueID" HeaderText="Student ID" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="RecipientName" HeaderText="Student Name" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="ClassName" HeaderText="Class" ItemStyle-Width="1%" ItemStyle-HorizontalAlign="Center"/>
                                                        <asp:BoundField DataField="SectionName" HeaderText="Sec" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="RollNo" HeaderText="Roll No" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="FatherName" HeaderText="Father Name" ItemStyle-Width="3%"/>
                                                        <asp:BoundField DataField="MotherName" HeaderText="Mother Name" ItemStyle-Width="3%"/>
                                                        <asp:BoundField DataField="DeliveredSMS" HeaderText="SMS Sent" ItemStyle-Width="20%" Visible="true"/>
                                                        <asp:BoundField DataField="SmsCost" HeaderText="SMS Cost" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="SentDate" visible="false" HeaderText="Date Sent" ItemStyle-Width="1%" DataFormatString="{0:dd-MM-yyyy}"/>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="GridEmpChild" runat="server" AutoGenerateColumns="false" DataKeyNames="SmsID"
                                                    CssClass="footable table-sm" HeaderStyle-BackColor="WhiteSmoke" BackColor="#ccffff" AlternatingRowStyle-BackColor="#ffffcc">
                                                    <Columns>
                                                        <asp:BoundField DataField="SmsID" HeaderText="SMS ID" Visible="false" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="ResponseID" HeaderText="Response ID" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="RecipientUniqueID" HeaderText="Employee ID" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="RecipientName" HeaderText="Employee Name" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="DesignationName" HeaderText="Designation" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="StaffTypeName" HeaderText="StaffType" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="DeliveredSMS" HeaderText="SMS Sent" ItemStyle-Width="20%" Visible="true"/>
                                                        <asp:BoundField DataField="SmsCost" HeaderText="SMS Cost" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="1%"/>
                                                        <asp:BoundField DataField="SentDate" HeaderText="Date Sent" Visible="false" ItemStyle-Width="1%" DataFormatString="{0:dd-MM-yyyy}"/>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Sl No</HeaderTemplate>
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SmsID" SortExpression="SmsID" HeaderText="SMS ID" ItemStyle-Width="1%"/>
                                    <asp:TemplateField>
                                        <HeaderTemplate>SMS Template</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSmsDesc" visible="false" runat="server" Text='<%# Eval("Descriptions") %>'></asp:Label>
                                            <asp:Label ID="lblSmsTemplate" runat="server" Text='<%# Eval("Template") %>'></asp:Label>
                                            <asp:Label ID="lblSMSID" Visible="false" runat="server" Text='<%# Eval("SmsID") %>'></asp:Label>
                                            <asp:Label ID="lblSentToID" Visible="false" runat="server" Text='<%# Eval("SendTo") %>'></asp:Label>
                                            <asp:Label ID="lblSmsTypeID" Visible="false" runat="server" Text='<%# Eval("SmsTypeID") %>'></asp:Label>
                                            <asp:Label ID="lblAcademicID" runat="server" Visible="false" Text='<%# Eval("AcademicSessionID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SentToDesc" SortExpression="SentToDesc" HeaderText="Sent To" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="SmsTypeDesc" SortExpression="SmsTypeDesc" HeaderText="SMS Type" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="RecipientCount" SortExpression="RecipientCount" HeaderText="No of Recipients" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="TotalSmsCost" SortExpression="TotalSmsCost" HeaderText="Total SMS Cost" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="BalanceAfter" SortExpression="BalanceAfter" HeaderText="SMS Balance" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="HeaderStatus" SortExpression="HeaderStatus" HeaderText="Status" ItemStyle-Width="1%" />
                                    <asp:BoundField DataField="SentDate" SortExpression="SentDate" HeaderText="Date Sent" ItemStyle-Width="1%" DataFormatString="{0:dd-MM-yyyy}"/>
                                    <asp:BoundField DataField="SentBy" SortExpression="SentBy" HeaderText="Sent By" ItemStyle-Width="1%" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Print
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="javascript: void(null);" onclick="PrintFullSmsHistory('<%# Eval("SmsID")%>','<%# Eval("SendTo")%>','<%# Eval("SmsTypeID")%>','<%# Eval("AcademicSessionID")%>'); return false;" style="color:darkslategrey" class="cus-btn btn-sm btn-yellow button">Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="0.1%" />
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
    <script type="text/javascript">
        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../EduImages/plus.gif")
            {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../EduImages/minus.gif");
            }
            else
            {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../EduImages/plus.gif");
            }
        }
    </script>
    <script type="text/javascript">

        function PrintSmsHistory() {
            objAcademicSessionID = document.getElementById("<%= ddlAcademicID.ClientID %>")
            objSmsID = document.getElementById("<%= txtSmsID.ClientID %>")
            objSentToID = document.getElementById("<%= ddlSendTo.ClientID %>")
            objSmsTypeID = document.getElementById("<%= ddlSmsType.ClientID %>")
            objStatusID = document.getElementById("<%= ddlStatus.ClientID %>")
            objSentByID = document.getElementById("<%= ddlSentBy.ClientID %>")
            objDateFrom = document.getElementById("<%= txtDateFrom.ClientID %>")
            objDateTo = document.getElementById("<%= txtDateTo.ClientID %>")

            window.open("../EduSmS/Reports/ReportViewer.aspx?option=SmsHistory&AcademicSessionID=" + objAcademicSessionID.value + "&SmsID=" + objSmsID.value + "&SentToID=" + objSentToID.value + "&SmsTypeID=" + objSmsTypeID.value + "&StatusID=" + objStatusID.value + "&SentByID=" + objSentByID.value + "&DateFrom=" + objDateFrom.value + "&DateTo=" + objDateTo.value)
        }
        function PrintFullSmsHistory(SmsID, SendTo, SmsTypeID, AcademicSessionID) {
            if (SendTo == 1) {
                window.open("../EduSmS/Reports/ReportViewer.aspx?option=SpecificStudentSmsHistory&SmsID=" + SmsID + "&SendToID=" + SendTo + "&SmsTypeID=" + SmsTypeID + "&AcademicSessionID=" + AcademicSessionID)
            }
            else {
                window.open("../EduSmS/Reports/ReportViewer.aspx?option=SpecificEmployeeSmsHistory&SmsID=" + SmsID + "&SendToID=" + SendTo + "&SmsTypeID=" + SmsTypeID + "&AcademicSessionID=" + AcademicSessionID)
            }
        }

        $(function () {

            $('[id*=GvSmsHistory]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvSmsHistory]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Studentlist table tbody tr').each(function () {
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
