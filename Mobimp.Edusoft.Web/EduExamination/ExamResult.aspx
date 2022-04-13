<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="ExamResult.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Campusoft.Web.EduExamination.ExamResult" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Examination&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduExamination/ExamResult.aspx">Print Result</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="row mt10">
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                    <asp:Label runat="server" ID="lblacademicsession" Text="Academic Year"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control "></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblclasses" Text="Class"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlclasses" runat="server" class="form-control" OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblsections" Text="Section"></asp:Label>
                                    <asp:DropDownList ID="ddlsections" runat="server" class="form-control" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblexam" Text="Exam"></asp:Label>
                                    <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                    <asp:DropDownList ID="ddlexam" runat="server" class="form-control" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
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
                                    <asp:Label runat="server" ID="lblrollNo" Text="Roll No"></asp:Label>
                                    <asp:TextBox ID="txtrollNo" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender3"
                                        runat="server" ValidChars="0123456789" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblTop" Text="Select Top"></asp:Label>
                                    <asp:TextBox ID="txttopstudent" MaxLength="5" runat="server" class="form-control"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender TargetControlID="txttopstudent" ID="FilteredTextBoxExtender1"
                                        runat="server" ValidChars="0123456789">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="col-md-3 customRow">
                                <div class="form-group pull-right" style="margin-top: 1.8em;">
                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_Click" />
                                    <asp:Button ID="btnReset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                    <asp:Button ID="btnprintall" class="btn btn-sm btn-indigo button" runat="server" Text="Print" OnClientClick="return PrintResult();" />                                    
                                </div>
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
                                    <asp:LinkButton ID="btn_export" Visible="false" OnClick="btn_export_Click" runat="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
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
                            <asp:GridView ID="GvExamdetails" AllowPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvExamdetails_PageIndexChanging"
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
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Roll No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblroll" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                            <asp:Label ID="lbliswitheld" Visible="false" runat="server" Text='<%# Eval("IsWitheld")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sec
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblsec" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rank">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server"  class="form-control" Text='<%# Eval("Ranks")%>'
                                                Width="30px" ID="txtrank"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Is Witheld?">
                                        <HeaderTemplate>
                                            Is Witheld?
                                                <asp:CheckBox ID="chekboxall" AutoPostBack="true" runat="server" OnCheckedChanged="chekboxall_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chekboxselect" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                            <div class="row">
                                <div class="col-md-12 customRow">
                                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                                        <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-info button" OnClientClick="javascript: return confirm('Are you sure to update?');" Text="Update" OnClick="btnupdate_Click" Visible="false" />
                                    </div>
                                </div>
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
            if (document.getElementById("<%=ddlacademicseesions.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexam.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please select Exam Name.";
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
        

        function PrintResult() {
            objclass = document.getElementById("<%= ddlclasses.ClientID %>")
            objsection = document.getElementById("<%= ddlsections.ClientID %>")
            objroll = document.getElementById("<%= txtrollNo.ClientID %>")
            objexam = document.getElementById("<%= ddlexam.ClientID %>")
            objtopstudent = document.getElementById("<%= txttopstudent.ClientID %>")
            objsession = document.getElementById("<%= ddlacademicseesions.ClientID %>")

            window.open("../EduReports/Reports/ReportViewer.aspx?option=PrintResult&ClassID=" + objclass.value + "&SectionID=" + objsection.value + "&RollNo=" + objroll.value + "&ExamID=" + objexam.value + "&TopStudent=" + objtopstudent.value + "&Session=" + objsession.value);
        }
    </script>
</asp:Content>



