<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="Productivity_MIS_DEO_FE.aspx.cs" Inherits="QueryBuilder_Productivity_MIS_DEO_FE"%>
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

function rbcheck(source,arguments)
{
   debugger;
  var rbFE=document.getElementById('<%=rbFE.ClientID%>');
  var rbDE=document.getElementById('<%=rbDEO.ClientID%>');
  if((rbFE.checked==false) &&(rbDE.checked==false))
  {
    arguments.IsValid=false;
     return;
  }
  else
  {
   arguments.IsValid=true;
    return;
  }
}
</script>
    <fieldset>
        <legend class="FormHeading"><strong>Productive MIS Of DEO/ FE</strong></legend>
        <table style="width: 100%">
       
            <tr>               
                <td colspan="1" style="width: 5px" valign="top">
                </td>
                <td colspan="9" valign="top">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
                <td colspan="1" valign="top">
                </td>
            </tr>
             <tr>
                 <td align="left" style="width: 5px" valign="top">
                 </td>
           <td align="left" valign="top" style="width: 27px">&nbsp;<asp:Label ID="Label11" runat="server" SkinID="lblSkin" Text="Database"></asp:Label></td>
            <td class="TDWidth" style="width: 1%" align="left" valign="top">
                :</td>
                 <td align="left" class="TDWidth" style="width: 1%" valign="top">
             <asp:DropDownList ID="ddlDataBase" runat="server" SkinID="ddlSkin" Width="150px">
             <asp:ListItem Text="PMS" Value="PMS"></asp:ListItem>
             <asp:ListItem Text="RepositoryPMS" Value="RepositoryPMS"></asp:ListItem>
             </asp:DropDownList></td>
                 <td align="left" class="TDWidth" style="width: 1%" valign="top">
                 </td>
                 <td align="left" class="TDWidth" style="width: 1%" valign="top">
                 </td>
            <td colspan="6" align="left" valign="top">
                &nbsp;</td>
            
        </tr>
            <tr>
                <td align="left" style="width: 5px" valign="top">
                </td>
                <td align="left" valign="top" style="width: 27px">
                    <asp:Label ID="Label3" runat="server" SkinID="lblSkin" Text="Centre" ></asp:Label><span
                        style="color: #ff0033"></span></td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    :</td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                <asp:DropDownList ID="ddlCentre" runat="server" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="150px" AutoPostBack="true" AppendDataBoundItems="True" SkinID="ddlSkin">
                        <asp:ListItem Value="0">--All Centre--</asp:ListItem>
                    </asp:DropDownList></td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    <asp:Label ID="Label13" runat="server" Text="Select  DE wise OR FE wise" Width="165px"></asp:Label></td>
                <td align="left" colspan="6" valign="top">
                    <asp:RadioButton ID="rbDEO" runat="server" AutoPostBack="True" GroupName="a" OnCheckedChanged="rbDEO_CheckedChanged"
                        Text="DEO Wise" Checked="True" />&nbsp;
                    <asp:RadioButton ID="rbFE" runat="server" AutoPostBack="True" GroupName="a" OnCheckedChanged="rbFE_CheckedChanged"
                        Text="FE Wise" /></td>
            </tr>
            <tr>
                <td align="left" style="width: 5px" valign="top">
                </td>
                <td align="left" valign="top" style="width: 27px">
                    &nbsp;<asp:Label ID="Label5" runat="server" SkinID="lblSkin" Text="Select FE/DE" Width="64px" ></asp:Label></td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    :</td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    <asp:DropDownList ID="ddlFE" runat="server" SkinID="ddlSkin" Width="150px">
                    </asp:DropDownList></td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    <asp:Label ID="Label4" runat="server" Text="Client" SkinID="lblSkin"></asp:Label></td>
                <td align="left" colspan="6" valign="top">
                    <asp:DropDownList ID="ddlClient" runat="server" Width="150px" SkinID="ddlSkin" OnDataBound="ddlClient_DataBound">
                        <asp:ListItem Value="0">--All Client--</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>               
                <td align="left" style="width: 5px" valign="top">
                </td>
                <td  valign="top" align="left">
                    <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="From Date" Width="57px"></asp:Label><span
                        style="color: #ff0033">*</span>
                </td>
                <td class="TDWidth" style="width: 1%" align="left" valign="top">
                :</td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="imgfrom" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    To Date &nbsp;<span style="color: #ff0033">*</span></td>
                <td colspan="4" align="left" valign="top" >
                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../Images/SmallCalendar.gif" /></td>               
                <td colspan="1" align="left" valign="top">
                </td>
            </tr>
            <tr>                
                <td align="left" style="width: 5px;" valign="top">
                </td>
                <td  valign="top" align="left" style="width: 27px;">
                    <span style="color: #ff0033;font-family:Arial;font-size:small"></span></td>
                <td class="TDWidth" style="width: 1%;" align="left" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                </td>
                <td align="left" class="TDWidth" style="width: 1%" valign="top">
                    <asp:Button ID="btnReport" runat="server" SkinID="btn" Text="Get Report"
                        ValidationGroup="Val" OnClick="btnReport_Click" />
                </td>
                <td align="left" valign="top" style="width: 68px;" >
                    <asp:Button ID="btnCancel"
                            runat="server" OnClick="btnCancel_Click" SkinID="btn" Text="Cancel" CausesValidation="False" /></td>
                <td align="left" valign="top" style="width: 130px">
                    </td>
               <td class="TDWidth" align="left" valign="top" style="width: 1%;">
                </td>
                <td align="left" valign="top" style="width: 620px;">
                    </td>
                <td align="left" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="1" style="width: 5px">
                </td>
                <td align="left" colspan="11">
                <span style="color: #ff0033;font-family:Arial;font-size:small">*</span>
                <asp:Label ID="Label6" runat="server" SkinID="lblSkin" Text="Indicate mandatory fields." ></asp:Label>            
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 5px">
                </td>
                <td colspan="10">
                    <asp:SqlDataSource ID="SqlDataSourceFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                        SelectCommand="SELECT '0' AS USER_ID, '--All FE--' AS Name FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID INNER JOIN CENTRE_MASTER ON A.CENTRE_ID = CENTRE_MASTER.CENTRE_ID WHERE (B.ROLE_CODE = 'FE' and a.dol is null) AND (CENTRE_MASTER.CENTRE_ID = ?) ORDER BY Name">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCentre" Name="CentreId" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceDE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '0' AS USER_ID, '--All DEO--' AS Name FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID INNER JOIN CENTRE_MASTER ON A.CENTRE_ID = CENTRE_MASTER.CENTRE_ID WHERE (B.ROLE_CODE = 'DE'  and a.dol is null) AND (CENTRE_MASTER.CENTRE_ID = ?) ORDER BY NAME">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCentre" Name="CentreId" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceDE_ALLCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '0' AS USER_ID, '--All DEO--' AS Name FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID INNER JOIN CENTRE_MASTER ON A.CENTRE_ID = CENTRE_MASTER.CENTRE_ID WHERE (B.ROLE_CODE = 'DE') ORDER BY NAME">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceFE_AllCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '0' AS USER_ID, '--All FE--' AS Name FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID UNION SELECT C.USER_ID, ISNULL(A.FIRSTNAME + ' ', '') + ISNULL(A.MIDDLENAME + ' ', '') + ISNULL(A.LASTNAME + ' ', '') AS NAME FROM EMPLOYEE_MASTER AS A INNER JOIN USER_ROLE AS C ON A.EMP_ID = C.USER_ID INNER JOIN ROLE_MASTER AS B ON C.ROLE_ID = B.ROLE_ID INNER JOIN CENTRE_MASTER ON A.CENTRE_ID = CENTRE_MASTER.CENTRE_ID WHERE (B.ROLE_CODE = 'FE') ORDER BY Name">
                    </asp:SqlDataSource>
                </td>
                
            </tr>
            
            <tr>               
                <td colspan="1" style="width: 5px" valign="top">
                </td>
                <td colspan="10" valign="top">
                    <table id="tbl" runat="server" width="100%" visible="false">
                        <tr>
                            <td align="left" style="width: 778px">
                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" SkinID="btn"
                                    Text="ExportTo Excel" CausesValidation="False" /></td>
                        </tr>
                        <tr>
                            <td style="width: 778px" >
                                <asp:GridView ID="gvMIS_FE_DEO" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="NAME" HeaderText="Name" />
                                        <asp:BoundField DataField="Avg_Complition_Time" HeaderText="Avg Complition Time Per Cases">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="No_Of_Case" HeaderText="Total Case Inputed">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                                        <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                                    </Columns>
                                </asp:GridView>
                                &nbsp;
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td colspan="1" style="width: 5px">
                </td>
                <td colspan="10">
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                        Display="None" ErrorMessage="Please select From Date" Font-Size="9pt" SetFocusOnError="True"
                        ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator_ToDate"
                            runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please Select To Date"
                            Font-Size="9pt" SetFocusOnError="True" ValidationGroup="Val"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="RegularExpressionValidator_FromDate" runat="server" ControlToValidate="txtFromDate"
                                Display="None" ErrorMessage="Please enter valid From Date." Font-Names="Arial"
                                Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="Val"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidatorFor_rb" runat="server" ErrorMessage="Select FE-Wise or DE-Wise " ClientValidationFunction="rbcheck" ValidationGroup="Val" Display="None" SetFocusOnError="True"></asp:CustomValidator>
                    <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                                    Display="None" ErrorMessage="Please enter valid To Date." Font-Names="Arial"
                                    Font-Size="9pt" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                    ValidationGroup="Val"></asp:RegularExpressionValidator><asp:CustomValidator ID="CustomValidator_From_ToDate"
                                        runat="server" ClientValidationFunction="funValidateFromToDate" Display="None"
                                        ErrorMessage="To Date should not be less then From Date" Font-Size="9pt" SetFocusOnError="True"
                                        ValidationGroup="Val"></asp:CustomValidator>
                    <asp:CompareValidator ID="CompareValidator_Centre" runat="server" ControlToValidate="ddlCentre"
                        Display="None" ErrorMessage="PLese Select Centre" Operator="NotEqual" SetFocusOnError="True" ValueToCompare="0"></asp:CompareValidator>
                    <asp:ValidationSummary ID="ValidationSummary1"
                                            runat="server" Font-Size="9pt" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Val" />
                </td>
            </tr>
        </table>
        <table style="width: 100%" id="tblExport" runat="server" visible="false">
            <tr >
            <td valign="top">
                <font size="4"><asp:Label ID="lbl" runat="server" Text="PAMAC Finserve Private Limited"></asp:Label></font>
                <br /><br />                    
                    <asp:Label ID="Label10" runat="server"  Text="Name:" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblFE" runat="server" Font-Size="12px"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server"  Text="Centre:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblCentre" runat="server" Font-Size="12px"></asp:Label>
                    <br /> 
                        <asp:Label ID="Label12" runat="server"  Text="Client:" Font-Bold="true"></asp:Label>                      
                        <asp:Label ID="lblClient" runat="server" Font-Size="12px"></asp:Label>                         
                    <br /> 
                      
                    <asp:Label ID="Label7" runat="server" Text="From Date:" Font-Bold="true" ></asp:Label>                
                    <asp:Label ID="lblFromDate" runat="server" Font-Size="12px"></asp:Label><br />
                    <asp:Label ID="Label8" runat="server"  Text="To Date:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblToDate" runat="server" Font-Size="12px" ></asp:Label>
                    <br />
                    <br />                    
                </td>            
           </tr>
            <tr>                
                <td >
                    <asp:GridView ID="gvExport" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort">
                        <Columns>
                            <asp:BoundField DataField="NAME" HeaderText="Name" />
                            <asp:BoundField DataField="Avg_Complition_Time" HeaderText="Avg Complition Time Per Cases">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="No_Of_Case" HeaderText="Total Case Inputed">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" />
                            <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" />
                        </Columns>
                    </asp:GridView>
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
        <table id="tblFor_FE" runat="server" visible="false" width="100%">
            <tr>
                <td align="left" >
                    <asp:Button ID="btnExportFE" runat="server" OnClick="btnExportFE_Click" Text="Export" SkinID="btn" />
                                <asp:GridView ID="gvFE" runat="server" SkinID="gridviewNoSort" AutoGenerateColumns="False" Width="99%">
                                    <Columns>
                                        <asp:BoundField DataField="FE Name" HeaderText="Fe Name" />
                                        <asp:BoundField DataField="Total Cases" HeaderText="Total Cases" />
                                        <asp:BoundField DataField="AVG PER CASE" HeaderText="Avg Per Cases" />
                                        <asp:BoundField DataField="Client Name" HeaderText="Client Name" />
                                        <asp:BoundField DataField="Centre Name" HeaderText="Centre Name" />
                                    </Columns>
                                </asp:GridView>
                </td>
            </tr>
        </table>
        
    </fieldset>
</asp:Content>

