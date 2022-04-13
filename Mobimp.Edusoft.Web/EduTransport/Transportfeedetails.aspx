<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="Transportfeedetails.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduTransport.Transportfeedetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Transport&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduTransport/Transportfeedetails.aspx">Fee Detail</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblsession" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrouteno" Text="Route No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlrouteno" runat="server" class="form-control" OnSelectedIndexChanged="ddlrouteno_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbltransporttype" Text="Vehicle Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddltranporttype" AutoPostBack="true" OnSelectedIndexChanged="ddltranporttype_SelectedIndexChanged" runat="server" class="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbl_vehiclenumber" Text="Vehicle No."></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_vehiclenumber" runat="server" class="form-control" OnSelectedIndexChanged="ddl_vehiclenumber_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbldestination" Text="Destination"></asp:Label>
                                <%--<asp:Label runat="server" ID="lblVehicleID" Visible="false"></asp:Label>--%>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdestination" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    TargetControlID="txtdestination" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbltransportfeeamount" Text="Fare Amount"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txttranfeeamount" MaxLength="6" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                    TargetControlID="txttranfeeamount" FilterType="Numbers,Custom" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                <asp:Button ID="btn_Exemption" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper" runat="server" id="divsearch">
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
                            <asp:UpdateProgress ID="updateProgress2" runat="server">
                                <ProgressTemplate>
                                    <div id="DIVloading" runat="server" class="Pageloader">
                                        <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                            AlternateText="Loading ..." ToolTip="Loading ..." />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <div id="TransportFeeList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvTransport" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvTransport_Sorting" OnRowCommand="GvTransport_RowCommand" runat="server" OnRowDataBound="GvTransport_RowDataBound" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" />
                                    <asp:BoundField DataField="RouteNo" SortExpression="RouteNo" HeaderText="Route Name" />
                                    <asp:BoundField DataField="TransportName" SortExpression="TransportName" HeaderText="Vehicle Type" />
                                    <asp:BoundField DataField="VehicleDetails" SortExpression="VehicleDetails" HeaderText="Vehicle Details" />
                                    <asp:BoundField DataField="Destination" SortExpression="Destination" HeaderText="Destination" />
                                    <asp:TemplateField HeaderText="Fare">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" Enabled="false" class="form-control" Text='<%# Eval("Fare", "{0:0#.##}")%>'
                                                Width="50px" ID="txtrate"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Academic Session
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcademicSessionName" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit Details
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="lbl_routeNo" Visible="false" runat="server" Text='<%# Eval("RouteNo")%>'></asp:Label>
                                            <asp:Label ID="lbl_routeID" Visible="false" runat="server" Text='<%# Eval("RouteID")%>'></asp:Label>
                                            <asp:Label ID="lbl_vehiclenumber" Visible="false" runat="server" Text='<%# Eval("VehicleNo")%>'></asp:Label>
                                            <asp:Label ID="lbl_vehicledetails" Visible="false" runat="server" Text='<%# Eval("VehicleDetails")%>'></asp:Label>
                                            <asp:Button ID="btn_edit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Edits" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Exemption Rule
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" Visible="false" Text='<%# Eval("ExemptionStatus")%>' runat="server"></asp:Label>
                                            <asp:Button ID="btn_rule" Text="Make" CssClass="small_btn cus_btn" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Rule" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Activation
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblactivate" Visible="false" Text='<%# Eval("IsActivate")%>' runat="server"></asp:Label>
                                            <asp:CheckBox ID="chkactivate" runat="server" AutoPostBack="true" OnCheckedChanged="chkactivate_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Action
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Deletes" ValidationGroup="none" />
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
                <div class="row">
                    <asp:ModalPopupExtender ID="ModalPopupExtender5" runat="server" PopupControlID="pnlexemption"
                        TargetControlID="btn_Exemption" BackgroundCssClass="modalBackground" BehaviorID="modalbehavior5">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlexemption" runat="server" CssClass="ModalPopUpPanel" Style="display: none; width: 650px">
                        <div style="text-align: right;">
                            <asp:LinkButton ID="lnbclosedpop5" runat="server" Style="padding: 0px 15px;"><i class="fa fa-close" style="color: #ff011c;" > </i></asp:LinkButton>
                        </div>
                        <div class="row">
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbl_session" runat="server" class="form-control" Text="Session"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbl_route" runat="server" class="form-control" Text="Route"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lbl_vehicle"  runat="server" class="form-control" Text="Vehicle"></asp:Label>
                                    <asp:Label ID="hdnlbl_feeID" Visible="false"  runat="server" class="form-control"></asp:Label>
                                    <asp:Label ID="hdn_lbl_routeid" Visible="false"  runat="server" class="form-control"></asp:Label>
                                    <asp:Label ID="hdnlbl_vehiclenumbers" Visible="false"  runat="server" class="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-2 customRow">
                                <div class="form-group">
                                    <div class="form-group pull-right" style="margin-top: 1.6em;">
                                        <asp:Button ID="btnExemptionRule" runat="server" Visible="false" Text="Preview" class="btn btn-sm btn-yellow button"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card_wrapper">
                            <div style="width: 100%; overflow: hidden; overflow-y: hidden; min-height: 199px; max-height: 250px; overflow-y: auto;">
                                <asp:GridView ID="Gv_Exemption" EmptyDataText="No record found..." AutoGenerateColumns="false" CssClass="table-striped table-hover" runat="server"
                                    Style="width: 100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Sl
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# (Container.DataItemIndex+1)+(Gv_Exemption.PageIndex)*Gv_Exemption.PageSize %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Student Type
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_exemtionID" Visible="false" runat="server" Text='<%# Eval("ExemptionID")%>'></asp:Label>
                                                <asp:Label ID="lbl_studenttypeID" Visible="false" runat="server" Text='<%# Eval("StudentTypeID")%>'></asp:Label>
                                                <asp:Label ID="lbl_studenttypename" runat="server" Font-Size="Small" Text='<%# Eval("StudentType")%>'></asp:Label>
                                                <asp:Label ID="lbl_feeID" Visible="false" runat="server" Text='<%# Eval("FeeID")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Fare
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fare" runat="server" Text='<%# Eval("Fare","{0:0#.##}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Exempted Amount
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_exemptedamount" autocomplete="off"  onfocus="this.select();" runat="server" Height="20px" Width="80px" class="form-control" Text='<%# Eval("ExemptedAmount","{0:0#.##}")%>'></asp:TextBox>
                                                <asp:FilteredTextBoxExtender TargetControlID="txt_exemptedamount" ID="FilteredTextBoxExtendertxtoldfeeamount27"
                                                    runat="server" ValidChars="1234567890." Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Net Amount
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_netfare" Enabled="false" runat="server" Width="80px" Text='<%# Eval("NetFare","{0:0#.##}")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 customRow">
                                <%--style="margin-top: 1.6em;"--%>
                                <div class="form-group">
                                    <asp:Button ID="btn_save" runat="server" Text="Save" class="btn btn-sm btn-success button" OnClick="btnsavepop5_Click" Style="float: right;" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
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
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#TransportFeeList table tbody tr').each(function () {
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
                str = str + "\n Please select Academic Session";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlrouteno.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select route No.";
                document.getElementById("<%=ddlrouteno.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddltranporttype.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select transport Type";
                document.getElementById("<%=ddltranporttype.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddl_vehiclenumber.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select vehicle no.";
                document.getElementById("<%=ddl_vehiclenumber.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=txtdestination.ClientID %>").value == "") {
                str = str + "\n Please enter destination";
                document.getElementById("<%=txtdestination.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txttranfeeamount.ClientID %>").value == "") {
                str = str + "\n Please enter fare rate";
                document.getElementById("<%=txttranfeeamount.ClientID %>").focus();
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
                        __doPostBack('<%=GvTransport.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvTransport]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvTransport]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#TransportFeeList table tbody tr').each(function () {
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
