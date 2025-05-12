<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ChequeUploadFILES.aspx.cs" Inherits="Pages_ChequeProcessing_ChequeUploadFILES" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="1">
        <tr>
            <td colspan="7" style="height: 13px">
                <asp:Label ID="lblMessage" runat="server" BackColor="Transparent" CssClass="ErrorMessage"
                    Font-Bold="True" ForeColor="Red" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 13px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidControls" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" headers="Y" style="height: 20px">
                &nbsp; Upload DBF Files</td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 21px">
                &nbsp; &nbsp; &nbsp;<b>Upload Files (Please select valid files for gener<span style="background-color: #faebd7">ating
                    MIS)</span></b></td>
        </tr>
        <tr style="background-color: #faebd7">
            <td class="TableTitle" colspan="2" style="height: 29px">
                &nbsp;&nbsp; Valid DBF
            </td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_ValidDBF" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_MDB" runat="server" ControlToValidate="FileUpload_ValidDBF"
                    ErrorMessage="Please select Valid ChequeMDB File" SetFocusOnError="True" ValidationGroup="ValidControls" Width="18px">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2" style="height: 29px">
                &nbsp; &nbsp;UpCountry DBF</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_Upcoutry" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_UpcountryDBF" runat="server" ControlToValidate="FileUpload_Upcoutry"
                    ErrorMessage="Please select UpCountry DBF File" SetFocusOnError="True" ValidationGroup="ValidControls" Width="12px">?</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2">
                &nbsp; &nbsp;Invalid DBF&nbsp;</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_InvalidDBF" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="RQ_InvalidDBF" runat="server" ControlToValidate="FileUpload_InvalidDBF"
                    ErrorMessage="Please select Invalid DBF File" SetFocusOnError="True" ValidationGroup="ValidControls">?</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2" style="height: 17px">
                &nbsp;&nbsp; OtherBank DBF</td>
            <td colspan="5" style="height: 17px">
                &nbsp;<asp:FileUpload ID="FileUpload_OtherBankDBF" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_OtherBankDBF" runat="server" ControlToValidate="FileUpload_OtherBankDBF"
                    ErrorMessage="Please select Other DBF File" SetFocusOnError="True" ValidationGroup="ValidControls" Width="11px">?</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2" style="height: 17px">
                &nbsp;&nbsp; Return DBF</td>
            <td colspan="5" style="height: 17px">
                &nbsp;<asp:FileUpload ID="FileUpload_ReturnDBF" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload_ReturnDBF"
                    ErrorMessage="Please select return DBF File" SetFocusOnError="True" ValidationGroup="ValidControls"
                    Width="11px">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 120px">
            </td>
            <td>
            </td>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 35px">
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload" runat="server" BorderWidth="1px" Height="25px" OnClick="btnUpload_Click"
                    Text="Upload All" ValidationGroup="ValidControls" Width="85px" /></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="800px">
                    <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0" visible="true"
                        width="100%">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 33px">
                &nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClose" runat="server" BorderWidth="1px" OnClick="btnClose_Click"
                    Text="Close" ToolTip="Back to Menu" Width="90px" /></td>
        </tr>
    </table>
</asp:Content>

