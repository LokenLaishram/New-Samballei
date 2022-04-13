<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="TeacherwiseClassAllocation.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.TeacherwiseClassAllocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <%--<li>Time Table&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="../EduUtility/ClassMST.aspx">Add class </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a6" href="../EduUtility/SectionMST.aspx">Add section </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a1" href="../EduUtility/SubjectMST.aspx">Add subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a10" href="../EduUtility/ClasswiseSubjectMst.aspx">Add classwise subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a11" href="../TimeTable/TimeTableRules.aspx">Rules</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a2" href="../TimeTable/PeriodSubjectPlanner.aspx">Period planner </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>--%>
            <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="../ELearning/SubjectTeacherMapping.aspx">Subject Teacher Mapping</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a7" href="~/TimeTable/TeacherwiseClassAllocation.aspx">Assign Class</a></li>
            <%--<li><a runat="server" id="a4" href="../TimeTable/ResourcePlanner.aspx">Manage Resource </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a3" href="../TimeTable/TimeTable.aspx">Generator </a></li>--%>

        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="RollNoAssigner">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSessionID_SelectedIndexChanged" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Teacher"></asp:Label>
                                            <asp:DropDownList ID="ddl_teacher" AutoPostBack="true" OnSelectedIndexChanged="ddl_teacher_SelectedIndexChanged" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnopen2" runat="server" />
                                            <asp:Button ID="btnopen3" runat="server" />
                                            <asp:Button ID="btn_add" runat="server" />
                                            <asp:Button ID="btn_analyse" runat="server" Visible="false" class="btn btn-sm btn-info button" OnClick="btn_analyse_Click" Text="Analyse" />
                                        </div>
                                    </div>
                                    <%--   <div class="col-md-3 customRow" style="visibility: hidden">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Class"></asp:Label>
                                            <asp:Button ID="btnopen2" runat="server" />
                                            <asp:Button ID="btn_add" runat="server" />
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span><br>
                                            <asp:ListBox ID="ClassList" CssClass="form-control" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow" style="visibility: hidden">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_period" runat="server" Text="Maximum period allowed per day"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_maxperiod" MaxLength="3" runat="server" class="form-control">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                Enabled="True" TargetControlID="txt_maxperiod" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-4 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px;">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                                    <div id="Teacherlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gv_classallocation" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="table-striped table-hover" OnRowDataBound="Gv_classallocation_RowDataBound" OnSorting="Gv_classallocation_Sorting" AllowSorting="true" OnRowCommand="Gv_classallocation_RowCommand" OnPageIndexChanging="Gv_classallocation_PageIndexChanging" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="EmployeeID" ItemStyle-Width="1%" SortExpression="EmployeeID" HeaderText="ID" />
                                                <asp:BoundField DataField="EmpName" SortExpression="EmpName" HeaderText="Name" ItemStyle-Width="3%" />
                                                <asp:BoundField DataField="Maxperiodallowed" SortExpression="Maxperiodallowed" Visible="false" HeaderText="Maximum Permitted" ItemStyle-Width="1%" />
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Class 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_name" Visible="false" runat="server" Text='<%# Eval("EmpName")%>'></asp:Label>
                                                        <asp:LinkButton ID="lnl_class" CssClass="btn btn-info small_btn" Text="select" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="class" ValidationGroup="none" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Allocated Classes
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_allocatedclasses" runat="server" Text='<%# Eval("AllocatedClasses")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Subject 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnl_subject" CssClass="btn btn-info small_btn" Text="select" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="subject" ValidationGroup="none" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Allocated subjects <%--with rating--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_allocatedsubjects" runat="server" Text='<%# Eval("AllocatedSubjects")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ActualAlloted" SortExpression="ActualAlloted" HeaderText="Total" ItemStyle-Width="1%" />
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <asp:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="modalbehavior1" TargetControlID="btn_add" runat="server" PopupControlID="Popupwindow1"
                                BackgroundCssClass="modalBackground" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel runat="server" ID="Popupwindow1" Style="display: none;">
                                <div class="row">
                                    <div class="col-sm-11">
                                        <h5>Assign Class</h5>
                                        <asp:Label ID="lbl_teachername" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                        <asp:LinkButton ID="btnClose" runat="server"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row" id="divmsg1" runat="server" style="min-height: 20px!important; margin: 6px; text-align: center;">
                                            <asp:Label ID="lbl_classmessage" runat="server"></asp:Label>
                                            <asp:Label ID="lblteacherID" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:GridView ID="gv_class" EmptyDataText="No record found..."
                                            CssClass="table-striped table-hover" runat="server" OnRowDataBound="gv_classr_RowDataBound" AutoGenerateColumns="false"
                                            Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="ID" ItemStyle-Width="1%" SortExpression="ID" HeaderText="ID" />
                                                <asp:BoundField DataField="Class" SortExpression="Class" HeaderText="Class" ItemStyle-Width="5%" />
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Check
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                        <asp:Label ID="lbl_allocated_classID" Visible="false" runat="server" Text='<%# Eval("AllocatedClassID")%>'></asp:Label>
                                                        <asp:CheckBox ID="chekclass" runat="server" onclick="Check_Click(this);" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>


                                <div class="row" id="div2" runat="server" style="margin: 5px 0px;">
                                    <div class="row">
                                        <div class="col-sm-6" align="right">
                                            <asp:Label ID="lbl_maxperiod" Text="Max period per day" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txt_Teachermaxperiod" MaxLength="3" runat="server" class="form-control">
                                            </asp:TextBox>

                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                Enabled="True" TargetControlID="txt_Teachermaxperiod" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">

                                    <div class="col-sm-12" align="right" style="text-align: right;">
                                        <div class="form-group input-group cuspanelbtngrp center ">
                                            <asp:Button ID="btn_saveclass" runat="server" class="btn btn-sm btn-info button" OnClientClick="javascript: return confirm('Are you sure to save ?');" Text="Save" OnClick="btnsave_Click" />
                                        </div>
                                    </div>
                                </div>
                                </div>

                            </asp:Panel>
                            <asp:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="modalbehavior2" runat="server" TargetControlID="btnopen2" PopupControlID="Popupwindow2"
                                BackgroundCssClass="modalBackground" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel runat="server" ID="Popupwindow2" BackColor="White" Style="display: none;">
                                <div class="row">
                                    <div class="col-sm-11">
                                        <h5>Assign Subject</h5>
                                        <asp:Label ID="lbl_teacher" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                        <asp:LinkButton ID="LinkButton1" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-12">
                                            <div class="" id="div1" runat="server" style="text-align: center; color: red;">
                                                <asp:Label ID="lbl_subjectmeassge" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_aasignteacherID" Visible="false" runat="server"></asp:Label>
                                                <asp:Label ID="lbl_class" Visible="false" runat="server"></asp:Label>
                                                <asp:DropDownList ID="ddl_selectclass" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_selectclass_SelectedIndexChanged" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:GridView ID="gv_subject" EmptyDataText="No record found..."
                                                    CssClass="table-striped table-hover" runat="server" OnRowDataBound="gv_subject_RowDataBound" AutoGenerateColumns="false"
                                                    Style="width: 100%" GridLines="None">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" ItemStyle-Width="1%" SortExpression="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Name" ItemStyle-Width="3%" />
                                                        <asp:TemplateField Visible="false">
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                                <asp:Label ID="lbl_allocated_subjectID" Visible="false" runat="server" Text='<%# Eval("AllocatedSubjectID")%>'></asp:Label>
                                                                <asp:CheckBox ID="checksubject" runat="server" onclick="Check_Click(this);" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Class
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_allocatedsectons" Visible="false" runat="server" Text='<%# Eval("AllocatedSections")%>'></asp:Label>
                                                                <asp:ListBox ID="listperiod" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Rating
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_rating" autocomplete="off" onfocus="this.select();" class="form-control" Height="10PX" Width="50px" MaxLength="2" runat="server" Text='<%# Eval("Rating")%>'></asp:TextBox>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                    Enabled="True" TargetControlID="txt_rating" ValidChars="1234567890">
                                                                </asp:FilteredTextBoxExtender>
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
                                            <div class="col-sm-12" align="right" style="text-align: right;">
                                                <br>
                                                <div class="form-group input-group cuspanelbtngrp center">
                                                    <asp:Button ID="btn_save" runat="server" class="btn btn-sm btn-info button" OnClientClick="javascript: return confirm('Are you sure to save ?');" Text="Save" OnClick="btn_savesubject_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:ModalPopupExtender ID="ModalPopupExtender3" BehaviorID="modalbehavior3" runat="server" TargetControlID="btnopen3" PopupControlID="Popupwindow3"
                                BackgroundCssClass="modalBackground" Enabled="True">
                            </asp:ModalPopupExtender>
                            <asp:Panel runat="server" ID="Popupwindow3" BackColor="White" Style="display: none;">
                                <div class="card_wrapper">
                                    <div class="row">
                                        <div class="col-sm-11">
                                            <h5>Class wise Subject List</h5>
                                        </div>
                                        <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_classes" runat="server" Text="Class"></asp:Label>
                                                <asp:DropDownList ID="ddl_class" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_section" runat="server" Text="Section"></asp:Label>
                                                <span style="color: #ff0000"></span><span style="color: #ff0000"></span>
                                                <asp:DropDownList ID="ddl_sections" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_sections_SelectedIndexChanged" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_subject" runat="server" Text="Subject"></asp:Label>
                                                <asp:DropDownList ID="ddl_subject" AutoPostBack="true" OnSelectedIndexChanged="ddl_subject_SelectedIndexChanged" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_teachers" runat="server" Text="Teacher"></asp:Label>
                                                <asp:DropDownList ID="ddl_teacherlist" AutoPostBack="true" OnSelectedIndexChanged="ddl_teacherlist_SelectedIndexChanged" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5 customRow" style="margin-top: 13px;">
                                            <asp:Label ID="lblsubjectresult" runat="server"></asp:Label>
                                            <asp:Label ID="lbl_subjecttotalrecords" Visible="false" runat="server"></asp:Label>
                                            <asp:Button runat="server" ID="btn_open" />
                                        </div>
                                        <div class="col-md-4 customRow">
                                            <input type="text" class="searchsubject form-control" placeholder="search..">
                                        </div>
                                        <div class="col-md-3 customRow">
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddl_status" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" runat="server" class="form-control">
                                                    <asp:ListItem Value="0">Status</asp:ListItem>
                                                    <asp:ListItem Value="1">Alloted</asp:ListItem>
                                                    <asp:ListItem Value="2">Non Alloted</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="height: 5px"></div>
                                    <div id="subjectlist" style="height: 46vh; overflow: auto" class="customRow">
                                        <asp:GridView ID="Gv_periodplanner" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv_periodplanner_RowDataBound"
                                            Style="width: 100%; margin-top: 7px;" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sln" Visible="false" runat="server"></asp:Label>
                                                        <%# (Container.DataItemIndex+1)+(Gv_periodplanner.PageIndex)*Gv_periodplanner.PageSize %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Section 
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
                                                        <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Teacher 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_teacherlist" runat="server" Text='<%# Eval("Allotedteachers")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total 
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_total" runat="server" Text='<%# Eval("TotalAllotedTeacher")%>'></asp:Label>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=ClassList]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>--%>
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
                        __doPostBack('<%=Gv_classallocation.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session."
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddl_teacher.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select teacher."
                document.getElementById("<%=ddl_teacher.ClientID %>").focus()
                i++
            }
<%--            if (document.getElementById("<%=ClassList.ClientID%>").value == "") {
                str = str + "\n Please select class."
                document.getElementById("<%=ClassList.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txt_maxperiod.ClientID%>").value == "") {
                str = str + "\n Please enter maximum period allowed."
                document.getElementById("<%=txt_maxperiod.ClientID %>").focus()
                i++
            }--%>
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {
                return true
            }
        }

        $(function () {

            $('[id*=Gv_classallocation]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_classallocation]').footable();
            $('[id*=ClassList]').multiselect({
                includeSelectAllOption: true
            });


            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Teacherlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });


            $('.searchsubject').on('keyup', function () {
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
    <script type="text/javascript" src="../app-assets/multiselectlist/jquery.min.js"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="../app-assets/multiselectlist/bootstrap-multiselect.js"></script>
    <link href="../app-assets/multiselectlist/bootstrap.min.css" rel="stylesheet" />
    <script src="../app-assets/multiselectlist/bootstrap.min.js"></script>
    <script src="../app-assets/multiselectlist/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=listperiod]').multiselect({
                includeSelectAllOption: true
            });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(function () {
                $('[id*=listperiod]').multiselect({
                    includeSelectAllOption: true
                });
            });
        });

    </script>
</asp:Content>
