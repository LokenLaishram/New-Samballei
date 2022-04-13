<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DailyProxyManager.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll.DailyProxyManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Payroll&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/Payroll/DailyProxyManager.aspx">Daily Proxy Manager</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabDailyProxyManager"><i class="icon nalika-edit" aria-hidden="true"></i>Proxy Manager</a></li>
                <li><a href="#tabDailyProxyManagerList"><i class="icon nalika-picture" aria-hidden="true"></i>Proxy Manager List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabDailyProxyManager">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlSession" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtEmployee" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txtEmployee_TextChanged"></asp:TextBox>
                                            <asp:Label ID="lblEmployeeID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblEmployeeName" runat="server" Visible="false"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetautoEmployeelist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtEmployee"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblProxyCharge" runat="server" Text="Proxy Charge"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtProxyCharge" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtDate" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblProxyFor" runat="server" Text="Proxy For"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtProxyFor" runat="server" AutoPostBack="true" OnTextChanged="txtProxyFor_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lblProxyForID" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblProxyForName" runat="server" Visible="false"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetautoEmployeelist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txtProxyFor"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblClass" Text="Class"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlClass" runat="server" class="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblReason" Text="Reason"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtReason" runat="server" class="form-control ">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblStatus" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlStatus" AutoPostBack="true"
                                                runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnAdd"  class="btn btn-sm btn-success button" OnClientClick="return Validate();" OnClick="btnAdd_Click" runat="server" Text="Save" />
                                            <asp:Button ID="btnReset" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-danger button" OnClick="btnReset_Click" runat="server" Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <%-- ----------------------------End Tab 1------------------------------%>
                <%-- ----------------------------Start Tab 2------------------------------%>
                <div class="product-tab-list tab-pane fade" id="tabDailyProxyManagerList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_Message" runat="server"></asp:Label>
                                            <asp:Label ID="lbltab2_Session" runat="server" Text="Session"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddltab2_Session" AutoPostBack="true" OnSelectedIndexChanged="ddltab2_Session_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_EmpName" runat="server" Text="Employee Name"></asp:Label>
                                            <asp:TextBox ID="txttab2_EmpName" runat="server" AutoPostBack="true" OnTextChanged="txttab2_EmpName_TextChanged"
                                                class="form-control"></asp:TextBox>
                                            <asp:Label ID="lbltab2_EmpID" runat="server" Visible="false"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                                ServiceMethod="GetautoEmployeelist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txttab2_EmpName"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_Class" runat="server" Text="Class"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_Class" AutoPostBack="true" OnSelectedIndexChanged="ddltab2_Class_SelectedIndexChanged" class="form-control " runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">

                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" AutoPostBack="true" OnTextChanged="txtfrom_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" runat="server" AutoPostBack="true" OnTextChanged="txtto_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_Status" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_IsActive" AutoPostBack="true" OnTextChanged="ddltab2_IsActive_TextChanged" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btntab2_Search" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" OnClick="btntab2_Search_Click" class="btn btn-sm btn-info button " Text="Search" />
                                            <asp:Button ID="btntab2_Cancel" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-danger button" OnClick="btntab2_Cancel_Click" runat="server" Text="Reset" />
                                            <asp:Button ID="btntab2_Print" Visible="false" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
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
                                                <asp:LinkButton ID="btn_export" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                                    <div id="ProxyManagerList" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gvtab2_ProxyManagerList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%" OnRowCommand="Gvtab2_ProxyManagerList_RowCommand" OnPageIndexChanging="Gvtab2_ProxyManagerList_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Sl.No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Employee
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gv_lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                                        <asp:Label ID="Gv_lblEmployeeID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                        <asp:Label ID="Gv_lblEmployee" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Date
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gv_lblDate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Proxy For
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gv_lblProxyForName" runat="server" Text='<%# Eval("ProxyForName")%>'></asp:Label>
                                                        <asp:Label ID="Gv_lblProxyForID" Visible="false" runat="server" Text='<%# Eval("ProxyForID")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Proxy Charge
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="GV_lblProxyCharge" runat="server" Text='<%# Eval("ProxyCharge","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Reason
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gv_lblReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Gv_txtRemark" runat="server" class="form-control" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Edit
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                    CommandName="Edits" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkEdit" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>

                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="0.5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="0.5%" />
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

                <%-- ----------------------------End Tab 2------------------------------%>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlSession.ClientID%>").value == "0") {
                str = str + "\n Please Select Session.";
                document.getElementById("<%=ddlSession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtEmployee.ClientID%>").value == "") {
                str = str + "\n Please Enter Employee Name.";
                document.getElementById("<%=txtEmployee.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtDate.ClientID%>").value == "") {
                str = str + "\n Please Select Date.";
                document.getElementById("<%=txtDate.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtProxyFor.ClientID%>").value == "") {
                str = str + "\n Please Enter Proxy For.";
                document.getElementById("<%=txtProxyFor.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlClass.ClientID%>").value == "") {
                str = str + "\n Please Select Class.";
                document.getElementById("<%=ddlClass.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtReason.ClientID%>").value == "") {
                str = str + "\n Please Enter Reason.";
                document.getElementById("<%=txtReason.ClientID %>").focus();
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

        $(function () {
            $('[id*=Gvtab2_ProxyManagerList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gvtab2_ProxyManagerList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#ProxyManagerList table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

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
                        __doPostBack('<%=Gvtab2_ProxyManagerList.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }
    </script>
</asp:Content>
