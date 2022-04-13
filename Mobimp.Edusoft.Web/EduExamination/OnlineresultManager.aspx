<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="OnlineresultManager.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduExamination.OnlineresultManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ul id="myTab3" class="tab-review-design">
            <li class="active"><a href="#tapfeecollection"><i class="icon nalika-edit" aria-hidden="true"></i>Manage Online Exam Result</a></li>
        </ul>
        <div class="review-tab-pro-inner">
            <div class="product-tab-list tab-pane fade active in" id="tapfeecollection" style="margin-top: -28px;">
                <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card_wrapper">
                            <div class="row">
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lblsession" runat="server" Text="Session"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged" class="form-control "
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3 customRow">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_class" runat="server" Text="Class"></asp:Label>
                                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                        <asp:DropDownList ID="ddl_class" class="form-control " AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card_wrapper col-md-12 customRow">
                            <div class="col-md-8 customRow">
                                <asp:UpdateProgress ID="updateProgress6" runat="server">
                                    <ProgressTemplate>
                                        <div id="DIVloading6" runat="server" class="Pageloader ">
                                            <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                AlternateText="Loading ..." ToolTip="Loading ..." />
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:GridView ID="Gv_examlist" CssClass="footable table-striped" runat="server" EmptyDataText="No record found..."
                                    AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false" OnRowDataBound="Gv_resultlist_RowDataBound"
                                    HorizontalAlign="Center" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                SL No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Exam
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                <asp:Label ID="lbl_examID" Visible="false" runat="server" Text='<%# Eval("ExamID") %>'></asp:Label>
                                                <asp:Label ID="lbl_classid" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                                <asp:Label ID="lbl_exam" runat="server" Text='<%# Eval("ExamName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Exclude Fee Defaulters
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_exclude_status" Visible="false" runat="server" Text='<%# Eval("Excludedefaulter") %>'></asp:Label>
                                                <asp:CheckBox ID="chk_dafulter" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Publish
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_publish_status" Visible="false" runat="server" Text='<%# Eval("Ispublished") %>'></asp:Label>
                                                <asp:CheckBox ID="chk_publish" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Published On
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_publishedon" runat="server" Text='<%# Eval("PublishDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="1%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Published By
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_publishedby" runat="server" Text='<%# Eval("AddedBy") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="2%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                    <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                                </asp:GridView>
                            </div>
                            <div class="col-md-4 customRow">
                                <div class="col-md-8 customRow">
                                    <div class="form-group">
                                        <div class="form-group pull-right" style="margin-top: 0.3em;">
                                            <asp:Button ID="btn_update" Visible="false" runat="server" UseSubmitBehavior="False" OnClientClick="this.disabled='true';this.value='Saving..'" class="btn btn-sm btn-indigo button" OnClick="btn_update_Click" Text="Save" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ItemChildGridview(input) {
            var displayIcon = "img" + input;
            if ($("#" + displayIcon).attr("src") == "../EduImages/plus.gif") {
                $("#" + displayIcon).closest("tr")
                    .after("<tr><td></td><td colspan = '100%'>" + $("#" + input)
                        .html() + "</td></tr>");
                $("#" + displayIcon).attr("src", "../EduImages/minus.gif");
            } else {
                $("#" + displayIcon).closest("tr").next().remove();
                $("#" + displayIcon).attr("src", "../EduImages/plus.gif");
            }
        }
    </script>
    <script type="text/javascript">

        $(function () {

            $('[id*=Gv_examlist]').footable();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=Gv_examlist]').footable();

            $('.searchs').on('keyup', function () {
                var searchTerm = $(this).val().toLowerCase();
                $('#Studentlist table tbody tr').each(function () {
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
