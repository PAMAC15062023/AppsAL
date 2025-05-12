<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme ="SkinFile" AutoEventWireup="true" CodeFile="NegativeMISTypeWise.aspx.cs" Inherits="QueryBuilder_NegativeMISTypeWise"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
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
        <legend class="FormHeading"><strong>Negative MIS</strong></legend>
        <table style="width: 100%" cellpadding="0" cellspacing="0">
       
            <tr>                
                <td colspan="7" valign="top">
                    <asp:Label ID="LblMsg" runat="server" SkinID="lblError" Visible="False"></asp:Label></td>
                <td colspan="1" valign="top" style="width: 62px">
                </td>
            </tr>
             <tr>
           <td>&nbsp;<asp:Label ID="Label8" runat="server" SkinID="lblSkin" Text="Database"></asp:Label></td>
            <td>
                :</td>
            <td colspan="7">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin" Width="150px">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList>
            </td>
            
        </tr>
            <tr>
                <td valign="top">
                    &nbsp;<asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Select Centre"></asp:Label>
                    <span style="color: #ff0033;font-family:Arial;font-size:small">*</span></td>
                <td>
                    :</td>
                <td valign="top">
                    <asp:DropDownList ID="ddlCentre" runat="server" Width="150px" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td colspan="4" valign="top">
                    </td>
                <td colspan="1" valign="top" style="width: 62px">
                </td>
            </tr>
            <tr>               
                <td style="height:5px" valign="top"></td>
            </tr>
            <tr>
               
                <td  valign="top" style="height: 24px">
                    &nbsp;<asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="From Date"></asp:Label>
                    <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                    </td>
               <td style="height: 24px">
                :</td>
                <td  valign="top" style="height: 24px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
                <td  valign="top" style="height: 24px">
                    <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="To Date" ></asp:Label>
                    <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                    </td>
                <td style="height: 24px">
                :</td>
                <td  valign="top" colspan="2" style="height: 24px; width: 514px;">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
                <td colspan="1" style="height: 24px; width: 62px;" valign="top">
                    &nbsp;</td>                                            
            </tr>
            <tr>
                <td style="height: 24px" valign="top">
                </td>
                <td style="height: 24px">
                </td>
                <td colspan="2" style="height: 24px" valign="top">
                    <table>
                        <tr>
                            <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" SkinID="btn"
                        Text="Get Report" ValidationGroup="Val" OnClick="btnReport_Click" /></td>
                            <td align="center" style="width: 100px">
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btn"
                                    Text="Cancel" /></td>
                        </tr>
                    </table>
                </td>
                <td style="height: 24px">
                </td>
                <td colspan="2" style="width: 514px; height: 24px" valign="top">
                </td>
                <td colspan="1" style="width: 62px; height: 24px" valign="top">
                </td>
            </tr>
            
            <tr>
                <td align="left" colspan="7">&nbsp;
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label5" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                </td>
                <td align="left" colspan="1" style="width: 62px">
                </td>
            </tr>
            
            <tr>
                
                <td colspan="7">
                <table id="tbl" runat="server" visible="false" width="100%">
                 <tr>
                     <td >
                        <asp:Button ID="btnExptExcel" runat="server" SkinID="btn" Text="Export To Excel"
                        OnClick="btnExptExcel_Click" />
                     </td>
                     </tr>
                 <tr>
                     <td>
                        <asp:GridView ID="gvNegativeMIS" runat="server" SkinID="gridviewNoSort" Width="100%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                            <asp:BoundField DataField="APPLICANT_NAME" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="REF_NO" HeaderText="Ref. No." />
                            <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                            <asp:BoundField DataField="VERIFICATION_TYPE_CODE" HeaderText="Verification Type Code" />
                            <asp:BoundField DataField="STATUS_NAME" HeaderText="Status Name" />
                            <asp:BoundField DataField="DECLINED_CODE" HeaderText="Declined Code" />
                            <asp:BoundField DataField="DECLINED_REASON" HeaderText="Declined Reason" />
                            <asp:BoundField DataField="FE_NAME" HeaderText="FE Name" />
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
               </table>
              </td>
                <td colspan="1" style="width: 62px">
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:CompareValidator ID="CompareValidator_Centres" runat="server" ControlToValidate="ddlCentre"
                        Display="None" ErrorMessage="Please Select Centre" Operator="NotEqual" SetFocusOnError="True"
                        ValidationGroup="Val" ValueToCompare="0"></asp:CompareValidator>
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
                                    ValidationGroup="Val"></asp:RegularExpressionValidator><asp:CustomValidator ID="CustomValidator_From_ToDate"
                                        runat="server" ClientValidationFunction="funValidateFromToDate" Display="None"
                                        ErrorMessage="To Date should not be less then From Date" Font-Size="9pt" SetFocusOnError="True"
                                        ValidationGroup="Val"></asp:CustomValidator>&nbsp;
                    <asp:ValidationSummary ID="ValidationSummary1"
                                            runat="server" Font-Size="9pt" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Val" />
                </td>
                <td colspan="1" style="width: 62px">
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
    <table style="width: 100%" id="tblExport" runat="server" visible="false">
        <tr >
            <td valign="top">
                <font size="4"><asp:Label ID="lbl" runat="server" Text="PAMAC Finserve Private Limited"></asp:Label></font>
                <br /><br />              
                <asp:Label ID="Label4" runat="server" Text="From Date:" Font-Bold="true" ></asp:Label>                
                <asp:Label ID="lblFromDate" runat="server" Font-Size="12px"></asp:Label><br />
                <asp:Label ID="Label6" runat="server"  Text="To Date:" Font-Bold="true"></asp:Label>
                <asp:Label ID="lblToDate" runat="server" Font-Size="12px" ></asp:Label>
                <br />
                    <asp:Label ID="Label7" runat="server"  Text="Centre:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblCentre" runat="server" Font-Size="12px"></asp:Label>
                    <br />
                    <br />
                </td>            
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvExport" runat="server" SkinID="gridviewNoSort" Width="100%">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

