<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_Crawler.aspx.cs" Inherits="CC_CC_Crawler" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
function getExtention(source, arguments)
{
        var fileName = document.getElementById("<%=xslFileUpload.ClientID%>").value;
        var extName = fileName.split('.');
        for(iCtr=0; iCtr<extName.length;iCtr++)
        {
            if((extName[iCtr].toLowerCase()=='html')||(extName[iCtr].toLowerCase()=='htm'))
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
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend  class="FormHeading">Crawler</legend>
<table cellpadding="0" cellspacing="0" border="0" id="tblMain" style="width:100%" runat="server" >
        <tr>
            <td class="txtError" colspan="1" >
                <span class="label">&nbsp;Select File </span><span class="txtRed">* </span>
            </td>
            <td>
                <asp:FileUpload ID="xslFileUpload" runat="server" CssClass="textbox" 
                Width="300px" SkinID="flup" />&nbsp;
            &nbsp;[Only *.html/htm]<asp:RequiredFieldValidator ID="RFVImport"
                    runat="server" ControlToValidate="xslFileUpload" CssClass="txtError" Display="None"
                    ErrorMessage="Please select file to upload." SetFocusOnError="True" ValidationGroup="grpCrawler"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnUplaod" runat="server" CssClass="button" OnClick="btnUplaod_Click" ValidationGroup="grpCrawler" SkinID="btnUploadSkin" />
            </td>
        </tr>
        <tr>
        
            <td colspan="7">
                &nbsp;<span class="txtRed">*</span>&nbsp;Indicate mandatory fields.
            </td>
        </tr>
        <tr><td colspan="7">&nbsp;</td></tr>        
        <tr>        
        <td colspan="7" align="center">
        <asp:Panel ID="pnlCrawler" runat="server" Visible="false">
            <table id="tblGrid" runat="server" cellpadding="0" cellspacing="0">
                <tr><td align="right"><asp:Button ID="btnExcelReport" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click"/></td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td><div id="dvCrawler" style="overflow:scroll; width:970px; height:auto;">             
                    <asp:GridView ID="gvCrawler" runat="server" SkinID="gridviewNoSort" >
                    </asp:GridView>
                </div></td></tr>
                <tr><td>&nbsp;</td></tr>
                <tr><td align="right"><asp:Button ID="btnExcelReport1" runat="server" Text="Generate Excel Report" SkinID="btnGenerateExcelReportSkin" OnClick="btnExcelReport_Click"/></td></tr>
            </table>        
        </asp:Panel>
        </td>
        </tr>
</table>
    <asp:Label ID="lblMsgXls" runat="server" SkinID="lblErrorMsg" Font-Bold="True"></asp:Label>&nbsp;
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="txtError" DisplayMode="List"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpCrawler" />
    <asp:CustomValidator ID="cvCrawler" runat="server" 
                   ErrorMessage="Please select .html/.htm file" ValidationGroup="grpCrawler" Display="None" 
                   ClientValidationFunction="getExtention" SetFocusOnError="true"
                   ControlToValidate="xslFileUpload" >
     </asp:CustomValidator>  
</fieldset> 
</td></tr>
</table>
</asp:Content>

