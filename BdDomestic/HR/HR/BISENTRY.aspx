<%@ Page Language="C#" AutoEventWireup="true"Theme="SkinFile"  MasterPageFile="HRMasterPage.master"  CodeFile="BISENTRY.aspx.cs" Inherits="HR_HR_BISENTRY" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="JAVASCRIPT" type="text/javascript"> 


var OnOff=1;

// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function isInteger(s)
{
	var i;
    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}
function UpperLetter(ID)
{

ID.value=ID.value.toUpperCase();

}
function stripCharsInBag(s, bag)
{
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++)
    {   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year)
{
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}

function DaysArray(n) 
{
	for (var i = 1; i <= n; i++) 
	{
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) 
		{
		  this[i] = 30
		}
		if (i==2) 
		{
		  this[i] = 29
		}
   } 
   return this
} 

function isAge(Strdt)
{
    
        var dtStr=Strdt.value;
        var pos1=dtStr.indexOf(dtCh);
	    var pos2=dtStr.indexOf(dtCh,pos1+1);
        var strDay =dtStr.substring(0,pos1);
	    var strMonth =dtStr.substring(pos1+1,pos2);
	    var strYear =dtStr.substring(pos2+1);
	    var now = new Date();
	    var yr=now.getFullYear();
	    var mo=now.getMonth()+1;
	    var dt=now.getDay();
        if(now.getFullYear()-parseInt(strYear)<=18 && (parseInt(strMonth)>mo || parseInt(strMonth)==mo ))
        {
       
        return false;
        }
       
        else
        return true;
}
 function candidate()
 {
 var SurName=document.getElementById("<%=txtLastName.ClientID %>").value;
var FirstName=document.getElementById("<%=txtFirstName.ClientID %>").value;
var MiddileName=document.getElementById("<%=txtMiddileName.ClientID %>").value;

var Name=document.getElementById("<%=txtCandidate.ClientID %>").value=FirstName+' '+MiddileName+' '+SurName;

 }
function isDate(Strdt)
{

    
	var daysInMonth = DaysArray(12);
	    var pos1=Strdt.indexOf(dtCh);
	    var pos2=Strdt.indexOf(dtCh,pos1+1);
	    var strDay =Strdt.substring(0,pos1);
	    var strMonth =Strdt.substring(pos1+1,pos2);
	    var strYear =Strdt.substring(pos2+1);
	    strYr = strYear;
    	
	    if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	    if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
    	
	    for (var i = 1; i <= 3; i++) 
	    {
		    if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	    }
    	
	    day=parseInt(strDay);
	    month=parseInt(strMonth);	
	    year=parseInt(strYr);
	    if (Strdt.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(Strdt, dtCh))==false)
	    {
		    
		    return false;
	    }
	    if (pos1==-1 || pos2==-1)
	    {
		    
		    return false;
	    }
	    if (strMonth.length<1 || month<1 || month>12)
	    {
		    
		    return false;
	    }
	    if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	    {
		   
		    return false;
	    }
	    if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	    {
		    
		    return false;
	    }
	    
	   
     return true;
	
	
} 


 function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       

function ValEducation()
{

var NameCollege=document.getElementById("<%=txtNameOfCollage.ClientID %>").value;
var FromToYear=document.getElementById("<%=txtFromToYear.ClientID %>").value;
var Certificate=document.getElementById("<%=txtCertificate.ClientID %>").value;
var DIvMarks=document.getElementById("<%=txtCertificate.ClientID %>").value;
var Browse=document.getElementById("<%=FileUpload2.ClientID %>").value;
var ddlCopy=document.getElementById("<%=ddlCopyAttached.ClientID %>").value;
var ddlType=document.getElementById("<%=ddlQulfication.ClientID %>").value;
var strmessage="";
var bflag="true";

if(Certificate!="")
{
bflag="false";
}
if(NameCollege!="")
{
bflag="false";
}

if(FromToYear!="")
{
bflag="false";
}



if(DIvMarks!="")
{
bflag="false";
}
if(ddlType=="Select")
{
strmessage +=" Please select  the qualification type"+ "\n";
}
if(bflag=="true")
{
strmessage +=" Enter Value in at least One Field "+ "\n";
}
if(ddlCopy=="Yes")
{
if(Browse=="")
{
strmessage +=" Please browse the file"+ "\n";
}
}
if(FromToYear!="")
{
if(check(document.getElementById("<%=txtFromToYear.ClientID %>"))==false)
{

strmessage+=" From to year is not in correct format "+ "\n";
}
}
if(strmessage!="")
{
alert(strmessage);
if(ddlType=="Select")
{
document.getElementById("<%=ddlQulfication.ClientID %>").focus();
return false;
}
if(bflag=="true")
{
document.getElementById("<%=txtCertificate.ClientID %>").focus();
return false;
}
if(FromToYear!="")
{
if(check(document.getElementById("<%=txtFromToYear.ClientID %>"))==false)
{
document.getElementById("<%=txtFromToYear.ClientID %>").focus();
return false;
}
}
if(ddlCopy=="Yes")
{
if(Browse=="")
{
document.getElementById("<%=FileUpload2.ClientID %>").focus();
return false;
}
}


return false;
}

else
return true;
}

function ValEmployee()
{

var EmployerName=document.getElementById("<%=txtEmployerName.ClientID %>").value;
var FromTo=document.getElementById("<%=txtFrom_To.ClientID %>").value;
var Salary=document.getElementById("<%=txtSalary.ClientID %>").value;
var ReasonForLeaving=document.getElementById("<%=txtReasonforLeaving.ClientID %>").value;
var Designation=document.getElementById("<%=txtDesignation.ClientID %>").value;
var ContactNo=document.getElementById("<%=txtEmploeeContact.ClientID %>").value;
var strmessage="";
var bflag="true";
if(EmployerName!="")
{
bflag="false";
}

if(Salary!="")
{
bflag="false";
}
if(ReasonForLeaving!="")
{
bflag="false";
}
if(Designation!="")
{
bflag="false";
}
if(bflag=="true")
{

strmessage+="Enter Value in at least One Field "+ "\n";
}
if(ContactNo=="")
{
strmessage+="Enter Value of Contact No."+ "\n";

}
if(FromTo!="")
{

if(mmyyy(document.getElementById("<%=txtFrom_To.ClientID %>"))==false)
{
strmessage+="Please correct the from of From-To Year "+ "\n";

}
}
if(strmessage!="")
{
alert(strmessage);

if(bflag=="true")
{
document.getElementById("<%=txtEmployerName.ClientID %>").focus();
return false;
}
if(ContactNo=="")
{
document.getElementById("<%=txtEmploeeContact.ClientID %>").focus();
return false;
}
if(FromTo!="")
{

if(mmyyy(document.getElementById("<%=txtFrom_To.ClientID %>"))==false)
{
document.getElementById("<%=txtFrom_To.ClientID %>").focus();
return false;
}
}
return false;
}
else
return true;
}
function ValHobby()
{

var Literary=document.getElementById("<%=txtLiterary.ClientID %>").value;
var Sport=document.getElementById("<%=txtSport.ClientID %>").value;
var Hobby=document.getElementById("<%=txtHobby.ClientID %>").value;
var strmessage="";
var bflag="true";
if(Literary!="")
{
 bflag="false";
}
if(Sport!="")
{
 bflag="false";
}
if(Hobby!="")
{
 bflag="false";
}
if(bflag=="true")
{
strmessage+="Enter Value in at least One Field ";
}
if(strmessage!="")
{
alert(strmessage);
document.getElementById("<%=txtLiterary.ClientID %>").focus();

return false;
}
else
return true;
}

function ValReference()
{

var ReferenceName=document.getElementById("<%=txtReferenceName.ClientID %>").value;
var ReferenceAddress=document.getElementById("<%=txtReferenceAddress.ClientID %>").value;
var Occupation=document.getElementById("<%=txtOccupation.ClientID %>").value;
var Relation=document.getElementById("<%=txtRelationReference.ClientID %>").value;
var ContactNo=document.getElementById("<%=txtContactNo.ClientID %>").value;
var strmessage="";
var bflag="true";
if(ReferenceName=="")
{
strmessage +=" Please enter the  Reference Name"+"\n";
}
if(IsNotSpace(ReferenceName)==false)
{
strmessage +="First character should not be space"+"\n";
}

if(ReferenceAddress=="")
{
strmessage +=" Please enter the  Reference Address "+"\n";
}
if(IsNotSpace(ReferenceAddress)==false)
{
strmessage +="First character should not be space"+"\n";
}
if(Occupation=="")
{
strmessage +=" Please enter the  Occuapation "+"\n";
}
if(IsNotSpace(Occupation)==false)
{
strmessage +="First character should not be space"+"\n";
}
if(Relation=="")
{
strmessage +=" Please enter the  Reference Relation "+"\n";
}
if(IsNotSpace(Relation)==false)
{
strmessage +="First character should not be space"+"\n";
}
if(ContactNo=="")
{
strmessage +=" Please enter the  Contact No. "+"\n";
}
if(IsNotSpace(ContactNo)==false)
{
strmessage +="First character should not be space"+"\n";
}
if(strmessage!="")
{
alert(strmessage);
if(ReferenceName=="")
{
document.getElementById("<%=txtReferenceName.ClientID %>").focus();
return false;
}
if(IsNotSpace(ReferenceName)==false)
{
document.getElementById("<%=txtReferenceName.ClientID %>").focus();
return false;
}

if(ReferenceAddress=="")
{
document.getElementById("<%=txtReferenceAddress.ClientID %>").focus();
return false;
}
if(IsNotSpace(ReferenceAddress)==false)
{
document.getElementById("<%=txtReferenceAddress.ClientID %>").focus();
return false;
}
if(Occupation=="")
{
document.getElementById("<%=txtOccupation.ClientID %>").focus();
return false;
}
if(IsNotSpace(Occupation)==false)
{
document.getElementById("<%=txtOccupation.ClientID %>").focus();
return false;
}
if(Relation=="")
{
document.getElementById("<%=txtRelationReference.ClientID %>").focus();
return false;
}
if(IsNotSpace(Relation)==false)
{
document.getElementById("<%=txtRelationReference.ClientID %>").focus();
return false;
}
if(ContactNo=="")
{
document.getElementById("<%=txtContactNo.ClientID %>").focus();
return false;
}
if(IsNotSpace(ContactNo)==false)
{
document.getElementById("<%=txtContactNo.ClientID %>").focus();
return false;
}
return false;
}
else
return true;
}
function valChild()
{

var NameOfChild=document.getElementById("<%=txtNameOfChild.ClientID %>").value;
var AgeOfChild=document.getElementById("<%=txtAgeOfChild.ClientID %>").value;
var strmessage="";
var bflag="true";
if(NameOfChild!="")
{
 bflag="false";
}
if(AgeOfChild!="")
{
 bflag="false";
}
if(bflag=="true")
{
strmessage+="Enter Value in at least One Field";
}
if(strmessage!="")
{
alert(strmessage);
document.getElementById("<%=txtNameOfChild.ClientID %>").focus();
return false;
}
else
return true;
}
function PreventCharacterToAdd(controlId,Length)
   {  

     
     if(controlId.value.length > Length-1)
     {
       controlId.value = controlId.value.substring( 0, Length );
        controlId.focus=false;
       alert("Length should not be greater then "+Length+" ");            
       return false;
     }
              
   }

