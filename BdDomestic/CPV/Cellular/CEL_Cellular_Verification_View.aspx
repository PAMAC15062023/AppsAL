<%@ Page Language="C#" MasterPageFile="CEL_MasterPage.master" Theme="SkinFile"  AutoEventWireup="true" CodeFile="CEL_Cellular_Verification_View.aspx.cs" Inherits="CPV_Cellular_CC_CELLULAR_VERIFICATION_VIEW"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend  class="FormHeading">Cellular Verification</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblSearch" style="width:100%" runat="server" >
<tr>
      <td class="TDWidth"> </td>               
   </tr>
    <tr>
        <td align="center" colspan="3">
            <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label></td>
    </tr>
<tr><td colspan="3">&nbsp;</td></tr>


<tr>
<td > <asp:Label ID="lblCaseId" runat="server" SkinID="lblSkin" Text="CASE ID:"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="txtCaseId" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
<td > <asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" ValidationGroup="grp" SkinID="btnSearchSkin" Text="Enter"></asp:Button></td>
<td >
    &nbsp;
</td>

</tr>
<tr><td colspan="3">&nbsp;</td></tr>
</table>
    <asp:RequiredFieldValidator ID="rfvCaseId" runat="server" ControlToValidate="txtCaseId"
        Display="None" ErrorMessage="Please enter caseId." SetFocusOnError="True" ValidationGroup="grpValidateSearch"></asp:RequiredFieldValidator>
    <asp:HiddenField ID="hdnFEID" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grp" />
    <asp:RequiredFieldValidator ID="rfvfortextcaseid" runat="server" ControlToValidate="txtCaseId"
        Display="None" ErrorMessage="Please Enter Case Id" SetFocusOnError="True" ValidationGroup="grp"></asp:RequiredFieldValidator></fieldset>

</asp:Content>

