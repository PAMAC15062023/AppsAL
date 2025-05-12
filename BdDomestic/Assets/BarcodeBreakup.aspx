<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarcodeBreakup.aspx.cs" MasterPageFile="~/Assets/AssetMasterPage.master" Theme="SkinFile" Inherits="Assets_BarcodeBreakup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 946px">
<fieldset>
<legend class="FormHeading">Barcode Breakup</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 445px">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;

<asp:Label ID="lblbar" runat="server" SkinID="lblSkin" Text="Barcode" Width="50px"></asp:Label>&nbsp;
<asp:TextBox ID="txtbar" runat="server" SkinID="txtSkin" Width="195px" AutoPostBack="true" OnTextChanged="txtbar_TextChanged" ></asp:TextBox>
</td>
<%--<td style="width: 178px">
<asp:button ID="btnsearch" runat="server" SkinID="btn" Text="Search" Width="117px" OnClick="btnsearch_Click" />
</td>--%>
<td>
<asp:Button ID="btnclear" runat="server" SkinID="btn" text="Clear" Width="112px" OnClick="btnclear_Click" />
</td>
</tr>
<tr>
<td style="width: 491px">
<asp:Label ID="lblmsg" runat="server" SkinID="lblSkin" ForeColor="red" Font-Bold="true" Visible="false"></asp:Label>
</td>
</tr>
</table>
<br />
    <br />
    <br />
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 491px; height: 24px">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
<asp:Label ID="lbldeptcode" runat="server" Text="Deptt. Code" SkinID="lblSkin" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtdeptcode" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Width="200px" Visible="false"></asp:TextBox>
</td>
<td style="height: 24px">
<asp:Label ID="lbldeptname" Text="Deptt. Name" runat="server" SkinID="lblSkin" Visible="false"></asp:Label>
    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:TextBox ID="txtdeptname" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Width="184px" Visible="false"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 491px; height: 24px;">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lblloccode" runat="server" SkinID="lblSkin" Text="Location Code" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="txtloccode" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Width="198px" Visible="false"></asp:TextBox>
</td>
<td style="height: 24px">
<asp:Label ID="lbllocname" runat="server" SkinID="lblSkin" Text="Location Name" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtlocname" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Visible="false" Width="182px"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 491px; height: 24px">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lblassetcode" SkinID="lblSkin" runat="server" Text="Asset Code" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="txtassetcode" SkinID="txtSkin" runat="server" Enabled="false" ReadOnly="true" Visible="false" Width="200px"></asp:TextBox>
</td>
<td style="height: 24px">
<asp:Label ID="lblasset" SkinID="lblSkin" Text="Asset Type." runat="server" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtasset" SkinID="txtSkin" runat="server" Enabled="false" ReadOnly="true" Visible="false" Width="180px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
<asp:Label ID="lblassetdesccode" SkinID="lblSkin" Text="Asset Desc Code." runat="server" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:TextBox ID="Txtassetdesccode" SkinID="txtSkin" runat="server" Enabled="false" ReadOnly="true" Visible="false" Width="199px"></asp:TextBox>
</td>
<td>
<asp:Label ID="lblassetdesctype" SkinID="lblSkin" Text="Asset Desc Type." runat="server" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:TextBox ID="txtassetdesctype" SkinID="txtSkin" runat="server" Enabled="false" ReadOnly="true" Visible="false" Width="180px"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 491px">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lblname" runat="server" SkinID="lblSkin" Text="Name" Visible="false"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtname" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Width="201px" Visible="false"></asp:TextBox>
</td>
<td>
<asp:label ID="lblsrno" runat="server" SkinID="lblSkin" Text="Asset SrNo." Visible="false"></asp:label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtsrno" runat="server" SkinID="txtSkin" Enabled="false" ReadOnly="true" Visible="false" Width="181px"></asp:TextBox>
</td>
</tr>
</table>
</fieldset>
</td>
</tr>
</table>
</asp:Content>