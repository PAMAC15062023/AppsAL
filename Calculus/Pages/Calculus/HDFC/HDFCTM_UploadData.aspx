<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="HDFCTM_UploadData.aspx.cs" Inherits="Pages_Calculus_HDFC_HDFCTM_UploadData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form-horizontal">


      <%--  <p class="sign" style="padding: 0" align="center">
            Upload&nbsp; File
        </p>
        <br />--%>
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
                        <strong>Select File<span style="color : red"> *</span></strong>
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
                        <asp:Button ID="btnImport" runat="server" Text="Import" ValidationGroup="validdata" OnClick="btnImport_Click"
                            BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000" OnClick="btnCancel_Click"
                        BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" OnClick="btnBack_Click"
                        BorderWidth="1px" Font-Bold="False" Width="105px" />
                        <asp:Button ID="btnDownloadUploadFormat" runat="server" Text="Download Excel Upload Format" BorderColor="#400000" OnClick="btnDownloadUploadFormat_Click"
                            BorderWidth="1px" Font-Bold="False" Width="220px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>









    </form>




























</asp:Content>

