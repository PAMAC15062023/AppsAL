<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" Theme="skinFile" CodeFile="KYC_BUSINESS_VERI.aspx.cs" Inherits="CPV_KYC_KYC_BUSINESS_VERI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
 <fieldset>
        <legend class="FormHeading">Business Verification </legend>
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
                                <asp:PlaceHolder ID="PlaceHolder51" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder52" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder53" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder54" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder55" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder56" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder57" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder58" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder59" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder60" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder61" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder62" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder63" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder64" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder65" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder66" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder67" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder68" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder69" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder70" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder71" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder72" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder73" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder74" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder75" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="PlaceHolder76" runat="server"></asp:PlaceHolder>
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
                                 <asp:Panel ID="pnlDetailsOfCustomer" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDetailsOfCustomer" runat="server" Text="DETAILS OF CUSTOMER"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlCompanyType" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlEntityType" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlNameOfFirm" runat="server" Width="100%" Visible="false">
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
                                
                                 <%--////////add by kamal ddl 28-10-09///////////--%>
                                  <asp:Panel ID="pnlConstitution" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblConstitution">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblConstitution" runat="server" SkinID="lblSkin">
                                                    Constitutions</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlConstitution" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Prop</asp:ListItem>
                                                    <asp:ListItem>Partnership</asp:ListItem>
                                                    <asp:ListItem>Pvt Ltd Co</asp:ListItem>            
                                                    <asp:ListItem>Public Ltd Co</asp:ListItem> 
                                                    <asp:ListItem>HUF</asp:ListItem>
                                                    <asp:ListItem>Others (pls specify</asp:ListItem>            
                                                    <asp:ListItem>Individual</asp:ListItem>  
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                               <asp:Panel ID="pnlLocalityType" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblLocalityType">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocalityType" runat="server" SkinID="lblSkin">
                                                    Locality Type</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityType" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Residential</asp:ListItem>
                                                    <asp:ListItem>Commercial</asp:ListItem>
                                                    <asp:ListItem>Industrial</asp:ListItem>            
                                                    <asp:ListItem>Business Centre</asp:ListItem> 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                    <asp:Panel ID="pnlWhetherVisitingCardobtained" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblWhetherVisitingCardobtained">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblWhetherVisitingCardobtained" runat="server" SkinID="lblSkin">
                                                    Whether Visiting Card obtained</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlWhetherVisitingCardobtained" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                               <asp:Panel ID="pnlFurniture" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblfurniture" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblfurniture" runat="server" Text="Furniture/fixtures/office equipments seen or was it a make shift arrangement"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtfurniture" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                               <asp:Panel ID="pnlReasonfornothavingavalidBusinessproof" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonfornothavingavalidBusinessproof" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblReasonfornothavingavalidBusinessproof" runat="server" Text="Reason for not having a valid address / Business proof"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonfornothavingavalidBusinessproof" runat="server" MaxLength="255"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>  
                                
                                 <asp:Panel ID="pnlIfNotRecommended" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblIfNotRecommended">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfNotRecommended" runat="server" SkinID="lblSkin">
                                                   Observations of Employee conducting CPV if Not recommended</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlIfNotRecommended" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Recommended</asp:ListItem>
                                                    <asp:ListItem>Address not traceable</asp:ListItem>
                                                    <asp:ListItem>Detail mismatch</asp:ListItem>
                                                    <asp:ListItem>Applicant does not exist</asp:ListItem>            
                                                    <asp:ListItem>Defaulter/Bad market reputation</asp:ListItem> 
                                                    <asp:ListItem>Entry not allowed</asp:ListItem>            
                                                    <asp:ListItem>Others</asp:ListItem> 
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblIfOtherRecommended" runat="server" SkinID="lblSkin">
                                                   if Recommended OtherSpecify</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                            <asp:TextBox SkinID="txtSkin"  ID="txtIfOtherRecommended" runat="server" MaxLength="255">
                                            </asp:TextBox>                                    
                                        </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                 <asp:Panel ID="pnlLocatingAddress" runat="server" Width="100%" Visible="false">
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
                                
                                
                                 <%--///Added by kamal matekar for Hdfc_Liab PDf format//--%>

                                <asp:Panel ID="pnlLocalityTypeForFemu" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table8">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblLocalityTypeForFemu" runat="server" SkinID="lblSkin">Locality Type</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityTypeForFemu" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Lower Middle Class</asp:ListItem>
                                                    <asp:ListItem>Middle Class</asp:ListItem>
                                                    <asp:ListItem>Upper Middle Class</asp:ListItem>
                                                    <asp:ListItem>Posh</asp:ListItem>
                                                    <asp:ListItem>Village Area</asp:ListItem>
                                                    <asp:ListItem>Slums</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                 <asp:Panel ID="pnlDoNeighbourShopsKnowTheCustomer" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table9">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblDoNeighbourShopsKnowTheCustomer" runat="server" SkinID="lblSkin">Do Neighbour/Neighboring shops or offices know the customer</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlDoNeighbourShopsKnowTheCustomer" runat="server" AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAddressOfNeighbour" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table10">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblAddressOfNeighbour" runat="server" SkinID="lblSkin">Name & Address Neighbours</asp:Label></td>
                                             <td style="width:2%">:</td>
                                            <td >
                                                <asp:TextBox ID="txtAddressOfNeighbour" runat="server" SkinID="txtSkin" Width="80%" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                                             
                               <asp:Panel ID="pnlOfficeEquipmentSeen" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeEquipmentSeen" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOfficeEquipmentSeen" runat="server" Text="Office Equipments Seen"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                     <asp:CheckBoxList SkinID="chkListSkin" ID="chkOfficeEquipmentSeen" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                                        <asp:ListItem>A/C</asp:ListItem>
                                        <asp:ListItem>Computers</asp:ListItem>
                                        <asp:ListItem>Fax</asp:ListItem>
                                        <asp:ListItem>Photocopier</asp:ListItem>
                                        <asp:ListItem>Telephone</asp:ListItem>
                                        <asp:ListItem>Machinery</asp:ListItem>
                                        <asp:ListItem>Others(specify)</asp:ListItem>                            
                                    </asp:CheckBoxList>                              
                                    </td>
                                    </tr>
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOfficeEquipmentSeenOther" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtOfficeEquipmentSeenOther" Width="80%" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>

                           <%--///ended by kamal matekar for Hdfc_Liab PDf format//--%>
                                
                                
                                 <%--added by TCM client releted by santosh--%>
                                <asp:Panel ID="pnlWebsite" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblWebsite" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblWebsite" runat="server" Text="Website"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtwebsite" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckSince" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckSince" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckSince" runat="server" Text="Company Registration Check Since"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckSince" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckSinceRegNo" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckSinceRegNo" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckSinceRegNo" runat="server" Text="Company Registration Check Regd No."></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckSinceRegNo" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlCompRegiCheckRemark" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblCompRegiCheckRemark" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblCompRegiCheckRemark" runat="server" Text="Company Registration Check Remarks"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtCompRegiCheckRemark" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlLocProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblLocProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblLocProfile" runat="server" Text="Site Visit Location Profile & general description"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLocProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlbldgProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblbldgProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblbldgProfile" runat="server" Text="Site Visit Building Profile with general description"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtbldgProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfile" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfile" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfile" runat="server" Text="Site Visit Floor Profile Right neighbour"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfile" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileLeftNeigh" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfileLeftNeigh" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileLeftNeigh" runat="server" Text="Site Visit Floor Profile left neighbour"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileLeftNeigh" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileFlrAb" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileFlrAb" runat="server" Text="Site Visit Floor Profile Floor Above"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileFlrAb" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlFlrProfileFlrBl" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblFlrProfileFlrBl" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblFlrProfileFlrBl" runat="server" Text="Site Visit Floor Profile Floor Below"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtFlrProfileFlrBl" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlNameBoardOutOffice" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameBoardOutOffice" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameBoardOutOffice" runat="server" Text="Name Board Details Outside office"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameBoardOutOffice" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlNameBoardLobbyArea" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNameBoardLobbyArea" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNameBoardLobbyArea" runat="server" Text="Name Board Details Lobby Area"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameBoardLobbyArea" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlAssoCompany" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAssoCompany" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAssoCompany" runat="server" Text="Associate comapny/other occupation"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAssoCompany" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                  <asp:Panel ID="pnlGenInterior" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblGenInterior" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblGenInterior" runat="server" Text="General Interior Profile"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtGenInterior" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                   <asp:Panel ID="pnlNoWorkstations" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblNoWorkstations" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblNoWorkstations" runat="server" Text="No. of Workstations"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoWorkstations" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlOwnerCabin" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblOwnerCabin" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblOwnerCabin" runat="server" Text="Whether Owner has a separate cabin"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOwnerCabin" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnllandloard" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tbllandloard" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lbllandloard" runat="server" Text="Landlord(if any)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtlandloard" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyResi" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyResi" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyResi" runat="server" Text="Propery valuation Residential"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyResi" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyComm" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyComm" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyComm" runat="server" Text="Propery valuation Commercial"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyComm" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                
                                <asp:Panel ID="pnlProperyShop" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblProperyShop" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblProperyShop" runat="server" Text="Propery valuation Shoppinng"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtProperyShop" runat="server"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <%--///////////////////////end of code/////////////////////--%>
                                                        
                                <asp:Panel ID="pnlBusinessAddress" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlBusinessPincode" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlBusinessTelNo" runat="server" Width="100%" Visible="false">
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
                                 
                                <asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false"> 
                                
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table4">
                                        <tr>
                                       
                                        <td class="TDWidth">
                                           <asp:Label SkinID="lblSkin" ID="Label1" runat="server">Proprietor/Partner</asp:Label>
                                           </td>                                            
                                           <td style="width:2%">:</td>
                                           <td>
                                     <asp:DropDownList SkinID="ddlSkin" ID="ddlproperietorpartener" runat="server" AutoPostBack="false">
                                        <asp:ListItem>NA</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList> 
                                    </td>
                                    </tr>
                                    </table>
                                    
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
                                <asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlNoOfYearsInCurrentEmployment" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlBusinessAddressVerification" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblBusinessAddressVerification" runat="server" Text="BUSINESS ADDRESS VERIFICATION"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>        
                                <asp:Panel ID="pnlPremiseLocation" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlProminentLandmark" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlAddressVerifiedIs" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlHowLongInBusiness" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlAreaPremises" runat="server" Width="100%" Visible="false">
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
                                
                                <asp:Panel ID="pnlAnyOthDet" runat="server" Width="100%" Visible="false">
                                <table cellpadding="0" cellspacing="0" border="0" id="tblAnyOthDet" style="width:100%" runat="server"> 
                                    <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblAnyOthDet" runat="server" Text="Any Othere Details"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtAnyOthDet" runat="server" Width="80%" MaxLength="500"></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel> 
                                
                                <asp:Panel ID="pnlOwnershipOfPremises" runat="server" Width="100%" Visible="false">
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
                               
                                  <asp:Panel ID="pnlLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblLevelOfBusinessActivityAndNatureOfBusiness" runat="server" Text="LEVEL OF BUSINESS ACTIVITY AND NATURE OF BUSINESS"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel>           
                                <asp:Panel ID="pnlTypeOfPremise" runat="server" Width="100%" Visible="false">
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
                                  
                                <asp:Panel ID="pnlContactPerson" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
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
                                        <asp:ListItem>Professional</asp:ListItem>
                                        <asp:ListItem>Manufacturer</asp:ListItem>
                                        <asp:ListItem>Trader</asp:ListItem>
                                        <asp:ListItem>Shopkeeper</asp:ListItem>
                                        <asp:ListItem>Service Provider</asp:ListItem>
                                        <asp:ListItem>Comm Agent</asp:ListItem>
                                        <asp:ListItem>Broker</asp:ListItem>
                                        <asp:ListItem>Tutor Personal Care</asp:ListItem>
                                        <asp:ListItem>LIC Agent</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>  
                                    <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtNatureBuss" runat="server" MaxLength="300"></asp:TextBox>                            
                                    </td>
                                  </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlFirmSignBoardSighted" runat="server" Width="100%" Visible="false">
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
                             
                                <asp:Panel ID="pnlSignBoardSightedRemark" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlDocumentSightedWithNameandAddressofthefirm" runat="server" Width="100%" Visible="false">
                                 <table>
                                 <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblDocumentSightedWithNameandAddressofthefirm" runat="server" Text="DOCUMENTS SIGHTED WITH NAME AND ADDRESS OF THE FIRM"></asp:Label>
                                  </td>
                                 </tr>
                                  </table>
                               </asp:Panel> 
                                <asp:Panel ID="pnlTypeOfDocSighted" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlIfOtherDocSightedRemark" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlUsedPageSightDate" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlIssuedTo" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlInitialInvoiceSightedNo" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlInitialInvoiceSightedDate" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlInitialInvoiceSightedIssuedTo" runat="server" Width="100%" Visible="false">
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
                                
                                <asp:Panel ID="pnlThirdPartyInvoiceNo" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlThirdPartyInvoiceDate" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlThirdPartyInvoiceIssuedBy" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlThirdPartyAddress" runat="server" Width="100%" Visible="false">
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
                                  
                                <asp:Panel ID="pnlRelationshipBtnEntity" runat="server" Width="100%" Visible="false">
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
                                   <asp:Panel ID="pnlBusinessOwnership" runat="server" Width="100%" Visible="false">
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
                                     <tr>
                                    <td class="TDWidth">
                                        <asp:Label SkinID="lblSkin" ID="lblplspecify" runat="server" Text="If Other (Please Specify)"></asp:Label>
                                    </td> 
                                    <td style="width:2%">:</td>           
                                    <td >
                                    <asp:TextBox SkinID="txtSkin"  ID="txtplsSpecify" runat="server" ></asp:TextBox>                                    
                                    </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlLevelOfBusinessActivity" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlNoOfEmployee" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlBusinessEquipSighted" runat="server" Width="100%" Visible="false">
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
                               <asp:Panel ID="pnlPersonalDetailHead" runat="server" Width="100%" Visible="false">
                            <table>
                                <tr>
                                  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                   <asp:Label SkinID="lblSkin"   ID="lblPersonalDetail" runat="server" Text="PERSONAL DETAILS"></asp:Label>
                                  </td>
                                 </tr>
                            </table>
                      </asp:Panel>                          
                                <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlAddress" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlPhone" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlEmail" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlDateOfBirth" runat="server" Width="100%" Visible="false">
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
                                 <asp:Panel ID="pnlMaritalStatus" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlNamePlateDisplay" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlRelationshipWithApp" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlStayingSinceAtResi" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblStayingSinceAtResi">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblStayingSinceAtResi" runat="server" SkinID="lblSkin">Staying since at Business</asp:Label></td>
                                           <td style="width:2%">:</td>
                                            <td>
                                                <asp:TextBox ID="txtStayingSinceAtResi" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                  <asp:Panel ID="pnlOtherDetailsHead" runat="server" Width="100%" Visible="false">
                                    <table>
                                        <tr>
                                          <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
                                           <asp:Label SkinID="lblSkin"   ID="lblOthersDetails" runat="server" Text="OTHER DETAILS"></asp:Label>
                                          </td>
                                         </tr>
                                    </table>
                              </asp:Panel>                                    
                                
                                     <asp:Panel ID="pnlNameOfDematAcct" runat="server" Width="100%" Visible="false">
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
                                 <asp:Panel ID="pnlHavingDematAcwithOtherInstitution" runat="server" Width="100%" Visible="false">
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
                                
                                 
                                 <asp:Panel ID="pnlIfYesThenNameOfDP" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlHavingSMEAccountWithOtherInstitution" runat="server" Width="100%" Visible="false">
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
                                 <asp:Panel ID="pnlNameOfInstitution" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlStatusOfDematAcct" runat="server" Width="100%" Visible="false">
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
                              
                                <asp:Panel ID="pnlDoBrokeOtherThanSSKI" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlAttituteOfContactPerson" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlBuisinessActivity" runat="server" Width="100%" Visible="false">
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table5">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="Label4" runat="server" SkinID="lblSkin">
                                            Business Activity</asp:Label></td>
                                            <td style="width:2%">:</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlbusinessActivity" runat="server"
                                                    AutoPostBack="false">
                                                    <asp:ListItem>NA</asp:ListItem>
                                                    <asp:ListItem>Good</asp:ListItem>
                                                    <asp:ListItem>Normal</asp:ListItem>
                                                    <asp:ListItem>Bad</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                    <asp:ListItem>High</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Low</asp:ListItem>
                                                    <asp:ListItem>None</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
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
                              
         
    <table cellpadding="0" cellspacing="0" border="0" id="tblCityLimit" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblCityLimit" runat="server"  Text="City Limit"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin"  ID="ddlCityLimit" runat="server" AutoPostBack="false">
                        <asp:ListItem>ICL</asp:ListItem>
                        <asp:ListItem>OCL</asp:ListItem>
                        <asp:ListItem>Beyound OCL</asp:ListItem>
                     </asp:DropDownList>
    </td>
    </tr>
   </table>           
         
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
                                                <asp:TextBox ID="txtVerifierName" runat="server" SkinID="txtSkin" ></asp:TextBox></td>  
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
                                  <asp:Panel ID="pnlSupervisorName" runat="server" Width="100%" Visible="false">
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
                                <asp:Panel ID="pnlSupervisorDate" runat="server" Width="100%" Visible="false">
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
                                                <td>
                                                SubStatus</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                1st Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate1" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat1" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat1" runat="server" Text=""></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                2nd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate2" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat2" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat2" runat="server" Text=""></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                3rd Attempt</td>
                                            <td >
                                                <asp:TextBox ID="txtDate3" runat="server" Width="100" SkinID="txtSkin"></asp:TextBox>
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
                                                <td>
                                                <asp:DropDownList ID="ddlSubSat3" runat="server" DataSourceID="sdsFE" DataTextField="Description" DataValueField="Description" SkinID="ddlSkin">
                                                </asp:DropDownList>
                                                <asp:Label SkinID="lblSkin" ID="lblsat3" runat="server" Text=""></asp:Label>
                                        </td>
                                        </tr>
                                    </table>
                                </asp:Panel>  
                                
                                 <asp:Panel ID="pnlRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tblRemark">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblTeleRemark" runat="server" SkinID="lblSkin">Tele Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeyPress="ValidateTextLength('Remark', this, 1000);" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </asp:Panel> 
                                 <asp:Panel ID="pnloverallRemark" runat="server" Width="100%" Visible="false">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="Table6">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label ID="lblremark" runat="server" SkinID="lblSkin">Remark</asp:Label>
                                            </td>
                                           <td style="width:2%">:</td>
                                            <td>
                                             <asp:TextBox ID="txtoverallRemark" TextMode="MultiLine" runat="server" SkinID="txtSkin" Width="488px"></asp:TextBox></td>
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
                                              <asp:HiddenField ID="hdnTransStart" runat="server" />
                                               <asp:HiddenField ID="hidMode" runat="server" />
                                            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
                                </asp:Panel>
                              
                                 </asp:TableCell></asp:TableRow>
                            </asp:Table>
                                </td>
                                </tr>
                                </table>
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
     <asp:SqlDataSource ID="sdsFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
         ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SubStatus_Master;1"
         SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        
        
 </fieldset>
</asp:Content>
