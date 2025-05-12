<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="TeleMisReport.aspx.cs" Inherits="CPV_CC_TeleMisReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript">
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="padding-left:10px; height: 207px;">
<fieldset>
<legend class="FormHeading">Tele Mis Report For Declined Cases</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td><asp:TextBox ID="txtFDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td><asp:TextBox ID="txtTDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtTDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td><asp:Button ID="btnsearch" Text="Search" SkinID="btnSearchSkin" runat="server" OnClick="btnsearch_Click"/></td>
<td><asp:Button ID="btnExport" runat="server" SkinID="btnGenerateExcelReportSkin" Text="Export To Excel" OnClick="btnExport_Click" /></td>
</tr>
<tr> <td><asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" ForeColor="red" Font-Bold="true"></asp:Label></td></tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td><asp:GridView ID="GvTele" runat="server"  AllowSorting="false" AllowPaging="false" AutoGenerateColumns="true" SkinID="gridviewNoSort"  >
                  </asp:GridView>      
</td>
</tr>
</table>

</fieldset>
</td>
</tr>
</table>
</asp:Content>
