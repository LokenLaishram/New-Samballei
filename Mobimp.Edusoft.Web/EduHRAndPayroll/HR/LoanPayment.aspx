<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="LoanPayment.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduHRAndPayroll.HR.LoanPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>HR&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../HR/LoanPayment.aspx">Loan Payment</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <ul id="myTab3" class="tab-review-design">
                <li class="active"><a href="#tabLoanPayment"><i class="icon nalika-edit" aria-hidden="true"></i>Loan Payment</a></li>
                <li><a href="#tabLoanRecordList"><i class="icon nalika-picture" aria-hidden="true"></i>Loan Record List</a></li>
            </ul>
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="tabLoanPayment">
                    <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row mt10">
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                            <asp:Label runat="server" ID="lbl_EmployeeName" Text="Employee Name"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtEmployeeName" runat="server" AutoPostBack="true" OnTextChanged="txtEmployeeName_TextChanged" class="form-control"></asp:TextBox>
                                            <asp:Label ID="lbl_EmployeeID" Visible="false" runat="server"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                ServiceMethod="GetEmployeeName" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txtEmployeeName" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" CompletionListCssClass="accordion" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_LoanType" Text="Loan Type"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:DropDownList ID="ddlLoanType" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_LoanAmt" Text="Loan Amount"></asp:Label>
                                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                            <asp:TextBox ID="txtLoanAmount" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBox1" runat="server" Enabled="True"
                                                TargetControlID="txtLoanAmount" FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt10">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_LoanPaymentNo" Text="Loan Payment Number"></asp:Label>
                                            <asp:TextBox ID="txt_LoanPaymentNo" disabled="disabled" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-9 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-sm btn-green button" OnClientClick="return Validate();" OnClick="btnSave_Click" Text="Pay" />
                                            <asp:Button ID="btnCancel" class="btn btn-sm btn-danger button" OnClick="btnCancel_Click" runat="server" Text="Cancel" />
                                            <asp:Button ID="btnPrint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintLoanReceipt();"/>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <%-- ----------------------------End Tab 1------------------------------%>
                <%-- ----------------------------Start Tab 2------------------------------%>
                <div class="product-tab-list tab-pane fade" id="tabLoanRecordList">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_EmpName" runat="server" Text="Employee Name"></asp:Label>
                                            <asp:TextBox ID="txttab2_EmpName" runat="server" AutoPostBack="true"
                                                class="form-control"></asp:TextBox>
                                            <asp:Label ID="lbltab2_EmpID" runat="server" Visible="false"></asp:Label>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                ServiceMethod="GetEmployeeNameTab2" MinimumPrefixLength="1" CompletionInterval="100"
                                                CompletionSetCount="1" TargetControlID="txttab2_EmpName" UseContextKey="True"
                                                DelimiterCharacters="" Enabled="True" CompletionListCssClass="accordion" ServicePath="">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_LoanType" runat="server" Text="Loan Type"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_LoanType" class="form-control " runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_LoanStatus" runat="server" Text="Loan Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_LoanStatus" runat="server" class="form-control ">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="2">Completed</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lbltab2_Status" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddltab2_IsActive" runat="server" class="form-control ">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">InActive </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblfrom" runat="server" Text="Date from"></asp:Label>
                                            <asp:TextBox ID="txtfrom" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtfrom" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfrom" />
                                        </div>
                                    </div>
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblto" runat="server" Text="Date to"></asp:Label>
                                            <asp:TextBox ID="txtto" runat="server" class="form-control"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtto" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtto" />
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btntab2_Search" OnClick="btntab2_Search_Click" runat="server" class="btn btn-sm btn-info button " Text="Search" />
                                            <asp:Button ID="btntab2_Cancel" class="btn btn-sm btn-danger button" OnClick="btntab2_Cancel_Click" runat="server" Text="Cancel" />
                                            <asp:Button ID="btntab2_Print" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintLoanPaymentList();"/>
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
                                        <asp:UpdateProgress ID="updateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <div id="DIVloading" runat="server" class="Pageloader">
                                                    <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                        AlternateText="Loading ..." ToolTip="Loading ..." />
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div id="LoanRecordList" class="col-md-12 customRow ">
                                        <asp:GridView ID="Gvtab2_LoanRecordList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                            CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnRowCommand="Gvtab2_LoanRecordList_RowCommand"
                                            OnRowDataBound="Gvtab2_LoanRecordList_RowDataBound" OnPageIndexChanging="Gvtab2_LoanRecordList_PageIndexChanging" Style="width: 100%" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="JavaScript:ItemChildGridview('div<%# Eval("LoanPaymentNo") %>');">
                                                            <img alt="Detail" id='imgdiv<%# Eval("LoanPaymentNo") %>' src="../../Images/plus.gif" width="20px" />
                                                        </a>
                                                        <div id='div<%# Eval("LoanPaymentNo") %>' style="display: none;">
                                                            <asp:GridView ID="GridChildRecordDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="LoanPaymentNo"
                                                                CssClass="ChildGrid" GridLines="None">
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="93px" DataField="LoanReturnNo" HeaderText="Return No." />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="LoanType" HeaderText="Loan Type" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="LoanAmount" DataFormatString="{0:n}" HtmlEncode="false"  HeaderText="Loan Amount" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="ReturnAmount"  DataFormatString="{0:00.00}" HtmlEncode="false"  HeaderText="Return Amount" />
                                                                    <asp:BoundField ItemStyle-Width="193px" DataField="BalanceAmount"  DataFormatString="{0:n}" HtmlEncode="false"  HeaderText="Balance Amount" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
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
                                                        Loan Payment No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                         <%--Style="color: #01c; text-decoration-line: underline; cursor: pointer;" --%>
                                                        <asp:LinkButton ID="Gvlbtn_LoanPaymentNo" style="text-decoration-line:underline;" runat="server" Text='<%# Eval("LoanPaymentNo")%>' CommandName="LoanRepayment" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" ValidationGroup="none">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Employee Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_EmployeeName" Height="20px" runat="server" Text='<%# Eval("EmployeeName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Loan Type
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanType" Height="20px" runat="server" Text='<%# Eval("LoanType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Loan Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_LoanAmount" Height="20px" runat="server" Text='<%# Eval("LoanAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Total Return Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_TotalLoanAmount" Height="20px" runat="server" Text='<%# Eval("TotalReturnAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Balance Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Gvlbl_BalanceAmount" Height="20px" runat="server" Text='<%# Eval("LastBalanceAmount","{0:0#.00}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Remark
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtremarks" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remark")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
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
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Print
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--<asp:Button ID="btn_Print" class="cus-btn btn-sm btn-indigo button" Text="Print" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                            CommandName="Print" ValidationGroup="none" />--%>
                                                        <a href="javascript: void(null);" onclick="PrintLoanPaymentDetailed('<%# Eval("LoanPaymentNo")%>','<%# Eval("LoanTypeID")%>'); return false;" class="cus-btn btn-sm btn-info button">Print</a>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Loan Status
                                                    </HeaderTemplate>
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="Gvlbl_LoanStatus" runat="server" Text='<%# Eval("LoanStatus")%>' style="padding:3px;"></asp:Label>
                                                        <asp:Label ID="Gvlbl_LoanStatusID" Height="20px" Visible="false" runat="server" Text='<%# Eval("LoanStatusID")%>'></asp:Label>
                                                        <asp:Label ID="GVlbl_IsProcess" Height="20px" Visible="false" runat="server" Text='<%# Eval("IsProcess")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="2%" />
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
            if (document.getElementById("<%=txtEmployeeName.ClientID%>").value == "") {
                str = str + "\n Please Enter Employee Name.";
                document.getElementById("<%=txtEmployeeName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlLoanType.ClientID%>").value == "") {
                str = str + "\n Please Select Loan Type.";
                document.getElementById("<%=ddlLoanType.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtLoanAmount.ClientID%>").value == "") {
                str = str + "\n Please Enter Amount.";
                document.getElementById("<%=txtLoanAmount.ClientID %>").focus();
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

        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../../Images/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../../Images/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../../Images/plus.gif");
            }
        }

        $(function () {
            $('[id*=Gvtab2_LoanRecordList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gvtab2_LoanRecordList]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#LoanRecordList table tbody tr').each(function () {
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
                        __doPostBack('<%=Gvtab2_LoanRecordList.UniqueID%>', 'Deletes$' + paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });
        }

        function PrintLoanReceipt() {
            objLoanPaymentNo = document.getElementById("<%= txt_LoanPaymentNo.ClientID %>")
            objLoanTypeID = document.getElementById("<%= ddlLoanType.ClientID %>")
            window.open("../HR/Reports/ReportViewer.aspx?option=LoanPayment&LoanPaymentNo=" + objLoanPaymentNo.value + "&LoanTypeID=" + objLoanTypeID.value )
        }
        function PrintLoanPaymentDetailed(LoanNo, LoanTypeID) {
            window.open("../HR/Reports/ReportViewer.aspx?option=LoanPaymentDetailed&LoanPaymentNo=" + LoanNo + "&LoanTypeID=" + LoanTypeID )
        }

        function PrintLoanPaymentList() {
            var EmpName = document.getElementById("<%= txttab2_EmpName.ClientID %>")

            objEmpID = EmpName.value.substring(EmpName.value.indexOf(":") + 1);

            objLoanTypeID = document.getElementById("<%= ddltab2_LoanType.ClientID %>")
            objLoanStatus = document.getElementById("<%= ddltab2_LoanStatus.ClientID %>")
            objIsActive = document.getElementById("<%= ddltab2_IsActive.ClientID %>")
            objDatefrom = document.getElementById("<%= txtfrom.ClientID %>")
            objDateto = document.getElementById("<%= txtto.ClientID %>")

            window.open("../HR/Reports/ReportViewer.aspx?option=LoanPaymentList&EmpID=" + objEmpID + "&LoanTypeID=" + objLoanTypeID.value + "&LoanStatus=" + objLoanStatus.value + "&IsActive=" + objIsActive.value + "&Datefrom=" + objDatefrom.value + "&Dateto=" + objDateto.value)
        }

    </script>
</asp:Content>
