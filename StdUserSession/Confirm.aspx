<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MLoggedIn.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="CA4_10385012.StdUserSession.Confirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Are you sure you want to discard this product?</h2>
    <asp:Repeater ID="SetToDelete" runat="server">
        <ItemTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                    <td><%# Eval("ProdID") %></td>
                    <td><%# Eval("ProdPrice") %></td>
                    <td><asp:Button ID="btnDelConf" runat="server" OnCommand="btnDelConf_Command" CommandArgument='<%# Eval("ProdID") %>'
                        CommandName="DelConf" Text="Discard" CssClass="btnaddcart" /> </td>
                    </tr>
               </tbody>
            </table>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
