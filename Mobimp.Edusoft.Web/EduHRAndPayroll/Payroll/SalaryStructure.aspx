<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="SalaryStructure.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll.SalaryStructure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Payroll&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/Payroll/SalaryStructure.aspx">Salary Structure</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSession" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_employee" runat="server" Text="Employee"></asp:Label>
                                <asp:DropDownList ID="ddl_employee" AutoPostBack="true" OnSelectedIndexChanged="ddl_employee_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-info button" OnClick="btnSearch_Click" runat="server" Text="Search" />
                                <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" OnClick="btnReset_Click" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" runat="server" Text="Reset" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card_wrapper" runat="server">
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
                            <asp:UpdateProgress ID="updateProgress1" runat="server">
                                <ProgressTemplate>
                                    <div id="DIVloading" runat="server" class="Pageloader">
                                        <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                            AlternateText="Loading ..." ToolTip="Loading ..." />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>

                        <div id="SalaryStructure" class="col-md-12 customRow ">
                            <asp:GridView ID="GvSalaryStructure" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" OnPageIndexChanging="GvSalaryStructure_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl.No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# (Container.DataItemIndex+1)+(GvSalaryStructure.PageIndex)*GvSalaryStructure.PageSize %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Year
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYearID" Visible="false" runat="server" Text='<%# Eval("YearID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Employee Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblEmployeeID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblEmployee" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Designation
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDesignation" runat="server" Text='<%# Eval("Designation")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Basic Salary
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtBasicSalary" onfocus="this.select();" Height="18px" runat="server" Class="form-control" Text='<%# Eval("BasicSalary","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter1" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtBasicSalary" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            TA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtTA" onfocus="this.select();" runat="server" Height="18px" Class="form-control" Text='<%# Eval("TA","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter2" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtTA" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Proxy
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtProxy" onfocus="this.select();" runat="server" Height="18px" class="form-control" Text='<%# Eval("Proxy","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter3" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtProxy" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Absent
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtAbsent" onfocus="this.select();" runat="server" Height="18px" class="form-control" Text='<%# Eval("Absent","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter4" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtAbsent" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            EPF
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtEPF" onfocus="this.select();" runat="server" Height="18px" class="form-control" Text='<%# Eval("EPF","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter5" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtEPF" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            DA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="Gv_txtDA" onfocus="this.select();" runat="server" Height="18px" class="form-control" Text='<%# Eval("DA","{0:0#.00}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txt_filter6" runat="server"
                                                Enabled="True" TargetControlID="Gv_txtDA" ValidChars="01234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>

                        </div>
                    </div>
                    <div class="row" runat="server" id="divupdate">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" class="btn btn-sm btn-success button" runat="server" Text="Update" />
                                <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" OnClientClick="return PrintSalaryStructure();" runat="server" Text="Print" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <script type="text/javascript">

        function clickEnter(obj, event) {
            var keyCode;
            if (event.keyCode > 0) {
                keyCode = event.keyCode;
            }
            else if (event.which > 0) {
                keyCode = event.which;
            }
            else {
                keycode = event.charCode;
            }
            if (keyCode == 13) {
                document.getElementById(obj).focus();
                return false;
            }
            else {
                return true;
            }
        }

        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddlSession.ClientID%>").value == "") {
                str = str + "\n Please Select Session.";
                document.getElementById("<%=ddlSession.ClientID %>").focus();
                i++;
            }

            if (str.length > 0) {
                swal({
                    title: "Please check the following required fileds.",
                    text: str,
                    icon: "warning",
                });
                return false
            }
            else {
                return true
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
            $('[id*=GvSalaryStructure]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvSalaryStructure]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#SalaryStructure table tbody tr').each(function () {
                    var lineStr = $(this).text().toLowerCase();
                    if (lineStr.indexOf(searchTerm) === -1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            });
        });

        function PrintSalaryStructure() {
            objSessionID = document.getElementById("<%= ddlSession.ClientID %>");
            window.open("../Payroll/Reports/ReportViewer.aspx?option=PrintSalaryStructure&SessionID=" + objSessionID.value)
        }

    </script>

</asp:Content>
