<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_REF1Verification.aspx.cs" Inherits="CPV_RL_RL_REF1Verification"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">REF 1 VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
 <!--Start Heading-->
<asp:Panel ID="pnlRef1VerHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblRef1VerificationReport" runat="server" Text="REF 1 VERIFICATION REPORT"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>
    <!--END Heading-->
<!--- Start of Personal Detail-->
<asp:Table ID="tblRef1Veri" runat="server"  Width="100%">
<asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder9" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder10" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder11" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder12" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder13" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder14" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder15" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder16" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder17" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder18" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder19" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder20" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder21" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder22" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder23" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder24" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder25" runat="server"  EnableViewState="false"></asp:PlaceHolder>
     <asp:PlaceHolder ID="PlaceHolder26" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder27" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder28" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder29" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder30" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder31" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    
    
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="tblrow" runat="server" >
<asp:TableCell ID="tblCell" runat="server" >
<asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label>

<asp:Panel ID ="pnlDateRef1" runat="server" Width="100%" Visible="false">
<table id="tblDate" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDate" runat="server" Text="Date"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate" runat="server"  ReadOnly="True"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlAreaRef1" runat="server" Width="100%" Visible="false">
<table id="tblArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblArea" runat="server" Text="Area" >
</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtArea" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlRefNoRef1" runat="server" Width="100%" Visible="false">
<table id="tblRefNo"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRefNo" runat="server" Text="Ref No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRefNo" runat="server" ReadOnly="True" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlNameoftheApplicantRef1" runat="server" Width="100%" Visible="false">
<table id="tblNameoftheApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameoftheApplicant" runat="server" Text="Name of the Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtNameoftheApplicant" runat="server" ReadOnly="True" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlResidenceAddressofApplicantRef1" runat="server" Width="100%" Visible="false">
<table id="tblResidenceAddressofApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidenceAddressofApplicant" runat="server" Text="Residence Address of Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtResidenceAddressofApplicant" runat="server" ReadOnly="true" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlResidenceAddressasperApplicationRef1" runat="server" Width="100%" Visible="false">
<table id="tblResidenceAddressasperApplication" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidenceAddressasperApplication" runat="server" Text="Residence Address as per Application"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtResidenceAddressasperApplication" runat="server"  Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>



<asp:Panel ID="pnlNameoftheReferencepersonContactedRef1" runat="server" Width="100%" Visible="false">
<table id="tblNameoftheReferencepersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameoftheReferencepersonContacted" runat="server" Text="Name of the Reference person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNameoftheReferencepersonContacted" runat="server" MaxLength="100" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlRelationshipofReferencewithApplicantRef1" runat="server" Width="100%" Visible="false">
<table id="tblRelationshipofReferencewithApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRelationshipofReferencewithApplicant" runat="server" Text="Relationship of Reference with Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtRelationshipofReferencewithApplicant" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlApplicantKnowSinceMMAndYYbytheReferenceRef1" runat="server" Width="100%" Visible="false">
<table id="tblApplicantKnowSinceMMAndYYbytheReference" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblApplicantKnowSinceMMAndYYbytheReference" runat="server" Text="Applicant Know Since (MM/YY) by the Reference"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtApplicantKnowSinceMMAndYYbytheReference" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPhoneNumberoftheReferenceRef1" runat="server" Width="100%" Visible="false">
<table id="tblPhoneNumberoftheReference" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPhoneNumberoftheReference" runat="server" Text="Phone Number of the Reference"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtPhoneNumberoftheReference" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="PnlRefContactedConfirmsAppStayGivenAddressRef1" runat="server" Width="100%" Visible="false">
<table id="tblRefContactedConfirmsAppStayGivenAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRefContactedConfirmsAppStayGivenAddress" runat="server" Text="Ref. Contacted Confirms that the Applicant stays at given Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlRefContactedConfirmsAppStayGivenAddress" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlReferenceResidenceAddressasperCallRef1" runat="server" Width="100%" Visible="false">
<table id="tblReferenceResidenceAddressasperCall" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblReferenceResidenceAddressasperCall" runat="server" Text="Reference Residence Address as per Call"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtReferenceResidenceAddressasperCall" runat="server" MaxLength="255" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNumberofYearsatResidenceRef1" runat="server" Width="100%" Visible="false">
<table id="tblNumberofYearsatResidence" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNumberofYearsatResidence" runat="server" Text="Number of Years at Residence"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNumberofYearsatResidence" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOccupationTypeRef1" runat="server" Width="100%" Visible="false">
<table id="tblOccupationType" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOccupationType" runat="server" Text="Occupation Type"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtOccupationType" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNameofEmpOrNatureBusinessRef1" runat="server" Width="100%" Visible="false">
<table id="tblNameofEmpOrNatureBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameofEmpOrNatureBusiness" runat="server" Text="Name of Emp/Nature Business"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNameofEmpOrNatureBusiness" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDesignationoftheApplicantRef1" runat="server" Width="100%" Visible="false">
<table id="tblDesignationoftheApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDesignationoftheApplicant" runat="server" Text="Designation of the Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDesignationoftheApplicant" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlMTNLCheckRef1" runat="server" Width="100%" Visible="false">
<table id="tblMTNLCheck" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMTNLCheck" runat="server" Text="MTNL Check"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlMTNLCheck" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
 </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlPurposeRef1" runat="server" Width="100%" Visible="false">
