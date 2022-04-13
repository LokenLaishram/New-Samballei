<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkOrderPreview.aspx.cs" Inherits="Mobimp.Edusoft.Web.EduInventory.WorkOrderPreview" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @page {
            size: 7in 9.25in;
            margin: 27mm 16mm 27mm 16mm;
        }
    </style>
    <link href="../app-assets/css/bootstrap.css" rel="stylesheet" />
    <link href="../app-assets/css/font-awesome.css" rel="stylesheet" />
    <link href="PrintCSS/htmlprint.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <!-- Main content -->
            <section class="invoice">
                <!-- title row -->
                <div class="row">
                    <div class="col-xs-12">
                        <h2 class="page-header" style="text-align: center;">BOARD OF SECONDARY EDUCATION,<br />
                            MANIPUR                     
                        </h2>
                    </div>
                    <!-- /.col -->
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <b>
                            <asp:Label ID="lblOrderNo" runat="server" Text="No. 1/6/05-BSEM(TB)(Pt-IV)"></asp:Label>
                        </b>
                        <br />
                        <br />
                    </div>
                    <div class="col-xs-5">
                        <span class="pull-right"><b>Order Date:</b>
                            <asp:Label ID="lblOrderDate" runat="server" Text="02/03/2021"></asp:Label></span>
                    </div>
                    <div class="col-xs-1"></div>
                </div>

                <!-- info row -->
                <div class="row invoice-info">
                    <div class="col-sm-4 invoice-col">
                        To
                    <address>
                        <strong>Manager</strong><br />
                        <asp:Label ID="lblVendorName" runat="server" Text="Bir Computer Press, Imphal"></asp:Label>
                        <br />
                    </address>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-4 invoice-col"></div>
                    <!-- /.col -->
                    <div class="col-sm-4 invoice-col">
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-xs-12">
                        <b>Subject:</b>
                        <asp:Label ID="lblSubject" runat="server" Text="Printing of Text-Book"></asp:Label>
                        <br />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12" style="text-align: justify;">
                        <asp:Label ID="lblTemplateHeader" runat="server"></asp:Label><br />
                    </div>
                </div>
                <!-- Table row -->
                <div class="row">
                    <div class="col-xs-12 table-responsive" style="text-align: center; border: 1px solid #8a7373;">
                        <div class="row" style="background-color: #d9dfe6; border: 1px solid #8a7373;">
                            <div class="col-sm-1">Sl.No.</div>
                            <div class="col-sm-4">Book Name</div>
                            <div class="col-sm-1">Size</div>
                            <div class="col-sm-2">Pages</div>
                            <div class="col-sm-2">Copies</div>
                            <div class="col-sm-2">Paper </div>
                        </div>
                        <asp:Literal ID="LtrWorkOrderTable" runat="server"></asp:Literal>
                    </div>
                </div>
                <!-- /.row -->
                <div class="row">
                    <br />
                    <div class="col-xs-12">
                        <asp:Label ID="lblTemplateFooter" runat="server" Text=""></asp:Label><br />
                    </div>
                </div>
                <!-- /.row -->
            </section>
            <!-- /.content -->
        </div>
        <!-- ./wrapper -->

    </form>
</body>
</html>
