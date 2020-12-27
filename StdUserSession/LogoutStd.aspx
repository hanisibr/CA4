<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MLoggedIn.Master" AutoEventWireup="true" CodeBehind="LogoutStd.aspx.cs" Inherits="CA4_10385012.LogoutStd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Are you sure you want to log out?</h2>
    <div class="Logout">
    <figure>
       <asp:Button ID="btnlogout" runat="server" Text="Yes" CssClass="btnaddcart" OnClick="btnlogout_Click" />
    </figure>
    <figure>
        <asp:Button ID="btnback" runat="server" Text="No" CssClass="btnaddcart" OnClick="btnback_Click" />
    </figure>
     </div>
</asp:Content>
