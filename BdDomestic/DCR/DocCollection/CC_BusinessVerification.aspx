<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile"AutoEventWireup="true" CodeFile="CC_BusinessVerification.aspx.cs" Inherits="CC_CC_BusinessVerification"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
       <!--
       
       function ValidateStatus()
       {
              var statusIndex=document.getElementById("<%=ddlCaseStatus.ClientID%>").selectedIndex;
              var status=document.getElementById("<%=ddlCaseStatus.ClientID%>").options[statusIndex].text;
              var outcome=document.getElementById("<%=ddlOutcome.ClientID%>");
              var declineReason=document.getElementById("<%=txtDeclineReason.ClientID%>");
              
              if(status =='DECLINE' || status =='NEGATIVE' || status =='Decline' || status =='Negative')
              {       
                    outcome.disabled=false;
                    declineReason.disabled=false;                  
              }
              
              if(status =='Accept' || status =='ACCEPT' || status =='Positive' || status =='POSITIVE' || status =='Refer To Bank' || status =='REFER TO BANK' || status =='Neutral' || status =='NEUTRAL')
              {
                    outcome.disabled=true;
                    declineReason.disabled=true;
                    statusIndex=0;
              }
       }
       
       function ValidateDeclineStatus(source, arguments)
       {
              var statusIndex=document.getElementById("<%=ddlCaseStatus.ClientID%>").selectedIndex;
              var status=document.getElementById("<%=ddlCaseStatus.ClientID%>").options[statusIndex].text;
              var outcome=document.getElementById("<%=ddlOutcome.ClientID%>");
              var declineReason=document.getElementById("<%=txtDeclineReason.ClientID%>");
              
              if(status =='DECLINE' || status =='NEGATIVE' || status =='Decline' || status =='Negative')
              {       
                    outcome.disabled=false;
                    declineReason.disabled=false;  
                           
                     if(outcome.selectedIndex == 0)
                    {                        
                        arguments.IsValid=false;
                    }
                    if(declineReason.value == '')
                    {                        
                        arguments.IsValid=false;                      
                    }
              }
       }
  function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 249)
     {
       getControlsId.value = getControlsId.value.substring( 0, 249 );            
       return false;
     }          
   }
   function ValidateTextLength(DisplayName, ControlName, xLength)
    {   
        
        if (ControlName.value.length > parseInt(xLength)-2)
        {                      
             ControlName.value = ControlName.value.substring( 0, parseInt(xLength)-1 ); 
             alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
             return false;         
        }      
    }
    
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
           if((document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length == 0) && (document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length == 0) && (document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length ==0))
           {
                arguments.IsValid = false;
           }
           else
           {
                arguments.IsValid = true;
           }
       }
 /*-----------------------Modified By Gargi Srivastava on 31-May-2007----------------------------------*/
////      function ValidateTime1(source, arguments)
////       { 
////          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
////          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length >0)
////          {            
////            if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length ==0)
////            {
////                document.aspnetForm.ctl00$C1$txtAttemptRemark1.focus();
////                arguments.IsValid=false;
////            }              
////          }
////       }
        function ValidateTime1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length ==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime1.focus();
                arguments.IsValid=false;
                        
          }
       }
//       function ValidateRemark1(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime1.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
//       function ValidateTime2(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark2.focus();
//                arguments.IsValid=false;
//            }   
//          }
//       }
        function ValidateTime2(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime2.focus();
                arguments.IsValid=false;
               
          }
       }
//       function ValidateRemark2(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime2.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
//       function ValidateTime3(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark3.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark3.focus();
//                arguments.IsValid=false;
//            }   
//          }
//       }

        function ValidateTime3(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length==0)
          {            
            
                document.aspnetForm.ctl00$C1$txtAttemptTime3.focus();
                arguments.IsValid=false;
             
          }
       }
//       function ValidateRemark3(source, arguments)
//       {
//           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
//           {                
//                if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length ==0)
//                {
//                    document.aspnetForm.ctl00$C1$txtAttemptTime3.focus();
//                    arguments.IsValid=false;
//                }
//           }
//       }
// -->
 /*-----------------------End----------------------------------*/


