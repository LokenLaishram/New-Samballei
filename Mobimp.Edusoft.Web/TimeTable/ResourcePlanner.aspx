<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ResourcePlanner.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.ResourcePlanner" %>

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
            <li><a class="active" runat="server" id="a4" href="../TimeTable/ResourcePlanner.aspx">Resource Planner </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a3" href="../TimeTable/TimeTable.aspx">Generator </a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="RollNoAssigner">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="div_subjectlist" runat="server">
                                <div class="card_wrapper">
                                    <div class="row">
                                        <div class="col-md-2 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                                <asp:DropDownList ID="ddlAcademicSessionID" runat="server" class="form-control ">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_group" runat="server" Text="Group"></asp:Label>
                                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                                <asp:DropDownList ID="ddl_group" AutoPostBack="true" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_subject" runat="server" Text="Subject"></asp:Label>
                                                <asp:DropDownList ID="ddl_subject" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged"
                                                    runat="server" class="form-control">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow" style="margin-top: 1.5em;">
                                            <input type="text" class="search form-control" placeholder="search..">
                                        </div>
                                    </div>
                                </div>
                                <div class="card_wrapper" id="divsearch" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 customRow ">

                                            <div id="subjectlist" class="col-md-12 customRow ">
                                                <asp:GridView ID="Gv_resourceplanner" EmptyDataText="No record found..."
                                                    CssClass="table-striped table-hover" ShowFooter="true" runat="server" OnRowDataBound="Gv_resourceplanner_RowDataBound" AutoGenerateColumns="false" OnRowCommand="Gv_resourceplanner_RowCommand"
                                                    Style="width: 100%" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sl No
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# (Container.DataItemIndex+1)+(Gv_resourceplanner.PageIndex)*Gv_resourceplanner.PageSize %>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Subject 
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnl_subject" Text='<%# Eval("SubjectName")%>' runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="subject" ValidationGroup="none" />
                                                                <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_subjectname" Visible="false" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Total Period
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_totalperiod" runat="server" Text='<%# Eval("TotalPeriod")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Extra Period                                                   
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_extraperiod" runat="server" Text='<%# Eval("ExtraPeriod")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Teacher Reqd.
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_teacherreqd" runat="server" Text='<%# Eval("TeacherRequired")%>'></asp:Label>
                                                                <asp:Label ID="lbl_totalteacherreqd" Visible="false" Text='<%# Eval("TotalTeacheredReqd")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Teacher
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_addteacher" CssClass="btn btn-info small_btn" OnClick="btn_addteacher_Click" Text="Add" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                                SU
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_sunday" Visible="false" runat="server" Text='<%# Eval("Sunday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_sundaystatus" Visible="false" runat="server" Text='<%# Eval("SundayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_sunday" OnClick="btn_sunday_Click" Text='<%# Eval("Sunday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                MN
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_monday" Visible="false" runat="server" Text='<%# Eval("Monday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_mondaystatus" Visible="false" runat="server" Text='<%# Eval("MondayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_monday" OnClick="btn_monday_Click" Text='<%# Eval("Monday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                TU
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_tuesday" Visible="false" runat="server" Text='<%# Eval("Tuesday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_tuesdaystatus" Visible="false" runat="server" Text='<%# Eval("TuesdayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_tuesday" OnClick="btn_tuesday_Click" Text='<%# Eval("Tuesday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                WE
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_wednesday" Visible="false" runat="server" Text='<%# Eval("Wednesday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_wednesdaystatus" Visible="false" runat="server" Text='<%# Eval("WednesdayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_wednesday" OnClick="btn_wednesday_Click" Text='<%# Eval("Wednesday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                TH
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_thursday" Visible="false" runat="server" Text='<%# Eval("Thursday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_thursdaystatus" Visible="false" runat="server" Text='<%# Eval("ThursdayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_thursday" OnClick="btn_thursday_Click" Text='<%# Eval("Thursday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                FR
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_friday" Visible="false" runat="server" Text='<%# Eval("Friday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_fridaystatus" Visible="false" runat="server" Text='<%# Eval("FridayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_friday" OnClick="btn_friday_Click" Text='<%# Eval("Friday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                ST
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="txt_saturday" Visible="false" runat="server" Text='<%# Eval("Saturday")%>'></asp:Label>
                                                                <asp:Label ID="lbl_saturdaystatus" Visible="false" runat="server" Text='<%# Eval("SaturdayStatus")%>'></asp:Label>
                                                                <asp:LinkButton ID="btn_saturday" OnClick="btn_saturday_Click" CssClass="AttendanceDesign" Text='<%# Eval("Saturday")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Available Teacher List
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_teacherlist" runat="server" Text='<%# Eval("Teacherlist")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" />
                                                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" />
                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                                </asp:GridView>
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
                            </div>
                            <div id="div_addteacher" visible="false" runat="server">
                                <div>
                                    <div style="height: 10px">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 customRow">
                                        </div>
                                        <div class="col-md-6 customRow card_wrapper">
                                            <div class="row">
                                                <div class="col-sm-11">
                                                    <asp:Label ID="lbl_teachersubject" Font-Bold="true" runat="server"></asp:Label>
                                                    <asp:Label runat="server" Visible="false" ID="lbl_teachersubjectname"></asp:Label></h5>
                                                 <asp:Label ID="lbl_teachersubjectid" Visible="false" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_dayid" Visible="false" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-9 customRow">
                                                    <div class="form-group">
                                                    </div>
                                                </div>
                                                <div class="col-md-2 customRow">
                                                    <div class="form-group">
                                                        <asp:Button ID="btn_add" CssClass="btn btn-info small_btn" Text="Add" OnClick="btn_add_Click" runat="server"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="height: 5px"></div>
                                            <div id="Teacher_subjectlist" style="max-height: 60vh; min-height: 30vh; overflow: auto" class="customRow">
                                                <asp:GridView ID="gv_teachers" EmptyDataText="No record found..."
                                                    CssClass="footable table-striped" runat="server" OnRowDataBound="gv_teachers_RowDataBound" AutoGenerateColumns="false"
                                                    Style="width: 100%; margin-top: 7px;" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Sl 
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sln" Visible="false" runat="server"></asp:Label>
                                                                <%# (Container.DataItemIndex+1)+(gv_teachers.PageIndex)*gv_teachers.PageSize %>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Teacher 
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_subjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_teacherid" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_teacher" runat="server" Text='<%# Eval("TeacherName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Action 
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_status" Visible="false" runat="server" Text='<%# Eval("IsActive")%>'></asp:Label>
                                                                <asp:Button ID="btn_action" OnClick="btn_action_Click" runat="server"></asp:Button>
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
                                </div>
                            </div>
                            <asp:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="modalbehavior2" runat="server" TargetControlID="btnopen2" PopupControlID="popupwindow2"
                                BackgroundCssClass="modalBackground" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel runat="server" ID="popupwindow2" BackColor="White" Style="display: none; width: 400px">
                                <div class="card_wrapper">
                                    <div class="row">
                                        <div class="col-sm-11">
                                            <asp:Label ID="lbl_daywisesubject" Font-Bold="true" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_daywisesubjectid" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_totalperiod" Visible="false" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                            <asp:LinkButton ID="btn_close" OnClick="btn_close_Click" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="row" style="height: 5px"></div>
                                    <div id="daywiseteacherlist" style="max-height: 60vh; min-height: 30vh; overflow: auto" class="customRow">
                                        <asp:GridView ID="Gv_teacherwsie_period" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%; margin-top: 7px;" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                                                        <%# (Container.DataItemIndex+1)+(Gv_teacherwsie_period.PageIndex)*Gv_teacherwsie_period.PageSize %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Teacher 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_dayid" Visible="false" runat="server" Text='<%# Eval("DayID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_subjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_teacherid" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_teachername" runat="server" Text='<%# Eval("TeacherName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" CssClass="btn btn-info small_btn" OnClick="btn_assignsubject_Click" Text="Assign" ID="btn_assignsubject"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_noperiod" runat="server" Text='<%# Eval("PeriodCount")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div id="Div_period_Planner" class="card_wrapper" runat="server" visible="false">
                               
                                <div class="row">
                                    <div class="col-sm-3">
                                        <asp:Label ID="lbl_teacherwisesubject" Font-Bold="true" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_teacherwisesubjectid" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_teacherwiseTeacherID" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_teachernames" Visible="false" Font-Bold="true" runat="server"></asp:Label>

                                    </div>
                                    <div class="col-md-2 customRow">
                                        <asp:DropDownList ID="ddl_subjectwiseteacher" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_subjectwiseteacher_SelectedIndexChanged" class="form-control ">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <asp:DropDownList ID="ddl_category" AutoPostBack="true" OnSelectedIndexChanged="ddl_category_SelectedIndexChanged" runat="server" class="form-control ">
                                            <asp:ListItem Value="0">Show all category </asp:ListItem>
                                            <asp:ListItem Value="1">Category-A (Pre-III)</asp:ListItem>
                                            <asp:ListItem Value="2">Category-B (IV-VII)</asp:ListItem>
                                            <asp:ListItem Value="3">Category-C (VIII-X)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control ">
                                            <asp:ListItem Value="0">Show all</asp:ListItem>
                                            <asp:ListItem Value="1">Show Completed</asp:ListItem>
                                            <asp:ListItem Value="2">Show Uncompleted</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <input type="text" id="idsearch" runat="server" onfocus="this.select();" class="search1 form-control" placeholder="search..">
                                    </div>
                                    <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row" style="height: 5px"></div>
                                <div id="assignsubjectlist" class="col-md-9 customRow " style="max-height: 65vh; min-height: 65vh; overflow: auto">
                                    <asp:GridView ID="Gv_subsubjectlist" EmptyDataText="No record found..." OnRowDataBound="Gv_subsubjectlist_RowDataBound"
                                        CssClass="footable table-striped" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%; margin-top: 7px;" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_id" Font-Bold="true" Text=" <%# (Container.DataItemIndex+1)+(Gv_subsubjectlist.PageIndex)*Gv_subsubjectlist.PageSize %>" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_category" Visible="false" runat="server" Text='<%# Eval("CategoryID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_dayID" Visible="false" runat="server" Text='<%# Eval("DayID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_class" Font-Bold="true" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    <asp:Label ID="lbl_class_totalperiod" Visible="false" Font-Bold="true" runat="server" Text='<%# Eval("ClassTotalPeriod")%>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Subject                                                    
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_teacherid" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_subjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_subsubjectid" Visible="false" runat="server" Text='<%# Eval("SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_subsubjectname" Font-Bold="true" runat="server" Text='<%# Eval("SubSubject")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Teacher                                                    
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_teacher" Visible="false" Font-Bold="true" runat="server" Text='<%# Eval("TeacherName")%>'></asp:Label>
                                                    <asp:LinkButton runat="server" Visible="false" Font-Bold="true" ID="btn_teacher" OnClick="btn_teacher_Click" Text='<%# Eval("TeacherName")%>'></asp:LinkButton>
                                                    <asp:DropDownList ID="ddl_teacherlist" class="form-control " AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_teacherlist_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Period                                                    
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_period" Font-Bold="true" autocomplete="off" onfocus="this.select();" class="form-control" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        Enabled="True" TargetControlID="txt_period" ValidChars="1234567890">
                                                    </asp:FilteredTextBoxExtender>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    Check                                                    
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_status" Visible="false" runat="server" Text='<%# Eval("AssignStatus")%>'></asp:Label>
                                                    <asp:CheckBox ID="checksubjt" AutoPostBack="true" OnCheckedChanged="checksubjt_CheckedChanged" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(1)                                           
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_I_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_I_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_I_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_I_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_I_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_I_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_I_SubSubjectName" runat="server" Text='<%# Eval("P_I_SubSubjectName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(2)                                       
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_II_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_II_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_II_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_II_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_II_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_II_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_II_SubSubjectName" runat="server" Text='<%# Eval("P_II_SubSubjectName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(3)                                               
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_III_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_III_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_III_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_III_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_III_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_III_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_III_SubSubjectName" runat="server" Text='<%# Eval("P_III_SubSubjectName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(4)                                           
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_IV_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_IV_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_IV_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_IV_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_IV_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_IV_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_IV_SubSubjectName" runat="server" Text='<%# Eval("P_IV_SubSubjectName")%>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(5)                                         
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_V_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_V_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_V_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_V_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_V_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_V_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_V_SubSubjectName" runat="server" Text='<%# Eval("P_V_SubSubjectName")%>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(6)                                             
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_VI_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_VI_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VI_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_VI_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VI_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_VI_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VI_SubSubjectName" runat="server" Text='<%# Eval("P_VI_SubSubjectName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(7)                                            
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_VII_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_VII_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VII_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_VII_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VII_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_VII_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VII_SubSubjectName" runat="server" Text='<%# Eval("P_VII_SubSubjectName")%>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    P(8)                                          
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_p_VIII_TeacherID" Visible="false" runat="server" Text='<%# Eval("P_VIII_TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VIII_SubjectID" Visible="false" runat="server" Text='<%# Eval("P_VIII_SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VIII_SubSubjectID" Visible="false" runat="server" Text='<%# Eval("P_VIII_SubSubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_p_VIII_SubSubjectName" runat="server" Text='<%# Eval("P_VIII_SubSubjectName")%>'></asp:Label>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_focus" Width="1px" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                                <div id="divteacherlist" class="col-md-3 customRow ">
                                    <asp:GridView ID="gv_teacherlist" EmptyDataText="No record found..."
                                        CssClass="footable table-striped" ShowFooter="true" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%; margin-top: 7px;" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" Visible="false" runat="server"></asp:Label>
                                                    <%# (Container.DataItemIndex+1)+(Gv_teacherwsie_period.PageIndex)*Gv_teacherwsie_period.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Teacher 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_dayid" Visible="false" runat="server" Text='<%# Eval("DayID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_subjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_teacherid" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_teachername" runat="server" Text='<%# Eval("TeacherName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Class
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_classlist" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Period 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_periodcount" autocomplete="off" onfocus="this.select();" MaxLength="2" AutoPostBack="true" OnTextChanged="txt_periodcount_TextChanged" class="form-control" runat="server" Text='<%# Eval("PeriodCount")%>'></asp:TextBox>
                                                    <asp:Label ID="lbl_noperiod" Visible="false" runat="server" Text='<%# Eval("PeriodCount")%>'></asp:Label>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        Enabled="True" TargetControlID="txt_periodcount" ValidChars="1234567890">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                    <div style="height: 10px">
                                    </div>
                                    <div class="row" style="text-align: center">
                                        <asp:Button ID="btn_gen" class="btn btn-sm btn-indigo button" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Generate Time Table" OnClick="btn_gen_Click" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-8" style="padding: 0px 9px; font-size: large; text-align: right">
                                        <asp:Button ID="btn_update" Visible="false" CssClass="btn btn-info small_btn" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btn_update_Click" Text="Save" runat="server" />
                                        <asp:Button ID="btnopen1" runat="server" />
                                        <asp:Button ID="btnopen2" runat="server" />
                                        <asp:Button ID="btnopen3" runat="server" />
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

            $('[id*=Gv_resourceplanner]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_resourceplanner]').footable();

            $('.search').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#subjectlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });

            $('.search1').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#assignsubjectlist table tbody tr').each(function () {
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
