<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="FeeCollection.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduFees.FeeCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ul id="myTab3" class="tab-review-design">
            <li class="active"><a href="#tapfeecollection"><i class="icon nalika-edit" aria-hidden="true"></i>Fee Payment</a></li>
        </ul>
        <div class="review-tab-pro-inner">
            <div class="product-tab-list tab-pane fade active in" id="tapfeecollection" style="margin-top: -28px;">
                <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card_wrapper">
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsession" runat="server" Text="Year"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged1" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_roll" runat="server" Text="Student ID"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_studentID" AutoPostBack="true" OnTextChanged="txt_student_TextChanged" class="form-control "
                                            runat="server">
                                        </asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            Enabled="True" TargetControlID="txt_studentID" FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblstudentdetail" runat="server" Text="Student Details"></asp:Label>
                                        <asp:TextBox runat="server" AutoPostBack="true" TextMode="MultiLine"
                                            ID="txtstudentanme" OnTextChanged="txtstudentanme_TextChanged" class="form-control"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                            ServiceMethod="Getautostudentlist" MinimumPrefixLength="1"
                                            CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstudentanme"
                                            UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                        </asp:AutoCompleteExtender>
                                        <asp:Label ID="lbl_studentID" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_feetypes" runat="server" Text="Fee Types"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_feetype" AutoPostBack="true" OnSelectedIndexChanged="ddl_feetype_SelectedIndexChanged" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="lbl_freeStatus" Visible="false"
                                            runat="server"> </asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="card_wrapper col-md-8 customRow">
                            <div style="min-height: 61vh; overflow: auto">
                                <asp:UpdateProgress ID="updateProgress6" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading6" runat="server" class="Pageloader ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="GvFeedetails" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false" OnRowDataBound="GvFeedetails_RowDataBound"
                                    HorizontalAlign="Center" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                SL No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Particulars
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                <asp:Label ID="lblmonthID" Visible="false" runat="server" Text='<%# Eval("MonthID") %>'></asp:Label>
                                                <asp:Label ID="lblfeetypeID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID") %>'></asp:Label>
                                                <asp:Label ID="sessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID") %>'></asp:Label>
                                                <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                                <asp:Label ID="lbl_paymenttype" Visible="false" runat="server" Text='<%# Eval("PaymentType") %>'></asp:Label>

                                                <asp:Label ID="lblparticulars" runat="server" Text='<%# Eval("Particulars") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="6%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Amount
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_feetype" Visible="false" runat="server" Text='<%# Eval("FeeType") %>'></asp:Label>
                                                <asp:Label ID="lblfeeamount" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label>
                                                <asp:Label ID="lbl_paymentstatus" Visible="false" runat="server" Text='<%# Eval("PaymentStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fine Amount
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_prepaidDuedate" Visible="false" Text='<%# Eval("PrepaidDueDate")%>' runat="server"></asp:Label>
                                                <asp:Label ID="lbl_postpaidDuedate" Visible="false" Text='<%# Eval("PostpaidDueDate")%>' runat="server"></asp:Label>
                                                <asp:Label ID="lblactualfineamount" Visible="false" Text='<%# Eval("FineAmount", "{0:0#.##}")%>' runat="server"></asp:Label>
                                                <asp:Label ID="lbl_exemptedamount" Visible="false" Text='<%# Eval("ExemptionAmount", "{0:0#.##}")%>' runat="server"></asp:Label>
                                                <asp:Label ID="lbl_discountamount" Visible="false" Text='<%# Eval("DiscountAmount", "{0:0#.##}")%>' runat="server"></asp:Label>
                                                <asp:Label ID="lblcalcfineamount" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Paid On
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_paidon" runat="server" Text='<%# Eval("PaidOn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Check
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkfeestatus" AutoPostBack="true" OnCheckedChanged="chkfeestatus_CheckedChanged" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="bottomFeeCollection" style="min-height: 64.8vh; overflow: auto" class="card_wrapper col-md-4 customRow" runat="server">
                            <div class="row">
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbltotalamount" runat="server" Text="Total Amount  (₹)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_totalamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbltotalexempted" runat="server" Text="Total Exempted  (₹)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_totalexempted"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblgrandfeeamount" runat="server" Text="Grand Fee Amount  (₹)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_grandfeeamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfineamount" runat="server" Text="Fine Amount  (₹)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_totalfineamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblpayableamount" runat="server" Text="Net Amount  (₹)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_netamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbldiscountamount" runat="server" Text="Total Discount (₹)"></asp:Label>
                                        <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txt_discountamount_TextChanged" class="form-control " ID="txt_discountamount"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="txt_filter_roll" runat="server"
                                            Enabled="True" TargetControlID="txt_discountamount" ValidChars="1234567890.">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_payable" runat="server" Text="Payable Amount (₹)"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:Label runat="server" class="form-control" Font-Bold="true" ID="lbl_payableamount"></asp:Label>
                                        <asp:Label runat="server" ID="lblBillID" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Payment Mode"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_paymentmode" class="form-control "
                                            runat="server">
                                            <asp:ListItem Value="3">--select-- </asp:ListItem>
                                            <asp:ListItem Value="0">Offline </asp:ListItem>
                                            <asp:ListItem Value="1">Online </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblto" runat="server" Text="Bill Date"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_billdate" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                            TargetControlID="txt_billdate" />
                                        <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_billdate" />
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group pull-right" style="margin-top: 2em; align-content: center">
                                        <asp:Button ID="btnpay" runat="server" class="btn btn-sm btn-success button" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Pay" OnClick="btnpay_Click" />
                                        <asp:Button ID="btnprint" Visible="false" runat="server" class="btn btn-sm btn-success button" Text="Print" OnClick="btnprint_Click" />
                                        <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" OnClick="btnreset_Click" runat="server" Text="Reset" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../EduImages/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../EduImages/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../EduImages/plus.gif");
            }
        }
    </script>
    <script type="text/javascript">

        $(function () {

            $('[id*=GvstudentDetails]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvstudentDetails]').footable();

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
