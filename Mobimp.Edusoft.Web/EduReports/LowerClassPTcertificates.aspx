<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="LowerClassPTcertificates.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduReports.LowerClassPTcertificates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Reports&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduReports/LowerClassPTcertificates.aspx">Lower Class certificates</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">

                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclass" runat="server"    OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                    class="form-control " AutoPostBack="true" >
                                </asp:DropDownList>
                            </div>
                         
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsection" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblrollNo" runat="server" Text="Roll No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtrollnos" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <asp:Label ID="lblCertificate" runat="server" Text="Certificate"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcType" runat="server" class="form-control">
                                        <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                        <asp:ListItem Value="1">Provisional</asp:ListItem>
                                        <asp:ListItem Value="2">Transfer </asp:ListItem>
                                        <asp:ListItem Value="3">Reading </asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                         </div>
                        <div class="col-md-3 customRow">
                        <asp:Label ID="lbldiv" runat="server" Text="Division"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddldiv" runat="server" class="form-control">
                                        <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                        <asp:ListItem Value="1">1st</asp:ListItem>
                                        <asp:ListItem Value="2">2nd</asp:ListItem>
                                        <asp:ListItem Value="3">3rd</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">

                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-info button"  OnClientClick="return Validate();"
                                    Text="Create" OnClick="btnsave_Click" /> 
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-success button" Text="Search" OnClientClick="return Validate1();"
                                    OnClick="btnsearch_Click" />
                                <asp:Button ID="btncanceldeliv" runat="server"  class="btn btn-sm btn-danger button" Text="Reset" OnClick="btncanceldeliv_Click" />
                                <asp:Button ID="btnprint" runat="server" class="btn btn-sm btn-info button" Text="Print" 
                                    OnClientClick="return PrintCertificate();" />
                            </div> <%--Enabled="False"--%>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper">
                    <div class="row pad15">
                        <div class="col-md-4 customRow" style="margin-top: 13px;">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
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
                            <asp:UpdateProgress ID="updateProgress1" runat="server">
                                <ProgressTemplate>
                                    <div id="DIVloading" runat="server" class="Pageloader">
                                        <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                            AlternateText="Loading ..." ToolTip="Loading ..." />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>                      
                        <div id="ClassList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvCertificateDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                OnRowCommand="Gvcertificate_RowCommand"  OnSorting="GvCertificateDetails_Sorting" GridLines="None"
                                CssClass="footable table-striped" AllowSorting="true" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            C No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblccID" runat="server" Visible="false" Text='<%# Eval("ID")%>'></asp:Label>
                                            <asp:Label ID="lblctno" runat="server" Text='<%# Eval("CNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstudentname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Class
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Section
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblsectionname" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            RollNo
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblrollno" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Created By
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            DCC Date
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldccdate" runat="server" Text='<%# Eval("CDate","{0:dd/MM/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                             <asp:Button ID="lnkdelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server" 
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
                dangerMode: true,
                dangerMode: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        __doPostBack('<%=GvCertificateDetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

       }



        function Validate() {

            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                 str = str + "\n Please select Academic Session.";
                 document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                 i++;
             }
             if (document.getElementById("<%=ddlclass.ClientID %>").selectedIndex == "0") {
                 str = str + "\n Please select Class.";
                 document.getElementById("<%=ddlclass.ClientID %>").focus();
                 i++;
             }
             if (document.getElementById("<%=ddlsection.ClientID %>").selectedIndex == "0") {
                 str = str + "\n Please select Section.";
                 document.getElementById("<%=ddlsection.ClientID %>").focus();
                 i++;
             }
             if (document.getElementById("<%=ddlcType.ClientID %>").selectedIndex == "0") {
                 str = str + "\n Please select Certificate type.";
                 document.getElementById("<%=ddlcType.ClientID %>").focus();
                 i++;
             }
             if (document.getElementById("<%=txtrollnos.ClientID %>").value == "") {
                 str = str + "\n Please enter Roll No.";
                 document.getElementById("<%=txtrollnos.ClientID %>").focus();
                 i++;
             }
             if (document.getElementById("<%=ddldiv.ClientID %>").selectedIndex == "0") {
                 str = str + "\n Please select division.";
                 document.getElementById("<%=ddldiv.ClientID %>").focus();
                i++;
            }

            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }
        function Validate1() {

            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlcType.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select Certificate type.";
                document.getElementById("<%=ddlcType.ClientID %>").focus();
                i++;
            }
            if (str.length > 0) {
                alert("Check Following Required Fields : " + str);
                return false;
            }
            else
                return true;
        }

        function PrintCertificate() {
            objclass = document.getElementById("<%= ddlclass.ClientID %>")
            objsection = document.getElementById("<%= ddlsection.ClientID %>")
            objrollno = document.getElementById("<%= txtrollnos.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objCtype = document.getElementById("<%= ddlcType.ClientID %>")
            if (objCtype.value == "1") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=LowerProvisional&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
            }
            else if (objCtype.value == "2") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=LowerTransfer&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
            }
            else if (objCtype.value == "3") {
                window.open("../EduReports/Reports/ReportViewer.aspx?option=LowerReading&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&CertificateType=" + objCtype.value)
            }
        }
    </script>
</asp:Content>
