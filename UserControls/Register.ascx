<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="CA4_10385012.Register" %>

<div id="reg">
    <figure>
        <asp:Label ID="lblUserID" AssociatedControlID="txtUserID"
            runat="server" Text="UserID:"></asp:Label>

        <asp:TextBox ID="txtUserID" runat="server" CssClass="txtbox"></asp:TextBox>
        
    </figure>
    <figure>
        <asp:Label ID="lblPassword" AssociatedControlID="txtPassword"
            runat="server" Text="Password:" ></asp:Label>

        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="txtbox"></asp:TextBox>
           
    </figure>
    <figure>
        <asp:Button ID="btnReg" runat="server" Text="Register"
            OnClick="btnReg_Click" ValidationGroup="Register"
            CssClass="btnreg"/>
    </figure>
    <figure>
        <asp:Label ID="lblRegDone" runat="server" Text=" " Font-Names="'Jua', sans-serif"></asp:Label>
    </figure>
</div>