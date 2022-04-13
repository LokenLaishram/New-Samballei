<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="CertificateMaker.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduReports.CertificateMaker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" runat="server" id="a1" href="../EduReports/CertificateMaker.aspx">Certificate Maker</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclasses" runat="server" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged"
                                    class="form-control " AutoPostBack="true" Enabled="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsections" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <asp:Label ID="lblCertificate" runat="server" Text="Certificate Type"></asp:Label>
                            <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                            <asp:DropDownList ID="ddlCertificateType" runat="server" class="form-control" OnSelectedIndexChanged="ddlCertificateType_SelectedIndexChanged">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Character</asp:ListItem>
                                <asp:ListItem Value="2">Transfer</asp:ListItem>
                                <asp:ListItem Value="3">Provisional</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblrollNo" runat="server" Text="Roll No"></asp:Label>
                                <asp:TextBox ID="txtrollNo" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender9"
                                    runat="server" ValidChars="0123456789"
                                    Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_printdate" runat="server" Text="Print Date"></asp:Label>
                                <asp:TextBox ID="txt_printdate" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                    TargetControlID="txt_printdate" />
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_printdate" />
                            </div>
                        </div>
                    </div>
                    <div class="row mt10">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" OnClientClick="return Validate() " />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-red button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                <asp:Button ID="btnprint" runat="server" class="btn btn-sm btn-indigo button" Text="Print" OnClientClick="return PrintCertificate();" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper" id="divSearch" runat="server">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecord" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-3 customRow" style="text-align: right; margin-top: 1em;">
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
                        <div id="ClassList" class="col-md-12 customRow " style="overflow: auto">
                            <asp:GridView ID="GvCertificateDetails" EmptyDataText="No record found..." OnRowDataBound="GvCertificateDetails_RowDataBound"
                                OnPageIndexChanging="GvCertificateDetails_PageIndexChanging" OnSorting="GvCertificateDetails_Sorting" CssClass="footable table-striped"
                                AllowSorting="true" runat="server" AutoGenerateColumns="false" Style="width: 100%" AllowPaging="true" AllowCustomPaging="true">
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
                                            Student ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstudentID" runat="server" Text='<%# Eval("StudentID")%>'></asp:Label>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Roll No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblroll" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sub Division
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSubDivision" class="form-control" runat="server" Text='<%# Eval("SubDivisions")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Board Roll No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBrollno" class="form-control" Text='<%# Eval("BRollNo")%>' runat="server" ></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtBrollno" ID="FilteredTextBoxExtender11"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Division
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblBDiv" runat="server" Text='<%# Eval("BDivision")%>'></asp:Label>
                                            <asp:DropDownList ID="ddlBDiv" Class="form-control" runat="server" Width="70px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">First</asp:ListItem>
                                                <asp:ListItem Value="2">Second</asp:ListItem>
                                                <asp:ListItem Value="3">Third</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date Left-On
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdateleft" class="form-control" Text='<%# Eval("DateLeft")%>' runat="server" ></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy,dd-MM-yyyy"
                                                TargetControlID="txtdateleft" />
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtdateleft" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Passing Year
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblYearP" runat="server" Text='<%# Eval("YearPass")%>'></asp:Label>
                                            <asp:DropDownList ID="ddlYearP" Class="form-control" runat="server" Width="80px">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="10">2019</asp:ListItem>
                                                <asp:ListItem Value="11">2020</asp:ListItem>
                                                <asp:ListItem Value="12">2021</asp:ListItem>
                                                <asp:ListItem Value="13">2022</asp:ListItem>
                                                <asp:ListItem Value="14">2023</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Regist.No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtregistrationno" class="form-control" Text='<%# Eval("RegistrationNo")%>' runat="server" ></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtregistrationno" ID="FilteredTextBoxgistrationno"
                                                runat="server" ValidChars="1234567890" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chekboxall" runat="server" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreate" Visible="false" runat="server" Text='<%# Eval("IsCertificateCreate")%>'></asp:Label>
                                            <asp:CheckBox ID="chekboxIsCreate" runat="server" onclick="Check_Click(this);" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btn_delete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-md-12 customRow">
                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                            <asp:Button ID="btnupdate" Visible="false" class="btn btn-sm btn-success button" runat="server" Text="Create" OnClick="btnupdate_Click" />
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
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclasses.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlCertificateType.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Certificate type.";
                document.getElementById("<%=ddlCertificateType.ClientID %>").focus();
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
            $('[id*=GvCertificateDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvCertificateDetails]').footable();

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

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
        function PrintCertificate() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objrollno = document.getElementById("<%= txtrollNo.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objCtype = document.getElementById("<%= ddlCertificateType.ClientID %>")
            objprintdate = document.getElementById("<%= txt_printdate.ClientID %>")

            if (objCtype.value == "1") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Character&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value + "&PrintDate=" + objprintdate.value)
            }
            if (objCtype.value == "2") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Transfer&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value + "&PrintDate=" + objprintdate.value)
            }
            if (objCtype.value == "3") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=Provisional&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value + "&PrintDate=" + objprintdate.value)
            }
        }
    </script>
</asp:Content>
