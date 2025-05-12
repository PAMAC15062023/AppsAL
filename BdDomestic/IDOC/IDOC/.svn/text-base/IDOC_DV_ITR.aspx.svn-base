<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="IDOC_DV_ITR.aspx.cs" Inherits="IDOC_IDOC_IDOC_DV_ITR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
   
function PreventCharacterToAdd()
 { 
  getControlsId = document.getElementById("ctl00_C1_txtRemarks");
  if(getControlsId.value.length > 600)
  {
    getControlsId.value = getControlsId.value.substring( 0, 599 ); 
   return false;
  } 
}

  
  </script> 
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>

<fieldset><legend class="FormHeading">INCOME TAX RETURN (ITR) VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>

<table id="tblIncomeTaxReturnVerificationReport" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr>
<td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblIncomeTaxReturnVerificationReport" runat="server" Text="INCOME TAX RETURN (ITR) VERIFICATION REPORT"></asp:Label>
 </td>
</tr>
<tr>
<td><asp:Label SkinID="lblSkin"   ID="lblApplicantsName" runat="server">Applicant's Name (Mr./Ms./Mrs.)</asp:Label>
</td>
<td style="width:2%">:</td>
<td colspan="7">
<asp:TextBox SkinID="txtSkin"   ID="txtApplicantsName" runat="server" ReadOnly="True"></asp:TextBox>
</td>
</tr>
<tr>
<td><asp:Label SkinID="lblSkin"   ID="lblCDMRefNo" runat="server">CDM Referance No</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCDMRefNo" runat="server" ReadOnly="True" TabIndex="1"></asp:TextBox>
</td>
<td><asp:Label SkinID="lblSkin"   ID="lblDateOfInitiation" runat="server">Date of Initiation</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfInitiation" runat="server" ReadOnly="True" TabIndex="2"></asp:TextBox>
</td>
<td><asp:Label SkinID="lblSkin"   ID="lblAgencyCode" runat="server">Agency Code</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAgencyCode" runat="server" ReadOnly="True" TabIndex="3"></asp:TextBox>
</td>
</tr>
</table>


<table id="Table2" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr>
<td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblBackOfficeCheck" runat="server" Text="Back Office Check"></asp:Label>
 </td>
</tr>

<tr>
<td><asp:Label SkinID="lblSkin"   ID="lblTotalIncomeasperITR" runat="server">Total Income as per ITR</asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtTotalIncomeasperITR" runat="server" ReadOnly="True" TabIndex="4"></asp:TextBox>
</td>


<td><asp:Label SkinID="lblSkin"   ID="lblPANlogicandcorrectness" runat="server" Width="141px">PAN logic and correctness</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlPANLogicAndCorrectness" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="5">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td><asp:Label SkinID="lblSkin"   ID="lblIsit10digitsAlphabet" runat="server">Is it 10 digits Alphabet</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIsIt10DigitsAlphabet" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="6">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>


</tr>
<tr>
<td colspan="1"><asp:Label SkinID="lblSkin"   ID="lblAredigitsnumeri" runat="server">Are the 6th,7th,8th,and 9th digits numeri</asp:Label>
</td>
<td style="width:2%">:</td>
<td colspan="7">
<asp:DropDownList ID="ddlAredigitsnumeri" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="7">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td colspan="4"><asp:Label SkinID="lblSkin"   ID="lblIsTheFourthDigit" runat="server"> Is the fourth digit "P" for individuals, "H" for HUF,  "C" for companies and "F" for firms</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIsTheFourthDigit" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="8">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td><asp:Label SkinID="lblSkin"   ID="lblComputationCorrect" runat="server"> Computation correct </asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlComputationCorrect" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="9">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td><asp:Label SkinID="lblSkin"   ID="lblIncomeCalculationsCorrect" runat="server">Income calculations correct</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlIncomeCalculationsCorrect" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="10">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td><asp:Label SkinID="lblSkin"   ID="lblTaxCalculationsCorrect" runat="server">Tax  calculations correct</asp:Label>
</td>
<td style="width:2%">:</td>
<td colspan="4">
<asp:DropDownList ID="ddlTaxCalculationsCorrect" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="11">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td colspan="1"><asp:Label SkinID="lblSkin"   ID="lblAlphabetFallsUnderWard" runat="server"> Alphabet Falls Under Ward / Circle / Range Jurisdiction</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlAlphabetFallsUnderWard" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="12">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td colspan="4">
    <asp:Label ID="lblAddrressFallsUnderWard" runat="server" SkinID="lblSkin"> Addrress Falls Under Ward / Circle / Range Jurisdiction</asp:Label></td>
