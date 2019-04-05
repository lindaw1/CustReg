<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="CustReg.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row" style="width: 60%">

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblCity" runat="server" Text="City" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCity" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblProvince" runat="server" Text="Province" CssClass="col-sm-4"></asp:Label>
            <asp:DropDownList ID="txtProvince" runat="server" Width="125px" OnSelectedIndexChanged="txtProvince_SelectedIndexChanged" CssClass="col-sm-6">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtProvince" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div> 

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPostalCode" ForeColor="Red">Cannot be null</asp:RequiredFieldValidator>
            <asp:Label ID="ErrPostal" runat="server" ForeColor="Red" Text="Invalid Postal Code" Visible="False"></asp:Label>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="col-sm-4"></asp:Label>
            <asp:DropDownList ID="txtCountry" runat="server" Width="125px" CssClass="col-sm-6">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCountry" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblEmail" runat="server" Text="email" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtHomePhone" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtHomePhone" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
            <asp:Label ID="ErrHome" runat="server" ForeColor="Red" Text="Invalid Phone Number" Visible="False"></asp:Label>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblBusPhone" runat="server" Text="Business Phone" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtBusPhone" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBusPhone" ForeColor="Red">Cannot Be Null</asp:RequiredFieldValidator>
            <asp:Label ID="ErrBus" runat="server" ForeColor="Red" Text="Invalid Phone Number" Visible="False"></asp:Label>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblUserId" runat="server" Text="User Id" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtUserId" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUserId" ForeColor="Red">Cannot be null</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword" ForeColor="Red">Cannot be null</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPasswordConfirm" ForeColor="Red">Cannot be null</asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" ForeColor="Red">Passwords do not match</asp:CompareValidator>
        </div>
  
   
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>

    <%--To do:  make better messages for validator--%>
    
</asp:Content>
