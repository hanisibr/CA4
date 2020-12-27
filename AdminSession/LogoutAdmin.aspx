<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MAdmin.Master" AutoEventWireup="true" CodeBehind="LogoutAdmin.aspx.cs" Inherits="CA4_10385012.LogoutAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Are you sure you want to log out?</h2>
        <figure>
            <asp:Button ID="btnlogout" runat="server" Text="Yes" CssClass="btnadd" OnClick="btnlogout_Click" />
            <asp:Button ID="btnback" runat="server" Text="No" CssClass="btnadd" OnClick="btnback_Click" />
        </figure>
</asp:Content>