<td style="width:2%">:</td>
<td colspan="1">
    &nbsp;<asp:DropDownList ID="ddlAddrressFallsUnderWard" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="12">
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>
        <asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
    </asp:DropDownList></td>
</tr>
    <tr>
        <td colspan="1">
            <asp:Label SkinID="lblSkin" ID="lblWhetherOKToSendForFieldVerification" runat="server">Whether OK to send for field verification</asp:Label></td>
        <td style="width: 2%">
        </td>
        <td>
<asp:DropDownList ID="ddlWhetherOKToSendForFieldVerification" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="13">
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
        <td colspan="4">
        </td>
        <td style="width: 2%">
        </td>
        <td colspan="1">
        </td>
    </tr>
<tr>
<td colspan="1"><asp:Label SkinID="lblSkin"   ID="lblOtherObservation" runat="server">Other Observation ( Highlight details for any "No" above)</asp:Label>
</td>
<td style="width:2%">:</td>
<td colspan="7">
<asp:TextBox SkinID="txtSkin" ID="txtOtherObservation" runat="server" MaxLength="255" Width="586px" TabIndex="14"></asp:TextBox>
</td>
</tr>

</table>
<table id="Table1" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr>
<td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="Label30" runat="server" Text="Field Verification Of ITR"></asp:Label>
 </td>
</tr>
<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTalliedWith" runat="server" Text="Tallied with" ></asp:Label>
</td>
<td colspan="2">
<asp:Label SkinID="lblSkin"   ID="lblCOMPUTERRECORDS" runat="server" Text="COMPUTER RECORDS" Width="171px"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblINWARDREGISTER" runat="server" Text="INWARD REGISTER"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblBLUEREGISTER" runat="server" Text="BLUE REGISTER"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblINDEXREGISTER" runat="server" Text="INDEX REGISTER"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblORALLYOKBYCLERK" runat="server" Text="ORALLY OK BY CLERK" Width="171px"></asp:Label>
</td>
</tr>
<tr>
<td >
<asp:Label SkinID="lblSkin"   ID="lblWardNumber" runat="server" Text="Ward Number"></asp:Label>
</td>
<td colspan="2">
<asp:DropDownList ID="ddlCOMPUTERRECORDSWardNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="15">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td >
<asp:DropDownList ID="ddlINWARDREGISTERWNWardNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="20">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlBLUEREGISTERWardNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="25">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINDEXREGISTERWardNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="30">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
<td>
<asp:DropDownList ID="ddlORALLYOKBYCLERKWardNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="35">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>

</td>

</tr>
<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblSerialNumber" runat="server" Text="Serial Number"></asp:Label>
</td>
<td colspan="2">
<asp:DropDownList ID="ddlCOMPUTERRECORDSSerialNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="16">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINWARDREGISTERWNSerialNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="21">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlBLUEREGISTERSerialNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="26">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINDEXREGISTERSerialNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="31">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
<td>
<asp:DropDownList ID="ddlORALLYOKBYCLERKSerialNumber" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="36">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>

</td>

</tr>

<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblDateOfFiling" runat="server" Text="Date of Filing"></asp:Label>
</td>
<td colspan="2">
<asp:DropDownList ID="ddlCOMPUTERRECORDSDateOfFiling" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="17">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINWARDREGISTERWNDateOfFiling" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="22">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlBLUEREGISTERDateOfFiling" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="27">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINDEXREGISTERDateOfFiling" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="32">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
<td>
<asp:DropDownList ID="ddlORALLYOKBYCLERKDateOfFiling" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="37">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>

</td>

</tr>

