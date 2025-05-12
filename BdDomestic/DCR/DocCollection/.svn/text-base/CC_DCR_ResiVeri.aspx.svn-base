        <%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="SkinFile" 
AutoEventWireup="true" CodeFile="~/DCR/DocCollection/CC_DCR_ResiVeri.aspx.cs" Inherits="CPV_CC_CC_DCR_ResiVeri"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server" >
 

<script type="text/javascript" language="javascript">
       
     
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
      
//       function ValidateTime1(source, arguments)
//       { 
//          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
//          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length >0)
//          {            
//            if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length ==0)
//            {
//                document.aspnetForm.ctl00$C1$txtAttemptRemark1.focus();
//                arguments.IsValid=false;
//            }              
//          }
//       }
        function ValidateTime1(source, arguments)
       { 
                    
          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length==0)
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
<fieldset><legend class="FormHeading"><asp:Label ID="lblHead" runat="server"></asp:Label> </legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server"  width="100%" style="background-color:#E7F6FF" >
<tr><td style="height: 14px"></td><td style="height: 14px"></td><td style="height: 14px"></td></tr>
<tr><td></td>
<td>
    <asp:Panel ID="pnlMsg" runat="server"  Width="100%">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMsg" style="width:100%" runat="server" >
        <tr>
        <td class="TDWidth" style="height: 14px">
            <asp:Label SkinID="lblSkin" ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label></td>               
        </tr>
       </table>
   </asp:Panel> 
   
    <asp:Table ID="tblResiVeri" runat="server"  Width="100%">
    <asp:TableRow ID="tblrowPlace" runat="server" >
    <asp:TableCell ID="tblCellPlace" runat="server" >
     <asp:PlaceHolder ID="PlaceHolder1" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server"  EnableViewState="false"></asp:PlaceHolder>
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
    <asp:PlaceHolder ID="PlaceHolder85" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder86" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder87" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder88" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder89" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder90" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder91" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder92" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder93" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder94" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder95" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder96" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder97" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder98" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder99" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder100" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder101" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder102" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder103" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder104" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder105" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder106" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder107" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder108" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder109" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder110" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder111" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder112" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder113" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder114" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder115" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder116" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder117" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder118" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder119" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder120" runat="server"  EnableViewState="false"></asp:PlaceHolder>        
    <asp:PlaceHolder ID="PlaceHolder121" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder122" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder123" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder124" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder125" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder126" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder127" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder128" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder129" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder130" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder131" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder132" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder133" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder134" runat="server"  EnableViewState="false"></asp:PlaceHolder>    
    <asp:PlaceHolder ID="PlaceHolder135" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder136" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder137" runat="server"  EnableViewState="false"></asp:PlaceHolder>
    </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="tblrow" runat="server" >
    <asp:TableCell ID="tblCell" runat="server" >
       
    <asp:Panel ID="pnlResiVerHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
       <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%"  >
       <asp:Label SkinID="lblSkin" ID="lblResVerHead" runat="server" ForeColor="blue"  Text="RESIDENCE VERIFICATION REPORT" Font-Bold="True"></asp:Label>
        </td>
       </tr>
       
       </table>
    </asp:Panel>
       <asp:Panel ID="pnlAppName" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAppName" style="width:100%" runat="server" >
        <tr>
            <td  class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAppName" runat="server"  Text=" Applicant's Name (Mr./Ms./Mrs.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAppName" runat="server" Width="60%" ReadOnly="true"></asp:TextBox>
                <%--<asp:Label SkinID="lblSkin" ID="lblIsCase" runat="server"></asp:Label>--%>
            </td>
          
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlRefNo" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblRefNo" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth" style="height: 25px"><asp:Label SkinID="lblSkin" ID="lblRefNo" runat="server"  Text="CDM Referance No"></asp:Label>
            </td>
            <td style="width:2%; height: 25px;">:</td>
            <td style="height: 25px" >
                <asp:TextBox  SkinID="txtSkin" ID="txtRefNo" runat="server"  ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel  ID="pnlInitiationDate" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblInitiationDate" style="width:100%" runat="server" > 
        <tr>
        <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblInitiationDate" runat="server"  Text="Date of Initiation"></asp:Label>
        </td> 
        <td style="width:2%">:</td>           
        <td >
        <asp:TextBox SkinID="txtSkin" ID="txtInitiationDate" runat="server"  MaxLength="11"  ReadOnly="true"></asp:TextBox>
             
        </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlAgencyCode" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblAgencyCode" style="width:100%" runat="server" >      
           <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAgencyCode" runat="server"  Text="Agency Code"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtAgencyCode" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlResAddress" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblResAddress" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblResAddress" runat="server"  Text="Address (Residence)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtResAddress" runat="server"  Width="80%" ReadOnly="true" ></asp:TextBox>
            </td>
           
        </tr>
         </table>
    </asp:Panel>
    <asp:Panel ID="pnlPinCode" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblPinCode" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPincode" runat="server"  Text="Pincode"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtPincode" runat="server" ></asp:TextBox>
            </td>
            </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlLandmark" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblLandmark" style="width:100%" runat="server" >
        <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLandmark" runat="server"  Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td  ><asp:TextBox SkinID="txtSkin" ID="txtLandmark" runat="server" ></asp:TextBox>
            </td>
            
        </tr>
         </table>
    </asp:Panel>
    
    
    <asp:Panel ID="pnlTelPPNormal" runat="server"  Width="100%" Visible="false">
    <table cellpadding="0" cellspacing="0" border="0" id="tblTelPPNormal" style="width:100%" runat="server" >             
    <tr>
         <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTelPPNormal" runat="server"  Text="Telephone No (Resi.)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
             <td><asp:TextBox SkinID="txtSkin" ID="txtTelPPNormal" runat="server" ></asp:TextBox>
             <asp:DropDownList SkinID="ddlSkin"  ID="ddlTelPPNormal" runat="server"   AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>PP</asp:ListItem>
                <asp:ListItem>Normal</asp:ListItem>
             </asp:DropDownList>
            </td>
             </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlMobile" runat="server"  Width="100%" Visible="false">
   <table cellpadding="0" cellspacing="0" border="0" id="tblMobile" style="width:100%" runat="server" >             
    <tr>
    <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblMobile" runat="server"  Text="Mobile No" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" ID="txtMobile" runat="server"  ReadOnly="true"></asp:TextBox></td>
            
        </tr>
    </table>
    </asp:Panel>    
    <asp:Panel ID="pnlVerDtlHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%" >
        <asp:Label ID="lblVerDtlHead" runat="server" ForeColor="blue"  Text="VERIFICATION DETAILS" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    </table>
    </asp:Panel>
  
        <asp:Panel ID="pnlPerAddress" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddress" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPerAddress" runat="server"  Text="Permanent Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPerAddress" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <%--///////add by santosh shelar for DCR//////////////////--%>
        <asp:Panel ID="pnlPickUpStat" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickUpStat" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickUpStat" runat="server"  Text="Pick Up Status1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickUpStat" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlDate1" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDate1" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDate1" runat="server"  Text="Date 1"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtDate1" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPickUpStat2" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickUpStat2" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickUpStat2" runat="server"  Text="Pick Up Status 2"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickUpStat2" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlDate2" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDate2" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDate2" runat="server"  Text="Date 2"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtDate2" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPickUpStat3" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickUpStat3" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickUpStat3" runat="server"  Text="Pick Up Status 3"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickUpStat3" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlDate3" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDate3" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDate3" runat="server"  Text="Date 3"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtDate3" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPickUpStatFinal" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickUpStatFinal" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickUpStatFinal" runat="server"  Text="Pick Up Status Final"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickUpStatFinal" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPickedupDate" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickedupDate" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickedupDate" runat="server"  Text="Picked up Date"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickedupDate" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlPickUpFeedback" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPickUpFeedback" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblPickUpFeedback" runat="server"  Text="Pick Up Feedback"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtPickUpFeedback" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlReturnDate" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblReturnDate" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblReturnDate" runat="server"  Text="Return Date"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtReturnDate" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlDespatchDate" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDespatchDate" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDespatchDate" runat="server"  Text="Despatch Date"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtDespatchDate" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlFEName" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFEName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblFEName" runat="server"  Text="FE Name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtFEName" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlFECODE" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFECODE" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblFECODE" runat="server"  Text="FE CODE"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtFECODE" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlFEMobile" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblFEMobile" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblFEMobile" runat="server"  Text="FE Mobile"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtFEMobile" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlTMEName" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTMEName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTME_Name" runat="server"  Text="TME Name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtTMEName" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlDept" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDept" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblDept" runat="server"  Text="Department"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtDept" runat="server"  Width="40%" MaxLength="255"></asp:TextBox>                
            </td>
            </tr>
          </table>
        </asp:Panel>
        
      <%--  \\\\\\\\\\\\\\\\\\\\\\\\\\\\end of code\\\\\\\\\\\\\\\\\\\\\\\\--%>
        
        <asp:Panel ID="pnlPerAddPinCode" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddPinCode" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblPerAddPinCode" runat="server"  Text="Pincode"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtPerAddPinCode" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPerAddLandmark" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblPerAddLandmark" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblPerAddLandmark" runat="server"  Text="Landmark observed"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin"  ID="txtPerAddLandmark" runat="server"  MaxLength="25"></asp:TextBox>
            </td>
            </tr>
            </table>
        </asp:Panel>        
        <asp:Panel ID="pnlDOB" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblDOB" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDOB" runat="server"  Text="Date of Birth"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:TextBox SkinID="txtSkin" ID="txtDOB" runat="server"  MaxLength="10" ></asp:TextBox>
             <img id="img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            
           </td>
           </tr>
           </table>
        </asp:Panel>
        <asp:Panel ID="pnlQualification" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblQualification" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" id="lblQualification" runat="server"  Text="Qualification"></asp:Label>
           </td>
           <td style="width:2%">:</td>
           <td>            
            <asp:DropDownList SkinID="ddlSkin"  ID="ddlQualification" runat="server" AutoPostBack="false">
                <asp:ListItem>NA</asp:ListItem>
                <asp:ListItem>Matric</asp:ListItem>
                <asp:ListItem>Undergraduate</asp:ListItem>
                <asp:ListItem>Post graduate</asp:ListItem>
                <asp:ListItem>Professional</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
             </asp:DropDownList>            
            </td>
            </tr>
            <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherQualification" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherQualification" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
            </table>
        </asp:Panel>        
       
        <asp:Panel ID="pnlTimeCurr" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurr" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblTimeCurr" runat="server"  Text="Time at curr"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td >
                <asp:TextBox SkinID="txtSkin" Width="5%" ID="txtTimeCurrYrs" runat="server"  MaxLength="2"  ></asp:TextBox>Yrs
                <asp:TextBox SkinID="txtSkin" Width="5%" ID="txtTimeCurrMths" runat="server"  MaxLength="2"  ></asp:TextBox>Mths
            </td>
            </tr>
            </table>
        </asp:Panel>                
        <asp:Panel ID="pnlMaritalStatus" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblMaritalStatus" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblMaritalStatus" runat="server"  Text="Marital Status"></asp:Label>    
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList SkinID="ddlSkin"  ID="ddlMaritalStatus" runat="server"   AutoPostBack="false"> 
            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
            <asp:ListItem Text="Single" Value="Single"></asp:ListItem>            
            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
            </asp:DropDownList>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherMaritalStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherMaritalStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherMaritalStatus" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherMaritalStatus" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlIfSpouseWorking" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblIfSpouseWorking" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblpnlIfSpouseWorking" runat="server"  Text="If Spouse working"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
           <asp:DropDownList SkinID="ddlSkin" ID="ddlIfSpouseWorking" runat="server"   AutoPostBack="false">
            <asp:ListItem>NA</asp:ListItem>
            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
            <asp:ListItem Text="No" Value="No"></asp:ListItem>
           </asp:DropDownList>
            </td>
            </tr>            
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseCompanyName" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseCompanyName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseCompanyName" runat="server"  Text="Company Name"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseCompanyName" Width="60%" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseTelephoneNo" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseTelephoneNo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseTelephoneNo" runat="server"  Text="Telephone No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseTelephoneNo" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlSpouseSalary" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblSpouseSalary" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblSpouseSalary" runat="server"  Text="Salary"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
                <asp:TextBox SkinID="txtSkin" ID="txtSpouseSalary" runat="server"  MaxLength="12"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
         <asp:Panel ID="pnlNoDependent" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblNoDependent" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblNoDependent" runat="server"  Text="No of dependent"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtNoDependent" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
         </asp:Panel>
          <asp:Panel ID="pnlDesignationAtOffice" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblDesignationAtOffice" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblDesignationAtOffice" runat="server"  Text="Designation at Office" ></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtDesignationAtOffice" runat="server"  MaxLength="100"></asp:TextBox>            
            </td>
            </tr>
            </table>
          </asp:Panel>
          <asp:Panel ID="pnlAppCompName" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblAppCompName" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblAppCompName" runat="server"  Text="Company Name" ></asp:Label>           
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAppCompName" runat="server" Width="60%" MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlOfficeAddress" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeAddress" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblOfficeAddress" runat="server"  Text="Office Address"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtOfficeAddress" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
            </td>
            </tr>
            </table>            
           </asp:Panel>
           <asp:Panel ID="pnlVerOfficePhone" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVerOfficePhone" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblVerOfficePhone" runat="server"  Text="Office Phone No"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtVerOfficePhone" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           <asp:Panel ID="pnlOfficeExtn" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeExtn" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblOfficeExtn" runat="server"  Text="Office Extn"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtOfficeExtn" runat="server"  MaxLength="5"></asp:TextBox>
            </td>
            </tr>
            </table>
           </asp:Panel>
           
           <asp:Panel ID="pnlVehicleType" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleType" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblVehicleType" runat="server"  Text="Vehicle Type"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:DropDownList  SkinID="ddlSkin" ID="ddlVehicleType" runat="server"   AutoPostBack="false">
                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                <asp:ListItem Text="Two wheeler" Value="Two wheeler"></asp:ListItem>
                <asp:ListItem Text="Three wheeler" Value="Three wheeler"></asp:ListItem>
                <asp:ListItem Text="Four wheeler" Value="Four wheeler"></asp:ListItem>            
            </asp:DropDownList>
            </td>
            </tr>
            </table>                
           </asp:Panel>
                  <asp:Panel ID="PnlTypeofSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table1" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label1" runat="server"  Text="Type of Society"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkTypeofSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Govt Approved (DDA/BMP)</asp:ListItem>
                    <asp:ListItem>Other Private Builders</asp:ListItem>
                    <asp:ListItem>Top Private Builders</asp:ListItem> 
                    <asp:ListItem>None</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlOtherFacilities" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table2" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label2" runat="server"  Text="Other Facilities"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkOtherFacilities" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Maintenance Charges</asp:ListItem>
                    <asp:ListItem>Supermart/parking</asp:ListItem>
                    <asp:ListItem>Gym</asp:ListItem> 
                    <asp:ListItem>Swimming Pool</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
