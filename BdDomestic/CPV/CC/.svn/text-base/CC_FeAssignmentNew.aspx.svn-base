<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_FeAssignmentNew.aspx.cs" Inherits="CPV_CC_FeAssignmentNew" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
       <!--
       function ClientValidate(source, arguments)
       {
          if ((arguments.Value) == "0")
          {
             //alert('Please select FE');
             arguments.IsValid=false;
          }
          else
          {
              arguments.IsValid=true;
          }
       }
       function DoAtLeastOne(source, arguments)
       {
           if(((document.getElementById('<%=txtCaseId.ClientID%>').value=="") && (document.getElementById('<%=txtRefNo.ClientID%>').value!=""))||((document.getElementById('<%=txtCaseId.ClientID%>').value!="") && (document.getElementById('<%=txtRefNo.ClientID%>').value=="")))
           {
                arguments.IsValid =true;
           }
           else
           {
                //alert('Enter either Case ID or Ref. No.');
                arguments.IsValid =false;
           }
       }
       -->
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">FE Assignment</legend>
 <table border="0" cellpadding="1" cellspacing="0" width="100%">   
    <tr><td><asp:Label ID="lblMsg" runat="server" SkinID="lblError"></asp:Label>
        <br />
        <asp:Label ID="lblCount" runat="server" Font-Bold="True"></asp:Label></td></tr> 
    <tr><td>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="height: 24px"  >
            Date</td>
        <td style="height: 24px" >
            :
        </td>
        <td style="height: 24px" >
            <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.ctl00$C1$txtDate, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.gif" />&nbsp;[dd/MM/yyyy]
        </td>
        <td style="height: 24px" >
        </td>
        <td style="height: 24px" >
            FE Name
        </td>
        <td style="height: 24px" >
            :
        </td>
        <td style="height: 24px" >
            <asp:DropDownList ID="ddlSearchFE" runat="server" DataSourceID="sdsSearchFE" CausesValidation="false"
                DataTextField="FULLNAME" DataValueField="FE_ID" OnDataBound="ddlSearchFE_DataBound" SkinID="ddlSkin" OnSelectedIndexChanged="ddlSearchFE_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <asp:CustomValidator ID="cvSelectFe" runat="server" ControlToValidate="ddlSearchFE"
                Display="None" ErrorMessage="Please select FE Name" ValidationGroup="grpFeAssign" ClientValidationFunction="ClientValidate"></asp:CustomValidator><%--<asp:CustomValidator ID="cvEitherOne" runat="server" Display="None" ErrorMessage="Enter either Case ID or Ref. No."
                ValidationGroup="grpFeAssign" ClientValidationFunction="OneOf" ></asp:CustomValidator>--%></td>
    </tr>
    <tr>
        <td>
            Case ID
        </td>
        <td>:
        </td>
        <td>
            <asp:TextBox ID="txtCaseId" runat="server" SkinID="txtSkin" MaxLength="15"></asp:TextBox>    </td>
        <td>
        </td>
        <td>
            Ref. No.
        </td>
        <td>:
        </td>
        <td>
            <asp:TextBox ID="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td>
            Verification Type
        </td>
        <td style="width: 2px">
            :
        </td>
        <td>
                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE_CODE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlType_DataBound" AutoPostBack="false" SkinID="ddlSkin">
                </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 2px">
            &nbsp;</td>
        <td>
            &nbsp;<asp:Button ID="btnAssign" runat="server" SkinId="btnAssingSkin" OnClick="btnAssign_Click" ValidationGroup="grpFeAssign" /></td>
    </tr>
  </table>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>        
        <asp:GridView ID="gvFEAssignedList" runat="server" AutoGenerateColumns="False" DataSourceID="sdsGV" OnRowCommand="gvFEAssignedList_RowCommand" SkinID="gridviewSkin" Width="100%" OnRowDeleting="gvFEAssignedList_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Ref_No" HeaderText="Reference No" />
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="VERIFICATION_TYPE_CODE" HeaderText="Verification" />
                <asp:BoundField DataField="IsAuto" HeaderText="Assignment Status" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete"
                            ImageUrl="~/Images/icon_delete.gif" /><asp:HiddenField ID="hidCaseId" Value='<%# Bind("Case_Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>         
            </Columns>
        </asp:GridView>

    </td></tr>
    <tr><td align="right" style="height: 15px">
        &nbsp;</td></tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="grpFeAssign" />
</fieldset>
</td></tr>
</table>
     <asp:SqlDataSource ID="sdsVeriType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
     SelectCommand="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(1,2,4,3,10) AND (PARENT_TYPE_CODE = 'VV')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsPincode" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [PINCODE] FROM [FE_PINCODE_MAPPING] ORDER BY [PINCODE]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" DeleteCommand="delete from CPV_CC_FE_CASE_MAPPING where 1=2">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID where ([Centre_ID]=?) order by FULLNAME ">
        <SelectParameters>
            <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                            
        </SelectParameters> 
        </asp:SqlDataSource>
        <asp:HiddenField ID="hdnVerificatioTypeID" runat="server" />
        <asp:SqlDataSource ID="sdsSearchFE" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT FULLNAME, FE_ID FROM FE_VW INNER JOIN FE_PINCODE_MAPPING ON EMP_ID=FE_ID order by FULLNAME ">
        </asp:SqlDataSource>
<%--        <asp:RegularExpressionValidator ID="revDate" runat="server" ErrorMessage="Please enter valid date format for Date" Display="None" SetFocusOnError="True" ValidationGroup="FEAssign" ControlToValidate="txtDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="FEAssign" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="vgrpFE" />
        <asp:RequiredFieldValidator ID="rfvFE" runat="server" ErrorMessage="Please select FE to assign" ControlToValidate="ddlFE" Display="None" SetFocusOnError="True" ValidationGroup="vgrpFE"></asp:RequiredFieldValidator>
--%>
</asp:Content>

