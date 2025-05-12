<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="TatAnalysisCentreWise.aspx.cs" Inherits="QueryBuilder_TatAnalysisCentreWise"%>
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
        <legend class="FormHeading"><strong>TAT Analysis Centre Wise</strong></legend>
    <table style="width: 100%">
    
        <tr>
           
            <td colspan="8">
                <asp:Label ID="LblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
            <td >                </td>
        </tr>
        <tr>
           <td style="width: 75px" align="left" valign="top"><asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Database"></asp:Label></td>
            <td class="TDWidth" align="left" valign="top">
                :</td>
            <td colspan="7" align="left" valign="top">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList>
            </td>
            <td > </td>
        </tr>
        <tr>           
            <td style="width: 75px" align="left" valign="top">
                <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="From Date "></asp:Label><span style="color: #ff0033;font-family:Arial;font-size:small">*</span> &nbsp;
                &nbsp; &nbsp;&nbsp;
            </td>
            <td class="TDWidth" align="left" valign="top">
                :</td>
            <td style="width: 150px" align="left" valign="top" >
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="imgfrom" alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
            <td align="right" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="To Date" ></asp:Label>
                <span style="color: #ff0033; font-family: Arial">*</span></td>
            <td align="left" valign="top" >
                &nbsp;:<span style="color: #ff0033;font-family:Arial;font-size:small"></span></td>                
            <td class="TDWidth" align="left" valign="top">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img1" alt="Calendar" src="../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
            <td align="left" valign="top">            &nbsp;
            </td>
            <td>
                </td>
            
        </tr>
        <tr>
            <td align="left" style="width: 75px" valign="top">
            </td>
            <td align="left" class="TDWidth" valign="top">
            </td>
            <td align="left" valign="top">
                &nbsp;<asp:Button ID="btnReport" runat="server" Text="Get Report" OnClick="btnReport_Click" SkinID="btn" ValidationGroup="Val" /></td>
            <td align="left" style="width: 35px" valign="top">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btn"
                    Text="Cancel" /></td>
            <td align="left" valign="top">
            </td>
            <td align="left" class="TDWidth" valign="top">
            </td>
            <td align="left" valign="top">
            </td>
            <td>
            </td>
        </tr>
       <tr>
                <td align="left" colspan="8" valign="top">&nbsp;<span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label6" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                </td>
            </tr>
        <tr>
            <td colspan="8">
                <table id="tbl" runat="server" visible="false" width="100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btn"
                                Text="Export To Excel" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvCentreWise" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                                    <asp:BoundField DataField="NO" HeaderText="Total No" />
                                    <asp:BoundField DataField="WITHIN_TAT" HeaderText="With In TAT" />
                                    <asp:BoundField DataField="GRATER_THAN_TAT" HeaderText="Grater Than TAT" />
                                    <asp:BoundField DataField="PENDING" HeaderText="Pending" />
                                    <asp:BoundField DataField="PER_WITHIN" HeaderText="% With In" />
                                    <asp:BoundField DataField="PER_GRATER_TAT" HeaderText="% Grater Than TAT" />
                                    <asp:BoundField DataField="PER_PENDING" HeaderText="% Pending" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td colspan="8">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                    Display="None" ErrorMessage="Please select From Date" SetFocusOnError="True"
                    ValidationGroup="Val" Font-Size="9pt"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                    Display="None" ErrorMessage="Please Select To Date" SetFocusOnError="True" ValidationGroup="Val" Font-Size="9pt"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator_From_ToDate" runat="server" Display="None" Font-Size="9pt" SetFocusOnError="True" ValidationGroup="Val" ClientValidationFunction="funValidateFromToDate" ErrorMessage="To Date should not be less then From Date"></asp:CustomValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_FromDate"
            runat="server" ControlToValidate="txtFromDate" Display="None" ErrorMessage="Please enter valid From Date."
            Font-Names="Arial" Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Val"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_ToDate" runat="server"
            ControlToValidate="txtToDate" Display="None" ErrorMessage="Please enter valid To Date."
            Font-Names="Arial" Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Val"></asp:RegularExpressionValidator><%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom_Date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter From date." ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo_date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter To date."  ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        --%>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select From Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select To Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        --%>
        
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Val" Font-Size="9pt" />
        </td>        
        </tr>
    </table>
                
    </fieldset>
    <br />
   <table style="width: 100%" id="tblExport" runat="server" visible="false">       
        <tr>
            <td >
                <table>            
                
                    <tr>
                    <td>
                   <font size="4"><asp:Label ID="lbl" runat="server" Text="PAMAC Finserve Private Limited"></asp:Label></font>
                    <br /><br />              
                    <asp:Label ID="Label4" runat="server" Text="From Date:" Font-Bold="true" ></asp:Label>                
                    <asp:Label ID="lblFromDate" runat="server" Font-Size="12px"></asp:Label><br />
                    <asp:Label ID="Label5" runat="server"  Text="To Date:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblToDate" runat="server" Font-Size="12px" ></asp:Label>
                    <br />                    
                    <br />
                    </td>
                     </tr>   
                </table>
            </td>
        </tr>           
        <tr>
            <td>
                <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort">      
                <Columns>
                    <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                    <asp:BoundField DataField="NO" HeaderText="Total No" />
                    <asp:BoundField DataField="WITHIN_TAT" HeaderText="With In TAT" />
                    <asp:BoundField DataField="GRATER_THAN_TAT" HeaderText="Grater Than TAT" />
                    <asp:BoundField DataField="PENDING" HeaderText="Pending" />
                    <asp:BoundField DataField="PER_WITHIN" HeaderText="% With In" />
                    <asp:BoundField DataField="PER_GRATER_TAT" HeaderText="% Grater Than TAT" />
                    <asp:BoundField DataField="PER_PENDING" HeaderText="% Pending" />
                </Columns>              
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

