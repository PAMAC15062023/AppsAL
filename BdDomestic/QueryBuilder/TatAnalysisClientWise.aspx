<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true"  Theme="SkinFile" CodeFile="TatAnalysisClientWise.aspx.cs" Inherits="QueryBuilder_TatAnalysisClientWise"%>
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
        <legend class="FormHeading"><strong>TAT Analysis Client Wise</strong></legend>
    <table id="tblTatClientWise" cellpadding="0" cellspacing="0" width="100%">
   
   
        <tr>
        
            <td colspan="7">
                <asp:Label ID="LblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
        </tr>
         <tr>
           <td style="width: 124px">&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Database"></asp:Label></td>
            <td style="height: 22px" align="left" valign="top">
                :</td>
            <td colspan="6" style="height: 22px" align="left" valign="top">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td style="width: 124px; height: 24px">
               &nbsp;&nbsp; From date <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                </td>
           <td style="height: 24px" align="left" valign="top">
                :</td>
            <td style="width: 499px; height: 24px" align="left" valign="top" >
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.gif" /></td>
            <td style="height: 24px" align="left" valign="top">
                <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="ToDate" ></asp:Label>
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                </td>
           <td style="height: 24px" align="left" valign="top">
                :</td>
            <td style="width: 2361px; height: 24px" align="left" valign="top">
                <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.gif" /></td>
            <td style="height: 24px" align="left" valign="top" >
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 124px; height: 30px">
            </td>
            <td align="left" style="height: 30px" valign="top">
            </td>
            <td align="left" style="width: 499px; height: 30px" valign="bottom">
                <asp:Button ID="btnReport" runat="server" SkinID="btn"
                    Text="Get Report" OnClick="btnReport_Click" ValidationGroup="Val" />&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
            <td align="left" style="height: 30px" valign="bottom">
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btn"
                    Text="Cancel" /></td>
            <td align="left" style="height: 30px" valign="top">
            </td>
            <td align="left" style="width: 2361px; height: 30px" valign="top">
            </td>
            <td align="left" style="height: 30px" valign="top">
            </td>
        </tr>
        <tr>
                <td align="left" colspan="7">&nbsp;
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label6" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                </td>
            </tr>
        <tr>
            <td colspan="7">
                <table id="tbl" runat="server" visible="false" width="100%">
                    <tr>
                        <td style="width: 962px" >
                            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btn"
                                Text="Export To Excel" />&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 962px">
                            <asp:GridView ID="gvClientWise" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                                    <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                                    <asp:BoundField DataField="CASE_REC_DATETIME" HeaderText="Recieve Date Time" />
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
            <td colspan="6" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                    Display="None" ErrorMessage="Please select From Date" Font-Size="9pt" SetFocusOnError="True"
                    ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator_ToDate"
                        runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please Select To Date"
                        Font-Size="9pt" SetFocusOnError="True" ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                            Display="None" ErrorMessage="Please enter valid From Date." Font-Names="Arial"
                            Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="Val"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                                Display="None" ErrorMessage="Please enter valid To Date." Font-Names="Arial"
                                Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="Val"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator_From_ToDate" runat="server" ClientValidationFunction="funValidateFromToDate"
                    Display="None" ErrorMessage="To Date should not be less then From Date" Font-Size="9pt"
                    SetFocusOnError="True" ValidationGroup="Val"></asp:CustomValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="9pt" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Val" />
            </td>
        </tr>
    </table>
       
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom_Date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter From date." ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo_date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter To date."  ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        --%>
        
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select From Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select To Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        --%>
       
    </fieldset>
    <br />
   <table id="tblExport" runat="server" visible="false" width="100%" cellpadding="0" cellspacing="0">
        
        <tr>
            <td colspan="9">
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
            <td colspan="9" >&nbsp;</td>            
        </tr>     
        <tr>
            <td colspan="9" >
                <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort">
                    <Columns>
                        <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                        <asp:BoundField DataField="client_name" HeaderText="Client Name" SortExpression="client_name" />
                        <asp:BoundField DataField="Case_rec_datetime" HeaderText="Recieve Date Time" />
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


