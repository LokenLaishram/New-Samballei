<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ItemCondemnationRecord.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.ItemCondemnationRecord" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Item Condemnation Record&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduInventory/ItemCondemnationRecord.aspx">Item Condemnation Record</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label16" Text="Condem Type"></asp:Label>
                                <asp:DropDownList ID="ddlCondemnTypeID" runat="server" class="form-control custextbox">
                                    <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Nature"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Third Party"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Reject"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_ItemName" Text="Item Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_ItemName" AutoPostBack="true" OnTextChanged="txt_ItemName_TextChanged" MaxLength="100" runat="server" class="form-control ">
                                </asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" Enabled="True"
                                    ServiceMethod="GetItemNameStockNo" MinimumPrefixLength="1" TargetControlID="txt_ItemName"
                                    CompletionInterval="100" CompletionSetCount="1" CompletionListCssClass="Completion" UseContextKey="True"
                                    DelimiterCharacters="" CompletionListItemCssClass="" CompletionListHighlightedItemCssClass="">
                                </asp:AutoCompleteExtender>
                                <asp:Label ID="lbl_Vendor" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lbl_GetItemName" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lbl_ItemID" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lbl_StockNo" runat="server" Visible="false"></asp:Label>

                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_Unit" Text="Unit"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_Unit" disabled="disabled" runat="server" class="form-control ">
                                </asp:TextBox>
                                <asp:Label ID="lbl_GetUnitID" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_Price" Text="Price"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_Price" disabled="disabled" runat="server" class="form-control ">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Text="Recieved Qty"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_RecievedQty" disabled="disabled" runat="server" class="form-control ">
                                </asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_AvailableQty" Text="Available Qty"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_AvailableQty" disabled="disabled" runat="server" class="form-control ">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label2" Text="Condem Details"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtCondemnRemark" runat="server" class="form-control ">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_Quantity" Text="Condemn Qty"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txt_CondemnQty" MaxLength="5" runat="server" class="form-control ">                                                                  
                                </asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_CondemnQty"
                                    ValidChars="0987654321"></asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" class="btn btn-sm btn-success button" runat="server" Text="Add" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper">
                    <div class="row">
                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                            <ProgressTemplate>
                                <div id="DIVloading" runat="server" class="Pageloader">
                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div id="itemcondemnationrecordlist" class="col-md-12 customRow ">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Gv_ItemComnationRecord" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                        CssClass="table-bordered table-striped gridviewcss" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gv_ItemComnationRecord_RowCommand"
                                        Style="width: 100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" SL No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1%>
                                                    <asp:Label ID="lblGv_StockNo" Visible="false" class="form-control" runat="server" Text='<%# Eval("StockNo")%>'></asp:Label>
                                                    <asp:Label ID="lblGv_VendorID" Visible="false" class="form-control" runat="server" Text='<%# Eval("VendorID")%>'></asp:Label>
                                                    <asp:Label ID="lblGv_ItemID" Visible="false" class="form-control" runat="server" Text='<%# Eval("ItemID")%>'></asp:Label>
                                                    <asp:Label ID="lblGv_UnitID" Visible="false" class="form-control" runat="server" Text='<%# Eval("UnitID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="0.3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Item Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Condemn Type
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcondemnTypeID" Visible="false" runat="server" Text='<%# Eval("CondemnTypeID") %>'></asp:Label>
                                                    <asp:Label ID="lblcondemnType" runat="server" Text='<%# Eval("CondemnType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Price
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Condemn Details
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCondemnRemark" runat="server" Text='<%# Eval("CondemnRemark") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Available Qty
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecQty" runat="server" Text='<%# Eval("NetRecievedQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Available Qty
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAvailQty" runat="server" Text='<%# Eval("NetBalanceQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Condemn Qty
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCondemnQty" runat="server" Text='<%# Eval("CondemnQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                        CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-7 customRow"></div>
                         <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label3" Text="Condemn No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtCondemnNo" MaxLength="5" runat="server" class="form-control ">                                                                  
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSave" class="btn btn-sm btn-success button" OnClick="btnSave_Click" runat="server" Text="Save" />
                                <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btnReset_OnClick" />
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
                $('#itemcondemnationrecordlist table tbody tr').each(function () {
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
            if (document.getElementById("<%=txt_ItemName.ClientID%>").value == "") {
                str = str + "\n Please enter Item Name.";
                document.getElementById("<%=txt_ItemName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_AvailableQty.ClientID%>").value == "") {
                str = str + "\n Please enter Available.";
                document.getElementById("<%=txt_AvailableQty.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txt_CondemnQty.ClientID%>").value == "") {
                str = str + "\n Please enter Quantity.";
                document.getElementById("<%=txt_CondemnQty.ClientID %>").focus();
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
                        __doPostBack('<%=Gv_ItemComnationRecord.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gv_ItemComnationRecord]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_ItemComnationRecord]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#itemcondemnationrecordlist table tbody tr').each(function () {
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
