<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PitchRecap.aspx.cs" Inherits="PitchMetrics.PitchRecap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class = "col-xs-12"><br /></div>
        <div class="form-group">
            <div class="col-xs-12 table-responsive">
                <asp:GridView ID="gvPitches" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-bordered-table-condensed table-striped"
                    OnPreRender="gvPitches_PreRender" DataSourceID="SqlDataSource1" AllowSorting="True">
                    <RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}">
                            <ItemStyle CssClass="col-xs-1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PitchNo" HeaderText="Pitch Number" SortExpression="PitchNo">
                            <ItemStyle CssClass="col-xs-1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PitchType" HeaderText="Pitch Type" SortExpression="PitchType">
                            <ItemStyle CssClass="col-xs-2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Velocity" HeaderText="Velocity" SortExpression="Velocity">
                            <ItemStyle CssClass="col-xs-1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpinRate" HeaderText="Spin Rate" SortExpression="SpinRate">
                            <ItemStyle CssClass="col-xs-1" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HorizontalBreak" HeaderText="Horizontal Break" SortExpression="HorizontalBreak">
                            <ItemStyle CssClass="col-xs-2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VerticalBreak" HeaderText="Vertical Break" SortExpression="VerticalBreak">
                            <ItemStyle CssClass="col-xs-2" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AUC" HeaderText="Area under Curve" SortExpression="AUC">
                            <ItemStyle CssClass="col-xs-2" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#000044" ForeColor="White" HorizontalAlign="Center" />
                    <AlternatingRowStyle CssClass="altRow" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PitchMetricsConnectionString %>" SelectCommand="SELECT [Date], [PitchNo], [PitchType], [Velocity], [SpinRate], [HorizontalBreak], [VerticalBreak], [AUC] FROM [Bullpen] WHERE (([FirstName] = @FirstName) AND ([LastName] = @LastName)) ORDER BY [Date] DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="FirstName" SessionField="FirstName" Type="String" />
                        <asp:SessionParameter Name="LastName" SessionField="LastName" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            
        </div>
    </div>
    
</asp:Content>
