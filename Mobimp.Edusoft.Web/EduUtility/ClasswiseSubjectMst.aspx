<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ClasswiseSubjectMst.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduUtility.ClasswiseSubjectMst" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Exam Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a1" href="../EduUtility/SubjectMST.aspx">Add subject </a></li>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i>
            <li><a class="active" runat="server" id="a10" href="../EduUtility/ClasswiseSubjectMst.aspx">Add Classwise Subject</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_session" runat="server" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSessionID" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclass" runat="server" class="form-control custextbox"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSubjectID" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged" AutoPostBack="true" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Subject Category"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_category" AutoPostBack="true" OnSelectedIndexChanged="ddl_category_SelectedIndexChanged" runat="server"  CssClass="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control custextbox">
                                    <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-green button" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" Visible="false" class="btn btn-sm btn-info button" runat="server" OnClientClick="return  Validate1();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                <asp:Button ID="btnopen2" runat="server" />
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
                                    <asp:BoundField DataField="SubjectID" ItemStyle-Width="1%" SortExpression="SubjectID" HeaderText="ID" />
                                    <asp:BoundField DataField="ClassName" ItemStyle-Width="2%" SortExpression="ClassName" HeaderText="Class" />
                                    <asp:BoundField DataField="CODE" ItemStyle-Width="2%" SortExpression="CODE" HeaderText="Code" />
                                    <asp:BoundField DataField="Descriptions" ItemStyle-Width="2%" SortExpression="Descriptions" HeaderText="Subject" />
                                    <asp:BoundField DataField="SubjectCategory" ItemStyle-Width="2%" SortExpression="SubjectCategory" HeaderText="SubjectCategory" />
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            <%--Subject Type--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddloptionalsubject" Class="form-control gridtextbox" runat="server">
                                                <asp:ListItem> Main </asp:ListItem>
                                                <asp:ListItem> Optional </asp:ListItem>
                                                <asp:ListItem> Alternative </asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Add
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn_add" class="cus-btn btn-sm btn-info button" runat="server" Text="Sub Subject" OnClick="btn_add_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sub Subjects
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_subsubjects" runat="server" Text='<%# Eval("Subsubjectlist")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AddedBy" ItemStyle-Width="1%" SortExpression="AddedBy" HeaderText="Added By" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" Height="20px" Width="70px" class="form-control gridtextbox" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="lblclassname" Visible="false" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                            <asp:Label ID="lblSubjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                            <asp:Label ID="lbl_subjectname" Visible="false" runat="server" Text='<%# Eval("Descriptions")%>'></asp:Label>
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
                <asp:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="modalbehavior2" runat="server" TargetControlID="btnopen2" PopupControlID="Popupwindow2"
                    BackgroundCssClass="modalBackground" Enabled="True">
                </asp:ModalPopupExtender>
                <asp:Panel runat="server" ID="Popupwindow2" BackColor="White" Style="display: none; width: 800px; height:300px">
                    <div class="row">
                        <div class="col-sm-11">
                            <h5>Add Sub Subject</h5>
                        </div>
                        <div class="col-sm-1" style="padding: 0px 9px; font-size: large;">
                            <asp:LinkButton ID="btn_close" OnClick="btn_close_Click" runat="server"><i class="fa fa-close" style="color: #ff011c;" ></i></asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_class" runat="server" Text="Class"></asp:Label>
                                        <asp:Label ID="lbl_classname" class="form-control custextbox" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_classid" Visible="false" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_subject" runat="server" Text="Subject"></asp:Label>
                                        <asp:Label ID="lbl_subjectname" class="form-control custextbox" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_subjectid" Visible="false" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_subsubjectID" Visible="false" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_subsubject" runat="server" Text="Sub Subject"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:TextBox ID="txt_sub_subject" runat="server" class="form-control custextbox"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                            ServiceMethod="GetAutoSubSubjectName" MinimumPrefixLength="1"
                                            CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt_sub_subject"
                                            UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                        </asp:AutoCompleteExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="Label7" runat="server" Text="Status"></asp:Label>
                                        <asp:DropDownList ID="ddl_substatus" AutoPostBack="true" OnSelectedIndexChanged="ddl_substatus_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                            <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-9 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btn_addsub" runat="server" class="btn btn-sm btn-green button" Text="Add" OnClick="btn_addsub_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:GridView ID="gv_subsubject" EmptyDataText="No record found..." OnRowCommand="gv_subsubject_RowCommand"
                                        CssClass="table-striped table-hover" runat="server" AutoGenerateColumns="false"
                                        Style="width: 100%" GridLines="None">
                                        <Columns>
                                            <asp:BoundField DataField="ID" ItemStyle-Width="1%" SortExpression="ID" HeaderText="ID" />
                                            <asp:BoundField DataField="Descriptions" SortExpression="Descriptions" HeaderText="Subject" ItemStyle-Width="3%" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Edit
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_subjectID" Visible="false" runat="server" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                    <asp:Label ID="lbl_classID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
                                                    <asp:Button ID="lnkEdit" Text="Edit" Height="20PX" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Edits" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkDelete" Height="20PX" class="cus-btn btn-sm btn-deep-orange button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletes" ValidationGroup="none" />
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
                </asp:Panel>
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
            if (document.getElementById("<%=ddlSessionID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select academic session.";
                document.getElementById("<%=ddlSessionID.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclass.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=ddlSubjectID.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subject.";
                document.getElementById("<%=ddlSubjectID.ClientID %>").focus();
                i++;

            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }
        function Validate1() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select class.";
                document.getElementById("<%=ddlclass.ClientID %>").focus();
                i++;

            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
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
