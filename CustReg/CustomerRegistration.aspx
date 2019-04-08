<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="CustReg.CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <br/>

    <div class="row" style="width: 100%">
        <asp:Label ID="lblGreeting" runat="server" Text="Welcome Aboard" Height="50px" CssClass="h3"></asp:Label>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFirstName"  CssClass="text-danger">Please enter your first name.</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLastName"  CssClass="text-danger">Please enter your last name.</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" CssClass="text-danger">Please enter your address.</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblCity" runat="server" Text="City" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCity"  CssClass="text-danger">Please enter city.</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblProvince" runat="server" Text="Province" CssClass="col-sm-4"></asp:Label>
            <asp:DropDownList ID="txtProvince" runat="server" Height="30px" Width="300px" CssClass="col-sm-6">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtProvince"  CssClass="text-danger">Please select your province.</asp:RequiredFieldValidator>
        </div> 

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPostalCode"  CssClass="text-danger">Please enter your postal code. X1X 1X1</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="PostalErr" ControlToValidate="txtPostalCode" ValidationExpression="[ABCEGHJKLMNPRSTVXY][0123456789][ABCEGHJKLMNPRSTVWXYZ][\s][0123456789][ABCEGHJKLMNPRSTVWXYZ][0123456789]"  CssClass="text-danger" ErrorMessage="X1X 1X1 is the required format"></asp:RegularExpressionValidator>
           
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="col-sm-4"></asp:Label>
            <asp:DropDownList ID="txtCountry" runat="server" Height="30px" Width="300px" CssClass="col-sm-6">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCountry"  CssClass="text-danger">Please select your country.</asp:RequiredFieldValidator>
        </div>

        <div style="margin-bottom: 20px">
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail"  CssClass="text-danger">Please enter your email.</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtHomePhone" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtHomePhone"  CssClass="text-danger">Please enter your home phone number.</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="HomeErr" ControlToValidate="txtHomePhone" ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" CssClass="text-danger" ErrorMessage="(555) 555-1212 is the required format"></asp:RegularExpressionValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblBusPhone" runat="server" Text="Business Phone" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtBusPhone" runat="server" CssClass="col-sm-6"></asp:TextBox>
          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBusPhone"  Display="Dynamic" CssClass="text-danger">Please enter your business phone number.</asp:RequiredFieldValidator>--%>
            <asp:RegularExpressionValidator runat="server" ID="BusErr" ControlToValidate="txtBusPhone" ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" CssClass="text-danger" ErrorMessage="(555) 555-1212 is the required format"></asp:RegularExpressionValidator>
         </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblUserId" runat="server" Text="User Id" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtUserId" runat="server" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUserId"  CssClass="text-danger">Please enter a user ID.</asp:RequiredFieldValidator>
            <asp:Label ID="ErrUserId" runat="server"  CssClass="text-danger" Text="Invalid User Id" Visible="False"></asp:Label>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword"  CssClass="text-danger">Please enter a password.</asp:RequiredFieldValidator>
        </div>
        
        <div style="margin-bottom: 20px">
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password" CssClass="col-sm-4"></asp:Label>
            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" CssClass="col-sm-6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPasswordConfirm"  CssClass="text-danger">Please confirm your password.</asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm"  CssClass="text-danger">Passwords do not match</asp:CompareValidator>
        </div>
  
    <asp:Button ID="btnRegister" runat="server" CssClass="btn-primary" Text="Register" OnClick="btnRegister_Click" />
    </div>

</asp:Content>
