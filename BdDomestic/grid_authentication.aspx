<%@ Page Language="C#" AutoEventWireup="true" CodeFile="grid_authentication.aspx.cs" Inherits="grid_authentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="left: 0.1em; top: 0.8em; width: 100%; height: 100%; margin: 0;">
    <form id="form1" runat="server">
        <h2 style="text-align: center">GRID Authentication</h2>


        <table border="0" cellpadding="0" cellspacing="0" width="1200px">

            <table border="0" cellpadding="2" cellspacing="2" style="width: 100px">
                <tr>
                    <td colspan="8">
                        <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="500%" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtGridA" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtGrid1" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGridB" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtGrid2" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGridC" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtGrid3" runat="server" Text="" BorderWidth="1px" Font-Bold="false" Visible="true" AutoCompleteType="Disabled" Height="25px" Width="200px" BorderColor="Black"></asp:TextBox>
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVerify" class="button" runat="server" BorderWidth="1px" Font-Bold="False" Text="Verify" Visible="true" Height="30px" Width="100px" BackColor="#07D5BF" ForeColor="white" OnClick="btnVerify_Click" />
                        <asp:Button ID="btnBack" class="button" runat="server" BorderWidth="1px" Font-Bold="False" Text="Back" Visible="true" Height="30px" Width="100px" BackColor="#0733d5" ForeColor="white" OnClick="btnBack_Click" />

                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
