<%@ Page Title="" Language="C#" MasterPageFile="~/Campusoft.Master" AutoEventWireup="true"
    CodeBehind="Examwise.aspx.cs" Inherits="Mobimp.Campusoft.Web.EduStudent.Examwise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CampusoftPlaceholder" runat="server">
    <script src="../Scripts/Chart.bundle.min.js"></script>
    <script src="../Scripts/utils.js"></script>
    <style>
        canvas {
            -moz-user-select: none;
            -webkit-user-select: none;
            -ms-user-select: none;
        }
    </style>
    <div class="container-fluid" id="page_wrapper">
        <ol class="breadcrumb">
            <li><a href="../HomeDashboard.aspx">Dashboard&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li>Analysis&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></li>
            <li><a runat="server" href="../EduAnalytics/PerformanceTrackerChart.aspx">Class wise  &nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a class="active" id="activepage" runat="server" href="../EduAnalytics/Examwise.aspx">Exam wise&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduAnalytics/Subjectwise.aspx">Subject wise&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduAnalytics/Studentwise.aspx">Student wise&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
            <li><a runat="server" href="../EduAnalytics/StudentSubjectwise.aspx">Student Subjectwise&nbsp;&nbsp;<i class="fa fa-chevron-right" style="font-size: xx-small;" aria-hidden="true"></i></a></li>
        </ol>

        <div class="card_wrapper">
            <div class="row">
                <div class="col-md-3 customRow">
                    <div class="form-group">
                        <asp:Label ID="lblacademicsession" runat="server" Text="Academic year"></asp:Label>
                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                        <asp:DropDownList ID="ddlacademicseesions" runat="server" class="form-control ">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3 customRow">
                    <div class="form-group">
                        <asp:Label ID="lblclasses" runat="server" Text="Class"></asp:Label>
                        <span class="mandatory_field">*</span><span style="color: #ff0000"></span>
                        <asp:DropDownList ID="ddlclasses" runat="server" AutoPostBack="true" class="form-control " OnSelectedIndexChanged="ddlclasses_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3 customRow">
                    <div class="form-group">
                        <asp:Label ID="lblsections" runat="server" Text="Section"></asp:Label>
                        <asp:DropDownList ID="ddlsections" runat="server" class="form-control ">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3 customRow">
                    <div class="form-group">
                        <asp:Label ID="lbl_graphtype" runat="server" Text="Graph Type"></asp:Label>
                        <select onchange="changeGraphType()" id="ddl_graph_type" class="form-control input-sm">
                            <option value="line">Line Chart</option>
                            <option value="bar">Bar Chart</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 customRow">
                    <div class="form-group pull-right" style="margin-top: 1.8em;">
                        <asp:Button ID="btnsearch" runat="server" OnClientClick="return Validate();" class="btn btn-sm btn-info button " Text="Search" OnClick="btnsearch_Click" />
                        <asp:Button ID="btncancel" class="btn btn-sm btn-danger button" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card_wrapper">
        <div class="row">
            <div class="col-sm-8 offset-md-2">
                <asp:Literal ID="ArrayLiterals" runat="server"></asp:Literal>
                <canvas style="height: 45vh; width: 90%" id="canvas"></canvas>
            </div>
        </div>
    </div>
    <script>
        var config = {
            type: 'line',
            data: {

                datasets: [{
                    label: "Pass Percentage",
                    backgroundColor: '#5458d2',
                    borderColor: '#5458d2',
                    data: [
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor(),
                        randomScalingFactor()
                    ],
                    fill: false,
                },]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    text: ''
                },

                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'ExamName'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'PassPC ( % )'
                        }
                    }]
                }
            }
        };
        function drawgrap() {
            var i = 0;
            var value = 0;
            config.data.datasets.forEach(function (dataset) {
                dataset.data = dataset.data.map(function () {
                    value = QtyArray[i];
                    i++;

                    return value;
                });

            });
            config.data.labels = ItemArray;
            config.type = document.getElementById('ddl_graph_type').value;
            config.options.title.text = "Class wise exam performance"
            var ctx = document.getElementById("canvas").getContext("2d");
            window.myLine = new Chart(ctx, config);

            return false;
        }
        function changeGraphType() {
            var i = 0;
            var value = 0;
            config.data.datasets.forEach(function (dataset) {
                dataset.data = dataset.data.map(function () {
                    value = QtyArray[i];
                    i++;

                    return value;
                });

            });
            config.data.labels = ItemArray;

            config.type = document.getElementById('ddl_graph_type').value;
            config.options.title.text = "Class wise exam performance"
            var ctx = document.getElementById("canvas").getContext("2d");
            window.myLine = new Chart(ctx, config);
        }
        function Validate() {
            var str = "";
            var i = 0;
            if (document.getElementById("<%=ddlacademicseesions.ClientID %>").selectedIndex == "0") {
                str = str + "\n Please select academic session.";
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
    </script>
</asp:Content>