<%--start santosh--%>         
            <asp:Panel ID="pnlNameontheSocietyAddressboard" runat="server" Width="100%" Visible="false">
                                    <table id="tblNameontheSocietyAddressboard" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNameontheSocietyAddressboard" runat="server" Text="Name on the Society Address board"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:TextBox SkinID="txtSkin" Width="80%" MaxLength="100" ID="txtNameontheSocietyAddressboard" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlNamePlateonDoor" runat="server" Width="100%" Visible="false">
                                    <table id="tblNamePlateonDoor" cellpadding="0" cellspacing="0" style="width: 100%"
                                        runat="server">
                                        <tr>
                                            <td class="TDWidth">
                                                <asp:Label SkinID="lblSkin" ID="lblNamePlateonDoor" runat="server" Text="Name Plate on Door"></asp:Label>
                                            </td>
                                            <td style="width: 2%">
                                                :</td>
                                            <td>
                                                <asp:DropDownList SkinID="ddlSkin" ID="ddlNamePlateonDoor" runat="server"  AutoPostBack="false">
                                                    <asp:ListItem Text="NA" Value=""></asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
<%--end santosh--%>
       <asp:Panel ID="PnlMarketValue" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table3" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label3" runat="server"  Text="Market Value of Property"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkMarketValue" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>35 Lacs</asp:ListItem>
                    <asp:ListItem>35-50 Lacs</asp:ListItem>
                    <asp:ListItem>50-75 Lacs</asp:ListItem> 
                    <asp:ListItem>>75 Lacs</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlBuiltupArea" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table4" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label4" runat="server"  Text="Built up Area"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkBuiltupArea" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>400-700 sq ft</asp:ListItem>
                    <asp:ListItem>800-1300 sq ft</asp:ListItem>
                    <asp:ListItem>1300-3000 sq ft</asp:ListItem> 
                    <asp:ListItem>>300 sq ft</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNoOfFlatsSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table5" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label5" runat="server"  Text="No. of flats in the Society"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkNoOfFlatsSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem><20</asp:ListItem>
                    <asp:ListItem>20-50</asp:ListItem>
                    <asp:ListItem>50-100</asp:ListItem> 
                    <asp:ListItem>>100</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlBedroom" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table6" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label6" runat="server"  Text="Does the Society have 1 bedroom flats?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkBedroom" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNegativeAreaSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table7" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label7" runat="server"  Text="Is Scoiety in negative area?"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="ChkNegativeAreaSociety" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:CheckBoxList>   
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlDetailstakenbytpc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table8" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label8" runat="server"  Text="Details taken by - TPC"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtDetailstakenbytpc" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlPhoneNumbersoftpc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table9" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label9" runat="server"  Text="Phone Numbers of TPC"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtPhoneNumbersoftpc" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlHistory" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table10" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label10" runat="server"  Text="History"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtHistory" runat="server" width="80%" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       <asp:Panel ID="PnlNoOfEmployeesSociety" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table11" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label11" runat="server"  Text="No of Employees in the Society"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtNoOfEmployeesSociety" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>
       
              <asp:Panel ID="pnlVehicleMake" runat="server"  Width="100%" Visible="false">
           <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleMake" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label ID="lblVehicleMake" runat="server"  Text="Vehicle Make"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtVehicleMake" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlVehicleIs" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblVehicleIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                <asp:Label ID="lblVehicleIs" runat="server"  Text="Vehicle is"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td style="width: 145px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVehicleIs" runat="server"   AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Co provided" Value="Co provided"></asp:ListItem>
                    <asp:ListItem Text="Financed" Value="Financed"></asp:ListItem>
                    <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                    <asp:ListItem Text="Others(specify)" Value="Others(specify)"></asp:ListItem>
                </asp:DropDownList>
                </td>                
                </tr>
            </table>                
             </asp:Panel>
             <asp:Panel ID="pnlOtherVehicleIs" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherVehicleIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherVehicleIs" runat="server"  Text="If Others specify"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherVehicleIs" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>             
            <asp:Panel ID="pnlIncomeDoc" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblIncomeDoc" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin"  ID="lblIncomeDoc" runat="server"  Text="Income Docs submitted with application(only if applicant contacted)"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtIncomeDoc" runat="server"  MaxLength="20"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCreditCards" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblCreditCards" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblCreditCards" runat="server"  Text="Any CreditCards"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlCreditCards" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>                    
                </asp:DropDownList>
            </td>
            </tr>
            </table>
            </asp:Panel> 
            <asp:Panel ID="pnlIfCreditCard" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblIfCreditCard" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIfYes" runat="server"  Text="If Yes then"></asp:Label>   
            </td>            
            </tr>
            </table>            
            </asp:Panel>
            <asp:Panel ID="pnlCardType" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardType" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardType" runat="server"  Text="a) Card Type"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardType" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCardNo" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardNo" style="width:100%" runat="server" >
            <tr>
            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardNo" runat="server"  Text="b) Card No."></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardNo" runat="server"  MaxLength="50"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCardLimit" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardLimit" style="width:100%" runat="server" >
            <tr>            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardLimit" runat="server"  Text="c) Card Limit"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtCardLimit" runat="server"  MaxLength="10"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnlCardExpiry" runat="server"  Width="100%" Visible="false"> 
            <table cellpadding="0" cellspacing="0" border="0" id="tblCardExpiry" style="width:100%" runat="server" >
            <tr>            
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblCardExpiry" runat="server"  Text=" d) Card Expiry"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox  SkinID="txtSkin" ID="txtCardExpiry" runat="server"  MaxLength="12"></asp:TextBox>
            </td>
            </tr>
            </table>
            </asp:Panel>
            
                        
   
    <asp:Panel ID="pnlNeghContactHead" runat="server"  Width="100%" Visible="false">
    <table>
    <tr>
    <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:10%" >
    <asp:Label SkinID="lblSkin" ID="lblNeghContactHead" runat="server" ForeColor="blue"  Text="IF NEIGHBOUR HAS BEEN CONTACTED" Font-Bold="True"></asp:Label>
    </td>
    </tr>    
    </table>
        
    </asp:Panel>
         
         <asp:Panel  ID="pnlAppAvailableAt" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblAppAvailable" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label  SkinID="lblSkin" ID="lblAppAvailbleAt" runat="server"  Text="Applicant is usually available at"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtAppAvailbleAt" runat="server"  MaxLength="100"></asp:TextBox>
            </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlTimeCurrRes" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTimeCurrRes" style="width:100%" runat="server" >
            <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblTimeCurrRes" runat="server"  Text="Time at curr res"></asp:Label>
                    </td>
               <td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" id="txtTimeCurrResYrs" Width="5%"  runat="server"  MaxLength="2" ></asp:TextBox>Yrs
                    <asp:TextBox SkinID="txtSkin" id="txtTimeCurrResMths" Width="5%"  runat="server"   MaxLength="2" ></asp:TextBox>Mths
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlNeighResidenceIs" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblNeighResidenceIs" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNeighResidenceIs" runat="server"  Text="Residence is"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNeighResidenceIs" runat="server"   AutoPostBack="false">
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Company Accommodation" Value="Company Accommodation"></asp:ListItem>
                        <asp:ListItem Text="Lodging" Value="Lodging"></asp:ListItem>
                        <asp:ListItem Text="Owned by Friend" Value="Owned by Friend"></asp:ListItem>
                        <asp:ListItem Text="Owned by Parents" Value="Owned by Parents"></asp:ListItem>
                        <asp:ListItem Text="Owned by Relative" Value="Owned by Relative"></asp:ListItem>
                        <asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
                        <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                        <asp:ListItem Text="Self Owned" Value="Self Owned"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>  
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOtherNeighResidenceIs" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherNeighResidenceIs" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherNeighResidenceIs" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherNeighResidenceIs" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
        </asp:Panel>
        <asp:Panel ID="pnlIfNeighRentedthenAmt" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblIfNeighRentedthenAmt" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblIfNeighRentedthenAmt" runat="server"  Text="If Rented then Amount"></asp:Label>
            </td>
            <td style="width:2%">:</td>
            <td>
            <asp:TextBox SkinID="txtSkin" ID="txtIfNeighRentedthenAmt" runat="server"  MaxLength="15"></asp:TextBox>
            </td>
            </tr>
        </table>
        </asp:Panel>        
         <asp:Panel ID="pnlApplicantWorkAt" runat="server"  Width="100%" Visible="false"> 
         <table cellpadding="0" cellspacing="0" border="0" id="tblApplicantWorkAt" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblApplicantWorkAt" runat="server"  Text="Applicant works at"></asp:Label>            
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtApplicantWorkAt" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>
        <asp:Panel ID="pnlVerifiedFrom" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblVerifiedFrom" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
            <asp:Label SkinID="lblSkin" ID="lblVerifiedFrom" runat="server"  Text="Verified from"></asp:Label>
            </td><td style="width:2%">:</td>
            <td>
                <asp:DropDownList SkinID ="ddlSkin" ID="ddlVerifiedFrom" runat="server"   AutoPostBack="false">                
                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                    <asp:ListItem Text="Name plate" Value="Name plate"></asp:ListItem>
                    <asp:ListItem Text="Neighbour" Value="Neighbour"></asp:ListItem>
                    <asp:ListItem Text="Society Board" Value="Society Board"></asp:ListItem>
                    <asp:ListItem Text="Watchman" Value="Watchman"></asp:ListItem> 
                    <asp:ListItem Text="Company Board" Value="Company Board"></asp:ListItem>                                    
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
        <asp:Panel ID="pnlObservationHead" runat="server"  Width="100%" Visible="false">
        <table>
        <tr>
        <td align="center"  class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%">
         <asp:Label ID="lblObservationHead" runat="server"  ForeColor="blue" Text="OBSERVATIONS" Font-Bold="True"></asp:Label>
        </td></tr>
        </table>
           
        </asp:Panel>
             
        <asp:Panel ID="pnlTypeOfResidence" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblTypeOfResidence" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTypeOfResidence" runat="server"  Text="Type of residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTypeOfResidence" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Bungalow</asp:ListItem>
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Independent House</asp:ListItem>
                    <asp:ListItem>Multi tenant House</asp:ListItem>
                    <asp:ListItem>Part of Independent House</asp:ListItem>
                    <asp:ListItem>Row House</asp:ListItem>
                    <asp:ListItem>Hutment/Sitting Chawl</asp:ListItem>
                    <asp:ListItem>Standing Chawl/Janta Flat</asp:ListItem>
                    </asp:DropDownList>
                </td>                
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOtherResiType" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherResiType" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherResiType" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherResiType" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
        <asp:Panel ID="pnlApproxArea" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblApproxArea" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblApproxArea" runat="server"  Text="Approximate Area(in sq ft)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtApproxArea" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlGeneralApp" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblGeneralApp" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblGeneralApp" runat="server"  Text="General appearance"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlGeneralApp" runat="server"   AutoPostBack="false">
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
         <asp:Panel ID="pnlLocality" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblLocality" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label ID="lblLocality" runat="server"  Text="Locality"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin"  ID="ddlLocality" runat="server"   AutoPostBack="false">
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
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherLocality" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherLocality" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlLocatingAdd" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblLocatingAdd" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblLocatingAdd" runat="server"  Text="Locating the address"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlLocatingAdd" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                    <asp:ListItem>Untraceable</asp:ListItem>
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
       <asp:Panel ID="pnlAssets" runat="server"  Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblAssets" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAssets" runat="server"  Text="Assets visible"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:CheckBoxList ID="chkAssetsVisible" SkinID="chkListSkin" runat="server"   AutoPostBack="false" RepeatDirection="Horizontal">
                    <asp:ListItem>Air Conditioner</asp:ListItem>
                    <asp:ListItem>Television</asp:ListItem>
                    <asp:ListItem>Two Wheeler</asp:ListItem>
                    <asp:ListItem>Refrigerator</asp:ListItem>
                    <asp:ListItem>Car</asp:ListItem> 
                    <asp:ListItem>Music System</asp:ListItem>
                    <asp:ListItem>PC</asp:ListItem>                    
                    </asp:CheckBoxList>   
                </td>                
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlOtherAssetVisible" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherAssetVisible" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherAssetVisible" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherAssetVisible" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
         <asp:Panel ID="pnlPoliticalPic" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblPoliticalPic" style="width:100%" runat="server" >          
            <tr>
            <td class="TDWidth" style="height: 22px">
                <asp:Label SkinID="lblSkin" ID="lblPoliticalPic" runat="server"  Text="Portrait/picture of political leader Sighted"></asp:Label>
                </td><td style="width:2%; height: 22px;">:</td>
                <td style="height: 22px">
                <asp:DropDownList SkinID="ddlSkin" ID="ddlPoliticalPic" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>                  
                </asp:DropDownList>
                </td>   
                </tr>
                </table>
         </asp:Panel>
          <asp:Panel ID="pnlVisitProof" runat="server"  Width="100%" Visible="false">
          <table cellpadding="0" cellspacing="0" border="0" id="tblVisitProof" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblVisitProof" runat="server"  Text="Proof of Visit Collected"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlVisitProof" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
          </asp:Panel>
        <asp:Panel ID="pnlRouteMap" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblRouteMap" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblRouteMap" runat="server"  Text="Route map drawn"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlRouteMap" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>            
                </td>
                </tr>
                </table>
        </asp:Panel>
       <asp:Panel ID="pnlNegativeArea" runat="server"  Width="100%" Visible="false">
       <table cellpadding="0" cellspacing="0" border="0" id="tblNegativeArea" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNegativeArea" runat="server"  Text="Negative area"></asp:Label>
                </td><td style="width:2%">:</td>
                
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlNegativeArea" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlOCL" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblOCL" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblOCL" runat="server"  Text="OCL"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
               <asp:DropDownList SkinID="ddlSkin" ID="ddlOCL" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>    
        </asp:Panel>  
         <asp:Panel ID="pnlTPCDone" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDone" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTPCDone" runat="server"  Text="TPC Done"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:DropDownList SkinID="ddlSkin" ID="ddlTPCDone" runat="server"   AutoPostBack="false">
                    <asp:ListItem>NA</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>            
                </asp:DropDownList>
                </td>
                </tr>
                </table>
         </asp:Panel>
         <asp:Panel ID="pnlTPCDetail" runat="server"  Width="100%" Visible="false">
         <table cellpadding="0" cellspacing="0" border="0" id="tblTPCDetail" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblTPCDetail" runat="server"  Text="Details of TPC"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtTPCDetail" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
                </table>
         </asp:Panel>   
        <asp:Panel ID="pnlAnyInfo" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblAnyInfo" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblAnyInfo" runat="server"  Text="Any other information obtained"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>                
                <asp:TextBox SkinID="txtSkin" ID="txtAnyInfo" runat="server"  Width="80%" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>
        <asp:Panel ID="pnlNewInfoFERemark" runat="server"  Width="100%" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" id="tblNewInfoFERemark" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="lblNewInfoFERemark" runat="server"  Text="New Info Obtained (FE Remarks)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="txtNewInfoFERemark" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
                </table>
        </asp:Panel>        
   
       <asp:Panel ID="pnlRatingHead" runat="server"  Width="100%" Visible="false">
           <table>
    <tr>
    <td align="center" class="txtBold" style="background-color:#D0D5D8; height: 16px; width:2%">
    <asp:Label SkinID="lblSkin" ID="lblRatingHead" runat="server" ForeColor="blue"  Text="RATING" Font-Bold="True"></asp:Label></td>
    </tr>
    </table>
          
       </asp:Panel>
                  
         <asp:Panel ID="pnlAddConfirmation" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfirmation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAddConfirmation" runat="server"  Text="Address Confirmation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAddConfirmation" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
               </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlContactability" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblContactability" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblContactability" runat="server"  Text="Contactability"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtContactability" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlConfirmationApp" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConfirmationApp" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConfirmationApp" runat="server"  Text="Confirmation of Application"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtConfirmationApp" runat="server"  MaxLength="15"></asp:TextBox>
                </td>            
                </tr>        
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlProfile" runat="server"  Width="100%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="tblProfile" style="width:100%" runat="server" >
                <tr>         
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProfile" runat="server"  Text="Profile"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtProfile" runat="server"  MaxLength="200"></asp:TextBox>
                </td>
                </tr>
           </table>
           </asp:Panel>
            <asp:Panel ID="pnlReputation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReputation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReputation" runat="server"  Text="Reputation"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:TextBox SkinID="txtSkin" ID="txtReputation" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlOverallAsst" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOverallAsst" style="width:100%" runat="server" >
                <tr>
           
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOverallAsst" runat="server"  Text="Overall Assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOverallAsst" runat="server"  Width="80%" MaxLength="20"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>
            <asp:Panel ID="pnlAsstReason" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAsstReason" style="width:100%" runat="server" >
                <tr>
           
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblAsstReason" runat="server"  Text="Reasons for the above assessment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAsstReason" runat="server"  Width="80%" MaxLength="50"></asp:TextBox>
                </td>
                 </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlPersonContacted" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPersonContacted" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonContacted" runat="server"  Text="Person contacted/Met"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPersonContacted" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlRelationApplicant" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblRelationApplicant" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblRelationApplicant" runat="server"  Text="Relation with applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtRelationApplicant" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlResidenceIsStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResidenceIsStatusk" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblResidenceIsStatus" runat="server"  Text="Residence is (Status)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                   <asp:DropDownList SkinID="ddlSkin" ID="ddlResidenceIsStatus" runat="server"   AutoPostBack="false">
                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                        <asp:ListItem Text="Company Accommodation" Value="Company Accommodation"></asp:ListItem>
                        <asp:ListItem Text="Lodging" Value="Lodging"></asp:ListItem>
                        <asp:ListItem Text="Owned by Friend" Value="Owned by Friend"></asp:ListItem>
                        <asp:ListItem Text="Owned by Parents" Value="Owned by Parents"></asp:ListItem>
                        <asp:ListItem Text="Owned by Relative" Value="Owned by Relative"></asp:ListItem>
                        <asp:ListItem Text="Paying Guest" Value="Paying Guest"></asp:ListItem>
                        <asp:ListItem Text="Rented" Value="Rented"></asp:ListItem>
                        <asp:ListItem Text="Self Owned" Value="Self Owned"></asp:ListItem>
                        </asp:DropDownList>
                </td>                
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlOtherResidenceIsStatus" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOtherResidenceIsStatus" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOtherResidenceIsStatus" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOtherResidenceIsStatus" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlCooperativeCustomer" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCooperativeCustomer" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblCooperativeCustomer" runat="server"  Text="How Cooperative was customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                    
                    <asp:DropDownList SkinID="ddlSkin"  ID="ddlCooperativeCustomer" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Polite</asp:ListItem>
                        <asp:ListItem>Rude</asp:ListItem>
                     </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlIssuingBank" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIssuingBank" style="width:100%" runat="server" >
                <tr>
                <td  class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIssuingBank" runat="server"  Text="Issuing Bank"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIssuingBank" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlNeighbourRef" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNeighbourRef" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNeighbourRef" runat="server"  Text="Neighbour reference"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >                    
                    <asp:DropDownList SkinID="ddlSkin"  ID="ddlNeighbourRef" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                       <%-- <asp:ListItem>+ve</asp:ListItem>
                        <asp:ListItem>-ve</asp:ListItem>--%>
                        <asp:ListItem>Positive</asp:ListItem>
                        <asp:ListItem>Negative</asp:ListItem>
                     </asp:DropDownList>
                    
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlConstructionOfResi" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblConstructionOfResi" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblConstructionOfResi" runat="server"  Text="Construction of residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" Id="ddlConstructionOfResi" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Pukka</asp:ListItem>
                        <asp:ListItem>Semi-Pukka</asp:ListItem> 
                        <asp:ListItem>Temporary</asp:ListItem>           
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlExteriorComments" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblExteriorComments" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblExteriorComments" runat="server"  Text="Comments of exteriors"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:CheckBoxList ID="chkExteriorComments" runat="server" SkinID="chkListSkin"  AutoPostBack="false" RepeatDirection="Horizontal">
                        <asp:ListItem>Garden</asp:ListItem> 
                        <asp:ListItem>Security</asp:ListItem>  
                        <asp:ListItem>Building Wall</asp:ListItem>
                        <asp:ListItem>Fenced/Compound Wall</asp:ListItem>
                        <asp:ListItem>Elevator</asp:ListItem>      
                        <asp:ListItem>Other</asp:ListItem>                              
                    </asp:CheckBoxList>                    
                </td>                
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlIfOtherExteriorComments" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIfOtherExteriorComments" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherExteriorComments" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherExteriorComments" runat="server"  MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>
           <asp:Panel ID="pnlDoesAppStay" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblDoesAppStay" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label SkinID="lblSkin" ID="lblDoesAppStay" runat="server"  Text="Does the app stay at this residence"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlDoesAppStay" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                    
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlApproxAgeOfApp" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproxAgeOfApp" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproxAgeOfApp" runat="server"  Text="Approximate age of applicant"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                   <asp:TextBox SkinID="txtSkin" ID="txtApproxAgeOfApp" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfFamilyMem" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfFamilyMem" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfFamilyMem" runat="server"  Text="Number of family member in the house"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtNoOfFamilyMem" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlAppNameplateSight" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppNameplateSight" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppNameplateSight" runat="server"  Text="App nameplate sighted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                    <asp:DropDownList SkinID="ddlSkin" ID="ddlAppNameplateSight" runat="server"   AutoPostBack="false">
                        <asp:ListItem>NA</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>            
                    </asp:DropDownList>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOwenershipApp1" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOwenershipApp1" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOwenershipApp1" runat="server"  Text="Ownership of residence of applicant-1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOwenershipApp1" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlEmpStatus1" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmpStatus1" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmpStatus1" runat="server"  Text="Employment status-1"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEmpStatus1" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlOwenershipApp2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOwenershipApp2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOwenershipApp2" runat="server"  Text="Ownership of residence of applicant-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOwenershipApp2" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>  
           <asp:Panel ID="pnlEmpStatus2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEmpStatus2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEmpStatus2" runat="server"  Text="Employment status-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEmpStatus2" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>     
           
            <asp:Panel ID="pnlBankNameCC" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBankNameCC" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBankNameCC" runat="server"  Text="Bank Name(CC)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtBankNameCC" runat="server"  MaxLength="100" Width="80%"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            <asp:Panel ID="pnlProductName" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblProductName" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblProductName" runat="server"  Text="Product Name"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtProductName" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAmountDefault" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAmountDefault" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAmountDefault" runat="server"  Text="Amount Default"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAmountDefault" runat="server"  MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlPriorityCustomer" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPriorityCustomer" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPriorityCustomer" runat="server"  Text="Priority Customer"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPriorityCustomer" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlSegment" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblSegment" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblSegment" runat="server"  Text="Segment"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtSegment" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlInfoRequired" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRequired" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRequired" runat="server"  Text="Info required"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtInfoRequired" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlChangeAdd" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblChangeAdd" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblChangeAdd" runat="server"  Text="Change in add"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtChangeAdd" runat="server"  MaxLength="300"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlReasonForChange" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForChange" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblReasonForChange" runat="server"  Text="Reason for change"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtReasonForChange" runat="server"  Width="80%" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           
           <asp:Panel ID="pnlCPVScore" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblCPVScore" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblCPVScore" runat="server"  Text="CPV Score"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtCPVScore" runat="server"  MaxLength="50" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTrackNo" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTrackNo" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTrackNo" runat="server"  Text="Track No"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtTrackNo" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlEntryPermitted" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblEntryPermitted" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblEntryPermitted" runat="server"  Text="Entry Permitted"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtEntryPermitted" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAddConfBy" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAddConfBy" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblAddConfBy" runat="server"  Text="Add Conf By"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAddConfBy" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfFamMemEarning" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfFamMemEarning" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblNoOfFamMemEarning" runat="server"  Text="No of earning family member"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtNoOfFamMemEarning" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOfficeTelephone" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOfficeTelephone" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblOfficeTelephone" runat="server"  Text="Telephone no office"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtOfficeTelephone" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlApproxValIfOwned" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblApproxValIfOwned" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblApproxValIfOwned" runat="server"  Text="Approx value if owned"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtApproxValIfOwned" runat="server"  MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>            
           <asp:Panel ID="pnlBranch" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblBranch" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblBranch" runat="server"  Text="Branch"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtBranch" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlInfoRefused" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblInfoRefused" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblInfoRefused" runat="server"  Text="Information refused"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtInfoRefused" runat="server"  MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblTPC2" runat="server"  Text="TPC2" ></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtTPC2" runat="server"  ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlPersonMet2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblPersonMet2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblPersonMet2" runat="server"  Text="Person met-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtPersonMet2" runat="server"  MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAdd2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAdd2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAdd2" runat="server"  Text="add-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAdd2" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAppAvaAtHome" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppAvaAtHome" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppAvaAtHome" runat="server"  Text="app is available at home-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAppAvaAtHome" runat="server"  MaxLength="20" ></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAppAge2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAppAge2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblAppAge2" runat="server"  Text="app age-2"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtAppAge2" runat="server"  MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNoOfResAtHome2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNoOfResAtHome2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth" >
                    <asp:Label ID="lblNoOfResAtHome2" runat="server"  Text="No of residents at home-2"></asp:Label>
                </td> 
                <td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtNoOfResAtHome2" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
            <asp:Panel ID="pnlYearLiveAtAdd2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblYearLiveAtAdd2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblYearLiveAtAdd2" runat="server"  Text="Years lived at this add-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtYearLiveAtAdd2" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlResStatus2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResStatus2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblResStatus2" runat="server"  Text="Residents status-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtResStatus2" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlOccupation2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblOccupation2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblOccupation2" runat="server"  Text="Occupation-2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtOccupation2" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlReasonForAddNotConfirm" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblReasonForAddNotConfirm" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblReasonForAddNotConfirm" runat="server"  Text="Reason for add not confirmed" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtReasonForAddNotConfirm" runat="server"  Width="80%" SkinID="txtSkin" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlUntraceableReason" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblUntraceableReason"  style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblUntraceableReason" runat="server"   SkinID="lblSkin" Text="Untraceable reason"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtUntraceableReason" runat="server"  Width="80%" SkinID="txtSkin" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlLocalityInfo" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblLocalityInfo" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblLocalityInfo" runat="server"  Text="Locality" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtLocalityInfo" runat="server"  SkinID="txtSkin" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlResultOfCalling" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblResultOfCalling" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblResultOfCalling" runat="server"  Text="Result of calling" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtResultOfCalling" runat="server"  SkinID="txtSkin" MaxLength="20"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlMismatchInResAdd" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblMismatchInResAdd" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblMismatchInResAdd" runat="server"  Text="Mismatched in resi add" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtMismatchInResAdd" runat="server"  MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlIsAppKnownToPerson" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblIsAppKnownToPerson" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIsAppKnownToPerson" runat="server"  Text="Is app known to the person(Y/N)"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtIsAppKnownToPerson" runat="server"  SkinID="txtSkin" MaxLength="1"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlToWhomAddBelong" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblToWhomAddBelong" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblToWhomAddBelong" runat="server"  Text="To whom does the add belong" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtToWhomAddBelong" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlVerificationContactAt" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblVerificationContactAt" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin"  ID="lblVerificationContactAt" runat="server"  Text="Verification conducted at"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtVerificationContactAt" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlAccomodation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblAccomodation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblAccomodation" runat="server"  Text="Accomodation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtAccomodation" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
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
                <td class="TDWidth">
                    <asp:Label SkinID="lblSkin" ID="lblIfOtherInteriorConditions" runat="server"  Text="If Others specify"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox SkinID="txtSkin" ID="txtIfOtherInteriorConditions" runat="server"  MaxLength="100"></asp:TextBox>
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
                    <asp:TextBox ID="txtExterior" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlTPCBy" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblTPCBy" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblTPCBy" runat="server"  Text="TPC By" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtTPCBy" runat="server"  SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlNameTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblNameTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblNameTPC2" runat="server"  Text="Name_TPC2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtNameTPC2" runat="server"  SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           
         <asp:Panel ID="pnlStayTPC2" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblStayTPC2" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblStayTPC2" runat="server"  Text="Stay_TPC2" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtStayTPC2" runat="server"  SkinID="txtSkin" MaxLength="25"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel> 
           <asp:Panel ID="pnlObservation" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblObservation" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblObservation" runat="server"  Text="Observation" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtObservation" runat="server"  SkinID="txtSkin" MaxLength="30"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>   
           <asp:Panel ID="pnlWorkingChildren" runat="server"  Width="100%" Visible="false">
                <table cellpadding="0" cellspacing="0" border="0" id="tblWorkingChildren" style="width:100%" runat="server" >
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblWorking" runat="server"  Text="Working" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtWorking" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="TDWidth">
                    <asp:Label ID="lblChildren" runat="server"  Text="Children" SkinID="lblSkin"></asp:Label>
                </td><td style="width:2%">:</td>
                <td >
                    <asp:TextBox ID="txtChildren" runat="server"  SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                </td>
                </tr>
               </table>
           </asp:Panel>             
         <!--START FE DETAIL-->
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
                  
 <asp:Panel ID="PnlRemarkSociey" runat="server"  Width="80%" Visible="false">
            <table cellpadding="0" cellspacing="0" border="0" id="Table12" style="width:100%" runat="server" >
            <tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label12" runat="server"  Text="Any Addidtional Remarks"></asp:Label>
                </td>
                <td style="width:2%">:</td>
                <td>
                <asp:TextBox ID="TxtRemarkSociey" runat="server" Width="100%" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                </td>                
            </tr>
            </table>
         </asp:Panel>          

