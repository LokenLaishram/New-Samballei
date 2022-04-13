<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="TransportMonthlyFeeSetting.aspx.cs" EnableEventValidation="false" Inherits="Mobimp.Edusoft.Web.EduTransport.TransportMonthlyFeeSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <a id="back-to-top" href="#" class="btn btn-warning btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left"><span class="fa fa-chevron-up"></span></a>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Transport&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a class="active" runat="server" id="activepage" href="../EduTransport/TransportMonthlyFeeSetting.aspx">Monthly Transport Fee Master</a></li>
        </ol>

        <asp:UpdatePanel ID="upMains" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-3 customRow">
                            <div class="form-group">
                                 <asp:Label ID="lblresult" runat="server"></asp:Label>
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                <asp:Label ID="lblsession" runat="server" Text="Academic Session"></asp:Label>
                                <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                                <asp:DropDownList ID="ddlacademicsession" runat="server" class="form-control ">
                                </asp:DropDownList>
                            </div>
                        </div>
                      
                    </div>
               

                </div>
                <div class="card_wrapper">
                    <div class="row mt10">
                        <div class="col-md-12 customRow">
                            <div class="form-group">
                        <div id="ClassList" class="col-md-12 customRow ">
                            <asp:GridView ID="GvTransportMonthlyFeeSetting" OnRowDataBound="GvTransportMonthlyFeeSetting_RowDataBound"  EmptyDataText="No record found..." 
                                CssClass="footable table-striped" AllowSorting="true"  runat="server" AutoGenerateColumns="false"
                                Style="width: 100%"  GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                           ID
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                           </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Month Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblmonthID" runat="server" Visible="false" Text='<%# Eval("MonthID")%>'></asp:Label>
                                            <asp:Label ID="lblmonthly" runat="server" Text='<%# Eval("MonthName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>                                
                                  
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Activate
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                             <asp:Label ID="lblActivate" runat="server" Visible="false" Text='<%# Eval("Activate")%>'></asp:Label>
                                            <asp:CheckBox ID="chkactivate"  Enabled="true"  runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="1%" />
                                    </asp:TemplateField>

                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="<" LastPageText=">" />
                                <PagerStyle CssClass="gridpager" HorizontalAlign="left" Height="1em" Width="2%" />
                            </asp:GridView>
                             <div class="col-md-12 customRow">
                            <div class="form-group pull-right" style="margin-top: 1.8em;">
                                <asp:Button ID="btnupdate" runat="server" class="btn btn-sm btn-success button"  Text="Update" OnClick="btnupdate_Click" />
                            </div>
                        </div>
                        </div>
                        </div>
                        </div>
                      
                    </div>
               

                </div>
            </contenttemplate>
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
            $('[id*=GvMonthlyTransportFee]').footable();
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('[id*=GvMonthlyTransportFee]').footable();

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
