<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_ExportDataDump.aspx.cs" Inherits="CC_CC_ExportDataDump" Theme="skinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
function funValidateFromToDate()
{

    var strFromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
    var strToDate = document.getElementById("<%=txtToDate.ClientID%>").value;            
   
    //===split and fill into array
    var arFromDate = strFromDate.split('/');
    var arToDate = strToDate.split('/');
    
    //==Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy
    var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];
    var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

    //==Converting the string to date format
    dtFromDate = new Date(strNewFromDate);
    dtToDate = new Date(strNewToDate);

    //declareing the date variable
    date1 = new Date();
    date2 = new Date();
    diff  = new Date();
    //setTime 
    date1.setTime(dtFromDate.getTime());
    date2.setTime(dtToDate.getTime());
    var add_one_day = date2.getTime()+(1000 * 60 * 60 * 24);
    diff.setTime(Math.floor(add_one_day-date1.getTime()));
    var dateDiff = diff.getTime();

    if (parseInt(dateDiff) <= 0) 
    {
         alert("To Date should not be less then From Date");           
         return false;
    }
    else
    {            
         return true;
    }
}  
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Export Data Dump</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" runat="server" width="100%">
<tr>   
<td >
<asp:Label SkinID="lblSkin"  ID="lblFromDate" runat="server" Text="From Date"></asp:Label></td>
<td><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" CausesValidation="True"></asp:TextBox>
<img id="imgFromDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateFromDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Label SkinID="lblSkin"  ID="lblToDate" runat="server" Text="To Date"></asp:Label>
</td>
<td  ><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
<img id="imgToDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
<asp:Label ID="lblFormateToDate" runat="server" SkinID="lblSkin" Text="[dd/MM/yyyy]"></asp:Label>
</td>
<td  >
<asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnsearchskin" 
    OnClick="btnSearch_Click" ValidationGroup="grpDates"/>
</td>
</tr>
<tr>
<td colspan="5"><asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label></td>
</tr>
<tr>
<td colspan="5">&nbsp;
</td>
</tr>
<tr>
    <td colspan="5">
    <table id="tblExportDump" runat="server" cellpadding="0" cellspacing="0" width="100%" visible="false">
    <tr><td align="right"> 
    <asp:Button ID="btnExcelReport" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click" ValidationGroup="grpDates"/>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>
    <div id="dvExport" style="overflow:scroll;  width:980px; height:420px;"> 
        <asp:GridView ID="gvExportDataDump" PageSize="5" runat="server" SkinID="gridviewSkin" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvExportDataDump_PageIndexChanging" OnSorting="gvExportDataDump_Sorting">        
        </asp:GridView>
    </div>
    </td></tr>    
    </table>
    </td>
</tr>
</table>
<tr>
    <td>
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="grpDates"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select From Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please Select To Date" ValidationGroup="grpDates"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="vsValidateDate" runat="server" ShowMessageBox="True"
         ShowSummary="False" ValidationGroup="grpDates"/>
  <asp:CustomValidator ID="cvDate" runat="server" ClientValidationFunction="funValidateFromToDate"
     Display="None" SetFocusOnError="True" ValidationGroup="grpDates" ></asp:CustomValidator>

    </td>    
    </tr>
</fieldset>
</td></tr></table>
</asp:Content>

