<%@ Page Language="C#" Theme="SkinFile" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" AutoEventWireup="true" CodeFile="~/DCR/DocCollection/CC_PendingList.aspx.cs" Inherits="CC_PendingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend  class="FormHeading">Pending Report</legend>

<table id="tblMain"  cellpadding="0" cellspacing="0" width="100%">
 <tr>   
<td >
<asp:Label SkinID="lblSkin"  ID="lblFromDate" runat="server" Text="From Date"></asp:Label></td>
<td><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateFromDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Label SkinID="lblSkin"  ID="lblToDate" runat="server" Text="To Date"></asp:Label>
</td>
<td  ><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateToDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" ValidationGroup="grpDates" SkinID="btnReportSkin" />
</td>
</tr>
<tr>
<td colspan="5"><asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></td>
</tr>
<tr>
    <td colspan="5">&nbsp;</td>
</tr>
 
</table>
 <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select From Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select To Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="vsValidateDate" runat="server" ShowMessageBox="True"
         ShowSummary="False" ValidationGroup="grpDates"/>
</fieldset>
      </td></tr>
</table>
</asp:Content>

