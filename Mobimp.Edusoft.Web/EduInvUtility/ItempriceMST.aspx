<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ItempriceMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInvUtility.ItempriceMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Inv.Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a2" href="../EduInvUtility/UnitMST.aspx">Unit&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" id="a3" href="../EduInvUtility/ItemMST.aspx">Item&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" runat="server" id="a1" href="../EduInvUtility/ItemPriceMST.aspx">Item Price</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_Year" Text="Batch Year"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_Year" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_group" Text="Group"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_group" AutoPostBack="true"
                                    runat="server" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_subgroup" Text="Sub Group"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_subgroup" AutoPostBack="true" OnSelectedIndexChanged="ddl_subgroup_SelectedIndexChanged"
                                    runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_item" Text="Item"></asp:Label>
                                <asp:TextBox ID="txt_item" OnTextChanged="txt_item_TextChanged" AutoPostBack="true" runat="server" class="form-control custextbox"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetItemNameAuto" CompletionSetCount="1" TargetControlID="txt_item"
                                    UseContextKey="True" DelimiterCharacters="" Enabled="True" CompletionInterval="100">
                                </asp:AutoCompleteExtender>
                                <asp:HiddenField runat="server" ID="hdnitemid"/>
                                <asp:HiddenField runat="server" ID="hdnacademic"/>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_status" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddl_status" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true"
                                    runat="server" class="form-control custextbox">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-9"></div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btn_search" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" OnClick="btnsearch_Click" Text="Search" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btncancel_Click" Text="Cancel" />
                                <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" OnClientClick="return PrintItemPriceList()" runat="server" Text="Print" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper" runat="server" id="divivitem">
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

                        <div class="col-md-6 customRow">
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
                        <div id="itemlist" class="col-md-12 customRow ">
                            <asp:GridView ID="Gv_Item" EmptyDataText="No record found..."
                                CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" OnSorting="Gv_Item_Sorting" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="ItemPriceID" SortExpression="ItemPriceID" HeaderText="ID" />
                                    <asp:BoundField DataField="YearName" SortExpression="YearName" HeaderText="Year" />
                                    <asp:BoundField DataField="Groupname" SortExpression="Groupname" HeaderText="Group" />
                                    <asp:BoundField DataField="Subgroupname" SortExpression="Subgroupname" HeaderText="SubGroup" />
                                    <asp:BoundField DataField="Itemname" SortExpression="Itemname" HeaderText="Item Name" />
                                    <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="Unit" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Price
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" class="form-control" runat="server" Text='<%# Eval("ItemPriceID")%>'></asp:Label>
                                            <asp:Label ID="lbl_itemid" Visible="false" class="form-control" runat="server" Text='<%# Eval("Itemid")%>'></asp:Label>
                                            <asp:TextBox ID="txt_price" Width="100px" Height="20px" class="form-control" runat="server" Text='<%# Eval("Price","{0:0#.##}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txt_price" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="1234567890." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="row mt10">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-info button" OnClick="btnupdate_Click" Text="Update" />
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
                $('#itemlist table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddl_Year.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select year.";
                document.getElementById("<%=ddl_Year.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_group.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select group.";
                document.getElementById("<%=ddl_group.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_subgroup.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select subgroup.";
                document.getElementById("<%=ddl_subgroup.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_Item.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_Item]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_Item]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#itemlist table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function PrintItemPriceList() {
            objgroupid = document.getElementById("<%= ddl_group.ClientID%>")
            objsubgroupid = document.getElementById("<%= ddl_subgroup.ClientID %>")
            objyear = document.getElementById("<%= ddl_Year.ClientID %>")
            objacademic = document.getElementById("<%= hdnacademic.ClientID %>")
            objitemid = document.getElementById("<%= hdnitemid.ClientID %>")
            objstatus = document.getElementById("<%= ddl_status.ClientID %>")
            window.open("../EduInvUtility/Reports/ReportViewer.aspx?option=ItemPriceList&groupid=" + objgroupid.value + "&subgroupid=" + objsubgroupid.value + "&yearid=" + objyear.value + "&status=" + objstatus.value + "&AcademicSessionID=" + objacademic.value + "&itemid=" + objitemid.value)
        }

    </script>
</asp:Content>

