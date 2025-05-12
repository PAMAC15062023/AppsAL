<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_ResiCumBusiness.aspx.cs" Inherits="CPV_RL_RL_ResiCumBusiness"  %>
<asp:Content ID="Contant1" ContentPlaceHolderID="C1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<script language="javascript" type="text/javascript">
function PreventCharacterToAddInTextBox(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 99)
     {
       getControlsId.value = getControlsId.value.substring( 0, 99 );            
       return false;
     }          
   }
   
   function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 749)
     {
       getControlsId.value = getControlsId.value.substring( 0, 749 );            
       return false;
     }          
   }
//Added by hemangi kambli on 05-Sep-2007 for increasing size of Verifier comments to 750.
function ValidateTextLength(DisplayName, ControlName, xLength)
{   
    if (ControlName.value.length > parseInt(xLength)-2)
    {                      
         ControlName.value = ControlName.value.substring( 0, parseInt(xLength)-1 ); 
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
         return false;         
    }      
}

</script>
      

<fieldset><legend class="FormHeading">RESI CUM BUSINESS REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
 <!--Start Heading-->
<asp:Panel ID="pnlResiCumBusinessHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblResiCumBusiness" runat="server" Text="RESI CUM BUSINESS"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>
    <!--END Heading-->
<!--- Start of Personal Detail-->
<asp:Table ID="tblResiCumBusinessVeri" runat="server"  Width="100%">
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
    <asp:PlaceHolder ID="PlaceHolder32" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder33" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder34" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder35" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder36" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder37" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder38" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder39" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder40" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder41" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder42" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder43" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder44" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder45" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder46" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder47" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder48" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder49" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder50" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder51" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder52" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder53" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder54" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder55" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder56" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder57" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder58" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder59" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder60" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder61" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder62" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder63" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder64" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder65" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder66" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder67" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder68" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder69" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder70" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder71" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder72" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder73" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder74" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder75" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder76" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder77" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder78" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder79" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder80" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder81" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder82" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder83" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder84" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder85" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder86" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder87" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder88" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder89" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder90" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder91" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder92" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder93" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder94" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder95" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder96" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder97" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder98" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder99" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder100" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder101" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder102" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder103" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder104" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder105" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="tblrow" runat="server" >
<asp:TableCell ID="tblCell" runat="server" >
<asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label>

<asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="false">
<table id="tblRefNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblRefNo" runat="server" Text="Reference No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRefNo" runat="server" ReadOnly="true" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlApplicantName" runat="server" Width="100%" Visible="false">
<table id="tblApplicantName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblApplicantName" runat="server" Text="Applicant Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtApplicantName" runat="server" ReadOnly="true" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlApplicantAddress" runat="server" Width="100%" Visible="false">
<table id="tblApplicantAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblApplicantAddress" runat="server" Text="Applicant Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtApplicantAddress" runat="server" ReadOnly="true" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAgeOfApplicant" runat="server" Width="100%" Visible="false">
<table id="tblAgeOfApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblAgeOfApplicant" runat="server" Text="Age Of Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAgeOfApplicant" runat="server" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlVerifierName" runat="server" Width="100%" Visible="false">
<table id="tblVerifierName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblVerifierName" runat="server" Text="Verifier Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtVerifierName" runat="server" ReadOnly="true" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>



<asp:Panel ID="pnlVerificationAgency" runat="server" Width="100%" Visible="false">
<table id="tblVerificationAgency" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblVerificationAgency" runat="server" Text="Verification Agency"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtVerificationAgency" runat="server" Width="80%"></asp:TextBox>
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
<%--
<asp:Panel ID="pnlDateOfVerification" runat="server" Width="100%" Visible="true">
<table id="tblDateOfVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblDateOfVerification" runat="server" Text="Date Of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfVerification" runat="server" ReadOnly="true" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>--%>

<%--
<asp:Panel ID="pnlTimeOfVerification" runat="server" Width="100%" Visible="true">
<table id="tblTimeOfVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblTimeOfVerification" runat="server" Text="Time Of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeOfVerification" runat="server" ReadOnly="true"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>--%>




