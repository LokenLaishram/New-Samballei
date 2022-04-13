<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="Examverifcation.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduUtility.Examverifcation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <%-- <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduUtility/Examverifcation.aspx">Pre Exam Verification</a></li>--%>
            
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" href="../EduUtility/ExamDetail.aspx">Mark Detail&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>    

            <li><a class="active" runat="server" id="activepage"  href="../EduUtility/Examverifcation.aspx">Verification&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduExamination/SubjectWiseMarkEntry.aspx">Mark Entry&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduExamination/ResultProcessing.aspx">Result Processing&nbsp;&nbsp;</a></li>
        </ol>
        <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblmessage" Visible="false">   </asp:Label>
                                <asp:Label runat="server" ID="lblacademic" Text="Session">   </asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Visible="false">   </asp:Label>
                                <asp:Label runat="server" ID="lblclasses" Text="Class">   </asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclasses" AutoPostBack="true" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label2" Visible="false">   </asp:Label>
                                <asp:Label runat="server" ID="lblexam" Text="Exam Name">   </asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlexam" AutoPostBack="true" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnsearch_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Reset" OnClick="btncancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper" id="divsearch" runat="server" visible="false">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" Visible="false" runat="server"></asp:Label>
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
                                <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" class="form-control">
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
                </div>
                <div class="card_wrapper">
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
                        <div id="ExamVerification List" class="col-md-12 customRow ">
                            <asp:GridView ID="GvExamdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvExamdetails_PageIndexChanging"
                                CssClass="footable table-striped" OnSorting="GvExamdetails_Sorting" OnRowDataBound="GvExamdetails_RowDataBound"
                                Style="width: 100%" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" HeaderStyle-Width="1%" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Exam Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Descriptions")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="9%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Class Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                            <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblnostudent" class="form-control" Width="50px" runat="server" Text='<%# Eval("NoOfStudent")%>'></asp:TextBox>
                                            <asp:Label ID="lblchkstudent" Visible="false" runat="server" Text='<%# Eval("chkstudent")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkstd" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblnosubject" class="form-control" Width="50px" runat="server" Text='<%# Eval("NoOfSubject")%>'></asp:TextBox>
                                            <asp:Label ID="lblchksubject" Visible="false" runat="server" Text='<%# Eval("chksubject")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chksubject" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alt Student">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblalt" runat="server" class="form-control" Width="50px" Text='<%# Eval("NoOfAlt")%>'></asp:TextBox>
                                            <asp:Label ID="lblchkaltsubject" Visible="false" runat="server" Text='<%# Eval("chkaltsubject")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkaltsubject" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opt Student">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblopt" runat="server" class="form-control" Width="50px" Text='<%# Eval("NoOfOpt")%>'></asp:TextBox>
                                            <asp:Label ID="lblchkoptional" Visible="false" runat="server" Text='<%# Eval("chkoptsubject")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkoptsubject" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total FullMark">
                                        <ItemTemplate>
                                            <%--<span runat="server" id="Span2">TotalFM</span>--%>
                                            <asp:TextBox ID="lblfm" runat="server" class="form-control" Width="50px" Text='<%# Eval("TotalMark")%>'></asp:TextBox>
                                            <%--<span runat="server" id="Span1">TotalPM</span>
                                            <asp:TextBox ID="lblpm" runat="server"  Width="30px" Text='<%# Eval("TotalPassMark")%>'></asp:TextBox>--%>
                                            <asp:Label ID="lblchkmark1" Visible="false" runat="server" Text='<%# Eval("chkmark")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkmark1" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total PassMark">
                                        <ItemTemplate>
                                            <%-- <span runat="server" id="Span2">TotalFM</span>
                                            <asp:TextBox ID="lblfm"  runat="server"  Width="30px" Text='<%# Eval("TotalMark")%>'></asp:TextBox>
                                            <span runat="server" id="Span1">TotalPM</span>--%>
                                            <asp:TextBox ID="lblpm" runat="server" class="form-control" Width="50px" Text='<%# Eval("TotalPassMark")%>'></asp:TextBox>
                                            <asp:Label ID="lblchkmark" Visible="false" runat="server" Text='<%# Eval("chkmark")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkmark" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mark Entry" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchkmarkentry" Visible="false" runat="server" Text='<%# Eval("chkmarkentry")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkmarkentry" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="form-group pull-right" style="margin-top: 1.2em;">
                            <asp:Button ID="btnupdate" runat="server" Visible="false" class="btn btn-sm btn-success button" Text="Update" OnClick="btnupdate_Click" />
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
                $('#ExamVerification List table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddlacademicsession.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Session.";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
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
                        __doPostBack('<%=GvExamdetails.UniqueID%>', 'Deletes$' + paramID);
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
                $('#ClassList table tbody tr').each(function () {
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
