<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Assets/AssetMasterPage.master" Theme="SkinFile" CodeFile="AssetDescription.aspx.cs" Inherits="Assets_AssetDescription" %>

<asp:Content ID="ContentId" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">
function UpperLetter(ID)
{

ID.value=ID.value.toUpperCase();

}


</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
<fieldset><legend class="FormHeading">Asset Description</legend>
<table border="0" cellpadding="0" cellspacing="0" width="50%">
<tr>
<td>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lblcode" Text="Asset Description Code" SkinID="lblSkin" runat="server" ></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtcode" runat="server" MaxLength="10" SkinID="txtSkin"  OnKeyup="UpperLetter(this);" ></asp:TextBox><br />
    <br />
</td>
</tr>
<tr>
<td style="height: 24px">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;
<asp:Label ID="lbltype" Text="Asset Description Type" SkinID="lblSkin" runat="server"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txttype" runat="server" SkinID="txtSkin"  OnKeyup="UpperLetter(this);" ></asp:TextBox>
    <br />
    <br />
</td>
</tr>
<tr>
<td>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
<asp:button ID="btnid" runat="server" Text="Save" SkinID="btnSaveSkin" Width="95px" OnClick="btnid_Click" />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btncancel" runat="server" Text="Cancel" SkinID="btnCancelSkin" Width="92px" OnClick="btncancel_Click" />
</td>
</tr>
</table>
    <br />
    <br />
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr>
<td>  
<asp:GridView ID="grdvw" runat="server" AutoGenerateColumns="false" Visible="false"
AllowPaging="true" PageSize="15" CellPadding="2" CellSpacing="1"
 GridLines="None" AllowSorting="true" SkinID="gridviewSkin" OnRowCommand="grdvw_RowCommand" OnRowDataBound="grdvw_RowDataBound" >
<Columns>
<asp:BoundField DataField="asset_Desc_code" HeaderText="Asset Description Code" />
<asp:BoundField DataField="asset_Desc" HeaderText="Asset Description Type" />
<asp:TemplateField>
<ItemTemplate>
<asp:LinkButton id="lnkbtn" runat="server" CommandArgument='<%# Eval("Asset_Desc") %>' CommandName="Edit">
<img src="../Images/icon_edit.gif" alt="Edit" style="border : 0" />
</asp:LinkButton>
</ItemTemplate>
<ItemStyle Width="20px" />
</asp:TemplateField>
</Columns>
</asp:GridView>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblid" runat="server" Visible="false" Font-Bold="true" ForeColor="red"></asp:Label>
<asp:Label ID="lblmsg" runat="server" Visible="false" Font-Bold="true" ForeColor="red"></asp:Label>
</td>
</tr>

</table>


</fieldset>
</td>

</tr>

</table>


</asp:Content>
