<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="PaymentTypeMST.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduFeeUtility.PaymentTypeMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fee Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduFeeUtility/PaymentTypeMST.aspx">Payment Type Manager</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lbldescription" Text="Payment Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdescription" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-left" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-success button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                            </div>
                        </div>
                        <div class="col-sm-6 customRow" style="margin-top:2.1em">
                            <div class="form-group">
                                <asp:Label runat="server" ForeColor="Red" Font-Bold="true" ID="lbl_errormessage" Text="Please contact Campusoft Technical Team on addition of new Payment Type."></asp:Label>
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
                                <asp:DropDownList ID="ddl_show" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="20"> 20 </asp:ListItem>
                                    <asp:ListItem Value="50"> 50 </asp:ListItem>
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
                        <div id="Paymentdetails" class="col-md-12 customRow ">
                            <asp:GridView ID="GvPaymentdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvPaymentdetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvPaymentdetails_Sorting" OnRowCommand="GvPaymentdetails_RowCommand" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="PaymentTypeID" SortExpression="PaymentTypeID" HeaderText="ID" />
                                    <asp:BoundField DataField="PaymentType" SortExpression="PaymentType" HeaderText="Payment Type" />
                                    <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="AddedBy" />
                                    <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" HeaderText="Added Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("PaymentTypeID")%>'></asp:Label>
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
                                            <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
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
                $('#Paymentdetails table tbody tr').each(function () {
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
            if (document.getElementById("<%=txtdescription.ClientID%>").value == "") {
                str = str + "\n Please enter Description.";
                document.getElementById("<%=txtdescription.ClientID %>").focus();
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
                        __doPostBack('<%=GvPaymentdetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvPaymentdetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvPaymentdetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Paymentdetails table tbody tr').each(function () {
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


