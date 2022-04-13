<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="MonthlyTransportFeeMaster.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.EduTransport.MonthlyTransportFeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Transport&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduTransport/MonthlyTransportFeeMaster.aspx">Monthly Transport Fee Master</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblsession" runat="server" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbltransportstdttype" Text="Student Type"></asp:Label>
                                <asp:DropDownList ID="ddltransportstdtype" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddltransportstdtype_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblrouteno" runat="server" Text="Route"></asp:Label>
                                <asp:DropDownList ID="ddlrouteno" AutoPostBack="true" OnSelectedIndexChanged="ddlrouteno_SelectedIndexChanged" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsubroute" runat="server" Text="SubRoute"></asp:Label>
                                <asp:DropDownList ID="ddlsubroute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlsubroute_SelectedIndexChanged" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>


                    </div>
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblclass" Text="Class"></asp:Label>
                                <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>

                </div>
                <div class="card_wrapper">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdStudentID"  runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdActivation"  runat="server"></asp:HiddenField>

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
                            <asp:GridView ID="GvMonthlyTransportFee" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvMonthlyTransportFee_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvMonthlyTransportFee_Sorting" OnRowCommand="GvMonthlyTransportFee_RowCommand" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" OnRowDataBound="GvMonthlyTransportFee_RowDataBound" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            STudent ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudentID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>
                                            <asp:Label ID="lblActivate" runat="server" Visible="false" Text='<%# Eval("Activate")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Student Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudentName" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Route No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblrouteno" runat="server" Text='<%# Eval("RouteName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sub Route
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubroute" runat="server" Text='<%# Eval("SubRouteName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Address
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbladdress" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Driver's Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldriverName" runat="server" Text='<%# Eval("DriverName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Student Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbltransportstudenttype" runat="server" Text='<%# Eval("TransportStudentType")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Fee Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblfeeamount" runat="server" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Exemption
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtexemption" AutoPostBack="true" OnTextChanged="txtexemption_TextChanged" CssClass="form-control" Height="20px" Width="50px" MaxLength="4" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Onfocus="this.select();" Text='<%# Eval("Exemption", "{0:0#.##}")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtexemption" ID="FilteredTextBoxExtendera4"
                                                runat="server" ValidChars="1234567890." Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Net Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblnetamount" runat="server" Text='<%# Eval("NetAmount", "{0:0#.##}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Activate
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkactivate" AutoPostBack="true" Enabled="true" OnCheckedChanged="chkactivate_CheckedChanged" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>

                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                        <div>
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                  <%--<asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />--%>
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button"  Text="Update" OnClick="btnupdate_Click" />
                            </div>
                        </div>
                       </div>
                    </div>
                </div>

                <%----POP-UP ACTIVATE DATE----%>
                <div class="row">
                    <asp:ModalPopupExtender ID="modalpopup_activatedate" BehaviorID="modalbehavior_activatedate" TargetControlID="btnAdd_activatedate" runat="server" PopupControlID="popcontrolid_activatedate"
                        BackgroundCssClass="modalBackground" Enabled="True">
                    </asp:ModalPopupExtender>
                    <asp:Panel runat="server" ID="popcontrolid_activatedate" CssClass="ModalPopUpPanel" Style="display: none;width:240px;">

                        <div class="card_wrapper">
                            <div class="row pad15">
                        <div class="col-sm-1 pull-right" style="padding: 0px 9px; font-size: large;">
                            <asp:LinkButton ID="btnClose_activatedate" runat="server"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                        </div>
                  
                                <div class="form-group">
                                    <asp:Label ID="lblactivatedate" runat="server" style="text-align:center; margin-right:auto" Text="Entry Date"></asp:Label>
                                    <asp:TextBox ID="txtactivatedate" style="text-align:center" runat="server" class="form-control"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                        TargetControlID="txtactivatedate" />
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtactivatedate" />
                              
                              </div>
                                <div class="col-md-7 customRow">
                                        <div class="form-group pull-right" style="text-align:center">
                                            <asp:Button ID="btnsave" Width="50px" runat="server" class="btn btn-sm btn-success button"  OnClick="btnsave_Click" />                                            
                                        </div>
                                    </div>
                           </div>
                        </div>

                    </asp:Panel>


                </div>
                <asp:Button ID="btnAdd_activatedate" runat="server" />
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
            if (document.getElementById("<%=ddlacademicsession.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select academic session.";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlrouteno.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Route No.";
                document.getElementById("<%=ddlrouteno.ClientID %>").focus();
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
                        __doPostBack('<%=GvMonthlyTransportFee.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvMonthlyTransportFee]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvMonthlyTransportFee]').footable();

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
