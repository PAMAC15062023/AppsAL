<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="Pages_JFS_demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr>
<td>
<asp:Label ID="lblheading" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Panel ID="pnldemo" runat="server">
<asp:TextBox ID="textbox1" runat="server"></asp:TextBox>
<asp:TextBox ID="textbox2" runat="server"></asp:TextBox>
<asp:Button ID="btndeom" runat="server" Text="ADD" onclick="btndeom_Click1" 
        Width="110px"/>
    &nbsp;&nbsp;
    <br />
<asp:Button ID="btnclickadd" runat="server" Text="Click_add" 
        onclick="btnclickadd_Click" />
</asp:Panel>


</td>
</tr>
</table>
</asp:Content>

