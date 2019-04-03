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
            <asp:Label ID="lblEmail" runat="server" Text="email"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
        </div>
    </div>
     <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtHomePhone"></asp:RequiredFieldValidator>
        </div>
    </div>
        
    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblBusPhone" runat="server" Text="Business Phone"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtBusPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBusPhone"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCountry"></asp:RequiredFieldValidator>

        </div>
    </div>
    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblProvince" runat="server" Text="Province"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtProvince"></asp:RequiredFieldValidator>

        </div>
    </div>
     <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCity"></asp:RequiredFieldValidator>

        </div>
    </div>
    
    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>

        </div>
    </div>
    <div>
        <div class="lblCustInfo">
            <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
        </div>
        <div class="txtCustInfo">
            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPostalCode"></asp:RequiredFieldValidator>
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
