<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="HR_Export.aspx.cs" Inherits="HR_HR_HR_Export" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function checkSelectedRecords()
{
    debugger; 
    var count='<%=Session["RecCount"]%>';
    chk='';   
    var cnt;     
    chkRecord=false;
    cnt=2;  
    for(i=0; i<count; i++)
        {
          //for selectde checkbox
        
             chk="ctl00_ContentPlaceHolder1_gvExport_ctl0"+cnt+"_chkSelect";         
             if(cnt > 9)
             {
              chk="ctl00_ContentPlaceHolder1_gvExport_ctl"+cnt+"_chkSelect";
             }
             getCheckBoxId='';
             getCheckBoxId=document.getElementById(chk);             
             if(getCheckBoxId.checked == true)
             {
                  chkRecord = true;             
             }       
              cnt = cnt + 1;      
    
          }
     if( chkRecord==false)
     {
           alert('- Please select at least one records for Export...');
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
 
 /********************************************************
1-Function To Validate Date 
*********************************************************/
function ValidateDate()
{
     debugger;            
     var fromDate='';
     var dueDate=''; 
                                 
     fromDate = document.getElementById("<%=txtFrom.ClientID%>");
     dueDate = document.getElementById("<%=txtTo.ClientID%>");
     
//       if((fromDate.value == "") && (dueDate.value == ""))
//     {
//        alert("- Please enter To date and From Date...");
//        fromDate.focus();
//        return false;
//     }     
     
      if((fromDate.value != "") && (dueDate.value == ""))
     {
        alert("- Please enter To date...");
        dueDate.focus();
        return false;
     }
     else if ((fromDate.value == "") && (dueDate.value != ""))
     {
        alert("- Please enter From date...");
        fromDate.focus();
        return false;
     }
                      
    
    else if((fromDate.value != "") && (dueDate.value != ""))
    {  
            if(isDate(fromDate.value) == false)
            {
              // alert("- Please enter valid date format...");
               fromDate.focus();
               return false;
             }
             else if(isDate(dueDate.value) == false)
              {
                //alert("- Please enter valid date format...");
                dueDate.focus();
                return false;
               }
              else
              {
               if(compareDate(fromDate.value, dueDate.value) == false)
                {
                  alert("- To date should be Greater than the From Date...");
                  return false;
                }
     } 
}
               
}

 
 /********************************************************************************
 7- Date Validation function
*********************************************************************************/
var OnOff=1;

// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=1980;
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
		alert("- The date format should be : dd/mm/yyyy...")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12)
	{
		alert("- Please enter a valid month...")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	{
		alert("- Please enter a valid day...")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	{
		alert("- Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
	{
		alert("- Please enter a valid date...")
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


<fieldset><legend class="FormHeading"><b>HR Export Report</b></legend>   
<%--<atlas:UpdatePanel ID="pnl1" runat="server">
     <ContentTemplate>--%>

<table>  
<tr>
<td colspan="10">
            <asp:Label ID="lblMessage" runat="server" Text="" Width="590px" ForeColor="red" Font-Bold="true"></asp:Label></td>
</tr>
<tr>
<td style="width: 67px" >
</td>
<td style="width: 1%">
</td>
<td >
</td>
<td style="width: 81px" >
</td>
<td style="width: 1%">
</td>
<td>
</td>
<td style="width: 99px">
</td>
<td style="width: 1%">
</td>
<td colspan="2">
</td>
</tr>
<tr>
<td align="right" >Cluster Name</td>
<td style="width: 1%;">:</td>
<td>
<asp:DropDownList ID="ddlCluster"  SkinID="ddlSkin" runat="server" Width="123px" AutoPostBack="True" OnDataBound="ddlCluster_DataBound" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged">
</asp:DropDownList></td>
   
<td align="right"  >
Centre Name</td>
<td style="width: 1%;">
:</td>
<td  >

    
     <asp:DropDownList ID="ddlCentre" runat="server" SkinID="ddlSkin" Width="123px" AutoPostBack="True" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged">
</asp:DropDownList>
  
    
</td>
<td align="right"  >
    Sub Centre Name</td>
<td style="width: 1%;">
:</td>
<td  colspan="2"  >

     <asp:DropDownList ID="ddlSubCentre" SkinID="ddlSkin" runat="server" Width="123px" AutoPostBack="false" OnDataBound="ddlSubCentre_DataBound" >
</asp:DropDownList>
  
</td>
</tr>
<tr>    
<td align="right" style="width: 67px">
From</td>
<td valign="Middle" style="width: 1%">
:</td>
<td  >
<asp:TextBox ID="txtFrom" SkinID="txtSkin" runat="server" Width="97px" MaxLength="10"></asp:TextBox>

<img id="date" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFrom.ClientID%>, 'dd/mm/yyyy', 0, 0);"
    src="../../Images/SmallCalendar.gif" /> [dd/mmyyyy]</td>
<td align="right">
To</td>
<td valign="Middle" >
:</td>
<td  >
    <asp:TextBox ID="txtTo" SkinID="txtSkin" runat="server" Width="97px" MaxLength="10"></asp:TextBox>
<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTo.ClientID%>, 'dd/mm/yyyy', 0, 0);"
    src="../../Images/SmallCalendar.gif" /> [dd/mm/yyyy]</td>
<td>
</td>
<td style="width: 1%">
</td>
<td colspan="2" align="right">
    </td>

</tr>
    <tr>
        <td align="right" colspan="10" valign="top">

    <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" Text="Search" OnClick="btnSearch_Click" OnClientClick="javascript:return ValidateDate();" />
<asp:Button ID="btnExport" runat="server" SkinID="btnExportSkin" Text="Export" OnClick="btnExport_Click" OnClientClick="javascript:return checkSelectedRecords(),ValidateDate();" /></td>
<td align="right" colspan="2">
         </td>
     
</table> 
     
 
<table>
<tr>
    
        <td colspan="10">
            <div id="Div1" runat="server" style="overflow: scroll; width: 100%; height: 40%">
                <asp:GridView ID="gvExport" runat="server" OnRowDataBound="gvExport_RowDataBound"
                    SkinID="gridviewNoSort" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeaderSelect" runat="server" onClick="javascript:SelectAllCheckboxes(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </td>
    <td colspan="2">
    </td>
   
    </tr>
    <tr>
        
        <td colspan="10" align="right" valign="top">
        <asp:Button id="btnExort1" onclick="btnExort1_Click" runat="server" SkinID="btnExportSkin" OnClientClick="javascript:return checkSelectedRecords();" Text="Export"></asp:Button></td>
       <td align="right" colspan="2">
         </td>
        
    </tr>
</table>


<table>
    <tr>
     <td colspan="10" >
            <asp:Label ID="lblreport" runat="server" Font-Bold="True" Text="HR Export Report"
                Visible="False"></asp:Label>
         <asp:HiddenField ID="hidSearch" runat="server" />
         &nbsp;
     </td>
        <td colspan="1" style="width: 58px">
        </td>
        <td colspan="1">
        </td>
        <td colspan="1">
        </td>
                 </tr>
                 <tr>
                 <td colspan="10" >
            </td>
                     <td colspan="1" style="width: 58px">
                     </td>
                     <td colspan="1">
                     </td>
                     <td colspan="1">
                     </td>
                 </tr>

</table>
  <%--</ContentTemplate>
    </atlas:UpdatePanel> --%>

</fieldset>

</asp:Content>

