<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="DataPurge.aspx.cs" Inherits="LNTFinance.Pages.DataPurge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="../App_Assets/js/popcalendar.js"></script>
    <table style="width: 907px">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4" style="height: 22px">&nbsp;Data Purging
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 100px">
                <strong>Till Date</strong>
            </td>
            <td class="TableGrid" style="width: 201px">
                <table cellpadding="0" cellspacing="0" style="width: 87px">
                    <tr>
                        <td style="width: 100px; height: 22px">
                            <asp:TextBox ID="txtTillDate" runat="server" BorderWidth="1px" SkinID="txtSkin"
                                Width="72px"></asp:TextBox>
                        </td>
                        <td style="width: 100px; height: 22px">&nbsp;
                        </td>
                        <td style="width: 100px; height: 22px">
                            <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtTillDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="TableTitle" colspan="4" style="height: 34px">&nbsp;
                <asp:Button ID="btnTruncate" runat="server" BorderWidth="1px" Text="Purge" BackColor="Red" OnClientClick="return confirm('Are you sure, you want to purge data? This action cannot be reversed and will clear all data Till Date mentioned ...!!');" OnClick="btnTruncate_Click" />&nbsp;
                <asp:Button ID="btnBack" runat="server" BorderWidth="1px" Text="Back" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
