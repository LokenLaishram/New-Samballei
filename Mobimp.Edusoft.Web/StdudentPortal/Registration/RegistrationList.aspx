<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.StdudentPortal.Registration.RegistrationList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="AddStudent.aspx">Registration List</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="card_wrapper">
                        <div class="row">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicseesions_SelectedIndexChanged" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:Label runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblstudentanme" runat="server" Text="Name"></asp:Label>
                                    <asp:TextBox runat="server"
                                        ID="txtstudentanme" AutoPostBack="true" OnTextChanged="txtstudentanme_TextChanged" class="form-control"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                        ServiceMethod="GetautosRegistrationlist" MinimumPrefixLength="1"
                                        CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtstudentanme"
                                        UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                    </asp:AutoCompleteExtender>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                    <asp:DropDownList ID="ddlclasses" AutoPostBack="true" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged" runat="server" class="form-control ">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblsexs" runat="server" Text="Gender"></asp:Label>
                                    <asp:DropDownList ID="ddlsexs" AutoPostBack="true" OnSelectedIndexChanged="ddlsexs_SelectedIndexChanged" runat="server" class="form-control ">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblcastes" runat="server" Text="Caste"></asp:Label>
                                    <asp:DropDownList ID="ddlcastes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcastes_SelectedIndexChanged" class="form-control ">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Admission Status"></asp:Label>
                                    <asp:DropDownList ID="ddl_admissionstatus" AutoPostBack="true" OnSelectedIndexChanged="ddl_admissionstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                        <asp:ListItem Value="5">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Done</asp:ListItem>
                                        <asp:ListItem Value="0">Not Done </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                    <asp:TextBox ID="txtfrom" AutoPostBack="true" OnTextChanged="txtfrom_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtfrom" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                    <asp:TextBox ID="txtto" AutoPostBack="true" OnTextChanged="txtto_TextChanged" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtto" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbluser" runat="server" Text="Added By"></asp:Label>
                                    <asp:DropDownList ID="ddluser" AutoPostBack="true" OnSelectedIndexChanged="ddluser_SelectedIndexChanged" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                    <asp:DropDownList ID="ddlstatus" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" runat="server" class="form-control ">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">InActive </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button " Text="Search" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnsearch_Click" />
                                    <asp:Button ID="btnreset" Visible="false" class="btn btn-sm btn-danger button" runat="server" Text="Reset" />
                                    <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btnprint_Click" />
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
                                        <asp:LinkButton ID="btn_export" OnClick="btn_export_Click"
                                            runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                                    <asp:DropDownList ID="ddl_show" runat="server" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" AutoPostBack="true"  class="form-control">
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
                            <div id="Studentlist" class="col-md-12 customRow ">
                                <asp:GridView ID="GvstudentDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                    CssClass="footable table-striped" AllowSorting="true" OnPageIndexChanging="GvstudentDetails_PageIndexChanging"
                                    OnRowCommand="GvstudentDetails_RowCommand" runat="server" AutoGenerateColumns="false"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:BoundField DataField="StudentID" SortExpression="StudentID" HeaderText="ID" />
                                        <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" />
                                        <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                        <asp:BoundField DataField="SexName" SortExpression="SexName" HeaderText="Gender" />
                                        <asp:BoundField DataField="CasteName" SortExpression="CasteName" HeaderText="Caste" />
                                        <asp:BoundField DataField="cAddress" SortExpression="cAddress" HeaderText="Address" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Added On
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" Width="70px" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                Remark
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtremarks" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Edit
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                <asp:Button ID="btn_edit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Edits" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Delete
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
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
    </div>
    <script type="text/javascript">

        $(document).ready(function () {
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
                        __doPostBack('<%=GvstudentDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }



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
