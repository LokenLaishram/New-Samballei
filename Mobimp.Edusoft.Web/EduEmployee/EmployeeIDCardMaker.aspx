<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="EmployeeIDCardMaker.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduEmployee.EmployeeIDCardMaker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
  
     <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Employees&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="a1" href="../EduUtility/ClassMST.aspx">EmployeeIDCardMarker</a></li>
        </ol>
      <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card_wrapper">
                <div class="row mt10">    
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblacademicsession" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicseesions" AutoPostBack="true"  runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                     </div>
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblempnames" Text="Employee Name"></asp:Label>
                                <asp:TextBox ID="txtempnames" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtempnames" ID="FilteredTextBoxExtender8"
                                        runat="server" ValidChars=" -ABCDEFGHIJKLMNOPQRSTWUVXYZabcdefghijklmnopqrstwuvxyz"
                                        Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender" runat="server"
                                        ServiceMethod="GetempNames" MinimumPrefixLength="2" CompletionInterval="100"
                                        CompletionSetCount="1" TargetControlID="txtempnames" UseContextKey="True" DelimiterCharacters=""
                                        Enabled="True" ServicePath="">
                                    </asp:AutoCompleteExtender>
                            </div>
                     </div>                    
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblsexs" Text="Gender"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlsexs" AutoPostBack="true"  runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                     </div>
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblstatus" Text="Status"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlstatus"  AutoPostBack="true"
                                    runat="server" class="form-control ">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                </div>
                <div class="row ">
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblemployeeNo" Text="Employee No"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:TextBox ID="txtemployeedID" MaxLength="100" runat="server" class="form-control"></asp:TextBox>
                            </div>
                     </div>
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblempcaategorys" Text="Employee Category"></asp:Label>
                                <asp:DropDownList ID="ddlempcategories" AutoPostBack="true"  runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                     </div>
                    <div class="col-md-3 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblstafftypess" Text="Staff Type"></asp:Label>
                                <asp:DropDownList ID="ddlstfftypes" AutoPostBack="true"  runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                     </div>                  
                    <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
                                <asp:Button ID="btnprintprofile" class="btn btn-sm btn-indigo button" runat="server" Text="Print IDCard" OnClientClick="return PrintempEmpIDCard();" />
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
                                        <asp:LinkButton ID="btn_export" Visible="false"   runat ="server"><i class="ficon icon-export" style="font-size:48px;"></i></asp:LinkButton>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_export" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1  customRow" style="text-align: right; margin-top: 1em;">
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
                            <div id="EmployeeIDCardList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvemployeeDetails" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..."
                                      OnPageIndexChanging="GvemployeeDetails_PageIndexChanging" AllowSorting="true" CssClass="footable table-striped" AutoGenerateColumns="False" 
                                        runat="server" Style="width: 100%" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:Image ID="empPhoto" Height="100px" runat="server" ImageUrl='<%# "~/EmpImageHandler.ashx?EmpID="+ Eval("EmployeeID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                                <%--<ItemTemplate>
                                                    <asp:Image ID="Image1" Height="100px" Width="75px" runat="server" ImageUrl='<%# Bind("EmployeePhotoLocation") %>' /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Emp No.</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNo" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Emp Code</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("EmployeeCode")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Emp Name</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcode" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Gender</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsex" runat="server" Text='<%# Eval("SexName")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added By</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdedBy" runat="server" Text='<%# Eval("AddedBy","{0:dd-MM-yyyy}")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Added Date</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbladdeddate" runat="server" Text='<%# Eval("AddedDate","{0:dd-MM-yyyy}")%>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="3%" />
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

        function PrintempEmpIDCard()
        {
                objempnames = document.getElementById("<%= txtempnames.ClientID %>")
                objacademicsessionID = document.getElementById("<%= ddlacademicseesions.ClientID %>")
                objSexID = document.getElementById("<%= ddlsexs.ClientID %>")
                objEmpID = document.getElementById("<%= txtemployeedID.ClientID %>")
                objstatus = document.getElementById("<%= ddlstatus.ClientID %>")
                objEmpCategory = document.getElementById("<%= ddlempcategories.ClientID %>")
                objstaff = document.getElementById("<%= ddlstfftypes.ClientID %>")

                window.open("../EduEmployee/Reports/ReportViewer.aspx?option=EmpIDCard&EmpName=" + objempnames.value + "&SessionID=" + objacademicsessionID.value + "&SexID=" + objSexID.value + "&EmpNo=" + objEmpID.value + "&Status=" + objstatus.value + "&EmpCategory=" + objEmpCategory.value + "&StaffID=" + objstaff.value)
        }
        $(document).ready(function () {
            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#EmployeeIDCardList table tbody tr').each(function () {
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
            if (document.getElementById("<%=ddlacademicseesions.ClientID%>").selectedIndex == "") {
                str = str + "\n Please enter Academic Session.";
                document.getElementById("<%=ddlacademicseesions.ClientID %>").focus();
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
                        __doPostBack('<%=GvemployeeDetails.UniqueID%>', 'Deletes$' + paramID);
                        //alert(paramID);
                    } else {
                        swal("Your data is safe!");
                    }
                });

        }

        $(function () {
            $('[id*=GvemployeeDetails]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvemployeeDetails]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#EmployeeIDCardList table tbody tr').each(function () {
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
