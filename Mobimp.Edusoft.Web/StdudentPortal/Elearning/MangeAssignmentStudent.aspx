<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="MangeAssignmentStudent.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.StdudentPortal.ELearning.MangeAssignmentStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a5" href="~/StdudentPortal/Elearning/DailyStudentLiveClassList.aspx">Online Class</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="~/StdudentPortal/Elearning/MangeAssignmentStudent.aspx">Assignment</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStudentID" Text="Student"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtStudentName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="lblhiddenID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensessionID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenclassID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensectionID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensession" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenclass" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensection" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenRollNo" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
                                <asp:TextBox ID="txtClass" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblSubject" Text="Subject"></asp:Label>
                                <asp:DropDownList ID="ddlSubjectID" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStatus" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Pending" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Done"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.7em;">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-blue button" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%--<asp:Timer ID="timerGridview" runat="server" Interval="100000" OnTick="timerGridview_Tick"></asp:Timer>--%>
                            <div class="row pad15">
                                <div class="col-md-4 customRow" style="margin-top: 13px;">
                                    <asp:Label ID="lblresult" runat="server" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 1em">
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
                                <div id="AssignmentList" class="col-md-12 customRow">
                                    <asp:GridView ID="GvStudentAssignment" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvStudentAssignment_PageIndexChanging"
                                        CssClass="footable table-striped" AllowSorting="false" OnSorting="GvStudentAssignment_Sorting" OnRowCommand="GvStudentAssignment_RowCommand" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%" OnRowDataBound="GvStudentAssignment_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1%>
                                                    <asp:Label ID="lbl_AsgmtID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_TeacherAssignmentID" runat="server" Visible="false" Text='<%# Eval("AssignmentID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtStudentID" Visible="false" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtClassName" runat="server" Visible="false" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtSectionName" runat="server" Visible="false" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtSubjectName" Visible="false" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtTitle" Visible="false" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtSubmissionStatus" Visible="false" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                                    <asp:Label ID="lbl_AsgmtLastDate" Visible="false" runat="server" Text='<%# Eval("LastDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="TeacherName" SortExpression="TeacherName" HeaderText="Teacher" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="Title" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="Remark" SortExpression="Remark" HeaderText="Remark" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Added On" ItemStyle-Width="1%" Visible="false"/>
                                            <asp:BoundField DataField="LastDate" SortExpression="LastDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Last Date" ItemStyle-Width="1%" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Assignment
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_AsgmtTeacher" Visible="false" runat="server" Text='<%# Eval("AssignmentFileTeacher")%>'></asp:Label>
                                                    <asp:LinkButton ID="lnk_AsgmtTeacherView" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="ViewTeacherAssignment" ValidationGroup="none" Text="View" Font-Bold="true" Font-Underline="true" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    File
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                        <ContentTemplate>--%>
                                                            <asp:FileUpload ID="fileUpload" runat="server" />
                                                        <%--</ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Action
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>--%>
                                                            <asp:Button ID="btn_AsgmtUpload" Text="Upload" CssClass="btn btn-success cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Upload" />
                                                        <%--</ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btn_AsgmtUpload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Submitted Assignment
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_AsgmtStudent" Visible="false" runat="server" Text='<%# Eval("AssignmentFile")%>'></asp:Label>
                                                    <asp:LinkButton ID="lnk_AsgmtStudentView" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="ViewSubmittedAssignment" ValidationGroup="none" Text="View" Font-Bold="true" Font-Underline="true" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubmissionStatus" SortExpression="SubmissionStatus" HeaderText="Status" ItemStyle-Width="1%" />
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                        <%--<Triggers>
                            <asp:PostBackTrigger ControlID="btn_AsgmtUpload" />
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
ipt>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AssignmentList table tbody tr').each(function () {
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

        $(function () {
            $('[id*=GvStudentAssignment]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvStudentAssignment]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#AssignmentList table tbody tr').each(function () {
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
