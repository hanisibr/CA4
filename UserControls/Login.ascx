<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="CA4_10385012.Login" %>

<div id="login">
    <figure>
        <asp:Label ID="lblUserID" AssociatedControlID="txtUserID"
            runat="server" Text="UserID:"></asp:Label>

        <asp:TextBox ID="txtUserID" runat="server" CssClass="txtbox"></asp:TextBox>
    </figure>
    <figure>
        <asp:Label ID="lblPassword" AssociatedControlID="txtPassword"
            runat="server" Text="Password:"></asp:Label>

        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"
            CssClass="txtbox"></asp:TextBox>
    </figure>
    <figure>
        <asp:Button ID="btnLogIn" runat="server" Text="Log In"
            OnClick="btnLogIn_Click" ValidationGroup="Login" CssClass="btnlogin" />
    </figure>

</div>
