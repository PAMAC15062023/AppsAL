<%@ Page Language="C#"  MasterPageFile="CEL_MasterPage.master" AutoEventWireup="true" CodeFile="CEL_Cellular_Verification_FEData_Entry.aspx.cs" Theme="SkinFile" Inherits="CPV_Cellular_CEL_Cellular_Verification_FEData_Entry" %>
<asp:content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<fieldset><legend class="FormHeading">Cellular FE Verification Entry</legend>
    <table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
    <tr><td style="width: 250px; height: 25px;"><asp:Label id="lblmessage" runat="server" font-bold="True" forecolor="Red" Visible="False" ></asp:Label></td>
    </tr>
    
    
  <tr>
  <td  align="left" valign="top" style="width: 250px; height: 14px;">
      Case Id</td>
        <td align="left" valign="top" style="height: 14px; width: 6px;">:</td>
      <td align="left" valign="top" style="height: 14px; width: 185px;">
      <asp:TextBox ID="txtcaseid" runat="server" SkinID="txtSkin" Width="119px" ReadOnly="True"></asp:TextBox></td>
      <td align="left" valign="top" style="width: 207px; height: 14px">
   <asp:Label ID="Label1" text="Ref No" runat="server" Width="91px" Height="12px"></asp:Label></td>
   <td align="left" valign="top" style="height: 14px;">:</td>
   <td style="height: 14px"><asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" Width="109px" ReadOnly="True"></asp:TextBox></td>
   <td align="left" valign="top" style="height: 14px; width: 233px;">
   </td>
  </tr>
  
  <tr>
  <td  align="left" valign="top" style="width: 250px; height: 25px;">
       Name of the Applicant </td>
        <td align="left" valign="top" style="height: 14px; width: 6px;">:</td>
      <td align="left" valign="top"  colspan="5" style="height: 14px; width: 250px;">
      <asp:TextBox ID="txtNameOftheApplicant" runat="server" SkinID="txtSkin" Width="342px" ReadOnly="True"></asp:TextBox></td>
  </tr>
 
 <tr>
  <td  align="left" valign="top" style="width: 250px; height: 25px;">
      Address of the Applicant </td>
        <td align="left" valign="top" style="height: 14px; width: 6px;">:</td>
      <td align="left" valign="top"  colspan="5" style="height: 14px; width: 250px;">
      <asp:TextBox ID="txtAddressoftheApplicant" runat="server" SkinID="txtSkin" Width="342px" ReadOnly="True"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td  align="left" valign="top" style="width: 250px; height: 25px;">
       Name of person contacted</td>
        <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
      <td align="left" valign="top"  colspan="5" style="height: 25px; width: 250px;">
      <asp:TextBox ID="txtNameofPersonContacted" runat="server" SkinID="txtSkin" Width="184px"></asp:TextBox></td>
  </tr>

  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Designation of person contacted</td>
   <td align="left" valign="top" style="height: 17px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 17px; width: 250px;">
   <asp:TextBox ID="txtDesignationofpersoncontacted" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
    
  <tr>
  <td  align="left" valign="top" style="width: 250px; height: 25px;">
       Residence Address</td>
        <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
      <td align="left" valign="top"  colspan="5" style="height: 25px; width: 250px;">
      <asp:TextBox ID="txtResidenceAddress" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Resi Pincode</td>
   <td align="left" valign="top" style="height: 17px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 17px; width: 250px;">
   <asp:TextBox ID="txtResiPincode" runat="server"  MaxLength="10" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Resi Tel No</td>
   <td align="left" valign="top" style="height: 24px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 24px; width: 250px;">
   <asp:TextBox ID="txtResiTelNo" runat="server" SkinID="txtSkin"  MaxLength="11" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Resi Landmark</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtResiLandmark" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Landmark observed</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtLandmarkObserved" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
   
   <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Name of Company</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 28px; width: 250px;">
   <asp:TextBox ID="txtNameOfCompany" runat="server" SkinID="txtSkin"  MaxLength="11" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Address of company</td>
   <td align="left" valign="top" style="height: 17px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 17px; width: 250px;">
   <asp:TextBox ID="txtAddressOfCompany" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Business Tel No</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtBusinessTelNo" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
   
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Type of Office</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" style="width: 185px; height: 28px">
   <asp:DropDownList ID="ddlTypeOfOffice" SkinID="ddlSkin" runat="server" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Business Center" Value="Business Center"></asp:ListItem>
                    <asp:ListItem Text="Office Complex" Value="Office Complex"></asp:ListItem>
                    <asp:ListItem Text="Industry/Factory" Value="Industry/Factory"></asp:ListItem>
                    <asp:ListItem Text="Residence cum Office" Value="Residence cum Office"></asp:ListItem>
                    <asp:ListItem Text="Shop" Value="Shop"></asp:ListItem>
                     <asp:ListItem Text="Clinic" Value="Clinic"></asp:ListItem>
                    <asp:ListItem Text="Shared Office" Value="Shared Office"></asp:ListItem>
                    <asp:ListItem Text="Independent Office" Value="Independent Office"></asp:ListItem>
                    <asp:ListItem Text="Small Scale/Shed" Value="Small Scale/Shed"></asp:ListItem>
                    <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                    <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                    <asp:ListItem Text="Shared" Value="Shared"></asp:ListItem>
                    <asp:ListItem Text="Undeveloped" Value="Undeveloped"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                    </asp:DropDownList>
   </td>
   <td align="left" valign="top" style="width: 207px; height: 28px">
   <asp:Label ID="lblTypeOfOfficeOtherSpecify" text="If Others Specify" runat="server" Width="91px"></asp:Label></td>
   <td align="left" valign="top" style="height: 28px;">:</td>
   <td style="height: 28px"><asp:TextBox ID="txtIfOtherSpecify" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox></td>
   <td align="left" valign="top" style="height: 28px; width: 233px;">
   </td>
   </tr>
   
    <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Type Of Organization</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" style="width: 185px; height: 28px">
   <asp:TextBox ID="txtTypeOfOrganization" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox>
   </td>
   <td align="left" valign="top" style="width: 207px; height: 28px">
    If Other Specify  </td>
   <td align="left" valign="top" style="height: 28px;">:</td>
   <td><asp:TextBox ID="txtiftypeoforgSpecify" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox></td>
   <td align="left" valign="top" style="height: 28px; width: 233px;">
   </td>
   </tr>  
     
      
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Number of employees</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtNoOfEmployee" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
   
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Annual Turnover</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 28px; width: 250px;">
   <asp:TextBox ID="txtAnnualTurnover" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
   
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Email</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtEmail" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
   
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Address Of Neighbour</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtAddressOfNeighbour" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Comment Of Neighbour</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlCommentOfNeighbour"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Positive</asp:ListItem>
   <asp:ListItem>Negative</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Color Of the Building</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtColoroftheBuilding" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Nearest railway station</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtNearestRailwayStation" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Nearest bus stop</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtNearestBusStop" runat="server" SkinID="txtSkin" Width="185px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Type of Company</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlTypeOfCompany"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Govt</asp:ListItem>
   <asp:ListItem>PSU</asp:ListItem>
   <asp:ListItem>MNC</asp:ListItem>
   <asp:ListItem>Pvt.Ltd</asp:ListItem>
   <asp:ListItem>Public Ltd</asp:ListItem>
   <asp:ListItem>Proprietorship</asp:ListItem>
   <asp:ListItem>Partnership</asp:ListItem>
   <asp:ListItem>HUF</asp:ListItem>
   <asp:ListItem>Others</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Qualification</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" style="width: 185px; height: 28px">
   <asp:DropDownList ID="ddlQualification" SkinID="ddlSkin" runat="server" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Matric" Value="Matric"></asp:ListItem>
                    <asp:ListItem Text="Undergraduate" Value="Undergraduate"></asp:ListItem>
                    <asp:ListItem Text="Post graduate" Value="Post graduate"></asp:ListItem>
                    <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem>
                    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                    </asp:DropDownList>
   </td>
   <td align="left" valign="top" style="width: 207px; height: 28px">
   If Others Specify</td>
   <td align="left" valign="top" style="height: 28px;">:</td>
   <td><asp:TextBox ID="txtIfQualificationOtherSpecify" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox></td>
   <td align="left" valign="top" style="height: 28px; width: 233px;">
   </td>
   </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Date of Birth</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtDateOfBirth" runat="server" SkinID="txtSkin" Width="150px"></asp:TextBox>
   <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateOfBirth.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]
   </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Applicant is usually available at</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtApplicantAvailableAt" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Staying since at Resi</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtStayingSinceAtResi" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   User of Sim</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtUserOfSim" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Total work experience</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtTotalWorkExperience" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Name of the User</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 28px; width: 250px;">
   <asp:TextBox ID="txtNameOftheUser" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Vodafone number applied for</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtVodafoneNumberAppliedFor" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Approximate Area(in sq ft)</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtApproximateArea" runat="server" SkinID="txtSkin" Width="193px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Nature of Business</td>
   <td align="left" valign="top" style="height: 28px; width: 6px;">:</td>
   <td align="left" valign="top" style="width: 185px; height: 28px">
   <asp:DropDownList ID="ddlNatureofBusiness" SkinID="ddlSkin" runat="server" >
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem>
                    <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem>
                    <asp:ListItem Text="Trading" Value="Trading"></asp:ListItem>
                    <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                    <asp:ListItem Text="Trade shopkeeper" Value="Trade shopkeeper"></asp:ListItem>
                    <asp:ListItem Text="Broker" Value="Broker"></asp:ListItem>
                    <asp:ListItem Text="STD PCO" Value="STD PCO"></asp:ListItem>
                    <asp:ListItem Text="other" Value="other"></asp:ListItem>
                    </asp:DropDownList>
   </td>
   <td align="left" valign="top" style="width: 207px; height: 28px">
   If Others Specify</td>
   <td align="left" valign="top" style="height: 28px;">:</td>
   <td style="height: 28px"><asp:TextBox ID="txtIfNatureOfBusinessOtherSpecify" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox></td>
   <td align="left" valign="top" style="height: 28px; width: 233px;">
   </td>
   </tr>
   
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Number of Years in Current Employment</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtNumberOfYearsinCurrentEmployment" runat="server" SkinID="txtSkin" Width="192px"></asp:TextBox></td>
  </tr>
  
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Entry Permitted</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlEntryPermitted"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Yes</asp:ListItem>
   <asp:ListItem>No</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
    
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Assets</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
    <asp:CheckBoxList ID="ckhAssests" runat="server" SkinID="chkListSkin" RepeatDirection="horizontal" Height="51px" Width="495px" RepeatLayout="Flow">
                    <asp:ListItem>Air Conditioner</asp:ListItem>
                    <asp:ListItem>Television</asp:ListItem> 
                    <asp:ListItem>Two Wheeler</asp:ListItem> 
                    <asp:ListItem>Refrigerator</asp:ListItem>
                    <asp:ListItem>Car</asp:ListItem>
                    <asp:ListItem>Music System</asp:ListItem>
                    <asp:ListItem>PC</asp:ListItem>
                    <asp:ListItem>Fax</asp:ListItem>
                    <asp:ListItem>Xerox</asp:ListItem> 
                    <asp:ListItem>Canis</asp:ListItem> 
                    <asp:ListItem>Tables</asp:ListItem>
                    <asp:ListItem>Stock</asp:ListItem>
                    <asp:ListItem>Business counter</asp:ListItem>
                    <asp:ListItem>Stock shelf</asp:ListItem>
                    <asp:ListItem>Printer</asp:ListItem>
                </asp:CheckBoxList>   
  </td>
  </tr>
  
   <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
     <asp:Label ID="lblInterior" Text="Describe Interior of Premises" runat="server" Width="154px" SkinID="lblSkin" ></asp:Label></td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
    <asp:CheckBoxList ID="chkDescribeInteriorofPremises" runat="server" SkinID="chkListSkin" RepeatDirection="horizontal" Width="488px">
                    <asp:ListItem>Sofa</asp:ListItem>
                    <asp:ListItem>Clean</asp:ListItem> 
                    <asp:ListItem>Painted</asp:ListItem> 
                    <asp:ListItem>Carpeted</asp:ListItem>
                    <asp:ListItem>Venetian Blinds</asp:ListItem>
                    <asp:ListItem>Curtains</asp:ListItem>
                    </asp:CheckBoxList>   
  </td>
  </tr>
  
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Business board sigghted</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlBusinessboardsigghted"  runat="server" SkinID="ddlSkin">
    <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Yes</asp:ListItem>
   <asp:ListItem>No</asp:ListItem>
   <asp:ListItem>Visible</asp:ListItem>
   <asp:ListItem>Non Visible</asp:ListItem>
   <asp:ListItem>Others</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Locating the address</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlLocatingtheaddress"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Easy</asp:ListItem>
   <asp:ListItem>Difficult</asp:ListItem>
   <asp:ListItem>Untraceable</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Describe Exterior of Premises</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtDescribeExteriorofPremises" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
       
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Sim card purchases from</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtSimcardpurchasesfrom" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
  
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Are you interested in making payments through credit card or direct debit account ? - Yes / No</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtCreditCard" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   If Yes Tick payment mode</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtPaymentMode" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Preferred mode of communication</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtPerferredmodeofcommunication" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Preferred language of communication</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtlanguageofcommunication" runat="server" SkinID="txtSkin" Width="200px"></asp:TextBox></td>
  </tr>
  
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Business Activity</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlBusinessActivity"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>High</asp:ListItem>
   <asp:ListItem>Medium</asp:ListItem>
   <asp:ListItem>Low</asp:ListItem>
   <asp:ListItem>None</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
    
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Owned Value</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtOwnedValue" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Rental Value</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtRentedValue" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Occupation</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtOccupation" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   if Retired</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtIfRetired" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Pan Card Number</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtPanCardNumber" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Bill To</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtBillTo" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Alternate Contact number</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtAlternateNo" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Simcard received</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtSimcardReceived" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Welcome Kit Delivered</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtwelcomeKitDelivered" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Bill Plan confirmed</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:TextBox ID="txtBillPlanConfirmed" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   First Bill explanation</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtFirstBillExplanation" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Payment Options</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtpaymentOptions" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Standing Instructions</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtStandingInstructions" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   ECS</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtECS" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   E-Bill</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtEBill" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Photograph identified</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtPhotographIdentified" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Billing address is owned / Rented</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtBillingAddress" runat="server" SkinID="txtSkin" Width="204px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Locality</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlLocality"  runat="server" SkinID="ddlSkin">
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
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Business stock seen</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlBusinessStockSeen"  runat="server" SkinID="ddlSkin">
    <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>High</asp:ListItem>
   <asp:ListItem>Medium</asp:ListItem>
   <asp:ListItem>Low</asp:ListItem>
   <asp:ListItem>Yes</asp:ListItem>
   <asp:ListItem>No</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Type of Job/emp</td>
   <td align="left" valign="top" style="height: 25px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 25px; width: 250px;">
   <asp:DropDownList ID="ddlTypeOfJob"  runat="server" SkinID="ddlSkin">
   <asp:ListItem>NA</asp:ListItem>
   <asp:ListItem>Contract Worker</asp:ListItem>
   <asp:ListItem>Permanent</asp:ListItem>
   <asp:ListItem>Probation</asp:ListItem>
   <asp:ListItem>Temporary Worker</asp:ListItem>
   </asp:DropDownList>
  </td>
  </tr>

  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Reason for applicant not met</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtReasonforapplicantnotmet" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Any other business in same city / another city</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtAnyotherbusinessinsamecity" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
  Payment responsibility</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtPaymentresponsibility" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Previous number</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtPreviousNumber" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Billing Average</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtBillingAverage" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Recommended number of connections by Field Executive</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtRecomNumByFE" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   Vodafone mobile used by Self</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtVodafoneMobileUsedBySelf" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   No. of connections required</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtNoOfConnections" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   COCP/IOIP Connections</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtCOCP" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 23px;">
   Date and Time Of Verification</td>
   <td align="left" valign="top" style="height: 23px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 23px; width: 250px;">
   <asp:TextBox ID="txtDateTime" runat="server" SkinID="txtSkin" Width="150px" MaxLength="10"></asp:TextBox>
   <img id="date" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDateTime.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" />[dd/MM/yyyy]
    <asp:TextBox  ID="txttime" runat="server" SkinID="txtSkin" Width="51px" MaxLength="5"></asp:TextBox>
     <asp:DropDownList ID="ddldatetime" runat="server">
     <asp:ListItem>AM</asp:ListItem>
     <asp:ListItem>PM</asp:ListItem>
     </asp:DropDownList>
     
  </td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   FE Remark</td>
   <td align="left" valign="top" style="height: 22px; width: 6px;">:</td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   <asp:TextBox ID="txtFERemark" runat="server" SkinID="txtSkin" Width="203px"></asp:TextBox></td>
  </tr>
  
  <tr>
  <td align="left" valign="top" style="width: 250px; height: 25px;">
   </td>
   <td align="left" valign="top" style="height: 22px; width: 6px;"></td>
   <td align="left" valign="top" colspan="5" style="height: 22px; width: 250px;">
   </td> 
  </tr>
     
     <tr>
       <td valign="top" style="width: 111px">
           <asp:LinkButton ID="lnkCellularVerificationEntry" runat="server" OnClick="lnkCellularVerificationEntry_Click">[Supervisor Rating]</asp:LinkButton></td>
       <td valign="top" style="width: 6px">
        </td>
       <td valign="top" style="width: 185px">
         <asp:Button ID="btnSubmit"  runat="server" SkinID="btnSaveSkin" Text="Submit" OnClick="btnSubmit_Click"/>
         <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/></td>
      </tr>   
     
     
 </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
</fieldset>
</asp:content>


