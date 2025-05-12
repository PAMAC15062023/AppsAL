<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="EISReports.aspx.cs" Inherits="HR_HR_EISReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript"src="popcalendar.js"></script>
    <script language="javascript" type="text/javascript">
    // JScript File
     
        //REQUERE FIELD VALIDATION
        function CkechRequireFields1()
        {
                var SystemDate= "<%=Session["SystemDate"]%>"; 
                var Fdate=document.getElementById("<%=txtfromdate.ClientID %>").value;
                var Tdate=document.getElementById("<%=txtToDate.ClientID %>").value;
                var Fdate1= Fdate.substring(0,10);
                var Tdate1= Tdate.substring(0,10);
                if(document.getElementById("<%=ddlReport.ClientID %>").value=='---Select---')
                {
                    alert('Please Select Report For');
                    document.getElementById("<%=ddlReport.ClientID %>").focus();
                    return false;
                }
                if (Fdate=="")
	            {          
	            }
	            else
	            {
	                if(isDate(document.getElementById("<%=txtfromdate.ClientID %>"))==false)
	                {
	                    document.getElementById("<%=txtfromdate.ClientID %>").focus();
	                    return false;
	                }	
	                else if(compareDate(Fdate1,SystemDate) == false)
                    {                        
                     alert('FromDate can not be Greater than CurrentDate .');
                     document.getElementById("<%=txtfromdate.ClientID %>").value='';
                     document.getElementById("<%=BtnSearch.ClientID %>").focus();
                     return false;                  
                    } 
                    else
                    {
                        if (Tdate=="")
                        {
                            alert('Please Provide ToDate.');
                             document.getElementById("<%=txtToDate.ClientID %>").focus();
                             return false;      
                        } 
                    }
        	    }
	            if (Tdate=="")
	            {     
	            }
	            else
	            {
	                if(isDate(document.getElementById("<%=txtToDate.ClientID %>"))==false)
	                    {
	                        document.getElementById("<%=txtToDate.ClientID %>").focus();
	                        return false;
	                    }  
	                else if(compareDate(Tdate1,SystemDate) == false)
                    {
                         alert('ToDate can not be Greater than CurrentDate .');
                         document.getElementById("<%=txtToDate.ClientID %>").value='';
                         document.getElementById("<%=BtnSearch.ClientID %>").focus();
                         return false;                  
                    }
                    else
                    {
                        if (Fdate=="")
                        {
                            alert('Please Provide FromDate.');
                             document.getElementById("<%=txtfromdate.ClientID %>").focus();
                             return false;      
                        } 
                    } 
                }  
	            var Fdate1= Fdate.substring(0,10);
                var Tdate1= Tdate.substring(0,10);
	            if(compareDate(Fdate1, Tdate1) == false)
                      {
                        
                           alert('- FromDate should be less than ToDate.');
                            document.getElementById("<%=txtfromdate.ClientID %>").value='';
                            document.getElementById("<%=txtToDate.ClientID %>").value='';
                            document.getElementById("<%=BtnSearch.ClientID %>").focus();
                            return false;
                       }	   
                         
        }
          
          /********************************************************************************
 7- Date Validation function
*********************************************************************************/
var OnOff=1;

