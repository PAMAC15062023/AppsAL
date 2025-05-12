<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_BusinessTELEVerification_GESBI.aspx.cs" Inherits="CC_BusinessTELEVerification_GESBI" Title="Business Tele Verification" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">

 
    

        function Autopopulate_Remarks()
        {
          
            var ddlWelcomeMessageHeard=document.getElementById("<%=ddlWelcomeMessageHeard.ClientID%>");
            var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
            var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");            
            var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");
            var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");
            var ddlApplicantEmployment=document.getElementById("<%=ddlApplicantEmployment.ClientID%>");            
            var ddlDesignationOfApplicant=document.getElementById("<%=ddlDesignationOfApplicant.ClientID%>");
            var txtDesignationOfApplicant=document.getElementById("<%=txtDesignationOfApplicant.ClientID%>");             
            var chkYCE=document.getElementById("<%=chkYCE.ClientID%>");
            var txtYearsAtEmployement_YY=document.getElementById("<%=txtYearsAtEmployement_YY.ClientID%>");
            var txtYearsAtEmployement_MM=document.getElementById("<%=txtYearsAtEmployement_MM.ClientID%>");           
            var ddlNatureOfBusiness=document.getElementById("<%=ddlNatureOfBusiness.ClientID%>");            
            var txtNaturaOfBusiness=document.getElementById("<%=txtNaturaOfBusiness.ClientID%>");            
            var txtDescOfBusiness=document.getElementById("<%=txtDescOfBusiness.ClientID%>");            
            var ddlWebCheck=document.getElementById("<%=ddlWebCheck.ClientID%>");            
            var txtTeleCallerRemark=document.getElementById("<%=txtTeleCallerRemark.ClientID%>");
            var ddlOfficeTeleNo_Confirmed=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>");            
            var ddlReasonForOffice_NotConf=document.getElementById("<%=ddlReasonForOffice_NotConf.ClientID%>");                        
            var ddlInfo_Provided=document.getElementById("<%=ddlInfo_Provided.ClientID%>");            
            var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>"); 
            var ddlAddition_No=document.getElementById("<%=ddlAddition_No.ClientID%>");            
            var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>"); 
            var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");            
            var txtDefault=document.getElementById("<%=txtDefault.ClientID%>"); 
            
            var ddlDesignationOfPersonContatced=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>"); 
            var txtDesignationOfPersonContacted=document.getElementById("<%=txtDesignationOfPersonContacted.ClientID%>"); 
           
            
            
            var strAdditionalPhone;                         
            var strNOB;
            var strDesignApp;
            var strSpokenTo;
            var strEmployerName;
            var strYCE;
            var strRel='Not Confirmed' ;
            
            
            if (ddlDesignationOfPersonContatced.value=='Yes')
            {   
                strRel=txtDesignationOfPersonContacted.value;
            }
             
             
             if (ddlAddition_No.value=='Yes')
             {
                strAdditionalPhone=txtAdditionalNo.value;
             }
             else
             {
                strAdditionalPhone=ddlAddition_No.value;            
             }
             
             
            
            
            if (ddlNatureOfBusiness.value=='Other')
            {
                strNOB=txtNaturaOfBusiness.value;
            }
            else
            {
                strNOB=ddlNatureOfBusiness.value;
            }
            
            
            if(chkYCE.checked==true)
            {
                strYCE='Not Confirmed';
            }
            else
            {
                strYCE=txtYearsAtEmployement_YY.value +':'+txtYearsAtEmployement_MM.value
            }
            
            
            if (ddlDesignationOfApplicant.value=='Confirmed')
            {
                strDesignApp=txtDesignationOfApplicant.value;
            
            }
            else            
            {            
                strDesignApp=ddlDesignationOfApplicant.value;
            }
            
            if (ddlEmployerName.value=='Confirmed')
            {
                strEmployerName=txtEmployerName.value;
            }
            else
            {
                 strEmployerName=ddlEmployerName.value;
            }
                         
            var strRemark;
            if (ddlPersonSpokenTo.value=='Name')
            {
              strSpokenTo=txtPersonSpokenTo.value;
            }          
            else
            {
                strSpokenTo=ddlPersonSpokenTo.value;            
            }
            strRemark="";
                
                     
            if ((ddlReasonForOffice_NotConf.value=='Perpetually engaged')||(ddlReasonForOffice_NotConf.value=='No response')||(ddlReasonForOffice_NotConf.value=='Answering machine'))
            {
                    strRemark=" Welmsg-"+ddlWelcomeMessageHeard.value;        
            }
             
            if (ddlOfficeTeleNo_Confirmed.value=='Confirmed')
            {
                strRemark=" Welmsg-"+ddlWelcomeMessageHeard.value;        
                strRemark=strRemark+" /Spk to -"+strSpokenTo;
                    if (ddlInfo_Provided.value=='Yes')
                    {
                                strRemark=strRemark+" /Rel-" +strRel;
                                strRemark=strRemark+" /Empname-"+strEmployerName;                
                                strRemark=strRemark+" /Empmnt-"+ddlApplicantEmployment.value;
                                 if (ddlEmployerAddress.value=='Not Confirmed')
                                        {
                                            strRemark=strRemark+" /Employer Add-"+ddlEmployerAddress.value;  
                                        }
                            
                        if (ddlApplicantEmployment.value=='Confirmed')
                        {
                            strRemark=strRemark+" /Desgofapp-"+strDesignApp;
                            strRemark=strRemark+" /YCE-"+strYCE;
                        
                            strRemark=strRemark+" /NOB-"+strNOB;
                            strRemark=strRemark+" /Desc-"+txtDescOfBusiness.value;
                        }    
                    }
                        else
                        {                 
                        strRemark=strRemark+" /Infoprovide-"+ddlInfo_Provided.value;
                        }
                        
                   
                    if (ddlAddition_No.value=='Yes')
                    {
                    strRemark=strRemark+ " /Contd.on addi.offno"+strAdditionalPhone;
                    }            
                    if (ddlProprietor_recomm.value=='Defaulter')
                    {
                    strRemark=strRemark+ ' /Defaulter Dtls-' +txtDefault.value;
                    }     
                        
                        
                }
            else
            {
                strRemark=strRemark+" /Off.no/(not confd)/Reason-"+ddlReasonForOffice_NotConf.value;          
            }            
           
              strRemark=strRemark+" /Web chk -"+ddlWebCheck.value; 
                        
           
                                  
        
            txtTeleCallerRemark.value=strRemark;
        }


        function Enabled_Validation_On_Submit()    
        {
            
            var returnValue=true;
            var ErrorMessage="";
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
      
             var statusIndex=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>").selectedIndex;
             var status=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>").options[statusIndex].text;        

            //Reason for Office No Not Confirmed
            if (status=="Not Confirmed")
            {
                var statusIndex1=document.getElementById("<%=ddlReasonForOffice_NotConf.ClientID%>").selectedIndex;
                var status1=document.getElementById("<%=ddlReasonForOffice_NotConf.ClientID%>").options[statusIndex1].text;        
           
                if (status1=="")
                {
                    returnValue=false;
                    ErrorMessage=ErrorMessage+"Please Select the reason for office phone no not confirmed!";
                }
            }
            else if (status=="Confirmed")
            {
                var txtEmployerPhoneNo=document.getElementById("<%=txtEmployerPhoneNo.ClientID%>");
                if (txtEmployerPhoneNo.value=="")
                   {
                    returnValue=false;                   
                    ErrorMessage=ErrorMessage+"Office Telephone No cannot be left blank!";            
                   }
                   
                
            }
            
             var statusIndexPerson=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").selectedIndex;
             var statusPerson=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").options[statusIndexPerson].text;        
 
                if (statusPerson=="Name")
                {
                     var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
                     var statusIndexDesg=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>").selectedIndex;
                     var statusDesg=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>").options[statusIndexDesg].text;        
     
                     if (txtPersonSpokenTo.value=="")   
                     {
                         returnValue=false;                   
                         ErrorMessage=ErrorMessage+"Person Spoken To Name Fleid cannot be left blank!";
                        
                     }
                     else if (statusDesg=="")
                     {
                     
                        returnValue=false;                   
                        ErrorMessage=ErrorMessage+"Plese select Designation of person contacted Confirmed!";
                        
                     }
                     else if (statusDesg!="")
                     {
                         var txtDesignationOfPersonContacted=document.getElementById("<%=txtDesignationOfPersonContacted.ClientID%>");
                         if (txtDesignationOfPersonContacted.value=="")
                         {
                               returnValue=false;                   
                               ErrorMessage=ErrorMessage+"Plese Enter Designation of person contacted!";
                      
                         }
                    
                     }
                    
                }
            
    
                         
          
          var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");          
          if (ddlProprietor_recomm.value=='')          { 
            
            returnValue=false;
            ErrorMessage="Please select Proprietor Recommendation!";
          }
          
            
            //var ddlOfficeTeleNo_Confirmed=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>");
            //var ddlReasonForOffice_NotConf=document.getElementById("<%=ddlReasonForOffice_NotConf.ClientID%>");
      
      
            if (returnValue==false)
            {
                window.scrollTo(0,0);
                lblMessage.innerText=ErrorMessage;
            }
            
            return returnValue;
        
        
        }

    function Page_Load_Validation()    
    {
       // debugger;
       //For Approx Age Validation
       var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
       var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
       var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
       var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");             
       Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM);
       
       //For YCE Validation
       var chkYCE=document.getElementById("<%=chkYCE.ClientID%>");
       var txtYearsAtEmployement_YY=document.getElementById("<%=txtYearsAtEmployement_YY.ClientID%>");
       var txtYearsAtEmployement_MM=document.getElementById("<%=txtYearsAtEmployement_MM.ClientID%>");       
       Enabled_Validation_YY_MM(chkYCE,true,null,txtYearsAtEmployement_YY,txtYearsAtEmployement_MM);           
  
      
       //For YCE Additional Contact No
       var ddlAddition_No=document.getElementById("<%=ddlAddition_No.ClientID%>");
       var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");              
       Enable_Validation_ResidanceNo_Confirmed(ddlAddition_No,'No',true,txtAdditionalNo,'TextBox');
       
            
       // Info Provided Validation
       Enabled_Validation_on_InfoProvided();
       //For Employer Name Confirmation
       var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");
       var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");                     
       Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerName,'TextBox');
       
       //For ResidanceAddress  Confirmation
       //debugger;
       var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");
       var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");                            
       Enable_Validation_ResidanceNo_Confirmed(ddlResiAddress,'Not Confirmed',true,txtResidanceAddress,'TextBox');
    
              


       
       // Info Provided Validation
       Enabled_Validation_on_InfoProvided();
       
         
           
       //For Employer Address Confirmation
       var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");
       var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");          
       Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerAddress,'TextBox');
        
       //For Employer Person Designation Confirmation
       var ddlDesignationOfPersonContatced=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>");
       var txtDesignationOfPersonContacted=document.getElementById("<%=txtDesignationOfPersonContacted.ClientID%>");                  
       
       Enable_Validation_ResidanceNo_Confirmed(ddlDesignationOfPersonContatced,'No',true,txtDesignationOfPersonContacted,'TextBox');
          
       //For Applicant Designation Confirmation
       var ddlDesignationOfApplicant=document.getElementById("<%=ddlDesignationOfApplicant.ClientID%>");
       var txtDesignationOfApplicant=document.getElementById("<%=txtDesignationOfApplicant.ClientID%>");                       
       Enable_Validation_ResidanceNo_Confirmed(ddlDesignationOfApplicant,'Not confirmed',true,txtDesignationOfApplicant,'TextBox');
      
       //For Applicant Department Confirmation
       var ddlDepartmentOfApplicant=document.getElementById("<%=ddlDepartmentOfApplicant.ClientID%>");
       var txtDepartmentOfApplicant=document.getElementById("<%=txtDepartmentOfApplicant.ClientID%>");                              
       Enable_Validation_ResidanceNo_Confirmed(ddlDepartmentOfApplicant,'Not confirmed',true,txtDepartmentOfApplicant,'TextBox');
       
              
         
        
       //For Applicant NatureOfBusinessConfirmation
       var ddlNatureOfBusiness=document.getElementById("<%=ddlNatureOfBusiness.ClientID%>");
       var txtNaturaOfBusiness=document.getElementById("<%=txtNaturaOfBusiness.ClientID%>");                                     
       var txtDescOfBusiness=document.getElementById("<%=txtDescOfBusiness.ClientID%>");         
       Enabled_Validation_on_NatureOfBusiness(ddlNatureOfBusiness,txtNaturaOfBusiness,txtDescOfBusiness); 
       
       //For Applicant InfoProvided Confirmation      
       Enabled_Validation_on_InfoProvided(); 
            
       //For Applicant OfficePhone Confirmation            
       Enabled_Validation_On_OfficePhone_Confirm();
      
       //For Applicant Person Contacted( Confirmation      
       Enabled_Validation_On_PersonContacted();
        //For Applicant Employment Confirmation            
       Enabled_Validation_on_ApplicantEmployment();    
      
     //For Applicant Proprietor Recommendation sConfirmation
       var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");
       var txtDefault=document.getElementById("<%=txtDefault.ClientID%>");                                     
       Enable_Validation_ResidanceNo_Confirmed(ddlProprietor_recomm,'Defaulter',false,txtDefault,'TextBox');
      
    }
    
   
    
    function Enabled_Validation_on_NatureOfBusiness(MainControlId,ControlOthers,ControlDescOfBusiness)
    {
            
           var statusIndex=MainControlId.selectedIndex;
           var status=MainControlId.options[statusIndex].text; 
           
           var value=false;
            
           if (status=="Other")
           {
                ControlOthers.disabled=false;
                
           }
           else if (status=="Not Confirmed")
           {
                ControlDescOfBusiness.disabled=true;
                ControlDescOfBusiness.value="";
                ControlOthers.disabled=true;
                ControlOthers.value="";
           }
           else
           {
            ControlOthers.disabled=true;
            ControlOthers.value="";
            ControlDescOfBusiness.disabled=false;
           }
            
            
            
    }
    
      function Enabled_Validation_on_ApplicantEmployment()
    {
        var statusIndex=document.getElementById("<%=ddlApplicantEmployment.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlApplicantEmployment.ClientID%>").options[statusIndex].text;        
                
         
         
        var ddlApplicantEmployment=document.getElementById("<%=ddlApplicantEmployment.ClientID%>");        
        
        var ddlDesignationOfApplicant=document.getElementById("<%=ddlDesignationOfApplicant.ClientID%>");
        var txtDesignationOfApplicant=document.getElementById("<%=txtDesignationOfApplicant.ClientID%>");        
        
        var ddlDepartmentOfApplicant=document.getElementById("<%=ddlDepartmentOfApplicant.ClientID%>");
        var txtDepartmentOfApplicant=document.getElementById("<%=txtDepartmentOfApplicant.ClientID%>");
        
        var txtExtNo=document.getElementById("<%=txtExtNo.ClientID%>");
        var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");
        var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
         
        var chkYCE=document.getElementById("<%=chkYCE.ClientID%>");
        var txtYearsAtEmployement_YY=document.getElementById("<%=txtYearsAtEmployement_YY.ClientID%>");
        var txtYearsAtEmployement_MM=document.getElementById("<%=txtYearsAtEmployement_MM.ClientID%>");        
        
        var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
        var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
        var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
        var txtApplicatAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
        
        var ddlAddition_No=document.getElementById("<%=ddlAddition_No.ClientID%>");                             
        var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");                             
        
        var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");                             
        var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");                             
        var txtResiPhone=document.getElementById("<%=txtResiPhone.ClientID%>");                             
        var Img1=document.getElementById("Img1");        
          
        var ddlNatureOfBusiness=document.getElementById("<%=ddlNatureOfBusiness.ClientID%>");
        var txtNaturaOfBusiness=document.getElementById("<%=txtNaturaOfBusiness.ClientID%>");
        var txtDescOfBusiness=document.getElementById("<%=txtDescOfBusiness.ClientID%>");

           
  
        
         //debugger;
                         
        var value=false;       
       
        if (status!="Confirmed")
        {
            value=true;
            
             
            
            ddlEmployerAddress.selectedIndex=2;
            ddlDepartmentOfApplicant.selectedIndex=2;
            ddlAddition_No.selectedIndex=2;
            ddlDesignationOfApplicant.selectedIndex=2;
            ddlResiAddress.selectedIndex=2;
            txtExtNo.value="";
            
            ddlNatureOfBusiness.selectedIndex=0;
            txtNaturaOfBusiness.value="";
            txtDescOfBusiness.value="";
            chkAGE_DOB.checked=value;
            chkYCE.checked=value;
        }
        
         
        
      
         
        ddlDesignationOfApplicant.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlDesignationOfApplicant,'Not confirmed',true,txtDesignationOfApplicant,'TextBox');
       
       
        ddlDepartmentOfApplicant.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlDepartmentOfApplicant,'Not confirmed',true,txtDepartmentOfApplicant,'TextBox');
        
        txtExtNo.disabled=value; 
               
        ddlEmployerAddress.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerAddress,'TextBox');
        
        
        
        chkAGE_DOB.disabled=value;
        Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB, txtApplicantAge_DOB_YY, txtApplicatAge_DOB_MM);
         
        
        chkYCE.disabled=value;         
        Enabled_Validation_YY_MM(chkYCE,true,null, txtYearsAtEmployement_YY, txtYearsAtEmployement_MM);
       
        ddlAddition_No.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlAddition_No,'No',true,txtAdditionalNo,'TextBox');
        
        ddlResiAddress.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlResiAddress,'Not Confirm',true,txtResidanceAddress,'TextBox');
        txtResiPhone.disabled=value;
        Img1.disabled=value;
        
         ddlNatureOfBusiness.disabled=value;
         txtNaturaOfBusiness.disabled=value;
         txtDescOfBusiness.disabled=value;
        
    }

    

    
    function Enabled_Validation_On_PersonContacted()
    {
     //debugger;
        var statusIndex=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").options[statusIndex].text;        
        var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
        var ddlDesignationOfPersonContatced=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>");        
        var txtDesignationOfPersonContacted=document.getElementById("<%=txtDesignationOfPersonContacted.ClientID%>");        
        
        
         var value=false;
       
        if (status=="Applicant")
        {
            value=true;      
            ddlDesignationOfPersonContatced.selectedIndex=0;
            txtPersonSpokenTo.value="";
            txtPersonSpokenTo.value="";
            //txtDesignationOfPersonContacted.value="";
            txtPersonSpokenTo.disabled=value;
            ddlDesignationOfPersonContatced.disabled=value;
            txtDesignationOfPersonContacted.disabled=value;
       
            
        }      
        else if (status=="Name")
        {
            value=false;     
            //txtDesignationOfPersonContacted.value="";
            txtPersonSpokenTo.disabled=value;
            ddlDesignationOfPersonContatced.disabled=value;
            txtDesignationOfPersonContacted.disabled=value;
        }
        else if(status=="Not Confimed")
        {
            value=true; 
            //txtDesignationOfPersonContacted.value="";
            txtPersonSpokenTo.disabled=value;
            ddlDesignationOfPersonContatced.disabled=value;
            txtDesignationOfPersonContacted.disabled=value;
        
        }
       
        
    }


    function Enabled_Validation_on_InfoProvided()
    {
        var statusIndex=document.getElementById("<%=ddlInfo_Provided.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlInfo_Provided.ClientID%>").options[statusIndex].text;        
                
        var ddlEmployerName=document.getElementById("<%=ddlEmployerName.ClientID%>");
        var txtEmployerName=document.getElementById("<%=txtEmployerName.ClientID%>");        
        
        var ddlDesignationOfPersonContatced=document.getElementById("<%=ddlDesignationOfPersonContatced.ClientID%>");
        var txtDesignationOfPersonContacted=document.getElementById("<%=txtDesignationOfPersonContacted.ClientID%>");
        
        var ddlApplicantEmployment=document.getElementById("<%=ddlApplicantEmployment.ClientID%>");        
        
        var ddlDesignationOfApplicant=document.getElementById("<%=ddlDesignationOfApplicant.ClientID%>");
        var txtDesignationOfApplicant=document.getElementById("<%=txtDesignationOfApplicant.ClientID%>");        
        
        var ddlDepartmentOfApplicant=document.getElementById("<%=ddlDepartmentOfApplicant.ClientID%>");
        var txtDepartmentOfApplicant=document.getElementById("<%=txtDepartmentOfApplicant.ClientID%>");
        
        var txtExtNo=document.getElementById("<%=txtExtNo.ClientID%>");
        var ddlEmployerAddress=document.getElementById("<%=ddlEmployerAddress.ClientID%>");
        var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
         
        var chkYCE=document.getElementById("<%=chkYCE.ClientID%>");
        var txtYearsAtEmployement_YY=document.getElementById("<%=txtYearsAtEmployement_YY.ClientID%>");
        var txtYearsAtEmployement_MM=document.getElementById("<%=txtYearsAtEmployement_MM.ClientID%>");        
        
        var chkAGE_DOB=document.getElementById("<%=chkAGE_DOB.ClientID%>");
        var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
        var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
        var txtApplicatAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
        
        var ddlAddition_No=document.getElementById("<%=ddlAddition_No.ClientID%>");                             
        var txtAdditionalNo=document.getElementById("<%=txtAdditionalNo.ClientID%>");                             
        
        var ddlResiAddress=document.getElementById("<%=ddlResiAddress.ClientID%>");                             
        var txtResidanceAddress=document.getElementById("<%=txtResidanceAddress.ClientID%>");                             
        var txtResiPhone=document.getElementById("<%=txtResiPhone.ClientID%>");                             
        var Img1=document.getElementById("Img1");        
          
        var ddlNatureOfBusiness=document.getElementById("<%=ddlNatureOfBusiness.ClientID%>");
        var txtNaturaOfBusiness=document.getElementById("<%=txtNaturaOfBusiness.ClientID%>");
        var txtDescOfBusiness=document.getElementById("<%=txtDescOfBusiness.ClientID%>");

           
  
        
        //debugger;
                         
        var value=false;       
       
        if (status=="No")
        {
            value=true;
            
            ddlEmployerName.selectedIndex=2;
            ddlDesignationOfPersonContatced.selectedIndex=2;
            ddlEmployerAddress.selectedIndex=2;
            ddlDepartmentOfApplicant.selectedIndex=2;
            ddlAddition_No.selectedIndex=2;
            ddlDesignationOfApplicant.selectedIndex=2;
            ddlResiAddress.selectedIndex=2;
            txtExtNo.value="";
            
            ddlNatureOfBusiness.selectedIndex=0;
            txtNaturaOfBusiness.value="";
            txtDescOfBusiness.value="";
            chkAGE_DOB.checked=value;
             chkYCE.checked=value;
        }
        
        ddlApplicantEmployment.disabled=value;
        
        ddlEmployerName.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlEmployerName,'Not Confirmed',true,txtEmployerName,'TextBox');
       
        //Changes By Avinash Wankhede 16 JULY 2009
        ddlDesignationOfPersonContatced.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlDesignationOfPersonContatced,'No',true,txtDesignationOfPersonContacted,'TextBox');

        ddlDesignationOfApplicant.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlDesignationOfApplicant,'Not confirmed',true,txtDesignationOfApplicant,'TextBox');
       
       
        ddlDepartmentOfApplicant.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlDepartmentOfApplicant,'Not confirmed',true,txtDepartmentOfApplicant,'TextBox');
        
        txtExtNo.disabled=value; 
               
        ddlEmployerAddress.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlEmployerAddress,'Not Confirmed',true,txtEmployerAddress,'TextBox');
        
        
        
        chkAGE_DOB.disabled=value;
        Enabled_Validation_YY_MM(chkAGE_DOB,true,txtApplicantAge_DOB, txtApplicantAge_DOB_YY, txtApplicatAge_DOB_MM);
         
       
        chkYCE.disabled=value;         
        Enabled_Validation_YY_MM(chkYCE,true,null, txtYearsAtEmployement_YY, txtYearsAtEmployement_MM);
       
        ddlAddition_No.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlAddition_No,'No',true,txtAdditionalNo,'TextBox');
        
        ddlResiAddress.disabled=value;
        Enable_Validation_ResidanceNo_Confirmed(ddlResiAddress,'Not Confirm',true,txtResidanceAddress,'TextBox');
        txtResiPhone.disabled=value;
        Img1.disabled=value;
        
         ddlNatureOfBusiness.disabled=value;
         txtNaturaOfBusiness.disabled=value;
         txtDescOfBusiness.disabled=value;
        
    }


    function Enable_Validation_On_PersonSPOKEN()
    {
        
        var statusIndex=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>").options[statusIndex].text;
                 
        var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
        var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
            
           
           if (status=="Name")
           {
                txtPersonSpokenTo.disabled=false;                
                
           }
           else if (status=="Applicant")
           {
                 txtPersonSpokenTo.disabled=true;
                          
           }
           else if (status=="Not Confimed")
           {
                txtPersonSpokenTo.disabled=true;
                                 
            
           }
           else
           {
            txtPersonSpokenTo.disabled=false;
            
           }
           
         
    
    }
    

 function Enabled_Validation_YY_MM(ChkboxId,ChkValue,Control_DOBID,Control_YYID,Control_MMID)
    {
//            var value=false;
//            if (ChkboxId.checked==ChkValue)
//            {     
//                value=true;       
//                Control_YYID.value="";
//                Control_MMID.value="";            
//            }       

//                Control_YYID.disabled=value;
//                Control_MMID.disabled=value;
//            
//                
//            if (Control_DOBID!=null)
//            {
//                Control_DOBID.disabled=value;
//                Control_DOBID.value="";
//                var img1=document.getElementById("img1");
//                if (img1!=null)
//                {
//                img1.disabled=value;
//                }
//            }
          var value=false;
        if (ChkboxId.checked==ChkValue)
        {     
            value=true;       
            Control_YYID.value="";
            Control_MMID.value="";  
            
             if (Control_DOBID!=null)
            {
                Control_DOBID.disabled=value;
                Control_DOBID.value="";
                var Img1=document.getElementById("Img1");
                if (Img1!=null)
                {
                 Img1.disabled=value
                }
            }
                      
        }   
        else
        {
                if (Control_DOBID!=null)
                    {
                        Control_DOBID.disabled=value;
                        
                        var Img1=document.getElementById("Img1");
                        if (Img1!=null)
                        {
                         Img1.disabled=value
                        }
                    }
                
        }      
            
        
            Control_YYID.disabled=value;
            Control_MMID.disabled=value;
        
    
    }
    


        function Enabled_Validation_On_OfficePhone_Confirm()
        {
            var statusIndex=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlOfficeTeleNo_Confirmed.ClientID%>").options[statusIndex].text;
            
            var ddlNatureOfBusiness=document.getElementById("<%=ddlNatureOfBusiness.ClientID%>");
            var txtDescOfBusiness=document.getElementById("<%=txtDescOfBusiness.ClientID%>");
            var txtEmployerPhoneNo=document.getElementById("<%=txtEmployerPhoneNo.ClientID%>");
            var ddlWelcomeMessageHeard=document.getElementById("<%=ddlWelcomeMessageHeard.ClientID%>");
            var ddlPersonSpokenTo=document.getElementById("<%=ddlPersonSpokenTo.ClientID%>");
            var txtPersonSpokenTo=document.getElementById("<%=txtPersonSpokenTo.ClientID%>");
            var ddlInfo_Provided=document.getElementById("<%=ddlInfo_Provided.ClientID%>");
            var ddlReasonForOffice_NotConf=document.getElementById("<%=ddlReasonForOffice_NotConf.ClientID%>");
            
            
            
            
           
            var value=false;
            if (status=="Not Confirmed")
            {
                    value=true;
                    txtDescOfBusiness.value="";
                    txtEmployerPhoneNo.value="";
                    txtPersonSpokenTo.value="";
                    
                    ddlInfo_Provided.selectedIndex=2;                   
                    ddlNatureOfBusiness.selectedIndex=0;
                    ddlWelcomeMessageHeard.selectedIndex=0;
                    ddlPersonSpokenTo.selectedIndex=0;
                    
    
                   
            }
            ddlInfo_Provided.disabled=value;
            ddlNatureOfBusiness.disabled=value;
            ddlWelcomeMessageHeard.disabled=value;
            ddlPersonSpokenTo.disabled=value;            
            txtDescOfBusiness.disabled=value;
            txtEmployerPhoneNo.disabled=value;
            txtPersonSpokenTo.disabled=value;
            
            if (status=="Not Confirmed")
            {
                ddlReasonForOffice_NotConf.disabled=false;
              }
            else
            {
                ddlReasonForOffice_NotConf.disabled=true;       
                ddlReasonForOffice_NotConf.selectedIndex=0;
       
            }
            
             Enabled_Validation_on_InfoProvided();
     
                                      
            
        
        }
       
        
        function Enable_Validation_ResidanceNo_Confirmed(MainControlId,MainValue,ActionToTake,ControlIdToComp,ControlType)
        {
          // debugger;
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

    <asp:Panel ID="PnlView" runat="server" Height="100%" Width="100%">
    <table style="width: 100%">
        <tr>
            <td style="width: 29px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:HiddenField ID="hdnVeriTypeId" runat="server" />
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="5">
                &nbsp;Business Telephonic Verification</td>
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
            <td class="TableTitle" colspan="5">
                Applicantion Details</td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Case Id" Width="204px"></asp:Label></td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtCaseId" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Applicantion Number</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtApplicantionNumber" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Applicant Name</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtApplicantName" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Office No &nbsp;Confimed</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlOfficeTeleNo_Confirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 29px;">
            </td>
            <td>
                Reason for Office No if Not Confimed</td>
            <td style="height: 22px;">
            </td>
            <td style="height: 22px;">
                <asp:DropDownList ID="ddlReasonForOffice_NotConf" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Wrong No</asp:ListItem>
                    <asp:ListItem>Invalid No</asp:ListItem>
                    <asp:ListItem>Temporarily out of service</asp:ListItem>
                    <asp:ListItem>Perpetually engaged</asp:ListItem>
                    <asp:ListItem>No response</asp:ListItem>
                    <asp:ListItem>Answering machine</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Office Telephone No</td>
            <td>
                <asp:RegularExpressionValidator ID="rntxtEmployerPhoneNo" runat="server" ControlToValidate="txtEmployerPhoneNo"
                    ErrorMessage="Plese enter only Numeric values!"  
                     Width="17px" Font-Bold="True" ValidationExpression="[0-9]{0,15}">?</asp:RegularExpressionValidator></td>
            <td>
                <asp:TextBox ID="txtEmployerPhoneNo" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                <span style="color: dimgray">(Please enter only numeric values)</span></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Welcome Message Heard</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlWelcomeMessageHeard" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 29px;">
            </td>
            <td>
                Person Spoken</td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlPersonSpokenTo" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Not Confimed</asp:ListItem>
                    <asp:ListItem>Applicant</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Person Spoken To Name</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtPersonSpokenTo" runat="server" SkinID="txtSkin" Width="206px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 29px;">
            </td>
            <td>
                Information provided</td>
            <td style="height: 22px;">
            </td>
            <td style="height: 22px;">
                <asp:DropDownList ID="ddlInfo_Provided" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Employer name confimed</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlEmployerName" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Employer name If Confimed</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtEmployerName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 29px;">
            </td>
            <td>
                Designation of person contacted Confirmed</td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlDesignationOfPersonContatced" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Designation of person contacted</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtDesignationOfPersonContacted" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Applicant Employment</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlApplicantEmployment" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                    <asp:ListItem>Transferred</asp:ListItem>
                    <asp:ListItem>Left the job</asp:ListItem>
                    <asp:ListItem>About to resign</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Designation of Applicant Confirmed</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlDesignationOfApplicant" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Designation of Applicant
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtDesignationOfApplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Department of Applicant Confirmed</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartmentOfApplicant" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Department of Applicant</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtDepartmentOfApplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Extension No. of applicant</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtExtNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px; height: 22px;">
            </td>
            <td style="height: 22px">
                Employer Address Confirmed</td>
            <td style="height: 22px">
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlEmployerAddress" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                If Employer Address Confirm</td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtEmployerAddress" runat="server" Height="44px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="461px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px; height: 41px;">
            </td>
            <td style="height: 41px">
                Y C E</td>
            <td style="height: 41px">
            </td>
            <td style="height: 41px">
                <table border="0" style="width: 57%; height: 100%">
                    <tr>
                        <td colspan="1" style="width: 100px" class="HighLight">
                            <asp:CheckBox ID="chkYCE" runat="server" Text="Not Confirmed" Width="99px" /></td>
                        <td colspan="1" style="width: 100px" class="HighLight">
                            YY:MM</td>
                        <td style="width: 8px" class="HighLight">
                            <asp:TextBox ID="txtYearsAtEmployement_YY" runat="server" SkinID="txtSkin" Width="31px" MaxLength="2"></asp:TextBox></td>
                        <td class="HighLight">
                            <asp:TextBox ID="txtYearsAtEmployement_MM" runat="server" SkinID="txtSkin" Width="31px" MaxLength="2"></asp:TextBox></td>
                        <td>
                            <asp:RangeValidator ID="rnYCRYY" runat="server" ControlToValidate="txtYearsAtEmployement_YY"
                                ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer" Width="9px">?</asp:RangeValidator></td>
                        <td>
                            <asp:RangeValidator ID="rnYCRMonth" runat="server" ControlToValidate="txtYearsAtEmployement_MM"
                                ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer" Width="9px">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 41px;">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Age/DOB</td>
            <td>
            </td>
            <td>
                <table border="0" cellpadding="0" cellspacing="1" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 9px" class="HighLight">
                            &nbsp;&nbsp;<asp:CheckBox ID="chkAGE_DOB" runat="server" Text="Not Confirmed" Width="99px" />
                        </td>
                        <td class="HighLight">
                            <strong>
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="DD-MM-YYYY" Width="76px"></asp:Label></strong></td>
                        <td style="width: 100px" class="HighLight">
                            <asp:TextBox ID="txtApplicantAge_DOB" runat="server" SkinID="txtSkin" Width="151px" MaxLength="10"></asp:TextBox></td>
                        <td style="width: 100px">
                            &nbsp;<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtApplicantAge_DOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td style="width: 63px">
                            &nbsp;</td>
                        <td style="width: 63px" class="HighLight">
                            &nbsp;YY:MM</td>
                        <td class="HighLight">
                            <asp:TextBox ID="txtApplicantAge_DOB_YY" runat="server" SkinID="txtSkin" Width="29px"></asp:TextBox>
                        </td>
                        <td style="width: 100px" class="HighLight">
                            <asp:TextBox ID="txtApplicantAge_DOB_MM" runat="server" SkinID="txtSkin" Width="29px"></asp:TextBox>
                            </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            &nbsp;<asp:RangeValidator ID="rn_DOB_MM" runat="server" ControlToValidate="txtApplicantAge_DOB_MM"
                                ErrorMessage="Please Enter Numeric Values for DOB Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator>
                            <asp:RangeValidator ID="RnDOB_YY" runat="server" ControlToValidate="txtApplicantAge_DOB_YY"
                                ErrorMessage="Please Enter Numeric Values for DOB Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Additional Office no. if contacted</td>
            <td>
            </td>
            <td>
                <asp:DropDownList ID="ddlAddition_No" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Additional Office no</td>
            <td>
                <asp:RegularExpressionValidator  ID="rntxtAdditionalNo" runat="server" ControlToValidate="txtAdditionalNo"
                    ErrorMessage="Plese enter only Numeric values!"  
                     Width="13px" Font-Bold="True" ValidationExpression="[0-9]{0,15}">?</asp:RegularExpressionValidator></td>
            <td>
                <asp:TextBox ID="txtAdditionalNo" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox>
                <span style="color: dimgray">(Please enter only numeric values)</span></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Residence Ph no.</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtResiPhone"
                    ErrorMessage="Plese enter only Numeric values!" Font-Bold="True" ValidationExpression="[0-9]{0,15}"
                    Width="13px">?</asp:RegularExpressionValidator></td>
            <td>
                <asp:TextBox ID="txtResiPhone" runat="server" SkinID="txtSkin"></asp:TextBox>
                <span style="color: #696969">(Please enter only numeric values)</span></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Residence Address Confirmed</td>
            <td>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlResiAddress" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not Confirm</asp:ListItem>
                    <asp:ListItem>Not Possible</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 29px;">
            </td>
            <td>
                Residance Address</td>
            <td style="height: 16px">
            </td>
            <td colspan="2" style="height: 16px">
                <asp:TextBox ID="txtResidanceAddress" runat="server" Height="44px" SkinID="txtSkin"
                    TextMode="MultiLine" Width="461px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 29px; height: 22px;">
            </td>
            <td style="height: 22px">
                Nature of Business</td>
            <td style="height: 22px">
            </td>
            <td colspan="2" style="height: 22px">
                <asp:DropDownList ID="ddlNatureOfBusiness" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>
                    <asp:ListItem>Trading</asp:ListItem>
                    <asp:ListItem>Services</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                If Other</td>
            <td>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtNaturaOfBusiness" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Description of Business</td>
            <td>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDescOfBusiness" runat="server" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="5" style="height: 19px">
                Tele Caller Attempt Details</td>
        </tr>

        <tr>
            <td style="width: 29px">
            </td>
            <td colspan="4">
                <table>
                    <tr>
                        <td class="TDWidth" style="width: 5%; height: 16px">
                            Attempt</td>
                        <td style="height: 16px">
                            Date</td>
                        <td style="height: 16px">
                            Time [hh:mm]</td>
                        <td style="height: 16px">
                            Telephone No</td>
                        <td style="height: 16px">
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
<td class="TDWidth" style="width: 5%; height: 23px;">
<asp:Label SkinID="lblSkin"   ID="lbl3rdCall" runat="server" Text="3rd call"></asp:Label>
</td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtDate3rdCall" runat="server"></asp:TextBox>
    <img id="ImgDate3rdCall"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate3rdCall.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtTime3rdCall" runat="server" MaxLength="5"></asp:TextBox>
    <asp:DropDownList ID="ddlTime3rdCall" runat="server" SkinID="ddlSkin">
        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
    </asp:DropDownList></td>
<td style="height: 23px">
<asp:TextBox SkinID="txtSkin"   ID="txtTelNo3rdCall" runat="server" MaxLength="50"></asp:TextBox>
</td>
<td style="height: 23px">
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
<td class="TDWidth" style="width: 5%">
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
            <td style="width: 29px">
            </td>
            <td>
                Tele Caller Name</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlTeleCallerName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        
        <tr>
            <td style="height: 47px; width: 29px;">
            </td>
            <td>
                Tele Caller Remark <span style="font-size: 9pt; color: #ff0000">*</span></td>
            <td style="height: 47px;" colspan="2">
                <asp:TextBox ID="txtTeleCallerRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="474px" Height="46px" MaxLength="500"></asp:TextBox>
                </td>
            <td align="left" valign="top">
                <asp:Label ID="lblCount" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Supervisor Name</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlSupervisorName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Supervisor Remark</td>
            <td colspan="2">
                <asp:TextBox ID="txtSuperVisorRemark" runat="server" SkinID="txtSkin" TextMode="MultiLine"
                    Width="474px" Height="45px" MaxLength="100"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 29px; height: 22px;">
            </td>
            <td style="height: 22px">
                Web Checked</td>
            <td colspan="2" style="height: 22px">
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
            <td style="width: 100px; height: 22px;">
            </td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
                Proprietor recommendation <span style="font-size: 9pt; color: #ff0000">*</span></td>
            <td colspan="2">
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
            <td style="height: 16px; width: 29px;">
            </td>
            <td>
                If defaulter, details</td>
            <td style="height: 16px" colspan="2">
                <asp:TextBox ID="txtDefault" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="5" class="TableTitle" style="height: 41px">
                &nbsp; &nbsp;<asp:Button ID="btnSubmit" runat="server" SkinID="btnSubmitSkin" OnClick="btnSubmit_Click" Height="23px" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" SkinID="btnCancelSkin" Height="23px" /></td>
        </tr>
        <tr>
            <td style="width: 29px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    </asp:Panel>   
</asp:Content>


