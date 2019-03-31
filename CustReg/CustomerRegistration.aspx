<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="CustReg.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblUserId" runat="server" Text="User Id"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUserId"></asp:RequiredFieldValidator>
        </div>
    </div>

        <div>
            <div class="lblCustInfo">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </div>
            <div class="txtCustInfo">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
        </div>

    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtPasswordConfirm" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPasswordConfirm"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm"></asp:CompareValidator>
        </div>
    </div>
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />

    <%--To do:  make better messages for validator--%>
    <br />
    <br />
</asp:Content>