<!--Start of ATTEMPT DETAIL-->

<%--<table id="tblAttempt" cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >

<tr>
<td class="TDWidth" style="height: 14px">
<asp:Label SkinID="lblSkin" ID="lblLogin" runat="server"  Text="Attempts"></asp:Label>
</td>
<td style="height: 14px" >
<asp:Label SkinID="lblSkin" ID="lblDate" runat="server"  Text="Date [dd/MM/yyyy]"></asp:Label>
</td>
<td style="height: 14px">
<asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server"  Text="Time [hh:mm]"></asp:Label>
</td>
<td style="height: 14px">
<asp:Label SkinID="lblSkin" ID="lblRemark" runat="server"  Text="Verifier Remark"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblFirstAttempt" runat="server"  Text="First Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10"   ID="txtAttemptDate1" runat="server" ></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="5"   ID="txtAttemptTime1" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType1" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark1" runat="server" ></asp:TextBox>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSecondAttempt" runat="server"  Text="Second Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10"   ID="txtAttemptDate2" runat="server" ></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="5"   ID="txtAttemptTime2" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType2" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50"   ID="txtAttemptRemark2" runat="server" ></asp:TextBox>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblThirdAttempt" runat="server"  Text="Third Attempt"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" MaxLength="10"   ID="txtAttemptDate3" runat="server" ></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"  MaxLength="5"  ID="txtAttemptTime3" runat="server" ></asp:TextBox>
    <asp:DropDownList ID="ddlAttemptTimeType3" runat="server"  SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>

