<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_ResidanceTELEVerification_GESBI.aspx.cs" Inherits="CPV_CC_CC_ResidanceTELEVerification_GESBI" Title="Residance Tele Verification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
    
     function Enable_Validation_On_Submit()
    {
    
       
        var ReturnValue=true;
        var strErrorMessage="";
            
                  
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");          
        
          
          var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");          
          if (ddlProprietor_recomm.value=='')
          { 
            ReturnValue=false;
            strErrorMessage="Please select Proprietor Recommendation!";
          }
        
        if (strErrorMessage!="")
        {
               lblMessage.innerText=strErrorMessage;
        } 
           
        window.scrollTo(0,0);
        return ReturnValue;
    }
    
    function Enable_validation_On_AutoPopulate_Remark()
    { 
         
     //debugger;
     
      var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
      var txtRelationWithApplicant=document.getElementById("<%=txtRelationWithApplicant.ClientID%>");
      var ddlApplicantName_Confirmed=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>");
      var txtTeleCallerRemark=document.getElementById("<%=txtTeleCallerRemark.ClientID%>");
      var ddlApplicantStay_Confirm=document.getElementById("<%=ddlApplicantStay_Confirm.ClientID%>");
      var ddlResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>");
      
      var chkYCR=document.getElementById("<%=chkYCR.ClientID%>");
      var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
      var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");
      
      var ddlNoOfFamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>");
      var ddlEaringFamilyMembers=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>");
      var ddlWebCheck=document.getElementById("<%=ddlWebCheck.ClientID%>");
      
      var statusIndex_AppName=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").selectedIndex;
      var statusAppName=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").options[statusIndex_AppName].text;         

      var statusIndex_ResiTeleNo=document.getElementById("<%=ddlResiTeleNo_Confirmed.ClientID%>").selectedIndex;
      var statusResiTeleNo=document.getElementById("<%=ddlResiTeleNo_Confirmed.ClientID%>").options[statusIndex_ResiTeleNo].text;         
           
      var statusIndex_ReasonForResi=document.getElementById("<%=ddlReasonForResiNo_NotConf.ClientID%>").selectedIndex;
      var statusReasonForResi=document.getElementById("<%=ddlReasonForResiNo_NotConf.ClientID%>").options[statusIndex_ReasonForResi].text;         
      
      var statusIndex_InfoPro=document.getElementById("<%=ddlInfo_Provided.ClientID%>").selectedIndex;
      var statusReason_InfoPro=document.getElementById("<%=ddlInfo_Provided.ClientID%>").options[statusIndex_InfoPro].text;         
      
      var statusIndex_ResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>").selectedIndex;
      var statusReason_ResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>").options[statusIndex_ResiAddress].text;         
      var txtResidanceAddress =document.getElementById("<%=txtResidanceAddress.ClientID%>");
      
      var statusIndex_AdditionResi=document.getElementById("<%=ddlAdditionResi_No.ClientID%>").selectedIndex;
      var statusReason_AdditionResi=document.getElementById("<%=ddlAdditionResi_No.ClientID%>").options[statusIndex_AdditionResi].text;         
      var txtAdditionalNo =document.getElementById("<%=txtAdditionalNo.ClientID%>");
      
      var statusIndex_Prop=document.getElementById("<%=ddlProprietor_recomm.ClientID%>").selectedIndex;
      var statusReason_Prop=document.getElementById("<%=ddlProprietor_recomm.ClientID%>").options[statusIndex_Prop].text;         
      var txtDefault =document.getElementById("<%=txtDefault.ClientID%>");
      
      
      
      var str;
      var str_ApplicantName;
      
      if ((statusAppName=='Applicant')||(statusAppName=='Applicant'))
      {
        str_ApplicantName=statusAppName;        
      }
      else
      {
        str_ApplicantName=txtPersonSpokenTo.value;
      }

      var strYCR;
      
      if(chkYCR.checked==true)
              {
                strYCR="NOT CONFIRMED";
              }
              else
              {
                strYCR=txtYearsLivedAtResi_YY.value+":"+txtYearsLivedAtResi_MM.value;
                  
              }
              
      if (statusResiTeleNo=='Confirmed')
      {      
              str="SPK TO-" +str_ApplicantName;
              if (statusReason_InfoPro=='Yes')
              {
              str=str +" /RELATIONSHIP-"+ txtRelationWithApplicant.value ;               
              str=str +" /APP NAME-"+ ddlApplicantName_Confirmed.value;
                if  (ddlApplicantName_Confirmed.value!='No Such Person')
                {
                      
                      str=str +" /APP STAY-"+ddlApplicantStay_Confirm.value;
                      if ((ddlApplicantStay_Confirm.value=='Confirmed') || (ddlApplicantStay_Confirm.value=='Details not provided'))
                      
                                     
                      
                       {
                      if (ddlResiStatus.value!='Details not provided')
                       {
                        str=str +" /RESI STATUS-"+ddlResiStatus.value;
                        }
                      str=str +" /NO OF FAMILY MEM-"+ddlNoOfFamilyMembers.value;
                      str=str +" /EARING FAMILY MEM-"+ddlEaringFamilyMembers.value;
                      str=str + "/YCR -"+strYCR;
                      }
                }     
              }
              else
              { 
                str=str +" /Info provided -"+statusReason_InfoPro; 
              }
              
              str=str +" /WEB CHECK-"+ddlWebCheck.value; 
              
              if (statusReason_ResiAddress=='Mismatch in Address')
              {
                str=str +" /Resi address-(Mismatch in Address):"+txtResidanceAddress.value; 
              }
              if (statusReason_AdditionResi=='Yes')
              {
                str=str +" /Contacted on additional resi no -"+txtAdditionalNo.value; 
              }
                 
              if (statusReason_Prop=='Defaulter')  
              {
                  str=str +" /Defaulter details -"+txtDefault.value; 
              }
           
              
          }
          else
          {          
                str=" Resi no -"+statusResiTeleNo;
                str=str +" /Reason -"+statusReasonForResi; 
                str=str +" /web check -"+ddlWebCheck.value; 
                
                
          }
          
          txtTeleCallerRemark.value=str ;
          
    }
    

    function Page_Load_Validation()
    {
     //debugger;
        
     //For Validatiing Residence Address      
     var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");        
     var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");               
     Enable_Validation_ResidanceNo_Confirmed(ddlResiAddress,'Mismatch in Address',false,txtResidanceAddress,'TextBox');
     
     //For Validatiing Addition Number  
     var ddlAdditionResi_No=document.getElementById("<%=ddlAdditionResi_No.ClientID%>");        
     var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");    
     Enable_Validation_ResidanceNo_Confirmed(ddlAdditionResi_No,'No',true,txtAdditionalNo,'TextBox');
     
     //For Validatiing Employer Name Confirmed
     var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");        
     var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");        
     Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerName,'TextBox');
     
     
     //For Validating Employer Address
     var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");       
     var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");       
     Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerAddress,'TextBox');
     
    
     //For Validating Proprietor Recommendations
     var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");  
     var txtDefault=document.getElementById("<%=txtDefault.ClientID%>");           
     Enable_Validation_ResidanceNo_Confirmed(ddlProprietor_recomm,'Defaulter',false,txtDefault,'TextBox');
     
     //For Validating Applicant Stay Confirmed
     Enable_Validation_On_Applicant_Stay_Confirm();
     
     //For Validating Applicant Name Confirmed
     Enable_Validation_On_ApplicantName_Confirm();
       
     //For Validating Info Provided
     Enabled_Validation_on_InfoProvided();
     
     //For Validating Person Spoken 
     Enable_Validation_On_PersonSPOKEN();    
        
      //For Validationg Resi Phone
     Enabled_Validation_On_ResiPhone_Confirm();
           
      //For Validating Date of Birth.     
     var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
     var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
     var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
     var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");             
     Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM);
     
     
      //For Validating YCR
     var chkYCR=document.getElementById("<%=chkYCR.ClientID%>");     
     var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");     
     var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");          
     Enabled_Validation_YY_MM(chkYCR,true,null,txtYearsLivedAtResi_YY,txtYearsLivedAtResi_MM);

           
          
         
    
    }
    function Enable_Validation_On_ApplicantName_Confirm()
    {
         var statusIndex=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>").selectedIndex;
         var status=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>").options[statusIndex].text;         
          
         var ddlApplicantStay_Confirm=document.getElementById("<%=ddlApplicantStay_Confirm.ClientID%>");
          
         var value=true;
            
            
            if(status=="Confirmed")        
            {
                 value=false;
                 //ddlApplicantStay_Confirm.selectedIndex=0;
            } 
            else
            {
                ddlApplicantStay_Confirm.selectedIndex=2;
            }
             ddlApplicantStay_Confirm.disabled=value;   
             Enable_Validation_On_Applicant_Stay_Confirm();
    
    }

    function Enable_Validation_On_Applicant_Stay_Confirm()
    {
            var statusIndex=document.getElementById("<%=ddlApplicantStay_Confirm.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlApplicantStay_Confirm.ClientID%>").options[statusIndex].text;
            var ddlResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>");
                        
            var chkYCR=document.getElementById("<%=chkYCR.ClientID%>");
            var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
            var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");            
            var ddlNoOfFamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>");
            var ddlEaringFamilyMembers=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>");
            var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");            
            var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");
            var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");            
            
            var ddlAdditionResi_No=document.getElementById("<%=ddlAdditionResi_No.ClientID%>");
            var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");
            var txtEmployerPhoneNo=document.getElementById("<%=txtEmployerPhoneNo.ClientID%>");
            
            var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");                   
            var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");
            
            var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
          
            
            var value=true;
            
            
            if ((status=="Confirmed")||(status=="Details not provided"))       
            {
                value=false;
                
            
            }
            else
            {
                    ddlAdditionResi_No.selectexIndex=2; 
                    txtEmployerPhoneNo.value="";
                    ddlEmployerName.selectexIndex=2;
                    ddlEmployerAddress.selectedIndex=2;
                    ddlResiStatus.selectedIndex=0;
                    chkAGE_DOB.checked=value;
                     chkYCR.checked=value;
                    
            }
               ddlResiStatus.disabled=value;                           
               
               chkYCR.disabled=value;              
               Enabled_Validation_YY_MM(chkYCR,true,null,txtYearsLivedAtResi_YY,txtYearsLivedAtResi_MM) ;           
               
               ddlNoOfFamilyMembers.disabled=value;
               ddlEaringFamilyMembers.disabled=value;
               txtYearsLivedAtResi_MM.disabled=value;
               
               chkAGE_DOB.disabled=value;
               // avinash july 2009
               Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM)   ;         
              
               ddlResiAddress.disabled=value;
               txtResidanceAddress.disabled=value;
               txtApplicantAge_DOB_MM.disabled=value;
               
               ddlAdditionResi_No.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlAdditionResi_No,'No',true,txtAdditionalNo,'TextBox');            
               txtEmployerPhoneNo.disabled=value;
               
               ddlEmployerName.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerAddress,'TextBox');
            
               ddlEmployerAddress.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerName,'TextBox');
            
               
            
    
    }
    function Enable_Validation_On_PersonSPOKEN()
    {
        
        var statusIndex=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").options[statusIndex].text;
                 
        var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
        var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
        var txtRelationWithApplicant=document.getElementById("<%=txtRelationWithApplicant.ClientID%>");
        var ddlApplicantName_Confirmed=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>");
        
           
           
           if (status=="Name")
           {
                txtPersonSpokenTo.disabled=false;                
                txtRelationWithApplicant.disabled=false;
                ddlApplicantName_Confirmed.disabled=false;                  
          
           }
           else if (status=="Applicant")
           {
                 txtPersonSpokenTo.disabled=true;
                 txtRelationWithApplicant.disabled=true;
                 ddlApplicantName_Confirmed.selectedIndex=1;
                 ddlApplicantName_Confirmed.disabled=true;  
                 txtPersonSpokenTo.value="";               
                 txtRelationWithApplicant.value="";
                 
           }
           else if (status=="Not Confirmed")
           {
                txtPersonSpokenTo.disabled=true;
                txtRelationWithApplicant.disabled=true; 
                txtPersonSpokenTo.value="";               
                txtRelationWithApplicant.value="";
                ddlApplicantName_Confirmed.selectedIndex=0;
                ddlApplicantName_Confirmed.disabled=false;                    
                    
           }
           else
           {
            txtPersonSpokenTo.disabled=false;
            txtRelationWithApplicant.disabled=false;
            ddlApplicantName_Confirmed.disabled=false;     
           }
           
         
    
    }
    

 function Enabled_Validation_YY_MM(ChkboxId,ChkValue,Control_DOBID,Control_YYID,Control_MMID)
    {
            var Img1=document.getElementById("Img1");                    
            var value=false;
            
            if (ChkboxId.checked==ChkValue)
            {     
                value=true;       
                Control_YYID.value="";
                Control_MMID.value="";
                
                 if (Control_DOBID!=null)
                 {    
                    Control_DOBID.value="";                   
                  
                }
                            
            }       
            
                 if (Control_DOBID!=null)
                 {
                     Control_DOBID.disabled=value;
                     if (Img1!=null)
                    {
                        Img1.disabled=value;
                    }
                 }
                Control_YYID.disabled=value;
                Control_MMID.disabled=value;
       
    }
    


        function Enabled_Validation_On_ResiPhone_Confirm()
        {
            //debugger;
            var statusIndex=document.getElementById("<%=ddlResiTeleNo_Confirmed.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlResiTeleNo_Confirmed.ClientID%>").options[statusIndex].text;
            
            var ddlReasonForOffice_NotConf=document.getElementById("<%=ddlReasonForResiNo_NotConf.ClientID%>");
            var txtResidance_Number=document.getElementById("<%=txtResidance_Number.ClientID%>");
            var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
            var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
            var ddlReasonForResiNo_NotConf=document.getElementById("<%=ddlReasonForResiNo_NotConf.ClientID%>");                             
            var ddlInfo_Provided=document.getElementById("<%=ddlInfo_Provided.ClientID%>");                    
           
            var ddlAdditionResi_No=document.getElementById("<%=ddlAdditionResi_No.ClientID%>");                             
            var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");                             
                
            var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");   
            var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");                             
                                     
            var txtEmployerPhoneNo=document.getElementById("<%=txtEmployerPhoneNo.ClientID%>");                             
            
            var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");                    
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");                    
            var txtRelationWithApplicant=document.getElementById("<%=txtRelationWithApplicant.ClientID%>");
            var ddlApplicantName_Confirmed=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>");
           
           
           
            var value=false;
            if (status=="Not Confirmed")
            {
                    value=true;
                   
                    //debugger;
                    ddlInfo_Provided.selectedIndex=2;
                    ddlPersonSpokenTo.selectedIndex=0;
                    txtPersonSpokenTo.value="";
                    ddlReasonForResiNo_NotConf.value="";
                    ddlAdditionResi_No.selectedIndex=2;
                    ddlEmployerName.selectedIndex=2; 
                    ddlEmployerAddress.selectedIndex=2; 
                    txtRelationWithApplicant.value="";
                    ddlApplicantName_Confirmed.selectedIndex=0; 
            }
     
             txtResidance_Number.disabled=value;
             
             ddlPersonSpokenTo.disabled=value;
             
             ddlReasonForResiNo_NotConf.disabled!=value;
             txtEmployerPhoneNo.disabled=value;
              
             ddlInfo_Provided.disabled=value;
             Enabled_Validation_on_InfoProvided(); 
             
             ddlAdditionResi_No.disabled=value; 
             Enable_Validation_ResidanceNo_Confirmed(ddlAdditionResi_No,'No',true,txtAdditionalNo,'TextBox')
       
             ddlEmployerName.disabled=value; 
             Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerName,'TextBox')
             
             ddlEmployerAddress.disabled=value; 
             Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerAddress,'TextBox')
             
             txtPersonSpokenTo.disabled=value;
             txtRelationWithApplicant.disabled=value;
             ddlApplicantName_Confirmed.disabled=value;
             
             if (status=="Not Confirmed")
            {
                ddlReasonForOffice_NotConf.disabled=false;
            }
            else
            {
                ddlReasonForOffice_NotConf.disabled=true;
                ddlReasonForOffice_NotConf.selectedIndex=0; 
            }           
        
        }
        function Enabled_Validation_on_InfoProvided()   
        {
            
            var statusIndex=document.getElementById("<%=ddlInfo_Provided.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlInfo_Provided.ClientID%>").options[statusIndex].text;
            
            var txtRelationWithApplicant=document.getElementById("<%=txtRelationWithApplicant.ClientID%>");
            var ddlApplicantName_Confirmed=document.getElementById("<%=ddlApplicantName_Confirmed.ClientID%>");
            var ddlApplicantStay_Confirm=document.getElementById("<%=ddlApplicantStay_Confirm.ClientID%>");
            var ddlResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>");
            
            
            var chkYCR=document.getElementById("<%=chkYCR.ClientID%>");
            var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
            var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");
            
            var ddlNoOfFamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>");
            var ddlEaringFamilyMembers=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>");
            var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");
            
            var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");

            var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");
            var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            
            
            var ddlAdditionResi_No=document.getElementById("<%=ddlAdditionResi_No.ClientID%>");
            var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");
            var txtEmployerPhoneNo=document.getElementById("<%=txtEmployerPhoneNo.ClientID%>");
            
            var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");                   
            var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");
            
            var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
            var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
            
            
            var value=false;                
                  
            if (status=="No")
                {
                    value=true;
                    ddlAdditionResi_No.selectexIndex=2; 
                    txtEmployerPhoneNo.value="";
                    ddlEmployerName.selectexIndex=2;
                    ddlEmployerAddress.selectedIndex=2;
                    chkAGE_DOB.checked=value;
                    chkYCR.checked=value;     
                }
               //Avinash
                
               //txtRelationWithApplicant.disabled=value;
               //ddlApplicantName_Confirmed.disabled=value;
               
               Enable_Validation_On_PersonSPOKEN();
               ddlApplicantStay_Confirm.disabled=value;
               ddlResiStatus.disabled=value;            
               
               chkYCR.disabled=value;              
               Enabled_Validation_YY_MM(chkYCR,true,null,txtYearsLivedAtResi_YY,txtYearsLivedAtResi_MM)            
               
               ddlNoOfFamilyMembers.disabled=value;
               ddlEaringFamilyMembers.disabled=value;
               txtYearsLivedAtResi_MM.disabled=value;
               
               chkAGE_DOB.disabled=value;               
               Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM)            
              
               ddlResiAddress.disabled=value;
               txtResidanceAddress.disabled=value;
               txtApplicantAge_DOB_MM.disabled=value;
               
               ddlAdditionResi_No.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlAdditionResi_No,'No',true,txtAdditionalNo,'TextBox');            
               txtEmployerPhoneNo.disabled=value;
               
               ddlEmployerName.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerAddress,'TextBox');
            
               ddlEmployerAddress.disabled=value;
               Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerName,'TextBox');
            
                 
               
                
        }
        
        function Enable_Validation_ResidanceNo_Confirmed(MainControlId,MainValue,ActionToTake,ControlIdToComp,ControlType)
        {
         //debugger;
            //var MainControlId=document.getElementById(""
            var statusIndex=MainControlId.selectedIndex;
            var status=MainControlId.options[statusIndex].text; 
             
            if (ControlType=="DropDown")
            {
                 if (status==MainValue)
                {
                    ControlIdToComp.disabled=ActionToTake;
                    ControlIdToComp.selectedIndex=0;
                }
                else
                {
                    ControlIdToComp.disabled=!ActionToTake;
                }
            
            }
           
            
            
            if ((ControlType=="TextBox"))
            {
                 if (status==MainValue)
                {
                    ControlIdToComp.disabled=ActionToTake;
                    ControlIdToComp.value="";
                }
                else
                {
                    ControlIdToComp.disabled=!ActionToTake;
                }
            
            }

        }
        
        



