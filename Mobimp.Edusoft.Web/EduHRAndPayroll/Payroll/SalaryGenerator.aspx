<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="SalaryGenerator.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.Payroll.SalaryGenerator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Payroll&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduHRAndPayroll/Payroll/SalaryGenerator.aspx">Salary Generator</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                                <asp:DropDownList ID="ddlSession" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblEmployee" runat="server" Text="Employee"></asp:Label>
                                <asp:TextBox ID="txtEmployee" runat="server" class="form-control"></asp:TextBox>
                                <asp:Label ID="lblEmployeeID" runat="server" Visible="false"></asp:Label>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                    ServiceMethod="GetEmployeeName" MinimumPrefixLength="1" CompletionInterval="100"
                                    CompletionSetCount="1" TargetControlID="txtEmployee" UseContextKey="True"
                                    DelimiterCharacters="" Enabled="True" CompletionListCssClass="accordion" ServicePath="">
                                </asp:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnSearch" class="btn btn-sm btn-info button" OnClick="btnSearch_Click" runat="server" Text="Generate" />
                                <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" />
                                <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" />
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
                                <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" class="form-control">
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

                        <div id="SalaryGenerator" class="col-md-12 customRow table-responsive">
                            <asp:GridView ID="GvSalaryGenerator" AllowPaging="false" AllowCustomPaging="false" EmptyDataText="No record found..."
                                CssClass="footable table-striped table-responsive" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%; overflow: auto;" ShowFooter="true">
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
                                            Employee Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="Gv_EmployeeID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblYearID" runat="server" Visible="false" Text='<%# Eval("YearID")%>'></asp:Label>
                                            <asp:Label ID="Gv_lblMonthID" runat="server" Visible="false" Text='<%# Eval("MonthID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="5%"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total P
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalPresent" runat="server" Text='<%# Eval("TotalNoPresent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total A
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalAbsent" runat="server" Text='<%# Eval("TotalNoAbsent")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total L
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalLeave" runat="server" Text='<%# Eval("TotalNoLeave")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total Proxy
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalProxy" runat="server" Text='<%# Eval("TotalNoProxy")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total OD
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTotalOutsideDuty" runat="server" Text='<%# Eval("TotalNoOutsideDuty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Basic Salary
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblBasicSalary" runat="server" Text='<%# Eval("BasicSalary")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Basic Salary PD
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblBasicSalaryPerDay" runat="server" Text='<%# Eval("BasicSalaryPerDay")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Proxy Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblProxyAmount" runat="server" Text='<%# Eval("ProxyAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Outside Duty Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblOutsideDutyAmount" runat="server" Text='<%# Eval("OutsideDutyAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            TA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblTravellingAllowance" runat="server" Text='<%# Eval("TravellingAllowance")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            DA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblDutyAllowance" runat="server" Text='<%# Eval("DutyAllowance")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            EPF
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblEPF" runat="server" Text='<%# Eval("EPF")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Loan Balance
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblLoanBalance" runat="server" Text='<%# Eval("LoanBalance")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Loan Adjust
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblLoanAdjust" runat="server" Text='<%# Eval("LoanAdjust")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Misc. Deduction
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblMiscellaneousDeduction" runat="server" Text='<%# Eval("MiscellaneousDeduction")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <HeaderTemplate>
                                            Salary Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Gv_lblSalaryAmount" runat="server" Text='<%# Eval("SalaryAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnUpdate" class="btn btn-sm btn-success button" runat="server" Text="Update" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
