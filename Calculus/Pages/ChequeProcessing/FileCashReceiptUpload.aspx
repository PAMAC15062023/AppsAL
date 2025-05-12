<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="FileCashReceiptUpload.aspx.cs" Inherits="Pages_ChequeProcessing_FileCashReceiptUpload" Title="Cash Upload Validation" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="popcalendar.js">
</script>
<script language="javascript" type="text/javascript" >
    

</script>
    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 16px" class="TableHeader">
                &nbsp;Cash Upload Validation
            </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 125px;" class="TableTitle">
                &nbsp;Upload Excel File</td>
            <td colspan="4" style="height: 16px">
                <asp:FileUpload ID="FileUpload_ValidExcel" runat="server" BorderWidth="1px" Width="394px" /></td>
            <td style="width: 100px; height: 16px;">
            </td>
            <td style="width: 100px; height: 16px;">
            </td>
        </tr>
        <tr>
            <td style="width: 125px; height: 15px;" class="TableTitle">
                &nbsp;Pickup Date</td>
            <td style="height: 15px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 112px">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtPickupDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="71px"></asp:TextBox></td>
                        <td style="width: 100px">
                            <img
                    id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px">
                            <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPickupDate"
                        ErrorMessage="Please Enter Pickup Date" SetFocusOnError="True" ValidationGroup="ValidControls"
                        Width="9px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 15px;" class="TableTitle">
                Deposit Date</td>
            <td style="width: 100px; height: 15px;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 72%">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtDepositFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                    Width="72px"></asp:TextBox></td>
                        <td style="width: 100px">
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.png" style="width: 17px; height: 16px" />&nbsp;
                        </td>
                        <td style="width: 100px">
                <asp:RequiredFieldValidator ID="RQ_txtDepositFromDate" runat="server" ControlToValidate="txtDepositFromDate"
                    ErrorMessage="Please Enter Pickup Date" SetFocusOnError="True" ValidationGroup="ValidControls"
                    Width="9px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="height: 28px;" class="TableTitle" colspan="7">
                &nbsp;<asp:Button ID="btnUpload" runat="server" BorderWidth="1px" Text="Upload" Width="82px" OnClick="btnUpload_Click" />&nbsp;</td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp; Cash Receipt List</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="800px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvUploadedDATA" runat="server" CssClass="GridViewStyle" Height="100px"
                                    Width="98%">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 33px;" class="TableTitle" colspan="7">
                &nbsp;
                <asp:Button ID="btnGenerate" runat="server" BorderWidth="1px" Text="Generate" Width="82px" OnClick="btnGenerate_Click" />
                <asp:Button
                    ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="82px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 125px">
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

