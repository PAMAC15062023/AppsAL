<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="GeneralQuery.aspx.cs" Inherits="QueryBuilder_GeneralQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript"  type="text/javascript">
function funValidateFromToDate(sender, args)
{
   debugger;
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
         args.IsValid = false;
         return;
         //alert("To Date should not be less then From Date");           
         //return false;
    }
    else
    {            
         args.IsValid = true;
         return;
    }
}  
</script>
<fieldset>
<legend class="FormHeading">General Saved Queries</legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top" colspan="9" style="height: 22px;"></td>
</tr>
 <tr>               
                <td valign="top" colspan="9">
                    <asp:Label ID="LblMsg" runat="server" SkinID="lblErrorMsg" Visible="true" Width="501px" ForeColor="Red"></asp:Label></td>
                
            </tr>
             <tr>
           <td style="width: 28px">DataBase</td>
           <td class="TDWidth" style="width: 1%">
                :</td>
            
            <td colspan="7">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList>
            </td>
            
        </tr>
    <tr>
        <td style="height: 10px; width: 28px;">
        </td>
        <td style="height: 10px;" colspan="8">
        </td>
    </tr>
<tr>
<td >Saved Query</td>
<td>
                :</td>
<td colspan="7">
<asp:DropDownList ID="ddlSavedQuery" SkinID="ddlSkin" runat="server" Width="181px" AutoPostBack="True" OnSelectedIndexChanged="ddlSavedQuery_SelectedIndexChanged">
</asp:DropDownList>
</td>
</tr>
<tr>
<td style="height: 10px;" colspan="9"></td>
</tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
 <tr id="TR_Hide" runat="server">
 <td>

 <table border="0" cellspacing="0" cellpadding="0" width="100%">
 <tr>
               <td width="24%">
            
                    From Date<span style="color: #ff0033;font-family:Arial;font-size:small">*</span></td>
                <td>
                :</td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
               
                <td>
                    To Date<span style="color: #ff0033;font-family:Arial;font-size:small">*</span></td>
                <td>
                :</td>
                <td colspan="3" >
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>&nbsp;
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" />
                    </td>
               
                    </tr>
   <tr>
        <td style="height: 10px; width: 28px;">
        </td>
        <td style="height: 10px;" colspan="8">
        </td>
    </tr>
     <tr>
         <td >
         Condition Based On
         </td>
         <td >
         :
         </td>
         <td >
                <asp:DropDownList ID="ddlDateType" runat="server" SkinID="ddlSkin">
                        <asp:ListItem>Received Date</asp:ListItem>
                        <asp:ListItem>Send Date</asp:ListItem>
                    </asp:DropDownList>
                    </td>
         <td >
         </td>
         <td >
         </td>
         <td colspan="3" >
         </td>
         
     </tr>
                    </table>
              
                </td>
            </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top" colspan="9" style="height: 20px;">
        </td>
    </tr>
            <tr><td colspan="9" style="height: 24px">
                                <asp:Button ID="btnExport" runat="server" SkinID="btn" Text="Export To Excel"
                                Width="121px" OnClick="btnExport_Click" /></td></tr>
    <tr>
        <td colspan="9" style="height: 10px;">
        </td>
    </tr>
            <tr>
                <td align="left" colspan="8">
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                </td>
            </tr>
   
             <tr>                
                <td colspan="9" valign="top">
                    <table id="tbl" visible="true" width="100%">
                        
                        
                         <tr>
                            <td style="width: 100px">
                                 <asp:GridView ID="gvSavedQuery" runat="server" SkinID="gridviewNoSort" Width="100%">
                                  </asp:GridView>
                                  <asp:HiddenField Id="hidQueryType" runat="server"/>
                         <asp:HiddenField Id="hidQueryID" runat="server"/>
                         <asp:HiddenField Id="hidQueryTextFile" runat="server"/>
                         <asp:HiddenField Id="hidIsCreteria" runat="server"/> 
                         <asp:HiddenField  ID="hidAlias" runat="server"/> 
                         <asp:HiddenField  ID="hidWholeQuery" runat="server"/>
                                <asp:Label ID="lblreport" runat="server" Font-Bold="True" Text="General Saved Query Report"
                                    Visible="False" Width="264px"></asp:Label></td>
                               
                         </tr>
                         
                    </table>
                </td>
            </tr>
            <tr>
            <td colspan="9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                    Display="None" ErrorMessage="Please select From Date" Font-Size="9pt" SetFocusOnError="True"
                    ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator_ToDate"
                        runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please Select To Date"
                        Font-Size="9pt" SetFocusOnError="True" ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                            Display="None" ErrorMessage="Please enter valid From Date." Font-Names="Arial"
                            Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="Val"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                                Display="None" ErrorMessage="Please enter valid To Date." Font-Names="Arial"
                                Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="Val">
                            </asp:RegularExpressionValidator>
                                <%--<asp:CustomValidator ID="CustomValidator_From_ToDate"
                                    runat="server" ClientValidationFunction="funValidateFromToDate" Display="None"
                                    ErrorMessage="To Date should not be less then From Date" Font-Size="9pt" SetFocusOnError="True"
                                    ValidationGroup="Val"></asp:CustomValidator>--%>
                                    <asp:ValidationSummary ID="ValidationSummary1"
                                        runat="server" Font-Size="9pt" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Val" />
            </td>
        </tr>   
</table>
   
</fieldset>

</asp:Content>

