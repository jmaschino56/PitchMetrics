<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PitchMetrics._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron"></div>
    <div class="row">
        <div class="col-xs-12">
            <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                <h1><strong>Built For Pitchers by a Pitcher</strong></h1>
            </div>
            <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Image runat="server" ID="pitcherImg" ImageUrl="Images/Pitcher.png"/>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-offset-1 col-xs-10">
                    PitchMetrics was designed by former NJCAA and NCAA Division II Pitcher, Jeremy Maschino. They goal of PitchMetrics is to bring an affordable pitching
                    analytic application after seeing small budget baseball programs struggle to provide their athletes with the same tools that big budget programs can afford.
                    PitchMetrics brings you closer to achieving your goals, on the mound.
            </div>
        </div>
        <div class="col-xs-12">
            <br />
        </div>
        <div class="col-xs-12">
            <div class="col-xs-6">
                <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                    <h1><strong>Powered by the TI AWR1642 Sensor</strong></h1>
                </div>
                <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                    <asp:Image runat="server" ID="radarImg" ImageUrl="Images/AWR.png" />
                </div>
                <div class="col-xs-offset-1 col-xs-10">
                </div>
            </div>
            <div class="col-xs-6">
                <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                    <h1><strong>Using Advanced Analytics</strong></h1>
                </div>
                <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                    <asp:Image runat="server" ID="chartImg" ImageUrl="Images/Capture.PNG" />
                </div>
                <div class="col-xs-12"><br /></div>
                <div class="col-xs-offset-1 col-xs-10">
                    PitchMetrics takes advantage of a number of different advanced analytical options. The first being tunneling. PitchMetrics shows how long your
                pitch stays in or out of the strike zone. Secondly, we provide true break, the amount the baseball moves from leaving your hand, to the catcher.
                Third, PitchMetrics provides a regression based spin rate, derived from Major League Baseball pitchers such as Clayton Kershaw, Max Scherzer, 
                Justin Verlander, and hundreds of MLB pitchers.
                </div>
            </div>
        </div>
    </div>

</asp:Content>
