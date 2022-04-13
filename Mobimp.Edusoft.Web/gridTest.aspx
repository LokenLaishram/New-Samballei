<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridTest.aspx.cs" Inherits="Mobimp.Campusoft.Web.gridTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid" id="page_wrapper">
        <asp:GridView ID="GridView1" CssClass="footable" runat="server" AutoGenerateColumns="false"
            Style="max-width: 500px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Customer Id" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
                <asp:BoundField DataField="Id" HeaderText="Customer Id" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
                 <asp:BoundField DataField="Id" HeaderText="Customer Id" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
            </Columns>
        </asp:GridView>
       <link href="app-assets/FooTable/css/footable.min.css" rel="stylesheet" />
    <script src="app-assets/FooTable/js/jquery1.8.3.min.js"></script>
    <script src="app-assets/FooTable/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=GridView1]').footable();
        });
    </script>

    </form>
</body>
</html>
