<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="HomeDashboard.aspx.cs" Inherits="Mobimp.Campusoft.Web.HomeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <script type="text/javascript">
        //On Page Load
        $(function () {
            $("#page_wrapper").accordion();

        });
        //On UpdatePanel Refresh
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $("#page_wrapper").accordion();

                }
            });
        };
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container-fluid" id="page_wrapper">
                   <div class="row">
                    <div class="col-md-12" style="padding: 0px 24px;
    margin: 5px 0px;">
                 <ol class="breadcrumb" style="background-color:#2a2c5c;">
            <li><a class="active" style="color:#ffffff;" href="#">Dashboard</a></li>
           
        </ol>
                          </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                      
                        <asp:Label ID="message" runat="server"></asp:Label>
                        <asp:Literal ID="ModuleDasboard" runat="server">  </asp:Literal>
                    </div>
                </div>

               

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
