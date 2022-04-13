<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="DailyStudentLiveClassList.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.StdudentPortal.ELearning.DailyStudentLiveClassList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a5" href="/StdudentPortal/Elearning/DailyStudentLiveClassList.aspx">Online Class</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        
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
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStudentID" Text="Student"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtStudentName" runat="server" class="form-control"></asp:TextBox>
                                <asp:Button ID="btn_TotalStudents" runat="server" />
                                <asp:Button ID="btn_TotalAttended" runat="server" />
                                <asp:Label ID="lblhiddenID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensessionID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensession" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenclassID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenclass" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensectionID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddensection" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblhiddenRollNo" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-blue button" Text="Search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Timer ID="timerGridview" runat="server" Interval="10000" OnTick="timerGridview_Tick"></asp:Timer>
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
                                <div id="StudentList" class="col-md-12 customRow">
                                    <asp:GridView ID="GvStudentOnlineClass" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvStudentOnlineClass_PageIndexChanging"
                                        CssClass="footable table-striped" AllowSorting="false" OnSorting="GvStudentOnlineClass_Sorting" OnRowCommand="GvStudentOnlineClass_RowCommand" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%" OnRowDataBound="GvStudentOnlineClass_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sl.No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1%>
                                                    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_SessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_DayID" runat="server" Visible="false" Text='<%# Eval("DayID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_ClassID" runat="server" Visible="false" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_SectionID" runat="server" Visible="false" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_RollNo" runat="server" Visible="false" Text='<%# Eval("RollNo")%>'></asp:Label>
                                                    <asp:Label ID="lbl_LiveClassID" runat="server" Visible="false" Text='<%# Eval("LiveClassID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_SubjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_StartTime" Visible="false" runat="server" Text='<%# Eval("StartTime","{0:h:mm tt}")%>'></asp:Label>
                                                    <asp:Label ID="lbl_EndTime" Visible="false" runat="server" Text='<%# Eval("EndTime","{0:h:mm tt}")%>'></asp:Label>
                                                    <asp:Label ID="lbl_VideoLink" Visible="false" runat="server" Text='<%# Eval("VideoLink")%>'></asp:Label>
                                                    <asp:Label ID="lbl_ClassDate" Visible="false" runat="server" Text='<%# Eval("ClassDate")%>'></asp:Label>
                                                    <asp:Label ID="lbl_TeacherClassID" Visible="false" runat="server" Text='<%# Eval("TeacherClassID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DayName" SortExpression="DayName" HeaderText="Day" ItemStyle-Width="1%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="StartTime" DataFormatString="{0:h:mm tt}" SortExpression="StartTime" HeaderText="Start Time" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="EndTime" DataFormatString="{0:h:mm tt}" SortExpression="EndTime" HeaderText="End Time" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%" />
                                            <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true" />
                                            <asp:BoundField DataField="TeacherName" SortExpression="TeacherName" HeaderText="Teacher Name" ItemStyle-Width="1%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Action
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_OnlineClassStatus" Visible="false" runat="server" Text='<%# Eval("ClassStatus")%>'></asp:Label>
                                                    <asp:Button ID="btn_Action" Text="Start" CssClass="btn btn-info cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="JoinClass" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IsPresent" SortExpression="IsPresent" HeaderText="Attendance" ItemStyle-Width="1%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true" />
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#StudentList table tbody tr').each(function () {
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
            if (document.getElementById("<%=txtStudentName.ClientID%>").value == "") {
                str = str + " Please check Teacher \n"
                document.getElementById("<%=txtStudentName.ClientID %>").focus()
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
                        __doPostBack('<%=GvStudentOnlineClass.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        $(function () {
            $('[id*=GvStudentOnlineClass]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvStudentOnlineClass]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#StudentList table tbody tr').each(function () {
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
