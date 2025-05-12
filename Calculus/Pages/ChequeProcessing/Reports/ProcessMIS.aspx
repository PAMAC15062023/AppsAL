<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProcessMIS.aspx.cs" Inherits="Pages_ChequeProcessing_Reports_ProcessMIS"
    Title="Final Process MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../popcalendar.js" type="text/javascript">
    </script>

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
                &nbsp;Processing MIS
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 21px">
                &nbsp; &nbsp; &nbsp;<b>Upload Files (Please select valid files for generating MIS)</b></td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 29px" colspan="2">
                &nbsp;&nbsp; Valid MDB
            </td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_MDB" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_MDB" runat="server" ControlToValidate="FileUpload_MDB"
                    ErrorMessage="Please select Valid ChequeMDB File" SetFocusOnError="True" ValidationGroup="ValidControls">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2" style="height: 29px">
                &nbsp; &nbsp;UpCountry DBF</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_Upcoutry" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_UpcountryDBF" runat="server" ControlToValidate="FileUpload_Upcoutry"
                    ErrorMessage="Please select UpCountry DBF File" SetFocusOnError="True" ValidationGroup="ValidControls">?</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2">
                &nbsp;&nbsp; Suspense Bounce Excel &nbsp;</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_Suspense" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="RQ_InvalidDBF" runat="server" ControlToValidate="FileUpload_Suspense"
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
                    ErrorMessage="Please select Other DBF File" SetFocusOnError="True" ValidationGroup="ValidControls">?</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="2">
                &nbsp;&nbsp; PDC Report Excel</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_PDCReport" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_FileUpload_PDCReport" runat="server" ControlToValidate="FileUpload_PDCReport"
                    ErrorMessage="Please select PDC Report Excel File" SetFocusOnError="True" ValidationGroup="ValidControls">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 29px" colspan="2">
                &nbsp;&nbsp; Pickup Date
               </td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:TextBox ID="txtDepositFromDate" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    SkinID="txtSkin" Width="106px"></asp:TextBox>
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../SmallCalendar.png" style="width: 17px; height: 16px" />&nbsp;
                      <asp:RequiredFieldValidator ID="RQ_txtDepositFromDate" runat="server" ControlToValidate="txtDepositFromDate"
                    ErrorMessage="Please Enter Pickup Date" SetFocusOnError="True" ValidationGroup="ValidControls" Width="9px">?</asp:RequiredFieldValidator>
           
                    </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 22px;">
                &nbsp; &nbsp;
                <asp:CheckBox ID="chkFileUploaded" runat="server" Font-Bold="True" Text="Already  Uploaded the DBF Files"
                    Width="419px" /></td>
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
                    Text="Upload All" Width="85px" ValidationGroup="ValidControls" /></td>
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
            <td class="TableTitle" colspan="7" style="height: 33px">
                &nbsp; &nbsp;
                <asp:Button ID="btnGenerateReport" runat="server" BorderWidth="1px" OnClick="btnExport_Click"
                    Text="Generate" Width="122px" />
                <asp:Button ID="btnClose" runat="server" BorderWidth="1px" OnClick="btnClose_Click"
                    Text="Close" ToolTip="Back to Menu" Width="90px" /></td>
        </tr>
    </table>
</asp:Content>
