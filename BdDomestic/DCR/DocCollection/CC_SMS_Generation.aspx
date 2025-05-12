<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" Theme="skinFile" CodeFile="CC_SMS_Generation.aspx.cs" Inherits="CPV_CC_CC_SMS_Generation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">


/********************************************************
1-Function To Validate Date 
*********************************************************/
function ValidateDate()
{
   debugger;            
     var fromDate='';
     var dueDate=''; 
      var getVerificationId ='';  
                                 
     fromDate = document.getElementById("ctl00_C1_txtFromDate");
     dueDate = document.getElementById("ctl00_C1_txtToDate");                       
     getVerificationId = document.getElementById("ctl00_C1_ddlVerificationId");
    
    
         if(fromDate.value=="" && dueDate.value=="")
         {
         alert("- Please enter From date and To date...");
          return false;
         }
         else
         {  
           if(fromDate.value =="")
           {
             alert('- Please select the From date.');
             fromDate.focus();
              return false;
           }
           else if(dueDate.value =="")
           {
             alert('- Please select the To date.');
             dueDate.focus();
             return false;
           }
           else 
           {
                if(isDate(fromDate.value) == false)
                     {
                       alert("- Please enter valid date format.");
                       fromDate.focus();
                       return false;
                     }
                 else if(isDate(dueDate.value) == false)
                     {
                       alert("- Please enter valid date format.");
                       dueDate.focus();
                       return false;
                     }
                 else
                 {
                     if(compareDate(fromDate.value, dueDate.value) == false)
                     {
                       alert("- Please check the From and To date.");
                       return false;
                     }
                 }
           }//end of inner else
     }//end of outer else 
      if(getVerificationId.value == 0)
          {
           alert("Please Select Verification Type...");          
           return false; 
           }      
               
}

/********************************************************************************
 7- Date Validation function
*********************************************************************************/
var OnOff=1;

// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=2005;
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
function isDate(dtStr)
{
    debugger;
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strDay =dtStr.substring(0,pos1)
	var strMonth =dtStr.substring(pos1+1,pos2)
	var strYear =dtStr.substring(pos2+1)
	strYr = strYear
	
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	
	for (var i = 1; i <= 3; i++) 
	{
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	
	day=parseInt(strDay)
	month=parseInt(strMonth)	
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1)
	{
		alert("The date format should be : dd/mm/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12)
	{
		alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	{
		alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	{
		alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
	{
		alert("Please enter a valid date")
		return false
	}
    return true
} 

/*************************************************
2- Date compare function
*************************************************/     
                    
function compareDate(date1, date2)
    {
        k = date1.split('/');
        monthTo = k[0] - 1; // javascript month range : 0- 11
        yearTo = k[2];
        dayTo = k[1];
        
        var tempStartDate = new Date(yearTo,monthTo,dayTo);
        k = date2.split('/');
        monthFrom = k[0] - 1; // javascript month range : 0- 11
        yearFrom = k[2];
        dayFrom = k[1];
        var tempEndDate = new Date(yearFrom,monthFrom,dayFrom);

        if(tempStartDate > tempEndDate)
        {
            //alert(msg);
            if(tempStartDate != tempEndDate)
            {
             return false;
            }
        }
        else
        {
           return true;
        }
    }
        
        

     
     
 /***************************************************************
4-Prevent character to enter into textbox    
***************************************************************/
function CheckChar(id)
{        
  getControlsId = document.getElementById(id);
  if(getControlsId.value.length > 255)
  {
    getControlsId.value = getControlsId.value.substring( 0, 255 );            
    return false;
  }          
}  
 
   
   
   // Removes leading whitespaces
function LTrim( value ) 
  {            
          var re = /\s*((\S+\s*)*)/;
          return value.replace(re, "$1");            
   }
//Removes ending whitespaces
   function RTrim( value ) 
   {            
           var re = /((\s*\S+)*)\s*/;
           return value.replace(re, "$1");            
   }
//Removes leading and ending whitespaces
   function Trim( value ) 
   {           
         return LTrim(RTrim(value));            
   }
   
    
/*******************************************************
6-check Check Null Valueof textbox
*********************************************************/
function checkSelectedRecords()
{
    debugger; 
    var count='<%=Session["RecCount"]%>';
    chk='';
    phone='';
    comments='';
    var cnt;
     
    chkRecord=false;
    cnt=2;  
    for(i=0; i<count; i++)
        {
          //for selectde checkbox
         chk="ctl00_C1_Gview_ctl0"+cnt+"_ChkSelect";
         
         if(cnt > 9)
         {
          chk="ctl00_C1_Gview_ctl"+cnt+"_ChkSelect";
         }
         //for phone textbox
         phone="ctl00_C1_Gview_ctl0"+cnt+"_txtMobile";
         if(cnt > 9)
         {
          phone="ctl00_C1_Gview_ctl"+cnt+"_txtMobile";
         }
         //for comments textbox
         comments="ctl00_C1_Gview_ctl0"+cnt+"_txtSms";
         if(cnt > 9)
         {
           comments="ctl00_C1_Gview_ctl"+cnt+"_txtSms";
         }  
         
        getCheckBoxId='';
        getPhoneId='';
        getCommentsId='';
         getCheckBoxId=document.getElementById(chk);    
         getPhoneId=document.getElementById(phone);    
         getCommentsId=document.getElementById(comments); 
                  
      
      
      
      
    
     
             
         if(getCheckBoxId.checked == true)
         {
              chkRecord = true;
              if(Trim(getPhoneId.value) == "")//passing value in trim() function
                  {
                   alert("Please Enter Mobile No.");
                   getPhoneId.focus();
                   return false;
                  }
              else
               {              
                if(isNaN(getPhoneId.value))
                     {
                     alert('Please provide mobile no as number only...');
                     getPhoneId.value='';
                     getPhoneId.focus();
                     return false;
                     }    
                      if(getPhoneId.value.length < 10)
                     {
                       alert('Please provide 10 digits mobile no ...');                   
                       getPhoneId.focus();
                       return false;  
                     }    
              
              }
              if(Trim(getCommentsId.value) == "")//passing value in trim() function
              {
               alert("Please Enter Sms Content.");
               getCommentsId.focus();
               return false;
              }
              
       
         }
       
            cnt = cnt + 1;      
    
     }
     if( chkRecord==false)
     {
           alert('Please select at least one records for message sending...');
           return false;    
               
     
     }
     return true;
}


function SelectAllCheckboxes(spanChk)
{
   // Added as ASPX uses SPAN for checkbox
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
       xState=theBox.checked;
       elm=theBox.form.elements;
       
   for(i=0;i<elm.length;i++)
     if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
     {       
       if(elm[i].checked!=xState)
         elm[i].click();       
     }
 }



</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">SMS Sending</legend>


        <table id="tblSMSSend" width="100%">
            <tr>
                <td >
                    From Date<span style="color: #ff0000">*</span>
                </td>
                <td>
              
                    <asp:TextBox ID="txtFromDate" Width="80px"  SkinID="txtSkin" runat="server" MaxLength="11"></asp:TextBox>
                  <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                        src="../../Images/SmallCalendar.gif" />
                    &nbsp;[dd/mm/yyyy]
                </td>
                <td>
                    ToDate <span style="color: #ff0000">*</span>
                </td>
                <td >
               
                    <asp:TextBox ID="txtToDate" Width="80px" SkinID="txtSkin" runat="server" MaxLength="11"></asp:TextBox>
                
                    <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                        src="../../Images/SmallCalendar.gif" />
                    &nbsp;[dd/mm/yyyy]</td>
            </tr>
            <tr>
                <td  >
                VerifivationType<span style="color: #ff3366">*</span></td>
                <td >
                    <asp:DropDownList ID="ddlVerificationId" SkinID="ddlSkin" runat="server" OnDataBound="ddlVerificationId_DataBound" >
                </asp:DropDownList></td>
                <td >
                </td>
                <td >
                    <asp:Button ID="brnSearch"  SkinID="btnSearchSkin" runat="server" Text="Search" OnClick="brnSearch_Click"   OnClientClick="javascript:return ValidateDate();"  ToolTip="Click Here For Searching" ValidationGroup="dateValidation" /></td>
            </tr>
           <tr>
                <td colspan="4"> 
                    <span style="color: #ff0033">* </span>Indicate mandatory fields. </td>
            </tr>
            <tr>
                <td colspan="4" >
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Width="940px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="Gview" runat="server" SkinID="gridviewSkin" Width="606px" AutoGenerateColumns="False" OnRowDataBound="Gview_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="Case_id" HeaderText="CaseId" />
                            <asp:BoundField DataField="REF_NO" HeaderText="Ref.No" />
                            <asp:BoundField DataField="APPLICANT_NAME" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="ADDRESS" HeaderText="Address" />
                            <asp:BoundField DataField="REC_DATETIME" HeaderText="Recd.DateTime" />
                            <asp:BoundField DataField="FullName" HeaderText="Verifier" />                            
                            <asp:TemplateField HeaderText="Mobile">
                              <ItemTemplate>                                
                                <asp:TextBox ID="txtMobile" SkinID="txtSkin"  Width="80px" ReadOnly="true" Text='<%# Bind("MOBILE") %>'  runat="server" MaxLength="13"></asp:TextBox>&nbsp;
                              </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText="Sms_Content">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtSms" SkinID="txtSkin"   runat="server"  Text='<%# Bind("SmsContent") %>' TextMode="MultiLine" Width="250px" Height="40px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Check" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                             <HeaderTemplate>                                      
                             <asp:CheckBox ID="chkAll" runat="server" onClick="javascript:SelectAllCheckboxes(this);"  />                    
                              </HeaderTemplate>
                              <ItemTemplate>
                              <asp:CheckBox  ID="ChkSelect" runat="server"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                       
                        </Columns>
                    </asp:GridView>
                   
                    
                </td>
            </tr>
            <tr>
                <td colspan="4"  >
                    <asp:Button ID="btnSend" runat="server" SkinID="btnsendfeskin" OnClick="btnSend_Click" OnClientClick="javascript:return checkSelectedRecords();"  Text="Send" Visible="False"
                        Width="90px"  />
                </td>
            </tr>
        </table>
    
   


</fieldset>
 </td></tr>
</table>
</asp:Content>
