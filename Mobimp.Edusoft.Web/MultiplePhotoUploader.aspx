<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MultiplePhotoUploader.aspx.cs" Inherits="Mobimp.Edusoft.Web.MultiplePhotoUploader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentMultiplePhoto" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="MultiplePhotoUploader.aspx">Upload Student Photos</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="MultiplePhotoUploader">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="Academic Year"></asp:Label>
                                            <asp:DropDownList ID="ddlAcademicSessionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>
                                            <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClassID" AutoPostBack="true" runat="server" class="form-control "
                                                OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Section"></asp:Label>
                                              <span style="color: #ff0000">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlSectionID" AutoPostBack="true" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Roll No"></asp:Label>
                                            <asp:TextBox ID="txtRollNo" runat="server" class="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.6em;">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-sm btn-info button " Text="Search" OnClick="btnSearch_Click" OnClientClick="return Validate()" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                            <asp:Button ID="btnprint" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printstudentlist();" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Visible="false" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlStatus" Visible="false" AutoPostBack="true" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Uploaded</asp:ListItem>
                                                <asp:ListItem Value="0">Not Uploaded</asp:ListItem>
                                            </asp:DropDownList>
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
                                    <div id="Studentlist" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvStudentPhotoDetails"  EmptyDataText="No record found..." OnPageIndexChanging="GvStudentPhotoDetails_PageIndexChanging"
                                            CssClass="footable table-striped" AllowSorting="true" OnRowDataBound="GvStudentPhotoDetails_RowDataBound" OnSorting="GvStudentPhotoDetails_Sorting" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%">
                                            <Columns>
                                                <asp:BoundField DataField="StudentID" ItemStyle-Width="1%" SortExpression="StudentID" HeaderText="Student ID" />
                                                <asp:BoundField DataField="StudentName" SortExpression="StudentName" HeaderText="Name" />
                                                <asp:BoundField DataField="ClassName" SortExpression="ClassName" HeaderText="Class" />
                                                <asp:BoundField DataField="SectionName" SortExpression="SectionName" HeaderText="Section" />
                                                <asp:BoundField DataField="RollNo" SortExpression="RollNo" HeaderText="RollNo" />
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Class
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblclassIDs" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                        <asp:Label ID="lblclass" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <HeaderTemplate>
                                                        Sec
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsectionID" Visible="false" runat="server" Text='<%# Eval("SectionID")%>'></asp:Label>
                                                        <asp:Label ID="lblsection" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Source Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkstatus" Enabled="false" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Upload Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbluploadstatus" Visible="false" runat="server" Text='<%# Eval("IsPhotoUploaded")%>'></asp:Label>
                                                        <asp:CheckBox ID="chkuploadstatus" Enabled="false" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <%--<asp:CheckBoxField DataField="IsPhotoUploaded" SortExpression="IsPhotoUploaded" HeaderText="Source Status" />--%>
                                                <%--<asp:CheckBoxField DataField="IsPhotoUploaded" SortExpression="IsPhotoUploaded" HeaderText="Upload Status" />--%>
                                            </Columns>
                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                            <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-12 customRow">
                                            <div class="form-group pull-right" style="margin-top: 1.6em;">
                                                <asp:Button ID="btnUpdate" runat="server" Visible="false" class="btn btn-sm btn-info button " Text="Upload" OnClick="btnUpdate_Click" />
                                            </div>
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
                        __doPostBack('<%=GvStudentPhotoDetails.UniqueID%>', 'Deletes$' + paramID);
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
                document.getElementById("<%=ddlAcademicSessionID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class."
                document.getElementById("<%=ddlClassID.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddlSectionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select section."
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
                return true
            }
        }

        $(function () {

            $('[id*=GvStudentPhotoDetails]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvStudentPhotoDetails]').footable();

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
        <%--function Printstudentlist() {
            objClassID = document.getElementById("<%= ddlclasses.ClientID %>")
            objacademicID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objSection = document.getElementById("<%= ddlsections.ClientID %>")
            
            if (document.getElementById("<%=ddlclassid.ClientID%>").selectedIndex == "0") {
                alert("Please select class.");
                return false;
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                alert("Please select section.");
                return false;
            }
            if (document.getElementById("<%=ddlcategorys.ClientID%>").selectedIndex == "0") {
                alert("Please select Student Category.");
                return false;
            }
            else {
                window.open("../EduStudent/Reports/ReportViewer.aspx?option=SectionStudentList&StudentID=" + objStudentID.value + "&SessionID=" + objacademicID.value + "&SexID=" + objSex.value + "&ClassID=" + objClassID.value + "&SectionID=" + objSection.value + "&Searchtype=" + objsearchtype.value + "&SearchBy=" + objStudentname.value + "&RollNo=" + objroll.value + "&Category=" + objcategory.value)
                return true;
            }
        }--%>
    </script>

</asp:Content>
