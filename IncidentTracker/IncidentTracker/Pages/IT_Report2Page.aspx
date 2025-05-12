<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/IncidentTracker.Master" AutoEventWireup="true" CodeBehind="IT_Report2Page.aspx.cs" Inherits="IncidentTracker.Pages.IT_Report2Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    Report&nbsp;2</span>
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
                <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Incident Number</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtIncidentNumber" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8"></td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Button ID="btnSearch" runat="server" Text="Search" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnSearch_Click" />
            </td>
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
             &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="105px" />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    OnClick="btnBack_Click" Font-Bold="False" Width="105px" />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table style="width: 900px;">
        <asp:GridView ID="gvDataShow" HeaderStyle-BackColor="#099df3" HeaderStyle-ForeColor="Black"
            runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="RowName" HeaderText="RowName" ItemStyle-Width="50px" />
                <asp:BoundField DataField="RowName2" HeaderText="RowName2" ItemStyle-Width="150px" />
            </Columns>
        </asp:GridView>
    </table>
</asp:Content>
