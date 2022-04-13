<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="ExamDivisionRule.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.ExamDivisionRule" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Student Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduExamination/ExamDivisionRule.aspx">Exam Result Division Rule Master</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblgrade" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlSessionID" runat="server" class="form-control custextbox">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="Label1" Text="Exam"></asp:Label>
                                <asp:DropDownList ID="ddlExamID" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lbldescription" Text="Class"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlClassID" runat="server" class="form-control custextbox"
                                    AutoPostBack="true" OnTextChanged="ddlExamID_OnTextChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" Text="Add New Row" OnClick="btnsave_Click" />
                                <asp:Button ID="Button1" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_OnClick" />

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
                        <div class="col-md-2 ">
                            <asp:Label ID="Label2" runat="server" Text='Division'></asp:Label>
                            <asp:CheckBox runat="server" ID="chkIsDivision" />
                            <asp:Label ID="lblIsGrade" runat="server" Text='Grade'></asp:Label>
                            <asp:CheckBox runat="server" ID="chkIsGrade" />                            
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
                        <div class="col-md-2 customRow">
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
                            <asp:GridView ID="GvExamDivisionRule" AllowPaging="false" AllowCustomPaging="true" EmptyDataText="No record found..." AutoGenerateColumns="false"
                                CssClass="footable table-striped" AllowSorting="true" runat="server"
                                Style="width: 100%">
                                <%-- OnSorting="GvExamDivisionRule_Sorting" OnRowCommand="GvExamDivisionRule_RowCommand"--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblclassName" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                            <asp:Label ID="lblClassID" runat="server" Visible="false" Text='<%# Eval("ClassID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of the Exam" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExam" runat="server" Text='<%# Eval("ExamName") %>'></asp:Label>
                                            <asp:Label ID="lblExamID" runat="server" Visible="false" Text='<%# Eval("ExamID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Division">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDivision" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("DivisionName")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtDivision" ID="FilteredTextBoxExtender1" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz.1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PC From">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPCFrom" Height="20px" MaxLength="2" class="form-control custextbox" runat="server" Text='<%# Eval("PCFrom")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtPCFrom" ID="FilteredTextBoxExtender2" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PC UpTo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPCUpTo" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("PCUpTo")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtPCUpTo" ID="FilteredTextBoxExtender3" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of absent ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfAbsent" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfAbsent")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfAbsent" ID="FilteredTextBoxExtender4" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of absent Upto ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfAbsentUpto" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfAbsentUpto")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfAbsentUpto" ID="FilteredTextBoxExtender41" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of subject failed allow ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfFailed" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfFailed")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfFailed" ID="FilteredTextBoxExtender5" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of subject failed allow upto">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfFailedUpto" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfFailedUpto")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfFailedUpto" ID="FilteredTextBoxExtender51" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="No. of subject failed / absent allow (both common) ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfFailedAbsent" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfFailed")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfFailedAbsent" ID="FilteredTextBoxExtender52" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="No. of subject failed / absent allow Upto (both common) ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfFailedAbsentUpto" Height="20px" MaxLength="3" class="form-control custextbox" runat="server" Text='<%# Eval("NoOfFailed")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtNoOfFailedAbsentUpto" ID="FilteredTextBoxExtender53" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grade">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGrade" Height="20px" MaxLength="2" class="form-control custextbox" runat="server" Text='<%# Eval("Grade")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtGrade" ID="FilteredTextBoxExtender6" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ+ 0123457896">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grade PC From">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGradePCFrom" Height="20px" MaxLength="2" class="form-control custextbox" runat="server" Text='<%# Eval("GPCFrom")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtGradePCFrom" ID="FilteredTextBoxExtender7" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PC UpTo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGradePCUpTo" Height="20px" MaxLength="2" class="form-control custextbox" runat="server" Text='<%# Eval("GPCUpTo")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtGradePCUpTo" ID="FilteredTextBoxExtender8" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Division Divisions">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDivisionRemark" Height="20px" class="form-control custextbox" runat="server" Text='<%# Eval("DivisionRemark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtDivisionRemark" ID="FilteredTextBoxExtender9" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz.1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
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
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button" Visible="true" OnClientClick="javascript: return confirm('Are you sure want to update?');" Text="Update" OnClick="btnupdate_Click" />
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
            if (document.getElementById("<%=ddlSessionID.ClientID%>").value == "") {
                str = str + "\n Please select academic session.";
                document.getElementById("<%=ddlSessionID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlClassID.ClientID%>").value == "") {
                str = str + "\n Please select name of the clase.";
                document.getElementById("<%=ddlClassID.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlExamID.ClientID%>").value == "") {
                str = str + "\n Please select name of the clase.";
                document.getElementById("<%=ddlExamID.ClientID %>").focus();
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
                        __doPostBack('<%=GvExamDivisionRule.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvExamDivisionRule]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvExamDivisionRule]').footable();

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
