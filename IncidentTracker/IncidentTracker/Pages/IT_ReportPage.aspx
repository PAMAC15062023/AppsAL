<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/IncidentTracker.Master" AutoEventWireup="true" CodeBehind="IT_ReportPage.aspx.cs" Inherits="IncidentTracker.Pages.IT_ReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="../App_Assets/js/popcalendar.js"></script>

    <script language="javascript" type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Report&nbsp;1</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">From Date</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 20px" class="TableTitle">
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../images/SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">To date</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td style="width: 100px" class="TableTitle">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../images/SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <asp:Button ID="btnSearch" runat="server" Text="Search" BorderColor="#400000" OnClick="btnSearch_Click"
                 BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000" OnClick="btnExport_Click"
                    BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px" OnClick="btnBack_Click"
                    Font-Bold="False" Width="105px" />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table style="width: 900px;">
        <asp:GridView ID="gvDataShow" HeaderStyle-BackColor="#099df3" HeaderStyle-ForeColor="Black"
            runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="SrNo" ItemStyle-Width="50px" />
                <asp:BoundField DataField="Incident Number" HeaderText="Incident Number" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Incident Date & Time:" HeaderText="Incident Date & Time:" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Incident Description" HeaderText="Incident Description" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Severity" HeaderText="Severity" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Users/BU Impacted" HeaderText="Users/BU Impacted" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Impact Cost" HeaderText="Impact Cost" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Duration Of Incident" HeaderText="Duration Of Incident" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Root/Reason For Incident" HeaderText="Root/Reason For Incident" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Remidial Action" HeaderText="Remidial Action" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Result Of Remedial Action" HeaderText="Result Of Remedial Action" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Long Term Solution" HeaderText="Long Term Solution" ItemStyle-Width="150px" />
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>
