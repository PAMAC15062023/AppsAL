<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" CodeFile="PAMACHEADCOUNT.aspx.cs" Inherits="HR_HR_PAMACHEADCOUNT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript"></script>

<fieldset>
<legend class="FormHeading">PAMAC HEAD COUNT MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width:225px; height:38px"><b>
    Select Year<span style="color: #ff6666">*</span></b><span style="color: #ff6666"> </span>
<asp:DropDownList ID="ddlyear" runat="server" SkinID="ddlSkin" Width="130px"></asp:DropDownList>
</td>
 <td style="width: 98px"><asp:Button ID="btnreport" SkinID="btn" Text="Report" runat="server" Width="104px" OnClick="btnreport_Click"   /></td>
<td style="width: 150px"><asp:Button ID="Export" runat="server" Text="Export To Excel" SkinID="btnExpToExlSkin" OnClick="Export_Click"   /> </td>
</tr>
<tr><td colspan="7"><span class="txtRed">&nbsp;<span style="color: #ff6666"> *</span></span>Indicate Mendatory Fields.</td></tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%" visible="false">
<tr>
<td style="width: 960px"><asp:GridView ID="gvmis" runat="server" SkinID="gridviewNoSort" Visible="false" AutoGenerateColumns="true"></asp:GridView>
</td>
</tr>
<tr><td style="width: 960px"><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label></td>
</tr>




</table>

</fieldset>


</asp:Content>


