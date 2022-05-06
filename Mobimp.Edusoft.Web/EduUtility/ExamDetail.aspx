<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="ExamDetail.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduUtility.ExamDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li>Exam Utility&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="a1" href="../EduExamination/ExamName.aspx">Exam Name </a></li>&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i>
            <li><a class="active" runat="server" id="a2" href="../EduUtility/ExamDetail.aspx">Exam Mark Detail</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblmessage" Visible="false"></asp:Label>
                                <asp:Label runat="server" ID="lblacademic" Text="Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademic" AutoPostBack="true" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblclass" Text="Class">   </asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlclass" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblexamtype" Text="Exam Type">   </asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlexamtype" AutoPostBack="true" OnSelectedIndexChanged="ddlexamtype_SelectedIndexChanged" runat="server" class="form-control custextbox">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" Text="Search" OnClick="btnsearch_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                <%--<asp:Button ID="btnprint" class="btn btn-sm btn-success button" runat="server" Text="Print" OnClientClick="return Printstudentlist();" />--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card_wrapper" id="divsearch" runat="server">
                    <div class="row pad15">
                        <div class="col-md-4 customRow">
                            <asp:Label ID="lblresult" runat="server"></asp:Label>
                            <asp:Label ID="lbl_totalrecords" Visible="false" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
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
                        </div>
                        <div id="ExamDetailList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvExamdetails" EmptyDataText="No record found..." OnPageIndexChanging="GvExamdetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnRowDataBound="GvExamdetails_RowDataBound" OnSorting="GvExamdetails_Sorting" runat="server" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" HeaderStyle-Width="1%" />
                                    <asp:BoundField DataField="SubjectName" SortExpression="SubjectName" HeaderText="Subject Name" HeaderStyle-Width="5%" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="ID" Visible="false" runat="server" Text='<%# Eval("ID")%>'></asp:Label>--%>
                                            <asp:Label ID="lblexamID" Visible="false" runat="server" Text='<%# Eval("ExamID")%>'></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("SubjectID")%>'></asp:Label>
                                            <asp:Label ID="lbldescription" Visible="false" runat="server" Text='<%# Eval("SubjectName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Alternative Subject?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_altsubject" Font-Bold="true" Visible="false" runat="server" Text='<%# Eval("AltSubjectID")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chk_altsubject"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Optional Subject?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_optional" Font-Bold="true" Visible="false" runat="server" Text='<%# Eval("OptSubjectID")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="Chk_optional"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Science Comb?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsScience" Font-Bold="true" Visible="false" runat="server" Text='<%# Eval("IsScience")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkIsScience"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Sc.Science Comb?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsSocialScience" Font-Bold="true" Visible="false" runat="server" Text='<%# Eval("IsSocialScience")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkIsScocialScience"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Grade Subject?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsGrade" Font-Bold="true" Visible="false" runat="server" Text='<%# Eval("IsGradeSubject")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkIsGrade"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Subject in Total Mark?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblchkmarkcount" Visible="false" runat="server" Text='<%# Eval("IsMarkCount")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkmarkcount" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Theory Full Mark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtutmark" Height="20px" Width="50px" autocomplete="off" onfocus="this.select();" class="form-control custextbox" runat="server" Text='<%# Eval("UTmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtutmark" ID="FilteredTextBoxExtender1" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Theory Pass Mark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtutpmark" class="form-control custextbox" Height="20px" Width="50px" autocomplete="off" onfocus="this.select();" runat="server" Text='<%# Eval("UTpassmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtutpmark" ID="FilteredTextBoxExtender2" runat="server" ValidChars="1234567890.">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CA FM" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpwmark" class="form-control custextbox" Height="20px" Width="50px" autocomplete="off" onfocus="this.select();" runat="server" Text='<%# Eval("PWmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtpwmark" ID="FilteredTextBoxExtender3" runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CA PM" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpwpmark" class="form-control custextbox" Height="20px" Width="50px" autocomplete="off" onfocus="this.select();" runat="server" Text='<%# Eval("PWpassmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtpwpmark" ID="FilteredTextBoxExtender4" runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="HA Fmark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txthamark" class="form-control custextbox" Height="20px" Width="50px" autocomplete="off" onfocus="this.select();" runat="server" Text='<%# Eval("HAmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txthamark" ID="FilteredTextBoxExtender5" runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="HA Pmark">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txthapmark" class="form-control custextbox" Height="20px" runat="server" autocomplete="off" onfocus="this.select();" Text='<%# Eval("HApassmark")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txthapmark" ID="FilteredTextBoxExtender6" runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority Value" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtprioValue" class="form-control custextbox" runat="server" Text='<%# Eval("PrioValue")%>'></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtprioValue" ID="FilteredTextBoxExtender7"
                                                runat="server" ValidChars="1234567890">
                                            </asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Minor Subject?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsMinor" Visible="false" runat="server" Text='<%# Eval("IsMinorSubject")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chkIsMinor" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Activate?
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblActivate" Visible="false" runat="server" Text='<%# Eval("Isactivate")%>'></asp:Label>
                                            <asp:CheckBox runat="server" ID="chklActivate" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row mt10">
                    </div>
                    <div class="row mt10" style="margin-top: 13px;">
                        <div class="col-md-1 ">
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="LabelTotal" Text="Full Mark : " runat="server"></asp:Label>
                                <asp:Label ID="lbltotalmark" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="LabelPass" Text="Pass Mark : " runat="server"></asp:Label>
                                <asp:Label ID="lblpassmark" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group pull-right">
                                <asp:Button ID="btnUpdate" class="btn btn-sm btn-success button" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                            </div>
                        </div>

                    </div>
                </div>
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
                $('#ExamDetailList table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddlacademic.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please enter Session.";
                document.getElementById("<%=ddlacademic.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlclass.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please enter Class.";
                document.getElementById("<%=ddlclass.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=ddlexamtype.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please enter ExamType.";
                document.getElementById("<%=ddlexamtype.ClientID %>").focus();
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
                $('#ExamDetailList table tbody tr').each(function () {
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
