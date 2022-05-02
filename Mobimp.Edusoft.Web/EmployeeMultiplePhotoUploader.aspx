<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeMultiplePhotoUploader.aspx.cs" Inherits="Mobimp.EduUtility.Web.EmployeeMultiplePhotoUploader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="ContentMultiplePhoto" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return to the top of the page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Employee&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="EmployeeMultiplePhotoUploader.aspx">Upload Employee Photos</a></li>
        </ol>
        <div class="review-tab-pro-inner">
            <div id="myTabContent" class="tab-content custom-product-edit">
                <div class="product-tab-list tab-pane fade active in" id="MultiplePhotoUploader">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblmessage" Visible="true" runat="server"></asp:Label>
                                            <asp:Label ID="lblemployeeNo" runat="server" Text="Employee No"></asp:Label>
                                            <asp:TextBox ID="txtemployeedID" runat="server" class="form-control"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender TargetControlID="txtemployeedID" ID="FilteredTextBoxExtender2"
                                                runat="server" ValidChars="0123456789" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblempcaategorys" runat="server" Text="Employee Category"></asp:Label>
                                            <asp:DropDownList ID="ddlempcategories" runat="server" class="form-control" OnSelectedIndexChanged="ddlempcategories_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstafftypess" runat="server" Text="Staff Type"></asp:Label>
                                            <asp:DropDownList ID="ddlstfftypes" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstfftypes_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Uploaded</asp:ListItem>
                                                <asp:ListItem Value="2">Not Uploaded</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 customRow">
                                        <div class="form-group pull-right" style="margin-top: 1.8em;">
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-sm btn-info button" Text="Search" OnClick="btnsearch_Click" />
                                            <asp:Button ID="btnreset" class="btn btn-sm btn-danger button" runat="server" Text="Reset" OnClick="btnreset_Click" />
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
                                    <div class="col-md-1 customRow" style="text-align: right; margin-top: 1em;">
                                        <asp:Label ID="lbl_show" Text="Show" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-1 customRow">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddl_show" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_show_SelectedIndexChanged" class="form-control">  
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
                                     <asp:UpdatePanel ID="UPGvemployeeDetails" runat="server">
                                          <ContentTemplate>
                                   <asp:GridView ID="GvemployeeList" AllowPaging="true" AllowCustomPaging="true" EmptyDataText="No record found..." 
                                        OnRowCommand="GvemployeeDetails_RowCommand" OnSorting="GvemployeeDetails_Sorting" 
                                         CssClass="footable table-striped" AllowSorting="true"  runat="server" AutoGenerateColumns="false"
                                          Style="width: 100%">
                                        <Columns>                                          
                                         <asp:TemplateField>
                                              <HeaderTemplate>
                                                  Sl.</HeaderTemplate>
                                                      <ItemTemplate>
                                                           <%# Container.DataItemIndex+1%>
                                                      </ItemTemplate>
                                                      <ItemStyle HorizontalAlign="Left" Width="2%" />
                                           </asp:TemplateField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Employee No
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("EmployeeID")%>'></asp:Label>
                                                    <asp:Label ID="lblempno" runat="server" Text='<%# Eval("EmployeeNo")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Emp Name
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Photo Browse
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="EmpPhotoUploader" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sign. Browse
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:FileUpload ID="signaouploader" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Uploader
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnupdate" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>"
                                                                Text="Upload" class="btn btn-sm btn-info button " CommandName="Upload"  />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnupdate" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" Height="100px" Width="100px" runat="server" ImageUrl='<%# Bind("EmployeePhotoLocation") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sign.">
                                                <ItemTemplate>
                                                    <asp:Image ID="Image2" Height="100px" Width="100px" runat="server" ImageUrl='<%# Bind("DigitalSignatureLocation") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                        <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                    </asp:GridView>
                                 </ContentTemplate>
                               </asp:UpdatePanel>
                              </div>
                            </div>
                          </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
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
         $(function () {
            $('[id*=GvemployeeList]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvemployeeList]').footable();

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
         $(document).ready(function () {

            $(window).scroll(function () {
                if ($(this).scrollTop() > 50) {
                    $('#back-to-top').fadeIn();
                } else {
                    $('#back-to-top').fadeOut();
                }
            });
            // scroll body to 0px on click
            $('#back-to-top').click(function () {
                $('#back-to-top').tooltip('hide');
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });

            $('#back-to-top').tooltip('show');

        });
       
</script>

</asp:Content>