function isNumeric(value) 
{
  if (value == null || !value.toString().match(/^[-]?\d*\.?\d*$/)) return false;
  return true;
}
function isNumeric1(ID) 
{

  if (ID.value == null || !ID.value.toString().match(/^[-]?\d*\.?\d*$/)) 
  {
  var v1=ID.value.length;
  ID.value  = ID.value.substring(v1);
  
  alert("Please Enter the numeric value");
  return false;
  }
  return true;
}
function IsNotSpace(iChar)
{  
        iChar=iChar+"";
        if(iChar !="")
        {    
            var c=iChar.charCodeAt(0);
            if (c==32)
            {
               
                 return false;
            }        

        } 
}

function WindowOpen1()
{

 var strFirstName=document.getElementById("<%=txtFirstName.ClientID %>").value;
 var strCentreID=document.getElementById("<%=hdfCentre.ClientID %>").value; 
 var strLastName=document.getElementById("<%=txtLastName.ClientID %>").value;
 var helpwinparam='width=800px,height=300px,toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,dependent,left=200,top=150';
 var strURL = "DedupSearch.aspx?FirstName="+strFirstName+"&LastName="+strLastName+" &CentreID="+strCentreID+"";
 var popup = window.open(strURL,'',helpwinparam);
}
    function WidowOpen()

        {
            
            var strMessage="";
            var strFirstName=document.getElementById("<%=txtFirstName.ClientID %>").value;
            var strCentreID=document.getElementById("<%=hdfCentre.ClientID %>").value; 
            var strLastName=document.getElementById("<%=txtLastName.ClientID %>").value;
            var strNameOfBank=document.getElementById("<%=ddlNameOfBank.ClientID %>").value;
            var strNameOfBank1=document.getElementById("<%=txtNameOfBank.ClientID %>").value;
            var strAC=document.getElementById("<%=txtAC.ClientID %>").value;
            var strRelation=document.getElementById("<%=ddlRelation.ClientID %>").value;
            var strRelation1=document.getElementById("<%=txtRelation.ClientID %>").value;
            var strCourtProceeding=document.getElementById("<%=ddllCourtProceeding.ClientID %>").value;
            var strCourtProceeding1=document.getElementById("<%=txtCourtProceeding.ClientID %>").value;
            var strContagiousDisease=document.getElementById("<%=ddlContagiousDisease.ClientID %>").value;
            var strContagiousDisease1=document.getElementById("<%=txtCountagiosDisease.ClientID %>").value;
            var strPresentAdd=document.getElementById("<%=txtPresentAdd1.ClientID %>").value;
            var strPresentAddTel=document.getElementById("<%=txtPhonepresentAdd.ClientID %>").value;
            var strtdbank=document.getElementById("<%=tdBank.ClientID %>").value;
            var strDOJ=document.getElementById("<%=txtDOJ.ClientID %>").value;
            var strDesignation=document.getElementById("<%=ddlDesignation.ClientID%>") .value;
            var strUnit=document.getElementById("<%=ddlUnit.ClientID%>").value;
            var strDepartment=document.getElementById("<%=ddlDepartment.ClientID %>").value;
            var strClient=document.getElementById("<%=ddlClient.ClientID %>").value;
            var strProduct=document.getElementById("<%=ddlProduct.ClientID%>").value;
            var strBasic=document.getElementById("<%=txtBasic.ClientID%>").value;
            var strHRA=document.getElementById("<%=txtHRA.ClientID%>").value;
            var strSPAllo=document.getElementById("<%=txtSPAllo.ClientID%>").value;
            var strCompany=document.getElementById("<%=ddlCompany.ClientID%>").value;
            var strApprovalMailDate=document.getElementById("<%=txtApprovalMailDate.ClientID%>") .value;
            var strApprovalBy=document.getElementById("<%=txtApprovedBy.ClientID%>").value;  
            var strCategory=document.getElementById("<%=ddlTypeOfCategory.ClientID %>").value;
            var ddl=document.getElementById("<%=ddlTypeOfCategory.ClientID %>");
            
            var bflag="true";
          
          
            if(strFirstName=="" )
            {
            strMessage +=" Please enter the  first name"+"\n";
            
            bflag="false"
            }
            
            if(IsNotSpace(strFirstName)==false)
            {
            strMessage +=" Please do not  enter space charecter"+"\n";
            bflag="false"
            }
            if(strLastName=="")
            {
            strMessage +=" Please enter the  last name"+"\n";
            bflag="false"
            }
            if(IsNotSpace(strLastName)==false)
            {
            strMessage +=" Please do not  enter space charecter"+"\n";
            bflag="false"
            }
            if(document.getElementById("<%=txtDOB.ClientID %>").value!="")
           {
          
           if(isDate(document.getElementById("<%=txtDOB.ClientID %>").value)==false)
          {
          strMessage +="Please enter the valid date formate "+"\n";
          }
          if(isAge(document.getElementById("<%=txtDOB.ClientID %>"))==false)
          {
          strMessage +="Age should not be less than 18-year "+"\n";
          }
          }
        else
        {
        strMessage +="Please enter the date of birth "+"\n";
          bflag="false"
        }
         if(strNameOfBank=="OTHER" && strNameOfBank1=="")
             {
             strMessage +=" Please enter the Name of Bank"+"\n";
             bflag="false"
             }
         if(strAC=="" && strNameOfBank !="Select")
            {
             strMessage +=" Please enter the   A/C #"+"\n";
                         
             bflag="false"
            }
           
           
            if(strPresentAdd=="" )
            {
            strMessage +=" Please enter the  present address "+"\n";
            bflag="false"
            }
            if(strPresentAddTel=="" )
            {
            strMessage +=" Please enter the present Tel. No. "+"\n";
            bflag="false"
            }
            
           
           if(strRelation=="Y" && strRelation1=="")
           {
            strMessage +=" Please enter the  Relationship"+"\n";
            bflag="false"
           
           }
           if(strCourtProceeding=="Y" && strCourtProceeding1=="")
           {
            strMessage +="Please enter the Detail of Court Proceeding"+"\n";
           bflag="false"
           }
           
           if(strContagiousDisease=="Y" && strContagiousDisease1=="")
           {
            strMessage +="Please enter the Detail of Cotagious Disease "+"\n";
           bflag="false"
           }
           if(strDOJ!="")
           {
           if(isDate(document.getElementById("<%=txtDOJ.ClientID %>").value)==false)
          {
          strMessage +="Please enter the valid date formate "+"\n";
           bflag="false"
          }
           }
           else
           {
            strMessage +="Please enter the value of DOJ "+"\n";
             bflag="false"
           }
           
           if(strDesignation=="0")
           {
           strMessage +="Please select the value of Designation "+"\n";
            bflag="false"
           }
           if(strUnit=="0")
           {
             strMessage +="Please select the value of Unit "+"\n";
              bflag="false"
           }
           if(strDepartment=="0")
           {
           strMessage +="Please select the value of Department "+"\n";
           bflag="false"
           }
           if(strClient=="0")
           {
           strMessage +="Please select the value of Client "+"\n";
           bflag="false"
           }
           if(strProduct=="0")
           {
            strMessage +="Please select the value of Product "+"\n";
            bflag="false"
           }
          
           if(strBasic=="")
           {
           strMessage +="Please Enter the value of Basic salary "+"\n";
           bflag="false"
           }
           if(strBasic=="0")
           {
            strMessage +="Basic salary can not be zero "+"\n";
            bflag="false"
           }
       
           if(strCategory=="Salaried")
           {
           if(strHRA=="")
           {
           strMessage +="Please Enter the value of HRA salary "+"\n";
            bflag="false"
           }
           if(strSPAllo=="")
           {
            strMessage +="Please Enter the value of SP Allownce salary "+"\n";
            bflag="false"
           }
           }
           
           else
           {
           if(strHRA!="" )
           {
           if(strHRA!="0" )
           {
             strMessage +=" HRA salary should be zero or blank "+"\n";
            bflag="false"
           }
           }
           if(strSPAllo!="")
           {
           if(strSPAllo!="0" )
           {
            strMessage +=" SPAllownce salary should be zero or blank "+"\n";
            bflag="false"
           }
           }
           }
            if(strCompany=="0")
           {
           strMessage +="Please select the value of Company "+"\n";
           }
            if(document.getElementById("<%=txtApprovalMailDate.ClientID %>").value!="")
           {
          
           if(isDate(document.getElementById("<%=txtApprovalMailDate.ClientID %>").value)==false)
          {
          strMessage +="Please enter the valid date formate "+"\n";
          }
          
          }
        else
        {
        strMessage +="Please enter the Approval mail date "+"\n";
           bflag="false"
        }
      
         if(strApprovalBy=="")
         {
        
         strMessage +="Please enter the value of Approvad by other "+"\n";
         bflag="false"
         }
         if(strMessage!="")
         {
         alert(strMessage);
          
          if( document.getElementById("<%=txtFirstName.ClientID %>").value=="")
          {
          document.getElementById("<%=txtFirstName.ClientID %>").focus();
          return false;
          }
            if(IsNotSpace(strFirstName)==false)
            {
           document.getElementById("<%=txtFirstName.ClientID %>").focus();
          return false;
            }
          if(document.getElementById("<%=txtLastName.ClientID %>").value=="")
          {
           document.getElementById("<%=txtLastName.ClientID %>").focus();
           return false;
          }
          if(IsNotSpace(strLastName)==false)
            {
           document.getElementById("<%=txtLastName.ClientID %>").focus();
           return false;
            }
           if(document.getElementById("<%=txtDOB.ClientID %>").value=="")
          {
          document.getElementById("<%=txtDOB.ClientID %>").focus();
          return false;
          }
           if(isDate(document.getElementById("<%=txtDOB.ClientID %>").value)==false)
          {
            document.getElementById("<%=txtDOB.ClientID %>").focus();
          return false;
          }
          if(isAge(document.getElementById("<%=txtDOB.ClientID %>"))==false)
          {
            document.getElementById("<%=txtDOB.ClientID %>").focus();
          return false;
          }
        if(document.getElementById("<%=txtNameOfBank.ClientID %>").value=="" && strNameOfBank=="OTHER")
          {
           document.getElementById("<%=txtNameOfBank.ClientID %>").focus();
           return false;
          }
          if(document.getElementById("<%=txtAC.ClientID %>").value=="" && strNameOfBank !="Select")
          {
          document.getElementById("<%=txtAC.ClientID %>").focus();
          return false;
          }
          
          
          
          if(document.getElementById("<%=txtPresentAdd1.ClientID %>").value=="")
          {
          document.getElementById("<%=txtPresentAdd1.ClientID %>").focus();
          return false;
          }
          if(document.getElementById("<%=txtPhonepresentAdd.ClientID %>").value=="")
          {
          document.getElementById("<%=txtPhonepresentAdd.ClientID %>").focus();
          return false;
          }
           if(strRelation=="Y" && strRelation1=="")
           {
          if(document.getElementById("<%=txtRelation.ClientID %>").value=="")
          {
          document.getElementById("<%=txtRelation.ClientID %>").focus();
          return false;
          }
          }
          if(strCourtProceeding=="Y" && strCourtProceeding1=="")
           {
          if(document.getElementById("<%=txtCourtProceeding.ClientID %>").value=="")
          {
          document.getElementById("<%=txtCourtProceeding.ClientID %>").focus();
          return false;
          }
          }
          if(strContagiousDisease=="Y" && strContagiousDisease1=="")
           {
          if(document.getElementById("<%=txtCountagiosDisease.ClientID %>").value=="")
          {
          document.getElementById("<%=txtCountagiosDisease.ClientID %>").focus();
          return false;
          }
          }
          if(document.getElementById("<%=txtDOJ.ClientID %>").value=="")
          {
          document.getElementById("<%=txtDOJ.ClientID %>").focus();
          return false;
          }
          if(isDate(document.getElementById("<%=txtDOJ.ClientID %>").value)==false)
          {
            document.getElementById("<%=txtDOJ.ClientID %>").focus();
          return false;
          }
          
          if(document.getElementById("<%=ddlDesignation.ClientID%>") .value=="0")
          {
          document.getElementById("<%=ddlDesignation.ClientID%>").focus();
          return false;
          }
          if(document.getElementById("<%=ddlUnit.ClientID%>").value=="0")
          {
          document.getElementById("<%=ddlUnit.ClientID%>").focus();
           return false;
          }
          if(document.getElementById("<%=ddlDepartment.ClientID %>").value=="0")
          {
          document.getElementById("<%=ddlDepartment.ClientID %>").focus();
          return false;
          }
          if(document.getElementById("<%=ddlClient.ClientID %>").value=="0")
          {
          document.getElementById("<%=ddlClient.ClientID %>").focus();
           return false;
          }
          if(document.getElementById("<%=ddlProduct.ClientID%>").value=="0")
          {
          document.getElementById("<%=ddlProduct.ClientID%>").focus();
           return false;
          }
          
          if(document.getElementById("<%=txtBasic.ClientID%>").value=="")
          {
          document.getElementById("<%=txtBasic.ClientID%>").focus();
          return false;
          }
          if(strBasic=="0")
           {
             document.getElementById("<%=txtBasic.ClientID%>").focus();
            return false;
           }
           
          if(strCategory=="Salaried")
           {
          if(document.getElementById("<%=txtHRA.ClientID%>").value=="")
          {
          document.getElementById("<%=txtHRA.ClientID%>").focus();
          return false;
          }
          if(document.getElementById("<%=txtSPAllo.ClientID%>").value=="")
          {
          document.getElementById("<%=txtSPAllo.ClientID%>").focus();
          return false;
          }
          }
          
          else
          {
         
          if(strHRA!="" )
          {
          if(strHRA!="0" )
           {
             document.getElementById("<%=ddlTypeOfCategory.ClientID %>").focus();
            return false;
           }
           }
           if(strSPAllo!="")
           {
           if(strSPAllo!="0" )
           {
            document.getElementById("<%=ddlTypeOfCategory.ClientID %>").focus();
            return false;
           }
           }
          }
          if(document.getElementById("<%=ddlCompany.ClientID%>").value=="0")
          {
          document.getElementById("<%=ddlCompany.ClientID%>").focus();
           return false;
          }
           if(document.getElementById("<%=txtApprovalMailDate.ClientID %>").value=="")
           {
          document.getElementById("<%=txtApprovalMailDate.ClientID %>").focus();
          return false;          
          }
          
           if(isDate(document.getElementById("<%=txtApprovalMailDate.ClientID %>").value)==false)
          {
           document.getElementById("<%=txtApprovalMailDate.ClientID %>").focus();
           return false;
          }
        
          if( document.getElementById("<%=txtApprovedBy.ClientID%>").value=="")
          {
          document.getElementById("<%=txtApprovedBy.ClientID%>").focus();
          return false;
          }
          return false;
          
          
           
         }
         else
         {
        
        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
       
        tblpersonalInfo1.style.display = "none";
        tblReference.style.display="block";
        tblHobby1.style.display="block"
        tblEmployementDetail1.style.display="block";
        tblEducation1.style.display="block";
      
        
        hdf.value="OtherInfo";
        
         return true;
         }
         
        }
        
      

 function ShowImg()
        {
        
        var img = document.getElementById("<%=FileUpload1.ClientID %>");
        if(img.value == null || img.value == "")
        {
        }
        else
        {
          document.getElementById("<%=PhotoImage.ClientID %>").src = img.value; 
        }
        }
        
        function TRhide()
        {
      
        var ddl = document.getElementById("<%=ddlMaritalStatus.ClientID %>");
         var tr1= document.getElementById("<%=tr.ClientID %>");
         var tab1=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        if(ddl.value=="Single")
        {
          tr1.style.display ="none";
          tab1.style.display ="none";
        }
        else
        {
       
         tr1.style.display ="block";
         tab1.style.display ="block";
        }
        
        }
        
        function TableShowPersonalInfo()
        {
        

        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
       
        tblpersonalInfo1.style.display = "block";
        tblReference.style.display="none";
        tblHobby1.style.display="none"
        tblEmployementDetail1.style.display="none";
        tblEducation1.style.display="none";
        tblChildren.style.display="block";
         tblActivity.style.display="block";
         
         
        var strBasic=document.getElementById("<%=txtBasic.ClientID %>").value;
       var strHRA=document.getElementById("<%=txtHRA.ClientID %>").value;
       var strSPALL=document.getElementById("<%=txtSPAllo.ClientID %>").value;
       var strGrossAmt=document.getElementById("<%=txtGrossAmt.ClientID %>");
       if(strBasic!=""&& strHRA!="" && strSPALL!="" && strGrossAmt!="")
       {
        convert() ;
       }
         hdf.value="PersonalInfo";
         document.getElementById("<%=txtFirstName.ClientID %>").focus();
        return false;
        
        }
        function TableOtherInfo()
        {
        

        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
    
        tblpersonalInfo1.style.display = "none";
        tblReference.style.display="block";
        tblHobby1.style.display="block"
        tblEmployementDetail1.style.display="block";
        tblEducation1.style.display="block";
        tblChildren.style.display="none";
         tblActivity.style.display="none";
         hdf.value="OtherInfo";
         document.getElementById("<%=ddlQulfication.ClientID %>").focus();
        return false;
        }
