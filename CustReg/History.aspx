<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="CustReg.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="width:100%"
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblCust" runat="server" Text="Label" CssClass="h3"></asp:Label>
        <br/>
        <br/>
        
        <%--added by linda-- class="table-responsive" and removed Width="xxx" to make the gridview responsive--%>
        <div class="table-responsive">
        <asp:GridView ID="grvHistory" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grvHistory_RowDataBound" CssClass="table table-responsive">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" BorderStyle="None" HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="15px" HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>
    </p>
<p>
        &nbsp;</p>
<p>
  
        <asp:Label ID="Label1" runat="server" Text="Total Cost" ></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTotal" runat="server" ></asp:Label>
 
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        <div />
</asp:Content>
