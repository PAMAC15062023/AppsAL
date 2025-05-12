<%@ Page Language="C#" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="EBC_Standard_Output.aspx.cs" Inherits="CPV_EBC_EBC_Standard_Output"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td align="center">
<fieldset><legend class="FormHeading">Export</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td style="height: 14px">&nbsp; &nbsp; &nbsp; &nbsp;</td></tr>
<tr><td style="height: 6px">
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
    <tr><td align="left" valign="top" style="width: 57px">From</td><td align="left" valign="top" >:</td>
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
    <td align="left" valign="top" >
        <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="vgrpExcelReport" /></td>
    </tr> 
    <tr><td colspan="7" align="left">
    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Text=""></asp:Label>
        <asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink></td></tr>  
    </table>
    </td></tr>
    <asp:Panel ID="pnlView" runat="server" Visible="false">
    <tr><td align="left">
        <asp:Label ID="lblCaseCount" runat="server" Text="" Font-Bold="true"></asp:Label>
    </td></tr>
    <tr><td align="right">
        <asp:Button ID="btnGenrate_Report" runat="server" Text="Genrate Report"  SkinID="btnGenerateReportSkin"  OnClick="btnGenrate_Report_Click" ValidationGroup="vgrpExcelReport" />
        <asp:Button ID="btnReport1" runat="server" Text="Generate Excel Report" Visible="false" SkinID="btnGenerateExcelReportSkin" OnClick="btnReport_Click" ValidationGroup="vgrpExcelReport" /></td></tr>

    <tr><td>
        <asp:GridView ID="gvOutput" runat="server" SkinID="gridviewNoSort" DataSourceID="sdsOutput" AutoGenerateColumns="False" 
        DataKeyNames="CASE_ID" Width="100%" OnDataBound="gvOutput_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="CASE_ID" SortExpression="CASE_ID">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CASE_ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CASE_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                </ItemTemplate></asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsOutput" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            SelectCommand="SELECT CD.[CASE_ID], ISNULL(CD.FIRST_NAME + ' ', '') +ISNULL(CD.MIDDLE_NAME + ' ', '') + ISNULL(CD.LAST_NAME + ' ', '') AS [APPLICANT_NAME],  Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5)  + RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as [CASE_REC_DATETIME],  Convert(varchar(24),CD.SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3))as [SEND_DATETIME],VM.VERIFICATION_TYPE_CODE AS VERIFICATION_CODE FROM [CPV_EBC_CASE_DETAILS] CD INNER JOIN CPV_EBC_VERIFICATION CV ON CD.CASE_ID=CV.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VM ON CV.VERIFICATION_TYPE_ID= VM.VERIFICATION_TYPE_ID  WHERE (SEND_DATETIME IS NOT NULL) AND (CD.CASE_STATUS_ID IS NOT NULL) AND (CENTRE_ID = ?) AND (CLIENT_ID = ?) AND (SEND_DATETIME >= ?) AND (SEND_DATETIME < ?) ORDER BY cd.CASE_ID" 
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
            <SelectParameters>
                <asp:SessionParameter Name="CENTRE_ID" SessionField="CentreId" Type="String" />
                <asp:SessionParameter Name="CLIENT_ID" SessionField="ClientId" Type="String" /> 
                <asp:ControlParameter ControlID="hdFromDate" Name="FromDate" PropertyName="Value" />
                <asp:ControlParameter ControlID="hdToDate" Name="ToDate" PropertyName="Value" />                     
            </SelectParameters>
        </asp:SqlDataSource>
    </td></tr>
    
    <tr><td align="right">
        <asp:Button ID="btnGenrate_Report1"  runat="server" Text="Genrate Report" SkinID="btnGenerateReportSkin" OnClick="btnGenrate_Report_Click" ValidationGroup="vgrpExcelReport" />    
        <asp:Button ID="btnReport" runat="server" Visible="false"  Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnReport_Click" ValidationGroup="vgrpExcelReport" />
        <asp:HiddenField ID="hdFromDate" runat="server" />
        <asp:HiddenField ID="hdToDate" runat="server" />      
    </td></tr>
                            
 </asp:Panel>
</table></fieldset>
</td></tr>
</table>

    <asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter From Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter To Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>&nbsp;
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport" />
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
</asp:Content>

