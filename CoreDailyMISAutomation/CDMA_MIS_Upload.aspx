<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDMA.Master" CodeBehind="CDMA_MIS_Upload.aspx.cs" Inherits="CoreDailyMISAutomation.CDMA_MIS_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript" src="App_Assets/js/popcalendar.js"></script>
    <script language="javascript" type="text/javascript">
        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <table style="width: 800px;">
        <tr>
            <td class="TableTitle" style="height: 40px" colspan="8">
                <span style="font-size: 13pt; font-weight: bold;">Upload MIS</span>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlFieldSelection" runat="server">
        <table style="width: 800px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblVertical" runat="server">Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtVertical" runat="server" Text="CPA" Enabled="false"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblSubVertical" runat="server">Sub Vertical</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlSubVertical" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlSubVertical_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblClientName" runat="server">Client Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlClientName" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
                </td>

                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblActivity" runat="server">Activity</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlActivity" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>   <%--OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged"--%>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblProduct" runat="server">Product</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlProduct" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblSubProduct" runat="server">Sub Product/process</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:DropDownList ID="ddlSubProduct" runat="server" Width="175px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:Label ID="lblMonthYear" runat="server">Month and Year</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:TextBox ID="txtMonthYear" runat="server" BorderWidth="1px" SkinID="txtSkin"
                        autocomplete="off" oncopy="return false" onpaste="return false" Width="150px"></asp:TextBox>
                    <img id="ImgAgreementExeDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtMonthYear.ClientID%>, 'mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                </td>
                <td class="TableTitle" style="height: 27px" colspan="4">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlRadioButton" runat="server">
        <table style="width: 800px;">
            <tr>
                <td align="center" class="TableTitle" style="height: 40px" colspan="8">
                    <asp:RadioButtonList ID="rdMIS" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdMIS_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem>Monthly MIS</asp:ListItem>
                        <asp:ListItem>Billing MIS</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlUploadMonthlyMIS" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
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
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click" />
                    <asp:Button ID="btnDownloadUploadFormat" runat="server" Text="Download Excel Upload Format" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="220px" OnClick="btnDownloadUploadFormat_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="xslFileUpload"
        Display="None" ErrorMessage="Select Import File" SetFocusOnError="True" ValidationGroup="validdata"></asp:RequiredFieldValidator>
    &nbsp;<asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="validdata" />

    <asp:Panel ID="pnlUploadBillingMIS" runat="server">
        <table style="width: 688px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 71px;" class="TableTitle">
                    <strong>Select File</strong>
                </td>
                <td style="width: 95px;" class="TableGrid">
                    <asp:FileUpload ID="FileUploadBilling" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="4">
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnImportBilling" runat="server" Text="Import" ValidationGroup="validdata"
                        BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnImportBilling_Click" />&nbsp;
                    <asp:Button ID="btnBackBilling" runat="server" Text="Back" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBackBilling_Click" />
                    <asp:Button ID="btnDownloadBilling" runat="server" Text="Download Excel Upload Format" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="220px" OnClick="btnDownloadBilling_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="xslFileUpload"
        Display="None" ErrorMessage="Select Import File" SetFocusOnError="True" ValidationGroup="validdata"></asp:RequiredFieldValidator>
    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="validdata" />
</asp:Content>
