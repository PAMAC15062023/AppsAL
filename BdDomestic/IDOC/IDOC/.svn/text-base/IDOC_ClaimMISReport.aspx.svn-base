<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="IDOC_ClaimMISReport.aspx.cs" Inherits="IDOC_IDOC_IDOCClaimMISReport"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend  class="FormHeading">Claim MIS</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr><td >
<table id="tblGenerateReport" runat="server" style="width:100%;" >
    <tr >
    <td>
    <asp:Label ID="lblFromDate" runat="server" Text="From Date :"></asp:Label>
    </td>
    <td>  <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
    <img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
    <asp:Label ID="lblFormateFromDate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
    </td>
    
    <td>
    <asp:Label ID="lblToDate" runat="server" Text="To Date :"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        <img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        <asp:Label ID="lblFormateToDate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
    </td>
    <td><asp:Button ID="btnGenrateReport" runat="server" ValidationGroup="grpDates" Text="Generate Report" OnClick="btnGenrateReport_Click" SkinID="btnReportSkin" />
    </td>
    </tr>
    <tr>
        <td colspan="5">
            <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
    </tr>
    <tr align="center">
    <td>
        <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter From Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter To Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator></td>
    <td>
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
    Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"   
    ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
    Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    </td>
    </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="grpDates"/>
    <asp:Label ID="lblMessage" runat="server" Width="499px" Visible="false"></asp:Label>&nbsp;
    </td></tr>
</table>
</fieldset>
</asp:Content>






