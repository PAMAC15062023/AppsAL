<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="RL_QCBusinessTelephonicVerification.aspx.cs" Inherits="CPV_RL_RL_QCBusinessTelephonicVerification"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" language="javascript">

function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 254)
     {
       getControlsId.value = getControlsId.value.substring( 0, 254 );            
       return false;
     }          
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
                   
          if(document.aspnetForm.ctl00$C1$txtTime1stCall.value.length >0)
          {    
                   
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



</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">BUSINESS TELE VERIFICATION REPORT</legend>
<table id="tblMain" runat="server" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td>
 <!--Start Heading-->
 <asp:Panel ID="pnlBusinessVerTelHead" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin"   ID="lblBusinessVerifiReport" runat="server" Text="BUSINESS VERIFICATION REPORT"></asp:Label>
 </td>
 </tr>
 </table>
 </asp:Panel>

    <!--END Heading-->
<!--- Start of Personal Detail-->
<asp:Table ID="tblBusiTelVeri" runat="server"  Width="100%">
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
<asp:Label SkinID="lblSkin"   ID="lblMessage" runat="server" ForeColor="Red" Width="672px"></asp:Label>

<asp:Panel ID ="pnlDateRecieved" runat="server" Width="100%" Visible="false">
<table id="tblDateRecieved" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateRecieved" runat="server" Text="Date Recieved"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtDateRecieved" runat="server"  ReadOnly="True"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID ="pnlRefNo" runat="server" Width="100%" Visible="false">
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


<asp:Panel ID ="pnlArea" runat="server" Width="100%" Visible="false">
<table id="tblArea" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblArea" runat="server" Text="Area" >
</asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtArea" runat="server" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--///////////add by santosh shelar change in readyonly item 23/08/08/////////////////--%>
<asp:Panel ID ="pnlNameoftheApplicant" runat="server" Width="100%" Visible="false">
<table id="tblNameoftheApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNameoftheApplicant" runat="server" Text="Name of the Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtNameoftheApplicant" runat="server" ReadOnly="False" ></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOfficeTelephoneNo" runat="server" Width="100%" Visible="false">
<table id="tblOfficeTelephoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOfficeTelephoneNo" runat="server" Text="Office Telephone No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtOfficeTelephoneNo" runat="server" ReadOnly="true"  MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlExactCompanyName" runat="server" Width="100%" Visible="false">
<table id="tblExactCompanyName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblExactCompanyName" runat="server" Text="Exact Company Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtExactCompanyName" runat="server" ReadOnly="true" MaxLength="100" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlExactCompanyAddress" runat="server" Width="100%" Visible="false">
<table id="tblExactCompanyAddress" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblExactCompanyAddress" runat="server" Text="Exact Company Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtExactCompanyAddress" runat="server" ReadOnly="true" MaxLength="100" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPersonContacted" runat="server" Text="Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtPersonContacted" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlPersoncontactedOfficeTeleConfirmsAppWork" runat="server" Width="100%" Visible="false">
<table id="tblPersoncontactedOfficeTeleConfirmsAppWork" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblPersoncontactedOfficeTeleConfirmsAppWork" runat="server" Text="Person Contacted at Office Telephone Confirms that the Applicant works at given Address"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlPersoncontactedOfficeTeleConfirmsAppWork" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value=""></asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlAddressDifferent" runat="server" Width="100%" Visible="false">
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

<asp:Panel ID="pnlDesignationOfPersonContacted" runat="server" Width="100%" Visible="false">
<table id="tblDesignationOfPersonContacted" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDesignationOfPersonContacted" runat="server" Text="Designation Of Person Contacted"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDesignationOfPersonContacted" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlExactDesignationOftheApplicant" runat="server" Width="100%" Visible="false">
<table id="tblExactDesignationOftheApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblExactDesignationOftheApplicant" runat="server" Text="Exact Designation Of the Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtExactDesignationOftheApplicant" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNoofyrswiththeCompany" runat="server" Width="100%" Visible="false">
<table id="tblNoofyrswiththeCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNoofyrswiththeCompany" runat="server" Text="No. of yrs with the Company"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNoofyrswiththeCompany" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
<table id="tblNatureOfBusiness" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNatureOfBusiness" runat="server" Text="Nature Of Business"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtNatureOfBusiness" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlMainlineBusinessoftheCompany" runat="server" Width="100%" Visible="false">
<table id="tblMainlineBusinessoftheCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblMainlineBusinessoftheCompany" runat="server" Text="Mainline Business of the Company"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtMainlineBusinessoftheCompany" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlCategoryofCompany" runat="server" Width="100%" Visible="false">
<table id="tblCategoryofCompany" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblCategoryofCompany" runat="server" Text="Category of Company"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtCategoryofCompany" runat="server" MaxLength="50"></asp:TextBox>

<%--<asp:DropDownList ID="ddlCategoryofCompany" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem>NA</asp:ListItem>
        <asp:ListItem>Huf</asp:ListItem>
        <asp:ListItem>Partnership</asp:ListItem>
        <asp:ListItem>Propritorship</asp:ListItem>
        <asp:ListItem>Pvt Ltd</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
        <asp:ListItem>PSU</asp:ListItem>
        <asp:ListItem>MNC</asp:ListItem>
        <asp:ListItem>Public LTD</asp:ListItem>
       
 </asp:DropDownList>--%>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlOfficeOrBusinessAddressasperCall" runat="server" Width="100%" Visible="false">
<table id="tblOfficeOrBusinessAddressasperCall" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOfficeOrBusinessAddressasperCall" runat="server" Text="Office/Business Address as per Call"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtOfficeOrBusinessAddressasperCall" runat="server" MaxLength="100" Width="60%"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>


<asp:Panel ID="pnlOverallRemarks" runat="server" Width="100%" Visible="false">
<table id="tblOverallRemarks" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblOverallRemarks" runat="server" Text="Overall Remarks"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtOverallRemarks" runat="server" Width="60%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOverallRemarks')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOverallRemarks');"></asp:TextBox>
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

<asp:Panel ID="pnlTeleCallersName" runat="server" Width="100%" Visible="true">
<table id="tblTeleCallersName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblTeleCallersName" runat="server" Text="Tele Caller's Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:DropDownList ID="ddlTeleCallersName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">

</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlInBusinessSince" runat="server" Width="100%" Visible="false">
<table id="tblInBusinessSince" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblInBusinessSince" runat="server" Text="In Business Since"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtInBusinessSince" runat="server" MaxLength="30"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<%--/////////////add by santosh shelar add new code in BT 20/08/08///////////////////////--%>

<asp:Panel ID="pnlContactedpersonRelationshipWithApplicant" runat="server" Width="100%" Visible="false">
<table id="tblContactedpersonRelationshipWithApplicant" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblContactedpersonRelationshipWithApplicant" runat="server" Text="Contacted person Relationship With Applicant"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList SkinID="ddlSkin" ID="ddlContactedpersonRelationshipWithApplicant" runat="server" AutoPostBack="false">
    <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
    <asp:ListItem Text="Partner" Value="Partner"></asp:ListItem>
    <asp:ListItem Text="Superior" Value="Superior"></asp:ListItem>
    <asp:ListItem Text="Relative" Value="Relative"></asp:ListItem>
    <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
    <asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
</asp:DropDownList> 
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlExtNo" runat="server" Width="100%" Visible="false">
<table id="tblExtNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblExtNo" runat="server" Text="Ext. No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtExtNo" runat="server" MaxLength="5"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlTelecallerName" runat="server" Width="100%" Visible="false">
<table id="tblTelecallerName" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblTelecallerName" runat="server" Text="Tele caller Name"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlTelecallerName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlResidencePhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblResidencePhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResidencePhoneNo" runat="server" Text="Residence Phone No."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtResidencePhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlNoOfYearscurrEmployment" runat="server" Width="100%" Visible="false">
<table id="tblNoOfYearscurrEmployment" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblNoOfYearscurrEmployment" runat="server" Text="No. of Years at current Employment"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtNoOfYearscurrEmployment" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlDeptofApp" runat="server" Width="100%" Visible="false">
<table id="tblDeptofApp" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDeptofApp" runat="server" Text="Dept. of App."></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDeptofApp" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlBusinessNature" runat="server" Width="100%" Visible="false">
<table id="tblBusinessNature" border="0" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblBusinessNature" runat="server" Text="Nature of business"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlBusinessNature" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Trading" Value="Trading"></asp:ListItem>
        <asp:ListItem Text="Building" Value="Building"></asp:ListItem>
        <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem> 
        <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem> 
        <asp:ListItem Text="Contractor" Value="Contractor"></asp:ListItem> 
        <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem> 
        <asp:ListItem Text="Consultancy" Value="Consultancy"></asp:ListItem> 
        <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem> 
        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>            
</asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlResiPhoneNo" runat="server" Width="100%" Visible="false">
<table id="tblResiPhoneNo" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResiPhoneNo" runat="server" Text="Resi Phone No"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtResiPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlResiCumOffice" runat="server" Width="100%" Visible="false">
<table id="tblResiCumOffice" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblResiCumOffice" runat="server" Text="Resi Cum Office"></asp:Label>
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
<asp:Panel ID="pnlOffice" runat="server" Width="100%" Visible="false">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%" align="center">
<asp:Label SkinID="lblSkin" ID="lblOffice" runat="server" ForeColor="blue" Text="OFFICE"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID ="pnlAgencyCode" runat="server" Width="100%" Visible="false">
<table id="tblAgencyCode" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server" Text="Agency Code" >
</asp:Label></td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtAgencyCode" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<%--/////////add by santosh shelar change readyonly option 23/08/08//////////////////////--%>
<asp:Panel ID ="pnlInitiationDate" runat="server" Width="100%" Visible="false">
<table id="tblInitiationDate" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="False"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<!--END Personal Detail-->

<%--Sabbani Naresh Start 17/06/08--%>
         <asp:Panel ID="pnlOffOwner" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblOffOwner" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOffOwner" runat="server" Text="Office Ownership"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin" ID="ddlOffOwner" runat="server"  AutoPostBack="false">
            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                <asp:ListItem Text="Pagdi" Value="Pagdi"></asp:ListItem>
                <asp:ListItem Text="Others(specify)" Value="Others(specify)"></asp:ListItem>            
            </asp:DropDownList>            
            </td>
            </tr>
            </table>
         </asp:Panel>  
<asp:Panel ID="pnlAppAvailable" runat="server" Width="100%" Visible="false">
<table id="tblAppAvailable" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblAppAvailable" runat="server" Text="Applicant is usually available at"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtAppAvailable" runat="server" MaxLength="20"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
<table id="tblDirectoryCheck" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblDirectoryCheck" runat="server" Text="Directory Check"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDirectoryCheck" runat="server" MaxLength="100"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlCurrentResidencePeriod" runat="server" Width="100%" Visible="false">
<table id="tblCurrentResidencePeriod" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblCurrentResidencePeriod" runat="server" Text="Current Residence Period"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtCurrentResidencePeriod" runat="server" MaxLength="50"></asp:TextBox>
</td>
</tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlForSelfEmployedTypeOrganisation" runat="server" Width="100%" Visible="false">
<table id="tblForSelfEmployedTypeOrganisation" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblForSelfEmployedTypeOrganisation" runat="server" Text="For Self Employed- Type of Organisation"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlForSelfEmployedTypeOrganisation" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
        <asp:ListItem Text="Proprietorship" Value="Proprietorship"></asp:ListItem>
        <asp:ListItem Text="Partnership" Value="Partnership"></asp:ListItem> 
        <asp:ListItem Text="Pvt Ltd" Value="Pvt Ltd"></asp:ListItem> 
        <asp:ListItem Text="Public Ltd" Value="Public Ltd"></asp:ListItem> 
        <asp:ListItem Text="Others" Value="Others"></asp:ListItem> 
    </asp:DropDownList>
</td>
</tr>
</table>
</asp:Panel>


<%--Sabbani Naresh End 17/06/08--%>

<!--Start of TeleLog Head-->
<asp:Panel ID="pnlTelecallLog" runat="server" Width="100%" Visible="true">
<table>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">
<asp:Label SkinID="lblSkin" ForeColor="blue"  ID="lblTelecallLog" runat="server" Text="TELECALL LOG"></asp:Label>
</td>
</tr>
</table>
</asp:Panel>
<!--End of TeleLog Head-->
<!--Start of TeleLog-->

<asp:Panel ID="pnlLogin" runat="server" Width="100%" Visible="true">
<table id="tblLogin" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">

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
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contractable" Value="Contractable"></asp:ListItem>
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
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contractable" Value="Contractable"></asp:ListItem>
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
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contractable" Value="Contractable"></asp:ListItem>
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
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contractable" Value="Contractable"></asp:ListItem>
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
<asp:ListItem Text="NA" Value=""></asp:ListItem>
<asp:ListItem Text="Neighbour contacted" Value="Neighbour contacted"></asp:ListItem>
<asp:ListItem Text="Uncontactable" Value="Uncontactable"></asp:ListItem>
<asp:ListItem Text="Engaged" Value="Engaged"></asp:ListItem>
<asp:ListItem Text="Contractable" Value="Contractable"></asp:ListItem>
<asp:ListItem Text="Out of Service" Value="Out of Service"></asp:ListItem>
<asp:ListItem Text="RNR" Value="RNR"></asp:ListItem>
<asp:ListItem Text="Temporarily disconected" Value="Temporarily disconected"></asp:ListItem>
<asp:ListItem Text="Incorrect Number" Value="Incorrect Number"></asp:ListItem>
<asp:ListItem Text="Incomplete Number" Value="Incomplete Number"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
<table id="tblNewInfoObt"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblNewInfoObt" runat="server" Text="New Info Obtained (TCRemarks)"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"   ID="txtNewInfoObt" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
</td>
</tr>
</table>
</asp:Panel><br />
<!--End of TeleLog-->
<asp:Panel ID="pnlDateOfVerification" runat="server" Width="100%" Visible="false">
<table id="tblDateOfVerification" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin"   ID="lblDateOfVerification" runat="server" Text="Date Of Verification"></asp:Label>
</td>
<td style="width:2%">:</td>
<td >
<asp:TextBox SkinID="txtSkin"   ID="txtDateOfVerification" runat="server" MaxLength="10"></asp:TextBox>
<img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfVerification.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
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



<asp:Panel ID="pnlSubmit" runat="server" Width="100%"  Visible="True">
    <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
      <tr>
       <td align="center">
         <asp:Button ID="btnSubmit" runat="server" ValidationGroup="grpAttempts" SkinID="btnSubmitSkin" Text="Submit" OnClick="btnSubmit_Click" />       
         <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel"  OnClick="btnCancel_Click"/>
        </td>
      </tr>
    </table>
    <asp:HiddenField ID="hidCaseID" runat="server" />
    <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
    <asp:HiddenField ID="hidMode" runat="server" />
     <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
    
    </asp:Panel>
 </asp:TableCell></asp:TableRow></asp:Table>
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
