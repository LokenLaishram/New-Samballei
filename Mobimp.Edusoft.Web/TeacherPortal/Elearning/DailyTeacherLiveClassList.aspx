<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="DailyTeacherLiveClassList.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.TeacherPortal.ELearning.DailyTeacherLiveClassList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
            <div class="container-fluid" id="page_wrapper">
                <ol class="breadcrumb">
                    <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a class="active" runat="server" id="a5" href="/TeacherPortal/Elearning/DailyTeacherLiveClassList.aspx">Online Class</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
                    <li><a runat="server" id="a1" href="/TeacherPortal/Elearning/ManageAssignment.aspx">Assignment</a></li>
                </ol>

                <div id="divMain" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10" >
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    <asp:Label runat="server" ID="lblDayID" Text="Day"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlDayID" runat="server" class="form-control" OnSelectedIndexChanged="ddlDayID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblDate" Text="Date"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtDate" type="text" runat="server" class="form-control" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtDate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate" />
                                </div>
                            </div>
                            <div class="col-md-5 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblTeacherID" Text="Teacher"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtTeacherName" runat="server" class="form-control"></asp:TextBox>
                                    <asp:Button ID="btn_TotalStudents" runat="server" />
                                    <asp:Button ID="btn_TotalAttended" runat="server" />
                                    <asp:Label ID="lblhiddenID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensessionID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensession" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenclassID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenclass" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensectionID" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddensection" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenTotalStudent" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblhiddenTotalStudentAttended" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group pull-right" style="margin-top:1.8em">
                                    <asp:Button ID="btnUpdateTop" runat="server" visible="false" class="btn btn-sm btn-success button" Text="Update" OnClick="btnUpdateTop_Click" />
                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btncancel_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row mt10" id="divVideo" runat="server" visible="false" style="margin-top:0em">
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
                                    <asp:TextBox ID="txtClass" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="Label4" Text="Subject"></asp:Label>
                                    <asp:TextBox ID="txtSubject" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5 customRow" >
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblVideoLink" Text="Class Link"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:TextBox ID="txtVideoLink" runat="server" class="form-control"></asp:TextBox>
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
                                        <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size: 48px;"></i></asp:LinkButton>
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
                            <div id="SubjectTeacherList" class="col-md-12 customRow">
                                <asp:GridView ID="GvSubjectTeacher" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvSubjectTeacher_PageIndexChanging"
                                    CssClass="footable table-striped" AllowSorting="true" OnSorting="GvSubjectTeacher_Sorting" OnRowCommand="GvSubjectTeacher_RowCommand" runat="server" AutoGenerateColumns="false"
                                    Style="width: 100%" OnRowDataBound="GvSubjectTeacher_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                <asp:Label ID="lbl_SessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_Session" Visible="false" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                                <asp:Label ID="lbl_DayID" runat="server" Visible="false" Text='<%# Eval("DayID")%>'></asp:Label>
                                                <asp:Label ID="lbl_ClassID" runat="server" Visible="false" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                <asp:Label ID="lbl_Class" runat="server" Visible="false" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                <asp:Label ID="lbl_SectionID" runat="server" Visible="false" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_Section" runat="server" Visible="false" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                <asp:Label ID="lbl_LiveClassID" runat="server" Visible="false" Text='<%# Eval("LiveClassID")%>'></asp:Label>
                                                <asp:Label ID="lbl_SubjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                <asp:Label ID="lbl_StartTime" Visible="false" runat="server" Text='<%# Eval("StartTime","{0:h:mm tt}")%>'></asp:Label>
                                                <asp:Label ID="lbl_EndTime" Visible="false" runat="server" Text='<%# Eval("EndTime","{0:h:mm tt}")%>'></asp:Label>
                                                <asp:Label ID="lbl_VideoLink" Visible="false" runat="server" Text='<%# Eval("VideoLink")%>'></asp:Label>
                                                <asp:Label ID="lbl_ClassDate" Visible="false" runat="server" Text='<%# Eval("ClassDate")%>'></asp:Label>
                                                <asp:Label ID="lbl_TeacherID" Visible="false" runat="server" Text='<%# Eval("TeacherID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DayName" SortExpression="DayName" HeaderText="Day" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="StartTime" DataFormatString="{0:h:mm tt}" SortExpression="StartTime" HeaderText="Start Time" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="EndTime" DataFormatString="{0:h:mm tt}" SortExpression="EndTime" HeaderText="End Time" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" ItemStyle-Width="1%" />
                                        <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" Visible="false" />
                                        <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Change Link
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_Edit" Text="Edit" CssClass="btn btn-info cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Edits" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Action
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_OnlineClassStatus" Visible="false" runat="server" Text='<%# Eval("ClassStatus")%>'></asp:Label>
                                                <asp:Button ID="btn_Action" Text="Start" CssClass="btn btn-success cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="Start" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                IsEnded
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_EndClass" Text="End Class" CssClass="btn btn-danger cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="EndClass" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Total Student
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_TotalStudent" runat="server" Visible="false" Text='<%# Eval("TotalStudent")%>'></asp:Label>
                                                <asp:LinkButton ID="lnk_TotalStudent" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="ViewTotalStudents" ValidationGroup="none" Text='<%# Eval("TotalStudent")%>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Total Attended
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_TotalAttended" Visible="false" runat="server" Text='<%# Eval("TotalAttended")%>'></asp:Label>
                                                <asp:LinkButton ID="lnk_TotalAttended" CssClass=" small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                    CommandName="ViewTotalStudentsAttended" ValidationGroup="none" Text='<%# Eval("TotalAttended")%>' />
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

                <%--TotalStudents Div--%>
                <div id="divTotalStudents" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblsessionTotalStudents" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionTotalStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclassTotalStudents" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassTotalStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblSectionTotalStudents" runat="server" Text="Section"></asp:Label>
                                        <asp:Label ID="lblSectionTotalStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalStudentTotalStudents" runat="server" Text="Total Students"></asp:Label>
                                        <asp:Label ID="lblTotalStudentTotalStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow pull-right">
                                    <div class="form-group" style="margin-top: 1.8em;">
                                        <asp:LinkButton ID="btn_back_1" OnClick="btn_back_1_Click" runat="server" class="btn btn-sm btn-info button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 customRow" style="margin-top: 1em">
                                <asp:GridView ID="GvTotalStudents" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="footable table-striped" runat="server"
                                    Style="width: 100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student ID
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_StdIDTotalStudents" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_StdNameTotalStudents" runat="server" Text='<%# Eval("StudentDetail")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_RollNoTotalStudents" Text='<%# Eval("RollNo")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <%--AttendedStudents Div--%>
                <div id="divAttendedStudents" runat="server" visible="false">
                    <div class="card_wrapper">
                        <div class="row mt10">
                            <div class="row col-md-12">
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblsessionpop2" Text="Session"></asp:Label>
                                        <asp:Label ID="lblsessionAttendedStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblclasspop2" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lblclassAttendedStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblSectionPop2" runat="server" Text="Section"></asp:Label>
                                        <asp:Label ID="lblSectionAttendedStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-2 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblTotalAttendedPop2" runat="server" Text="Total Students Attended"></asp:Label>
                                        <asp:Label ID="lblTotalAttendedStudents2" runat="server" class="form-control">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-1 customRow pull-right">
                                    <div class="form-group" style="margin-top: 1.8em;">
                                        <asp:LinkButton ID="btn_back_2" OnClick="btn_back_2_Click" runat="server" class="btn btn-sm btn-info button">
                                            <i class="fa fa-arrow-left"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 customRow" style="margin-top: 1em">
                                <asp:GridView ID="GvTotalAttended" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="footable table-striped" runat="server"
                                    Style="width: 100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl.No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                                <asp:Label ID="lbl_AttendID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student ID
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_StdIDAttendedStudents" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_StdNameAttendedStudents" runat="server" Text='<%# Eval("StudentDetail")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Roll No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_RollNoAttendedStudents" Text='<%# Eval("RollNo")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Attendance
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_StudentAttendance" Visible="false" Text='<%# Eval("IsPresent")%>' runat="server"></asp:Label>
                                                <asp:DropDownList ID="ddl_StudentAttendance" Class="form-control" runat="server">
                                                    <asp:ListItem Value="0">Absent</asp:ListItem>
                                                    <asp:ListItem Value="1" Selected="True">Present</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-12 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.6em;">
                                    <asp:Button ID="btnUpdateBottom" runat="server" class="btn btn-sm btn-success button" Text="Update" OnClick="btnUpdateBottom_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SubjectTeacherList table tbody tr').each(function () {
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

            if (document.getElementById("<%=ddlDayID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Day \n"
                document.getElementById("<%=ddlDayID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtDate.ClientID%>").value == "") {
                str = str + "\n Please select Date";
                document.getElementById("<%=txtDate.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtTeacherName.ClientID%>").value == "") {
                str = str + " Please check Teacher \n"
                document.getElementById("<%=txtTeacherName.ClientID %>").focus()
                i++
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

        $(function () {
            $('[id*=GvSubjectTeacher]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvSubjectTeacher]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SubjectTeacherList table tbody tr').each(function () {
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
