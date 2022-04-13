<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="HostelVisitor.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduStudent.HostelVisitor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentHostelVisitor" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Hostel&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduStudent/HostelVisitor.aspx">Hostel Visitor</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="HostelVisitor">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblMessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Student ID"></asp:Label>
                                            <asp:TextBox ID="txtStudentID" MaxLength="15" OnTextChanged="txtStudentID_TextChanged" AutoPostBack="true" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtStudentID" ID="FilteredTextBoxExtender4"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetStudentIDs" MinimumPrefixLength="2" CompletionInterval="10"
                                                CompletionSetCount="1" TargetControlID="txtStudentID" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            <asp:HiddenField runat="server" ID="hdnBillGroup" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Student Name"></asp:Label>
                                            <asp:TextBox ID="txtStudentName" MaxLength="40" OnTextChanged="txtStudentName_TextChanged" AutoPostBack="true" runat="server" Class="form-control"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                                ServiceMethod="GetStdNames" MinimumPrefixLength="2" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txtStudentName" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtStudentName" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="Registration Number"></asp:Label>
                                            <asp:TextBox ID="txtRegdNo" MaxLength="15" runat="server" class="form-control"> </asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hdRegdNo" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="ddlClassID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblstatus" Text="Status"></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdnclassID" />
                                            <asp:DropDownList ID="ddlstatus" runat="server" Class="form-control">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="2">Inactive</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblvisitname" Text="Visitor Name"></asp:Label>
                                            <asp:TextBox ID="txtvisitname" MaxLength="40" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblpurpose" Text="Purpose of Visit"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtpurpose" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblvisitdate" runat="server" Text="Date of Visit"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtvisitdate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtvisitdate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtvisitdate" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbltime" Text="Visiting time"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtvisittime" MaxLength="7" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtvisittime" ID="FilteredTextBoxExtender1"
                                                runat="server" ValidChars="1234567890.amp" Enabled="true">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.5em;">
                                            <asp:Button ID="btnSave" class="btn btn-sm btn-success button" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return Validate()" />
                                            <asp:Button ID="btnSearch" class="btn btn-sm btn-info button " runat="server" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintVisitorList();" />
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
                                    <div class="wrapper">
                                        <div id="HostelVisitorList" class="col-md-12 customRow ">
                                            <asp:GridView ID="GvHostelVisit" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvHostelVisit_PageIndexChanging"
                                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvHostelVisit_Sorting" runat="server" AutoGenerateColumns="false"
                                                Style="width: 100%">
                                                <Columns>
                                                    <asp:BoundField DataField="StudentID" ItemStyle-Width="1%" SortExpression="StudentID" HeaderText="Student ID" />
                                                    <asp:BoundField DataField="RegistrationNo" ItemStyle-Width="1%" SortExpression="RegistrationNo" HeaderText="Regd. No." />
                                                    <asp:BoundField DataField="StudentName" ItemStyle-Width="1%" SortExpression="StudentName" HeaderText="Name" />
                                                    <asp:BoundField DataField="ClassName" ItemStyle-Width="1%" SortExpression="ClassName" HeaderText="Class" />
                                                    <asp:BoundField DataField="RollNo" ItemStyle-Width="1%" SortExpression="RollNo" HeaderText="Roll No" />
                                                    <asp:BoundField DataField="VisitorName" ItemStyle-Width="1%" SortExpression="VisitorName" HeaderText="VisitorName" />
                                                    <asp:BoundField DataField="VisitDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="1%" SortExpression="VisitDate" HeaderText="VisitDate" />
                                                    <asp:BoundField DataField="VisitTime" ItemStyle-Width="1%" SortExpression="VisitTime" HeaderText="Time" />
                                                    <asp:BoundField DataField="VisitPurpose" ItemStyle-Width="1%" SortExpression="VisitPurpose" HeaderText="VisitPurpose" />
                                                    <%--<asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Visit Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvisitdate" runat="server" Text='<%# Eval("VisitDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Visiting Time
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvisitime" runat="server" Text='<%# Eval("VisitTime")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Purpose of Visit
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvisitpurpose" runat="server" Text='<%# Eval("VisitPurpose")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>--%>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                            </asp:GridView>
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
                        __doPostBack('<%=GvHostelVisit.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        $(function () {

            $('[id*=GvHostelVisit]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvHostelVisit]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#HostelVisitorList table tbody tr').each(function () {
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

        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=txtStudentID.ClientID%>").value == "") {
                str = str + "\n Please enter Student ID."
                document.getElementById("<%=txtStudentID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtRegdNo.ClientID%>").value == "") {
                str = str + "\n Please enter Registration No."
                document.getElementById("<%=txtRegdNo.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtvisitname.ClientID%>").value == "") {
                str = str + "\n Please enter Visitor Name."
                document.getElementById("<%=txtvisitname.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtpurpose.ClientID%>").value == "") {
                str = str + "\n Please enter Purpose of Visit."
                document.getElementById("<%=txtpurpose.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=txtvisitdate.ClientID%>").value == "") {
                str = str + "\n Please select Date of Visit."
                document.getElementById("<%=txtvisitdate.ClientID %>").focus()
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

        function PrintVisitorList() {
            objacademicID = document.getElementById("<%= ddlAcademicSessionID.ClientID %>")
            objStudentID = document.getElementById("<%= txtStudentID.ClientID %>")
            objStudentName = document.getElementById("<%= txtStudentName.ClientID %>")
            objregno = document.getElementById("<%= txtRegdNo.ClientID %>")
            objClassID = document.getElementById("<%= ddlClassID.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")

            window.open("../EduHostel/Reports/ReportViewer.aspx?option=HostelVisitorlist&SessionID=" + objacademicID.value + "&StudentID=" + objStudentID.value + "&StudentName=" + objStudentName.value + "&RegistrationID=" + objregno.value + "&ClassID=" + objClassID.value + "&IsActive=" + objstatus.value)
        }

    </script>
</asp:Content>
