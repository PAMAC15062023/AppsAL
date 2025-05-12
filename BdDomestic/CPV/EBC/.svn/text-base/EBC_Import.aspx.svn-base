<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile"  CodeFile="EBC_Import.aspx.cs" Inherits="CPV_EBC_EBC_Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
   <!--
   function ClientValidate(source, arguments)
   {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
   // -->
</script>
<table align="center" width="99%"  border="0" cellpadding="0" cellspacing="0"><tr><td>
<fieldset><legend class="FormHeading">Import</legend>
<table align="center"  border="0" cellpadding="2" cellspacing="1"
    width="100%">
    <tr valign="top">
        <td class="label" colspan="7" align="center"  style="background-color:#E7F6FF">
            <asp:Label ID="lblRecordCount" runat="server" SkinID="lblError"></asp:Label></td>
    </tr>
    <tr valign="top">
        <td class="label" colspan="2" >
            Template <span class="txtRed">* </span></td>
        <td align="left">
            <asp:DropDownList ID="ddlTemplate" runat="server" OnDataBound="ddlTemplate_DataBound" SkinID="ddlSkin">
                <asp:ListItem Value="0">-- Select Template --</asp:ListItem>
            </asp:DropDownList>&nbsp; &nbsp;&nbsp; Case Type&nbsp;
            <asp:DropDownList ID="ddlCaseType" runat="server" OnDataBound="ddlTemplate_DataBound" SkinID="ddlSkin">
                <asp:ListItem Value="1">Fresh cases</asp:ListItem>
                <asp:ListItem Value="2">Redo cases</asp:ListItem>
                <asp:ListItem Value="3">RCC cases</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="sdsTemplate" runat="server" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
            ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"></asp:SqlDataSource>
            <asp:CustomValidator ID="cvTemplate" runat="server" ClientValidationFunction="ClientValidate"
                ControlToValidate="ddlTemplate" Display="None" ErrorMessage="Please select Template"
                 ValidationGroup="grpImport"></asp:CustomValidator>
            <asp:CheckBox ID="chkRedo" Text="Redo" SkinID="chkSkin" runat="server" />
        </td>
        <td class="txtError" colspan="1" >
            <span class="label">&nbsp;Select File </span><span class="txtRed">* </span></td>
        <td align="left" class="label" colspan="3">
            &nbsp;<asp:FileUpload ID="xslFileUpload" runat="server" CssClass="textbox" 
                Width="300px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.xls]<asp:RequiredFieldValidator ID="RFVImport"
                    runat="server" ControlToValidate="xslFileUpload" CssClass="txtError" Display="None"
                    ErrorMessage="Please select file to Import." SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator></td>
    </tr>
    <tr valign="top">
        <td class="label" colspan="2" >
            Verification Type&nbsp; <span class="txtRed">* </span></td>
        <td align="left">
            <asp:DropDownList ID="ddlVeriType" runat="server" SkinID="ddlSkin" DataSourceID="sdsVeriType" DataValueField="VERIFICATION_TYPE_ID" DataTextField="VERIFICATION_TYPE" OnDataBound="ddlVeriType_DataBound">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sdsVeriType" runat="server" SelectCommand="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(1,15,16,17,18) AND (PARENT_TYPE_CODE = 'VV')" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
                <asp:CustomValidator ID="VeriVal" runat="server" ClientValidationFunction="ClientValidate"
                ControlToValidate="ddlVeriType" Display="None" ErrorMessage="Please select Verification Type"
                 ValidationGroup="grpImport"></asp:CustomValidator>
        </td>
        <td class="txtError" colspan="1">
        </td>
        <td align="left" class="label" colspan="3">
        </td>
    </tr>
    <tr valign="top">
        <td class="label" colspan="2">
            Received &nbsp;Date&nbsp;<span class="txtRed">* </span></td>
        <td align="left">
            &nbsp;<asp:TextBox ID="txtALC_Date" runat="server" CssClass="textbox" MaxLength="11"
                Text="" SkinID="txtSkin"></asp:TextBox>
                <img src="../../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtALC_Date.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
            &nbsp;[dd/mm/yyyy]<asp:RequiredFieldValidator ID="RFVALC_Date" runat="server" ControlToValidate="txtALC_Date"
                CssClass="txtError" Display="None" ErrorMessage="Received Date should not be blank"
                SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVALC_Date" runat="server" ControlToValidate="txtALC_Date"
                CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for Received Date"
                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="grpImport"></asp:RegularExpressionValidator></td>
        <td class="txtError" colspan="1">
            Received Time <span class="txtRed">* </span></td>
        <td align="left" class="label" colspan="3">
            &nbsp;<asp:TextBox ID="txtACT_Time" runat="server" CssClass="textbox" MaxLength="5"
                Text="09:30" Width="40px" SkinID="txtSkin"></asp:TextBox>
            <asp:DropDownList ID="ddlTimeType" runat="server" CssClass="combo" SkinID="ddlSkin">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>[hh:mm]<asp:RequiredFieldValidator ID="RFVACT_Time" runat="server" ControlToValidate="txtACT_Time"
                CssClass="txtError" Display="None" ErrorMessage="Received Time should not be blank"
                SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="REVACT_Time" runat="server" ControlToValidate="txtACT_Time" CssClass="txtError"
                    Display="None" ErrorMessage="Enter valid Received Time" SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpImport"></asp:RegularExpressionValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUplaod_Click" ValidationGroup="grpImport" SkinID="btnImport" /></td>
    </tr>
    <tr>
        <td colspan="7">
            &nbsp;<span class="txtRed">*</span>&nbsp;Indicate mandatory fields.
        </td>
    </tr>
</table>
    <asp:Label ID="lblMsgXls" runat="server" CssClass="txtRed" Font-Bold="True"></asp:Label><asp:ValidationSummary ID="ValidationSummary1"
        runat="server" CssClass="txtError" DisplayMode="List" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="grpImport" />
    <asp:GridView ID="gvLog" runat="server" SkinID="gridviewNoSort" >
    </asp:GridView>
</fieldset>
</td></tr></table>
</asp:Content>