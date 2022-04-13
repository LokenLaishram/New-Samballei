<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="DailyTimetable.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.DailyTimetable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Time Table&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a3" href="../TimeTable/DailyTimetable.aspx">Daily Time Table </a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="RollNoAssigner">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSessionID_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_group" AutoPostBack="true" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_class" runat="server" Text="Class"></asp:Label>
                                            <%--  <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>--%>
                                            <asp:DropDownList ID="ddl_class" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_teacher" runat="server" Text="Section"></asp:Label>
                                            <span style="color: #ff0000"></span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_sections" AutoPostBack="true" OnSelectedIndexChanged="ddl_sections_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_period" runat="server" Text="Period"></asp:Label>
                                            <span style="color: #ff0000"></span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_period" AutoPostBack="true" OnSelectedIndexChanged="ddl_period_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Period 1</asp:ListItem>
                                                <asp:ListItem Value="2">Period 2</asp:ListItem>
                                                <asp:ListItem Value="3">Period 3</asp:ListItem>
                                                <asp:ListItem Value="4">Period 4</asp:ListItem>
                                                <asp:ListItem Value="5">Period 5</asp:ListItem>
                                                <asp:ListItem Value="6">Period 6</asp:ListItem>
                                                <asp:ListItem Value="7">Period 7</asp:ListItem>
                                                <asp:ListItem Value="8">Period 8</asp:ListItem>
                                                <asp:ListItem Value="9">Period 9</asp:ListItem>
                                                <asp:ListItem Value="10">Period 10</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                            <asp:DropDownList ID="ddl_subject" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_teachers" runat="server" Text="Teacher"></asp:Label>
                                            <asp:DropDownList ID="ddl_teacher" AutoPostBack="true" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_date" runat="server" Text="Date"></asp:Label>
                                            <asp:TextBox ID="txt_date" AutoPostBack="true" OnTextChanged="txt_date_TextChanged" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_date" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_date" />
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow" style="margin-top: 1.8em;">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btn_search" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-info button " OnClick="btn_search_Click" Text="Search" runat="server" />
                                        </div>
                                    </div>
                                       <div class="col-md-2 customRow" style="margin-top: 1.8em;">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btn_print" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'"  class="btn btn-sm btn-indigo button" OnClick="btn_print_Click"  Text="Print" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="Pageloader">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                        <asp:Button runat="server" ID="btn_open" />
                                    </div>
                                    <div class="col-md-2 customRow"  style="text-align: right; margin-top: -5px;visibility:hidden">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                                                <asp:ListItem Value="50"> 50 </asp:ListItem>
                                                <asp:ListItem Value="100"> 100 </asp:ListItem>
                                                <asp:ListItem Value="10000"> All</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <input type="text" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="row">

                                    <div id="periodlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_TimeTable" EmptyDataText="No record found..."
                                            CssClass="table-striped table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_TimeTable_RowCommand" OnRowDataBound="Gv_TimeTable_RowDataBound"
                                            Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_periodid" runat="server" Text='<%# Eval("Periodid")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                        <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("CLassID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Section 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_section" Visible="false" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slotype" Visible="false" runat="server" Text='<%# Eval("SlotType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Time 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_timeslot" runat="server" Text='<%# Eval("TimeRange")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_noperiods" Visible="false" runat="server" Text='<%# Eval("Noperiods")%>'></asp:Label>
                                                        <asp:Label ID="lbl_period" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subject
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_subject" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddl_subject" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged2" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Teacher
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_teacher" runat="server" Text='<%# Eval("TeacherName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subst.Teacher
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                           <asp:Label ID="lbl_substeacher" Visible="false" runat="server" Text='<%# Eval("SubsTeacherID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddl_substeacher"  AutoPostBack="true" OnSelectedIndexChanged="ddl_substeacher_SelectedIndexChanged" Width="250px" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Button ID="lnkPrint" Visible="false" class="btn btn-sm btn-indigo small_btn button cus_btn" Height="25px" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Print" ValidationGroup="none" />
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
        </div>
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

        $(function () {

            $('[id*=Gv_TimeTable]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_TimeTable]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#periodlist table tbody tr').each(function () {
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