// Declaring valid date character, minimum year and maximum year
var dtCh= "/";
var minYear=1901;
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
function isDate(Strdt)
{
    debugger;
    var dtStr=Strdt.value
	var daysInMonth = DaysArray(12);
	    var pos1=dtStr.indexOf(dtCh);
	    var pos2=dtStr.indexOf(dtCh,pos1+1);
	    var strDay =dtStr.substring(0,pos1);
	    var strMonth =dtStr.substring(pos1+1,pos2);
	    var strYear =dtStr.substring(pos2+1);
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
	    if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
	    {
		    alert("Please enter a valid date");
		    return false;
	    }
	    if (pos1==-1 || pos2==-1)
	    {
		    alert("The date format should be : dd/mm/yyyy");
		    return false;
	    }
	    if (strMonth.length<1 || month<1 || month>12)
	    {
		    alert("Please enter a valid month");
		    return false;
	    }
	    if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	    {
		    alert("Please enter a valid day");
		    return false;
	    }
	    if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	    {
		    alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear);
		    return false;
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
<table  width="99%" border="0" align="center" cellspacing="0" cellpadding="0" >
          <tr> 
            <td align="left" ><asp:Label ID="lblMsg" runat="server" CssClass="txtError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
          </tr>
          <tr> 
            <td align="center">
                <fieldset><legend class="FormHeading"><b>Reports</b></legend>
                              <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0">
                                <tr> 
                                  <td><table width="100%" border="0" align="center" cellpadding="0" 
                                    cellspacing="0"  class="shadow">
                                      <tr> 
                                        <td class="shadow-center" align="center"> <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" >
                                           <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td class="label" align="left" style="width: 70px">
                                                                Report For <span style="color: #ff0000">* </span>
                                                             </td>
                                                             <td class="label" style="width:2%">:</td>
                                                             <td align="left" style="width: 250px"><font color="#990000"><strong>
                                                                <asp:DropDownList ID="ddlReport" SkinID="ddlSkin" runat="server" Width="120px">
                                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                                    <asp:ListItem Value="Join">New Joinee Details</asp:ListItem>
                                                                    <asp:ListItem Value="A/C#">Pending A/C#</asp:ListItem>
                                                                    <asp:ListItem Value="ESIC#">Pending ESIC#</asp:ListItem>
                                                                    <asp:ListItem Value="Pan#">Pending PAN#</asp:ListItem>
                                                                    <asp:ListItem Value="Pf#">Pending PF#</asp:ListItem>
                                                                </asp:DropDownList>
                                                             </strong></font></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="label" align="left" style="width: 70px">
                                                                  Cluster
                                                              </td>
                                                                <td class="label" style="width:2%">
                                                                :
                                                                </td>
                                                              <td align="left" style="width: 250px"><font color="#990000"><strong>
                                                                  <asp:DropDownList ID="ddlcluster" Enabled="false" SkinID="ddlSkin" runat="server" Width="120" DataSourceID="ClusterData" DataTextField="Cluster" DataValueField="ClusterId" OnDataBound="ddlcluster_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlcluster_SelectedIndexChanged"></asp:DropDownList>
                                                                </strong></font></td>
                                                                <td class="label" align="left" style="width: 50px">
                                                                  Centre
                                                              </td>
                                                                <td class="label" style="width:2%">
                                                                :
                                                                </td>
                                                              <td align="left" style="width: 250px"><font color="#990000"><strong>
                                                                  <asp:DropDownList ID="ddlcentre" Enabled="false" runat="server" SkinID="ddlSkin" Width="120" OnDataBound="ddlcentre_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlcentre_SelectedIndexChanged"></asp:DropDownList>
                                                               </strong></font></td>
                                                                <td class="label" align="left" style="width: 70px">
                                                                    Sub Centre
                                                                </td>
                                                                <td class="label" style="width:2%">
                                                                :
                                                                </td>
                                                              <td align="left" style="width: 125px"><font color="#990000"><strong>
                                                                  <asp:DropDownList ID="ddlsubcentre" Enabled="false" runat="server" SkinID="ddlSkin" Width="120" OnDataBound="ddlsubcentre_DataBound"></asp:DropDownList>
                                                             </strong></font>
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="label" align="left" style="width: 70px">
                                                                    Date From</td>
                                                                <td class="label" style=" width:2%">
                                                                    :</td>
                                                                <td align="left" style="width: 250px">
                                                                    <asp:TextBox id="txtfromdate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                                                                    <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" alt="Calendar" src="../../Images/SmallCalendar.gif" />
                                                                    <asp:Label id="lblfromdateformate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                                                                </td>
                                                                <td class="label" align="left" style="width: 50px">
                                                                    To</td>
                                                                <td class="label" style=" width:2%">
                                                                    :</td>
                                                                <td align="left" style="width: 250px">
                                                                    <asp:TextBox id="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                                                                    <img id="Img4" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" alt="Calendar" src="../../Images/SmallCalendar.gif" />
                                                                    <asp:Label id="Label1" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                                                                </td>
                                                                <td align="left" style="width: 70px"></td>
                                                                <td class="label" style=" width:2%">
                                                                    </td>
                                                                <td align="left" style="width: 125px">
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnSearch" SkinID="btn" runat="server" Text="Search" OnClick="BtnSearch_Click"  OnClientClick="javascript:return CkechRequireFields1();" /><asp:Button ID="BtnExport" SkinID="btn" runat="server" Text="Export" OnClick="BtnExport_Click" />
                                                                </td>
                                                            </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GvEmpoyeePan" SkinID="gridviewSkin" runat="Server" AutoGenerateColumns="false" PageSize="20" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GvEmpoyeePan_PageIndexChanging" OnSorting="GvEmpoyeePan_Sorting">
                                                        <Columns>
                                                            <asp:BoundField DataField="PAMACianCode" HeaderText="PAMACian Code" SortExpression="PAMACianCode" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="PAMACian" HeaderText="PAMACian" SortExpression="PAMACian" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="DOJ" HeaderText="Date of Joining" SortExpression="DOJ" ItemStyle-HorizontalAlign="Left" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="Activity_Name" HeaderText="Unit" SortExpression="Activity_Name" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="Pan#" HeaderText="PAN#" SortExpression="Pan#" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField DataField="AC#" HeaderText="A/C#" SortExpression="AC#" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField DataField="Pf#" HeaderText="PF#" SortExpression="PF#" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField DataField="Esic#" HeaderText="ESIC#" SortExpression="Esic#" ItemStyle-HorizontalAlign="Right" />
                                                            <asp:BoundField DataField="Cluster_Name" HeaderText="Cluster Name" SortExpression="Cluster_Name" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="Centre_Name" HeaderText="Centre Name" SortExpression="Centre_Name" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name" SortExpression="SubCentreName" ItemStyle-HorizontalAlign="Left" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table></td>
                                      </tr>
                                    </table></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:SqlDataSource ID="ClusterData" runat="server" SelectCommandType="StoredProcedure" SelectCommand="SpGetClusters" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="PanDataSource" runat="Server" SelectCommandType="StoredProcedure" SelectCommand="SpEmployeeDetails" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
                                            <SelectParameters>
                                                <asp:Parameter Name="For" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                              </table>
                              </fieldset>
            </td>
          </tr>
        </table>
</asp:Content>