</script>

<asp:Panel runat="server" ID="PnlView" Height="100%" Width="100%">
    <table style="width: 100%" border="0" cellpadding="1" cellspacing="1">
        <tr>
            <td style="width: 13px">
            </td>
            <td>
            </td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnVeriTypeId" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Residence Telephonic Verification</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
            </td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="5">
                Application Details</td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Case Id" Width="204px"></asp:Label></td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtCaseId" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Application Number</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtApplicantionNumber" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Applicant Name</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtApplicantName" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Residence No <span style="font-size: 8pt; font-family: Arial; mso-fareast-font-family: 'Times New Roman';
                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    Confirmed</span></td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlResiTeleNo_Confirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Reason for Residence No if Not <span style="font-size: 8pt; font-family: Arial; mso-fareast-font-family: 'Times New Roman';
                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    Confirmed</span></td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlReasonForResiNo_NotConf" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Wrong No</asp:ListItem>
                    <asp:ListItem>Invalid No</asp:ListItem>
                    <asp:ListItem>Temporarily out of service</asp:ListItem>
                    <asp:ListItem>Perpetually engaged</asp:ListItem>
                    <asp:ListItem>No response</asp:ListItem>
                    <asp:ListItem>Answering machine</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Residence Telephone No</td>
            <td align="center" style="width: 1px">
                </td>
            <td style="width: 100px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 39px; height: 100%">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtResidance_Number" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
                        <td style="width: 100px; text-align: center">
                <asp:RegularExpressionValidator  ID="rnResiNumber" runat="server" ControlToValidate="txtResidance_Number"
                    ErrorMessage="Plese enter only Numeric values!" 
                      Width="16px" Font-Bold="True" ValidationExpression="[0-9]{0,15}" BackColor="Red" BorderColor="Red" BorderStyle="Groove" BorderWidth="1px" ForeColor="White">?</asp:RegularExpressionValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 16px">
            </td>
            <td>
                Person Spoken</td>
            <td align="center" style="width: 1px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlPersonSpokenTo" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                    <asp:ListItem>Applicant</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Person Spoken To Name</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtPersonSpokenTo" runat="server" SkinID="txtSkin" Width="206px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Information provided</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlInfo_Provided" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Relationship with Applicant</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtRelationWithApplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Applicant Name Confirmed</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlApplicantName_Confirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                    <asp:ListItem>No Such Person</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 22px;">
            </td>
            <td style="height: 22px">
                Applicant Stay Confirmed</td>
            <td align="center" style="width: 1px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
                <asp:DropDownList ID="ddlApplicantStay_Confirm" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                    <asp:ListItem>Shifted</asp:ListItem>
                    <asp:ListItem>Details not provided</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Residence Status of Applicant</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlResiStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Family Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Co Provided</asp:ListItem>
                    <asp:ListItem>PG</asp:ListItem>
                    <asp:ListItem>Bach Acco</asp:ListItem>
                    <asp:ListItem>Relatives House</asp:ListItem>
                    <asp:ListItem>Details not provided</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Y C R</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <table border="0" style="width: 57%; height: 100%">
                    <tr>
                        <td colspan="1" style="width: 100px" class="HighLight">
                            <asp:CheckBox ID="chkYCR" runat="server" Text="Not Confirmed" Width="99px" Font-Bold="False" /></td>
                        <td colspan="1" style="width: 100px" class="HighLight">
                            YY:MM</td>
                        <td style="width: 8px" class="HighLight">
                            <asp:TextBox ID="txtYearsLivedAtResi_YY" runat="server" SkinID="txtSkin" Width="31px"></asp:TextBox></td>
                        <td class="HighLight">
                            <asp:TextBox ID="txtYearsLivedAtResi_MM" runat="server" SkinID="txtSkin" Width="31px"></asp:TextBox></td>
                        <td>
                            <asp:RangeValidator ID="rnYCRYY" runat="server" ControlToValidate="txtYearsLivedAtResi_YY"
                                ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer" Width="9px">?</asp:RangeValidator></td>
                        <td>
                            <asp:RangeValidator ID="rnYCRMonth" runat="server" ControlToValidate="txtYearsLivedAtResi_MM"
                                ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer" Width="9px">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                No Of Family Members</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlNoOfFamilyMembers" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>&gt;4</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                <span style="font-size: 8pt; font-family: Arial; mso-fareast-font-family: 'Times New Roman';
                    mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                    Earning</span> Family Members</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlEaringFamilyMembers" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>&gt;4</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Age/DOB</td>
            <td align="center" style="width: 1px">
            </td>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%" class="HighLight">
                    <tr>
                        <td style="width: 9px">
                            &nbsp;&nbsp;<asp:CheckBox ID="chkAGE_DOB" runat="server" Text="Not Confirmed" Width="99px" />
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="DD-MM-YYYY" Width="76px"></asp:Label></strong></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtApplicantAge_DOB" runat="server" SkinID="txtSkin" Width="151px"></asp:TextBox></td>
                        <td style="width: 100px">
                            &nbsp;<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtApplicantAge_DOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td style="width: 63px">
                            &nbsp; YY:MM</td>
                        <td>
                            <asp:TextBox ID="txtApplicantAge_DOB_YY" runat="server" SkinID="txtSkin" Width="29px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtApplicantAge_DOB_MM" runat="server" SkinID="txtSkin" Width="29px"></asp:TextBox>
                            <asp:RangeValidator ID="RnDOB_YY" runat="server" ControlToValidate="txtApplicantAge_DOB_YY"
                                ErrorMessage="Please Enter Numeric Values for DOB Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator></td>
                        <td style="width: 100px">
                            <asp:RangeValidator ID="rn_DOB_MM" runat="server" ControlToValidate="txtApplicantAge_DOB_MM"
                                ErrorMessage="Please Enter Numeric Values for DOB Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 22px;">
            </td>
            <td style="height: 22px">
                Residence Address</td>
            <td align="center" style="width: 1px; height: 22px;">
            </td>
            <td colspan="2" style="height: 22px">
                <asp:DropDownList ID="ddlResiAddress" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Same as Mentioned</asp:ListItem>
                    <asp:ListItem>Mismatch in Address</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 13px; height: 16px">
            </td>
            <td>
                if Mismatch in residence Address</td>
            <td align="center" style="width: 1px; height: 16px">
            </td>
            <td colspan="2" style="height: 16px">
                <asp:TextBox ID="txtResidanceAddress" runat="server" Height="44px" SkinID="txtSkin"
                    TextMode="MultiLine" Width="461px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Additional residence no. if contacted</td>
            <td align="center" style="width: 1px">
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlAdditionResi_No" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Additional residence No.</td>
            <td align="center" style="width: 1px">
                </td>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 130px; height: 100%">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtAdditionalNo" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
                        <td style="width: 100px; text-align: center">
                <asp:RegularExpressionValidator  ID="RangeValidator1" runat="server" ControlToValidate="txtAdditionalNo"
                    ErrorMessage="Plese enter only Numeric values!" ValidationExpression="[0-9]{0,15}"
                     Width="17px" Font-Bold="True" BorderStyle="Groove" BorderWidth="1px" CssClass="Error_blink" ForeColor="White">?</asp:RegularExpressionValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Employer Name Confirmed</td>
            <td align="center" style="width: 1px">
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlEmployerName" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Employer Name</td>
            <td align="center" style="width: 1px">
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmployerName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Employer Phone No.</td>
            <td align="center" style="width: 1px">
                </td>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 130px; height: 100%">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtEmployerPhoneNo" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
                        <td style="width: 100px; text-align: center">
                <asp:RegularExpressionValidator  ID="rntxtEmployerPhoneNo" runat="server" ControlToValidate="txtEmployerPhoneNo"
                    ErrorMessage="Plese enter only Numeric values!"  
                      ValidationExpression="[0-9]{0,15}" Width="18px" Font-Bold="True" BorderStyle="Groove" BorderWidth="1px" CssClass="Error_blink" ForeColor="White">?</asp:RegularExpressionValidator></td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Employer Address Confirmed</td>
            <td align="center" style="width: 1px">
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlEmployerAddress" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                if Employer Address Confirm</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtEmployerAddress" runat="server" Height="44px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="461px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="5" style="height: 19px">
                Tele Caller Attempt Details</td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Tele Caller Name</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlTeleCallerName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>

        <tr>
            <td style="width: 13px">
            </td>
            <td colspan="4">
                <table>
                    <tr>
                        <td class="TDWidth" style="width: 5%">
                            Attempt</td>
                        <td>
                            Date</td>
                        <td>
                            Time HH:MM</td>
                        <td>
                            Telephone No</td>
                        <td>
                            Remark</td>
                    </tr>
                        <tr>