<td>
<asp:TextBox SkinID="txtSkin" MaxLength="50" ID="txtAttemptRemark3" runat="server" ></asp:TextBox>
</td>
</tr>
</table>--%>
<table id="tblLogin" cellpadding="0" cellspacing="0" style="width: 100%" runat="server">
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center" colspan="6">
<asp:Label SkinID="lblSkin" ID="lblTelecallLog" ForeColor="blue" runat="server" Text="TELECALL LOG"></asp:Label>
</td>
</tr>

<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblLogin" runat="server" Text="Login"></asp:Label>
</td>
<td >
<asp:Label SkinID="lblSkin" ID="lblDate" runat="server" Text="CallingDate[dd/mm/yyyy]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTime" runat="server" Text="Time [hh:mm]"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblTelNo" runat="server" Text="Tel No."></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblRemark" runat="server" Text="FeedBack Status"></asp:Label>
</td>
<td>
<asp:Label SkinID="lblSkin" ID="lblSubRemark" runat="server" Text="Final Status"></asp:Label>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl1stCall" runat="server" Text="1st call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtDate1stCall" runat="server" Width="80"  MaxLength="11"></asp:TextBox>
    <img id="ImgDate1stCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate1stCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime1stCall" runat="server" Width="60"  MaxLength="5"></asp:TextBox></td> 
   <%-- <asp:DropDownList ID="ddlTime1stCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>--%>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo1stCall" runat="server" Width="100"  MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks1stCall" runat="server" AutoPostBack="false" Width="400"  SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks1stCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl2ndCall" runat="server" Text="2nd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin" ID="txtDate2ndCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate2ndCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate2ndCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime2ndCall" runat="server" Width="60"  MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime2ndCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo2ndCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks2ndCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks2ndCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl3rdCall" runat="server" Text="3rd call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate3rdCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3rdCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime3rdCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime3rdCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtTelNo3rdCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks3rdCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks3rdCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl4thCall" runat="server" Text="4th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate4thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate4thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate4thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime4thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime4thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo4thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks4thCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks4thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl5thCall" runat="server" Text="5th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate5thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate5thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate5thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime5thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime5thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo5thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks5thCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks5thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl6thCall" runat="server" Text="6th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate6thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate6thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate6thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime6thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime6thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo6thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks6thCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks6thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl7thCall" runat="server" Text="7th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate7thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate7thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate7thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime7thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime7thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo7thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks7thCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks7thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl8thCall" runat="server" Text="8th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtDate8thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate8thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate8thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTime8thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime8thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo8thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks8thCall" runat="server" AutoPostBack="false" Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks8thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl9thCall" runat="server" Text="9th call"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtDate9thCall" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="ImgDate9thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate9thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtTime9thCall" runat="server"  Width="60" MaxLength="5"></asp:TextBox>
    <%--<asp:DropDownList ID="ddlTime9thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList>--%></td>
