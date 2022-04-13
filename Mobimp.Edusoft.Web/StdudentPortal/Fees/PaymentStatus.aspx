<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true" CodeBehind="PaymentStatus.aspx.cs" Inherits="Mobimp.Campusoft.Web.StdudentPortal.Fees.PaymentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">

    <div class="review-tab-pro-inner card_wrapper">
        <div class="row customRow">
            <div class="col-md-2 feeSuccessPrint">
                <div class="form-group" style="text-align: center; color: green">
                    <asp:LinkButton ID="btn_print" OnClick="btn_print_Click" runat="server"><i class="fa fa-print fa-3x" aria-hidden="true"></i></asp:LinkButton>
                </div>
            </div>


        </div>
        <div class="row" style="height: 40vh">
            <div class="col-md-12 customRow">
                <div class="form-group" style="text-align: center; font: bold; font-size: x-large; color: green">
                    <asp:Label ID="lbl_feestatus" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row" style="height: 40vh">
            <div class="col-md-12 customRow">
                <div class="form-group" style="text-align: center; font: bold; font-size: x-large; color: red">
                    <asp:Label ID="lbl_error" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
