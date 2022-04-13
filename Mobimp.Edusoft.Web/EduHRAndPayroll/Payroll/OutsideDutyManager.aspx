<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="OutsideDutyManager.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll.OutsideDutyManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Payroll&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/Payroll/OutsideDutyManager.aspx">Outside Duty Manager</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabdutydetails"><i class="icon nalika-edit" aria-hidden="true"></i>Add Details</a></li>
                <li><a href="#tabDutyList"><i class="icon nalika-picture" aria-hidden="true"></i>Duty List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabdutydetails">
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
                                            <asp:TextBox ID="txtEmployee" runat="server" class="form-control"></asp:TextBox>
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
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Convenience charge"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txt_covinentcharge" onfocus="this.select();" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filtercharge" runat="server"
                                                Enabled="True" TargetControlID="txt_covinentcharge" ValidChars="0123456789.">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtReason" runat="server" MaxLength="200" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnAdd" class="btn btn-sm btn-success button" OnClientClick="return Validate();" OnClick="btnAdd_Click" runat="server" Text="Add" />
                                            <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" OnClick="btnReset_Click" runat="server" Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="product-tab-list tab-pane fade" id="tabDutyList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_message1" runat="server"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="Session"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_sessions" AutoPostBack="true" OnSelectedIndexChanged="ddl_sessions_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Employee"></asp:Label>
                                            <asp:TextBox ID="txt_employeenames" runat="server" class="form-control"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetautoEmployeelist" MinimumPrefixLength="1"
                                                CompletionInterval="100" CompletionSetCount="1" TargetControlID="txt_employeenames"
                                                UseContextKey="True" DelimiterCharacters="" Enabled="True" ServicePath="~/webservices/AutocompleteLinks.asmx">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_month" runat="server" Text="Month"></asp:Label>
                                            <asp:DropDownList ID="ddl_month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_months_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbl_from" runat="server" Text="From"></asp:Label>
                                            <asp:TextBox ID="txt_datefrom" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_datefrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_datefrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="To"></asp:Label>
                                            <asp:TextBox ID="txt_to" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txt_to" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_to" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_status" Text="Status"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddl_status" AutoPostBack="true"
                                                runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btn_search" class="btn btn-sm btn-info button" OnClick="btnSearch_Click" runat="server" Text="Search" />
                                            <asp:Button ID="btn_reset" class="btn btn-sm btn-danger button" OnClick="btn_reset_Click" runat="server" Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card_wrapper" id="divsearch" runat="server">
                                <div class="row pad15">
                                    <div class="col-md-7 customRow" style="margin-top: 13px;">
                                        <asp:Label ID="lblresult" Text="Show" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
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
                                    <div id="OutsideDutyList" class="col-md-12 customRow ">
                                        <asp:GridView ID="GvOutsideDutyList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                            Style="width: 100%" OnRowCommand="GvOutsideDutyList_RowCommand" OnPageIndexChanging="GvOutsideDutyList_PageIndexChanging">
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
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Reason
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Gv_txtReason" runat="server" class="form-control" Text='<%# Eval("Reason")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Convenience Fee
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Gv_txtConvenience" runat="server" class="form-control" Text='<%# Eval("ConvenienceFee","{0:0#.00}")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                                        <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Edits" />
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
            if (document.getElementById("<%=txt_covinentcharge.ClientID%>").value == "") {
                str = str + "\n Please Enter Convinience Charge.";
                document.getElementById("<%=txt_covinentcharge.ClientID %>").focus();
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
            $('[id*=GvOutsideDutyList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvOutsideDutyList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#OutsideDutyList table tbody tr').each(function () {
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
                        __doPostBack('<%=GvOutsideDutyList.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

    </script>
</asp:Content>
