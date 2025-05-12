<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TELETIMELOG.aspx.cs" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" Inherits="CPV_CC_TELETIMELOG" %>
<asp:Content ID="cONTENT1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript"  language="javascript"></script>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td style="padding-left:10PX">
<fieldset>
<legend class="FormHeading">Tele Caller Time Log MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td><asp:Label ID="LBLTELENAME" Text="Tele Name" SkinID="lblSkin" runat="server"></asp:Label></td>
<td><asp:DropDownList ID="DDLTELENAME" runat="server" SkinID="ddlSkin"></asp:DropDownList></td>
<td>From Date:</td>
 <td style="width: 245px" >  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" Width="118px" ></asp:TextBox>
        <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
</td>
<td><asp:Button ID="btnsearch" Text="Search" runat="server" SkinID="btnsearchskin" OnClick="btnsearch_Click" />
    <asp:Button ID="cmdExcel" SkinID="btnExpToExlSkin" runat="server" Text="Export To Excel" OnClick="cmdExcel_Click" /></td>               
</tr>
<tr><td><asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
</td>
</tr>
</table>
    <asp:GridView ID="GridView" SkinID="gridviewNoSort" runat="server" Height="117px" Width="890px">
    </asp:GridView>
</fieldset>
</td>
</tr>
</table>
</asp:Content>