<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="GenerateMDBFile.aspx.cs" Inherits="Pages_ChequeProcessing_GenerateMDBFile" Title="Generating MDB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="popcalendar.js" >

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
                &nbsp; Generating Mdb File
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="7" style="height: 21px">
                &nbsp; &nbsp; &nbsp;<b><span style="background-color: #faebd7">Upload Files (Please
                    select valid files for ge</span>ner<span style="background-color: #faebd7">ating MIS)</span></b></td>
        </tr>
        <tr style="background-color: #faebd7">
            <td class="TableTitle" colspan="2" style="height: 29px">
                &nbsp;&nbsp; Valid <strong>MDB</strong></td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_ValidDBF" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_MDB" runat="server" ControlToValidate="FileUpload_ValidDBF"
                    ErrorMessage="Please select Valid ChequeMDB File" SetFocusOnError="True" ValidationGroup="ValidControls"
                    Width="18px">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr style="background-color: #faebd7">
            <td class="TableTitle" colspan="2" style="height: 29px; text-align: left">
                &nbsp;&nbsp; Invalid <strong>DBF</strong></td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload_InvalidDBF" runat="server" BorderColor="Maroon"
                    BorderWidth="1px" Height="25px" Width="485px" />
                <asp:RequiredFieldValidator ID="Rq_FileUpload_InvalidDBF" runat="server" ControlToValidate="FileUpload_InvalidDBF"
                    ErrorMessage="Please select invalid dbf File." SetFocusOnError="True" ValidationGroup="ValidControls"
                    Width="18px">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr style="background-color: #faebd7">
            <td class="TableTitle" colspan="2" style="height: 29px">
                &nbsp;&nbsp; Pickup Date</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:TextBox ID="txtPickupDate" runat="server" BorderColor="Maroon" BorderWidth="1px"
                    SkinID="txtSkin" Width="106px"></asp:TextBox>
                <img id="ImgDate3rdCall" alt="Calendar"
                        onclick="popUpCalendar(this, document.all.<%=txtPickupDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.png" style="width: 17px; height: 16px" /><asp:RequiredFieldValidator
                            ID="RQ_txtDepositFromDate" runat="server" ControlToValidate="txtPickupDate"
                            ErrorMessage="Please Enter Pickup Date" SetFocusOnError="True" ValidationGroup="ValidControls"
                            Width="9px">?</asp:RequiredFieldValidator></td>
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
                    Text="Upload " ValidationGroup="ValidControls" Width="85px" Font-Bold="False" />&nbsp;
            </td>
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
                &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnClose" runat="server" BorderWidth="1px" OnClick="btnClose_Click"
                    Text="Close" ToolTip="Back to Menu" Width="90px" /></td>
        </tr>
    </table>
</asp:Content>