//         function TableReferenceInfo()
//        {
//        

//        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
//        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
//        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
//        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
//        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
//        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
//        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
//     
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="block";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//         hdf.value="ReferenceInfo";
//        return false;
//        }

//        function TableHobbyInfo()
//        {
//        

//        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
//        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
//        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
//        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
//        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
//        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
//        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
//       
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="block"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//          hdf.value="HobbyInfo";
//        return false;
//        }
//        function TableEmployementInfo()
//        {
//        

//        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
//        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
//        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
//        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
//        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
//        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
//        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
//      
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="block";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//         hdf.value="EmployementInfo";
//        return false;
//        }
//         function TableEducationInfo()
//        {
//        

//        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
//        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
//        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
//        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
//        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
//        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
//        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
//        
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none";
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="block";
//        tblChildren.style.display="none";
//        tblActivity.style.display="none";
//       hdf.value="EducationInfo";
//        return false;
//        }
//      function TableActivityManagerInfo()
//        {
//        

//        var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
//        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
//        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
//        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
//        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
//        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
//        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
//        
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblActivity.style.display="block";
//        tblChildren.style.display="none";
//         hdf.value="ActivityManagerInfo";
//         var strBasic=document.getElementById("<%=txtBasic.ClientID %>").value;
//       var strHRA=document.getElementById("<%=txtHRA.ClientID %>").value;
//       var strSPALL=document.getElementById("<%=txtSPAllo.ClientID %>").value;
//       var strGrossAmt=document.getElementById("<%=txtGrossAmt.ClientID %>");
//       if(strBasic!=""&& strHRA!="" && strSPALL!="" && strGrossAmt!="")
//       {
//        convert() ;
//       }
//         
//        return false;
//        }
        
  var n = "";

function validate() 
{
 var id1= document.getElementById("<%=txtGrossAmt.ClientID %>")
	if (id1.value.length == 0) 
	{
		alert ('Please Enter A Number.');
		document.myform.textver.value = "";
		return true;
	}
	else convert(input);
}

function d1(x) 
{ // single digit terms
	switch(x) 
	{
		case '0': n= ""; break;
		case '1': n= " One "; break;
		case '2': n= " Two "; break;
		case '3': n= " Three "; break;
		case '4': n= " Four "; break;
		case '5': n= " Five "; break;
		case '6': n= " Six "; break;
		case '7': n= " Seven "; break;
		case '8': n= " Eight "; break;
		case '9': n= " Nine "; break;
		default: n = "Not a Number";
	}
	return n;
}

function d2(x) 
{ // 10x digit terms
	switch(x) 
	{
		case '0': n= ""; break;
		case '1': n= ""; break;
		case '2': n= " Twenty "; break;
		case '3': n= " Thirty "; break;
		case '4': n= " Forty "; break;
		case '5': n= " Fifty "; break;
		case '6': n= " Sixty "; break;
		case '7': n= " Seventy "; break;
		case '8': n= " Eighty "; break;
		case '9': n= " Ninety "; break;
		default: n = "Not a Number";
	}
	return n;
}

function d3(x) 
{ // teen digit terms
	switch(x) 
	{
		case '0': n= " Ten "; break;
		case '1': n= " Eleven "; break;
		case '2': n= " Twelve "; break;
		case '3': n= " Thirteen "; break;
		case '4': n= " Fourteen "; break;
		case '5': n= " Fifteen "; break;
		case '6': n= " Sixteen "; break;
		case '7': n= " Seventeen "; break;
		case '8': n= " Eighteen "; break;
		case '9': n= " Nineteen "; break;
		default: n=  "Not a Number";
	}
	return n;
}

