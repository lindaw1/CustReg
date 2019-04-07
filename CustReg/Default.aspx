<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustReg._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <h3>Login to access your vacation memories.</h3>

    <br/>
    <div style="width: 50%"> 

        <div style="margin-bottom: 10px" class="row">
            <asp:Label ID="UserBox" runat="server" Text="User Name:" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="Userbox1" runat="server" CssClass="col-sm-6"></asp:TextBox>
        </div>

        <div style="margin-bottom: 10px" class="row">
            <asp:Label ID="PassBox" runat="server" Text="Password: " CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="Passbox1" runat="server" CssClass="col-sm-6"></asp:TextBox>
        </div>

        <div style="margin: 10px auto; text-align: center;">
            <asp:Label ID="ErrLogin" runat="server" ForeColor="Red" Text="Incorrect User Name or Password, please try again." Visible="False" CssClass="col-sm-12"></asp:Label>
        </div>

        <div style="margin: 10px auto; text-align: center;">
            <asp:Button ID="Loginbtn" runat="server" OnClick="Loginbtn_Click" Text="Login" CssClass="btn-primary" Style="height: 26px; margin: 0 10px"></asp:Button>
            <asp:Button ID="Createbtn" runat="server" OnClick="Createbtn_Click" Text="Create Account" CssClass="btn-primary" Style="height: 26px; margin: 0 10px"></asp:Button>
        </div>

    </div>

</asp:Content>
