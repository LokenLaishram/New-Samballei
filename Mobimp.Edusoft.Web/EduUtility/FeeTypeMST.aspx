<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="FeeTypeMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduUtility.FeeTypeMST" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fee Utility &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="AddStudent.aspx">Fee Types</a></li>
        </ol>
        <asp:UpdatePanel ID="upMain" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblsession" runat="server" Text="Academic Year"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="col-md-3 customRow">
                           <div class="form-group">
                                <asp:Label runat="server" ID="lblfeeid" Visible="false" Text="FeeID"></asp:Label>                             
                               <asp:TextBox runat="server" class="form-control"  Visible="false" MaxLength="10" ID="txtFeeID"></asp:TextBox>
                            </div>
               </div>--%>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblcode" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" class="form-control" MaxLength="10" ID="txtFeeCode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblname" Text="Fee Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox runat="server" class="form-control" MaxLength="10" ID="txtFeeName"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbltype" runat="server" Text="Fee Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlPaymentType" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.6em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnsearch_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="btncancel" runat="server" class="btn btn-sm btn-danger button" Text="Cancel" OnClick="btncancel_Click" />
                                <%--<asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printstudentlist();" />--%>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="card_wrapper" id="divsearch" runat="server" >--%>
                <div class="card_wrapper" id="divsearch" runat="server">
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
                            <div id="FeeTypeList" class="col-md-12 customRow ">
                                <asp:GridView ID="GvFeeTypes" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                    AutoGenerateColumns="false" CssClass="footable table-striped" runat="server" OnRowCommand="GvFeeTypes_RowCommand"
                                    OnPageIndexChanging="GvFeeTypes_PageIndexChanging"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:BoundField DataField="FeeTypeID" SortExpression="FeeTypeID" HeaderText="ID" />
                                        <asp:BoundField DataField="FeeCode" SortExpression="FeeCode" HeaderText="FeeCode" />
                                        <asp:BoundField DataField="FeeName" SortExpression="FeeName" HeaderText="FeeName" />
                                        <asp:BoundField DataField="FeeType" SortExpression="FeeType" HeaderText="FeeType" />
                                        <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Edit
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID")%>'></asp:Label>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#FeeTypeList table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddlacademicsession.ClientID%>").selectedIndex == "") {
                str = str + "\n Please enter Academic Year.";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
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
                        __doPostBack('<%=GvFeeTypes.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvFeeTypes]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvFeeTypes]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#FeeTypeList table tbody tr').each(function () {
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