<asp:Panel ID="pnlNameOfNeighbour1" runat="server" Width="100%" Visible="false">
<table id="tblNameOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblNameOfNeighbour1" runat="server" Text="Name Of Neighbour 1"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNameOfNeighbour1" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAddressOfNeighbour1" runat="server" Width="100%" Visible="false">
<table id="tblAddressOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddressOfNeighbour1" runat="server" Text="Address Of Neighbour"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtAddressOfNeighbour1" Width="80%" runat="server" TextMode="MultiLine" onkeypress="return PreventCharacterToAddInTextBox('ctl00_C1_txtAddressOfNeighbour1')" onkeyup="return PreventCharacterToAddInTextBox('ctl00_C1_txtAddressOfNeighbour1');"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDoesTheApplicantWorkHere1" runat="server" Width="100%" Visible="false">
<table id="tblDoesTheApplicantWorkHere1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDoesTheApplicantWorkHere1" runat="server" Text="Does the Applicant Work Here"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlDoesTheApplicantWorkHere1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthsOfWorkAtOffice1" runat="server" Width="100%" Visible="false">
<table id="tblMonthsOfWorkAtOffice1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>

<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthsOfWorkAtOffice1" runat="server" Text="Months of Work at Office"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtMonthsOfWorkAtOffice1" runat="server" MaxLength="50" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthofStayatResidenceNeigh1" runat="server" Width="100%" Visible="false">
<table id="tblMonthofStayatResidenceNeigh1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>

<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthofStayatResidenceNeigh1" runat="server" Text="Month of Stay at Residence-Neigh1"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtMonthofStayatResidenceNeigh1" runat="server" MaxLength="50" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMarketReputation1" runat="server" Width="100%" Visible="false">
<table id="tblMarketReputation1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMarketReputation1" runat="server" Text="Market Reputation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlMarketReputation1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>V Good</asp:ListItem>
        <asp:ListItem>Good</asp:ListItem>
        <asp:ListItem>Fair</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlIsTheOfficeSelfOwned1" runat="server" Width="100%" Visible="false">
<table id="tblIsTheOfficeSelfOwned1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblIsTheOfficeSelfOwned1" runat="server" Text="Is the Office self owned"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlIsTheOfficeSelfOwned1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlCommentsOfNeighbour1" runat="server" Width="100%" Visible="false">
<table id="tblCommentsOfNeighbour1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCommentsOfNeighbour1" runat="server" Text="Comments of Neighbour"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCommentsOfNeighbour1" runat="server" Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtCommentsOfNeighbour1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtCommentsOfNeighbour1');"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNameOfNeighbour2" runat="server" Width="100%" Visible="false">
<table id="tblNameOfNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfNeighbour2" runat="server" Text="Name of Neighbour 2"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNameOfNeighbour2" runat="server" Width="80%" MaxLength="100" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlAddressOfNeighbour2" runat="server" Width="100%" Visible="false">
<table id="tblAddressOfNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddressOfNeighbour2" runat="server" Text="Address Of Neighbour"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtAddressOfNeighbour2" runat="server" Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAddInTextBox('ctl00_C1_txtAddressOfNeighbour2')" onkeyup="return PreventCharacterToAddInTextBox('ctl00_C1_txtAddressOfNeighbour2');"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDoestheApplicantWorkHere2" runat="server" Width="100%" Visible="false">
<table id="tblDoestheApplicantWorkHere2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDoestheApplicantWorkHere2" runat="server" Text="Does the Applicant Work Here"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlDoestheApplicantWorkHere2" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthsofWorkatOffice2" runat="server" Width="100%" Visible="false">
<table id="tblMonthsofWorkatOffice2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>

<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthsofWorkatOffice2" runat="server" Text="Months of Work at Office"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtMonthsofWorkatOffice2" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthofStayatResidenceNeigh2" runat="server" Width="100%" Visible="false">
<table id="tblMonthofStayatResidenceNeigh2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>

<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthofStayatResidenceNeigh2" runat="server" Text="Month of Stay at Residence-Neigh2"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtMonthofStayatResidenceNeigh2" runat="server" MaxLength="50" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMarketReputation2" runat="server" Width="100%" Visible="false">
<table id="tblMarketReputation2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMarketReputation2" runat="server" Text="Market Reputation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlMarketReputation2" runat="server"  AutoPostBack="false"  SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>V Good</asp:ListItem>
        <asp:ListItem>Good</asp:ListItem>
        <asp:ListItem>Fair</asp:ListItem>
        <asp:ListItem>Poor</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlIstheOfficeselfowned2" runat="server" Width="100%" Visible="false">
