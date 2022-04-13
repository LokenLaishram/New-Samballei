<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AcademicSessionMST.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduUtility.AcademicSessionMST" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Common Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/AcademicSessionMST.aspx">Academic Session</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblcode" runat="server" Text="Code"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcode" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbldescription" runat="server" Text="Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdescription" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblfrom" runat="server" Text="From"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtfrom" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderfrom" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtfrom" />
                                <asp:MaskedEditExtender ID="MaskedEditExtenderfrom" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblto" runat="server" Text="To"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtto" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtenderto" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtto" />
                                <asp:MaskedEditExtender ID="MaskedEditExtenderto" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" Visible="false" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
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
                            <asp:GridView ID="GvAcademicDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvAcademicDetails_PageIndexChanging"
                                OnSorting="GvAcademicDetails_Sorting" OnRowCommand="GvAcademicDetails_RowCommand"
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="CODE" SortExpression="CODE" HeaderText="Code" />
                                    <asp:BoundField DataField="Descriptions" SortExpression="Descriptions" HeaderText="Session" />
                                    <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />
                                    <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" HeaderText="Added Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date From
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldatefrom" runat="server" Text='<%# Eval("DateFrom","{0:dd-MM-yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date To
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldateto" runat="server" Text='<%# Eval("DateTo","{0:dd-MM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Remarks
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" class="form-control" runat="server" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="lblstatuss" Visible="false" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
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
                                            <asp:Button ID="lnkdelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
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
            </contenttemplate>
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
            if (document.getElementById("<%=txtcode.ClientID%>").value == "") {
                str = str + "\n Please enter Code.";
                document.getElementById("<%=txtcode.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtdescription.ClientID%>").value == "") {
                str = str + "\n Please enter session.";
                document.getElementById("<%=txtdescription.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtfrom.ClientID%>").value == "") {
                str = str + "\n Please enter session starts from.";
                document.getElementById("<%=txtfrom.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtto.ClientID%>").value == "") {
                str = str + "\n Please enter session starts to.";
                document.getElementById("<%=txtto.ClientID %>").focus();
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
                text: "",

                buttons: true,
                dangerMode: true,
                dangerMode: true,
                dangerMode: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=GvAcademicDetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvAcademicDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvAcademicDetails]').footable();

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