<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_Standard_Output.aspx.cs" Inherits="IDOC_IDOC_Standard_Output" Theme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
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
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Export</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td>&nbsp;
    </td></tr>
<tr><td>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
    <tr><td align="left" valign="top">&nbsp;From Date <font color="red">* </font>&nbsp;&nbsp;</td><td align="left" valign="top">:</td>
    <td align="left" valign="top">
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]</td>
    <td align="left" valign="top">To Date&nbsp; <font color="red">* </font>
    </td><td align="left" valign="top">:</td>
    <td align="left" valign="top">
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>       
    <td align="left" valign="top">
        <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" ValidationGroup="vgrpExcelReport" OnClick="btnSearch_Click" /></td>
    </tr> 
    <tr>
        <td colspan="7">
            <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
    </tr>
   <tr>
        <td colspan="7">
             <asp:Label ID="lblCaseCount" runat="server" Font-Bold="True" Width="89%"></asp:Label></td>
    </tr>
    <tr><td colspan="7">    
    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label>
    <asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink></td>
   </tr>  
    </table>
    </td></tr>
    <asp:Panel ID="pnlView" runat="server" Visible="false" Width="100%">
    <tr><td align="right">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        
        <asp:Button ID="btnExcelReport1" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click"  /></td></tr>
    <tr><td>
        <asp:GridView ID="gvOutput" runat="server" SkinID="gridviewNoSort" DataSourceID="sdsOutput" 
        AutoGenerateColumns="False"  PageSize="100" AllowPaging="True"  OnPageIndexChanged="gvOutput_PageIndexChanged" 
        OnPageIndexChanging="gvOutput_PageIndexChanging" OnDataBound="gvOutput_DataBound"
        DataKeyNames="CASE_ID" Width="100%">
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
        <asp:SqlDataSource ID="sdsOutput" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
            SelectCommand="SELECT CASE_ID, ISNULL(FIRST_NAME + ' ', '') + ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '') AS APPLICANT_NAME, CONVERT (varchar(24), CASE_REC_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), CASE_REC_DATETIME, 22), 3)) AS CASE_REC_DATETIME, CONVERT (varchar(24), SEND_DATETIME, 103) + ' ' + LTRIM(SUBSTRING(CONVERT (VARCHAR(20), SEND_DATETIME, 22), 10, 5) + RIGHT (CONVERT (VARCHAR(20), SEND_DATETIME, 22), 3)) AS SEND_DATETIME FROM CPV_IDOC_CASE_DETAILS WHERE (SEND_DATETIME IS NOT NULL) AND (CENTRE_ID = ?) AND (CLIENT_ID = ?) AND (SEND_DATETIME >= ?) AND (SEND_DATETIME < ?) ORDER BY CASE_ID"><SelectParameters>
                <asp:SessionParameter Name="CENTRE_ID" SessionField="CentreId" Type="String" />
                <asp:SessionParameter Name="CLIENT_ID" SessionField="ClientId" Type="String" />   
                <asp:ControlParameter ControlID="hdFromDate" Name="FromDate" PropertyName="Value" />
                <asp:ControlParameter ControlID="hdToDate" Name="ToDate" PropertyName="Value" />            
            </SelectParameters>
        </asp:SqlDataSource>        
    </td></tr>
    <tr><td align="right">
    
    <asp:Button ID="btnExcelReport" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click"/></td></tr>
    <asp:HiddenField ID="hdFromDate" runat="server" />
    <asp:HiddenField ID="hdToDate" runat="server" />
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

</asp:Content>

