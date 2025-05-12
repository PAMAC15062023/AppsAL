<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="CC_ResidenceVerificationTelephonic.aspx.cs" Inherits="CPV_CC_CC_ResidenceVerificationTelephonic" %>
<asp:Content ID="Contant1" ContentPlaceHolderID="C1" runat="server">
<script type="text/javascript" language="javascript">
       <!--
       
       function ClientValidate(source, arguments)
       {
          //alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       
       function ValidateAttempts(source, arguments)
       {
           if((document.aspnetForm.ctl00$C1$txtTime1stCall.value.length == 0) && (document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length == 0) && (document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length ==0) && (document.aspnetForm.ctl00$C1$txtTime4thCall.value.length ==0) && (document.aspnetForm.ctl00$C1$txtTime5thCall.value.length ==0))
           {
                arguments.IsValid = false;
           }
           else
           {
                arguments.IsValid = true;
           }
       }
       function ValidateTime1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length >0)
          {    
            //alert("time");         
            if(document.aspnetForm.ctl00$C1$txtTelNo1stCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo1stCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel1(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo1stCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks1stCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks1stCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark1(source, arguments)
       {           
           if(document.aspnetForm.ctl00$C1$ddlRemarks1stCall.value != 'Select')
           {              
                if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length ==0)
                {
                
                    document.aspnetForm.ctl00$C1$txtTime1stCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //2nd Telecalling
       function ValidateTime2(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo2ndCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo2ndCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel2(source, arguments)
       {
           //alert(document.aspnetForm.ctl00$C1$txtTel2.value);    
           if(document.aspnetForm.ctl00$C1$txtTelNo2ndCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark2(source, arguments)
       {           
           if(document.aspnetForm.ctl00$C1$ddlRemarks2ndCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime2ndCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime2ndCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //3rd Telecalling
       function ValidateTime3(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo3rdCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo3rdCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel3(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo3rdCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark3(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks3rdCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime3rdCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime3rdCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //4th Telecalling
       function ValidateTime4(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime4thCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo4thCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo4thCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel4(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo4thCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks4thCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks4thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark4(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks4thCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime4thCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime4thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       //5th Telecalling
       function ValidateTime5(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime5thCall.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtTelNo5thCall.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtTelNo5thCall.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateTel5(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtTelNo5thCall.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$ddlRemarks5thCall.value == 'Select')
                {
                    document.aspnetForm.ctl00$C1$ddlRemarks5thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateRemark5(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$ddlRemarks5thCall.value != 'Select')
           {                
                if(document.aspnetForm.ctl00$C1$txtTime5thCall.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtTime5thCall.focus();
                    arguments.IsValid=false;
                }
           }
       }
// -->


</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">RESIDENCE TELE VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
 <!--Start Heading-->
<asp:Panel ID="pnlResiVerTelHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblResidenceVerifiReport" runat="server" Text="RESIDENCE TELE VERIFICATION REPORT"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>
    <!--END Heading-->
<!--- Start of Personal Detail-->
<asp:Table ID="tblResiTelVeri" runat="server"  Width="100%">
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
    
    
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow ID="tblrow" runat="server" >
<asp:TableCell ID="tblCell" runat="server" >
<%--asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label--%>
<asp:Panel ID ="pnlAppName" runat="server" Width="100%">
<table id="tblAppName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAppName" runat="server" Text="Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtAppName" runat="server" ReadOnly="True" MaxLength="150"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlRefNo" runat="server" Width="100%" Visible="false">
<table id="tblRefNo"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRefNo" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlInitiationDate" runat="server" Width="100%" Visible="false">
<table id="tblInitiationDate" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAgencyCode" runat="server" Width="100%" Visible="false">
<table id="tblAgencyCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAgencyCode" runat="server" Text="Agency Code" >
</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAgencyCode" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

    <!--END Personal Detail-->
  <!--Start Address Detail Head-->
  <asp:Panel ID="pnlAddressDetail" runat="server" Width="100%" Visible="false"> 
  <table>
  <tr>
  <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
  <asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblAddressDetail" runat="server" Text="ADDRESS DETAIL"></asp:Label>
  </td>
  </tr>
  </table>
  </asp:Panel>
  <!--Start Address Detail Head--> 
<!--Start Address Detail-->


<asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPersonContacted" runat="server" Text="Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<%--<asp:DropDownList ID="ddlPersonContacted" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Applicant" Value="Applicant"></asp:ListItem>
        <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
        <asp:ListItem Text="Family Member" Value="Family Member"></asp:ListItem>
        <asp:ListItem Text="Friend" Value="Friend"></asp:ListItem>
        <asp:ListItem Text="Neighbour" Value="Neighbour"></asp:ListItem>
        <asp:ListItem Text="Security" Value="Security"></asp:ListItem>
        <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
    </asp:DropDownList>--%>
    <asp:TextBox SkinID="txtSkin"   ID="txtPersonContacted" runat="server" MaxLength="100"></asp:TextBox>

</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlContactedNo" runat="server" Width="100%" Visible="false">
<table id="tblContactedNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblContactedNo" runat="server" Text="Contacted No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtContactedNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPPNo" runat="server" Width="100%" Visible="false">
<table id="tblPPNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth" >
<asp:Label SkinID="lblSkin"   ID="lblPPNo" runat="server" Text="PP.No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td style="height: 24px" >
<asp:TextBox SkinID="txtSkin"   ID="txtPPNo" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDetails" runat="server" Width="100%" Visible="false">
<table id="tblDetails" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDetails" runat="server" Text="Office Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtDetails" TextMode="MultiLine" runat="server" MaxLength="300"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAddressResi" runat="server" Width="100%" Visible="false">
<table id="tblAddressResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddressResi" runat="server" Text="Address(Residence)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAddressResi" runat="server" Width="80%" MaxLength="300"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPinCode" runat="server" Width="100%" Visible="false">
<table id="tblPinCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>

<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtPinCode" runat="server" MaxLength="10"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlLandmarkObserved" runat="server" Width="100%" Visible="false">
<table id="tblLandmarkObserved" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLandmarkObserved" runat="server" Text="Landmark Observed"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtLandmarkObserved" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPermanentAddress" runat="server" Width="100%" Visible="false">
<table id="tblPermanentAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPermanentAddress" runat="server" Text="Permanent Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtPermanentAddress" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAddressPPLocation" runat="server" Width="100%" Visible="false">
<table id="tblAddressPPLocation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddressPPLocation" runat="server" Text="Address (PP Location)"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtAddressPPLocation" runat="server" Width="80%" MaxLength="25"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--End Address Detail-->
<!--Start If Applicant has been Contacted Head-->
<asp:Panel ID="pnlIfApplicantHasBeenContacted" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblIfApplicantHasBeenContacted" runat="server" Text="IF APPLICANT HAS BEEN CONTACTED"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End If Applicant has been Contacted Head-->
<!--Start If Applicant has been Contacted-->


<asp:Panel ID="pnlTimeCurrResi" runat="server" Width="100%" Visible="false">

<table id="tblTimeCurrResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTimeCurrResi" runat="server" Text="Time at curr resi"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtTimeCurrYrs" runat="server"  MaxLength="2"></asp:TextBox>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrYrs" runat="server" Text="Yrs"></asp:Label>
</td>            
<td>
<asp:TextBox SkinID="txtSkin" ID="txtTimeCurrMths" runat="server"  MaxLength="2"></asp:TextBox>
<asp:Label SkinID="lblSkin" ID="lblTimeCurrMths" runat="server" Text="Mths"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlMailingAddress" runat="server" Width="100%" Visible="false">
<table id="tblMailingAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMailingAddress" runat="server" Text="Mailing address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlMailingAddress" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Residence" Value="Residence"></asp:ListItem>
<asp:ListItem Text="Office" Value="Office"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResiIs" runat="server" Width="100%" Visible="false">
<table id="tblResiIs" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResiIs" runat="server" Text="Residence is"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlResiIs" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
<asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
<asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
<asp:ListItem Text="Company Accomodation" Value="Company Accomodation"></asp:ListItem>
<asp:ListItem Text="With Parents" Value="With Parents"></asp:ListItem>
<asp:ListItem Text="With Relatives" Value="With Relatives"></asp:ListItem>
<asp:ListItem Text="With Friends" Value="With Friends"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResiCumOffice" runat="server" Width="100%" Visible="false">
<table id="tblResiCumOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResiCumOffice" runat="server" Text="Resi Cum Office"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlResiCumOffice" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOfficePhoneNoExtn" runat="server" Width="100%" Visible="false">
<table id="tblOfficePhoneNoExtn" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOfficePhoneNoExtn" runat="server" Text="Office Phone No & Extn"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtOfficePhoneNoExtn" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNameOfCompany" runat="server" Width="100%" Visible="false">
<table id="tblNameOfCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfCompany" runat="server" Text="Name Of Company"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox SkinID="txtSkin" Width="60%"  ID="txtNameOfCompany" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDesignation" runat="server" Width="100%" Visible="false">
<table id="tblDesignation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDesignation" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTimeCurrentEmployment" runat="server" Width="100%" Visible="false">
<table id="tblTimeCurrentEmployment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmployment" runat="server" Text="Time at Current Employment"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeCurrentEmploymentYrs" runat="server"  MaxLength="2"></asp:TextBox>

<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmploymentYrs" runat="server" Text="Yrs"></asp:Label>
</td>            
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeCurrentEmploymentMths" runat="server"  MaxLength="2"></asp:TextBox>

<asp:Label SkinID="lblSkin"   ID="lblTimeCurrentEmploymentMths" runat="server" Text="Mths."></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNOB" runat="server" Width="100%" Visible="false">
<table id="tblNOB" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNOB" runat="server" Text="NOB"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNOB" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--End If Applicant has been Contacted-->
<!--Start If SomeOne other than the applicant is Contacted Head-->
<asp:Panel ID="pnlIfOtherPersonNameContacted" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblIfOtherPersonNameContacted" runat="server" Text="IF SOMEONE OTHER THAN THEN APPLICANT IS CONTACTED"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End If SomeOne other than the applicant is Contacted Head-->
<!--Start If SomeOne other than the applicant is Contacted-->

<asp:Panel ID="pnlNameOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblNameOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameOfPersonContacted" runat="server" Text="Name Of Person Contacted"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%"  ID="txtNameOfPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRelationship" runat="server" Width="100%" Visible="false">
<table id="tblRelationship" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRelationship" runat="server" Text="Relationship"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRelationship" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDOBApp" runat="server" Width="100%" Visible="false">
<table id="tblDOBApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDOBApp" runat="server" Text="Date of Birth of applicant"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDOBApp" runat="server" MaxLength="50"></asp:TextBox>
<img id="ImgDOBApp"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOBApp.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTimeatCurrResi" runat="server" Width="100%" Visible="false">
<table id="tblTimeatCurrResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTimeatCurrResi" runat="server" Text="Time at curr resi"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTimeatCurrResi" runat="server" MaxLength="10"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAppAvailable" runat="server" Width="100%" Visible="false">
<table id="tblAppAvailable"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAppAvailable" runat="server" Text="Applicant is usually available at"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAppAvailable" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAgeApproxApp" runat="server" Width="100%" Visible="false">
<table id="tblAgeApproxApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAgeApproxApp" runat="server" Text="Age/ Approx age of applicant"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAgeApproxApp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNewDetailObt" runat="server" Width="100%" Visible="false">
<table id="tblNewDetailObt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNewDetailObt" runat="server" Text="New Details Obtained"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNewDetailObt" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--End of If SomeOne other than the applicant is Contacted-->

<!--Start of Rating Head-->
<asp:Panel ID="pnlRating" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblRating" runat="server" Text="RATING"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End of Rating Head-->
<!--Start of Rating-->


<asp:Panel ID="pnlAddrConfirmation" runat="server" Width="100%" Visible="false">
<table id="tblAddrConfirmation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddrConfirmation" runat="server" Text="Address Confirmation"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlAddrConfirmation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Not Confirmed" Value="Not Confirmed"></asp:ListItem>
<asp:ListItem Text="Confirmed" Value="Confirmed"></asp:ListItem>
<asp:ListItem Text="Refused to provide" Value="Refused to provide"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlContactability" runat="server" Width="100%" Visible="false">
<table id="tblContactability"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblContactability" runat="server" Text="Contactability"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlContactability" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlConfirmationApplication" runat="server" Width="100%" Visible="false">
<table id="tblConfirmationApplication"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblConfirmationApplication" runat="server" Text="Confirmation of Application"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlConfirmationApplication" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Applied" Value="Applied"></asp:ListItem>
<asp:ListItem Text="Not Applied" Value="Not Applied"></asp:ListItem>
<asp:ListItem Text="Not Known" Value="Not Known"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlProfile" runat="server" Width="100%" Visible="false">
<table id="tblProfile" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblProfile" runat="server" Text="Profile"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlProfile" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
<asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
<asp:ListItem Text="Good" Value="Good"></asp:ListItem>
<asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
<asp:ListItem Text="Average" Value="Average"></asp:ListItem>
<asp:ListItem Text="Failure" Value="Failure"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReputation" runat="server" Width="100%" Visible="false">
<table id="tblReputation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblReputation" runat="server" Text="Reputation"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlReputation" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>
<asp:ListItem Text="Unable to Confirm" Value="Unable to Confirm"></asp:ListItem>
<asp:ListItem Text="Excellent" Value="Excellent"></asp:ListItem>
<asp:ListItem Text="Good" Value="Good"></asp:ListItem>
<asp:ListItem Text="Bad" Value="Bad"></asp:ListItem>
<asp:ListItem Text="Average" Value="Average"></asp:ListItem>
<asp:ListItem Text="Failure" Value="Failure"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNegmatch" runat="server" Width="100%" Visible="false">
<table id="tblNegmatch" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNegmatch" runat="server" Text="Negmatch"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlNegmatch" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem>NA</asp:ListItem>
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDetailsNegmatch" runat="server" Width="100%" Visible="false">
<table id="tblDetailsNegmatch" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDetailsNegmatch" runat="server" Text="Details of Negmatch"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDetailsNegmatch" runat="server" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlOverallAssessment" runat="server" Width="100%" Visible="false">
<table id="tblOverallAssessment"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOverallAssessment" runat="server" Text="Overall Assessment"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlOverallAssessment" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="RCC Request" Value="RCC Request"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="Neutral"></asp:ListItem>
<asp:ListItem Text="Not Recommended" Value="Not Recommended"></asp:ListItem>
<asp:ListItem Text="Recommended" Value="Recommended"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDirCheck" runat="server" Width="100%" Visible="false">
<table id="tblDirCheck"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDirCheck" runat="server" Text="Directory Check"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlDirCheck" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="NA" Value="NA"></asp:ListItem>
<asp:ListItem Text="W01 - Both Match" Value="W01 - Both Match"></asp:ListItem>
<asp:ListItem Text="W02 - Both Mismatch" Value="W02 - Both Mismatch"></asp:ListItem>
<asp:ListItem Text="W03 - Name Match Address Mismatch" Value="W03 - Name Match Address Mismatch"></asp:ListItem>
<asp:ListItem Text="W04 - Address Match Name Mismatch" Value="W04 - Address Match Name Mismatch"></asp:ListItem>
<asp:ListItem Text="W05 - Number Not Found in Web check, Invalid No" Value="W05 - Number Not Found in Web check, Invalid No"></asp:ListItem>
<asp:ListItem Text="W06 - PVT Operator" Value="W06 - PVT Operator"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReasonsforAssessment" runat="server" Width="100%" Visible="false">
<table id="tblReasonsforAssessment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblReasonsforAssessment" runat="server" Text="Reasons for the above assessment"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtReasonsforAssessment" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlCPVAgentName" runat="server" Width="100%" Visible="false">
<table id="tblCPVAgentName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCPVAgentName" runat="server" Text="CPV Agent's Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCPVAgentName" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDateofVerification" runat="server" Width="100%" Visible="false">
<table id="tblDateofVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateofVerification" runat="server" Text="Date of Verification"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDateofVerification" runat="server"></asp:TextBox>
<img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateofVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
</td>
</tr>
</table>
</asp:Panel>

<!--End of Rating-->
<!---Start Of Additional Fields----->
<asp:Panel ID="pnlSpecialInstructions" runat="server" Width="100%" Visible="false">
<table id="tblSpecialInstructions" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSpecialInstructions" runat="server" Text="Special Instructions"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSpecialInstructions" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlIsOfficeAreaNegativeArea" runat="server" Width="100%" Visible="false">
<table id="tblIsOfficeAreaNegativeArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblIsOfficeAreaNegativeArea" runat="server" Text="Is Office Area is in a Negative Area"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlIsOfficeAreaNegativeArea" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
    <asp:ListItem>NA</asp:ListItem>
    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
    <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlIsResidenceAddressNegativeArea" runat="server" Width="100%" Visible="false">
<table id="tblIsResidenceAddressNegativeArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblIsResidenceAddressNegativeArea" runat="server" Text="Is Residence Address Is in a Negative Area"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlIsResidenceAddressNegativeArea" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
    <asp:ListItem>NA</asp:ListItem>
     <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
    <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNumberofYearsatcurrentaddress" runat="server" Width="100%" Visible="false">
<table id="tblNumberofYearsatcurrentaddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNumberofYearsatcurrentaddress" runat="server" Text="Number of Years at current address"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNumberofYearsatcurrentaddress" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNumberofResidentatcurrentaddress" runat="server" Width="100%" Visible="false">
<table id="tblNumberofResidentatcurrentaddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNumberofResidentatcurrentaddress" runat="server" Text="Number of Resident at current address"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNumberofResidentatcurrentaddress" runat="server" MaxLength="10"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlEmployerAddress" runat="server" Width="100%" Visible="false">
<table id="tblEmployerAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblEmployerAddress" runat="server" Text="Employer's Address"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtEmployerAddress" Width="80%" runat="server" MaxLength="255"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDesignationofApplicantBusiness" runat="server" Width="100%" Visible="false">
<table id="tblDesignationofApplicantBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDesignationofApplicantBusiness" runat="server" Text="Designation of Applicant Business"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDesignationofApplicantBusiness" Width="80%" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBusinessContactNo" runat="server" Width="100%" Visible="false">
<table id="tblBusinessContactNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblBusinessContactNo" runat="server" Text="Business Contact No.& Extn.(If Any)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtBusinessContactNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDept" runat="server" Width="100%" Visible="false">
<table id="tblDept" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDept" runat="server" Text="Dept."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDept" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="false">
<table id="tblMob" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMob" runat="server" Text="Mobile No."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtMob" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%-- New Field Added By Sunny Chauhan : Start>--%>
<asp:Panel ID="pnlNameofApplicantConfirmedatgivenPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblNameofApplicantConfirmedatgivenPhoneNo1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNameofApplicantConfirmedatgivenPhoneNo1" runat="server" Text="Name of Applicant Confirmed at given PhoneNo"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
 <asp:DropDownList ID="ddlNameofApplicantConfirmedatgivenPhoneNo1" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr> 
</table>
</asp:Panel> 

<asp:Panel ID="pnlCDNameCon" runat="server" Width="100%" Visible="false">
<table id="tblNameofApplicantConfirmedatgivenPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameofApplicantConfirmedatgivenPhoneNo" runat="server" Text="CD ROM (Name Confirmed)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlNameofApplicantConfirmedatgivenPhoneNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblMismatchedInAddTelNo" runat="server" Text="If No (Then Update the Details)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <%--asp:DropDownList ID="ddlMismatchedInAddTelNo" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employer Ph.No." Value="Employer Ph.No."></asp:ListItem>               
    </asp:DropDownList--%>
    <asp:TextBox SkinID="txtSkin" ID="txtMismatchedInAddTelNo" runat="server" MaxLength="150"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlMisMatch" runat="server" Width="100%" Visible="false">
<table id="tblMisMatch" cellpadding="0" cellspacing="0" style="width: 100%">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblMisMatch" runat="server" Text="Mismatched in"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlmismatch" runat="server" AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employment Ph.No." Value="Employer Ph.No."></asp:ListItem>               
</asp:DropDownList>

 <%--<asp:DropDownList ID ="ddlMismatch" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Residence Address" Value="Residence Address"></asp:ListItem>
        <asp:ListItem Text="Employer Address" Value="Employer Address"></asp:ListItem>
         <asp:ListItem Text="Residence Ph.No." Value="Residence Ph.No."></asp:ListItem>
        <asp:ListItem Text="Employment Ph.No." Value="Employer Ph.No."></asp:ListItem>               
    </asp:DropDownList>--%>
</td>
</tr> 
</table>
</asp:Panel> 
<%-- New Field Added By Sunny Chauhan : End>--%>
<%-- New Field Added By Sunny Chauhan : Start>--%>
<asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
<table id="tblDirectoryCheck" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDirectoryCheck" runat="server" Text="CD ROM(Address Confirmed)"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList SkinID="ddlSkin" ID="ddlDirectoryCheck" runat="server" >
<asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
<asp:ListItem Text="No" Value="No"></asp:ListItem>
<asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
</asp:DropDownList>
</td>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCDROMAddress" runat="server" Text="If No (Then Update the Details)"></asp:Label>
</td>
<td style="width:0.5%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtNoReason" runat="server" MaxLength="150"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%-- New Field Added By Sunny Chauhan : End>--%>
<%--<asp:Panel ID="pnlTeleCallerName" runat="server" Width="100%" Visible="false">
<table id="tblTeleCallerName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTeleCallerName" runat="server" Text="Tele Caller Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlTeleName" runat = "server" AutoPostBack="true" SkinID="ddlSkin"></asp:DropDownList>
<%--<asp:DropDownList ID="ddlTelecallerName" runat="server" AppendDataBoundItems="true"  AutoPostBack="false" SkinID="ddlSkin">
<%--<asp:ListItem Value="0">---SELECT---</asp:ListItem>--%>
<%--</asp:DropDownList>--%>
<%--</td>
</tr>
</table>
</asp:Panel>--%>
<asp:Panel ID="pnlTelCallName" runat="server" Width="100%" Visible="true">
<table id="tblTelCallName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTelCallName" runat="server" Text="Tele Caller Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlTeleName" runat="server" AutoPostBack="false" SkinID="ddlSkin"></asp:DropDownList>
<%--<asp:DropDownList ID="ddlTelecallerName" runat="server" AppendDataBoundItems="true"  AutoPostBack="false" SkinID="ddlSkin">
<%--<asp:ListItem Value="0">---SELECT---</asp:ListItem>--%>
<%--</asp:DropDownList>--%>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlCalleduponResiTel" runat="server" Width="100%" Visible="false">
<table id="tblCalleduponResiTel" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCalleduponResiTel" runat="server" Text="Called up on Resi Tel. No."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCalleduponResiTel" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlSpkto" runat="server" Width="100%" Visible="false">
<table id="tblSpkto" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSpkto" runat="server" Text="Spk to"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSpkto" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResidenceStatus" runat="server" Width="100%" Visible="false">
<table id="tblResidenceStatus" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblResidenceStatus" runat="server" Text="Residence Status"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlResidenceStatus" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Ancestral" Value="Ancestral"></asp:ListItem>
        <asp:ListItem Text="Bachelor acco" Value="Bachelor acco"></asp:ListItem>
        <asp:ListItem Text="Co.Provided" Value="Co.Provided"></asp:ListItem>
        <asp:ListItem Text="Family" Value="Family"></asp:ListItem>
        <asp:ListItem Text="Own" Value="Own"></asp:ListItem>
        <asp:ListItem Text="Paying guest" Value="Paying guest"></asp:ListItem>
        <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
        <asp:ListItem Text="Company accomodation" Value="Company accomodation"></asp:ListItem>
        <asp:ListItem Text="With Parents" Value="With Parents"></asp:ListItem>
        <asp:ListItem Text="With Relatives" Value="With Relatives"></asp:ListItem>
        <asp:ListItem Text="With Friends" Value="With Friends"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAnyotherResiPhoneNo" runat="server" Width="100%" Visible="false">
<table id="Table1" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAnyotherResiPhoneNo" runat="server" Text="Any other Resi. Phone No."></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAnyotherResiPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAdditionalRemark" runat="server" Width="100%" Visible="false">
<table id="tblAdditionalRemark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAdditionalRemark" runat="server" Text="Additional Remark"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAdditionalRemark" runat="server" MaxLength="250" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlRecommendation" runat="server" Width="100%" Visible="false">
<table id="tblRecommendation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRecommendation" runat="server" Text="Recommendation"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlRecommendation" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Positive" Value="Positive"></asp:ListItem>
        <asp:ListItem Text="Negative" Value="Negative"></asp:ListItem>
        <asp:ListItem Text="Defaulter" Value="Defaulter"></asp:ListItem>     
        <asp:ListItem Text="Referral" Value="Referral"></asp:ListItem>                 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNegativeCode" runat="server" Width="100%" Visible="false">
<table id="tblNegativeCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNegativeCode" runat="server" Text="Negative Code"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNegativeCode" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlPriorityCustomer" runat="server" Width="100%" Visible="false">
<table id="tblPriorityCustomer" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPriorityCustomer" runat="server" Text="Priority Customer"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlPriorityCustomer" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="a" Value="a"></asp:ListItem>
        <asp:ListItem Text="b" Value="b"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlSegmentation" runat="server" Width="100%" Visible="false">
<table id="tblSegmentation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSegmentation" runat="server" Text="Segmentation"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSegmentation" runat="server" MaxLength="15"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlInfoRequired" runat="server" Width="100%" Visible="false">
<table id="tblInfoRequired" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInfoRequired" runat="server" Text="Info. Required"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtInfoRequired" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlChangeinPhoneNumber" runat="server" Width="100%" Visible="false">
<table id="tblChangeinPhoneNumber" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblChangeinPhoneNumber" runat="server" Text="Change in Phone Number"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlChangeinPhoneNumber" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
        <asp:ListItem Text="No" Value="No"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReasonforchange" runat="server" Width="100%" Visible="false">
<table id="tblReasonforchange" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblReasonforchange" runat="server" Text="Reason for change"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlReasonforchange" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Customer Shifted" Value="Customer Shifted"></asp:ListItem>
        <asp:ListItem Text="Not Known" Value="Not Known"></asp:ListItem> 
        <asp:ListItem Text="Transferred PP No" Value="Transferred PP No"></asp:ListItem> 
        <asp:ListItem Text="Neighbor" Value="Neighbor"></asp:ListItem> 
        <asp:ListItem Text="PCO" Value="PCO"></asp:ListItem> 
        <asp:ListItem Text="Relative" Value="Relative"></asp:ListItem> 
        <asp:ListItem Text="STD Booth" Value="STD Booth"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlAddrPPLocation" runat="server" Width="100%" Visible="false">
<table id="tblAddrPPLocation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblAddrPPLocation" runat="server" Text="Address PP Location"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtAddrPPLocation" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--<Santosh Shelar : Start>--%>

<asp:Panel ID="pnlChangeAdd" runat="server"  Width="100%" Visible="false">
<table cellpadding="0" cellspacing="0" id="tblChangeAdd" style="width:100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblChangeAdd" runat="server"  Text="Address confirmed during calling"></asp:Label>
</td><td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin" ID="txtChangeAdd" TextMode="MultiLine" runat="server" MaxLength="500"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--<Santosh Shaelar : End>--%>
<asp:Panel ID="pnlNatureofBusiness" runat="server" Width="100%" Visible="false">
<table id="tblNatureofBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNatureofBusiness" runat="server" Text="Nature of Business"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNatureofBusiness" runat="server" MaxLength="200"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlInputtercode" runat="server" Width="100%" Visible="false">
<table id="tblInputtercode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInputtercode" runat="server" Text="Emp code"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtInputtercode" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlInputterName" runat="server" Width="100%" Visible="false">
<table id="tblInputterName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInputterName" runat="server" Text="Inputter Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtInputterName" runat="server" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlCPVScore" runat="server" Width="100%" Visible="false">
<table id="tblCPVScore" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCPVScore" runat="server" Text="CPV Score"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtCPVScore" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlRegion" runat="server" Width="100%" Visible="false">
<table id="tblRegion" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblRegion" runat="server" Text="Region"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtRegion" runat="server"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTypeofVerification" runat="server" Width="100%" Visible="false">
<table id="tblTypeofVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTypeofVerification" runat="server" Text="Type of Verification"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
    <asp:DropDownList ID="ddlTypeofVerification" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Business Phone" Value="Business Phone"></asp:ListItem>
        <asp:ListItem Text="Residence Phone" Value="Residence Phone"></asp:ListItem>            
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlSupervisorcode" runat="server" Width="100%"  Visible="false">
<table id="tblSupervisorcode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSupervisorcode" runat="server" Text="Supervisor code"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSupervisorcode" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<!---End Of Additional Fields----->
<!---Start Of Included Fields After Testing----->
<table id="tblTeleverificationResults" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTeleverificationResults" runat="server" Text="Televerification Result"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>                     
        
         <asp:DropDownList SkinID="ddlSkin" ID="ddlTeleverificationResults" runat="server" DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID"  OnDataBound="ddlTeleverificationResults_DataBound">
         </asp:DropDownList>
    </td>
</tr>
</table>
<table id="tblDeclineReasons" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDeclineReasons" runat="server" Text="Decline Reasons"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDeclineReasons" runat="server" MaxLength="500" Width="80%"></asp:TextBox>
</td>
</tr>
</table>

<table id="tblLogin" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center" colspan="5">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblTelecallLog" runat="server" Text="TELECALL LOG"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblLogin" runat="server" Text="Login"></asp:Label>
</td>
 <td>
<asp:Label SkinID="lblSkin"   ID="lblDate" runat="server" Text="Date [dd/mm/yyyy]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTime" runat="server" Text="Time [hh:mm]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblTelNo" runat="server" Text="Tel No."></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin"   ID="lblRemark" runat="server" Text="Remark"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl1stCall" runat="server" Text="1st call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate1stCall" runat="server"></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1stCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime1stCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime1stCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo1stCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks1stCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl2ndCall" runat="server" Text="2nd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate2ndCall" runat="server"></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2ndCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime2ndCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime2ndCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo2ndCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks2ndCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl3rdCall" runat="server" Text="3rd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate3rdCall" runat="server"></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3rdCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime3rdCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime3rdCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo3rdCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks3rdCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl4thCall" runat="server" Text="4th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate4thCall" runat="server"></asp:TextBox>
    <img id="ImgDate4thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate4thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime4thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime4thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo4thCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks4thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lbl5thCall" runat="server" Text="5th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDate5thCall" runat="server"></asp:TextBox>
    <img id="ImgDate5thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate5thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTime5thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime5thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo5thCall" runat="server"></asp:TextBox>
</td>
<td>

<asp:DropDownList ID="ddlRemarks5thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem>
<asp:ListItem Text="Cont. Enganaged" Value="Cont. Enganaged"></asp:ListItem>
<asp:ListItem Text="No Response" Value="No Response"></asp:ListItem>
<asp:ListItem Text="Switch Off" Value="Switch Off"></asp:ListItem>
<asp:ListItem Text="Not Reachable" Value="Not Reachable"></asp:ListItem>
<asp:ListItem Text="Blank Response" Value="Blank Response"></asp:ListItem>
<asp:ListItem Text="Telefax" Value="Telefax"></asp:ListItem>
<asp:ListItem Text="Customer Does not stay" Value="Customer Does not stay"></asp:ListItem>
<asp:ListItem Text="Refused For Details" Value="Refused For Details"></asp:ListItem>
<asp:ListItem Text="Correct Add. Updation" Value="Correct Add. Updation"></asp:ListItem>
<asp:ListItem Text="Wrong Number" Value="Wrong Number"></asp:ListItem>
<asp:ListItem Text="Invalid Number" Value="Invalid Number"></asp:ListItem>
<asp:ListItem Text="Unware Of details" Value="Unware Of details"></asp:ListItem>
<asp:ListItem Text="DTM" Value="DTM"></asp:ListItem>
<asp:ListItem Text="No Not Given" Value="No Not Given"></asp:ListItem>
<asp:ListItem Text="Extn Required" Value="Extn Required"></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Answering Machine" Value="Answering Machine"></asp:ListItem>
<asp:ListItem Text="Does Not Exist" Value="Does Not Exist"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contactable" Value="Contactable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
<%--Added By Sunny Chauhan : Start --%>
<table id="tblContactNumberDetail" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label ID="lblActContDet" SkinID="lblSkin" runat="server" Text="Actual Contacted Number Type"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlActContNum" SkinID="ddlSkin" runat="server" AutoPostBack="false">
<asp:ListItem Text="New" Value="New"></asp:ListItem>
<asp:ListItem Text="Mobile" Value="Mobile"></asp:ListItem>
<asp:ListItem Text="Landline" Value="Landline"></asp:ListItem>
</asp:DropDownList>
</td>
<td class="TDWidth">
<asp:Label ID="lblNumber" SkinID="lblSkin" runat="server" Text="Actual Number"></asp:Label>
</td>
<td style="width:2%" >:</td>
<td>
<asp:TextBox ID="txtActualNumber" SkinID="txtSkin" runat="server" MaxLength="15"></asp:TextBox>
</td></tr>
</table>
<%--Addition Done Sunny Chauhan : End --%>
<table id="tblNewInfoObt"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNewInfoObt" runat="server" Text="New Info Obtained (TCRemarks)"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNewInfoObt" runat="server" TextMode="MultiLine" Height="90%"  Width="90%" MaxLength="750"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
</td>
</tr>
</table>
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


<table id="tblSupervisorRemark" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblSupervisorRemark" runat="server" Text="Supervisor Remark"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtSupervisorRemark" runat="server" MaxLength="255" Width="80%"></asp:TextBox>
</td>
</tr>
</table>
<br />
<!--End of TeleLog-->
<!---End Of Included Fields After Testing----->

<asp:Panel ID="pnlSubmit" runat="server" Width="100%"  Visible="True">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpAttempts" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />       
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
        </td>
      </tr>
    </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
    <asp:HiddenField ID="hidMode" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
    
    <asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label>
    </asp:Panel>
 </asp:TableCell></asp:TableRow></asp:Table>
 <asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select televerification result." ValidationGroup="grpAttempts" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlTeleverificationResults" OnServerValidate="cvSelectCaseStatus_ServerValidate">
 </asp:CustomValidator> 
 
  <%--asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="txtSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grpAttempts"></asp:RequiredFieldValidator--%>
            
 <asp:RequiredFieldValidator ID="refDate1" runat="server" ControlToValidate="txtDate1stCall" Display="None" ErrorMessage="Enter Date in 1st call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate2" runat="server" ControlToValidate="txtDate2ndCall" Display="None" ErrorMessage="Enter Date in 2nd call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate3" runat="server" ControlToValidate="txtDate3rdCall" Display="None" ErrorMessage="Enter Date in 3rd call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate4" runat="server" ControlToValidate="txtDate4thCall" Display="None" ErrorMessage="Enter Date in 4th call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
 <asp:RequiredFieldValidator ID="refDate5" runat="server" ControlToValidate="txtDate5thCall" Display="None" ErrorMessage="Enter Date in 5th call."
    SetFocusOnError="True" ValidationGroup="grpAttempts"></asp:RequiredFieldValidator>
    
 
 
 <asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtTime1stCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 1st call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime2" runat="server" ControlToValidate="txtTime2ndCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 2nd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime3" runat="server" ControlToValidate="txtTime3rdCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 3rd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime4" runat="server" ControlToValidate="txtTime4thCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 4th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revTime5" runat="server" ControlToValidate="txtTime5thCall"
    Display="None" ErrorMessage="Please enter valid Time Format for 5th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpAttempts"></asp:RegularExpressionValidator> 
 <asp:RegularExpressionValidator ID="revDate1" runat="server" ControlToValidate="txtDate1stCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 1st call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate2" runat="server" ControlToValidate="txtDate2ndCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 2nd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate3" runat="server" ControlToValidate="txtDate3rdCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 3rd call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate4" runat="server" ControlToValidate="txtDate4thCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 4th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
 <asp:RegularExpressionValidator ID="revDate5" runat="server" ControlToValidate="txtDate5thCall"
    Display="None" ErrorMessage="Please enter valid Date Format for 5th call" SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpAttempts"></asp:RegularExpressionValidator>
    
<%-- <asp:CustomValidator ID="cv1stTelCall" runat="server" ClientValidationFunction="ValidateTime1"
    ControlToValidate="txtTime1stCall" Display="None" ErrorMessage="Enter telephone no in 1st call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv2ndTelCall" runat="server" ClientValidationFunction="ValidateTime2"
    ControlToValidate="txtTime2ndCall" Display="None" ErrorMessage="Enter telephone no in 2nd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv3rdTelCall" runat="server" ClientValidationFunction="ValidateTime3"
    ControlToValidate="txtTime3rdCall" Display="None" ErrorMessage="Enter telephone no in 3rd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv4thTelCall" runat="server" ClientValidationFunction="ValidateTime4"
    ControlToValidate="txtTime4thCall" Display="None" ErrorMessage="Enter telephone no in 4th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>
 <asp:CustomValidator ID="cv5thTelCall" runat="server" ClientValidationFunction="ValidateTime5"
    ControlToValidate="txtTime5thCall" Display="None" ErrorMessage="Enter telephone no in 5th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator>--%>
    
   
 <asp:CustomValidator ID="cvAttemptRemark1" runat="server" ClientValidationFunction="ValidateRemark1"
    ControlToValidate="ddlRemarks1stCall" Display="None" ErrorMessage="Enter time in 1st call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark2" runat="server" ClientValidationFunction="ValidateRemark2"
    ControlToValidate="ddlRemarks2ndCall" Display="None" ErrorMessage="Enter time in 2nd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark3" runat="server" ClientValidationFunction="ValidateRemark3"
    ControlToValidate="ddlRemarks3rdCall" Display="None" ErrorMessage="Enter time in 3rd call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark4" runat="server" ClientValidationFunction="ValidateRemark4"
    ControlToValidate="ddlRemarks4thCall" Display="None" ErrorMessage="Enter time in 4th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
 <asp:CustomValidator ID="cvAttemptRemark5" runat="server" ClientValidationFunction="ValidateRemark5"
    ControlToValidate="ddlRemarks5thCall" Display="None" ErrorMessage="Enter time in 5th call."
    ValidationGroup="grpAttempts"></asp:CustomValidator> 
    
 <asp:CustomValidator ID="cvTel1" runat="server"
    ControlToValidate="txtTelNo1stCall" Display="None" ErrorMessage="Enter remark in 1st call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel1"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel2" runat="server"
    ControlToValidate="txtTelNo2ndCall" Display="None" ErrorMessage="Enter remark in 2nd call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel2"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel3" runat="server"
    ControlToValidate="txtTelNo3rdCall" Display="None" ErrorMessage="Enter remark in 3rd call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel3"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel4" runat="server"
    ControlToValidate="txtTelNo4thCall" Display="None" ErrorMessage="Enter remark in 4th call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel4"></asp:CustomValidator>
 <asp:CustomValidator ID="cvTel5" runat="server"
    ControlToValidate="txtTelNo5thCall" Display="None" ErrorMessage="Enter remark in 5th call."
    ValidationGroup="grpAttempts" ClientValidationFunction="ValidateTel5"></asp:CustomValidator>
    
 <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtDate1stCall"
        ClientValidationFunction="ValidateAttempts"  ValidationGroup="grpAttempts"  
        ErrorMessage="Enter atleast one Attempt." Display="None">
      </asp:CustomValidator> 
   
 <asp:ValidationSummary ID="vsAttempt" runat="server" ValidationGroup="grpAttempts" ShowMessageBox="True" ShowSummary="False" />
</td>
</tr>
</table>
<table>
    <tr>
    <td><asp:LinkButton ID="lbRV" runat="server" Text="RV" Width="22px" OnClick="lbRV_Click" Visible="False"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBV" runat="server" Text="BV" Width="22px" Visible="False" OnClick="lbBV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbRT" runat="server" Text="RT" Width="22px" Visible="False" OnClick="lbRT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbBT" runat="server" Text="BT" Width="22px" Visible="False" OnClick="lbBT_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRTV" runat="server" Text="PRTV" Width="22px" Visible="False" OnClick="lbPRTV_Click"></asp:LinkButton>
    </td>
     <td><asp:TextBox ID="txtfdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txttdate" runat="server" MaxLength="10" Visible="false"></asp:TextBox></td>
       
    </tr>
   
    </table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
    &nbsp;
</fieldset>
</td></tr></table>
</asp:Content>
