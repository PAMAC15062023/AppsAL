<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" CodeFile="telecilentwisereport.aspx.cs" Inherits="CPV_CC_telecilentwisereport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript"></script>

<fieldset>
<legend class="FormHeading">Tele Client Wise MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td>From Date:
</td>
 <td style="width: 247px" >  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" Width="134px" ></asp:TextBox>
        <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
</td>
<td>To Date:
</td>
<td style="width: 252px"><asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
        Text="" Width="128px"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
   src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
 </td>
 <td><asp:Button ID="btnsearch" Text="Search" runat="server" SkinID="btnsearchskin" OnClick="btnsearch_Click" Width="94px" />
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="cmdExcel" SkinID="btnExpToExlSkin" runat="server"
         Text="Export To Excel" OnClick="cmdExcel_Click" /></td>               
</tr>
<tr><td><asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="red"></asp:Label>
</td>
</tr>
</table>
    <asp:GridView ID="GridView" SkinID="gridviewNoSort"  runat="server" Height="108px" Width="915px" AutoGenerateColumns="true">
    </asp:GridView>
</fieldset>

</asp:Content>
