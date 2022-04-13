<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="LeaveTypeMST.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.Utility.LeaveTypeMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/Utility/LeaveTypeMST.aspx">Leave Type</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt12">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblcode" runat="server" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" ID="txtcode" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblleavetype" runat="server" Text="Leave Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtleavetype" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_nodays" runat="server" Text="No. Vaild Days"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_nodays" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="txt_filter_height" runat="server"
                                    Enabled="True" TargetControlID="txt_nodays" FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Applicable For"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_applicablefor" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblisactive" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddl_isactive" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_isactive_SelectedIndexChanged" class="form-control">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnAdd" class="btn btn-sm btn-success button" OnClick="btnadd" runat="server" Text="Add" />
                                <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" OnClick="btncancel_Click" runat="server" Text="Reset" />
                                <asp:Button ID="btnPrint" Visible="false" class="btn btn-sm btn-indigo" runat="server" Text="Print" OnClientClick="return PrintLeaveType();" />
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
                            <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" class="form-control">
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
                        <div id="LeaveType" class="col-md-12 customRow ">
                            <asp:GridView ID="GvLeaveType" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvLeaveTypeDetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnSorting="GvLeaveType_Sorting" OnRowCommand="GvLeaveType_RowCommand"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="LeaveId" SortExpression="LeaveId" HeaderText="Sl" ItemStyle-Width="2%" />
                                    <asp:BoundField DataField="Code" SortExpression="Code" HeaderText="Code" />
                                    <asp:BoundField DataField="LeaveType" SortExpression="LeaveType" HeaderText="Leave Type" />
                                    <asp:BoundField DataField="Nodays" SortExpression="Nodays" HeaderText="No. Valid Days" />
                                     <asp:BoundField DataField="LeaveApplicablefor" SortExpression="LeaveApplicablefor" HeaderText="Appicable for" />
                                    <asp:BoundField DataField="AddedBy" Visible="false" SortExpression="AddedBy" HeaderText="Added By" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("LeaveId")%>'></asp:Label>
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
                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
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

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">       
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#LeaveType table tbody tr').each(function () {
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

        function Validate() {

            var str = "";
            var i = 0;

            if (document.getElementById("<%=txtcode.ClientID%>").value == "") {
                str = str + "\n Please Enter the Code.";
                document.getElementById("<%=txtcode.ClientID %>").focus();
                i++;

            }
            if (document.getElementById("<%=txtleavetype.ClientID%>").value == "") {
                str = str + "\n Please Enter the type of leave.";
                document.getElementById("<%=txtleavetype.ClientID%>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_isactive.ClientID%>").value == "") {
                str = str + "\n Please Select either Active or InActive.";
                document.getElementById("<%=ddl_isactive.ClientID%>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        function PrintLeaveType() {
            objCode = document.getElementById("<%= txtcode.ClientID %>");
            objName = document.getElementById("<%= txtleavetype.ClientID %>");
            objStatus = document.getElementById("<%= ddl_isactive.ClientID %>");

            window.open("../Utility/Reports/ReportViewer.aspx?option=LeaveType&Code=" + objCode.value + "&Name=" + objName.value + "&Status=" + objStatus.value)
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
                        __doPostBack('<%=GvLeaveType.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }
        //$(function () {
        //    $('[id*=GvLeaveType]').footable();
        //});
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvLeaveType]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#LeaveType table tbody tr').each(function () {
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