<td class="TDWidth" style="width: 5%">
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
    <asp:ListItem Value="CR">Contacted</asp:ListItem>
    <asp:ListItem Value="NR">Not responding</asp:ListItem>
    <asp:ListItem Value="TO">Temporarily out of service</asp:ListItem>
    <asp:ListItem Value="PE">Perpetually engaged</asp:ListItem>
    <asp:ListItem Value="AM">Answering Machine</asp:ListItem>
    <asp:ListItem Value="WN">Wrong No</asp:ListItem>
    <asp:ListItem Value="IN">Invalid No</asp:ListItem>
</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth" style="width: 5%">
<asp:Label SkinID="lblSkin"   ID="lbl2ndCall" runat="server" Text="2nd call" Width="61px"></asp:Label>
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
    <asp:ListItem Value="CR">Contacted</asp:ListItem>
    <asp:ListItem Value="NR">Not responding</asp:ListItem>
    <asp:ListItem Value="TO">Temporarily out of service</asp:ListItem>
    <asp:ListItem Value="PE">Perpetually engaged</asp:ListItem>
    <asp:ListItem Value="AM">Answering Machine</asp:ListItem>
    <asp:ListItem Value="WN">Wrong No</asp:ListItem>
    <asp:ListItem Value="IN">Invalid No</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth" style="width: 5%">
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
    <asp:ListItem Value="CR">Contacted</asp:ListItem>
    <asp:ListItem Value="NR">Not responding</asp:ListItem>
    <asp:ListItem Value="TO">Temporarily out of service</asp:ListItem>
    <asp:ListItem Value="PE">Perpetually engaged</asp:ListItem>
    <asp:ListItem Value="AM">Answering Machine</asp:ListItem>
    <asp:ListItem Value="WN">Wrong No</asp:ListItem>
    <asp:ListItem Value="IN">Invalid No</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth" style="width: 5%; height: 23px;">