<td>
<asp:TextBox SkinID="txtSkin"    ID="txtTelNo9thCall" runat="server" Width="100" MaxLength="50"></asp:TextBox>
</td>
<td>
<asp:DropDownList ID="ddlRemarks9thCall" runat="server" AutoPostBack="false"  Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
</asp:DropDownList>
</td>
<td>
<asp:DropDownList ID="ddlSubRemarks9thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
<asp:ListItem Text="Close" Value="Close"></asp:ListItem>
<asp:ListItem Text="Return" Value="Return"></asp:ListItem>
<asp:ListItem Text="Onfield" Value="Onfield"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lbl10thCall" runat="server" Text="Other Remark"></asp:Label>
</td>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtOtherRemark" runat="server" MaxLength="500"></asp:TextBox>
    <%--<img id="ImgDate10thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate10thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" />--%></td>
<td>
<asp:Label SkinID="lblSkin" ID="lblFollup" runat="server" Text="FolloupDate"></asp:Label>
<td>
<asp:TextBox SkinID="txtSkin"  ID="txtFolloup" runat="server" Width="80" MaxLength="11"></asp:TextBox>
    <img id="Img2"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFolloup.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<%--<asp:TextBox SkinID="txtSkin"  ID="txtTime10thCall" runat="server"  Width="80" MaxLength="5"></asp:TextBox>--%>
