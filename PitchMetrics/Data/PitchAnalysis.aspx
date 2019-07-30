<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PitchAnalysis.aspx.cs" Inherits="PitchMetrics.PitchAnalysis" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="form-group">
        <div class="row">
            <div class="col-xs-offset-2 col-xs-2">
                <label for="FileUpload1">Upload Data:</label>
            </div>
            <div class="col-xs-offset-1 col-xs-4">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div class="col-xs-3">
                <asp:Button ID="btnImport" CssClass="btn btn-primary" runat="server" Text="Import CSV File" OnClick="ImportCSV" />
            </div>
            <div class="col-xs-12">
                <div class="col-xs-offset-5">
                        <asp:Label runat="server" ID="errorMessagelbl" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-offset-1 col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-6"><label for="firstNameTxt">First Name:</label></div>
                    <div class="col-xs-6"><asp:Label runat="server" ID="firstNamelbl" Font-Bold="false"></asp:Label></div>
                </div>
            </div>
            <div class="col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-6"><label for="lastNameTxt">Last Name:</label></div>
                    <div class="col-xs-6"><asp:Label runat="server" ID="lastNamelbl" Font-Bold="false"></asp:Label></div>
                </div>
            </div>
            <div class="col-xs-4">
                <div class="col-xs-12">
                    <div class="col-xs-4">
                        <label for="pitchTypeDDL">Pitch Type:</label></div>
                    <div class="col-xs-8">
                        <asp:DropDownList runat="server" ID="pitchTypeDDL" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="PitchType" DataValueField="PitchTypeID"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PitchMetricsConnectionString %>" SelectCommand="SELECT * FROM [PitchTypes] ORDER BY [PitchTypeID]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-offset-3 col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-5">
                        <label for="vBreaklbl">Velocity:</label>
                    </div>
                    <div class="col-xs-7">
                        <strong>
                            <asp:Label runat="server" ID="velocitylbl"></asp:Label></strong>
                    </div>
                </div>
            </div>
            <div class="col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-5">
                        <label for="vBreaklbl">Spin Rate:</label>
                    </div>
                    <div class="col-xs-7">
                        <strong>
                            <asp:Label runat="server" ID="spinRatelbl"></asp:Label></strong>
                    </div>
                </div>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-offset-1 col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-8">
                        <label for="hBreaklbl">Horizontal Break:</label></div>
                    <div class="col-xs-4"><strong>
                        <asp:Label runat="server" ID="hBreaklbl"></asp:Label></strong></div>
                </div>
            </div>
            <div class="col-xs-3">
                <div class="col-xs-12">
                    <div class="col-xs-8"><label for="vBreaklbl">Vertical Break:</label></div>
                    <div class="col-xs-4"><strong><asp:Label runat="server" ID="vBreaklbl"></asp:Label></strong></div>
                </div>
            </div>
            <div class="col-xs-4">
                <div class="col-xs-12">
                    <div class="col-xs-6"><label for="auclbl">Area Under Curve:</label></div>
                    <div class="col-xs-6"><strong><asp:Label runat="server" ID="auclbl"></asp:Label></strong></div>
                </div>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Chart ID="Chart1" runat="server" BorderlineDashStyle="Solid" BorderlineWidth="0" Width="850">
                    <Series>
                        <asp:Series Name ="Series1" ChartType="Area" ChartArea="ChartArea1" Color="Yellow"></asp:Series>
                        <asp:Series Name ="Series2" ChartType="Area" ChartArea="ChartArea1" Color="Yellow"></asp:Series>
                        <asp:Series Name="Series3" ChartType="Area" ChartArea="ChartArea1" Color="LightGreen"></asp:Series>
                        <asp:Series Name="Series4" ChartType="Area" ChartArea="ChartArea1" Color="LightGreen"></asp:Series>
                        <asp:Series Name="Series5" ChartType="Line" ChartArea="ChartArea1" Color="#000044" BorderWidth="12"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX LineWidth="0" Interval="2"></AxisX>
                            <AxisY LineWidth="0" Maximum="5" Minimum="-5"></AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Text="Top View" Font="Microsoft Sans Serif, 14pt"></asp:Title>
                    </Titles>
                </asp:Chart>
            </div>
            <div class="col-xs-12" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Chart ID="Chart2" runat="server" BorderlineDashStyle="Solid" BorderlineWidth="0" Width="850">
                    <Series>
                        <asp:Series Name ="Series1" ChartType="Area" ChartArea="ChartArea2" Color="Yellow"></asp:Series>
                        <asp:Series Name ="Series2" ChartType="Area" ChartArea="ChartArea2" Color="LightGreen"></asp:Series>
                        <asp:Series Name="Series3" ChartType="Area" ChartArea="ChartArea2" Color="Yellow"></asp:Series>
                        <asp:Series Name="Series4" ChartType="Area" ChartArea="ChartArea2" Color="White"></asp:Series>
                        <asp:Series Name="Series5" ChartType="Line" ChartArea="ChartArea2" Color="#000044" BorderWidth="12"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2">
                            <AxisX LineWidth="0" Minimum="Auto" Interval="3"></AxisX>
                            <AxisY LineWidth="0" Maximum="8"></AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Text="Side View" Font="Microsoft Sans Serif, 14pt"></asp:Title>
                    </Titles>
                </asp:Chart>
            </div>
            <div class="col-xs-12"><br /></div>
            <div class="col-xs-4">
                <div class="col-xs-12">
                    <div class="col-xs-5">
                        <label for="dateTxt">Bullpen Date:</label>
                    </div>
                    <div class="col-xs-7">
                        <asp:TextBox runat="server" ID="dateTxt" TextMode="Date" CssClass="form-control"  OnPreRender="dateTxt_PreRender"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-xs-4">
                <div class="col-xs-12">
                    <div class="col-xs-5">
                        <label for="pitchNoTxt">Pitch Number:</label></div>
                    <div class="col-xs-7">
                        <asp:TextBox runat="server" ID="pitchNoTxt" CssClass="form-control" OnPreRender="pitchNoTxt_PreRender"></asp:TextBox></div>
                </div>
            </div>
            <div class="col-xs-4" style="margin-left: auto; margin-right: auto; text-align: center;">
                    <div class="col-xs-12">
                        <asp:Button runat="server" ID="saveBTN" CssClass="btn btn-primary form-control" Text="Save Pitch Data" OnClick="saveBTN_Click" /></div>
            </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PitchMetricsConnectionString %>"
                InsertCommand="INSERT INTO [Bullpen] ([Date], [FirstName], [LastName], [PitchNo], [PitchType], [Velocity], [SpinRate], [HorizontalBreak], [VerticalBreak], [AUC]) VALUES (@Date, @FirstName, @LastName, @PitchNo, @PitchType, @Velocity, @SpinRate, @HorizontalBreak, @VerticalBreak, @AUC)">
                <InsertParameters>
                    <asp:Parameter Name="Date" Type="DateTime" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="PitchNo" Type="String" />
                    <asp:Parameter Name="PitchType" Type="String" />
                    <asp:Parameter Name="Velocity" Type="String" />
                    <asp:Parameter Name="SpinRate" Type="String" />
                    <asp:Parameter Name="HorizontalBreak" Type="String" />
                    <asp:Parameter Name="VerticalBreak" Type="String" />
                    <asp:Parameter Name="AUC" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
