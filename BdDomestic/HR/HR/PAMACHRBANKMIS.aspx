<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" CodeFile="PAMACHRBANKMIS.aspx.vb" Inherits="HR_HR_PAMACHRBANKMIS" %>

<asp:Content ID="CONTENT1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript"></script>

<fieldset><legend class="FormHeading">PAMAC-BANK MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 357px; height: 38px;"><b>Select Month<span style="color: #ff6666">*</span></b>
            <asp:DropDownList ID="ddlmonth" runat="server" SkinID="ddlSkin">
            <asp:ListItem>----SELECT----</asp:ListItem>
            <asp:ListItem>JAN</asp:ListItem>
            <asp:ListItem>FEB</asp:ListItem>
            <asp:ListItem>MAR</asp:ListItem>
            <asp:ListItem>APR</asp:ListItem>
            <asp:ListItem>MAY</asp:ListItem>
            <asp:ListItem>JUN</asp:ListItem>
            <asp:ListItem>JUL</asp:ListItem>
            <asp:ListItem>AUG</asp:ListItem>
            <asp:ListItem>SEP</asp:ListItem>
            <asp:ListItem>OCT</asp:ListItem>
            <asp:ListItem>NOV</asp:ListItem>
            <asp:ListItem>DEC</asp:ListItem>
            </asp:DropDownList>
</td>
<td style="width:238px; height:38px"><b>Select Year<span style="color: #ff6666">*</span></b><span style="color: #ff6666">
    </span>
<asp:DropDownList ID="ddlyear" runat="server" SkinID="ddlSkin"></asp:DropDownList>
</td>
<td><asp:Button ID="btnreport" SkinID="btn" Text="Report" runat="server" Width="104px" /></td>
<td><asp:Button ID="Export" runat="server" Text="Export To Excel" SkinID="btnExpToExlSkin"/> </td>
</tr>
<tr><td colspan="7"><span class="txtRed">&nbsp;<span style="color: #ff6666"> *</span></span>Indicate Mendatory Fields.</td></tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="99%" visible="false">
<tr>
<td><asp:GridView ID="gvmis" runat="server" SkinID="gridviewNoSort" Visible="false" AutoGenerateColumns="true"></asp:GridView>
</td>
</tr>
<tr><td><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label></td>
</tr>

</table>
</fieldset>



</asp:Content>

