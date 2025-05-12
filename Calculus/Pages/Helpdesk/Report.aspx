<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Report.aspx.cs" StylesheetTheme="SkinFile" Inherits="Pages_Helpdesk_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="popcalendar.js"></script>
    <script language="JAVASCRIPT" type="text/javascript">
</script>
    <table style="width: 100%;">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
                <asp:Label ID="Label1" runat="server" BackColor="#FFFFCC" Font-Bold="True"
                    Text="lblmsgstatus" Visible="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4" style="height: 22px">HelpDesk
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td style="width: 84px" class="TableTitle">
                <strong>Select Resport Type</strong>
            </td>
            <td style="width: 13px" class="TableGrid">
                <asp:DropDownList ID="ddlResportType" runat="server" CssClass="Masterbody" Height="22px"
                    SkinID="ddlSkin" Width="133px">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Reports" Value="1"></asp:ListItem>
                    <asp:ListItem Text="TicketHistory" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 68px" class="TableTitle"></td>
            <td style="width: 13px" class="TableGrid">
            </td>
        </tr>
        <tr>
            <td style="width: 165px" class="TableTitle"><strong>From Date</strong></td>
            <td style="width: 165px" class="TableGrid">
                <asp:TextBox ID="txtFromDate" runat="server" Width="125px" Height="16px"></asp:TextBox>
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../ChequeProcessing/SmallCalendar.png" style="width: 17px; height: 16px" /></td>
            <td style="width: 140px" class="TableTitle"><strong>To date</strong></td>
            <td style="width: 315px" class="TableGrid">
                <asp:TextBox ID="txtToDate" runat="server" Width="125px" Height="16px"></asp:TextBox>
                <img id="ImgDate3rdCall0" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../ChequeProcessing/SmallCalendar.png"
                    style="width: 17px; height: 16px" /></td>
        </tr>
        <tr>
            <td style="width: 84px" class="TableTitle">
                <strong>Status</strong>
            </td>
            <td style="width: 13px" class="TableGrid">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="Masterbody" Height="22px"
                    SkinID="ddlSkin" Width="133px">
                </asp:DropDownList>
            </td>
            <td style="width: 68px" class="TableTitle">
                <strong>Location</strong>:
            </td>
            <td style="width: 13px" class="TableGrid">
                <asp:DropDownList ID="ddlbranch" runat="server" Height="22px" SkinID="ddlSkin" Width="133px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 34px;" class="TableTitle" colspan="11">&nbsp;&nbsp;
                <asp:Button ID="btnsearch" runat="server" Text="Search" Width="94px" OnClick="btnsearch_Click" />
                <asp:Button ID="btnExporttoExcel" runat="server" BorderColor="Black" BorderWidth="1px"
                    OnClick="btnExporttoExcel_Click" Text="Export" Width="94px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="90px" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 68px">&nbsp;
            </td>
            <td style="width: 13px">&nbsp;
            </td>
            <td style="width: 30px">&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                    <Columns>
                        <asp:BoundField DataField="branchname" HeaderText="Branch" />
                        <asp:BoundField DataField="ticketno" HeaderText="Ticket Number" />
                        <asp:BoundField DataField="Date" HeaderText="Ticket Date" />
                        <asp:BoundField DataField="Username" HeaderText="Requested By" />
                        <asp:BoundField DataField="department" HeaderText="Department" />
                        <asp:BoundField DataField="problemtypename" HeaderText="Problem Name" />
                        <asp:BoundField DataField="problemdetailsname" HeaderText="Problem Details" />
                        <asp:BoundField DataField="remark" HeaderText="Remark" />
                        <asp:BoundField DataField="ticketStatus" HeaderText="Status" />
                        <asp:BoundField DataField="AssignedBy" HeaderText="Assigned By" />
                        <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To" />
                        <asp:BoundField DataField="TAT" HeaderText="TAT(Days)" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
