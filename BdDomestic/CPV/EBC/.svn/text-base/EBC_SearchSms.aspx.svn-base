<%@ Page Language="C#" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="EBC_SearchSms.aspx.cs" Inherits="CPV_EBC_EBC_SearchSms"  %>
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
         alert("Please provide from date and To date...");
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
                       alert("Please provide valid date formate..");
                       fromDate.focus();
                       return false;
                     }
                 else if(isDate(dueDate.value) == false)
                     {
                       alert("Please provide valid date formate..");
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
</script>
<fieldset><legend class="FormHeading">Search Sms </legend>


        <table>
           
            <tr>
                <td colspan="7" > 
                    <span style="color: #ff0033">* </span>Indicate mandatory fields. </td>
            </tr>
            <tr>
                <td>
                    From Date<span style="color: #ff0000">*</span>
              
                    <asp:TextBox ID="txtFromDate" Width="80px"  SkinID="txtSkin" runat="server" MaxLength="11"></asp:TextBox>
                  <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
                <td>
                    ToDate <span style="color: #ff0000">*</span>
               
                    <asp:TextBox ID="txtToDate" Width="80px" SkinID="txtSkin" runat="server" MaxLength="11"></asp:TextBox>
                
                    <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
                       
                <td style="width: 66px">
                    <asp:Button ID="brnSearch"  SkinID="btnExpToExlSkin" runat="server" Text="Search" OnClick="brnSearch_Click"   OnClientClick="javascript:return ValidateDate();"  ToolTip="Click Here For Searching" ValidationGroup="dateValidation" /></td>
            </tr>
            <tr>
            <td colspan="3">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="501px"></asp:Label>
            </td>
            </tr>
                     
        </table>
    
   


</fieldset>
</asp:Content>