<asp:Label SkinID="lblSkin"   ID="lbl4thCall" runat="server" Text="4th call"></asp:Label>
</td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtDate4thCall" runat="server"></asp:TextBox>
    <img id="ImgDate4thCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate4thCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtTime4thCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime4thCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo4thCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td style="height: 23px">

<asp:DropDownList ID="ddlRemarks4thCall" runat="server" AutoPostBack="false" SkinID="ddlSkin">
<asp:ListItem Text="Select" Value="Select"></asp:ListItem>
    <asp:ListItem Value="CR">Contacted</asp:ListItem>
    <asp:ListItem Value="NR">Not responding</asp:ListItem>
    <asp:ListItem Value="TO">Temporarily out of service</asp:ListItem>
    <asp:ListItem Value="PE">Perpetually engaged</asp:ListItem>
    <asp:ListItem Value="AM">Answering Machine</asp:ListItem>
    <asp:ListItem Value="WN">Wrong No</asp:ListItem>
    <asp:ListItem Value="IN">Invalid No</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
<tr>
<td class="TDWidth" style="width: 5%">
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
    <asp:ListItem Value="CR">Contacted</asp:ListItem>
    <asp:ListItem Value="NR">Not responding</asp:ListItem>
    <asp:ListItem Value="TO">Temporarily out of service</asp:ListItem>
    <asp:ListItem Value="PE">Perpetually engaged</asp:ListItem>
    <asp:ListItem Value="AM">Answering Machine</asp:ListItem>
    <asp:ListItem Value="WN">Wrong No</asp:ListItem>
    <asp:ListItem Value="IN">Invalid No</asp:ListItem>

