<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_Import_Dump.aspx.cs" Inherits="CPV_CC_CC_Import_Dump" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
function getExtention(source, arguments)
{
        var fileName = document.getElementById("<%=xslFileUpload.ClientID%>").value;
        var extName = fileName.split('.');
        for(iCtr=0; iCtr<extName.length;iCtr++)
        {
            if(extName[iCtr].toLowerCase()=='xls')
            {
                 arguments.IsValid=true;
            }
            else
            {
                arguments.IsValid=false;
            }
        }
}
</script>
<table align="center" width="99%"  border="0" cellpadding="0" cellspacing="0"><tr><td>
<fieldset><legend class="FormHeading">Data Dump</legend>
    <table align="center"  border="0" cellpadding="2" cellspacing="1" width="100%">
        <tr>
            <td class="txtError" colspan="1" >
                <span class="label">&nbsp;Select File </span><span class="txtRed">* </span>
            </td>
            <td>
                <asp:FileUpload ID="xslFileUpload" runat="server" CssClass="textbox" 
                Width="300px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.xls]<asp:RequiredFieldValidator ID="RFVImport"
                    runat="server" ControlToValidate="xslFileUpload" CssClass="txtError" Display="None"
                    ErrorMessage="Please select file to Import." SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUplaod_Click" ValidationGroup="grpImport" SkinID="btnImport" />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;<span class="txtRed">*</span>&nbsp;Indicate mandatory fields.
            </td>
        </tr>
    </table>

</fieldset>
    <asp:Label ID="lblMsgXls" runat="server" CssClass="txtRed" Font-Bold="True"></asp:Label>&nbsp;<asp:ValidationSummary
        ID="ValidationSummary1" runat="server" CssClass="txtError" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpImport" />
        <asp:GridView ID="gvLog" runat="server" SkinID="gridviewNoSort" >
    </asp:GridView>
</td></tr></table>
    <asp:CustomValidator ID="cvImport" runat="server" 
                   ErrorMessage="Please select .xls file" ValidationGroup="grpImport" Display="None" 
                   ClientValidationFunction="getExtention" SetFocusOnError="true"
                   ControlToValidate="xslFileUpload" >
   </asp:CustomValidator>  
</asp:Content>

