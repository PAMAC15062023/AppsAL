<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" CodeFile="EBC_Verification.aspx.cs" Inherits="CPV_EBC_EBC_Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function PreventCharacterToAdd1(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 254)
     {
       getControlsId.value = getControlsId.value.substring( 0, 254);            
       return false;
     }          
   }
   
   function PreventCharacterToAdd2(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 749)
     {
       getControlsId.value = getControlsId.value.substring( 0, 749);            
       return false;
     }          
   }
</script>
<fieldset ><legend class="FormHeading"> <asp:Label ID="lblHead" runat="server"></asp:Label> </legend>

<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" style="background-color:#E7F6FF">
   
<tr><td ></td><td >
 <asp:Table ID="tblBusiVerification" runat="server" Width="100%">
               <asp:TableRow ID="tblrowPlace" runat="server">
                <asp:TableCell ID="tblCellPlace" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder5" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder6" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder7" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder8" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder9" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder10" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder11" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder12" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder13" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder14" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder15" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder16" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder17" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder18" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder19" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder20" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder21" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder22" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder23" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder24" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder25" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder26" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder27" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder28" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder29" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder30" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder31" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder32" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder33" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder34" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder35" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder36" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder37" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder38" runat="server" EnableViewState="false"></asp:PlaceHolder>
                     <asp:PlaceHolder ID="PlaceHolder39" runat="server" EnableViewState="false"></asp:PlaceHolder>
                     <asp:PlaceHolder ID="PlaceHolder40" runat="server" EnableViewState="false"></asp:PlaceHolder>
                     <asp:PlaceHolder ID="PlaceHolder41" runat="server" EnableViewState="false"></asp:PlaceHolder>
                    </asp:TableCell>
                     </asp:TableRow>
                      <asp:TableRow ID="tblrow" runat="server">
    <asp:TableCell ID="tblCell" runat="server"> 
    <!--Start ErrorMessgage-->
     <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="true">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ></asp:Label>
        </td>        
        </tr>
        </table>
    </asp:Panel> 
   
     <asp:Panel ID="pnlDateTimeOfVerification" runat="server" Width="100%" Visible="true">
         <table cellpadding="0" cellspacing="0" border="0" id="tblDateTimeOfVerification" style="width:100%" runat="server">
            <tr>         
             <td class="TDWidth">
              <asp:Label SkinID="lblSkin" ID="lblDateTimeOfVerification" runat="server" Text="Date and Time Of Verification"></asp:Label>
               </td><td style="width:2%">:</td>
               <td >
               <asp:TextBox SkinID="txtSkin"  ID="txtDateOfVerification" runat="server" MaxLength="10" ></asp:TextBox>
               <img id="img3"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" />   [dd/MM/yyyy]
               <asp:TextBox SkinID="txtSkin" Width="5%" MaxLength="5" ID="txtTimeOfVerification" runat="server" ></asp:TextBox>   [hh:mm]
               <asp:DropDownList SkinID="ddlSkin" ID="ddlDateTimeOfVerification" runat="server"  AutoPostBack="false">
               <asp:ListItem>AM</asp:ListItem>
               <asp:ListItem>PM</asp:ListItem>                                    
               </asp:DropDownList>
               </td>
              </tr>
         </table>
     </asp:Panel>
     <asp:Panel ID="pnlLanNo" runat="server" Width="100%" Visible="true">
                                    <table id="tblLanNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblLanNo" runat="server" Text="Lan No./Ref No"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtLanNo" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlDateAndTime" runat="server" Width="100%" Visible="true">
                                    <table id="tblDateAndTime" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblDateAndTime" runat="server" Text="Date"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" ID="txtDateAndTime" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               
   
            <asp:Panel ID="pnlEmployeeName" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblEmpName" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtEmpName" runat="server" MaxLength="100" ReadOnly="true"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlAddress" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblAddress" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddress" runat="server" MaxLength="100" TextMode="MultiLine" ReadOnly="true" onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtAddress');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtAddress');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameofPersonContacted" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblNameofPersonContacted" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNameofPersonContacted" runat="server" Text="Name of Person Contacted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNameofPersonContacted" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelationShipEmp" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblRelationshiptoEmployee" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRelationshiptoEmp" runat="server" Text="Relationship to Employee"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRelationshipToEmp" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlTeleNo" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblTelePhoneNo" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblTeleNo" runat="server" Text="Telephone number" ></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtTeleNo" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoOfyear" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYear" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfYear" runat="server" Text="Number of Year"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNoOfYear" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlResidenceType" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceType" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblResidenceType" runat="server" Text="Residence Type"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropdownList SkinID="ddlSkin" ID="ddlResidenceType" runat="server" Visible="true"  >
                <asp:ListItem> Own </asp:ListItem>
                <asp:ListItem> Spouse </asp:ListItem>
                <asp:ListItem> Parental </asp:ListItem>
                <asp:ListItem> Rented </asp:ListItem>
                <asp:ListItem> Relatives </asp:ListItem>
                <asp:ListItem> Shared </asp:ListItem>
                <asp:ListItem> Hostel </asp:ListItem>
                </asp:DropdownList>
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlLandMark" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblLandMark" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLandMark" runat="server" Text="Land Mark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLAndMark" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlAccessbility" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblAccessbility" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAccessblity" runat="server" Text="Accesbility(Approach to House)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAccessbility" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
              
            <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblLocalty" style="width:100%" runat="server" >
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lbllocality" runat="server" Text="Localty"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtlocalty" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           
           </asp:Panel>
          
           <asp:Panel ID="pnlFamily" runat="server" Width="100%" Visible="true">
          
    <table width="100%" >
               <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label1" runat="server" Text="Relationship"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtRelation" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
                <table width="100%">
                <tr>
                <td class="TDWidth">
                
                <asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Occupation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOccupation" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
               </table>
               <table>
                <tr>
                <td>
                <asp:Button ID="addbtn" Text="Add new" ValidationGroup="valFamily" SkinID = "btnAddNewSkin" runat="server" OnClick="addbtn_Click"/>
                 </td>
                </tr>
                </table>
                <table width="100%">
                <tr>
                <td colspan="3">
                
                 <asp:GridView ID="gvRelationship" runat="server" AutoGenerateColumns="false"
                 BackColor="White" BorderColor="Transparent"
                    BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    ForeColor="Black" GridLines="None" BorderStyle="Solid" Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Width="87%"
                   OnRowDeleting="gvRelationship_RowDeleting" OnRowEditing="gvRelationship_RowEditing">
                   <FooterStyle BackColor="#D0D5D8" Height="20px"  ForeColor="White" />
                    <RowStyle BackColor="#E5E5E5"  />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" ForeColor="Black" Height="20px" Font-Names="Arial" Font-Size="8pt" />
                    <AlternatingRowStyle BackColor="White" />
                                               <Columns>
                                                <asp:BoundField DataField="Relationship" HeaderText="Relationship" SortExpression="Relationship" />
                                                 <asp:BoundField DataField="Occupation" HeaderText="Occupation" SortExpression="Occupation" />
                                                  <asp:TemplateField>
                                               <ItemTemplate>
                                              <asp:LinkButton ID="lnkTemplate1" runat="server" CausesValidation="False"
                                                   CommandName="Edit" ><img src="../../images/icon_Edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                        
                                                </ItemTemplate>
                                              </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemStyle VerticalAlign="Top" />
                                                     <ItemTemplate>
                                                  <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                                    CommandName="Delete"><img src="../../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                                
                                                   </ItemTemplate>
                                                   </asp:TemplateField>
                                                   
                                              
                                                  </Columns>
                                                </asp:GridView>
                </td>
                </tr>
                
           </table>
          
           </asp:Panel>
          
           <asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblPermanentAdd" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblpermanentAdd" runat="server" Text="Permanent Address (if different from address mentioned above)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPermanentAdd" runat="server" MaxLength="100" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtPermanentAdd');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtPermanentAdd');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlTeleNo1" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblTeleNo" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="Telephone Number"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtTelNo" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
             
            <asp:Panel ID="pnlNeighbourName" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblneighbourName" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNeighbourName" runat="server" Text="Neighbour Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtneighbourName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           
            <asp:Panel ID="pnlneighbourFeedBack" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblneighbourFeedback" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNeighbourFeedBack" runat="server" Text="Neighbour FeedBack on Employee"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtNeighbourFeedBackOn" runat="server"  TextMode="MultiLine" onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtNeighbourFeedBackOn');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtNeighbourFeedBackOn');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlRemk" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblRemk" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRemk" runat="server" Text="Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRemk" runat="server" MaxLength="100" TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd2('ctl00_C1_txtRemk');" onkeyup="return PreventCharacterToAdd2('ctl00_C1_txtRemk');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <!----------Finish of RV Panels--------->
           <asp:Panel ID="pnlEmployeeECN" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblEmployeeECN" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEmployeeECN" runat="server" Text="Employee ECN"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtEmpECN" runat="server" MaxLength="100" ReadOnly="true"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlGapIdentified" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblGapIdentified" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblGapIdentified" runat="server" Text="Gap Identified"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtGapIdentified" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlPeroidOfGap" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblPeriodOfGap" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPeriodOfGap" runat="server" Text="Period Of Gap"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPeriodOfGap" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            
           <asp:Panel ID="pnlReasonOfGap" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblReasonOfGap" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblReasonOfGap" runat="server" Text="Reason Of Gap"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtReasonOfGap" runat="server"  TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtReasonOfGap');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtReasonOfGap');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlAddressDuringGap" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblAddressDuringGap" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAddressDuringGap" runat="server" Text="Address During Gap"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtAddressDuringGap" runat="server"   TextMode="MultiLine"  onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtAddressDuringGap');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtAddressDuringGap');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
                <asp:Panel ID="pnlpoliceVerificationGap" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblPoliceVerificationGap" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPoliceVerificationGap" runat="server" Text="Police verification Gap"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtPoliceVerificationGap" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
           </table>
           
                </asp:Panel>
                <asp:Panel ID="pnlPoliceVerification" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblPoliceVerification" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPoliceVerification" runat="server" Text="Police verification "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtpoliceVerification" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
                     `
           <!----------End of GAP Panels--------->
                             
            <asp:Panel ID="pnlRespondentDesignation" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblRespondentDesignation" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRespondentDesignation" runat="server" Text="Respondent Designation "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtRespondentDesignation" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
              <asp:Panel ID="pnlOrganisationName" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOrganisationName" runat="server" Text="Organisation Name "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtOrganisationName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
                    <asp:Panel ID="pnlEmpDates" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEmpDates" runat="server" Text="Employee Dates "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtEmpDates" runat="server" MaxLength="50" ></asp:TextBox>
                <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtEmpDates.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlLastPositionheld" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblLastPositionheld" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLastPositionheld" runat="server" Text="Last Position "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtLastPosition" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
                      <asp:Panel ID="pnlReportingManager" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblReportingManager" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblReprotingManager" runat="server" Text="Reporting Manager"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtReportingManager" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlStatus" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblDStatus" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblStatus" runat="server" Text="Status "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlStatus" runat="server" DataSourceID="SdsStatus" DataTextField="STATUS_NAME" DataValueField="Case_status_id"  AutoPostBack="false"></asp:DropDownList>
                </td>
                </tr>
           </table>
           </asp:Panel>
                 
                 <!----------End of EMP Panels--------->  
                  
            <asp:Panel ID="pnlDOB" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server" Text="Date of Birth "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtDOB" runat="server" MaxLength="100" ReadOnly="true"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel> 
             <asp:Panel ID="pnlVerificatorName" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVerificatorName" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVerificatorName" runat="server" Text="Verificator Name "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtVerificatorName" runat="server" MaxLength="100" ReadOnly="true"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameOfInstitution" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfInstitution" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblInstitutionName" runat="server" Text="Institution Name "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtInstitutionName" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel> 
           <asp:Panel ID="pnlDatesAttended" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblDatesAttented" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblDatesAttended" runat="server" Text="Dates Attended "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtDatesdAttended" runat="server" MaxLength="50" ></asp:TextBox>
                
                </td>
                </tr>
           </table>
           </asp:Panel> 
                  <asp:Panel ID="pnlQualificationGained" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="tblQualificationGained" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblQualificationGained" runat="server" Text="Qualification Gained "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtQualificationGained" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            
                  <asp:Panel ID="pnlPreviousjobDetail" runat="server" Width="100%" Visible="true">
           <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width:100%" runat="server">
           
           <tr>
            <td class="TDWidth" >
                <asp:Label SkinID="lblSkin" ID="lblPreviousjobDetail" runat="server" Text="Previous Job Detail "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" Width="80%" ID="txtpreviuosJobDetail" runat="server" MaxLength="100" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd1('ctl00_C1_txtpreviuosJobDetail');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtpreviuosJobDetail');"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlSubmit" runat="server" Width="100%"  Visible="true">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server"  SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="ValDateTime"/>       
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click" />
        </td>
      </tr>
       <asp:HiddenField ID="hidCaseID" runat="server" />
                                <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
                                <asp:HiddenField ID="hidMode" runat="server" />
                                <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
    </table>
    
    
   </asp:Panel>              
            </asp:TableCell></asp:TableRow>
                    </asp:Table>
    &nbsp;
   
                  </td>
                  </tr>
<tr><td style="height: 28px"></td><td style="width: 754px; height: 28px;">
    <asp:RequiredFieldValidator ID="VAlVeriDate" runat="server" ErrorMessage="Please Enter Date" ControlToValidate="txtDateOfVerification" Display="None" SetFocusOnError="True" ValidationGroup="ValDateTime"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="valTime" runat="server" ErrorMessage="Please Enter the Time" Display="None" SetFocusOnError="True" ValidationGroup="ValDateTime" ControlToValidate="txtTimeOfVerification"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RvalDate" runat="server" ErrorMessage="Please enter valid date format for verification." ControlToValidate="txtDateOfVerification" ValidationGroup="ValDateTime" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" Display="None"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RvalTime" runat="server" ErrorMessage="Please enter valid Time format for verification." ControlToValidate="txtTimeOfVerification" ValidationGroup="ValDateTime" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ValidationGroup="ValDateTime" ShowSummary="False" />
    <asp:HiddenField ID="hidIndex1" runat="server" />
    <asp:RequiredFieldValidator ID="valtxtRelationship" runat="server" Display="None"
        ErrorMessage="Relationship should not be blank" SetFocusOnError="True" ValidationGroup="valFamily" ControlToValidate="txtRelation"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="valsummfamilyDetail" runat="server" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="valFamily" />
    <asp:SqlDataSource ID="SdsStatus" runat="server" 
    SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_Name] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) order by case_status_id" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
    </asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="valoccupation" runat="server" ErrorMessage="Occupation should not be blank" Display="None" SetFocusOnError="True" ValidationGroup="valFamily" ControlToValidate="txtOccupation"></asp:RequiredFieldValidator>
</td><td style="height: 28px"><asp:HiddenField ID="hdnTransStart" runat="server" /></td></tr>  
      
                    </table>
                 </fieldset>    
</asp:Content>

