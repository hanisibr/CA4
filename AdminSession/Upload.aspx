<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MAdmin.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="CA4_10385012.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Image Upload</h2>
    <figure>
        <asp:Label ID="lblID" Text="Image ID:" runat="server" CssClass="lblstyle" Font-Size="16pt"></asp:Label>
        <asp:TextBox ID="txtID" runat="server" CssClass="txtbox" />
    </figure>
    <figure>
        <asp:Label ID="lblName" Text="Image Name:" runat="server" CssClass="lblstyle" Font-Size="16pt"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="txtbox"></asp:TextBox>
    </figure>
    <figure>
        <asp:Label ID="lblUpload" Text="Image Upload:" runat="server" CssClass="lblstyle" Font-Size="16pt"></asp:Label>
        <asp:FileUpload ID="FilUpl" runat="server" />
    </figure>
    <figure>
        <asp:Button ID="btnUpl" runat="server" Text="Upload" OnClick="btnUpl_Click" CssClass="btnadd"/>
        <asp:Label ID="lblSuccess" runat="server" CssClass="lblstyle" Font-Size="16pt"></asp:Label>
    </figure>
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Type</th>
                <th>Image</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptImg" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ImgID") %></td>
                        <td><%# Eval("ImgName") %></td>
                        <td><%# Eval("ImgType") %></td>
                        <td><img src='data:image/jpg;base64,<%# Eval("Img") != System.DBNull.Value ?
                            Convert.ToBase64String((byte[])Eval("Img")): string.Empty %>' alt="image" height="150" /></td>
                        <td><asp:Button ID="btnViewChgs" Text="View Changes" runat="server"
                            CommandArgument='<%# Eval("ImgID") %>' OnCommand="btnViewChgs_Command" CssClass="btnadd"/></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
