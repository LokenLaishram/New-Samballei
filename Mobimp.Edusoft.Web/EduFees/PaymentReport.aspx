<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="PaymentReport.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduFees.DefaulterList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Fees &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" id="activepage" class="active" href="../EduFees/PaymentReport.aspx">Payment Report</a></li>
        </ol>
        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="card_wrapper">
                    <div class="row">
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
                                <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                                <asp:DropDownList ID="ddlsections" AutoPostBack="true" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblrollNo" Text="Roll No"></asp:Label>
                                <asp:TextBox ID="txtrollNo" MaxLength="3" runat="server" class="form-control"></asp:TextBox>
                                <asp:FilteredTextBoxExtender TargetControlID="txtrollNo" ID="FilteredTextBoxExtender2"
                                    runat="server" ValidChars="0123456789" Enabled="True">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="lbl_feetype" runat="server" Text="Fee Type"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_feetype" runat="server" AutoPostBack="true" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Upto Month "></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_month" runat="server" AutoPostBack="true" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-2 customRow">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddl_status" runat="server" AutoPostBack="true" class="form-control ">
                                    <asp:ListItem Value="1">Paid</asp:ListItem>
                                    <asp:ListItem Value="2">UnPaid</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-10 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" OnClientClick="return Validate();" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnprint" class="btn btn-sm btn-indigo button" runat="server" OnClick="btnprint_Click" Text="Print" />
                                <asp:Button ID="btn_sprint" class="btn btn-sm btn-indigo button" runat="server" OnClick="sbtnprint_Click" Text="Std_Print" />
                                <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" OnClick="btncancel_Click" Text="Reset" />
                                <asp:UpdateProgress ID="updateProgress6" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading6" runat="server" class="Pageloader ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                            </div>
                        </div>
                    </div>

                </div>
                <div class="card_wrapper" id="divsearch" visible="false" runat="server">
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
                    <div>

                        <div id="BillList" style="width: 100%;">
                            <asp:GridView ID="GvFeedetails" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                AutoGenerateColumns="False" AllowPaging="true" AllowCustomPaging="true" Width="100%" OnRowCommand="GvFeedetails_RowCommand" AllowSorting="true" OnSorting="GvClassDetails_Sorting" OnPageIndexChanging="GvFeedetails_PageIndexChanging" class="grid" HeaderStyle-Height="45px"
                                HorizontalAlign="Center" GridLines="None">
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
                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("StudentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("ClassName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sec" runat="server" Text='<%# Eval("SectionName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Roll">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_roll" runat="server" Text='<%# Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Particulars
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_particulars" runat="server" Text='<%# Eval("Particulars")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Total Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totalamount" runat="server" Text='<%# Eval("TotalFeeAmount", "{0:0#.##}")%>'></asp:Label>
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

                <script type="text/javascript">

                    $(document).ready(function () {
                        $('.searchs').on('keyup', function () {
                            var searchTerm = $(this).val().toLowerCase();
                            $('#BillList table tbody tr').each(function () {
                                var lineStr = $(this).text().toLowerCase();
                                if (lineStr.indexOf(searchTerm) === -1) {
                                    $(this).hide();
                                } else {
                                    $(this).show();
                                }
                            });
                        });
                    });


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
                            $('#BillList table tbody tr').each(function () {
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function Validate() {

            var str = ""
            var i = 0

            if (document.getElementById("<%=ddl_feetype.ClientID%>").selectedIndex == "0") {
                str = str + " Please select fee type.\n"
                document.getElementById("<%=ddl_feetype.ClientID %>").focus()
                i++
            }
            if (document.getElementById("<%=ddl_month.ClientID%>").selectedIndex == "0") {
                str = str + " Please select month.\n"
                document.getElementById("<%=ddl_month.ClientID %>").focus()
                i++
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
    </script>
</asp:Content>
