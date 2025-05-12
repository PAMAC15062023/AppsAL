<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" CodeFile="PAMACFEPAYOUT.aspx.vb" Inherits="HR_HR_PAMACFEPAYOUT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript"  runat="server"></script>
<fieldset><legend class="FormHeading">PAMAC FE PAYOUT MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width: 243px; height: 38px;"><b>&nbsp;Select Month<span style="color: #ff6666">*</span></b>&nbsp;
            <asp:DropDownList ID="ddlmonth" runat="server" SkinID="ddlSkin" Width="105px">
            <asp:ListItem>----Select----</asp:ListItem>
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
<td style="width:269px; height:38px"><b>
    Select Year<span style="color: #ff6666">*</span></b>&nbsp;&nbsp;&nbsp; &nbsp;<span style="color: #ff6666"></span><asp:DropDownList ID="ddlyear" runat="server" SkinID="ddlSkin" Width="121px"></asp:DropDownList>
</td>
</tr>
<tr>
 <td style="width: 243px; height: 24px;"><b>&nbsp;Select Centre</b><span style="color: #ff6666">*</span>&nbsp;
 <asp:DropDownList ID="ddlcentre" runat="server" AutoPostBack="true" AppendDataBoundItems="True" SkinID="ddlSkin" Width="106px">
         <%--<asp:ListItem Value="0">--All Centre--</asp:ListItem>--%>
         </asp:DropDownList>
         </td>
 <td style="width: 269px; height: 24px;"><b>Select Report</b><span style="color:#ff6666">*</span>
 <asp:DropDownList ID="ddlreport" runat="server" AutoPostBack="true" AppendDataBoundItems="true" SkinID="ddlSkin" Width="123px">
 <asp:ListItem Value="0">---All Reports---</asp:ListItem>
 <asp:ListItem>Index</asp:ListItem>
 <asp:ListItem>Barclays</asp:ListItem>
 <asp:ListItem>Pay-MIS</asp:ListItem>
 </asp:DropDownList>
 </td>
        
         <td style="width: 78px; height: 24px;">
             &nbsp;&nbsp;
             <asp:Button ID="btnreport" SkinID="btn" Text="Report" runat="server" Width="76px"  /></td>
             <td style="width: 30px; height: 24px;">
                 &nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="Export" runat="server" Text="Export To Excel" skinid="btnExpToExlSkin" Width="131px"  /> </td>
<td style="height: 24px; width: 83px;">
    &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnexport" runat="server" Text="Export All To Excel" SkinID="btn" Width="173px" /></td>
</tr>
<tr><td colspan="7" style="height: 15px"><span class="txtRed">&nbsp;<span style="color: #ff6666"> *</span></span>Indicate Mendatory Fields.</td></tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%" visible="false">
<tr>
<td style="width: 960px; height: 87px;"><asp:GridView ID="gvmis" runat="server" SkinID="gridviewNoSort" Visible="false" AutoGenerateColumns="true"></asp:GridView>
</td>
</tr>
<tr><td style="width: 960px"><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red" Visible="false"></asp:Label></td>
</tr>

</table>
</fieldset>



</asp:Content>