<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTotalTaxableIncome" runat="server" Text="Total Taxable Income"></asp:Label>
</td>
<td colspan="2">
<asp:DropDownList ID="ddlCOMPUTERRECORDSTotalTaxableIncome" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="18">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINWARDREGISTERWNTotalTaxableIncome" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="23">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlBLUEREGISTERTotalTaxableIncome" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="28">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINDEXREGISTERTotalTaxableIncome" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="33">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
<td>
<asp:DropDownList ID="ddlORALLYOKBYCLERKTotalTaxableIncome" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="38">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>

</td>

</tr>

<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblAppName" runat="server" Text="Applicant's Name"></asp:Label>
</td>
<td colspan="2">
<asp:DropDownList ID="ddlCOMPUTERRECORDSAppName" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="19">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINWARDREGISTERAppName" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="24">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlBLUEREGISTERAppName" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="29">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlINDEXREGISTERAppName" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="34">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList></td>
<td>
<asp:DropDownList ID="ddlORALLYOKBYCLERKAppName" runat="server" AutoPostBack="false" SkinID="ddlSkin" TabIndex="40">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="UTV" Value="UTV"></asp:ListItem>
</asp:DropDownList>

</td>

</tr>

<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="Label34" runat="server" Text="Final Status"></asp:Label>
</td>
<td colspan="8">
<asp:DropDownList ID="ddlFinalStatus" runat="server" AutoPostBack="false" SkinID="ddlSkin" DataSourceID="sdsCaseStatus"
 DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID" TabIndex="41">
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
</table>
<table id="Table3" runat="server" width="100%" cellpadding="0" cellspacing="0">
<tr>
<td colspan="5">
<asp:Label SkinID="lblSkin"   ID="lblRemark" runat="server" Text=" REMARKS ( Clerarly specify reason for not okay cases and not confirmed cases.)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td colspan="3">
<asp:TextBox ID="txtRemarks" runat="server" SkinID="txtSkin" Width="487px" TabIndex="42" TextMode="multiLine" onkeypress="return PreventCharacterToAdd()" onkeyup="return PreventCharacterToAdd();"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="9"></td>
</tr>
<tr>
<td>
    <asp:Label SkinID="lblSkin"   ID="lblNameOfFE" runat="server" Text="Name of FE"></asp:Label></td>
<td style="width:2%">:</td>
<td>
    &nbsp;<asp:TextBox ID="txtNameOfFE" runat="server" SkinID="txtSkin" TabIndex="43" ReadOnly="true"></asp:TextBox></td>
<td>
    &nbsp;</td>
<td style="width:2%"></td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td style="width:2%"></td>
<td>
    &nbsp;</td>
</tr>


<tr>
<td>
<asp:Label SkinID="lblSkin"   ID="lblDateofVerification" runat="server" Text="Date of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox ID="txtDateofVerification" MaxLength="10" runat="server" SkinID="txtSkin" TabIndex="44" ValidationGroup="grpAttempts"></asp:TextBox>
 <img alt="Calendar" onclick="popUpCalendar(this, <%=txtDateofVerification.ClientID %>, 'dd/mm/yyyy', 0, 0);"
        src="../../Images/SmallCalendar.gif" /> [dd/MM/yyyy]</td>
   
<td>

</td>

<td>
    &nbsp;</td>
<td style="width:2%"></td>
<td colspan="3">
    &nbsp;</td>
</tr>
<tr>
<td colspan="9" align="center">
 <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpAttempts" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />        
 <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
</td>
</tr>
<tr><td colspan="9"><asp:HiddenField ID="hidCaseID" runat="server" />
<asp:HiddenField ID="hidVerificationTypeID" runat="server" />
</td></tr>
<tr><td colspan="9">
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</td></tr>
<tr>
<td colspan="9">
 <asp:RegularExpressionValidator ID="revDateofVerification" runat="server" ControlToValidate="txtDateofVerification"
            Display="None" ErrorMessage="Please enter valid date format for Date of Verification."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpAttempts">
 </asp:RegularExpressionValidator>

 <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />   
            
 <asp:HiddenField ID="hdnTransStart" runat="server" />          
</td>
</tr>

</table>

</td></tr>
    
</table>
</fieldset>
</td></tr>
</table>
</asp:Content>

