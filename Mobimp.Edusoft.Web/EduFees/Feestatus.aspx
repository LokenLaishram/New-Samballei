<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Feestatus.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduFees.Feestatus1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fees &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="activepage" class="active" href="../EduFees/FeesStatus.aspx">Fee Status </a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsections" AutoPostBack="true" OnSelectedIndexChanged="ddlsections_SelectedIndexChanged" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrollNo" Text="Roll No"></asp:Label>
                                <asp:TextBox ID="txtrollNo" AutoPostBack="true" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_feetype" runat="server" Text="Fee Type"></asp:Label>
                                <asp:DropDownList ID="ddl_feetype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_feetype_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_collectedby" Text="Collected By"></asp:Label>
                                <asp:DropDownList ID="ddl_collectedby" AutoPostBack="true" OnSelectedIndexChanged="ddl_collectedby_SelectedIndexChanged" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Payment Mode"></asp:Label>
                                <asp:DropDownList ID="ddl_paymentmode" AutoPostBack="true" OnSelectedIndexChanged="ddl_paymentmode_SelectedIndexChanged" runat="server" class="form-control ">
                                    <asp:ListItem Value="3">--select-- </asp:ListItem>
                                    <asp:ListItem Value="0">Offline </asp:ListItem>
                                    <asp:ListItem Value="1">Online </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Admission Type"></asp:Label>
                                <asp:DropDownList ID="ddl_admissiontype" AutoPostBack="true" OnSelectedIndexChanged="ddl_admissiontype_SelectedIndexChanged" runat="server" class="form-control ">
                                    <asp:ListItem Value="0">--select-- </asp:ListItem>
                                    <asp:ListItem Value="1">New </asp:ListItem>
                                    <asp:ListItem Value="2">Old </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_from" Text="Date From"></asp:Label>
                                <asp:TextBox ID="txt_from" MaxLength="3" AutoPostBack="true" OnTextChanged="txt_from_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txt_from" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_from" />
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_to" Text="Date To"></asp:Label>
                                <asp:TextBox ID="txt_to" MaxLength="3" AutoPostBack="true" OnTextChanged="txt_to_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txt_to" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_to" />
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_status" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddl_status" AutoPostBack="true" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged" runat="server" class="form-control ">
                                    <asp:ListItem Value="1">Active </asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" OnClick="btnprint_Click" Text="Print" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btncancel_Click" Text="Reset" />
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
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                    <div>
                        <asp:UpdateProgress ID="updateProgress6" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading6" runat="server" class="Pageloader ">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div id="BillList">
                            <asp:GridView ID="GvFeedetails" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                AutoGenerateColumns="False" AllowPaging="true" AllowCustomPaging="true" Width="100%" OnRowCommand="GvFeedetails_RowCommand" AllowSorting="true" OnSorting="GvClassDetails_Sorting" OnPageIndexChanging="GvFeedetails_PageIndexChanging" class="grid" HeaderStyle-Height="45px"
                                HorizontalAlign="Center" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            SL No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                <%--    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_admissiontype" Font-Bold="true" runat="server" Text='<%# Eval("AdmissionType")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Bill No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_billno" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                            <asp:Label ID="lblstudentID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>

                                            <asp:Label ID="lblsessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Bill Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_bildate" runat="server" Text='<%# Eval("Billdatetime")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Pay Mode
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaymode" runat="server" Text='<%# Eval("Paymode")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname"  Font-Bold="true"  runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Particulars
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_particulars" Font-Bold="true" runat="server" Text='<%# Eval("Particulars")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totalamount" runat="server" Font-Bold="true" Text='<%# Eval("TotalFeeAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Exempted Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_exempted" runat="server" Text='<%# Eval("TotalExemptedAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Fine Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fine" runat="server" Text='<%# Eval("TotalFineAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Disc. Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_dic" runat="server" Text='<%# Eval("TotalDiscountAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Paid Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_paid" runat="server" Font-Bold="true" Text='<%# Eval("TotalPaidAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Collected By
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_collectedby" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="lbl_remark" Width="50px" Height="20px" runat="server" class="form-control" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Text="Delete" runat="server"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Print
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_print" class="cus-btn btn-sm btn-indigo" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Text="Print" runat="server"
                                                CommandName="Print" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            Upload Reciept
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_view" Visible="false" class="cus-btn btn-sm btn-indigo" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Text="View" runat="server"
                                                CommandName="View" ValidationGroup="none" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-3 customRow">
                        <div class="form-group">
                            <asp:Label ID="lbl_totalamount" BackColor="#3366cc" ForeColor="White" runat="server" class="form-control ">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="col-md-2 customRow">
                        <div class="form-group">
                            <asp:Label ID="lbl_totalexempted" BackColor="#3366cc" ForeColor="White" runat="server" class="form-control ">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="col-md-2 customRow">
                        <div class="form-group">
                            <asp:Label ID="lbl_totalfine" BackColor="#3366cc" ForeColor="White" runat="server" class="form-control ">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="col-md-2 customRow">
                        <div class="form-group">
                            <asp:Label ID="lbl_totaldiscount" BackColor="#3366cc" ForeColor="White" runat="server" class="form-control ">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3 customRow">
                        <div class="form-group">
                            <asp:Label ID="lbl_totapaid" BackColor="#3366cc" ForeColor="White" runat="server" class="form-control ">
                            </asp:Label>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">

                    $(document).ready(function () {
                        $('.searchs').on('keyup', function () {
                            var searchTerm = $(this).val().toLowerCase();
                            $('#BillList table tbody tr').each(function () {
                                var lineStr = $(this).text().toLowerCase();
                                if (lineStr.indexOf(searchTerm) === -1) {
                                    $(this).hide();
                                } else {
                                    $(this).show();
                                }
                            });
                        });
                    });


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
                                    __doPostBack('<%=GvFeedetails.UniqueID%>', 'Deletes$' + paramID);
                                    //alert(paramID);
                                } else {
                                    swal("Your data is safe!");
                                }
                            });

                    }
                    $(function () {
                        $('[id*=GvFeedetails]').footable();
                    });
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {

                        $('[id*=GvFeedetails]').footable();

                        $('.searchs').on('keyup', function () {
                            var searchTerm = $(this).val().toLowerCase();
                            $('#BillList table tbody tr').each(function () {
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
