<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="SubjectTeacherMapping.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.ELearning.SubjectTeacherMapping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>E-Learning&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a5" href="../ELearning/SubjectTeacherMapping.aspx">Subject Teacher Mapping</a>&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a2" href="~/TimeTable/TeacherwiseClassAllocation.aspx">Assign Class</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblAcademicSessionID" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlAcademicSessionID" runat="server" class="form-control" OnSelectedIndexChanged="ddlAcademicSessionID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server" Enabled="True"
                                    TargetControlID="txtcode" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" -">
                                </asp:FilteredTextBoxExtender>--%>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblDayID" Text="Day"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlDayID" runat="server" class="form-control" OnSelectedIndexChanged="ddlDayID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblClassID" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlClassID" runat="server" class="form-control" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblSectionID" Text="Section"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSectionID" runat="server" class="form-control" OnSelectedIndexChanged="ddlSectionID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblSubjectID" Text="Subject"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSubjectID" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblTeacherID" Text="Teacher"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtTeacherID" runat="server" class="form-control" AutoPostBack="true"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="GetAutoTeachingStaffList" MinimumPrefixLength="1"
                                    CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtTeacherID" UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                </asp:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="col-md-8 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblVideoLink" Text="Video Link"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtVideoLink" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStartTime" Text="Start Time"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <cc1:TimeSelector ID="timeStart" runat="server" class="form-control"  CssClass="custimepick"></cc1:TimeSelector>
                                <%--<asp:TextBox ID="txtStartTime" runat="server" class="TimePick form-control" MaxLength="8"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                Enabled="True" TargetControlID="txtStartTime" FilterType="Numbers,Custom" ValidChars=" :AMPamp">
                                </asp:FilteredTextBoxExtender>--%>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblEndTime" Text="End Time"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <cc1:TimeSelector ID="timeEnd" runat="server" class="form-control" CssClass="custimepick"></cc1:TimeSelector>
                                <%--<asp:TextBox ID="txtEndTime" runat="server" class="form-control TimePicker" MaxLength="8"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                Enabled="True" TargetControlID="txtEndTime" FilterType="Numbers,Custom" ValidChars=" :AMPamp">
                                </asp:FilteredTextBoxExtender>--%>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStatus" Text="Status"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged1" AutoPostBack="true">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-green button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-blue button" Text="Search" OnClick="btnSearch_Click1" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btncancel_Click" />
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
                                Style="width: 100%" >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl.No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                            <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DayName" SortExpression="DayName" HeaderText="Day" ItemStyle-Width="1%"/>
                                    <asp:BoundField DataField="TeacherStartTime" DataFormatString="{0:h:mm tt}" SortExpression="TeacherStartTime" HeaderText="Start Time" ItemStyle-Width="1%"/>
                                    <asp:BoundField DataField="TeacherEndTime" DataFormatString="{0:h:mm tt}" SortExpression="TeacherEndTime" HeaderText="End Time" ItemStyle-Width="1%"/>
                                    <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" ItemStyle-Width="1%"/>
                                    <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" ItemStyle-Width="1%"/>
                                    <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject" ItemStyle-Width="1%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true"/>
                                    <asp:BoundField DataField="TeacherName" SortExpression="TeacherName" HeaderText="Teacher" ItemStyle-Width="4%" ItemStyle-Font-Italic="true" ItemStyle-Font-Bold="true"/>
                                    <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            Start Time
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_StartTime" runat="server" Text='<%# Eval("StartTime","{0:h:mm tt}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            End Time
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_EndTime" runat="server" Text='<%# Eval("EndTime","{0:h:mm tt}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Video Link
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="HyperLink" NavigateUrl='<%# String.Format(Eval("VideoLink").ToString()) %>'
                                                Text="Click Here"></asp:HyperLink>
                                            <asp:Label ID="lbl_Link" Visible="false" runat="server" Text='<%# Eval("VideoLink")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_Edit" Text="Edit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Edits" CssClass="btn btn-info cus_btn"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_delete" Text="Delete" runat="server" CssClass="btn btn-danger cus_btn"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

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
            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Academic Session \n"
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlDayID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Day \n"
                document.getElementById("<%=ddlDayID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Class \n"
                document.getElementById("<%=ddlClassID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlSectionID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Section \n"
                document.getElementById("<%=ddlSectionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlSubjectID.ClientID%>").selectedIndex == "0") {
                str = str + " Please select Subject \n"
                document.getElementById("<%=ddlSubjectID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtTeacherID.ClientID%>").value == "") {
                str = str + " Please assign Teacher \n"
                document.getElementById("<%=txtTeacherID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtVideoLink.ClientID%>").value == "") {
                str = str + "\n Please enter Video Link";
                document.getElementById("<%=txtVideoLink.ClientID %>").focus();
                i++;
            }
            <%--if (document.getElementById("<%=txtStartTime.ClientID%>").value == "") {
                str = str + "\n Please enter Start Time";
                document.getElementById("<%=txtStartTime.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtEndTime.ClientID%>").value == "") {
                str = str + "\n Please enter End Time";
                document.getElementById("<%=txtEndTime.ClientID %>").focus();
                i++;
            }--%>
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
                        __doPostBack('<%=GvSubjectTeacher.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
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
