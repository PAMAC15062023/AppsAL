<%@ Page Language="C#"  MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_F16.aspx.cs" Inherits="CPV_IDOC_IDOC_F16" Theme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

 <script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {

          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
    </script>
    <script type="text/javascript" language="javascript">

function imposeMaxLength(Object,Maxlength)

{

return (Object.value.length<Maxlength);

}

 
function ValidateTextLength(DisplayName, ControlName, xLength)

{

            if (ControlName.value.length > parseInt(xLength))

            {
              alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");

              ControlName.focus();                                          

            } 
 } 
 
 
       <!--
       function ValidateAttempt1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime1.value.length ==0 && document.aspnetForm.ctl00$C1$txtDate1.value.length!=0 || document.aspnetForm.ctl00$C1$txtTime1.value.length !=0 && document.aspnetForm.ctl00$C1$txtDate1.value.length==0)
          {    
              document.aspnetForm.ctl00$C1$txtTime1.focus();
              
              
              
              
               arguments.IsValid=false;
            }         
                       
          }
           function ValidateAttempt2(source, arguments)
           { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime2.value.length ==0 && document.aspnetForm.ctl00$C1$txtDate2.value.length!=0 || document.aspnetForm.ctl00$C1$txtTime2.value.length !=0 && document.aspnetForm.ctl00$C1$txtDate2.value.length==0)
            {    
              document.aspnetForm.ctl00$C1$txtTime2.focus();
               arguments.IsValid=false;
            }         
                       
          }
           function ValidateAttempt3(source, arguments)
         { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime3.value.length ==0 && document.aspnetForm.ctl00$C1$txtDate3.value.length!=0 ||document.aspnetForm.ctl00$C1$txtTime3.value.length !=0 && document.aspnetForm.ctl00$C1$txtDate3.value.length==0)
          {    
              document.aspnetForm.ctl00$C1$txtTime3.focus();
               arguments.IsValid=false;
            }         
                     
          }
           function ValidateAttempt4(source, arguments)
        { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime4.value.length ==0 && document.aspnetForm.ctl00$C1$txtDate4.value.length!=0 || document.aspnetForm.ctl00$C1$txtTime4.value.length !=0 && document.aspnetForm.ctl00$C1$txtDate4.value.length==0)
          {    
              document.aspnetForm.ctl00$C1$txtTime4.focus();
               arguments.IsValid=false;
            }         
                    
          }
           function ValidateAttempt5(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtTime5.value.length ==0 && document.aspnetForm.ctl00$C1$txtDate5.value.length!=0 || document.aspnetForm.ctl00$C1$txtTime5.value.length !=0 && document.aspnetForm.ctl00$C1$txtDate5.value.length==0)
          {    
              document.aspnetForm.ctl00$C1$txtTime5.focus();
               arguments.IsValid=false;
            }         
                     
          }
// -->


            

function TABLE1_onclick() {

}

  </script>

 
<fieldset ><legend class="FormHeading">DOCUMENT VERIFICATION</legend>