<table id="tblIstheOfficeselfowned2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblIstheOfficeselfowned2" runat="server" Text="Is the Office self owned"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlIstheOfficeselfowned2" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlCommentsofNeighbour2" runat="server" Width="100%" Visible="false">
<table id="tblCommentsofNeighbour2" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCommentsofNeighbour2" runat="server" Text="Comments of Neighbour"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCommentsofNeighbour2" runat="server" Width="80%" TextMode="multiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtCommentsofNeighbour2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtCommentsofNeighbour2');"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlLocalityOrSurroundings" runat="server" Width="100%" Visible="false">
<table id="tblLocalityOrSurroundings" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLocalityOrSurroundings" runat="server" Text="Locality / Surroundings"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:DropDownList ID="ddlLocalityOrSurroundings" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
    <asp:ListItem Text="NA" Value=""></asp:ListItem>
    <asp:ListItem>Slum</asp:ListItem>
    <asp:ListItem>Lower Middle</asp:ListItem>
    <asp:ListItem>Upper Class</asp:ListItem>
    <asp:ListItem>Under Developed</asp:ListItem>
    <asp:ListItem>Middle Class</asp:ListItem>
    <asp:ListItem>Village Area</asp:ListItem>
    <asp:ListItem>Negative Area</asp:ListItem>
    <asp:ListItem>Others</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">If Others(Pls.Specify)</td>
