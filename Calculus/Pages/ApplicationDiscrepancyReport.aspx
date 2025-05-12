<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationDiscrepancyReport.aspx.cs" Inherits="Pages_ApplicationDiscrepancyReport" Title="Discrepancy Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="popcalendar.js">
</script>
    <table style="width: 100%">
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="6">
                &nbsp;Discrepancy Report</td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
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
        <tr>
            <td class="TableTitle" style="width: 100px">
                &nbsp; Source Branch</td>
            <td class="TableTitle" style="width: 100px">
                Application From Date</td>
            <td class="TableTitle" style="width: 100px">
                &nbsp;Application To Date</td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSourceBranch" runat="server" Font-Size="Small">
                    <asp:ListItem>(Select)</asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" Font-Size="Small" MaxLength="10" Width="113px"></asp:TextBox><img
                    id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.gif" /></td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" Font-Size="Small" MaxLength="10"
                    Width="113px"></asp:TextBox><img id="ImgDOB1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" /></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 17px">
                &nbsp;&nbsp;<asp:Button ID="btnGetReport" runat="server" OnClick="btnGetReport_Click" 
                    Text="Generate" />
                </td>
        </tr>
        <tr>
            <td colspan="6">
                <table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="true" width="100%">
                    <tr>
                        <td style="height: 13px">
                            <asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 26px">
                &nbsp;<asp:Button ID="btnRetrive" runat="server" OnClick="btnRetrive_Click" 
                    Text="Export to Excel" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="53px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" /></td>
        </tr>
        <tr>
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
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

