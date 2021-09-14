<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="blog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div id="form1" runat="server">
<div>
    Roll No.
    <asp:TextBox ID="txtrollno" runat="server">
    </asp:TextBox>
    <br />
    Select File
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Convert" OnClick="Button1_Click" />
</div>
</div>
</asp:Content>
