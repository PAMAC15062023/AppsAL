<%@ Page Language="C#" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" AutoEventWireup="true"
    CodeFile="KYC_VerificationEntry.aspx.cs" Inherits="KYC_KYC_VerificationEntry" Theme="skinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
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
    
    <fieldset>
        <legend class="FormHeading">KYC Verification form</legend>
        <table cellpadding="0" cellspacing="0" border="0" id="Table1" runat="server" width="100%"
            style="background-color: #E7F6FF">
            
            <tr>
                <td>
                </td>
                <td>
                    <!--Start ErrorMessgage-->
                    <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="false">
                        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width: 100%"
                            runat="server">
                            <tr>
                                <td class="TDWidth">
                                    <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <!--END ErrorMessgage-->
                    <!--Place holder Start-->
                    <asp:Table ID="tblKYCVerification" runat="server" Width="100%">
                        <asp:TableRow ID="tblrowPlace" runat="server">
                            <asp:TableCell ID="tblCellPlace" runat="server">  
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblrow" runat="server">
                            <asp:TableCell ID="tblCell" runat="server">
                                <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="true">
                                    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
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
                                        <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox>
                                         
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlDetailsOfCustomer" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDetailsOfCustomer" runat="server" Text="DETAILS OF CUSTOMER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlCompanyType" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyType" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Company Type"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlCompanyType" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Govt.</asp:ListItem>
                                        <asp:ListItem>PSU</asp:ListItem>            
                                        <asp:ListItem>MNC</asp:ListItem>            
                                        <asp:ListItem>Pvt. Ltd</asp:ListItem>            
                                        <asp:ListItem>Public Ltd.</asp:ListItem>            
                                        <asp:ListItem>Proprietorship</asp:ListItem> 
                                        <asp:ListItem>Partnership</asp:ListItem>           
                                        <asp:ListItem>HUF</asp:ListItem>  
                                        <asp:ListItem>Others</asp:ListItem>  
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEntityType" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblEntityType" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblEntityType" runat="server" Text="Entity Type"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:DropDownList SkinID="ddlSkin" ID="ddlEntityType" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Proprietorship</asp:ListItem> 
                                        <asp:ListItem>Partnership</asp:ListItem>           
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfFirm" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lnlNameOfFirm" runat="server" Text="Name of firm"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlBusinessAddress" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessAddress" runat="server" Text="Business Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtBusinessAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlBusinessPincode" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessPincode" runat="server" Text="Business Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusinessPincode" runat="server" MaxLength="20"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlBusinessTelNo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessTelNo" runat="server" Text="Business Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusinessTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                 
                                <asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNameOfPersonContacted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameOfPersonContacted" runat="server">Name of Person contacted</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameOfPersonContacted" runat="server" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblDesignation" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtDesignation" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoOfYearsInCurrentEmployment" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYearsInCurrentEmployment" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoOfYearsInCurrentEmployment" runat="server" Text="Number of Years in Current Employment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYearsInCurrentEmployment" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlBusinessAddressVerification" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblBusinessAddressVerification" runat="server" Text="BUSINESS ADDRESS VERIFICATION"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>        
                                <asp:Panel ID="pnlPremiseLocation" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPremiseLocation" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPremiseLocation" runat="server" Text="Premise Location"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlPremiseLocation" runat="server" AutoPostBack="false">
                                          <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Easy to Locate</asp:ListItem>
                                        <asp:ListItem>Difficult to Locate</asp:ListItem>
                                        <asp:ListItem>Untraceable</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProminentLandmark" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProminentLandmark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProminentLandmark" runat="server" Text="Prominent Landmark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtProminentLandmark" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlAddressVerifiedIs" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressVerifiedIs" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAddressVerifiedIs" runat="server" Text="Address verified is"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAddressVerifiedIs" runat="server" AutoPostBack="false">
                                          <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Trading Address</asp:ListItem>
                                        <asp:ListItem>Registered Address</asp:ListItem>
                                        <asp:ListItem>Both</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlHowLongInBusiness" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblHowLongInBusiness" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblHowLongInBusiness" runat="server" Text="How long in Business from this Premises"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtHowLongInBusiness" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlAreaPremises" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAreaPremises" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAreaPremises" runat="server" Text="Area of Premises"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAreaPremises" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlOwnershipOfPremises" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOwnershipOfPremises" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOwnershipOfPremises" runat="server" Text="Ownership of Premises"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlOwnershipOfPremises" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Owned</asp:ListItem>
                                        <asp:ListItem>Rented / Leased</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherPlzSpecify" runat="server" Text="If Others (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherPlzSpecify" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                               
                                  <asp:Panel ID="pnlLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Text="LEVEL OF BUSINESS ACTIVITY AND NATURE OF BUSINESS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>           
                                <asp:Panel ID="pnlTypeOfPremise" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfPremise" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTypeOfPremise" runat="server" Text="Type of Premise"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfPremise" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Office</asp:ListItem>
                                        <asp:ListItem>Factory</asp:ListItem>
                                        <asp:ListItem>Workship</asp:ListItem>
                                        <asp:ListItem>Godown / Warehouse</asp:ListItem>
                                        <asp:ListItem>Cabin</asp:ListItem>
                                        <asp:ListItem>Table Space</asp:ListItem>
                                        <asp:ListItem>RetailShop</asp:ListItem>
                                        <asp:ListItem>Wholesaleshop</asp:ListItem>
                                        <asp:ListItem>Showroom</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOtherTypeOfPremise" runat="server" Text="If Others specify"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtOtherTypeOfPremise" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlContactPerson" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblContactPerson" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblContactPerson" runat="server" Text="Contact Person"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlContactPerson" runat="server" AutoPostBack="false">
                                         <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Neighbour</asp:ListItem>
                                        <asp:ListItem>Watchman</asp:ListItem>
                                        <asp:ListItem>others</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherProvideDetail" runat="server" Text="If Others (Please Provide Details)"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtIfOtherProvideDetail" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>       
                                <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNatureOfBusiness" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNatureOfBusiness" runat="server" Text="Nature Of Business"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlNatureOfBusiness" runat="server" AutoPostBack="false">
                                         <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Trading in</asp:ListItem>
                                        <asp:ListItem>Manufacturing of</asp:ListItem>
                                        <asp:ListItem>Consultancy in</asp:ListItem>
                                        <asp:ListItem>Service Rendered of</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlFirmSignBoardSighted" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFirmSignBoardSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFirmSignBoardSighted" runat="server" Text="Firm Signboard sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlFirmSignBoardSighted" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOnSignBoard" runat="server" Text="Name On Sign Board"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtNameOnSignBoard" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfNotSameConcernDetails" runat="server" Text="If not of the same concern details of how the concern is related"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                     <td >
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlProprietorPartner" runat="server" >
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem Value="Same Proprietor" Text="Same Proprietor"></asp:ListItem>
                                        <asp:ListItem Value="Common Partner" Text="Common Partner"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                    <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblName" runat="server" Text="Name"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtName" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                    
                                    <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFamilyMemberIs" runat="server" Text="Family Member Is"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                  
                                    <td >
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlFamilyMemberIs" runat="server" >
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem Value="Proprietor" Text="Proprietor"></asp:ListItem>
                                        <asp:ListItem Value="Partner" Text="Partner"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                    <tr>
                                     <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameIs" runat="server" Text="Name"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtNameIs" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblRelationshipIs" runat="server" Text="Relationship"></asp:Label>
                                    </td><td style="width:2%">:</td>
                                    <td >
                                        <asp:TextBox SkinID="txtSkin" ID="txtRelationshipIs" runat="server" ></asp:TextBox>
                                    </td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                             
                                <asp:Panel ID="pnlSignBoardSightedRemark" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblSignBoardSightedRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblSignBoardSightedRemark" runat="server" Text="Sign Board Sighted Remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtSignBoardSightedRemark" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDocumentSightedWithNameandAddressofthefirm" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDocumentSightedWithNameandAddressofthefirm" runat="server" Text="DOCUMENTS SIGHTED WITH NAME AND ADDRESS OF THE FIRM"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlTypeOfDocSighted" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfDocSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblTypeOfDocSighted" runat="server" Text="Type of document sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfDocSighted" runat="server" AutoPostBack="false">
                                     <asp:ListItem>NA</asp:ListItem>
                                       <asp:ListItem>Bill Book</asp:ListItem>
                                       <asp:ListItem>Order Book</asp:ListItem>
                                       <asp:ListItem>Invoice Book</asp:ListItem>
                                       <asp:ListItem>Delivery Challan Book</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIfOtherDocSightedRemark" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherDocSightedRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherDocSightedRemark" runat="server" Text="If other document sighted remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherDocSightedRemark" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlUsedPageSightDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblUsedPageSightDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblUsedPageSightDate" runat="server" Text="Used pages sighted date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtUsedPageSightDate" runat="server" MaxLength="50"></asp:TextBox>
                                    <img id="img4" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtUsedPageSightDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlIssuedTo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIssuedTo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIssuedTo" runat="server" Text="Issued To"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIssuedTo" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedNo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedNo" runat="server" Text="Initial invoice sighted no"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedDate" runat="server" Text="Initial invoice sighted date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedDate" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    <img id="img1" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtInitialInvoiceSightedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlInitialInvoiceSightedIssuedTo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblInitialInvoiceSightedIssuedTo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblInitialInvoiceSightedIssuedTo" runat="server" Text="Initial invoice sighted issued to"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtInitialInvoiceSightedIssuedTo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                
                                <asp:Panel ID="pnlThirdPartyInvoiceNo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceNo" runat="server" Text="Third Party invoice no"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyInvoiceDate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceDate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceDate" runat="server" Text="Third Party invoice date"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceDate" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    <img id="img2" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtThirdPartyInvoiceDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyInvoiceIssuedBy" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyInvoiceIssuedBy" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyInvoiceIssuedBy" runat="server" Text="Third Party invoice issued by"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyInvoiceIssuedBy" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlThirdPartyAddress" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblThirdPartyAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblThirdPartyAddress" runat="server" Text="Third Party Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtThirdPartyAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                  
                                <asp:Panel ID="pnlRelationshipBtnEntity" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationshipBtnEntity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblRelationshipBtnEntity" runat="server" Text="Relationship between entity whose Signane and entity being verified"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlRelationshipBtnEntity" runat="server" AutoPostBack="false">
                                       <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Same Proprietor</asp:ListItem>
                                        <asp:ListItem>Common Partner</asp:ListItem>
                                        <asp:ListItem>Other Relationship</asp:ListItem>                                        
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherRelationship" runat="server" Text="If Other Relationship(Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherRelationship" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlBusinessOwnership" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessOwnership" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessOwnership" runat="server" Text="Business ownership"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessOwnership" runat="server" AutoPostBack="false">
                                      <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Owned by Self</asp:ListItem>
                                        <asp:ListItem>Family Owned</asp:ListItem>
                                        <asp:ListItem>By Others</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblLevelOfBusinessActivity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblLevelOfBusinessActivity" runat="server" Text="Level of Business Activity"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlLevelOfBusinessActivity" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Busy</asp:ListItem>
                                        <asp:ListItem>Empty / Vacant</asp:ListItem>
                                        <asp:ListItem>Locked</asp:ListItem>                                       
                                    </asp:DropDownList>                              
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNoOfEmployee" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployee" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoOfEmployee" runat="server" Text="No of employees"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmployee" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlBusinessEquipSighted" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessEquipSighted" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusinessEquipSighted" runat="server" Text="Business equipment sighted"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="chklBusinessEquipSighted" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                                        <asp:ListItem>Fax Machine</asp:ListItem>
                                        <asp:ListItem>Telex</asp:ListItem> 
                                        <asp:ListItem>Computer</asp:ListItem>
                                        <asp:ListItem>Photostat Machine</asp:ListItem> 
                                        <asp:ListItem>Other Equipment</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>                                       
                                    </asp:CheckBoxList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOtherBusinessEquipment" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherBusinessEquipment" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    
                                    
                                </table>
                                </asp:Panel>
                               
                       <asp:Panel ID="pnlPersonalDetailHead" runat="server" Width="100%" Visible="true">
                            <table>
                                <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblPersonalDetail" runat="server" Text="PERSONAL DETAILS"></asp:Label>
                                  </td>
                                 </tr>
                            </table>
                      </asp:Panel>                          
                                <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAppName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server">Applicant's Name(Mr./Ms./Mrs.)</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddress" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAddress">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblAddress" runat="server">Address</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtAddress" runat="server" Width="80%" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPhone" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblPhone">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblPhone" runat="server" SkinID="lblSkin">Phone</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblMobile">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblMobile" runat="server" SkinID="lblSkin">Mobile</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtMobile" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlEmail" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblEmail">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblEmail" runat="server" SkinID="lblSkin">Email</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" SkinID="txtSkin" Width="80%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDateOfBirth" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblDateOfBirth">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDOB" runat="server" SkinID="lblSkin">Date of Birth of Applicant</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtDOB" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgDOB" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlMaritalStatus" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblMaritalStatus">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblMaritalStatus" runat="server" SkinID="lblSkin">Marital Status</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                               <asp:DropDownList SkinID="ddlSkin" ID="ddlMaritalStatus" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Single</asp:ListItem>
                                                    <asp:ListItem>Married</asp:ListItem>
                                                    <asp:ListItem>Divorce</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNamePlateDisplay" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNamePlateDisplay">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNamePlateDisplay" runat="server" SkinID="lblSkin">Name displayed in name board of the society</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateDisplay" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblPersonContacted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblPersonContacted" runat="server">Person contacted</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtPersonContacted" runat="server" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                    
                                <asp:Panel ID="pnlRelationshipWithApp" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRelationshipWithApp">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRelationshipWithApp" runat="server" SkinID="lblSkin">Relationship with applicant</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td >
                                                <asp:TextBox ID="txtRelationshipWithApp" runat="server" SkinID="txtSkin" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlStayingSinceAtResi" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStayingSinceAtResi">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStayingSinceAtResi" runat="server" SkinID="lblSkin">Staying since at Resi</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtStayingSinceAtResi" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                            <asp:Panel ID="pnlOtherDetailsHead" runat="server" Width="100%" Visible="true">
                                    <table>
                                        <tr>
                                          <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                           <asp:Label SkinID="lblSkin"   ID="lblOthersDetails" runat="server" Text="OTHER DETAILS"></asp:Label>
                                          </td>
                                         </tr>
                                    </table>
                              </asp:Panel>                                    
                                
                                     <asp:Panel ID="pnlNameOfDematAcct" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfDematAcct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfDematAcct" runat="server" SkinID="lblSkin">Name of Demat Account(If Status is Yes)</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfDematAcct" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnlHavingDematAcwithOtherInstitution" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table2">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblHavingDematAcwithOtherInstitution" runat="server" SkinID="lblSkin">Having Demat Account With Other Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlHavingDematAcwithOtherInstitution" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem>NA</asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 
                                 <asp:Panel ID="pnlIfYesThenNameOfDP" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="Table3">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfYesThenNameOfDP" runat="server" SkinID="lblSkin">If Yes,Then Name Of The DP</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtIfYesThenNameOfDP" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlHavingSMEAccountWithOtherInstitution" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblHavingSMEAccountWithOtherInstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblHavingSMEAccountWithOtherInstitution" runat="server" SkinID="lblSkin">Having SME Account With Other Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlHavingSMEAccountWithOtherInstitution" runat="server" SkinID="ddlSkin">
                                                <asp:ListItem>NA</asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnlNameOfInstitution" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="" cellspacing="0" width="100%" id="tblNameOfInstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfInstitution" runat="server" SkinID="lblSkin">If Yes; Then Name Of The Institution</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfInstitution" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                        
                                <asp:Panel ID="pnlStatusOfDematAcct" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStatusOfDematAcct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStatusOfDematAcct" runat="server" SkinID="lblSkin">Status of Demat account</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlStatusOfDematAcct" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              
                                <asp:Panel ID="pnlDoBrokeOtherThanSSKI" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblDoBrokeOtherThanSSKI">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDoBrokeOtherThanSSKI" runat="server">
                                            Doing Broking through any Broker other than SSKI</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtDoBrokeOtherThanSSKI" runat="server" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlAttituteOfContactPerson" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblAttituteOfContactPerson">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblAttituteOfContactPerson" runat="server" SkinID="lblSkin">
                                            Attitute of the contact person</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlAttituteOfContactPerson" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Bad</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRating">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRating" runat="server" SkinID="lblSkin">
                                               Rating</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlRating" runat="server" AutoPostBack="false">
                                                  <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
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
                                
                                
                                
                                <asp:Panel ID="pnlOnVerifyingCAFirmLetterHeadOnllyHead" runat="server" Width="100%" Visible="true">
                                <table>
                                <tr>
                                <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                <asp:Label SkinID="lblSkin"   ID="lblOnVerifyingCAFirmLetterHeadOnlly" runat="server" Text="ON VERIFYING CA FIRM LETTER HEAD ONLY"></asp:Label>
                                 </td>
                                 </tr>
                                 </table>
                                 </asp:Panel>  
                                <asp:Panel ID="pnlNameOfAccount" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfAccount" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfAccount" runat="server" Text="Name of Account being opened"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfAccount" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlRequestNo" runat="server" Width="100%" Visible="true">
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
                                 <asp:Panel ID="pnlNameOfCAFirm" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfCAFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfCAFirm" runat="server" Text="Name of CA Firm that has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfCAFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlAddressOfCAFirm" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAddressOfCAFirm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAddressOfCAFirm" runat="server" Text="Address of CA Firm that has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAddressOfCAFirm" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlTelNoOfCAFirm" runat="server" Width="100%" Visible="true">
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
                                
                                <asp:Panel ID="pnlPersonVerificationOfCAHead" runat="server" Width="100%" Visible="true">
                                    <table>
                                    <tr>
                                    <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                    <asp:Label SkinID="lblSkin"   ID="lblPersonVerificationOfCA" runat="server" Text="CA FIRM NAME,ADDRESS & PERSON VERIFICATION"></asp:Label>
                                     </td>
                                     </tr>
                                     </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDoesFirmExistAtAddress" runat="server" Width="100%" Visible="true">
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
                                <asp:Panel ID="pnlIsFirmACAFirm" runat="server" Width="100%" Visible="true">
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
                                <asp:Panel ID="pnlNameOfPersonWhoIssuedCACertificate" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfPersonWhoIssuedCACertificate" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameOfPersonWhoIssuedCACertificate" runat="server" Text="Name of the Person who has issued the CA Certificate"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtNameOfPersonWhoIssuedCACertificate" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlIsPersonOneOfPractising" runat="server" Width="100%" Visible="true">
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
                                <asp:Panel ID="pnlWasPersonSpokenTo" runat="server" Width="100%" Visible="true">
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
                                <asp:Panel ID="pnlConfirmCACertificateIssued" runat="server" Width="100%" Visible="true">
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
                                 <asp:Panel ID="pnlIfInconclusiveReason" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfInconclusiveReason" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfInconclusiveReason" runat="server" Text="If inconclusive Reason/Remark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfInconclusiveReason" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlSupervisorName" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSupervisorName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblSupervisorName" runat="server" SkinID="lblSkin">Supervisor Name</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSupervisorName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                <asp:Panel ID="pnlSupervisorDate" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSupervisorDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label2" runat="server" SkinID="lblSkin">Date and Time</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSupervisorDate" runat="server" SkinID="txtSkin" ></asp:TextBox>
                                                <img id="imgSupervisorDate" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSupervisorDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                <asp:TextBox ID="txtSupervisorTime" runat="server" SkinID="txtSkin" MaxLength="5"
                                                    Width="4%"></asp:TextBox>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlSupervisorTimeType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                    </table>
                                </asp:Panel>                                
                                
                                <asp:Panel ID="pnlResiVerTelHead" runat="server" Width="100%" Visible="true">
                                    <table>
                                    <tr>
                                    <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                    <asp:Label SkinID="lblSkin"   ID="lblResidenceVerifiReport" runat="server" Text="RESIDENCE VERIFICATION REPORT"></asp:Label>
                                     </td>
                                     </tr>
                                     </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlSendDate" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblSendDate">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblSendDate" runat="server" SkinID="lblSkin">Send Date</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtSendDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                                                <img id="img3" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtSendDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlProduct" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblProduct">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblProduct" runat="server" SkinID="lblSkin">Product</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtProduct" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNameOfVerificationAgent" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNameOfVerificationAgent">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNameOfVerificationAgent" runat="server" SkinID="lblSkin">Name of verification Agent</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtNameOfVerificationAgent" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlResidenceAddress" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResidenceAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlResiPincode" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiPincode" runat="server" Text="Resi Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiPincode" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlResiTelNo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiTelNo" runat="server" Text="Resi Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlResiLandmark" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblResiLandmark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblResiLandmark" runat="server" Text="Resi Landmark"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtResiLandmark" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentAddress" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentAddress" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>    
                                <asp:Panel ID="pnlPermanentPincode" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentPincode" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentPincode" runat="server" Text="Permanent Pincode"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentPincode" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>      
                                <asp:Panel ID="pnlPermanentTelNo" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentTelNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblPermanentTelNo" runat="server" Text="Permanent Tel No"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtPermanentTelNo" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlBusiOccupationDtl" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblBusiOccupationDtl" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblBusiOccupationDtl" runat="server" Text="Business/Occupation Details"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtBusiOccupationDtl" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblrvComment" runat="server" Text="RV Comment"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"    ID="txtRvComment" MaxLength="750" TextMode="MultiLine"  onkeyPress="ValidateTextLength('verifier comments', this, 750);"  runat="server"  Width="488px"></asp:TextBox>                                   
                                    </td>
                                    </tr>
                                    
                                </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlObservation" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblObservation" runat="server" Text="Observation(Not to be asked to the customer)"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                               
                                <asp:Panel ID="pnlPlaceVisited" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table4">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblPlaceVisited" runat="server" SkinID="lblSkin">
                                                    Place Visited</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlPlaceVisited" runat="server" AutoPostBack="false">
                                                   <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Residence</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                    <asp:ListItem>Others</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                <asp:Panel ID="pnlIfOthersSpecify" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOthersSpecify" runat="server" Text="If Others (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOthersSpecify" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                                                
                                <asp:Panel ID="pnlNamePlateOfAppSighted" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblNamePlateOfAppSighted">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblNamePlateOfAppSighted" runat="server" SkinID="lblSkin">
                                                    Name Plate of Applicant Sighted</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateOfAppSighted" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               
                                <asp:Panel ID="pnlAreaOfResidence" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAreaOfResidence" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAreaOfResidence" runat="server" Text="Area of Residence"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAreaOfResidence" runat="server" MaxLength="100"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlLocatingAddress" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblLocatingAddress">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocatingAddress" runat="server" SkinID="lblSkin">
                                                    Locating Address</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingAddress" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Easy</asp:ListItem>
                                                    <asp:ListItem>Difficult</asp:ListItem>            
                                                    <asp:ListItem>Untraceable</asp:ListItem>  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlIfOfficeBusiActivity" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOfficeBusiActivity" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblIfOfficeBusiActivity" runat="server" Text="If Office are Business activity seen"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtIfOfficeBusiActivity" runat="server" MaxLength="50"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlDescriptionOfResi" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblDescriptionOfResi" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblDescriptionOfResi" runat="server" Text="General Description Of Resi."></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtDescriptionOfResi" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                <asp:Panel ID="pnlGeneralComments" runat="server" Width="100%" Visible="true">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralComments" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblGeneralComments" runat="server" Text="General Comments"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtGeneralComments" runat="server" width="488px" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlCommentsRemarkOfVerifierHead" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblCommentsRemarkOfVerifier" runat="server" Text="COMMENTS / REMARKS OF VERIFIER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                 <asp:Panel ID="pnlVerifierName" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblVerifierName">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblVerifierName" runat="server" SkinID="lblSkin">Verifier Name</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtVerifierName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>  
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlVerifierDate" runat="server" Width="100%" Visible="true">
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
                                
                                 <asp:Panel ID="pnlAttemptsHead" runat="server" Width="100%" Visible="true">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblpnlAttemptsHead" runat="server" Text="ATTEMPTS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>
                                
                                <asp:Panel ID="pnlAttempts" runat="server" Width="100%" Visible="true">
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
                                
                                <asp:Panel ID="pnlRemark" runat="server" Width="100%" Visible="true">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRemark">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblRemark" runat="server" SkinID="lblSkin">Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 750);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
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
                                </asp:Panel>
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
                                <asp:RegularExpressionValidator ID="revVerifierDate" runat="server" ControlToValidate="txtVerifierDate"
                                    Display="None" ErrorMessage="Please enter valid date format for Verifier." SetFocusOnError="True"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revVerifierTime" runat="server" ControlToValidate="txtVerifierTime"
                                    Display="None" ErrorMessage="Please enter valid time format for Verifier." SetFocusOnError="True"
                                    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="revSupervisorDate" runat="server" ControlToValidate="txtSupervisorDate"
                                    Display="None" ErrorMessage="Please enter valid date format for Supervisor."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSupervisorTime"
                                    Display="None" ErrorMessage="Please enter valid time format for Supervisor."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                               
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUsedPageSightDate"
                                    Display="None" ErrorMessage="Please enter valid date format for Used Page Sight Date."
                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="grValidate">
                                </asp:RegularExpressionValidator>
                                <asp:ValidationSummary ID="vsValidate" runat="server" ValidationGroup="grValidate"
                                    ShowMessageBox="True" ShowSummary="False" />
                            </asp:TableCell></asp:TableRow>
                    </asp:Table>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
