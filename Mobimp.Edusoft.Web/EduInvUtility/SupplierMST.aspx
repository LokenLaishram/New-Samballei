<%@ Page Language="C#"  MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" 
    CodeBehind="SupplierMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInvUtility.SupplierMST" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduInvUtility/SupplierMST.aspx">Supplier Master</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_code" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_code" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_description" Text="Supplier Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_supplier" MaxLength="100" runat="server" class="form-control custextbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_type" Text="Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList runat="server" ID="ddl_type" class="form-control custextbox">
                                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                                    <asp:ListItem Value="1">Small</asp:ListItem>
                                    <asp:ListItem Value="2"> Medium </asp:ListItem>
                                    <asp:ListItem Value="3"> Large </asp:ListItem>
                                </asp:DropDownList>
                                
                                
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_contactno" Text="Contact No."></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_contactno" MaxLength="11" runat="server" class="form-control custextbox"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txt_contactno" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="1234567890" Enabled="True"></asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                         <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_status" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddl_status" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true"
                                    runat="server" class="form-control ">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>                  
                    <div class="row mt10">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-green button" OnClientClick="return Validate();" OnClick="btnsave_Click" Text="Add" />
                                        <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btncancel_Click" Text="Cancel" />
                                        <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" OnClientClick="return PrintSupplierList()" runat="server" Text="Print" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnsave" />
                                        <asp:PostBackTrigger ControlID="btncancel" />
                                    </Triggers>
                                </asp:UpdatePanel>
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
                        <div id="companylist" class="col-md-12 customRow ">
                            <asp:GridView ID="Gv_supplier" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="Gv_supplier_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="Gv_supplier_Sorting" OnRowCommand="Gv_supplier_RowCommand" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="SupplierID" SortExpression="SupplierID" HeaderText="ID" />
                                    <asp:BoundField DataField="Code" SortExpression="Code" HeaderText="Code" />
                                    <asp:BoundField DataField="Supplier" SortExpression="Supplier" HeaderText="Supplier" />
                                    <asp:BoundField DataField="Type" SortExpression="Type" HeaderText="Type" />
                                    <asp:BoundField DataField="ContactNo" SortExpression="ContactNo" HeaderText="ContactNo" />
                                    <asp:BoundField DataField="EmpName" SortExpression="EmpName" HeaderText="Added By" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" Width="100px" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("SupplierID")%>'></asp:Label>
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
                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Activate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Button ID="btn_activate" runat="server" class="cus-btn btn-sm btn-info button" Text="Activate" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="activate" />
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
                $('#companylist table tbody tr').each(function () {
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
            if (document.getElementById("<%=txt_code.ClientID%>").value == "") {
                str = str + "\n Please enter Code.";
                document.getElementById("<%=txt_code.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_supplier.ClientID%>").value == "") {
                str = str + "\n Please enter supllier.";
                document.getElementById("<%=txt_supplier.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_type.ClientID%>").value == "0") {
                str = str + "\n Please enter address.";
                document.getElementById("<%=ddl_type.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_contactno.ClientID%>").value == "") {
                str = str + "\n Please enter pin.";
                document.getElementById("<%=txt_contactno.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_supplier.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_supplier]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_supplier]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#companylist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function PrintSupplierList() {
            objtypeid = document.getElementById("<%= ddl_type.ClientID%>")
            objstatus = document.getElementById("<%= ddl_status.ClientID %>")
            window.open("../EduInvUtility/Reports/ReportViewer.aspx?option=SupplierList&SupplierID=" + objtypeid.value + "&status=" + objstatus.value)
        }
    </script>
</asp:Content>