<table  border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF" id="TABLE1" onclick="return TABLE1_onclick()">
    <tr>
        <td class="txtBold" colspan="7"  valign="top">
            <asp:Label ID="lblmsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
    </tr>

  <tr> 
  <td  valign="top" colspan="7" class="txtBold" style="background-color:#D0D5D8; height: 16px;" >
      &nbsp;<asp:Label ID="lblF16" runat="server" SkinID="lblSkin" Text="Form-16 Verification Report"
          Visible="False"></asp:Label>
      <asp:Label ID="lblss" runat="server" SkinID="lblSkin" Text="Salary Slip Verification Report"
          Visible="False"></asp:Label>
      <asp:Label ID="lblsc" runat="server" SkinID="lblSkin" Text="Salary Certificate Verification Report"
          Visible="False"></asp:Label></td>
  </tr>
  
  <tr> 
    <td class="label" > Applicant's Name (Mr./Ms./Mrs.)</td>
      <td valign="top"   >
          :</td>
    <td valign="top"><asp:TextBox ID="txtApplicantName" SkinID="txtSkin" runat="server" Columns="50" ReadOnly="True" Width="320px"></asp:TextBox>
        </td>
      
    <td valign="top" colspan="4"></td>
  </tr>
  <tr> 
    <td valign="top" class="label"> CDM Referance No</td>
      <td valign="top" >
          :</td>
    <td valign="top" class="label"><asp:TextBox ID="txtRefNo" SkinID="txtSkin" runat="server" ReadOnly="True" Width="321px"></asp:TextBox></td>
    
    <td valign="top" class="label">Date of Initiation[dd/MM/yyyy]</td>
      <td valign="top" >
          :</td>
    <td colspan="1" valign="top"> 
        <asp:TextBox ID="txtRecDate" SkinID="txtSkin" runat="server" ReadOnly="True"></asp:TextBox> </td>
  </tr>
  <tr> 
    <td valign="top" class="label">Name of the Company</td>
      <td valign="top"  >
          :</td>
    <td colspan="5" valign="top" class="label"><asp:TextBox ID="txtCompanyName" SkinID="txtSkin" runat="server" Columns="50" ReadOnly="True" Width="322px"></asp:TextBox>
        </td>
      
  </tr>
  </table>

  <table border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td  valign="top" colspan="3" class="txtBold" style="background-color:#D0D5D8; height: 16px;">Back Office Check</td>
  </tr>
  <tr> 
    <td valign="top" class="label" style="width: 531px; height: 26px"> Total Income as per SS / SC / Pay slip / Form -16 
        <asp:CompareValidator ID="valAmtTotal" runat="server" ControlToValidate="txtAmount"
            Display="None" ErrorMessage="Please Enter numeric only in Total Income " Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Double" ValidationGroup="valsumDocVer"></asp:CompareValidator></td>
      <td   valign="top" style="width: 6px; height: 26px" >
          :</td>
    <td style="height: 26px"  ><asp:TextBox ID="txtAmount" runat="server" SkinID="txtSkin" valign="top" MaxLength="9"></asp:TextBox></td>
  </tr>
  <tr> 
    <td   valign="top" style="width: 531px"> Overwriting / Tampering of Any Provision in the Salary Slip 
      Dectected</td>
      <td   valign="top" style="width: 6px" >
          :</td>
    <td  valign="top" ><asp:DropDownList ID="ddlOTSSD" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  </table>
  <asp:Panel ID ="pnlform16" runat="server" Width="100%" Visible="false">
  <table  border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td  valign="top" style="width: 531px"  >
        &nbsp;<asp:Label ID="lblPanCorr" runat="server" SkinID="lblSkin" Text="Construction of Pan correct"></asp:Label></td>
      <td  valign="top" style="width: 7px"  >
          <asp:Label ID="lblcol1" runat="server" Text=":" Width="4px"></asp:Label></td>
    <td valign="top"  ><asp:DropDownList ID="ddlCPC" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
        
  </tr>
  
  <tr> 
    <td  valign="top" style="width: 531px" >
        &nbsp;<asp:Label ID="lblTanCorr" runat="server" SkinID="lblSkin" Text="Construction of Tan correct"></asp:Label></td>
      <td  valign="top" style="width: 7px" >
          <asp:Label ID="lblcol2" runat="server" Text=":"></asp:Label></td>
    <td valign="top" ><asp:DropDownList ID="ddlCTC" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
   <tr> 
    <td  valign="top" style="width: 531px" > 
        <asp:Label ID="lblInCase" runat="server" Text="In case of F16 Tax Payable is correct (For Tax payable cases Tax paid should be = to TDS)"></asp:Label></td>
      <td  valign="top" style="width: 7px" >
          <asp:Label ID="lblcol3" runat="server" Text=":"></asp:Label></td>
    <td valign="top"  ><asp:DropDownList ID="ddlTDS" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  
  </table>
  </asp:Panel>
  <table border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td  valign="top"  style="width: 531px"> Overall computation correct</td>
      <td   valign="top"  style="width: 7px" >
          :</td>
    <td  valign="top" ><asp:DropDownList ID="ddlOCC" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr> 
    <td valign="top" style="width: 531px" > Income calculations correct</td>
      <td  valign="top"  style="width: 7px">
          :</td>
    <td valign="top"  ><asp:DropDownList ID="ddlICC" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr> 
    <td  valign="top" style="width: 531px"> Tax calculations correct</td>
      <td  valign="top" style="width: 7px" >
          :</td>
    <td valign="top" ><asp:DropDownList ID="ddlTCC" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
 
  <tr> 
    <td  valign="top" style="width: 531px">Whether OK to send for field verification</td>
      <td   valign="top" style="width: 7px" >
          :</td>
    <td valign="top" ><asp:DropDownList ID="ddlOK" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr> 
    <td valign="top"  style="width: 531px">Any speling mistake in document </td>
      <td   valign="top" style="width: 7px"  >
          :</td>
    <td valign="top" ><asp:DropDownList ID="ddlSpellMistake" SkinID="ddlSkin" runat="server">
            <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>UTV</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr> 
    <td valign="top"  style="width: 531px" >Other  Observation </td>
      <td valign="top"  style="width: 7px"   >
          :</td>
    <td  valign="top" >
        <asp:TextBox ID="txtOtherObservation" SkinID="txtSkin" runat="server" Columns="60" Rows="3" TextMode="MultiLine"  onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
  </tr>
  </table>

  

  <table  border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td colspan="7" valign="top"   class="txtBold" style="background-color:#D0D5D8; ">Field Verification</td>
  </tr>
  <tr> 
    <td valign="top" style="height: 33px"  > Name of the Person Contacted</td>
      <td valign="top" style="height: 33px"  >
          :</td>
      <td colspan="2" valign="top" style="height: 33px" >
          <asp:TextBox ID="txtPersonContacted" SkinID="txtSkin" runat="server" Columns="40" MaxLength="200"></asp:TextBox></td>
    <td valign="top" style="height: 33px" >Designation  Department</td>
      <td  valign="top" style="height: 33px" >
          :</td>
    <td valign="top" style="width: 158px; height: 33px;"><asp:TextBox ID="txtDepartment" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox></td>
  </tr>
  
  <tr> 
    <td valign="top" > Applicant 's Designation</td>
      <td  valign="top"   >
          :</td>
      <td colspan="2" valign="top">
          <asp:TextBox ID="txtApplicantDesi" SkinID="txtSkin" runat="server" Columns="40" MaxLength="100"></asp:TextBox>
          </td>
    <td valign="top" >Applicant's Department</td>
      <td  valign="top" >
          :</td>
    <td valign="top" style="width: 158px">
        <asp:TextBox ID="txtApplicantDepart" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox></td>
  </tr>
  <tr> 
    <td valign="top" > Applicant's Year in service with the Organization</td>
      <td valign="top"  >
          :</td>
      <td colspan="2" valign="top">
          <asp:TextBox ID="txtApplicantYSerOrg" SkinID="txtSkin" runat="server" Columns="40" MaxLength="2" Width="50px"></asp:TextBox>
          Year<asp:TextBox ID="txtMonth" runat="server" MaxLength="2" SkinID="txtSkin" Width="50px"></asp:TextBox>Month
          <asp:CompareValidator ID="valYof" runat="server" ControlToValidate="txtApplicantYSerOrg"
              Display="None" ErrorMessage="Please Enter numeric Value in Applicant Year" Operator="DataTypeCheck"
              SetFocusOnError="True" Type="Integer" ValidationGroup="valsumDocVer"></asp:CompareValidator>
          <asp:CompareValidator ID="ValMonth" runat="server" ControlToValidate="txtMonth" Display="None"
              ErrorMessage="Please Enter numeric Value" Operator="DataTypeCheck" SetFocusOnError="True"
              Type="Integer" ValidationGroup="valsumDocVer"></asp:CompareValidator></td>
    <td valign="top" >Gross Annual / Monthly Income<asp:CompareValidator ID="valAMSal" runat="server" ControlToValidate="txtAMIncome"
            Display="None" ErrorMessage="Please Enter Numeric value in Gross Annual Salary"
            Operator="DataTypeCheck" SetFocusOnError="True" Type="Double" ValidationGroup="valsumDocVer"></asp:CompareValidator></td>
      <td  valign="top" >
          :</td>
    <td valign="top" style="width: 158px" >
        <asp:TextBox ID="txtAMIncome" SkinID="txtSkin" MaxLength="9" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddlSalary" runat="server" SkinID="ddlSkin">
           <asp:ListItem>Monthly income</asp:ListItem>
            <asp:ListItem>Annual income</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr> 
    <td valign="top"  > Number of Employees in the Organisation</td>
      <td valign="top" >
          :</td>
      <td colspan="2" valign="top">
          <asp:TextBox ID="txtEmpOrg" SkinID="txtSkin" runat="server" Columns="40" MaxLength="9"></asp:TextBox>
        <asp:CompareValidator ID="valsumNoofEmp" runat="server" ControlToValidate="txtEmpOrg"
            Display="None" ErrorMessage="Please Enter numeric only in No. of Employyes seen"
            Operator="DataTypeCheck" SetFocusOnError="True" Type="Integer" ValidationGroup="valsumDocVer"></asp:CompareValidator></td>
    <td valign="top" >Type of Industry</td>
      <td  valign="top" >
          :</td>
    <td valign="top" style="width: 158px" ><asp:TextBox ID="txtTypeOfIndustry" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox></td>
  </tr>
  </table>
  <table border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td  valign="top" colspan="7" class="txtBold" style="background-color:#D0D5D8; height: 16px;" >Document Confirmed</td>
  </tr>
  <tr> 
    <td   valign="top" > Seal of the Organization</td>
      <td valign="top"   >
          :</td>
    
      <td  valign="top">
          <asp:DropDownList ID="ddlSealOrg" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            <asp:ListItem>Not Confirmed</asp:ListItem>
        </asp:DropDownList></td>
    
  </tr>
  <tr> 
    <td valign="top" > Signature of the Issuing Authority</td>
      <td valign="top" >
          :</td>
      <td  valign="top">
          <asp:DropDownList ID="ddlSIAuthority" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>Not Confirmed</asp:ListItem>
    </asp:DropDownList></td>
   
  </tr>
  <tr> 
    <td  valign="top" > Document as per the Standard Format of the Organization</td>
      <td valign="top"  >
          :</td>
   
      <td   valign="top">
          <asp:DropDownList ID="ddlSFOrg" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>Not Confirmed</asp:ListItem>
    </asp:DropDownList></td>
    
  </tr>
  <tr> 
    <td    valign="top" > Date on the SS/ SP/SC</td>
      <td valign="top"   >
          :</td>
    
      <td valign="top"  >
          <asp:DropDownList ID="ddlSSCDate" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>Not Confirmed</asp:ListItem>
    </asp:DropDownList></td>
   
  </tr>
  <tr> 
    <td valign="top" style="height: 33px" > Amount on the SS/ SP/SC</td>
      <td valign="top" style="height: 33px" >
          :</td>
   
      <td valign="top" style="height: 33px"  >
          <asp:DropDownList ID="ddlSSSAmount" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>Not Confirmed</asp:ListItem>
    </asp:DropDownList></td>
   
  </tr>
  <tr> 
    <td  valign="top" > Address of the Applicant's Office is correct</td>
      <td   valign="top"  >
          :</td>
    
      <td valign="top" >
          <asp:DropDownList ID="ddlAppOffCorrect" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>Not Confirmed</asp:ListItem>
    </asp:DropDownList></td>
    
  </tr>
  </table>
  <table  border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td colspan="7"  valign="top"  class="txtBold" style="background-color:#D0D5D8; height: 16px;">Observation</td>
  </tr>
  <tr> 
    <td valign="top" > Business Activity Seen</td>
      <td valign="top"  >
          :</td>
    <td valign="top" ><asp:DropDownList ID="ddlBusinessActivitySeen" SkinID="ddlSkin" runat="server">
    <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>UTV</asp:ListItem>
    </asp:DropDownList></td>
    <td> Number of Employees Seen </td>
    <td valign="top" >
        :</td>
      <td valign="top" >
          <asp:TextBox ID="txtNoEmployess" SkinID="txtSkin" runat="server" MaxLength="10"></asp:TextBox></td>
    <td valign="top" ></td>
  </tr>
  <tr> 
    <td valign="top"  > Equipment / Stock Sighted </td>
      <td valign="top"  >
          :</td>
    <td valign="top"><asp:TextBox ID="txtStock" SkinID="txtSkin" runat="server" MaxLength="255"></asp:TextBox></td>
    <td> Name Board Seen</td>
    <td valign="top" >
        :</td>
      <td  valign="top" >
          <asp:DropDownList ID="ddlNameBoard" SkinID="ddlSkin" runat="server">
          <asp:ListItem>--Select One--</asp:ListItem>
        <asp:ListItem>YES</asp:ListItem>
        <asp:ListItem>NO</asp:ListItem>
        <asp:ListItem>UTV</asp:ListItem>
    </asp:DropDownList></td>
    <td valign="top" ></td>
  </tr>
  <tr> 
    <td valign="top"  > Field Remarks</td>
      <td valign="top"  >
          :</td>
    <td valign="top">
        <asp:TextBox ID="txtFRemarks" SkinID="txtSkin" runat="server" Columns="60" Rows="3" TextMode="MultiLine" MaxLength="600" onkeypress="ValidateTextLength('Description', this, 600);"></asp:TextBox></td>
  </tr>
  </table>
  <table  border="0" width="100%" cellpadding="1" cellspacing="0" style="background-color:#E7F6FF">
  <tr> 
    <td colspan="7" class="txtBold"  style="background-color:#D0D5D8; height: 10px;" valign="top">
        Tele Log</td>
  </tr>
  <tr> 
    <td valign="top"  >Login</td>
      
    <td valign="top" style="width: 8px"  > </td>
    <td valign="top"> Date[dd/MM/yyyy]</td>
    <td valign="top"> Time[hh:mm]</td>
      
    <td valign="top" >
        Tell Number</td>
      <td valign="top" >
          Remark</td>
  </tr>
  <tr> 
    <td valign="top" style="height: 12px" > 1st call</td>
      <td valign="top" style="width: 8px; height: 12px;" >
          :</td>
    <td valign="top" style="height: 12px">
       <asp:TextBox ID="txtDate1" SkinID="txtSkin" runat="server" Width="85px" MaxLength="10"></asp:TextBox>
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" /></td>
         <td valign="top" style="height: 12px">
        <asp:TextBox ID="txtTime1" SkinID="txtSkin" runat="server" Width="30px" MaxLength="5" ></asp:TextBox>  <asp:DropDownList ID="ddlTimeType1" runat="server" CssClass="combo" SkinID="ddlSkin">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem></asp:DropDownList></td>
          <td valign="top" style="height: 12px" >
        <asp:TextBox ID="txtTelNo1" SkinID="txtSkin" runat="server" MaxLength="50"></asp:TextBox></td> 
          <td valign="top" style="height: 12px" >
        <asp:TextBox ID="txtRemarks1" SkinID="txtSkin" runat="server" MaxLength="255" TextMode="MultiLine" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>                          
    <td  valign="top" style="height: 12px">
        </td>
     
    
  </tr>
  <tr> 
    <td valign="top"  > 2nd call</td>
      <td valign="top" style="width: 8px"  >
          :</td>
      <td valign="top" >
          <asp:TextBox ID="txtDate2" runat="server" Width="85px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
          <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" /></td>
      <td valign="top" >
          <asp:TextBox ID="txtTime2" runat="server" Width="30px" SkinID="txtSkin"></asp:TextBox>
          <asp:DropDownList ID="ddlTimeType2" runat="server" CssClass="combo" SkinID="ddlSkin">
              <asp:ListItem Selected="True">AM</asp:ListItem>
              <asp:ListItem>PM</asp:ListItem>
          </asp:DropDownList></td>
      <td valign="top"  >
          <asp:TextBox ID="txtTelNo2" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
      <td valign="top" >
          <asp:TextBox ID="txtRemarks2" runat="server" SkinID="txtSkin" MaxLength="255" TextMode="MultiLine" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
    
    
  </tr>
  <tr> 
    <td valign="top" > 3rd call</td>
      <td valign="top" style="width: 8px"   >
          :</td>
      <td valign="top" >
          <asp:TextBox ID="txtDate3" runat="server" Width="85px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
          <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" /></td>
      <td valign="top" >
          <asp:TextBox ID="txtTime3" runat="server" Width="30px" SkinID="txtSkin"></asp:TextBox>
          <asp:DropDownList ID="ddlTimeType3" runat="server" CssClass="combo" SkinID="ddlSkin">
              <asp:ListItem Selected="True">AM</asp:ListItem>
              <asp:ListItem>PM</asp:ListItem>
          </asp:DropDownList></td>
      <td valign="top" >
          <asp:TextBox ID="txtTelNo3" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
      <td valign="top" >
          <asp:TextBox ID="txtRemarks3" runat="server" SkinID="txtSkin" MaxLength="255" TextMode="MultiLine" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
  
  </tr>
  <tr> 
    <td valign="top"   > 4th call</td>
      <td valign="top" style="width: 8px"    >
          :</td>
      <td valign="top">
          <asp:TextBox ID="txtDate4" runat="server" Width="85px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
          <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate4.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" /></td>
      <td valign="top">
          <asp:TextBox ID="txtTime4" runat="server" Width="30px" SkinID="txtSkin" ></asp:TextBox>
          <asp:DropDownList ID="ddlTimeType4" runat="server" CssClass="combo" SkinID="ddlSkin">
              <asp:ListItem Selected="True">AM</asp:ListItem>
              <asp:ListItem>PM</asp:ListItem>
          </asp:DropDownList></td>
      <td valign="top" >
          <asp:TextBox ID="txtTelNo4" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
      <td valign="top" >
          <asp:TextBox ID="txtRemarks4" runat="server" SkinID="txtSkin" MaxLength="255" TextMode="MultiLine" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
   
  </tr>
  <tr> 
    <td  valign="top"   > 5th call</td>
      <td style="width: 8px" >
          :</td>
      <td>
          <asp:TextBox ID="txtDate5" runat="server" Width="85px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
          <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate5.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" /></td>
      <td valign="top">
          <asp:TextBox ID="txtTime5" runat="server" Width="30px" SkinID="txtSkin"></asp:TextBox>
          <asp:DropDownList ID="ddlTimeType5" runat="server" CssClass="combo" SkinID="ddlSkin">
              <asp:ListItem Selected="True">AM</asp:ListItem>
              <asp:ListItem>PM</asp:ListItem>
          </asp:DropDownList></td>
      <td  valign="top">
          <asp:TextBox ID="txtTelNo5" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
      <td valign="top" >
          <asp:TextBox ID="txtRemarks5" runat="server" SkinID="txtSkin" MaxLength="255" TextMode="MultiLine" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
      </tr>
  <tr> 
    <td valign="top"  >Tele Remarks</td>
      <td  valign="top" style="width: 8px"  >
          :</td>
    <td valign="top"  >
        <asp:TextBox ID="txtTeleRemark" runat="server" Columns="60" SkinID="txtSkin" TextMode="MultiLine" MaxLength="255" onkeypress="ValidateTextLength('Description', this, 255);"></asp:TextBox></td>
    <td valign="top" ></td>
    <td  valign="top" ></td>
      <td  valign="top"  >
      </td>
    <td valign="top"  ></td>
  </tr>
  <tr> 
    <td valign="top"   >
        Date of Verification</td>
      <td valign="top" style="width: 8px"     >
          :</td>
    <td valign="top" ><asp:TextBox ID="txtVeriDate" SkinID="txtSkin" runat="server" Width="107px" MaxLength="10"></asp:TextBox>
     <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtVeriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />
        [dd/MM/yyyy]</td>
    <td valign="top" ></td>
    <td valign="top"  ></td>
      <td  >
      </td>
    <td valign="top"  ></td>
  </tr>
  <tr> 
    <td valign="top" > Final Status</td>
      <td valign="top" style="width: 8px" >
          :</td>
    <td valign="top" ><asp:DropDownList ID="ddlStatus" SkinID="ddlSkin" runat="server" OnDataBound="ddlStatus_DataBound" DataSourceID="SdsStatus" 
    DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID">
                  
            
        </asp:DropDownList>
        </td>
    <td >
        
        <asp:SqlDataSource ID="SdsStatus" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                          ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) order by case_status_id">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
                     </asp:SqlDataSource>
    </td >
    <td valign="top" ></td>
      <td >
      </td>
    <td valign="top"   ></td>
  </tr>
  <tr> 
    <td valign="top"> Name of FE</td>
      <td valign="top" style="width: 8px"  >
          :</td>
    <td valign="top"   >
        &nbsp;<asp:TextBox ID="txtFEName" SkinID="txtSkin" runat="server" ReadOnly="True"></asp:TextBox></td>
    <td valign="top"  >
        &nbsp;</td>
    <td valign="top" > </td>
      <td >
          </td>
    <td valign="top">
        &nbsp;</td>
  </tr>
  <tr> 
    <td valign="top" > </td>
      <td valign="top" style="width: 8px"  >
          </td>
    <td valign="top"  >
        &nbsp;</td>
    <td valign="top" >
        &nbsp;</td>
    <td valign="top" ></td>
      <td >
      </td>
    <td valign="top"  ></td>
  </tr>
  <tr> 
    <td valign="top" style="height: 60px" >
        &nbsp;</td>
      <td valign="top" style="width: 8px; height: 60px;"  >
      </td>
    <td valign="top" style="height: 60px">
        &nbsp;&nbsp;
    </td>
    <td style="height: 60px">
       <asp:ValidationSummary ID="valSum" runat="server" ShowMessageBox="True" ShowSummary="False"
            ValidationGroup="valsumDocVer" />
    </td>
    <td style="height: 60px" ></td>
      <td style="height: 60px"  >
      </td>
    <td valign="top" style="height: 60px"  ></td>
  </tr>
  <tr> 
    <td valign="top" colspan="6" >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" 
            Text="save" SkinID="btnSaveSkin" ValidationGroup="valsumDocVer" />
        <asp:Button ID="btnCancel" runat="server"  Text="Cancel" SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
    <td valign="top"  ></td>
  </tr>
