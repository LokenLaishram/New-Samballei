<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="PeriodSubjectPlanner.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.TeacherClassSubjectMapping" %>

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
            <li><a class="active" runat="server" id="a2" href="../TimeTable/PeriodSubjectPlanner.aspx">Period planner </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                      <li><a runat="server" id="a4" href="../TimeTable/ResourcePlanner.aspx">Manage Resource </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a3" href="../TimeTable/TimeTable.aspx">Generator </a></li>
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
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_class" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_teacher" runat="server" Text="Section"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_sections" AutoPostBack="true" OnSelectedIndexChanged="ddl_sections_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                            <asp:DropDownList ID="ddl_subject" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddl_teacher" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged1" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btn_preview" runat="server" class="btn btn-sm btn-info button" Text="Preview" />
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
                                    <div id="periodlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_periodplanner" EmptyDataText="No record found..." ShowFooter="true"
                                            CssClass="table-striped table-hover" runat="server" OnRowDataBound="Gv_periodplanner_RowDataBound" AutoGenerateColumns="false"
                                            Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sln" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class Details 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("CLassID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_class" runat="server" Font-Bold="true" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                        <asp:Label ID="lbl_sectionwise_weekly_period" Visible="false" Font-Bold="true" runat="server" Text='<%# Eval("TotalTableWeeklyPeriod")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subject 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_suject" Font-Bold="true" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                        <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_mainsubjectid" Visible="false" runat="server" Text='<%# Eval("MainSubjectID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_setpriod" Font-Bold="true" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_setpriod_TextChanged" class="form-control" Height="10PX" Width="40px" MaxLength="2" runat="server" Text='<%# Eval("SubjectwisePeriod")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge1" runat="server"
                                                            Enabled="True" TargetControlID="txt_setpriod" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sundayperiod" Visible="false" runat="server" Text='<%# Eval("SundayPeriod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_sunday"  Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_sunday_TextChanged" autocomplete="off"  onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Sunday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge2" runat="server"
                                                            Enabled="True" TargetControlID="txt_sunday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_mondayperiod" Visible="false" runat="server" Text='<%# Eval("Modayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_monday" Font-Bold="true"  AutoPostBack="true" OnTextChanged="txt_monday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control"  Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Monday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge3" runat="server"
                                                            Enabled="True" TargetControlID="txt_monday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_tuesdayperiod" Visible="false" runat="server" Text='<%# Eval("Tuesdayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_tuesday" Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_tuesday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Tuesday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge4" runat="server"
                                                            Enabled="True" TargetControlID="txt_tuesday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_wednesdayperiod" Visible="false" runat="server" Text='<%# Eval("Wednesdayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_wednesday" Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_wednesday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Wednesday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge5" runat="server"
                                                            Enabled="True" TargetControlID="txt_wednesday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_thursdayperiod" Visible="false" runat="server" Text='<%# Eval("Thursdayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_thursday" Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_thursday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Thursday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge6" runat="server"
                                                            Enabled="True" TargetControlID="txt_thursday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>

                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_fridayperiod" Visible="false" runat="server" Text='<%# Eval("Fridayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_friday" Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_friday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Friday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge7" runat="server"
                                                            Enabled="True" TargetControlID="txt_friday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_saturdayperiod" Visible="false" runat="server" Text='<%# Eval("Saturdayperiod")%>'></asp:Label>
                                                        <asp:TextBox ID="txt_saturday" Font-Bold="true" AutoPostBack="true" OnTextChanged="txt_saturday_TextChanged" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="30px" MaxLength="1" runat="server" Text='<%# Eval("Saturday")%>'></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="txt_filtercharge8" runat="server"
                                                            Enabled="True" TargetControlID="txt_saturday" ValidChars="0123456789">
                                                        </asp:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Teacher
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_teacher" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                        <asp:DropDownList runat="server" Width="100px" ID="ddl_teacher">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                       <HeaderTemplate>
                                                        SG
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_atperiod" Visible="false" runat="server" Text='<%# Eval("Subsubjectwiseperiodcount")%>'></asp:Label>
                                                        <asp:LinkButton ID="bnt_cg" Font-Bold="true" OnClick="bnt_cg_Click" Font-Underline="true" runat="server" Text='<%# Eval("Subsubjectwiseperiodcount")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>

                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btn_cgzero" Font-Bold="true" OnClick="btn_cgzero_Click" Font-Underline="true" runat="server" Text="Clear"></asp:LinkButton>
                                                        <asp:Label ID="lbl_noperiod" Visible="false" runat="server" Text='<%# Eval("Noperiods")%>'></asp:Label>
                                                        <asp:Label ID="lbl_norecess" Visible="false" runat="server" Text='<%# Eval("Norecess")%>'></asp:Label>
                                                        <asp:Label ID="lbl_defaultperiod" Visible="false" runat="server" Text='<%# Eval("DefaultPeriod")%>'></asp:Label>
                                                        <asp:DropDownList Visible="false" runat="server" Width="80px" ID="ddl_period">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5" style="margin-top: .8em;">
                                        <asp:Label ID="lblNote" Style="color: #f47b20; font-weight: bold;" runat="server" Text="* NPD : No.period per day; WTP : Weekly total period"></asp:Label>
                                    </div>
                                    <div class="col-md-5" style="visibility: hidden">
                                        <div class="form-group" style="margin-top: .8em;">
                                            <asp:TextBox ID="txt_perdaytotalperiod" Style="color: #f47b20; font-weight: bold;" ReadOnly="true" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:Label ID="lbl_maxperiod" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_sundaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_mondaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_tuesdaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_wednesdaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_thursdaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_fridaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_saturdaytotal" Visible="false" Style="color: #f47b20; font-weight: bold;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group pull-right" style="margin-top: .8em;">
                                            <asp:Button ID="btn_section" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" runat="server" class="btn btn-sm btn-info button"  OnClick="btn_update_section_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group pull-right" style="margin-top: .8em;">
                                            <asp:Button ID="btnupdate" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" runat="server" class="btn btn-sm btn-indigo button" Text="Apply All" OnClick="btn_save_Click" />
                                        </div>
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

        function clickEnter(obj, event) {
            var keyCode;
            if (event.keyCode > 0) {
                keyCode = event.keyCode;
            }
            else if (event.which > 0) {
                keyCode = event.which;
            }
            else {
                keycode = event.charCode;
            }
            if (keyCode == 13) {
                document.getElementById(obj).focus();
                return false;
            }
            else {
                return true;
            }
        }

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

            $('[id*=Gv_periodplanner]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_periodplanner]').footable();

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
