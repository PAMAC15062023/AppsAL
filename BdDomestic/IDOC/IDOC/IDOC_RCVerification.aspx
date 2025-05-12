<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="IDOC_RCVerification.aspx.cs" Inherits="IDOC_IDOC_IDOC_RCVerification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
   
function PreventCharacterToAdd()
 { 
  getControlsId = document.getElementById("ctl00_C1_txtRemark");
  if(getControlsId.value.length > 600)
  {
    getControlsId.value = getControlsId.value.substring( 0, 599 ); 
   return false;
  } 
}
</script> 
<fieldset><legend class="FormHeading">RC VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>

<table id="tblRCVerificationReport" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr>
<td colspan="6" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblRCVerificationReport" runat="server" Text="RC VERIFICATION REPORT"></asp:Label>
 </td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblDateOfReceipt" runat="server" Width="133px">Date Of Receipt</asp:Label>
</td>
<td style="width:6%">:</td>
<td style="width: 156px">
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfReceipt" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td style="width: 30px">
    &nbsp;&nbsp;
    <asp:Label SkinID="lblSkin"   ID="lblCPAReferenceNumber" runat="server" Width="116px">CPA Reference Number</asp:Label>
</td>
<td colspan="2">
    &nbsp;:<asp:TextBox SkinID="txtSkin"   ID="txtCPAReferenceNumber" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblBankReferenceNumber" runat="server">Bank Reference Number</asp:Label>
</td>
<td style="width:6%">:</td>
<td style="width: 156px">
<asp:TextBox SkinID="txtSkin"   ID="txtBankReferenceNumber" runat="server" ReadOnly="true"></asp:TextBox>
</td>
<td style="width: 30px">
    &nbsp;&nbsp;
    <asp:Label SkinID="lblSkin"   ID="lblNameOfApplicant" runat="server" Width="110px">Name Of the Applicant</asp:Label>
</td>
<td colspan="2" style="width:2%">
    &nbsp;:<asp:TextBox SkinID="txtSkin"   ID="txtNameOfApplicant" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="6" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="Label1" runat="server" Text="RC Details as per RC Book"></asp:Label>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblRegistrationNumberOfVehicle" runat="server" Width="154px">Registration Number Of Vehicle</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtRegistrationNumberOfVehicle" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblRTOOffice" runat="server">RTO Office</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtRTOOffice" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblAddressFallsUnderJurisdiction" runat="server" Width="166px">Address Falls Under Jurisdiction</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlAddressFallsUnderJurisdiction" runat="server" SkinID="ddlSkin">
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblOtherObservation" runat="server">Other Observation</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtOtherObservation" runat="server" MaxLength="255" Width="521px"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="6" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblFieldVerificationOfRC" runat="server" Text="Field Verification Of RC"></asp:Label>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblRCDetailsConfirmedWith" runat="server" Width="154px">RC Details Confirmed With</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlRCDetailsConfirmedWith" runat="server" SkinID="ddlSkin">
<asp:ListItem Text="RC Register" Value="RC Register"></asp:ListItem>
<asp:ListItem Text="Clerk" Value="Clerk"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblRegistrationNumberOfVehicleisCorrect" runat="server">Registration Number Of Vehicle is Correct</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlRegistrationNumberOfVehicleisCorrect" runat="server" SkinID="ddlSkin">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="Not Confirmed" Value="Not Confirmed"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblWhethertheVehicleisPersonalCommercial" runat="server" Width="339px">Whether the Vehicle is Personal/Commercial</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlWhethertheVehicleisPersonalCommercial" runat="server" SkinID="ddlSkin">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="Not Confirmed" Value="Not Confirmed"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblIsVehicleHypothecated" runat="server">Is Vehicle Hypothecated</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlIsVehicleHypothecated" runat="server" SkinID="ddlSkin">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="Not Confirmed" Value="Not Confirmed"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblIfYesNameofFinancer" runat="server">If Yes Name of Financer</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtIfYesNameofFinancer" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblDateOfRegistrationasperRCRegister" runat="server">Date Of Registration as per RC Register</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfRegistrationasperRCRegister" runat="server" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, <%=txtDateOfRegistrationasperRCRegister.ClientID %>, 'dd/mm/yyyy', 0, 0);"
        src="../../Images/SmallCalendar.gif" /> [dd/MM/yyyy]</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblDetailsOfTransferIfAny" runat="server">Details Of Transfer If Any</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtDetailsOfTransferIfAny" runat="server" Width="522px" MaxLength="50"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblFinalStatus" runat="server">Final Status</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlFinalStatus" runat="server" AutoPostBack="false" SkinID="ddlSkin" DataSourceID="sdsCaseStatus"
 DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID">
</asp:DropDownList>
<asp:SqlDataSource ID="sdsCaseStatus" runat="server"  ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
              SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY CASE_STATUS_ID">
            <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
           </SelectParameters>  
</asp:SqlDataSource>
</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblRemark" runat="server" Width="389px">REMARK(Clerarly specify reason for not okay cases and not confirmed cases.)</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtRemark" runat="server" Width="526px" TextMode="multiLine" onkeypress="return PreventCharacterToAdd()" onkeyup="return PreventCharacterToAdd();"></asp:TextBox>
</td>
</tr>
<tr>
<td style="width: 366px; height: 19px;"><asp:Label SkinID="lblSkin"   ID="lblNameofVerifier" runat="server" Width="177px">Name Of the Verifier</asp:Label>
</td>
<td style="width:6%; height: 19px;">:</td>
<td colspan="4" style="height: 19px">
<asp:TextBox SkinID="txtSkin"   ID="txtNameofVerifier" runat="server" ></asp:TextBox>
    &nbsp;&nbsp;</td>
</tr>
<tr>
<td style="width: 366px"><asp:Label SkinID="lblSkin"   ID="lblDate" runat="server">Date</asp:Label>
</td>
<td style="width:6%">:</td>
<td colspan="4">
<asp:TextBox SkinID="txtSkin"   ID="txtDate" runat="server" ValidationGroup="grpAttempts" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, <%=txtDate.ClientID %>, 'dd/mm/yyyy', 0, 0);"
        src="../../Images/SmallCalendar.gif" /> [dd/MM/yyyy]</td>
</tr>
    <tr>
        <td style="width: 366px">&nbsp;
        </td>
        <td style="width: 6%">
        </td>
        <td colspan="4">
        </td>
    </tr>
<tr>
<td colspan="6" align="center" style="height: 24px">
 <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpAttempts" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />        
 <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
</td>
</tr>
<tr><td colspan="6"><asp:HiddenField ID="hidCaseID" runat="server" />
<asp:HiddenField ID="hidVerificationTypeID" runat="server" />
</td></tr>
<tr><td colspan="6">
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</td></tr>
<tr>
<td colspan="6">
<asp:RegularExpressionValidator ID="revDateofVerification" runat="server" ControlToValidate="txtDate"
            Display="None" ErrorMessage="Please enter valid date format for Date of Verification."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpAttempts">
 </asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDateOfRegistrationasperRCRegister"
            Display="None" ErrorMessage="Please enter valid date format for Date of registration as per RC register."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpAttempts">
 </asp:RegularExpressionValidator>
<asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />   
                    <asp:HiddenField ID="hdnTransStart" runat="server" />
       
</td>
</tr>
</table>

</td>
</tr>
    
</table>
</fieldset>
</asp:Content>




