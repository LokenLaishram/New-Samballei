<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="StudentTypeWiseFeeStructure.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduUtility.StudentTypeWiseFeeStructure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fee Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/StudentTypeWiseFeeStructure.aspx">Fee Type</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblsession" Text="Academic Year"></asp:Label>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control " AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblamissiontype" Text="Admission Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddladmissiontype" class="form-control " runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclass" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblfeetype" runat="server" Text="Fee Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlfeetype" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
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
                                    <asp:LinkButton ID="btn_export" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn_export" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                            <asp:Label ID="lbl_show" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-1 customRow">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_show" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" runat="server" class="form-control">
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
                        <div id="Feedetails" class="col-md-12 customRow ">
                            <asp:GridView ID="GvFeedetails" AllowPaging="true" EmptyDataText="No record found..." OnRowDataBound="GvFeedetails_RowDataBound"
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GvFeedetails_PageIndexChanging"
                                Style="width: 100%" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            SL No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Student Type
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            <asp:Label ID="lblfeetypeID" Visible="false" runat="server" Text='<%# Eval("FeeTypeID") %>'></asp:Label>
                                            <asp:Label ID="sessionID" Visible="false" runat="server" Text='<%# Eval("AcademicSessionID") %>'></asp:Label>
                                            <asp:Label ID="lblclassID" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                            <asp:Label ID="lbladmissiontype" Visible="false" runat="server" Text='<%# Eval("AdmissionTypeID") %>'></asp:Label>
                                            <asp:Label ID="lblstudentypeID" Visible="false" runat="server" Text='<%# Eval("StudentTypeID") %>'></asp:Label>
                                            <asp:Label ID="lblstudentype" runat="server" Text='<%# Eval("StudentType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Fee Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtfeeamount" Text='<%# Eval("FeeAmount", "{0:0#.##}")%>'
                                                class="form-control"  MaxLength="6"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtfeeamount" ID="FilteredTextBoxExtender6"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Exempted Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtbreakupamnt" Text='<%# Eval("ExemptedAmount", "{0:0#.##}")%>'
                                                class="form-control"  MaxLength="6"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtbreakupamnt" ID="FilteredTextBoxExtender7"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Late Fine
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtlatefine" Text='<%# Eval("LateFine", "{0:0#.##}")%>'
                                                class="form-control"  MaxLength="6" OnTextChanged="txtlatefine_TextChanged"  AutoPostBack="true"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtlatefine" ID="FilteredTextBoxExtendertxtlatefine"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            FineDate
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtfinedate" runat="server" class="form-control" Text='<%# Eval("FineDate","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtfinedate"    />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtfinedate" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Net Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtnetamount" Text='<%# Eval("TotalFeeAmount", "{0:0#.##}")%>'
                                                class="form-control"  MaxLength="6"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtnetamount" ID="FilteredTextBoxExtendertxtnetamount"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Due Allowed
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldueallowed" class="form-control" Visible="false" runat="server" Text='<%# Eval("DueAllowed")%>'></asp:Label>
                                            <asp:CheckBox ID="chkdueallowedstatus"  runat="server" OnCheckedChanged="chkdueallowedstatus_CheckedChanged" AutoPostBack="true"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Due Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtdueamount" Text='<%# Eval("DueAmount", "{0:0#.##}")%>'
                                                class="form-control" Height="30px" MaxLength="6" Enabled="false"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtdueamount" ID="FilteredTextBoxExtender8"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"  />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>

                        </div>
                    </div>
                </div>
                <div class="row mt10">
                    <div class="col-md-12 customRow">
                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                            <asp:Button ID="btnupdate" runat="server" Visible="False" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Update" OnClick="btnupdate_Click" />

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
                $('#Feedetails table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddlacademicsession.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Session.";
                document.getElementById("<%=ddlacademicsession.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddladmissiontype.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select admission type.";
                document.getElementById("<%=ddladmissiontype.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclass.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlfeetype.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select feetype.";
                document.getElementById("<%=ddlfeetype.ClientID %>").focus();
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
                        __doPostBack('<%=GvFeedetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvFeedetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvFeedetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Feedetails table tbody tr').each(function () {
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