</table>
    <asp:CustomValidator ID="valdate1" runat="server" ControlToValidate="txtDate1" Display="None"
        ErrorMessage="Please enter time for first attempt" SetFocusOnError="True" ValidationGroup="valsumDocVer" ClientValidationFunction="ValidateAttempt1"></asp:CustomValidator>
    <asp:CustomValidator ID="vadate2" runat="server" ClientValidationFunction="ValidateAttempt2"
        Display="None" ErrorMessage="Please enter time for second attempt" SetFocusOnError="True" ValidationGroup="valsumDocVer" ControlToValidate="txtDate2"></asp:CustomValidator>
    &nbsp;
    <asp:CustomValidator ID="vadate3" runat="server" ClientValidationFunction="ValidateAttempt3"
        ControlToValidate="txtDate3" Display="None" ErrorMessage="please enter time third attempt" ValidationGroup="valsumDocVer"></asp:CustomValidator>&nbsp;
    <asp:CustomValidator ID="valdate4" runat="server" ErrorMessage="Please enter time for fourth attempt" ClientValidationFunction="ValidateAttempt4" ControlToValidate="txtDate4" Display="None" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    <asp:CustomValidator ID="valdate5" runat="server" ErrorMessage="Please enter time for fifth attempt" ClientValidationFunction="ValidateAttempt5" ControlToValidate="txtDate5" Display="None" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    <asp:CustomValidator ID="valtime1" runat="server" ErrorMessage="Please enter date for first attempt " ControlToValidate="txtTime1" ValidationGroup="valsumDocVer" ClientValidationFunction="ValidateAttempt1" Display="None" SetFocusOnError="True"></asp:CustomValidator>
    <asp:CustomValidator ID="valtime2" runat="server" ErrorMessage="Please enter date for second attempt" ClientValidationFunction="ValidateAttempt2" Display="None" ControlToValidate="txtTime2" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    <asp:CustomValidator ID="valtime3" runat="server" ErrorMessage="Please enter date time third attempt" ClientValidationFunction="ValidateAttempt3" ControlToValidate="txtTime3" Display="None" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    <asp:CustomValidator ID="valtime4" runat="server" ErrorMessage="Please enter date for fourth attempt" ClientValidationFunction="ValidateAttempt4" ControlToValidate="txtTime4" Display="None" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    <asp:CustomValidator ID="valtime5" runat="server" ErrorMessage="Please enter date for fifth attempt" ClientValidationFunction="ValidateAttempt5" ControlToValidate="txtTime5" Display="None" SetFocusOnError="True" ValidationGroup="valsumDocVer"></asp:CustomValidator>
    </fieldset>
      
 <asp:RegularExpressionValidator ID="AttemptDate1" runat="server"  ControlToValidate="txtDate1"
                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="AttemptDate2" runat="server"  ControlToValidate="txtDate2"
                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer">
       </asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="AttemptDate3" runat="server"  ControlToValidate="txtDate3"
                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="AttemptDate4" runat="server"  ControlToValidate="txtDate4"
                    Display="None" ErrorMessage="Please enter valid date format for fourth attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator ID="AttemptDate5" runat="server"  ControlToValidate="txtDate5"
                    Display="None" ErrorMessage="Please enter valid date format for fifth attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>&nbsp;
       <asp:RegularExpressionValidator ID="AttemptTime1" runat="server"  ControlToValidate="txtTime1"
                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="AttemptTime2" runat="server"  ControlToValidate="txtTime2"
                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="AttemptTime3" runat="server"  ControlToValidate="txtTime3"
                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>                    
                <asp:RegularExpressionValidator ID="AttemptTime4" runat="server"  ControlToValidate="txtTime4"
                    Display="None" ErrorMessage="Please enter valid time format for Forth attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator> 
                     <asp:RegularExpressionValidator ID="AttemptTime5" runat="server"  ControlToValidate="txtTime5"
                    Display="None" ErrorMessage="Please enter valid time format for Fifth attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="valsumDocVer"></asp:RegularExpressionValidator>             
                     <asp:RegularExpressionValidator ID="valveridate" runat="server"  ControlToValidate="txtVeriDate"
                    Display="None" ErrorMessage="Please enter valid date format for verification date."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="valsumDocVer">
                      </asp:RegularExpressionValidator>
                      <asp:HiddenField ID="hdnTransStart" runat="server" />
</asp:Content>

