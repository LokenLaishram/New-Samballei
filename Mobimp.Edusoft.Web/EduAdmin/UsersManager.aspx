<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="UsersManager.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduAdmin.UsersManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Admin &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduAdmin/UsersManager.aspx">User Manager</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="lblempname" Text="Employee Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlemp" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblloginID" runat="server" Text="User Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtusername" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <%--      <asp:FilteredTextBoxExtender FilterType="UppercaseLetters,LowercaseLetters,Numbers"
                                    runat="server" ID="FilteredTextBoxExtender11" TargetControlID="txtusername">
                                </asp:FilteredTextBoxExtender>--%>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtpassword" TextMode="Password" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                                <%--              <asp:FilteredTextBoxExtender FilterType="UppercaseLetters,LowercaseLetters,Numbers"
                                    runat="server" ID="FilteredTextBoxExtender3" TargetControlID="txtpassword">
                                </asp:FilteredTextBoxExtender>--%>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblconfirmpassword" runat="server" Text="Confirm Password"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtcpassword" TextMode="Password" MaxLength="20" runat="server" class="form-control"></asp:TextBox>
                                <%--  <asp:FilteredTextBoxExtender FilterType="UppercaseLetters,LowercaseLetters,Numbers"
                                    runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtcpassword">
                                </asp:FilteredTextBoxExtender>--%>
                                <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtpassword" ControlToCompare="txtcpassword"
                                    runat="server" ErrorMessage="Password not match." ValidationGroup="grp"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblrole" runat="server"></asp:Label>
                                <asp:Label runat="server" ID="Label2" Text="Role Name"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlrole" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 customRow pull-right">
                            <div class="form-group pull-right" >
                                <asp:Button ID="btnsave" runat="server" class="btn btn-sm btn-success button" OnClientClick="return Validate();" Text="Add" OnClick="btnsave_Click" />
                                <asp:Button ID="btnsearch" class="btn btn-sm btn-info button" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Please wait..'" Text="Reset" OnClick="btncancel_Click" />
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
                        <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                            <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-3 customRow">
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
                        <div id="ClassList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvUserdetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." OnPageIndexChanging="GvUserdetails_PageIndexChanging"
                                CssClass="footable table-striped" AllowSorting="true" OnSorting="GvUserdetails_Sorting" OnRowCommand="GvUserdetails_RowCommand" runat="server" OnRowDataBound="GvUserdetails_RowDataBound" AutoGenerateColumns="false"
                                Style="width: 100%">
                                <Columns>
                                    <asp:BoundField DataField="LoginID" SortExpression="LoginID" HeaderText="ID" />
                                    <asp:BoundField DataField="UserName" SortExpression="UserName" HeaderText="User Name" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Password
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblpassword" runat="server" Text='<%# Eval("UserPassword") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"/>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RoleName" SortExpression="RoleName" HeaderText="Role Name" />
                                    <asp:BoundField DataField="EmployeeName" SortExpression="EmployeeName" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="AddedBy" SortExpression="AddedBy" HeaderText="Added By" />
                                    <asp:BoundField DataField="AddedDate" SortExpression="AddedDate" HeaderText="Added Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("LoginID")%>'></asp:Label>
                                            <asp:Button ID="lnkEdit" Text="Edit" class="cus-btn btn-sm btn-info button" runat="server"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" CommandName="Edits" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="lnkDelete" class="cus-btn btn-sm btn-danger button" Text="Delete" runat="server"
                                                CommandName="Deletes" ValidationGroup="none" OnClientClick="functionConfirm(this); return false;" />
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
            if (document.getElementById("<%=ddlemp.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Employee.";
                document.getElementById("<%=ddlemp.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtusername.ClientID%>").value == "") {
                str = str + "\n Please Enter User Name.";
                document.getElementById("<%=txtusername.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtpassword.ClientID%>").value == "") {
                str = str + "\n Please Enter Password.";
                document.getElementById("<%=txtpassword.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=txtpassword.ClientID%>").value = "") {
                str = str + "\n Please Enter Password.";
                document.getElementById("<%=txtpassword.ClientID %>").focus();
                i++;
            }
            if (document.getElementById("<%=txtcpassword.ClientID%>").value == "") {
                str = str + "\n Please Enter Confirm Password.";
                document.getElementById("<%=txtcpassword.ClientID %>").focus();
                i++;
            }

            if (document.getElementById("<%=ddlrole.ClientID%>").selectedIndex == "0") {
                str = str + "\n Please Select Role.";
                document.getElementById("<%=ddlrole.ClientID %>").focus();
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
                        __doPostBack('<%=GvUserdetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }


        $(function () {
            $('[id*=GvUserdetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvUserdetails]').footable();

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
