<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="VehicleManager.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.EduTransport.VehicleManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Transport&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduTransport/VehicleManager.aspx">Vehicle Manager</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblsession" runat="server" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrouteno" Text="Route"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlrouteno" runat="server" class="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbltransporttype" runat="server" Text="Transport Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddltranporttype" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblvehicleno" Text="Vehicle No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtvehicleno" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtvehicleno" ValidChars=" 0987654321ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-4 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Text="Driver Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtdriverName" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBox" runat="server" Enabled="True"
                                    TargetControlID="txtdriverName" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblcontactno" Text="Contact No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcontactno" MaxLength="10" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtcontactno" ValidChars="0987654321">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblCareOf" Text="C/O"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtCareOf" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                    TargetControlID="txtCareOf" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbladdress" Text="Address"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtAddress" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                    TargetControlID="txtAddress" FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbllicence" Text="License No."></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtlicence" MaxLength="18" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True"
                                    TargetControlID="txtlicence" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=" ">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbladmission" Text="Status"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlstatus" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true"
                                    runat="server" class="form-control ">
                                    <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" Visible="true" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                <asp:Button ID="btnPrintVehicle" class="btn btn-sm btn-indigo button" runat="server" Visible="false" Text="Print" OnClientClick="return VehicleManager();" />
                                <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" />
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
                            <asp:GridView ID="GvTransport" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvTransport_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvTransport_Sorting" OnRowCommand="GvTransport_RowCommand" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Route Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRouteName" runat="server" Text='<%# Eval("RouteName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Vehicle Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblvihicltetype" runat="server" Text='<%# Eval("TransportName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Vehicle No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblno" runat="server" Text='<%# Eval("VehicleNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Destination
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
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
                                            Contact No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("ContactNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
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
                                            License
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbllicence" runat="server" Text='<%# Eval("Licence")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Academic Session
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcademicSession" runat="server" Text='<%# Eval("AcademicSessionName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="True">
                                        <HeaderTemplate>
                                            Remark
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" Height="20px" class="form-control" runat="server" Text='<%# Eval("Remarks")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Edits" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField>
                                        <HeaderTemplate>
                                            Print ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="javascript: void(null);" style="color: red" onclick="PrintDriverIDCard2('<%# Eval("ID")%>'); return false;">Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-info button" Visible="false" OnClientClick="return Validate();" Text="Upload" OnClick="btnupdate_Click" />
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
            if (document.getElementById("<%=ddltranporttype.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select vehicle type";
                document.getElementById("<%=ddltranporttype.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtvehicleno.ClientID %>").value == "") {
                str = str + "\n Please enter vehicle's no.";
                document.getElementById("<%=txtvehicleno.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtcontactno.ClientID %>").value == "") {
                str = str + "\n Please enter contact no.";
                document.getElementById("<%=txtcontactno.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtdriverName.ClientID %>").value == "") {
                str = str + "\n Please enter driver name";
                document.getElementById("<%=txtdriverName.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtCareOf.ClientID %>").value == "") {
                str = str + "\n Please enter care of.";
                document.getElementById("<%=txtCareOf.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtAddress.ClientID %>").value == "") {
                str = str + "\n Please enter address.";
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                 i++;
            }
            if (document.getElementById("<%=txtlicence.ClientID %>").value == "") {
                str = str + "\n Please enter liscence no.";
                document.getElementById("<%=txtlicence.ClientID %>").focus();
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

        function PrintDriverIDCard() {
            objAcademic = document.getElementById("<%= ddlacademicsession.ClientID %>")
            objTranportType = document.getElementById("<%= ddltranporttype.ClientID %>")
            objVehicleNo = document.getElementById("<%= txtvehicleno.ClientID %>")
            objDriverName = document.getElementById("<%= txtdriverName.ClientID %>")
            objContactNo = document.getElementById("<%= txtcontactno.ClientID %>")
            window.open("../EduTransport/Reports/ReportViewer.aspx?option=PrintDriverID&ID=0&AcademicSessionID=" + objAcademic.value + "&RouteID=" + objRouteID.value + "&TranportTypeID=" + objTranportType.value + "&VehicleNo=" + objVehicleNo.value + "&DriverName=" + objDriverName.value + "&ContactNo=" + objContactNo.value)
        }

        function VehicleManager() {
            objAcademic = document.getElementById("<%= ddlacademicsession.ClientID %>")
            objTranportType = document.getElementById("<%= ddltranporttype.ClientID %>")
            objVehicleNo = document.getElementById("<%= txtvehicleno.ClientID %>")
            objDriverName = document.getElementById("<%= txtdriverName.ClientID %>")
            objContactNo = document.getElementById("<%= txtcontactno.ClientID %>")
            window.open("../EduTransport/Reports/ReportViewer.aspx?option=VehicleManager&ID=0&AcademicSessionID=" + objAcademic.value + "&RouteID=" + objRouteID.value + "&TranportTypeID=" + objTranportType.value + "&VehicleNo=" + objVehicleNo.value + "&DriverName=" + objDriverName.value + "&ContactNo=" + objContactNo.value)
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
