<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerMasterUpload.aspx.cs" Inherits="Pages_CFS_CustomerMasterUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;IMPORT&nbsp; CUSTOMER MASTER
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMsgXls1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 71px;">
                    <strong>Select File</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:FileUpload ID="fuDataFile" runat="server" accept=".xls,.XLS,.xlsx,.XLSX" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuDataFile"
                        Display="None" ErrorMessage="Select Import File" SetFocusOnError="True" ValidationGroup="validdata"></asp:RequiredFieldValidator>
                    &nbsp;<asp:HiddenField ID="hdnrows" runat="server" />
                    <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="fuDataFile"
                        ErrorMessage="Only XLS are allowed" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.xls|.XLS|.xlsx|.XLSX)$"
                        ValidationGroup="validdata">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="4">
                    <asp:Button ID="btnImport" runat="server" Text="Import" ValidationGroup="validdata" OnClick="btnImport_Click"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px"  />&nbsp;
                    <asp:Button ID="btnCalcel" runat="server" Text="Cancel" BorderColor="#400000" BorderWidth="1px"
                        Font-Bold="False" Width="105px" OnClick="btnCalcel_Click"  />
                </td>
            </tr>
            <tr>
                <td>                     
                    <asp:Button ID="btnImportNew" runat="server" Text="Import New" Visible="false"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px"  />&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="validdata" />
</asp:Content>

