<%@ Page Language="C#" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" Theme ="SkinFile" AutoEventWireup="true" CodeFile="~/DCR/DocCollection/CC_TC_Assign.aspx.cs" Inherits="CPV_CC_CC_TC_Assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">

 
</script>
<table border="0" cellpadding="0" cellspacing="0" style="width: 99%">
    <tr><td style="padding-left:10px; height: 397px;">
    <fieldset><legend class="FormHeading">Tele Caller Assignment</legend>
        <table border="0" cellpadding="1" cellspacing="0" style="width: 95%">   
         <tr><td style="width: 945px"><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible ="false" ></asp:Label>
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td></tr>
             <tr>
                <td style="width: 945px; height: 1px;">
                </td>
            </tr>
        </table> 
     <table border="0" cellpadding="0" cellspacing="0" width="95%">
        <tr>
        <td style="height: 43px" >From Date</td>
        <td style="width: 2px; height: 43px;">:</td><td style="height: 43px; width: 212px;">
        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="111px"></asp:TextBox>&nbsp;
        <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]</td>
         <td style="height: 43px" >To Date</td>
         <td style="width: 2px; height: 43px;">:</td>
         <td style="height: 43px; width: 230px;">
             &nbsp; &nbsp;<asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="112px"></asp:TextBox>&nbsp;&nbsp;
             <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" id="IMG1" />
             &nbsp; [dd/MM/yyyy]</td>
            
       <%--<td style="height: 43px">Verification Type</td>
        <td style="width: 2px; height: 43px;">:</td>
        <td style="height: 43px">
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID"  AutoPostBack="false" SkinID="ddlSkin" >
                </asp:DropDownList></td>--%>
               <%-- <td style="height: 43px">
                </td>--%>
                <td style="height: 43px; width: 319px;">
                    &nbsp; &nbsp;
                    &nbsp;<strong>Verification Type</strong>
                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" DataSourceID="sdsVeriType"
                        DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID"
                        SkinID="ddlSkin">
                    </asp:DropDownList>
                    &nbsp;&nbsp;<%--<asp:DropDownList ID="ddlClient" runat="server" DataSourceID="sdsClient"
                        Width="146px" AutoPostBack="true" AppendDataBoundItems="true" SkinID="ddlSkin" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem Value="101145">Baclay Dcr</asp:ListItem>
                    </asp:DropDownList>--%>&nbsp; 
                <asp:Button ID="btnSearch" runat="server" SkinID="btnSearchSkin"  ValidationGroup="FEAssign" OnClick="btnSearch_Click" Width="89px" />
                </td>
            </tr></table>
                                              
                   <asp:Label ID="Label2" runat="server" Text="No. Of Search Cases:" Font-Bold="True"></asp:Label>
             <asp:Label ID="lbltot" runat="server" Width="104px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="btnAssign1_Click1" Font-Bold="True" Text="Assign Cases" Width="105px"  /><br />
                  <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 120px">
    <tr>
    
               <td align="left" style="height: 124px; width: 426px;">
                <asp:GridView ID="GVTCTOT" runat="server" AutoGenerateColumns="False" DataSourceID="sdsTC"
                    Width="400px" SkinID="gridviewSkin" Height="1px" OnDataBound="GVTCTOT_DataBound">
                    <Columns>
                <asp:BoundField  DataField="emp_id" HeaderText="Telecaller ID" SortExpression="Emp_id" />
                     
                <asp:BoundField HeaderText="Telecaller Name" DataField="Fullname" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
                    </HeaderTemplate>                
                <ItemTemplate>
                <asp:CheckBox ID="chkname" runat="server" /><asp:HiddenField ID="hidfullname" runat="server"
                        Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                    </Columns>
                    <PagerSettings Position="Top" />
                </asp:GridView>
             
     </td><td style="height: 124px"><asp:GridView ID="GVTCCou"  SkinID="gridviewSkin" runat="server" Width="300px" Height="128px"> 
         <PagerSettings Position="Top" />
     </asp:GridView></td>
                
                <asp:SqlDataSource ID="sdsTC" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT Emp_id,FULLNAME FROM EMPLOYEE_MASTER WHERE department_id=10140  and (DESIGNATION_ID = '8') AND (DOL IS NULL OR  DOL=' ') ORDER BY FULLNAME&#13;&#10;">
                </asp:SqlDataSource>
                <%--<tr><td align="right"> <asp:Button ID="btnAssign" runat="server" SkinId="btnAssingSkin" ValidationGroup="vgrpFE" Width="80px" /></td>
                </tr>--%>
             
     </tr>
                 
   <tr>
    <td style="width: 426px; height: 54px;">
        &nbsp;
       </td></tr>
    <tr><td align="right" style="width: 426px"><asp:Button ID="btnAssign1" runat="server" OnClick="btnAssign1_Click1" Font-Bold="True" Text="Assign Cases"  />  
   
     <asp:SqlDataSource ID="sdsVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
     SelectCommand="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER &#13;&#10;               WHERE VERIFICATION_TYPE_ID IN(20,21,22,23,24) "></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsPincode" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FPM.PINCODE FROM FE_PINCODE_MAPPING AS FPM INNER JOIN FE_VW AS FV ON FPM.FE_ID = FV.EMP_ID WHERE (FV.CENTRE_ID = ?) ORDER BY FPM.PINCODE">
            <SelectParameters>
                <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" ></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsClient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
        &nbsp;&nbsp;
        
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
       <%-- <asp:SqlDataSource ID="sdsSearchFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT TC_ID,e.fullname AS 'TC Name','XXXXX'AS BT,'XXXXX' AS RT,'XXXXX' AS Total INTO #t FROM cpv_cc_tc_case_mapping a,cpv_cc_case_details b, employee_master e WHERE a.case_id=b.case_id AND a.tc_id=e.emp_id AND CONVERT(varchar(10),a.date_time,25) >= ? AND CONVERT(varchar(10),a.date_time,25) < ? AND b.client_id=(?) AND b.centre_id=(?) UPDATE c SET BT = (SELECT count(a.case_id) FROM cpv_cc_tc_case_mapping a, cpv_cc_case_details b WHERE a.case_id = b.case_id AND CONVERT(varchar(10),a.date_time,25) >= ? AND CONVERT(varchar(10),a.date_time,25) < ? AND b.client_id =(?) AND b.centre_id = (?) AND a.verification_type_id IN('3','4')) FROM #t c, cpv_cc_tc_case_mapping d WHERE c.tc_id = d.tc_id UPDATE c SET RT=(SELECT count(a.case_id) FROM cpv_cc_tc_case_mapping a,cpv_cc_case_details b WHERE a.case_id=b.case_id AND CONVERT(varchar(10),a.date_time,25) >= ? AND CONVERT(varchar(10),a.date_time,25) < ? AND b.client_id =(?) AND b.centre_id=(?) AND a.verification_type_id IN('3','4'))FROM #t c, cpv_cc_tc_case_mapping d WHERE c.tc_id=d.tc_id UPDATE #t SET Total=RT+BT SELECT * FROM #t">
         <SelectParameters>
             <asp:SessionParameter Name="CentreId" SessionField="centreId" />
             <asp:SessionParameter DefaultValue="ClientId" Name="ClientId" SessionField="ClientId" />
             <asp:QueryStringParameter DefaultValue="" Name="FromDate" QueryStringField="FromDate" />
             <asp:QueryStringParameter DefaultValue="" Name="ToDate" QueryStringField="ToDate" />
             <asp:Parameter DefaultValue="" Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
             <asp:Parameter Name="?" />
        </SelectParameters> 
        </asp:SqlDataSource>--%>
        <asp:RegularExpressionValidator ID="revDate" runat="server" ErrorMessage="Please enter valid date format for Date" Display="None" SetFocusOnError="True" ValidationGroup="FEAssign" ControlToValidate="txtDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup='vgrpFE' />
        <%-- <asp:RequiredFieldValidator ID="rfvFE" runat="server" ErrorMessage="Please select FE to assign" ControlToValidate="ddlFE" Display="None" SetFocusOnError="True" ValidationGroup="vgrpFE"></asp:RequiredFieldValidator>--%>
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
        </script></td></tr></table>


    <asp:CustomValidator ID="valgv" runat="server" ClientValidationFunction="vaidation"
        Display="None" ErrorMessage="Please select at least one Case. " SetFocusOnError="True"
        ValidationGroup="vgrpFE"></asp:CustomValidator>
         </fieldset>
</td></tr></table>
</asp:Content>
    
