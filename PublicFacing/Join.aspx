<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MPublicFace.Master" AutoEventWireup="true" CodeBehind="Join.aspx.cs" Inherits="CA4_10385012.Join" %>
<%@ Register TagPrefix="uc1" TagName="Reg" Src="~/UserControls/Register.ascx" %>
<%@ Register TagPrefix="uc2" TagName="LogIn" Src="~/UserControls/Login.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register</h2>
        <figure>
            <uc1:Reg ID="Register" runat="server" />
        </figure>
    <h2>Log In</h2>
        <figure>
            <uc2:LogIn ID="Login" runat="server" />
        </figure>
</asp:Content>
