<%@ Page Language="C#" MasterPageFile="~/CPV/RL/RL_MasterPage.master" AutoEventWireup="true" CodeFile="RL_EXPORT_ALL.aspx.cs" Inherits="CPV_RL_RL_EXPORT_ALL" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
<!--
function CheckAtleastOne(source, arguments)
{
    var gvID=document.getElementById("<%=gvOutput.ClientID %>");
    var length=gvID.rows.length;
    var i;
    var nCount="Y";
    for(i=1;i<length;i++)
    {
        if(document.getElementById(gvID.rows[i].cells[0].firstChild.id).checked)
        {
            nCount="N";
            break;
        }
    }
    if(nCount=="Y")
    {
         arguments.IsValid=false;
    }
    else
    {
         arguments.IsValid=true;
    }    
}

 function ValidateDateTime(source,arguments)
 {      
       if(document.getElementById("<%=rdoDateTime.ClientID%>").checked==true)
       {
            if(document.getElementById("<%=txtDate.ClientID%>").value=="" || document.getElementById("<%=txtTime.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
            }
       }      
 }
 
 function ValidateFromToDateTime(source,arguments)
 {      
       if(document.getElementById("<%=rdoFromToDate.ClientID%>").checked==true)
       {
            if(document.getElementById("<%=txtFromDate.ClientID%>").value=="" || document.getElementById("<%=txtToDate.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
            }
       }      
 }
  function ExportValidation(source,arguments)
 {
    var ddl1=document.getElementById("<%=ddlSelectFormat1.ClientID%>").value;
    var ddl=document.getElementById("<%=ddlSelectFormat.ClientID%>").value;
    if(ddl!="0" || ddl1!="0")
    {
        arguments.IsValid=true;
    }
    else
    {
        arguments.IsValid=false;
    }     
 }
 function ClientValidate(source, arguments)
 {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
 }

 
 -->
</script>
    <%--<asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter From Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter To Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    --%>
        
    <%--<asp:CustomValidator ID="cvSelectFormat" runat="server" 
        ErrorMessage="Please select format." ValidationGroup="vgrpExcelReport" Display="None" ClientValidationFunction="ClientValidate"
        ControlToValidate="ddlSelectFormat" OnServerValidate="cvSelectFormat_ServerValidate"></asp:CustomValidator>--%>
    <script type="text/javascript" language="javascript">
            <!--
               function ChangeCheckBoxState(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState(CheckBoxIDs[i], checkState);
                  }
               }
            -->
    </script>

<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">    
<fieldset><legend class="FormHeading">RL - Export</legend>
<br />
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td>
<table id="tblExport" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="left" valign="top" style="width: 95px">
            <asp:RadioButton ID="rdoFromToDate" runat="server" Checked="true" GroupName="SelectDateCriteria"
                /></td>
        <td align="left" valign="top" style="width: 57px">From</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]</td>
    <td align="left" valign="top">To</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>       
        <td align="left" valign="top">
        </td>
        <td align="left" valign="top">
        </td>
    <td align="left">
        </td>
    </tr> 
   <tr><td colspan="11"><hr /></td></tr>
    <tr>
        <td align="left" valign="top" style="width: 95px" >
            <asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria"/></td>
        <td align="left" style="width: 57px;" valign="top">
            Date</td>
        <td align="left" valign="top" >
            :</td>
        <td align="left" valign="top" >
            <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp; [dd/MM/yyyy]</td>
        <td align="left" valign="top" >
            Time</td>
        <td align="left" valign="top" >
            :</td>
        <td align="left" valign="top" >
            <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Width="44px"></asp:TextBox>&nbsp;
            <asp:DropDownList
                ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" valign="top" >
           <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" ValidationGroup="vgrpExcelReport" OnClick="btnSearch_Click" />
        </td>
    </tr>   
    <tr>
        <td align="left" colspan="8" valign="top">
                            <asp:Label ID="lblCaseCount" runat="server" Font-Bold="True" Width="89%"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="8" style="height: 16px" valign="top">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Width="617px"></asp:Label></td>
    </tr>
    </table>
    <table id="tblViewDetail" runat="server" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="TDWidth" colspan="3">
                <table id="tblCaseCount" runat="server" visible="false" width="100%">
                    <tr><td colspan="4">
                    <asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink>
                    </td></tr>
                    <tr>
                        <td align="right" valign="top" colspan="4">
                            &nbsp;<strong>Select format : </strong>
                            <asp:DropDownList ID="ddlSelectFormat1" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat1"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="btnExport1" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a" OnClick="btnExport1_Click"  /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp; &nbsp; &nbsp;
        <asp:GridView ID="gvOutput" runat="server" SkinID="gridviewNoSort" DataSourceID="SqlDataSourceDate" AutoGenerateColumns="False" 
        DataKeyNames="CASE_ID" Width="100%" PageSize="100" AllowPaging="True" OnDataBound="gvOutput_DataBound"  >
            <Columns>
                <asp:TemplateField HeaderText="Case Id" SortExpression="CASE_ID">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CASE_ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CASE_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="REF_NO" HeaderText="Ref.No" ReadOnly="True"
                    SortExpression="REF_NO" />
                <asp:BoundField DataField="APPLICANT_NAME" HeaderText="Applicant Name" ReadOnly="True"
                    SortExpression="APPLICANT_NAME" />
                <asp:BoundField DataField="VERIFICATION_CODE" HeaderText="Verification Code" SortExpression="VERIFICATION_CODE" />
                <asp:BoundField DataField="CASE_REC_DATETIME" HeaderText="Case Receive DateTime" ReadOnly="True"
                    SortExpression="CASE_REC_DATETIME" />
                    <asp:BoundField DataField="SEND_DATETIME" HeaderText="Case Send DateTime" ReadOnly="True"
                    SortExpression="SEND_DATETIME" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                    </HeaderTemplate>                
                <ItemTemplate>
                <asp:CheckBox ID="chkCaseId" runat="server" /><asp:HiddenField ID="hidCaseId" runat="server"
                        Value='<%# DataBinder.Eval(Container.DataItem, "CASE_ID") %>' />
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <strong>Select format : </strong><asp:DropDownList ID="ddlSelectFormat" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="btnExport" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a" OnClick="btnExport_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4">
                            <asp:HiddenField ID="hdFromDate" runat="server" />
                            <asp:SqlDataSource ID="sdsSelectFormat" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
              SelectCommand="SELECT '0' as TEMPLATE_ID,'Select' as TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER
                            UNION 
                            SELECT ETM.TEMPLATE_ID,TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER ETM INNER JOIN 
                            EXPORT_TEMPLATE_DETAIL ETD ON ETM.TEMPLATE_ID=ETD.TEMPLATE_ID                             
                            WHERE ([PRODUCT_ID] = ?) and ([CLIENT_ID] = ?)">
          <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
            <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" /> 
          </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsSelectFormat1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
              SelectCommand="SELECT '0' as TEMPLATE_ID,'Select' as TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER
                            UNION 
                            SELECT ETM.TEMPLATE_ID,TEMPLATE_NAME FROM EXPORT_TEMPLATE_MASTER ETM INNER JOIN 
                            EXPORT_TEMPLATE_DETAIL ETD ON ETM.TEMPLATE_ID=ETD.TEMPLATE_ID                             
                            WHERE ([PRODUCT_ID] = ?) and ([CLIENT_ID] = ?)">
          <SelectParameters>
            <asp:SessionParameter Name="ProductId" SessionField="ProductId" Type="String" />                            
            <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" /> 
          </SelectParameters>
        </asp:SqlDataSource>
                            <asp:HiddenField ID="hdToDate" runat="server" />
                            <asp:SqlDataSource ID="SqlDataSourceDate" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
                            SelectCommand="SELECT CASE_ID, REF_NO, ISNULL(FIRST_NAME + ' ', '') + ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS APPLICANT_NAME, VERIFICATION_CODE, CONVERT (varchar(24), CASE_REC_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 3)) AS CASE_REC_DATETIME, CONVERT (varchar(24), SEND_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), SEND_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), SEND_DATETIME, 22), 3)) AS SEND_DATETIME FROM CPV_RL_CASE_DETAILS WHERE (SEND_DATETIME IS NOT NULL) AND (CENTRE_ID = ?) AND (CLIENT_ID = ?) AND (SEND_DATETIME >= ?) AND (SEND_DATETIME < ?) ORDER BY CASE_ID">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="Centre_Id" SessionField="CentreId" />
                                    <asp:SessionParameter Name="Client_Id" SessionField="ClientId" />
                                    <asp:ControlParameter ControlID="hdFromDate" Name="FromDate" PropertyName="Value" />
                                    <asp:ControlParameter ControlID="hdToDate" Name="ToDate" PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
    
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport" />
        <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
            Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
            ID="revTime" runat="server" ControlToValidate="txtTime" Display="None" ErrorMessage="Please enter valid time format."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator><asp:CustomValidator ID="cvDateTime" runat="server" Display="None" ErrorMessage="Please select both date and time."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator><asp:CustomValidator ID="cvFromToDateTime" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td class="TDWidth" colspan="3">
        <asp:ValidationSummary ID="valSelectFormat1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport1" />
                &nbsp;
                <asp:CustomValidator ID="CustomValidator_Export" runat="server" ClientValidationFunction="ExportValidation"
                    Display="None" ErrorMessage="Select Format..." ValidationGroup="a"></asp:CustomValidator>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="a" />       
            </td>
        </tr>
    </table>
    </td></tr>      
</table>
</fieldset>
</td></tr></table>
</asp:Content>

