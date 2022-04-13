<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="AdmissionFee.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduFees.AdmissionFee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ul id="myTab3" class="tab-review-design">
            <li class="active"><a href="#tapfeecollection"><i class="icon nalika-edit" aria-hidden="true"></i>Admission Fee Payment</a></li>
        </ul>
        <div class="review-tab-pro-inner">
            <div class="product-tab-list tab-pane fade active in" id="tapfeecollection" style="margin-top: -28px;">
                <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card_wrapper">
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Previous Session"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_previuosyear" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_class" runat="server" Text="Class"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_class" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_section" runat="server" Text="Section"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_section" AutoPostBack="true" OnSelectedIndexChanged="ddl_section_SelectedIndexChanged" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="lbl_studentID" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-1 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_roll" runat="server" Text="Roll No."></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_roll" AutoPostBack="true" OnTextChanged="txt_roll_TextChanged" class="form-control "
                                            runat="server">
                                        </asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            Enabled="True" TargetControlID="txt_roll" FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-5 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblstudentdetail" runat="server" Text="Student Details"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txtstddetail"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_feetypes" runat="server" Text="Fee Types"></asp:Label>

                                        <asp:DropDownList ID="ddl_feetype" AutoPostBack="true" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsession" runat="server" Text="Admission for"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged1" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_newclass" runat="server" Text="New Class"></asp:Label>
                                        <asp:Label ID="txt_newclass" class="form-control "
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="New Section"></asp:Label>
                                        <asp:Label ID="txt_newsection" class="form-control "
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="New Roll No."></asp:Label>
                                        <asp:Label ID="txt_newroll" class="form-control "
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_status" runat="server" Text="Prev. Fee Status"></asp:Label>
                                        <asp:Label ID="lbl_freeStatus" class="form-control "
                                            runat="server">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="card_wrapper col-md-12 customRow">
                            <div>
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
                                                <%--  <asp:Label ID="lbladmissiontype" Visible="false" runat="server" Text='<%# Eval("AdmissionType") %>'></asp:Label>
                                                <asp:Label ID="lblstudentypeID" Visible="false" runat="server" Text='<%# Eval("StudentTypeID") %>'></asp:Label>
                                                --%>
                                                <asp:Label ID="lblparticulars" runat="server" Text='<%# Eval("Particulars") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Type
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_feetype" runat="server" Text='<%# Eval("FeeType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Status
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_paymentstatus" runat="server" Text='<%# Eval("PaymentStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fee Amount
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblfeeamount" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
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
                        <div id="bottomFeeCollection" class="card_wrapper col-md-12 customRow" runat="server">
                            <div class="row">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbltotalamount" runat="server" Text="Total Amount (INR)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_totalamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblfineamount" runat="server" Text="Fine Amount (INR)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_totalfineamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblpayableamount" runat="server" Text="Net Amount (INR)"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="txt_payableamount"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbldiscountamount" runat="server" Text="Total Discount (INR)"></asp:Label>
                                        <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txt_discountamount_TextChanged" class="form-control " ID="txt_discountamount"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="txt_filter_roll" runat="server"
                                            Enabled="True" TargetControlID="txt_discountamount" ValidChars="1234567890.">
                                        </asp:FilteredTextBoxExtender>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_payable" runat="server" Text="Payable Amount (INR)"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:Label runat="server" class="form-control"
                                            ID="lbl_payableamount"></asp:Label>
                                        <asp:Label runat="server" ID="lblBillID" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.6em; align-content: center">
                                        <asp:Button ID="btnpay" runat="server" class="btn btn-sm btn-success button" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Pay" OnClick="btnpay_Click" />
                                        <asp:Button ID="btnprint" Visible="false" runat="server" class="btn btn-sm btn-success button" Text="Print" OnClick="btnprint_Click" />
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbllastdate" runat="server" Text="Last Payment Date"></asp:Label>
                                        <asp:Label runat="server" class="form-control"
                                            ID="lbl_lastdateID"></asp:Label>
                                    </div>
                                </div>

                            </div>--%>
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