</asp:DropDownList>
</td>
</tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td style="width: 13px; height: 47px;">
            </td>
            <td style="height: 47px">
                Tele Caller Remark <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td align="center" style="width: 1px; height: 47px;">
            </td>
            <td style="width: 100px; height: 47px;">
                <asp:TextBox ID="txtTeleCallerRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="474px" Height="46px"></asp:TextBox></td>
            <td style="width: 100px; height: 47px;">
                </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Supervisor Name</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlSupervisorName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Supervisor Remark</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtSuperVisorRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="474px" Height="45px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Web Checked</td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlWebCheck" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"
                    SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="W001">W001</asp:ListItem>
                    <asp:ListItem Value="W002">W002</asp:ListItem>
                    <asp:ListItem>W003</asp:ListItem>
                    <asp:ListItem Value="W004">W004</asp:ListItem>
                    <asp:ListItem>W005</asp:ListItem>
                    <asp:ListItem>W006</asp:ListItem>
                    <asp:ListItem>No record</asp:ListItem>
                    <asp:ListItem>Server down </asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
                Proprietor recommendation <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlProprietor_recomm" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"
                    SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="Positive">Positive</asp:ListItem>
                    <asp:ListItem Value="Negative">Negative</asp:ListItem>
                    <asp:ListItem>Defaulter</asp:ListItem>
                    <asp:ListItem>Referral</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px; height: 16px">
            </td>
            <td>
                If defaulter, details</td>
            <td align="center" style="width: 1px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
                <asp:TextBox ID="txtDefault" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
            </td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="5" class="TableTitle" style="height: 33px">
                &nbsp; &nbsp;<asp:Button ID="btnSubmit" runat="server" SkinID="btnSaveSkin" Height="25px" Width="56px" OnClick="btnSubmit_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Height="25px" /></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td>
            </td>
            <td align="center" style="width: 1px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

