<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ManageResource.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.ManageResource" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <style>
        .dash_bg {
            width: 100%;
            padding: 10px 17px;
            display: inline-block;
            background: #03a9f4;
            color: #fff;
            border: 1px solid #E6E9ED;
            -webkit-column-break-inside: avoid;
            -moz-column-break-inside: avoid;
            column-break-inside: avoid;
            opacity: 1;
            transition: all .2s ease;
        }

        .dash_bg_dark {
            width: 100%;
            3 padding: 10px 17px;
            display: inline-block;
            background: #2a2c5c;
            color: #fff;
            border: 1px solid #E6E9ED;
            -webkit-column-break-inside: avoid;
            -moz-column-break-inside: avoid;
            column-break-inside: avoid;
            opacity: 1;
            transition: all .2s ease;
        }

            .dash_bg_dark:hover {
                box-shadow: 0 30px 70px rgba(0,0,0,.2);
            }

        .num_size {
            position: relative;
            animation: num_size 2s;
            animation-iteration-count: 1;
            font-size: 2.8em;
        }

        @keyframes num_size {
            from {
                bottom: 100px;
            }

            to {
                bottom: 0px;
            }
        }
    </style>
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
            <li><a runat="server" id="activepage" href="../TimeTable/TeacherwiseClassAllocation.aspx">Class | Subject  allocation </a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a4" href="../TimeTable/ManageResource.aspx">Manage Resource </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
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
                                            <asp:Label ID="lbl_group" runat="server" Text="Group"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_group" AutoPostBack="true" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_day" runat="server" Text="Day"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_day" AutoPostBack="true" OnSelectedIndexChanged="ddl_day_SelectedIndexChanged" runat="server" class="form-control">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <%-- <asp:ListItem Value="1"> Sunday</asp:ListItem>--%>
                                                <asp:ListItem Value="2"> Monday </asp:ListItem>
                                                <asp:ListItem Value="3"> Tuesday </asp:ListItem>
                                                <asp:ListItem Value="4"> Wednesday </asp:ListItem>
                                                <asp:ListItem Value="5"> Thursday </asp:ListItem>
                                                <asp:ListItem Value="6"> Friday</asp:ListItem>
                                                <asp:ListItem Value="7"> Saturday</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Subject"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_subject" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_teacher" runat="server" Text="Teacher"></asp:Label>
                                            <asp:DropDownList ID="ddl_teacher" AutoPostBack="true" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-1 customRow" style="margin-top: 1.8em;">
                                        <div class="form-group pull-right">
                                            <asp:Button ID="btn_print" class="btn btn-sm btn-indigo" Text="Print" OnClick="btn_print_Click" runat="server" />
                                            <asp:Button ID="btnopen3" runat="server" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row">
                                    <div class="row pad15">
                                        <div class="col-md-6 customRow" style="margin-top: 13px;">
                                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                            <asp:Button runat="server" ID="btn_open" />
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
                                
                                    <div id="periodlist" style="height: 52vh; overflow: auto" class="col-md-8 customRow ">
                                        <asp:GridView ID="Gv_TimeTable" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv_TimeTable_RowDataBound"
                                            Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        ID
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_periodIDs" Visible="false" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:Label>
                                                        <asp:Label ID="ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                        <%# (Container.DataItemIndex+1)+(Gv_TimeTable.PageIndex)*Gv_TimeTable.PageSize %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
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
                                                        <asp:Label ID="lbl_periodcount" Visible="false" runat="server" Text='<%# Eval("PeriodCount")%>'></asp:Label>
                                                        <asp:Label ID="lbl_period" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Alloted Subject 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_alloted" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Select Subject 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_subjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_mainsubjectid" Visible="false" runat="server" Text='<%# Eval("MainSubjectID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_maonsubjectids" Visible="false" runat="server" Text='<%# Eval("MainSubjectIDs")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddl_sbject" Width="130px" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddl_sbject_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Alloted Teacher 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_allotedtecherid" runat="server" Visible="false" Text='<%# Eval("AllocatedTeacher")%>'></asp:Label>
                                                        <asp:LinkButton runat="server" ID="btn_teacher" OnClick="btn_teacher_Click" Text='<%# Eval("TeacherName")%>'></asp:LinkButton>
                                                        <asp:DropDownList ID="ddl_gridteacher" class="form-control" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                    <div id="divblock" class="col-md-4 customRow ">
                                        <div id="divallotedlist" class="customRow">
                                            <asp:GridView ID="gv_allotedsubjectlist" EmptyDataText="No record found..."
                                                CssClass="footable table-striped" runat="server" AutoGenerateColumns="false"
                                                Style="width: 100%; margin-top: 7px;" GridLines="None">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Sl 
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_sln" Visible="false" runat="server"></asp:Label>
                                                            <%# (Container.DataItemIndex+1)+(gv_allotedsubjectlist.PageIndex)*gv_allotedsubjectlist.PageSize %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Sec 
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_section" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Period 
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_period" Visible="false" runat="server" Text='<%# Eval("PeriodNo")%>'></asp:Label>
                                                            <asp:Button runat="server" ID="btn_period" Font-Underline="true" OnClick="btn_period_Click" Text='<%# Eval("PeriodNo")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Subject 
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_alloted" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Action
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_status" runat="server" Visible="false" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                            <asp:Button runat="server" ID="btn_action" Text="SET" />
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

                            <asp:ModalPopupExtender ID="ModalPopupExtender3" BehaviorID="modalbehavior3" runat="server" TargetControlID="btnopen3" PopupControlID="Popupwindow3"
                                BackgroundCssClass="modalBackground" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel runat="server" ID="Popupwindow3" BackColor="White" Style="display: none; width: 800px">
                                <div class="card_wrapper">
                                    <div class="row">
                                        <div class="col-sm-11">
                                            <h5>Plan your resource</h5>
                                            <asp:Label runat="server" Font-Bold="true" ID="lbl_teachername"></asp:Label>
                                        </div>
                                        <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                            <asp:LinkButton ID="LinkButton2" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row" style="height: 5px"></div>
                                    <div id="subjectlist" style="height: 46vh; overflow: auto" class="customRow">
                                        <asp:GridView ID="Gv_resourceplanner" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%; margin-top: 7px;" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sln" Visible="false" runat="server"></asp:Label>
                                                        <%# (Container.DataItemIndex+1)+(Gv_resourceplanner.PageIndex)*Gv_resourceplanner.PageSize %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("CLassID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subject 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_suject" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                        <asp:Label ID="lbl_subsubjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_mainsubjectid" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period I 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_I" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_I_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_I" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 1 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_II" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_II_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_II" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 2 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_III" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_III_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_III" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 3 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_III" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_III_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_III" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 4 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_IV" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_IV_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_IV" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 5 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_V" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_V_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_V" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 6 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_VI" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_VI_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_VI" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 7 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_VII" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_VII_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_VII" runat="server"></asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Period 8 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_slot_VIII" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Label ID="lbl_slot_VIiI_status" runat="server" Text='<%# Eval("slotid")%>'></asp:Label>
                                                        <asp:Button ID="btn_VIII" runat="server"></asp:Button>
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
                                        <asp:UpdateProgress ID="updateProgress2" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                            </asp:Panel>
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

