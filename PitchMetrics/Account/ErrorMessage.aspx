<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorMessage.aspx.cs" Inherits="PitchMetrics.ErrorMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-danger">An unrecoverable error has occurred</h1>
    <div class="alert alert-danger">
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label></p>
    </div>
    <asp:Button ID="btnReturn" runat="server" Text="Return to Safety"
        PostBackUrl="PitchAnaylsis" CssClass="btn btn-danger" />
</asp:Content>