<table id="tblPurpose" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPurpose" runat="server" Text="Purpose"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtPurpose" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAddressDifferentRef1" runat="server" Width="100%" Visible="false">
<table id="tblAddressDifferent" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddressDifferent" runat="server" Text="Address Different"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlAddressDifferent" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
 </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="true">
<table id="tblRating" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRating" runat="server" Text="Rating"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlRating" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
         
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlProvidereasonforunsatisfactoryrating" runat="server" Width="100%" Visible="false">
<table id="tblProvidereasonforunsatisfactoryrating" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblProvidereasonforunsatisfactoryrating" runat="server" Text="Please provide reason for unsatisfactory rating "></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtProvidereasonforunsatisfactoryrating" runat="server" MaxLength="255" Width="60%"></asp:TextBox>

</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDateOfVerification" runat="server" Width="100%" Visible="false">
<table id="tblDateOfVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateOfVerification" runat="server" Text="Date Of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfVerification" runat="server" MaxLength="10"></asp:TextBox>
<img id="ImgDate5thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
 <td><asp:Label SkinID="lblSkin"   ID="Label1" runat="server" Text="Time Of Verification"></asp:Label></td>
<td>:</td>
<td><asp:TextBox id="txtVerificationTime" runat="server" SkinID="txtSkin" MaxLength="5" Columns="8"></asp:TextBox>
<asp:DropDownList id="ddlVerificationTimeType" runat="server" SkinID="ddlSkin">
<asp:ListItem>AM</asp:ListItem>
<asp:ListItem>PM</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>


<!--END Personal Detail-->

<asp:Panel ID="pnlSubmitRef1" runat="server" Width="100%"  Visible="True">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server"  SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="grpAttempts" />       
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
        </td>
      </tr>
    </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
     <asp:HiddenField ID="hidMode" runat="server" />
     <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
    
    </asp:Panel>
 </asp:TableCell></asp:TableRow></asp:Table>
 
   <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtDateOfVerification"
                    Display="None" ErrorMessage="Please enter valid date format for verification."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="revVerificationTime" runat="server" ControlToValidate="txtVerificationTime"
                    Display="None" ErrorMessage="Please enter valid time format for verification."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grpAttempts">  </asp:RegularExpressionValidator>

    <asp:ValidationSummary ID="vsAttempt" runat="server" ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />
<asp:HiddenField ID="hdnTransStart" runat="server" />
 
</td>
</tr>
</table>
<table>
    <tr>
    <td><asp:LinkButton ID="lbRV" runat="server" Text="RV" Width="22px"  Visible="False" OnClick="lbRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBV" runat="server" Text="BV" Width="22px" Visible="False" OnClick="lbBV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbRT" runat="server" Text="RT" Width="22px" Visible="False" OnClick="lbRT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBT" runat="server" Text="BT" Width="22px" Visible="False" OnClick="lbBT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbREF1" runat="server" Text="REF1" Width="22px" Visible="False" OnClick="lbREF1_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbREF2" runat="server" Text="REF2" Width="22px" Visible="False" OnClick="lbREF2_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbRCO" runat="server" Text="RCO" Width="22px" Visible="False" OnClick="lbRCO_Click" ></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    
    </tr>
    
    </table>
</fieldset>
</td></tr></table>
</asp:Content>

