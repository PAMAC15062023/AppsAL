<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_Standard_Output.aspx.cs" Inherits="CPV_CC_CC_Standard_Output" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
<!--
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
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Export</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%" >
<tr><td >&nbsp; &nbsp; &nbsp; &nbsp;</td></tr>
<tr><td >
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%" >
    <tr>
        <td align="left" valign="top">
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
        <td align="left" valign="top">
            <asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria"/></td>
        <td align="left" style="width: 57px" valign="top">
            Date</td>
        <td align="left" valign="top">
            :</td>
        <td align="left" valign="top">
            <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp; [dd/MM/yyyy]</td>
        <td align="left" valign="top">
            Time</td>
        <td align="left" valign="top">
            :</td>
        <td align="left" valign="top">
            <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Width="44px"></asp:TextBox>&nbsp;
            <asp:DropDownList
                ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td align="right" valign="top">
           <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="vgrpExcelReport" />&nbsp;&nbsp;
        </td>
       
    </tr>   
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td align="left" colspan="1" style="height: 14px">&nbsp;
        </td>
        <td colspan="9" align="left" style="height: 14px">
    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Text=""></asp:Label>
        <asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink></td></tr>  
    </table>
    </td></tr>
    <asp:Panel ID="pnlView" runat="server" Visible="false">    
     <tr><td align="right">
    <table id="Table1" runat="server">
    <tr>
    <td class="TDWidth">
    <b>Select format :</b>
    </td>
    <td class="TDWidth"><asp:DropDownList ID="ddlSelectFormat1" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat1"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>
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
        <asp:CompareValidator ID="cmpvalSelectFormat1" runat="server" ControlToValidate="ddlSelectFormat1"
            Operator="NotEqual" ValueToCompare="0" ValidationGroup="vgrpExcelReport1" ErrorMessage="Please select format." SetFocusOnError="true" Display="none"></asp:CompareValidator>
        <asp:ValidationSummary ID="valSelectFormat1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="vgrpExcelReport1" />
    </td>
    <td class="TDWidth">    
    <asp:Button ID="btnExport1" runat="server" Text="Export" SkinID="btnexportskin" OnClick="btnExport_Click" ValidationGroup="vgrpExcelReport1"  />&nbsp;&nbsp;
    </td>
    </tr>
    </table>
      </td></tr>  
    <tr>
    <td>
        <asp:GridView ID="gvOutput" runat="server" SkinID="gridviewNoSort" DataSourceID="sdsOutput" AutoGenerateColumns="False" 
        DataKeyNames="CASE_ID" Width="100%" OnDataBound="gvOutput_DataBound" PageSize="1" AllowPaging="true">
            <Columns>
                <asp:TemplateField HeaderText="CASE_ID" SortExpression="CASE_ID">
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
                <asp:TemplateField ItemStyle-HorizontalAlign="center">
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
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
            <SelectParameters>
                <asp:SessionParameter Name="CENTRE_ID" SessionField="CentreId" Type="String" />
                <asp:SessionParameter Name="CLIENT_ID" SessionField="ClientId" Type="String" />               
            </SelectParameters>
        </asp:SqlDataSource>
    </td></tr>
    <tr><td align="left">
        <asp:Label ID="lblCaseCount" runat="server" Text="" Font-Bold="true"></asp:Label></td></tr>
    <tr><td align="right">
    <table id="tblSelectFormat" runat="server">
    <tr>
    <td class="TDWidth">
    <b>Select format :</b>
    </td>
    <td class="TDWidth"><asp:DropDownList ID="ddlSelectFormat" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>
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
        <asp:CompareValidator ID="cmpvalSelectFormat" runat="server" ControlToValidate="ddlSelectFormat"
            Operator="NotEqual" ValueToCompare="0" ValidationGroup="vgrpExcelReport" ErrorMessage="Please select format." SetFocusOnError="true" Display="none"></asp:CompareValidator>
      
    </td>
    <td class="TDWidth">    
    <asp:Button ID="btnExport" runat="server" Text="Export" SkinID="btnexportskin" OnClick="btnExport_Click" ValidationGroup="vgrpExcelReport"  />&nbsp;&nbsp;
    </td>
    </tr>
    </table>
      </td></tr>  
    <%--<asp:Button ID="btnGenrate_Report1" runat="server" Text="Genrate Report" SkinID="btnGenerateReportSkin" OnClick="btnGenrate_Report_Click" ValidationGroup="vgrpExcelReport" />
    <asp:Button ID="btnReport" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnReport_Click" ValidationGroup="vgrpExcelReport" /></td></tr>--%>
 </asp:Panel>
</table>
<br />
</fieldset>
</td></tr>
</table>
    <%--<asp:RequiredFieldValidator ID="rvFromDate" runat="server" ControlToValidate="txtFromDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter From Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="rvToDate" runat="server" ControlToValidate="txtToDate"
         Display="None" SetFocusOnError="True" ErrorMessage="Please enter To Date" ValidationGroup="vgrpExcelReport"></asp:RequiredFieldValidator>
    --%><asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>
        
    <%--<asp:CustomValidator ID="cvSelectFormat" runat="server" 
        ErrorMessage="Please select format." ValidationGroup="vgrpExcelReport" Display="None" ClientValidationFunction="ClientValidate"
        ControlToValidate="ddlSelectFormat" OnServerValidate="cvSelectFormat_ServerValidate"></asp:CustomValidator>--%>
        
    
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
        <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
            Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator
            ID="revTime" runat="server" ControlToValidate="txtTime" Display="None" ErrorMessage="Please enter valid time format."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
            ValidationGroup="vgrpExcelReport"></asp:RegularExpressionValidator>            
       <asp:CustomValidator ID="cvDateTime" runat="server" Display="None" ErrorMessage="Please select both date and time."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator>        
       <asp:CustomValidator ID="cvFromToDateTime" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
            ValidationGroup="vgrpExcelReport" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator>
            
</asp:Content>

