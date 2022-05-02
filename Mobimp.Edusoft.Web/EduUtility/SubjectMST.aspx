<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="SubjectMST.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduUtility.SubjectMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Exam Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/SubjectMST.aspx">Add subject </a></li>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i>
            <li><a runat="server" id="a5" href="../EduUtility/ClasswiseSubjectMst.aspx">Add Classwise Subject </a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblcode" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcode" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbldescription" Text="Subject Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdescription" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclass" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlStatusID" runat="server" CssClass="form-control custextbox" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusID_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-1 customRow" style="visibility:hidden">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Subject Category"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_category" AutoPostBack="true" OnSelectedIndexChanged="ddl_category_SelectedIndexChanged" runat="server"  CssClass="form-control custextbox">
                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Regular"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Grade"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Alternative"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Optional"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-green button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" OnClientClick="return  Validate1();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
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
                            <asp:Label ID="lbl_show" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_show" Visible="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20"> 20 </asp:ListItem>
                                    <asp:ListItem Value="50"> 50 </asp:ListItem>
                                    <asp:ListItem Value="100"> 100 </asp:ListItem>
                                    <asp:ListItem Value="10000"> all</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <input type="text" class="searchs form-control custextbox" placeholder="search..">
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
                        <div id="Subjectdetails" class="col-md-12 customRow ">
                            <asp:GridView ID="GvSubjectdetails" EmptyDataText="No record found..." OnPageIndexChanging="GvSubjectdetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvSubjectdetails_Sorting" OnRowCommand="GvSubjectdetails_RowCommand" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="SubjectID" ControlStyle-Width="1%" SortExpression="SubjectID" HeaderText="ID" />
                                    <asp:BoundField DataField="CODE" ControlStyle-Width="2%" SortExpression="CODE" HeaderText="Code" />
                                    <asp:BoundField DataField="Descriptions" ControlStyle-Width="4%" SortExpression="Descriptions" HeaderText="Subject" />
                                    <asp:BoundField DataField="SubjectCategory" ControlStyle-Width="4%" SortExpression="SubjectCategory" HeaderText="Category" Visible="false"/>
                                    <asp:BoundField DataField="AddedBy" ControlStyle-Width="2%" SortExpression="AddedBy" HeaderText="Added By" />
                                    <asp:BoundField DataField="AddedDate" ControlStyle-Width="1%" SortExpression="AddedDate" HeaderText="Added Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                            <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Edits" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-deep-orange button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
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
                <div class="row mt10 hidden">
                    <div class="col-md-12 customRow">
                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                            <asp:Button ID="btnupdate" runat="server" Visible="False" class="btn btn-sm btn-success button" Text="Update" OnClick="btnupdate_Click" />

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
                $('#Subjectdetails table tbody tr').each(function () {
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
            if (document.getElementById("<%=txtcode.ClientID%>").value == "") {
                str = str + "\n Please enter code.";
                document.getElementById("<%=txtcode.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=txtdescription.ClientID%>").value == "") {
                str = str + "\n Please enter description.";
                document.getElementById("<%=txtdescription.ClientID %>").focus();
                i++;

            }
            <%--if (document.getElementById("<%=ddl_category.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please enter category.";
                document.getElementById("<%=ddl_category.ClientID %>").focus();
                i++;

            }--%>
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
                        __doPostBack('<%=GvSubjectdetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvSubjectdetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvSubjectdetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Subjectdetails table tbody tr').each(function () {
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