</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Business Verification</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%" style="background-color:#E7F6FF">
<tr><td style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
<tr><td></td><td>
 <!--Start ErrorMessgage-->
    <asp:Panel ID="pnlMsg" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server">
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblErrorMsg" ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
        </td>        
        </tr>
       </table>
   </asp:Panel>   
   <!--END ErrorMessgage-->  
   <!--Place holder Start-->
   <asp:Table ID="tblBusiVeri" runat="server"  Width="100%">
    <asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >  
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
    <asp:PlaceHolder ID="PlaceHolder77" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder78" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder79" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder80" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder81" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder82" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder83" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder84" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder85" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder86" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder87" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder88" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder89" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder90" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder91" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder92" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder93" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder94" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder95" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder96" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder97" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder98" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder99" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder100" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder101" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder102" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder103" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder104" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder105" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder106" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder107" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder108" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder109" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder110" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder111" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder112" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder113" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder114" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder115" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder116" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder117" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder118" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder119" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder120" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder121" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder122" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder123" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder124" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder125" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder126" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder127" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder128" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder129" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder130" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder131" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder132" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder133" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder134" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder135" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder136" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder137" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder138" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder139" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder140" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder141" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder142" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder143" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder144" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder145" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder146" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder147" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder148" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder149" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder150" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder151" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder152" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder153" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder154" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder155" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder156" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder157" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder158" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder159" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder160" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder161" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder162" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder163" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder164" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder165" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder166" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder167" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder168" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder169" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder170" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder171" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder172" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder173" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder174" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder175" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder176" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder177" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder178" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder179" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder180" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder181" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder182" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder183" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder184" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder185" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder186" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder187" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder188" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder189" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder190" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder191" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder192" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder193" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder194" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder195" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder196" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder197" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder198" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder199" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder200" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder201" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder202" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder203" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder204" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder205" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder206" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder207" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder208" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder209" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder210" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder211" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder212" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder213" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder214" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder215" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder216" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder217" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder218" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder219" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder220" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder221" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder222" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder223" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder224" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder225" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder226" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder227" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder228" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder229" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder230" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder231" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder232" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder233" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder234" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder235" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder236" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder237" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder238" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder239" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder240" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder241" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder242" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder243" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder244" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder245" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder246" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder247" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder248" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder249" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder250" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder251" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder252" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder253" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder254" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder255" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder256" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder257" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder258" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder259" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder260" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder261" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder262" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder263" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder264" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder265" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder266" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder267" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder268" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder269" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder270" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder271" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder272" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder273" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder274" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder275" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder276" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder277" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder278" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder279" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder280" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder281" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder282" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder283" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder284" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder285" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder286" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder287" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder288" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder289" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder290" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder291" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder292" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder293" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder294" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder295" runat="server"></asp:PlaceHolder>
     </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >
   <!--Place holder End-->
    <!--Start Heading-->
    <asp:Panel ID="pnlBusVerHead" runat="server" Width="100%" Visible="false">
    <table>
    <tr>
    <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
        <asp:Label SkinID="lblSkin" ID="lblBusVerHead" runat="server" ForeColor="blue" Text="BUSINESS VERIFICATION REPORT" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
    <!--END Heading-->
    <!--Start Personal Detail-->    
    <asp:Panel ID="pnlAppName" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAppName" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin"  ID="lblAppName" runat="server" Text=" Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtAppName" runat="server" ReadOnly="True" Width="60%"></asp:TextBox>
            </td>
          
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlRefNo" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth"><asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server" Text="CDM Referance No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtRefNo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlInitiationDate" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server"> 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server" Text="Date of Initiation"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td ><asp:TextBox SkinID="txtSkin"  ID="txtInitiationDate" runat="server" MaxLength="11" ReadOnly="True" ></asp:TextBox>
             <img id="imgInitiationDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtInitiationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
        </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlAgencyCode" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAgencyCode" style="width:100%" runat="server">      
           <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server" Text="Agency Code"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtAgencyCode" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeAddress" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAddress" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeAddress" runat="server" Text="Address (Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeAddress" runat="server"  Width="80%" MaxLength="255" ></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlPinCode" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPinCode" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPincode" runat="server" Text="Pincode"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtPincode" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlLandmark" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server" Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  >
                <asp:TextBox SkinID="txtSkin"  ID="txtLandmark" runat="server" MaxLength="25"></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeTel" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeTel" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeTel" runat="server" Text="Telephone No(Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeTel" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlPPNormal" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPPNormal" style="width:100%" runat="server">             
    <tr>
         <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPPNormal" runat="server" Text="Telehone No (Office)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtPPNormal" runat="server"></asp:TextBox>
            
            <asp:DropDownList SkinID="ddlSkin" ID="ddlPPNormal" runat="server"  AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>PP</asp:ListItem>
                <asp:ListItem>Normal</asp:ListItem>
            </asp:DropDownList></td>
            
             </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlOfficeExtn" runat="server" Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeExtn" style="width:100%" runat="server">
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOfficeExtn" runat="server" Text="Extn No (If any)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtOfficeExtn" runat="server" MaxLength="5"></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlMobile" runat="server" Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblMobile" style="width:100%" runat="server">             
    <tr>
    <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblMobile" runat="server" Text="Mobile No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtMobile" runat="server" ReadOnly="true"></asp:TextBox></td>
            
        </tr>
    </table>
    </asp:Panel>
    
    <!--END Personal Detail-->
    <!--Start Verification Head-->
    <asp:Panel ID="pnlVerDtlHead" runat="server" Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center" style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold">
        <asp:Label SkinID="lblSkin" ID="lblVerDtlHead" runat="server" ForeColor="blue" Text="VERIFICATION DETAILS" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
    <!--END Verification Head-->
    <!--Start Verification Details-->    
        <asp:Panel ID="pnlContactPersonName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblContactPersonName" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContactPersonName" runat="server" Text="Name of person contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtContactPersonName" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlContPersonDesgn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblContPersonDesgn" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContPersonDesgn" runat="server" Text="Designation of person contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtContPersonDesgn" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlPersonContact" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPersonContact" style="width:100%" runat="server">
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonContact" runat="server" Text="Person Contacted"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtPersonContact" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
        </table>
    </asp:Panel>
        <asp:Panel ID="pnlCompanyName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblCompanyName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblCompanyName" runat="server" Text="Name of Firm/Company"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  Width="60%" ID="txtCompanyName" runat="server" MaxLength="100" ></asp:TextBox>
            </td>
            </tr>
          </table>
        </asp:Panel>                
        <asp:Panel ID="pnlNoOfYrCompany" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrCompany" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblNoOfYrCompany" runat="server" Text="No of years of existence of company"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrCompany" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlDesgnOfApplicant" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDesgnOfApplicant" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDesgnOfApplicant" runat="server" Text="Designation of applicant"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="80%"  ID="txtDesgnOfApplicant" runat="server" MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>        
        <asp:Panel ID="pnlTimeCurr" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurr" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblTimeCurrOffYrs" runat="server" Text="Time at curr empl/business (Yrs/mths)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtTimeCurrOffYrs" runat="server"  MaxLength="2"></asp:TextBox>Yrs             
             <asp:TextBox SkinID="txtSkin" Width="5%"   ID="txtTimeCurrOffMths" runat="server"  MaxLength="2"></asp:TextBox>Mths
             </td>            
             
            </tr>
            </table>
        </asp:Panel>                
        <asp:Panel ID="pnlTypeOfJob" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfJob" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblTypeOfJobo" runat="server" Text="Type of Job/emp"></asp:Label>    
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfJob" runat="server"  AutoPostBack="false">
                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Contract Worker" Value="Contract Worker"></asp:ListItem>
                <asp:ListItem Text="Permanent" Value="Permanent"></asp:ListItem>
                <asp:ListItem Text="Probation" Value="Probation"></asp:ListItem>
                <asp:ListItem Text="Temporary Worker" Value="Temporary Worker"></asp:ListItem>            
            </asp:DropDownList>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlOffPrmises" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblOffPrmises" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblOffPrmises" runat="server" Text="Office/Business premises"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin" ID="ddlOffPrmises" runat="server"  AutoPostBack="false">
            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                <asp:ListItem Text="Pagdi" Value="Pagdi"></asp:ListItem>
                </asp:DropDownList>            
            </td>
            </tr>
            </table>
         </asp:Panel>  
         <asp:Panel ID="pnlOtherOffPrmises" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherOffPrmises" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOffPrmises" runat="server" Text="If Others spcify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtOtherOffPrmises" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>       
         <!--End Verification Detail-->
          <!--Start Heading-->
        <asp:Panel ID="pnlAdditonalInfoHead" runat="server" Width="100%" Visible="false">
        <table> <tr>
        <td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center">         
        <asp:Label SkinID="lblSkin" ID="lblAdditonalInfoHead" runat="server" ForeColor="blue" Text="IF APPLICANT IS CONTACTED (ADDITIONAL INFORMATION TO BE OBTAINED)" Font-Bold="True"></asp:Label>
        </td>
        </tr>  
        </table>

        </asp:Panel>
        <!--END Heading-->
        <!--Start Additional Information-->
        <asp:Panel ID="pnlDOB" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin"  ID="txtDOB" runat="server" MaxLength="11" ></asp:TextBox>
             <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
           </td>
           </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlIncomeDoc" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIncomeDoc" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIncomeDoc" runat="server" Text="Income document submitted with application"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td style="height: 21px">
            <asp:DropDownList SkinID="ddlSkin" ID="ddlIncomeDoc" runat="server"  AutoPostBack="false">
                 <asp:ListItem>NA</asp:ListItem>
                 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                 <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>  
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPerAddress" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddress" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPerAddress" runat="server" Text="Permanent Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtPerAddress" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlVerPhoneNo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVerPhoneNo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblVerPhoneNo" runat="server" Text="Phone No"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtVerPhoneNo" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlAddOnApplication" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAddOnApplication" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblAddOnApplication" runat="server" Text="Given Resi Add On Application(Y/N)"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtAddOnApplication"  Width="80%" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPhOnApplication" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPhOnApplication" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
            <asp:Label SkinID="lblSkin" ID="lblPhOnApplication" runat="server" Text="Phone No"></asp:Label>            
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtPhOnApplication" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <!--End Additional Information-->                         
        <!--Start Observation Head-->
        <asp:Panel ID="pnlObservationHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
            <asp:Label SkinID="lblSkin" ID="lblObservationHead" runat="server" ForeColor="blue" Text="OBSERVATIONS" Font-Bold="True"></asp:Label>
        </td>
        </tr>
        </table>
        </asp:Panel>        
        <!--END Observation Head-->
        <!--Start OBSERVATIONS-->
        <asp:Panel ID="pnlVisibleNameBoard" runat="server" Width="100%" Visible="false">                
        <table cellpadding="0" cellspacing="0" border="0" id="tblVisibleNameBoard" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisibleNameBoard" runat="server" Text="Visibility of the name board"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisibleNameBoard" runat="server"  AutoPostBack="false">
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
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVisibleNameBoard" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVisibleNameBoard" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNonVisibleReason" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNonVisibleReason" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNonVisibleReason" runat="server" Text="If non visible then the reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNonVisibleReason" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOfficeSize" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeSize" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeSize" runat="server" Text="Size of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td   >
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeSize" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Very small</asp:ListItem>
                    <asp:ListItem>Small</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Large</asp:ListItem>                    
                    <asp:ListItem>Very Large</asp:ListItem>                    
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlApproxArea" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblApproxArea" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server" Text="Approx. area (sq ft)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtApproxArea" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlNoOfEmployee" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployee" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfEmployee" runat="server" Text="No. of employees"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmployee" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlGenAppearance" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblGenAppearance" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblGenAppearance" runat="server" Text="General appearance of the office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlGenAppearance" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Fair</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>                    
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlLocalityOffice" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocalityOffice" runat="server" Text="Locality of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocalityOffice" runat="server"  AutoPostBack="false">
                    <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Commercial Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Shop/Office Complex</asp:ListItem>
                    <asp:ListItem>Small Scale Industrial Area</asp:ListItem>
                    <asp:ListItem>Plant</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherLocalityOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherLocalityOffice" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlReputationOffice" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblReputationOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblReputationOffice" runat="server" Text="Reputation of off in the locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlReputationOffice" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Fair</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        
        
        <asp:Panel ID="pnlLocatingOfficeAdd" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocatingOfficeAdd" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocatingOfficeAdd" runat="server" Text="Locating the office address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingOfficeAdd" runat="server"  AutoPostBack="false">
                    <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                    <asp:ListItem>Untraceable</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
       <asp:Panel ID="pnlOfficeIsIn" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeIsIn" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeIsIn" runat="server" Text="Office is in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeIsIn" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Commercial Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Shop/Office Complex</asp:ListItem>
                    <asp:ListItem>Small Scale Industrial Area</asp:ListItem>
                    <asp:ListItem>Plant</asp:ListItem>
                    <%--asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem--%>
                    <asp:ListItem>Others</asp:ListItem>                                 
                </asp:DropDownList>   
                </td>                
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherOfficeIsIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherOfficeIsIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOfficeIsIn" Width="80%" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherOfficeIsIn"  Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlBusinessType" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessType" runat="server" Text="Type of business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessType" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Partnership</asp:ListItem>
                    <asp:ListItem>Public Ltd.</asp:ListItem>
                    <asp:ListItem>Proprietorship</asp:ListItem>
                    <asp:ListItem>Private Ltd.</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlOtherBusinessType" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherBusinessType" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherBusinessType" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherBusinessType" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
          <asp:Panel ID="pnlAffPolParty" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAffPolParty" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAffPolParty" runat="server" Text="Affiliation of Political party seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlAffPolParty" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
        <asp:Panel ID="pnlEquipInOffice" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblEquipInOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEquipInOffice" runat="server" Text="Equipments sighted in office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkEquipInOffice" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
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
                </table>
        </asp:Panel>
        <asp:Panel ID="pnltOtherEquipInOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tbltOtherEquipInOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lbltOtherEquipInOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherEquipInOffice" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlBusinessStock" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessStock" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessStock" runat="server" Text="Business stock seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessStock" runat="server"  AutoPostBack="false">
                    <asp:ListItem>N/C</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlStockType" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblStockType" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblStockType" runat="server" Text="Type of stock"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtStockType" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
       <asp:Panel ID="pnlBusinessActivity" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessActivity" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessActivity" runat="server" Text="Business activity seen"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlBusinessActivity" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>   
                    <asp:ListItem>Low</asp:ListItem>   
                    <asp:ListItem>None</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlVisitProof" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblVisitProof" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblVisitProof" runat="server" Text="Proof of Visit Collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitProof" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVisitProof" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVisitProof" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlRouteMap" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRouteMap" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblRouteMap" runat="server" Text="Route map drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRouteMap" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>            
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNegativeArea" runat="server" Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeArea" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNegativeArea" runat="server" Text="Negative area"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNegativeArea" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOCL" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOCL" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOCL" runat="server" Text="OCL"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlOCL" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>    
        </asp:Panel>  
        <!--END OBSERVATIONS-->
        <!--Start Rating HEAD-->
       <asp:Panel ID="pnlTPCHead" runat="server" Width="100%" Visible="false">
       <table>
       <tr>
       <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblTPCHead" runat="server" ForeColor="blue" Text="Third Party Confirmation" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Rating HEAD-->
        <!--Start Internal TPC HEAD-->
       <asp:Panel ID="pnlInternalHead" runat="server" Width="100%" Visible="false">
          <table>
          <tr>
          <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblInternalHead" ForeColor="blue" runat="server" Text="INTERNAL"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Internal TPC HEAD-->
        <!--Start Third Party Confirmation-->        
         <asp:Panel ID="pnlTPCDone" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDone" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCDone" runat="server" Text="TPC Done"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCDone" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                    <%--<asp:ListItem>+ve</asp:ListItem>
                    <asp:ListItem>-ve</asp:ListItem>--%>
                    <asp:ListItem>Not Possible</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlTPCDetail" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDetail" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCDetail" runat="server" Text="Details of TPC"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtTPCDetail" runat="server" MaxLength="255" Width="80%"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>  
         <asp:Panel ID="pnlEntryRestricted" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblEntryRestricted" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblEntryRestricted" runat="server" Text="Entry Restricted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlEntryRestricted" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel> 
        <asp:Panel ID="pnlAnyInfo" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAnyInfo" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblAnyInfo" runat="server" Text="Any other information obtained"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                <asp:TextBox SkinID="txtSkin"  ID="txtAnyInfo" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
         <!--Start External TPC HEAD-->
       <asp:Panel ID="pnlExternalHead" runat="server" Width="100%" Visible="false">
          <table>
          <tr>
          <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
          <asp:Label SkinID="lblSkin" ID="lblExternalHead" ForeColor="blue" runat="server" Text="EXTERNAL"></asp:Label>
          </td>
          </tr>
          </table>    
       </asp:Panel>
      <!--END External TPC HEAD-->        
        <asp:Panel ID="pnlTPCNameCompanyName" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="yblTPCNameCompanyName" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTPCNameCompanyName" runat="server" Text="Name of the TPC with Company/shop name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtTPCNameCompanyName" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
         <asp:Panel ID="pnlNoOfYrsPresentAddress" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfYrsPresentAddress" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfYrsPresentAddress" runat="server" Text="No of years at the present address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfYrsPresentAddress" runat="server" MaxLength="9" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlBusinessNature" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblBusinessNature" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblBusinessNature" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtBusinessNature" runat="server" MaxLength="100" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNoOfEmployeeTPC" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmployeeTPC" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblNoOfEmployeeTPC" runat="server" Text="No. of employee"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmployeeTPC" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlFERemark" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFERemark" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblFERemark" runat="server" Text="FE Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtFERemark" runat="server" Width="80%" TextMode="MultiLine"  MaxLength="750" onkeyPress="ValidateTextLength('FE Remark', this, 749);" ></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
       <!--END Third Party Confirmation-->
       <!--Start Rating HEAD-->
       <asp:Panel ID="pnlRatingHead" runat="server" Width="100%" Visible="false">
       <table>
       <tr>
       <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%">
          <asp:Label SkinID="lblSkin" ID="lblRatingHead" runat="server" ForeColor="blue" Text="RATING" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       </table>
       </asp:Panel>
       <!--END Rating HEAD-->
       <!--Start RATING-->    
             
         <asp:Panel ID="pnlAddConfirmation" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfirmation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblAddConfirmation" runat="server" Text="Address Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlAddConfirmation" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
               </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlContactability" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblContactability" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth"  >
                    <asp:Label SkinID="lblSkin" ID="lblContactability" runat="server" Text="Contactability"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlContactability" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlConfirmationApp" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConfirmationApp" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConfirmationApp" runat="server" Text="Confirmation of Application"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlConfirmationApp" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>            
                </tr>        
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlProfile" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProfile" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfile" runat="server" Text="Profile"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlProfile" runat="server"  AutoPostBack="false">
                     <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
           </table>
           </asp:Panel>
           <asp:Panel ID="pnlReputationTPC" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblRepurationTPC" style="width:100%" runat="server">
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReputationTPC" runat="server" Text="Reputation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                       <asp:DropDownList SkinID="ddlSkin" ID="ddlReputationTPC" runat="server"  AutoPostBack="false">
                            <asp:ListItem>NA</asp:ListItem>
                            <asp:ListItem>a</asp:ListItem>
                            <asp:ListItem>b</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
           </table>
           </asp:Panel>                            
           <asp:Panel ID="pnlOverallAsst" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOverallAsst" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOverallAsst" runat="server" Text="Overall Assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtOverallAsst" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlAsstReason" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAsstReason" style="width:100%" runat="server">
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAsstReason" runat="server" Text="Reasons for the above assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAsstReason" runat="server" Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <!--END RATING-->
            <!--Start to ADD Additional Field-->
            <asp:Panel ID="pnlCoAppName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCoAppName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCoAppName" runat="server" Text="Co-App Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtCoAppName" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>           
           <asp:Panel ID="pnlExtNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExtNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExtNo" runat="server" Text="Ext. No."></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtExtNo" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlParticulars" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblParticulars" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblParticulars" runat="server" Text="Particulars"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtParticulars" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAverageMonthlyTurnover" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAverageMonthlyTurnover" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAverageMonthlyTurnover" runat="server" Text="( FOR SELF Employed) Average Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtAverageMonthlyTurnover" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoCustomersPerDay" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoCustomersPerDay" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoCustomersPerDay" runat="server" Text="No. of Customers per day"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNoCustomersPerDay" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlApplicantJobTransferable" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantJobTransferable" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicantJobTransferable" runat="server" Text="Applicant Job Transferable"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                    
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantJobTransferable" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlPreviousEmploymentDetails" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPreviousEmploymentDetails" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPreviousEmploymentDetails" runat="server" Text="Previous Employment details( if working for< 1 year in current employment)"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtPreviousEmploymentDetails" runat="server"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameofCompany" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameofCompany" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameofCompany" runat="server" Text="Name of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td  >
                    <asp:TextBox SkinID="txtSkin" Width="60%" ID="txtNameofCompany" runat="server"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlYearsWorkedIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsWorkedIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsWorkedIn" runat="server" Text="Years worked in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtYearsWorkedIn" runat="server" MaxLength="2"></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" Width="5%"  ID="txtMthsWorkedIn"  runat="server" MaxLength="2"></asp:TextBox>Mths                      
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSalaryDrawn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSalaryDrawn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSalaryDrawn" runat="server" Text="Salary Drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin"  ID="txtSalaryDrawn" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlConstructionOfOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConstructionOfOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConstructionOfOffice" runat="server" Text="Construction of office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlConstructionOfOffice" runat="server"  AutoPostBack="false">
                        <asp:ListItem>N/C</asp:ListItem>
                        <asp:ListItem>Pukka</asp:ListItem>
                        <asp:ListItem>Semi-Pukka</asp:ListItem> 
                        <asp:ListItem>Temporary</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlNoOfCustomersSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfCustomersSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfCustomersSeen" runat="server" Text="No. of Customers Seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfCustomersSeen" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlPriorityCustomer" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPriorityCustomer" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPriorityCustomer" runat="server" Text="Priority Customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtPriorityCustomer" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlSegmentation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSegmentation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSegmentation" runat="server" Text="Segmentation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSegmentation" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlInfoRequired" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRequired" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRequired" runat="server" Text="Info. Required"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtInfoRequired" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlChangeAddress" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblChangeAddress" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblChangeAddress" runat="server" Text="Change Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlChangeAddress" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlReasonForChanges" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForChanges" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForChanges" runat="server" Text="If yes, Reason for Changes"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin"  ID="txtReasonForChanges" runat="server" Width="80%" MaxLength="50"></asp:TextBox>                    
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelationofPersonContacted" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationofPersonContacted" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblRelationofPersonContacted" runat="server" Text="Relation of Person Contacted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlRelationofPersonContacted" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>ABNR</asp:ListItem>
                        <asp:ListItem>Brother</asp:ListItem>
                        <asp:ListItem>Childern</asp:ListItem>
                        <asp:ListItem>Father</asp:ListItem>
                        <asp:ListItem>Friends</asp:ListItem>
                        <asp:ListItem>Grandfather</asp:ListItem>
                        <asp:ListItem>Grandmother</asp:ListItem>
                        <asp:ListItem>Husband</asp:ListItem>                        
                        <asp:ListItem>Inlaws</asp:ListItem>                        
                        <asp:ListItem>Mother</asp:ListItem>
                        <asp:ListItem>Sister</asp:ListItem>
                        <asp:ListItem>Wife</asp:ListItem>
                        <asp:ListItem>Others(Pl.Specify)</asp:ListItem>
                    </asp:DropDownList>
                </td>                 
            </tr>
            </table>               
           </asp:Panel>
           <asp:Panel ID="pnlOtherRelation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherRelation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherRelation" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherRelation" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlDeatailsOfProofCollected" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDeatailsOfProofCollected" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDeatailsOfProofCollected" runat="server" Text="(If Proof collect =Yes) Deatails of Proof collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDeatailsOfProofCollected" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="pnlOthers1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOthers1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOthers1" runat="server" Text="others1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOthers1" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             <asp:Panel ID="pnlOthers2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOthers2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOthers2" runat="server" Text="others2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOthers2" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            
           <asp:Panel ID="pnlCPVscore" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCPVscore" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCPVscore" runat="server" Text="CPV score"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCPVscore" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResiCumoff" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResiCumoff" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResiCumoff" runat="server" Text="If Nature of Busi Resi Cum off"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResiCumoff" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoofYrsatthisAdd" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoofYrsatthisAdd" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoofYrsatthisAdd" runat="server" Text="No. of Yrs at this Add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin"  ID="txtNoofYrsatthisAdd" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNoofResidents" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoofResidents" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoofResidents" runat="server" Text="No. of Residents"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                <asp:TextBox SkinID="txtSkin"  ID="txtNoofResidents" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlTypeofResi" runat="server" Width="100%" Visible="false">
             <table id="tblTypeofResi" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblTypeofResi" runat="server" Text="Type of Resi"></asp:Label>
                </td>
                <td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                 <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofResi" runat="server"  AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem> 
                    <asp:ListItem Text="Bachelor acco" Value="Bachelor acco"></asp:ListItem>                
                    <asp:ListItem Text="Co.Provided" Value="Co.Provided"></asp:ListItem>
                    <asp:ListItem Text="Family/Ancestral" Value="Family/Ancestral"></asp:ListItem>
                    <asp:ListItem Text="Own" Value="Own"></asp:ListItem>                
                    <asp:ListItem Text="Paying guest" Value="Paying guest"></asp:ListItem>                
                    <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
            </table>
           </asp:Panel>
            <asp:Panel ID="pnlResicomoffOwned" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResicomoffOwned" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResicomoffOwned" runat="server" Text="IF Resi. cum off Owned ( Fly/ Self owned)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResicomoffOwned" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Fly</asp:ListItem>
                        <asp:ListItem>Self owned</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlSeparateareforOff" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSeparateareforOff" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSeparateareforOff" runat="server" Text="Separate are for Off"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlSeparateareforOff" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlTypeofacco" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeofacco" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeofacco" runat="server" Text="Type of acco."></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeofacco" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlInformationRefused" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInformationRefused" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInformationRefused" runat="server" Text="Information refused"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                  <asp:TextBox SkinID="txtSkin"  ID="txtInformationRefused" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAssetsSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAssetsSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAssetsSeen" runat="server" Text="Assets seen"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                   
                    <asp:CheckBoxList ID="chkAssetsSeen" runat="server" RepeatColumns="8" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                        <asp:ListItem>AC</asp:ListItem>
                        <asp:ListItem>PC</asp:ListItem>
                        <%--asp:ListItem>Cooler</asp:ListItem>
                        <asp:ListItem>Music System</asp:ListItem>
                        <asp:ListItem>Refrigerator</asp:ListItem>
                        <asp:ListItem>TV</asp:ListItem--%>                       
                        <asp:ListItem>Xerox</asp:ListItem>
                        <asp:ListItem>Telephone</asp:ListItem>
                        <asp:ListItem>Fax</asp:ListItem>
                        <asp:ListItem>Printer</asp:ListItem>
                        <asp:ListItem>Others(specify)</asp:ListItem>
                    </asp:CheckBoxList>  
                </td>
                </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlOtherAssestSeen" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherAssestSeen" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherAssetsSeen" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherAssestSeen" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
             <asp:Panel ID="pnlBranches" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranches" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranches" runat="server" Text="Branches"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtBranches" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlIfAppFullTimeEmp" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfAppFullTimeEmp" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfAppFullTimeEmp" runat="server" Text="If the Applicant is a full time Employee"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIfAppFullTimeEmp" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlApproximateAppAge" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproximateAppAge" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproximateAppAge" runat="server" Text="Approximate Applicant age"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtApproximateAppAge" runat="server" Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <asp:Panel ID="pnlTPCTypeofCompany" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCTypeofCompany" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPCTypeofCompany" runat="server" Text="TPC Type of Company"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCTypeofCompany" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlTPCTypeofBusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCTypeofBusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPCTypeofBusiness" runat="server" Text="TPC Type of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCTypeofBusiness" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResonsAddrnotconfirmed" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResonsAddrnotconfirmed" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResonsAddrnotconfirmed" runat="server" Text="Reasons for address not confirmed"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlResonsAddrnotconfirmed" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>a</asp:ListItem>
                        <asp:ListItem>b</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
                 <asp:Panel ID="pnlUntreaceablereason" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblUntreaceablereason" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblUntreaceablereason" runat="server" Text="If Adress not confirmed = Untreaceable reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtUntreaceablereason" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <asp:Panel ID="pnlLocality" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocality" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblLocality" runat="server" Text="Locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocality" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Low class area</asp:ListItem>
                    <asp:ListItem>Lower Middle class</asp:ListItem>
                    <asp:ListItem>Middle class</asp:ListItem>
                    <asp:ListItem>Upper Middle class</asp:ListItem>
                    <asp:ListItem>Posh</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlResultofCalling" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResultofCalling" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblResultofCalling" runat="server" Text="Result of Calling"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtResultofCalling" runat="server" Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
              <asp:Panel ID="pnlMismatchresidenceadd" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMismatchresidenceadd" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMismatchresidenceadd" runat="server" Text="Mismatch In residence add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtMismatchresidenceadd" runat="server" Width="80%" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
               <asp:Panel ID="pnlIsApplicantknowntotheperson" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsApplicantknowntotheperson" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsApplicantknowntotheperson" runat="server" Text="is Applicant known to the person"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlIsApplicantknowntotheperson" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
              <asp:Panel ID="pnlwhomdoesaddbelong" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblwhomdoesaddbelong" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblwhomdoesaddbelong" runat="server" Text="To whom does the add belong"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtwhomdoesaddbelong" runat="server" Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            
               <asp:Panel ID="pnlApplMetat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplMetat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplMetat" runat="server" Text="Appl. Met at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlApplMetat" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>His Desk</asp:ListItem>
                        <asp:ListItem>Reception</asp:ListItem>            
                        <asp:ListItem>Other</asp:ListItem> 
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlOtherApplMetat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherApplMetat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherApplMetat" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherApplMetat" Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
               <asp:Panel ID="pnlVerificationconductedat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVerificationconductedat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblVerificationconductedat" runat="server" Text="Verification conducted at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlVerificationconductedat" runat="server"  AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Applicant's Address</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlOtherVerificationconductedat" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVerificationconductedat" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVerificationconductedat" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVerificationconductedat" Width="80%" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
            <asp:Panel ID="pnlDirectoryCheck" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDirectoryCheck" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDirectoryCheck" runat="server" Text="Directory Check"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:CheckBoxList ID="chkDirectoryCheck" runat="Server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                        <asp:ListItem>W01-Both Matched</asp:ListItem>
                        <asp:ListItem>W02-Both Mismatches</asp:ListItem>
                        <asp:ListItem>W03-Name Matched Address Mismatched</asp:ListItem>
                        <asp:ListItem>W04-Address Matched Name Mismatched</asp:ListItem>
                        <asp:ListItem>W05-Not Found in Web Check, Invalid No.</asp:ListItem>
                        <asp:ListItem>W06-PVT Checked</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlSupervisorReamarks" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSupervisorReamarks" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSupervisorReamarks" runat="server" Text="Supervisor Reamarks"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtSupervisorReamarks" runat="server" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlWhoareyourcustomer" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblWhoareyourcustomer" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblWhoareyourcustomer" runat="server" Text="Who are your customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtWhoareyourcustomer" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlNeighbour2Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbour2Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbour2Name" runat="server" Text="Neighbour 2 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbour2Name" runat="server" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlNeighbour2Add" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbour2Add" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbour2Add" runat="server" Text="Neighbour 2 Add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtNeighbour2Add" runat="server" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlCoEstabilshedIn" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCoEstabilshedIn" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCoEstabilshedIn" runat="server" Text="Co. Estabilshed in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin"  ID="txtCoEstabilshedIn" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
           <!--START Added New Panels-->
           <asp:Panel ID="pnlVerifiedFrom" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVerifiedFrom" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblVerifiedFrom" runat="server"  Text="Verified from"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlVerifiedFrom" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Colleague" Value="Colleague"></asp:ListItem>
                        <asp:ListItem Text="Receptionist" Value="Receptionist"></asp:ListItem>
                        <asp:ListItem Text="Security" Value="Security"></asp:ListItem>   
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    </tr>
                    </table>
            </asp:Panel>             
            <asp:Panel ID="pnlInterior" runat="server"  Width="100%" Visible="false"> 
                <table cellpadding="0" cellspacing="0" border="0" id="tblInterior" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblInterior" runat="server"  Text="Interior" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                    
                    <asp:CheckBoxList ID="chkInterior" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="horizontal">                    
                        <asp:ListItem>Painted</asp:ListItem>
                        <asp:ListItem>carpeted</asp:ListItem>                 
                        <asp:ListItem>curtains</asp:ListItem>
                        <asp:ListItem>clean</asp:ListItem>                                               
                        <asp:ListItem>N/C</asp:ListItem>
                        <asp:ListItem>Others(P1. Specify)</asp:ListItem>                
                </asp:CheckBoxList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherInterior" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherInterior" Width="80%" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlExterior" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExterior" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblExterior" runat="server"  Text="Exterior" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlExterior" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="N/C" Value="N/C"></asp:ListItem>
                        <asp:ListItem Text="Good" Value="Good"></asp:ListItem>
                        <asp:ListItem Text="Average" Value="Average"></asp:ListItem>
                        <asp:ListItem Text="Poor" Value="Poor"></asp:ListItem>                                                            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOtherVerified" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVerified" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVerified" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVerified" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="pnlTypeOfOffice" runat="server" Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfOffice" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblTypeOfOffice" runat="server" Text="Type of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfOffice" runat="server"  AutoPostBack="false">
                     <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Business Center</asp:ListItem>
                    <asp:ListItem>Office Complex</asp:ListItem>
                    <asp:ListItem>Industry/Factory</asp:ListItem>
                    <asp:ListItem>Residence cum Office</asp:ListItem>
                    <asp:ListItem>Shop</asp:ListItem>
                    <asp:ListItem>Clinic</asp:ListItem>
                    <asp:ListItem>Shared Office</asp:ListItem>
                    <asp:ListItem>Independent Office</asp:ListItem>
                    <asp:ListItem>Small Scale/Shed</asp:ListItem>
                    <%--asp:ListItem>Plant</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Average</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem--%>
                    <asp:ListItem>Others</asp:ListItem>                            
                </asp:DropDownList>   
                </td>                
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherTypeOfOffice" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherTypeOfOffice" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
         
         <asp:Panel ID="pnlApplicantWorkingAs" runat="server" Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantWorkingAs" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblApplicantWorkingAs" runat="server" Text="Applicant working as"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlApplicantWorkingAs" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Sr/Mid. Management</asp:ListItem>
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>Jr. Management</asp:ListItem>
                    <asp:ListItem>Assistant</asp:ListItem>
                    <asp:ListItem>Clerk</asp:ListItem>
                    <asp:ListItem>Typist</asp:ListItem>
                    <asp:ListItem>Middle Management</asp:ListItem>
                    <asp:ListItem>Stenographer</asp:ListItem>
                    <asp:ListItem>Skilled Labor</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>                   
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherApplicantWorkingAs" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherApplicantWorkingAs" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
            <!--END Added New Panels-->                  
            <!--END to ADD Additional Field-->
            
           <!--Start of ATTEMPT DETAIL-->
            
         <!--Start of Fields For City Bank (Dubai)-->
         
          <asp:Panel ID="pnlFaxNumber" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFaxNumber" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFaxNumber" runat="server" Text="Fax Number"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFaxNumber" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsThereSecurityGuardForBuildingOffice" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsThereSecurityGuardForBuildingOffice" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsThereSecurityGuardForBuildingOffice" runat="server"  Text="Is there a security guard for the building / office" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsThereSecurityGuardForBuildingOffice" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsThereReceptionDesk" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsThereReceptionDesk" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsThereReceptionDesk" runat="server"  Text="Is there a reception desk" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsThereReceptionDesk" runat="server"   AutoPostBack="false"> 
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>               
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           
          <asp:Panel ID="pnlHowManyDesksWorkStationsTables" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblHowManyDesksWorkStationsTables" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblHowManyDesksWorkStationsTables" runat="server" Text="How many desks / workstations / tables?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtHowManyDesksWorkStationsTables" runat="server" MaxLength="50" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsTradeLicenseOfCompanyDisplayedOnPremises" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"  Text="Is the trade license of the company displayed on the premises" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlIsTradeLicenseOfCompanyDisplayedOnPremises" runat="server"   AutoPostBack="false"> 
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>               
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>                                                                                
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label1" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherIsTradeLicenseOfCompanyDisplayedOnPremises"  Width="80%" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNumberOfEmployees" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfEmployees" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNumberOfEmployees" runat="server" Text="Number of employees?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfEmployees" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
      <!--Start of Head For Number of Branches / Offices / Warehouses?-->      
        <asp:Panel ID="pnlNumberOfBranchesOfficesWarehousesHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblNumberOfBranchesOfficesWarehousesHead" runat="server" ForeColor="blue" Text="NUMBER OF BRANCHES / OFFICES / WAREHOUSES?" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Number of Branches / Offices / Warehouses?---> 
       <asp:Panel ID="pnlBranch1Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Location" runat="server" Text="Branch 1 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1Telephoneno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Telephoneno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Telephoneno" runat="server" Text="Branch 1 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Telephoneno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1RentalAmt" runat="server" Text="Branch 1 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch1Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1Faxno" runat="server" Text="Branch 1 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="pnlBranch1ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch1ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch1ManagerName" runat="server" Text="Branch 1 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch1ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2Location" runat="server" Text="Branch 2 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2TelephoneNo" runat="server" Text="Branch 2 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2RentalAmt" runat="server" Text="Branch 2 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2Faxno" runat="server" Text="Branch 2 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch2ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch2ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch2ManagerName" runat="server" Text="Branch 2 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch2ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3Location" runat="server" Text="Branch 3 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3TelephoneNo" runat="server" Text="Branch 3 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3RentalAmt" runat="server" Text="Branch 3 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch3FaxNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3FaxNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3FaxNo" runat="server" Text="Branch 3 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
            <asp:Panel ID="pnlBranch3ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch3ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch3ManagerName" runat="server" Text="Branch 3 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch3ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlBranch4Location" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Location" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4Location" runat="server" Text="Branch 4 Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Location" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4Telephoneno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Telephoneno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4Telephoneno" runat="server" Text="Branch 4 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Telephoneno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4RentalAmt" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4RentalAmt" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4RentalAmt" runat="server" Text="Branch 4 Rental Amt"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4RentalAmt" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranch4Faxno" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4Faxno" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label2" runat="server" Text="Branch 4 Faxno"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4Faxno" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
             <asp:Panel ID="pnlBranch4ManagerName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch4ManagerName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch4ManagerName" runat="server" Text="Branch 4 Manager name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranch4ManagerName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlApplicationNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApplicationNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApplicationNo" runat="server" Text="Application No"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtApplicationNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNumberOfBranchesOfficeWarehouse" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNumberOfBranchesOfficeWarehouse" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNumberOfBranchesOfficeWarehouse" runat="server" Text="Number Of Branches/Office/Warehouse"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNumberOfBranchesOfficeWarehouse" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
       <!--Start of Head For Sponsor’s / Other Partners’ Details-->      
        <asp:Panel ID="pnlSponsorsOtherPartnersDetailsHead" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblSponsorsOtherPartnersDetailsHead" runat="server" ForeColor="blue" Text="SPONSOR’S / OTHER PARTNERS’ DETAILS" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Sponsor’s / Other Partners’ Details--->  
     
     <asp:Panel ID="pnlSponsor1Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1Name" runat="server" Text="Sponsor 1 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
      </asp:Panel>
           
           <asp:Panel ID="pnlType1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType1" runat="server" Text="Type 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType1" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor1TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1TelephoneNo" runat="server" Text="Sponsor 1 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor1Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor1Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor1Address" runat="server" Text="Sponsor 1 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor1Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor1Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor1Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2Name" runat="server" Text="Sponsor 2 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlType2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType2" runat="server" Text="Type 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType2" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2TelephoneNo" runat="server" Text="Sponsor 2 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor2Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor2Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor2Address" runat="server" Text="Sponsor 2 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor2Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor2Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor2Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3Name" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3Name" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3Name" runat="server" Text="Sponsor 3 Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3Name" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlType3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblType3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblType3" runat="server" Text="Type 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtType3" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3TelephoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3TelephoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3TelephoneNo" runat="server" Text="Sponsor 3 Telephone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3TelephoneNo" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlSponsor3Address" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSponsor3Address" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSponsor3Address" runat="server" Text="Sponsor 3 Address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtSponsor3Address" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtSponsor3Address')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtSponsor3Address');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNoOfEmpsInSeniorPosition" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfEmpsInSeniorPosition" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfEmpsInSeniorPosition" runat="server" Text="No of Emps in Senior Position"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNoOfEmpsInSeniorPosition" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlNatureOfBusinessSponsor" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNatureOfBusinessSponsor" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNatureOfBusinessSponsor" runat="server" Text="Nature of Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNatureOfBusinessSponsor" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtNatureOfBusinessSponsor')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtNatureOfBusinessSponsor');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
           <asp:Panel ID="pnlProductDealtWith" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductDealtWith" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductDealtWith" runat="server" Text="Product Dealt With"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtProductDealtWith" runat="server"  Width="80%" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtProductDealtWith')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtProductDealtWith');"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
       <!--Start of Head For Banking Relationships?-->      
        <asp:Panel ID="pnlBankingRelationships" runat="server" Width="100%" Visible="false">
            <table>
            <tr>
            <td style="background-color:#D0D5D8; height: 16px; width:5%" class="txtBold" align="center" >
                <asp:Label SkinID="lblSkin" ID="lblBankingRelationships" runat="server" ForeColor="blue" Text="BANKING RELATIONSHIPS?" Font-Bold="True"></asp:Label>
            </td>
            </tr>
            </table>
    </asp:Panel>
     <!--End of Head For Banking Relationships?--->  
        <asp:Panel ID="pnlBankName1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName1" runat="server" Text="BankName 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName1" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlTypeOfAccount1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount1" runat="server" Text="Type of Account 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount1" runat="server"  Width="80%"  MaxLength="50"  ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities1" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities1" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities1" runat="server" Text="Facilities 1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities1" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlBankName2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName2" runat="server" Text="BankName 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlTypeOfAccount2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount2" runat="server" Text="Type of Account 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities2" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities2" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities2" runat="server" Text="Facilities 2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities2" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlBankName3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankName3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankName3" runat="server" Text="BankName 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBankName3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlTypeOfAccount3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfAccount3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfAccount3" runat="server" Text="Type of Account 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfAccount3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           
            <asp:Panel ID="pnlFacilities3" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFacilities3" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFacilities3" runat="server" Text="Facilities 3"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFacilities3" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlSalesIn" runat="server" Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblSalesIn" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblSalesIn" runat="server" Text="Sales in"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkSalesIn" runat="server" SkinID="chkListSkin" AutoPostBack="false" RepeatDirection="horizontal">
                    <asp:ListItem>Local Market</asp:ListItem>
                    <asp:ListItem>GCC</asp:ListItem> 
                    <asp:ListItem>Exports</asp:ListItem> 
                   
                </asp:CheckBoxList>                           
                </td>                
                </tr>
                </table>
        </asp:Panel> 
        
        <asp:Panel ID="pnlAvgMonthlyTurnover" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAvgMonthlyTurnover" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAvgMonthlyTurnover" runat="server" Text="Avg Monthly Turnover"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAvgMonthlyTurnover" runat="server"  Width="80%" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
           <asp:Panel ID="pnlClientList" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblClientList" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblClientList" runat="server" Text="Client List"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtClientList" runat="server"  Width="80%" MaxLength="250" TextMode="multiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtClientList')"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           
           <asp:Panel ID="pnlImpressionOfOffice" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblImpressionOfOffice" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblImpressionOfOffice" runat="server" Text="Impression of Office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtImpressionOfOffice" runat="server"  Width="80%" MaxLength="250" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtImpressionOfOffice')" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystDecision" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystDecision" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblCreditAnalystDecision" runat="server"  Text="Credit Analyst Decision" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlCreditAnalystDecision" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Ok to Process" Value="Ok to Process"></asp:ListItem>
                        <asp:ListItem Text="Declined" Value="Declined"></asp:ListItem>
                                                                                   
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCreditAnalystName" runat="server" Text="Credit Analyst Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditAnalystName" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCreditAnalystDate" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCreditAnalystDate" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCreditAnalystDate" runat="server" Text="Credit Analyst Date"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCreditAnalystDate" runat="server"  Width="20%" MaxLength="10"></asp:TextBox>
                     <img id="img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtCreditAnalystDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />

                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlOfficeVerificationNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeVerificationNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeVerificationNo" runat="server" Text="Office Verification No."></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtOfficeVerificationNo" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTelephoneBill" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTelephoneBill" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTelephoneBill" runat="server" Text="Telephone Bill"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTelephoneBill" runat="server"  Width="80%" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            
           
           
           <asp:Panel ID="pnlEmploymentStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblEmploymentStatus" runat="server"  Text="Employment Status" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID ="ddlSkin" ID="ddlEmploymentStatus" runat="server"   AutoPostBack="false">                
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Permanent Employee ( STL )" Value="Permanent Employee ( STL )"></asp:ListItem>
                        <asp:ListItem Text="Permanent Employee ( PIL)" Value="Permanent Employee ( PIL)"></asp:ListItem>
                        <asp:ListItem Text="Temp" Value="Temp"></asp:ListItem>                                                            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlYearsInEmploymentBusiness" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearsInEmploymentBusiness" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblYearsInEmploymentBusiness" runat="server" Text="Years in Employment/Business"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtYearsInEmploymentBusiness" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlCmDesign" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCmDesign" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCmDesign" runat="server" Text="Cm Design"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtCmDesign" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBasicSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBasicSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBasicSalary" runat="server" Text="Basic Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBasicSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTransportAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTransportAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTransportAllowance" runat="server" Text="Transport Allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTransportAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlHouseRentAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblHouseRentAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblHouseRentAllowance" runat="server" Text="House Rent Allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtHouseRentAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlFixedAllowance" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblFixedAllowance" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblFixedAllowance" runat="server" Text="Fixed allowance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtFixedAllowance" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTotalFixedSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTotalFixedSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTotalFixedSalary" runat="server" Text="Total Fixed Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTotalFixedSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlAdditionalComments" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAdditionalComments" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAdditionalComments" runat="server" Text="Additional Comments"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAdditionalComments" runat="server" TextMode="multiLine" Width="80%" MaxLength="250" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtAdditionalComments')" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEmploymentConfirmedWith" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentConfirmedWith" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmploymentConfirmedWith" runat="server" Text="Employment confirmed with"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmploymentConfirmedWith" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlEmploymentConfirmedWithDesignation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmploymentConfirmedWithDesignation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmploymentConfirmedWithDesignation" runat="server" Text="Employment Confirmed with Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmploymentConfirmedWithDesignation" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfApplicant" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfApplicant" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfApplicant" runat="server" Text="Type of Applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfApplicant" runat="server"  Width="80%" ReadOnly="true" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfLoan" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="Table64" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfLoan" runat="server" Text="Type of Loan"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfLoan" runat="server"  Width="80%" ReadOnly="true" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           
           <asp:Panel ID="pnlDetailsOfTradeLicense" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDetailsOfTradeLicense" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDetailsOfTradeLicense" runat="server" Text="Details of Trade License"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDetailsOfTradeLicense" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlTypeOfSalary" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfSalary" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTypeOfSalary" runat="server" Text="Type of Salary"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtTypeOfSalary" runat="server"  Width="80%" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <!--End of Fields For City Bank (Dubai)-->
         <!--START Below New Fields for HSBC Bank-->
         <asp:Panel ID="pnlOfficeCumResidence" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeCumResidence" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblOfficeCumResidence" runat="server" Text="Office Cum Residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlOfficeCumResidence" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherOfficeCumResidence" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherOfficeCumResidence" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlPhotographOfLocation" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblPhotographOfLocation" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="lblPhotographOfLocation" runat="server" Text="Photograph of Location"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPhotographOfLocation" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherPhotographOfLocation" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherPhotographOfLocation" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
          </asp:Panel>
          <asp:Panel ID="pnlEmirate" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmirate" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmirate" runat="server" Text="Emirate"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtEmirate" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppReportToName" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppReportToName" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppReportToName" runat="server" Text="Applicant Report to Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppReportToName" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppReportToDesignation" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppReportToDesignation" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppReportToDesignation" runat="server" Text="Applicant Report to Designation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppReportToDesignation" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlAppHomeCountryPhoneNo" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppHomeCountryPhoneNo" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppHomeCountryPhoneNo" runat="server" Text="Applicant Home Country Phone no"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtAppHomeCountryPhoneNo" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlIsCompanyPartOfGroupCompanies" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsCompanyPartOfGroupCompanies" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsCompanyPartOfGroupCompanies" runat="server" Text="Is the company part of Group Companies"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtIsCompanyPartOfGroupCompanies" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlMainBusiOrCompanyActivity" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMainBusiOrCompanyActivity" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblMainBusiOrCompanyActivity" runat="server" Text="Main business or Company Activity"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtMainBusiOrCompanyActivity" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNameOfOwner" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameOfOwner" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNameOfOwner" runat="server" Text="Name of Owner"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtNameOfOwner" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlBranchesWareHouseCompanyHaveInUAE" runat="server" Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranchesWareHouseCompanyHaveInUAE" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranchesWareHouseCompanyHaveInUAE" runat="server" Text="How many more Branches/Offices/Ware house/associated concerns does the company have in UAE"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtBranchesWareHouseCompanyHaveInUAE" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <!--Added By Naresh For Nature of Business Start 13/05/2008-->
     <asp:Panel ID="pnlNatureOfBusiness" runat="server" Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server">
            <tr>
            <td class="TDWidth"  >
                <asp:Label SkinID="lblSkin" ID="Label3" runat="server" Text="Nature of Business "></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="DDLNatureOfBusiness" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>  
                    <asp:ListItem>Trading</asp:ListItem>  
                    <asp:ListItem>Service</asp:ListItem>
                    <asp:ListItem>Trade shopkeeper</asp:ListItem>
                    <asp:ListItem>Broker</asp:ListItem>
                    <asp:ListItem>STD PCO</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                <asp:DropDownList SkinID="ddlSkin" ID="DDLServiceProvider" runat="server"  AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Commission Agent</asp:ListItem>
                    <asp:ListItem>Broker</asp:ListItem>  
                    <asp:ListItem>Tutor/Personal Care</asp:ListItem>  
                    <asp:ListItem>LIC Agent</asp:ListItem>  
                    <asp:ListItem>STD-PCO Booth</asp:ListItem>  
                    <asp:ListItem>Others</asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="Label4" runat="server" Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="TextBox1" Width="80%" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
      </asp:Panel>
           <!--Added By Naresh For Nature of Business End -->
           
           
          <!--END Below New Fields for HSBC Bank-->
          <!--Below details are always seen--->      
                <table cellpadding="0" cellspacing="0" border="0" id="tblCaseStatus" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server" Text="Case Status"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                     
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server" DataSourceID="sdsCaseStatus"
                          DataTextField="STATUS_CODE" DataValueField="CASE_STATUS_ID" OnDataBound="ddlCaseStatus_DataBound">
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="sdsCaseStatus" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                          ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
                     </asp:SqlDataSource>
                </td>
                </tr>
               </table>
          
                <table cellpadding="0" cellspacing="0" border="0" id="tblOutcome" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOutcome" runat="server" Text="Outcome"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                     
                     <asp:DropDownList SkinID="ddlSkin" ID="ddlOutcome" runat="server" DataSourceID="sdsOutcome"
                          DataTextField="DESCRIPTION" DataValueField="DECLINED_CODE" OnDataBound="ddlOutcome_DataBound"  >
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="sdsOutcome" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                          ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
                          SelectCommand="SELECT [ID],[DECLINED_CODE],[DESCRIPTION] FROM [DECLINED_CODE_MASTER] WHERE ([CLIENT_ID] = ?) ORDER BY DECLINED_CODE">
                         <SelectParameters>
                             <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                </td>
                </tr>
               </table>
          
                <table cellpadding="0" cellspacing="0" border="0" id="tblDeclineReason" style="width:100%" runat="server">
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblDeclineReason" runat="server" Text="Decline Reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                     <asp:TextBox SkinID="txtSkin"  ID="txtDeclineReason" runat="server" MaxLength="255" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           
                <table id="tblAttempt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">

                <tr>
                <td class="TDWidth" style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblLogin" runat="server" Text="Attempts"></asp:Label>
                </td>                
                <td style="height: 14px" >
                <asp:Label SkinID="lblSkin" ID="lblDate" runat="server" Text="Date [dd/mm/yyyy]"></asp:Label>
                </td>
                <td style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="Time [hh:mm]"></asp:Label>
                </td>
                <td style="height: 14px">
                <asp:Label SkinID="lblSkin" ID="lblRemark" runat="server" Text="Verifier Remark"></asp:Label>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server" Text="First Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11"    ID="txtAttemptDate1" runat="server"></asp:TextBox>
                    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime1" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType1" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark1" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSecondAttempt" runat="server" Text="Second Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11"   ID="txtAttemptDate2" runat="server"></asp:TextBox>
                    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime2" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType2" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin"  MaxLength="50"  ID="txtAttemptRemark2" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblThirdAttempt" runat="server" Text="Third Attempt"></asp:Label>
                </td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="11"   ID="txtAttemptDate3" runat="server"></asp:TextBox>
                    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="5"   ID="txtAttemptTime3" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlAttemptTimeType3" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                <asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark3" runat="server"></asp:TextBox>
                </td>
                </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" id="tblSupName" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSupName" runat="server"  Text="Supervisor Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                     <asp:TextBox SkinID="txtSkin" ID="txtSupervisorName" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
                </td>
                </tr>
                </table>
                <table id="tblSupervisorRemark"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
                <tr>
                <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblSupervisorRemark" runat="server" Text="Supervisor Remark"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSupervisorRemark" runat="server" Width="80%" MaxLength="750" TextMode="MultiLine" onkeyPress="ValidateTextLength('Supervisor Remark', this, 749);"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td colspan="2">
                </td>
                </tr>
                </table>
                <br />
<!--End of ATTEMPT DETAIL-->
             
        <asp:Panel ID="pnlSubmit" runat="server" Width="100%" Visible="true">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" SkinID="btnSubmitSkin" runat="server" Text="Submit"  ValidationGroup="grValidateDate" OnClick="btnSubmit_Click"/>    
                <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hidCaseID" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
            <asp:HiddenField ID="hidMode" runat="server"/>
            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
        </asp:Panel>
        <asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select case status." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus" OnServerValidate="cvSelectCaseStatus_ServerValidate">
       </asp:CustomValidator> 
      <asp:CustomValidator ID="cvAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
             Display="None" ErrorMessage="Enter time in first attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime1"></asp:CustomValidator>
        <%--Modified By Gargi Srivastava 31-May-2007--%> 
        <%--<asp:CustomValidator ID="cvAttemptRemark1" runat="server" ClientValidationFunction="ValidateRemark1"
                ControlToValidate="txtAttemptRemark1" Display="None" ErrorMessage="Enter time in first attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
        <%--End--%>         
     <asp:CustomValidator ID="cvAttemptTime2" runat="server" ControlToValidate="txtAttemptTime2"
             Display="None" ErrorMessage="Enter time in second attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime2"></asp:CustomValidator>
      <%--Modified By Gargi Srivastava 31-May-2007--%> 
      <%-- <asp:CustomValidator ID="cvAttemptRemark2" runat="server" ClientValidationFunction="ValidateRemark2"
                ControlToValidate="txtAttemptRemark2" Display="None" ErrorMessage="Enter time in second attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
      <%--End--%> 
       <asp:CustomValidator ID="cvAttemptTime3" runat="server" ControlToValidate="txtAttemptTime3"
                 Display="None" ErrorMessage="Enter time in third attempt." 
                 ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime3"></asp:CustomValidator>
      <%--Modified By Gargi Srivastava 31-May-2007--%> 
      <%-- <asp:CustomValidator ID="cvAttemptRemark3" runat="server" ClientValidationFunction="ValidateRemark3"
                    ControlToValidate="txtAttemptRemark3" Display="None" ErrorMessage="Enter time in third attempt."
                    ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
      <%--End--%> 
      <asp:CustomValidator ID="cvValidate" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateStatus" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus">
       </asp:CustomValidator> 
       <asp:CustomValidator ID="cvValidateDeclineStatus" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateDeclineStatus" SetFocusOnError="true"
                   OnServerValidate="ValidateDeclineCaseStatus">
       </asp:CustomValidator> 

        <asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="txtSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grValidateDate"></asp:RequiredFieldValidator>
    
    
       <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server" ControlToValidate="txtAttemptDate1"
                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server" ControlToValidate="txtAttemptDate2"
                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate3" runat="server" ControlToValidate="txtAttemptDate3"
                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                    SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server" ControlToValidate="txtAttemptTime2"
                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revAttemptTime3" runat="server" ControlToValidate="txtAttemptTime3"
                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>                    
         <asp:RegularExpressionValidator ID="revInitiationDate" runat="server" ControlToValidate="txtInitiationDate"
                    Display="None" ErrorMessage="Please enter valid initiation date." SetFocusOnError="True"
                     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCreditAnalystDate"
                    Display="None" ErrorMessage="Please enter valid Credit Analyst Date." SetFocusOnError="True"
                     ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
         </asp:RegularExpressionValidator>           
         <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" /> 
         <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtAttemptDate1"
            ClientValidationFunction="ValidateAttempts"  ValidationGroup="grValidateDate"  
            ErrorMessage="Enter atleast one Attempt." Display="None">
          </asp:CustomValidator>      
          
        <asp:CompareValidator ID="cmpValYrsWorkedIn" runat="server"  ControlToValidate="txtMthsWorkedIn"  SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12" Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
        <asp:CompareValidator ID="cmpCurrYrsWorkedIn" runat="server"  ControlToValidate="txtTimeCurrOffMths" SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12" Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>          
        <asp:CompareValidator ID="valYrsWorkedIn" runat="server" ControlToValidate="txtYearsWorkedIn"
            Display="None" ErrorMessage="Please Enter numeric only in Months for years lived in" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valMthsWorkedIn" runat="server" ControlToValidate="txtMthsWorkedIn"
            Display="None" ErrorMessage="Please Enter numeric only in Months for months lived in" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrYrsWorkedIn" runat="server" ControlToValidate="txtTimeCurrOffYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr empl/business" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrMtsWorkedIn" runat="server" ControlToValidate="txtTimeCurrOffMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr empl/business" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>        
         </asp:TableCell></asp:TableRow></asp:Table>
</td><td></td>
</tr>
<tr><td></td><td></td><td></td></tr>
</table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
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
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRTV" runat="server" Text="PRTV" Width="22px" Visible="False" OnClick="lbPRTV_Click"></asp:LinkButton>
    </td>
    </tr>
    
    </table>
</fieldset>
</td></tr></table>
</asp:Content>

