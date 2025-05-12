<%@ page language="C#" masterpagefile="~/HDFCBANK/HDFCBANK/MasterPage.master" autoeventwireup="true" inherits="CPV_KYC_KYC_EXPORT_ALL, App_Web_kyc_export_all.aspx.513d3bc3" theme="SkinFile" viewStateEncryptionMode="Always" %>

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
       
            if(document.getElementById("<%=txtFromDate.ClientID%>").value=="" || document.getElementById("<%=txtToDate.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
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
  

<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">    
<fieldset><legend class="FormHeading">Kyc - Export</legend>
    <br />
    
<br />

<table border="0" cellpadding="0" cellspacing="0" width="100%" >

<tr><td>
<table id="tblExport" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="width: 80px; height: 13px" valign="top">
            Client Name :
        </td>
        <td align="left" style="height: 13px" valign="top">
            :</td>
        <td align="left" style="height: 13px" valign="top">
            <asp:DropDownList ID="ddlclientname" runat="server" SkinID="ddlSkin">
            </asp:DropDownList></td>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="height: 13px" valign="top">
        </td>
        <td align="left" style="height: 13px">
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top" style="width: 80px">From</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>&nbsp;&nbsp;
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtFromDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;
        [dd/MM/yyyy]</td>
    <td align="left" valign="top">To</td><td align="left" valign="top" >:</td>
    <td align="left" valign="top" >
    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
    <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtToDate, 'dd/mm/yyyy', 0, 0);"
            src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy] &nbsp;
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" SkinID="btnSearchSkin"
             ValidationGroup="grpValidate" /></td>       
        <td align="left" valign="top">
            </td>
        <td align="left" valign="top">
        </td>
    <td align="left">
        </td>
    </tr> 
   <tr><td colspan="11" style="height: 65px"><hr />
       &nbsp;<asp:Label ID="lblreport" runat="server" Font-Bold="True" Text="Excel Reports :-"></asp:Label>&nbsp;
       <asp:DropDownList ID="ddlReports" runat="server" SkinID="ddlSkin" Width="229px">
           <asp:ListItem Value="HDFC_CPV_Initiation_Details">CPV Initiation Detail MIS</asp:ListItem>
           <asp:ListItem Value="HDFC_CPV_Initiator_Details">Initiator Detail MiS</asp:ListItem>
           <asp:ListItem Value="Sp_HDFC_Count">Count MiS</asp:ListItem>
                <asp:ListItem Value="HDFC_CPV_Initiation_Details_PanIndia">CPV Initiation HDFC Liability Individual PANINDIA MIS</asp:ListItem>
                      <asp:ListItem Value="HDFC_CPV_Initiation_Details_PanIndia_Current">CPV Initiation HDFC Liability Current PANINDIA MIS</asp:ListItem>

      
       </asp:DropDownList>
       <asp:Button ID="btnCPVintdetl" runat="server" OnClick="btnCPVintdetl_Click" SkinID="btn"
           Text="Download Report" Width="195px" />
       &nbsp; &nbsp; &nbsp;
       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="HDFC Excel Report" SkinID="btn" Visible="False" />
       &nbsp; &nbsp;<asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria"
           Visible="False" />
       <asp:TextBox ID="TextBox1" runat="server" MaxLength="10" SkinID="txtSkin" Visible="False"
           Width="33px"></asp:TextBox><asp:TextBox ID="TextBox2" runat="server" MaxLength="5"
               SkinID="txtSkin" Visible="False" Width="44px"></asp:TextBox>&nbsp;
       <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlSkin" Visible="False">
           <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
           <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
       </asp:DropDownList>
       &nbsp;</td></tr>
    <tr>
        <td colspan="11" style="height: 24px">
            <asp:RequiredFieldValidator ID="Rfvddlclient" runat="server" ControlToValidate="ddlclientname"
                Display="None" ErrorMessage="Please Select Client Name" InitialValue="--select--"
                ValidationGroup="grpValidate"></asp:RequiredFieldValidator><asp:ValidationSummary
                    ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="grpValidate" />
            <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ErrorMessage="Please Enter From Date" ControlToValidate="txtFromDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ErrorMessage="Please Enter To Date" ControlToValidate="txtToDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td align="left" colspan="8" valign="top" style="height: 14px">
                            <asp:Label ID="lblCaseCount" runat="server" Font-Bold="True" Width="89%"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="8" style="height: 14px" valign="top">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Width="617px"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" colspan="8" style="height: 16px" valign="top">
            &nbsp;<asp:HyperLink ID="hplDownload" runat="server" Target="_blank" Visible="False">Download Reports</asp:HyperLink>
            <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" style="height: 24px" valign="top">
                        <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin" Visible="False"></asp:TextBox>
                    </td>
                    <td align="left" style="height: 24px" valign="top">
                    </td>
                    <td align="left" style="height: 24px" valign="top">
                    </td>
                    <td align="left" style="height: 24px" valign="top">
                        <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Visible="False"
                            Width="44px"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin" Visible="False">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="4" style="height: 24px" valign="top">
                <table id="tblCaseCount" runat="server" visible="false" width="100%">
                    <tr>
                        <td align="right" valign="top" colspan="4" style="width: 908px">
                            &nbsp;<strong>Select format : </strong>
                            <asp:DropDownList ID="ddlSelectFormat1" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat1"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="btnExport1" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a" OnClick="btnExport1_Click"  /></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 908px">
                            &nbsp; &nbsp; &nbsp;
        <asp:GridView ID="gvOutput" runat="server" SkinID="gridviewNoSort" DataSourceID="SqlDataSourceDate" AutoGenerateColumns="False" 
        DataKeyNames="CASE_ID" Width="100%" PageSize="50" AllowPaging="True" OnDataBound ="gvOutput_DataBound" >
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
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <br />
                            <br />
                            <asp:GridView ID="grdvwFGB" runat="server">
                                <RowStyle Font-Names="Calibri" />
                                <EditRowStyle Font-Italic="False" />
                            </asp:GridView>
                            
                              
                               
                        
                            <br />
                            <asp:GridView ID="grv_annexure" runat="server" OnRowCommand="grv_annexure_RowCommand1"
                                SkinID="gridviewNoSort" Width="111px">
                              <Columns>
                                  <asp:TemplateField HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkdownloadAnnexure" runat="server" CommandArgument='<%#Eval("CASE_ID")%>'
                                                CommandName="download"><img src="../../Images/icon_edit.gif" alt="download" style="border:0"/></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            &nbsp;&nbsp;
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="4" style="height: 352px; width: 908px;">
                            <strong>Select format : </strong><asp:DropDownList ID="ddlSelectFormat" runat="server" SkinID="ddlSkin" DataSourceID="sdsSelectFormat"
                DataTextField="TEMPLATE_NAME" DataValueField="TEMPLATE_ID" >            
        </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="btnExport" runat="server" Text="Export" SkinID="btnexportskin" ValidationGroup="a" OnClick="btnExport_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 140px; width: 908px;">
                            <asp:HiddenField ID="hdFromDate" runat="server" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:HiddenField ID="hdnDestPath" runat="server" />
                            <asp:HiddenField ID="hdToDate" runat="server" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:SqlDataSource ID="sdsSelectFormat" runat="server" ProviderName="System.Data.OleDb"
                                SelectCommand="   sp_SelectFormat                    &#13;&#10;                   "
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="@ProductId" SessionField="ProductId" Type="String" />
                                    <asp:ControlParameter ControlID="ddlclientname" Name="@ClientId" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sdsSelectFormat1" runat="server" ProviderName="System.Data.OleDb"
                                SelectCommand="sp_SelectFormat1" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="@ProductId" SessionField="ProductId" Type="String" />
                                    <asp:ControlParameter ControlID="ddlclientname" Name="@ClientId" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSourceDate" runat="server" ProviderName="System.Data.OleDb"
                                SelectCommand="sp_SQlDatasourcedate" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="@Centre_Id" SessionField="CentreId" />
                                    <asp:ControlParameter ControlID="ddlclientname" Name="@Client_Id" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="hdFromDate" Name="@FromDate" PropertyName="Value" />
                                    <asp:ControlParameter ControlID="hdToDate" Name="@ToDate" PropertyName="Value" />
                                    <asp:ControlParameter ControlID="HdnBranchCode" DefaultValue="" Name="@Branch_Code"
                                        PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:HiddenField ID="hdnAnnexure" runat="server" />
                            <asp:HiddenField ID="HdnBranchCode" runat="server" />
                        </td>
                    </tr>
                </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    <table id="tblViewDetail" runat="server" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="TDWidth" colspan="3" style="height: 3417px">
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td class="TDWidth" colspan="3" style="height: 47px">
                &nbsp;&nbsp;  
              
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
  <script type="text/javascript" language="javascript">
           
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
           
    </script>
   
   <script type="text/javascript" language="javascript">
           
               function ChangeCheckBoxState1(id, checkState)
               {
                  var cb = document.getElementById(id);
                  if (cb != null)
                     cb.checked = checkState;
               }
               function ChangeAllCheckBoxStates1(checkState)
               {
                  // Toggles through all of the checkboxes defined in the CheckBoxIDs array
                  // and updates their value to the checkState input parameter
                  if (CheckBoxIDs != null)
                  {
                     for (var i = 0; i < CheckBoxIDs.length; i++)
                        ChangeCheckBoxState1(CheckBoxIDs[i], checkState);
                  }
               }
           
    </script>
</asp:Content>