</td>
<td>
<%--<asp:TextBox SkinID="txtSkin"    ID="txtTelNo10thCall" runat="server" MaxLength="50"></asp:TextBox>--%>
</td>
<%--<td>
<asp:DropDownList ID="ddlRemarks10thCall" runat="server" AutoPostBack="false"  Width="400" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Customer not Intrested" Value="Customer not Intrested"></asp:ListItem>
<asp:ListItem Text="Customer is not intrested to take loan now" Value="Customer is not intrested to take loan now"></asp:ListItem>
<asp:ListItem Text="Customer doesen't want ECS facility" Value="Customer doesen't want ECS facility"></asp:ListItem>
<asp:ListItem Text="Customer have only Pancard, he don't have any other document" Value="Customer have only Pancard, he don't have any other document"></asp:ListItem>
<asp:ListItem Text="Customer have willing to give only single document, he refused to give nationality proof" Value="Customer have willing to give only single document, he refused to give nationality proof"></asp:ListItem>
<asp:ListItem Text="Customer not intrested due ROI reason" Value="Customer not intrested due ROI reason"></asp:ListItem>
<asp:ListItem Text="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq" Value="Customer asked he will be do full payment, so he refused to give ECS form & cancelled chq"></asp:ListItem>
<asp:ListItem Text="Cust no. is ringing" Value="Cust no. is ringing"></asp:ListItem>
<asp:ListItem Text="Cust is out of station" Value="Cust is out of station"></asp:ListItem>
<asp:ListItem Text="Cust asked callback later" Value="Cust asked callback later"></asp:ListItem>
<asp:ListItem Text="Cust no.not reachable" Value="Cust no.not reachable"></asp:ListItem>
<asp:ListItem Text="Cust no.egaged" Value="Cust no.egaged"></asp:ListItem>
<asp:ListItem Text="Cust no.out of service" Value="Cust no.out of service"></asp:ListItem>
<asp:ListItem Text="All the given no. are not contactable" Value="All the given no. are not contactable"></asp:ListItem>
<asp:ListItem Text="Cust asked come tomorrow" Value="Cust asked come tomorrow"></asp:ListItem>
<asp:ListItem Text="Onfeild" Value="Onfeild"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 days" Value="Customer asked call back after 2 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 3-4 days" Value="Customer asked call back after 3-4 days"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 1 week" Value="Customer asked call back after 1 week"></asp:ListItem>
<asp:ListItem Text="Customer asked call back after 2 week" Value="Customer asked call back after 2 week"></asp:ListItem>
<asp:ListItem Text="Customer Not available" Value="Customer Not available"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
</asp:DropDownList>
</td>
--%><%--<td>
<asp:DropDownList ID="ddlSubRemarks10thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="NI" Value="NI"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
<asp:ListItem Text="Query" Value="Query"></asp:ListItem>
</asp:DropDownList>
</td>--%>
</tr>
 <%--<tr>
            <td class="TDWidth">
                <asp:Label SkinID="lblSkin" ID="Label14" runat="server"  Text="Details of TPC"></asp:Label>
                </td><td style="width:2%">:</td>
                <td>
                <asp:TextBox SkinID="txtSkin" ID="TextBox1" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
                </td>
                </tr>--%>
