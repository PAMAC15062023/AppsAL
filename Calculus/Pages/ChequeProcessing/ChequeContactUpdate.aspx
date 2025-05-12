<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ChequeContactUpdate.aspx.cs" Inherits="Pages_ChequeProcessing_ChequeContactUpdate" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script  language="javascript" src="popcalendar.js" type="text/javascript"></script>
    <table cellpadding="2" cellspacing="2" style="width: 804px">
        <tr>
            <td colspan="7" style="height: 24px">
                <asp:Label ID="lblMessage" runat="server" BackColor="Transparent" CssClass="ErrorMessage"
                    Font-Bold="True" ForeColor="Red" Width="100%" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 24px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Val_ChequeNo" />
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7">
                &nbsp; Contact No Update Screen</td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Pickup Date</td>
            <td class="tabs1">
                <table cellpadding="0" cellspacing="0" style="width: 114px">
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="txtPickupdate" runat="server" BorderWidth="1px" Width="87px"></asp:TextBox></td>
                        <td style="width: 100px">
                            &nbsp;<img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPickupdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.png" style="width: 17px; height: 16px" /></td>
                        <td style="width: 100px; text-align: center">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="Red"
                                BorderStyle="None" ControlToValidate="txtPickupdate" ErrorMessage="Please enter Pickup Date to Continue"
                                ForeColor="White" ValidationGroup="Val_ChequeNo" Width="17px" Height="16px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 155px">
                </td>
            <td>
                &nbsp;</td>
            <td style="width: 978px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Cheque No" Width="118px"></asp:Label></td>
            <td class="tabs1">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 118px">
                    <tr>
                        <td style="width: 100px; height: 13px">
                            <asp:TextBox ID="txtChequeNo" runat="server" BorderWidth="1px" ValidationGroup="Val_ChequeNo"
                                Width="85px"></asp:TextBox></td>
                        <td style="width: 100px; height: 13px; text-align: center">
                            <asp:RequiredFieldValidator ID="rq_ChequeNo" runat="server" BackColor="Red" BorderStyle="None"
                                ControlToValidate="txtChequeNo" ErrorMessage="Please enter Cheque No to Continue"
                                ForeColor="White" ValidationGroup="Val_ChequeNo" Width="18px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td style="width: 155px">
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Width="79px" BorderWidth="1px" OnClick="btnSearch_Click" ValidationGroup="Val_ChequeNo" /></td>
            <td style="text-align: center">
            </td>
            <td style="width: 978px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td style="width: 100px">
            </td>
            <td>
            </td>
            <td style="width: 155px">
            </td>
            <td>
            </td>
            <td style="width: 978px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Bank Name</td>
            <td class="tabs1">
                <asp:TextBox ID="txtBankName" runat="server" BorderWidth="1px" ReadOnly="True" Width="136px"></asp:TextBox></td>
            <td class="TableTitle" style="width: 155px">
                &nbsp;Cheque Amt</td>
            <td class="tabs1">
                <asp:TextBox ID="txtChequeAmt" runat="server" BorderWidth="1px" ReadOnly="True" Width="136px"></asp:TextBox></td>
            <td style="width: 978px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Cheque Date</td>
            <td class="tabs1">
                <asp:TextBox ID="txtChequeDate" runat="server" BorderWidth="1px" ReadOnly="True"
                    Width="136px"></asp:TextBox></td>
            <td class="TableTitle" style="width: 155px">
                &nbsp;Reason</td>
            <td class="tabs1">
                <asp:TextBox ID="txtReason" runat="server" BorderWidth="1px" ReadOnly="True" Width="134px"></asp:TextBox></td>
            <td style="width: 978px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px">
            </td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Contact No</td>
            <td class="tabs1">
                <asp:TextBox ID="txtContactNo" runat="server" BorderWidth="1px" Width="135px"></asp:TextBox></td>
            <td style="width: 155px" class="TableTitle">
                &nbsp;Receipt No</td>
            <td class="tabs1">
                <asp:TextBox ID="txtReceiptNo" runat="server" BorderWidth="1px" Width="132px"></asp:TextBox></td>
            <td style="width: 978px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 7px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
                </td>
            <td style="height: 26px">
                <asp:HiddenField ID="hdnTableID" runat="server" />
                </td>
            <td style="width: 155px; height: 26px">
            </td>
            <td style="height: 26px">
            </td>
            <td style="width: 978px; height: 26px">
            </td>
            <td style="width: 100px; height: 26px">
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Update" BorderWidth="1px" OnClick="btnSave_Click" ValidationGroup="Val_ChequeNo" Width="92px" />
                <asp:Button ID="btnCancel" runat="server" Text="Close" BorderWidth="1px" OnClick="btnCancel_Click" Width="92px" /></td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="7">
            </td>
        </tr>
    </table>
</asp:Content>

