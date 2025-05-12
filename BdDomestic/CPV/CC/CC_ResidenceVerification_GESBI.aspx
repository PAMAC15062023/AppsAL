<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true"
    CodeFile="CC_ResidenceVerification_GESBI.aspx.cs" Inherits="CC_ResidenceVerification_GESBI"
    Title="GeSBI- RV " StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script language="javascript" type="text/javascript">   
    
        function CountLength()
        {
          //debugger;
          var txtObservation=document.getElementById("<%=txtObservation.ClientID%>").value;
          var txtVerifierRemark=document.getElementById("<%=txtVerifierRemark.ClientID%>").value;
          
       
            var Label4=document.getElementById("<%=Label4.ClientID%>");  
            Label4.innerText=txtVerifierRemark.length+txtObservation.length;     
        
        }       
        
        function Enable_validation_On_SupervisorAutoPopulate_Remark()
        {
            var statusIndex=document.getElementById("<%=ddlDirectory_Check.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlDirectory_Check.ClientID%>").options[statusIndex].text;
            var strSuperVisorRemark="";
            var txtSuperVisorRemark=document.getElementById("<%=txtSuperVisorRemark.ClientID%>");
            
            if (status!='')
            {
                status=status.substring(0,4);
                strSuperVisorRemark=status;
            
            }       
        
            txtSuperVisorRemark.value=strSuperVisorRemark;
        }    
    
    
    
        function Enable_Validation_ResidanceNo_Confirmed(MainControlId,MainValue,ActionToTake,ControlIdToComp,ControlType)
        {
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
    
        function Enable_validation_AddressConfirmBy()
        {
          //debugger;
            var statusIndex=document.getElementById("<%=ddlAddConfBy.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlAddConfBy.ClientID%>").options[statusIndex].text;
            var ddlNameOfPersonMet=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>");        
            var ddlRelationShipWithApp=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>");
            var txtRelationship_Other=document.getElementById("<%=txtRelationship_Other.ClientID%>");              

      
          var value=false; 
          if ((status=='Neighbor')||(status=='Guard'))
          {
               //value=true; 
               ddlNameOfPersonMet.selectedIndex=0;
               ddlRelationShipWithApp.selectedIndex=0;
          }
          else if (status=='Self')
          {
              value=true;   
              ddlNameOfPersonMet.selectedIndex=2;
          } 
          else 
          {
              ddlNameOfPersonMet.selectedIndex=0;
          }    
            
            ddlNameOfPersonMet.disabled=value;  
            Enabled_Validation_PersonMet();
            Enable_Validation_ResidanceNo_Confirmed(ddlRelationShipWithApp,'Others',false,txtRelationship_Other,'TextBox');                                   
        }
        
        function Enable_validation_On_AutoPopulate_Remark()
        { 
         //debugger;
          var statusIndex_Info=document.getElementById("<%=ddl_InfoRefused.ClientID%>").selectedIndex;
          var status_Info=document.getElementById("<%=ddl_InfoRefused.ClientID%>").options[statusIndex_Info].text;

          var statusIndex_Propreco=document.getElementById("<%=ddlProprietor_recomm.ClientID%>").selectedIndex;
          var status_Propreco=document.getElementById("<%=ddlProprietor_recomm.ClientID%>").options[statusIndex_Propreco].text;
          var txtDefault=document.getElementById("<%=txtDefault.ClientID%>");
            
             
          var statusIndex_ADDUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").selectedIndex;
          var status_ADDUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").options[statusIndex_ADDUpdation].text;
 
          var statusIndex_AreaType=document.getElementById("<%=ddlAreaType.ClientID%>").selectedIndex;
          var status_AreaType=document.getElementById("<%=ddlAreaType.ClientID%>").options[statusIndex_AreaType].text;
             
          var statusIndexAppName=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").selectedIndex;
          var statusAppName=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").options[statusIndexAppName].text;                    
           
          var statusIndex_Relation=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>").selectedIndex;         
          var status_Relation=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>").options[statusIndex_Relation].text;          
          
          var statusIndex_AddressConfirm=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;         
          var status_AddressConfirm=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusIndex_AddressConfirm].text;          
          
          var txtNameOfThePersonMet=document.getElementById("<%=txtNameOfThePersonMet.ClientID%>");
          var txtVerifierRemark=document.getElementById("<%=txtVerifierRemark.ClientID%>");
                  
          var statusIndexAppName_conf=document.getElementById("<%=ddlApplicantNameConfirmed.ClientID%>").selectedIndex;
          var statusAppName_conf=document.getElementById("<%=ddlApplicantNameConfirmed.ClientID%>").options[statusIndexAppName_conf].text;                    
          
          var statusIndex_StayConfirm=document.getElementById("<%=ddlApplicantStayConfirm.ClientID%>").selectedIndex;
          var status_StayConfirm=document.getElementById("<%=ddlApplicantStayConfirm.ClientID%>").options[statusIndex_StayConfirm].text;                    
          
          var statusIndex_ResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>").selectedIndex;
          var status_ResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>").options[statusIndex_ResiStatus].text;                    

          
          var statusIndex_FamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>").selectedIndex;
          var status_FamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>").options[statusIndex_FamilyMembers].text;                    
          
          var statusIndex_EaringFamily=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>").selectedIndex;
          var status_EaringFamily=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>").options[statusIndex_EaringFamily].text;                    
           
          //Added By Avinash Wankhede 23-Sept-2009  
          var statusIndex_VerifierRemarks1=document.getElementById("<%=ddlVerifierRemarks1.ClientID%>").selectedIndex;
          var status_VerifierRemarks1=document.getElementById("<%=ddlVerifierRemarks1.ClientID%>").options[statusIndex_VerifierRemarks1].text;                    
          
          var statusIndex_VerifierRemarks2=document.getElementById("<%=ddlVerifierRemarks2.ClientID%>").selectedIndex;
          var status_VerifierRemarks2=document.getElementById("<%=ddlVerifierRemarks2.ClientID%>").options[statusIndex_VerifierRemarks2].text;                    
         
         
          //End Here 23-Sept-2009  
           
                  
          var strYCR;
          
          var chk_YCR=document.getElementById("<%=chk_YCR.ClientID%>");
          var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
          var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");
          
          if (chk_YCR.checked==true)
          {
            strYCR="Not Conf";
          }
          else          
          {
           strYCR=txtYearsLivedAtResi_YY.value +':'+txtYearsLivedAtResi_MM.value ;
          }
           
          var statusIndex_TypeAcco=document.getElementById("<%=ddlTypeAcco.ClientID%>").selectedIndex;
          var status_TypeAcco=document.getElementById("<%=ddlTypeAcco.ClientID%>").options[statusIndex_TypeAcco].text;                    
          
          var statusIndex_EntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>").selectedIndex;
          var status_EntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>").options[statusIndex_EntryPermitted].text;                    
          
          var statusIndex_StandardOfLiving=document.getElementById("<%=ddlStandardOfLiving.ClientID%>").selectedIndex;
          var status_StandardOfLiving=document.getElementById("<%=ddlStandardOfLiving.ClientID%>").options[statusIndex_StandardOfLiving].text;                    

          var statusIndex_Exterior=document.getElementById("<%=ddlExteriorCondition.ClientID%>").selectedIndex;
          var status_Exterior=document.getElementById("<%=ddlExteriorCondition.ClientID%>").options[statusIndex_Exterior].text;                    
          
          var statusIndex_Locality=document.getElementById("<%=ddlLocality.ClientID%>").selectedIndex;
          var status_Locality=document.getElementById("<%=ddlLocality.ClientID%>").options[statusIndex_Locality].text;                    
         
          var statusIndex_TPC1_Name=document.getElementById("<%=ddlTPC1_Name.ClientID%>").selectedIndex;
          var status_TPC1_Name=document.getElementById("<%=ddlTPC1_Name.ClientID%>").options[statusIndex_TPC1_Name].text;                    
          var txtTPC1_Name=document.getElementById("<%=txtTPC1_Name.ClientID%>");
          
           var strTPC1_Name ;
          if (status_TPC1_Name=='Name')
          {
            strTPC1_Name=txtTPC1_Name.value;
          }
          else
          {
            strTPC1_Name=status_TPC1_Name;
          }
          var statusIndex_ByWHOM1=document.getElementById("<%=ddlTPC1_ByWHOM.ClientID%>").selectedIndex;
          var status_ByWHOM1=document.getElementById("<%=ddlTPC1_ByWHOM.ClientID%>").options[statusIndex_ByWHOM1].text;                    
          
          var txtTPC1_Address=document.getElementById("<%=txtTPC1_Address.ClientID%>");
          var statusIndex_AppNameConf1=document.getElementById("<%=ddlTPC1_AppNameConfirmed.ClientID%>").selectedIndex;
          var status_AppNameConf1=document.getElementById("<%=ddlTPC1_AppNameConfirmed.ClientID%>").options[statusIndex_AppNameConf1].text;                    
          
          var statusIndex_AppStayConf1=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>").selectedIndex;
          var status_AppStayConf1=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>").options[statusIndex_AppStayConf1].text;                    
        
          var strTPC1_AppYCR;          
          var chkTPC1_AppYCR=document.getElementById("<%=chkTPC1_AppYCR.ClientID%>");
          var txtTPC1_AppYCR_YY=document.getElementById("<%=txtTPC1_AppYCR_YY.ClientID%>");
          var txtTPC1_AppYCR_MM=document.getElementById("<%=txtTPC1_AppYCR_MM.ClientID%>");
           
            if (chkTPC1_AppYCR.checked==true)
            {
               strTPC1_AppYCR='Not Conf';            
            }  
            else
            {
                strTPC1_AppYCR=txtTPC1_AppYCR_YY.value+':'+txtTPC1_AppYCR_MM.value
            }
            
                       
         var statusIndex_AppOwner1=document.getElementById("<%=ddlTCP1_AppOwnershipStatus.ClientID%>").selectedIndex;
         var status_AppOwner1=document.getElementById("<%=ddlTCP1_AppOwnershipStatus.ClientID%>").options[statusIndex_AppOwner1].text;                                    
              
        
          //-----------------------------------  TPC 2---------------------------------------------
         
          var statusIndex_TPC2_Name=document.getElementById("<%=ddlTPC2_Name.ClientID%>").selectedIndex;
          var status_TPC2_Name=document.getElementById("<%=ddlTPC2_Name.ClientID%>").options[statusIndex_TPC2_Name].text;                    
          var txtTPC2_Name=document.getElementById("<%=txtTPC2_Name.ClientID%>");
          
           var strTPC2_Name ;
          if (status_TPC2_Name=='Name')
          {
            strTPC2_Name=txtTPC2_Name.value;
          }
          else
          {
            strTPC2_Name=status_TPC2_Name;
          }
          
          var statusIndex_ByWHOM2=document.getElementById("<%=ddlTPC2_ByWhom.ClientID%>").selectedIndex;
          var status_ByWHOM2=document.getElementById("<%=ddlTPC2_ByWhom.ClientID%>").options[statusIndex_ByWHOM2].text;                             

          var txtTPC2_Address=document.getElementById("<%=txtTPC2_Address.ClientID%>");
          var statusIndex_AppNameConf2=document.getElementById("<%=ddlTPC2_AppNameConfirmed.ClientID%>").selectedIndex;
          var status_AppNameConf2=document.getElementById("<%=ddlTPC2_AppNameConfirmed.ClientID%>").options[statusIndex_AppNameConf2].text;                    
          
          var statusIndex_AppStayConf2=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>").selectedIndex;
          var status_AppStayConf2=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>").options[statusIndex_AppStayConf2].text;                    
        
          var strTPC2_AppYCR;          
          var chkTPC2_AppYCR=document.getElementById("<%=chkTPC2_AppYCR.ClientID%>");
          var txtTPC2_AppYCR_YY=document.getElementById("<%=txtTPC2_AppYCR_YY.ClientID%>");
          var txtTPC2_AppYCR_MM=document.getElementById("<%=txtTPC2_AppYCR_MM.ClientID%>");
           
            if (chkTPC2_AppYCR.checked==true)
            {
               strTPC2_AppYCR='Not Conf';            
            }  
            else
            {
                strTPC2_AppYCR=txtTPC2_AppYCR_YY.value+':'+txtTPC2_AppYCR_MM.value
            }
            
         var statusIndex_AppOwner2=document.getElementById("<%=ddlTCP2_AppOwnershipStatus.ClientID%>").selectedIndex;
         var status_AppOwner2=document.getElementById("<%=ddlTCP2_AppOwnershipStatus.ClientID%>").options[statusIndex_AppOwner2].text;                    
                      
         
          var strRemark='';
          var str_ApplicantName;
        
            if ((statusAppName=='Applicant')||(statusAppName=='Not Confirmed')||(statusAppName=='Not Possible'))
            {
                if (statusAppName=='Not Confirmed')
                {
                        str_ApplicantName='Name '+statusAppName;        
                }
                else
                {
                      str_ApplicantName=statusAppName;        
                }
            }
            else
            {
                str_ApplicantName=txtNameOfThePersonMet.value;
            }
           
            var statusIndex_AddConf=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
            var status_AddConf=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusIndex_AddConf].text;
            var txtAddressUpdation=document.getElementById("<%=txtAddressUpdation.ClientID%>");
            
            var statusIndex_Proof=document.getElementById("<%=ddlTypeOfProof.ClientID%>").selectedIndex;
            var status_Proof=document.getElementById("<%=ddlTypeOfProof.ClientID%>").options[statusIndex_Proof].text;                    
                  
            //ddlTypeOfIDProof
            //txtProofDetails
            
            if (status_AddConf=='Yes')
                {       
                        
                        strRemark='';    
                        if (status_VerifierRemarks1=='Untraceable')                        
                        {
                            if (status_VerifierRemarks2=='Contactable')
                                {
                                    strRemark=strRemark+'1ST VST UNTRACLE 2ND VST TRACD/' 
                                }
                        }
                        else if (status_VerifierRemarks1=='door Locked')                        
                        {
                            if (status_VerifierRemarks2=='Contactable')
                                {
                                    strRemark=strRemark+'1ST VST DOORLOCKD 2ND VST CONTD/' 
                                }
                        }
            
            
                        strRemark=strRemark+'MET-'+str_ApplicantName;
                        if (statusAppName!='Not Possible')
                        {
                            if (status_Relation=='Others')
                            {
                                var txtRelationship_Other=document.getElementById("<%=txtRelationship_Other.ClientID%>");          
                                status_Relation=status_Relation+ ":" +txtRelationship_Other.value;
                            }
                            strRemark=strRemark+'/REL-'+status_Relation;
                            
                            if (status_AddressConfirm=='Yes')
                            {
                                strRemark=strRemark+'/ADD CONF' ;
                            }
                            else
                            {
                               strRemark=strRemark+'/ADD NOT CONF' ;     
                            }
                            statusAppName_conf=statusAppName_conf.replace('Confirmed','Conf'); 
                            strRemark=strRemark+'/APP NM-'+ statusAppName_conf;
                            status_StayConfirm=status_StayConfirm.replace('onfirmed','onf');                             
                            strRemark=strRemark+'/STAY-'+ status_StayConfirm;
                            
                            if (status_Info=='No')
                            {
                                status_ResiStatus=status_ResiStatus.replace('Confirmed','Conf'); 
                                strRemark=strRemark+'/RESI STATUS-'+ status_ResiStatus;
                                strRemark=strRemark+'/FMLY MEM-'+ status_FamilyMembers;
                                strRemark=strRemark+'/EARN MEM-'+ status_EaringFamily;
                                strRemark=strRemark+'/YCR-'+ strYCR;
                            }
                            else
                            {
                               strRemark=strRemark+'/INFO REFUSD-'+ status_Info;
                            }
                            
                            
                        }
                        strRemark=strRemark+'/ACCO-'+ status_TypeAcco;                        
                        strRemark=strRemark+'/ENTY PERMD-'+ status_EntryPermitted;
                        
                          if (status_EntryPermitted=='Yes')    
                          {
                            strRemark=strRemark+'/SOL-'+ status_StandardOfLiving;            
                          }
                        strRemark=strRemark+'/EXT-'+ status_Exterior;
                        strRemark=strRemark+'/LOC-'+ status_Locality;
                        
                        strTPC1_Name=strTPC1_Name.replace('Provided','Provd');                                                  
                        strRemark=strRemark+'/TPC1-'+ strTPC1_Name;  
                        
                        if  (status_TPC1_Name!='Not Possible')                        
                        {                        
                        status_ByWHOM1=status_ByWHOM1.replace('Neighbour','Neigh');  
                        strRemark=strRemark+'/BY-'+ status_ByWHOM1;   
                        strRemark=strRemark+'/ADD-'+ txtTPC1_Address.value;  
                            
                        status_AppNameConf1=status_AppNameConf1.replace('confirmed','Conf');  
                        strRemark=strRemark+'/NAME-'+ status_AppNameConf1;
                         
                            if (status_AppNameConf1!='No such person')   
                                {
                        status_AppStayConf1=status_AppStayConf1.replace('onfirmed','onf'); 
                        strRemark=strRemark+'/STAY-'+ status_AppStayConf1;   
                        strRemark=strRemark+'/YCR-'+ strTPC1_AppYCR;   
                        strRemark=strRemark+'/OWNRSHP-'+ status_AppOwner1;
                                }
                        }                           
                        
                        strTPC2_Name=strTPC2_Name.replace('Provided','Provd');
                        strRemark=strRemark+'/TPC2-'+ strTPC2_Name;
                         if  (status_TPC2_Name!='Not Possible')                        
                        {  
                        
                        status_ByWHOM2=status_ByWHOM2.replace('Neighbour','Neigh');                     
                        strRemark=strRemark+'/BY-'+ status_ByWHOM2;   
                        strRemark=strRemark+'/ADD-'+ txtTPC2_Address.value;  
                        status_AppNameConf2=status_AppNameConf2.replace('Confirmed','Conf');  
                        strRemark=strRemark+'/NAME-'+ status_AppNameConf2;  
                            if (status_AppNameConf2!='No such person')   
                                { 
                                status_AppStayConf2=status_AppStayConf2.replace('onfirmed','onf'); 
                                strRemark=strRemark+'/STAY-'+ status_AppStayConf2;   
                                strRemark=strRemark+'/YCR-'+ strTPC2_AppYCR;   
                                strRemark=strRemark+'/OWNRSHP-'+ status_AppOwner2; 
                                }
                        }
                        if (status_AreaType!='')
                        { 
                            if (status_AreaType!='Acceptable')
                            {
                                    
                                strRemark=strRemark+'/AREA-'+ status_AreaType; 
                            }
                        }
                        if (status_Propreco=='Defaulter')
                        {
                            strRemark=strRemark+'/DEFLTR DTLS-'+ txtDefault.value; 
                        }
                        if(status_ADDUpdation=='Yes')
                        {   
                            strRemark=strRemark+'/ADD UPD-'+ txtAddressUpdation.value;          
                        } 
                        
                         if(status_Proof=='Yes')
                        {   
                            var statusIndex_IDProof=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>").selectedIndex;
                            var status_IDProof=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>").options[statusIndex_IDProof].text;                    
                            var txtProofDetails=document.getElementById("<%=txtProofDetails.ClientID%>");                    
             
                            if (txtProofDetails.value!='')
                            {
                                strRemark=strRemark+'/PROOF-'+ status_IDProof + ':'+txtProofDetails.value ;          
                            }
                            else
                            {
                                strRemark=strRemark+'/PROOF-'+ status_IDProof;
                            }
                        }  
                         
            }
            else
            {
                var statusIndex1=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").selectedIndex;
                var status1=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").options[statusIndex1].text;
        
             if (status1=="Mismatched")
                {
                    var txtWhomtheAddBelongsTo=document.getElementById("<%=txtWhomtheAddBelongsTo.ClientID%>");
                    strRemark='Add-'+status_AddressConfirm;
                    strRemark=strRemark+'/ADD-'+status1;
                    strRemark=strRemark+'/ADD BLNGS TO-'+txtWhomtheAddBelongsTo.value;
                    
                    strTPC1_Name=strTPC1_Name.replace('Provided','Provd');                                                                                         
                    
                    strRemark=strRemark+'/TPC1-'+ strTPC1_Name; 
                      
                    status_ByWHOM1=status_ByWHOM1.replace('Neighbour','Neigh'); 
                    strRemark=strRemark+'/BY-'+ status_ByWHOM1;   
                    
                    status_AppNameConf1=status_AppNameConf1.replace('onfirmed','onf');
                    strRemark=strRemark+'/NAME-'+ status_AppNameConf1;   
                    
                    status_AppStayConf1=status_AppStayConf1.replace('onfirmed','onf'); 
                    strRemark=strRemark+'/STAY-'+ status_AppStayConf1;   
                    
                    strRemark=strRemark+'/ADD-'+ txtTPC1_Address.value;   
                  }
                else if (status1=="Untraceable")
                {
                 
                     var txtResultOfCalling=document.getElementById("<%=txtResultOfCalling.ClientID%>");                  
                     if (status_AddressConfirm=='Yes')
                     {
                        strRemark='/ADD CONF';
                     }
                     else
                     {
                        strRemark='/ADD NOT CONF';
                     }
                     
                     strRemark=strRemark+'/ADD-'+status1;
                     strRemark=strRemark+'/RESLT OF CALING-'+txtResultOfCalling.value;                      
                } 
            }          
               
            //debugger;          
            strRemark=strRemark.replace('Neighbour','Neigh');
            strRemark=strRemark.replace('onfirmed','onf');             
             
            var Label4=document.getElementById("<%=Label4.ClientID%>");  
            Label4.innerText=strRemark.length;                
            txtVerifierRemark.value=strRemark ;
            CountLength();
            
        }
   
    function Enable_Validation_On_TPC1_Application_Stay_Confirmed()
    {
          var statusIndex=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>").options[statusIndex].text;          
          
          var ddlTCP1_AppOwnershipStatus=document.getElementById("<%=ddlTCP1_AppOwnershipStatus.ClientID%>");
          var chkTPC1_AppYCR=document.getElementById("<%=chkTPC1_AppYCR.ClientID%>");          
          var txtTPC1_AppYCR_YY=document.getElementById("<%=txtTPC1_AppYCR_YY.ClientID%>");
          var txtTPC1_AppYCR_MM=document.getElementById("<%=txtTPC1_AppYCR_MM.ClientID%>");
          var value=false;
          
          if ((status=="Shifted")||(status=="Owned but given on rent")||(status=="Comes here rarely"))
          {
             value=true;                
                ddlTCP1_AppOwnershipStatus.selectedIndex=0;
                chkTPC1_AppYCR.checked=true;
              }
          else
              {
                chkTPC1_AppYCR.checked=false;
              }
              
          ddlTCP1_AppOwnershipStatus.disabled=value;             
          chkTPC1_AppYCR.disabled=value;          
          Enabled_Validation_YY_MM(chkTPC1_AppYCR,true,null,txtTPC1_AppYCR_YY,txtTPC1_AppYCR_MM);            
          
    }
    
     function Enable_Validation_On_TPC2_Application_Stay_Confirmed()
    {
          var statusIndex=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>").options[statusIndex].text;          
          
          var ddlTCP2_AppOwnershipStatus=document.getElementById("<%=ddlTCP2_AppOwnershipStatus.ClientID%>");
          var chkTPC2_AppYCR=document.getElementById("<%=chkTPC2_AppYCR.ClientID%>");          
          var txtTPC2_AppYCR_YY=document.getElementById("<%=txtTPC2_AppYCR_YY.ClientID%>");
          var txtTPC2_AppYCR_MM=document.getElementById("<%=txtTPC2_AppYCR_MM.ClientID%>");
          var value=false;
          
          if ((status=="Shifted")||(status=="Owned but given on rent")||(status=="Comes here rarely"))
          {
             value=true;                
                ddlTCP2_AppOwnershipStatus.selectedIndex=0;
                chkTPC2_AppYCR.checked=true;
              }
          else
              {
                chkTPC2_AppYCR.checked=false;
              }
              
          ddlTCP2_AppOwnershipStatus.disabled=value;             
          chkTPC2_AppYCR.disabled=value;          
          Enabled_Validation_YY_MM(chkTPC2_AppYCR,true,null,txtTPC2_AppYCR_YY,txtTPC2_AppYCR_MM);            
          
    }   
    
    
      function Enable_Validation_on_AddConfirm()
       {                    
            var statusIndex=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusIndex].text;
          
            var ddlAddConfBy=document.getElementById("<%=ddlAddConfBy.ClientID%>");
            var ddlNameOfPersonMet=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>");
            var ddlEntryPermitted=document.getElementById("<%=ddlEntryPermitted.ClientID%>");
            var ddlExteriorCondition=document.getElementById("<%=ddlExteriorCondition.ClientID%>");                    
            var ddlLocality=document.getElementById("<%=ddlLocality.ClientID%>");
            var ddlAreaType=document.getElementById("<%=ddlAreaType.ClientID%>");
            var ddlTypeAcco=document.getElementById("<%=ddlTypeAcco.ClientID%>");                    
            var ddlEaseOfLocatingHouse=document.getElementById("<%=ddlEaseOfLocatingHouse.ClientID%>");
            var ddlAreaOfHouse=document.getElementById("<%=ddlAreaOfHouse.ClientID%>");                   
            var ddlDirectory_Check=document.getElementById("<%=ddlDirectory_Check.ClientID%>");                    
            var txtLandmark=document.getElementById("<%=txtLandmark.ClientID%>");
            var ddlAddressUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>");
            var txtAddressUpdation=document.getElementById("<%=txtAddressUpdation.ClientID%>");
                    
             
          var value=false;
          
          if (status=="No")
            {
              var value=true;
                ddlAddConfBy.selectedIndex=0;
                ddlNameOfPersonMet.selectedIndex=3;
                ddlEntryPermitted.selectedIndex=0;
                ddlExteriorCondition.selectedIndex=0; 
                ddlAreaType.selectedIndex=0; 
                ddlTypeAcco.selectedIndex=0; 
                ddlEaseOfLocatingHouse.selectedIndex=0; 
                ddlAreaOfHouse.selectedIndex=0; 
                ddlDirectory_Check.selectedIndex=0; 
                ddlLocality.selectedIndex=0; 
                txtLandmark.value="";  
                ddlAddressUpdation.selectedIndex=0; 
                txtAddressUpdation.value="";  
            }
            else 
            {
                //ddlNameOfPersonMet.selectedIndex=0; 
            } 
             txtAddressUpdation.disabled=value; 
             ddlAddressUpdation.disabled=value; 
             ddlAreaType.disabled=value;  
             ddlTypeAcco.disabled=value;  
             ddlEaseOfLocatingHouse.disabled=value;  
             ddlAreaOfHouse.disabled=value;  
             ddlDirectory_Check.disabled=value;              
             ddlLocality.disabled=value;  
             txtLandmark.disabled=value;  
            ddlExteriorCondition.disabled=value;      
            ddlEntryPermitted.disabled=value;          
            ddlAddConfBy.disabled=value;
            ddlNameOfPersonMet.disabled=value;
            Enabled_Validation_PersonMet();
            Enable_Validation_on_EntryPermitted();
            Validation_on_Panel_Enabled_Disabled();
       }
    
    
    function Enable_Validation_On_TPC1_Application_Name_Confirmed()    
    {
   
          var statusIndex=document.getElementById("<%=ddlTPC1_AppNameConfirmed.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlTPC1_AppNameConfirmed.ClientID%>").options[statusIndex].text;
          var ddlTPC1_AppStayConfirmed=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>");
          var ddlTCP1_AppOwnershipStatus=document.getElementById("<%=ddlTCP1_AppOwnershipStatus.ClientID%>");
         
          var chkTPC1_AppYCR=document.getElementById("<%=chkTPC1_AppYCR.ClientID%>");
          var txtTPC1_AppYCR_YY=document.getElementById("<%=txtTPC1_AppYCR_YY.ClientID%>");
          var txtTPC1_AppYCR_MM=document.getElementById("<%=txtTPC1_AppYCR_MM.ClientID%>");
          
          
          var value=false;
          if (status=="No such person")
              {
                  value=true; 
                  ddlTPC1_AppStayConfirmed.selectedIndex=0;
                  ddlTCP1_AppOwnershipStatus.selectedIndex=0;
                  chkTPC1_AppYCR.checked=true;
              }
          else
              {
                chkTPC1_AppYCR.checked=false;
              }
          ddlTPC1_AppStayConfirmed.disabled=value;
          ddlTCP1_AppOwnershipStatus.disabled=value;  
          
          chkTPC1_AppYCR.disabled=value;          
          Enabled_Validation_YY_MM(chkTPC1_AppYCR,true,null,txtTPC1_AppYCR_YY,txtTPC1_AppYCR_MM);            
          
    }
    
    function Enable_Validation_On_TPC2_Application_Name_Confirmed()    
    {
   
          var statusIndex=document.getElementById("<%=ddlTPC2_AppNameConfirmed.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlTPC2_AppNameConfirmed.ClientID%>").options[statusIndex].text;
          var ddlTPC2_AppStayConfirmed=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>");
          var ddlTCP2_AppOwnershipStatus=document.getElementById("<%=ddlTCP2_AppOwnershipStatus.ClientID%>");
         
          var chkTPC2_AppYCR=document.getElementById("<%=chkTPC2_AppYCR.ClientID%>");
          var txtTPC2_AppYCR_YY=document.getElementById("<%=txtTPC2_AppYCR_YY.ClientID%>");
          var txtTPC2_AppYCR_MM=document.getElementById("<%=txtTPC2_AppYCR_MM.ClientID%>");
         
          var value=false;
          if (status=="No such person")
              {
                  value=true; 
                  ddlTPC2_AppStayConfirmed.selectedIndex=0;
                  ddlTCP2_AppOwnershipStatus.selectedIndex=0;
                  chkTPC2_AppYCR.checked=true;
              }
          else
              {
                chkTPC2_AppYCR.checked=false;
              }
          
          ddlTPC2_AppStayConfirmed.disabled=value;
          ddlTCP2_AppOwnershipStatus.disabled=value;  
          
          chkTPC2_AppYCR.disabled=value;
          Enabled_Validation_YY_MM(chkTPC2_AppYCR,true,null,txtTPC2_AppYCR_YY,txtTPC2_AppYCR_MM);            
          
    }
    
    function Validation_on_Panel_Enabled_Disabled()
    {
            //debugger;
             var pnlAddnotConfirmed=document.getElementById("<%=pnlAddnotConfirmed.ClientID%>");
             var statusIndex=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
             var status=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusIndex].text;
          
             if (status=='No')
             {
                    pnlAddnotConfirmed.style.visibility="visible"; 
             }
             else
             {
                pnlAddnotConfirmed.style.visibility="hidden"; 
             }
             
            
        
    } 
    
    function Page_Load_Validation()
    {
  
       //For Proof Validation
       Enable_Validation_on_Proof();
       
       //Company Details Validations
       Enabled_Validation_CompanyDetails();
       
       //For Entry Permitted Validation
       Enable_Validation_on_EntryPermitted();
       
       //For TPC1 Name Validation
       Enable_Validation_On_TPC1_Name();
       
       //For Address Updation Validation
       Enable_Validation_On_AddressUpdation();
       
     
       //debugger;
       var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
       var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
       var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
       var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");           
       Enabled_Validation_YY_MM( chkApplicant_DOBAGE_NotConf,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM);
        
       //For Person Met Validation        
       Enabled_Validation_PersonMet();
        
      //For Address Confirmation 
      Enable_Validation_on_AddConfirm();
      
       var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
       var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
       var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
       var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");           
       Enabled_Validation_YY_MM( chkApplicant_DOBAGE_NotConf,true,txtApplicantAge_DOB,txtApplicantAge_DOB_YY,txtApplicantAge_DOB_MM);
      
       //For YCR 
       var chk_YCR=document.getElementById("<%=chk_YCR.ClientID%>");
       var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
       var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");      
       Enabled_Validation_YY_MM( chk_YCR,true,null,txtYearsLivedAtResi_YY,txtYearsLivedAtResi_MM);
      
       //For YCE
       var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
       var txtYrsInEMP_YY=document.getElementById("<%=txtYrsInEMP_YY.ClientID%>");
       var txtYrsInEMP_MM=document.getElementById("<%=txtYrsInEMP_MM.ClientID%>");       
       Enabled_Validation_YY_MM( chk_YCE,true,null,txtYrsInEMP_YY,txtYrsInEMP_MM);
       
       
       //For TPC YCR
       var chkTPC1_AppYCR=document.getElementById("<%=chkTPC1_AppYCR.ClientID%>");
       var txtTPC1_AppYCR_YY=document.getElementById("<%=txtTPC1_AppYCR_YY.ClientID%>");
       var txtTPC1_AppYCR_MM=document.getElementById("<%=txtTPC1_AppYCR_MM.ClientID%>");       
       Enabled_Validation_YY_MM( chkTPC1_AppYCR,true,null,txtTPC1_AppYCR_YY,txtTPC1_AppYCR_MM);
       Validation_on_Panel_Enabled_Disabled();
       
    }
    
    
   function Enable_Validation_On_TPC2_Name()
   {
                var statusIndex=document.getElementById("<%=ddlTPC2_Name.ClientID%>").selectedIndex;
                var status=document.getElementById("<%=ddlTPC2_Name.ClientID%>").options[statusIndex].text;
                var txtTPC2_Name=document.getElementById("<%=txtTPC2_Name.ClientID%>");
                var ddlTPC2_ByWhom=document.getElementById("<%=ddlTPC2_ByWhom.ClientID%>");
                var txtTPC2_Address=document.getElementById("<%=txtTPC2_Address.ClientID%>");
                var txtTPC2_AppHomeConfirm=document.getElementById("<%=txtTPC2_AppHomeConfirm.ClientID%>");
                
                var ddlTPC2_AppStayConfirmed=document.getElementById("<%=ddlTPC2_AppStayConfirmed.ClientID%>");
                
                var ddlTCP2_AppOwnershipStatus=document.getElementById("<%=ddlTCP2_AppOwnershipStatus.ClientID%>");
                var ddlTPC2_AppNameConfirmed=document.getElementById("<%=ddlTPC2_AppNameConfirmed.ClientID%>");
                   
                var chkTPC2_AppYCR=document.getElementById("<%=chkTPC2_AppYCR.ClientID%>");
                var txtTPC2_AppYCR_YY=document.getElementById("<%=txtTPC2_AppYCR_YY.ClientID%>");
                var txtTPC2_AppYCR_MM=document.getElementById("<%=txtTPC2_AppYCR_MM.ClientID%>");
                
                
                
                if (status=="Name")
                {     
                    txtTPC2_Name.disabled=false;
                    ddlTPC2_ByWhom.disabled=false;   
                    txtTPC2_Address.disabled=false;
                    txtTPC2_AppHomeConfirm.disabled=false;
                    ddlTPC2_AppStayConfirmed.disabled=false;                    
                    ddlTCP2_AppOwnershipStatus.disabled=false;      
                    ddlTPC2_AppNameConfirmed.disabled=false; 
                    chkTPC2_AppYCR.checked=false;                  
                    chkTPC2_AppYCR.disabled=false; 
                    
                   }
                else if (status=="Not Possible")
                {
                     txtTPC2_Name.disabled=true;
                     txtTPC2_Address.disabled=true;
                     txtTPC2_AppHomeConfirm.disabled=true;                     
                     ddlTPC2_AppStayConfirmed.disabled=true;
                    
                     ddlTCP2_AppOwnershipStatus.disabled=true;                             
                     ddlTPC2_AppNameConfirmed.disabled=true;    
                     ddlTPC2_ByWhom.disabled=true;   
                    
                     txtTPC2_Name.value="";     
                     txtTPC2_Address.value="";
                     txtTPC2_AppHomeConfirm.value="";
                     
                     ddlTPC2_AppStayConfirmed.selectedIndex=2;
                      
                     ddlTCP2_AppOwnershipStatus.selectedIndex=8;
                     ddlTPC2_AppNameConfirmed.selectedIndex=2;
                     ddlTPC2_ByWhom.selectedIndex=0;
                     chkTPC2_AppYCR.checked=true;                 
                    
                     chkTPC2_AppYCR.disabled=true; 
                     
                         
                }
                else if(status=="Not Provided")
                {
                    txtTPC2_Name.disabled=true;
                    ddlTPC2_ByWhom.disabled=false;   
                    txtTPC2_Address.disabled=false;
                    txtTPC2_AppHomeConfirm.disabled=false;
                    ddlTPC2_AppStayConfirmed.disabled=false;                    
                    ddlTCP2_AppOwnershipStatus.disabled=false;      
                    ddlTPC2_AppNameConfirmed.disabled=false;  
                    chkTPC2_AppYCR.checked=false;    
                    chkTPC2_AppYCR.disabled=false; 
                }
                
            Enabled_Validation_YY_MM(chkTPC2_AppYCR,true,null,txtTPC2_AppYCR_YY,txtTPC2_AppYCR_MM);
           
   }
    
    
    
    
    function Enabled_Validation_CompanyDetails()
    {
        var statusIndex=document.getElementById("<%=ddlCompanyDetails.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlCompanyDetails.ClientID%>").options[statusIndex].text;
        
        var txtCompanyName=document.getElementById("<%=txtCompanyName.ClientID%>") ;
        var txtOfficeAdd=document.getElementById("<%=txtOfficeAdd.ClientID%>") ;
        var txtDesignation=document.getElementById("<%=txtDesignation.ClientID%>") ;
        var txtOfficePhone=document.getElementById("<%=txtOfficePhone.ClientID%>") ;        
        var txtResiPhone=document.getElementById("<%=txtResiPhone.ClientID%>") ;
        var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>") ;
        var txtYrsInEMP_YY=document.getElementById("<%=txtYrsInEMP_YY.ClientID%>") ;        
        var txtYrsInEMP_MM=document.getElementById("<%=txtYrsInEMP_MM.ClientID%>") ;
        var txtDepartMent=document.getElementById("<%=txtDepartMent.ClientID%>") ;
         
        
        var value=false;
       if (status=="No")
       {    
            value=true;
            txtCompanyName.value="";
            txtOfficeAdd.value="";
            txtDesignation.value="";
            txtOfficePhone.value="";
            txtResiPhone.value="";
            chk_YCE.checked=false;
            txtYrsInEMP_YY.value="";
            txtYrsInEMP_MM.disabled=value;
            txtDepartMent.value="";
            
          
       }
       
        
       txtCompanyName.disabled=value;
       txtOfficeAdd.disabled=value;
       txtDesignation.disabled=value;
       txtOfficePhone.disabled=value;
       txtResiPhone.disabled=value;
       chk_YCE.disabled=value;
       txtYrsInEMP_YY.disabled=value;
       txtYrsInEMP_MM.disabled=value;
       txtDepartMent.disabled=value;
       
    }
    
    
    function Enabled_Validation_YY_MM(ChkboxId,ChkValue,Control_DOBID,Control_YYID,Control_MMID)
    {
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
    

//  function Enabled_Validation_YY_MM(ChkboxId,ChkValue,Control_DOBID,Control_YYID,Control_MMID)
//    {
//            var value=false;
//            if (ChkboxId.checked==ChkValue)
//            {     
//                value=true;       
//                Control_YYID.value="";
//                Control_MMID.value="";
//                
//                
//                            
//            }       

//                Control_YYID.disabled=value;
//                Control_MMID.disabled=value;
//                
//            if (Control_DOBID!=null)
//            { 
//                debugger;
//                Control_DOBID.disabled=value;
//                Control_DOBID.value="";
//                var img1=document.getElementById("img1");
//                if (img1!=null)
//                {
//                img1.disabled=value;
//                }
//            }
//        
//        
//    
//    }

    function Enabled_Validation_PersonMet()
    {        
        var statusIndex=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>").options[statusIndex].text;
        var txtNameOfThePersonMet=document.getElementById("<%=txtNameOfThePersonMet.ClientID%>") ;
        var ddlRelationShipWithApp=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>") ;
        var ddl_InfoRefused=document.getElementById("<%=ddl_InfoRefused.ClientID%>") ;      
        var ddlApplicantNameConfirmed=document.getElementById("<%=ddlApplicantNameConfirmed.ClientID%>") ;      
        var ddlCompanyDetails=document.getElementById("<%=ddlCompanyDetails.ClientID%>");
        
        var value=false;
        var valueNotConfirmed=false;
        if (status=="Applicant")
        {
            value=true;
            valueNotConfirmed=true;
            txtNameOfThePersonMet.value="";            
            ddlRelationShipWithApp.selectedIndex=1;
            ddlApplicantNameConfirmed.selectedIndex=1;
        }   
        else if (status=="Not Possible")
        {
            value=true;
            valueNotConfirmed=true;
            ddl_InfoRefused.selectedIndex=1;
            ddl_InfoRefused.disabled=value;
            ddlApplicantNameConfirmed.selectedIndex=2;    
        
        } 
        else if (status=="Not Confirmed")
        {
            valueNotConfirmed=true;
            txtNameOfThePersonMet.value="";
            ddl_InfoRefused.disabled=value;  
        }      
        else 
        {
             ddl_InfoRefused.disabled=value;
             
        }
                
        txtNameOfThePersonMet.disabled=valueNotConfirmed;
        ddlApplicantNameConfirmed.disabled=value;
        ddlRelationShipWithApp.disabled=value;
        Enable_Validation_on_InfoRefused();
    }
    
    
    
     function Enable_Validation_Confirmed(MainControlId,MainValue,ActionToTake,ControlIdToComp,ControlType)
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
        
    
    
    
    
    function Enable_Validation_Final_Submit()
    {

        
        var ReturnValue=true;
        var ErrorMessage="";
        var statusIndex=document.getElementById("<%=ddlAddressConfirm.ClientID%>").selectedIndex;
        var status=document.getElementById("<%=ddlAddressConfirm.ClientID%>").options[statusIndex].text;
        var ValidationSummary1=document.getElementById("<%=ValidationSummary1.ClientID%>");
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        
        var ddlProprietor_recomm=document.getElementById("<%=ddlProprietor_recomm.ClientID%>");
        var statusIndex_Pro=ddlProprietor_recomm.selectedIndex;
        var status_Pro=ddlProprietor_recomm.options[statusIndex_Pro].text;
        
        var statusIndex_Rel=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>").selectedIndex;
        var status_Rel=document.getElementById("<%=ddlRelationShipWithApp.ClientID%>").options[statusIndex_Rel].text;
        
                             
        
            
        if (status=="No") 
        {        
        var statusIndex1=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").selectedIndex;
        var status1=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").options[statusIndex1].text;
       
             if (status1=="")
             {
                ReturnValue=false;
                ErrorMessage="Please Select the Address Not Confirmed Reason!";
             }
             else
             {
                if (status1=="Mismatched")
                {
                  var txtWhomtheAddBelongsTo=document.getElementById("<%=txtWhomtheAddBelongsTo.ClientID%>");
                  if (txtWhomtheAddBelongsTo.value=="")  
                  {
                   ReturnValue=false;
                   ErrorMessage="Whom this Add Belong is cannot be left blank!";
                  }
                    
                }
                else if (status1=="Untraceable")
                {
                  var txtResultOfCalling=document.getElementById("<%=txtResultOfCalling.ClientID%>");
                    if (txtResultOfCalling.value=="")  
                  {
                   ReturnValue=false;
                   ErrorMessage="Result of Calling is cannot be left blank!";
                  }        
                }                                             
             } 
             
           
       
       
    } 
         
         var statusIndexProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>").selectedIndex;
                var statusProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>").options[statusIndexProof].text;
                
                var statusIndexProofID=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>").selectedIndex;
                var statusProofId=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>").options[statusIndexProofID].text;
                
                
                var txtAddressUpdation=document.getElementById("<%=txtAddressUpdation.ClientID%>");
                if ((statusProof=="Yes")&& (statusProofId==""))
                {
                
                ReturnValue=false;
                ErrorMessage="Please select Valid proofID!";

                }
                
            var statusIndexUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").selectedIndex;
            var statusUpdation=document.getElementById("<%=ddlAddressUpdation.ClientID%>").options[statusIndexUpdation].text;
            var txtAddressUpdation=document.getElementById("<%=txtAddressUpdation.ClientID%>");
                if ((statusUpdation=="Yes")&& (txtAddressUpdation.value==""))
                  {
                    txtAddressUpdation.focus();
                    ReturnValue=false;
                    ErrorMessage="Correct Address is cannot be left blank!";
                    
                  }
        
          if (status_Pro=="")
            {
                ddlProprietor_recomm.focus();
                ReturnValue=false;
                ErrorMessage="Please Select Prorietor Recommendation!"; 
            }            
            
          if (status_Rel=='Others')
          {
             var txtRelationship_Other=document.getElementById("<%=txtRelationship_Other.ClientID%>");          
                if (txtRelationship_Other.value=='')
                {
                    txtRelationship_Other.focus();
                     ReturnValue=false;
                     ErrorMessage="Other Relationship can not be left blank!";                      
                }          
          }    
 
         if (status=='Yes')
         {
                     if (!Enable_Validation_On_Dropdown('ddlAddConfBy',0))            
                        {
                            ErrorMessage="Please check Mandatory fields: Address Confirmed By !";
                            ReturnValue=false;                                
                        }
                        
                        if (!Enable_Validation_On_Dropdown('ddl_InfoRefused',0))            
                        {   
                            ErrorMessage="Please check Mandatory fields:Information Refused !";
                            ReturnValue=false;                                
                        } 
                        
                        if (!Enable_Validation_On_Dropdown('ddlApplicantNameConfirmed',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Applicant Name Confirmed!";              
                            ReturnValue=false;                                
                        } 
                        
                         if (!Enable_Validation_On_Dropdown('ddlApplicantStayConfirm',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Applicant Stay Confirm!";                            
                            ReturnValue=false;                                
                        } 
                         if (!Enable_Validation_On_Dropdown('ddlResiStatus',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Resi Status!";              
                            ReturnValue=false;                                
                        } 
                        
                        if (!Enable_Validation_On_Dropdown('ddlNoOfFamilyMembers',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:No Of Family Members!";                          
                            ReturnValue=false;                                
                        } 
                        
                         if (!Enable_Validation_On_Dropdown('ddlEaringFamilyMembers',0))            
                        {   
                            ErrorMessage="Please check Mandatory fields:Earing Family Members!";     
                            ReturnValue=false;                                
                        } 
                         if (!Enable_Validation_On_Dropdown('ddlTypeOfProof',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Type Of Proof!";                   
                            ReturnValue=false;                                
                        }
                        
                         if (!Enable_Validation_On_Dropdown('ddlCompanyDetails',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Company Details!";      
                            ReturnValue=false;                                
                        }
                        
                        if (!Enable_Validation_On_Dropdown('ddlEntryPermitted',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Entry Permitted!";     
                            ReturnValue=false;                                
                        }
                        if (!Enable_Validation_On_Dropdown('ddlTypeAcco',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Type of Accommodation!";     
                            ReturnValue=false;                                
                        }  
                        if (!Enable_Validation_On_Dropdown('ddlAddressUpdation',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:Address Updation!";  
                            ReturnValue=false;                                
                        }  
                         if (!Enable_Validation_On_Dropdown('ddlTPC1_Name',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:TPC 1 Name!";  
                            ReturnValue=false;                                
                        } 
                           if (!Enable_Validation_On_Dropdown('ddlTPC1_AppNameConfirmed',0))            
                        {
                            
                            ErrorMessage="Please check Mandatory fields:TPC 1 Applicant Name Confirmed!";  
                            ReturnValue=false;                                
                        } 
                            if (!Enable_Validation_On_Dropdown('ddlTPC1_AppStayConfirmed',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:TPC 1 Applicant Stay Confirmed!";  
                            ReturnValue=false;                                
                        } 
                            if (!Enable_Validation_On_Dropdown('ddlTCP1_AppOwnershipStatus',0))            
                        {
                            ErrorMessage="Please check Mandatory fields:TPC 1 Applicant Stay Confirmed!";                    
                            ReturnValue=false;                                
                        } 
                    
                        if (!Enable_Validation_On_Dropdown('ddlTPC2_Name',0))            
                        {                
                            ErrorMessage="Please check Mandatory fields:TPC 2 Name!";      
                            ReturnValue=false;                                
                        } 
                        
                         if (!Enable_Validation_On_Dropdown('ddlTPC2_AppStayConfirmed',0))            
                        {                
                            ErrorMessage="Please check Mandatory fields:TPC2 Applicant Stay Confirmed!"; 
                            ReturnValue=false;                                
                        } 
                         if (!Enable_Validation_On_Dropdown('ddlTPC2_AppNameConfirmed',0))            
                        {                
                            ErrorMessage="Please check Mandatory fields:TPC2 Applicant Name Confirmed!"; 
                            ReturnValue=false;                                
                        } 
            
           }  
            
            
        if (ErrorMessage!="")
           {         
               //debugger;            
               //ValidationSummary1.style.cssText="COLOR: red";
               //ValidationSummary1.innerText=ErrorMessage;                     
               lblMessage.innerText=ErrorMessage;                    
           }
           else
           {
            lblMessage.innerText="";    
           }
            
        window.scrollTo(0,0);
        return ReturnValue;    
    } 
    
    function Enable_Validation_On_Mandatory_Fields()
    {
        var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");          
        var ErrorMessage="";    
        var ReturnValue=true;
         
           
            
         lblMessage.innerText=ErrorMessage;    
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
    function Enable_Validation_On_AddressUpdation()
    {
          var statusIndex=document.getElementById("<%=ddlAddressUpdation.ClientID%>").selectedIndex;
          var status=document.getElementById("<%=ddlAddressUpdation.ClientID%>").options[statusIndex].text;
          var txtAddressUpdation=document.getElementById("<%=txtAddressUpdation.ClientID%>");    
          var value=false;
                if (status=="No")
                {
                     value=true;  
                     txtAddressUpdation.value="";      
                }
                 
               txtAddressUpdation.disabled=value;
   
    
    }
    
        function Enable_Validation_On_TPC1_Name()
        {
                var statusIndex=document.getElementById("<%=ddlTPC1_Name.ClientID%>").selectedIndex;
                var status=document.getElementById("<%=ddlTPC1_Name.ClientID%>").options[statusIndex].text;
                var txtTPC1_Name=document.getElementById("<%=txtTPC1_Name.ClientID%>");
                var ddlTPC1_ByWHOM=document.getElementById("<%=ddlTPC1_ByWHOM.ClientID%>");
                var txtTPC1_Address=document.getElementById("<%=txtTPC1_Address.ClientID%>");
                var txtTPC1_AppHomeConfirm=document.getElementById("<%=txtTPC1_AppHomeConfirm.ClientID%>");
                
                var ddlTPC1_AppStayConfirmed=document.getElementById("<%=ddlTPC1_AppStayConfirmed.ClientID%>");
                
                var ddlTCP1_AppOwnershipStatus=document.getElementById("<%=ddlTCP1_AppOwnershipStatus.ClientID%>");
                var ddlTPC1_AppNameConfirmed=document.getElementById("<%=ddlTPC1_AppNameConfirmed.ClientID%>");
                   
                var chkTPC1_AppYCR=document.getElementById("<%=chkTPC1_AppYCR.ClientID%>");
                var txtTPC1_AppYCR_YY=document.getElementById("<%=txtTPC1_AppYCR_YY.ClientID%>");
                var txtTPC1_AppYCR_MM=document.getElementById("<%=txtTPC1_AppYCR_MM.ClientID%>");
                   
                if (status=="Name")
                {     
                    txtTPC1_Name.disabled=false;
                    ddlTPC1_ByWHOM.disabled=false;   
                    txtTPC1_Address.disabled=false;
                    txtTPC1_AppHomeConfirm.disabled=false;
                    ddlTPC1_AppStayConfirmed.disabled=false;
                    
                    ddlTCP1_AppOwnershipStatus.disabled=false;      
                    ddlTPC1_AppNameConfirmed.disabled=false;  
                    
                    chkTPC1_AppYCR.checked=false;                  
                    chkTPC1_AppYCR.disabled=false; 
                   }
                else if (status=="Not Possible")
                {
                     txtTPC1_Name.disabled=true;
                     txtTPC1_Address.disabled=true;
                     txtTPC1_AppHomeConfirm.disabled=true;                     
                     ddlTPC1_AppStayConfirmed.disabled=true;
                    
                     ddlTCP1_AppOwnershipStatus.disabled=true;                             
                     ddlTPC1_AppNameConfirmed.disabled=true;    
                     ddlTPC1_ByWHOM.disabled=true;   
                    
                     txtTPC1_Name.value="";     
                     txtTPC1_Address.value="";
                     txtTPC1_AppHomeConfirm.value="";
                     
                     ddlTPC1_AppStayConfirmed.selectedIndex=2;
                      
                     ddlTCP1_AppOwnershipStatus.selectedIndex=8;
                     ddlTPC1_AppNameConfirmed.selectedIndex=2;
                     ddlTPC1_ByWHOM.selectedIndex=0;
                     chkTPC1_AppYCR.checked=true;               
                    
                     chkTPC1_AppYCR.disabled=true; 
                     
                         
                }
                else if(status=="Not Provided")
                {
                    txtTPC1_Name.disabled=true;
                    ddlTPC1_ByWHOM.disabled=false;   
                    txtTPC1_Address.disabled=false;
                    txtTPC1_AppHomeConfirm.disabled=false;
                    ddlTPC1_AppStayConfirmed.disabled=false;
                    
                    ddlTCP1_AppOwnershipStatus.disabled=false;      
                    ddlTPC1_AppNameConfirmed.disabled=false;  
                     chkTPC1_AppYCR.checked=false;    
                    chkTPC1_AppYCR.disabled=false; 
                }
                
                
             Enabled_Validation_YY_MM(chkTPC1_AppYCR,true,null,txtTPC1_AppYCR_YY,txtTPC1_AppYCR_MM);
               
        
        }
    
    
    
    
        function Enable_Validation_on_InfoRefused()
        {
          
           //debugger;
                var statusIndex=document.getElementById("<%=ddl_InfoRefused.ClientID%>").selectedIndex;
                var status=document.getElementById("<%=ddl_InfoRefused.ClientID%>").options[statusIndex].text;
                var txtApplicantAge_DOB=document.getElementById("<%=txtApplicantAge_DOB.ClientID%>");
                var txtApplicantAge_DOB_YY=document.getElementById("<%=txtApplicantAge_DOB_YY.ClientID%>");
                var txtApplicantAge_DOB_MM=document.getElementById("<%=txtApplicantAge_DOB_MM.ClientID%>");                
                var ddlEaringFamilyMembers=document.getElementById("<%=ddlEaringFamilyMembers.ClientID%>");
                var ddlNoOfFamilyMembers=document.getElementById("<%=ddlNoOfFamilyMembers.ClientID%>");
                var txtYearsLivedAtResi_YY=document.getElementById("<%=txtYearsLivedAtResi_YY.ClientID%>");
                var txtYearsLivedAtResi_MM=document.getElementById("<%=txtYearsLivedAtResi_MM.ClientID%>");
                var ddlResiStatus=document.getElementById("<%=ddlResiStatus.ClientID%>");
                var txtPermenantAddress=document.getElementById("<%=txtPermenantAddress.ClientID%>");
                var txtPermenantNo=document.getElementById("<%=txtPermenantNo.ClientID%>");
                var ddlApplicantStayConfirm=document.getElementById("<%=ddlApplicantStayConfirm.ClientID%>");
                var Img1=document.getElementById("Img1");
                var chkApplicant_DOBAGE_NotConf=document.getElementById("<%=chkApplicant_DOBAGE_NotConf.ClientID%>");
                var chk_YCR=document.getElementById("<%=chk_YCR.ClientID%>");
                var chk_YCE=document.getElementById("<%=chk_YCE.ClientID%>");
                var ddlNameOfPersonMet=document.getElementById("<%=ddlNameOfPersonMet.ClientID%>");
                
                var ddlCompanyDetails=document.getElementById("<%=ddlCompanyDetails.ClientID%>");
                var ddlTypeOfProof=document.getElementById("<%=ddlTypeOfProof.ClientID%>");
                var ddlTypeOfIDProof=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>");
                
                
                   
                var value=false;
                
                if (status=="Yes")
                {
                    value=true;
                    txtApplicantAge_DOB.value="";
                    txtApplicantAge_DOB_YY.value="";
                    txtApplicantAge_DOB_MM.value="";
                    txtPermenantAddress.value="";
                    txtPermenantNo.value="";
                     
                    txtYearsLivedAtResi_YY.value="";
                    txtYearsLivedAtResi_MM.value="";
                    ddlApplicantStayConfirm.selectedIndex=2;                 
                    ddlEaringFamilyMembers.selectedIndex=1;
                    ddlNoOfFamilyMembers.selectedIndex=1;    
                    ddlResiStatus.selectedIndex=9;                    
                    ddlCompanyDetails.selectedIndex=2;
                    
                    ddlTypeOfProof.selectedIndex=2;
                    chkApplicant_DOBAGE_NotConf.checked=true;
                    chk_YCR.checked=true;
                    chk_YCE.checked=true; 
                }
                else
                {
                 //chkApplicant_DOBAGE_NotConf.checked=false;
                 //chk_YCR.checked=false;
                 //chk_YCE.checked=false;
                }
                
                    txtApplicantAge_DOB.disabled=value;
                    txtApplicantAge_DOB_YY.disabled=value;
                    txtApplicantAge_DOB_MM.disabled=value;
                    
                    
                    chkApplicant_DOBAGE_NotConf.disabled=value;
                     
                    chk_YCR.disabled=value;                     
                    
                     
                    chk_YCE.disabled=value;                     
                   
                    
                    ddlApplicantStayConfirm.disabled=value;                 
                    ddlEaringFamilyMembers.disabled=value;
                    ddlNoOfFamilyMembers.disabled=value;    
                               
                    txtYearsLivedAtResi_YY.disabled=value;
                    txtYearsLivedAtResi_MM.disabled=value;
                    
                    ddlResiStatus.disabled=value; 
                    txtPermenantAddress.disabled=value;
                    txtPermenantNo.disabled=value;
                    ddlApplicantStayConfirm.disabled=value;
                    
                    
                    ddlTypeOfProof.disabled=value;
                     
                    Enable_Validation_on_Proof();
                    
                    ddlCompanyDetails.disabled=value;
                    Enabled_Validation_CompanyDetails()
                
             
                      if (status=="Yes")
                        {
                            Img1.style.visibility="hidden";
                        }
                      else
                      {
                           Img1.style.visibility="visible";
                      }
                       
        }
        
    
    
        function Enable_Validation_on_AddressNotConfirmed()
            {
                //debugger;
                var statusIndex=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").selectedIndex;
                var status=document.getElementById("<%=ddlReasonForAddNotConfirmed.ClientID%>").options[statusIndex].text;
                var txtResultOfCalling=document.getElementById("<%=txtResultOfCalling.ClientID%>");                
                var txtWhomtheAddBelongsTo=document.getElementById("<%=txtWhomtheAddBelongsTo.ClientID%>");                           
                var lblResultofCalling=document.getElementById("<%=lblResultofCalling.ClientID%>");
                var lblWhomTo=document.getElementById("<%=lblWhomTo.ClientID%>");
                var ddlTPC1_Name=document.getElementById("<%=ddlTPC1_Name.ClientID%>");
                var ddlTPC2_Name=document.getElementById("<%=ddlTPC2_Name.ClientID%>");
               
                var ddlVeri_Conduct_At=document.getElementById("<%=ddlVeri_Conduct_At.ClientID%>");
               
                          
                     if (status=="Mismatched")
                     {   
                      txtResultOfCalling.style.visibility="hidden";                       
                      txtWhomtheAddBelongsTo.style.visibility="visible"; 
                      lblWhomTo.style.visibility="visible";
                      lblResultofCalling.style.visibility="hidden";                    
                      ddlTPC1_Name.selectedIndex=0;
                      ddlTPC1_Name.disabled=false;                       
                      Enable_Validation_On_TPC1_Name();
                      
                      ddlTPC2_Name.selectedIndex=0;
                      ddlTPC2_Name.disabled=false;                       
                      Enable_Validation_On_TPC2_Name();
                      
                      ddlVeri_Conduct_At.disabled=false; 
                     }
                     else if (status=="Untraceable")
                     {
                       txtWhomtheAddBelongsTo.style.visibility="hidden"; 
                       txtResultOfCalling.style.visibility="visible"; 
                       lblWhomTo.style.visibility="hidden";
                       lblResultofCalling.style.visibility="visible"; 
                        
                       var ans = confirm("TPC 1 Data Will Be lost!");
                        if (ans)
                        {
	                          ddlTPC1_Name.selectedIndex=2;
	                          ddlTPC1_Name.disabled=true; 
	                          
	                          ddlTPC2_Name.selectedIndex=2;
	                          ddlTPC2_Name.disabled=true; 
                              Enable_Validation_On_TPC1_Name();
                              Enable_Validation_On_TPC2_Name();
                              ddlVeri_Conduct_At.selectedIndex=0;
                              ddlVeri_Conduct_At.disabled=true; 
                              //avinash
                              
                        }
                         
                       
                                                                  
                     }
                     else
                     {
                    
                        txtWhomtheAddBelongsTo.style.visibility="hidden"; 
                        txtResultOfCalling.style.visibility="hidden";   
                        lblWhomTo.style.visibility="hidden";
                        lblResultofCalling.style.visibility="hidden";                                           
                        ddlTPC1_Name.selectedIndex=0;
                        ddlTPC1_Name.disabled=false;
                        Enable_Validation_On_TPC1_Name();
                        
                        ddlTPC2_Name.selectedIndex=0;
                        ddlTPC2_Name.disabled=false;
                        Enable_Validation_On_TPC2_Name();
                        
                        ddlVeri_Conduct_At.disabled=false; 
                     }
                       
            
            }
           
           



      

        function Enable_Validation_on_EntryPermitted()
        {
         //debugger;
                var statusIndex=document.getElementById("<%=ddlEntryPermitted.ClientID%>").selectedIndex;
                var status=document.getElementById("<%=ddlEntryPermitted.ClientID%>").options[statusIndex].text;
                var ddlStandardOfLiving=document.getElementById("<%=ddlStandardOfLiving.ClientID%>");
                var chkInterior=document.getElementById("<%=chkInterior.ClientID%>");                
                var chkAssetsVisible=document.getElementById("<%=chkAssetsVisible.ClientID%>");
                  var value=false;
                var i=0;
                
                 if ((status=="No")||(status=="Door Locked")||(status==""))
                    {
                        value=true;
                        ddlStandardOfLiving.selectedIndex=0;
                         
                        for (i=0;i<=chkInterior.cells.length-1;i++)
                        {
                            var  chk=document.getElementById("ctl00_C1_chkInterior_"+i);
                            chk.checked=false;
                           //ctl00_C1_ChkVehicleType_0                        
                        }
                        for (i=0;i<=chkAssetsVisible.cells.length-1;i++)
                        {
                            var  chk=document.getElementById("ctl00_C1_chkAssetsVisible_"+i);
                            chk.checked=false;
                           //ctl00_C1_ChkVehicleType_0                        
                        }
                        
                        
                        
                    }                  
                   
                   
                 
                   
                     ddlStandardOfLiving.disabled=value;             
                     chkAssetsVisible.disabled=value; 
                     chkInterior.disabled=value; 
                     
                     
                                
            
        }
        
        function Enable_Validation_on_Proof()
        {
      //debugger;
            var statusIndex=document.getElementById("<%=ddlTypeOfProof.ClientID%>").selectedIndex;
            var status=document.getElementById("<%=ddlTypeOfProof.ClientID%>").options[statusIndex].text;
            var ddlTypeOfIDProof=document.getElementById("<%=ddlTypeOfIDProof.ClientID%>");
            var txtProofDetails =document.getElementById("<%=txtProofDetails .ClientID%>");
            
            var value="false";
              if (status=="No")
                {
                
                ddlTypeOfIDProof.disabled=true;
                txtProofDetails.disabled=true;
                ddlTypeOfIDProof.selectedIndex=0; 
                }
                else
                {
                    ddlTypeOfIDProof.disabled=false;
                    txtProofDetails.disabled=false;
                }         
               
        
        }
        
       
        

 

    </script>
    <asp:Panel ID="PnlView" runat="server" Height="100%"  Width="100%">   
    <table cellspacing="1" cellpadding="0" width="100%">
        <tr>
            <td colspan="9">
            </td>
        </tr>
        <tr>
            <td colspan="9" class="TableHeader" style="height: 14px">
                <strong>&nbsp;Residence Verification</strong></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                </td>
            <td colspan="3" style="height: 16px">
                <asp:HiddenField ID="hdnVeriTypeId" runat="server" />
                <asp:HiddenField ID="hdnTransStart" runat="server" />
                &nbsp;&nbsp;
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 112px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td colspan="9" style="height: 18px">
                <asp:Label ID="lblMessage" runat="server" Width="100%" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="9">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"  />
            </td>
        </tr>
        <tr>
            <td colspan="9" class="TableTitle" style="height: 15px">
                &nbsp;<strong>Applicant Details</strong></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                <asp:Label ID="Label3" runat="server" Text="Case Id" Width="183px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtCaseID" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 26px;">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Application Number</td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtApplicationNo" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="height: 26px;">
            </td>
            <td style="width: 100px; height: 26px;">
            </td>
            <td style="width: 112px; height: 26px;">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Applicant Name</td>
            <td colspan="5">
                <asp:TextBox ID="txtApplicantNAme" runat="server" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 52px;">
            </td>
            <td style="width: 1px; height: 52px">
            </td>
            <td style="height: 52px; width: 210px;">
                &nbsp;Resi Address</td>
            <td colspan="5" style="height: 52px">
                <asp:TextBox ID="txtResiAdd" runat="server" Height="42px" TextMode="MultiLine" Width="444px" ReadOnly="True" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 52px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px">
                &nbsp;Address Confirmed</td>
            <td style="width: 100px; height: 24px;">
                <asp:DropDownList ID="ddlAddressConfirm" runat="server" SkinID="ddlSkin"  >
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Address Confirmed &nbsp;By <strong><span style="font-size: 10pt; color: #ff0000">
                    *</span></strong></td>
            <td style="width: 100px; height: 24px;">
                <asp:DropDownList ID="ddlAddConfBy" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Self</asp:ListItem>
                    <asp:ListItem>Family Member</asp:ListItem>
                    <asp:ListItem Value="Guard">Guard</asp:ListItem>
                    <asp:ListItem>Neighbor</asp:ListItem>
                </asp:DropDownList>
                <span style="font-size: 10pt; color: #ff0000"></span></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Name of The Person met</td>
            <td style="width: 100px">
                <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                            <asp:DropDownList ID="ddlNameOfPersonMet" runat="server" SkinID="ddlSkin"  >
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Confirm</asp:ListItem>
                                <asp:ListItem>Applicant</asp:ListItem>
                                <asp:ListItem>Not Possible</asp:ListItem>
                                <asp:ListItem>Not Confirmed</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 20px;">
                <asp:TextBox ID="txtNameOfThePersonMet" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 100px; height: 20px;">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Relationship with applicant</td>
            <td style="width: 100px">
                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 20px;">
                <asp:DropDownList ID="ddlRelationShipWithApp" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Self</asp:ListItem>
                    <asp:ListItem>Spouse</asp:ListItem>
                    <asp:ListItem>Mother</asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Brother</asp:ListItem>
                    <asp:ListItem>Sister</asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Colleagues</asp:ListItem>
                    <asp:ListItem>Son</asp:ListItem>
                    <asp:ListItem>Daughter</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px; height: 20px;">
                            <asp:TextBox ID="txtRelationship_Other" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 8px">
            </td>
            <td style="width: 1px; height: 8px;">
            </td>
            <td style="width: 210px; height: 8px;">
                &nbsp;Information Refused <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px; height: 8px;">
                <asp:DropDownList ID="ddl_InfoRefused" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="height: 8px">
            </td>
            <td style="width: 100px; height: 8px;">
            </td>
            <td style="width: 112px; height: 8px;">
            </td>
            <td style="height: 8px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Applicant Name Confirmed <strong><span style="font-size: 10pt; color: #ff0000">
                    *</span></strong></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlApplicantNameConfirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Approx Age/ Applicant DOB <strong><span style="font-size: 10pt; color: #ff0000">
                    *</span></strong></td>
            <td colspan="5">
                <table cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td class="HighLight">
                            <asp:CheckBox ID="chkApplicant_DOBAGE_NotConf" runat="server" Height="14px" Text="Not Confirmed"
                                Width="95px" /></td>
                        <td class="HighLight" style="height: 20px">
                            <strong>&nbsp;<asp:Label ID="Label2" runat="server" Text="dd-mm-yyyy" Width="76px" Font-Bold="False"></asp:Label></strong></td>
                        <td>
                            <asp:TextBox ID="txtApplicantAge_DOB" runat="server" Width="151px" SkinID="txtSkin"></asp:TextBox></td>
                        <td>
                            &nbsp;<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtApplicantAge_DOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td class="HighLight">
                            &nbsp;YY:MM</td>
                        <td style="height: 20px" class="HighLight">
                            <asp:TextBox ID="txtApplicantAge_DOB_YY" runat="server" Width="29px" SkinID="txtSkin"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 20px;" class="HighLight">
                            <asp:TextBox ID="txtApplicantAge_DOB_MM" runat="server" Width="29px" SkinID="txtSkin"></asp:TextBox>
                            <asp:RangeValidator ID="RnDOB_YY" runat="server" ControlToValidate="txtApplicantAge_DOB_YY"
                                ErrorMessage="Please Enter Numeric Values for DOB Year!" MaximumValue="99" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator></td>
                        <td style="width: 100px; height: 20px;">
                            <asp:RangeValidator ID="rn_DOB_MM" runat="server" ControlToValidate="txtApplicantAge_DOB_MM"
                                ErrorMessage="Please Enter Numeric Values for DOB Month!" MaximumValue="12" MinimumValue="0"
                                Type="Integer">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Applicant Stay Confirm <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlApplicantStayConfirm" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                    <asp:ListItem>Comes here rarely</asp:ListItem>
                    <asp:ListItem>Owned but given on rent</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Resi Status <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px; height: 24px;">
                <asp:DropDownList ID="ddlResiStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Family Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Co Provided</asp:ListItem>
                    <asp:ListItem>PG</asp:ListItem>
                    <asp:ListItem>Bach Acco</asp:ListItem>
                    <asp:ListItem>Relatives House</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;No Of Family Members <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px; height: 24px;">
                <asp:DropDownList ID="ddlNoOfFamilyMembers" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Earning Family Members <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px; height: 24px">
                <asp:DropDownList ID="ddlEaringFamilyMembers" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>Not Confirmed</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td style="width: 1px; height: 18px">
            </td>
            <td style="height: 18px; width: 210px;">
                &nbsp;Y&nbsp; C &nbsp;R (Year At) <strong><span style="font-size: 10pt; color: #ff0000">
                    *</span></strong></td>
            <td style="width: 100px; height: 18px">
                <table border="0">
                    <tr>
                        <td class="HighLight" colspan="1" style="width: 100px">
                            <asp:CheckBox ID="chk_YCR" runat="server" Height="14px" Text="Not Confirmed" Width="95px" /></td>
                        <td class="HighLight" colspan="" style="width: 100px">
                            YY:MM</td>
                        <td style="width: 8px" class="HighLight">
                            <asp:TextBox ID="txtYearsLivedAtResi_YY" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td class="HighLight">
                            <asp:TextBox ID="txtYearsLivedAtResi_MM" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                        <td>
                <asp:RangeValidator ID="rnYCRYY" runat="server" ControlToValidate="txtYearsLivedAtResi_YY"
                    ErrorMessage="Please Enter Numeric Values for Year!" Type="Integer" MaximumValue="99" MinimumValue="0">?</asp:RangeValidator></td>
                        <td>
                <asp:RangeValidator ID="rnYCRMonth" runat="server" ControlToValidate="txtYearsLivedAtResi_MM"
                    ErrorMessage="Please Enter Numeric Values for Month!" Type="Integer" MaximumValue="12" MinimumValue="0">?</asp:RangeValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 18px">
                &nbsp;</td>
            <td style="height: 18px">
            </td>
            <td style="width: 100px; height: 18px">
            </td>
            <td style="width: 112px; height: 18px">
            </td>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Permanent Address</td>
            <td colspan="5" style="height: 24px">
                <asp:TextBox ID="txtPermenantAddress" runat="server" Height="42px" TextMode="MultiLine"
                    Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Permanent Address Tel No.</td>
            <td style="width: 100px; height: 24px">
                <asp:TextBox ID="txtPermenantNo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Proof Attached <strong><span style="font-size: 10pt; color: #ff0000">*</span></strong></td>
            <td style="width: 100px; height: 24px">
                <asp:DropDownList ID="ddlTypeOfProof" runat="server" SkinID="ddlSkin"  >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Type of ID Proof</td>
            <td style="width: 100px; height: 24px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px; height: 18px">
                <asp:DropDownList ID="ddlTypeOfIDProof" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Visiting Card</asp:ListItem>
                    <asp:ListItem>Employee ID</asp:ListItem>
                    <asp:ListItem>Ration Card</asp:ListItem>
                    <asp:ListItem>PAN card</asp:ListItem>
                    <asp:ListItem>Voter Id</asp:ListItem>
                    <asp:ListItem>Driving License</asp:ListItem>
                    <asp:ListItem>Utility Bill</asp:ListItem>
                    <asp:ListItem>Passport</asp:ListItem>
                    <asp:ListItem>Letter</asp:ListItem>
                </asp:DropDownList>
                        </td>
                        <td style="width: 100px; height: 18px">
                            <asp:TextBox ID="txtProofDetails" runat="server" SkinID="txtSkin" Width="102px"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px" colspan="9">
                <asp:Panel ID="pnlAddnotConfirmed" runat="server" Width="100%">
                    <table width="100%">
                        <tr>
                            <td class="TableTitle" colspan="5" style="height: 15px">
                                Address Not Confirmed</td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                            </td>
                            <td style="width: 197px">
                                &nbsp;<asp:Label ID="Label1" runat="server" Text=" Reason for Add not Confirmed"
                                    Width="182px"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlReasonForAddNotConfirmed" runat="server" AutoPostBack="false"
                                    RepeatDirection="Horizontal" SkinID="ddlSkin">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Mismatched</asp:ListItem>
                                    <asp:ListItem Value="Untraceable">Untraceable</asp:ListItem>
                                </asp:DropDownList></td>
                            <td colspan="1">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 30px">
                            </td>
                            <td style="width: 197px; height: 30px">
                                &nbsp;<asp:Label ID="lblWhomTo" runat="server" Text=" Whom the Add Belongs To" Width="182px"></asp:Label></td>
                            <td style="width: 100px; height: 30px;">
                                <asp:TextBox ID="txtWhomtheAddBelongsTo" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 286px; height: 30px">
                            </td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px; height: 26px">
                            </td>
                            <td style="width: 197px; height: 26px">
                                &nbsp;<asp:Label ID="lblResultofCalling" runat="server" Text="Result of Calling" Width="182px"></asp:Label></td>
                            <td style="width: 100px; height: 26px">
                                <asp:TextBox ID="txtResultOfCalling" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                            <td style="width: 286px; height: 26px">
                            </td>
                            <td style="height: 26px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="9" class="TableTitle" style="height: 15px">
                &nbsp;<strong>Employer Details</strong></td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Company Details <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td colspan="5">
                <asp:DropDownList ID="ddlCompanyDetails" runat="server" SkinID="ddlSkin"  >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Company Name</td>
            <td colspan="5">
                <asp:TextBox ID="txtCompanyName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 24px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px" valign="top">
            </td>
            <td valign="top" style="width: 210px">
                &nbsp;Office Address</td>
            <td colspan="5">
                <asp:TextBox ID="txtOfficeAdd" runat="server" Height="39px" TextMode="MultiLine"
                    Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Designation at Office</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtDesignation" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Office Phone</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtOfficePhone" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Resi Phone</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtResiPhone" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Year In Current Employment</td>
            <td><table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td class="HighLight" colspan="1" style="width: 100px">
                        <asp:CheckBox ID="chk_YCE" runat="server" Height="14px" Text="Not Confirmed" Width="95px" SkinID="chkSkin" /></td>
                    <td class="HighLight" colspan="">
                        &nbsp;YY:MM</td>
                    <td style="width: 8px" class="HighLight">
                <asp:TextBox ID="txtYrsInEMP_YY" runat="server" Width="32px" SkinID="txtSkin"></asp:TextBox></td>
                    <td class="HighLight">
                        <asp:TextBox ID="txtYrsInEMP_MM" runat="server" Width="31px" SkinID="txtSkin"></asp:TextBox></td>
                </tr>
            </table>
            </td>
            <td style="width: 100px; height: 26px">
                <asp:RangeValidator ID="rn_YCE_YY" runat="server" ControlToValidate="txtYrsInEMP_YY"
                    ErrorMessage="Please Enter Numeric Values for DOB Year!" MaximumValue="99" MinimumValue="0"
                    Type="Integer" Width="11px">?</asp:RangeValidator></td>
            <td style="height: 26px">
            <asp:RangeValidator ID="Rn_YCE_MM" runat="server"
                        ControlToValidate="txtYrsInEMP_MM" ErrorMessage="Please Enter Numeric Values for DOB Month!"
                        MaximumValue="12" MinimumValue="0" Type="Integer" Width="11px">?</asp:RangeValidator></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;Department</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtDepartMent" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="height: 26px">
                &nbsp;</td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="9" class="TableTitle" style="height: 15px">
                &nbsp;<strong>Verifier Observation [Demography]</strong></td>
        </tr>
        <tr>
            <td style="height: 24px;">
                &nbsp;</td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                &nbsp;Entry permitted <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlEntryPermitted" runat="server" SkinID="ddlSkin"  >
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                    <asp:ListItem>Door Locked</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                &nbsp;Standard of Living
            </td>
            <td style="height: 16px">
                <asp:DropDownList ID="ddlStandardOfLiving" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Upper</asp:ListItem>
                    <asp:ListItem>Upper middle</asp:ListItem>
                    <asp:ListItem>Middle</asp:ListItem>
                    <asp:ListItem>Lower middle</asp:ListItem>
                    <asp:ListItem>Lower</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 112px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td>
                &nbsp;Interior Condition</td>
            <td colspan="5">
                <asp:CheckBoxList ID="chkInterior" runat="server" AutoPostBack="false" RepeatDirection="horizontal"
                    SkinID="chkListSkin">
                    <asp:ListItem>Sofa</asp:ListItem>
                    <asp:ListItem>Clean</asp:ListItem>
                    <asp:ListItem>Painted</asp:ListItem>
                    <asp:ListItem>Carpeted</asp:ListItem>
                    <asp:ListItem>Venetian Blinds</asp:ListItem>
                    <asp:ListItem>Curtains</asp:ListItem>
                </asp:CheckBoxList></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 56px">
            </td>
            <td style="width: 1px; height: 56px">
            </td>
            <td>
                &nbsp;Asset Seen</td>
            <td colspan="5">
                <asp:CheckBoxList ID="chkAssetsVisible" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"
                    SkinID="chkListSkin" Height="13px">
                    <asp:ListItem>Air Conditioner</asp:ListItem>
                    <asp:ListItem>Television</asp:ListItem>
                    <asp:ListItem>Two Wheeler</asp:ListItem>
                    <asp:ListItem>Refrigerator</asp:ListItem>
                    <asp:ListItem>Car</asp:ListItem>
                    <asp:ListItem>Music System</asp:ListItem>
                    <asp:ListItem>PC</asp:ListItem>
                </asp:CheckBoxList></td>
            <td style="height: 56px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Exterior Condition</td>
            <td colspan="5">
                <asp:DropDownList ID="ddlExteriorCondition" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Good</asp:ListItem>
                    <asp:ListItem>Acceptable</asp:ListItem>
                    <asp:ListItem>Poor</asp:ListItem>
                    <asp:ListItem>Tar sheeted</asp:ListItem>
                    <asp:ListItem>Tin Roofed</asp:ListItem>
                    <asp:ListItem>Asbestos sheet</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Locality</td>
            <td>
                <asp:DropDownList ID="ddlLocality" runat="server" Width="117px" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Upper</asp:ListItem>
                    <asp:ListItem>Upper middle</asp:ListItem>
                    <asp:ListItem>Middle</asp:ListItem>
                    <asp:ListItem>Lower middle</asp:ListItem>
                    <asp:ListItem>Lower</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px;">
                &nbsp;Area type</td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlAreaType" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Acceptable</asp:ListItem>
                    <asp:ListItem>Negative</asp:ListItem>
                    <asp:ListItem>Village</asp:ListItem>
                    <asp:ListItem>Slum</asp:ListItem>
                    <asp:ListItem>Surrounded by slum</asp:ListItem>
                    <asp:ListItem>Partly slum</asp:ListItem>
                    <asp:ListItem>Community dominated</asp:ListItem>
                    <asp:ListItem>Grey area</asp:ListItem>
                    <asp:ListItem>JJ colony</asp:ListItem>
                    <asp:ListItem> Slum board</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Type of Accommodation <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td>
                <asp:DropDownList ID="ddlTypeAcco" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Independent</asp:ListItem>
                    <asp:ListItem>Flat</asp:ListItem>
                    <asp:ListItem>Bungalow</asp:ListItem>
                    <asp:ListItem>Upper chaw</asp:ListItem>
                    <asp:ListItem>Lower chawl</asp:ListItem>
                    <asp:ListItem>Paying guest</asp:ListItem>
                    <asp:ListItem>Hutment</asp:ListItem>
                    <asp:ListItem>Temporary shed</asp:ListItem>
                    <asp:ListItem>Semi permanent establishment</asp:ListItem>
                    <asp:ListItem>Row house</asp:ListItem>
                    <asp:ListItem>Hostel</asp:ListItem>
                    <asp:ListItem>Not confd</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Ease of locating house</td>
            <td>
                <asp:DropDownList ID="ddlEaseOfLocatingHouse" runat="server" AutoPostBack="false"
                    RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Area of the house (Sq Ft. )</td>
            <td>
                <asp:DropDownList ID="ddlAreaOfHouse" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>100-300</asp:ListItem>
                    <asp:ListItem>300-500</asp:ListItem>
                    <asp:ListItem>500-800</asp:ListItem>
                    <asp:ListItem>800-1200</asp:ListItem>
                    <asp:ListItem>&gt;1200</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;Directory Checked</td>
            <td>
                <asp:DropDownList ID="ddlDirectory_Check" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>W01-Both Matched</asp:ListItem>
                    <asp:ListItem>W02-Both Mismatches</asp:ListItem>
                    <asp:ListItem>W03-Name Matched Address Mismatched</asp:ListItem>
                    <asp:ListItem>W04-Address Matched Name Mismatched</asp:ListItem>
                    <asp:ListItem>W05-Not Found in Web Check, Invalid No.</asp:ListItem>
                    <asp:ListItem>W06-PVT Operator</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px">
                &nbsp;Address Updation <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlAddressUpdation" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 38px;">
            </td>
            <td style="width: 1px; height: 38px">
            </td>
            <td style="width: 210px; height: 38px;">
                &nbsp;Correct Address</td>
            <td colspan="5" style="height: 38px">
                <asp:TextBox ID="txtAddressUpdation" runat="server" TextMode="MultiLine" Width="474px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 38px">
            </td>
        </tr>
        <tr>
            <td style="height: 38px">
            </td>
            <td style="width: 1px; height: 38px">
            </td>
            <td style="width: 210px; height: 38px">
                &nbsp;Landmark</td>
            <td colspan="5" style="height: 38px">
                <asp:TextBox ID="txtLandmark" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 38px">
            </td>
        </tr>
        <tr>
            <td colspan="9" class="TableTitle" style="height: 15px">
                &nbsp;<strong>TPC 1 Details</strong></td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                &nbsp;TPC 1 Name <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td style="width: 100px; height: 16px">
                <table border="0" style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlTPC1_Name" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Not Provided</asp:ListItem>
                    <asp:ListItem>Not Possible</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                </asp:DropDownList></td>
                        <td style="width: 100px">
                <asp:TextBox ID="txtTPC1_Name" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 112px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                &nbsp;TPC 1 By Whom</td>
            <td style="width: 100px; height: 16px">
                <asp:DropDownList ID="ddlTPC1_ByWHOM" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Shop </asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
            <td style="width: 100px; height: 16px">
            </td>
            <td style="width: 112px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;TPC 1&nbsp; Address</td>
            <td colspan="5">
                <asp:TextBox ID="txtTPC1_Address" runat="server" Height="42px" TextMode="MultiLine"
                    Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
            </td>
            <td style="width: 1px; height: 26px">
            </td>
            <td style="height: 26px; width: 210px;">
                &nbsp;TPC 1 Applicant Available at Home</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtTPC1_AppHomeConfirm" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 26px">
            </td>
            <td style="height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
            <td style="width: 112px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
        </tr>
        <tr>
            <td style="height: 31px;">
            </td>
            <td style="width: 1px; height: 31px">
            </td>
            <td style="width: 210px; height: 31px;">
                &nbsp;TPC 1 Applicant Name Confirmed <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td style="height: 31px">
                <asp:DropDownList ID="ddlTPC1_AppNameConfirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 31px">
            </td>
            <td style="height: 31px;">
            </td>
            <td style="width: 100px; height: 31px;">
            </td>
            <td style="width: 112px; height: 31px;">
            </td>
            <td style="height: 31px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;TPC 1 Applicant Stay Confirmed <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td>
                <asp:DropDownList ID="ddlTPC1_AppStayConfirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                    <asp:ListItem>Shifted</asp:ListItem>
                    <asp:ListItem>Not possible</asp:ListItem>
                    <asp:ListItem>Owned but given on rent </asp:ListItem>
                    <asp:ListItem>Comes here rarely</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">
            </td>
            <td style="width: 1px; height: 20px">
            </td>
            <td style="height: 20px; width: 210px;">
                &nbsp;TPC 1 App YCR</td>
            <td><table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td class="HighLight" colspan="1" style="width: 100px; height: 22px;">
                        <asp:CheckBox ID="chkTPC1_AppYCR" runat="server" Height="14px" Text="Not Confirmed" Width="95px" SkinID="chkSkin" /></td>
                    <td class="HighLight" colspan="" style="width: 27px; height: 22px;">
                        &nbsp;YY:MM</td>
                    <td style="width: 8px; height: 22px;" class="HighLight">
                        <asp:TextBox ID="txtTPC1_AppYCR_YY" runat="server" SkinID="txtSkin" Width="32px"></asp:TextBox></td>
                    <td class="HighLight" style="height: 22px">
                        <asp:TextBox ID="txtTPC1_AppYCR_MM" runat="server" SkinID="txtSkin" Width="31px"></asp:TextBox></td>
                </tr>
            </table>
            </td>
            <td style="height: 20px">
            </td>
            <td style="height: 20px">
            </td>
            <td style="width: 100px; height: 20px">
            </td>
            <td style="width: 112px; height: 20px">
            </td>
            <td style="height: 20px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                &nbsp;TPC1 App Ownership Status</td>
            <td>
                <asp:DropDownList ID="ddlTCP1_AppOwnershipStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Family Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Co Provided</asp:ListItem>
                    <asp:ListItem>PG</asp:ListItem>
                    <asp:ListItem>Bach Acco</asp:ListItem>
                    <asp:ListItem> Relatives House</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>    
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 15px" class="TableTitle" colspan="9">
                &nbsp;TPC 2 Details</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                TPC 2 Name</td>
            <td><table border="0" style="width: 17%; height: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlTPC2_Name" runat="server" SkinID="ddlSkin">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Not Provided</asp:ListItem>
                            <asp:ListItem>Not Possible</asp:ListItem>
                            <asp:ListItem>Name</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtTPC2_Name" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                </tr>
            </table>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                TPC 2 By Whom</td>
            <td>
                <asp:DropDownList ID="ddlTPC2_ByWhom" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Guard</asp:ListItem>
                    <asp:ListItem>Neighbour</asp:ListItem>
                    <asp:ListItem>Shop </asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                TPC 2 Address</td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtTPC2_Address" runat="server" Height="42px" TextMode="MultiLine" Width="444px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px;">
            </td>
            <td style="width: 210px;">
                TPC 2 Applicant Available at Home</td>
            <td style="width: 261px;">
                <asp:TextBox ID="txtTPC2_AppHomeConfirm" runat="server" SkinID="txtSkin"></asp:TextBox></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 112px;">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px;">
                TPC 2 Applicant Name Confirmed</td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlTPC2_AppNameConfirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                    <asp:ListItem>No such person</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 4px;">
            </td>
            <td style="width: 1px; height: 4px">
            </td>
            <td style="width: 210px; height: 4px;">
                TPC 2 Applicant Stay Confirmed</td>
            <td style="height: 4px">
                <asp:DropDownList ID="ddlTPC2_AppStayConfirmed" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Confirmed</asp:ListItem>
                    <asp:ListItem>Not confirmed</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                    <asp:ListItem>Shifted</asp:ListItem>
                    <asp:ListItem>Not possible</asp:ListItem>
                    <asp:ListItem>Comes here rarely</asp:ListItem>
                    <asp:ListItem>Owned but given on rent</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 4px">
            </td>
            <td style="height: 4px;">
            </td>
            <td style="width: 100px; height: 4px;">
            </td>
            <td style="width: 112px; height: 4px;">
            </td>
            <td style="height: 4px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                TPC 2 App YCR</td>
            <td><table border="0" style="width: 57%; height: 100%" cellpadding="0" cellspacing="1">
                <tr>
                    <td class="HighLight" colspan="1" style="width: 100px">
                        <asp:CheckBox ID="chkTPC2_AppYCR" runat="server" Height="14px" Text="Not Confirmed" Width="95px" SkinID="chkSkin" /></td>
                    <td class="HighLight" colspan="" style="width: 100px">
                        &nbsp;YY:MM</td>
                    <td style="width: 8px" class="HighLight">
                        <asp:TextBox ID="txtTPC2_AppYCR_YY" runat="server" SkinID="txtSkin" Width="32px"></asp:TextBox></td>
                    <td class="HighLight">
                        <asp:TextBox ID="txtTPC2_AppYCR_MM" runat="server" SkinID="txtSkin" Width="31px"></asp:TextBox></td>
                </tr>
            </table>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                TPC 2 App Ownership Status</td>
            <td>
                <asp:DropDownList ID="ddlTCP2_AppOwnershipStatus" runat="server" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Owned</asp:ListItem>
                    <asp:ListItem>Family Owned</asp:ListItem>
                    <asp:ListItem>Rented</asp:ListItem>
                    <asp:ListItem>Co Provided</asp:ListItem>
                    <asp:ListItem>PG</asp:ListItem>
                    <asp:ListItem>Bach Acco</asp:ListItem>
                    <asp:ListItem> Relatives House</asp:ListItem>
                    <asp:ListItem>Not Aware</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="9" style="height: 15px">
                &nbsp;Attempts Details</td>
        </tr>
        <tr>
            <td style="height: 102px;">
            </td>
            <td colspan="1" style="width: 1px; height: 102px">
            </td>
            <td colspan="6" style="height: 102px">
                <table id="tblAttempt" runat="server" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="TDWidth" style="width: 13%; height: 14px">
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
                        <td class="TDWidth" style="width: 13%; height: 21px;">
                            <asp:Label ID="lblFirstAttempt" runat="server" SkinID="lblSkin" Text="First Attempt"></asp:Label>
                        </td>
                        <td style="height: 21px">
                            <asp:TextBox ID="txtAttemptDate1" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                            <img id="ImgDate1stCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate1.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td style="height: 21px">
                            <asp:TextBox ID="txtAttemptTime1" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType1" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="height: 21px">
                            <asp:DropDownList ID="ddlVerifierRemarks1" runat="server" SkinID="ddlSkin">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Contactable</asp:ListItem>
                                <asp:ListItem>door Locked</asp:ListItem>
                                <asp:ListItem>No Information</asp:ListItem>
                                <asp:ListItem>Untraceable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth" style="width: 13%; height: 22px;">
                            <asp:Label ID="lblSecondAttempt" runat="server" SkinID="lblSkin" Text="Second Attempt"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtAttemptDate2" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                            <img id="ImgDate2ndCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif" /></td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtAttemptTime2" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                            <asp:DropDownList ID="ddlAttemptTimeType2" runat="server" SkinID="ddlSkin">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="height: 22px">
                            <asp:DropDownList ID="ddlVerifierRemarks2" runat="server" SkinID="ddlSkin">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Contactable</asp:ListItem>
                                <asp:ListItem>door Locked</asp:ListItem>
                                <asp:ListItem>No Information</asp:ListItem>
                                <asp:ListItem>Untraceable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDWidth" style="width: 13%">
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
                                <asp:ListItem>Untraceable</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="height: 102px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                Verifier Name</td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtVerifierName" runat="server" Width="127px" SkinID="txtSkin"></asp:TextBox></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                Verification Conducted At</td>
            <td colspan="5" style="height: 16px">
                <asp:DropDownList ID="ddlVeri_Conduct_At" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Applicant Address</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="height: 16px;">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="height: 16px; width: 210px;">
                Verifier Remarks <span style="font-size: 10pt; color: #ff0000"><strong>*</strong></span></td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtVerifierRemark" runat="server" Height="39px" TextMode="MultiLine"
                    Width="472px" MaxLength="500" SkinID="txtSkin_NEW"></asp:TextBox>
                </td>
            <td style="height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="height: 16px">
            </td>
            <td style="width: 1px; height: 16px">
            </td>
            <td style="width: 210px; height: 16px">
                Verifier <span style="font-size: 8pt; font-family: Arial">Observation<?xml namespace=""
                    ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtObservation" runat="server" Height="39px" MaxLength="500" SkinID="txtSkin_NEW"
                    TextMode="MultiLine" Width="472px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" ForeColor="Maroon"></asp:Label></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                Supervisor Name</td>
            <td>
                <asp:DropDownList ID="ddlSupervisorName" runat="server" SkinID="ddlSkin">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
                Supervisor Remark</td>
            <td colspan="5">
                <asp:TextBox ID="txtSuperVisorRemark" runat="server" TextMode="MultiLine" Width="474px" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="height: 24px; width: 210px;">
                Proprietor recommendation&nbsp; <span style="font-size: 10pt; color: #ff0000"><strong>
                    *</strong></span></td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddlProprietor_recomm" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" SkinID="ddlSkin">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="Positive">Positive</asp:ListItem>
                    <asp:ListItem Value="Negative">Negative</asp:ListItem>
                    <asp:ListItem>Defaulter</asp:ListItem>
                    <asp:ListItem>Referral</asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px">
                If Defaulter, details</td>
            <td style="height: 24px">
                <asp:TextBox ID="txtDefault" runat="server" SkinID="txtSkin" Width="127px"></asp:TextBox></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px">
            </td>
            <td style="width: 100px; height: 24px">
            </td>
            <td style="width: 112px; height: 24px">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 24px;">
            </td>
            <td style="width: 1px; height: 24px">
            </td>
            <td style="width: 210px; height: 24px;">
                </td>
            <td style="height: 24px">
                <asp:TextBox ID="txtDeclineCode" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtAuthSign" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
            <td style="height: 24px">
            </td>
            <td style="height: 24px;">
            </td>
            <td style="width: 100px; height: 24px;">
            </td>
            <td style="width: 112px; height: 24px;">
            </td>
            <td style="height: 24px">
            </td>
        </tr>
        <tr>
            <td style="height: 6px;">
            </td>
            <td style="width: 1px; height: 6px">
            </td>
            <td style="width: 210px; height: 6px;">
                </td>
            <td style="height: 6px">
                </td>
            <td style="height: 6px">
            </td>
            <td style="height: 6px;">
            </td>
            <td style="width: 100px; height: 6px;">
            </td>
            <td style="width: 112px; height: 6px;">
            </td>
            <td style="height: 6px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
            </td>
            <td>
                </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 25px" class="TableTitle" colspan="9">
                &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin" />&nbsp;&nbsp;&nbsp;
                &nbsp;<asp:Button
                    ID="btnCancel" runat="server" SkinID="btnCancelSkin" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
            <td style="width: 210px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 112px">
            </td>
            <td>
            </td>
        </tr>
    </table>
    </asp:Panel> 
</asp:Content>


