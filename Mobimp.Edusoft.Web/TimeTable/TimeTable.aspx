<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="TimeTable.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.TimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Time Table&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="../EduUtility/ClassMST.aspx">Add class </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a6" href="../EduUtility/SectionMST.aspx">Add section </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a1" href="../EduUtility/SubjectMST.aspx">Add subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a10" href="../EduUtility/ClasswiseSubjectMst.aspx">Add classwise subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a11" href="../TimeTable/TimeTableRules.aspx">Rules</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a2" href="../TimeTable/PeriodSubjectPlanner.aspx">Period planner </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a4" href="../TimeTable/ResourcePlanner.aspx">Manage Resource </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a3" href="../TimeTable/TimeTable.aspx">Generator </a></li>
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
                                   <%-- <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                            <asp:DropDownList ID="ddl_subject"  AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                   <%-- <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_teachers" runat="server" Text="Teacher"></asp:Label>
                                            <asp:DropDownList ID="ddl_teacher" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-2 customRow" style="margin-top: 1.8em;">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btn_print"  class="btn btn-sm btn-indigo" OnClick="btn_print_Click" Text="Print" runat="server" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                        <asp:Button runat="server" ID="btn_open" />
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
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
                                   
                                    <div id="periodlist"  class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_TimeTable" EmptyDataText="No record found..."
                                           CssClass="footable table-striped" runat="server" AutoGenerateColumns="false"  OnRowCommand="Gv_TimeTable_RowCommand" OnRowDataBound="Gv_TimeTable_RowDataBound"
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
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                                        <asp:Label ID="lbl_period" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        SN
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sundaySlotID" Visible="false" runat="server" Text='<%# Eval("Sunday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_sundaysubject"  runat="server" Text='<%# Eval("SundaySubject")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        MN
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_mondayslot" Visible="false"  runat="server" Text='<%# Eval("Monday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_mondaysubject"  runat="server" Text='<%# Eval("MondaySubject")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        TUE
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_tuesdayslot" Visible="false" runat="server" Text='<%# Eval("Tuesday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_tuesdaysubject"  runat="server" Text='<%# Eval("TuesdaySubject")%>' CommandName="Tuesday" ValidationGroup="none" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        WED
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_wednesdayslot" Visible="false" runat="server" Text='<%# Eval("Wednesday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_wednesdaysubject"  runat="server" Text='<%# Eval("WednesdaySubject")%>' CommandName="Wednesday" ValidationGroup="none" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        THU
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_thursdayslot" Visible="false" runat="server" Text='<%# Eval("Thursday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_thursdaysubject"  runat="server" Text='<%# Eval("ThursdaySubject")%>' CommandName="Thursday" ValidationGroup="none" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        FR
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_fridayslot" Visible="false" runat="server" Text='<%# Eval("Friday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_fridaysubject"  runat="server" Text='<%# Eval("FridaySubject")%>' CommandName="Friday" ValidationGroup="none" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        ST
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_saturdayslot" Visible="false" runat="server" Text='<%# Eval("Saturday")%>'></asp:Label>
                                                        <asp:LinkButton ID="btn_saturdaysubject"  runat="server" Text='<%# Eval("SaturdaySubject")%>' CommandName="Saturday" ValidationGroup="none" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
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
