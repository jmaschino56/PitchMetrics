<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PitchMetrics.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron"></div>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Your email is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="firstNametxt">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="firstNametxt" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNametxt"
                    CssClass="text-danger" ErrorMessage="Your first name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="lastNametxt">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="lastNametxt" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="lastNametxt"
                    CssClass="text-danger" ErrorMessage="Your last name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="handDDL">Throwing Hand</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="handDDL" CssClass="form-control">
                    <asp:ListItem Text="Right" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Left" Value="2"></asp:ListItem>
                </asp:DropDownList>
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PitchMetricsConnectionString %>"
        InsertCommand="INSERT INTO [Players] ([FirstName], [LastName], [Email], [ThrowingHand]) VALUES (@FirstName, @LastName, @Email, @ThrowingHand)" ConflictDetection="CompareAllValues"
        OldValuesParameterFormatString="original_{0}">
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="ThrowingHand" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