<td style="width: 2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtOtherLocality" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlLandMark" runat="server" Width="100%" Visible="false">
<table id="tblLandMark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLandMark" runat="server" Text="LandMark"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtLandMark" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlTypeOfBusinessActivity" runat="server" Width="100%" Visible="false">
<table id="tblTypeOfBusinessActivity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTypeOfBusinessActivity" runat="server" Text="Type of Business Activity"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTypeOfBusinessActivity" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="false">
<table id="tblLevelOfBusinessActivity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLevelOfBusinessActivity" runat="server" Text="Level of Business Activity"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlLevelOfBusinessActivity" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>High</asp:ListItem>
<asp:ListItem>Average</asp:ListItem>
<asp:ListItem>Poor</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlStockSeen" runat="server" Width="100%" Visible="false">
<table id="tblStockSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblStockSeen" runat="server" Text="Stock Seen"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlStockSeen" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>High</asp:ListItem>
<asp:ListItem>Average</asp:ListItem>
<asp:ListItem>Poor</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNoOfEmployeesSeen" runat="server" Width="100%" Visible="false">
<table id="tblNoOfEmployeesSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNoOfEmployeesSeen" runat="server" Text="No of Employees Seen"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNoOfEmployeesSeen" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAccessibility" runat="server" Width="100%" Visible="false">
<table id="tblAccessibility" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAccessibility" runat="server" Text="Accessibility"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlAccessibility" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>By All Means</asp:ListItem>
<asp:ListItem>By Two Wheeler Only</asp:ListItem>
<asp:ListItem>By Foot Only</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlEntranceMotorable" runat="server" Width="100%" Visible="false">
<table id="tblEntranceMotorable" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblEntranceMotorable" runat="server" Text="Entrance Motorable"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlEntranceMotorable" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlClearDemarcationBetweenResidenceAndOffice" runat="server" Width="100%" Visible="false">
<table id="tblClearDemarcationBetweenResidenceAndOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblClearDemarcationBetweenResidenceAndOffice" runat="server" Text="Clear demarcation between Residence and Office"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlClearDemarcationBetweenResidenceAndOffice" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlInternalCondition" runat="server" Width="100%" Visible="false">
<table id="tblInternalCondition" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInternalCondition" runat="server" Text="Internal Condition"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlInternalCondition" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Good</asp:ListItem>
<asp:ListItem>Fair</asp:ListItem>
<asp:ListItem>Poor</asp:ListItem>
<asp:ListItem>Painted</asp:ListItem>
<asp:ListItem>Unpainted</asp:ListItem>
<asp:ListItem>Plastered</asp:ListItem>
<asp:ListItem>Unplastered</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlExternalCondition" runat="server" Width="100%" Visible="false">
<table id="tblExternalCondition" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblExternalCondition" runat="server" Text="External Condition"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlExternalCondition" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Plastered</asp:ListItem>
<asp:ListItem>Brick Wall</asp:ListItem>
<asp:ListItem>Mud/Thatched Wall</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNamePlateSightedResi" runat="server" Width="100%" Visible="false">
<table id="tblNamePlateSightedResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNamePlateSightedResi" runat="server" Text="Name Plate Sighted(Residence)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlNamePlateSightedResi" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNamePlateSightedOffice" runat="server" Width="100%" Visible="false">
<table id="tblNamePlateSightedOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNamePlateSightedOffice" runat="server" Text="Name Plate Sighted(Office)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlNamePlateSightedOffice" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlEntryPermittedResi" runat="server" Width="100%" Visible="false">
<table id="tblEntryPermittedResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblEntryPermittedresi" runat="server" Text="Entry Permitted(Residence)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlEntryPermittedResi" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlEntryPermittedOffice" runat="server" Width="100%" Visible="false">
<table id="tblEntryPermittedOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblEntryPermittedOffice" runat="server" Text="Entry Permitted(Office)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlEntryPermittedOffice" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlApproxAreaResi" runat="server" Width="100%" Visible="false">
<table id="tblApproxAreaResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblApproxAreaResi" runat="server" Text="Approx Area (Residence)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtApproxAreaResi" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlApproxAreaOffice" runat="server" Width="100%" Visible="false">
<table id="tblApproxAreaOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblApproxAreaOffice" runat="server" Text="Approx Area (Office)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtApproxAreaOffice" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAssetSeen" runat="server" Width="100%" Visible="false">
<table id="tblAssetSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAssetSeen" runat="server" Text="Asset Seen"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:CheckBoxList ID="chkAssetSeen" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal" RepeatColumns="6">                                                    
<asp:ListItem>Fax</asp:ListItem>
<asp:ListItem>Photo Stat</asp:ListItem>
<asp:ListItem>Telephone</asp:ListItem>
<asp:ListItem>A/C</asp:ListItem>
<asp:ListItem>Computer</asp:ListItem>
<asp:ListItem>Printer</asp:ListItem>
<asp:ListItem>Xerox</asp:ListItem>
<asp:ListItem>Cabins</asp:ListItem>
<asp:ListItem>Table</asp:ListItem>
<asp:ListItem>Stock</asp:ListItem>
<asp:ListItem>Furniture seen</asp:ListItem>
<asp:ListItem>TW</asp:ListItem>
<asp:ListItem>Other</asp:ListItem>
</asp:CheckBoxList>
</td>
</tr>
<tr>
<td class="TDWidth">
If Others(Pls.Specify)</td>
<td style="width: 2%">
:</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="200" ID="txtOtherAssetSeen" runat="server" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblNameOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfPersonContacted" runat="server" Text="Name Of Person Contacted"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNameOfPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlRelationshipWithApplicant" runat="server" Width="100%" Visible="false">
<table id="tblRelationshipWithApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRelationshipWithApplicant" runat="server" Text="Relationship With Applicant"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRelationshipWithApplicant" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlIdentityProofSeen" runat="server" Width="100%" Visible="false">
<table id="tblIdentityProofSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblIdentityProofSeen" runat="server" Text="Identity Proof Seen"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIdentityProofSeen" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlBusinessProofSeen" runat="server" Width="100%" Visible="false">
<table id="tblBusinessProofSeen" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblBusinessProofSeen" runat="server" Text="Business Proof Seen"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlBusinessProofSeen" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNatureofBusiness" runat="server" Width="100%" Visible="false">
<table id="tblNatureofBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNatureofBusiness" runat="server" Text="Nature of Business"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox ID="txtNatureofBusiness" runat="server" SkinID="txtSkin" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlTypeOfOrganization" runat="server" Width="100%" Visible="false">
<table id="tblTypeOfOrganization" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTypeOfOrganization" runat="server" Text="Type Of Organization"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlTypeOfOrganization" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Huf</asp:ListItem>
<asp:ListItem>Partnership</asp:ListItem>
<asp:ListItem>Proprietorship</asp:ListItem>
<asp:ListItem>Pvt Ltd</asp:ListItem>
<asp:ListItem>Other</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlStatusOfResidence" runat="server" Width="100%" Visible="false">
<table id="tblStatusOfResidence" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblStatusOfResidence" runat="server" Text="Status Of Residence"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlStatusOfResidence" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Parent/Relative Owned</asp:ListItem>
<asp:ListItem>Rental/Co-Provided</asp:ListItem>
<asp:ListItem>Self Owned</asp:ListItem>
<asp:ListItem>PG Accomodation</asp:ListItem>
<asp:ListItem>Govt.Quarters</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthsOfWorkatCurrentOffice" runat="server" Width="100%" Visible="false">
<table id="tblMonthsOfWorkatCurrentOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthsOfWorkatCurrentOffice" runat="server" Text="Months Of Work at Current Office"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtMonthsOfWorkatCurrentOffice" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMonthsOfStayatResidence" runat="server" Width="100%" Visible="false">
<table id="tblMonthsOfStayatResidence" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMonthsOfStayatResidence" runat="server" Text="Months Of Stay at Residence"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtMonthsOfStayatResidence" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlApplicantIncome" runat="server" Width="100%" Visible="false">
<table id="tblApplicantIncome" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblApplicantIncome" runat="server" Text="Applicant's Income"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtApplicantIncome" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOtherSourceOfIncome" runat="server" Width="100%" Visible="false">
<table id="tblOtherSourceOfIncome" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOtherSourceOfIncome" runat="server" Text="Other Source Of Income"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtOtherSourceOfIncome" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDetailOfPreviousOccupation" runat="server" Width="100%" Visible="false">
<table id="tblDetailOfPreviousOccupation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDetailOfPreviousOccupation" runat="server" Text="Detail Of Previous Occupation"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDetailOfPreviousOccupation" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlFatherOrSpouseName" runat="server" Width="100%" Visible="false">
<table id="tblFatherOrSpouseName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="Label6" runat="server" Text="Father/Spouse's Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtFatherOrSpouseName" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMotherName" runat="server" Width="100%" Visible="false">
<table id="tblMotherName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMotherName" runat="server" Text="Mother's Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtMotherName" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMaritalStatus" runat="server" Width="100%" Visible="false">
<table id="tblMaritalStatus" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMaritalStatus" runat="server" Text="Marital Status"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlMaritalStatus" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Single</asp:ListItem>
<asp:ListItem>Married</asp:ListItem>
<asp:ListItem>Divorce</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNoOfDependents" runat="server" Width="100%" Visible="false">
<table id="tblNoOfDependents" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNoOfDependents" runat="server" Text="No. Of Dependents"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNoOfDependents" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOtherInvestments" runat="server" Width="100%" Visible="false">
<table id="tblOtherInvestments" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOtherInvestments" runat="server" Text="Other Investments"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtOtherInvestments" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAnyOtherLoansBeingTaken" runat="server" Width="100%" Visible="false">
<table id="tblAnyOtherLoansBeingTaken" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAnyOtherLoansBeingTaken" runat="server" Text="Any Other Loans Being Taken"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAnyOtherLoansBeingTaken" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPurposeOfLoanBeingTaken" runat="server" Width="100%" Visible="false">
<table id="tblPurposeOfLoanBeingTaken" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPurposeOfLoanBeingTaken" runat="server" Text="Purpose Of Loan Being Taken"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtPurposeOfLoanBeingTaken" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlBehaviourOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblBehaviourOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblBehaviourOfPersonContacted" runat="server" Text="Behaviour Of Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlBehaviourOfPersonContacted" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Polite</asp:ListItem>
<asp:ListItem>Rude</asp:ListItem>
<asp:ListItem>Doubtful</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlEducationBackground" runat="server" Width="100%" Visible="false">
<table id="tblEducationBackground" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblEducationBackground" runat="server" Text="Education Background"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlEducationBackground" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Under SSC</asp:ListItem>
<asp:ListItem>Grad (General)</asp:ListItem>
<asp:ListItem>Grad (Professional)</asp:ListItem>
<asp:ListItem>Some College</asp:ListItem>
<asp:ListItem>SSC/MSC</asp:ListItem>
<asp:ListItem>PG (General)</asp:ListItem>
<asp:ListItem>PG (Professional)</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlVerifierComments" runat="server" Width="100%" Visible="false">
<table id="tblVerifierComments" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblVerifierComments" runat="server" Text="Verifier's Comments"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="80%"  MaxLength="750" ID="txtVerifierComments" runat="server" TextMode="MultiLine" onkeyPress="ValidateTextLength('verifier comments', this, 750);"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlColourOfDoor" runat="server" Width="100%" Visible="false">
<table id="tblColourOfDoor" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblColourOfDoor" runat="server" Text="Colour Of Door"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtColourOfDoor" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOfficeName" runat="server" Width="100%" Visible="false">
<table id="tblOfficeName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOfficeName" runat="server" Text="Office Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtOfficeName" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>




