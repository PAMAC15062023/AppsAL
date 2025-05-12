<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Pages_CFS_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../popcalendar.js"></script>

    <asp:Panel ID="pnlproduct" runat="server">
        <table style="width: 688px; height: 40px;">
            <tr>
                <td class="TableHeader" colspan="4" style="width: 690px;">&nbsp;Reports &nbsp; 
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlAL" runat="server">
        <table style="width: 688px; height: 123px;">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">From Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px"></td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">To Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                <td style="width: 100px" class="TableTitle">
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <strong>Select Reports Type</strong>
                </td>
                <td class="TableGrid" style="width: 95px;">
                    <asp:DropDownList ID="ddlcustomerType" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="--Selete--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Vertical Report" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DCH Report" Value="2"></asp:ListItem>
                        <asp:ListItem Text="DCH Team Report" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Consolidated Report" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Score Report" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvcustomerDetails" runat="server" AutoGenerateColumns="true">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <table>
        <tr>
            <td class="TableTitle" colspan="4">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="Export" Visible="false" OnClick="btnExport_Click"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;
                    <asp:Button ID="btnCalcel" runat="server" Text="Cancel" BorderColor="#400000" BorderWidth="1px"
                        Font-Bold="False" Width="105px" OnClick="btnCalcel_Click" />
            </td>
        </tr>
    </table>

    <asp:ValidationSummary ID="validdata" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="validdata" />
    <asp:HiddenField ID="hfReportTypes" runat="server" />

</asp:Content>