</table>

<%--////////////////////////////////end of code/////////////////////--%>
<tr>
<td class="txtBold" style="background-color:#D0D5D8; height: 16px; width:5%" align="center" colspan="6">
<asp:Label SkinID="lblSkin" ID="Label13" ForeColor="blue" runat="server" Text="SUPERVISOR LOG"></asp:Label>
</td>
</tr>

<%--<table cellpadding="0" cellspacing="0" border="0" id="tblSupName" style="width:100%" runat="server" >
<tr>
<td class="TDWidth">
    <asp:Label SkinID="lblSkin" ID="lblSupName" runat="server"  Text="Supervisor Name"></asp:Label>
</td><td style="width:2%">:</td>
<td >
     <asp:TextBox SkinID="txtSkin" ID="txtSupervisorName" runat="server" MaxLength="50"  Width="80%"></asp:TextBox>
</td>
</tr>
</table>--%>
<%--///////////////////add by santosh shelar increase lenth 255 to 700 ///23/08/08////////////////--%>            
<table id="tblSupervisorRemark"  cellpadding="0" cellspacing="0" style="width: 100%" runat="server" >
<tr>
<td class="TDWidth">
<asp:Label SkinID="lblSkin" ID="lblSupervisorRemark" runat="server"  Text="Local Supervisor Remark"></asp:Label>
</td>
<td style="width:2%">:</td>
<td>
<asp:DropDownList ID="ddlSupervisorRemark" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
<asp:ListItem Text="Pickedup" Value="Pickedup"></asp:ListItem>
<asp:ListItem Text="Deposited" Value="Deposited"></asp:ListItem>
<asp:ListItem Text="OCL" Value="OCL"></asp:ListItem>
<asp:ListItem Text="LastMonthDisp" Value="LastMonthDisp"></asp:ListItem>
</asp:DropDownList>
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
<asp:Label SkinID="lblSkin"   ID="lblSupervisorName" runat="server" Text="Local Supervisor Name"></asp:Label>
</td>
<td style="width:2%"  >:</td>
<td>
<asp:DropDownList ID="ddlSupervisorName" runat="server"  AutoPostBack="false" SkinID="ddlSkin">
</asp:DropDownList>
</td>
</tr>
</table>

    <table cellpadding="0" cellspacing="0" border="0" id="tblCaseStatus" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblCaseStatus" runat="server"  Text="Centre Supervisor Remark"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin" ID="ddlCaseStatus" runat="server"  DataSourceID="sdsCaseStatus"
              DataTextField="STATUS_NAME" DataValueField="CASE_STATUS_ID" OnDataBound="ddlCaseStatus_DataBound">
         </asp:DropDownList>
         <asp:SqlDataSource ID="sdsCaseStatus" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                          ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
                          SelectCommand="SELECT [CASE_STATUS_ID], [STATUS_CODE],[STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] = ?) ORDER BY STATUS_CODE">
                          <SelectParameters>
                            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
                          </SelectParameters>
        </asp:SqlDataSource>
    </td>
    </tr>
   </table>

    <table cellpadding="0" cellspacing="0" border="0" id="tblOutcome" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin" ID="lblOutcome" Visible="false" runat="server"  Text="Outcome"></asp:Label>
    </td><td style="width:2%">:</td>
    <td>                     
         <asp:DropDownList SkinID="ddlSkin" ID="ddlOutcome" Visible="false" runat="server"  DataSourceID="sdsOutcome"
              DataTextField="DESCRIPTION" DataValueField="DECLINED_CODE">
         </asp:DropDownList>
         <asp:SqlDataSource ID="sdsOutcome" runat="server"  ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
              SelectCommand="SELECT [ID],[DECLINED_CODE],[DESCRIPTION] FROM [DECLINED_CODE_MASTER] WHERE ([CLIENT_ID] = ?) ORDER BY DECLINED_CODE">
             <SelectParameters>
                 <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />
             </SelectParameters>
         </asp:SqlDataSource>
    </td>
    </tr>
   </table>

    <table cellpadding="0" cellspacing="0" border="0" id="tblDeclineReason" style="width:100%" runat="server" >
    <tr>
    <td class="TDWidth">
        <asp:Label SkinID="lblSkin"  ID="lblDeclineReason" runat="server"  Text="Overall Remark"></asp:Label>
    </td><td style="width:2%">:</td>
    <td >
        <asp:TextBox SkinID="txtSkin" ID="txtDeclineReason" runat="server"  Width="80%" MaxLength="255"></asp:TextBox>
    </td>
    </tr>
   </table>

