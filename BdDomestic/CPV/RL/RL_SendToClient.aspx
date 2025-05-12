<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="RL_SendToClient.aspx.cs" Inherits="CPV_RL_RL_SendToClient" Title="" %>
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
      
                                 
     fromDate = document.getElementById("ctl00_C1_txtfromdate");
     dueDate = document.getElementById("ctl00_C1_Txttodate1");
    
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
//        monthTo = k[0] - 1; // javascript month range : 0- 11
//        yearTo = k[2];
//        dayTo = k[1];
//        
        dayTo = k[0]; // javascript month range : 0- 11
        yearTo = k[2];
        monthTo  = k[1];
        


        var tempStartDate = new Date(yearTo,monthTo,dayTo);
        k = date2.split('/');
       
//        monthFrom = k[0] - 1; // javascript month range : 0- 11
//        yearFrom = k[2];
//        dayFrom = k[1];

        dayFrom= k[0]; // javascript month range : 0- 11
        yearFrom = k[2];
        monthFrom = k[1];
        
    
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
 <fieldset><legend class="FormHeading" >Tat Calculation</legend>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
     
          
            <tr>
            
          
        
          </tr>
             
             
              <tr>
                <td class="label">From Date:<span class="txtRed">* </span></td>
                     
                   <%-- <asp:Label ID="lblfromdate" SkinID="lblSkin" runat="server"  Text=" From Date:"></asp:Label></td>--%>
                  
                   <td><asp:TextBox ID="txtfromdate" SkinID="txtSkin" runat="server" MaxLength="10" ValidationGroup="grpsearch" ></asp:TextBox>
                      </td>
               
                   <td><table id="fromdatetable" runat="server">
                   <tr>
                   <td> <img alt="Calendar" id="Img1" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" src="../../Images/SmallCalendar.gif"/>
                    
                     <asp:Label ID="lblfromdateformate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                    </td>
                    </tr></table>
                   </td>
                <%--<td><asp:Label ID="lbltodate" SkinID="lblSkin" runat="server" Text="To Date"></asp:Label></td>--%>
                <td class="label">To Date:<span class="txtRed">* </span></td>
                
                <td><asp:TextBox ID="Txttodate1" SkinID="txtSkin"   runat="server" MaxLength="10" ValidationGroup="grpsearch" ></asp:TextBox> </td>
                
               <td>
                <table id="Table1" runat="server">
                <tr>
                <td>
                    <img alt="Calendar" id="Img4" onclick="popUpCalendar(this, document.all.<%=Txttodate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" src="../../Images/SmallCalendar.gif"/>
                    <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                    </td>
               </tr>
               </table>
               </td>
            
           
                <td><asp:Button ID="BtnSearch" runat="server"  SkinID="btnSearchSkin"  OnClick="BtnSearch_Click" Text="Search" OnClientClick="javascript:return ValidateDate();" /></td>
          
           </tr>
          
         
           <tr>
                <td colspan="9" > <asp:Label ID="lblmessage" runat="server" Width="437px" ForeColor="Red"></asp:Label></td>
           
           </tr>
              
              <tr>
                    <td colspan="9" > <asp:Label ID="lbldatavalidation" runat="server" ForeColor="Red" Width="441px"></asp:Label></td>
              </tr>

          
          <tr>
                <td colspan="9"  > 
                 <asp:GridView ID="gvSearch" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="False"  >
                        <Columns>
                            <asp:BoundField DataField="Ref_no"  HeaderText="Ref_no" />
                            <asp:BoundField DataField="Applicant_name"    HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Rec_date"  HeaderText="Rec Date" />
                        
                        
                        
                        </Columns>
                    </asp:GridView>
                    
                    
                    
                    <%-- <asp:GridView ID="gvSearch" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="False" AllowPaging="True"  OnPageIndexChanging="gvSearch_PageIndexChanging" PageSize="3" AllowSorting="True" OnSorting="gvSearch_Sorting"  >
                        <Columns>
                            <asp:BoundField DataField="Ref_no"  HtmlEncode="False"  SortExpression="Ref_no"  HeaderText="Ref_no" />
                            <asp:BoundField DataField="Applicant_name"   HtmlEncode="False"  SortExpression="Applicant_name"   HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Rec_date"  HtmlEncode="False"  SortExpression="Rec_date"  HeaderText="Rec Date" />
                        
                        
                        
                        </Columns>
                    </asp:GridView>--%>
                   
     <%--             <asp:GridView ID="gvSendTat" runat="server" SkinID="gridviewSkin"  OnRowDataBound="gvSendTat_RowDataBound" OnSorting="gvSendTat_Sorting" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CaseId" HeaderText="CaseId" />
                            <asp:BoundField DataField="REF_NO" HeaderText="REF_NO" />
                            <asp:BoundField DataField="APPLICANT_NAME" HeaderText="APPLICANT_NAME" />
                            <asp:BoundField DataField="REC_DATE" HeaderText="REC_DATE" />
                            <asp:BoundField DataField="TAT_HRS" HeaderText="TAT_HRS" />
                            <asp:TemplateField HeaderText="WITHIN_TAT ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkTAT" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                    
                    
                   <asp:GridView ID="gvSendTat" runat="server" SkinID="gridviewSkin"   AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="CaseId"  HeaderText="CaseId" />
                            <asp:BoundField DataField="REF_NO"   HeaderText="REF_NO" />
                            <asp:BoundField DataField="APPLICANT_NAME"   HeaderText="APPLICANT_NAME" />
                            <asp:BoundField DataField="REC_DATE" HeaderText="REC_DATE" />
                            <asp:BoundField DataField="TAT_HRS"   HeaderText="TAT_HRS" />
                            <asp:TemplateField HeaderText="WITHIN_TAT ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkTAT" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    
                    
                    
                    
                    
                </td>
           </tr>
           
           
           <tr>
                 <td class="label" > <asp:Label ID="lblsenddate" SkinID="lblSkin" runat="server" Text="Send Date" Visible="False"></asp:Label>
                 <label id="dd" visible="false" runat="server"><span class="txtRed" >* </span></label>
                </td>
                
                <td ><asp:TextBox ID="txtSendDt" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"  Visible="False" ValidationGroup="grpSend"></asp:TextBox>
                   </td>
                    
                <td>
                <table id="tblImg" runat="server">
                <tr>
                <td><img id="Img2"  alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSendDt.ClientID%>, 'dd/mm/yyyy', 0, 0);"src="../../Images/SmallCalendar.gif" />
                    <asp:Label ID="lblsenddatefotmate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]" Visible="False"></asp:Label>
                </td>
                </tr>
                </table>
                </td> 
               
               
                 <td class="label" ><asp:Label ID="lblsendtime" SkinID="lblSkin" runat="server" Text="Send Time " Visible="False"></asp:Label>
                <%--<span class="txtRed"  visible ="false">* </span>--%>
                <label id="ddd" visible="false" runat="server"><span class="txtRed" >* </span></label>
                </td>
               
               
                <td ><asp:TextBox ID="txtSendTm" SkinID="txtSkin" runat="server" CssClass="textbox"  Visible="False" ValidationGroup="grpSend" MaxLength="5"></asp:TextBox>
                      <asp:Label ID="lblhourandminformate" runat="server" SkinID="lblSkin" Text="[hh:mm]" Visible="False"></asp:Label>
                </td>
                <td style="width: 110px"><asp:DropDownList ID="ddlSendTimeType" SkinID="ddlSkin" runat="server" CssClass="combo" Visible="False">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>
                </td>
               
               
       </tr>
       <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        <td><asp:Button ID="btnCalcTat"  SkinID="btntatcalskin" runat="server" CssClass="button" Width="100%" OnClick="btnCalcTat_Click" ValidationGroup="grpSend" Visible="False" /></td>
        <td><asp:Button ID="btnSentToClient"  SkinID="btnSendSkin"  runat="server" OnClick="btnSentToClient_Click"  Visible="False" ValidationGroup="grpSend" /></td>
        </tr>
       
       <tr>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSendDt" Display="None" ErrorMessage="Please enter Send Date" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator></td>
               
                <td ><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSendTm" Display="None" ErrorMessage="Please enter Send Time" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator></td>
               
          
           
                <td><asp:RegularExpressionValidator ID="revDate1" runat="server" ControlToValidate="txtSendDt" Display="None" ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"  ValidationGroup="grpSend"></asp:RegularExpressionValidator></td>
                
                <td><asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtSendTm" Display="None" ErrorMessage="Please enter valid Time Format for Send Time" SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpSend"></asp:RegularExpressionValidator></td>
               
                <td ><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpSend" /> 
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List"
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpsearch" />
                </td>
                
          </tr>
        </table>
        <%--<asp:RequiredFieldValidator ID="rvvforfromdate" runat="server" ControlToValidate="txtfromdate"
            Display="None" ErrorMessage="Please Enter from date" SetFocusOnError="True" ValidationGroup="grpsearch"></asp:RequiredFieldValidator>
       
       
        <asp:RequiredFieldValidator ID="rfvfortodate" runat="server" ControlToValidate="Txttodate1"
            Display="None" ErrorMessage="Please Enter todate" SetFocusOnError="True" ValidationGroup="grpsearch"></asp:RequiredFieldValidator></fieldset>
   
   --%>
   
   
   <%--<asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtfromdate"
    Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpsearch"></asp:RegularExpressionValidator>
    
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="Txttodate1"
    Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpsearch"></asp:RegularExpressionValidator>--%>

</asp:Content>