<asp:Panel ID="pnlProofOfBusinessAcitivity" runat="server" Width="100%" Visible="false">
<table id="tblProofOfBusinessAcitivity" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblProofOfBusinessAcitivity" runat="server" Text="Proof Of Business Acitivity"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox ID="txtProofOfBusinessAcitivity" runat="server" SkinID="txtSkin" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOverallVerification" runat="server" Width="100%" Visible="false">
<table id="tblOverallVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOverallVerification" runat="server" Text="Overall Verification"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlOverallVerification" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem>Positive</asp:ListItem>
<asp:ListItem>Negative</asp:ListItem>
<asp:ListItem>Reffred</asp:ListItem>
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
<asp:TextBox SkinID="txtSkin"   ID="txtProvidereasonforunsatisfactoryrating" runat="server" MaxLength="255" Width="80%"></asp:TextBox>

</td>
</tr>
</table>
</asp:Panel>
                            <!--Start Additional Fields on 03-Oct-2007-->     
                                <asp:Panel ID="pnlSepBathroom" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSepBathroom" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblSepBathroom" runat="server" Text="Sep.Bathroom/Kitchen"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlSepBathroom" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>            
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlFamilySeen" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblFamilySeen" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFamilySeen" runat="server" Text="Family Seen"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlFamilySeen" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>            
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                   </table>
                               </asp:Panel>
                               <asp:Panel ID="pnlSupervisorComments" runat="server" Width="100%" Visible="false">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorComments" style="width:100%" runat="server">
                                        <tr>         
                                        <td class="TDWidth">
                                            <asp:Label SkinID="lblSkin" ID="lblSupervisorComments" runat="server" Text="Supervisor comments"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td >
                                           <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" MaxLength="250" onkeyPress="ValidateTextLength('verifier comments', this, 250);"  ID="txtSupervisorComments" runat="server" ></asp:TextBox> 
                                        </td>
                                        </tr>
                                   </table>
                               </asp:Panel>  
                               <asp:Panel ID="pnlRoofType" runat="server" Width="100%" Visible="false">
                                 <table cellpadding="0" cellspacing="0" border="0" id="tblRoofType" style="width:100%" runat="server">
                                    <tr>
                                    <td class="TDWidth"  >
                                        <asp:Label SkinID="lblSkin" ID="lblRoofType" runat="server" Text="Roof Type"></asp:Label>
                                        </td><td style="width:2%">:</td>
                                        <td>
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlRoofType" runat="server"  AutoPostBack="false">
                                            <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                            <asp:ListItem>Cemented</asp:ListItem>
                                            <asp:ListItem>Tin shed</asp:ListItem>
                                            <asp:ListItem>Tiled roof</asp:ListItem>                                   
                                        </asp:DropDownList>
                                        </td>  
                                        </tr>               
                                  </table>
                             </asp:Panel>   
                                <!--End Additional Fields on 03-Oct-2007-->
<%--<asp:Panel ID="pnlSupervisorName" runat="server" Width="100%"  Visible="true">
<table id="tblSupervisorName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSupervisorName" runat="server" Text="Supervisor Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlSupervisorName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
--%>
<asp:Panel ID="pnlSubmit" runat="server" Width="100%"  Visible="true">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpResiCumBusiness" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />       
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

 <%--<asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
    Display="None" ErrorMessage="Please enter valid Date Format for DOB" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpResiCumBusiness"></asp:RegularExpressionValidator>--%>
    
     <asp:RegularExpressionValidator ID="revVerificationDate" runat="server" ControlToValidate="txtDateOfVerification"
                    Display="None" ErrorMessage="Please enter valid date format for verification."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grpResiCumBusiness"></asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="revVerificationTime" runat="server" ControlToValidate="txtVerificationTime"
                    Display="None" ErrorMessage="Please enter valid time format for verification."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grpResiCumBusiness">  </asp:RegularExpressionValidator>

 <asp:ValidationSummary ID="vsResiCumBusiness" runat="server" ValidationGroup="grpResiCumBusiness" ShowMessageBox="True" ShowSummary="False" OnInit="vsResiCumBusiness_Init" />
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

