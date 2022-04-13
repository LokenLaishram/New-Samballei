<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SubjectWiseMarkEntry.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.SubjectWiseMarkEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container-fluid" id="page_wrapper">
                <ol class="breadcrumb">
                    <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
                    <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" href="../EduUtility/ExamDetail.aspx">Mark Detail&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
                    <li><a class="active" id="activepage" runat="server" href="../EduExamination/SubjectWiseMarkEntry.aspx">Mark Entry&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
                    <li><a runat="server" href="../EduExamination/ResultProcessing.aspx">Result Processing&nbsp;&nbsp;</a></li>
                    <li class="pull-right " style="color: #f47b20; font-weight: bold;">
                        <asp:Label ID="lblNote" runat="server" Text="Note: Use Caps 'A' for absent, 'A+','A','B+','C','D' for grades."></asp:Label>
                    </li>
                </ol>

                <div id="divsubject" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                    <asp:Label ID="lblIsSubSubject" Visible="false" runat="server"></asp:Label>
                                    <asp:Label ID="lblIsGrade" Visible="false" runat="server"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control custextbox">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlexam" AutoPostBack="true" OnSelectedIndexChanged="ddlexam_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                    <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged" class="form-control custextbox">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                    <asp:DropDownList ID="ddlsections" runat="server" AutoPostBack="true" class="form-control custextbox" OnSelectedIndexChanged="ddlsections_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                                    <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="true" class="form-control custextbox" OnSelectedIndexChanged="ddlsubject_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbl_enter" runat="server" Text="Enter By"></asp:Label>
                                    <asp:DropDownList ID="ddl_enterby" runat="server" AutoPostBack="true" class="form-control custextbox">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row" id="diventrylist" runat="server" visible="false">
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
                            <div id="subjectlist" class="col-md-12 customRow ">
                                <asp:GridView ID="Gv_class_exam_subject_list" OnRowDataBound="Gv_class_exam_subject_list_RowDataBound" OnRowCommand="Gv_class_exam_subject_list_RowCommand" EmptyDataText="No record found..."
                                    runat="server" CssClass="table-striped table-hover" AutoGenerateColumns="false"
                                    Style="width: 100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText=" SL">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sno" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Class">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                <asp:Label ID="lblClass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                <asp:Label ID="lbl_classnames" runat="server" Visible="false" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Student">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_nostudent" runat="server" Text='<%# Eval("Nostudent")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No.WA Entered">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_noWA" runat="server" Text='<%# Eval("UTEntryCount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No.CA Entered">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_noCA" runat="server" Text='<%# Eval("PWEntryCount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No.GRADE Entered">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_noGRADE" runat="server" Text='<%# Eval("GRADEEntryCount")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CA FM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_CAFM" runat="server" Text='<%# Eval("PW_FM")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CA PM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_CAPM" runat="server" Text='<%# Eval("PW_PM")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="WA FM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_WAFM" runat="server" Text='<%# Eval("UT_FM")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="WA PM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_WAPM" runat="server" Text='<%# Eval("UT_PM")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CA MARK">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_castatus" Visible="false" runat="server" Text='<%# Eval("PW_entry_status")%>'></asp:Label>
                                                <asp:Label ID="lblTWD" Visible="false" runat="server" Text='<%# Eval("TWD")%>'></asp:Label>
                                                <asp:Label ID="lblAttendance" Visible="false" runat="server" Text='<%# Eval("Attendance")%>'></asp:Label>
                                                <asp:LinkButton ID="lnl_CA" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="CA" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="WA MARK">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_wastatus" Visible="false" runat="server" Text='<%# Eval("UT_entry_status")%>'></asp:Label>
                                                <asp:LinkButton ID="lnl_WA" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="WA" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="GRADE MARK">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_gradestatus" Visible="false" runat="server" Text='<%# Eval("grade_entry_status")%>'></asp:Label>
                                                <asp:Label ID="lbl_isgradesubject" Visible="false" runat="server" Text='<%# Eval("IsGradeSubject")%>'></asp:Label>
                                                <asp:LinkButton ID="lnl_Grade" CssClass=" small_btn cus_btn" Height="25px" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="GRADE" ValidationGroup="none" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="lnkPrint" class="btn btn-sm btn-indigo small_btn button cus_btn" Height="25px" Visible="false" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="BS" ValidationGroup="none" />
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
                <div id="divsubjectmark" runat="server" visible="false">
                    <div class="card_wrapper">
                        <asp:Panel runat="server">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_class" ReadOnly="true" ForeColor="Black" runat="server" placeholder="Class" class="form-control">
                                        </asp:TextBox>
                                        <asp:Label ID="lbl_message" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_classids" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_markingtype" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_sectionids" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_SectionName" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_SubjectName" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_subjectids" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_examids" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_utfm" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_pwfm" Visible="false" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_PW" ReadOnly="true" runat="server" ForeColor="Black" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_UT" ReadOnly="true" runat="server" ForeColor="Black" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_grade" ReadOnly="true" runat="server" ForeColor="Black" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2 customRow">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="form-group" style="margin-top: 0.6em;">
                                                <asp:FileUpload ID="fileUploadBtn" runat="server" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group pull-left" style="margin-top: 0.3em;">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnImport" runat="server" class="btn btn-sm btn-deep-purple button" Text="Import" OnClick="btnImport_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnImport" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="form-group pull-left" style="margin-top: 0.3em;">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_export" runat="server" class="btn btn-sm btn-deep-purple button" Text="Export" OnClick="btn_export_Click" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btn_export" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-9 customRow" runat="server" id="diverrormessage">
                                    <div class="form-group">
                                        <asp:Label runat="server"  Font-Bold="true" ID="lbl_errormessage"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 customRow">
                                    <div class="form-group">
                                        <input type="text" id="txt_search" runat="server" class="searchs form-control" placeholder="search..">
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow">
                                    <div class="form-group" style="margin-top: 0.3em;">
                                        <asp:LinkButton ID="btn_back" OnClick="btn_back_Click" runat="server" class="btn btn-sm btn-info button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" id="studentlist" style="max-height: 52vh; overflow: auto;">
                                    <asp:GridView ID="Gv_subjectwiseStudentlist" EmptyDataText="No record found..." OnRowDataBound="Gv_subjectwiseStudentlist_RowDataBound"
                                        runat="server" CssClass="table-striped table-hover" AutoGenerateColumns="false"
                                        Style="width: 100%" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# (Container.DataItemIndex+1)+(Gv_subjectwiseStudentlist.PageIndex)*Gv_subjectwiseStudentlist.PageSize %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" ItemStyle-Width="5%" />
                                            <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="Roll" SortExpression="Roll" HeaderText="Roll" ItemStyle-Width="1%" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    CA
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbl_ca_fm" Visible="false" Text='<%# Eval("PW_FM")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lbl_ca_pm" Visible="false" Text='<%# Eval("PW_PM")%>'></asp:Label>
                                                    <asp:TextBox ID="txt_CA" autocomplete="off" onfocus="this.select();" Width="50PX" CssClass="custextbox" Style="text-align: center; border: 1px solid;"
                                                        MaxLength="5" runat="server" Text='<%# Eval("PW_SM","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        Enabled="True" TargetControlID="txt_CA" ValidChars="1234567890.A">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label runat="server" ID="lbl_sca" Visible="false" Text='<%# Eval("PW_SM","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />

                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    WA
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lbl_studentID" Visible="false" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblrollno" Visible="false" Text='<%# Eval("Roll")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lbl_wa_fm" Visible="false" Text='<%# Eval("UT_FM")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lbl_wa_pm" Visible="false" Text='<%# Eval("UT_PM")%>'></asp:Label>
                                                    <asp:TextBox ID="txt_WA" autocomplete="off" Width="50PX" onfocus="this.select();" Style="text-align: center; border: 1px solid;"
                                                        MaxLength="5" CssClass="custextbox" runat="server" Text='<%# Eval("UT_SM","{0:0#.##}")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        Enabled="True" TargetControlID="txt_WA" ValidChars="1234567890.A">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label runat="server" ID="lbl_swa" Visible="false" Text='<%# Eval("UT_SM","{0:0#.##}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    GR
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_GRADE" autocomplete="off" Width="50PX" onfocus="this.select();" Style="text-align: center; border: 1px solid;"
                                                        MaxLength="5" CssClass="custextbox" runat="server" Text='<%# Eval("GRADE_SM")%>'></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender177" runat="server"
                                                        Enabled="True" TargetControlID="txt_GRADE" ValidChars="1234567890.ABCDEFGHIJKLMNOPQRSTUVWXYZ+">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:Label runat="server" ID="lbl_sgrade" Visible="false" Text='<%# Eval("GRADE_SM")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_statusID" Visible="false" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                    <asp:Label ID="lbl_status" Text="Done" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_wa_entrystatus" Visible="false" runat="server" Text='<%# Eval("ChkUTmarkentry")%>'></asp:Label>
                                                    <asp:Label ID="lbl_ca_entrystatus" Visible="false" runat="server" Text='<%# Eval("ChkPWmarkentry")%>'></asp:Label>
                                                    <asp:Label ID="lbl_grade_entrystatus" Visible="false" runat="server" Text='<%# Eval("Chkgrademarkentry")%>'></asp:Label>
                                                    <asp:Label ID="lbl_absentPW" Visible="false" runat="server" Text='<%# Eval("IsAbsentPW")%>'></asp:Label>
                                                    <asp:Label ID="lbl_absentUT" Visible="false" runat="server" Text='<%# Eval("IsAbsentUT")%>'></asp:Label>
                                                    <asp:Label ID="lbl_absentGrade" Visible="false" runat="server" Text='<%# Eval("IsAbsentgrade")%>'></asp:Label>
                                                    <asp:Label ID="lbl_isgrade" Visible="false" runat="server" Text='<%# Eval("IsGradeSubject")%>'></asp:Label>
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
                                <div class="col-md-11 customRow">
                                    <div class="form-group pull-right" style="margin-top: 0.8em;">
                                        <asp:Button ID="btn_save" OnClick="btn_save_Click" OnClientClick="javascript: return confirm('Are you sure to save the data ?');" runat="server" class="btn btn-sm btn-info button" Text="Save" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>


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

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#studentlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select exam type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
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
                        __doPostBack('<%=Gv_class_exam_subject_list.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }


        $(function () {
            $('[id*=GvExamdetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvExamdetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#studentlist table tbody tr').each(function () {
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

</asp:Content>
