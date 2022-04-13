<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ExamRankTieRule.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.ExamRankTieRule" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduExamination/ExamRankTieRule.aspx">Exam Rank Tie Rule Master</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblgrade" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSessionID" runat="server" class="form-control custextbox">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Text="Exam"></asp:Label>
                                <asp:DropDownList ID="ddlExamID" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbldescription" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlClassID" runat="server" class="form-control custextbox"
                                    AutoPostBack="true" OnTextChanged="ddlExamID_OnTextChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" Text="Add New Row" OnClick="btnsave_Click" />
                                <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_OnClick" />

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
                                    <asp:LinkButton ID="btn_export" Visible="false" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn_export" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-3 customRow" style="text-align: right; margin-top: 1em;">
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
                        <div id="ClassList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvExamRankTieRule" AllowPaging="false" AllowCustomPaging="true" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                CssClass="footable table-striped" AllowSorting="true" runat="server"
                                Style="width: 100%">
                                <%-- OnSorting="GvExamRankTieRule_Sorting" OnRowCommand="GvExamRankTieRule_RowCommand"--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            <asp:Label ID="lblClassID" runat="server" Visible="false" Text='<%# Eval("ClassID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of the Exam">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExam" runat="server" Text='<%# Eval("ExamName") %>'></asp:Label>
                                            <asp:Label ID="lblExamID" runat="server" Visible="false" Text='<%# Eval("ExamID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Mark RankTies">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtParticular" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("Particular")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtParticular" ID="FilteredTextBoxExtender3" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz.1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPriority" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("Priority")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtPriority" ID="FilteredTextBoxExtender2" runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button" Visible="true" OnClientClick="javascript: return confirm('Are you sure want to update?');" Text="Update" OnClick="btnupdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                            
        <%-- <%----POP-UP ROW-----%>
        <div class="row">
            <asp:ModalPopupExtender ID="WorkOrderPopup" BehaviorID="modalbehavior4" TargetControlID="btn_add" runat="server" PopupControlID="StockEntryPopUpWindow"
                BackgroundCssClass="modalBackground" Enabled="True" CancelControlID="btnclose">
            </asp:ModalPopupExtender>
            <asp:Panel runat="server" ID="StockEntryPopUpWindow" CssClass="ModalPopUpPanelBg " Style="display: none; width: 80%; margin-top: -10px;">
                <div class="row" style="border-bottom: 0px solid green;">
                    <div class="col-sm-4">
                        <h5>Stock Entry With WO/PO </h5>
                    </div>
                    <div class="col-md-7 ">
                        <asp:Label ID="lblpopMessage" runat="server" Style="color: red;"></asp:Label>
                    </div>
                    <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                        <asp:LinkButton ID="btnclose" runat="server"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                </div>

            </asp:Panel>
            <asp:Button ID="btn_add" runat="server" Text="pop" />
        </div>
        <%----/POP-UP ROW-----%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {
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

        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlSessionID.ClientID%>").value == "") {
                str = str + "\n Please select academic session.";
                document.getElementById("<%=ddlSessionID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").value == "") {
                str = str + "\n Please select name of the clase.";
                document.getElementById("<%=ddlClassID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlExamID.ClientID%>").value == "") {
                str = str + "\n Please select name of the clase.";
                document.getElementById("<%=ddlExamID.ClientID %>").focus();
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
                        __doPostBack('<%=GvExamRankTieRule.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvExamRankTieRule]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvExamRankTieRule]').footable();

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