function convert() 
{

        var strCategory=document.getElementById("<%=ddlTypeOfCategory.ClientID %>").value;
        var strBasic=document.getElementById("<%=txtBasic.ClientID %>").value;
       
       var strHRA=document.getElementById("<%=txtHRA.ClientID %>").value;
       var strSPALL=document.getElementById("<%=txtSPAllo.ClientID %>").value;
       var strGrossAmt=document.getElementById("<%=txtGrossAmt.ClientID %>");
      
       if(strCategory=="Salaried")
       {
       var result=parseFloat(strBasic)+parseFloat(strHRA)+parseFloat(strSPALL);
       strGrossAmt.value=Math.round(result);
      }
      else
      strGrossAmt.value=Math.round(parseFloat(strBasic));
      
     var id= document.getElementById("<%=txtGrossAmt.ClientID %>")
 var id1= document.getElementById("<%=txtGrossInWord.ClientID %>")
	var inputlength = id.value.length;
	var x = 0;
	var teen1 = "";
	var teen2 = "";
	var teen3 = "";
	var numName = "";
	var invalidNum = "";
	var a1 = ""; // for insertion of million, thousand, hundred 
	var a2 = "";
	var a3 = "";
	var a4 = "";
	var a5 = "";
	digit = new Array(inputlength); // stores output
	
	for (i = 0; i < inputlength; i++)  
	{
		// puts digits into array
		digit[inputlength - i] = id.value.charAt(i)
	};
	
	store = new Array(9); // store output
	
	for (i = 0; i < inputlength; i++) 
	{
		x= inputlength - i;
		switch (x) 
		{ // assign text to each digit
			case x=9: d1(digit[x]); store[x] = n; break;
			case x=8: if (digit[x] == "1") {teen3 = "yes"}
					  else {teen3 = ""}; d2(digit[x]); store[x] = n; break;
			case x=7: if (teen3 == "yes") {teen3 = ""; d3(digit[x])}
					  else {d1(digit[x])}; store[x] = n; break;
			case x=6: d1(digit[x]); store[x] = n; break;
			case x=5: if (digit[x] == "1") {teen2 = "yes"}
					  else {teen2 = ""}; d2(digit[x]); store[x] = n; break;
			case x=4: if (teen2 == "yes") {teen2 = ""; d3(digit[x])}    
					  else {d1(digit[x])}; store[x] = n; break;
			case x=3: d1(digit[x]); store[x] = n; break;
			case x=2: if (digit[x] == "1") {teen1 = "yes"}
					  else {teen1 = ""}; d2(digit[x]); store[x] = n; break;
			case x=1: if (teen1 == "yes") {teen1 = "";d3(digit[x])}     
					  else {d1(digit[x])}; store[x] = n; break;
		}
		
		if (store[x] == "Not a Number"){invalidNum = "yes"};
		
		switch (inputlength)
		{
			case 1:   store[2] = ""; 
			case 2:   store[3] = ""; 
			case 3:   store[4] = ""; 
			case 4:   store[5] = "";
			case 5:   store[6] = "";
			case 6:   store[7] = "";
			case 7:   store[8] = "";
			case 8:   store[9] = "";
		}
		
		if (store[9] != "") { a1 =" Hundred, "} else {a1 = ""};
		if ((store[9] != "")||(store[8] != "")||(store[7] != ""))
		{ a2 =" Million, "} else {a2 = ""};
		if (store[6] != "") { a3 =" Hundred "} else {a3 = ""};
		if ((store[6] != "")||(store[5] != "")||(store[4] != ""))
		{ a4 =" Thousand, "} else {a4 = ""};
		if (store[3] != "") { a5 =" Hundred "} else {a5 = ""};
	}
	// add up text, cancel if invalid input found
	if (invalidNum == "yes"){numName = "Invalid Input"}
	else 
	{
		numName =  store[9] + a1 + store[8] + store[7] 
		+ a2 + store[6] + a3 + store[5] + store[4] 
		+ a4 + store[3] + a5 + store[2] + store[1];
	}
	
	store[1] = ""; store[2] = ""; store[3] = ""; 
	store[4] = ""; store[5] = ""; store[6] = "";
	store[7] = ""; store[8] = ""; store[9] = "";
	if (numName == ""){numName = "Zero"};
	id1.value = numName+" "+" Only";
	if( strGrossAmt.value=="NaN")
	{
	id1.value="";
	}
	if(isNumeric(strBasic)==false)
	{
	
	var v1=strBasic.length;
	document.getElementById("<%=txtBasic.ClientID %>").value=strBasic.substring(v1);
	alert("Please enter only numeric value in Basic");
	
	return false;
	}
	if(isNumeric(strHRA)==false)
	{
	var v1=strHRA.length;
	strHRA=strHRA.substring(strHRA.length);
	document.getElementById("<%=txtHRA.ClientID %>").value=strHRA.substring(v1);
	alert("Please enter only numeric value in HRA");
	return false;
	}
	if(isNumeric(strSPALL)==false)
	{
	var v1=strSPALL.length;
	document.getElementById("<%=txtSPAllo.ClientID %>").value=strSPALL.substring(v1);
	strSPALL=strSPALL.substring(strSPALL.length);
	alert("Please enter only numeric value in SPALL.");
	return false;
	}
	return true;
}

        function HideRelation()
        {
    
        var ddl=document.getElementById("<%=ddlRelation.ClientID %>")
        var td=document.getElementById("<%=tdRelation.ClientID %>")
        var tr=document.getElementById("<%=trRelation.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
        tr.style.display="none";
        }
        else
        {
        td.style.display ="block";
        tr.style.display="block";
        }
        }
         function HideCourt()
        {
    
        var ddl=document.getElementById("<%=ddllCourtProceeding.ClientID %>")
        var td=document.getElementById("<%=tdCourt.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        }
         function HideDisease()
        {
    
        var ddl=document.getElementById("<%=ddlContagiousDisease.ClientID %>")
        var td=document.getElementById("<%=tdDisease.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        }
       function HideBrowse()
       {
        var ddl=document.getElementById("<%=ddlCopyAttached.ClientID %>")
        var td=document.getElementById("<%=tdBrwose.ClientID %>")
        if(ddl.value=="No")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
       }
       
         function HideBank()
       {
       
        var ddl=document.getElementById("<%=ddlNameOfBank.ClientID %>")
        var td=document.getElementById("<%=tdBank.ClientID %>")
        if(ddl.value=="OTHER")
        {
        td.style.display ="block";
        
        }
        else
        td.style.display ="none";
       }
       
       
       function hidePF()
       {
     
        var ddl=document.getElementById("<%=ddlTypeOfCategory.ClientID %>")
        var hdfHo=document.getElementById("<%=hdfHOHR.ClientID %>")
        if(hdfHo=="true")
        {
        var tr=document.getElementById("<%=trpf.ClientID %>")
        }
        var td=document.getElementById("<%=tdHRA.ClientID %>")
        var td1=document.getElementById("<%=tdSPAllo.ClientID %>")
        if(ddl.value=="Professional")
        {
        if(hdfHo=="true")
        {
        tr.style.display ="none";
        }
        td.style.display="none";
        td1.style.display="none";
        }
        else
        {
        if(hdfHo=="true")
        {
        tr.style.display ="block";
        }
        td.style.display="block";
        td1.style.display="block";
        }
       }
       
       
function check(ID)

    {    
        var str=ID.value
        if(str.length==9)
        {
            var str1=str.split("-");
            if(str1.length==2)
            {
                var first=str1[0];
                var last=str1[1];
                if((isNaN(parseFloat(first))) && (isNaN(parseFloat(last))))
                {
                 return false;
                }
                else
                {
                    if(first>last)

                    {
                        return false;
                    }                   

                }
            }
            else
            {
                return false;
            }
        }
        else
        {
         return false;
        }
    }
    
function mmyyy(ID)

{ 


        var str=ID.value;
        if(str.length==15)
        {
            var str1=str.split("-");
            if(str1.length==2)
            {
                var first='01/'+str1[0];
                var last='01/'+str1[1];
                var str2=str1[0].split("/");
                var str3=str1[1].split("/");
                if(parseInt(str2[1])>parseInt(str3[1]))
                {
                return false ;
                }
                if(isDate(first)==false )
                {
                  return false;
                }
                if(isDate(last)==false)
                {
                  return false;
                }
            }
            else
            {
             return false;
            }
        }
        else
        { 
        return false;
        }

        }
    


        </script>
<fieldset><legend class="FormHeading">BIS-ENTRY</legend>&nbsp;

   <table border="0" cellpadding="2" cellspacing="3" width="100%">
       <tr>
       <td  align="left">
        <asp:Label ID="lblMsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"></asp:Label>
       </td >
           <td valign="top" align="right" colspan="3">
              
               
               <asp:Label ID="lblMode" runat="server" SkinID="lblSkin" Font-Bold="True"></asp:Label>
<asp:HiddenField ID="hdf" runat="server" />
               
               
           </td>
       </tr>

<tr>
<td valign="top"  >
    <asp:Button ID="btnPersonal" runat="server" SkinID="btn" Text="Personal/Official Detail" OnClientClick=" return TableShowPersonalInfo();" Width="161px" UseSubmitBehavior="False"/>
    <asp:Button ID="btnOther" runat="server" SkinID="btn" Text="Other Detail" OnClientClick=" return TableOtherInfo();" Width="100px" UseSubmitBehavior="False"/>
    </td>
    
<td valign="top" >
    
    
    </td>
    <td valign="top" >
    </td>
    <td valign="top" align="right" >
               </td>
</tr>

  <tr>
<td valign="top" colspan="5"  >
        <table id="tblPersonalInfo" width="100%" runat="server">
            <tr>
<td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
<strong>Personal Information</strong>
</td>
</tr>
            <tr>
                <td valign="top" style="width: 311px">
                 
                </td>
                <td style="width: 2px" valign="top">
                </td>
                <td  valign="top" style="width: 414px">
                   
               <asp:HiddenField ID="hdfPhoto" runat="server" />
                <asp:SqlDataSource ID="sdsNameOfBank" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [BankId], [BankName] FROM [BANK_MASTER] order by BankName">
                    </asp:SqlDataSource>
                    
                </td>
                <td align="center" valign="top" colspan="3">
                    
                    <span style="font-size: 14pt"><strong>Basic Information Sheet</strong></span></td>
                <td align="right" valign="top" style="width: 110px">
                </td>
                <td  valign="top">
                </td>
                <td align="left" valign="top">
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:Image ID="PhotoImage" runat="server" BorderWidth="1px" Height="115px" ImageUrl="~/Images/NoImage.gif"
                                    Width="139px" /></td>
                        </tr>
                        <tr>
                            <td style="height: 24px" valign="top">
                                <asp:FileUpload ID="FileUpload1" runat="server" onblur="javascript:ShowImg()" SkinID="flup" /></td>
                        </tr>
                    </table>
                    <span style="color: #ff0000">[Please browse only image &nbsp;file]</span></td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left"   >
                    First Name <span style="color: #ff0000">*</span></td>
                <td valign="top"  style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px"  >
                    <asp:TextBox ID="txtFirstName" runat="server" SkinID="txtSkin" MaxLength="100" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px"  ><span style="color: #000000">
                    Middle Name</span></td>
                <td valign="top"  >
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtMiddileName" runat="server" SkinID="txtSkin" MaxLength="100" OnKeyup="UpperLetter(this);"></asp:TextBox></td>
                <td valign="top" align="left" >
                    &nbsp;SurName<span style="color: #ff0000">*</span></td>
                <td valign="top" style="width: 6px" >
                    :</td>
                <td valign="top" align="left"  >
                    <asp:TextBox ID="txtLastName" runat="server" SkinID="txtSkin" MaxLength="100" OnKeyup="UpperLetter(this);" OnBlur="WindowOpen1()"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top"  style="width: 311px" align="left">
                    Father's Name</td>
                <td valign="top" >
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:TextBox ID="txtFatherName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top" style="height: 40px; width: 271px;" align="left"  >
                    DOB<span style="color: #ff0000">*</span></td>
                <td valign="top" style="width: 2px; ">
                    :</td>
                <td valign="top" style="width: 262px">
                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtSkin"  MaxLength="10"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
                <td valign="top"  align="left">
                </td>
                <td valign="top" >
                </td>
               
                <td valign="top"  align="left" >
                
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left" >
                    Name Of Bank</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:DropDownList ID="ddlNameOfBank" runat="server" SkinID="ddlSkin" DataSourceID="sdsNameOfBank" DataTextField="BankName" DataValueField="BankName" OnDataBound="ddlNameOfBank_DataBound" onchange="HideBank();" Width="130px">
                    </asp:DropDownList></td>
                <td valign="top"  align="left" style="width: 271px"  >
                </td>
                <td valign="top" >
                </td>
                <td valign="top" id="tdBank" runat="server" style="width: 262px" >
                    <asp:TextBox ID="txtNameOfBank" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px" >
                    </td>
                <td valign="top" >
                    </td>
                    <td valign="top" >
                    </td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left" >
                    A/C #</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:TextBox ID="txtAC" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px" >
                    PAN #</td>
                <td>
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtPan" runat="server" MaxLength="25" SkinID="txtSkin"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px" >
                </td>
                <td valign="top" >
                </td>
                 <td valign="top" >
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left"  >
                    Present <br />Address1<span style="color: #ff0000">*</span></td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px"  >
                    <asp:TextBox ID="txtPresentAdd1" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px" >
                    Present 
                    <br />
                    Address2</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px"   >
                    <asp:TextBox ID="txtPresentAdd2" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px"  >
                    Present <br />Address3</td>
                <td valign="top" style="width: 6px">
                    :</td>
                <td valign="top" align="left">
                    <asp:TextBox ID="txtPresentAdd3" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left">
                    City</td>
                <td style="width: 2px" valign="top">
                    :</td>
                <td style="width: 414px" valign="top">
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                <td align="left" valign="top" style="width: 271px">
                    Pin</td>
                <td style="width: 2px" valign="top">
                    :</td>
                <td valign="top" style="width: 262px">
                    <asp:TextBox ID="txtPin" runat="server" MaxLength="10" SkinID="txtSkin" onKeyUp="isNumeric1(this);"></asp:TextBox></td>
                <td align="left" style="width: 110px" valign="top">
                </td>
                <td style="width: 6px" valign="top">
                </td>
                <td align="left" valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top" align="left" style="width: 311px" >
                    Permanent <br />Address1</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:TextBox ID="txtPermanentAdd1" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px" >
                    Permanent <br />Address2</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtPerMananetAdd2" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px"  >
                    Permanent Address3</td>
                <td valign="top" style="width: 6px">
                    :</td>
                <td valign="top" align="left" >
                    <asp:TextBox ID="txtPermanentAdd3" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,200);" onkeyup="return PreventCharacterToAdd(this,200);"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left"  >
                    Present <br />Address <br />Telephone No.<span style="color: #ff0000">*</span></td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:TextBox ID="txtPhonepresentAdd" runat="server" SkinID="txtSkin" MaxLength="30"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px" >
                    Permanent <br />Address <br />Telephone No.</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px"   >
                    <asp:TextBox ID="txtPermanentTelePhoneNo" runat="server" SkinID="txtSkin" MaxLength="30"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px" >
                    Mobile No.</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" align="left" >
                    <asp:TextBox ID="txtMobileNo" runat="server" SkinID="txtSkin" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left"   >
                    Height</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px" >
                    <asp:TextBox ID="txtHieght" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px" >
                    Weight</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtWeight" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
                <td valign="top" align="left" style="width: 110px" >
                    Blood Group</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" align="left">
                    <asp:TextBox ID="txtBloodGroup" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" style="width: 311px" align="left"  >
                    Sex</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px">
                    <asp:DropDownList ID="ddlSex" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Selected="True">M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" align="left" style="width: 271px"  >
                    Marital Status</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px" >
                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" SkinID="ddlSkin" OnChange="TRhide()" Width="130px">
                        <asp:ListItem>Married</asp:ListItem>
                        <asp:ListItem>Single</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" align="left" style="width: 110px"  >
                    Language known</td>
                <td valign="top" style="width: 2px" >
                    :</td>
                <td valign="top" align="left" >
                    <asp:TextBox ID="txtLanguage" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            </tr>
            <tr id="tr" runat="server">
                <td valign="top" style="width: 311px" align="left"   >
                    Spouse Name
                </td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 414px"  >
                    <asp:TextBox ID="txtWifeName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top"  align="left" style="width: 271px"  >
                    Spouse Age</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtWifeAge" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
                <td valign="top" style="width: 110px" align="left" >
                </td>
                <td valign="top" style="width: 6px"  >
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td valign="top" colspan="3">
                    Are you related to any of our PAMACian?
                </td>
                <td valign="top"  align="left" style="width: 271px" >
                    </td>
                <td valign="top">
                    :</td>
                <td valign="top"  style="width: 262px">
                    <asp:DropDownList ID="ddlRelation" runat="server" SkinID="ddlSkin" onchange=" HideRelation();">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" align="left"  >
                    Relationship</td>
                <td valign="top" style="width: 2px" >
                    :</td>
                <td valign="top" id="tdRelation" runat="server" >
                   <asp:TextBox ID="txtRelation" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            </tr>
            <tr id="trRelation" runat="server">
                <td colspan="3" valign="top">
                    Relative PAMACian&nbsp; name</td>
                <td align="left" valign="top" style="width: 271px" >
                </td>
                <td valign="top">
                    :</td>
                <td  valign="top" style="width: 262px">
                    <asp:TextBox ID="txtRelatveName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td align="left" style="width: 110px" valign="top">
                    Relative PAMACian&nbsp; Code</td>
                <td style="width: 2px" valign="top">
                    :</td>
                <td runat="server" valign="top">
                    <asp:TextBox ID="txtRelativeCode" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" colspan="3">
                    Have you ever been involved in any court proceedings? </td>
                <td valign="top" style="width: 271px" align="left"  >
                    </td>
                <td valign="top" >
                    :</td>
                <td valign="top" style="width: 262px" >
                    <asp:DropDownList ID="ddllCourtProceeding" runat="server" SkinID="ddlSkin" onchange="HideCourt();">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top"  align="left"  >
                    Detail of Court proceeding</td>
                <td valign="top" style="width: 2px"  >
                    :</td>
                <td valign="top"  id="tdCourt" runat="server">
                    <asp:TextBox ID="txtCourtProceeding" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,250);" onkeyup="return PreventCharacterToAdd(this,250);"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" colspan="3" >
                    Have you ever been suffered from any contagious diseases? </td>
                <td valign="top" style="width: 271px" align="left"  >
                    </td>
                <td valign="top" >
                    :</td>
                <td valign="top" style="width: 262px" >
                    <asp:DropDownList ID="ddlContagiousDisease" runat="server" SkinID="ddlSkin" onchange="HideDisease();">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" align="left"  >
                    Detail of Contagious disease&nbsp;</td>
                <td valign="top"  >
                    :</td>
                <td valign="top"  id="tdDisease" runat="server" >
                    <asp:TextBox ID="txtCountagiosDisease" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,250);" onkeyup="return PreventCharacterToAdd(this,250);"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" colspan="3" >
                    I here by nominate 
                    <asp:DropDownList ID="ddlTitle" runat="server" SkinID="ddlSkin">
                        <asp:ListItem>Shri</asp:ListItem>
                        <asp:ListItem>Smt</asp:ListItem>
                        <asp:ListItem>Kum</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" align="left" style="width: 271px"   >
                    &nbsp;Nominee Name</td>
                <td valign="top" >
                    :</td>
                <td valign="top" style="width: 262px"  >
                    <asp:TextBox ID="txtNominee" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top"  align="left">
                    Nominee relation</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" align="left" >
                    <asp:DropDownList ID="ddlNomineeTitle" runat="server" SkinID="ddlSkin" onchange="candidate();">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>B/O</asp:ListItem>
                        <asp:ListItem>D/O</asp:ListItem>
                        <asp:ListItem>F/O</asp:ListItem>
                        <asp:ListItem>M/O</asp:ListItem>
                        <asp:ListItem>S/O</asp:ListItem>
                        <asp:ListItem>W/O</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCandidate" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" colspan="3"  >
                    to collect all my dues in case of my death</td>
                <td valign="top" align="right" style="width: 271px"  >
                    &nbsp;&nbsp;</td>
                <td valign="top" >
                </td>
                <td valign="top" style="width: 262px"   >
                    </td>
                <td valign="top" align="right" >
                </td>
                <td valign="top" >
                </td>
                <td valign="top" align="right"  >
                    &nbsp;</td>
            </tr>
             <tr>
                <td colspan="9"  valign="top">
                <table id="tblChildrenDetail" width="100%" runat="server"  >
        <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
<strong>Children Detail</strong>
</td>
        </tr>
        <tr>
            <td valign="top" >
                Name of Child</td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtNameOfChild" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td valign="top" >
                Age of Child</td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtAgeOfChild" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
            <td valign="top"  align="right">
                </td>
            <td valign="top" >
                </td>
            <td valign="top" align="right" >
                <asp:Button ID="btnSaveChildInfo" runat="server" Text="Button" SkinID="btnAddNewSkin" OnClick="btnSaveChildInfo_Click"  OnClientClick="return valChild();" Width="60px" />
                </td>
        </tr>
        <tr>
            <td valign="top" colspan="9" align="right" >
                <asp:GridView ID="GVChildDetail" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin" Width="100%" OnRowDataBound="GVChildDetail_RowDataBound" AllowSorting="True" OnRowDeleting="GVChildDetail_RowDeleting" OnRowEditing="GVChildDetail_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="Child Name" HeaderText="Child Name">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Child Age" HeaderText="Child Age">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Edit"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmpChild" runat="server" 
                                  CommandName="Edit"><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
                             <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                         CommandName="Delete"><img src="../../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        

                                </ItemTemplate>
                                <ItemStyle Width="20px" VerticalAlign="Top" />
                            <HeaderStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                        
                    </Columns>
                    
                </asp:GridView>
               
    <asp:HiddenField ID="hdfInsUPChid" runat="server" />
              
             
               
              
              
            </td>
        </tr>
    </table>

                </td>
            </tr>
            <tr>
                <td colspan="9" valign="top" >
                 <table width="100%" id="tblActivityManager" runat="server" >
        <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
    <strong>Official Detail</strong></td>
        </tr>
        <tr>
            <td valign="top"  >
                Date of Joining<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtDOJ" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDOJ.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
            <td valign="top"  >
                Designation<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:DropDownList ID="ddlDesignation" runat="server" SkinID="ddlSkin" DataSourceID="sdsDesignation" DataTextField="DESIGNATION" DataValueField="DESIGNATION_ID" OnDataBound="ddlDesignation_DataBound" Width="130px">
                </asp:DropDownList></td>
            <td valign="top" >
                Unit <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" align="left"  >
                <asp:DropDownList ID="ddlUnit" runat="server" SkinID="ddlSkin" DataSourceID="sdsActivity" DataTextField="ACTIVITY_NAME" DataValueField="ACTIVITY_ID" OnDataBound="ddlUnit_DataBound" Width="130px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td valign="top"   >
                Type of Category <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px; ">
                :</td>
            <td valign="top" >
                <asp:DropDownList ID="ddlTypeOfCategory" runat="server" SkinID="ddlSkin" onchange="hidePF();" Width="130px">
                    <asp:ListItem>Salaried</asp:ListItem>
                    <asp:ListItem>Professional</asp:ListItem>
                </asp:DropDownList></td>
            <td valign="top" >
                Department <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px; ">
                :</td>
            <td >
                <asp:DropDownList ID="ddlDepartment" runat="server" SkinID="ddlSkin" DataSourceID="sdsDepartment" DataTextField="DEPARTMENT" DataValueField="DEPT_ID" OnDataBound="ddlDepartment_DataBound" Width="130px">
                </asp:DropDownList></td>
            <td valign="top" >
            </td>
            <td valign="top" >
            </td>
            <td valign="top" align="left"  >
            </td>
        </tr>
        <tr>
            <td valign="top"  >
                Client <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:DropDownList ID="ddlClient" runat="server" DataSourceID="sdsClient" DataTextField="CLIENT_NAME"
                    DataValueField="CLIENT_ID" SkinID="ddlSkin" OnDataBound="ddlClient_DataBound" Width="130px">
                </asp:DropDownList></td>
            <td valign="top"  >
                Product <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td >
                <asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="sdsProduct" DataTextField="PRODUCT_NAME"
                    DataValueField="PRODUCT_ID" SkinID="ddlSkin" OnDataBound="ddlProduct_DataBound" Width="130px">
                </asp:DropDownList></td>
            <td>
            </td>
            <td valign="top" >
            </td>
            <td valign="top" align="left" >
            </td>
        </tr>
        <tr>
            <td valign="top" >
                Basic <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtBasic" runat="server" SkinID="txtSkin" OnKeyUp="convert();"   MaxLength="5" ></asp:TextBox></td>
            <td valign="top" >
                HRA <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" id="tdHRA" runat="server" >
                <asp:TextBox ID="txtHRA" runat="server" SkinID="txtSkin" OnKeyUp="convert();"  MaxLength="5"></asp:TextBox></td>
            <td valign="top" >
               SP.Allowance <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" align="left" id="tdSPAllo" runat="server">
                <asp:TextBox ID="txtSPAllo" runat="server" SkinID="txtSkin" OnKeyUp="convert();"   MaxLength="5"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" >
                Gross Amount(P.M.) <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtGrossAmt" runat="server" SkinID="txtSkin" ReadOnly="True" ></asp:TextBox></td>
            <td valign="top"   >
                Gross Amt (In Words)<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" colspan="4" align="left">
                <asp:TextBox ID="txtGrossInWord" runat="server" Width="500px" SkinID="txtSkin" ReadOnly="True" ></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" >
                Company Code <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:DropDownList ID="ddlCompany" runat="server" DataSourceID="sdsCompanyID" DataTextField="COMPANY_NAME" DataValueField="COMPANY_ID" SkinID="ddlSkin" OnDataBound="ddlCompany_DataBound" Width="130px">
                </asp:DropDownList></td>
            <td valign="top"  >
                Approval Mail Date <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td >
                <asp:TextBox ID="txtApprovalMailDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtApprovalMailDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
            <td>
                Approved By <span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" align="left" >
                <asp:TextBox ID="txtApprovedBy" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" colspan="3"  >
                <strong>Activity Manager Detail </strong></td>
            <td valign="top"  >
                EMP Code <span style="color: #ff0000">*</span></td>
            <td valign="top" >
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtEMPCodeActivityManager" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td valign="top" >
                EMP Name <span style="color: #ff0000">*</span></td>
            <td valign="top" >
                :</td>
            <td valign="top" align="left" >
                <asp:TextBox ID="txtEMPNameActivityManager" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td align="center" colspan="9" valign="top">
                <asp:Button ID="btnSavePersonal" runat="server" Text="Next" SkinID="btn" OnClick="btnSavePersonal_Click" OnClientClick=" return WidowOpen();" ValidationGroup="ValPersonalInfo" Width="60px" />&nbsp;
            </td>
        </tr>
    </table>

                </td>
            </tr>
        </table>
        </td>
        </tr>

<tr>
<td valign="top" colspan="5" >
<table width="100%" id="tblEducation" runat="server" style="display: none">
    <tr>
       <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
<strong>Education/Qualification &nbsp;Information</strong>
</td>
    </tr>
            <tr>
                <td valign="top" >
                    Type Of Qualification</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 158px" >
                    <asp:DropDownList ID="ddlQulfication" runat="server" SkinID="ddlSkin" Width="130px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Educational</asp:ListItem>
                        <asp:ListItem>Professional</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" >
                    Certificate Examination</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" >
                    <asp:TextBox ID="txtCertificate" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top" >
                    Name Of College/Institute</td>
                <td valign="top" style="width: 6px">
                    :</td>
                <td valign="top" style="width: 100px">
                    <asp:TextBox ID="txtNameOfCollage" runat="server" SkinID="txtSkin" MaxLength="250"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" >
                    From-To Year</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 158px" >
                    <asp:TextBox ID="txtFromToYear" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox>[yyyy-yyyy]</td>
                <td valign="top" >
                    Div/Marks</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" >
                    <asp:TextBox ID="txtDivMarks" runat="server" SkinID="txtSkin" MaxLength="20"></asp:TextBox></td>
                <td valign="top" >
                </td>
                <td valign="top" style="width: 6px" >
                </td>
                <td valign="top" >
                </td>
            </tr>
            <tr>
                <td valign="top"  >
                    Copy Attached</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="height: 25px; width: 158px;" >
                    <asp:DropDownList ID="ddlCopyAttached" runat="server" SkinID="ddlSkin" onchange="HideBrowse();">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList></td>
                <td valign="top" >
                </td>
                <td valign="top"  >
                </td>
                <td valign="top"  id="tdBrwose" runat="server">
                    <asp:FileUpload ID="FileUpload2" runat="server" SkinID="flup" /></td>
                <td valign="top" >
                    <span style="color: #ff0000">[Please browse only image &nbsp;file]</span></td>
                <td style="width: 6px">
                </td>
                <td valign="top" align="right" >
                    <asp:Button ID="btnSaveEducation" runat="server" SkinID="btnSaveSkin" Text="Button" OnClick="btnSaveEducation_Click" OnClientClick="return ValEducation();" Width="60px" />
                    &nbsp;
                </td>
            </tr>
    <tr>
        <td valign="top" colspan="9">
            <asp:GridView ID="gvQualification" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False" DataSourceID="sdsQualification" Width="100%" OnRowCommand="gvQualification_RowCommand" OnRowDataBound="gvQualification_RowDataBound" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="Type_of_Qualification" HeaderText="Type of Qualification" ItemStyle-HorizontalAlign="left"/>
                    <asp:BoundField DataField="Name_of_College" HeaderText="Name of College/Institute" ItemStyle-HorizontalAlign="left"/>
                    <asp:BoundField DataField="Duration_of_Education" HeaderText="From-To Year" ItemStyle-HorizontalAlign="left"/>
                    <asp:BoundField DataField="Certificate_Examination" HeaderText="Certificate Examination" ItemStyle-HorizontalAlign="left"/>
                    <asp:BoundField DataField="Div_Marks" HeaderText="Div/Marks" ItemStyle-HorizontalAlign="left"/>
                    <asp:BoundField DataField="Copies_Attached" HeaderText="Copy Attached" ItemStyle-HorizontalAlign="left"/>
                    <asp:TemplateField HeaderText="View File" >						
				    <ItemTemplate>
				    
                    <asp:HyperLink ID="lnkView" runat="server" ForeColor="#B1005D" Font-Bold="true" NavigateUrl='<%#"EmployeeDocument/" + Eval("File_Path")%>' Target="_blank" >View</asp:HyperLink>                    						                        
				    </ItemTemplate>
			    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmpQualification" runat="server" CommandArgument='<%# Eval("Education_Qualification_Id") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdeleteEmpQualification" runat="server" CommandArgument='<%# Eval("Education_Qualification_Id") %>'
                                CommandName="del" ><img src="../../Images/icon_delete.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
            </asp:TemplateField>
                </Columns>
            </asp:GridView>
         
            <asp:SqlDataSource ID="sdsQualification" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EM.[TEMP_EMP_CODE] ,[Education_Qualification_Id], [Name_of_College], [Duration_of_Education], [Certificate_Examination], [Div_Marks], [Copies_Attached], [Type_of_Qualification],[File_Path]  FROM [EMPLOYEE_EDUCATION_QUALIFICATION] EDQ INNER JOIN EMPLOYEE_MASTER EM ON(EM.EMP_ID=EDQ.EMP_ID) WHERE (EDQ.[Emp_Id] = ?) ORDER BY Education_Qualification_Id desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdfEMPID" Name="Emp_Id" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
            <asp:HiddenField ID="hdfEducation" runat="server" />
            <%--<asp:RequiredFieldValidator ID="revNameOfCollege" runat="server" ErrorMessage="Please put the name of college" Display="None" SetFocusOnError="True" ControlToValidate="txtNameOfCollage" ValidationGroup="ValEdu"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="revduration" runat="server" ErrorMessage="Please put the From-To Year" Display="None" SetFocusOnError="True" ValidationGroup="ValEdu" ControlToValidate="txtFromToYear"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="revCertificate" runat="server" ErrorMessage="Please put the certificate name" Display="None" SetFocusOnError="True" ValidationGroup="ValEdu" ControlToValidate="txtCertificate"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="revDivMark" runat="server" ErrorMessage="Please put the Div/marks" Display="None" SetFocusOnError="True" ValidationGroup="ValEdu" ControlToValidate="txtDivMarks"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="ValCumCopy" runat="server" Display="None" ErrorMessage="Please brwose the file"
                SetFocusOnError="True" ValidationGroup="ValEdu" ClientValidationFunction="valcopy"></asp:CustomValidator>
            <asp:ValidationSummary ID="ValSummEdu" runat="server" ValidationGroup="ValEdu" ShowMessageBox="True" ShowSummary="False" />--%>
        </td>
    </tr>
        </table>
</td>
</tr>
<tr>
<td valign="top" colspan="5">
<table width ="100%" id="tblEmployementDetail" runat="server" style="display: none">
    <tr>
        <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;" >
    <strong>Employment Detail</strong>
        </td>
    </tr>
            <tr>
                <td valign="top" style="width: 127px" >
                    Employer's Name</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" >
                    <asp:TextBox ID="txtEmployerName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top" >
                    Employed&nbsp; From-To</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" >
                    <asp:TextBox ID="txtFrom_To" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox>[mm/yyyy-mm/yyyy]</td>
                <td>
                    Last
                    Salary Drawn</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" style="width: 100px; height: 17px;">
                    <asp:TextBox ID="txtSalary" runat="server" SkinID="txtSkin" OnKeyUp="isNumeric1(this);" KyePress="isNumeric1(this);" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" style="width: 127px" >
                    Reason for Leaving</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top" >
                    <asp:TextBox ID="txtReasonforLeaving" runat="server" SkinID="txtSkin" MaxLength="250" TextMode="MultiLine" onkeypress="return PreventCharacterToAdd(this,250);" onkeyup="return PreventCharacterToAdd(this,250);" Width="194px"></asp:TextBox></td>
                <td valign="top" >
                    Designation</td>
                <td valign="top" style="width: 2px">
                    :</td>
                <td valign="top">
                    <asp:TextBox ID="txtDesignation" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                <td valign="top" style="width: 100px" align="left">
                    Contact No.<span style="color: #ff0000">*</span></td>
                <td valign="top" >
                    :</td>
                <td valign="top" align="left" >
                    <asp:TextBox ID="txtEmploeeContact" runat="server" MaxLength="30" SkinID="txtSkin"></asp:TextBox>&nbsp;
                    </td>
            </tr>
    <tr>
        <td valign="top" style="width: 127px">
        </td>
        <td style="width: 2px" valign="top">
        </td>
        <td valign="top">
        </td>
        <td valign="top">
        </td>
        <td style="width: 2px" valign="top">
        </td>
        <td>
        </td>
        <td align="right" style="width: 100px" valign="top">
        </td>
        <td valign="top">
        </td>
        <td align="right" valign="top">
                    <asp:Button ID="btnSaveEmployement" runat="server" Text="Button" SkinID="btnSaveSkin" OnClick="btnSaveEmployement_Click"  OnClientClick="return ValEmployee();" Width="60px" />&nbsp;
        </td>
    </tr>
            <tr>
                <td valign="top" colspan="9" >
                    <asp:GridView ID="gvEmployementDetail" runat="server" AutoGenerateColumns="False" DataSourceID="sdsEmploymentDetail" SkinID="gridviewNoSort" Width="100%" OnRowCommand="gvEmployementDetail_RowCommand" OnRowDataBound="gvEmployementDetail_RowDataBound" AllowSorting="True">
                        <Columns>
                            <asp:BoundField DataField="Employer_Name" HeaderText="Employer Name" ItemStyle-HorizontalAlign="left"/>
                            <asp:BoundField DataField="Duration_of_Employment" HeaderText="Employed From-To" ItemStyle-HorizontalAlign="left"/>
                            <asp:BoundField DataField="Salary" HeaderText="Salary" ItemStyle-HorizontalAlign="Right"/>
                            <asp:BoundField DataField="Reason_of_Leaving" HeaderText="Reason For Leaving" ItemStyle-HorizontalAlign="left"/>
                            <asp:BoundField DataField="Designation_Nature_job" HeaderText="Designation &amp; Nature of Job" ItemStyle-HorizontalAlign="left"/>
                            <asp:BoundField DataField="Contact_No" HeaderText="Contact No" ItemStyle-HorizontalAlign="left"/>
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkEditEmpEmployement" runat="server" CommandArgument='<%# Eval("Employement_Detail_Id") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdeleteEmpQualification" runat="server" CommandArgument='<%# Eval("Employement_Detail_Id") %>'
                                CommandName="del" ><img src="../../Images/icon_delete.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="sdsEmploymentDetail" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Employement_Detail_Id], [Duration_of_Employment], [Employer_Name], [Salary], [Reason_of_Leaving], [Designation_Nature_job],[Contact_No] FROM [EMPLOYEE_EMPLOYMENT_DETAIL] WHERE ([Emp_id] = ?) ORDER BY Employement_Detail_Id desc">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdfEMPID" Name="Emp_id" PropertyName="Value" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                   
                    <asp:HiddenField ID="hdfEmployement" runat="server" />
                   <%-- <asp:RequiredFieldValidator ID="revEmployerName" runat="server" ErrorMessage="Please put the employer name" ControlToValidate="txtEmployerName" Display="None" SetFocusOnError="True" ValidationGroup="valEMP"></asp:RequiredFieldValidator>
                   <asp:RequiredFieldValidator ID="revEmolyerFromTo" runat="server" ErrorMessage="please put the Employed From-To " ControlToValidate="txtFrom_To" Display="None" SetFocusOnError="True" ValidationGroup="valEMP"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="revSalary" runat="server" ErrorMessage="Please put the Salary" ControlToValidate="txtSalary" Display="None" SetFocusOnError="True" ValidationGroup="valEMP"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="revReason" runat="server" ErrorMessage="Please put the reason pf leaving" ControlToValidate="txtReasonforLeaving" Display="None" SetFocusOnError="True" ValidationGroup="valEMP"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="revDesignation" runat="server" ErrorMessage="Please put the designation" ControlToValidate="txtDesignation" Display="None" SetFocusOnError="True" ValidationGroup="valEMP"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="ValSummEmployer" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valEMP" />--%>
                </td>
            </tr>
        </table>
        
</td>
</tr>

<tr>
<td valign="top" colspan="5" >
    <table width="100%" id="tblHobby" runat="server" style="display: none">
        <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
    <strong>Hobby/Interest</strong>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 81px"  >
                Literary/Cultural/Art</td>
            <td valign="top" style="width: 2px">
            :
            </td>
            <td valign="top" style="width: 122px" >
                <asp:TextBox ID="txtLiterary" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td valign="top" >
                Sport</td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtSport" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td valign="top" >
                Hobby</td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtHobby" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 81px" >
            </td>
            <td valign="top" >
            </td>
            <td valign="top" style="width: 122px" >
            </td>
            <td valign="top"  >
            </td>
            <td valign="top" >
            </td>
            <td valign="top"  >
            </td>
            <td valign="top" align="right" >
                </td>
            <td valign="top"  >
            </td>
            <td valign="top" align="right"  >
                &nbsp;<asp:Button ID="btnSaveHobby" runat="server" Text="Button" SkinID="btnSaveSkin" OnClick="btnSaveHobby_Click" OnClientClick="return ValHobby();" Width="60px"/>
                </td>
        </tr>
        <tr>
            <td valign="top" colspan="9" >
                <asp:GridView ID="GVHobby" runat="server" AutoGenerateColumns="False" DataSourceID="sdsHobby" SkinID="gridviewSkin" Width="100%" OnRowCommand="GVHobby_RowCommand" OnRowDataBound="GVHobby_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Literary_Cultural_Art" HeaderText="Literary/Cultural/Art" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Sports" HeaderText="Sports" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Hobbies" HeaderText="Hobbies" ItemStyle-HorizontalAlign="left"/>
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmpHobby" runat="server" CommandArgument='<%# Eval("Hobby_Interest_Detail_id") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdeleteEmpHobby" runat="server" CommandArgument='<%# Eval("Hobby_Interest_Detail_id") %>'
                                CommandName="del" ><img src="../../Images/icon_delete.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="sdsHobby" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Hobby_Interest_Detail_id], [Literary_Cultural_Art], [Sports], [Hobbies] FROM [EMPLOYEE_HOBBY] WHERE ([Emp_Id] = ?) ORDER BY Hobby_Interest_Detail_id desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdfEMPID" Name="Emp_Id" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                <asp:HiddenField ID="hdfHobby" runat="server" />
            </td>
        </tr>
    </table>
</td>
</tr>

<tr>
<td valign="top" colspan="5" >
    <table width="100%" id="tblReferenceDetail" runat="server"  style="display: none">
     <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
    <strong>Reference Detail</strong></td>
        </tr>
        <tr>
            <td valign="top" style="width: 91px" >
                Reference Name<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtReferenceName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td valign="top" >
                Reference Address<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtReferenceAddress" runat="server" SkinID="txtSkin" MaxLength="250" TextMode="MultiLine" Width="194px" onkeypress="return PreventCharacterToAdd(this,250);" onkeyup="return PreventCharacterToAdd(this,250);"></asp:TextBox></td>
            <td valign="top"  >
                Occupation<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtOccupation" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td valign="top" style="width: 91px" >
                Relation<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtRelationReference" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
            <td valign="top" >
                Contact No.<span style="color: #ff0000">*</span></td>
            <td valign="top" style="width: 2px">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtContactNo" runat="server" SkinID="txtSkin" MaxLength="30"></asp:TextBox></td>
            <td valign="top"  align="right">
                </td>
            <td valign="top" style="width: 2px" >
            </td>
            <td valign="top" align="right" >
                <asp:Button ID="btnSaveReference" runat="server" Text="Button" SkinID="btnSaveSkin" OnClick="btnSaveReference_Click" OnClientClick="return ValReference();" Width="60px" />
                </td>
        </tr>
        <tr>
            <td valign="top" colspan="9" >
                <asp:GridView ID="GVReferenceDetail" runat="server" AutoGenerateColumns="False" DataSourceID="sdsReferenceDetail" SkinID="gridviewNoSort" Width="100%" OnRowCommand="GVReferenceDetail_RowCommand" OnRowDataBound="GVReferenceDetail_RowDataBound" AllowSorting="True">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Relation" HeaderText="Relation" ItemStyle-HorizontalAlign="left"/>
                        <asp:BoundField DataField="Contact_No" HeaderText="Contact No" ItemStyle-HorizontalAlign="right"/>
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmpReference" runat="server" CommandArgument='<%# Eval("Reference_Detail_id") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdeleteEmpReference" runat="server" CommandArgument='<%# Eval("Reference_Detail_id") %>'
                                CommandName="del" ><img src="../../Images/icon_delete.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <asp:SqlDataSource ID="sdsReferenceDetail" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Reference_Detail_id], [Name], [Address], [Occupation], [Relation], [Contact_No] FROM [EMPLOYEE_REFERENCE_DETAIL] WHERE ([Emp_id] = ?) ORDER BY  Reference_Detail_id desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdfEMPID" Name="Emp_id" PropertyName="Value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
               
                <asp:HiddenField ID="hdfReference" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="9" valign="top">
                <asp:Button ID="btnConfirm" runat="server" SkinID="btn" Text="Confirm" OnClientClick=" return confirmGV();" OnClick="btnConfirm_Click"  /></td>
        </tr>
    </table>

</td>
</tr>

<tr>
<td valign="top" colspan="5" style="height: 18px" >
   
</td>
</tr>
<tr>
<td valign="top" colspan="5">
    <table width="100%" id="tblClusterHR" runat="server" visible="false">
        <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
    <strong>Approve by Cluster-HR</strong></td>
        </tr>
        <tr>
            <td valign="top"  colspan="2" >
                PAMACian Code Of Cluster HR</td>
            <td valign="top" style="height: 30px">
                :</td>
            <td valign="top" style="height: 30px" >
                <asp:TextBox ID="txtEMPCodeOfClusterHR" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td valign="top"  colspan="2" >
                PAMACian Name Of Cluster HR</td>
            <td valign="top" >
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtEMPNameOfCluster" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td valign="top" align="right"  >
                <asp:Button ID="btnDedupCluster" runat="server" SkinID="btn" Text="Dedup" Visible="False" OnClientClick="WindowOpen1();" />
                <asp:Button ID="btnApproveCluster" runat="server" Text="Approve" SkinID="btn" OnClick="btnApproveCluster_Click" Width="60px" /></td>
        </tr>
    </table>

</td>
</tr>

<tr>
<td valign="top" colspan="5" >
    <table width="100%" id="tblHOHR" runat="server" visible="false">
        <tr>
            <td valign="top" colspan="9" style="background-color:#D0D5D8; height: 14px; width: 942px;">
    <strong>Approve by HO-HR</strong></td>
        </tr>
        <tr>
            <td valign="top" colspan="2" style="width: 135px">
                New Joinee
               PAMACian Code</td>
            <td valign="top" style="width: 2px;">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtEmpCode" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox></td>
             <td valign="top" colspan="2" style="width: 135px">
                PF #</td>
            <td valign="top" style="width: 2px;">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtPF" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
             <td valign="top" colspan="2" style="width: 190px">
                ESIC #</td>
            <td valign="top" style="width: 2px; ">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtESIC" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
            <td valign="top" >
            </td>
            <td valign="top" >
            </td>
        </tr>
        <tr id="trpf" runat="server">
        <td valign="top" colspan="2" style="width: 190px">
                DOL</td>
            <td valign="top" style="width: 2px; ">
                :</td>
          <td>
                <asp:TextBox ID="txtLastWorkingDay" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox><br />
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtLastWorkingDay.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
        <td valign="top" colspan="2" style="width: 190px">
                Dol Reason</td>
            <td valign="top" style="width: 2px; ">
                :</td>
         
          <td><asp:DropDownList ID="ddldolreason" runat="server" SkinID="ddlSkin">
          <asp:ListItem Value="0">Select</asp:ListItem>
          <asp:ListItem>Resigned with Notice</asp:ListItem>
          <asp:ListItem>Resigned without Notice</asp:ListItem>
          <asp:ListItem>Left without Intimation</asp:ListItem>
          <asp:ListItem>Fraud and Fired.</asp:ListItem>
          <asp:ListItem>Retrenchment</asp:ListItem>
          </asp:DropDownList></td>
            <td valign="top" colspan="2" style="width: 190px">
                </td>
            <td valign="top" style="width: 2px">
                </td>
            <td>
                </td>
            <td>
            </td>
          </tr>
           <tr>
           
                 <td valign="top" colspan="2" style="width: 135px">
                Kit Received Date</td>
            <td valign="top" style="width: 2px">
                :</td>
            <td>
                <asp:TextBox ID="txtKitRedeivedDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtKitRedeivedDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
          
       
            <td valign="top" colspan="2" style="width: 135px">
                PAMACian Code Of &nbsp;HO-HR</td>
            <td valign="top" style="width: 2px; ">
                :</td>
            <td valign="top" >
                <asp:TextBox ID="txtEMPCodeOfHOHR" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td valign="top" colspan="2" style="width: 190px">
                PAMACian Name Of HO-HR</td>
            <td valign="top" style="width: 2px;">
                :</td>
            <td valign="top"  >
                <asp:TextBox ID="txtEMPOfNameHOHR" runat="server" SkinID="txtSkin" ReadOnly="True"></asp:TextBox></td>
            <td valign="top" align="right" >
                <asp:Button ID="btnDedupHo" runat="server" SkinID="btn" Text="Dedup" OnClientClick="WindowOpen1();" Visible="False" />
                <asp:Button ID="btnApproveHOHR" runat="server" Text="Approve" SkinID="btn" OnClick="btnApproveHOHR_Click" ValidationGroup="ValApp" Width="60px"  /></td>
        </tr>
    </table>
</td>
</tr>
</table>
   
    </fieldset>
    <asp:HiddenField ID="hdfHOHR" runat="server" />
   <script language="JAVASCRIPT" type="text/javascript"> 

     var hdf=document.getElementById("<%=hdf.ClientID %>");
       var tblpersonalInfo1=document.getElementById("<%=tblPersonalInfo.ClientID %>");
        var tblChildren=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        var tblEducation1=document.getElementById("<%=tblEducation.ClientID %>");
        var tblEmployementDetail1=document.getElementById("<%=tblEmployementDetail.ClientID %>");
        var tblHobby1=document.getElementById("<%=tblHobby.ClientID %>");
        var tblReference=document.getElementById("<%=tblReferenceDetail.ClientID %>");
        var tblActivity=document.getElementById("<%=tblActivityManager.ClientID %>");
       
    if(hdf.value=="PersonalInfo")
    {
        tblpersonalInfo1.style.display = "block";
        tblReference.style.display="none";
        tblHobby1.style.display="none"
        tblEmployementDetail1.style.display="none";
        tblEducation1.style.display="none";
        tblChildren.style.display="block";
         tblActivity.style.display="block";
         document.getElementById("<%=txtFirstName.ClientID %>").focus();
    }
    if(hdf.value=="OtherInfo")
    {
        
         tblpersonalInfo1.style.display = "none";
        tblReference.style.display="block";
        tblHobby1.style.display="block"
        tblEmployementDetail1.style.display="block";
        tblEducation1.style.display="block";
        tblChildren.style.display="none";
         tblActivity.style.display="none";
        document.getElementById("<%=ddlQulfication.ClientID %>").focus();
    }
//    if(hdf.value=="ReferenceInfo")
//    { 
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="block";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//    
//    }
//    if(hdf.value=="HobbyInfo")
//    {
//        tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="block"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//    }
//    if(hdf.value=="EmployementInfo")
//    {
//         tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="block";
//        tblEducation1.style.display="none";
//        tblChildren.style.display="none";
//         tblActivity.style.display="none";
//    }
//    if(hdf.value=="EducationInfo")
//    {
//         tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="block";
//        tblChildren.style.display="none";
//        tblActivity.style.display="none";
//    }
//    if(hdf.value=="ActivityManagerInfo")
//    {
//      tblpersonalInfo1.style.display = "none";
//        tblReference.style.display="none";
//        tblHobby1.style.display="none"
//        tblEmployementDetail1.style.display="none";
//        tblEducation1.style.display="none";
//        tblActivity.style.display="block";
//        tblChildren.style.display="none";
//    }
    
    
     
        var ddl=document.getElementById("<%=ddlRelation.ClientID %>")
        var td=document.getElementById("<%=tdRelation.ClientID %>")
         var tr=document.getElementById("<%=trRelation.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
         tr.style.display="none";
        }
        else
        {
        td.style.display ="block";
        tr.style.display="block";
        }
        
          var ddl=document.getElementById("<%=ddllCourtProceeding.ClientID %>")
        var td=document.getElementById("<%=tdCourt.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        
        var ddl=document.getElementById("<%=ddlContagiousDisease.ClientID %>")
        var td=document.getElementById("<%=tdDisease.ClientID %>")
        if(ddl.value=="N")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        
         var ddl=document.getElementById("<%=ddlCopyAttached.ClientID %>")
        var td=document.getElementById("<%=tdBrwose.ClientID %>")
        if(ddl.value=="No")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        
        
         var ddl=document.getElementById("<%=ddlNameOfBank.ClientID %>")
        var td=document.getElementById("<%=tdBank.ClientID %>")
        if(ddl.value=="OTHER")
        {
        td.style.display ="none";
        }
        else
        td.style.display ="block";
        
        
        
        
var SurName=document.getElementById("<%=txtLastName.ClientID %>").value;
var FirstName=document.getElementById("<%=txtFirstName.ClientID %>").value;
var MiddileName=document.getElementById("<%=txtMiddileName.ClientID %>").value;

var Name=document.getElementById("<%=txtCandidate.ClientID %>").value=FirstName+' '+MiddileName+' '+SurName;

//for Name of Bank
        var ddl=document.getElementById("<%=ddlNameOfBank.ClientID %>")
        var td=document.getElementById("<%=tdBank.ClientID %>")
        var hdfHo=document.getElementById("<%=hdfHOHR.ClientID %>")
        if(ddl.value=="OTHER")
        {
        td.style.display ="block";
        
        }
        else
        td.style.display ="none";
       
        var ddl=document.getElementById("<%=ddlTypeOfCategory.ClientID %>")
        if(hdfHo.value=="true")
        {
        var tr=document.getElementById("<%=trpf.ClientID %>")
        }
        var td=document.getElementById("<%=tdHRA.ClientID %>")
        var td1=document.getElementById("<%=tdSPAllo.ClientID %>")
        if(ddl.value=="Professional")
        {
         if(hdfHo.value=="true")
        {
        tr.style.display ="none";
        }
        td.style.display="none";
        td1.style.display="none";
        }
        else
        {
        td.style.display="block";
        td1.style.display="block";
        if(hdfHo.value=="true")
        {
        tr.style.display ="block";
        }
        }
       convert() 
function confirmGV()
{

var gvQualificationID=document.getElementById("<%=gvQualification.ClientID %>");
var gvReferenceID=document.getElementById("<%=GVReferenceDetail.ClientID %>");

var strmessage="";
if(gvQualificationID==null)
{
strmessage +=" Minimum one Qualification Detail Required"+"\n";

}
if(gvReferenceID==null)
{
strmessage +="Minimum one Reference Detail Required "+"\n";

}
if(strmessage!="")
{
alert(strmessage);

if(gvQualificationID==null)
{
document.getElementById("<%=ddlQulfication.ClientID %>").focus();
return false;
}
if(gvReferenceID==null)
{
document.getElementById("<%=txtReferenceName.ClientID %>").focus();
return false;
}
return false
}
else
{
return true
}
}
  var ddl = document.getElementById("<%=ddlMaritalStatus.ClientID %>");
         var tr1= document.getElementById("<%=tr.ClientID %>");
         var tab1=document.getElementById("<%=tblChildrenDetail.ClientID %>");
        if(ddl.value=="Single")
        {
          tr1.style.display ="none";
          tab1.style.display ="none";
        }
        else
        {
       
         tr1.style.display ="block";
         tab1.style.display ="block";
        }
        
        
   </script>

    
    
    <asp:ValidationSummary ID="ValPersonal" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValPersonalInfo" />
    <asp:RegularExpressionValidator ID="regDOB" runat="server" ControlToValidate="txtDOB"
                            Display="None" ErrorMessage="Please enter valid date format for DOB."
                            SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="ValPersonalInfo"></asp:RegularExpressionValidator>&nbsp;
    <asp:CustomValidator ID="CVDesignation" runat="server" ControlToValidate="ddlDesignation"
        ErrorMessage="Please enter the Designation" ClientValidationFunction="ClientValidate" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:CustomValidator ID="CVDepartment" runat="server" ErrorMessage="Please enter the Department" ClientValidationFunction="ClientValidate" ControlToValidate="ddlDepartment" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:SqlDataSource ID="sdsActivity" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [ACTIVITY_ID], [ACTIVITY_NAME] FROM [ACTIVITY_MASTER] ORDER BY ACTIVITY_NAME"></asp:SqlDataSource>
    <asp:CustomValidator ID="CVClient" runat="server" ErrorMessage="Please select the client " ClientValidationFunction="ClientValidate" ControlToValidate="ddlClient" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:CustomValidator ID="CVProduct" runat="server" ErrorMessage="Please select the product" ClientValidationFunction="ClientValidate" ControlToValidate="ddlProduct" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:CustomValidator ID="CVUnit" runat="server" ErrorMessage="Please select the Unit" ClientValidationFunction="ClientValidate" ControlToValidate="ddlUnit" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:CustomValidator ID="CVCcompany" runat="server" ErrorMessage="Please select the Company " ClientValidationFunction="ClientValidate" ControlToValidate="ddlCompany" Display="None" SetFocusOnError="True" ValidationGroup="ValActi"></asp:CustomValidator>
    <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [PRODUCT_ID], [PRODUCT_NAME] FROM [PRODUCT_MASTER] ORDER BY PRODUCT_NAME"></asp:SqlDataSource>
    <asp:HiddenField ID="hdfEMPID" runat="server" />
    <asp:ValidationSummary ID="ValsActivityDetail" runat="server" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValActi" />
    <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" ControlToValidate="txtDOJ"
        Display="None" ErrorMessage="Please enter the DOJ" SetFocusOnError="True" ValidationGroup="ValActi"></asp:RequiredFieldValidator>&nbsp;
    <asp:RegularExpressionValidator ID="REVDoJ" runat="server" ControlToValidate="txtDOJ"
        CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for DOJ"
        SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="ValActi"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RevBasicSalary" runat="server" ControlToValidate="txtBasic"
        Display="None" ErrorMessage="Please enter the basic salary" SetFocusOnError="True"
        ValidationGroup="ValActi"></asp:RequiredFieldValidator>
    <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CLIENT_ID], [CLIENT_NAME] FROM [CLIENT_MASTER] ORDER BY CLIENT_NAME"></asp:SqlDataSource>
    <asp:RequiredFieldValidator ID="RevHRA" runat="server" ControlToValidate="txtHRA"
        Display="None" ErrorMessage="Please enter the HRA" SetFocusOnError="True" ValidationGroup="ValActi"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RevGross" runat="server" ControlToValidate="txtGrossAmt"
        Display="None" ErrorMessage="Please enter the Gross Amount" SetFocusOnError="True"
        ValidationGroup="ValActi"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RevApprovalMailDate" runat="server" ControlToValidate="txtApprovalMailDate"
        Display="None" ErrorMessage="Please enter the Approval Mail date" SetFocusOnError="True"
        ValidationGroup="ValActi"></asp:RequiredFieldValidator>&nbsp;&nbsp;
    <asp:SqlDataSource ID="sdsDesignation" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [DESIGNATION_ID], [DESIGNATION] FROM [DESIGNATION_MASTER] ORDER BY DESIGNATION"></asp:SqlDataSource>
    &nbsp;
  
    <asp:RequiredFieldValidator ID="RevApprovalBy" runat="server" ControlToValidate="txtApprovedBy"
        Display="None" ErrorMessage="Please enter the approved by" SetFocusOnError="True"
        ValidationGroup="ValActi"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegApprovalMailDate" runat="server" ControlToValidate="txtDOB"
        Display="None" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="ValActi"></asp:RegularExpressionValidator>&nbsp;
    <asp:SqlDataSource ID="sdsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [DEPT_ID], [DEPARTMENT] FROM [DEPARTMENT_MASTER] ORDER BY DEPARTMENT"></asp:SqlDataSource>

    <asp:ValidationSummary ID="ValApprove" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="ValApp" />
  
    <asp:RegularExpressionValidator ID="regKitReceived" runat="server" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ControlToValidate="txtKitRedeivedDate" Display="None" ValidationGroup="ValApp"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="regDOL" runat="server" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ControlToValidate="txtLastWorkingDay" Display="None" ValidationGroup="ValApp"></asp:RegularExpressionValidator>
    <asp:SqlDataSource ID="sdsCompanyID" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [COMPANY_ID], [COMPANY_NAME] FROM [COMPANY_MASTER] ORDER BY COMPANY_NAME"></asp:SqlDataSource>
    <asp:HiddenField ID="hdfSubcentre" runat="server" />
     
     <asp:HiddenField ID="hdfCentre" runat="server" />
     <asp:HiddenField ID="hdfCluster" runat="server" />
</asp:Content>
