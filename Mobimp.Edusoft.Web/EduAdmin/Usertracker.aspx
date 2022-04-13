<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Usertracker.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduAdmin.Usertracker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Admin&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduAdmin/Usertracker.aspx">User Tracker</a></li>
        </ol>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblemployeeID" Text="Employee ID"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtempID" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtempID" ID="FilteredTextBoxExtender3"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblempname" Text="Employee Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtempname" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtempname" ID="FilteredTextBoxExtender1"
                                    runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                    Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group ">
                                <asp:Label ID="lbldatefrom" runat="server" Text="Date from"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdatefrom" type="text" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtdatefrom" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdatefrom" />

                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group ">
                                <asp:Label ID="lbldateto" runat="server" Text="Date to"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdateto" type="text" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txtdateto" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateto" />

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
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
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_export" Visible="false" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_export" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-3 customRow">
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
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading" runat="server" class="Pageloader">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="ClassList" class="col-md-12 customRow ">
                                <asp:GridView ID="Gvlogintracklist" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                    CssClass="footable table-striped" AllowSorting="true" OnSorting="Gvlogintracklist_Sorting" runat="server" AutoGenerateColumns="false"
                                    Style="width: 100%">
                                    <Columns>
                                        <asp:BoundField DataField="LoginID" SortExpression="LoginID" HeaderText="LoginID" />
                                        <asp:BoundField DataField="EmployeeNo" SortExpression="EmployeeNo" HeaderText="Emp No." />
                                        <asp:BoundField DataField="EmpName" SortExpression="EmpName" HeaderText="Emp. Name" />
                                        <asp:BoundField DataField="Logintime" SortExpression="Logintime" HeaderText="Login Time" />
                                        <asp:BoundField DataField="EmpName" SortExpression="LogOuttime" HeaderText="Logout Time" />
                                        <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />                                        
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Date
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" class="form-control" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Edit
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ClassID")%>'></asp:Label>
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
           if (document.getElementById("<%=txtdatefrom.ClientID%>").value == "") {
            str = str + "\n Please select Datefrom."
            document.getElementById("<%=txtdatefrom.ClientID %>").focus()
            i++
        }
        if (document.getElementById("<%=txtdateto.ClientID%>").value == "") {
            str = str + "\n Please select Dateto."
            document.getElementById("<%=txtdateto.ClientID %>").focus()
            i++
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
                        __doPostBack('<%=Gvlogintracklist.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=Gvlogintracklist]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gvlogintracklist]').footable();

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
