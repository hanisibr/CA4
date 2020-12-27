<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MLoggedIn.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="CA4_10385012.Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><u>Spring New Arrival</u></h1>
    <h2>View more items at the Product section.</h2>
    <h2>Offer valid till 1st June 2020 at 6 pm.</h2>
    <div class="UserProdDisplay">
    <asp:Repeater ID="rptdisplay" runat="server">
       <ItemTemplate>
    <figure>
      <h3><asp:Label ID="lblimgID" runat="server" Text='<%# Eval("ImgID") %>' ></asp:Label></h3> 
   </figure>
<br />
   <figure>
        <img src='data:image/jpg;base64,<%# Eval("Img") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("Img")): string.Empty %>' alt="image" height="250"/>
    </figure>
     <br />
    <figure>
       <h3><asp:Label ID="lblimgName" runat="server" Text='<%# Eval("ImgName") %>'></asp:Label></h3>
    </figure>
     
           </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>
