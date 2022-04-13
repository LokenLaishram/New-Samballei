<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Examresult.aspx.cs" Inherits="Mobimp.Campusoft.Web.StdudentPortal.Examination.Examresult" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ul id="myTab3" class="tab-review-design">
            <li class="active"><a href="#tapfeecollection"><i class="icon nalika-edit" aria-hidden="true"></i>Exam Result</a></li>
        </ul>
        <div class="review-tab-pro-inner">
            <div class="product-tab-list tab-pane fade active in" id="tapfeecollection" style="margin-top: -28px;">
                <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div runat="server" id="divpayment">
                            <div class="card_wrapper">
                                <div class="row">
                                    <div class="col-md-3 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblsession" runat="server" Text="Year"></asp:Label>
                                            <asp:DropDownList ID="ddlacademicsession" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicsession_SelectedIndexChanged" class="form-control "
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6 customRow">
                                        <div class="form-group">
                                            <asp:Label ID="lblstudentdetail" runat="server" Text="Student Details"></asp:Label>
                                            <asp:Label runat="server" class="form-control"
                                                ID="txtstddetail"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="card_wrapper col-md-12 customRow">
                                <div style="min-height: 60px; width: 100%; padding: 5px 0px 10px 0px;">
                                    <asp:UpdateProgress ID="updateProgress6" runat="server">
                                        <ProgressTemplate>
                                            <div id="DIVloading6" runat="server" class="Pageloader ">
                                                <asp:Image ID="imgUpdateProgress" ImageUrl="~/app-assets/images/loader.gif" runat="server"
                                                    AlternateText="Loading ..." ToolTip="Loading ..." />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:GridView ID="Gv_result" CssClass="footable table-striped" runat="server" OnRowDataBound="Gv_result_RowDataBound" OnRowCommand="Gv_result_RowCommand" EmptyDataText="No record found..."
                                        AutoGenerateColumns="False" Width="100%" class="grid" AllowPaging="false"
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
                                                    <asp:Label ID="lbl_studentID" Visible="false" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                                                    <asp:Label ID="lbl_examid" Visible="false" runat="server" Text='<%# Eval("ExamID") %>'></asp:Label>
                                                    <asp:Label ID="lbl_classid" Visible="false" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label>
                                                    <asp:Label ID="lbl_sec" Visible="false" runat="server" Text='<%# Eval("SectionID") %>'></asp:Label>
                                                    <asp:Label ID="lbl_roll" Visible="false" runat="server" Text='<%# Eval("RollNo") %>'></asp:Label>
                                                    <asp:Label ID="lbl_duestatus" Visible="false" runat="server" Text='<%# Eval("DueStatus") %>'></asp:Label>
                                                    <asp:Label ID="lbl_excludestatus" Visible="false" runat="server" Text='<%# Eval("Excludedefaulter") %>'></asp:Label>
                                                    <asp:Label ID="lbl_examname" runat="server" Text='<%# Eval("ExamName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Status
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_status" Visible="false" runat="server" Text='<%# Eval("Ispublished")%>'></asp:Label>
                                                    <asp:Label ID="lbl_result" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="1%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderTemplate>
                                                    Declared On
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_declaredon" Text='<%# Eval("PublishDate")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Result
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_print" class="cus-btn btn-sm btn-indigo" CommandArgument="<%# ((GridViewRow) Container).RowIndex  %>" Text="Print" runat="server"
                                                        CommandName="Print" ValidationGroup="none" />
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
        </div>
    </div>

    <script type="text/javascript">
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
