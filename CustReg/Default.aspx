<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustReg._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <asp:Label ID="UserBox" runat="server" Text="UserName: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;<asp:Label ID="PassBox" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ErrLogin" runat="server" ForeColor="Red" Text="Invalid Account Info" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Loginbtn" runat="server" Text="Login" />
    <br />
    <br />
    <asp:Button ID="Createbtn" runat="server" Text="Create Account" />
    <br />
    <br />


</asp:Content>
