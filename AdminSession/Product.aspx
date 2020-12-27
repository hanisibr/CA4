<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MAdmin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="CA4_10385012.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="AddProduct">
    <h2>Add Products</h2>
        <figure>
            <asp:Label ID="lblProdID" runat="server" Text="ProductID:" CssClass="lblstyle"></asp:Label>
            <asp:TextBox ID="txtProdID" runat="server" CssClass="txtbox"></asp:TextBox>
        </figure>
        <figure>
            <asp:Label ID="lblImgUp" runat="server" Text="Product Image:" CssClass="lblstyle"></asp:Label>
            <asp:FileUpload ID="ProdUpl" runat="server" />
        </figure>
        <figure>
            <asp:Label ID="lblProdName" runat="server" Text="Product Name:" CssClass="lblstyle"></asp:Label>
            <asp:TextBox ID="txtProdName" runat="server" CssClass="txtbox"></asp:TextBox>
        </figure>
        <figure>
            <asp:Label ID="lblProdDesc" runat="server" Text="Description:" CssClass="lblstyle"></asp:Label>
            <asp:TextBox ID="txtProdDesc" runat="server"  CssClass="txtbox"></asp:TextBox>
        </figure>
        <figure>
            <asp:Label ID="lblProdPrice" runat="server" Text="Price:" CssClass="lblstyle"></asp:Label>
            <asp:TextBox ID="txtProdPrice" runat="server" CssClass="txtbox"></asp:TextBox>
        </figure>
        <figure>
            <asp:Button ID="btnAdd" runat="server" Text="Add Product" OnClick="btnAdd_Click" CssClass="btnadd" />
        </figure>
        <asp:Label ID="lblsuccess" runat="server" Text=" " CssClass="lblstyle"></asp:Label>
    </div>
    <h2>Add Product Photo</h2>
    <div class="OutputProduct">
        <h2>Output the Added Products</h2>
        <asp:Repeater ID="rptProdInfo" runat="server">
            <ItemTemplate> 
                <figure>
                    <asp:Label ID="lblOutID" runat="server" Text='<%# Eval("ProdID") %>' CssClass="lblstyle"></asp:Label>
                </figure>
                <br />
                <figure> 
                    <img src='data:image/jpg;base64,<%# Eval("ProdImg") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("ProdImg")): string.Empty  %>' alt="prodimage" height="150" />
                </figure>
                    <br />
                <figure>
                    <asp:Label ID="lblOutName" runat="server" Text='<%# Eval("ProdName") %>' CssClass="lblstyle"></asp:Label>
                </figure>
                <figure>
                    <asp:Label ID="lblOutDesc" runat="server" Text='<%# Eval("ProdDesc") %>' CssClass="lblstyle"></asp:Label>
                </figure>
                <figure>
                    <asp:Label ID="lblOutPrice" runat="server" Text='<%# Eval("ProdPrice") %>' CssClass="lblstyle" Font-Size="16pt"></asp:Label>
                </figure>
                <figure>

                    <asp:Button ID="BtnDelete" runat="server" Text="Delete"
                        OnCommand="BtnDelete_Command" CommandName="Delete"
                        CommandArgument='<%# Eval("ProdID") %>' CssClass="btndelete" />        
                </figure>
            </ItemTemplate>
        </asp:Repeater>

        <div class="SendToPage">
            <figure>
                <asp:Button ID="btnViewChgs" runat="server" Text="View Changes"
                    OnCommand="btnViewChgs_Command" CommandName="ViewChgs"
                    CommandArgument='<%# Eval("ProdID") %>' CssClass="btnviewchgs" />
            </figure>
        </div>
    </div>
</asp:Content>
