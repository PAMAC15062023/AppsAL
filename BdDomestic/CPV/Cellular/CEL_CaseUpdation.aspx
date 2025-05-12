<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/Cellular/CEL_MasterPage.master" Theme="SkinFile" CodeFile="CEL_CaseUpdation.aspx.cs" Inherits="CPV_Cellular_CEL_CaseUpdation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset><legend  class="FormHeading">Cellular Updation</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblSearch" style="width:100%" runat="server" >
<tr>
      <td class="TDWidth"> </td>               
   </tr>



<tr>
<td style="height: 24px" > <asp:Label ID="lblCaseId" runat="server" SkinID="lblSkin" Text="CASE ID:"></asp:Label>
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="txtCaseId" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
<td style="height: 24px" > <asp:Button id="btnCaseReceived" onclick="btnSearch_Click" runat="server" ValidationGroup="grp" SkinID="btn" Text="Case Recieved"></asp:Button></td>
<td style="height: 24px" >
    &nbsp;
</td>

</tr>

</table>
            <asp:Label SkinID="lblError" ID="lblMsg" runat="server"  ></asp:Label>
    <asp:RequiredFieldValidator ID="rfvCaseId" runat="server" ControlToValidate="txtCaseId"
        Display="None" ErrorMessage="Please enter caseId." SetFocusOnError="True" ValidationGroup="grpValidateSearch"></asp:RequiredFieldValidator>
    <asp:HiddenField ID="hdnFEID" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grp" />
    <asp:RequiredFieldValidator ID="rfvfortextcaseid" runat="server" ControlToValidate="txtCaseId"
        Display="None" ErrorMessage="Please Enter Case Id" SetFocusOnError="True" ValidationGroup="grp"></asp:RequiredFieldValidator></fieldset>

</asp:Content>