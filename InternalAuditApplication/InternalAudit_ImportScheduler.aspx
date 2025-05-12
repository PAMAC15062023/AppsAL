<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/InternalAudit.Master" CodeBehind="InternalAudit_ImportScheduler.aspx.cs" Inherits="InternalAuditApplication.InternalAudit_ImportScheduler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">Upload&nbsp; File</span>
            </td>
        </tr>
    </table>

    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 71px;" class="TableTitle">
                    <strong>Select File</strong>
                </td>
                <td style="width: 95px;" class="TableGrid">
                    <asp:FileUpload ID="xslFileUpload" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="4">
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnImport" runat="server" Text="Import" ValidationGroup="validdata"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnImport_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click1"/>
                     <asp:Button ID="btnDownloadUploadFormat" runat="server" Text="Download Excel Upload Format" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="220px" OnClick="btnDownloadUploadFormat_Click"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="xslFileUpload"
        Display="None" ErrorMessage="Select Import File" SetFocusOnError="True" ValidationGroup="validdata"></asp:RequiredFieldValidator>
    &nbsp;<asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="validdata" />
</asp:Content>