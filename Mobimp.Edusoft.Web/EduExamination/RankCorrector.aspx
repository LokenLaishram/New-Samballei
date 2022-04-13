<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="RankCorrector.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.RankCorrector" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduExamination/RankCorrector.aspx">Rank Corrector</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblacademicsession" runat="server" Text="Academic Year"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" class="form-control " OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlsections" runat="server" class="form-control "></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblexam" runat="server" Text="Exam"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlexam" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrollNo" Text="Roll No"></asp:Label>
                                <asp:TextBox ID="txtrollNo" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender4"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblstatus" Text="Status"></asp:Label>
                                <asp:DropDownList ID="ddlstatus" runat="server" class="form-control ">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Pass</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbltop" Text="Top Rank"></asp:Label>
                                <asp:TextBox ID="txtrank" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrank" ID="FilteredTextBoxExtender1"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblwork" Text="total WD"></asp:Label>
                                <asp:TextBox ID="txtworkingdays" MaxLength="3" runat="server" class="form-control" placeholder="Working Days"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtworkingdays" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btncancel_Click" />
                                <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return Printtoplist();" />
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
                                    <asp:LinkButton ID="btn_export" Visible="false" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn_export" />
                                </Triggers>
                            </asp:UpdatePanel>
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
                            <asp:GridView ID="GvExamdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvExamdetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvExamdetails_Sorting" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%" OnRowDataBound="GvExamdetails_RowDataBound">
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
                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attedance">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" class="form-control" Text='<%# Eval("Attendance")%>'
                                                Width="60px" ID="txtattendance" MaxLength="3"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtattendance" ID="FilteredTextBoxExtender4"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Obtained">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotalmark" runat="server" Text='<%# Eval("TotalMarkObtain")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("ResultStatus")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PC" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpc" runat="server" Text='<%# Eval("PC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
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
                                    <asp:TemplateField HeaderText="Rank">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" class="form-control" Text='<%# Eval("Ranks")%>' Width="60px"
                                                ID="txtrank"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button" Visible="false" OnClientClick="javascript: return confirm('Are you sure to update?');" Text="Update" OnClick="btnupdate_Click" />
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
            if (document.getElementById("<%=ddlclasses.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Class.";
                document.getElementById("<%=ddlclasses.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlsections.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Section.";
                document.getElementById("<%=ddlsections.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Type.";
                document.getElementById("<%=ddlexam.ClientID %>").focus();
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
                        __doPostBack('<%=GvExamdetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvExamdetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvExamdetails]').footable();

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


        function Printtoplist() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objrollno = document.getElementById("<%= txtrollNo.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")
            objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
            objexam = document.getElementById("<%= ddlexam.ClientID %>")
            objrank = document.getElementById("<%= txtrank.ClientID %>")

            window.open("../EduReports/Reports/ReportViewer.aspx?option=Toplist&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&ExamID=" + objexam.value + "&RollNo=" + objrollno.value + "&Session=" + objsession.value + "&Status=" + objstatus.value + "&Rank=" + objrank.value)
        }
    </script>
</asp:Content>
