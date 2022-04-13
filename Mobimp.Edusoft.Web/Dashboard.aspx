<%@ Page Title="" Language="C#" MasterPageFile="~/CMS.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="Mobimp.Campusoft.Web.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
         $.ajax({
         type: "POST",
         contentType: "application/json",
        | data: "{}",
         url: "Dashboard.aspx/GetEvents",
         dataType: "json",
         success: function (data) {
         $('div[id*=fullcal]').fullCalendar({
         header: {
         left: 'prev,next today',
         center: 'title',
         right: 'month,agendaWeek,agendaDay'
         },
         editable: true,
         events: $.map(data.d, function (item, i) 
         {
         var event = new Object();
         event.id = item.EventID;
         event.start = new Date(item.StartDate);
         event.end = new Date(item.EndDate);
         event.title = item.EventName;
         event.url = item.Url;
         event.ImageType = item.ImageType;
         return event;
         }), 
         eventRender: function (event, eventElement) 
         {
         if (event.ImageType) 
         {
         if (eventElement.find('span.fc-event-time').length) 
         {
         eventElement.find('span.fc-event-time').before($(GetImage(event.ImageType)));
         } 
         else {
         eventElement.find('span.fc-event-title').before($(GetImage(event.ImageType)));
         }
         }
         },
        
         error: function (XMLHttpRequest, textStatus, errorThrown) 
         {debugger;
         }
         });
         $('#loading').hide();
         $('div[id*=fullcal]').show();
         });
         function GetImage(type) 
         {
         if (type == 0) {
         return "<br/><img src = 'Styles/Images/attendance.png' style='width:24px;height:24px'/><br/>"
         }
         else if (type == 1) {
         return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
         }
         else
         return "<br/><img src = 'Styles/Images/not_available.png' style='width:24px;height:24px'/><br/>"
         }
    </script>
    <link href="Styles/custom.css" rel="stylesheet" type="text/css" />
   
    <div class="css3gradient" style="text-align: left; font-size: 15px; font-family: Arial CE;
        color: Blue; height: 3px">
    </div>
   <%-- <div class="col-md-3">
        <div class="panel div-shadow"> 
            <div class="panel-body">
            <div id="loading">
        <img src="Styles/images/loading_wh.gif" />
    </div>
             <div id="fullcal">
    </div>
          </div>
        </div>
    </div>--%>
    <div class="col-md-3">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Chart ID="StudentChart" runat="server" BorderlineWidth="0" Height="250px" Palette="None"
                        PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                        <Titles>
                            <asp:Title ShadowOffset="10" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Chart ID="StudentAttendnaceChart" runat="server" BorderlineWidth="0" Height="250px"
                        Palette="None" PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                        <Titles>
                            <asp:Title ShadowOffset="10" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Chart ID="EmployeeChart" runat="server" BorderlineWidth="0" Height="250px" Palette="None"
                        PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                        <Titles>
                            <asp:Title ShadowOffset="10" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
        </div>
    </div>
    
    <div class="col-md-3">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Chart ID="EmployeeAttendanceChart" runat="server" BorderlineWidth="0" Height="250px"
                        Palette="None" PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                        <Titles>
                            <asp:Title ShadowOffset="10" Name="Items" />
                        </Titles>
                        <Series>
                            <asp:Series Name="" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
        </div>
    </div>
    <div class="col-md-3" style="vertical-align: middle">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <asp:Chart ID="ExamChart" runat="server" BorderlineWidth="0" Height="250px" Palette="None"
                    PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                    <Titles>
                        <asp:Title ShadowOffset="10" Name="Items" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"  BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>
    <div class="col-md-6" style="vertical-align: bottom">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Calendar ID="Calendar1" BorderColor="BurlyWood" SelectedDayStyle-ForeColor="Blue"
                        TitleStyle-Font-Size="20px" TitleStyle-BackColor="SeaGreen" TitleStyle-ForeColor="#ffffff" Font-Bold="true"
                        Width="500px" runat="server" OnDayRender="Calendar1_DayRender">
                        <DayHeaderStyle BackColor="#9fdfbf"/>
                        <DayStyle BackColor="#D1FFEB" BorderColor="Green" BorderWidth="1" Font-Bold="true" Font-Italic="true" Font-Size="Medium"/>
                       <%-- <DayStyle BorderWidth="1" BorderColor="Chocolate" BorderStyle="Ridge"></DayStyle>--%>
                        <%-- <SelectedDayStyle BackColor="DarkGreen" BorderColor="ForestGreen"/>--%>
                    </asp:Calendar>
                </p>
            </div>
        </div>
    </div>
    <div class="col-md-3" style="vertical-align: middle">
        <div class="panel div-shadow"> 
            <div class="panel-body">
                <p>
                    <asp:Chart ID="FeeChart" runat="server" BorderlineWidth="0" Height="250px" Palette="None"
                        PaletteCustomColors="Maroon" Width="250px" BorderlineColor="64, 0, 64">
                        <Titles>
                            <asp:Title ShadowOffset="10" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
