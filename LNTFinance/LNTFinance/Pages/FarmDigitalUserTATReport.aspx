<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/LNT_CommonMaster.Master" AutoEventWireup="true" CodeBehind="FarmDigitalUserTATReport.aspx.cs" Inherits="LNTFinance.Pages.FarmDigitalUserTATReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


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
                <span style="font-size: 13pt; font-weight: bold;">Farm&nbsp;Digital&nbsp;User&nbsp;TAT&nbsp;Report</span>
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
    <asp:UpdatePanel ID="UP_ddlUserName" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table style="width: 688px;">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Report Type</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlReportType" runat="server" Width="150px">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem Value="LNT_GetFarmDigitalUserTATReport_SP">TAT Report</asp:ListItem>
                            <asp:ListItem Value="LNT_DailyProductivityMIS_SP">Productivity Report</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">User ID</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:DropDownList ID="ddlUserID" runat="server" Width="150px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">From Date</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                        <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                    </td>
                </tr>
                <tr>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">To date</asp:Label>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                        <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                            src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="150px" />&nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000"
                BorderWidth="1px" Font-Bold="False" Width="105px" Visible="false" OnClick="btnExport_Click"/>&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnBack_Click"/>&nbsp;
            </td>
        </tr>
    </table>
     <br />
    <table style="width: 688px;">
        <tr>
            <td class="TableHeader" colspan="9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:GridView ID="gvData" runat="server" Height="16px" Width="1200px" CssClass="mGrid">
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