<br />
<!--End of ATTEMPT DETAIL-->
         <!--END FE DETAIL-->
            <asp:Panel ID="pnlSubmit" runat="server"  Width="100%">
            <table cellpadding="0" cellspacing="0" border="0" id="tblSubmit" width="100%" >
            <tr>
            <td align="center">
                <asp:Button ID="btnSubmit" runat="server"  Text="Submit" SkinID="btnSubmitSkin" ValidationGroup="grValidateDate" OnClick="btnSubmit_Click" />        
                <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" Text="Cancel" OnClick="btnCancel_Click"/>
            </td>
            </tr>
            </table>
            <asp:HiddenField ID="hidCaseID" runat="server" />
            <asp:HiddenField ID="hidVerificationTypeID" runat="server" />
    
            <asp:HiddenField ID="hidMode" runat="server" />
           
            <asp:HiddenField ID="hidVerificationTypeCode" runat="server"/>
        </asp:Panel>
        
        <%--
        <asp:CustomValidator ID="cvAttemptTime1" runat="server"  ControlToValidate="txtAttemptTime1"
             Display="None" ErrorMessage="Enter time in first attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime1"></asp:CustomValidator>--%>
       <%--Modified By Gargi Srivastava 31-May-2007--%>   
       <%-- <asp:CustomValidator ID="cvAttemptRemark1" runat="server"  ClientValidationFunction="ValidateRemark1"
                ControlToValidate="txtAttemptRemark1" Display="None" ErrorMessage="Enter time in first attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>
                
        <%--<asp:CustomValidator ID="cvAttemptTime2" runat="server"  ControlToValidate="txtAttemptTime2"
             Display="None" ErrorMessage="Enter time in second attempt." 
             ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime2"></asp:CustomValidator>--%>
       <%--Modified By Gargi Srivastava 31-May-2007--%>      
       <%--<asp:CustomValidator ID="cvAttemptRemark2" runat="server"  ClientValidationFunction="ValidateRemark2"
                ControlToValidate="txtAttemptRemark2" Display="None" ErrorMessage="Enter time in second attempt."
                ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>         
      <%-- <asp:CustomValidator ID="cvAttemptTime3" runat="server"  ControlToValidate="txtAttemptTime3"
                 Display="None" ErrorMessage="Enter time in third attempt." 
                 ValidationGroup="grValidateDate" ClientValidationFunction="ValidateTime3"></asp:CustomValidator>--%>
       <%--Modified By Gargi Srivastava 31-May-2007--%>         
       <%--<asp:CustomValidator ID="cvAttemptRemark3" runat="server"  ClientValidationFunction="ValidateRemark3"
                    ControlToValidate="txtAttemptRemark3" Display="None" ErrorMessage="Enter time in third attempt."
                    ValidationGroup="grValidateDate"></asp:CustomValidator>--%>
       <%--End--%>   
       <%--<asp:CustomValidator ID="cvCaseStatus" runat="server" 
                   ErrorMessage="Please select case status." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ClientValidate" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus" OnServerValidate="cvSelectCaseStatus_ServerValidate">
       </asp:CustomValidator>         
       
       <asp:CustomValidator ID="cvValidate" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateStatus" SetFocusOnError="true"
                   ControlToValidate="ddlCaseStatus">
       </asp:CustomValidator> --%>
       <%--<asp:CustomValidator ID="cvValidateDeclineStatus" runat="server" 
                   ErrorMessage="Please select Decline Code/Outcome and enter Decline Reason." ValidationGroup="grValidateDate" Display="None" 
                   ClientValidationFunction="ValidateDeclineStatus" SetFocusOnError="true"
                   OnServerValidate="ValidateDeclineCaseStatus">
       </asp:CustomValidator> --%>

        <asp:RequiredFieldValidator ID="rvSupRemark" runat="server" ControlToValidate="ddlSupervisorRemark"
            Display="None" SetFocusOnError="True" ErrorMessage="Please enter Supervisor Remark." 
            ValidationGroup="grValidateDate"></asp:RequiredFieldValidator>
    
                   
       <%--<asp:RegularExpressionValidator ID="revAttemptDate1" runat="server"  ControlToValidate="txtAttemptDate1"
                    Display="None" ErrorMessage="Please enter valid date format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptDate2" runat="server"  ControlToValidate="txtAttemptDate2"
                    Display="None" ErrorMessage="Please enter valid date format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate">
       </asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate3" runat="server"  ControlToValidate="txtAttemptDate3"
                    Display="None" ErrorMessage="Please enter valid date format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime1" runat="server"  ControlToValidate="txtAttemptTime1"
                    Display="None" ErrorMessage="Please enter valid time format for first attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator ID="revAttemptTime2" runat="server"  ControlToValidate="txtAttemptTime2"
                    Display="None" ErrorMessage="Please enter valid time format for second attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revAttemptTime3" runat="server"  ControlToValidate="txtAttemptTime3"
                    Display="None" ErrorMessage="Please enter valid time format for third attempt."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>                    
        <asp:RegularExpressionValidator ID="revInitiationDate" runat="server"  ControlToValidate="txtInitiationDate"
                    Display="None" ErrorMessage="Please enter valid initiation date." SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
        <asp:CustomValidator ID="cvAtleastOne" runat="server" ControlToValidate="txtAttemptDate1"
            ClientValidationFunction="ValidateAttempts"  ValidationGroup="grValidateDate"  
            ErrorMessage="Enter atleast one Attempt." Display="None">
          </asp:CustomValidator> --%>
                  
         <asp:ValidationSummary ID="vsValidateDate" runat="server"   
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" /> 
        
        <asp:CompareValidator ID="valCurrYrs" runat="server" ControlToValidate="txtTimeCurrYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="valCurrMths" runat="server" ControlToValidate="txtTimeCurrMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr" Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator> 
        <asp:CompareValidator ID="valCurrYrsResi" runat="server" ControlToValidate="txtTimeCurrResYrs"
            Display="None" ErrorMessage="Please Enter numeric only in years for Time at curr resi." Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtTimeCurrResMths"
            Display="None" ErrorMessage="Please Enter numeric only in Months for Time at curr resi." Operator="DataTypeCheck"
            SetFocusOnError="True" Type="Integer" ValidationGroup="grValidateDate"></asp:CompareValidator> 
              
        <asp:CompareValidator ID="cmpValCurrMths" runat="server"  ControlToValidate="txtTimeCurrMths"  SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12 for Time at curr." Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
        <asp:CompareValidator ID="cmpValCurrMthsResi" runat="server"  ControlToValidate="txtTimeCurrResMths" SetFocusOnError="true" Type="integer"
            Operator="LessThan" ValueToCompare="12" ErrorMessage="Month must be less than 12 for Time at curr resi." Display="None" ValidationGroup="grValidateDate">
        </asp:CompareValidator>  
              
         </asp:TableCell></asp:TableRow></asp:Table>
</td><td></td>
</tr>
<tr><td></td><td></td><td></td></tr>
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
    <td><asp:LinkButton ID="lbPRV" runat="server" Text="PRV" Width="22px" Visible="False" OnClick="lbPRV_Click"></asp:LinkButton>
    </td>
    <td><asp:LinkButton ID="lbPRTV" runat="server" Text="PRTV" Width="22px" Visible="False" OnClick="lbPRTV_Click"></asp:LinkButton>
    </td>
    </tr>
    
    </table>
    <asp:HiddenField ID="hdnTransStart" runat="server" />
    &nbsp;
</fieldset>
</td></tr></table>
</asp:Content>