<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MLoggedIn.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CA4_10385012.Cart1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Review your Cart</h2>
        <table>
            <thead>
                <tr>
                <th>Product</th>
                <th>Price</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptcart" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td><%# Eval("ProductName") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><asp:Button ID="btnDeleteCart" runat="server" OnCommand="btnDeleteCart_Command"
                            CommandArgument='<%# Eval("ProductID") %>' CommandName="DeleteCart" Text="Discard"
                            CssClass="btndeletecart"  />
                        </td>
                    </tr>
                
                    </ItemTemplate>
                </asp:Repeater>
           </tbody>
        </table>
        
          <h2><asp:Label ID="lblFinalTotal" runat="server" CssClass="lblstyle"></asp:Label></h2>  
        
</asp:Content>
