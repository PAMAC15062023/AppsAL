<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Assets/AssetMasterPage.master"  Theme="SkinFile" CodeFile="AssetSearch.aspx.cs" Inherits="Assets_AssetSearch" %>

<asp:Content ID="content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 973px">
<fieldset>
<legend class="FormHeading">Search Barcode</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
    &nbsp; &nbsp; &nbsp; 
<asp:Label ID="lblName" runat="server" SkinID="lblSkin" Text="Name"></asp:Label>
<asp:TextBox ID="txtname" runat="server" SkinID="txtSkin"></asp:TextBox>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lblBarcode" runat="server" SkinID="lblSkin" Text="Barcode"></asp:Label>
<asp:TextBox ID="txtbar" runat="server" SkinID="txtSkin"></asp:TextBox>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Button ID="btnsearch" Text="Search" SkinID="btn" runat="server" Width="101px" OnClick="btnsearch_Click" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
    <asp:button ID="btnClear" Text="Clear" SkinID="btn" runat="server" Width="84px" OnClick="btnClear_Click" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnexport" Text="Export To Excel" runat="server" SkinID="btn" Visible="false" Width="116px" OnClick="btnexport_Click"/>
   </td>
</tr>
<tr>
<td style="height: 14px">
<asp:label ID="lblmsg" runat="server" Visible="false" ForeColor="red" Font-Bold="true"></asp:label><br />
</td>
</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
<asp:GridView ID="grdvw" AutoGenerateColumns="true" runat="server" Visible="false" Width="100%"></asp:GridView>
</td>
</tr>
</table>
</fieldset>
</td>
</tr>
</table>
</asp:Content>