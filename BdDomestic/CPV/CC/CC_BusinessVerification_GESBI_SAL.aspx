<%@ Page Language="C#" MasterPageFile= "~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="~/CPV/CC/CC_BusinessVerification_GESBI_SAL.aspx.cs" Inherits="CC_BusinessVerification_GESBI_SAL" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script language ="javascript"  type ="text/javascript" >
    
        function CountLength()
        {
          //debugger;
          var txtObservation=document.getElementById("<%=txtObservation.ClientID%>").value;
          var txtVerifierRemark=document.getElementById("<%=txtVerifierRemark.ClientID%>").value;          
       
          var Label4=document.getElementById("<%=Label4.ClientID%>");  
          Label4.innerText=txtVerifierRemark.length+txtObservation.length;     
        
        }      
    

      function Enable_SupervisorAutoPopulate_Remark()
        {
            var statusIndex=document.getElementById("<%=ddlDirectoryChecked.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlDirectoryChecked.ClientID%>").options[statusIndex].text;
            var strSuperVisorRemark="";
            var txtSuperVisorRemark=document.getElementById("<%=txtSuperVisorRemark.ClientID%>");
            
            if (status!='')
            {   
                status=status.substring(0,4);
                strSuperVisorRemark=status;
            
            }       
        
            txtSuperVisorRemark.value=strSuperVisorRemark;
        }    
    
    function Enable_Validation_On_Submit()
    {
    
       
        var ReturnValue=true;
        var strErrorMessage="";
                     
        var lblMsg=document.getElementById("<%=lblMsg.ClientID%>");          
        var txtNoOfEmployees=document.getElementById("<%=txtNoOfEmployees.ClientID%>");          
        var strNoOfEmp=txtNoOfEmployees.value;
          
          var ddlProprietorRecomm=document.getElementById("<%=ddlProprietorRecomm.ClientID%>");          
          if (ddlProprietorRecomm.value=='')
          { 
            ReturnValue=false;
            strErrorMessage="Please select Proprietor Recommendation!";
          }
      
            if (!Enable_Validation_On_Dropdown('ddlTPC1_Name',0))            
            {
                strErrorMessage="Please check Mandatory fields: TPC1 Name";
                ReturnValue=false;                                
            }
            
             if (!Enable_Validation_On_Dropdown('ddlTPC2_Name',0))            
            {
                strErrorMessage="Please check Mandatory fields: TPC2 Name!";
                ReturnValue=false;                                
            }
        
         
      lblMsg.innerText=strErrorMessage;
      
      window.scrollTo(0,0);
      return ReturnValue;
    }
    
    function Enable_Validation_On_Dropdown(ddlControlId,SelectedIndex)
    {      
       ddlControlId=document.getElementById('ctl00_C1_'+ddlControlId);       
       
       if (ddlControlId!=null)
       {
           if(ddlControlId.selectedIndex==SelectedIndex)
            {
                //ddlControlId.focus()
                return false;
            }     
           else
           {
                return true;
           }            
       }  
       else
       {
             return true;
       }
       
       
    }    

    
    function Page_load_validation()
    {    
      var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
      var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
      var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
      var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
      
      var chk_Exit_Company=document.getElementById("<%=chk_Exit_Company.ClientID%>");
      var txtNoofExistenceYear=document.getElementById("<%=txtNoofExistenceYear.ClientID%>");
      var txtNoOfExistenceMonth=document.getElementById("<%=txtNoOfExistenceMonth.ClientID%>");
      
      var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
      var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
      var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
      
      var chk_TPC2_YCE=document.getElementById("<%=chk_TPC2_YCE.ClientID%>");
      var txtTPC2_YCEYear=document.getElementById("<%=txtTPC2_YCEYear.ClientID%>");
      var txtTPC2_Month=document.getElementById("<%=txtTPC2_Month.ClientID%>");
      
      var chk_TPC1AppYCE=document.getElementById("<%=chk_TPC1AppYCE.ClientID%>");
      var txtTPC1_Year=document.getElementById("<%=txtTPC1_Year.ClientID%>");
      var txtTPC1_Month=document.getElementById("<%=txtTPC1_Month.ClientID%>");
         
      var chk_TPC1_age=document.getElementById("<%=chk_TPC1_age.ClientID%>");
      var txtTPC1_AgeYear=document.getElementById("<%=txtTPC1_AgeYear.ClientID%>");
      var txtTPC1_AgeMonth=document.getElementById("<%=txtTPC1_AgeMonth.ClientID%>");
      
      var chkTPC2_age=document.getElementById("<%=chkTPC2_age.ClientID%>");
      var txtTPC2_AgeYear=document.getElementById("<%=txtTPC2_AgeYear.ClientID%>");
      var txtTPC2_AgeMonth=document.getElementById("<%=txtTPC2_AgeMonth.ClientID%>");
      
      Enabled_Validation_YY_MM( chkApplicant_DOBAGE_NotConf,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM);
      Enabled_Validation_YY_MM(chk_Exit_Company,true,null,txtNoofExistenceYear,txtNoOfExistenceMonth);
      Enabled_Validation_YY_MM(chk_YCE,true,null,txtYearinEmployment,txtMonth);
      Enabled_Validation_YY_MM(chk_TPC2_YCE,true,null,txtTPC2_YCEYear,txtTPC2_Month);
      Enabled_Validation_YY_MM(chk_TPC1AppYCE,true,null,txtTPC1_Year,txtTPC1_Month);
      Enabled_Validation_YY_MM(chk_TPC1_age,true,null,txtTPC1_AgeYear,txtTPC1_AgeMonth);
      Enabled_Validation_YY_MM(chkTPC2_age,true,null,txtTPC2_AgeYear,txtTPC2_AgeMonth);
      
      information_Provided();
      Address_Not_Confirmed();
      Entry_Permitted();
      TPC_Not_Confirmed();
      TPC2_Not_Confirmed();
      
     // Enable_validation_on_TPC_ApplicantName();
     // Enable_validation_on_TPC2_ApplicantName();
     //Enable_validation_on_TPC_ApplicantName_ForSalaried();
      
      Enable_Validation_On_AddressUpdation();
      Enabled_validation_ApplicantName();
      ValidationOn_Address_Confirmed();
      Name_of_person_met();
         
}
function Enable_validation_on_Remark_for_Salaried()
{
 var statusAddConf=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
 var status_AddressConf=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusAddConf].text;
 
 var statusNameofPerson=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").selectedIndex; 
 var StatusPerson_Met=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").options[statusNameofPerson].text; 
 var txtNameOfPersonMet=document.getElementById("<%=txtNameOfPersonMet.ClientID%>");  

 var str_PersonMet;
        
            if ((StatusPerson_Met=="Applicant")||(StatusPerson_Met=="NotConfirmed")||(StatusPerson_Met=='NotPossible'))
            {
                str_PersonMet=StatusPerson_Met;        
            }
            else
            {
                str_PersonMet=txtNameOfPersonMet.value;
            }
 var status_info=document.getElementById("<%=ddlInformationProvided.ClientID%>").selectedIndex;
 var status_InfoProvided=document.getElementById("<%=ddlInformationProvided.ClientID%>").options[status_info].text;
          
 var statusRelationWithApp=document.getElementById("<%=ddlrelationwithapplicant.ClientID%>").selectedIndex;
 var statusRelation=document.getElementById("<%=ddlrelationwithapplicant.ClientID%>").options[statusRelationWithApp].text;
 var txtrelationwithapplicant=document.getElementById("<%=txtrelationwithapplicant.ClientID%>");             
 var str_Relationship;
 
     if((statusRelation=='NotConfirmed')||(statusRelation=='NotPossible'))
     {
       str_Relationship=statusRelation;
     }
     else
     {
      str_Relationship=txtrelationwithapplicant.value;
     }
 
 var stat_CompName=document.getElementById("<%=ddlCompanyName.ClientID%>").selectedIndex;
 var status_CompanyName=document.getElementById("<%=ddlCompanyName.ClientID%>").options[stat_CompName].text;
 var txtNameofBusiness=document.getElementById("<%=txtNameofBusiness.ClientID%>");
 var str_CompanyName
    
     if((status_CompanyName=='NotConfirmed')||(status_CompanyName=='No such person'))
     {
      str_CompanyName=status_CompanyName;
     }
     else
     {
      str_CompanyName=txtNameofBusiness.value;
     }
 
 var statusAppConfwith=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>").selectedIndex;
 var status_AppConfWith=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>").options[statusAppConfwith].text;
           
 var statusDesgApp=document.getElementById("<%=ddldesignationofApplicant.ClientID%>").selectedIndex;
 var status_DesigOfAppl=document.getElementById("<%=ddldesignationofApplicant.ClientID%>").options[statusDesgApp].text;
 var txtdesignationofapplicant=document.getElementById("<%=txtdesignationofapplicant.ClientID%>");
 var str_DesigOfApp;
      
     if(status_DesigOfAppl=="Not Confirmed")
     {
      str_DesigOfApp="Not Conf";
     }
     else
     {
      str_DesigOfApp=txtdesignationofapplicant.value;
     }

 var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
 var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
 var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
 var str_YCE;
         if(chk_YCE.checked==true)
             {
               str_YCE='Not Conf';
             }
             else
             {
               str_YCE=txtYearinEmployment.value+":"+txtMonth.value;
             }
 
 var statusDepartment=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>").selectedIndex;
 var status_Department=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>").options[statusDepartment].text;
 var txtDepartment=document.getElementById("<%=txtDepartment.ClientID%>");  
 var str_dept;
         if(status_Department=="NotConfirmed")
         {
          str_dept='Not Conf';
         }
         else
         {
          str_dept=txtDepartment.value;
         }
 var ddlNature_of_Business=document.getElementById("<%=ddlNature_of_Business.ClientID%>");
 var txtBusinessDescription=document.getElementById("<%=txtBusinessDescription.ClientID%>");

 var statusEntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>").selectedIndex;
 var status_EntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>").options[statusEntryPermitted].text;
 
 var ddlActivitySeen=document.getElementById("<%=ddlActivitySeen.ClientID%>");
 var ddlStockSeen=document.getElementById("<%=ddlStockSeen.ClientID%>");    
 var ddl_OfficeStatus=document.getElementById("<%=ddl_OfficeStatus.ClientID%>");
 var txtNoOfEmployees=document.getElementById("<%=txtNoOfEmployees.ClientID%>");
 var ddlCompanyboardSeen=document.getElementById("<%=ddlCompanyboardSeen.ClientID%>");
              
 
 var statTPC1=document.getElementById("<%=ddlTPC1_Name.ClientID%>").selectedIndex;
 var statIndTPC1=document.getElementById("<%=ddlTPC1_Name.ClientID%>").options[statTPC1].text;
 var txtTPC1_Name=document.getElementById("<%=txtTPC1_Name.ClientID%>");
 var str_TPC1;
    if((statIndTPC1=="NotPossible")||(statIndTPC1=="NotProvided"))
     {
      str_TPC1=statIndTPC1;
     }
     else
     {
      str_TPC1=txtTPC1_Name.value;
     }
     
 var ddlTPC1_ByWHOM=document.getElementById("<%=ddlTPC1_ByWHOM.ClientID%>");
 var txtTPC1_Address=document.getElementById("<%=txtTPC1_Address.ClientID%>");
 
 var statusAppName=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").selectedIndex;
 var stat_TPC1ApplicantName=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").options[statusAppName].text;
 var txtTPC1_ApplicantName=document.getElementById("<%=txtTPC1_ApplicantName.ClientID%>");
 var str_AppName;
     if((stat_TPC1ApplicantName=="Not Confirmed")||(stat_TPC1ApplicantName=="No Such Person"))
     {
      str_AppName=stat_TPC1ApplicantName;
     }
     else
     {
      str_AppName=txtTPC1_ApplicantName.value;
     }
 
 var ddlTPC1_Employment=document.getElementById("<%=ddlTPC1_Employment.ClientID%>");
 
 var statusTPC1_DesigApp=document.getElementById("<%=ddlTPC1_DesignofApplicant.ClientID%>").selectedIndex;
 var stat_TPC1_DesiApp=document.getElementById("<%=ddlTPC1_DesignofApplicant.ClientID%>").options[statusTPC1_DesigApp].text;
 var txtTPC1_designationOfApp=document.getElementById("<%=txtTPC1_designationOfApp.ClientID%>");
 var str_TPC1DesigApp;
      if(stat_TPC1_DesiApp=="Not confirmed")
      {
       str_TPC1DesigApp="Not Conf";
      }
      else
      {
       str_TPC1DesigApp=txtTPC1_designationOfApp.value;
      }
 
 var chk_TPC1AppYCE=document.getElementById("<%=chk_TPC1AppYCE.ClientID%>");
 var txtTPC1_Year=document.getElementById("<%=txtTPC1_Year.ClientID%>");
 var txtTPC1_Month=document.getElementById("<%=txtTPC1_Month.ClientID%>");
 var str_TPC1YCE;  
   if(chk_TPC1AppYCE.checked==true)
     {
       str_TPC1YCE="Not Conf";
     }
     else
     {
       str_TPC1YCE=txtTPC1_Year.value+":"+txtTPC1_Month.value;
     }

 var statTPC2=document.getElementById("<%=ddlTPC2_Name.ClientID%>").selectedIndex;
 var statIndTPC2=document.getElementById("<%=ddlTPC2_Name.ClientID%>").options[statTPC2].text;
 var txtTPC2_Name=document.getElementById("<%=txtTPC2_Name.ClientID%>");
 var str_TPC2;
   if((statIndTPC2=="NotPossible")||(statIndTPC2=="NotProvided"))
   {
    str_TPC2=statIndTPC2;
   }
   else
   {
    str_TPC2=txtTPC2_Name.value;
   }
   
 var ddlTPC2_ByWhom=document.getElementById("<%=ddlTPC2_ByWhom.ClientID%>");
 var txtTPC2_Address=document.getElementById("<%=txtTPC2_Address.ClientID%>");
 
 var statTPC2AppName=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").selectedIndex;
 var stat_TPC2AppName=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").options[statTPC2AppName].text;
 var txtTPC2_AppName=document.getElementById("<%=txtTPC2_AppName.ClientID%>");
 var str_TPC2AppName;
   if((stat_TPC2AppName=="Not Confirmed")||(stat_TPC2AppName=="No Such Person"))
     {
      str_TPC2AppName=stat_TPC2AppName;
     }
     else
     {
      str_TPC2AppName=txtTPC2_AppName.value;
     }
     
 var ddlTPC2_employment=document.getElementById("<%=ddlTPC2_employment.ClientID%>");
 
 var statTPC2Desig=document.getElementById("<%=ddl_TPC2Desig_App.ClientID%>").selectedIndex;
 var stat_TPC2Desig=document.getElementById("<%=ddl_TPC2Desig_App.ClientID%>").options[statTPC2Desig].text;
 var txtTPC2_dsigApp=document.getElementById("<%=txtTPC2_dsigApp.ClientID%>");
 var str_TPC2Desig;
     if(stat_TPC2Desig=="Not confirmed")
     {
      str_TPC2Desig="Not Conf";
     }
     else
     {
       str_TPC2Desig=txtTPC2_dsigApp.value;
     }
     
 var chk_TPC2_YCE=document.getElementById("<%=chk_TPC2_YCE.ClientID%>");   
 var txtTPC2_YCEYear=document.getElementById("<%=txtTPC2_YCEYear.ClientID%>");
 var txtTPC2_Month=document.getElementById("<%=txtTPC2_Month.ClientID%>");
 var str_TPC2YCE;
 if(chk_TPC2_YCE.checked==true)
     {
       str_TPC2YCE="Not Conf";
     }
     else
     {
       str_TPC2YCE=txtTPC2_YCEYear.value+":"+txtTPC2_Month.value;
     }
     
 var statAddUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").selectedIndex;
 var stat_AddUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").options[statAddUpdation].text;
 var txtCorrectAddress=document.getElementById("<%=txtCorrectAddress.ClientID%>");
 var str_AddUpdation;
   if(stat_AddUpdation=="No")
   {
    str_AddUpdation=stat_AddUpdation;
   }
   else
   {
    str_AddUpdation=txtCorrectAddress.value;
   }
 
 
 var statProprietorRecc=document.getElementById("<%=ddlProprietorRecomm.ClientID%>").selectedIndex;
 var stat_ProprietorRecc=document.getElementById("<%=ddlProprietorRecomm.ClientID%>").options[statProprietorRecc].text;
 var txtdefaulter=document.getElementById("<%=txtdefaulter.ClientID%>");
     
 var statReaAdd=document.getElementById("<%=ddl_ReasonAddNotConf.ClientID%>").selectedIndex;
 var statReason=document.getElementById("<%=ddl_ReasonAddNotConf.ClientID%>").options[statReaAdd].text;
 
 var txtResultofCalling=document.getElementById("<%=txtResultofCalling.ClientID%>");
 var txtWhomaddBelong=document.getElementById("<%=txtWhomaddBelong.ClientID%>");
 var Hdn_OccupationType=document.getElementById("<%=Hdn_OccupationType.ClientID%>");    

 var txtVerifierRemark=document.getElementById("<%=txtVerifierRemark.ClientID%>");
 
 var str='';
 if(status_AddressConf=="Yes")
    {      
    
        
           
            var statusIndex_VerifierRemarks1=document.getElementById("<%=ddlVerifierRemarks1.ClientID%>").selectedIndex;
            var status_VerifierRemarks1=document.getElementById("<%=ddlVerifierRemarks1.ClientID%>").options[statusIndex_VerifierRemarks1].text;
            
            var statusIndex_VerifierRemarks2=document.getElementById("<%=ddlVerifierRemarks2.ClientID%>").selectedIndex;
            var status_VerifierRemarks2=document.getElementById("<%=ddlVerifierRemarks2.ClientID%>").options[statusIndex_VerifierRemarks2].text;
           
              
        
                    if (status_VerifierRemarks1=='Untraceable')                        
                    {
                        if (status_VerifierRemarks2=='Contactable')
                            {
                                str=str+'1ST VST UNTRACLE 2ND VST TRACD/' 
                            }
                    }
                    else if (status_VerifierRemarks1=='door Locked')                        
                    {
                        if (status_VerifierRemarks2=='Contactable')
                            {
                                str=str+'1ST VST DOORLOCKD 2ND VST CONTD/' 
                            }
                    }
 
            str=str+"MET-"+str_PersonMet;
             if(StatusPerson_Met!="NotPossible")
               {
                 //str=str+" / Relationship- "+str_Relationship;
                
                     if(status_InfoProvided!="No") 
                     {
                       if((StatusPerson_Met!="Applicant")&&(StatusPerson_Met!="NotPossible"))
                         {
                           str=str+"/REL-"+str_Relationship;
                         }
                         if (status_AddressConf=='Yes')
                         {
                            str=str+"/ADD CONF";
                         }
                         else
                         {
                            str=str+"/ADD NOT CONF"
                         }
                         str=str+"/CO NM-"+str_CompanyName;                                                  
                         status_AppConfWith=status_AppConfWith.replace('onfirm','onf');
                         str=str+"/APP NM-"+status_AppConfWith;
                         str=str+"/DESG-"+str_DesigOfApp;
                         
                       if(Hdn_OccupationType.value=="S")
                         {
                           str=str+"/YCE-"+str_YCE;
                         }
                       else
                        {
                          str=str+"/YCB-"+str_YCE;
                        }
                        
                         str=str+"/DEPT-"+str_dept;
                         str=str+"/NOB-"+ddlNature_of_Business.value;
                         str=str+"/DESC-"+txtBusinessDescription.value;
                         
                    }
                    else
                    {
                      str=str+"/INFO PROVD-"+status_InfoProvided;
                    }
               }
               str=str+"/ENTY PERMD-"+status_EntryPermitted;
              if((status_EntryPermitted!="No")&&(status_EntryPermitted!="Door Locked"))
               {  
                 str=str+"/ACTVY-"+ddlActivitySeen.value;
                 str=str+"/STOCK-"+ddlStockSeen.value;
                 str=str+"/OFF STATUS-"+ddl_OfficeStatus.value;
                 str=str+"/EMPLS-"+txtNoOfEmployees.value;
                 //str=str+" / Comp Board- "+ddlCompanyboardSeen.value;
               }
              str=str+"/CO BOARD-"+ddlCompanyboardSeen.value;
              
              if(statIndTPC1!="NotPossible")
               {
                 str=str+"/TPC1- "+str_TPC1;
                 str=str+"/BY-"+ddlTPC1_ByWHOM.value;
                 str=str+"/ADD-"+txtTPC1_Address.value;
                 //str=str+"/APP NM-"+str_AppName;
                 if (str_AppName!='Not Confirmed')
                 {
                    var TPC1_Employment=ddlTPC1_Employment.value;                    
                    TPC1_Employment=TPC1_Employment.replace('onfirmed','onf');
                    str=str+"/EMPLMT-"+TPC1_Employment;                 
                    if(stat_TPC1ApplicantName!="No Such Person")
                    {
                        str=str+"/DESG-"+str_TPC1DesigApp;
                        str=str+"/YCE-"+str_TPC1YCE;           
                    }
                 }   
               }
                if(statIndTPC2!="NotPossible")
                 
                {
                 str=str+"/TPC2-"+str_TPC2;
                 str=str+"/BY-"+ddlTPC2_ByWhom.value;
                 str=str+"/ADD-"+txtTPC2_Address.value;
                 //str=str+"/APP NM-"+str_TPC2AppName;
                 
                 if (str_TPC2AppName!='Not Confirmed')
                 {
                    str=str+"/EMPLMT-"+ddlTPC2_employment.value;                                            
                    if(stat_TPC2AppName!="No Such Person")
                    {
                      str=str+"/DESG-"+str_TPC2Desig;
                      str=str+"/YCE-"+str_TPC2YCE;
                    }
                } 
                
              }
              if(stat_AddUpdation=="Yes")
               {
                 str=str+"/ADD UPD-"+str_AddUpdation;
               }
             if(stat_ProprietorRecc=="Defaulter")
              {
               str=str+"/DFAULTR-"+txtdefaulter.value;
              }
          }
    else
     {
       if(statReason=="Untraceable")
       {
        if (status_AddressConf=='Confirmed')
            {
                str="/ADD CONF";
            }
            else
            {
                    str="/ADD NOT CONF";
            }
        str=str+"/ADD UNTRACEABLE";
        str=str+"/RESULT OF CALLING-"+txtResultofCalling.value;
       }
       else if(statReason=="Mismatch in address")
       { 
        str="ADD-"+status_AddressConf;
        str=str+"/ADD-MISMATCH";
        str=str+"/ADD BLONGS TO-"+txtWhomaddBelong.value;
        str=str+"/TPC1-"+str_TPC1;
        str=str+"/BY-"+ddlTPC1_ByWHOM.value;
        str=str+"/TPC2-"+str_TPC2;
        str=str+"/BY-"+ddlTPC2_ByWhom.value;
       }
     }
     
     str=str.replace('Confirmed','Conf');
     
     txtVerifierRemark.value=str;
     CountLength() ;      
}

 function Enable_Validation_Confirmed(MainControlId,MainValue,ActionToTake,ControlIdToComp,ControlType)
        {   var statusIndex=MainControlId.selectedIndex;
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
    

  function ValidationOn_Address_Confirmed()
      {
             
            var statusindex=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusindex].text;
            var ddlNameOfPersonMet=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>");              
            var txtNameOfPersonMet=document.getElementById("<%=txtNameOfPersonMet.ClientID%>");
            var txtDesignationofPerMet=document.getElementById("<%=txtDesignationofPerMet.ClientID%>");
            var ddlInformationProvided=document.getElementById("<%=ddlInformationProvided.ClientID%>");
            var ddlrelationwithapplicant=document.getElementById("<%=ddlrelationwithapplicant.ClientID%>");
            var txtrelationwithapplicant=document.getElementById("<%=txtrelationwithapplicant.ClientID%>");             
            var ddldesignationofApplicant=document.getElementById("<%=ddldesignationofApplicant.ClientID%>");
            var txtdesignationofapplicant=document.getElementById("<%=txtdesignationofapplicant.ClientID%>");
            var ddlApplicantConfirmedwith=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>");
            var ddldepartmentofApplicant=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>");
            var txtDepartment=document.getElementById("<%=txtDepartment.ClientID%>");    
            var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
            var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            var ddlCompanyName=document.getElementById("<%=ddlCompanyName.ClientID%>");    
            var txtNameofBusiness=document.getElementById("<%=txtNameofBusiness.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
            var ddlTypeofCompany=document.getElementById("<%=ddlTypeofCompany.ClientID%>");
            var ddlNature_of_Business=document.getElementById("<%=ddlNature_of_Business.ClientID%>");
            var txtBusinessDescription=document.getElementById("<%=txtBusinessDescription.ClientID%>");
            var txtTelephoneNo=document.getElementById("<%=txtTelephoneNo.ClientID%>");    
            var txtExtension=document.getElementById("<%=txtExtension.ClientID%>");
            var txtNoofExistenceYear=document.getElementById("<%=txtNoofExistenceYear.ClientID%>");
            var txtNoOfExistenceMonth=document.getElementById("<%=txtNoOfExistenceMonth.ClientID%>");
            var txtResidence=document.getElementById("<%=txtResidence.ClientID%>");
            var txtEmailId=document.getElementById("<%=txtEmailId.ClientID%>");
            var ddlTypeOfProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>");
            var ddlAppFullTimeEmployee=document.getElementById("<%=ddlAppFullTimeEmployee.ClientID%>");
           ////verifier fields
            var ddlEntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>");
            var ddlActivitySeen=document.getElementById("<%=ddlActivitySeen.ClientID%>");
            var ddlStockSeen=document.getElementById("<%=ddlStockSeen.ClientID%>");    
            var ddlOfficesetupseen=document.getElementById("<%=ddlOfficesetupseen.ClientID%>");
            var ddl_OfficeStatus=document.getElementById("<%=ddl_OfficeStatus.ClientID%>");
            var ddlAreaOfOffice=document.getElementById("<%=ddlAreaOfOffice.ClientID%>");
            var ddlTypeOfficeLocality=document.getElementById("<%=ddlTypeOfficeLocality.ClientID%>");
            var txtNoOfEmployees=document.getElementById("<%=txtNoOfEmployees.ClientID%>");
            var ddlCompanyboardSeen=document.getElementById("<%=ddlCompanyboardSeen.ClientID%>");
            var ddlEaseOfLocationOffice=document.getElementById("<%=ddlEaseOfLocationOffice.ClientID%>");
            var ddlAddressUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>");
            var txtCorrectAddress=document.getElementById("<%=txtCorrectAddress.ClientID%>");
            var txtLandmark=document.getElementById("<%=txtLandmark.ClientID%>");
            var Img1=document.getElementById("Img1");
            var pnlAddnotConfirmed=document.getElementById("<%=pnlAddnotConfirmed.ClientID%>");
            var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
            var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
            var chk_Exit_Company=document.getElementById("<%=chk_Exit_Company.ClientID%>");
            var value=false;
            
            if(status=="No")
                {
                   Img1.style.visibility="hidden";
                   pnlAddnotConfirmed.style.visibility="visible";             
               
                }
            else
                {
                    Img1.style.visibility="visible";
                    pnlAddnotConfirmed.style.visibility="hidden";
                }
            
            if(status=="No")
            
            {
                     value=true;
                     ddlNameOfPersonMet.value="";
                     txtNameOfPersonMet.value="";
                     txtDesignationofPerMet.value="";
                     ddlInformationProvided.value="";
                     ddlrelationwithapplicant.value="";
                     txtrelationwithapplicant.value="";
                     ddldesignationofApplicant.value="";
                     txtdesignationofapplicant.value="";
                     ddlApplicantConfirmedwith.value="";
                     ddldepartmentofApplicant.value="";
                     txtDepartment.value="";
                     txtYearinEmployment.value="";
                     txtMonth.value="";
                     txtApplicantAge_DOB.value="";
                     txtApplicantAge_DOB_YY.value="";
                     txtApplicantAge_DOB_MM.value="";
                     ddlCompanyName.value="";
                     txtNameofBusiness.value="";
                     txtEmployerAddress.value="";
                     ddlTypeofCompany.value="";
                     ddlNature_of_Business.value="";
                     txtBusinessDescription.value="";
                     txtTelephoneNo.value="";
                     txtExtension.value="";
                     txtNoofExistenceYear.value="";
                     txtNoOfExistenceMonth.value="";
                     txtResidence.value="";
                     txtEmailId.value="";
                     
                     ddlAppFullTimeEmployee.value="";
                     ddlTypeOfProof.value="";
                     chk_YCE.value="";
                     chkApplicant_DOBAGE_NotConf.value="";
                     chk_Exit_Company.value="";
                     /////verifier fields
                     ddlEntryPermitted.value="";
                     ddlActivitySeen.value="";
                     ddlStockSeen.value="";
                     ddlOfficesetupseen.value="";
                     ddl_OfficeStatus.value="";
                     ddlAreaOfOffice.value="";
                     ddlTypeOfficeLocality.value="";
                     txtNoOfEmployees.value="";
                     ddlCompanyboardSeen.value="";
                     ddlEaseOfLocationOffice.value="";
                     ddlAddressUpdation.value="";
                     txtCorrectAddress.value="";
                     txtLandmark.value="";
                     //---------
                     ddlNameOfPersonMet.selectedIndex=0;
                     txtNameOfPersonMet.selectedIndex=0;
                     txtDesignationofPerMet.selectedIndex=0;
                     ddlInformationProvided.selectedIndex=0;
                     ddlrelationwithapplicant.selectedIndex=0;
                     txtrelationwithapplicant.selectedIndex=0;
                     ddldesignationofApplicant.selectedIndex=0;
                     txtdesignationofapplicant.selectedIndex=0;
                     ddlApplicantConfirmedwith.selectedIndex=0;
                     ddldepartmentofApplicant.selectedIndex=0;
                     txtDepartment.selectedIndex=0;
                     txtYearinEmployment.selectedIndex=0;
                     txtMonth.selectedIndex=0;
                     txtApplicantAge_DOB.selectedIndex=0;
                     txtApplicantAge_DOB_YY.selectedIndex=0;
                     txtApplicantAge_DOB_MM.selectedIndex=0;
                     ddlCompanyName.selectedIndex=0;
                     txtNameofBusiness.selectedIndex=0;
                     txtEmployerAddress.selectedIndex=0;
                     ddlTypeofCompany.selectedIndex=0;
                     ddlNature_of_Business.selectedIndex=0;
                     txtBusinessDescription.selectedIndex=0;
                     txtTelephoneNo.selectedIndex=0;
                     txtExtension.selectedIndex=0;
                     txtNoofExistenceYear.selectedIndex=0;
                     txtNoOfExistenceMonth.selectedIndex=0;
                     txtResidence.selectedIndex=0;
                     txtEmailId.selectedIndex=0;
                     ddlAppFullTimeEmployee.selectedIndex=0;
                     ddlTypeOfProof.selectedIndex=0;
                     chk_YCE.selectedIndex=0;
                     chkApplicant_DOBAGE_NotConf.selectedIndex=0;
                     chk_Exit_Company.selectedIndex=0;     
                     /////verifier fields
                     ddlEntryPermitted.selectedIndex=0;
                     ddlActivitySeen.selectedIndex=0;
                     ddlStockSeen.selectedIndex=0;
                     ddlOfficesetupseen.selectedIndex=0;
                     ddl_OfficeStatus.selectedIndex=0;
                     ddlAreaOfOffice.selectedIndex=0;
                     ddlTypeOfficeLocality.selectedIndex=0;
                     txtNoOfEmployees.selectedIndex=0;
                     ddlCompanyboardSeen.selectedIndex=0;
                     ddlEaseOfLocationOffice.selectedIndex=0;
                     ddlAddressUpdation.selectedIndex=0;
                     txtCorrectAddress.selectedIndex=0;
                     txtLandmark.selectedIndex=0;
                     
                 }
                     ddlNameOfPersonMet.disabled=value;
                     txtNameOfPersonMet.disabled=value;
                     txtDesignationofPerMet.disabled=value;
                     ddlInformationProvided.disabled=value;
                     ddlrelationwithapplicant.disabled=value;
                     txtrelationwithapplicant.disabled=value;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddlApplicantConfirmedwith.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     
                     ddlAppFullTimeEmployee.disabled=value;
                     ddlTypeOfProof.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value; 
                     /////verifier fields
                     ddlEntryPermitted.disabled=value;
                     ddlActivitySeen.disabled=value;
                     ddlStockSeen.disabled=value;
                     ddlOfficesetupseen.disabled=value;
                     ddl_OfficeStatus.disabled=value;
                     ddlAreaOfOffice.disabled=value;
                     ddlTypeOfficeLocality.disabled=value;
                     txtNoOfEmployees.disabled=value;
                     ddlCompanyboardSeen.disabled=value;
                   
                     ddlEaseOfLocationOffice.disabled=value;
                     ddlAddressUpdation.disabled=value;
                     txtCorrectAddress.disabled=value;
                     txtLandmark.disabled=value;
                     
         }

    function information_Provided()
     {
            
            var statusindex=document.getElementById("<%=ddlInformationProvided.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlInformationProvided.ClientID%>").options[statusindex].text;
            var ddlrelationwithapplicant=document.getElementById("<%=ddlrelationwithapplicant.ClientID%>");              
            var txtrelationwithapplicant=document.getElementById("<%=txtrelationwithapplicant.ClientID%>");
            var ddldesignationofApplicant=document.getElementById("<%=ddldesignationofApplicant.ClientID%>");
            var txtdesignationofapplicant=document.getElementById("<%=txtdesignationofapplicant.ClientID%>");
            var ddldepartmentofApplicant=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>");
            var txtDepartment=document.getElementById("<%=txtDepartment.ClientID%>");              
            var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
            var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            var ddlCompanyName=document.getElementById("<%=ddlCompanyName.ClientID%>");    
            var txtNameofBusiness=document.getElementById("<%=txtNameofBusiness.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
            var ddlTypeofCompany=document.getElementById("<%=ddlTypeofCompany.ClientID%>");
            var ddlNature_of_Business=document.getElementById("<%=ddlNature_of_Business.ClientID%>");
            var txtBusinessDescription=document.getElementById("<%=txtBusinessDescription.ClientID%>");
            var txtTelephoneNo=document.getElementById("<%=txtTelephoneNo.ClientID%>");    
            var txtExtension=document.getElementById("<%=txtExtension.ClientID%>");
            var txtNoofExistenceYear=document.getElementById("<%=txtNoofExistenceYear.ClientID%>");
            var txtNoOfExistenceMonth=document.getElementById("<%=txtNoOfExistenceMonth.ClientID%>");
            var txtResidence=document.getElementById("<%=txtResidence.ClientID%>");
            var txtEmailId=document.getElementById("<%=txtEmailId.ClientID%>");
            var ddlTypeOfProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>");
            var Img1=document.getElementById("Img1");
            var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
            var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
            var chk_Exit_Company=document.getElementById("<%=chk_Exit_Company.ClientID%>");
            var ddlApplicantConfirmedwith=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>");
            var ddlAppFullTimeEmployee=document.getElementById("<%=ddlAppFullTimeEmployee.ClientID%>");
            value=false;
             if(status=="No")
            {
               Img1.style.visibility="hidden";
            }
            else
            {
              Img1.style.visibility="visible";
            }
            
            
            if (status=="No")
           { 
                     value=true;
                     ddlrelationwithapplicant.value="";
                     txtrelationwithapplicant.value="";
                     ddldesignationofApplicant.value="";
                     txtdesignationofapplicant.value="";
                     ddldepartmentofApplicant.value="";
                     txtDepartment.value="";
                     txtYearinEmployment.value="";
                     txtMonth.value="";
                     txtApplicantAge_DOB.value="";
                     txtApplicantAge_DOB_YY.value="";
                     txtApplicantAge_DOB_MM.value="";
                     ddlCompanyName.value="";
                     txtNameofBusiness.value="";
                     txtEmployerAddress.value="";
                     ddlTypeofCompany.value="";
                     ddlNature_of_Business.value="";
                     txtBusinessDescription.value="";
                     txtTelephoneNo.value="";
                     txtExtension.value="";
                     txtNoofExistenceYear.value="";
                     txtNoOfExistenceMonth.value="";
                     txtResidence.value="";
                     ddlTypeOfProof.value="";
                     txtEmailId.value="";
                     chk_YCE.value="";
                     chkApplicant_DOBAGE_NotConf.value="";
                     chk_Exit_Company.value="";  
                     ddlApplicantConfirmedwith.value="";
                     ddlAppFullTimeEmployee.value="";
                     //-----
                     ddlrelationwithapplicant.selectedIndex=0;
                     txtrelationwithapplicant.selectedIndex=0;
                     ddldesignationofApplicant.selectedIndex=0;
                     txtdesignationofapplicant.selectedIndex=0;
                     ddldepartmentofApplicant.selectedIndex=0;
                     txtDepartment.selectedIndex=0
                     txtYearinEmployment.selectedIndex=0;
                     txtMonth.selectedIndex=0;
                     txtApplicantAge_DOB.selectedIndex=0;
                     txtApplicantAge_DOB_YY.selectedIndex=0;
                     txtApplicantAge_DOB_MM.selectedIndex=0;
                     ddlCompanyName.selectedIndex=0;
                     txtNameofBusiness.selectedIndex=0;
                     txtEmployerAddress.selectedIndex=0;
                     ddlTypeofCompany.selectedIndex=0;
                     ddlNature_of_Business.selectedIndex=0;
                     txtBusinessDescription.selectedIndex=0;
                     txtTelephoneNo.selectedIndex=0;
                     txtExtension.selectedIndex=0;
                     txtNoofExistenceYear.selectedIndex=0;
                     txtNoOfExistenceMonth.selectedIndex=0;
                     txtResidence.selectedIndex=0;
                     ddlTypeOfProof.selectedIndex=0;
                     txtEmailId.selectedIndex=0;
                     chk_YCE.selectedIndex=0;
                     chkApplicant_DOBAGE_NotConf.selectedIndex=0;
                     chk_Exit_Company.selectedIndex=0;
                     ddlApplicantConfirmedwith.selectedIndex=0;
                     ddlAppFullTimeEmployee.selectedIndex=0;
          
             }
                     ddlrelationwithapplicant.disabled=value;
                     txtrelationwithapplicant.disabled=value;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     ddlTypeOfProof.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value;
                     ddlApplicantConfirmedwith.disabled=value;
                     ddlAppFullTimeEmployee.disabled=value;
          
                  
        }

 function Address_Not_Confirmed()
  {
   
    var statusindex=document.getElementById("<%=ddl_ReasonAddNotConf.ClientID%>").selectedIndex;
    var status=document.getElementById("<%=ddl_ReasonAddNotConf.ClientID%>").options[statusindex].text;
    var txtResultofCalling=document.getElementById("<%=txtResultofCalling.ClientID%>");              
    var txtWhomaddBelong=document.getElementById("<%=txtWhomaddBelong.ClientID%>");
    var lblResultofCalling=document.getElementById("<%=lblResultofCalling.ClientID%>");
    var lblToWhomdoestheaddressbelong=document.getElementById("<%=lblToWhomdoestheaddressbelong.ClientID%>");
    var ddlTPC1_Name=document.getElementById("<%=ddlTPC1_Name.ClientID%>");    
    var ddlTPC2_Name=document.getElementById("<%=ddlTPC2_Name.ClientID%>"); 
    var ddlVerification_conductedAt=document.getElementById("<%=ddlVerification_conductedAt.ClientID%>");
    var Panel1=document.getElementById("<%=Panel1.ClientID%>"); 
    var Hdn_OccupationType=document.getElementById("<%=Hdn_OccupationType.ClientID%>");    
               if (status=="Mismatch in address")
                     {   
                       
                      txtResultofCalling.style.visibility="hidden";                       
                      txtWhomaddBelong.style.visibility="visible"; 
                      lblToWhomdoestheaddressbelong.style.visibility="visible";
                      lblResultofCalling.style.visibility="hidden";     
                               
                                ddlTPC1_Name.selectedIndex=1;
                                ddlTPC1_Name.disabled=true;
                                ddlTPC2_Name.selectedIndex=1;
                                ddlTPC2_Name.disabled=true;
                                TPC_Not_Confirmed();
                                TPC2_Not_Confirmed();
                                if (Panel1!=null)
                                {
                                 Panel1.style.visibility="hidden";   
                                }
                     }
                     else if (status=="Untraceable")
                     {
                       txtWhomaddBelong.style.visibility="hidden"; 
                       txtResultofCalling.style.visibility="visible"; 
                       lblToWhomdoestheaddressbelong.style.visibility="hidden";
                       lblResultofCalling.style.visibility="visible";   
                       ddlVerification_conductedAt.disabled=true;  
                       ddlVerification_conductedAt.selectedIndex=0;                                      
                         if (Panel1!=null)
                                {
                         Panel1.style.visibility="visible";
                         }
                                ddlTPC1_Name.selectedIndex=2;
                                ddlTPC1_Name.disabled=true;
                                ddlTPC2_Name.selectedIndex=2;
                                ddlTPC2_Name.disabled=true;
                                TPC_Not_Confirmed();
                                TPC2_Not_Confirmed();
                           
                       
                     }
                     else
                     {
                         ddlTPC1_Name.selectedIndex=0;
                         ddlTPC1_Name.disabled=false;
                         ddlTPC2_Name.selectedIndex=0;
                         ddlTPC2_Name.disabled=false;
                       txtWhomaddBelong.style.visibility="hidden"; 
                       txtResultofCalling.style.visibility="hidden";   
                       lblToWhomdoestheaddressbelong.style.visibility="hidden";
                       lblResultofCalling.style.visibility="hidden";   
                       ddlVerification_conductedAt.disabled=false;   
                        if (Panel1!=null)
                        {
                        Panel1.style.visibility="visible";                                
                        }
                     
                     }
                  
                     
       }
      
      function Entry_Permitted()
      {
       
        var statusindex=document.getElementById("<%=ddlEntryPermitted.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlEntryPermitted.ClientID%>").options[statusindex].text;
        var ddlActivitySeen=document.getElementById("<%=ddlActivitySeen.ClientID%>");              
        var ddlStockSeen=document.getElementById("<%=ddlStockSeen.ClientID%>");
        var ddlOfficesetupseen=document.getElementById("<%=ddlOfficesetupseen.ClientID%>");
        var ddl_OfficeStatus=document.getElementById("<%=ddl_OfficeStatus.ClientID%>");
                   if ((status=="Door Locked")||(status=="No"))
                   {
                      ddlActivitySeen.disabled=true;
                      ddlStockSeen.disabled=true;
                      ddlOfficesetupseen.disabled=true;
                      ddl_OfficeStatus.disabled=true;
                      
                      ddlActivitySeen.selectedIndex=0;
                      ddlStockSeen.selectedIndex=0;
                      ddlOfficesetupseen.selectedIndex=0;
                      ddl_OfficeStatus.selectedIndex=0;
                      
                      
                   }
                   else
                   {
                      ddlActivitySeen.disabled=false;
                      ddlStockSeen.disabled=false;
                      ddlOfficesetupseen.disabled=false;
                      ddl_OfficeStatus.disabled=false;
                   }
                   
        
      }
       
       function Name_of_person_met()
       {
           
            var statusIndex=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").options[statusIndex].text;
            var txtNameOfPersonMet=document.getElementById("<%=txtNameOfPersonMet.ClientID%>");
            var txtDesignationofPerMet=document.getElementById("<%=txtDesignationofPerMet.ClientID%>");
            var ddlInformationProvided=document.getElementById("<%=ddlInformationProvided.ClientID%>");
            var ddlrelationwithapplicant=document.getElementById("<%=ddlrelationwithapplicant.ClientID%>");
            var txtrelationwithapplicant=document.getElementById("<%=txtrelationwithapplicant.ClientID%>");             
            var ddldesignationofApplicant=document.getElementById("<%=ddldesignationofApplicant.ClientID%>");
            var txtdesignationofapplicant=document.getElementById("<%=txtdesignationofapplicant.ClientID%>");
            var ddldepartmentofApplicant=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>");
            var txtDepartment=document.getElementById("<%=txtDepartment.ClientID%>");    
            var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
            var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            var ddlCompanyName=document.getElementById("<%=ddlCompanyName.ClientID%>");    
            var txtNameofBusiness=document.getElementById("<%=txtNameofBusiness.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
            var ddlTypeofCompany=document.getElementById("<%=ddlTypeofCompany.ClientID%>");
            var ddlNature_of_Business=document.getElementById("<%=ddlNature_of_Business.ClientID%>");
            var txtBusinessDescription=document.getElementById("<%=txtBusinessDescription.ClientID%>");
            var txtTelephoneNo=document.getElementById("<%=txtTelephoneNo.ClientID%>");    
            var txtExtension=document.getElementById("<%=txtExtension.ClientID%>");
            var txtNoofExistenceYear=document.getElementById("<%=txtNoofExistenceYear.ClientID%>");
            var txtNoOfExistenceMonth=document.getElementById("<%=txtNoOfExistenceMonth.ClientID%>");
            var txtResidence=document.getElementById("<%=txtResidence.ClientID%>");
            var txtEmailId=document.getElementById("<%=txtEmailId.ClientID%>");
            var ddlTypeOfProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>");
            var ddlAppFullTimeEmployee=document.getElementById("<%=ddlAppFullTimeEmployee.ClientID%>");
            var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
            var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
            var chk_Exit_Company=document.getElementById("<%=chk_Exit_Company.ClientID%>");
            var ddlApplicantConfirmedwith=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>");
            var Img1=document.getElementById("Img1");
            value=false;
            if(status=="NotPossible")
             { 
                      
                     value=true;
                     Img1.style.visibility="hidden";
                     txtNameOfPersonMet.disabled=value;
                     txtDesignationofPerMet.disabled=value;
                     ddlInformationProvided.disabled=value;
                     ddlrelationwithapplicant.disabled=value;
                     txtrelationwithapplicant.disabled=value;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value;
                     ddlApplicantConfirmedwith.disabled=value;
                     ddlAppFullTimeEmployee.disabled=value;
                     ddlTypeOfProof.disabled=value;
            
                     txtNameOfPersonMet.value="";
                     txtDesignationofPerMet.value="";
                     ddlInformationProvided.value="";
                     ddlrelationwithapplicant.value="";
                     txtrelationwithapplicant.value="";
                     ddldesignationofApplicant.value="";
                     txtdesignationofapplicant.value="";
                     ddldepartmentofApplicant.value="";
                     txtDepartment.value="";
                     txtYearinEmployment.value="";
                     txtMonth.value="";
                     txtApplicantAge_DOB.value="";
                     txtApplicantAge_DOB_YY.value="";
                     txtApplicantAge_DOB_MM.value="";
                     ddlCompanyName.value="";
                     txtNameofBusiness.value="";
                     txtEmployerAddress.value="";
                     ddlTypeofCompany.value="";
                     ddlNature_of_Business.value="";
                     txtBusinessDescription.value="";
                     txtTelephoneNo.value="";
                     txtExtension.value="";
                     txtNoofExistenceYear.value="";
                     txtNoOfExistenceMonth.value="";
                     txtResidence.value="";
                     txtEmailId.value="";
                     chk_YCE.value="";
                     chkApplicant_DOBAGE_NotConf.value="";
                     chk_Exit_Company.value="";
                     ddlApplicantConfirmedwith.value="";
                     ddlAppFullTimeEmployee="";
                     ddlTypeOfProof.value="";
               
                     txtNameOfPersonMet.selectedIndex=0;
                     txtDesignationofPerMet.selectedIndex=0;
                     ddlInformationProvided.selectedIndex=0;
                     ddlrelationwithapplicant.selectedIndex=0;
                     txtrelationwithapplicant.selectedIndex=0;
                     ddldesignationofApplicant.selectedIndex=0;
                     txtdesignationofapplicant.selectedIndex=0;
                     ddldepartmentofApplicant.selectedIndex=0;
                     txtDepartment.selectedIndex=0;
                     txtYearinEmployment.selectedIndex=0;
                     txtMonth.selectedIndex=0;
                     txtApplicantAge_DOB.selectedIndex=0;
                     txtApplicantAge_DOB_YY.selectedIndex=0;
                     txtApplicantAge_DOB_MM.selectedIndex=0;
                     ddlCompanyName.selectedIndex=0;
                     txtNameofBusiness.selectedIndex=0;
                     txtEmployerAddress.selectedIndex=0;
                     ddlTypeofCompany.selectedIndex=0;
                     ddlNature_of_Business.selectedIndex=0;
                     txtBusinessDescription.selectedIndex=0;
                     txtTelephoneNo.selectedIndex=0;
                     txtExtension.selectedIndex=0;
                     txtNoofExistenceYear.selectedIndex=0;
                     txtNoOfExistenceMonth.selectedIndex=0;
                     txtResidence.selectedIndex=0;
                     txtEmailId.selectedIndex=0;
                     chk_YCE.selectedIndex=0;
                     chkApplicant_DOBAGE_NotConf.selectedIndex=0;
                     chk_Exit_Company.selectedIndex=0;
                     ddlApplicantConfirmedwith.selectedIndex=0;
                     ddlAppFullTimeEmployee.selectedIndex=0;
                     ddlTypeOfProof.selectedIndex=0;
              }
            else if(status=="NotConfirmed")
            {        
                     value=false;
                     Img1.style.visibility="visible";
                     txtNameOfPersonMet.disabled=true;
                     txtDesignationofPerMet.disabled=value;
                     ddlInformationProvided.disabled=value;
                     ddlrelationwithapplicant.disabled=value;
                     txtrelationwithapplicant.disabled=value;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value;
                     ddlApplicantConfirmedwith.disabled=value;
                     ddlAppFullTimeEmployee.disabled=value;
                     ddlTypeOfProof.disabled=value;
            }
            else if(status=="NameConfirmed")
            {
                     value=false;
                     Img1.style.visibility="visible";
                     txtNameOfPersonMet.disabled=value;
                     txtDesignationofPerMet.disabled=value;
                     ddlInformationProvided.disabled=value;
                     ddlrelationwithapplicant.disabled=value;
                     txtrelationwithapplicant.disabled=value;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value;
                     ddlApplicantConfirmedwith.disabled=value;
                     ddlAppFullTimeEmployee.disabled=value;
                     ddlTypeOfProof.disabled=value;
            }
            else if(status=='Applicant')
            {   //debugger
                value=true;
                txtNameOfPersonMet.disabled=value;
                txtNameOfPersonMet.value="";
                txtDesignationofPerMet.disabled=value;
                txtDesignationofPerMet.value="";
                ddldesignationofApplicant.disabled=value;
                ddldesignationofApplicant.selectedIndex=1;
                txtdesignationofapplicant.disabled=value;
                txtdesignationofapplicant.value="";
                ddlrelationwithapplicant.disabled=value;
                ddlrelationwithapplicant.selectedIndex=0;
                txtrelationwithapplicant.disabled=value; 
                txtrelationwithapplicant.value="";
              
            }
               
                    
       }
       
     function TPC_Not_Confirmed()
     {
       
         var statusIndex=document.getElementById("<%=ddlTPC1_Name.ClientID%>").selectedIndex;
         var status=document.getElementById("<%=ddlTPC1_Name.ClientID%>").options[statusIndex].text;
         var ddlTPC1_ByWHOM=document.getElementById("<%=ddlTPC1_ByWHOM.ClientID%>");
         var txtTPC1_Address=document.getElementById("<%=txtTPC1_Address.ClientID%>");
         var ddlTcpApplicantName=document.getElementById("<%=ddlTcpApplicantName.ClientID%>");
         var txtTPC1_AgeYear=document.getElementById("<%=txtTPC1_AgeYear.ClientID%>");
         var txtTPC1_AgeMonth=document.getElementById("<%=txtTPC1_AgeMonth.ClientID%>");
         var ddlTPC1_Employment=document.getElementById("<%=ddlTPC1_Employment.ClientID%>");
         var txtTPC1_designationOfApp=document.getElementById("<%=txtTPC1_designationOfApp.ClientID%>");
         var txtTPC1_ApplicantName=document.getElementById("<%=txtTPC1_ApplicantName.ClientID%>");
         var ddlTPC1_DesignofApplicant=document.getElementById("<%=ddlTPC1_DesignofApplicant.ClientID%>");
         var txtTPC1_Year=document.getElementById("<%=txtTPC1_Year.ClientID%>");
         var txtTPC1_Month=document.getElementById("<%=txtTPC1_Month.ClientID%>");
         var ddl_TCP_TypeofCompany=document.getElementById("<%=ddl_TCP_TypeofCompany.ClientID%>");
         var ddl_TCP_NatureOfBusiness=document.getElementById("<%=ddl_TCP_NatureOfBusiness.ClientID%>");
         var txtTPC1_Name=document.getElementById("<%=txtTPC1_Name.ClientID%>");
         var chk_TPC1AppYCE=document.getElementById("<%=chk_TPC1AppYCE.ClientID%>");
         var chk_TPC1_age=document.getElementById("<%=chk_TPC1_age.ClientID%>");
         
         if(status=="NotPossible")
         { 
                ddlTPC1_ByWHOM.disabled=true;
                txtTPC1_Address.disabled=true;
                ddlTcpApplicantName.disabled=true;
                txtTPC1_ApplicantName.disabled=true;
                txtTPC1_AgeYear.disabled=true;
                txtTPC1_AgeMonth.disabled=true;
                ddlTPC1_Employment.disabled=true;
                txtTPC1_designationOfApp.disabled=true;
                ddlTPC1_DesignofApplicant.disabled=true;
                txtTPC1_Year.disabled=true;
                txtTPC1_Month.disabled=true;
                ddl_TCP_TypeofCompany.disabled=true;
                ddl_TCP_NatureOfBusiness.disabled=true;
                txtTPC1_Name.disabled=true;
                chk_TPC1AppYCE.disabled=true;
                chk_TPC1_age.disabled=true;
                
            ddlTPC1_ByWHOM.value="";
            txtTPC1_Address.value="";
            ddlTcpApplicantName.value="";
            txtTPC1_ApplicantName.value="";
            txtTPC1_AgeYear.value="";
            txtTPC1_AgeMonth.value="";
            ddlTPC1_Employment.value="";
            txtTPC1_designationOfApp.value="";
            ddlTPC1_DesignofApplicant.value="";
            txtTPC1_Year.value="";
            txtTPC1_Month.value="";
            ddl_TCP_TypeofCompany.value="";
            ddl_TCP_NatureOfBusiness.value="";
            txtTPC1_Name.value="";
            chk_TPC1AppYCE.value="";
            chk_TPC1_age.value="";
         
            ddlTPC1_ByWHOM.selectedIndex=0;
            txtTPC1_Address.selectedIndex=0;
            ddlTcpApplicantName.selectedIndex=0;
            txtTPC1_ApplicantName.selectedIndex=0;
            txtTPC1_AgeYear.selectedIndex=0;
            txtTPC1_AgeMonth.selectedIndex=0;
            ddlTPC1_Employment.selectedIndex=0;
            txtTPC1_designationOfApp.selectedIndex=0;
            ddlTPC1_DesignofApplicant.selectedIndex=0;
            txtTPC1_Year.selectedIndex=0;
            txtTPC1_Month.selectedIndex=0;
            chk_TPC1AppYCE.selectedIndex=0;
            ddl_TCP_TypeofCompany.selectedIndex=0;
            ddl_TCP_NatureOfBusiness.selectedIndex=0;
            txtTPC1_Name.selectedIndex=0;
            chk_TPC1_age.selectedIndex=0;
            
          }
         else if(status=="Name")
         {
         
            ddlTPC1_ByWHOM.disabled=false;
            txtTPC1_Address.disabled=false;
            ddlTcpApplicantName.disabled=false;
            txtTPC1_AgeYear.disabled=false;
            txtTPC1_AgeMonth.disabled=false;
            ddlTPC1_Employment.disabled=false;
            txtTPC1_designationOfApp.disabled=false;
            ddlTPC1_DesignofApplicant.disabled=false;
            txtTPC1_Year.disabled=false;
            txtTPC1_Month.disabled=false;
            ddl_TCP_TypeofCompany.disabled=false;
            ddl_TCP_NatureOfBusiness.disabled=false;
            txtTPC1_Name.disabled=false;
            chk_TPC1AppYCE.disabled=false;
            chk_TPC1_age.disabled=false;
            
         }
           else if(status=="NotProvided")
            {   
                ddlTPC1_ByWHOM.disabled=false;
                txtTPC1_Address.disabled=false;
                ddlTcpApplicantName.disabled=false;
                txtTPC1_ApplicantName.disabled=false;
                txtTPC1_AgeYear.disabled=false;
                txtTPC1_AgeMonth.disabled=false;
                ddlTPC1_Employment.disabled=false;
                txtTPC1_designationOfApp.disabled=false;
                ddlTPC1_DesignofApplicant.disabled=false;
                txtTPC1_Year.disabled=false;
                txtTPC1_Month.disabled=false;
                ddl_TCP_TypeofCompany.disabled=false;
                ddl_TCP_NatureOfBusiness.disabled=false;
                chk_TPC1AppYCE.disabled=false;
                chk_TPC1_age.disabled=false;
                txtTPC1_Name.disabled=true;
                
         
          }  
      }
       
   function TPC2_Not_Confirmed()
     {
       
         var statusIndex=document.getElementById("<%=ddlTPC2_Name.ClientID%>").selectedIndex;
         var status=document.getElementById("<%=ddlTPC2_Name.ClientID%>").options[statusIndex].text;
         var ddlTPC2_ByWhom=document.getElementById("<%=ddlTPC2_ByWhom.ClientID%>");
         var txtTPC2_Address=document.getElementById("<%=txtTPC2_Address.ClientID%>");
         var ddlTPC2_AppName=document.getElementById("<%=ddlTPC2_AppName.ClientID%>");
         var txtTPC2_AppName=document.getElementById("<%=txtTPC2_AppName.ClientID%>");
         var txtTPC2_AgeYear=document.getElementById("<%=txtTPC2_AgeYear.ClientID%>");
         var txtTPC2_AgeMonth=document.getElementById("<%=txtTPC2_AgeMonth.ClientID%>");
         var ddlTPC2_employment=document.getElementById("<%=ddlTPC2_employment.ClientID%>");
         var ddl_TPC2Desig_App=document.getElementById("<%=ddl_TPC2Desig_App.ClientID%>");
         var txtTPC2_dsigApp=document.getElementById("<%=txtTPC2_dsigApp.ClientID%>");
         var txtTPC2_YCEYear=document.getElementById("<%=txtTPC2_YCEYear.ClientID%>");
         var txtTPC2_Month=document.getElementById("<%=txtTPC2_Month.ClientID%>");
         var ddlTPC2_typeofComp=document.getElementById("<%=ddlTPC2_typeofComp.ClientID%>");
         var ddlTPC2_NatureofBusi=document.getElementById("<%=ddlTPC2_NatureofBusi.ClientID%>");
         var txtTPC2_Name=document.getElementById("<%=txtTPC2_Name.ClientID%>");
         var chk_TPC2_YCE=document.getElementById("<%=chk_TPC2_YCE.ClientID%>");
         var chkTPC2_age=document.getElementById("<%=chkTPC2_age.ClientID%>");
         
         if(status=="NotPossible")
         { 
                ddlTPC2_ByWhom.disabled=true;
                txtTPC2_Address.disabled=true;
                ddlTPC2_AppName.disabled=true;
                txtTPC2_AppName.disabled=true;
                txtTPC2_AgeYear.disabled=true;
                txtTPC2_AgeMonth.disabled=true;
                ddlTPC2_employment.disabled=true;
                ddl_TPC2Desig_App.disabled=true;
                txtTPC2_dsigApp.disabled=true;
                txtTPC2_YCEYear.disabled=true;
                txtTPC2_Month.disabled=true;
                ddlTPC2_typeofComp.disabled=true;
                ddlTPC2_NatureofBusi.disabled=true;
                txtTPC2_Name.disabled=true;
                chk_TPC2_YCE.disabled=true;
                chkTPC2_age.disabled=true;
           
                ddlTPC2_ByWhom.value="";
                txtTPC2_Address.value="";
                ddlTPC2_AppName.value="";
                txtTPC2_AppName.value="";
                txtTPC2_AgeYear.value="";
                txtTPC2_AgeMonth.value="";
                ddlTPC2_employment.value="";
                ddl_TPC2Desig_App.value="";
                txtTPC2_dsigApp.value="";
                txtTPC2_YCEYear.value="";
                txtTPC2_Month.value="";
                ddlTPC2_typeofComp.value="";
                ddlTPC2_NatureofBusi.value="";
                txtTPC2_Name.value="";
                chk_TPC2_YCE.value="";
                chkTPC2_age.value="";
          
                ddlTPC2_ByWhom.selectedIndex=0;
                txtTPC2_Address.selectedIndex=0;
                ddlTPC2_AppName.selectedIndex=0;
                txtTPC2_AppName.selectedIndex=0;
                txtTPC2_AgeYear.selectedIndex=0;
                txtTPC2_AgeMonth.selectedIndex=0;
                ddlTPC2_employment.selectedIndex=0;
                ddl_TPC2Desig_App.selectedIndex=0;
                txtTPC2_dsigApp.selectedIndex=0;
                txtTPC2_YCEYear.selectedIndex=0;
                txtTPC2_Month.selectedIndex=0;
                ddlTPC2_typeofComp.selectedIndex=0;
                ddlTPC2_NatureofBusi.selectedIndex=0;
                txtTPC2_Name.selectedIndex=0;
                chk_TPC2_YCE.selectedIndex=0;
                chkTPC2_age.selectedIndex=0;
          }
         else if(status=="Name")
         {
                ddlTPC2_ByWhom.disabled=false;
                txtTPC2_Address.disabled=false;
                ddlTPC2_AppName.disabled=false;
                txtTPC2_AppName.disabled=false;
                txtTPC2_AgeYear.disabled=false;
                txtTPC2_AgeMonth.disabled=false;
                ddlTPC2_employment.disabled=false;
                ddl_TPC2Desig_App.disabled=false;
                txtTPC2_dsigApp.disabled=false;
                txtTPC2_YCEYear.disabled=false;
                txtTPC2_Month.disabled=false;
                ddlTPC2_typeofComp.disabled=false;
                ddlTPC2_NatureofBusi.disabled=false;
                txtTPC2_Name.disabled=false;
                chk_TPC2_YCE.disabled=false;
                chkTPC2_age.disabled=false;
         }
           else if(status=="NotProvided")
            {   
                ddlTPC2_ByWhom.disabled=false;
                txtTPC2_Address.disabled=false;
                ddlTPC2_AppName.disabled=false;
                txtTPC2_AppName.disabled=false;
                txtTPC2_AgeYear.disabled=false;
                txtTPC2_AgeMonth.disabled=false;
                ddlTPC2_employment.disabled=false;
                ddl_TPC2Desig_App.disabled=false;
                txtTPC2_dsigApp.disabled=false;
                txtTPC2_YCEYear.disabled=false;
                txtTPC2_Month.disabled=false;
                ddlTPC2_typeofComp.disabled=false;
                ddlTPC2_NatureofBusi.disabled=false;
                chk_TPC2_YCE.disabled=false;
                chkTPC2_age.disabled=false;
                txtTPC2_Name.disabled=true;
           }
             
     }
     
 function Enable_validation_on_TPC_ApplicantName()
   {  
       var statusIndex=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").selectedIndex;
       var status=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").options[statusIndex].text;
       var txtTPC1_ApplicantName=document.getElementById("<%=txtTPC1_ApplicantName.ClientID%>");    
       var ddlTPC1_DesignofApplicant=document.getElementById("<%=ddlTPC1_DesignofApplicant.ClientID%>");
       var txtTPC1_designationOfApp=document.getElementById("<%=txtTPC1_designationOfApp.ClientID%>");
       
       if(status=="No Such Person")
       {  
        
          txtTPC1_ApplicantName.disabled=true;
          ddlTPC1_DesignofApplicant.disabled=true;
          txtTPC1_designationOfApp.disabled=true;
          
          txtTPC1_ApplicantName.value="";
          ddlTPC1_DesignofApplicant.value="";
          txtTPC1_designationOfApp.value="";
          
          txtTPC1_ApplicantName.selectedIndex=0;
          ddlTPC1_DesignofApplicant.selectedIndex=0;
          txtTPC1_designationOfApp.selectedIndex=0;
       }
       if(status=="Not Confirmed")
       {
         txtTPC1_ApplicantName.disabled=true;
          ddlTPC1_DesignofApplicant.disabled=false;
          txtTPC1_designationOfApp.disabled=false;
       }
       else if(status=="Confirmed")
       {
          txtTPC1_ApplicantName.disabled=false;
          ddlTPC1_DesignofApplicant.disabled=false;
          txtTPC1_designationOfApp.disabled=false;
          
       }
   }    
   
  function Enable_validation_on_TPC_ApplicantName_ForSalaried()
   {
       var statusIndex=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").selectedIndex;
       var status=document.getElementById("<%=ddlTcpApplicantName.ClientID%>").options[statusIndex].text;
       var txtTPC1_ApplicantName=document.getElementById("<%=txtTPC1_ApplicantName.ClientID%>");    
       var chk_TPC1_age=document.getElementById("<%=chk_TPC1_age.ClientID%>");    
       var txtTPC1_AgeYear=document.getElementById("<%=txtTPC1_AgeYear.ClientID%>");
       var txtTPC1_AgeMonth=document.getElementById("<%=txtTPC1_AgeMonth.ClientID%>");
       var ddlTPC1_Employment=document.getElementById("<%=ddlTPC1_Employment.ClientID%>");    
       var ddlTPC1_DesignofApplicant=document.getElementById("<%=ddlTPC1_DesignofApplicant.ClientID%>");
       var txtTPC1_designationOfApp=document.getElementById("<%=txtTPC1_designationOfApp.ClientID%>");
       var chk_TPC1AppYCE=document.getElementById("<%=chk_TPC1AppYCE.ClientID%>");
       var txtTPC1_Year=document.getElementById("<%=txtTPC1_Year.ClientID%>");
       var txtTPC1_Month=document.getElementById("<%=txtTPC1_Month.ClientID%>");
       var ddl_TCP_TypeofCompany=document.getElementById("<%=ddl_TCP_TypeofCompany.ClientID%>");
       var ddl_TCP_NatureOfBusiness=document.getElementById("<%=ddl_TCP_NatureOfBusiness.ClientID%>");
      if((status=="No Such Person")||(status=="Not Confirmed"))
       {  
                txtTPC1_ApplicantName.disabled=true;
                txtTPC1_AgeYear.disabled=true;
                txtTPC1_AgeMonth.disabled=true;
                ddlTPC1_Employment.disabled=true;
                txtTPC1_designationOfApp.disabled=true;
                ddlTPC1_DesignofApplicant.disabled=true;
                txtTPC1_Year.disabled=true;
                txtTPC1_Month.disabled=true;
                ddl_TCP_TypeofCompany.disabled=true;
                ddl_TCP_NatureOfBusiness.disabled=true;
                chk_TPC1AppYCE.disabled=true;
                chk_TPC1_age.disabled=true;
          
            txtTPC1_ApplicantName.value="";
            txtTPC1_AgeYear.value="";
            txtTPC1_AgeMonth.value="";
            ddlTPC1_Employment.value="";
            txtTPC1_designationOfApp.value="";
            ddlTPC1_DesignofApplicant.value="";
            txtTPC1_Year.value="";
            txtTPC1_Month.value="";
            ddl_TCP_TypeofCompany.value="";
            ddl_TCP_NatureOfBusiness.value="";
            chk_TPC1AppYCE.value="";
            chk_TPC1_age.value="";
          
            txtTPC1_ApplicantName.selectedIndex=0;
            txtTPC1_AgeYear.selectedIndex=0;
            txtTPC1_AgeMonth.selectedIndex=0;
            ddlTPC1_Employment.selectedIndex=0;
            txtTPC1_designationOfApp.selectedIndex=0;
            ddlTPC1_DesignofApplicant.selectedIndex=0;
            txtTPC1_Year.selectedIndex=0;
            txtTPC1_Month.selectedIndex=0;
            chk_TPC1AppYCE.selectedIndex=0;
            ddl_TCP_TypeofCompany.selectedIndex=0;
            ddl_TCP_NatureOfBusiness.selectedIndex=0;
            chk_TPC1_age.selectedIndex=0;
       }
       else if(status=="Confirmed")
       {    
                txtTPC1_ApplicantName.disabled=false;
                txtTPC1_AgeYear.disabled=false;
                txtTPC1_AgeMonth.disabled=false;
                ddlTPC1_Employment.disabled=false;
                txtTPC1_designationOfApp.disabled=false;
                ddlTPC1_DesignofApplicant.disabled=false;
                txtTPC1_Year.disabled=false;
                txtTPC1_Month.disabled=false;
                ddl_TCP_TypeofCompany.disabled=false;
                ddl_TCP_NatureOfBusiness.disabled=false;
                chk_TPC1AppYCE.disabled=false;
                chk_TPC1_age.disabled=false;
       }
   }    
     
  function Enable_validation_on_TPC2_ApplicantName_ForSalaried()   
  {
         var statusIndex=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").selectedIndex;
         var status=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").options[statusIndex].text;
         var txtTPC2_AppName=document.getElementById("<%=txtTPC2_AppName.ClientID%>");
         var txtTPC2_AgeYear=document.getElementById("<%=txtTPC2_AgeYear.ClientID%>");
         var txtTPC2_AgeMonth=document.getElementById("<%=txtTPC2_AgeMonth.ClientID%>");
         var ddlTPC2_employment=document.getElementById("<%=ddlTPC2_employment.ClientID%>");
         var ddl_TPC2Desig_App=document.getElementById("<%=ddl_TPC2Desig_App.ClientID%>");
         var txtTPC2_dsigApp=document.getElementById("<%=txtTPC2_dsigApp.ClientID%>");
         var txtTPC2_YCEYear=document.getElementById("<%=txtTPC2_YCEYear.ClientID%>");
         var txtTPC2_Month=document.getElementById("<%=txtTPC2_Month.ClientID%>");
         var ddlTPC2_typeofComp=document.getElementById("<%=ddlTPC2_typeofComp.ClientID%>");
         var ddlTPC2_NatureofBusi=document.getElementById("<%=ddlTPC2_NatureofBusi.ClientID%>");
         var txtTPC2_Name=document.getElementById("<%=txtTPC2_Name.ClientID%>");
         var chk_TPC2_YCE=document.getElementById("<%=chk_TPC2_YCE.ClientID%>");
         var chkTPC2_age=document.getElementById("<%=chkTPC2_age.ClientID%>");
         
         if((status=="No Such Person")||(status=="Not Confirmed"))
         {
                txtTPC2_AppName.disabled=true;
                txtTPC2_AgeYear.disabled=true;
                txtTPC2_AgeMonth.disabled=true;
                ddlTPC2_employment.disabled=true;
                ddl_TPC2Desig_App.disabled=true;
                txtTPC2_dsigApp.disabled=true;
                txtTPC2_YCEYear.disabled=true;
                txtTPC2_Month.disabled=true;
                ddlTPC2_typeofComp.disabled=true;
                ddlTPC2_NatureofBusi.disabled=true;
                chk_TPC2_YCE.disabled=true;
                chkTPC2_age.disabled=true;
                
                 txtTPC2_AppName.value="";
                txtTPC2_AgeYear.value="";
                txtTPC2_AgeMonth.value="";
                ddlTPC2_employment.value="";
                ddl_TPC2Desig_App.value="";
                txtTPC2_dsigApp.value="";
                txtTPC2_YCEYear.value="";
                txtTPC2_Month.value="";
                ddlTPC2_typeofComp.value="";
                ddlTPC2_NatureofBusi.value="";
                chk_TPC2_YCE.value="";
                chkTPC2_age.value="";
          
                txtTPC2_AppName.selectedIndex=0;
                txtTPC2_AgeYear.selectedIndex=0;
                txtTPC2_AgeMonth.selectedIndex=0;
                ddlTPC2_employment.selectedIndex=0;
                ddl_TPC2Desig_App.selectedIndex=0;
                txtTPC2_dsigApp.selectedIndex=0;
                txtTPC2_YCEYear.selectedIndex=0;
                txtTPC2_Month.selectedIndex=0;
                ddlTPC2_typeofComp.selectedIndex=0;
                ddlTPC2_NatureofBusi.selectedIndex=0;
                chk_TPC2_YCE.selectedIndex=0;
                chkTPC2_age.selectedIndex=0;

         }
        else if(status=="Confirmed")
         {
            txtTPC2_AppName.disabled=false;
                txtTPC2_AgeYear.disabled=false;
                txtTPC2_AgeMonth.disabled=false;
                ddlTPC2_employment.disabled=false;
                ddl_TPC2Desig_App.disabled=false;
                txtTPC2_dsigApp.disabled=false;
                txtTPC2_YCEYear.disabled=false;
                txtTPC2_Month.disabled=false;
                ddlTPC2_typeofComp.disabled=false;
                ddlTPC2_NatureofBusi.disabled=false;
                chk_TPC2_YCE.disabled=false;
                chkTPC2_age.disabled=false;
         }
    
  }
     
 function Enable_validation_on_TPC2_ApplicantName()
   {
       var statusIndex=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").selectedIndex;
       var status=document.getElementById("<%=ddlTPC2_AppName.ClientID%>").options[statusIndex].text;
       var txtTPC2_AppName=document.getElementById("<%=txtTPC2_AppName.ClientID%>");    
       var ddl_TPC2Desig_App=document.getElementById("<%=ddl_TPC2Desig_App.ClientID%>");
       var txtTPC2_dsigApp=document.getElementById("<%=txtTPC2_dsigApp.ClientID%>");
       if(status=="No Such Person")
       {  
          txtTPC2_AppName.disabled=true;
          ddl_TPC2Desig_App.disabled=true;
          txtTPC2_dsigApp.disabled=true;
          
          txtTPC2_AppName.value="";
          ddl_TPC2Desig_App.value="";
          txtTPC2_dsigApp.value="";
          
           txtTPC2_AppName.selectedIndex=0;
           ddl_TPC2Desig_App.selectedIndex=0;
           txtTPC2_dsigApp.selectedIndex=0;
       }
       if(status=="Not Confirmed")
       {
          txtTPC2_AppName.disabled=true;
          ddl_TPC2Desig_App.disabled=false;
          txtTPC2_dsigApp.disabled=false;
       }
       else if(status=="Confirmed")
       {
          txtTPC2_AppName.disabled=false;
          ddl_TPC2Desig_App.disabled=false;
          txtTPC2_dsigApp.disabled=false;
        
       }
   }

 function Enable_Validation_On_AddressUpdation()
    {
          var statusIndex=document.getElementById("<%=ddlAddressUpdation.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlAddressUpdation.ClientID%>").options[statusIndex].text;
          var txtCorrectAddress=document.getElementById("<%=txtCorrectAddress.ClientID%>");    
          var value=false;
                if (status=="No")
                {
                     value=true;  
                     txtCorrectAddress.value="";      
                     
                }
                 
               txtCorrectAddress.disabled=value;
               
   }
   
   function Enabled_validation_ApplicantName()
    { 
            var statusindex=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlApplicantConfirmedwith.ClientID%>").options[statusindex].text;
            var ddldesignationofApplicant=document.getElementById("<%=ddldesignationofApplicant.ClientID%>");
            var txtdesignationofapplicant=document.getElementById("<%=txtdesignationofapplicant.ClientID%>");
            var ddldepartmentofApplicant=document.getElementById("<%=ddldepartmentofApplicant.ClientID%>");
            var txtDepartment=document.getElementById("<%=txtDepartment.ClientID%>");              
            var txtYearinEmployment=document.getElementById("<%=txtYearinEmployment.ClientID%>");
            var txtMonth=document.getElementById("<%=txtMonth.ClientID%>");
            var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
            var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
            var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");
            var ddlCompanyName=document.getElementById("<%=ddlCompanyName.ClientID%>");    
            var txtNameofBusiness=document.getElementById("<%=txtNameofBusiness.ClientID%>");
            var txtEmployerAddress=document.getElementById("<%=txtEmployerAddress.ClientID%>");
            var ddlTypeofCompany=document.getElementById("<%=ddlTypeofCompany.ClientID%>");
            var ddlNature_of_Business=document.getElementById("<%=ddlNature_of_Business.ClientID%>");
            var txtBusinessDescription=document.getElementById("<%=txtBusinessDescription.ClientID%>");
            var txtTelephoneNo=document.getElementById("<%=txtTelephoneNo.ClientID%>");    
            var txtExtension=document.getElementById("<%=txtExtension.ClientID%>");
            var txtNoofExistenceYear=document.getElementById("<%=txtNoofExistenceYear.ClientID%>");
            var txtNoOfExistenceMonth=document.getElementById("<%=txtNoOfExistenceMonth.ClientID%>");
            var txtResidence=document.getElementById("<%=txtResidence.ClientID%>");
            var txtEmailId=document.getElementById("<%=txtEmailId.ClientID%>");
            var Img1=document.getElementById("Img1");
            var ddlTypeOfProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>");
            var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
            var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
            var chk_Exit_Company=document.getElementById("<%=chk_Exit_Company.ClientID%>");
            var ddlAppFullTimeEmployee=document.getElementById("<%=ddlAppFullTimeEmployee.ClientID%>");
            var Img1=document.getElementById("Img1");
            value=false;
            
            if(status=="NoSuchPerson")
            {
              Img1.style.visibility="hidden";
            }
            else
            {
             Img1.style.visibility="visible";
            }
            
           if(status=="NoSuchPerson")
            {
                    value=true;
                     
                     ddldesignationofApplicant.value="";
                     txtdesignationofapplicant.value="";
                    
                     ddldepartmentofApplicant.value="";
                     txtDepartment.value="";
                     txtYearinEmployment.value="";
                     txtMonth.value="";
                     txtApplicantAge_DOB.value="";
                     txtApplicantAge_DOB_YY.value="";
                     txtApplicantAge_DOB_MM.value="";
                     ddlCompanyName.value="";
                     txtNameofBusiness.value="";
                     txtEmployerAddress.value="";
                     ddlTypeofCompany.value="";
                     ddlNature_of_Business.value="";
                     txtBusinessDescription.value="";
                     txtTelephoneNo.value="";
                     txtExtension.value="";
                     txtNoofExistenceYear.value="";
                     txtNoOfExistenceMonth.value="";
                     txtResidence.value="";
                     txtEmailId.value="";
                     chk_YCE.value="";
                     chkApplicant_DOBAGE_NotConf.value="";
                     chk_Exit_Company.value="";  
                     ddlTypeOfProof.value="";
                     ddlAppFullTimeEmployee.value="";
                     //-----
                      ddldesignationofApplicant.selectedIndex=0;
                      txtdesignationofapplicant.selectedIndex=0;
                      ddldepartmentofApplicant.selectedIndex=0;
                     txtDepartment.selectedIndex=0;
                     
                     txtYearinEmployment.selectedIndex=0;
                     txtMonth.selectedIndex=0;
                     
                     txtApplicantAge_DOB.selectedIndex=0;
                     txtApplicantAge_DOB_YY.selectedIndex=0;
                     txtApplicantAge_DOB_MM.selectedIndex=0;
                     
                     ddlCompanyName.selectedIndex=0;
                     txtNameofBusiness.selectedIndex=0;
                     
                     txtEmployerAddress.selectedIndex=0;
                     ddlTypeofCompany.selectedIndex=0;
                     ddlNature_of_Business.selectedIndex=0;
                     txtBusinessDescription.selectedIndex=0;
                     txtTelephoneNo.selectedIndex=0;
                     txtExtension.selectedIndex=0;
                     txtNoofExistenceYear.selectedIndex=0;
                     txtNoOfExistenceMonth.selectedIndex=0;
                     txtResidence.selectedIndex=0;
                     txtEmailId.selectedIndex=0;
                     chk_YCE.selectedIndex=0;
                     chkApplicant_DOBAGE_NotConf.selectedIndex=0;
                     chk_Exit_Company.selectedIndex=0;
                     ddlTypeOfProof.selectedIndex=0;
                     ddlAppFullTimeEmployee.selectedIndex=0;
          
             }
                     Img1.style.disabled=true;
                     ddldesignationofApplicant.disabled=value;
                     txtdesignationofapplicant.disabled=value;
                     ddldepartmentofApplicant.disabled=value;
                     txtDepartment.disabled=value;
                     txtYearinEmployment.disabled=value;
                     txtMonth.disabled=value;
                     txtApplicantAge_DOB.disabled=value;
                     txtApplicantAge_DOB_YY.disabled=value;
                     txtApplicantAge_DOB_MM.disabled=value;
                     ddlCompanyName.disabled=value;
                     txtNameofBusiness.disabled=value;
                     txtEmployerAddress.disabled=value;
                     ddlTypeofCompany.disabled=value;
                     ddlNature_of_Business.disabled=value;
                     txtBusinessDescription.disabled=value;
                     txtTelephoneNo.disabled=value;
                     txtExtension.disabled=value;
                     txtNoofExistenceYear.disabled=value;
                     txtNoOfExistenceMonth.disabled=value;
                     txtResidence.disabled=value;
                     txtEmailId.disabled=value;
                     chk_YCE.disabled=value;
                     chkApplicant_DOBAGE_NotConf.disabled=value;
                     chk_Exit_Company.disabled=value;
                     ddlTypeOfProof.disabled=value;
                     ddlAppFullTimeEmployee.disabled=value;
          
        }
      
       
       function Enabled_Validation_Confirmation(DropDownId,FieldValue,TextFieldId)       
       {
            var DropDownId=document.getElementById(DropDownId);
            var StatusIndex=DropDownId.selectedIndex;
            var Status=DropDownId.options[StatusIndex].text;
            var FieldValue=FieldValue; //document.getElementById(FieldValue);
            var TextFieldId=document.getElementById(TextFieldId);
            var value=true;
            
            if (Status==FieldValue)
            {
                value=false;
                
            }        
            
            if (value==true)
            {
                TextFieldId.value="";
            }
            
            TextFieldId.disabled=value;
        
     }  
</script>
 <asp:Panel ID="PnlView" runat="server" Width="100%" Height="100%">   
    <table border="0" cellspacing="0">
        <tr>
            <td colspan="10" class="TableHeader" style="height: 22px">
                <strong>
                Business Verification-<asp:Label ID="lblType" runat="server" Text="Label"></asp:Label></strong></td>
        </tr> 
        <tr>
            <td style="height: 18px;">
            </td>
            <td style="height: 18px; width: 120px;">
            </td>
            <td style="height: 18px; width: 316px;">
                </td>
                 <td style="width: 99px; height: 18px">
                     <asp:HiddenField ID="CaseId" runat="server" />
                <asp:HiddenField ID="hidVerifierID" runat="server" />
                     <asp:HiddenField ID="Hdn_OccupationType" runat="server" />
                
                </td>
            <td style="width: 285px; height: 18px">
                &nbsp;</td>
            <td style="width: 1498px; height: 18px">
            </td>
            <td style="width: 173px; height: 18px">
            </td>
            <td style="width: 4032px; height: 18px">
            </td>
            <td style="height: 18px; width: 339px;">
            </td>
            <td style="height: 18px;">
            </td>
            <td style="height: 18px; width: 27px;">
            </td>
        </tr>
        <tr>
            <td colspan="11" style="height: 16px">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
         <tr>
            <td colspan="10">
                <asp:ValidationSummary ID="vsummary" runat="server" ValidationGroup="grpSummary" ShowMessageBox="True" />
            </td>
        </tr>
        <tr>
            <td colspan="10" class="TableTitle" style="height: 24px">
                &nbsp;Applicant Details</td>
        </tr>
         <tr>
            <td>
            </td>
             <td style="width: 120px">
             </td>
            <td style="width: 316px">
                <asp:Label ID="Label1" runat="server" Text="Case Id" Width="192px"></asp:Label></td>
            <td style="width: 99px">
                <asp:TextBox ID="txtCaseId" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        
        <tr>
            <td style="height: 25px;">
            </td>
            <td style="height: 25px; width: 120px;">
            </td>
            <td style="height: 25px; width: 120px;">
                Application Number</td>
            <td style="width: 99px; height: 25px;">
                <asp:TextBox ID="txtApplicationNo" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 285px; height: 25px;">
            </td>
            <td style="width: 1498px; height: 25px;">
            </td>
            <td style="width: 100px; height: 25px;">
            </td>
            <td style="width: 4032px; height: 25px;">
            </td>
            <td style="width: 339px; height: 25px;">
            </td>
            <td style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td style="height: 20px;">
            </td>
            <td style="height: 20px; width: 120px;">
            </td>
            <td style="height: 20px">
                Applicant Name</td>
            <td colspan="5" style="height: 20px">
                <asp:TextBox ID="txtApplicantNAme" runat="server" SkinID="txtSkin" ReadOnly="True" ></asp:TextBox></td>
            <td style="width: 339px; height: 20px;">
            </td>
            <td style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="height: 25px">
            </td>
            <td style="height: 25px; width: 120px;">
            </td>
            <td style="width: 316px; height: 25px">
                Office Address</td>
            <td colspan="5" style="height: 25px">
                <asp:TextBox ID="txtOfficeAddress" runat="server" TextMode="MultiLine" Width="474px" Height="60px" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td style="width: 339px; height: 25px">
            </td>
            <td style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="height: 24px; width: 120px;">
                Address Confirmed</td>
            <td style="width: 99px; height: 24px;"><asp:DropDownList ID="ddlAddressConfirm" runat="server" Width="92px" SkinID="ddlSkin">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="height: 24px; width: 316px;">
                Person Met&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlNameOfPersonMet" runat="server" Width="92px" SkinID="ddlSkin" >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>NotPossible</asp:ListItem>
                    <asp:ListItem>NameConfirmed</asp:ListItem>
                    <asp:ListItem>NotConfirmed</asp:ListItem>
                    <asp:ListItem>Applicant</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
                </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px;">
                Person Met Name&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>&nbsp; </strong></span></td>
            <td style="width: 99px;">
                <asp:TextBox ID="txtNameOfPersonMet" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px;">
            </td>
            <td style="width: 1498px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 4032px;">
            </td>
            <td style="width: 339px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Designation of Person Met&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    &nbsp; </strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:TextBox ID="txtDesignationofPerMet" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="height: 24px; width: 316px;">
                Information Provided&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlInformationProvided" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Relationship with applicant Confirm&nbsp; <span style="font-size: 10pt; color: #ff0000">
                    <strong>*</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlrelationwithapplicant"  runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Confirmed</asp:ListItem>
                <asp:ListItem >NotConfirmed</asp:ListItem>
                <asp:ListItem >NotPossible</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
                </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Relationship with Applicant&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:TextBox ID="txtrelationwithapplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Applicant Name&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlApplicantConfirmedwith" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirm</asp:ListItem>
                    <asp:ListItem>NotConfirm</asp:ListItem>
                    <asp:ListItem>NoSuchPerson</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="height: 24px; width: 316px;">
                Designation of Applicant Confirm&nbsp; <span style="font-size: 10pt; color: #ff0000">
                    <strong>*</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddldesignationofApplicant" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Confirmed</asp:ListItem>
                <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
                </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Designation Of Applicant&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td style="width: 99px; height: 24px">
                <asp:TextBox ID="txtdesignationofapplicant" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        
         <tr>
            <td style="height: 16px;">
            </td>
             <td style="height: 16px; width: 120px;">
             </td>
            <td style="height: 16px; width: 316px;">
                Department of Applicant Confirm&nbsp; <span style="font-size: 10pt; color: #ff0000">
                    <strong>*</strong></span></td>
            <td style="width: 99px; height: 16px;">
                <asp:DropDownList ID="ddldepartmentofApplicant" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>NotConfirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 16px;">
                </td>
            <td style="width: 1498px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 4032px; height: 16px;">
            </td>
            <td style="width: 339px; height: 16px;">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="width: 316px; height: 16px">
                Department of Applicant&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td style="width: 99px; height: 16px">
                <asp:TextBox ID="txtDepartment" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 16px">
            </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
      
       <tr>
            <td style="height: 18px">
            </td>
           <td style="height: 18px; width: 120px;">
           </td>
            <td style="height: 18px; width: 316px;">
                Year in Current Employement/YCB</td>
            <td style="width: 99px; height: 18px">
                <table border="0" style="width: 57%; height: 100%" cellspacing="1">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chk_YCE" runat="server" Height="14px" Text="Not Confirmed" Width="95px" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtYearinEmployment" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtMonth" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 18px">
                <asp:RangeValidator ID="rnYCRYY" runat="server" ControlToValidate="txtYearinEmployment"
                    ErrorMessage="Please Enter Numeric Values for Year!" Type="Integer" MaximumValue="99" MinimumValue="0" Width="11px">?</asp:RangeValidator>
                &nbsp;&nbsp;
                <asp:RangeValidator ID="RnYCRMM" runat="server" ControlToValidate="txtMonth"
                    ErrorMessage="Please Enter Numeric Values for Month!" Type="Integer" MaximumValue="12" MinimumValue="0" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px; height: 18px">
            </td>
            <td style="width: 100px; height: 18px">
            </td>
            <td style="width: 4032px; height: 18px">
            </td>
            <td style="width: 339px; height: 18px">
            </td>
            <td style="height: 18px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                Approx Age/ Applicant DOB</td>
            <td colspan="5">
                <table style="width: 100%; height: 100%" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td class="HighLight" style="height: 24px">
                            <asp:CheckBox ID="chkApplicant_DOBAGE_NotConf" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" /></td>
                        <td class="HighLight" style="height: 24px">
                            <strong>
                                <asp:Label ID="Label2" runat="server" Text="DD-MM-YYYY" Width="76px"></asp:Label></strong></td>
                        <td style="width: 100px; height: 24px;">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 100px">
                            <asp:TextBox ID="txtApplicantAge_DOB" runat="server" Width="85px" SkinID="txtSkin"></asp:TextBox></td>
                                    <td style="width: 100px">
                                        <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtApplicantAge_DOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 100px; height: 24px;">
                            &nbsp;</td>
                        <td style="width: 63px; height: 24px;" class="HighLight">
                            &nbsp; <strong>YY:MM</strong></td>
                        <td style="height: 24px; width: 34px;">
                            <asp:TextBox ID="txtApplicantAge_DOB_YY" runat="server" Width="29px" SkinID="txtSkin"></asp:TextBox>
                        </td>
                        <td style="width: 68px; height: 24px;">
                            <asp:TextBox ID="txtApplicantAge_DOB_MM" runat="server" Width="29px" SkinID="txtSkin"></asp:TextBox>
                            </td>
                        <td style="width: 100px; height: 24px;">
                            <asp:RangeValidator ID="RnDOB_YY" runat="server" ControlToValidate="txtApplicantAge_DOB_YY"
                                ErrorMessage="Please Enter Numeric Values for DOB Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer" Width="15px" ValidationGroup="grpsummary">?</asp:RangeValidator></td>
                        <td style="width: 100px; height: 24px">
                            <asp:RangeValidator ID="rn_DOB_MM" runat="server" ControlToValidate="txtApplicantAge_DOB_MM"
                                ErrorMessage="Please Enter Numeric Values for DOB Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer" Width="18px" ValidationGroup="valsummary">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                Company Name&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 16px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlCompanyName" runat="server" Width="92px" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>NotConfirmed</asp:ListItem>
                    <asp:ListItem> No such office</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtNameofBusiness" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 16px">
                </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="width: 316px; height: 16px">
                Employer Address</td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtEmployerAddress" runat="server" TextMode="MultiLine" Width="474px" Height="55px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
         <tr>
            <td>
            </td>
             <td style="width: 120px">
             </td>
            <td style="width: 316px">
                Type of Business&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px">
                <asp:DropDownList ID="ddlTypeofCompany" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Public Ltd</asp:ListItem>
                <asp:ListItem>Pvt.Ltd</asp:ListItem>
                <asp:ListItem>Partnership</asp:ListItem>
                <asp:ListItem>Prop</asp:ListItem>
                <asp:ListItem>NGO</asp:ListItem>
                <asp:ListItem>Govt Office</asp:ListItem>
                <asp:ListItem>MNC</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px;">
            </td>
            <td style="width: 316px;">
                Nature of Business&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px;">
                <asp:DropDownList ID="ddlNature_of_Business" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Manufacturing</asp:ListItem>
                <asp:ListItem>Trading</asp:ListItem>
                <asp:ListItem>Services</asp:ListItem>
                <asp:ListItem>other</asp:ListItem>
              </asp:DropDownList></td>
            <td style="width: 285px;">
            </td>
            <td style="width: 1498px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 4032px;">
            </td>
            <td style="width: 339px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="width: 316px; height: 16px">
                Business Description&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 16px">
                <asp:TextBox ID="txtBusinessDescription" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 16px">
            </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
         
        <tr>
            <td style="height: 22px">
            </td>
            <td style="height: 22px; width: 120px;">
            </td>
            <td style="width: 316px; height: 22px;">
               Telephone No:Office</td>
            <td style="width: 99px; height: 22px;">
                <asp:TextBox ID="txtTelephoneNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 22px;">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" BackColor="Red"
                    BorderColor="Red" BorderStyle="Groove" BorderWidth="1px" ControlToValidate="txtTelephoneNo"
                    ErrorMessage="Plese enter only Numeric values!" Font-Bold="True" ForeColor="White"
                    ValidationExpression="[0-9]{0,15}" Width="16px">?</asp:RegularExpressionValidator></td>
            <td style="width: 1498px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="width: 4032px; height: 22px;">
            </td>
            <td style="width: 339px; height: 22px;">
            </td>
            <td style="height: 22px;">
            </td>
        </tr>
         <tr>
            <td>
            </td>
             <td style="width: 120px">
             </td>
            <td style="width: 316px">
              Extension</td>
            <td style="width: 99px">
                <asp:TextBox ID="txtExtension" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" BackColor="Red"
                    BorderColor="Red" BorderStyle="Groove" BorderWidth="1px" ControlToValidate="txtExtension"
                    ErrorMessage="Plese enter only Numeric values!" Font-Bold="True" ForeColor="White"
                    ValidationExpression="[0-9]{0,15}" Width="16px">?</asp:RegularExpressionValidator></td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td style="height: 18px; width: 120px;">
            </td>
            <td style="height: 18px; width: 316px;">
                No of Years of Company's Existance</td>
            <td style="width: 99px; height: 18px">
                <table border="0" style="width: 57%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chk_Exit_Company" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" SkinID="chkSkin" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtNoofExistenceYear" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtNoOfExistenceMonth" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 18px">
                <asp:RangeValidator ID="rn_NoOfExistence" runat="server" ControlToValidate="txtNoofExistenceYear"
                    ErrorMessage="Please Enter Numeric Values for Year!" Type="Integer" MaximumValue="99" MinimumValue="0" Width="11px">?</asp:RangeValidator>
                &nbsp;&nbsp;
                <asp:RangeValidator ID="rn_NoOfExistenceM" runat="server" ControlToValidate="txtNoOfExistenceMonth"
                    ErrorMessage="Please Enter Numeric Values for Month!" Type="Integer" MaximumValue="12" MinimumValue="0" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px; height: 18px">
            </td>
            <td style="width: 100px; height: 18px">
            </td>
            <td style="width: 4032px; height: 18px">
            </td>
            <td style="width: 339px; height: 18px">
            </td>
            <td style="height: 18px;">
            </td>
        </tr>
        
      <tr>
            <td style="height: 26px;">
            </td>
          <td style="height: 26px; width: 120px;">
          </td>
            <td style="height: 26px; width: 316px;">
               Telephone No:Residence</td>
            <td style="width: 99px; height: 26px;">
                <asp:TextBox ID="txtResidence" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 26px;">
                <asp:RegularExpressionValidator ID="rnResiNumber" runat="server" BackColor="Red"
                    BorderColor="Red" BorderStyle="Groove" BorderWidth="1px" ControlToValidate="txtResidence"
                    ErrorMessage="Plese enter only Numeric values!" Font-Bold="True" ForeColor="White"
                    ValidationExpression="[0-9]{0,15}" Width="16px">?</asp:RegularExpressionValidator></td>
            <td style="width: 1498px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 4032px; height: 26px;">
            </td>
            <td style="width: 339px; height: 26px;">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="height: 26px; width: 316px;">
                Email-id</td>
            <td style="width: 99px; height: 26px">
                <asp:TextBox ID="txtEmailId" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px; height: 26px">
            </td>
            <td style="width: 1498px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 4032px; height: 26px">
            </td>
            <td style="width: 339px; height: 26px">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="height: 26px; width: 316px;">
                Type of Proof&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 26px">
                <asp:DropDownList ID="ddlTypeOfProof" runat="server" Width="92px" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Visiting Card</asp:ListItem>
                <asp:ListItem>Employee ID</asp:ListItem>
                <asp:ListItem>PAN Card</asp:ListItem>
                <asp:ListItem>Voter ID</asp:ListItem>
                <asp:ListItem>Driving License</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
                <asp:ListItem>Not Shown</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px; height: 26px">
            </td>
            <td style="width: 1498px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 4032px; height: 26px">
            </td>
            <td style="width: 339px; height: 26px">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
       
        <tr>
            <td style="height: 26px">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="width: 316px; height: 26px">
                Applicant Is Full Time Employee&nbsp; <span style="font-size: 10pt; color: #ff0000">
                    <strong>*</strong></span></td>
            <td style="width: 99px; height: 26px">
                <asp:DropDownList ID="ddlAppFullTimeEmployee" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 26px">
            </td>
            <td style="width: 1498px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 4032px; height: 26px">
            </td>
            <td style="width: 339px; height: 26px">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
        <tr>
            <td colspan="10" style="height: 26px">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td class="TableTitle" colspan="5" style="height: 18px">
                                &nbsp;Residence Cum Business</td>
                        </tr>
                        <tr>
                            <td style="width: 1px;">
                                <asp:Label ID="Label3" runat="server" Text="Residance Cum Business" Width="192px"></asp:Label></td>
                            <td style="height: 14px">
                                <asp:DropDownList ID="ddl_ResiCumBusi" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList><br />
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1px;">
                                SeperateAreaSeen&nbsp;</td>
                            <td style="height: 14px">
                                <asp:DropDownList ID="ddlSeperateAreaSeen" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 100px; height: 14px">
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                            <td style="width: 100px; height: 14px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td style="height: 24px" colspan="10">
                <asp:Panel ID="pnlAddnotConfirmed" runat="server" Width="100%">
                    <table width="100%" cellspacing="0">
        <tr>
            <td colspan="10" class="TableTitle" style="height: 23px; text-align: left;">
                <strong>If the Address is not confirmed then </strong></td>
        </tr>
         <tr>
            <td style="height: 30px">
            </td>
            <td style="width: 173px; height: 30px;">
                <asp:Label ID="lblReasonFortheAddressNotConfirmed" runat="server" Text="Reason for the address not confirmed"
                    Width="196px"></asp:Label></td>
            <td style="width: 26px; height: 30px;"><asp:DropDownList ID="ddl_ReasonAddNotConf" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Mismatch in address</asp:ListItem>
                <asp:ListItem>Untraceable</asp:ListItem>
             </asp:DropDownList></td>
            <td style="width: 285px; height: 30px;">
            </td>
            <td style="width: 173px; height: 30px;">
            </td>
            <td style="width: 100px; height: 30px;">
            </td>
            <td style="width: 208px; height: 30px;">
            </td>
            <td style="height: 30px">
            </td>
            <td style="width: 274px; height: 30px;">
            </td>
            <td style="height: 30px; width: 9px;">
            </td>
        </tr>
        <tr>
           <td>
            </td>
            <td style="width: 173px">
                <asp:Label ID="lblToWhomdoestheaddressbelong" runat="server" Text="To whom does the address belong"
                    Width="180px"></asp:Label></td>
            <td style="width: 26px">
                <asp:TextBox ID="txtWhomaddBelong" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px">
            </td>
            <td style="width: 173px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 208px">
            </td>
            <td>
            </td>
            <td style="width: 274px">
            </td>
            <td style="width: 9px">
            </td>
        </tr>
          <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 173px; height: 23px;">
                <asp:Label ID="lblResultofCalling" runat="server" Text="Result of Calling"></asp:Label></td>
            <td style="width: 26px; height: 23px;">
            <asp:TextBox ID="txtResultofCalling" runat="server" SkinID="txtSkin"></asp:TextBox>
             </td>
            <td style="width: 285px; height: 23px;">
            </td>
            <td style="width: 173px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 208px; height: 23px;">
            </td>
            <td style="height: 23px">
            </td>
            <td style="width: 274px; height: 23px;">
            </td>
            <td style="height: 23px; width: 9px;">
            </td>
        </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
       
         <tr>
            <td colspan="10" class="TableTitle" style="height: 25px; text-align: left;">
                &nbsp;T<strong>PC Details</strong></td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                &nbsp;TPC 1 Name&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 16px">
                <table border="0" cellpadding="0" style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlTPC1_Name" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>NotPossible</asp:ListItem>
                    <asp:ListItem>NotProvided</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC1_Name" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 16px">
                </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                &nbsp;TPC 1 By Whom</td>
            <td style="width: 99px; height: 16px">
                <asp:DropDownList ID="ddlTPC1_ByWHOM" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Reception</asp:ListItem>
                    <asp:ListItem>Colleague</asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Shop </asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 16px">
            </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                &nbsp;TPC 1&nbsp; Address</td>
            <td colspan="5">
                <asp:TextBox ID="txtTPC1_Address" runat="server" Height="42px" TextMode="MultiLine"
                    Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 13px">
            </td>
            <td style="height: 13px; width: 120px;">
            </td>
            <td style="height: 13px; width: 316px;">
                &nbsp;TPC 1 Applicant Name&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    &nbsp; </strong></span></td>
            <td style="height: 13px; width: 99px;">
                <table style="width: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 7px">
              <asp:DropDownList ID="ddlTcpApplicantName" runat="server" SkinID="ddlSkin">
              <asp:ListItem></asp:ListItem>
              <asp:ListItem>Confirmed</asp:ListItem>
              <asp:ListItem>Not Confirmed</asp:ListItem>
              <asp:ListItem >No Such Person</asp:ListItem>
              </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC1_ApplicantName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="height: 13px; width: 285px;">
                </td>
            <td style="width: 1498px; height: 13px">
            </td>
            <td style="width: 100px; height: 13px">
            </td>
            <td style="width: 4032px; height: 13px">
            </td>
            <td style="width: 339px; height: 13px">
            </td>
            <td style="height: 13px;">
            </td>
        </tr>
         <tr>
            <td>
            </td>
             <td style="width: 120px">
             </td>
            <td style="width: 316px;">
                &nbsp;TPC 1 Applicant Age(Approx)</td>
              <td style="width: 99px; height: 18px">
                <table border="0" style="width: 57%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chk_TPC1_age" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" SkinID="chkSkin" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtTPC1_AgeYear" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtTPC1_AgeMonth" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px;">
                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtTPC1_AgeYear"
                    ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                    Type="Integer" Width="11px">?</asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtTPC1_AgeMonth"
                    ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                    Type="Integer" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 4032px;">
            </td>
            <td style="width: 339px;">
            </td>
            <td>
            </td>
        </tr>
        
        
        <tr>
            <td style="height: 26px;">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="width: 316px; height: 26px;">
                &nbsp;TPC 1 Employment</td>
            <td style="width: 99px; height: 26px;">
                <asp:DropDownList ID="ddlTPC1_Employment" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem> Not confirmed</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                    <asp:ListItem>Transferred</asp:ListItem>
                    <asp:ListItem>Left the job</asp:ListItem>
                    <asp:ListItem>About to resign</asp:ListItem>
                </asp:DropDownList></td>
           
            <td style="width: 173px; height: 26px;">
            </td>
            <td style="width: 1498px; height: 26px;">
            </td>
            <td style="width: 208px; height: 26px;">
            </td>
            <td style="width: 4032px; height: 26px;">
            </td>
            <td style="height: 26px; width: 339px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                &nbsp;TPC 1 Designation of Applicant</td>
            <td style="width: 99px; height: 24px;">
                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                <asp:DropDownList ID="ddlTPC1_DesignofApplicant" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem> Not confirmed</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC1_designationOfApp" runat="server" Width="124px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 24px;">
                </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                &nbsp;TPC 1 App YCE</td>
                
            <td style="width: 99px; height: 18px">
                <table border="0" style="width: 57%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chk_TPC1AppYCE" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" SkinID="chkSkin" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtTPC1_Year" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtTPC1_Month" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="height: 16px; width: 285px;">
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTPC1_Year"
                    ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                    Type="Integer" Width="11px">?</asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtTPC1_Month"
                    ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                    Type="Integer" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        
        <tr>
            <td style="height: 23px;">
            </td>
            <td style="height: 23px; width: 120px;">
            </td>
            <td style="width: 316px; height: 23px;">
                Type of Company</td>
            <td style="width: 99px; height: 23px;"><asp:DropDownList ID="ddl_TCP_TypeofCompany" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Public Ltd</asp:ListItem>
                <asp:ListItem>Pvt.Ltd</asp:ListItem>
                <asp:ListItem>Partnership</asp:ListItem>
                <asp:ListItem>Prop</asp:ListItem>
                <asp:ListItem>NGO</asp:ListItem>
                <asp:ListItem>Govt Office</asp:ListItem>
                <asp:ListItem>MNC</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px; height: 23px;">
            </td>
            <td style="width: 1498px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 4032px; height: 23px;">
            </td>
            <td style="width: 339px; height: 23px;">
            </td>
            <td style="height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="height: 22px">
            </td>
            <td style="height: 22px; width: 120px;">
            </td>
            <td style="width: 316px; height: 22px;">
                Nature of Business</td>
            <td style="width: 99px; height: 22px;"><asp:DropDownList ID="ddl_TCP_NatureOfBusiness" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Manufacturing</asp:ListItem>
                <asp:ListItem>Trading</asp:ListItem>
                <asp:ListItem>Services</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
              </asp:DropDownList></td>
            <td style="width: 285px; height: 22px;">
            </td>
            <td style="width: 1498px; height: 22px;">
            </td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="width: 4032px; height: 22px;">
            </td>
            <td style="width: 339px; height: 22px;">
            </td>
            <td style="height: 22px;">
            </td>
        </tr>
                
        <tr>
            <td style="height: 16px" class="TableTitle" colspan="10">
                &nbsp;TPC 2 Details</td>
        </tr>
       <tr>
            <td style="height: 16px">
            </td>
           <td style="height: 16px; width: 120px;">
           </td>
            <td style="height: 16px; width: 316px;">
                &nbsp;TPC 2 Name <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 99px; height: 16px">
                <table border="0" style="width: 100%" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlTPC2_Name" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>NotPossible</asp:ListItem>
                    <asp:ListItem>NotProvided</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC2_Name" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 16px">
                </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                &nbsp;TPC 2 By Whom</td>
            <td style="width: 99px; height: 16px">
                <asp:DropDownList ID="ddlTPC2_ByWhom" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Reception</asp:ListItem>
                    <asp:ListItem>Colleague</asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Shop </asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 16px">
            </td>
            <td style="width: 1498px; height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 4032px; height: 16px">
            </td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                &nbsp;TPC 2&nbsp; Address</td>
            <td colspan="5">
                <asp:TextBox ID="txtTPC2_Address" runat="server" Height="42px" TextMode="MultiLine"
                    Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="height: 26px; width: 316px;">
                &nbsp;TPC 2 Applicant Name <strong><span style="font-size: 10pt; color: #ff0000"></span></strong></td>
            <td style="height: 26px; width: 99px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px">
              <asp:DropDownList ID="ddlTPC2_AppName" runat="server" SkinID="ddlSkin">
              <asp:ListItem></asp:ListItem>
              <asp:ListItem>Confirmed</asp:ListItem>
              <asp:ListItem>Not Confirmed</asp:ListItem>
              <asp:ListItem >No Such Person</asp:ListItem>
              </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC2_AppName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="height: 26px; width: 285px;">
                </td>
            <td style="width: 1498px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 4032px; height: 26px">
            </td>
            <td style="width: 339px; height: 26px">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
         <tr>
            <td style="height: 21px">
            </td>
             <td style="height: 21px; width: 120px;">
             </td>
            <td style="width: 316px; height: 21px;">
                &nbsp;TPC 2 Applicant Age(Approx)</td>
           <td style="width: 99px; height: 21px">
                <table border="0" style="width: 57%; height: 100%" cellpadding="1" cellspacing="1">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chkTPC2_age" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" SkinID="chkSkin" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtTPC2_AgeYear" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtTPC2_AgeMonth" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 21px;">
                <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtTPC2_AgeYear"
                    ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                    Type="Integer" Width="11px">?</asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtTPC2_AgeMonth"
                    ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                    Type="Integer" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 4032px; height: 21px;">
            </td>
            <td style="width: 339px; height: 21px;">
            </td>
            <td style="height: 21px;">
            </td>
        </tr>
        
        
        <tr>
            <td style="height: 26px;">
            </td>
            <td style="height: 26px; width: 120px;">
            </td>
            <td style="width: 316px; height: 26px;">
                &nbsp;TPC 2 Employment</td>
            <td style="width: 99px; height: 26px;">
                <asp:DropDownList ID="ddlTPC2_employment" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem> Not confirmed</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                    <asp:ListItem>Transferred</asp:ListItem>
                    <asp:ListItem>Left the job</asp:ListItem>
                    <asp:ListItem>About to resign</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 26px;">
                </td>
            <td style="width: 1498px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 4032px; height: 26px;">
            </td>
            <td style="width: 339px; height: 26px;">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                &nbsp;TPC 2 Designation of Applicant</td>
            <td style="width: 99px; height: 24px;">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddl_TPC2Desig_App" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem> Not confirmed</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC2_dsigApp" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 285px; height: 24px;">
                </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td style="height: 18px; width: 120px;">
            </td>
            <td style="height: 18px; width: 316px;">
                &nbsp;TPC 2 App YCE</td>
             <td style="width: 99px; height: 18px">
                <table border="0" style="width: 57%; height: 100%">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 92px; height: 22px">
                            <asp:CheckBox ID="chk_TPC2_YCE" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" SkinID="chkSkin" /></td>
                        <td class="HighLight" colspan="" style="width: 92px; height: 22px;">
                            <b>YY:MM</b></td>
                        <td style="width: 8px; height: 22px;">
                            <asp:TextBox ID="txtTPC2_YCEYear" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtTPC2_Month" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="height: 18px; width: 285px;">
                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtTPC2_YCEYear"
                    ErrorMessage="Please Enter Numeric Values for Year!" MaximumValue="99" MinimumValue="0"
                    Type="Integer" Width="11px">?</asp:RangeValidator>
                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtTPC2_Month"
                    ErrorMessage="Please Enter Numeric Values for Month!" MaximumValue="12" MinimumValue="0"
                    Type="Integer" Width="12px">?</asp:RangeValidator></td>
            <td style="width: 1498px; height: 18px">
            </td>
            <td style="width: 100px; height: 18px">
            </td>
            <td style="width: 4032px; height: 18px">
            </td>
            <td style="width: 339px; height: 18px">
            </td>
            <td style="height: 18px;">
            </td>
        </tr>
        
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                Type of Company</td>
            <td style="width: 99px; height: 24px;"><asp:DropDownList ID="ddlTPC2_typeofComp" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Public Ltd</asp:ListItem>
                <asp:ListItem>Pvt.Ltd</asp:ListItem>
                <asp:ListItem>Partnership</asp:ListItem>
                <asp:ListItem>Prop</asp:ListItem>
                <asp:ListItem>NGO</asp:ListItem>
                <asp:ListItem>Govt Office</asp:ListItem>
                <asp:ListItem>MNC</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                Nature of Business</td>
            <td style="width: 99px"><asp:DropDownList ID="ddlTPC2_NatureofBusi" runat="server" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>NotConfirmed</asp:ListItem>
                <asp:ListItem>Manufacturing</asp:ListItem>
                <asp:ListItem>Trading</asp:ListItem>
                <asp:ListItem>Services</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
              </asp:DropDownList></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
      
                
        <tr>
            <td class="TableTitle" colspan="10" style="height: 20px">
                Verifier Observation (Demography)</td>
        </tr>
        
        
          <tr>
            <td>
            </td>
              <td style="width: 120px">
              </td>
            <td style="width: 316px">
                <asp:Label ID="lblEntryPermitted" runat="server" Text="Entry permitted"></asp:Label><span style="font-size: 10pt; color: #ff0000"><strong>&nbsp;
                </strong></span></td>
            <td style="width: 99px">
                <asp:DropDownList ID="ddlEntryPermitted" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Door Locked</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                <asp:Label ID="lblActivitySeen" runat="server" Text="Activity Seen"></asp:Label>
                <span style="font-size: 10pt; color: #ff0000"></span></td>
            <td style="width: 99px; height: 24px;">
                <asp:DropDownList ID="ddlActivitySeen" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                <asp:Label ID="lblStockSeen" runat="server" Text="Stock Seen"></asp:Label>
                <span style="font-size: 10pt; color: #ff0000"></span></td>
            <td style="width: 99px; height: 24px;">
                <asp:DropDownList ID="ddlStockSeen" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                <asp:Label ID="lblOfficeSetUpSeen" runat="server" Text="Office Set Up Seen"></asp:Label>
                <span style="font-size: 10pt; color: #ff0000"></span></td>
            <td style="width: 99px; height: 24px;">
                <asp:DropDownList ID="ddlOfficesetupseen" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                <asp:Label ID="lblOfficeStatus" runat="server" Text="Office Status "></asp:Label></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddl_OfficeStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Excellent</asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Acceptable</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                <asp:Label ID="lblOfficeArea" runat="server" Text="Office Area(Sq Ft) "></asp:Label></td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlAreaOfOffice" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>less than 100</asp:ListItem>
                <asp:ListItem>100-300</asp:ListItem>
                <asp:ListItem>300-500</asp:ListItem>
                <asp:ListItem>500-800</asp:ListItem>
                <asp:ListItem>800-1200</asp:ListItem>
                <asp:ListItem>&gt;1200</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px">
                Type Of Office Locality</td>
            <td style="width: 99px; height: 24px">
                <asp:DropDownList ID="ddlTypeOfficeLocality" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Commercial</asp:ListItem>
                    <asp:ListItem>Residential</asp:ListItem>
                    <asp:ListItem>Industrial</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px">
            </td>
            <td style="width: 1498px; height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 4032px; height: 24px">
            </td>
            <td style="width: 339px; height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 22px">
            </td>
            <td style="height: 22px; width: 120px;">
            </td>
            <td style="width: 316px; height: 22px;">
                <asp:Label ID="lblNoOfEmployees" runat="server" Text="No.of Employees"></asp:Label></td>
            <td style="height: 22px;" colspan="3">
                <asp:TextBox ID="txtNoOfEmployees" runat="server" SkinID="txtSkin" ToolTip="Please enter only Numeric values!"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txtNoOfEmployees"
                    ErrorMessage="Please Enter Numeric Values." MaximumValue="99999" MinimumValue="0"
                    Type="Integer" Width="8px" BackColor="Red" ForeColor="White" SetFocusOnError="True">?</asp:RangeValidator>
                <span style="color: #696969">(Please enter only numeric values)</span></td>
            <td style="width: 100px; height: 22px;">
            </td>
            <td style="width: 4032px; height: 22px;">
            </td>
            <td style="width: 339px; height: 22px;">
            </td>
            <td style="height: 22px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                <asp:Label ID="lblCompanyBoardSeen" runat="server" Text="Company board Seen Outside the Building/Office " Width="182px"></asp:Label></td>
            <td style="width: 99px">
                <asp:DropDownList ID="ddlCompanyboardSeen" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Different</asp:ListItem>
                    </asp:DropDownList></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
       
        
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                <asp:Label ID="lblEaseofLocating" runat="server" Text="Ease Of Locating Office "></asp:Label></td>
            <td style="width: 99px; height: 24px;">
                <asp:DropDownList ID="ddlEaseOfLocationOffice" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
        
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="height: 24px; width: 120px;">
            </td>
            <td style="width: 316px; height: 24px;">
                <asp:Label ID="lblAddressUpdation" runat="server" Text="Address Updation"></asp:Label><span style="font-size: 10pt; color: #ff0000"><strong>&nbsp;
                </strong></span></td>
            <td style="width: 99px; height: 24px;">
            
                <asp:DropDownList ID="ddlAddressUpdation" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin"                    >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                 </asp:DropDownList>
            </td>
            <td style="width: 285px; height: 24px;">
            </td>
            <td style="width: 1498px; height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 4032px; height: 24px;">
            </td>
            <td style="width: 339px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
        </tr>
          <tr>
            <td style="height: 26px;">
            </td>
              <td style="height: 26px; width: 120px;">
              </td>
            <td style="height: 26px; width: 316px;">
                <asp:Label ID="lblCorrectAddress" runat="server" Text="Correct Address"></asp:Label></td>
            <td style="height: 26px; width: 99px;">
            <asp:TextBox ID="txtCorrectAddress" runat="server" SkinID="txtSkin"></asp:TextBox>
            </td>
            <td style="height: 26px; width: 285px;">
            </td>
            <td style="width: 1498px; height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 4032px; height: 26px;">
            </td>
            <td style="width: 339px; height: 26px;">
            </td>
            <td style="height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="height: 34px;">
            </td>
            <td style="height: 34px; width: 120px;">
            </td>
            <td style="height: 34px; width: 316px;">
                <asp:Label ID="lbllandmark" runat="server" Text="LandMark "></asp:Label></td>
            <td style="width: 99px; height: 34px;">
                <asp:TextBox ID="txtLandmark" runat="server" SkinID="txtSkin" ></asp:TextBox></td>
            <td style="width: 285px; height: 34px;">
            </td>
            <td style="width: 1498px; height: 34px;">
            </td>
            <td style="width: 100px; height: 34px;">
            </td>
            <td style="width: 4032px; height: 34px;">
            </td>
            <td style="width: 339px; height: 34px;">
            </td>
            <td style="height: 34px;">
            </td>
        </tr>
      
         
        <tr>
            <td class="TableTitle" colspan="10">
                Attempts Details</td>
        </tr>
        <tr>
            <td style="height: 76px;">
            </td>
            <td colspan="1" style="height: 76px; width: 120px;">
            </td>
            <td colspan="6" style="height: 76px">
                <table id="tblAttempt" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="TDWidth" style="height: 14px; width: 17%;">
                            <asp:Label ID="lblLogin" runat="server" SkinID="lblSkin" Text="Attempts"></asp:Label>
                        </td>
                        <td style="height: 14px">
                            <asp:Label ID="lblDate" runat="server" SkinID="lblSkin" Text="Date [dd/MM/yyyy]"></asp:Label>
                        </td>
                        <td style="height: 14px">
                            <asp:Label ID="lblTelNo" runat="server" SkinID="lblSkin" Text="Time [hh:mm]"></asp:Label>
                        </td>
                        <td style="height: 14px">
                            <asp:Label ID="lblRemark" runat="server" SkinID="lblSkin" Text="Verifier Remark"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth" style="width: 17%">
                            <asp:Label ID="lblFirstAttempt" runat="server" SkinID="lblSkin" Text="First Attempt"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAttemptDate1" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                            <img id="ImgDate1stCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td>
                            <asp:TextBox ID="txtAttemptTime1" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType1" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                              <asp:DropDownList ID="ddlVerifierRemarks1" runat="server" SkinID="ddlSkin">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Contactable</asp:ListItem>
                                <asp:ListItem>door Locked</asp:ListItem>
                                <asp:ListItem>No Information</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth" style="width: 17%">
                            <asp:Label ID="lblSecondAttempt" runat="server" SkinID="lblSkin" Text="Second Attempt"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAttemptDate2" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                            <img id="ImgDate2ndCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td>
                            <asp:TextBox ID="txtAttemptTime2" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType2" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlVerifierRemarks2" runat="server" SkinID="ddlSkin">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Contactable</asp:ListItem>
                                <asp:ListItem>door Locked</asp:ListItem>
                                <asp:ListItem>No Information</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth" style="width: 17%">
                            <asp:Label ID="lblThirdAttempt" runat="server" SkinID="lblSkin" Text="Third Attempt"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAttemptDate3" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td>
                            <asp:TextBox ID="txtAttemptTime3" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType3" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlVerifierRemarks3" runat="server" SkinID="ddlSkin">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Contactable</asp:ListItem>
                                <asp:ListItem>door Locked</asp:ListItem>
                                <asp:ListItem>No Information</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 339px; height: 76px;">
            </td>
            <td style="height: 76px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="height: 16px; width: 120px;">
            </td>
            <td style="height: 16px; width: 316px;">
                <asp:Label ID="lblVerificationConductedAt" runat="server" Text="Verification Conducted At"></asp:Label></td>
            <td colspan="5" style="height: 16px">
                <asp:DropDownList ID="ddlVerification_conductedAt" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Applicant Address</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 339px; height: 16px">
            </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 5px">
            </td>
            <td style="height: 5px; width: 120px;">
            </td>
            <td style="height: 5px; width: 316px;">
                <asp:Label ID="lblVerifierName" runat="server" Text="Verifier Name"></asp:Label></td>
            <td style="height: 5px; width: 99px;">
                <asp:TextBox ID="txtVerifierName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 5px; width: 285px;">
            </td>
            <td style="width: 1498px; height: 5px">
            </td>
            <td style="width: 100px; height: 5px">
            </td>
            <td style="width: 4032px; height: 5px">
            </td>
            <td style="width: 339px; height: 5px">
            </td>
            <td style="height: 5px;">
            </td>
        </tr>
          <tr>
            <td style="height: 5px">
            </td>
              <td style="height: 5px; width: 120px;">
              </td>
            <td style="height: 5px; width: 316px;">
                Verifier Remarks <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
              <td colspan="3" style="height: 5px">
                  <asp:TextBox ID="txtVerifierRemark" runat="server" Height="58px" TextMode="MultiLine"
                      Width="700px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 5px">
                </td>
            <td style="width: 4032px; height: 5px">
            </td>
            <td style="width: 339px; height: 5px">
            </td>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr>
            <td style="height: 5px">
            </td>
            <td style="width: 120px; height: 5px">
            </td>
            <td style="width: 316px; height: 5px">
                Verifier Observation</td>
            <td colspan="3" style="height: 5px">
                <asp:TextBox ID="txtObservation" runat="server" Height="29px" SkinID="txtSkin" TextMode="MultiLine"
                    Width="700px"></asp:TextBox></td>
            <td style="width: 100px; height: 5px">
                <asp:Label ID="Label4" runat="server" BackColor="White" ForeColor="Maroon"></asp:Label></td>
            <td style="width: 4032px; height: 5px">
            </td>
            <td style="width: 339px; height: 5px">
            </td>
            <td style="height: 5px">
            </td>
        </tr>
        <tr>
            <td style="height: 5px">
            </td>
            <td style="height: 5px; width: 120px;">
            </td>
            <td style="height: 5px; width: 316px;">
                Directory Checked</td>
            <td style="height: 5px; width: 99px;">
                <asp:DropDownList ID="ddlDirectoryChecked" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"                    >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>W01-Both Matched</asp:ListItem>
                    <asp:ListItem>W02-Both Mismatches</asp:ListItem>
                    <asp:ListItem>W03-Name Matched Address Mismatched</asp:ListItem>
                    <asp:ListItem>W04-Address Matched Name Mismatched</asp:ListItem>
                    <asp:ListItem>W05-Not Found in Web Check, Invalid No.</asp:ListItem>
                    <asp:ListItem>W06-PVT Checked</asp:ListItem>
                 </asp:DropDownList></td>
            <td style="height: 5px; width: 285px;">
            </td>
            <td style="width: 1498px; height: 5px">
            </td>
            <td style="width: 100px; height: 5px">
            </td>
            <td style="width: 4032px; height: 5px">
            </td>
            <td style="width: 339px; height: 5px">
            </td>
            <td style="height: 5px;">
            </td>
        </tr>
              <tr>
            <td>
            </td>
                  <td style="width: 120px">
                  </td>
            <td style="width: 316px">
                SupervisorName</td>
            <td style="width: 99px">
                <asp:DropDownList ID="ddlSupervisorName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
                Supervisor Remark</td>
            <td colspan="4">
                <asp:TextBox ID="txtSuperVisorRemark" runat="server" Height="60px" TextMode="MultiLine" Width="486px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 42px">
            </td>
            <td style="width: 120px; height: 42px;">
            </td>
            <td style="width: 316px; height: 42px;">
                Proprietor recommendation <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 99px; height: 42px;">
                <asp:DropDownList ID="ddlProprietorRecomm" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin"
                    >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Positive</asp:ListItem>
                    <asp:ListItem>Negative</asp:ListItem>
                    <asp:ListItem>Defaulter</asp:ListItem>
                    <asp:ListItem>Referral</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 285px; height: 42px;">
            </td>
            <td style="width: 1498px; height: 42px;">
            </td>
            <td style="width: 100px; height: 42px;">
            </td>
            <td style="width: 4032px; height: 42px;">
            </td>
            <td style="width: 339px; height: 42px;">
            </td>
            <td style="height: 42px;">
            </td>
        </tr>
         <tr>
            <td>
            </td>
             <td style="width: 120px">
             </td>
            <td style="width: 316px">
                If Defaulter,details</td>
            <td style="width: 99px">
                <asp:TextBox ID="txtdefaulter" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
       
        <tr>
            <td class="TableTitle" colspan="10">
                <br />
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save"  ValidationGroup="grpSummary" OnClick="btnSave_Click" Height="28px" SkinID="btnSaveSkin" Width="77px" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Height="28px" SkinID="btnCancelSkin" /><br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 120px">
            </td>
            <td style="width: 316px">
            </td>
            <td style="width: 99px">
            </td>
            <td style="width: 285px">
            </td>
            <td style="width: 1498px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 4032px">
            </td>
            <td style="width: 339px">
            </td>
            <td>
            </td>
        </tr>
       </table>
       </asp:Panel> 
</asp:Content>


