<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="VerificationTypeWiseMIS_DEO.aspx.cs" Inherits="QueryBuilder_VerificationTypeWiseMIS_DEO"%>
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
        <legend class="FormHeading"><strong>Verification&nbsp; Typewise MIS- DEO</strong></legend>
        <table style="width: 100%">
        
            <tr>                
                <td colspan="5" valign="top">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Width="453px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
           <td>&nbsp;<asp:Label ID="Label11" runat="server" SkinID="lblSkin" Text="Database"></asp:Label></td>
            <td class="TDWidth" style="width: 1%">
                :</td>
            <td colspan="6" valign="top">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin" Width="150px">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList>
            </td>
            
        </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Select Centre" Width="73px"></asp:Label></td>
                <td class="TDWidth" style="width: 1%">
                    :</td>
                <td colspan="6" valign="top">
                    <asp:DropDownList ID="ddlCentre" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" SkinID="ddlSkin" Width="150px" AutoPostBack="True">
                        <asp:ListItem Value="0">--All Centre--</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>                
                <td align="left"  valign="top">
                    &nbsp;<asp:Label ID="Label5" runat="server" SkinID="lblSkin" Text="Select DEO" ></asp:Label></td>
                 <td class="TDWidth" style="width: 1%">
                :</td>
                <td align="left"  valign="top" style="width: 228px">
                    <asp:ListBox ID="ListBoxFE" runat="server" SelectionMode="Multiple" SkinID="lbSkin" Width="210px">
                    </asp:ListBox>
                    &nbsp;
                </td>
                <td align="left" valign="top" style="width: 62px">
                    <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Verification Type" Width="94px" ></asp:Label></td>
                 <td class="TDWidth" style="width: 5%" valign="top">
                :</td>
                <td align="left"  valign="top">
                    <asp:ListBox ID="ListBoxVerificationType" runat="server" AppendDataBoundItems="True"
                        DataSourceID="SqlDataSourceVeriFication" DataTextField="VERIFICATION_TYPE_CODE"
                        DataValueField="VERIFICATION_TYPE_ID" SelectionMode="Multiple" SkinID="lbSkin" Width="210px">
                        <asp:ListItem Value="0">All Verification</asp:ListItem>
                    </asp:ListBox>&nbsp;
                    <asp:SqlDataSource ID="SqlDataSourceVeriFication" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT CASE_TRANSACTION_LOG.VERIFICATION_TYPE_ID, VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_CODE FROM CASE_TRANSACTION_LOG INNER JOIN VERIFICATION_TYPE_MASTER ON CASE_TRANSACTION_LOG.VERIFICATION_TYPE_ID = VERIFICATION_TYPE_MASTER.VERIFICATION_TYPE_ID">
                    </asp:SqlDataSource>
                </td>                
                <td align="left" valign="top">
                </td>
            </tr>
            <tr>                
                <td align="left"  valign="top">
                    &nbsp;<asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="From Date" ></asp:Label>
                    <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                    </td>
                     <td class="TDWidth" style="width: 1%">
                :</td>
                <td align="left"  valign="top" style="width: 228px">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
                <td align="left"  valign="top" style="width: 62px">
                <asp:Label ID="Label2" runat="server" SkinID="lblSkin" Text="To Date" ></asp:Label>
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                </td>
                 <td class="TDWidth" style="width: 5%" valign="top">
                :</td>
                <td align="left"  valign="top">
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
                <td align="left" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                </td>
                <td class="TDWidth" style="width: 1%">
                </td>
                <td align="left" style="width: 228px" valign="top">
                    <asp:Button ID="btnReport" runat="server" SkinID="btn"
                        Text="Get Report" ValidationGroup="Val" OnClick="btnReport_Click1" /></td>
                <td align="left" style="width: 62px" valign="top">
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="btn"
                        Text="Cancel" CausesValidation="False" /></td>
                <td class="TDWidth" style="width: 5%" valign="top">
                </td>
                <td align="left" valign="top">
                </td>
                <td align="left" valign="top">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="7">
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label6" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                    <br />
                   
                    <asp:SqlDataSource ID="SqlDataSource_FE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                        SelectCommand="SELECT '0' AS USER_ID, '--All DEO--' AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID WHERE (B.ROLE_CODE = 'DE') ORDER BY NAME">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceDE_CentreWise" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '0' AS USER_ID, '-- All DEO--' AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID INNER JOIN CENTRE_MASTER ON A.CENTRE_ID = CENTRE_MASTER.CENTRE_ID WHERE (B.ROLE_CODE = 'DE') AND (CENTRE_MASTER.CENTRE_ID = ?) ORDER BY NAME">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCentre" Name="CentreID" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td  valign="top" colspan="6">
                    &nbsp;<asp:Label ID="lbl" runat="server" SkinID="lblErrorMsg" Visible="False" Width="581px"></asp:Label></td>
                <td colspan="1" valign="top">
                </td>
            </tr>
            <tr>
               
                <td colspan="6">
                    <table id="tbl" runat="server" style="width: 100%" visible="false">
                        <tr>
                            <td>
                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btn"
                                    Text="Export To Excel" />
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></td>
                        </tr>
                        <tr>
                            <td >
                    <asp:GridView ID="gvVerificationTypeWise" runat="server"  SkinID="gridviewNoSort" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Verification_Type_Code" HeaderText="Verification Type">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="No_Of_Case" HeaderText="Total Records">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Avg_Complition_Time" HeaderText="Avg. Completion Time">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1">
                </td>
            </tr>
           
            <tr>
                
                <td colspan="6">                    
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
                   
                    <asp:ValidationSummary
                                                ID="ValidationSummary1" runat="server" Font-Size="9pt" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="Val" />
                </td>
                <td colspan="1">
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
                <font size="4"><asp:Label ID="Label4" runat="server" Text="PAMAC Finserve Private Limited"></asp:Label></font>
                <br />
                    <asp:Label ID="Label10" runat="server"  Text="FE Name:" Font-Bold="True" Visible="False"></asp:Label>
                    <asp:Label ID="lblFE" runat="server" Font-Size="12px" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server"  Text="Verification Type:" Font-Bold="True" Visible="False"></asp:Label>
                    <asp:Label ID="lblVerificationType" runat="server" Font-Size="12px" Visible="False"></asp:Label>
                    <br /> 
                    <asp:Label ID="Label7" runat="server" Text="From Date:" Font-Bold="true" ></asp:Label>                
                    <asp:Label ID="lblFromDate" runat="server" Font-Size="12px"></asp:Label><br />
                    <asp:Label ID="Label8" runat="server"  Text="To Date:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblToDate" runat="server" Font-Size="12px" ></asp:Label>
                </td>                  
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvExport" runat="server" SkinID="gridviewNoSort" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Verification_Type_Code" HeaderText="Verification Type" />
                        <asp:BoundField DataField="No_Of_Case" HeaderText="Total Records" />
                        <asp:BoundField DataField="Avg_Complition_Time" HeaderText="Avg Complition Time" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

