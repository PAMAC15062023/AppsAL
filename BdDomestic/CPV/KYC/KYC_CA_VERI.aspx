<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="KYC_MasterPage.master" Theme="skinFile" CodeFile="KYC_CA_VERI.aspx.cs" Inherits="CPV_KYC_KYC_CA_VERI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<fieldset>
 <script language="javascript" type="text/jscript">
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
<legend class="FormHeading">CA Verification</legend>
 <table cellpadding="0" cellspacing="0" border="0" id="Table1" runat="server" width="100%"
    style="background-color: #e7f6ff">

<tr>
    <td>
    </td>
    <td>
    
       <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width: 100%"
                runat="server">
                <tr>
                    <td class="TDWidth" style="height: 14px">
                        <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <!--END ErrorMessgage-->
    <asp:Table ID="tblKYCVerification" runat="server"  Width="100%">
    <asp:TableRow ID="TableRow1" runat="server" >
    <asp:TableCell ID="TableCell1" runat="server" >  
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder9" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder10" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder11" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder12" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder13" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder14" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder15" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder16" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder17" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder18" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder19" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder20" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder21" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder22" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder23" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder24" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder25" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder26" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder27" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder28" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder29" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder30" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder31" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder32" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder33" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder34" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder35" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder36" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder37" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder38" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder39" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder40" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder41" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder42" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder43" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder44" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder45" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder46" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder47" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder48" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder49" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder50" runat="server"></asp:PlaceHolder>    
    </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="TableRow2" runat="server" >
    <asp:TableCell ID="TableCell2" runat="server" >
                    <!--Place holder Start-->
                    
                                <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text=" Referance No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtRefNo" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlInitiationDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Received Date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox>
                                         
                                    </td>
                                    </tr>
                                </table>
                                
                                </asp:Panel>
                                 <asp:Panel ID="pnlOnVerifyingCAFirmLetterHeadOnllyHead" runat="server" Width="100%" Visible="false">
                                <table>
                                <tr>
                                <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                <asp:Label SkinID="lblSkin"   ID="lblOnVerifyingCAFirmLetterHeadOnlly" runat="server" Text="ON VERIFYING CA FIRM LETTER HEAD ONLY"></asp:Label>
                                 </td>
                                 </tr>
                                 </table>
                                 </asp:Panel>  
                                <asp:Panel ID="pnlNameOfAccount" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfAccount" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfAccount" runat="server" Text="Name of Account being opened"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfAccount" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlRequestNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblRequestNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblRequestNo" runat="server" Text="Request No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtRequestNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                 <asp:Panel ID="pnlNameOfCAFirm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfCAFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfCAFirm" runat="server" Text="Name of CA Firm that has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfCAFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlAddressOfCAFirm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressOfCAFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAddressOfCAFirm" runat="server" Text="Address of CA Firm that has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddressOfCAFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTelNoOfCAFirm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblTelNoOfCAFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTelNoOfCAFirm" runat="server" Text="Telephone number of the CA firm being verified"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtTelNoOfCAFirm" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlPersonVerificationOfCAHead" runat="server" Width="100%" Visible="false">
                                    <table>
                                    <tr>
                                    <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                    <asp:Label SkinID="lblSkin"   ID="lblPersonVerificationOfCA" runat="server" Text="CA FIRM NAME,ADDRESS & PERSON VERIFICATION"></asp:Label>
                                     </td>
                                     </tr>
                                     </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDoesFirmExistAtAddress" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblDoesFirmExistAtAddress">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDoesFirmExistAtAddress" runat="server" SkinID="lblSkin">
                                                    Does the firm exist at the Address given in letter Head</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesFirmExistAtAddress" runat="server" AutoPostBack="false">
                                                <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIsFirmACAFirm" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblIsFirmACAFirm">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIsFirmACAFirm" runat="server" SkinID="lblSkin">
                                                    Is the Firm a CA firm as seen by Signage/RC Copy</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIsFirmACAFirm" runat="server" AutoPostBack="false">
                                                  <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem> 
                                                    <asp:ListItem>Signage</asp:ListItem>
                                                    <asp:ListItem>RC</asp:ListItem>                                                     
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfPersonWhoIssuedCACertificate" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfPersonWhoIssuedCACertificate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfPersonWhoIssuedCACertificate" runat="server" Text="Name of the Person who has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfPersonWhoIssuedCACertificate" Width="80%" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlIsPersonOneOfPractising" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblIsPersonOneOfPractising">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIsPersonOneOfPractising" runat="server" SkinID="lblSkin">
                                                    Is the Person one of the practising CAs in the firm</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIsPersonOneOfPractising" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlWasPersonSpokenTo" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblWasPersonSpokenTo">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblWasPersonSpokenTo" runat="server" SkinID="lblSkin">
                                                    Was the person who has issued the ceritificate Spoken to</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlWasPersonSpokenTo" runat="server" AutoPostBack="false">
                                                     <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlConfirmCACertificateIssued" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblConfirmCACertificateIssued">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblConfirmCACertificateIssued" runat="server" SkinID="lblSkin">
                                                    Did he/she confirm that the said CA certificate was issued by him/her</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlConfirmCACertificateIssued" runat="server" AutoPostBack="false">
                                                     <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlStatus" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStatus">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStatus" runat="server" SkinID="lblSkin">
                                                    Status</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStatus" runat="server" AutoPostBack="false">
  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlIfInconclusiveReason" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfInconclusiveReason" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfInconclusiveReason" runat="server" Text="If inconclusive Reason/Remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" TextMode="multiLine" ID="txtIfInconclusiveReason" onkeyPress="ValidateTextLength('Remark', this, 255);"  runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlCommentsRemarkOfVerifierHead" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblCommentsRemarkOfVerifier" runat="server" Text="COMMENTS / REMARKS OF VERIFIER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                 <asp:Panel ID="pnlVerifierName" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblVerifierName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblVerifierName" runat="server" SkinID="lblSkin">Verifier Name</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierName" runat="server" Width="80%" SkinID="txtSkin" ></asp:TextBox></td>  
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVerifierDate" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblVerifierDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblVerifierDate" runat="server" SkinID="lblSkin">Date</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgVerifierDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtVerifierDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                <asp:TextBox ID="txtVerifierTime" runat="server" SkinID="txtSkin" MaxLength="5" Width="4%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlVerifierTimeType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlAttemptsHead" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblpnlAttemptsHead" runat="server" Text="ATTEMPTS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                <asp:Panel ID="pnlAttempts" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAttempts">
                                        <tr>
                                            <td class="TDWidth">
                                                Attempts</td>
                                            <td >
                                                Date</td>
                                            <td>
                                                Time</td>
                                            <td>
                                                Remark</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                1st Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate1" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td>
                                                <asp:TextBox ID="txtTime1" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType1" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark1" runat="server"   SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                2nd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate2" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate2" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td>
                                                <asp:TextBox ID="txtTime2" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType2" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark2" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                3rd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate3" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDate3" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td >
                                                <asp:TextBox ID="txtTime3" runat="server" SkinID="txtSkin" MaxLength="5" Width="35%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlTimeType3" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemark3" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                             
                                
                                <asp:Panel ID="pnlRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRemark">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRemark" runat="server" SkinID="lblSkin">Tele Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 750);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                  <asp:Panel ID="pnloverallRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table6">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label1" runat="server" SkinID="lblSkin">Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtoverallRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 750);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>         
                                <br/>
                                <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" runat="server" Text="Submit" ValidationGroup="grValidate" OnClick="btnSubmit_Click"/>
                                                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        
                                        </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidCaseID" runat="server" />
                                         <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                          <asp:HiddenField ID="hidVerifierID" runat="server" />
                                           <asp:HiddenField ID="hidMode" runat="server" />
                                            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
                                </asp:Panel>                                
                                
        </asp:TableCell></asp:TableRow></asp:Table>    </td>        
    </tr>             </table>
        <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server" ControlToValidate="txtDate1"
                                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server" ControlToValidate="txtDate2"
                                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revDate3" runat="server" ControlToValidate="txtDate3"
                                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtTime1"
                                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server" ControlToValidate="txtTime2"
                                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revTime3" runat="server" ControlToValidate="txtTime3"
                                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:ValidationSummary ID="vsValidate" runat="server" ValidationGroup="grValidate"
                                    ShowMessageBox="True" ShowSummary="False" />
                                    <asp:HiddenField ID="hdnTransStart" runat="server" />
                                    
  <table>
    <tr>
    <td><asp:LinkButton ID="lbRV" runat="server" Text="RV" Width="22px" OnClick="lbRV_Click" Visible="False"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBV" runat="server" Text="BV" Width="22px" Visible="False" OnClick="lbBV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbCA" runat="server" Text="CA" Width="22px" Visible="False" OnClick="lbCA_Click" ></asp:LinkButton>
    </td>
    </tr>
  </table>
        
</fieldset>
</asp:Content>