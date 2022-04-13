<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ClassIX_X_SubjectSetting.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduStudent.ClassIX_X_SubjectSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduStudent/ClassIX_X_SubjectSetting.aspx">Optional Subject Manager</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="SubjectManager">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlAcademicSessionID" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Class"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClassID" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Section"></asp:Label>
                                            <asp:DropDownList ID="ddlSectionID" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionID_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtRollNo" runat="server" AutoPostBack="true" OnTextChanged="txtRollNo_TextChanged" class="form-control custextbox">
                                            </asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtRollNo" ID="FilteredTextBoxExtender3"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="Optional"></asp:Label>
                                            <asp:DropDownList ID="ddlOptSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOptSubject_SelectedIndexChanged" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label10" runat="server" Text="Alternative"></asp:Label>
                                            <asp:DropDownList ID="ddlAltSubject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAltSubject_SelectedIndexChanged" class="form-control custextbox">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.7em;">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-info button " Text="Search" OnClick="btnSearch_Click" OnClientClick="return Validate()" />
                                            <asp:Button ID="btnprint" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintStudentSubject();" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
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
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control custextbox">
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
                                        <input type="text" class="searchs form-control custextbox" placeholder="search..">
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
                                    <div id="Studentlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvStudentSubjectDetails" EmptyDataText="No record found..." OnPageIndexChanging="GvStudentSubjectDetails_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnRowDataBound="GvStudentSubjectDetails_RowDataBound" OnSorting="GvStudentSubjectDetails_Sorting" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:BoundField DataField="StudentID" ItemStyle-Width="1%" SortExpression="StudentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="StudentName" ItemStyle-Font-Bold="true" ItemStyle-Width="4%" SortExpression="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="ClassName" ItemStyle-Width="1%" SortExpression="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" ItemStyle-Width="1%" SortExpression="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="RollNo" ItemStyle-Width="1%" SortExpression="RollNo" HeaderText="Roll No" />
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Optional
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                        <asp:Label ID="lblSectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lbloptional" Visible="false" runat="server" Text='<%# Eval("OptSubjectID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddloptionalsubject" Class="form-control gridtextbox" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Alternative
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaltsubject" Visible="false" runat="server" Text='<%# Eval("AltSubjectID")%>'></asp:Label>
                                                        <asp:DropDownList ID="ddlaltsubject" Class="form-control gridtextbox" runat="server">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.7em;">
                                            <asp:Button ID="btnUpdate" runat="server" Visible="false" class="btn btn-sm btn-info button " Text="Update" OnClick="btnUpdate_Click1" />
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
                        __doPostBack('<%=GvStudentSubjectDetails.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlAcademicSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select session."
                i++
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
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

        $(function () {

            $('[id*=GvStudentSubjectDetails]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvStudentSubjectDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Studentlist table tbody tr').each(function () {
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
        function PrintStudentSubject() {
            var str = ""
            var i = 0
            objClassID = document.getElementById("<%= ddlClassID.ClientID %>")
            objacademicID = document.getElementById("<%= ddlAcademicSessionID.ClientID %>")
            objSection = document.getElementById("<%= ddlSectionID.ClientID %>")
            objroll = document.getElementById("<%= txtRollNo.ClientID %>")
            if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Class."
                document.getElementById("<%=ddlClassID.ClientID %>").focus()
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
                window.open("../EduStudent/Reports/ReportViewer.aspx?option=StudentSubjectManager&SessionID=" + objacademicID.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&RollNo=" + objroll.value)
                return true;
            }
        }
    </script>
</asp:Content>
