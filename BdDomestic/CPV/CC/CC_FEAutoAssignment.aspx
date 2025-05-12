<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_FEAutoAssignment.aspx.cs" Inherits="CPV_CC_CC_FEAutoAssignment" Theme="skinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend  class="FormHeading">FE Auto Assignment</legend>

<table id="tblMain"  cellpadding="0" cellspacing="0" width="100%">
 <tr>   
<td >&nbsp;
<asp:Label SkinID="lblSkin"  ID="lblFromDate" runat="server" Text="From Date"></asp:Label></td>
<td style="width:5px" align="center">:</td>
<td><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateFromDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Label SkinID="lblSkin"  ID="lblToDate" runat="server" Text="To Date"></asp:Label>
</td>
<td style="width:5px" align="center">:</td>
<td  ><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateToDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
    &nbsp;</td>
</tr>
    <tr>
        <td colspan="6" height="8px">
        </td>        
    </tr>
    <tr>
        <td>
            &nbsp;<asp:Label ID="lblVerificationType" runat="server" SkinID="lblSkin" Text="Verification Type"></asp:Label></td>
        <td style="width:5px" align="center">:</td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" DataSourceID="sdsVeriType"
                DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID"
                SkinID="ddlSkin" ValidationGroup="grpDates">
            </asp:DropDownList></td>
       
        <td colspan="3">
            <asp:Button ID="btnFEAutoAssignmet" runat="server" CssClass="button" OnClick="btnFEAutoAssignmet_Click"
                SkinID="btn" Text="Auto FE Assignment" /></td>
       
    </tr>
<tr>
<td colspan="6"><asp:Label ID="lblMsg" runat="server" Visible="false" SkinID="lblErrorMsg"></asp:Label></td>
</tr>
<tr>
    <td colspan="6">&nbsp;<asp:SqlDataSource ID="sdsVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER &#13;&#10;               WHERE VERIFICATION_TYPE_ID IN(1,2,4,3,10) AND (PARENT_TYPE_CODE = 'VV')">
        </asp:SqlDataSource>
    </td>
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

