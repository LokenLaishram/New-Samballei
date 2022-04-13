<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="TimeTableRules.aspx.cs" Inherits="Mobimp.Campusoft.Web.TimeTable.TimeTableRules" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container-fluid" id="page_wrapper">
                <ol class="breadcrumb">
                    <li>Time Table&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a5" href="../EduUtility/ClassMST.aspx">Add class </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a6" href="../EduUtility/SectionMST.aspx">Add section </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a1" href="../EduUtility/SubjectMST.aspx">Add subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a10" href="../EduUtility/ClasswiseSubjectMst.aspx">Add classwise subject </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a class="active" runat="server" id="a11" href="../TimeTable/TimeTableRules.aspx">Rules</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a2" href="../TimeTable/PeriodSubjectPlanner.aspx">Period planner </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a4" href="../TimeTable/ResourcePlanner.aspx">Manage Resource </a>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a3" href="../TimeTable/TimeTable.aspx">Generator </a></li>
                </ol>
                <div class="card_wrapper">
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_academicyear" runat="server" Text="Academic Year"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSessionID_SelectedIndexChanged" runat="server" class="form-control ">
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
                                <asp:Label ID="lbl_nosubject" runat="server" Text="No.Subject"></asp:Label>
                                <asp:TextBox ID="txt_nosubject" ReadOnly="true" runat="server" class="form-control">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_startfrom" runat="server" Text="Starts From"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_starttime" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_periodday" runat="server" Text="Period/Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:Label ID="lbl_ID" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txt_noperiodperday" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_noperiodperday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    Enabled="True" TargetControlID="txt_noperiodperday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_recessperday" runat="server" Text="Recess/Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_recessperday" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_noperiodperday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    Enabled="True" TargetControlID="txt_recessperday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group test">
                                <asp:Label ID="lbl_recessperiods" runat="server" Text="Slot Setup"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:Button ID="btnopen2" class="form-control" Text="Select Slots" runat="server" />

                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_group" runat="server" Text="Group"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_group" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_sunday" runat="server" Text="SN-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_sunday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_sunday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" TargetControlID="txt_sunday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="MN-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_monday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_monday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    Enabled="True" TargetControlID="txt_monday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="TU_Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_tuesday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_tuesday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    Enabled="True" TargetControlID="txt_tuesday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="WE-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_wednesday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_wednesday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                    Enabled="True" TargetControlID="txt_wednesday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="TH-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_thursday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_thursday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    Enabled="True" TargetControlID="txt_thursday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="FR-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_friday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_friday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                    Enabled="True" TargetControlID="txt_friday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="ST-Day"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_saturday" autocomplete="off" onfocus="this.select();" AutoPostBack="true" OnTextChanged="txt_saturday_TextChanged" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    Enabled="True" TargetControlID="txt_saturday" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_wp" runat="server" Text="Total WP"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_totalweeklyperod" autocomplete="off" onfocus="this.select();" runat="server" class="form-control">
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                    Enabled="True" TargetControlID="txt_totalweeklyperod" ValidChars="1234567890">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control ">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" class="btn btn-sm btn-info button " Text="Add" />
                                <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" OnClick="btnreset_Click" runat="server" Text="Reset" />

                                <asp:ListBox ID="listperiod" Visible="false" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
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
                        <div class="col-md-2 customRow" style="text-align: right; margin-top: -5px; visibility: hidden">
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
                        <div id="rulelist" class="col-md-12 customRow ">
                            <asp:GridView ID="Gv_tablerule" EmptyDataText="No record found..." AllowPaging="true" AllowCustomPaging="true"
                                OnPageIndexChanging="Gv_tablerule_PageIndexChanging" OnRowEditing="Gv_tablerule_RowEditing" CssClass="footable table-striped" OnSorting="Gv_tablerule_Sorting" runat="server" OnRowCommand="Gv_tablerule_RowCommand" AutoGenerateColumns="false"
                                Style="width: 100%" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Class 
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                            <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Group 
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_groupid" Visible="false" runat="server" Text='<%# Eval("GroupID")%>'></asp:Label>
                                            <asp:Label ID="lbl_groupname" runat="server" Text='<%# Eval("GroupName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Starts From
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_from" runat="server" Text='<%# Eval("Startfrom")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            End To
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_to" runat="server" Text='<%# Eval("Startto")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            No. Period Per Day
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_period" runat="server" Text='<%# Eval("Noperiods")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField>
                                        <HeaderTemplate>
                                            Period Duration (min)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pduration" runat="server" Text='<%# Eval("PeriodDuration")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            No.Recess
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_nrecess" runat="server" Text='<%# Eval("Norecess")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <%--   <asp:TemplateField>
                                        <HeaderTemplate>
                                            Recess Duration (min)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                            <asp:Label ID="lbl_rduration" runat="server" Text='<%# Eval("RecessDuration")%>'></asp:Label>
                                            <asp:Label ID="lbl_status" Visible="false" runat="server" Text='<%# Eval("IsActive")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Recess Period
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_recessperiod" runat="server" Text='<%# Eval("Recessperiod")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Period Details
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_perioddetails" runat="server" Text='<%# Eval("PeriodDetails")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_edit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Edit" />
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
                <asp:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="modalbehavior2" runat="server" TargetControlID="btnopen2" PopupControlID="Popupwindow2"
                    BackgroundCssClass="modalBackground" Enabled="True">
                </asp:ModalPopupExtender>
                <asp:Panel runat="server" ID="Popupwindow2" BackColor="White" Style="display: none; width: 200px">
                    <div class="row">
                        <div class="col-sm-9">
                            <h5>Setup slots</h5>
                        </div>
                        <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                            <asp:LinkButton ID="btn_close" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:GridView ID="gv_slots" EmptyDataText="Please enter number of period and recess."
                                        CssClass="table-striped table-hover" OnRowDataBound="gv_slots_RowDataBound" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Slot No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="SlotID" runat="server" Text='<%# Eval("SlotID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Duration (min)
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_duration" MaxLength="3" autocomplete="off" onfocus="this.select();" Height="20px" Width="60px" class="form-control" Text='<%# Eval("Duration")%>' runat="server"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="txt_filtercharge8" runat="server"
                                                        Enabled="True" TargetControlID="txt_duration" ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Set Recess Slot
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_chkslot" Visible="false" runat="server" Text='<%# Eval("SlotType")%>'></asp:Label>
                                                    <asp:CheckBox ID="chk_slot" runat="server"></asp:CheckBox>
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
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txt_noperiodperday.ClientID%>").value == "") {
                str = str + " Please enter no. period per day.\n"
                document.getElementById("<%=txt_noperiodperday.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txt_recessperday.ClientID%>").value == "") {
                str = str + " Please enter no. recess per day.\n"
                document.getElementById("<%=txt_recessperday.ClientID %>").focus()
                i++
            }
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

            $('[id*=Gv_tablerule]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_tablerule]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#rulelist table tbody tr').each(function () {
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
