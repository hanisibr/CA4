<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MLoggedIn.Master" AutoEventWireup="true" CodeBehind="Product1.aspx.cs" Inherits="CA4_10385012.Product1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cartsection">
      <figure>
        <asp:Label ID="lblProd" runat="server" CssClass="lblstyle"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" CssClass="lblstyle"></asp:Label>
      </figure>
    </div>
    <div class="DisplayProduct">
        <asp:Repeater runat="server" ID="rptprod">
        <ItemTemplate>
        <figure>
            <asp:Label ID="lblProdID" runat="server" Text='<%# Eval("ProdID") %>' CssClass="lblstyle"></asp:Label>
        </figure>
        <br />
        <figure>
            <img src='data:image/jpg;base64, <%# Eval("ProdImg") != System.DBNull.Value ? Convert.ToBase64String ((byte[]) Eval("ProdImg")): string.Empty %>' alt="prod" height="150"/>
        </figure>
        <figure>
            <asp:Label ID="lblProdName" runat="server" Text='<%# Eval("ProdName") %>' CssClass="lblstyle" ></asp:Label>
        </figure>
        <figure>
            <asp:Label ID="lblProdDesc" runat="server" Text='<%# Eval("ProdDesc") %>' CssClass="lblstyle"></asp:Label>
        </figure>
        <figure>
            <asp:Label ID="lblProdPrice" runat="server" Text='<%# Eval("ProdPrice") %>' CssClass="lblstyle"></asp:Label>
        </figure>
            <br />
        <figure>
            <asp:Button runat="server" ID="btnAddCart" Text="Add to Cart" CommandName="Add"
                CommandArgument='<%# Eval("ProdID") %>' OnCommand="btnAddCart_Command" CssClass="btnaddcart" />
        </figure>
      </ItemTemplate>
    </asp:Repeater>
    </div>
    <br />
    <br />
 
</asp:Content>
